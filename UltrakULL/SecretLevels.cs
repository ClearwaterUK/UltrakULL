using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    class SecretLevels
    {
        private string currentLevel;

        private void PatchTestament(ref GameObject testamentRoom)
        {
            Text testamentPanelText = null;
            Text testamentPanelTitle = null;

            //0-S
            if (SceneManager.GetActiveScene().name == "Level 0-S")
            {
                GameObject finalRoom = GameObject.Find("FinalRoom 2");
                
                
                testamentPanelTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(finalRoom, "Room"),"Testament Shop"), "Canvas"),"Border"),"TipBox"),"Panel"),"Title"));
                
                testamentPanelText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(finalRoom, "Room"),"Testament Shop"), "Canvas"),"Border"),"TipBox"),"Panel"),"Text"));

                testamentPanelTitle.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testamentTitle;
            }
            //1-S
            else if (SceneManager.GetActiveScene().name == "Level 1-S")
            {
                GameObject finalRoom = GameObject.Find("5 - Finale");
                
                
                testamentPanelTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(finalRoom, "FinalRoom 2 (1)"),"Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Title"));
                
                testamentPanelText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(finalRoom, "FinalRoom 2 (1)"),"Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Text"));

                testamentPanelTitle.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testamentTitle;
                
            }
            //4-S
            else if (SceneManager.GetActiveScene().name == "Level 4-S")
            {
                testamentPanelTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(testamentRoom, "4 Stuff"), "FinalRoom 2"), "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"),"Panel"),"Title"));
            
                testamentPanelText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(testamentRoom, "4 Stuff"), "FinalRoom 2"), "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"),"Panel"),"Text"));


            }

            switch (this.currentLevel)
                {
                case "Level 0-S":
                    {
                        testamentPanelText.text =
                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testament1 + "\n\n" + LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testament2 + "\n\n" + LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testament3 + "\n\n" +
                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testament4;
                            
                        testamentPanelTitle.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testamentTitle;

                        break;
                    }
                case "Level 1-S":
                    {
                        testamentPanelText.text =

                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testament1 + "\n\n" + LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testament2 + "\n\n" + LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testament3 + "\n\n" +
                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testament4;

                        testamentPanelTitle.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testamentTitle;
                        break;
                    }
                
                case "Level 4-S":
                    {
                        testamentPanelText.text =

                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament1 + "\n" +
                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament2 + "\n\n" +

                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament3 + "\n" +
                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament4 + "\n" +
                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament5 + "\n\n" +

                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament6 + "\n" +
                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament7;
                            
                        testamentPanelTitle.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testamentTitle;
                        break;
                    }
                }
        }
        // SecretFirstRoom/Player/Main Camera/HUD Camera/HUD/FinishCanvas/Panel/Title/Text
        // Note - it uses a seperate panel that has the same name as the normal result panel.
        public SecretLevels(ref GameObject coreGame)
        {
            coreGame = GameObject.Find("Player");
            this.currentLevel = SceneManager.GetActiveScene().name;
            GameObject testamentRoom = null;

            switch (this.currentLevel)
            {
                case "Level 0-S": {testamentRoom = GameObject.Find("FinalRoom 2"); PatchTestament(ref testamentRoom); break; }
                case "Level 1-S": {testamentRoom = GameObject.Find("5 - Finale"); PatchTestament(ref testamentRoom); break; }
                case "Level 2-S": {Act1Vn.PatchPrompts(ref coreGame); break; }
                case "Level 4-S": {testamentRoom = GetInactiveRootObject("4 - Boulder Run");PatchTestament(ref testamentRoom); break; }
            }
            GameObject secretLevelResults = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GameObject.Find("Player"), "Main Camera"), "HUD Camera"), "HUD"), "FinishCanvas");

            List<GameObject> finishCanvasChildren = new List<GameObject>();
            foreach (Transform child in secretLevelResults.transform)
            {
                finishCanvasChildren.Add(child.gameObject);
            }
            GameObject secretLevelResultsPanel = finishCanvasChildren[1];

            Text secretLevelResultsName = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(secretLevelResultsPanel, "Title"), "Text"));
            secretLevelResultsName.text = GetSecretLevelName();

            Text secretLevelResultsInfo = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(secretLevelResultsPanel, "Time - Info"), "Text"));
            secretLevelResultsInfo.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_complete1;

            Text secretLevelComplete = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(secretLevelResultsPanel, "Time - Rank"), "Text"));
            secretLevelComplete.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_complete2;

        }

        public string GetSecretLevelName()
        {
            switch(this.currentLevel)
            {
                case ("Level 0-S"): { return "0-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_preludeSecret; }
                case ("Level 1-S"): { return "1-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_limboSecret; }
                case ("Level 2-S"): { return "2-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_lustSecret; }
                case ("Level 4-S"): { return "4-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_greedSecret;}
                default: { return "UNKNOWN"; }
            }
        }

    }
}
