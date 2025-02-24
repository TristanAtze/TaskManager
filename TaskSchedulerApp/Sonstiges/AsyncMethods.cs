using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerApp.BackgroundClasses;

namespace TaskSchedulerApp.Sonstiges;

public static class AsyncMethods
{
    public static async Task StartAsyncStatusTasks()
    {
        var startMonitorung = Task.Run(() => PcStatus.StartMonitoring(TimeSpan.FromHours(10), TimeSpan.FromSeconds(5), 100.0f, ["Test"], "Test"));

        _ = Task.Run(async () =>
        {
            while (true)
            {
                // Gib die aktuellen Statuswerte aus
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("---- PC-Status Update ----");
                Console.WriteLine($"JustBooted:     {PcStatus.IsJustBooted}");
                Console.WriteLine($"ShuttingDown:   {PcStatus.IsShuttingDown}");
                Console.WriteLine($"GoingToSleep:   {PcStatus.IsGoingToSleep}");
                Console.WriteLine($"UserInactive:   {PcStatus.IsUserInactive}");
                Console.WriteLine($"LightlyLoaded:  {PcStatus.IsPcLightlyLoaded}");
                Console.WriteLine("--------------------------");

                if (PcStatus.IsGoingToSleep)
                {
                    string settingsFilePath = "Bixt.txt";
                    string settings = "Bixt.txt";
                    File.WriteAllText(settingsFilePath, settings);
                }
                await Task.Delay(200);
            }

        });
        await startMonitorung;
    }
}
