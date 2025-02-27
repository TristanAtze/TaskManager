using HelperLibrary;
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

            Options =
            [
                .. Options,
                .. TaskScheduler.TaskQueue.TaskList
                               .Select(item => $"[ {item.Name} ]"),
            ];



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
                    TaskScheduler.TaskQueue.TaskList.RemoveAt(ChoiceIndex - 1);

                List<MainTask> plannedTask = [];
                if (TaskScheduler.NextTask != null)
                    plannedTask.Add(TaskScheduler.NextTask);

                plannedTask.AddRange(TaskScheduler.TaskQueue.TaskList);

                Config.SaveSettings(null, null, null, plannedTask);
            }

            KeepGoing = false;
        }
    }
}
