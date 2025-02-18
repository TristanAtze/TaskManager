using System;
using static TranslationsLibrary.TranslationManager;

public class NotificationManager
{
    public void SendNotification(string message)
    {
        GetTranslation(GetCurrentLanguage(), message);
        Console.WriteLine($"Notification: {message}");
    }
}
