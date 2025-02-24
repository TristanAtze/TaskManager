using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskClasses;
using static HelperLibrary.TranslationManager;
using static BasicTaskScheduler.BasicTaskScheduler;
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
                BasicTaskScheduler.BasicTaskScheduler.Start();
                BasicTasks.Email(TotalTime, Priority);
                break;
            case 1:
                BasicTaskScheduler.BasicTaskScheduler.Start();
                BasicTasks.Calculator(TotalTime, Priority);
                break;
            case 2:
                BasicTaskScheduler.BasicTaskScheduler.Start();
                BasicTasks.Browser(TotalTime, Priority);
                break;
            case 3:

                BasicTasks.LockInactive(TotalTime, Priority);
                break;
            case 5:
                KeepGoing = false;
                break;
            default:
                break;
        }
    }
}
