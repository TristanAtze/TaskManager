using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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

        Headline = "Automatische Tasks";
        Options =
        [
            "[ E-Mail ]",
            "[ Taschenrechner ]",
            "[ Browser ]",
            "[ Bildschirm-Sperre bei Inaktivität ]",
            " ",
            "[ zurück ]"
        ];
    }

    protected override void CallChoice()
    {
        switch (ChoiceIndex)
        {
            case 0:
                BasicTasks.Email(Scheduler);
                break;
            case 1:
                BasicTasks.Calculator(Scheduler);
                break;
            case 2:
                BasicTasks.Browser(Scheduler);
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
}
