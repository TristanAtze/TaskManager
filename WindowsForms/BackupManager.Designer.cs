using static HelperLibrary.TranslationManager;

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
            labelTitle = new Label();
            labelSource = new Label();
            textBoxSourceFolder = new TextBox();
            buttonBrowseSource = new Button();
            labelDestination = new Label();
            textBoxDestinationFolder = new TextBox();
            buttonBrowseDestination = new Button();
            labelBackupType = new Label();
            comboBoxBackupType = new ComboBox();
            labelAutomation = new Label();
            comboBoxAutomation = new ComboBox();
            buttonBackupStart = new Button();
            listViewActiveTasks = new ListView();
            columnHeaderTaskId = new ColumnHeader();
            columnHeaderSource = new ColumnHeader();
            columnHeaderDestination = new ColumnHeader();
            columnHeaderBackupType = new ColumnHeader();
            columnHeaderAutomation = new ColumnHeader();
            buttonStopSelectedTask = new Button();
            buttonStopAllTasks = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            labelTitle.Location = new Point(150, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(143, 26);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Backup Tool";
            // 
            // labelSource
            // 
            labelSource.AutoSize = true;
            labelSource.Location = new Point(30, 70);
            labelSource.Name = "labelSource";
            labelSource.Size = new Size(0, 15);
            labelSource.TabIndex = 1;
            // 
            // textBoxSourceFolder
            // 
            textBoxSourceFolder.Location = new Point(30, 90);
            textBoxSourceFolder.Name = "textBoxSourceFolder";
            textBoxSourceFolder.Size = new Size(400, 23);
            textBoxSourceFolder.TabIndex = 2;
            // 
            // buttonBrowseSource
            // 
            buttonBrowseSource.Location = new Point(440, 88);
            buttonBrowseSource.Name = "buttonBrowseSource";
            buttonBrowseSource.Size = new Size(100, 23);
            buttonBrowseSource.TabIndex = 3;

            buttonBrowseSource.UseVisualStyleBackColor = true;
            buttonBrowseSource.Click += ButtonBrowseSource_Click;
            // 
            // labelDestination
            // 
            labelDestination.AutoSize = true;
            labelDestination.Location = new Point(30, 130);
            labelDestination.Name = "labelDestination";
            labelDestination.Size = new Size(0, 15);
            labelDestination.TabIndex = 4;
            // 
            // textBoxDestinationFolder
            // 
            textBoxDestinationFolder.Location = new Point(30, 150);
            textBoxDestinationFolder.Name = "textBoxDestinationFolder";
            textBoxDestinationFolder.Size = new Size(400, 23);
            textBoxDestinationFolder.TabIndex = 5;
            // 
            // buttonBrowseDestination
            // 
            buttonBrowseDestination.Location = new Point(440, 148);
            buttonBrowseDestination.Name = "buttonBrowseDestination";
            buttonBrowseDestination.Size = new Size(100, 23);
            buttonBrowseDestination.TabIndex = 6;

            buttonBrowseDestination.UseVisualStyleBackColor = true;
            buttonBrowseDestination.Click += ButtonBrowseDestination_Click;
            // 
            // labelBackupType
            // 
            labelBackupType.AutoSize = true;
            labelBackupType.Location = new Point(30, 190);
            labelBackupType.Name = "labelBackupType";
            labelBackupType.Size = new Size(0, 15);
            labelBackupType.TabIndex = 7;
            // 
            // comboBoxBackupType
            // 
            comboBoxBackupType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBackupType.FormattingEnabled = true;

            comboBoxBackupType.Location = new Point(30, 210);
            comboBoxBackupType.Name = "comboBoxBackupType";
            comboBoxBackupType.Size = new Size(200, 23);
            comboBoxBackupType.TabIndex = 8;
            // 
            // labelAutomation
            // 
            labelAutomation.AutoSize = true;
            labelAutomation.Location = new Point(30, 250);
            labelAutomation.Name = "labelAutomation";
            labelAutomation.Size = new Size(0, 15);
            labelAutomation.TabIndex = 9;
            // 
            // comboBoxAutomation
            // 
            comboBoxAutomation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAutomation.FormattingEnabled = true;

            comboBoxAutomation.Location = new Point(30, 270);
            comboBoxAutomation.Name = "comboBoxAutomation";
            comboBoxAutomation.Size = new Size(200, 23);
            comboBoxAutomation.TabIndex = 10;
            // 
            // buttonBackupStart
            // 
            buttonBackupStart.Location = new Point(30, 310);
            buttonBackupStart.Name = "buttonBackupStart";
            buttonBackupStart.Size = new Size(120, 30);
            buttonBackupStart.TabIndex = 11;

            buttonBackupStart.UseVisualStyleBackColor = true;
            buttonBackupStart.Click += ButtonBackupStart_Click;
            // 
            // listViewActiveTasks
            // 
            listViewActiveTasks.Columns.AddRange(new ColumnHeader[] { columnHeaderTaskId, columnHeaderSource, columnHeaderDestination, columnHeaderBackupType, columnHeaderAutomation });
            listViewActiveTasks.FullRowSelect = true;
            listViewActiveTasks.GridLines = true;
            listViewActiveTasks.Location = new Point(30, 350);
            listViewActiveTasks.Name = "listViewActiveTasks";
            listViewActiveTasks.Size = new Size(510, 150);
            listViewActiveTasks.TabIndex = 13;
            listViewActiveTasks.UseCompatibleStateImageBehavior = false;
            listViewActiveTasks.View = View.Details;
            // 
            // columnHeaderTaskId
            // 

            // 
            // buttonStopSelectedTask
            // 
            buttonStopSelectedTask.Location = new Point(30, 520);
            buttonStopSelectedTask.Name = "buttonStopSelectedTask";
            buttonStopSelectedTask.Size = new Size(150, 30);
            buttonStopSelectedTask.TabIndex = 14;

            buttonStopSelectedTask.UseVisualStyleBackColor = true;
            buttonStopSelectedTask.Click += ButtonStopSelectedTask_Click;
            // 
            // buttonStopAllTasks
            // 
            buttonStopAllTasks.Location = new Point(200, 520);
            buttonStopAllTasks.Name = "buttonStopAllTasks";
            buttonStopAllTasks.Size = new Size(150, 30);
            buttonStopAllTasks.TabIndex = 15;

            buttonStopAllTasks.UseVisualStyleBackColor = true;
            buttonStopAllTasks.Click += ButtonStopAllTasks_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(584, 571);
            Controls.Add(buttonStopAllTasks);
            Controls.Add(buttonStopSelectedTask);
            Controls.Add(listViewActiveTasks);
            Controls.Add(buttonBackupStart);
            Controls.Add(comboBoxAutomation);
            Controls.Add(labelAutomation);
            Controls.Add(comboBoxBackupType);
            Controls.Add(labelBackupType);
            Controls.Add(buttonBrowseDestination);
            Controls.Add(textBoxDestinationFolder);
            Controls.Add(labelDestination);
            Controls.Add(buttonBrowseSource);
            Controls.Add(textBoxSourceFolder);
            Controls.Add(labelSource);
            Controls.Add(labelTitle);
            Name = "Form1";
            Text = "Backup Tool";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion
    }
}
