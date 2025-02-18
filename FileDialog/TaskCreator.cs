
using TaskClasses;
using System.Diagnostics;
using static TranslationsLibrary.TranslationManager;
namespace FileDialog;

public partial class TaskCreator : Form
{
    /// <summary>
    /// Array mit allen möglichen Prioritäten, die zur Auswahl stehen.
    /// </summary>
    private readonly string[] _prioritys =
    {
        GetTranslation(GetCurrentLanguage(), "veryimportant_prioritys_taskcreator"),
        GetTranslation(GetCurrentLanguage(), "important_prioritys_taskcreator"),
        GetTranslation(GetCurrentLanguage(), "normalimportant_prioritys_taskcreator"),
        GetTranslation(GetCurrentLanguage(), "lessimportant_prioritys_taskcreator"),
        GetTranslation(GetCurrentLanguage(), "leastimportant_prioritys_taskcreator")
    };


    private readonly Dictionary<string, int> _units = new Dictionary<string, int>()
    {
        {GetTranslation(GetCurrentLanguage(), "seconds_taskcreator"), 1 },
        {GetTranslation(GetCurrentLanguage(), "minutes_taskcreator"), 60 },
        {GetTranslation(GetCurrentLanguage(), "hours_taskcreator"), 3600 },
        {GetTranslation(GetCurrentLanguage(), "days_taskcreator"), 86400 },
        {GetTranslation(GetCurrentLanguage(), "weeks_taskcreator"), 604800 }
    };

    /// <summary>
    /// Werte die für das Erstellen einer neuen Task gebraucht werden.
    /// </summary>
    #region Werte für neuen Task
    private string _taskName = "";
    private string _taskFilePath = "";
    private DateTime _taskDateTime = DateTime.Now;
    private int _taskPriority = 3;
    private bool _taskIsRecurring = false;
    private TimeSpan? _taskInterval = null;
    #endregion

    /// <summary>
    /// Das Scheduler-Objekt, für das eine neue Task erstellt wird.
    /// </summary>
    private TaskScheduler Scheduler { get; set; }

    /// <summary>
    /// Konstruktor des Task-Erstellers.
    /// </summary>
    public TaskCreator(TaskScheduler taskScheduler)
    {
        Scheduler = taskScheduler;

        InitializeComponent();

        #region Fill Prioritys
        foreach (var item in _prioritys)
        {
            priority.Items.Add(item);
        }
        #endregion

        #region Fill Units
        foreach (var item in _units)
        {
            units.Items.Add(item.Key);
        }
        #endregion

        _taskDateTime = date.Value;
        saveButton.Enabled = false;
    }

    /// <summary>
    /// Prüft alle Bedingungen, ob der Save-Button aktiviert oder Deaktiviert werden muss.
    /// Wird nach jeder Wertänderung eines Eingabe-Feldes aufgerufen.
    /// </summary>
    private void UpdateSaveButton()
    {
        switch (_taskIsRecurring)
        {
            case true:
                if (_taskName != null &&
                    _taskFilePath != null &&
                    _taskInterval != null) saveButton.Enabled = true;
                else
                {
                    saveButton.Enabled = false;
                }
                break;
            case false:
                if (_taskName != null &&
                    _taskFilePath != null) saveButton.Enabled = true;
                else
                {
                    saveButton.Enabled = false;
                }
                break;
        }
    }

    /// <summary>
    /// Wandelt die ausgewählte string-Priorität in einen Integer um und gibt diesen zurück.
    /// </summary>
    /// <param name="selectedPriority">string-Priorität</param>
    /// <returns>Integer</returns>
    private int ConvertPriority(string selectedPriority)
    {
        int result = 3;
        if (selectedPriority == GetTranslation(GetCurrentLanguage(), "veryimportant_prioritys_taskcreator"))
            result = 1;
        else if (selectedPriority == GetTranslation(GetCurrentLanguage(), "important_prioritys_taskcreator"))
            result = 2;
        else if (selectedPriority == GetTranslation(GetCurrentLanguage(), "normalimportant_prioritys_taskcreator"))
            result = 3;
        else if (selectedPriority == GetTranslation(GetCurrentLanguage(), "lessimportant_prioritys_taskcreator"))
            result = 4;
        else if (selectedPriority == GetTranslation(GetCurrentLanguage(), "leastimportant_prioritys_taskcreator"))
            result = 5;

        return result;
    }

    private void Name_TextChanged(object sender, EventArgs e)
    {
        _taskName = name.Text;

        UpdateSaveButton();
    }

    private void FilePath_TextChanged(object sender, EventArgs e)
    {
        _taskFilePath = filePath.Text;

        UpdateSaveButton();
    }

    private void Priority_DropDown(object sender, EventArgs e)
    {
        priority.Items.Remove(GetTranslation(GetCurrentLanguage(), "priority_taskcreator"));
    }

    private void Units_DropDown(object sender, EventArgs e)
    {
        units.Items.Remove(GetTranslation(GetCurrentLanguage(), "unit_taskcreator"));
    }

    private void IsRecurring_MouseClick(object sender, MouseEventArgs e)
    {
        switch (_taskIsRecurring)
        {
            case true:
                _taskIsRecurring = false;
                interval.Enabled = false;
                units.Enabled = false;
                break;
            case false:
                _taskIsRecurring = true;
                interval.Enabled = true;
                units.Enabled = true;
                break;
            default:
        }

        UpdateSaveButton();
    }

    private void ActionButton_MouseClick(object sender, MouseEventArgs e)
    {
        actionDialog.Filter = "(*.exe)|*.exe|All files (*.*)|*.*";
        actionDialog.ShowDialog();
        filePath.Text = actionDialog.FileName;

        _taskFilePath = filePath.Text;
    }

    private void CancelButton_MouseClick(object sender, MouseEventArgs e)
    {
        Application.Exit();
    }

    private void SaveButton_MouseClick(object sender, MouseEventArgs e)
    {
        var task = new OwnTask(_taskName,
            _taskFilePath,
            _taskDateTime,
            _taskPriority,
            _taskIsRecurring,
            _taskInterval);

        Scheduler.ScheduleTask(task);
        Application.Exit();
    }

    private void DateTime_ValueChanged(object sender, EventArgs e)
    {
        _taskDateTime = date.Value;

        UpdateSaveButton();
    }

    private void Priority_SelectedIndexChanged(object sender, EventArgs e)
    {
        _taskPriority = ConvertPriority(priority.SelectedText);

        UpdateSaveButton();
    }

    private void Interval_TextChanged(object sender, EventArgs e)
    {
        if (units.SelectedItem != null && int.TryParse(interval.Text, out int value))
        {
            int interval = value * _units[units.SelectedItem.ToString()];

            _taskInterval = new TimeSpan(interval * 1000000000);
        }

        UpdateSaveButton();
    }

    private void Units_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (units.SelectedItem != null && int.TryParse(interval.Text, out int value))
        {
            int interval = value * _units[units.SelectedItem.ToString()];

            _taskInterval = new TimeSpan(interval * 1000000000);
        }

        UpdateSaveButton();
    }
}
