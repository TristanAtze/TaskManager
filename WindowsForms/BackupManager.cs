using Newtonsoft.Json;
using static HelperLibrary.TranslationManager;

namespace BackupTool
{
    public partial class Form1 : Form
    {
        // Liste für alle aktiven Backup-Tasks
        private List<BackupTask> backupTasks = new List<BackupTask>();

        public Form1()
        {
            InitializeComponent();
            buttonBrowseSource.Text = GetTranslation(GetCurrentLanguage(), "searching_designer_backupmanager");
            buttonBrowseDestination.Text = GetTranslation(GetCurrentLanguage(), "searching_designer_backupmanager");
            labelSource.Text = GetTranslation(GetCurrentLanguage(), "source_designer_backupmanager");
            labelDestination.Text = GetTranslation(GetCurrentLanguage(), "destination_folder_designer_backupmanager");
            comboBoxBackupType.Items.AddRange(new object[] { GetTranslation(GetCurrentLanguage(), "complete_backuptype_backupmanager"), GetTranslation(GetCurrentLanguage(), "incremental_backuptype_backupmanager"), GetTranslation(GetCurrentLanguage(), "differential_backuptype_backupmanager"), GetTranslation(GetCurrentLanguage(), "synchronize_backuptype_backupmanager") });
            labelAutomation.Text = GetTranslation(GetCurrentLanguage(), "automation_designer_backupmanager");
            labelBackupType.Text = GetTranslation(GetCurrentLanguage(), "backuptype_designer_backupmanager");

            comboBoxAutomation.Items.AddRange(new object[] { GetTranslation(GetCurrentLanguage(), "manual_automationmethod_backupmanager"), GetTranslation(GetCurrentLanguage(), "scheduled_automationmethod_backupmanager"), GetTranslation(GetCurrentLanguage(), "realtime_automationmethod_backupmanager") });
            buttonBackupStart.Text = GetTranslation(GetCurrentLanguage(), "startbackup_designer_backupmanager");

            columnHeaderTaskId.Text = GetTranslation(GetCurrentLanguage(), "taskid_designer_backupmanager");
            columnHeaderTaskId.Width = 150;

            columnHeaderSource.Text = GetTranslation(GetCurrentLanguage(), "source_designer_backupmanager");
            columnHeaderSource.Width = 100;

            columnHeaderDestination.Text = GetTranslation(GetCurrentLanguage(), "desti_designer_backupmanager");
            columnHeaderDestination.Width = 100;

            columnHeaderBackupType.Text = GetTranslation(GetCurrentLanguage(), "btype_designer_backupmanager");
            columnHeaderBackupType.Width = 75;

            columnHeaderAutomation.Text = GetTranslation(GetCurrentLanguage(), "bauto_designer_backupmanager");
            columnHeaderAutomation.Width = 75;
            buttonStopSelectedTask.Text = GetTranslation(GetCurrentLanguage(), "stopseltask_designer_backupmanager");
            buttonStopAllTasks.Text = GetTranslation(GetCurrentLanguage(), "stopalltask_designer_backupmanager"); ;

            comboBoxBackupType.SelectedIndex = -1;
            comboBoxAutomation.SelectedIndex = -1;
            buttonStopSelectedTask.Enabled = false;

            MaximumSize = Size;
            MinimumSize = Size;
        }

        /// <summary>
        /// Startet einen neuen Backup-Task.
        /// </summary>
        private void buttonBackupStart_Click(object sender, EventArgs e)
        {
            string sourceFolder = textBoxSourceFolder.Text;
            string destinationFolder = textBoxDestinationFolder.Text;
            string? backupType = comboBoxBackupType.SelectedItem?.ToString();
            string? automationMethod = comboBoxAutomation.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(sourceFolder) || string.IsNullOrWhiteSpace(destinationFolder))
            {
                MessageBox.Show(GetTranslation(GetCurrentLanguage(), "specify_source_destination_folder_button_backup_start_click_backupmanager"),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (backupType == null || automationMethod == null)
                return;

            // Neuen Task anlegen und starten
            BackupTask task = new (sourceFolder, destinationFolder, backupType, automationMethod);

            if(BackupManager.PlannedTasks != null)
            {
                BackupManager.PlannedTasks.Add(task);
                BackupManager.SaveTasks();
            }

            backupTasks.Add(task);
            task.Start();

            UpdateTaskListView();
        }

        /// <summary>
        /// Aktualisiert die Übersicht der aktiven Tasks.
        /// </summary>
        private void UpdateTaskListView()
        {
            listViewActiveTasks.Items.Clear();
            foreach (BackupTask? task in backupTasks)
            {
                if (task.IsActive)
                {
                    var item = new ListViewItem(task.TaskId.ToString());
                    item.SubItems.Add(task.SourceFolder);
                    item.SubItems.Add(task.DestinationFolder);
                    item.SubItems.Add(task.BackupType);
                    item.SubItems.Add(task.AutomationMethod);
                    listViewActiveTasks.Items.Add(item);
                }
            }
            // Schalte den Button "Stop Selected Task" nur frei, wenn mindestens ein Eintrag ausgewählt ist
            buttonStopSelectedTask.Enabled = true;
        }

        /// <summary>
        /// Stoppt den aktuell im ListView ausgewählten Task.
        /// </summary>
        private void ButtonStopSelectedTask_Click(object sender, EventArgs e)
        {
            if (listViewActiveTasks.SelectedItems.Count > 0)
            {
                var selectedItem = listViewActiveTasks.SelectedItems[0];
                Guid taskId = Guid.Parse(selectedItem.Text);
                var task = backupTasks.Find(t => t.TaskId == taskId);
                if (task != null)
                {
                    task.Stop();
                    backupTasks.Remove(task);
                    UpdateTaskListView();
                }
            }
        }

        /// <summary>
        /// Stoppt alle aktiven Tasks.
        /// </summary>
        private void ButtonStopAllTasks_Click(object sender, EventArgs e)
        {
            foreach (var task in backupTasks)
            {
                task.Stop();
            }
            backupTasks.Clear();
            UpdateTaskListView();
        }

        /// <summary>
        /// Öffnet den FolderBrowserDialog zur Auswahl des Quellordners.
        /// </summary>
        private void ButtonBrowseSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = GetTranslation(GetCurrentLanguage(), "choose_source_folder_backupmanager");
                if (!string.IsNullOrEmpty(textBoxSourceFolder.Text))
                    folderDialog.SelectedPath = textBoxSourceFolder.Text;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxSourceFolder.Text = folderDialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Öffnet den FolderBrowserDialog zur Auswahl des Zielordners.
        /// </summary>
        private void ButtonBrowseDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = GetTranslation(GetCurrentLanguage(), "choose_destination_folder_backupmanager");
                if (!string.IsNullOrEmpty(textBoxDestinationFolder.Text))
                    folderDialog.SelectedPath = textBoxDestinationFolder.Text;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxDestinationFolder.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    /// <summary>
    /// Repräsentiert einen einzelnen Backup-Task.
    /// </summary>
    public class BackupTask
    {
        public Guid? TaskId { get; private set; }
        public string? SourceFolder { get; private set; }
        public string? DestinationFolder { get; private set; }
        public string? BackupType { get; private set; }
        public string? AutomationMethod { get; private set; }
        public bool IsActive { get; private set; } = false;

        private System.Windows.Forms.Timer? plannedTimer;
        private System.Windows.Forms.Timer? debounceTimer;
        private FileSystemWatcher? fileWatcher { get; set; }

        public BackupTask(string source, string destination, string backupType, string automationMethod)
        {
            TaskId = Guid.NewGuid();
            SourceFolder = source;
            DestinationFolder = destination;
            BackupType = backupType;
            AutomationMethod = automationMethod;

            debounceTimer = new System.Windows.Forms.Timer();
        }

        /// <summary>
        /// Startet den Backup-Task abhängig vom Automatisierungsmodus.
        /// </summary>
        public void Start()
        {
            if (AutomationMethod == GetTranslation(GetCurrentLanguage(), "manual_automationmethod_backupmanager"))
            {
                // Bei manueller Ausführung: einmaliges Backup
                PerformBackup();
                IsActive = false;
            }
            else if (AutomationMethod == GetTranslation(GetCurrentLanguage(), "scheduled_automationmethod_backupmanager"))
            {
                plannedTimer = new System.Windows.Forms.Timer();
                plannedTimer.Interval = 60000; // 60 Sekunden
                plannedTimer.Tick += (s, e) => PerformBackup();
                plannedTimer.Start();
                IsActive = true;
            }
            else if (AutomationMethod == GetTranslation(GetCurrentLanguage(), "realtime_automationmethod_backupmanager"))
            {
                plannedTimer = new System.Windows.Forms.Timer();
                plannedTimer.Interval = 5000; // 5 Sekunden
                plannedTimer.Tick += (s, e) => PerformBackup();
                plannedTimer.Start();
                IsActive = true;
            }
        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (debounceTimer != null)
            {
                debounceTimer.Stop();
                debounceTimer.Start();
            }
        }

        /// <summary>
        /// Stoppt den Task und gibt verwendete Ressourcen frei.
        /// </summary>
        public void Stop()
        {
            if (plannedTimer != null)
            {
                plannedTimer.Stop();
                plannedTimer.Dispose();
            }
            if (fileWatcher != null)
            {
                fileWatcher.EnableRaisingEvents = false;
                fileWatcher.Dispose();
            }
            if (debounceTimer != null)
            {
                debounceTimer.Stop();
                debounceTimer.Dispose();
            }
            IsActive = false;
        }

        /// <summary>
        /// Führt das Backup aus.
        /// </summary>
        private void PerformBackup()
        {
            try
            {
                if (SourceFolder != DestinationFolder
                    && !SourceFolder.Contains("TaskScheduler")
                    && !DestinationFolder.Contains("TaskScheduler"))
                    BackupManager.PerformBackup(SourceFolder, DestinationFolder, BackupType);
                else
                    NotificationManager.SendNotification("ERROR. Please Retry");
            }
            catch (Exception ex)
            {
                MessageBox.Show(GetTranslation(GetCurrentLanguage(), "backupfailed_backupmanager") + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// BackupManager enthält die Logik für die unterschiedlichen Backup-Methoden.
    /// (Unverändert aus Deinem ursprünglichen Code)
    /// </summary>
    public static class BackupManager
    {
        public static List<BackupTask>? PlannedTasks { get; set; }

        private static string markerFileName = "fullBackupMarker.txt";

        static BackupManager()
        {
            if (!File.Exists("BackupTasks.json"))
            {
                File.Create("BackupTasks.json");
            }

            var content = File.ReadAllText("BackupTasks.json");

            PlannedTasks = JsonConvert.DeserializeObject<List<BackupTask>>(content);

            if (PlannedTasks == null)
                PlannedTasks = [];
        }

        public static void SaveTasks()
        {
            if (!File.Exists("BackupTasks.json"))
            {
                File.Create("BackupTasks.json");
            }

            var content = JsonConvert.SerializeObject(PlannedTasks);

            File.WriteAllText("BackupTasks.json", content);
        }

        public static void PerformBackup(string? sourceFolder, string? destinationFolder, string? backupType)
        {
            if (!Directory.Exists(sourceFolder))
                throw new Exception("Quellordner existiert nicht.");
            if (!Directory.Exists(destinationFolder) && destinationFolder != null)
                Directory.CreateDirectory(destinationFolder);

            if (backupType == GetTranslation(GetCurrentLanguage(), "complete_backuptype_backupmanager") && destinationFolder != null)
                CopyAll(new DirectoryInfo(sourceFolder), new DirectoryInfo(destinationFolder));
            else if (backupType == GetTranslation(GetCurrentLanguage(), "incremental_backuptype_backupmanager") && destinationFolder != null)
                CopyIncremental(new DirectoryInfo(sourceFolder), new DirectoryInfo(destinationFolder));
            else if (backupType == GetTranslation(GetCurrentLanguage(), "differential_backuptype_backupmanager") && destinationFolder != null)
                CopyDifferential(new DirectoryInfo(sourceFolder), new DirectoryInfo(destinationFolder));
            else if (backupType == GetTranslation(GetCurrentLanguage(), "synchronize_backuptype_backupmanager") && destinationFolder != null)
                Synchronize(new DirectoryInfo(sourceFolder), new DirectoryInfo(destinationFolder));
            else
                throw new Exception(GetTranslation(GetCurrentLanguage(), "unknown_backuptype_backupmanager"));
        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (FileInfo file in source.GetFiles())
            {
                string targetFilePath = Path.Combine(target.FullName, file.Name);
                file.CopyTo(targetFilePath, true);
            }
            foreach (DirectoryInfo subDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(subDir.Name);
                CopyAll(subDir, nextTargetSubDir);
            }
        }

        private static void CopyIncremental(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (FileInfo file in source.GetFiles())
            {
                string targetFilePath = Path.Combine(target.FullName, file.Name);
                if (!File.Exists(targetFilePath))
                {
                    file.CopyTo(targetFilePath, true);
                }
                else
                {
                    FileInfo targetFile = new FileInfo(targetFilePath);
                    if (file.LastWriteTime > targetFile.LastWriteTime)
                    {
                        file.CopyTo(targetFilePath, true);
                    }
                }
            }
            foreach (DirectoryInfo subDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(subDir.Name);
                CopyIncremental(subDir, nextTargetSubDir);
            }
        }

        private static void CopyDifferential(DirectoryInfo source, DirectoryInfo target)
        {
            string markerPath = Path.Combine(target.FullName, markerFileName);
            DateTime fullBackupTime;

            if (!File.Exists(markerPath))
            {
                CopyAll(source, target);
                fullBackupTime = DateTime.Now;
                File.WriteAllText(markerPath, fullBackupTime.ToString("o"));
            }
            else
            {
                string markerContent = File.ReadAllText(markerPath);
                if (!DateTime.TryParse(markerContent, null, System.Globalization.DateTimeStyles.RoundtripKind, out fullBackupTime))
                {
                    CopyAll(source, target);
                    fullBackupTime = DateTime.Now;
                    File.WriteAllText(markerPath, fullBackupTime.ToString("o"));
                    return;
                }
                CopyDifferentialRecursive(source, target, fullBackupTime);
            }
        }

        private static void CopyDifferentialRecursive(DirectoryInfo source, DirectoryInfo target, DateTime fullBackupTime)
        {
            foreach (FileInfo file in source.GetFiles())
            {
                if (file.LastWriteTime > fullBackupTime)
                {
                    string targetFilePath = Path.Combine(target.FullName, file.Name);
                    file.CopyTo(targetFilePath, true);
                }
            }
            foreach (DirectoryInfo subDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(subDir.Name);
                CopyDifferentialRecursive(subDir, nextTargetSubDir, fullBackupTime);
            }
        }

        private static void Synchronize(DirectoryInfo source, DirectoryInfo target)
        {
            if (!target.Exists)
                target.Create();
            foreach (FileInfo sourceFile in source.GetFiles())
            {
                string targetFilePath = Path.Combine(target.FullName, sourceFile.Name);
                if (!File.Exists(targetFilePath))
                {
                    sourceFile.CopyTo(targetFilePath, true);
                }
                else
                {
                    FileInfo targetFile = new FileInfo(targetFilePath);
                    if (sourceFile.LastWriteTime > targetFile.LastWriteTime)
                    {
                        sourceFile.CopyTo(targetFilePath, true);
                    }
                }
            }
            foreach (DirectoryInfo sourceSubDir in source.GetDirectories())
            {
                string targetSubDirPath = Path.Combine(target.FullName, sourceSubDir.Name);
                DirectoryInfo targetSubDir = new DirectoryInfo(targetSubDirPath);
                Synchronize(sourceSubDir, targetSubDir);
            }
            foreach (FileInfo targetFile in target.GetFiles())
            {
                string sourceFilePath = Path.Combine(source.FullName, targetFile.Name);
                if (!File.Exists(sourceFilePath))
                {
                    targetFile.Delete();
                }
            }
            foreach (DirectoryInfo targetSubDir in target.GetDirectories())
            {
                string sourceSubDirPath = Path.Combine(source.FullName, targetSubDir.Name);
                if (!Directory.Exists(sourceSubDirPath))
                {
                    targetSubDir.Delete(true);
                }
            }
        }
    }
}
