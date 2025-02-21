using System;
using static TranslationsLibrary.TranslationManager;

public class NotificationManager
{
    public void SendNotification(string message)
    {
        var logger = new Logger("task_logs.csv");
        logger.Log("NotificationManager", "SendNotification successfully executed.");
        Console.WriteLine(GetTranslation(GetCurrentLanguage(), message));
    }
}
