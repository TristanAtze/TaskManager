﻿using RestartApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;
using static TranslationsLibrary.TranslationManager;

namespace TaskSchedulerApp.Menus;

public class LanguageMenu : Menu
{
    public LanguageMenu()
    {
        Headline = GetTranslation(GetCurrentLanguage(), "choose_language");
        Options =
        [
            "[ Deutsch ]",
            "[ English ]",
            "[ Français ]",
            "[ Italiano ]",
            "[ Español ]",
            "[ 中文 (Mandarin) ]",
            "[ हिंदी (Hindi) ]",
            "[ Baschding ]",
            " ",
            GetTranslation(GetCurrentLanguage(), "back_options_settingsmenu")
        ];
    }

    protected override void CallChoice()
    {
        bool getBack = false;
        switch (ChoiceIndex)
        {
            case 0:
                CurrentLanguage = "de";
                break;
            case 1:
                CurrentLanguage = "en";
                break;
            case 2:
                CurrentLanguage = "fr";
                break;
            case 3:
                CurrentLanguage = "it";
                break;
            case 4:
                CurrentLanguage = "es";
                break;
            case 5:
                CurrentLanguage = "zh";
                break;
            case 6:
                CurrentLanguage = "hi";
                break;
            case 7:
                CurrentLanguage = "bd";
                break;
            case 9:
                getBack = true;
                break;
            default:
                break;
        }
        KeepGoing = false;
        SaveSettings();

        if (!getBack)
            DoRestart();

    }

    private static void DoRestart()
    {
        Application.Run(new MainForm());
        Environment.Exit(0);
    }
}
