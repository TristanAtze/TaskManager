using BackupTool;
using FileDialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static TranslationsLibrary.TranslationManager;

namespace TaskSchedulerApp.Menus;

class CreateTaskMenu : Menu
{
    private TaskScheduler Scheduler { get; set; }

    public CreateTaskMenu(TaskScheduler taskScheduler)
    {
        Scheduler = taskScheduler;

        Headline = GetTranslation(GetCurrentLanguage(), "headline_createtaskmenu");
        Options =
        [
            GetTranslation(GetCurrentLanguage(), "individualtask_createtaskmenu"),
            GetTranslation(GetCurrentLanguage(), "automatictask_createtaskmenu"),
            GetTranslation(GetCurrentLanguage(), "backuptask_createtaskMenu"),
            " ",
            GetTranslation(GetCurrentLanguage(), "return_createtaskmenu")
        ];
    }

    protected override void CallChoice()
    {
        switch (ChoiceIndex)
        {
            case 0:
                var creator = new TaskCreator(Scheduler);
                System.Windows.Forms.Application.Run(creator);
                break;
            case 1:
                var autoCreator = new AutoTaskOptions(Scheduler);
                autoCreator.Start();
                break;
            case 2:
                var backupTask = new Form1();
                System.Windows.Forms.Application.Run(backupTask);
                break;
            case 4:
                KeepGoing = false;
                break;
            default:
                break;
        }
    }
}
