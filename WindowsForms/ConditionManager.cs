using FileDialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HelperLibrary.TranslationManager;

namespace WindowsForms
{
    public partial class ConditionManager : Form
    {
        private TaskCreator Creator { get; set; }

        private bool _cpuUsage;
        private bool _justBooted;
        private bool _shuttingDown;

        public ConditionManager(TaskCreator creator)
        {
            Creator = creator;

            InitializeComponent();

            cpu.Text = GetTranslation(GetCurrentLanguage(), "cpuusage_taskcreator");
            afterBoot.Text = GetTranslation(GetCurrentLanguage(), "afterboot_taskcreator");
            preShutDown.Text = GetTranslation(GetCurrentLanguage(), "beforeshutdown_taskcreator");
            save.Text = GetTranslation(GetCurrentLanguage(), "save_designer_taskcreator");

            MinimumSize = Size;
            MaximumSize = Size;
        }

        private void Save_MouseClick(object sender, MouseEventArgs e)
        {
            Creator.CpuUsage = _cpuUsage;
            Creator.JustBooted = _justBooted;
            Creator.ShuttingDown = _shuttingDown;

            Close();
        }

        private void CpuUsage_MouseClick(object sender, MouseEventArgs e)
        {
            switch (_cpuUsage)
            {
                case true:
                    _cpuUsage = false;
                    break;
                case false:
                    _cpuUsage = true;
                    break;
            }
        }

        private void AfterBoot_MouseClick(object sender, MouseEventArgs e)
        {
            switch (_justBooted)
            {
                case true:
                    _justBooted = false;
                    break;
                case false:
                    _justBooted = true;
                    break;
            }
        }

        private void PreShutDown_MouseClick(object sender, MouseEventArgs e)
        {
            switch (_shuttingDown)
            {
                case true:
                    _shuttingDown = false;
                    break;
                case false:
                    _shuttingDown = true;
                    break;
            }
        }
    }
}