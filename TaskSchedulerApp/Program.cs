using TaskSchedulerApp.BackgroundClasses;
using System.Runtime.InteropServices;
using TaskSchedulerApp.Menus;

public class Program
{
    [STAThread]
    public static void Main()
    {
        Console.CursorVisible = false;
        Task.Run(() => PcStatus.StartMonitoring(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1), 20.0f, ["test"], "test"));
        var taskScheduler = new TaskScheduler();

        Task.Run(taskScheduler.Start);

        var mainMenu = new MainMenu(taskScheduler);
        mainMenu.Start();

        
    }

    //public static async Task PreventShutdownStart()
    //{
    //    System.Windows.Forms.Application.Run(new PreventShutdown());
    //}
}

public static class SystemControl
{
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool LockWorkStation();
}