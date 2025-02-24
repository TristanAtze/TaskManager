using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskClasses
{
    /// <summary>
    /// Überklasse für alle Tasks. Individuelle wie vorgefertigte.
    /// </summary>
    public class MainTask
    {
        /// <summary>
        /// Name der Task.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Zeitpunkt zu dem die Task ausgeführt werden soll.
        /// </summary>
        public DateTime ScheduledTime { get; set; }

        /// <summary>
        /// Priorität der Task.
        /// </summary>
        public int Priority { get; set; } // 1 = high, 5 = low

        /// <summary>
        /// Wahrheitswert, ob sich die Task wiederholen soll.
        /// True wenn ja, andernfalls False
        /// </summary>
        public bool IsRecurring { get; set; }

        /// <summary>
        /// Intervall in dem sich die Task wiederholen soll, wenn sie sich wiederholen soll.
        /// </summary>
        public TimeSpan? Interval { get; set; } // Für wiederkehrende Aufgaben

        /// <summary>
        /// Wahrheitswert, der angibt ob der task von der CPU-Auslastung abhängig ist.
        /// </summary>
        public bool ConditionCPUUsage { get; set; }

        /// <summary>
        /// Wahrheitswert, der angibt ob der Task nur nach Starten des PC's ausgeführt wird.
        /// </summary>
        public bool ConditionJustBooted { get; set; }

        /// <summary>
        /// Wahrheitswert, der angibt ob der Task nur vor Herunterfahren ausgeführt wird.
        /// </summary>
        public bool ConditionShuttingDown { get; set; }

        /// <summary>
        /// Die spezifische Art und Weise, wie eine Task ausgeführt werden soll
        /// </summary>
        public virtual void Execute() { }
    }
}