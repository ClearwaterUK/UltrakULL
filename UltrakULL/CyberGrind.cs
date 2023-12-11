using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    public static class CyberGrind
    {
        private static void PatchWaveBoard()
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
            GameObject cubeCanvas = GetGameObjectChild(everythingList[4],"Canvas");
            foreach (Transform child in cubeCanvas.transform)
            {
                cubeCanvasList.Add(child.gameObject);
            }
            GameObject cgBoard = cubeCanvasList[1];

            //Patch all the strings here.
            Text waveText = GetTextfromGameObject(GetGameObjectChild(cgBoard, "Wave Title"));
            waveText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wave +  ":";

            Text enemiesLeftText = GetTextfromGameObject(GetGameObjectChild(cgBoard, "Enemies Left Title"));
            enemiesLeftText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_enemiesRemaining + ":";

        }

        private static void PatchResults()
        {
            GameObject level = GameObject.Find("Player");

            GameObject resultsPanel = GetGameObjectChild(GetGameObjectChild(level, "FinishCanvas (1)"), "Panel");
            GameObject lastResult = GetGameObjectChild(resultsPanel, "Panel");
            GameObject bestResult = GetGameObjectChild(GetGameObjectChild(resultsPanel, "Panel (1)"),"Filler");
            GameObject pointsPanel = GetGameObjectChild(resultsPanel, "Total Points");
            GameObject leaderboardsPanel = GetGameObjectChild(resultsPanel, "Leaderboards");

            //Both result panels use the same strings, so declare them here to avoid redundancy.
            string wave = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wave;
            string kills = LanguageManager.CurrentLanguage.misc.levelstats_kills;
            string style = LanguageManager.CurrentLanguage.misc.levelstats_style;
            string time = LanguageManager.CurrentLanguage.misc.levelstats_time;


            //Title
            Text titleText= GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(resultsPanel, "Title"),"Text"));
            titleText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_cgTitle;

            //Last result panel
            Text lastTitle = GetTextfromGameObject(GetGameObjectChild(lastResult, "Text"));
            lastTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_previousRun;

            Text lastWave = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(lastResult, "Wave - Info"),"Text"));
            lastWave.text = wave;

            Text lastKills = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(lastResult, "Kills - Info"), "Text"));
            lastKills.text = kills;

            Text lastStyle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(lastResult, "Style - Info"), "Text"));
            lastStyle.text = style;

            Text lastTime = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(lastResult, "Time - Info"), "Text"));
            lastTime.text = time;

            //Best result panel
            Text bestTitle = GetTextfromGameObject(GetGameObjectChild(bestResult, "Text (1)"));
            bestTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_bestRun;

            Text bestWave = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(bestResult, "Wave - Info (1)"), "Text"));
            bestWave.text = wave;

            Text bestKills = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(bestResult, "Kills - Info (1)"), "Text"));
            bestKills.text = kills;

            Text bestStyle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(bestResult, "Style - Info (1)"), "Text"));
            bestStyle.text = style;

            Text bestTime = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(bestResult, "Time - Info (1)"), "Text"));
            bestTime.text = time;

            //Points panel
            Text totalPoints = GetTextfromGameObject(GetGameObjectChild(pointsPanel, "Text (1)"));
            totalPoints.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_total;

            //Leaderboards

            string connecting = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_connectingToSteam;

            GameObject friendScores = GetGameObjectChild(leaderboardsPanel, "Friend High Scores");
            GameObject globalScores = GetGameObjectChild(leaderboardsPanel, "Global High Scores");

            Text friendScoresTitle = GetTextfromGameObject(GetGameObjectChild(friendScores, "Text"));
            friendScoresTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_friendScores;

            Text globalScoresTitle = GetTextfromGameObject(GetGameObjectChild(globalScores, "Text"));
            globalScoresTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_globalScores;

            Text friendsConnectingText = GetTextfromGameObject(GetGameObjectChild(friendScores, "Connecting"));
            friendsConnectingText.text = connecting;

            Text globalConnectingText = GetTextfromGameObject(GetGameObjectChild(globalScores, "Connecting"));
            globalConnectingText.text = connecting;


        }

        private static void PatchTerminal()
        {
            GameObject level = GameObject.Find("FirstRoom");
            GameObject cgTerminal = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(level, "Room"),"CyberGrindSettings"),"Canvas");

            GameObject cgTerminalTipbox = GetGameObjectChild(GetGameObjectChild(cgTerminal, "TipBox"),"Panel");

            //Terminal description
            Text cgTerminalTipboxTitle = GetTextfromGameObject(GetGameObjectChild(cgTerminalTipbox, "Title"));
            cgTerminalTipboxTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_settings;

            Text cgTerminalTipboxDescription = GetTextfromGameObject(GetGameObjectChild(cgTerminalTipbox, "Text"));
            cgTerminalTipboxDescription.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_settingsDescription;

            //Main menu
            GameObject cgTerminalMainMenu = GetGameObjectChild(GetGameObjectChild(cgTerminal, "Main Menu"),"Buttons");

            Text cgTerminalThemesText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgTerminalMainMenu, "ThemeButton"), "Text"));
            cgTerminalThemesText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themes;
            
            Text cgTerminalMusicText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgTerminalMainMenu, "MusicButton"), "Text"));
            cgTerminalMusicText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_music;

            Text cgTerminalPatternsText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgTerminalMainMenu, "PatternsButton"), "Text"));
            cgTerminalPatternsText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patterns;

            Text cgTerminalWaveText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgTerminalMainMenu, "WavesButton"), "Text"));
            cgTerminalWaveText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_waves;

            //Themes
            GameObject cgTerminalThemes = GetGameObjectChild(GetGameObjectChild(cgTerminal, "Themes"),"Panel");

            Text cgTerminalThemesTitle = GetTextfromGameObject(GetGameObjectChild(cgTerminalThemes, "Title"));
            cgTerminalThemesTitle.text = "--" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesTitle + "--";

            Text cgTerminalThemesDescription = GetTextfromGameObject(GetGameObjectChild(cgTerminalThemes, "Text"));
            cgTerminalThemesDescription.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesDescription;
            
            GameObject cgTerminalThemesButton = GetGameObjectChild(cgTerminalThemes,"Buttons");

            Text cgTerminalThemesLight = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgTerminalThemesButton, "LightButton"), "Text"));
            cgTerminalThemesLight.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesLight;

            Text cgTerminalThemesDark = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgTerminalThemesButton, "DarkButton"), "Text"));
            cgTerminalThemesDark.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesDark;

            Text cgTerminalThemesCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgTerminalThemesButton, "CustomButton"), "Text"));
            cgTerminalThemesCustom.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustom;
            
            //Music
            GameObject cgMusic = GetGameObjectChild(GetGameObjectChild(cgTerminal, "Playlist"),"Panel");
            
            Text cgMusicTitle = GetTextfromGameObject(GetGameObjectChild(cgMusic,"Title"));
            cgMusicTitle.text = "--"+LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicTitle+"--";
            
            Text cgMusicBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgMusic,"BackButton"),"Text"));
            cgMusicBack.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack;
            
            GameObject cgMusicSoundtrack = GetGameObjectChild(GetGameObjectChild(cgTerminal,"SoundtrackMusic"),"Panel");
            Text cgMusicSoundtrackTitle = GetTextfromGameObject(GetGameObjectChild(cgMusicSoundtrack,"Title"));
            cgMusicSoundtrackTitle.text = "--"+LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicSoundtrack +"--";
            
            Text cgMusicSoundtrackConfirm = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgMusicSoundtrack,"Confirm"),"Text"));
            cgMusicSoundtrackConfirm.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicConfirm;
            
            Text cgMusicSoundtrackCancel = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgMusicSoundtrack,"BackButton"),"Text"));
            cgMusicSoundtrackCancel.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack;

            GameObject cgMusicSoundtrackAddMenu = GetGameObjectChild(GetGameObjectChild(cgMusicSoundtrack,"ImageSelectionWrapper"),"ImageSelector");

            //Changes the "UNLOCKED" string under songs that are unlocked
            foreach (GameObject child in cgMusicSoundtrackAddMenu.transform)
            {
                if (child.name == "SongTemplate(Clone)")
                {
                    Text cgMusicSoundtrackTask = GetTextfromGameObject(GetGameObjectChild(child, "Cost"));
                    if (cgMusicSoundtrackTask.text == "<i>UNLOCKED</i>") { cgMusicSoundtrackTask.text = "<i>" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicUnlocked + "/<i>"; }
                }
            }
            
            
            //Customize theme
            GameObject cgCustomTheme = GetGameObjectChild(GetGameObjectChild(cgTerminal, "CustomTextures"),"Panel");
            Text cgCustomThemeTitle = GetTextfromGameObject(GetGameObjectChild(cgCustomTheme, "Title"));
            cgCustomThemeTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesModify;


            Text cgCustomGrid = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "ModeButtonWrapper"),"BlockTopButton"),"Text"));
            cgCustomGrid.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGrid;

            Text cgCustomGridGlow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "ModeButtonWrapper"), "BlockTopButton (3)"), "Text"));
            cgCustomGridGlow.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGridGlow;

            Text cgCustomSkybox = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "ModeButtonWrapper"), "BlockTopButton (2)"), "Text"));
            cgCustomSkybox.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomSkybox;

            Text cgCustomThemeBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "BackButton"), "Text"));
            cgCustomThemeBack.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack;

            //Patterns
            Text cgCustomRefresh = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "ImageSelectorWrapper"),"RefreshButton"),"Text"));
            cgCustomRefresh.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsRefresh;

            GameObject cgCustomAdditionalRows = GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "AdditionalOptions"),"GridTypeSelection");
            Text cgCustomAdditionalBase = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgCustomAdditionalRows, "BaseButton"), "Text"));
            cgCustomAdditionalBase.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBase;

            Text cgCustomAdditionalTopRow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgCustomAdditionalRows, "TopRowButton"), "Text"));
            cgCustomAdditionalTopRow.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomTopRow;

            Text cgCustomAdditionalTop = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgCustomAdditionalRows, "TopButton"), "Text"));
            cgCustomAdditionalTop.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomTop;

            Text cgCustomAdditionalGlowIntensity = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "AdditionalOptions"), "GlowOptions"),"Title"));
            cgCustomAdditionalGlowIntensity.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGlowIntensity;

            //Patterns
            GameObject cgTerminalPatterns = GetGameObjectChild(GetGameObjectChild(cgTerminal, "Patterns"), "Panel");
            
            Text cgPatternsWarning = GetTextfromGameObject(GetGameObjectChild(cgTerminalPatterns,"WarningText"));
            cgPatternsWarning.text = "<color=red>" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsWarning + "</color>";


            Text cgCustomStateButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgTerminalPatterns, "StateButton"), "Text"));
            bool customPatternMode = MonoSingleton<EndlessGrid>.Instance.customPatternMode;
            cgCustomStateButton.text = (customPatternMode ? LanguageManager.CurrentLanguage.misc.state_activated : LanguageManager.CurrentLanguage.misc.state_deactivated);

            Text cgTerminalPatternsTitle = GetTextfromGameObject(GetGameObjectChild(cgTerminalPatterns, "Title"));
            cgTerminalPatternsTitle.text = "--" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsTitle + "--";
            
            Text cgTerminalPatternsRefresh = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgTerminalPatterns, "CustomStuff"), "RefreshButton"),"Text"));
            cgTerminalPatternsRefresh.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsRefresh;
            cgTerminalPatternsRefresh.fontSize = 14;

            Text cgTerminalPatternsEditor = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgTerminalPatterns, "CustomStuff"), "EditorButton"), "Text"));
            cgTerminalPatternsEditor.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsLaunchExternalEditor;

            //Waves
            GameObject cgTerminalWaves = GetGameObjectChild(GetGameObjectChild(cgTerminal, "Waves"), "Panel");

            Text cgTerminalWavesTitle = GetTextfromGameObject(GetGameObjectChild(cgTerminalWaves, "Title"));
            cgTerminalWavesTitle.text = "--" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesTitle + "--";

            Text cgTerminalWavesText = GetTextfromGameObject(GetGameObjectChild(cgTerminalWaves, "Text"));
            cgTerminalWavesText.text =
                LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesDescription1 + ":\n\n" +
                LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesDescription2;
            cgTerminalWavesText.fontSize = 16;
        }

        public static string PatchTerminalFolder()
        {
            //Changes all folders' own names based on their original name
            GameObject level = GameObject.Find("FirstRoom");
            GameObject cgTerminal = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(level, "Room"), "CyberGrindSettings"), "Canvas");
            GameObject cgMusicSoundtrack = GetGameObjectChild(GetGameObjectChild(cgTerminal, "SoundtrackMusic"), "Panel");
            GameObject cgMusicSoundtrackAddMenu = GetGameObjectChild(GetGameObjectChild(cgMusicSoundtrack, "ImageSelectionWrapper"), "ImageSelector");
            foreach (GameObject child in cgMusicSoundtrackAddMenu.transform)
            {
                if (child.name == "FolderTemplate(Clone)")
                {
                    Text cgMusicSoundtrackFolderTitle = GetTextfromGameObject(GetGameObjectChild(child, "Text"));
                    switch (cgMusicSoundtrackFolderTitle.text)
                    {
                        case "THE CYBER GRIND": { return LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameCyberGrind; }
                        case "PRELUDE": { return LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNamePrelude; }
                        case "ACT 1": { return LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct1; }
                        case "ACT 2": { return LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct2; }
                        case "ACT 3": { return LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct3; } //For when the act 3 folder gets added, currently shouldn't get activated
                        case "SECRET LEVELS": { return LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameSecret; }
                        case "PRIME SANCTUMS": { return LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNamePrime; }
                        case "MISCELLANEOUS TRACKS": { return LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameMisc; }

                        default: { return "Unknown folder name"; }
                    }
                }
            }
            return "Missing folder reference";
        }
        public static void PatchCg()
        {
            PatchWaveBoard();
            PatchResults();
            PatchTerminal();
            PatchTerminalFolder();
        }
    }
}
