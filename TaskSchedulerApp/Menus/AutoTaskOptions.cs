using System.Windows.Forms;
using static BasicTaskScheduler.BasicTaskScheduler;
using static HelperLibrary.TranslationManager;
namespace TaskSchedulerApp.Menus;

internal class AutoTaskOptions : Menu
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
        if (TotalTime != null)
        {
            switch (ChoiceIndex)
            {
                case 0:
                    BasicTaskScheduler.BasicTaskScheduler.Start();
                    BasicTasks.Email((double)TotalTime, Priority);
                    break;
                case 1:
                    BasicTaskScheduler.BasicTaskScheduler.Start();
                    BasicTasks.Calculator((double)TotalTime, Priority);
                    break;
                case 2:
                    BasicTaskScheduler.BasicTaskScheduler.Start();
                    BasicTasks.Browser((double)TotalTime, Priority);
                    break;
                case 3:
                    MessageBox.Show("In der aktuellen Version nicht verfügbar");    

                    break;
                case 5:
                    KeepGoing = false;
                    break;
                default:
                    break;
            }
        }
    }
}
