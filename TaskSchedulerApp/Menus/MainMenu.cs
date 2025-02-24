using FileDialog;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerApp.Sonstiges;
using static HelperLibrary.TranslationManager;

namespace TaskSchedulerApp.Menus;

public class MainMenu : Menu
{
    public MainMenu()
    {
        Headline = GetTranslation(GetCurrentLanguage(), "headline_mainmenu");
        Options =
        [
            GetTranslation(GetCurrentLanguage(), "newtask_options_mainmenu"),
            GetTranslation(GetCurrentLanguage(), "showtask_options_mainmenu"),
            $"[ {GetTranslation(GetCurrentLanguage(), "headline_deletetask")} ]",
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
                var createTask = new CreateTaskMenu();
                createTask.Start();
                break;
            case 1:
                PrintTasks();
                break;
            case 2:
                var delete = new DeleteTasks();
                delete.Start();
                break;
            case 4:
                //todo Config laden verknüpfen
                break;
            case 5:
                var settings = new SettingsMenu();
                settings.Start();
                break;
            case 7:
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
