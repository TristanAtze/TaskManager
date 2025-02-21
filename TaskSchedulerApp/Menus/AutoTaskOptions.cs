using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskClasses;
using static TranslationsLibrary.TranslationManager;

namespace TaskSchedulerApp.Menus;

class AutoTaskOptions : Menu
{
    private TaskScheduler Scheduler { get; set; }

    //todo übersetzen
    public AutoTaskOptions(TaskScheduler taskScheduler)
    {
        Scheduler = taskScheduler;

        Headline = GetTranslation(GetCurrentLanguage(), "headline_autotaskmenu");
        Options =
        [
            GetTranslation(GetCurrentLanguage(), "email_autotaskmenu"),
            GetTranslation(GetCurrentLanguage(), "calc_autotaskmenu"),
            GetTranslation(GetCurrentLanguage(), "browser_autotaskmenu"),
            GetTranslation(GetCurrentLanguage(), "screenlocker_autotaskmenu"),
            " ",
            GetTranslation(GetCurrentLanguage(), "return_autotaskmenu")
        ];
    }

    protected override void CallChoice()
    {
        switch (ChoiceIndex)
        {
            case 0:
                BasicTasks.Email(Scheduler, GetInput());
                break;
            case 1:
                BasicTasks.Calculator(Scheduler, GetInput());
                break;
            case 2:
                BasicTasks.Browser(Scheduler, GetInput());
                break;
            case 3:

                BasicTasks.LockInactive(Scheduler);
                break;
            case 5:
                KeepGoing = false;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Ist nur Temporär entsprechend weder eine Richtige beschreibung noch eine übersetzung
    /// </summary>
    /// <returns>hat als rückgabe wert einen double</returns>
    public static double GetInput()
    {
        try
        {
            //NUR TEMPORÄR
            Console.WriteLine("Bitte gebe an wie lange es dauern soll bis der Task Ausgeführt wird");
            string input = Console.ReadLine();
            double num = Convert.ToDouble(input);
            return num;
        }
        catch
        {
            return 0;
        }
    }
}
