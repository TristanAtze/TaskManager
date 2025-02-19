﻿using System;
using System.Threading;
using TaskClasses;

public class TaskScheduler
{
    public TaskQueue TaskQueue { get; private set; } = new TaskQueue();

    /// <summary>
    /// Fügt in der Warteschlange eine neue Task hinzu.
    /// </summary>
    /// <param name="task">Die neue Task</param>
    public void ScheduleTask(MainTask task)
    {
        TaskQueue.AddTask(task);
    }

    /// <summary>
    /// Startet den Scheduler.
    /// </summary>
    /// <returns>Leerer Task</returns>
    public async Task Start()
    {
        while (true)
        {
            var nextTask = TaskQueue.GetNextTask();
            if (nextTask != null)
            {
                var delay = nextTask.ScheduledTime - DateTime.Now;
                if (delay.TotalMilliseconds > 0)
                {
                    Thread.Sleep(delay);
                }

                nextTask.Execute();

                if (nextTask.IsRecurring && nextTask.Interval.HasValue)
                {
                    nextTask.ScheduledTime = DateTime.Now.Add(nextTask.Interval.Value); // Neu planen
                    ScheduleTask(nextTask); // Wieder hinzufügen
                }
            }
        }
    }
}
