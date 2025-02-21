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
    public AutoTaskOptions()
    {
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
                BasicTasks.Email(GetInput());
                break;
            case 1:
                BasicTasks.Calculator(GetInput());
                break;
            case 2:
                BasicTasks.Browser(GetInput());
                break;
            case 3:
                BasicTasks.LockInactive();
                break;
            case 5:
                KeepGoing = false;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Liest eine Benutzereingabe von der Konsole, die angibt, wie lange es dauern soll, bis der Task ausgeführt wird.
    /// Die Eingabe wird als Double-Wert zurückgegeben. Falls die Eingabe ungültig ist, wird 0 zurückgegeben.
    /// <b>Hinweis:</b> Diese Methode ist nur temporär und dient nur zu Demonstrationszwecken.
    /// </summary>
    /// <returns>Die eingegebene Zahl als Double-Wert. Im Fehlerfall wird 0 zurückgegeben.</returns>
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
