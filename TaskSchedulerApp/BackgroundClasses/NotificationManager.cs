using System;
using static TranslationsLibrary.TranslationManager;

public class NotificationManager
{
    public void SendNotification(string message)
    {

        Console.WriteLine(GetTranslation(GetCurrentLanguage(), message));
    }
}
