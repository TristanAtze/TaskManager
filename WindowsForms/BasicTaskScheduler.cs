
using TaskClasses;
using System.Diagnostics;
using static HelperLibrary.TranslationManager;

using System;
using System.Windows.Forms;

namespace BasicTaskScheduler
{
    public class BasicTaskScheduler : Form
    {
        private ComboBox comboBoxPriority;
        private TextBox txtTimeAmount;
        private ComboBox comboBoxUnit;
        private Button btnSubmit;

        public static int Priority = 3;
        public static double TotalTime = 0;

        public BasicTaskScheduler()
        {
            this.Text = "Time and Priority Application";
            this.Width = 300;
            this.Height = 200;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // ComboBox für Priorität (Dropdown von "Sehr Wichtig" bis "Sehr Unwichtig")
            comboBoxPriority = new ComboBox();
            comboBoxPriority.Items.AddRange(new string[] 
            { 
                GetTranslation(GetCurrentLanguage(), "veryimportant_prioritys_taskcreator"),
                GetTranslation(GetCurrentLanguage(), "important_prioritys_taskcreator"),
                GetTranslation(GetCurrentLanguage(), "normalimportant_prioritys_taskcreator"),
                GetTranslation(GetCurrentLanguage(), "lessimportant_prioritys_taskcreator"),
                GetTranslation(GetCurrentLanguage(), "leastimportant_prioritys_taskcreator")
            });

            comboBoxPriority.SelectedIndex = 0;
            comboBoxPriority.Location = new System.Drawing.Point(10, 10);
            comboBoxPriority.Width = 150;
            this.Controls.Add(comboBoxPriority);

            // TextBox zur Eingabe der Anzahl (z. B. 5)
            txtTimeAmount = new TextBox();
            txtTimeAmount.Location = new System.Drawing.Point(10, 50);
            txtTimeAmount.Width = 50;
            this.Controls.Add(txtTimeAmount);

            // ComboBox für die Zeiteinheit (Sekunden, Minuten, Stunden, Tage, Monate)
            comboBoxUnit = new ComboBox();
            comboBoxUnit.Items.AddRange(new string[] 
            {
                GetTranslation(GetCurrentLanguage(), "seconds_taskcreator"),
                GetTranslation(GetCurrentLanguage(), "minutes_taskcreator"),
                GetTranslation(GetCurrentLanguage(), "hours_taskcreator"),
                GetTranslation(GetCurrentLanguage(), "days_taskcreator"),
                GetTranslation(GetCurrentLanguage(), "weeks_taskcreator"),
            });

            comboBoxUnit.SelectedIndex = 0;
            comboBoxUnit.Location = new System.Drawing.Point(70, 50);
            comboBoxUnit.Width = 100;
            this.Controls.Add(comboBoxUnit);

            // Button zum Auslösen der Verarbeitung
            btnSubmit = new Button();
            btnSubmit.Text = "Submit";
            btnSubmit.Location = new System.Drawing.Point(10, 90);
            btnSubmit.Click += btnSubmit_Click;
            this.Controls.Add(btnSubmit);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Erhalte den int-Wert für die Priorität anhand der Auswahl
            Priority = GetPriorityFromSelection(comboBoxPriority.SelectedItem.ToString());

            // Versuche, die Zeitanzahl als double zu parsen
            if (double.TryParse(txtTimeAmount.Text, out double timeAmount))
            {
                // Ermittle den Umrechnungsfaktor basierend auf der gewählten Zeiteinheit
                double factor = GetTimeFactor(comboBoxUnit.SelectedItem.ToString());
                TotalTime = timeAmount * factor;

                // Ausgabe der Ergebnisse
                //MessageBox.Show($"Priorität: {Priority}\nTime: {TotalTime}");
            }
            else
            {
                MessageBox.Show("Bitte geben Sie eine gültige Zahl für die Zeit ein.");
            }
            Close();
        }

        // Wandelt die ausgewählte Priorität in einen int-Wert um.
        // Hier wird angenommen: "Sehr Wichtig" = 1 (höchste Priorität), "Sehr Unwichtig" = 5 (niedrigste Priorität)
        private int GetPriorityFromSelection(string selection)
        {
            if (selection == GetTranslation(GetCurrentLanguage(), "veryimportant_prioritys_taskcreator"))
                return 1;
            if (selection == GetTranslation(GetCurrentLanguage(), "important_prioritys_taskcreator"))
                return 2;
            if (selection == GetTranslation(GetCurrentLanguage(), "normalimportant_prioritys_taskcreator"))
                return 3;
            if (selection == GetTranslation(GetCurrentLanguage(), "lessimportant_prioritys_taskcreator"))
                return 4;
            if (selection == GetTranslation(GetCurrentLanguage(), "leastimportant_prioritys_taskcreator"))
                return 5;

            return 3;
        }

        // Liefert den Umrechnungsfaktor für die Zeiteinheit.
        // Beispiel: 1 Minute = 60 Sekunden, 1 Stunde = 3600 Sekunden, usw.
        private double GetTimeFactor(string unit)
        {

            if (unit == GetTranslation(GetCurrentLanguage(), "seconds_taskcreator"))
                return 1;
            if (unit == GetTranslation(GetCurrentLanguage(), "minutes_taskcreator"))
                return 60;
            if (unit == GetTranslation(GetCurrentLanguage(), "hours_taskcreator"))
                return 3600;
            if (unit == GetTranslation(GetCurrentLanguage(), "days_taskcreator"))
                return 86400;
            if (unit == GetTranslation(GetCurrentLanguage(), "weeks_taskcreator"))
                return 2592000;

            return 1;
        }

        [STAThread]
        public static void Start()
        {
            Application.EnableVisualStyles();
            Application.Run(new BasicTaskScheduler());
        }
    }
}
