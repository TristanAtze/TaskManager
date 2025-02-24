using System;
using System.Threading;
using TaskClasses;
using TaskSchedulerApp.BackgroundClasses;
using TaskSchedulerApp.TaskClasses;

public static class TaskScheduler
{
    public static TaskQueue TaskQueue { get; private set; } = new TaskQueue();

    public static MainTask? NextTask { get; set; } = null;

    /// <summary>
    /// Fügt in der Warteschlange eine neue Task hinzu.
    /// </summary>
    /// <param name="task">Die neue Task</param>
    public static void ScheduleTask(MainTask task)
    {
        TaskQueue.AddTask(task);

        List<MainTask> plannedTasks = [];
        if(NextTask != null)
        {
            plannedTasks.Add(NextTask);
        }
        foreach(var item in TaskQueue.TaskList)
        {
            plannedTasks.Add(item);
        }

        Config.SaveSettings(null, null, null, plannedTasks);
    }

    /// <summary>
    /// Startet den Scheduler.
    /// </summary>
    /// <returns>Leerer Task</returns>
    public static async Task Start()
    {
        while (true)
        {
            NextTask = TaskQueue.GetNextTask();
            if (NextTask != null)
            {
                var delay = NextTask.ScheduledTime - DateTime.Now;
                if (delay.TotalMilliseconds > 0)
                {
                    Thread.Sleep(delay);
                }

                if (RequirementsMet(NextTask))
                {
                    if (OwnTask.CompareType(NextTask))
                    {
                        var task = (OwnTask)NextTask;
                        task.Execute();
                    }
                    else if (PreTask.CompareType(NextTask))
                    {
                        var task = (PreTask)NextTask;
                        task.Execute();
                    }
                    else
                    {
                        NextTask.Execute();
                    }

                    if (NextTask.IsRecurring && NextTask.Interval.HasValue)
                    {
                        NextTask.ScheduledTime = DateTime.Now.Add(NextTask.Interval.Value); // Neu planen
                        ScheduleTask(NextTask); // Wieder hinzufügen
                    }
                }
                else
                {
                    TaskQueue.ThrowTask(NextTask);
                }
            }
        }
    }

    static bool RequirementsMet(MainTask task)
    {
        bool result = true;

        if (task.ConditionCPUUsage && !PcStatus.IsPcLightlyLoaded)
            result = false;

        if (task.ConditionJustBooted && !PcStatus.IsJustBooted)
            result = false;

        if (task.ConditionShuttingDown && !PcStatus.IsShuttingDown)
            result = false;

        return result;
    }
}
