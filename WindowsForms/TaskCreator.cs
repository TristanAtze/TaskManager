using TaskClasses;
using static HelperLibrary.TranslationManager;
using static HelperLibrary.Config;
using System.Windows.Forms;
using WindowsForms;

namespace FileDialog;



public partial class TaskCreator : Form
{
    private static int? CheckNum { get; set; }
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
    private string _taskName;
    private string _taskFilePath;
    private DateTime _taskDateTime;
    private int _taskPriority;
    private bool _taskIsRecurring;
    private TimeSpan? _taskInterval;

    public bool CpuUsage;
    public bool JustBooted;
    public bool ShuttingDown;
    #endregion

    /// <summary>
    /// Konstruktor des Task-Erstellers.
    /// </summary>
    public TaskCreator()
    {
        InitializeComponent();

        MaximumSize = Size;
        MinimumSize = Size;

        #region Text bearbeiten
        name.Text = GetTranslation(GetCurrentLanguage(), "name_designer_taskcreator");
        actionButton.Text = GetTranslation(GetCurrentLanguage(), "choise_designer_taskcreator");
        isRecurring.Text = GetTranslation(GetCurrentLanguage(), "recurring_designer_taskcreator");
        filePath.Text = GetTranslation(GetCurrentLanguage(), "filePath_designer_taskcreator");
        saveButton.Text = GetTranslation(GetCurrentLanguage(), "save_designer_taskcreator");
        cancelButton.Text = GetTranslation(GetCurrentLanguage(), "cancel_designer_taskcreator");
        conditions.Text = GetTranslation(GetCurrentLanguage(), "condition_taskcreator");
        #endregion

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

        _taskName = "";
        _taskFilePath = "";
        _taskDateTime = date.Value;

        saveButton.Enabled = false;
    }

    public static void StartTaskCreator(int checkNum = 0)
    {
        CheckNum = checkNum;
        TaskCreator creator = new();
        Application.Run(creator);

    }

    //public TaskCreator(TaskScheduler taskScheduler, string taskName, string taskFilePath) : this(taskScheduler)
    //{
    //    //Überladener Konstruktor
    //}

    /// <summary>
    /// Prüft alle Bedingungen, ob der Save-Button aktiviert oder Deaktiviert werden muss.
    /// Wird nach jeder Wertänderung eines Eingabe-Feldes aufgerufen.
    /// </summary>
    private void UpdateSaveButton()
    {
        switch (_taskIsRecurring)
        {
            case true:
                if (_taskName != "" &&
                    _taskFilePath != "" &&
                    _taskInterval != null) saveButton.Enabled = true;
                else
                {
                    saveButton.Enabled = false;
                }
                break;
            case false:
                if (_taskName != "" &&
                    _taskFilePath != "") saveButton.Enabled = true;
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
        Close();
    }

    private void SaveButton_MouseClick(object sender, MouseEventArgs e)
    {
        OwnTask task = new OwnTask(_taskName, _taskFilePath, _taskDateTime, _taskPriority, _taskIsRecurring, _taskInterval)
        {
            ConditionCPUUsage = CpuUsage,
            ConditionJustBooted = JustBooted,
            ConditionShuttingDown = ShuttingDown
        };

        if (CheckNum == 1)
        {
            ReturnValue(task);
        }
        else
            TaskScheduler.ScheduleTask(task);

        Close();
    }



    public static MainTask ReturnValue(MainTask task)
    {
        SaveSettings(null, null, [task]);
        return task;
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
            int interval = 0;
            string? selectedItem = units.SelectedItem.ToString();

            if (selectedItem != null)
            {
                interval = value * _units[selectedItem];
            }

            _taskInterval = new TimeSpan((int)(interval * 1000000000));
            UpdateSaveButton();
        }

    }

    private void Units_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (units.SelectedItem != null && int.TryParse(interval.Text, out int value))
        {
            int interval = 0;
            string? selectedItem = units.SelectedItem.ToString();

            if (selectedItem != null)
            {
                interval = value * _units[selectedItem];
            }

            _taskInterval = new TimeSpan((int)(interval * 1000000000));
            UpdateSaveButton();
        }

    }

    private void Conditions_MouseClick(object sender, MouseEventArgs e)
    {
        ConditionManager manager = new(this);

        manager.ShowDialog();
    }
}
