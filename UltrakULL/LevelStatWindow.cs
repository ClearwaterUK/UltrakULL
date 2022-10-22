using BepInEx;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    public static class LevelStatWindow
    {
        public static void patchStats()
        {
            GameObject canvas = getInactiveRootObject("Canvas");

            GameObject levelStatsWindow = getGameObjectChild(getGameObjectChild(canvas, "Level Stats Controller"), "Level Stats (1)");
            //Secret levels will only have a timer, or something else.
            Text timeName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Time Title"));
            timeName.text = LanguageManager.CurrentLanguage.misc.levelstats_time; 

            Text killsName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Kills Title"));
            killsName.text = LanguageManager.CurrentLanguage.misc.levelstats_kills;

            Text styleName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Style Title"));
            styleName.text = LanguageManager.CurrentLanguage.misc.levelstats_style;

            Text secretsName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Secrets Title"));
            secretsName.text = LanguageManager.CurrentLanguage.misc.levelstats_secrets;

            Text challengesName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Challenge Title"));
            challengesName.text = LanguageManager.CurrentLanguage.misc.levelstats_challenge;

            Text assistsName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Assists Title"));
            assistsName.text = LanguageManager.CurrentLanguage.misc.levelstats_majorAssists;

            if (SceneManager.GetActiveScene().name == "Level 4-S")
            {
                Text cratesName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Crates Counter"));
                cratesName.text = LanguageManager.CurrentLanguage.misc.levelstats_boxes;
            }
        }
    }
}
