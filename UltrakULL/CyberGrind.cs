using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;
using UltrakULL.json;
using System.Threading.Tasks;

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
            TextMeshProUGUI titleText= GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(resultsPanel, "Title"),"Text"));
            titleText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_cgTitle;

            //Last result panel
            TextMeshProUGUI lastTitle = GetTextMeshProUGUI(GetGameObjectChild(lastResult, "Text"));
            lastTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_previousRun;

            TextMeshProUGUI lastWave = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(lastResult, "Wave - Info"),"Text"));
            lastWave.text = wave;

            TextMeshProUGUI lastKills = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(lastResult, "Kills - Info"), "Text"));
            lastKills.text = kills;

            TextMeshProUGUI lastStyle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(lastResult, "Style - Info"), "Text"));
            lastStyle.text = style;

            TextMeshProUGUI lastTime = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(lastResult, "Time - Info"), "Text"));
            lastTime.text = time;

            //Best result panel
            TextMeshProUGUI bestTitle = GetTextMeshProUGUI(GetGameObjectChild(bestResult, "Text (1)"));
            bestTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_bestRun;

            TextMeshProUGUI bestWave = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(bestResult, "Wave - Info (1)"), "Text"));
            bestWave.text = wave;

            TextMeshProUGUI bestKills = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(bestResult, "Kills - Info (1)"), "Text"));
            bestKills.text = kills;

            TextMeshProUGUI bestStyle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(bestResult, "Style - Info (1)"), "Text"));
            bestStyle.text = style;

            TextMeshProUGUI bestTime = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(bestResult, "Time - Info (1)"), "Text"));
            bestTime.text = time;

            //Points panel
            TextMeshProUGUI totalPoints = GetTextMeshProUGUI(GetGameObjectChild(pointsPanel, "Text (1)"));
            totalPoints.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_total;

            //Leaderboards

            string connecting = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_connectingToSteam;

            GameObject friendScores = GetGameObjectChild(leaderboardsPanel, "Friend High Scores");
            GameObject globalScores = GetGameObjectChild(leaderboardsPanel, "Global High Scores");

            TextMeshProUGUI friendScoresTitle = GetTextMeshProUGUI(GetGameObjectChild(friendScores, "Text"));
            friendScoresTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_friendScores;

            TextMeshProUGUI globalScoresTitle = GetTextMeshProUGUI(GetGameObjectChild(globalScores, "Text"));
            globalScoresTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_globalScores;

            TextMeshProUGUI friendsConnectingText = GetTextMeshProUGUI(GetGameObjectChild(friendScores, "Connecting"));
            friendsConnectingText.text = connecting;

            TextMeshProUGUI globalConnectingText = GetTextMeshProUGUI(GetGameObjectChild(globalScores, "Connecting"));
            globalConnectingText.text = connecting;


        }

        private static void PatchTerminal()
        {
            GameObject level = GameObject.Find("FirstRoom");
            GameObject cgTerminal = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(level, "Room"),"CyberGrindSettings"),"Canvas");

            GameObject cgTerminalTipbox = GetGameObjectChild(GetGameObjectChild(cgTerminal, "TipBox"),"Panel");

            //Terminal description
            TextMeshProUGUI cgTerminalTipboxTitle = GetTextMeshProUGUI(GetGameObjectChild(cgTerminalTipbox, "Title"));
            cgTerminalTipboxTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_settings;

            TextMeshProUGUI cgTerminalTipboxDescription = GetTextMeshProUGUI(GetGameObjectChild(cgTerminalTipbox, "Text"));
            cgTerminalTipboxDescription.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_settingsDescription;

            //Main menu
            GameObject cgTerminalMainMenu = GetGameObjectChild(GetGameObjectChild(cgTerminal, "Main Menu"),"Buttons");

            TextMeshProUGUI cgTerminalMenuText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgTerminal, "Main Menu"),"Menu Title"));
            cgTerminalMenuText.text = "--" + LanguageManager.CurrentLanguage.shop.shop_menu + "--";

            TextMeshProUGUI cgTerminalThemesText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgTerminalMainMenu, "ThemeButton"), "Text"));
            cgTerminalThemesText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themes;
            
            TextMeshProUGUI cgTerminalMusicText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgTerminalMainMenu, "MusicButton"), "Text"));
            cgTerminalMusicText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_music;

            TextMeshProUGUI cgTerminalPatternsText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgTerminalMainMenu, "PatternsButton"), "Text"));
            cgTerminalPatternsText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patterns;

            TextMeshProUGUI cgTerminalWaveText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgTerminalMainMenu, "WavesButton"), "Text"));
            cgTerminalWaveText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_waves;

            //Themes
            GameObject cgTerminalThemes = GetGameObjectChild(GetGameObjectChild(cgTerminal, "Themes"),"Panel");

            TextMeshProUGUI cgTerminalThemesTitle = GetTextMeshProUGUI(GetGameObjectChild(cgTerminalThemes, "Title"));
            cgTerminalThemesTitle.text = "--" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesTitle + "--";

            TextMeshProUGUI cgTerminalThemesDescription = GetTextMeshProUGUI(GetGameObjectChild(cgTerminalThemes, "Text"));
            cgTerminalThemesDescription.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesDescription;
            
            GameObject cgTerminalThemesButton = GetGameObjectChild(cgTerminalThemes,"Buttons");

            TextMeshProUGUI cgTerminalThemesLight = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgTerminalThemesButton, "LightButton"), "Text"));
            cgTerminalThemesLight.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesLight;

            TextMeshProUGUI cgTerminalThemesDark = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgTerminalThemesButton, "DarkButton"), "Text"));
            cgTerminalThemesDark.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesDark;

            TextMeshProUGUI cgTerminalThemesCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgTerminalThemesButton, "CustomButton"), "Text"));
            cgTerminalThemesCustom.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustom;
            
            //Music
            GameObject cgMusic = GetGameObjectChild(GetGameObjectChild(cgTerminal, "Playlist"),"Panel");
            
            TextMeshProUGUI cgMusicTitle = GetTextMeshProUGUI(GetGameObjectChild(cgMusic,"Title"));
            cgMusicTitle.text = "--"+LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicTitle+"--";
            
            TextMeshProUGUI cgMusicBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgMusic,"BackButton"),"Text"));
            cgMusicBack.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack;

            GameObject cgMusicType = GetGameObjectChild(cgTerminal, "MusicType");
            TextMeshProUGUI cgMusicTypeCancel = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgMusicType, "BackButton"), "Text"));
            cgMusicTypeCancel.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack;

            GameObject cgMusicTypeCanvas = GetGameObjectChild(cgMusicType, "Panel");

            TextMeshProUGUI cgMusicTypeTitle = GetTextMeshProUGUI(GetGameObjectChild(cgMusicTypeCanvas, "Title"));
            cgMusicTypeTitle.text = "--"+LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicTitle+"--";

            TextMeshProUGUI cgMusicTypeText = GetTextMeshProUGUI(GetGameObjectChild(cgMusicTypeCanvas, "Text"));
            cgMusicTypeText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicType;

            GameObject cgMusicTypeButtons = GetGameObjectChild(cgMusicTypeCanvas, "Buttons");
            TextMeshProUGUI cgMusicTypeULTRAKILL = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgMusicTypeButtons, "ULTRAKILLButton"), "Text"));
            cgMusicTypeULTRAKILL.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicSoundtrack;

            TextMeshProUGUI cgMusicTypeCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgMusicTypeButtons, "CustomButton"), "Text"));
            cgMusicTypeCustom.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustom;

            GameObject cgMusicSoundtrack = GetGameObjectChild(GetGameObjectChild(cgTerminal,"SoundtrackMusic"),"Panel");
            TextMeshProUGUI cgMusicSoundtrackTitle = GetTextMeshProUGUI(GetGameObjectChild(cgMusicSoundtrack,"Title"));
            cgMusicSoundtrackTitle.text = "--"+LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicSoundtrack +"--";
            
            TextMeshProUGUI cgMusicSoundtrackConfirm = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgMusicSoundtrack,"Confirm"),"Text"));
            cgMusicSoundtrackConfirm.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicConfirm;
            
            TextMeshProUGUI cgMusicSoundtrackCancel = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgMusicSoundtrack,"BackButton"),"Text"));
            cgMusicSoundtrackCancel.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack;

            GameObject cgMusicSoundtrackAddMenu = GetGameObjectChild(GetGameObjectChild(cgMusicSoundtrack,"ImageSelectorWrapper"),"ImageSelector");

            //CustomMusic
            GameObject cgCustomMusic = GetGameObjectChild(GetGameObjectChild(cgTerminal, "CustomMusic"), "Panel");

            TextMeshProUGUI cgCustomMusicTitle = GetTextMeshProUGUI(GetGameObjectChild(cgCustomMusic, "Title"));
            cgCustomMusicTitle.text = "--" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustom + "--";

            TextMeshProUGUI cgCustomMusicConfirm = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgCustomMusic, "Confirm"), "Text"));
            cgCustomMusicConfirm.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicConfirm;

            TextMeshProUGUI cgCustomMusicCancel = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgCustomMusic, "BackButton"), "Text"));
            cgCustomMusicCancel.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack;

            //Changes the "UNLOCKED" string under songs that are unlocked

            foreach (Transform child in cgMusicSoundtrackAddMenu.transform)
            {
                if (child.name == "SongTemplate(Clone)")
                {
                    TextMeshProUGUI cgMusicSoundtrackTask = GetTextMeshProUGUI(GetGameObjectChild(child.gameObject, "Cost"));
                    if (cgMusicSoundtrackTask.text == "<i>UNLOCKED</i>") { cgMusicSoundtrackTask.text = "<i>" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicUnlocked + "</i>"; }
                }
            }
            Button[] aas = cgMusicSoundtrack.GetComponentsInChildren<Button>(true);
            foreach (Button button in aas)
            {
                button.onClick.AddListener(delegate { Task.Delay(1000); PatchTerminalFolder(); });
            }
            
            
            //Customize theme
            GameObject cgCustomTheme = GetGameObjectChild(GetGameObjectChild(cgTerminal, "CustomTextures"),"Panel");
            TextMeshProUGUI cgCustomThemeTitle = GetTextMeshProUGUI(GetGameObjectChild(cgCustomTheme, "Title"));
            cgCustomThemeTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesModify;

            TextMeshProUGUI cgCustomGrid = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "ModeButtonWrapper"),"BlockTopButton"),"Text"));
            cgCustomGrid.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGrid;

            TextMeshProUGUI cgCustomGridGlow = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "ModeButtonWrapper"), "BlockTopButton (3)"), "Text"));
            cgCustomGridGlow.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGridGlow;

            TextMeshProUGUI cgCustomSkybox = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "ModeButtonWrapper"), "BlockTopButton (2)"), "Text"));
            cgCustomSkybox.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomSkybox;

            TextMeshProUGUI cgCustomThemeBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "BackButton"), "Text"));
            cgCustomThemeBack.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack;

            //Patterns
            TextMeshProUGUI cgCustomRefresh = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "ImageSelectorWrapper"),"RefreshButton"),"Text"));
            cgCustomRefresh.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsRefresh;

            GameObject cgCustomAdditionalRows = GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "AdditionalOptions"),"GridTypeSelection");
            TextMeshProUGUI cgCustomAdditionalBase = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgCustomAdditionalRows, "BaseButton"), "Text"));
            cgCustomAdditionalBase.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBase;

            TextMeshProUGUI cgCustomAdditionalTopRow = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgCustomAdditionalRows, "TopRowButton"), "Text"));
            cgCustomAdditionalTopRow.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomTopRow;

            TextMeshProUGUI cgCustomAdditionalTop = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgCustomAdditionalRows, "TopButton"), "Text"));
            cgCustomAdditionalTop.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomTop;

            TextMeshProUGUI cgCustomAdditionalGlowIntensity = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgCustomTheme, "AdditionalOptions"), "GlowOptions"),"Title"));
            cgCustomAdditionalGlowIntensity.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGlowIntensity;

            //Patterns
            GameObject cgTerminalPatterns = GetGameObjectChild(GetGameObjectChild(cgTerminal, "Patterns"), "Panel");
            
            TextMeshProUGUI cgPatternsWarning = GetTextMeshProUGUI(GetGameObjectChild(cgTerminalPatterns,"WarningText"));
            cgPatternsWarning.text = "<color=red>" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsWarning + "</color>";

            TextMeshProUGUI cgCustomStateButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgTerminalPatterns, "StateButton"), "Text"));
            bool customPatternMode = MonoSingleton<EndlessGrid>.Instance.customPatternMode;
            cgCustomStateButton.text = (customPatternMode ? LanguageManager.CurrentLanguage.misc.state_activated : LanguageManager.CurrentLanguage.misc.state_deactivated);

            TextMeshProUGUI cgTerminalPatternsTitle = GetTextMeshProUGUI(GetGameObjectChild(cgTerminalPatterns, "Title"));
            cgTerminalPatternsTitle.text = "--" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsTitle + "--";
            
            TextMeshProUGUI cgTerminalPatternsRefresh = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgTerminalPatterns, "CustomStuff"), "RefreshButton"),"Text"));
            cgTerminalPatternsRefresh.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsRefresh;
            cgTerminalPatternsRefresh.fontSize = 14;

            TextMeshProUGUI cgTerminalPatternsEditor = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(cgTerminalPatterns, "CustomStuff"), "EditorButton"), "Text"));
            cgTerminalPatternsEditor.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsLaunchExternalEditor;

            //Waves
            GameObject cgTerminalWaves = GetGameObjectChild(GetGameObjectChild(cgTerminal, "Waves"), "Panel");

            TextMeshProUGUI cgTerminalWavesTitle = GetTextMeshProUGUI(GetGameObjectChild(cgTerminalWaves, "Title"));
            cgTerminalWavesTitle.text = "--" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesTitle + "--";

            TextMeshProUGUI cgTerminalWavesText = GetTextMeshProUGUI(GetGameObjectChild(cgTerminalWaves, "Text"));
            cgTerminalWavesText.text =
                LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesDescription1 + ":\n\n" +
                LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesDescription2;
            cgTerminalWavesText.fontSize = 16;
        }

        public async static void PatchTerminalFolder()
        {
            //Changes all folders' own names based on their original name
            GameObject level = GameObject.Find("FirstRoom");
            GameObject cgTerminal = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(level, "Room"), "CyberGrindSettings"), "Canvas");
            GameObject cgMusicSoundtrack = GetGameObjectChild(GetGameObjectChild(cgTerminal, "SoundtrackMusic"), "Panel");
            GameObject cgMusicSoundtrackAddMenu = GetGameObjectChild(GetGameObjectChild(cgMusicSoundtrack, "ImageSelectorWrapper"), "ImageSelector");
            await Task.Delay(10);
            foreach (Transform child in cgMusicSoundtrackAddMenu.transform)
            {
                if (child.name == "FolderTemplate(Clone)")
                {
                    Button a = child.GetComponent<Button>();
                    a.onClick.AddListener(delegate { Task.Delay(1000); PatchTerminalFolder(); });
                    TextMeshProUGUI cgMusicSoundtrackFolderTitle = GetTextMeshProUGUI(GetGameObjectChild(child.gameObject, "Text"));
                    switch (cgMusicSoundtrackFolderTitle.text)
                    {
                        case "THE CYBER GRIND": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameCyberGrind; break; }
                        case "PRELUDE": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNamePrelude; break; }
                        case "ACT 1": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct1; break; }
                        case "ACT 2": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct2; break; }
                        case "ACT 3": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct3; break; }
                        case "SECRET LEVELS": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameSecret; break; }
                        case "PRIME SANCTUMS": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNamePrime; break; }
                        case "MISCELLANEOUS TRACKS": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameMisc; break; }

                        default: {Logging.Warn("Missing CG music folder name: " + cgMusicSoundtrackFolderTitle.text); cgMusicSoundtrackFolderTitle.text = cgMusicSoundtrackFolderTitle.text; break; }
                    }
                }
                if (child.name == "SongTemplate(Clone)")
                {
                    TextMeshProUGUI cgMusicSoundtrackTask = GetTextMeshProUGUI(GetGameObjectChild(child.gameObject, "Cost"));
                    if (cgMusicSoundtrackTask.text == "<i>UNLOCKED</i>") { cgMusicSoundtrackTask.text = "<i>" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicUnlocked + "</i>"; }
                }
            }
            return;
        }
        public static void PatchCg()
        {
            try { PatchWaveBoard(); }catch (Exception e) { Console.WriteLine("Failed to patch CG wave board"); Console.WriteLine(e.ToString());}
            try { PatchResults(); }catch (Exception e) { Console.WriteLine("Failed to patch CG results"); Console.WriteLine(e.ToString());}
            try { PatchTerminal(); }catch (Exception e) { Console.WriteLine("Failed to patch CG terminal"); Console.WriteLine(e.ToString());}
            try { PatchTerminalFolder(); }catch (Exception e) { Console.WriteLine("Failed to patch CG terminal folders"); Console.WriteLine(e.ToString());}
            
        }
    }
}
