using FileDialog;
using static HelperLibrary.TranslationManager;

namespace TaskSchedulerApp.Menus;

public class SettingsMenu : Menu
{
    public SettingsMenu()
    {
        Headline = GetTranslation(GetCurrentLanguage(), "headline_settingsmenu");
        Options =
        [
            GetTranslation(GetCurrentLanguage(), "taskpreset_options_settingsmenu"),
            GetTranslation(GetCurrentLanguage(), "language_options_settingsmenu"),
            GetTranslation(GetCurrentLanguage(), "color_options_settingsmenu"),
            " ",
            GetTranslation(GetCurrentLanguage(), "back_options_settingsmenu")
        ];
    }

    protected override void CallChoice()
    {
        switch (ChoiceIndex)
        {
            case 0:
                TaskCreator.StartTaskCreator(1);
                break;
            case 1:
                var settings = new LanguageMenu();
                settings.Start();
                break;
            case 2:
                var color = new ColorMenu();
                color.Start();
                break;
            case 4:
                KeepGoing = false;
                break;
            default:
                break;
        }
    }
}
