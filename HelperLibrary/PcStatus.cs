﻿using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using static HelperLibrary.TranslationManager;
using System.Windows.Forms;
using System.Diagnostics;

namespace TaskSchedulerApp.BackgroundClasses
{
    public static class PcStatus
    {
        // Öffentliche Felder für die Statuswerte
        public static bool IsShuttingDown { get; set; } = false;
        public static bool IsGoingToSleep { get; set; } = false;
        public static bool IsProgramOpen { get; set; } = false;
        public static bool IsJustBooted { get; set; } = false;
        public static bool IsUserInactive { get; set; } = false;
        public static bool IsPcLightlyLoaded { get; set; } = false;
        public static bool AreProgramsOpen { get; set; } = false;

        // CancellationTokenSource, um alle Hintergrund-Tasks bei Bedarf zu stoppen.
        private static CancellationTokenSource? _cts;

        /// <summary>
        /// Startet die asynchrone Überwachung aller relevanten PC-Statuswerte.
        /// Die übergebenen Parameter definieren dabei die jeweiligen Schwellenwerte.
        /// </summary>
        /// <param name="bootThreshold">Zeitspanne, unter der der PC als „gerade hochgefahren“ gilt.</param>
        /// <param name="inactivityThreshold">Zeitspanne, ab der der Nutzer als inaktiv betrachtet wird.</param>
        /// <param name="cpuUsageThreshold">CPU-Auslastungsschwelle, unter der der PC als „leicht ausgelastet“ gilt.</param>
        /// <param name="processNames">Liste von Prozessen, die überwacht werden (gilt: mindestens einer läuft).</param>
        /// <param name="specificProgramName">Name eines bestimmten Programms, dessen Status ebenfalls überwacht werden soll.</param>
        public static async Task StartMonitoring(
            TimeSpan bootThreshold,
            TimeSpan inactivityThreshold,
            float cpuUsageThreshold,
            string[] processNames,
            string specificProgramName)
        {
            _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;

            _ = Task.Run(async () =>
            {
                Logger.Log("Async uptime started");
                while (!token.IsCancellationRequested)
                {
                    Logger.Log("Async uptime read");
                    long uptimeMilliseconds = Environment.TickCount64;
                    IsJustBooted = uptimeMilliseconds < bootThreshold.TotalMilliseconds;
                    await Task.Delay(1000, token);
                }
                
            }, token);

            _ = Task.Run(async () =>
            {
                Logger.Log("Async inactive started");
                while (!token.IsCancellationRequested)
                {
                    Logger.Log("Async inactive read");
                    try
                    {
                        LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
                        lastInputInfo.cbSize = (uint)Marshal.SizeOf(typeof(LASTINPUTINFO));

                        // Ruft die Zeit der letzten Eingabe ab
                        if (!GetLastInputInfo(ref lastInputInfo))
                        {
                            throw new Exception("Fehler beim Aufrufen von GetLastInputInfo.");
                        }

                        // Berechnet die seit der letzten Eingabe vergangene Zeit in Millisekunden
                        uint letzteEingabe = lastInputInfo.dwTime;
                        uint aktuelleZeit = (uint)Environment.TickCount;
                        uint inaktiveZeitInMillisekunden = aktuelleZeit - letzteEingabe;

                        // Prüft, ob die inaktive Zeit die angegebene Schwelle überschreitet
                        IsUserInactive = (inaktiveZeitInMillisekunden / 1000) >= 5;
                    }
                    catch
                    {
                        Logger.Log("Async inactive ERROR");
                        Environment.Exit(0);
                    }
                    await Task.Delay(1000, token);
                }
            }, token);

            //_ = Task.Run(async () =>
            //{
            //    IsUserInactive = true;
            //}, token);

            _ = Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    Logger.Log("Perfomance Counter Started");
                    try
                    {
                        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        {
                            using (PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
                            {
                                // Initialer Aufruf liefert oft 0, daher kurzes Warten
                                cpuCounter.NextValue();
                                await Task.Delay(1000, token);
                                float currentCpuUsage = cpuCounter.NextValue();
                                IsPcLightlyLoaded = currentCpuUsage < cpuUsageThreshold;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log("Fehler beim Abrufen der CPU-Auslastung: " + ex.Message);
                        IsPcLightlyLoaded = false;
                    }
                    await Task.Delay(1000, token);
                }
            }, token);

            _ = Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    Logger.Log("Get Current Process");
                    bool open = false;
                    try
                    {
                        var processes = Process.GetProcesses();
                        foreach (var proc in processes)
                        {
                            try
                            {
                                string procName = proc.ProcessName;
                                foreach (string target in processNames)
                                {
                                    string targetName = Path.GetFileNameWithoutExtension(target);
                                    if (string.Equals(procName, targetName, StringComparison.OrdinalIgnoreCase))
                                    {
                                        open = true;
                                        break;
                                    }
                                }
                                if (open)
                                    break;
                            }
                            catch { continue; }
                        }
                    }
                    catch { /* Fehler ggf. loggen */ }
                    AreProgramsOpen = open;
                    await Task.Delay(1000, token);
                }
            }, token);

            _ = Task.Run(async () =>
            {
                Logger.Log("Get Current Processes");
                while (!token.IsCancellationRequested)
                {
                    bool open = false;
                    try
                    {
                        // Sucht nach einem bestimmten Prozess
                        var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(specificProgramName));
                        open = processes.Any();
                    }
                    catch { /* Fehler ggf. loggen */ }
                    IsProgramOpen = open;
                    await Task.Delay(1000, token);
                }
            }, token);

            // Hinweis: Da die Tasks in Dauerschleifen laufen, beendet sich diese Methode nicht von selbst.
            // Sie kann ggf. als Starter-Methode betrachtet werden.
            await Task.CompletedTask;
        }

        #region Systemereignis-Handler

        /// <summary>
        /// Wird aufgerufen, wenn eine Abmeldung oder ein Shutdown initiiert wird.
        /// Setzt den Shutdown-Status.
        /// </summary>
        public static void OnSessionEnding(object sender, SessionEndingEventArgs e)
        {
            Logger.Log("Pc shutdown");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                e.Cancel = true;
            }
            IsShuttingDown = true;
        }

        /// <summary>
        /// Reagiert auf Änderungen im Stromversorgungsmodus (Suspend/Resume) und setzt den Schlafstatus.
        /// </summary>
        public static void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            Logger.Log("PowerModeChanged");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (e.Mode == PowerModes.Suspend)
                {
                    IsGoingToSleep = true;
                }
                else if (e.Mode == PowerModes.Resume)
                {
                    IsGoingToSleep = false;
                }
            }
            
        }

        #endregion

        /// <summary>
        /// Stoppt alle Hintergrund-Überwachungsschleifen.
        /// </summary>
        public static void StopMonitoring()
        {
            Logger.Log("Monitoring Stopped");
            if (_cts != null)
            {
                _cts.Cancel();
                _cts = null;
            }
        }

        #region Native Methoden für Nutzerinaktivität

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        // Struktur für die letzte Eingabeinformation
        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }
        #endregion
    }
}
