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

        public void patchTestament(ref GameObject testamentRoom, JsonParser language)
        {
            Text testamentPanelText = null;


            //0-S
            if (SceneManager.GetActiveScene().name == "Level 0-S")
            {
                GameObject finalRoom = GameObject.Find("FinalRoom 2");
                testamentPanelText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(finalRoom, "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Text"));
            }
            //1-S
            else if (SceneManager.GetActiveScene().name == "Level 1-S")
            {
                GameObject finalRoom = GameObject.Find("5 - Finale");
                testamentPanelText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(finalRoom, "FinalRoom 2 (1)"),"Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Text"));
            }
            //4-S
            else if (SceneManager.GetActiveScene().name == "Level 4-S")
            {
                testamentPanelText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(testamentRoom, "4 Stuff"), "FinalRoom 2"), "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"),"Panel"),"Text"));

            }

            switch (this.currentLevel)
                {
                case "Level 0-S":
                    {
                        testamentPanelText.text =
                            language.currentLanguage.secretLevels.secretLevels_prelude_testament1 + "\n\n" + language.currentLanguage.secretLevels.secretLevels_prelude_testament2 + "\n\n" + language.currentLanguage.secretLevels.secretLevels_prelude_testament3 + "\n\n" +
                            language.currentLanguage.secretLevels.secretLevels_prelude_testament4;

                        break;
                    }
                case "Level 1-S":
                    {
                        testamentPanelText.text =

                            language.currentLanguage.secretLevels.secretLevels_first_testament1 + "\n\n" + language.currentLanguage.secretLevels.secretLevels_first_testament2 + "\n\n" + language.currentLanguage.secretLevels.secretLevels_first_testament3 + "\n\n" +
                            language.currentLanguage.secretLevels.secretLevels_first_testament4;

                        break;
                    }


                case "Level 4-S":
                    {
                        testamentPanelText.text =

                            language.currentLanguage.secretLevels.secretLevels_fourth_testament1 + "\n" +
                            language.currentLanguage.secretLevels.secretLevels_fourth_testament2 + "\n\n" +

                            language.currentLanguage.secretLevels.secretLevels_fourth_testament3 + "\n" +
                            language.currentLanguage.secretLevels.secretLevels_fourth_testament4 + "\n" +
                            language.currentLanguage.secretLevels.secretLevels_fourth_testament5 + "\n\n" +

                            language.currentLanguage.secretLevels.secretLevels_fourth_testament6 + "\n" +
                            language.currentLanguage.secretLevels.secretLevels_fourth_testament7;

                        break;
                    }
                default: { break; }
            }

        }



        // SecretFirstRoom/Player/Main Camera/HUD Camera/HUD/FinishCanvas/Panel/Title/Text
        // Note - it uses a seperate panel that has the same name as the normal result panel.
        public SecretLevels(ref GameObject coreGame, JsonParser language)
        {
            Console.WriteLine("In secretLevels");
            coreGame = GameObject.Find("Player");
            this.currentLevel = SceneManager.GetActiveScene().name;
            GameObject testamentRoom = null;

            switch (this.currentLevel)
            {
                case "Level 0-S": { Console.WriteLine("Setting 0-S room object"); testamentRoom = GameObject.Find("FinalRoom 2"); patchTestament(ref testamentRoom, language); break; }
                case "Level 1-S": { Console.WriteLine("Setting 1-s room object"); testamentRoom = GameObject.Find("5 - Finale"); patchTestament(ref testamentRoom, language); break; }
                case "Level 2-S": { Console.WriteLine("2-S visual novel"); Act1VN.patchPrompts(ref coreGame); break; }
                case "Level 4-S": {
                        //I have absolutely no idea why I have to do it like this but I have to, for some reason the required GameObject can't be found by searching.
                        //THIS HAPPENS BECAUSE THE GAMEOBJECT ISN'T ACTIVE ON SCENE LOAD AND GameObject.Find() CANNOT DETECT INACTIVE OBJECTS.
                        List<GameObject> rootObjects = new List<GameObject>();
                        SceneManager.GetActiveScene().GetRootGameObjects(rootObjects);
                        foreach(GameObject a in rootObjects)
                        {
                            if(a.name == "4 - Boulder Run")
                            {
                                Console.WriteLine("Object found, setting");
                                testamentRoom = a;
                            }
                        }
                        patchTestament(ref testamentRoom, language);
                        break;
                    }

                default: { break; }
            }

            Console.WriteLine("Getting secret level end results");
            GameObject secretLevelResults = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(GameObject.Find("Player"), "Main Camera"), "HUD Camera"), "HUD"), "FinishCanvas");

            List<GameObject> FinishCanvasChildren = new List<GameObject>();
            foreach (Transform child in secretLevelResults.transform)
            {
                FinishCanvasChildren.Add(child.gameObject);
            }
            GameObject secretLevelResultsPanel = FinishCanvasChildren[1];

            Text secretLevelResultsName = getTextfromGameObject(getGameObjectChild(getGameObjectChild(secretLevelResultsPanel, "Title"), "Text"));
            secretLevelResultsName.text = getSecretLevelName(language);

            Text secretLevelResultsInfo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(secretLevelResultsPanel, "Time - Info"), "Text"));
            secretLevelResultsInfo.text = language.currentLanguage.secretLevels.secretLevels_complete1;

            Text secretLevelComplete = getTextfromGameObject(getGameObjectChild(getGameObjectChild(secretLevelResultsPanel, "Time - Rank"), "Text"));
            secretLevelComplete.text = language.currentLanguage.secretLevels.secretLevels_complete2;

            Console.WriteLine("secretLevels finished");
        }

        public string getSecretLevelName(JsonParser language)
        {
            switch(this.currentLevel)
            {
                case ("Level 0-S"): { return "0-S:" + language.currentLanguage.levelNames.levelName_preludeSecret; }
                case ("Level 1-S"): { return "1-S:" + language.currentLanguage.levelNames.levelName_limboSecret; }
                case ("Level 2-S"): { return "2-S:" + language.currentLanguage.levelNames.levelName_lustSecret; }
                case ("Level 4-S"): { return "4-S:" + language.currentLanguage.levelNames.levelName_greedSecret; ; }
                default: { return "UNKNOWN"; }
            }
        }

    }
}
