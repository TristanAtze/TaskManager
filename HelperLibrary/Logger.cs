using System.Runtime.CompilerServices;

namespace HelperLibrary;

public static class Logger
{
    private static List<string> logs = [];

    static Logger()
    {
        Task.Run(() => ExecuteLog());
    }

    public static void LogFileCreate(string logFilePath = "task_logs.csv")
    {
        if (!File.Exists(logFilePath))
        {
            using var writer = new StreamWriter(logFilePath, append: false);
            writer.WriteLine("Timestamp,TaskName,Message");
            writer.Close();
            Log("Log File Created");
        }
    }

    public static void Log(string message, [CallerMemberName] string memberName = "", string logFilePath = "task_logs.csv")
    {
        ArgumentNullException.ThrowIfNull(logFilePath);

        try
        {
            string logEntry = $"{DateTime.Now},{memberName},{message}";
            logs.Add(logEntry);
        }
        catch
        {
            Environment.Exit(0);
        }
    }

    private static async Task ExecuteLog(string logFilePath = "task_logs.csv")
    {
        using var writer = new StreamWriter(logFilePath, append: true);

        while (true)
        {
            if (logs.Count != 0)
            {
                var logsToWrite = new List<string>(logs);
                logs.Clear();

                foreach (var e in logsToWrite)
                {
                    await writer.WriteLineAsync(e);
                }
            }
            await Task.Delay(5000);
        }
    }
}

