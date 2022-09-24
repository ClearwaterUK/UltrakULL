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
    class CyberGrind
    {
        public void patchWaveBoard(JsonParser language)
        {
            //Get the object containing all the wave board strings.
            //If there's a better way of doing this someone let me know

            GameObject coreGame = GameObject.Find("Everything");
            List<GameObject> everythingList = new List<GameObject>();

            foreach(Transform child in coreGame.transform)
            {
                everythingList.Add(child.gameObject);
            }

            List<GameObject> cubeCanvasList = new List<GameObject>();
            GameObject cubeCanvas = getGameObjectChild(everythingList[4],"Canvas");
            foreach (Transform child in cubeCanvas.transform)
            {
                cubeCanvasList.Add(child.gameObject);
            }
            GameObject cgBoard = cubeCanvasList[1];

            //Patch all the strings here.
            Text waveText = getTextfromGameObject(getGameObjectChild(cgBoard, "Wave Title"));
            waveText.text = language.currentLanguage.cyberGrind.cybergrind_wave +  ":";

            Text enemiesLeftText = getTextfromGameObject(getGameObjectChild(cgBoard, "Enemies Left Title"));
            enemiesLeftText.text = language.currentLanguage.cyberGrind.cybergrind_enemiesRemaining + ":";

        }

        public void patchResults(GameObject level, JsonParser language)
        {
            level = GameObject.Find("Player");

            GameObject resultsPanel = getGameObjectChild(getGameObjectChild(level, "FinishCanvas (1)"), "Panel");
            GameObject lastResult = getGameObjectChild(resultsPanel, "Panel");
            GameObject bestResult = getGameObjectChild(getGameObjectChild(resultsPanel, "Panel (1)"),"Filler");
            GameObject pointsPanel = getGameObjectChild(resultsPanel, "Total Points");
            GameObject leaderboardsPanel = getGameObjectChild(resultsPanel, "Leaderboards");

            //Both result panels use the same strings, so declare them here to avoid redundancy.
            string wave = language.currentLanguage.cyberGrind.cybergrind_wave;
            string kills = language.currentLanguage.misc.levelstats_kills;
            string style = language.currentLanguage.misc.levelstats_style;
            string time = language.currentLanguage.misc.levelstats_time;


            //Title
            Text titleText= getTextfromGameObject(getGameObjectChild(getGameObjectChild(resultsPanel, "Title"),"Text"));
            titleText.text = language.currentLanguage.cyberGrind.cybergrind_cgTitle;

            //Last result panel
            Text lastTitle = getTextfromGameObject(getGameObjectChild(lastResult, "Text"));
            lastTitle.text = language.currentLanguage.cyberGrind.cybergrind_previousRun;

            Text lastWave = getTextfromGameObject(getGameObjectChild(getGameObjectChild(lastResult, "Wave - Info"),"Text"));
            lastWave.text = wave;

            Text lastKills = getTextfromGameObject(getGameObjectChild(getGameObjectChild(lastResult, "Kills - Info"), "Text"));
            lastKills.text = kills;

            Text lastStyle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(lastResult, "Style - Info"), "Text"));
            lastStyle.text = style;

            Text lastTime = getTextfromGameObject(getGameObjectChild(getGameObjectChild(lastResult, "Time - Info"), "Text"));
            lastTime.text = time;

            //Best result panel
            Text bestTitle = getTextfromGameObject(getGameObjectChild(bestResult, "Text (1)"));
            bestTitle.text = language.currentLanguage.cyberGrind.cybergrind_bestRun;

            Text bestWave = getTextfromGameObject(getGameObjectChild(getGameObjectChild(bestResult, "Wave - Info (1)"), "Text"));
            bestWave.text = wave;

            Text bestKills = getTextfromGameObject(getGameObjectChild(getGameObjectChild(bestResult, "Kills - Info (1)"), "Text"));
            bestKills.text = kills;

            Text bestStyle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(bestResult, "Style - Info (1)"), "Text"));
            bestStyle.text = style;

            Text bestTime = getTextfromGameObject(getGameObjectChild(getGameObjectChild(bestResult, "Time - Info (1)"), "Text"));
            bestTime.text = time;

            //Points panel
            Text totalPoints = getTextfromGameObject(getGameObjectChild(pointsPanel, "Text (1)"));
            totalPoints.text = language.currentLanguage.cyberGrind.cybergrind_total;

            //Leaderboards

            string connecting = language.currentLanguage.cyberGrind.cybergrind_connectingToSteam;

            GameObject friendScores = getGameObjectChild(leaderboardsPanel, "Friend High Scores");
            GameObject globalScores = getGameObjectChild(leaderboardsPanel, "Global High Scores");

            Text friendScoresTitle = getTextfromGameObject(getGameObjectChild(friendScores, "Text"));
            friendScoresTitle.text = language.currentLanguage.cyberGrind.cybergrind_friendScores;

            Text globalScoresTitle = getTextfromGameObject(getGameObjectChild(globalScores, "Text"));
            globalScoresTitle.text = language.currentLanguage.cyberGrind.cybergrind_globalScores;

            Text friendsConnectingText = getTextfromGameObject(getGameObjectChild(friendScores, "Connecting"));
            friendsConnectingText.text = connecting;

            Text globalConnectingText = getTextfromGameObject(getGameObjectChild(globalScores, "Connecting"));
            globalConnectingText.text = connecting;


        }

        public void patchTerminal(GameObject level,JsonParser language)
        {
            level = GameObject.Find("FirstRoom");
            GameObject cgTerminal = getGameObjectChild(getGameObjectChild(getGameObjectChild(level, "Room"),"CyberGrindSettings"),"Canvas");

            GameObject cgTerminalTipbox = getGameObjectChild(getGameObjectChild(cgTerminal, "TipBox"),"Panel");

            //Terminal description
            Text cgTerminalTipboxTitle = getTextfromGameObject(getGameObjectChild(cgTerminalTipbox, "Title"));
            cgTerminalTipboxTitle.text = language.currentLanguage.cyberGrind.cybergrind_settings;

            Text cgTerminalTipboxDescription = getTextfromGameObject(getGameObjectChild(cgTerminalTipbox, "Text"));
            cgTerminalTipboxDescription.text = language.currentLanguage.cyberGrind.cybergrind_settingsDescription;

            //Main menu
            GameObject cgTerminalMainMenu = getGameObjectChild(cgTerminal, "Main Menu");

            Text cgTerminalThemesText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalMainMenu, "ThemeButton"), "Text"));
            cgTerminalThemesText.text = language.currentLanguage.cyberGrind.cybergrind_themes;

            Text cgTerminalPatternsText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalMainMenu, "PatternsButton"), "Text"));
            cgTerminalPatternsText.text = language.currentLanguage.cyberGrind.cybergrind_patterns;

            Text cgTerminalWaveText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalMainMenu, "WavesButton"), "Text"));
            cgTerminalWaveText.text = language.currentLanguage.cyberGrind.cybergrind_waves;

            //Themes

            GameObject cgTerminalThemes = getGameObjectChild(getGameObjectChild(cgTerminal, "Themes"),"Panel");

            Text cgTerminalThemesTitle = getTextfromGameObject(getGameObjectChild(cgTerminalThemes, "Title"));
            cgTerminalThemesTitle.text = "--" + language.currentLanguage.cyberGrind.cybergrind_themesTitle + "--";

            Text cgTerminalThemesDescription = getTextfromGameObject(getGameObjectChild(cgTerminalThemes, "Text"));
            cgTerminalThemesDescription.text = language.currentLanguage.cyberGrind.cybergrind_themesDescription;

            Text cgTerminalThemesLight = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalThemes, "LightButton"), "Text"));
            cgTerminalThemesLight.text = language.currentLanguage.cyberGrind.cybergrind_themesLight;

            Text cgTerminalThemesDark = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalThemes, "DarkButton"), "Text"));
            cgTerminalThemesDark.text = language.currentLanguage.cyberGrind.cybergrind_themesDark;

            Text cgTerminalThemesCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalThemes, "CustomButton"), "Text"));
            cgTerminalThemesCustom.text = language.currentLanguage.cyberGrind.cybergrind_themesCustom;

            //Customize theme
            GameObject cgCustomTheme = getGameObjectChild(getGameObjectChild(cgTerminal, "Custom"),"Panel");
            Console.WriteLine("cgCustomThemeTitle");
            Text cgCustomThemeTitle = getTextfromGameObject(getGameObjectChild(cgCustomTheme, "Title"));
            cgCustomThemeTitle.text = language.currentLanguage.cyberGrind.cybergrind_themesModify;




            Text cgCustomGrid = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgCustomTheme, "ModeButtonWrapper"),"BlockTopButton"),"Text"));
            cgCustomGrid.text = language.currentLanguage.cyberGrind.cybergrind_themesCustomGrid;

            Text cgCustomGridGlow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgCustomTheme, "ModeButtonWrapper"), "BlockTopButton (3)"), "Text"));
            cgCustomGridGlow.text = language.currentLanguage.cyberGrind.cybergrind_themesCustomGridGlow;

            Text cgCustomSkybox = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgCustomTheme, "ModeButtonWrapper"), "BlockTopButton (2)"), "Text"));
            cgCustomSkybox.text = language.currentLanguage.cyberGrind.cybergrind_themesCustomSkybox;

            Text cgCustomThemeBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgCustomTheme, "BackButton"), "Text"));
            cgCustomThemeBack.text = language.currentLanguage.cyberGrind.cybergrind_themesCustomBack;

            //a
            Text cgCustomRefresh = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgCustomTheme, "ImageSelectorWrapper"),"RefreshButton"),"Text"));
            cgCustomRefresh.text = language.currentLanguage.cyberGrind.cybergrind_patternsRefresh;

            GameObject cgCustomAdditionalRows = getGameObjectChild(getGameObjectChild(cgCustomTheme, "AdditionalOptions"),"GridTypeSelection");
            Text cgCustomAdditionalBase = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgCustomAdditionalRows, "BaseButton"), "Text"));
            cgCustomAdditionalBase.text = language.currentLanguage.cyberGrind.cybergrind_themesCustomBase;

            Text cgCustomAdditionalTopRow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgCustomAdditionalRows, "TopRowButton"), "Text"));
            cgCustomAdditionalTopRow.text = language.currentLanguage.cyberGrind.cybergrind_themesCustomTopRow;

            Text cgCustomAdditionalTop = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgCustomAdditionalRows, "TopButton"), "Text"));
            cgCustomAdditionalTop.text = language.currentLanguage.cyberGrind.cybergrind_themesCustomTop;

            Text cgCustomAdditionalGlowIntensity = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgCustomTheme, "AdditionalOptions"), "GlowOptions"),"Title"));
            cgCustomAdditionalGlowIntensity.text = language.currentLanguage.cyberGrind.cybergrind_themesCustomGlowIntensity;

            //Patterns
            GameObject cgTerminalPatterns = getGameObjectChild(getGameObjectChild(cgTerminal, "Patterns"), "Panel");


            Text cgCustomStateButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalPatterns, "StateButton"), "Text"));
            bool customPatternMode = MonoSingleton<EndlessGrid>.Instance.customPatternMode;
            cgCustomStateButton.text = (customPatternMode ? language.currentLanguage.misc.state_activated : language.currentLanguage.misc.state_deactivated);

            Text cgTerminalPatternsTitle = getTextfromGameObject(getGameObjectChild(cgTerminalPatterns, "Title"));
            cgTerminalPatternsTitle.text = "--" + language.currentLanguage.cyberGrind.cybergrind_patternsTitle + "--";

            //Note - Will need to patch Toggle() in CustomPatterns for the "enabled"/"disabled" button.

            Text cgTerminalPatternsRefresh = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgTerminalPatterns, "CustomStuff"), "RefreshButton"),"Text"));
            cgTerminalPatternsRefresh.text = language.currentLanguage.cyberGrind.cybergrind_patternsRefresh;
            cgTerminalPatternsRefresh.fontSize = 14;

            Text cgTerminalPatternsEditor = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgTerminalPatterns, "CustomStuff"), "EditorButton"), "Text"));
            cgTerminalPatternsEditor.text = language.currentLanguage.cyberGrind.cybergrind_patternsLaunchExternalEditor;

            //Waves

            GameObject cgTerminalWaves = getGameObjectChild(getGameObjectChild(cgTerminal, "Waves"), "Panel");

            Text cgTerminalWavesTitle = getTextfromGameObject(getGameObjectChild(cgTerminalWaves, "Title"));
            cgTerminalWavesTitle.text = "--" + language.currentLanguage.cyberGrind.cybergrind_wavesTitle + "--";

            Text cgTerminalWavesText = getTextfromGameObject(getGameObjectChild(cgTerminalWaves, "Text"));
            cgTerminalWavesText.text =
                language.currentLanguage.cyberGrind.cybergrind_wavesDescription1 + ":\n\n" +
                language.currentLanguage.cyberGrind.cybergrind_wavesDescription2;
            cgTerminalWavesText.fontSize = 16;
        }
        public CyberGrind(ref GameObject level,JsonParser language)
        {
            var cgLogger = BepInEx.Logging.Logger.CreateLogSource("CGPatcher");
            cgLogger.LogInfo("Now entering CyberGrind class.");
            this.patchWaveBoard(language);
            this.patchResults(level, language);
            this.patchTerminal(level, language);
        }

    }
}
