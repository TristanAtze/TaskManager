using static TranslationsLibrary.TranslationManager;

namespace WindowsForms
{
    partial class ConditionManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cpu = new CheckBox();
            afterBoot = new CheckBox();
            preShutDown = new CheckBox();
            save = new Button();
            SuspendLayout();
            // 
            // cpu
            // 
            cpu.AutoSize = true;
            cpu.Location = new Point(12, 12);
            cpu.Name = "cpu";
            cpu.Size = new Size(15, 14);
            cpu.TabIndex = 0;
            cpu.UseVisualStyleBackColor = true;
            cpu.MouseClick += CpuUsage_MouseClick;
            // 
            // afterBoot
            // 
            afterBoot.AutoSize = true;
            afterBoot.Location = new Point(12, 37);
            afterBoot.Name = "afterBoot";
            afterBoot.Size = new Size(15, 14);
            afterBoot.TabIndex = 1;
            afterBoot.UseVisualStyleBackColor = true;
            afterBoot.MouseClick += AfterBoot_MouseClick;
            // 
            // preShutDown
            // 
            preShutDown.AutoSize = true;
            preShutDown.Location = new Point(12, 62);
            preShutDown.Name = "preShutDown";
            preShutDown.Size = new Size(15, 14);
            preShutDown.TabIndex = 2;
            preShutDown.UseVisualStyleBackColor = true;
            preShutDown.MouseClick += PreShutDown_MouseClick;
            // 
            // save
            // 
            save.Location = new Point(42, 108);
            save.Name = "save";
            save.Size = new Size(75, 23);
            save.TabIndex = 3;
            save.Text = "button1";
            save.UseVisualStyleBackColor = true;
            save.MouseClick += Save_MouseClick;
            // 
            // ConditionManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(156, 143);
            ControlBox = false;
            Controls.Add(save);
            Controls.Add(preShutDown);
            Controls.Add(afterBoot);
            Controls.Add(cpu);
            Name = "ConditionManager";
            Text = "ConditionManager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cpu;
        private CheckBox afterBoot;
        private CheckBox preShutDown;
        private Button save;
    }
}