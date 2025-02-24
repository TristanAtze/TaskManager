using TaskClasses;
using TaskSchedulerApp.BackgroundClasses;

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
                    await Task.Delay(delay);
                }

                if (RequirementsMet(NextTask))
                {
                    await Task.Run(() => NextTask.Execute());

                    if (NextTask.IsRecurring && NextTask.Interval.HasValue)
                    {
                        NextTask.ScheduledTime = DateTime.Now.Add(NextTask.Interval.Value);
                        ScheduleTask(NextTask);
                    }
                }
                else
                {
                    TaskQueue.ThrowTask(NextTask);
                }
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

        if (task.ConditionCPUUsage && !PcStatus.IsPcLightlyLoaded)
            result = false;

        if (task.ConditionJustBooted && !PcStatus.IsJustBooted)
            result = false;

        if (task.ConditionShuttingDown && !PcStatus.IsShuttingDown)
            result = false;

        return result;
    }
}
