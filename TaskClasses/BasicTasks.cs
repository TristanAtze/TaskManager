﻿using System.Diagnostics;
using System.Windows;
using TaskSchedulerApp.BackgroundClasses;
using TaskClasses;
using static HelperLibrary.TranslationManager;
using System.Windows.Forms;

public class BasicTasks
{
    //Time ist hier Tatsächlich die zeit bis zur ausführung (in Sekunden)
    public static void Email(double time, int? priority = 1)
    {
        //var notificationManager = new NotificationManager();
        //var logger = new Logger("task_logs.csv");
        var OpenEmail = new PreTask("OpenMail", () =>
        {

            //notificationManager.SendNotification("openmail_executed_mail_basictasks");
            //logger.Log("OpenMail", "Task successfully executed.");
            string email = GetTranslation(GetCurrentLanguage(), "reciever_mail_basictasks");
            string subject = Uri.EscapeDataString(GetTranslation(GetCurrentLanguage(), "subject_mail_basictasks"));
            string body = Uri.EscapeDataString(GetTranslation(GetCurrentLanguage(), "text_mail_basictasks"));

            string mailto = $"mailto:{email}?subject={subject}&body={body}";

            try
            {
                Process.Start(new ProcessStartInfo(mailto) { UseShellExecute = true });

            }
            catch (Exception ex)
            {
                MessageBox.Show(GetTranslation(GetCurrentLanguage(), "openmail_error_executed_mail_basictasks") + ex.Message);
            }
            NotificationManager.SendNotification("openmail_executed_mail_basictasks");

        }, DateTime.Now.AddSeconds(time), priority);

        TaskScheduler.ScheduleTask(OpenEmail);
    }

    public static void Calculator(double time, int? priority = 1)
    {
        var Calculator = new PreTask("Calculator", () =>
        {
            //notificationManager.SendNotification(GetTranslation(GetCurrentLanguage(), "opencalc_executed_calculator_basictasks"));
            //logger.Log("Calculator", "Task successfully executed.");
            try
            {
                Process.Start(new ProcessStartInfo("calc.exe") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(GetTranslation(GetCurrentLanguage(), "opencalc_error_executed_calculator_basictasks") + ex.Message);
            }
            NotificationManager.SendNotification("opencalc_executed_calculator_basictasks");
        }, DateTime.Now.AddSeconds(time), priority);
        TaskScheduler.ScheduleTask(Calculator);
    }

    public static void Browser(double time, int? priority = 1)
    {
        //var notificationManager = new NotificationManager();
        //var logger = new Logger("task_logs.csv");

        var Browser = new PreTask("Browser", () =>
        {
            //notificationManager.SendNotification(GetTranslation(GetCurrentLanguage(), "openbrowser_executed_browser_basictasks"));
            //logger.Log("Browser", "Task successfully executed.");
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://www.google.com",
                UseShellExecute = true
            };
            Process.Start(psi);
            NotificationManager.SendNotification("openbrowser_executed_browser_basictasks");
        }, DateTime.Now.AddSeconds(time), priority);

        TaskScheduler.ScheduleTask(Browser);
    }

    public static void LockInactive(double time, int? priority = 1)
    {
        //var notificationManager = new NotificationManager();
        //var logger = new Logger("task_logs.csv");

        var LockInactive = new PreTask("LockInactive", () =>
        {
            //notificationManager.SendNotification("LockInactive executed.");
            //logger.Log("LockInactive", "Task successfully executed.");
            Task.Run(async () =>
            {
                while (true)
                {
                    //Console.WriteLine("Test");
                    //Asynchrone Prüfung, ob der Nutzer mindestens 1 Minute inaktiv ist
                    bool inactive = PcStatus.IsUserInactive;
                    if (inactive)
                    {
                        //notificationManager.SendNotification("Nutzer inaktiv: PC wird gesperrt.");
                        //logger.Log("LockPC", "Nutzer inaktiv. PC wird sofort gesperrt.");
                        //SystemControl.LockWorkStation();
                        break; // Nach dem Sperren beenden wir die Überwachungsschleife.
                    }
                    //Überprüfe alle 5 Sekunden erneut
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            });

        }, DateTime.Now.AddSeconds(time), priority);
        TaskScheduler.ScheduleTask(LockInactive);
    }
}