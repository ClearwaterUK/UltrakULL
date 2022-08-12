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

namespace UltrakULL
{
    class CyberGrind
    {
        public void patchWaveBoard()
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
            waveText.text = "VAGUE:";

            Text enemiesLeftText = getTextfromGameObject(getGameObjectChild(cgBoard, "Enemies Left Title"));
            enemiesLeftText.text = "ENNEMIES RESTANTES:";

        }

        public void patchResults(GameObject level)
        {
            level = GameObject.Find("Player");

            GameObject resultsPanel = getGameObjectChild(getGameObjectChild(level, "FinishCanvas (1)"), "Panel");
            GameObject lastResult = getGameObjectChild(resultsPanel, "Panel");
            GameObject bestResult = getGameObjectChild(getGameObjectChild(resultsPanel, "Panel (1)"),"Filler");
            GameObject pointsPanel = getGameObjectChild(resultsPanel, "Total Points");
            GameObject leaderboardsPanel = getGameObjectChild(resultsPanel, "Leaderboards");

            //Both result panels use the same strings, so declare them here to avoid redundancy.
            string wave = "VAGUE";
            string kills = "TUES";
            string style = "STYLE";
            string time = "TEMPS";


            //Title
            Text titleText= getTextfromGameObject(getGameObjectChild(getGameObjectChild(resultsPanel, "Title"),"Text"));
            titleText.text = "LE CYBERGRIND";

            //Last result panel
            Text lastTitle = getTextfromGameObject(getGameObjectChild(lastResult, "Text"));
            lastTitle.text = "DERNIER";

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
            bestTitle.text = "MEILLEUR";

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
            totalPoints.text = "TOTALE:";

            //Leaderboards

            string connecting = "CONNEXION À STEAM...";

            GameObject friendScores = getGameObjectChild(leaderboardsPanel, "Friend High Scores");
            GameObject globalScores = getGameObjectChild(leaderboardsPanel, "Global High Scores");

            Text friendScoresTitle = getTextfromGameObject(getGameObjectChild(friendScores, "Text"));
            friendScoresTitle.text = "MEILLEURES SCORES (AMIS)";

            Text globalScoresTitle = getTextfromGameObject(getGameObjectChild(globalScores, "Text"));
            globalScoresTitle.text = "MEILLEURES SCORES (GLOBALE)";

            Text friendsConnectingText = getTextfromGameObject(getGameObjectChild(friendScores, "Connecting"));
            friendsConnectingText.text = connecting;

            Text globalConnectingText = getTextfromGameObject(getGameObjectChild(globalScores, "Connecting"));
            globalConnectingText.text = connecting;


        }

        public void patchTerminal(GameObject level)
        {
            level = GameObject.Find("FirstRoom");
            GameObject cgTerminal = getGameObjectChild(getGameObjectChild(getGameObjectChild(level, "Room"),"CyberGrindSettings"),"Canvas");

            GameObject cgTerminalTipbox = getGameObjectChild(getGameObjectChild(cgTerminal, "TipBox"),"Panel");

            //Terminal description
            Text cgTerminalTipboxTitle = getTextfromGameObject(getGameObjectChild(cgTerminalTipbox, "Title"));
            cgTerminalTipboxTitle.text = "PARAMÈTRES CYBERGRIND";

            Text cgTerminalTipboxDescription = getTextfromGameObject(getGameObjectChild(cgTerminalTipbox, "Text"));
            cgTerminalTipboxDescription.text = "Cet terminal est utilisé pour la personalisation du Cybergrind.";

            //Main menu
            GameObject cgTerminalMainMenu = getGameObjectChild(cgTerminal, "Main Menu");

            Text cgTerminalThemesText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalMainMenu, "ThemeButton"), "Text"));
            cgTerminalThemesText.text = "THÈMES";

            Text cgTerminalPatternsText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalMainMenu, "PatternsButton"), "Text"));
            cgTerminalPatternsText.text = "SCHÈMAS";

            Text cgTerminalWaveText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalMainMenu, "WavesButton"), "Text"));
            cgTerminalWaveText.text = "VAGUES";

            //Themes

            GameObject cgTerminalThemes = getGameObjectChild(getGameObjectChild(cgTerminal, "Themes"),"Panel");

            Text cgTerminalThemesTitle = getTextfromGameObject(getGameObjectChild(cgTerminalThemes, "Title"));
            cgTerminalThemesTitle.text = "--THÈMES--";

            Text cgTerminalThemesDescription = getTextfromGameObject(getGameObjectChild(cgTerminalThemes, "Text"));
            cgTerminalThemesDescription.text = "Sélectionnez le thème visuel pour l'arène";

            Text cgTerminalThemesLight = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalThemes, "LightButton"), "Text"));
            cgTerminalThemesLight.text = "CLAIR";

            Text cgTerminalThemesDark = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalThemes, "DarkButton"), "Text"));
            cgTerminalThemesDark.text = "SOMBRE";

            Text cgTerminalThemesCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalThemes, "CustomButton"), "Text"));
            cgTerminalThemesCustom.text = "PERSONNALISÉ";

            //Customize theme
            GameObject cgCustomTheme = getGameObjectChild(getGameObjectChild(cgTerminal, "Custom"),"Panel");
            Console.WriteLine("cgCustomThemeTitle");
            Text cgCustomThemeTitle = getTextfromGameObject(getGameObjectChild(cgCustomTheme, "Title"));
            cgCustomThemeTitle.text = "MODIFIER";

            

            Text cgCustomGrid = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgCustomTheme, "ModeButtonWrapper"),"BlockTopButton"),"Text"));
            cgCustomGrid.text = "GRILLE";

            Text cgCustomGridGlow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgCustomTheme, "ModeButtonWrapper"), "BlockTopButton (3)"), "Text"));
            cgCustomGridGlow.text = "BRILLEMENT DU GRILLE";

            Text cgCustomSkybox = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgCustomTheme, "ModeButtonWrapper"), "BlockTopButton (2)"), "Text"));
            cgCustomSkybox.text = "CIEL";

            Text cgCustomThemeBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgCustomTheme, "BackButton"), "Text"));
            cgCustomThemeBack.text = "RETOUR";

            //a
            Text cgCustomRefresh = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgCustomTheme, "ImageSelectorWrapper"),"RefreshButton"),"Text"));
            cgCustomRefresh.text = "RECHARGER";

            GameObject cgCustomAdditionalRows = getGameObjectChild(getGameObjectChild(cgCustomTheme, "AdditionalOptions"),"GridTypeSelection");
            Text cgCustomAdditionalBase = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgCustomAdditionalRows, "BaseButton"), "Text"));
            cgCustomAdditionalBase.text = "BASE";

            Text cgCustomAdditionalTopRow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgCustomAdditionalRows, "TopRowButton"), "Text"));
            cgCustomAdditionalTopRow.text = "LIGNE HAUT";

            Text cgCustomAdditionalTop = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgCustomAdditionalRows, "TopButton"), "Text"));
            cgCustomAdditionalTop.text = "HAUT";

            Text cgCustomAdditionalGlowIntensity = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgCustomTheme, "AdditionalOptions"), "GlowOptions"),"Title"));
            cgCustomAdditionalGlowIntensity.text = "INTENSITÉ";
            
            //Patterns
            GameObject cgTerminalPatterns = getGameObjectChild(getGameObjectChild(cgTerminal, "Patterns"), "Panel");


            Text cgCustomStateButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgTerminalPatterns, "StateButton"), "Text"));
            bool customPatternMode = MonoSingleton<EndlessGrid>.Instance.customPatternMode;
            cgCustomStateButton.text = (customPatternMode ? "ACTIVÉE" : "DÉSACTIVÉE");

            Text cgTerminalPatternsTitle = getTextfromGameObject(getGameObjectChild(cgTerminalPatterns, "Title"));
            cgTerminalPatternsTitle.text = "--SCHÈMAS--";

            //Note - Will need to patch Toggle() in CustomPatterns for the "enabled"/"disabled" button.

            Text cgTerminalPatternsRefresh = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgTerminalPatterns, "CustomStuff"), "RefreshButton"),"Text"));
            cgTerminalPatternsRefresh.text = "ACTUALISER";
            cgTerminalPatternsRefresh.fontSize = 14;

            Text cgTerminalPatternsEditor = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(cgTerminalPatterns, "CustomStuff"), "EditorButton"), "Text"));
            cgTerminalPatternsEditor.text = "ÉDITEUR";

            //Waves

            GameObject cgTerminalWaves = getGameObjectChild(getGameObjectChild(cgTerminal, "Waves"), "Panel");

            Text cgTerminalWavesTitle = getTextfromGameObject(getGameObjectChild(cgTerminalWaves, "Title"));
            cgTerminalWavesTitle.text = "--VAGUES--";

            Text cgTerminalWavesText = getTextfromGameObject(getGameObjectChild(cgTerminalWaves, "Text"));
            cgTerminalWavesText.text =
                "SÈLECTIONNEZ LA VAGUE DE DÉPART:\n\n" +
                "(Meilleur score doit être au moins double du vague de départ)";
            cgTerminalWavesText.fontSize = 16;
        }
        public CyberGrind(ref GameObject level)
        {
            var cgLogger = BepInEx.Logging.Logger.CreateLogSource("CGPatcher");
            cgLogger.LogInfo("Now entering CyberGrind class.");
            this.patchWaveBoard();
            this.patchResults(level);
            this.patchTerminal(level);
        }

        public GameObject getGameObjectChild(GameObject parentObject, string childToFind)
        {
            GameObject childToReturn = parentObject.transform.Find(childToFind).gameObject;
            return childToReturn;
        }

        public Text getTextfromGameObject(GameObject objectToUse)
        {
            return objectToUse.GetComponent<Text>();
        }


    }
}
