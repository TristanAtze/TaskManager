using System.Diagnostics;
using System.Runtime.InteropServices;
using static HelperLibrary.TranslationManager;

namespace RestartApp
{
    public partial class MainForm : Form
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_MINIMIZE = 6;
        const int SW_RESTORE = 9;

        public MainForm()
        {
            this.Load += MainForm_Load; // Beim Laden ausführen
        }

        private async void MainForm_Load(object? sender, EventArgs e)
        {
            var lockInput = Task.Run(LockInput);
            string processName = "TaskSchedulerApp";

            // 1️ Beende alle laufenden Instanzen des Programms
            KillProcess(processName);
            StartProcess(processName);
            //MessageBox.Show(GetTranslation(GetCurrentLanguage(), "programmrestarting_restartapp"), GetTranslation(GetCurrentLanguage(), "restart_restartapp"), MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 2 Starte das Programm neu
            

            await lockInput;
            Application.Exit();
            await Task.Delay(200);
        }

        private async Task LockInput()
        {
            IntPtr consoleHandle = GetConsoleWindow();
            ShowWindow(consoleHandle, SW_MINIMIZE); // Minimiert das Fenster
            Thread.Sleep(2000);                      // Warte 5 Sekunden
            ShowWindow(consoleHandle, SW_RESTORE);   // Stellt das Fenster wieder her
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
