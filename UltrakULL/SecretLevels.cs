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
    class SecretLevels
    {
        string currentLevel;

        public void patchTestament(ref GameObject testamentRoom)
        {
            Text testamentPanelText = null;
            Text testamentPanelTitle = null;


            //0-S
            if (SceneManager.GetActiveScene().name == "Level 0-S")
            {
                GameObject finalRoom = GameObject.Find("FinalRoom 2");
                testamentPanelText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(finalRoom, "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Text"));

                testamentPanelTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(finalRoom, "Room"),"Testament Shop"), "Canvas"),"Text"));
                testamentPanelTitle.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testamentTitle;
            }
            //1-S
            else if (SceneManager.GetActiveScene().name == "Level 1-S")
            {
                GameObject finalRoom = GameObject.Find("5 - Finale");
                testamentPanelText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(finalRoom, "FinalRoom 2 (1)"),"Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Text"));
                testamentPanelTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(finalRoom, "FinalRoom 2 (1)"),"Room"), "Testament Shop"), "Canvas"), "Text"));
                testamentPanelTitle.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testamentTitle;
            }
            //4-S
            else if (SceneManager.GetActiveScene().name == "Level 4-S")
            {
                testamentPanelText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(testamentRoom, "4 Stuff"), "FinalRoom 2"), "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"),"Panel"),"Text"));
                testamentPanelTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(testamentRoom, "4 Stuff"), "FinalRoom 2"), "Room"), "Testament Shop"),"Canvas"),"Text"));
                testamentPanelTitle.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testamentTitle;

            }

            

            switch (this.currentLevel)
                {
                case "Level 0-S":
                    {
                        testamentPanelText.text =
                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testament1 + "\n\n" + LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testament2 + "\n\n" + LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testament3 + "\n\n" +
                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testament4;

                        break;
                    }
                case "Level 1-S":
                    {
                        testamentPanelText.text =

                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testament1 + "\n\n" + LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testament2 + "\n\n" + LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testament3 + "\n\n" +
                            LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testament4;

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

                        break;
                    }
                default: { break; }
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
                case "Level 0-S": {testamentRoom = GameObject.Find("FinalRoom 2"); patchTestament(ref testamentRoom); break; }
                case "Level 1-S": {testamentRoom = GameObject.Find("5 - Finale"); patchTestament(ref testamentRoom); break; }
                case "Level 2-S": {Act1VN.patchPrompts(ref coreGame); break; }
                case "Level 4-S": {
                        //I have absolutely no idea why I have to do it like this but I have to, for some reason the required GameObject can't be found by searching.
                        //THIS HAPPENS BECAUSE THE GAMEOBJECT ISN'T ACTIVE ON SCENE LOAD AND GameObject.Find() CANNOT DETECT INACTIVE OBJECTS.
                        testamentRoom = getInactiveRootObject("4 - Boulder Run");

                        patchTestament(ref testamentRoom);
                        break;
                    }

                default: { break; }
            }
            GameObject secretLevelResults = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(GameObject.Find("Player"), "Main Camera"), "HUD Camera"), "HUD"), "FinishCanvas");

            List<GameObject> FinishCanvasChildren = new List<GameObject>();
            foreach (Transform child in secretLevelResults.transform)
            {
                FinishCanvasChildren.Add(child.gameObject);
            }
            GameObject secretLevelResultsPanel = FinishCanvasChildren[1];

            Text secretLevelResultsName = getTextfromGameObject(getGameObjectChild(getGameObjectChild(secretLevelResultsPanel, "Title"), "Text"));
            secretLevelResultsName.text = getSecretLevelName();

            Text secretLevelResultsInfo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(secretLevelResultsPanel, "Time - Info"), "Text"));
            secretLevelResultsInfo.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_complete1;

            Text secretLevelComplete = getTextfromGameObject(getGameObjectChild(getGameObjectChild(secretLevelResultsPanel, "Time - Rank"), "Text"));
            secretLevelComplete.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_complete2;

        }

        public string getSecretLevelName()
        {
            switch(this.currentLevel)
            {
                case ("Level 0-S"): { return "0-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_preludeSecret; }
                case ("Level 1-S"): { return "1-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_limboSecret; }
                case ("Level 2-S"): { return "2-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_lustSecret; }
                case ("Level 4-S"): { return "4-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_greedSecret; ; }
                default: { return "UNKNOWN"; }
            }
        }

    }
}
