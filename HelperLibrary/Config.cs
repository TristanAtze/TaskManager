using Newtonsoft.Json;
using System.Diagnostics;
using TaskClasses;

namespace HelperLibrary;

public class Config
{
    public DateTime TimeStamp { get; set; }
    public string? Language { get; set; } = null;
    public ConsoleColor ConsoleColorStr { get; set; }
    public List<MainTask> Presets { get; set; }
    public List<MainTask> PlannedTasks { get; set; }

    public Config()
    {
        Presets = [];
        PlannedTasks = [];
    }

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
        var content = JsonConvert.SerializeObject(settings);
        File.WriteAllText("settings.taskmanager", content);
        Logger.Log("settings were saved");
    }

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
