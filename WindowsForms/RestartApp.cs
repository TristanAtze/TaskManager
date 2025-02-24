using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HelperLibrary.TranslationManager;

namespace RestartApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.Load += MainForm_Load; // Beim Laden ausführen
        }

        private async void MainForm_Load(object? sender, EventArgs e)
        {
            string processName = "TaskSchedulerApp"; 

            // 1️ Beende alle laufenden Instanzen des Programms
            KillProcess(processName);

            MessageBox.Show(GetTranslation(GetCurrentLanguage(), "programmrestarting_restartapp"), GetTranslation(GetCurrentLanguage(), "restart_restartapp"), MessageBoxButtons.OK, MessageBoxIcon.Information);

            //await Task.Delay(2000);

            StartProcess(processName);

            Application.Exit();
            await Task.Delay(200);
        }

        private void KillProcess(string processName)
        {
            int currentProcessId = Process.GetCurrentProcess().Id;

            foreach (var process in Process.GetProcessesByName(processName))
            {
                if (process.Id == currentProcessId)
                    continue;

                try
                {
                    process.Kill();
                    process.WaitForExit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Beenden des Prozesses {processName}: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void StartProcess(string processName)
        {
            string exePath = Application.StartupPath + "\\" + processName + ".exe";
            if (System.IO.File.Exists(exePath))
            {
                Process.Start(exePath);
            }
            else
            {
                MessageBox.Show($"Die EXE wurde nicht gefunden: {exePath}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
