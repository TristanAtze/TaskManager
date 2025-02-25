using HelperLibrary;
using RestartApp;
using System.Drawing;
using System.Windows.Forms;
using static HelperLibrary.TranslationManager;

namespace TaskSchedulerApp.Menus;

public class LoadPresetsMenu : Menu
{
    public LoadPresetsMenu()
    {
        var settigns = Config.GetSettings();
        Headline = GetTranslation(GetCurrentLanguage(), "loadpreset_options_mainmenu");
        Options =
        [
            settigns.Presets.ToString(),
            "[ NOCH NICHT FUNKTIONS FÄHIG ]",
            GetTranslation(GetCurrentLanguage(), "return_autotaskmenu")
        ]; 
    }

    protected override void CallChoice()
    {
        switch (ChoiceIndex)
        {
            case 0:
                break;
            case 2:
                KeepGoing = false;
                break;
            default:
                break;
        }
    }
}
