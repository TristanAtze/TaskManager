using System;
using System.Collections.Generic;

namespace HelperLibrary
{
    public static class TranslationManager
    {
        public static string CurrentLanguage { get; set; } = "de";
        /// <summary>
        /// Ist Das Dictionary für die übersetzung. Darf nur über die dafür vorgesehene methode aufgerufen werden
        /// Die übergebenen Parameter definieren dabei die jeweiligen Schwellenwerte.
        /// </summary>
        public static readonly Dictionary<string, Dictionary<string, string>> translations = new()
        {
            {
                "de", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    //Test
                    { "welcome", "Willkommen im Hauptmenü:" },

                    //Language Menü
                    { "language_option", "Sprache ändern" },
                    { "choose_language", "Wähle eine Sprache:" },
                    { "back_option", "Zurück zum Hauptmenü" },

                    //Mainmenu
                    { "headline_mainmenu", "Hauptmenü" },
                    { "newtask_options_mainmenu", "[ neuen Task erstellen ]" },
                    { "showtask_options_mainmenu", "[ alle Tasks anzeigen ]" },
                    { "loadpreset_options_mainmenu", "[ Voreinstellungen laden ]" },
                    { "settings_options_mainmenu", "[ Einstellungen ]" },
                    { "end_options_mainmenu", "[ Beenden ]" },

                    //MainMenu - Task-Ausgabe
                    {"headline_printtasks_mainmenu", "\nAusstehende Tasks:\n------------------\n" },
                    {"name_printtasks_mainmenu", "[ Name ] = " },
                    {"priority_printtasks_mainmenu", "[ Priorität ] = " },
                    {"date_printtasks_mainmenu", "[ Datum ] = " },
                    {"interval_printtasks_mainmenu", "[ Intervall ]" },

                    //CreateTaskMenu - Optionen
                    {"headline_createtaskmenu", "Task erstellen" },
                    {"individualtask_createtaskmenu", "[ individueller Task ]" },
                    {"automatictask_createtaskmenu", "[ automatischer Task ]" },
                    {"backuptask_createtaskmenu", "[ Backup-Task ]" },
                    {"return_createtaskmenu", "[ zurück ]" },

                    //AutoMenu-Optionen
                    {"headline_autotaskmenu", "Automatische Tasks" },
                    {"email_autotaskmenu", "[ E-Mail ]" },
                    {"calc_autotaskmenu", "[ Taschenrechner ]" },
                    {"browser_autotaskmenu", "[ Browser ]" },
                    {"screenlocker_autotaskmenu", "[ Bildschirm sperren ]" },
                    {"return_autotaskmenu", "[ zurück ]" },
                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "Einstellungen" },
                    { "taskpreset_options_settingsmenu", "[ Voreinstellungen für neue Tasks]" },
                    { "language_options_settingsmenu", "[ Sprachen ]" },
                    { "back_options_settingsmenu", "[ zurück ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "E-Mail Programm wurde gestartet" },
                    { "reciever_mail_basictasks", "empfänger@example.com" },
                    { "subject_mail_basictasks", "Betreff der E-Mail" },
                    { "text_mail_basictasks", "Hallo,\n\nDies ist eine vorgefertigte Nachricht." },
                    { "openmail_error_executed_mail_basictasks", "Fehler beim Öffnen des E-Mail Clients: " },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "Taschenrechner wurde gestartet" },
                    { "opencalc_error_executed_calculator_basictasks", "Fehler beim Öffnen des Taschenrechners: " },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "Browser wurde gestartet" },
                    { "lockinactive_basictasks", "Nutzer inaktiv: PC wird gesperrt" },
                    #endregion

                    #region BackupManager
                    //BackupManager.cs
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "Bitte wähle einen Quell- und Zielordner" },
                    { "manual_automationmethod_backupmanager", "Manuell" },
                    { "scheduled_automationmethod_backupmanager", "Geplant" },
                    { "scheduled_started_automationmethod_backupmanager", "Geplante Backups gestartet (Intervall: 60 Sekunden)." },
                    { "realtime_automationmethod_backupmanager", "Echtzeit" },
                    { "realtime_started_automationmethod_backupmanager", "Echtzeit-Backup aktiviert. Änderungen werden überwacht." },
                    { "backupfailed_backupmanager", "Backup fehlgeschlagen: " },
                    { "automation_stopped_backupmanager", "Automatisierung gestoppt." },
                    { "choose_source_folder_backupmanager", "Quellordner auswählen" },
                    { "choose_destination_folder_backupmanager", "Zielordner auswählen" },

                    //Backuptype
                    { "complete_backuptype_backupmanager", "Vollständig" },
                    { "incremental_backuptype_backupmanager", "Inkrementell" },
                    { "differential_backuptype_backupmanager", "Differenziell" },
                    { "synchronize_backuptype_backupmanager", "Syncronisieren" },
                    { "unknown_backuptype_backupmanager", "Unbekannter Backup-Typ" },

                    //BackupManager.designer.cs
                    { "source_folder_designer_backupmanager", "Quellordner" },
                    { "searching_designer_backupmanager", "Durchsuchen..." },
                    { "destination_folder_designer_backupmanager", "Zielordner:" },
                    { "backuptype_designer_backupmanager", "Backup-Typ:" },
                    { "automation_designer_backupmanager", "Automatisierung:" },
                    { "startbackup_designer_backupmanager", "Backup starten" },
                    { "stopautomation_designer_backupmanager", "Automatisierung stoppen" },
                    //Table
                    { "taskid_designer_backupmanager", "Task ID" },
                    { "source_designer_backupmanager", "Quelle" },
                    { "desti_designer_backupmanager", "Ziel" },
                    { "btype_designer_backupmanager", "Backup Typ" },
                    { "bauto_designer_backupmanager", "Atomatisierung" },

                    { "stopseltask_designer_backupmanager", "Task stoppen" },
                    { "stopalltask_designer_backupmanager", "Alle Tasks stoppen" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "Herunterfahren wird durch diese Anwendung verhindert." },
                    #endregion

                    #region TaskCreator
                    //TaskCreator.cs
                    { "veryimportant_prioritys_taskcreator", "sehr wichtig" },
                    { "important_prioritys_taskcreator", "wichtig" },
                    { "normalimportant_prioritys_taskcreator", "normal" },
                    { "lessimportant_prioritys_taskcreator", "unwichtig" },
                    { "leastimportant_prioritys_taskcreator", "sehr unwichtig" },
                    { "priority_taskcreator", "Priorität" },
                    { "unit_taskcreator", "Einheit" },

                    //TaskCreator.designer.cs
                    { "name_designer_taskcreator", "Name" },
                    { "choise_designer_taskcreator", "Auswählen" },
                    { "recurring_designer_taskcreator", "Wiederkehrend" },
                    { "filePath_designer_taskcreator", "Dateipfad" },
                    { "save_designer_taskcreator", "Speichern" },
                    { "cancel_designer_taskcreator", "Abbrechen" },
                    { "create_designer_taskcreator", "Task erstellen" },

                    //Zeiteinheiten
                    {"seconds_taskcreator", "Sekunden" },
                    {"minutes_taskcreator", "Minuten" },
                    {"hours_taskcreator", "Stunden" },
                    {"days_taskcreator", "Tage" },
                    {"weeks_taskcreator", "Wochen" },

                    //Bedingungen
                    {"condition_taskcreator", "Bedingung" },
                    {"cpuusage_taskcreator", "CPU-Auslastung" },
                    {"afterboot_taskcreator", "nach Boot-Vorgang" },
                    {"beforeshutdown_taskcreator", "vor Shutdown" },
                    #endregion

                    #region RestartApp
                    {"programmrestarting_restartapp", "Das Programm wird neu gestartet." },
                    {"restart_restartapp", "Neustart" },
                    #endregion

                    #region
                    {"headline_deletetask", "Task entfernen" },
                    #endregion
                }
            },
            {
                "en", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    { "welcome", "Welcome to the main menu:" },
                    { "language_option", "Change language" },
                    { "choose_language", "Choose a language:" },
                    { "back_option", "Back to main menu" },

                    { "headline_mainmenu", "Main Menu" },
                    { "newtask_options_mainmenu", "[ Create new task ]" },
                    { "showtask_options_mainmenu", "[ Show all tasks ]" },
                    { "loadpreset_options_mainmenu", "[ Load presets ]" },
                    { "settings_options_mainmenu", "[ Settings ]" },
                    { "end_options_mainmenu", "[ Exit ]" },

                    { "headline_printtasks_mainmenu", "\nPending tasks:\n------------------\n" },
                    { "name_printtasks_mainmenu", "[ Name ] = " },
                    { "priority_printtasks_mainmenu", "[ Priority ] = " },
                    { "date_printtasks_mainmenu", "[ Date ] = " },
                    { "interval_printtasks_mainmenu", "[ Interval ]" },
                    #endregion

                    #region CreateTaskMenu
                    { "headline_createtaskmenu", "Create Task" },
                    { "individualtask_createtaskmenu", "[ Individual Task ]" },
                    { "automatictask_createtaskmenu", "[ Automatic Task ]" },
                    { "backuptask_createtaskmenu", "[ Backup Task ]" },
                    { "return_createtaskmenu", "[ Back ]" },
                    #endregion

                    #region AutoMenu
                    { "headline_autotaskmenu", "Automatic Tasks" },
                    { "email_autotaskmenu", "[ Email ]" },
                    { "calc_autotaskmenu", "[ Calculator ]" },
                    { "browser_autotaskmenu", "[ Browser ]" },
                    { "screenlocker_autotaskmenu", "[ Lock Screen ]" },
                    { "return_autotaskmenu", "[ Back ]" },
                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "Settings" },
                    { "taskpreset_options_settingsmenu", "[ Presets for new tasks ]" },
                    { "language_options_settingsmenu", "[ Languages ]" },
                    { "back_options_settingsmenu", "[ Back ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "Email program has been started" },
                    { "reciever_mail_basictasks", "recipient@example.com" },
                    { "subject_mail_basictasks", "Email subject" },
                    { "text_mail_basictasks", "Hello,\n\nThis is a preset message." },
                    { "openmail_error_executed_mail_basictasks", "Error opening email client: " },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "Calculator has been started" },
                    { "opencalc_error_executed_calculator_basictasks", "Error opening calculator: " },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "Browser has been started" },
                    { "lockinactive_basictasks", "User inactive: PC will be locked" },
                    #endregion

                    #region BackupManager
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "Please select a source and destination folder" },
                    { "manual_automationmethod_backupmanager", "Manual" },
                    { "scheduled_automationmethod_backupmanager", "Scheduled" },
                    { "scheduled_started_automationmethod_backupmanager", "Scheduled backups started (Interval: 60 seconds)." },
                    { "realtime_automationmethod_backupmanager", "Real-time" },
                    { "realtime_started_automationmethod_backupmanager", "Real-time backup activated. Changes are being monitored." },
                    { "backupfailed_backupmanager", "Backup failed: " },
                    { "automation_stopped_backupmanager", "Automation stopped." },
                    { "choose_source_folder_backupmanager", "Select source folder" },
                    { "choose_destination_folder_backupmanager", "Select destination folder" },

                    { "complete_backuptype_backupmanager", "Complete" },
                    { "incremental_backuptype_backupmanager", "Incremental" },
                    { "differential_backuptype_backupmanager", "Differential" },
                    { "synchronize_backuptype_backupmanager", "Synchronize" },
                    { "unknown_backuptype_backupmanager", "Unknown backup type" },

                    { "source_folder_designer_backupmanager", "Source folder" },
                    { "searching_designer_backupmanager", "Browse..." },
                    { "destination_folder_designer_backupmanager", "Destination folder:" },
                    { "backuptype_designer_backupmanager", "Backup type:" },
                    { "automation_designer_backupmanager", "Automation:" },
                    { "startbackup_designer_backupmanager", "Start backup" },
                    { "stopautomation_designer_backupmanager", "Stop automation" },
                    { "taskid_designer_backupmanager", "Task ID" },
                    { "source_designer_backupmanager", "Source" },
                    { "desti_designer_backupmanager", "Destination" },
                    { "btype_designer_backupmanager", "Backup Type" },
                    { "bauto_designer_backupmanager", "Automation" },
                    { "stopseltask_designer_backupmanager", "Stop task" },
                    { "stopalltask_designer_backupmanager", "Stop all tasks" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "Shutdown is prevented by this application." },
                    #endregion

                    #region TaskCreator
                    { "veryimportant_prioritys_taskcreator", "very important" },
                    { "important_prioritys_taskcreator", "important" },
                    { "normalimportant_prioritys_taskcreator", "normal" },
                    { "lessimportant_prioritys_taskcreator", "less important" },
                    { "leastimportant_prioritys_taskcreator", "least important" },
                    { "priority_taskcreator", "Priority" },
                    { "unit_taskcreator", "Unit" },

                    { "name_designer_taskcreator", "Name" },
                    { "choise_designer_taskcreator", "Select" },
                    { "recurring_designer_taskcreator", "Recurring" },
                    { "filePath_designer_taskcreator", "File path" },
                    { "save_designer_taskcreator", "Save" },
                    { "cancel_designer_taskcreator", "Cancel" },
                    { "create_designer_taskcreator", "Create task" },

                    //Zeiteinheiten
                    {"seconds_taskcreator", "Seconds" },
                    {"minutes_taskcreator", "Minutes" },
                    {"hours_taskcreator", "Hours" },
                    {"days_taskcreator", "Days" },
                    {"weeks_taskcreator", "Weeks" },

                    //Bedingungen
                    {"condition_taskcreator", "Condition" },
                    {"cpuusage_taskcreator", "CPU usage" },
                    {"afterboot_taskcreator", "after boot" },
                    {"beforeshutdown_taskcreator", "before shutdown" },
                    #endregion

                    #region RestartApp
                    { "programmrestarting_restartapp", "The program is restarting." },
                    { "restart_restartapp", "Restart" },
                    #endregion

                    #region
                    {"headline_deletetask", "Remove task" },
                    #endregion
                }
            },
            {
                "fr", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    { "welcome", "Bienvenue dans le menu principal:" },
                    { "language_option", "Changer de langue" },
                    { "choose_language", "Choisissez une langue:" },
                    { "back_option", "Retour au menu principal" },

                    { "headline_mainmenu", "Menu principal" },
                    { "newtask_options_mainmenu", "[ Créer une nouvelle tâche ]" },
                    { "showtask_options_mainmenu", "[ Afficher toutes les tâches ]" },
                    { "loadpreset_options_mainmenu", "[ Charger les préréglages ]" },
                    { "settings_options_mainmenu", "[ Paramètres ]" },
                    { "end_options_mainmenu", "[ Quitter ]" },

                    { "headline_printtasks_mainmenu", "\nTâches en attente:\n------------------\n" },
                    { "name_printtasks_mainmenu", "[ Nom ] = " },
                    { "priority_printtasks_mainmenu", "[ Priorité ] = " },
                    { "date_printtasks_mainmenu", "[ Date ] = " },
                    { "interval_printtasks_mainmenu", "[ Intervalle ]" },
                    #endregion

                    #region CreateTaskMenu
                    { "headline_createtaskmenu", "Créer une tâche" },
                    { "individualtask_createtaskmenu", "[ Tâche individuelle ]" },
                    { "automatictask_createtaskmenu", "[ Tâche automatique ]" },
                    { "backuptask_createtaskmenu", "[ Tâche de sauvegarde ]" },
                    { "return_createtaskmenu", "[ Retour ]" },
                    #endregion

                    #region AutoMenu
                    { "headline_autotaskmenu", "Tâches automatiques" },
                    { "email_autotaskmenu", "[ E-mail ]" },
                    { "calc_autotaskmenu", "[ Calculatrice ]" },
                    { "browser_autotaskmenu", "[ Navigateur ]" },
                    { "screenlocker_autotaskmenu", "[ Verrouiller l'écran ]" },
                    { "return_autotaskmenu", "[ Retour ]" },
                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "Paramètres" },
                    { "taskpreset_options_settingsmenu", "[ Préréglages pour les nouvelles tâches ]" },
                    { "language_options_settingsmenu", "[ Langues ]" },
                    { "back_options_settingsmenu", "[ Retour ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "Le programme de messagerie a démarré" },
                    { "reciever_mail_basictasks", "destinataire@example.com" },
                    { "subject_mail_basictasks", "Objet de l'e-mail" },
                    { "text_mail_basictasks", "Bonjour,\n\nCeci est un message prédéfini." },
                    { "openmail_error_executed_mail_basictasks", "Erreur lors de l'ouverture du client de messagerie : " },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "La calculatrice a démarré" },
                    { "opencalc_error_executed_calculator_basictasks", "Erreur lors de l'ouverture de la calculatrice : " },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "Le navigateur a démarré" },
                    { "lockinactive_basictasks", "Utilisateur inactif : le PC sera verrouillé" },
                    #endregion

                    #region BackupManager
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "Veuillez sélectionner un dossier source et un dossier de destination" },
                    { "manual_automationmethod_backupmanager", "Manuel" },
                    { "scheduled_automationmethod_backupmanager", "Planifié" },
                    { "scheduled_started_automationmethod_backupmanager", "Sauvegardes programmées démarrées (Intervalle : 60 secondes)." },
                    { "realtime_automationmethod_backupmanager", "En temps réel" },
                    { "realtime_started_automationmethod_backupmanager", "Sauvegarde en temps réel activée. Les modifications sont surveillées." },
                    { "backupfailed_backupmanager", "Échec de la sauvegarde : " },
                    { "automation_stopped_backupmanager", "Automatisation arrêtée." },
                    { "choose_source_folder_backupmanager", "Sélectionner le dossier source" },
                    { "choose_destination_folder_backupmanager", "Sélectionner le dossier de destination" },

                    { "complete_backuptype_backupmanager", "Complet" },
                    { "incremental_backuptype_backupmanager", "Incrémentiel" },
                    { "differential_backuptype_backupmanager", "Différentiel" },
                    { "synchronize_backuptype_backupmanager", "Synchroniser" },
                    { "unknown_backuptype_backupmanager", "Type de sauvegarde inconnu" },

                    { "source_folder_designer_backupmanager", "Dossier source" },
                    { "searching_designer_backupmanager", "Parcourir..." },
                    { "destination_folder_designer_backupmanager", "Dossier de destination:" },
                    { "backuptype_designer_backupmanager", "Type de sauvegarde:" },
                    { "automation_designer_backupmanager", "Automatisation:" },
                    { "startbackup_designer_backupmanager", "Démarrer la sauvegarde" },
                    { "stopautomation_designer_backupmanager", "Arrêter l'automatisation" },
                    { "taskid_designer_backupmanager", "ID de tâche" },
                    { "source_designer_backupmanager", "Source" },
                    { "desti_designer_backupmanager", "Destination" },
                    { "btype_designer_backupmanager", "Type de sauvegarde" },
                    { "bauto_designer_backupmanager", "Automatisation" },
                    { "stopseltask_designer_backupmanager", "Arrêter la tâche" },
                    { "stopalltask_designer_backupmanager", "Arrêter toutes les tâches" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "L'arrêt est empêché par cette application." },
                    #endregion

                    #region TaskCreator
                    { "veryimportant_prioritys_taskcreator", "très important" },
                    { "important_prioritys_taskcreator", "important" },
                    { "normalimportant_prioritys_taskcreator", "normal" },
                    { "lessimportant_prioritys_taskcreator", "moins important" },
                    { "leastimportant_prioritys_taskcreator", "le moins important" },
                    { "priority_taskcreator", "Priorité" },
                    { "unit_taskcreator", "Unité" },

                    { "name_designer_taskcreator", "Nom" },
                    { "choise_designer_taskcreator", "Choisir" },
                    { "recurring_designer_taskcreator", "Récurrent" },
                    { "filePath_designer_taskcreator", "Chemin du fichier" },
                    { "save_designer_taskcreator", "Enregistrer" },
                    { "cancel_designer_taskcreator", "Annuler" },
                    { "create_designer_taskcreator", "Créer une tâche" },

                    //Zeiteinheiten
                    {"seconds_taskcreator", "Secondes" },
                    {"minutes_taskcreator", "Minutes" },
                    {"hours_taskcreator", "Heures" },
                    {"days_taskcreator", "Jours" },
                    {"weeks_taskcreator", "Semaines" },

                    //Bedingungen
                    {"condition_taskcreator", "Condition" },
                    {"cpuusage_taskcreator", "Utilisation CPU" },
                    {"afterboot_taskcreator", "après le démarrage" },
                    {"beforeshutdown_taskcreator", "avant l'arrêt" },
                    #endregion

                    #region RestartApp
                    { "programmrestarting_restartapp", "Le programme redémarre." },
                    { "restart_restartapp", "Redémarrer" },
                    #endregion

                    #region
                    {"headline_deletetask", "Supprimer une tâche" },
                    #endregion
                }
            },
            {
                "it", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    { "welcome", "Benvenuto nel menu principale:" },
                    { "language_option", "Cambia lingua" },
                    { "choose_language", "Scegli una lingua:" },
                    { "back_option", "Torna al menu principale" },

                    { "headline_mainmenu", "Menu principale" },
                    { "newtask_options_mainmenu", "[ Crea nuovo task ]" },
                    { "showtask_options_mainmenu", "[ Mostra tutti i task ]" },
                    { "loadpreset_options_mainmenu", "[ Carica preimpostazioni ]" },
                    { "settings_options_mainmenu", "[ Impostazioni ]" },
                    { "end_options_mainmenu", "[ Esci ]" },

                    { "headline_printtasks_mainmenu", "\nTask in sospeso:\n------------------\n" },
                    { "name_printtasks_mainmenu", "[ Nome ] = " },
                    { "priority_printtasks_mainmenu", "[ Priorità ] = " },
                    { "date_printtasks_mainmenu", "[ Data ] = " },
                    { "interval_printtasks_mainmenu", "[ Intervallo ]" },
                    #endregion

                    #region CreateTaskMenu
                    { "headline_createtaskmenu", "Crea Task" },
                    { "individualtask_createtaskmenu", "[ Task individuale ]" },
                    { "automatictask_createtaskmenu", "[ Task automatico ]" },
                    { "backuptask_createtaskmenu", "[ Task di backup ]" },
                    { "return_createtaskmenu", "[ Indietro ]" },
                    #endregion

                    #region AutoMenu
                    { "headline_autotaskmenu", "Task automatici" },
                    { "email_autotaskmenu", "[ Email ]" },
                    { "calc_autotaskmenu", "[ Calcolatrice ]" },
                    { "browser_autotaskmenu", "[ Browser ]" },
                    { "screenlocker_autotaskmenu", "[ Blocca schermo ]" },
                    { "return_autotaskmenu", "[ Indietro ]" },
                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "Impostazioni" },
                    { "taskpreset_options_settingsmenu", "[ Preimpostazioni per nuovi task ]" },
                    { "language_options_settingsmenu", "[ Lingue ]" },
                    { "back_options_settingsmenu", "[ Indietro ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "Il programma di posta elettronica è stato avviato" },
                    { "reciever_mail_basictasks", "destinatario@example.com" },
                    { "subject_mail_basictasks", "Oggetto dell'email" },
                    { "text_mail_basictasks", "Ciao,\n\nQuesto è un messaggio predefinito." },
                    { "openmail_error_executed_mail_basictasks", "Errore durante l'apertura del client email: " },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "La calcolatrice è stata avviata" },
                    { "opencalc_error_executed_calculator_basictasks", "Errore durante l'apertura della calcolatrice: " },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "Il browser è stato avviato" },
                    { "lockinactive_basictasks", "Utente inattivo: il PC verrà bloccato" },
                    #endregion

                    #region BackupManager
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "Seleziona una cartella di origine e una di destinazione" },
                    { "manual_automationmethod_backupmanager", "Manuale" },
                    { "scheduled_automationmethod_backupmanager", "Programmato" },
                    { "scheduled_started_automationmethod_backupmanager", "Backup programmati avviati (Intervallo: 60 secondi)." },
                    { "realtime_automationmethod_backupmanager", "In tempo reale" },
                    { "realtime_started_automationmethod_backupmanager", "Backup in tempo reale attivato. Le modifiche vengono monitorate." },
                    { "backupfailed_backupmanager", "Backup fallito: " },
                    { "automation_stopped_backupmanager", "Automazione interrotta." },
                    { "choose_source_folder_backupmanager", "Seleziona la cartella di origine" },
                    { "choose_destination_folder_backupmanager", "Seleziona la cartella di destinazione" },

                    { "complete_backuptype_backupmanager", "Completo" },
                    { "incremental_backuptype_backupmanager", "Incrementale" },
                    { "differential_backuptype_backupmanager", "Differenziale" },
                    { "synchronize_backuptype_backupmanager", "Sincronizzare" },
                    { "unknown_backuptype_backupmanager", "Tipo di backup sconosciuto" },

                    { "source_folder_designer_backupmanager", "Cartella di origine" },
                    { "searching_designer_backupmanager", "Sfoglia..." },
                    { "destination_folder_designer_backupmanager", "Cartella di destinazione:" },
                    { "backuptype_designer_backupmanager", "Tipo di backup:" },
                    { "automation_designer_backupmanager", "Automazione:" },
                    { "startbackup_designer_backupmanager", "Avvia backup" },
                    { "stopautomation_designer_backupmanager", "Interrompi automazione" },
                    { "taskid_designer_backupmanager", "ID Task" },
                    { "source_designer_backupmanager", "Origine" },
                    { "desti_designer_backupmanager", "Destinazione" },
                    { "btype_designer_backupmanager", "Tipo di backup" },
                    { "bauto_designer_backupmanager", "Automazione" },
                    { "stopseltask_designer_backupmanager", "Ferma task" },
                    { "stopalltask_designer_backupmanager", "Ferma tutti i task" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "Lo spegnimento è impedito da questa applicazione." },
                    #endregion

                    #region TaskCreator
                    { "veryimportant_prioritys_taskcreator", "molto importante" },
                    { "important_prioritys_taskcreator", "importante" },
                    { "normalimportant_prioritys_taskcreator", "normale" },
                    { "lessimportant_prioritys_taskcreator", "meno importante" },
                    { "leastimportant_prioritys_taskcreator", "meno importante" },
                    { "priority_taskcreator", "Priorità" },
                    { "unit_taskcreator", "Unità" },

                    { "name_designer_taskcreator", "Nome" },
                    { "choise_designer_taskcreator", "Seleziona" },
                    { "recurring_designer_taskcreator", "Ricorrente" },
                    { "filePath_designer_taskcreator", "Percorso file" },
                    { "save_designer_taskcreator", "Salva" },
                    { "cancel_designer_taskcreator", "Annulla" },
                    { "create_designer_taskcreator", "Crea task" },

                    //Zeiteinheiten
                    {"seconds_taskcreator", "Secondi" },
                    {"minutes_taskcreator", "Minuti" },
                    {"hours_taskcreator", "Ore" },
                    {"days_taskcreator", "Giorni" },
                    {"weeks_taskcreator", "Settimane" },

                    //Bedingungen
                    {"condition_taskcreator", "Condizione" },
                    {"cpuusage_taskcreator", "Utilizzo CPU" },
                    {"afterboot_taskcreator", "dopo l'avvio" },
                    {"beforeshutdown_taskcreator", "prima dello spegnimento" },
                    #endregion

                    #region RestartApp
                    { "programmrestarting_restartapp", "Il programma si sta riavviando." },
                    { "restart_restartapp", "Riavvia" },
                    #endregion

                    #region
                    {"headline_deletetask", "Rimuovere attività" },
                    #endregion
                }
            },
            {
                "es", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    { "welcome", "Bienvenido al menú principal:" },
                    { "language_option", "Cambiar idioma" },
                    { "choose_language", "Elige un idioma:" },
                    { "back_option", "Volver al menú principal" },

                    { "headline_mainmenu", "Menú principal" },
                    { "newtask_options_mainmenu", "[ Crear nueva tarea ]" },
                    { "showtask_options_mainmenu", "[ Mostrar todas las tareas ]" },
                    { "loadpreset_options_mainmenu", "[ Cargar preajustes ]" },
                    { "settings_options_mainmenu", "[ Configuración ]" },
                    { "end_options_mainmenu", "[ Salir ]" },

                    { "headline_printtasks_mainmenu", "\nTareas pendientes:\n------------------\n" },
                    { "name_printtasks_mainmenu", "[ Nombre ] = " },
                    { "priority_printtasks_mainmenu", "[ Prioridad ] = " },
                    { "date_printtasks_mainmenu", "[ Fecha ] = " },
                    { "interval_printtasks_mainmenu", "[ Intervalo ]" },
                    #endregion

                    #region CreateTaskMenu
                    { "headline_createtaskmenu", "Crear Tarea" },
                    { "individualtask_createtaskmenu", "[ Tarea individual ]" },
                    { "automatictask_createtaskmenu", "[ Tarea automática ]" },
                    { "backuptask_createtaskmenu", "[ Tarea de respaldo ]" },
                    { "return_createtaskmenu", "[ Atrás ]" },
                    #endregion

                    #region AutoMenu
                    { "headline_autotaskmenu", "Tareas automáticas" },
                    { "email_autotaskmenu", "[ Correo electrónico ]" },
                    { "calc_autotaskmenu", "[ Calculadora ]" },
                    { "browser_autotaskmenu", "[ Navegador ]" },
                    { "screenlocker_autotaskmenu", "[ Bloquear pantalla ]" },
                    { "return_autotaskmenu", "[ Atrás ]" },
                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "Configuración" },
                    { "taskpreset_options_settingsmenu", "[ Preajustes para nuevas tareas ]" },
                    { "language_options_settingsmenu", "[ Idiomas ]" },
                    { "back_options_settingsmenu", "[ Atrás ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "El programa de correo electrónico se ha iniciado" },
                    { "reciever_mail_basictasks", "destinatario@example.com" },
                    { "subject_mail_basictasks", "Asunto del correo" },
                    { "text_mail_basictasks", "Hola,\n\nEste es un mensaje preestablecido." },
                    { "openmail_error_executed_mail_basictasks", "Error al abrir el cliente de correo: " },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "La calculadora se ha iniciado" },
                    { "opencalc_error_executed_calculator_basictasks", "Error al abrir la calculadora: " },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "El navegador se ha iniciado" },
                    { "lockinactive_basictasks", "Usuario inactivo: la PC se bloqueará" },
                    #endregion

                    #region BackupManager
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "Por favor, selecciona una carpeta de origen y destino" },
                    { "manual_automationmethod_backupmanager", "Manual" },
                    { "scheduled_automationmethod_backupmanager", "Programado" },
                    { "scheduled_started_automationmethod_backupmanager", "Respaldo programado iniciado (Intervalo: 60 segundos)." },
                    { "realtime_automationmethod_backupmanager", "Tiempo real" },
                    { "realtime_started_automationmethod_backupmanager", "Respaldo en tiempo real activado. Se están monitoreando los cambios." },
                    { "backupfailed_backupmanager", "Respaldo fallido: " },
                    { "automation_stopped_backupmanager", "Automatización detenida." },
                    { "choose_source_folder_backupmanager", "Seleccionar carpeta de origen" },
                    { "choose_destination_folder_backupmanager", "Seleccionar carpeta de destino" },

                    { "complete_backuptype_backupmanager", "Completo" },
                    { "incremental_backuptype_backupmanager", "Incremental" },
                    { "differential_backuptype_backupmanager", "Diferencial" },
                    { "synchronize_backuptype_backupmanager", "Sincronizar" },
                    { "unknown_backuptype_backupmanager", "Tipo de respaldo desconocido" },

                    { "source_folder_designer_backupmanager", "Carpeta de origen" },
                    { "searching_designer_backupmanager", "Buscar..." },
                    { "destination_folder_designer_backupmanager", "Carpeta de destino:" },
                    { "backuptype_designer_backupmanager", "Tipo de respaldo:" },
                    { "automation_designer_backupmanager", "Automatización:" },
                    { "startbackup_designer_backupmanager", "Iniciar respaldo" },
                    { "stopautomation_designer_backupmanager", "Detener automatización" },
                    { "taskid_designer_backupmanager", "ID de tarea" },
                    { "source_designer_backupmanager", "Origen" },
                    { "desti_designer_backupmanager", "Destino" },
                    { "btype_designer_backupmanager", "Tipo de respaldo" },
                    { "bauto_designer_backupmanager", "Automatización" },
                    { "stopseltask_designer_backupmanager", "Detener tarea" },
                    { "stopalltask_designer_backupmanager", "Detener todas las tareas" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "El apagado está bloqueado por esta aplicación." },
                    #endregion

                    #region TaskCreator
                    { "veryimportant_prioritys_taskcreator", "muy importante" },
                    { "important_prioritys_taskcreator", "importante" },
                    { "normalimportant_prioritys_taskcreator", "normal" },
                    { "lessimportant_prioritys_taskcreator", "menos importante" },
                    { "leastimportant_prioritys_taskcreator", "el menos importante" },
                    { "priority_taskcreator", "Prioridad" },
                    { "unit_taskcreator", "Unidad" },

                    { "name_designer_taskcreator", "Nombre" },
                    { "choise_designer_taskcreator", "Seleccionar" },
                    { "recurring_designer_taskcreator", "Recurrente" },
                    { "filePath_designer_taskcreator", "Ruta del archivo" },
                    { "save_designer_taskcreator", "Guardar" },
                    { "cancel_designer_taskcreator", "Cancelar" },
                    { "create_designer_taskcreator", "Crear tarea" },

                    //Zeiteinheiten
                    {"seconds_taskcreator", "Segundos" },
                    {"minutes_taskcreator", "Minutos" },
                    {"hours_taskcreator", "Horas" },
                    {"days_taskcreator", "Días" },
                    {"weeks_taskcreator", "Semanas" },

                    //Bedingungen
                    {"condition_taskcreator", "Condición" },
                    {"cpuusage_taskcreator", "Uso de CPU" },
                    {"afterboot_taskcreator", "después del arranque" },
                    {"beforeshutdown_taskcreator", "antes del apagado" },
                    #endregion

                    #region RestartApp
                    { "programmrestarting_restartapp", "El programa se está reiniciando." },
                    { "restart_restartapp", "Reiniciar" },
                    #endregion

                    #region
                    {"headline_deletetask", "Eliminar tarea" },
                    #endregion
                }
            },
            {
                "zh", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    { "welcome", "欢迎来到主菜单：" },
                    { "language_option", "更改语言" },
                    { "choose_language", "选择一种语言：" },
                    { "back_option", "返回主菜单" },

                    { "headline_mainmenu", "主菜单" },
                    { "newtask_options_mainmenu", "[ 创建新任务 ]" },
                    { "showtask_options_mainmenu", "[ 显示所有任务 ]" },
                    { "loadpreset_options_mainmenu", "[ 加载预设 ]" },
                    { "settings_options_mainmenu", "[ 设置 ]" },
                    { "end_options_mainmenu", "[ 退出 ]" },

                    { "headline_printtasks_mainmenu", "\n待处理任务:\n------------------\n" },
                    { "name_printtasks_mainmenu", "[ 名称 ] = " },
                    { "priority_printtasks_mainmenu", "[ 优先级 ] = " },
                    { "date_printtasks_mainmenu", "[ 日期 ] = " },
                    { "interval_printtasks_mainmenu", "[ 间隔 ]" },
                    #endregion

                    #region CreateTaskMenu
                    { "headline_createtaskmenu", "创建任务" },
                    { "individualtask_createtaskmenu", "[ 个人任务 ]" },
                    { "automatictask_createtaskmenu", "[ 自动任务 ]" },
                    { "backuptask_createtaskmenu", "[ 备份任务 ]" },
                    { "return_createtaskmenu", "[ 返回 ]" },
                    #endregion

                    #region AutoMenu
                    { "headline_autotaskmenu", "自动任务" },
                    { "email_autotaskmenu", "[ 邮件 ]" },
                    { "calc_autotaskmenu", "[ 计算器 ]" },
                    { "browser_autotaskmenu", "[ 浏览器 ]" },
                    { "screenlocker_autotaskmenu", "[ 锁定屏幕 ]" },
                    { "return_autotaskmenu", "[ 返回 ]" },
                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "设置" },
                    { "taskpreset_options_settingsmenu", "[ 新任务预设 ]" },
                    { "language_options_settingsmenu", "[ 语言 ]" },
                    { "back_options_settingsmenu", "[ 返回 ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "电子邮件程序已启动" },
                    { "reciever_mail_basictasks", "recipient@example.com" },
                    { "subject_mail_basictasks", "邮件主题" },
                    { "text_mail_basictasks", "你好，\n\n这是一条预设消息。" },
                    { "openmail_error_executed_mail_basictasks", "打开电子邮件客户端时出错：" },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "计算器已启动" },
                    { "opencalc_error_executed_calculator_basictasks", "打开计算器时出错：" },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "浏览器已启动" },
                    { "lockinactive_basictasks", "用户不活跃：电脑将被锁定" },
                    #endregion

                    #region BackupManager
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "请选择一个源文件夹和目标文件夹" },
                    { "manual_automationmethod_backupmanager", "手动" },
                    { "scheduled_automationmethod_backupmanager", "定时" },
                    { "scheduled_started_automationmethod_backupmanager", "已启动定时备份（间隔：60秒）。" },
                    { "realtime_automationmethod_backupmanager", "实时" },
                    { "realtime_started_automationmethod_backupmanager", "实时备份已激活。正在监控更改。" },
                    { "backupfailed_backupmanager", "备份失败：" },
                    { "automation_stopped_backupmanager", "自动化已停止。" },
                    { "choose_source_folder_backupmanager", "选择源文件夹" },
                    { "choose_destination_folder_backupmanager", "选择目标文件夹" },

                    { "complete_backuptype_backupmanager", "完整" },
                    { "incremental_backuptype_backupmanager", "增量" },
                    { "differential_backuptype_backupmanager", "差异" },
                    { "synchronize_backuptype_backupmanager", "同步" },
                    { "unknown_backuptype_backupmanager", "未知的备份类型" },

                    { "source_folder_designer_backupmanager", "源文件夹" },
                    { "searching_designer_backupmanager", "浏览..." },
                    { "destination_folder_designer_backupmanager", "目标文件夹：" },
                    { "backuptype_designer_backupmanager", "备份类型：" },
                    { "automation_designer_backupmanager", "自动化：" },
                    { "startbackup_designer_backupmanager", "开始备份" },
                    { "stopautomation_designer_backupmanager", "停止自动化" },
                    { "taskid_designer_backupmanager", "任务ID" },
                    { "source_designer_backupmanager", "来源" },
                    { "desti_designer_backupmanager", "目标" },
                    { "btype_designer_backupmanager", "备份类型" },
                    { "bauto_designer_backupmanager", "自动化" },
                    { "stopseltask_designer_backupmanager", "停止任务" },
                    { "stopalltask_designer_backupmanager", "停止所有任务" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "该应用程序阻止了关机。" },
                    #endregion

                    #region TaskCreator
                    { "veryimportant_prioritys_taskcreator", "非常重要" },
                    { "important_prioritys_taskcreator", "重要" },
                    { "normalimportant_prioritys_taskcreator", "正常" },
                    { "lessimportant_prioritys_taskcreator", "不太重要" },
                    { "leastimportant_prioritys_taskcreator", "最不重要" },
                    { "priority_taskcreator", "优先级" },
                    { "unit_taskcreator", "单位" },

                    { "name_designer_taskcreator", "名称" },
                    { "choise_designer_taskcreator", "选择" },
                    { "recurring_designer_taskcreator", "重复" },
                    { "filePath_designer_taskcreator", "文件路径" },
                    { "save_designer_taskcreator", "保存" },
                    { "cancel_designer_taskcreator", "取消" },
                    { "create_designer_taskcreator", "创建任务" },

                    //Zeiteinheiten
                    {"seconds_taskcreator", "秒" },
                    {"minutes_taskcreator", "分钟" },
                    {"hours_taskcreator", "小时" },
                    {"days_taskcreator", "天" },
                    {"weeks_taskcreator", "周" },

                    //Bedingungen
                    {"condition_taskcreator", "条件" },
                    {"cpuusage_taskcreator", "CPU-使用率" },
                    {"afterboot_taskcreator", "启动后" },
                    {"beforeshutdown_taskcreator", "关机前" },
                    #endregion

                    #region RestartApp
                    { "programmrestarting_restartapp", "程序正在重启。" },
                    { "restart_restartapp", "重启" },
                    #endregion
                }
            },
            {
                "hi", new Dictionary<string, string>
                {
                    #region ConsolenTranslation
                    { "welcome", "मुख्य मेनू में आपका स्वागत है:" },
                    { "language_option", "भाषा बदलें" },
                    { "choose_language", "एक भाषा चुनें:" },
                    { "back_option", "मुख्य मेनू पर वापस जाएँ" },

                    { "headline_mainmenu", "मुख्य मेनू" },
                    { "newtask_options_mainmenu", "[ नया कार्य बनाएं ]" },
                    { "showtask_options_mainmenu", "[ सभी कार्य दिखाएँ ]" },
                    { "loadpreset_options_mainmenu", "[ पूर्वनिर्धारण लोड करें ]" },
                    { "settings_options_mainmenu", "[ सेटिंग्स ]" },
                    { "end_options_mainmenu", "[ समाप्त करें ]" },

                    { "headline_printtasks_mainmenu", "\nलंबित कार्य:\n------------------\n" },
                    { "name_printtasks_mainmenu", "[ नाम ] = " },
                    { "priority_printtasks_mainmenu", "[ प्राथमिकता ] = " },
                    { "date_printtasks_mainmenu", "[ तिथि ] = " },
                    { "interval_printtasks_mainmenu", "[ अंतराल ]" },
                    #endregion

                    #region CreateTaskMenu
                    { "headline_createtaskmenu", "कार्य बनाएँ" },
                    { "individualtask_createtaskmenu", "[ व्यक्तिगत कार्य ]" },
                    { "automatictask_createtaskmenu", "[ स्वचालित कार्य ]" },
                    { "backuptask_createtaskmenu", "[ बैकअप कार्य ]" },
                    { "return_createtaskmenu", "[ वापस ]" },
                    #endregion

                    #region AutoMenu
                    { "headline_autotaskmenu", "स्वचालित कार्य" },
                    { "email_autotaskmenu", "[ ईमेल ]" },
                    { "calc_autotaskmenu", "[ कैलकुलेटर ]" },
                    { "browser_autotaskmenu", "[ ब्राउज़र ]" },
                    { "screenlocker_autotaskmenu", "[ स्क्रीन लॉक करें ]" },
                    { "return_autotaskmenu", "[ वापस ]" },
                    #endregion

                    #region Settingsmenu
                    { "headline_settingsmenu", "सेटिंग्स" },
                    { "taskpreset_options_settingsmenu", "[ नए कार्यों के लिए पूर्वनिर्धारण ]" },
                    { "language_options_settingsmenu", "[ भाषाएँ ]" },
                    { "back_options_settingsmenu", "[ वापस ]" },
                    #endregion

                    #region Basic Tasks (E-Mail)
                    { "openmail_executed_mail_basictasks", "ईमेल प्रोग्राम शुरू हो गया है" },
                    { "reciever_mail_basictasks", "प्राप्तकर्ता@example.com" },
                    { "subject_mail_basictasks", "ईमेल विषय" },
                    { "text_mail_basictasks", "नमस्ते,\n\nयह एक पूर्वनिर्धारित संदेश है।" },
                    { "openmail_error_executed_mail_basictasks", "ईमेल क्लाइंट खोलने में त्रुटि: " },
                    #endregion

                    #region Basic Tasks (Calculator)
                    { "opencalc_executed_calculator_basictasks", "कैलकुलेटर शुरू हो गया है" },
                    { "opencalc_error_executed_calculator_basictasks", "कैलकुलेटर खोलने में त्रुटि: " },
                    #endregion

                    #region Basic Tasks (Browser & LockInactive)
                    { "openbrowser_executed_browser_basictasks", "ब्राउज़र शुरू हो गया है" },
                    { "lockinactive_basictasks", "उपयोगकर्ता निष्क्रिय: पीसी लॉक हो जाएगा" },
                    #endregion

                    #region BackupManager
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "कृपया एक स्रोत और गंतव्य फ़ोल्डर चुनें" },
                    { "manual_automationmethod_backupmanager", "मैनुअल" },
                    { "scheduled_automationmethod_backupmanager", "अनुसूचित" },
                    { "scheduled_started_automationmethod_backupmanager", "अनुसूचित बैकअप शुरू हो गए (अंतराल: 60 सेकंड)।" },
                    { "realtime_automationmethod_backupmanager", "रियल-टाइम" },
                    { "realtime_started_automationmethod_backupmanager", "रियल-टाइम बैकअप सक्रिय है। परिवर्तनों की निगरानी की जा रही है।" },
                    { "backupfailed_backupmanager", "बैकअप असफल: " },
                    { "automation_stopped_backupmanager", "स्वचालन बंद कर दिया गया है।" },
                    { "choose_source_folder_backupmanager", "स्रोत फ़ोल्डर चुनें" },
                    { "choose_destination_folder_backupmanager", "गंतव्य फ़ोल्डर चुनें" },

                    { "complete_backuptype_backupmanager", "पूर्ण" },
                    { "incremental_backuptype_backupmanager", "इंक्रीमेंटल" },
                    { "differential_backuptype_backupmanager", "विभेदक" },
                    { "synchronize_backuptype_backupmanager", "सिंक करें" },
                    { "unknown_backuptype_backupmanager", "अज्ञात बैकअप प्रकार" },

                    { "source_folder_designer_backupmanager", "स्रोत फ़ोल्डर" },
                    { "searching_designer_backupmanager", "ब्राउज़ करें..." },
                    { "destination_folder_designer_backupmanager", "गंतव्य फ़ोल्डर:" },
                    { "backuptype_designer_backupmanager", "बैकअप प्रकार:" },
                    { "automation_designer_backupmanager", "स्वचालन:" },
                    { "startbackup_designer_backupmanager", "बैकअप शुरू करें" },
                    { "stopautomation_designer_backupmanager", "स्वचालन बंद करें" },
                    { "taskid_designer_backupmanager", "कार्य ID" },
                    { "source_designer_backupmanager", "स्रोत" },
                    { "desti_designer_backupmanager", "गंतव्य" },
                    { "btype_designer_backupmanager", "बैकअप प्रकार" },
                    { "bauto_designer_backupmanager", "स्वचालन" },
                    { "stopseltask_designer_backupmanager", "कार्य बंद करें" },
                    { "stopalltask_designer_backupmanager", "सभी कार्य बंद करें" },
                    #endregion

                    #region PreventShutdown
                    { "shutdown_prevented_preventshutdown", "इस एप्लिकेशन द्वारा शटडाउन रोका गया है।" },
                    #endregion

                    #region TaskCreator
                    { "veryimportant_prioritys_taskcreator", "बहुत महत्वपूर्ण" },
                    { "important_prioritys_taskcreator", "महत्वपूर्ण" },
                    { "normalimportant_prioritys_taskcreator", "साधारण" },
                    { "lessimportant_prioritys_taskcreator", "कम महत्वपूर्ण" },
                    { "leastimportant_prioritys_taskcreator", "सबसे कम महत्वपूर्ण" },
                    { "priority_taskcreator", "प्राथमिकता" },
                    { "unit_taskcreator", "इकाई" },

                    { "name_designer_taskcreator", "नाम" },
                    { "choise_designer_taskcreator", "चुनें" },
                    { "recurring_designer_taskcreator", "बार-बार होने वाला" },
                    { "filePath_designer_taskcreator", "फ़ाइल पथ" },
                    { "save_designer_taskcreator", "सहेजें" },
                    { "cancel_designer_taskcreator", "रद्द करें" },
                    { "create_designer_taskcreator", "कार्य बनाएँ" },

                    //Zeiteinheiten
                    {"seconds_taskcreator", "सेकंड" },
                    {"minutes_taskcreator", "मिनट" },
                    {"hours_taskcreator", "घंटे" },
                    {"days_taskcreator", "दिन" },
                    {"weeks_taskcreator", "सप्ताह" },

                    //Bedingungen
                    {"condition_taskcreator", "शर्त" },
                    {"cpuusage_taskcreator", "CPU-उपयोग" },
                    {"afterboot_taskcreator", "बूट के बाद" },
                    {"beforeshutdown_taskcreator", "शटडाउन से पहले" },
                    #endregion

                    #region RestartApp
                    { "programmrestarting_restartapp", "प्रोग्राम पुनरारंभ हो रहा है।" },
                    { "restart_restartapp", "पुनरारंभ" },
                    #endregion
                }
            },
            {
                "bd", new Dictionary<string, string>
                {
                    // Vorhandene Einträge (bleiben unverändert)
                    { "welcome", "Ozapft im Brauerei-Menü:" },
                    { "language_option", "Herkunft ändern" },
                    { "headline_mainmenu", "Zurück zur Brauerei" },
                    { "newtask_options_mainmenu", "[ Neue Gärung starten ]" },
                    { "showtask_options_mainmenu", "[ Alle Gärungen anzeigen ]" },
                    { "loadpreset_options_mainmenu", "[ Standard-Reinheitsgebot anwenden ]" },
                    { "settings_options_mainmenu", "[ Reinheitsgebot ]" },
                    { "end_options_mainmenu", "[ Krug auskippen]" },
                    { "back_option", "Zurück zur Brauerei" },
                    { "choose_option", "Entscheide dich für eine Sorte: " },
                    { "headline_settingsmenu", "Reinheitsgebot" },
                    { "taskpreset_options_settingsmenu", "[ Standard-Reinheitsgebot für neue Gärungen]" },
                    { "language_options_settingsmenu", "[ Herkunftsländer]" },
                    { "back_options_settingsmenu", "[ Krug zurückgeben ]" },
                    { "openmail_executed_mail_basictasks", "Bierpost wurde gestartet" },
                    { "reciever_mail_basictasks", "empfänger@example.com" },
                    { "subject_mail_basictasks", "Alkoholgehalt der Bierpost" },
                    { "text_mail_basictasks", "Servus!,\n\nDas ist eine vorgelederte Bierpost." },
                    { "openmail_error_executed_mail_basictasks", "Alkoholmangel beim Probieren des Bierpost-Klient: " },
                    { "opencalc_executed_calculator_basictasks", "Alkoholrechner wurde gestartet" },
                    { "opencalc_error_executed_calculator_basictasks", "Alkoholmangel beim Anbixn des Alkoholrechners: " },
                    { "openbrowser_executed_browser_basictasks", "Weinlager wurde ozapft" },
                    { "lockinactive_basictasks", "Säufer bewusstlos: Fass wird weggerollt" },
                    { "specify_source_destination_folder_button_backup_start_click_backupmanager", "Wähle eine Quelle und einen durstigen Mund" },
                    { "manual_automationmethod_backupmanager", "Hand anlegen" },
                    { "scheduled_automationmethod_backupmanager", "Vorglühen" },
                    { "scheduled_started_automationmethod_backupmanager", "Vorgeglühte Lederungen gestartet (Intervall: 60 Deutsche Sekunden)." },
                    { "realtime_automationmethod_backupmanager", "Grad eben" },
                    { "realtime_started_automationmethod_backupmanager", "GradEben-Lederung abgefüllt. Änderungen werden geniedert." },
                    { "backupfailed_backupmanager", "Lederung fehlgegärt: " },
                    { "automation_stopped_backupmanager", "Deckelung entzapft." },
                    { "choose_source_folder_backupmanager", "Quelle auswählen" },
                    { "choose_destination_folder_backupmanager", "Durstigen Mund auswählen" },
                    { "complete_backuptype_backupmanager", "Komplett gegärt" },
                    { "incremental_backuptype_backupmanager", "Wachtmeisterig" },
                    { "differential_backuptype_backupmanager", "Wachtmoaschterig" },
                    { "synchronize_backuptype_backupmanager", "Kopfnussen" },
                    { "unknown_backuptype_backupmanager", "Nicht lederiger Lederung-Typ" },
                    { "source_folder_designer_backupmanager", "Quelle" },
                    { "searching_designer_backupmanager", "Durchwachtmeistern..." },
                    { "destination_folder_designer_backupmanager", "Durstiger Mund:" },
                    { "backuptype_designer_backupmanager", "Lederung-Typ:" },
                    { "automation_designer_backupmanager", "Industrialisierung:" },
                    { "startbackup_designer_backupmanager", "Lederung starten" },
                    { "stopautomation_designer_backupmanager", "Industrialisierung stoppen" },
                    { "shutdown_prevented_preventshutdown", "Entzapfen wird durch diese Flasche verboten." },
                    { "veryimportant_prioritys_taskcreator", "Fundamental" },
                    { "important_prioritys_taskcreator", "Basiert" },
                    { "normalimportant_prioritys_taskcreator", "Bodenständig" },
                    { "lessimportant_prioritys_taskcreator", "Sushko" },
                    { "leastimportant_prioritys_taskcreator", "Gehirnschimmel" },
                    { "priority_taskcreator", "Twix" },
                    { "unit_taskcreator", "Twix" },
                    { "name_designer_taskcreator", "Kennung" },
                    { "choise_designer_taskcreator", "Anledern" },
                    { "recurring_designer_taskcreator", "Sowieja" },
                    { "filePath_designer_taskcreator", "Stirnpfad" },
                    { "save_designer_taskcreator", "Nasenbeinen" },
                    { "cancel_designer_taskcreator", "Auskippen" },
                    { "seconds_unitfactors_designer_taskcreator", "Deutsche Sekunden" },
                    { "minutes_unitfactors_designer_taskcreator", "Deutsche Minuten" },
                    { "hours_unitfactors_designer_taskcreator", "Deutsche Stunden" },
                    { "days_unitfactors_designer_taskcreator", "Deutsche Tage" },
                    { "weeks_unitfactors_designer_taskcreator", "Deutsche Wochen" },

                    // Neue Einträge (aus `de` in CAPS)
                    { "choose_language", "Wähle eine Herkunft:" },
                    { "headline_printtasks_mainmenu", "\nNicht verköstigte Bierpost:\n------------------\n" },
                    { "name_printtasks_mainmenu", "[ Kennung ] = " },
                    { "priority_printtasks_mainmenu", "[ Sushkole Level ] = " },
                    { "date_printtasks_mainmenu", "[ Ablaufdatum ] = " },
                    { "interval_printtasks_mainmenu", "[ Sonntag ]" },
                    { "headline_createtaskmenu", "Bierpost consulten" },
                    { "individualtask_createtaskmenu", "[ Consultige Bierpost ]" },
                    { "automatictask_createtaskmenu", "[ Industrielle Bierpost ]" },
                    { "backuptask_createtaskmenu", "[ Schlagsahne-Bierpost ]" },
                    { "return_createtaskmenu", "[ Entledern ]" },
                    { "headline_autotaskmenu", "Industrielle Bierpost" },
                    { "email_autotaskmenu", "[ Lederle-Post ]" },
                    { "calc_autotaskmenu", "[ Johannes' Modulo Ecke ]" },
                    { "browser_autotaskmenu", "[ Dumbo ]" },
                    { "screenlocker_autotaskmenu", "[ Bildschirm-Krug auskippen ]" },
                    { "return_autotaskmenu", "[ Entledern ]" },
                    { "taskid_designer_backupmanager", "Bierpost-Identifikationsnummer" },
                    { "source_designer_backupmanager", "Quelle" },
                    { "desti_designer_backupmanager", "Durstiger Mund" },
                    { "btype_designer_backupmanager", "Schlagsahne-Typ" },
                    { "bauto_designer_backupmanager", "Industrialisierung" },
                    { "stopseltask_designer_backupmanager", "Bierpost entbixn" },
                    { "stopalltask_designer_backupmanager", "Gesamte Bierpost entbixn" },
                    { "create_designer_taskcreator", "Neue Bierpost ozapfn" },
                    { "condition_taskcreator", "Ben Leuchterle" },
                    { "cpuusage_taskcreator", "Auslastung der in deinem persönlichen Rechner vorhandenen zentralen Recheneinheit" },
                    { "afterboot_taskcreator", "Nach Ingwerwürfelung" },
                    { "beforeshutdown_taskcreator", "Vor Auskippung des Strom-Krugs" },
                    { "nocondition_taskcreator", "Kein Ben Leuchterle" },
                    { "programmrestarting_restartapp", "Die Anwendung wird erneut geledert." },
                    { "restart_restartapp", "Neulederung" }
                }
            }
        };

        /// <summary>
        /// Gibt die übersetzte Zeichenkette für den angegebenen Sprachcode und Schlüssel zurück.
        /// Falls Platzhalter in der Übersetzung vorhanden sind, werden diese mit den übergebenen Werten ersetzt.
        /// Falls keine Übersetzung gefunden wird, wird der Schlüssel selbst zurückgegeben.
        /// </summary>
        /// <param name="language">Der Sprachcode, z. B. "de", "en", "fr" usw.</param>
        /// <param name="key">Der Schlüssel der Übersetzung, z. B. "welcome".</param>
        /// <param name="args">Optionale Parameter, die in der Übersetzung die Platzhalter {0}, {1} usw. ersetzen.</param>
        /// <returns>Die übersetzte Zeichenkette oder den Schlüssel, wenn keine passende Übersetzung vorhanden ist.</returns>
        public static string GetTranslation(string language, string key, params object[] args)
        {
            if (translations.ContainsKey(language) && translations[language].ContainsKey(key))
            {
                var translationStr = translations[language][key];
                for (int i = 0; i < args.Length; i++)
                {
                    translationStr = translationStr.Replace("{" + i.ToString() + "}", args[i].ToString());
                }
                return translationStr;
            }
            return key;
        }

        public static string SaveSettings()
        {
            string settingsFilePath = "settings.txt";

            string settings = CurrentLanguage;

            File.WriteAllText(settingsFilePath, settings);
            return settings;
        }

        public static string GetCurrentLanguage()
        {
            string settingsFilePath = "settings.txt";

            if (File.Exists(settingsFilePath))
            {
                string[] settings = File.ReadAllLines(settingsFilePath);

                if (settings.Length >= 1)
                {
                    CurrentLanguage = settings[0].Replace("\n", "").Trim();
                    return settings[0].Replace("\n", "").Trim();
                }
            }
            return SaveSettings();
        }
    }
}