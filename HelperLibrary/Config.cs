using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskClasses;

namespace TaskSchedulerApp.TaskClasses
{
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
            if (!File.Exists("settings.json"))
            {
                Logger.Log("settings.json created.");
                File.Create("settings.json");
            }

            string fileContent = File.ReadAllText("settings.json");

            Config? settings = JsonConvert.DeserializeObject<Config>(fileContent);
            Logger.Log("settings.json loaded.");
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

            if (!File.Exists("settings.json"))
            {
                File.Create("settings.json");
            }
            var content = JsonConvert.SerializeObject(settings);
            File.WriteAllText("settings.json", content);
            Logger.Log("settings were saved");
        }
    }
}
