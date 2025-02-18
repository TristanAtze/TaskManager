using System.Collections.Generic;
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
    public List<MainTask> TaskList { get; private set; } = new List<MainTask>();

    /// <summary>
    /// Fügt eine Task hinzu und sortiert anschließen die gesamte Liste nach Priorität.
    /// </summary>
    /// <param name="task">Hinzuzufügende Task</param>
    public void AddTask(MainTask task)
    {
        TaskList.Add(task);
        TaskList.Sort((x, y) => x.Priority.CompareTo(y.Priority)); // Priorität sortieren
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
}
