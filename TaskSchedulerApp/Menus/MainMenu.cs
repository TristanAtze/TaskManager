using FileDialog;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TranslationsLibrary.TranslationManager;

namespace TaskSchedulerApp.Menus;

public class MainMenu : Menu
{
    private TaskScheduler Scheduler { get; set; }

    public MainMenu(TaskScheduler taskScheduler)
    {
        Scheduler = taskScheduler;

        Headline = GetTranslation(GetCurrentLanguage(), "headline_mainmenu");
        Options =
        [
            GetTranslation(GetCurrentLanguage(), "newtask_options_mainmenu"),
            GetTranslation(GetCurrentLanguage(), "showtask_options_mainmenu"),
            " ",
            GetTranslation(GetCurrentLanguage(), "loadpreset_options_mainmenu"),
            GetTranslation(GetCurrentLanguage(), "settings_options_mainmenu"),
            " ",
            GetTranslation(GetCurrentLanguage(), "end_options_mainmenu")
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

    //todo übersetzen
    void PrintTasks()
    {
        Console.WriteLine(GetTranslation(GetCurrentLanguage(), "headline_printtasks_mainmenu"));

        foreach (var item in TaskScheduler.TaskQueue.TaskList)
        {
            Console.WriteLine(GetTranslation(GetCurrentLanguage(), "name_printtasks_mainmenu") + item.Name);
            Console.WriteLine(GetTranslation(GetCurrentLanguage(), "priority_printtasks_mainmenu") + item.Priority);
            Console.WriteLine(GetTranslation(GetCurrentLanguage(), "date_printtasks_mainmenu") + item.ScheduledTime);

            if (item.IsRecurring)
            {
                Console.WriteLine(GetTranslation(GetCurrentLanguage(), "interval_printtasks_mainmenu") + " = " + item.Interval);
            }
            else
            {
                Console.WriteLine(GetTranslation(GetCurrentLanguage(), "interval_printtasks_mainmenu"));
            }

            Console.WriteLine();
        }

        Console.ReadKey(true);
        Console.Clear();
    }
}
