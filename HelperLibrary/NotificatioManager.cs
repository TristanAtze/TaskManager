using System;
using System.Windows.Forms;
using static TranslationsLibrary.TranslationManager;

public static class NotificationManager
{
    public static void SendNotification(string message)
    {
        var logger = new Logger("task_logs.csv");
        logger.Log("NotificationManager", "SendNotification successfully executed.");
        MessageBox.Show(GetTranslation(GetCurrentLanguage(), message), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
