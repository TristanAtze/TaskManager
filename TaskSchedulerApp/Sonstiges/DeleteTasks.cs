using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TranslationsLibrary.TranslationManager;

namespace TaskSchedulerApp.Sonstiges
{
    public class DeleteTasks : Menu
    {
        public DeleteTasks()
        {
            Headline = GetTranslation(GetCurrentLanguage(), "headline_deletetask");

            foreach(var item in TaskScheduler.TaskQueue.TaskList)
            {
                Options.Append($"[ {item.Name} ]");
            }
            Options.Append("");
            Options.Append(GetTranslation(GetCurrentLanguage(), "back_options_settingsmenu"));
        }

        protected override void CallChoice()
        {
            if (Options[ChoiceIndex] != GetTranslation(GetCurrentLanguage(), "back_options_settingsmenu"))
            {
                for(int i = 0; i < TaskScheduler.TaskQueue.TaskList.Count; i++)
                {
                    if (TaskScheduler.TaskQueue.TaskList[i].Name == Options[ChoiceIndex])
                    {
                        TaskScheduler.TaskQueue.TaskList.Remove(TaskScheduler.TaskQueue.TaskList[i]);
                    }
                }
            }

            KeepGoing = false;
        }
    }
}
