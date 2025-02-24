using System;
using System.IO;
using System.Runtime.CompilerServices;
using static HelperLibrary.TranslationManager;
public static class Logger
{
    public static void LogFileCreate(string logFilePath = "task_logs.csv")
    {
        if (!File.Exists(logFilePath))
        {
            using var writer = new StreamWriter(logFilePath, append: false);
            writer.WriteLine("Timestamp,TaskName,Message");
            writer.Close();
            Logger.Log("Log File Created");
        }
    }

    public static void Log(string message, [CallerMemberName] string memberName = "", string logFilePath = "task_logs.csv")
    {
        

        string logEntry = $"{DateTime.Now},{memberName},{message}";

        using var writer = new StreamWriter(logFilePath, append: true);
        writer.WriteLine(logEntry);
        writer.Close();
    }
}
