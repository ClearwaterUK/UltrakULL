using System.Collections.Generic;
using Antlr4.StringTemplate;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    class SecretLevels
    {
        private const string PreludeTestament = "TESTAMENT_PRELUDE";
        private const string LimboTestament = "TESTAMENT_LIMBO";
        private const string GreedTestament = "TESTAMENT_GREED";
        private const string WrathTestament = "TESTAMENT_WRATH";

        private TemplateGroup templates = new TemplateGroupString(Resources.Testaments);
        private Secret secret = LanguageManager.CurrentLanguage.secretLevels;
        private string currentLevel;

        private void PatchTestament()
        {
            templates.EnableCache = false;
            Text testamentPanelTitle;
            Text testamentPanelText = null;
            var testamentTemplate = string.Empty;

            switch (GetCurrentSceneName())
            {
                case "Level 0-S":
                {
                    var testamentPanel = GetObject("FinalRoom 2/Room/Testament Shop/Canvas/Border/TipBox/Panel");
                    testamentPanelTitle = testamentPanel.transform.Find("Title").GetComponent<Text>();
                    testamentPanelText = testamentPanel.transform.Find("Text").GetComponent<Text>();
                    testamentPanelTitle.text = secret.secretLevels_prelude_testamentTitle;
                    testamentTemplate = PreludeTestament;
                    break;
                }
                case "Level 1-S":
                {
                    var testamentPanel = GetObject("5 - Finale/FinalRoom 2 (1)/Room/Testament Shop/Canvas/Border/TipBox/Panel");
                    testamentPanelTitle = testamentPanel.transform.Find("Title").GetComponent<Text>();
                    testamentPanelText = testamentPanel.transform.Find("Text").GetComponent<Text>();
                    testamentPanelTitle.text = secret.secretLevels_first_testamentTitle;
                    testamentTemplate = LimboTestament;
                    break;
                }
                case "Level 4-S":
                {
                    var testamentPanel =
                        GetObject("4 - Boulder Run/4 Stuff/FinalRoom 2/Room/Testament Shop/Canvas/Border/TipBox/Panel");
                    testamentPanelTitle = testamentPanel.transform.Find("Title").GetComponent<Text>();
                    testamentPanelText = testamentPanel.transform.Find("Text").GetComponent<Text>();
                    testamentPanelTitle.text = secret.secretLevels_fourth_testamentTitle;
                    testamentTemplate = GreedTestament;
                    break;
                }
                case "Level 5-S": 
                {
                    var testamentPanel = GetObject("FinalRoom 2/Room/Testament Shop/Canvas/Border/TipBox/Panel");
                    testamentPanelTitle = testamentPanel.transform.Find("Title").GetComponent<Text>();
                    testamentPanelText = testamentPanel.transform.Find("Text").GetComponent<Text>();
                    testamentPanelTitle.text = secret.secretLevels_fifth_testamentTitle;
                    testamentTemplate = WrathTestament;
                    break;
                }
            }

            if (testamentPanelText != null)
                testamentPanelText.text = templates
                    .GetInstanceOf(testamentTemplate)
                    .Add("secret", secret)
                    .Render();
        }

        private static void Patch5S()
        {
            var powerGauge = GetGameObjectChild(GetInactiveRootObject("FishingCanvas"),"Power Meter");
            var distanceFar = GetTextfromGameObject(GetGameObjectChild(powerGauge,"Text"));
            distanceFar.text = LanguageManager.CurrentLanguage.fishing.fish_rodFar;
            var distanceClose = GetTextfromGameObject(GetGameObjectChild(powerGauge,"Text (1)"));
            distanceClose.text = LanguageManager.CurrentLanguage.fishing.fish_rodClose;
            
            var fishingLeaderboard = GetObject("Exit Lobby Interior/Fish Scores/Canvas/Border/TipBox/Panel");
            
            var fishingLeaderboardTitle = GetTextfromGameObject(GetGameObjectChild(fishingLeaderboard,"Title"));
            fishingLeaderboardTitle.text = LanguageManager.CurrentLanguage.fishing.fish_leaderboard;
            
            var fishingTerminal = GetObject("Fishing Enc Terminal/Canvas/Border/TipBox/Panel");
            
            var fishingTerminalTitle = GetTextfromGameObject(GetGameObjectChild(fishingTerminal,"Title"));
            fishingTerminalTitle.text = LanguageManager.CurrentLanguage.fishing.fish_terminalTitle;
        }
        
        // SecretFirstRoom/Player/Main Camera/HUD Camera/HUD/FinishCanvas/Panel/Title/Text
        // Note - it uses a separate panel that has the same name as the normal result panel.
        public SecretLevels(ref GameObject canvasObj)
        {
            var player = GameObject.Find("Player");
            currentLevel = GetCurrentSceneName();
            GameObject testamentRoom;

            PatchTestament();
            switch (currentLevel)
            {
                case "Level 2-S":
                {
                    Act1Vn.PatchPrompts(ref canvasObj); break;
                }
                case "Level 5-S":
                {
                    Patch5S(); break;
                }
            }
            var secretLevelResults = player.transform.Find("Main Camera/HUD Camera/HUD/FinishCanvas");

            var finishCanvasChildren = new List<GameObject>();
            foreach (Transform child in secretLevelResults.transform)
            {
                finishCanvasChildren.Add(child.gameObject);
            }
            var secretLevelResultsPanel = finishCanvasChildren[1];

            var secretLevelResultsName = secretLevelResultsPanel.transform.Find("Title/Text").GetComponent<Text>();
            secretLevelResultsName.text = GetSecretLevelName();

            var secretLevelResultsInfo = secretLevelResultsPanel.transform.Find("Time - Info/Text").GetComponent<Text>();
            secretLevelResultsInfo.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_complete1;

            var secretLevelComplete = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(secretLevelResultsPanel, "Time - Rank"), "Text"));
            secretLevelComplete.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_complete2;

        }

        private string GetSecretLevelName()
        {
            switch(currentLevel)
            {
                case ("Level 0-S"): { return "0-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_preludeSecret; }
                case ("Level 1-S"): { return "1-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_limboSecret; }
                case ("Level 2-S"): { return "2-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_lustSecret; }
                case ("Level 4-S"): { return "4-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_greedSecret;}
                case ("Level 5-S"): { return "5-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_wrathSecret;}
                default: { return "UNKNOWN"; }
            }
        }

    }
}
