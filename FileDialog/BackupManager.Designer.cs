using static TranslationsLibrary.TranslationManager;

namespace BackupTool
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Alte Steuerelemente
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.TextBox textBoxSourceFolder;
        private System.Windows.Forms.Button buttonBrowseSource;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.TextBox textBoxDestinationFolder;
        private System.Windows.Forms.Button buttonBrowseDestination;
        private System.Windows.Forms.Label labelBackupType;
        private System.Windows.Forms.ComboBox comboBoxBackupType;
        private System.Windows.Forms.Label labelAutomation;
        private System.Windows.Forms.ComboBox comboBoxAutomation;
        private System.Windows.Forms.Button buttonBackupStart;
        private System.Windows.Forms.Button buttonStopAutomation;

        // Neue Steuerelemente für die Multi-Task-Verwaltung
        private System.Windows.Forms.ListView listViewActiveTasks;
        private System.Windows.Forms.ColumnHeader columnHeaderTaskId;
        private System.Windows.Forms.ColumnHeader columnHeaderSource;
        private System.Windows.Forms.ColumnHeader columnHeaderDestination;
        private System.Windows.Forms.ColumnHeader columnHeaderBackupType;
        private System.Windows.Forms.ColumnHeader columnHeaderAutomation;
        private System.Windows.Forms.Button buttonStopSelectedTask;
        private System.Windows.Forms.Button buttonStopAllTasks;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            // Alte Controls
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSource = new System.Windows.Forms.Label();
            this.textBoxSourceFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowseSource = new System.Windows.Forms.Button();
            this.labelDestination = new System.Windows.Forms.Label();
            this.textBoxDestinationFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowseDestination = new System.Windows.Forms.Button();
            this.labelBackupType = new System.Windows.Forms.Label();
            this.comboBoxBackupType = new System.Windows.Forms.ComboBox();
            this.labelAutomation = new System.Windows.Forms.Label();
            this.comboBoxAutomation = new System.Windows.Forms.ComboBox();
            this.buttonBackupStart = new System.Windows.Forms.Button();
            this.buttonStopAutomation = new System.Windows.Forms.Button();
            // Neue Controls
            this.listViewActiveTasks = new System.Windows.Forms.ListView();
            this.columnHeaderTaskId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDestination = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBackupType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAutomation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonStopSelectedTask = new System.Windows.Forms.Button();
            this.buttonStopAllTasks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(150, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(134, 26);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Backup Tool";
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(30, 70);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(67, 13);
            this.labelSource.TabIndex = 1;
            this.labelSource.Text = GetTranslation(GetCurrentLanguage(), "source_folder_designer_backupmanager");
            // 
            // textBoxSourceFolder
            // 
            this.textBoxSourceFolder.Location = new System.Drawing.Point(30, 90);
            this.textBoxSourceFolder.Name = "textBoxSourceFolder";
            this.textBoxSourceFolder.Size = new System.Drawing.Size(400, 20);
            this.textBoxSourceFolder.TabIndex = 2;
            // 
            // buttonBrowseSource
            // 
            this.buttonBrowseSource.Location = new System.Drawing.Point(440, 88);
            this.buttonBrowseSource.Name = "buttonBrowseSource";
            this.buttonBrowseSource.Size = new System.Drawing.Size(100, 23);
            this.buttonBrowseSource.TabIndex = 3;
            this.buttonBrowseSource.Text = GetTranslation(GetCurrentLanguage(), "searching_designer_backupmanager");
            this.buttonBrowseSource.UseVisualStyleBackColor = true;
            this.buttonBrowseSource.Click += new System.EventHandler(this.buttonBrowseSource_Click);
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(30, 130);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(63, 13);
            this.labelDestination.TabIndex = 4;
            this.labelDestination.Text = GetTranslation(GetCurrentLanguage(), "destination_folder_designer_backupmanager");
            // 
            // textBoxDestinationFolder
            // 
            this.textBoxDestinationFolder.Location = new System.Drawing.Point(30, 150);
            this.textBoxDestinationFolder.Name = "textBoxDestinationFolder";
            this.textBoxDestinationFolder.Size = new System.Drawing.Size(400, 20);
            this.textBoxDestinationFolder.TabIndex = 5;
            // 
            // buttonBrowseDestination
            // 
            this.buttonBrowseDestination.Location = new System.Drawing.Point(440, 148);
            this.buttonBrowseDestination.Name = "buttonBrowseDestination";
            this.buttonBrowseDestination.Size = new System.Drawing.Size(100, 23);
            this.buttonBrowseDestination.TabIndex = 6;
            this.buttonBrowseDestination.Text = GetTranslation(GetCurrentLanguage(), "searching_designer_backupmanager");
            this.buttonBrowseDestination.UseVisualStyleBackColor = true;
            this.buttonBrowseDestination.Click += new System.EventHandler(this.buttonBrowseDestination_Click);
            // 
            // labelBackupType
            // 
            this.labelBackupType.AutoSize = true;
            this.labelBackupType.Location = new System.Drawing.Point(30, 190);
            this.labelBackupType.Name = "labelBackupType";
            this.labelBackupType.Size = new System.Drawing.Size(64, 13);
            this.labelBackupType.TabIndex = 7;
            this.labelBackupType.Text = GetTranslation(GetCurrentLanguage(), "backuptype_designer_backupmanager");
            // 
            // comboBoxBackupType
            // 
            this.comboBoxBackupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBackupType.FormattingEnabled = true;
            this.comboBoxBackupType.Items.AddRange(new object[] {
            GetTranslation(GetCurrentLanguage(), "complete_backuptype_backupmanager"),
            GetTranslation(GetCurrentLanguage(), "incremental_backuptype_backupmanager"),
            GetTranslation(GetCurrentLanguage(), "differential_backuptype_backupmanager"),
            GetTranslation(GetCurrentLanguage(), "synchronize_backuptype_backupmanager")});
            this.comboBoxBackupType.Location = new System.Drawing.Point(30, 210);
            this.comboBoxBackupType.Name = "comboBoxBackupType";
            this.comboBoxBackupType.Size = new System.Drawing.Size(200, 21);
            this.comboBoxBackupType.TabIndex = 8;
            // 
            // labelAutomation
            // 
            this.labelAutomation.AutoSize = true;
            this.labelAutomation.Location = new System.Drawing.Point(30, 250);
            this.labelAutomation.Name = "labelAutomation";
            this.labelAutomation.Size = new System.Drawing.Size(80, 13);
            this.labelAutomation.TabIndex = 9;
            this.labelAutomation.Text = GetTranslation(GetCurrentLanguage(), "automation_designer_backupmanager");
            // 
            // comboBoxAutomation
            // 
            this.comboBoxAutomation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAutomation.FormattingEnabled = true;
            this.comboBoxAutomation.Items.AddRange(new object[] {
            GetTranslation(GetCurrentLanguage(), "manual_automationmethod_backupmanager"),
            GetTranslation(GetCurrentLanguage(), "scheduled_automationmethod_backupmanager"),
            GetTranslation(GetCurrentLanguage(), "realtime_automationmethod_backupmanager")});
            this.comboBoxAutomation.Location = new System.Drawing.Point(30, 270);
            this.comboBoxAutomation.Name = "comboBoxAutomation";
            this.comboBoxAutomation.Size = new System.Drawing.Size(200, 21);
            this.comboBoxAutomation.TabIndex = 10;
            // 
            // buttonBackupStart
            // 
            this.buttonBackupStart.Location = new System.Drawing.Point(30, 310);
            this.buttonBackupStart.Name = "buttonBackupStart";
            this.buttonBackupStart.Size = new System.Drawing.Size(120, 30);
            this.buttonBackupStart.TabIndex = 11;
            this.buttonBackupStart.Text = GetTranslation(GetCurrentLanguage(), "startbackup_designer_backupmanager");
            this.buttonBackupStart.UseVisualStyleBackColor = true;
            this.buttonBackupStart.Click += new System.EventHandler(this.buttonBackupStart_Click);
            // 
            // buttonStopAutomation
            // 
            
            //this.buttonStopAutomation.Click += new System.EventHandler(this.buttonStopAutomation_Click);
            // 
            // listViewActiveTasks
            // 
            this.listViewActiveTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTaskId,
            this.columnHeaderSource,
            this.columnHeaderDestination,
            this.columnHeaderBackupType,
            this.columnHeaderAutomation});
            this.listViewActiveTasks.FullRowSelect = true;
            this.listViewActiveTasks.GridLines = true;
            this.listViewActiveTasks.HideSelection = false;
            this.listViewActiveTasks.Location = new System.Drawing.Point(30, 350);
            this.listViewActiveTasks.Name = "listViewActiveTasks";
            this.listViewActiveTasks.Size = new System.Drawing.Size(510, 150);
            this.listViewActiveTasks.TabIndex = 13;
            this.listViewActiveTasks.UseCompatibleStateImageBehavior = false;
            this.listViewActiveTasks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTaskId
            // 
            this.columnHeaderTaskId.Text = GetTranslation(GetCurrentLanguage(), "taskid_designer_backupmanager");
            this.columnHeaderTaskId.Width = 150;
            // 
            // columnHeaderSource
            // 
            this.columnHeaderSource.Text = GetTranslation(GetCurrentLanguage(), "source_designer_backupmanager");
            this.columnHeaderSource.Width = 100;
            // 
            // columnHeaderDestination
            // 
            this.columnHeaderDestination.Text = GetTranslation(GetCurrentLanguage(), "desti_designer_backupmanager");
            this.columnHeaderDestination.Width = 100;
            // 
            // columnHeaderBackupType
            // 
            this.columnHeaderBackupType.Text = GetTranslation(GetCurrentLanguage(), "btype_designer_backupmanager");
            this.columnHeaderBackupType.Width = 75;
            // 
            // columnHeaderAutomation
            // 
            this.columnHeaderAutomation.Text = GetTranslation(GetCurrentLanguage(), "bauto_designer_backupmanager");
            this.columnHeaderAutomation.Width = 75;
            // 
            // buttonStopSelectedTask
            // 
            this.buttonStopSelectedTask.Location = new System.Drawing.Point(30, 520);
            this.buttonStopSelectedTask.Name = "buttonStopSelectedTask";
            this.buttonStopSelectedTask.Size = new System.Drawing.Size(150, 30);
            this.buttonStopSelectedTask.TabIndex = 14;
            this.buttonStopSelectedTask.Text = GetTranslation(GetCurrentLanguage(), "stopseltask_designer_backupmanager");
            this.buttonStopSelectedTask.UseVisualStyleBackColor = true;
            this.buttonStopSelectedTask.Click += new System.EventHandler(this.buttonStopSelectedTask_Click);
            // 
            // buttonStopAllTasks
            // 
            this.buttonStopAllTasks.Location = new System.Drawing.Point(200, 520);
            this.buttonStopAllTasks.Name = "buttonStopAllTasks";
            this.buttonStopAllTasks.Size = new System.Drawing.Size(150, 30);
            this.buttonStopAllTasks.TabIndex = 15;
            this.buttonStopAllTasks.Text = GetTranslation(GetCurrentLanguage(), "stopalltask_designer_backupmanager");
            this.buttonStopAllTasks.UseVisualStyleBackColor = true;
            this.buttonStopAllTasks.Click += new System.EventHandler(this.buttonStopAllTasks_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(584, 571);
            this.Controls.Add(this.buttonStopAllTasks);
            this.Controls.Add(this.buttonStopSelectedTask);
            this.Controls.Add(this.listViewActiveTasks);
            this.Controls.Add(this.buttonStopAutomation);
            this.Controls.Add(this.buttonBackupStart);
            this.Controls.Add(this.comboBoxAutomation);
            this.Controls.Add(this.labelAutomation);
            this.Controls.Add(this.comboBoxBackupType);
            this.Controls.Add(this.labelBackupType);
            this.Controls.Add(this.buttonBrowseDestination);
            this.Controls.Add(this.textBoxDestinationFolder);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.buttonBrowseSource);
            this.Controls.Add(this.textBoxSourceFolder);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.labelTitle);
            this.Name = "Form1";
            this.Text = "Backup Tool";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
