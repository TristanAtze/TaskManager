﻿using HelperLibrary;
using TaskClasses;
using static HelperLibrary.TranslationManager;

namespace TaskSchedulerApp.Sonstiges
{
    public class DeleteTasks : Menu
    {
        public DeleteTasks()
        {
            Headline = GetTranslation(GetCurrentLanguage(), "headline_deletetask");

            if (TaskScheduler.NextTask != null)
                Options = [.. Options, $"[ {TaskScheduler.NextTask.Name} ]"];

            foreach (var item in TaskScheduler.TaskQueue.TaskList)
            {
                Options = [.. Options, $"[ {item.Name} ]"];
            }

            if (Options.Length != 0)
                Options = [.. Options, " "];

            Options = [.. Options, GetTranslation(GetCurrentLanguage(), "back_options_settingsmenu")];
        }

        protected override void CallChoice()
        {
            if (Options[ChoiceIndex] != GetTranslation(GetCurrentLanguage(), "back_options_settingsmenu"))
            {
                if (ChoiceIndex == 0)
                    TaskScheduler.NextTask = TaskScheduler.TaskQueue.GetNextTask();

                else if (ChoiceIndex - 1 < TaskScheduler.TaskQueue.TaskList.Count)
                {
                    TaskScheduler.TaskQueue.TaskList.RemoveAt(ChoiceIndex - 1);
                }

                List<MainTask> plannedTask = [];
                if (TaskScheduler.NextTask != null)
                    plannedTask.Add(TaskScheduler.NextTask);

                foreach(var item in TaskScheduler.TaskQueue.TaskList)
                {
                    plannedTask.Add(item);
                }

                Config.SaveSettings(null, null, null, plannedTask);
            }

            KeepGoing = false;
        }
    }
}
