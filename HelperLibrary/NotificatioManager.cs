using HelperLibrary;
using System;
using System.Windows.Forms;
using static HelperLibrary.TranslationManager;

public static class NotificationManager
{
    public static void SendNotification(string message)
    {
        Logger.Log("SendNotification executed.");
        MessageBox.Show(GetTranslation(GetCurrentLanguage(), message), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
