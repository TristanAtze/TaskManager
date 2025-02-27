using HelperLibrary;
using ShutdownBlocker;
using System.Runtime.InteropServices;
using TaskSchedulerApp.Menus;

public class Program
{
    [STAThread]
    public static void Main()
    {
        Console.CursorVisible = false;
        Logger.LogFileCreate();
        ConsoleColor? color = Config.GetSettings()?.ConsoleColorStr;
        if (color != null && color != 0)
            Console.ForegroundColor = (ConsoleColor)color;
        else
            Console.ForegroundColor = ConsoleColor.White;



        List<MainTask>? plannedTasks = Config.GetSettings()?.PlannedTasks;
        if (plannedTasks != null)
            plannedTasks?.ToList().ForEach(TaskScheduler.ScheduleTask);

        Task.Run(PreventShutdown.Start);
        Task.Run(() => PcStatus.StartMonitoring(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1), 20.0f, ["test"], "test"));

        Task.Run(TaskScheduler.Start);

        var mainMenu = new MainMenu();
        mainMenu.Start();
    }
}

public static partial class SystemControl
{
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool LockWorkStation();
}

