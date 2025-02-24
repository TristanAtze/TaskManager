using TaskSchedulerApp.BackgroundClasses;
using System.Runtime.InteropServices;
using TaskSchedulerApp.Menus;
using System.Diagnostics;
using TaskSchedulerApp.Sonstiges;
using ShutdownBlocker;
using System.Runtime.CompilerServices;
using HelperLibrary;

public class Program
{
    [STAThread]
    public static void Main()
    {
        Console.CursorVisible = false;

        //ConsoleColor? color = Config.GetSettings()?.ConsoleColorStr;
        //if (color != null)
        //    Console.ForegroundColor = (ConsoleColor)color;
        //else
        //    Console.ForegroundColor = ConsoleColor.White;


        List<MainTask>? plannedTasks = Config.GetSettings()?.PlannedTasks;
        if(plannedTasks != null)
        {
            foreach(var item in plannedTasks)
            {
                TaskScheduler.ScheduleTask(item);
            }
        }

        Task.Run(PreventShutdown.Start);
        Task.Run(() => PcStatus.StartMonitoring(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1), 20.0f, ["test"], "test"));

        Task.Run(TaskScheduler.Start);

        var mainMenu = new MainMenu();
        mainMenu.Start();

        
    }
}

public static class SystemControl
{
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool LockWorkStation();
}

