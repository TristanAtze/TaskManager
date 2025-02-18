using FileDialog;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerApp.Menus;

public class MainMenu : Menu
{
    private TaskScheduler Scheduler { get; set; }

    public MainMenu(TaskScheduler taskScheduler)
    {
        Scheduler = taskScheduler;

        Headline = "Hauptmenü";
        Options =
        [
            "[ neuen Task erstellen ]",
            "[ alle Tasks anzeigen ]",
            " ",
            "[ Voreinstellungen laden ]",
            "[ Einstellungen ]",
            " ",
            "[ Beenden ]"
        ];
    }

    protected override void CallChoice()
    {
        switch (ChoiceIndex)
        {
            case 0:
                var createTask = new CreateTaskMenu(Scheduler);
                createTask.Start();
                break;
            case 1:
                PrintTasks();
                break;
            case 3:
                //todo Config laden verknüpfen
                break;
            case 4:
                var settings = new SettingsMenu();
                settings.Start();
                break;
            case 6:
                KeepGoing = false;
                break;
            default:
                break;
        }
    }

    void PrintTasks()
    {
        Console.WriteLine("\nAusstehende Tasks:\n------------------\n");

        foreach(var item in Scheduler.TaskQueue.TaskList)
        {
            Console.WriteLine("[ Name ] = " + item.Name);
            Console.WriteLine("[ Priorität ] = " + item.Priority);
            Console.WriteLine("[ Datum ] = " + item.ScheduledTime);

            if (item.IsRecurring)
            {
                Console.WriteLine("[ Intervall ] = " + item.Interval);
            }
            else
            {
                Console.WriteLine("[ Intervall ]");
            }

            Console.WriteLine();
        }

        Console.ReadKey(true);
        Console.Clear();
    }
}
