using Newtonsoft.Json;
using System.Diagnostics;
using TaskClasses;

namespace HelperLibrary
{
    /// <summary>
    /// Stellt die Konfigurationseinstellungen für die Taskmanager-Anwendung bereit.
    /// Beinhaltet Eigenschaften wie Zeitstempel, Sprache, Konsolenfarbe, Presets und geplante Tasks.
    /// Bietet Methoden zum Laden und Speichern der Einstellungen.
    /// </summary>
    public class Config
    {
        public DateTime TimeStamp { get; set; }
        public string? Language { get; set; } = null;
        public ConsoleColor ConsoleColorStr { get; set; }
        public List<MainTask> Presets { get; set; }
        public List<MainTask> PlannedTasks { get; set; }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Config"/>-Klasse.
        /// Initialisiert dabei die Listen für Presets und geplante Tasks.
        /// </summary>
        public Config()
        {
            Presets = new List<MainTask>();
            PlannedTasks = new List<MainTask>();
        }

        /// <summary>
        /// Lädt die Konfigurationseinstellungen aus der Datei "settings.taskmanager".
        /// Falls die Datei nicht existiert, wird sie erstellt.
        /// </summary>
        /// <returns>
        /// Ein <see cref="Config"/>-Objekt mit den geladenen Einstellungen oder null, wenn die Deserialisierung fehlschlägt.
        /// </returns>
        public static Config? GetSettings()
        {
            if (!File.Exists("settings.taskmanager"))
            {
                Logger.Log("settings.taskmanager created.");
                File.Create("settings.taskmanager");
            }

            string fileContent = ReadFile();

            Config? settings = JsonConvert.DeserializeObject<Config>(fileContent);
            Logger.Log("settings.taskmanager loaded.");
            return settings;
        }

        /// <summary>
        /// Speichert die Konfigurationseinstellungen in der Datei "settings.taskmanager".
        /// Es werden nur die übergebenen Parameter aktualisiert, während bestehende Einstellungen erhalten bleiben.
        /// </summary>
        /// <param name="language">Optional: Die neue Spracheinstellung.</param>
        /// <param name="consoleColor">Optional: Die neue Konsolenfarbe.</param>
        /// <param name="presets">Optional: Die neue Liste der Preset-Tasks.</param>
        /// <param name="plannedTasks">Optional: Die neue Liste der geplanten Tasks.</param>
        public static void SaveSettings(string? language = null,
            ConsoleColor? consoleColor = null,
            List<MainTask>? presets = null,
            List<MainTask>? plannedTasks = null)
        {
            Config? settings;

            if (GetSettings() != null)
            {
                settings = GetSettings();
            }
            else
            {
                settings = new();
                Logger.Log("New settings created");
            }

            if (settings != null)
            {
                settings.TimeStamp = DateTime.Now;

                if (language != null)
                    settings.Language = language;
                if (consoleColor != null)
                    settings.ConsoleColorStr = (ConsoleColor)consoleColor;
                if (presets != null)
                    settings.Presets = presets;
                if (plannedTasks != null)
                    settings.PlannedTasks = plannedTasks;
            }

            if (!File.Exists("settings.taskmanager"))
            {
                File.Create("settings.taskmanager");
            }

            var content = JsonConvert.SerializeObject("");
            //TODO: Fix this (AUTOTASKS)
            string[] basicTasks = ["OpenMail", "Calculator", "Browser", "LockInactiv"];

            if (plannedTasks != null)
            {
                for (int i = 0; i < plannedTasks.Count; i++)
                {
                    if (basicTasks.Contains(plannedTasks[i].Name))
                    {
                        plannedTasks.RemoveAt(i);
                    }
                }
            }
            content = JsonConvert.SerializeObject(settings);

            File.WriteAllText("settings.taskmanager", content);
            Logger.Log("settings were saved");
        }

        /// <summary>
        /// Liest den Inhalt der Datei "settings.taskmanager".
        /// Bei einem Leseproblem wird nach einer kurzen Verzögerung erneut versucht, den Inhalt zu lesen.
        /// </summary>
        /// <returns>Den Inhalt der Datei als <see cref="string"/>.</returns>
        static string ReadFile()
        {
            try
            {
                return File.ReadAllText("settings.taskmanager");
            }
            catch
            {
                Thread.Sleep(50);
                return ReadFile();
            }
        }
    }
}
