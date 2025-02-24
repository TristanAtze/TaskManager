using BackupTool;
using FileDialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static HelperLibrary.TranslationManager;

namespace TaskSchedulerApp.Menus;

class CreateTaskMenu : Menu
{
    public CreateTaskMenu()
    {
        Headline = GetTranslation(GetCurrentLanguage(), "headline_createtaskmenu");
        Options =
        [
            GetTranslation(GetCurrentLanguage(), "individualtask_createtaskmenu"),
            GetTranslation(GetCurrentLanguage(), "automatictask_createtaskmenu"),
            GetTranslation(GetCurrentLanguage(), "backuptask_createtaskmenu"),
            " ",
            GetTranslation(GetCurrentLanguage(), "return_createtaskmenu")
        ];
    }

    protected override void CallChoice()
    {
        switch (ChoiceIndex)
        {
            case 0:
                TaskCreator.StartTaskCreator();
                break;
            case 1:
                var autoCreator = new AutoTaskOptions();
                autoCreator.Start();
                break;
            case 2:
                var backupTask = new Form1();
                Application.Run(backupTask);
                break;
            case 4:
                KeepGoing = false;
                break;
            default:
                break;
        }
    }
}
