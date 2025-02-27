using HelperLibrary;
using HelperLibrary.TaskClasses;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskClasses;
using static HelperLibrary.TranslationManager;

public class BasicTasks
{
    //Time ist hier Tatsächlich die zeit bis zur ausführung (in Sekunden)
    public static async Task Email(double time, int? priority = 1)
    {
        await Task.Delay(TimeSpan.FromSeconds(time));
        string email = GetTranslation(GetCurrentLanguage(), "reciever_mail_basictasks");
        string subject = Uri.EscapeDataString(GetTranslation(GetCurrentLanguage(), "subject_mail_basictasks"));
        string body = Uri.EscapeDataString(GetTranslation(GetCurrentLanguage(), "text_mail_basictasks"));

        string mailto = $"mailto:{email}?subject={subject}&body={body}";

        try
        {
            Process.Start(new ProcessStartInfo(mailto) { UseShellExecute = true });
            Logger.Log("openmail_executed_mail_basictasks");
        }
        catch (Exception ex)
        {
            MessageBox.Show(GetTranslation(GetCurrentLanguage(), "openmail_error_executed_mail_basictasks") + ex.Message);
            Logger.Log("openmail_executed_mail_basictasks ERROR");
        }
        NotificationManager.SendNotification("openmail_executed_mail_basictasks");
    }

    public static async Task Calculator(double time, int? priority = 1)
    {
        await Task.Delay(TimeSpan.FromSeconds(time));

        try
        {
            Process.Start(new ProcessStartInfo("calc.exe") { UseShellExecute = true });
            Logger.Log("opencalc_executed_calculator_basictasks");
        }
        catch (Exception ex)
        {
            MessageBox.Show(GetTranslation(GetCurrentLanguage(), "opencalc_error_executed_calculator_basictasks") + ex.Message);
            Logger.Log("opencalc_executed_calculator_basictasks ERROR");
        }
        NotificationManager.SendNotification("opencalc_executed_calculator_basictasks");

    }

    public static async Task Browser(double time, int? priority = 1)
    {
        await Task.Delay(TimeSpan.FromSeconds(time));
        try
        {

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://www.google.com",
                UseShellExecute = true
            };
            Process.Start(psi);
            NotificationManager.SendNotification("openbrowser_executed_browser_basictasks");
            Logger.Log("openbrowser_executed_browser_basictasks");
        }
        catch
        {
            Logger.Log("openbrowser_executed_browser_basictasks ERROR");
        }
    }

    public static void LockInactive(double time, int? priority = 1)
    {
        var LockInactive = new PreTask("LockInactive", () =>
        {
            Logger.Log("Task successfully executed.");
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
    }
}