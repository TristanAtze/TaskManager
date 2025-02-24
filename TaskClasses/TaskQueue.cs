using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace TaskClasses;

/// <summary>
/// "Warteschlange" für alle Tasks.
/// </summary>
public class TaskQueue
{
    /// <summary>
    /// Liste mit allen Tasks.
    /// </summary>
    public List<MainTask> TaskList { get; private set; } = [];

    /// <summary>
    /// Fügt eine Task hinzu und sortiert anschließen die gesamte Liste nach Priorität.
    /// </summary>
    /// <param name="task">Hinzuzufügende Task</param>
    public void AddTask(MainTask task)
    {
        TaskList.Add(task);
        Logger.Log("Task was added to TaskQueue");
        //TaskList.Sort((x, y) => {
        //    var xNotNull = x.Priority ?? int.MinValue;
        //    var yNotNull = y.Priority ?? int.MinValue;
        //    Logger.Log("Task Queue was sorted");
        //    return xNotNull.CompareTo(yNotNull);
        //}); // Priorität sortieren

        TaskList = [.. TaskList.OrderBy(x => x.ScheduledTime).ThenBy(x => x.Priority)];
    }
    
    /// <summary>
    /// Gibt die nächste ausstehende Task der Liste zurück.
    /// </summary>
    /// <returns>Nächste ausstehende Task</returns>
    public MainTask? GetNextTask()
    {
        var taskToExecute = TaskList.FirstOrDefault();
        if (taskToExecute != null)
        {
            TaskList.RemoveAt(0);
        }
        return taskToExecute;
    }

    public void ThrowTask(MainTask actualTask)
    {
        TaskList.Add(actualTask);
    }
}
