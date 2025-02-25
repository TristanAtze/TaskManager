using HelperLibrary;
using RestartApp;
using System.Windows.Forms;

//using static System.Net.Mime.MediaTypeNames;
using static HelperLibrary.TranslationManager;

namespace TaskSchedulerApp.Menus;

public class ColorMenu : Menu
{
    public ColorMenu()
    {
        Headline = GetTranslation(GetCurrentLanguage(), "choose_language");
        Options =
        [
            $"[ {GetTranslation(GetCurrentLanguage(), "[ Blue ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ Cyan ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ DarkBlue ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ DarkCyan ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ DarkGray ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ DarkGreen ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ DarkMagenta ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ DarkRed ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ DarkYellow ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ Gray ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ Green ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ Magenta ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ Red ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ White ]")} ]",
            $"[ {GetTranslation(GetCurrentLanguage(), "[ Yellow ]")} ]",
            " ",
            GetTranslation(GetCurrentLanguage(), "back_options_settingsmenu")
        ];
    }

    protected override void CallChoice()
    {
        bool getBack = false;
        int color = 15;
        switch (ChoiceIndex)
        {
            case 0:
                color = 9;
                break;
            case 1:
                color = 11;
                break;
            case 2:
                color = 1;
                break;
            case 3:
                color = 3;
                break;
            case 4:
                color = 8;
                break;
            case 5:
                color = 2;
                break;
            case 6:
                color = 5;
                break;
            case 7:
                color = 4;
                break;
            case 8:
                color = 6;
                break;
            case 9:
                color = 7;
                break;
            case 10:
                color = 10;
                break;
            case 11:
                color = 13;
                break;
            case 12:
                color = 12;
                break;
            case 13:
                color = 15;
                break;
            case 14:
                color = 14;
                break;
            case 16:
                getBack = true;
                break;
            default:
                break;
        }
        KeepGoing = false;
        Config.SaveSettings(null, (ConsoleColor)color);

        if (!getBack)
            DoRestart();

    }

    private static void DoRestart()
    {
        Application.Run(new MainForm());
        Environment.Exit(0);
    }
}
