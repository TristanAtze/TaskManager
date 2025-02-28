using HelperLibrary;
using HelperLibrary.TaskClasses;
using TaskClasses;

public static class TaskScheduler
{
    public static TaskQueue TaskQueue { get; private set; } = new TaskQueue();

    public static bool IsRunning { private get; set; } = true;
    public static OwnTask NextTask { get; set; } = new OwnTask("", "", DateTime.Now);

    /// <summary>
    /// Fügt in der Warteschlange eine neue Task hinzu.
    /// </summary>
    /// <param name="task">Die neue Task</param>
    public static void ScheduleTask(OwnTask task)
    {
        TaskQueue.AddTask(task);

        List<OwnTask>? alreadyPlanned = Config.GetSettings()?.PlannedTasks;
        List<OwnTask> plannedTasks = [];
        if(alreadyPlanned != null)
        {
            plannedTasks.AddRange(
                new[] { NextTask }
                    .Where(task => task != null && !alreadyPlanned.Contains(task))
                    .Concat(TaskQueue.TaskList.Where(task => !alreadyPlanned.Contains(task)))
            );
        }

        Config.SaveSettings(null, null, null, plannedTasks);
    }

    /// <summary>
    /// Startet den Scheduler.
    /// </summary>
    /// <returns>Leerer Task</returns>
    public static async Task Start()
    {
        while (IsRunning)
        {
            NextTask = TaskQueue.GetNextTask();
            if (NextTask != null)
            {
                var delay = NextTask.ScheduledTime - DateTime.Now;

                if (delay.TotalMilliseconds > 0)
                    await Task.Delay(delay);

                if (RequirementsMet(NextTask))
                {
                    if (OwnTask.CompareType(NextTask))
                    {
                        OwnTask task = (OwnTask)NextTask;
                        task.Execute();
                    }
                    else 
                        NextTask.Execute();

                            

                    if (NextTask.IsRecurring && NextTask.Interval.HasValue)
                    {
                        NextTask.ScheduledTime = DateTime.Now.Add(NextTask.Interval.Value);
                        ScheduleTask(NextTask);
                    }
                }
                else
                    TaskQueue.ThrowTask(NextTask);

                Config.SaveSettings(null, null, null, TaskQueue.TaskList);
            }
            else
            {
                await Task.Delay(1000);
            }
        }
    }

    private static bool RequirementsMet(MainTask task)
    {
        bool result = true;
        if (task != null)
        {
            if (task.ConditionCPUUsage && !PcStatus.IsPcLightlyLoaded)
                result = false;
            if (task.ConditionJustBooted && !PcStatus.IsJustBooted)
                result = false;
            if (task.ConditionShuttingDown && !PcStatus.IsShuttingDown)
                result = false;
        }

        return result;
    }
}
