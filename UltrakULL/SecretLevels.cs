using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;
using System.Linq.Expressions;
using System;

namespace UltrakULL
{
    class SecretLevels
    {
        private string currentLevel;

        private void PatchTestament(ref GameObject testamentRoom)
        {
            TextMeshProUGUI testamentPanelText = null;
            TextMeshProUGUI testamentPanelTitle = null;

            //0-S
            if (GetCurrentSceneName() == "Level 0-S")
            {
                GameObject finalRoom = GameObject.Find("FinalRoom 2");


                testamentPanelTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(finalRoom, "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Title"));

                testamentPanelText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(finalRoom, "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Text"));

                testamentPanelTitle.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testamentTitle;
            }
            //1-S
            else if (GetCurrentSceneName() == "Level 1-S")
            {
                GameObject finalRoom = GameObject.Find("5 - Finale");


                testamentPanelTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(finalRoom, "FinalRoom 2 (1)"), "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Title"));

                testamentPanelText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(finalRoom, "FinalRoom 2 (1)"), "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Text"));

                testamentPanelTitle.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testamentTitle;

            }
            //4-S
            else if (GetCurrentSceneName() == "Level 4-S")
            {
                testamentPanelTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(testamentRoom, "4 Stuff"), "FinalRoom 2"), "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Title"));

                testamentPanelText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(testamentRoom, "4 Stuff"), "FinalRoom 2"), "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Text"));


            }
            //5-S   
            else if (GetCurrentSceneName() == "Level 5-S")
            {
                GameObject finalRoom = GameObject.Find("FinalRoom 2");

                testamentPanelTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(finalRoom, "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Title"));

                testamentPanelText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(finalRoom, "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Text"));

            }
            else if (GetCurrentSceneName() == "Level 7-S")
            {
                GameObject finalRoom = GameObject.Find("RealExit");

                testamentPanelTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(finalRoom, "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Title"));

                testamentPanelText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(finalRoom, "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Text"));

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
                case "Level 5-S":
                    {
                        testamentPanelText.text =
                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament1 + "\n" +
                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament2 + "\n\n" +

                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament3 + "\n" +
                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament4 + "\n" +
                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament5 + "\n" +
                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament6 + "\n" +

                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament7 + "\n" +
                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament8 + "\n\n" +

                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament9 + "\n" +
                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament10 + "\n" +
                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament11 + "\n" +
                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament12;

                        testamentPanelTitle.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testamentTitle;

                        break;
                    }
                case "Level 7-S":
                    {
                        testamentPanelText.text =
                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament1 + "\n\n" +

                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament2 + "\n" +
                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament3 + "\n\n" +

                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament4 + "\n" +
                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament5 + "\n\n" +

                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament6 + "\n\n" +

                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament7 + "\n\n" +

                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament8 + "\n\n" +

                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament9 + "\n" +
                                LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament10;
                        testamentPanelTitle.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testamentTitle;
                        break;
                    }
            }
        }

        public void Patch5S(ref GameObject canvasObj)
        {
            GameObject powerGauge = GetGameObjectChild(GetInactiveRootObject("FishingCanvas"), "Power Meter");
            Text distanceFar = GetTextfromGameObject(GetGameObjectChild(powerGauge, "Text"));
            distanceFar.text = LanguageManager.CurrentLanguage.fishing.fish_rodFar;
            Text distanceClose = GetTextfromGameObject(GetGameObjectChild(powerGauge, "Text (1)"));
            distanceClose.text = LanguageManager.CurrentLanguage.fishing.fish_rodClose;

            GameObject fishingLeaderboard = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Exit Lobby Interior"), "Fish Scores"), "Canvas"), "Border"), "TipBox"), "Panel");

            TextMeshProUGUI fishingLeaderboardTitle = GetTextMeshProUGUI(GetGameObjectChild(fishingLeaderboard, "Title"));
            fishingLeaderboardTitle.text = LanguageManager.CurrentLanguage.fishing.fish_leaderboard;

            GameObject fishingTerminal = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Fishing Enc Terminal"), "Canvas"), "Border"), "TipBox"), "Panel");

            TextMeshProUGUI fishingTerminalTitle = GetTextMeshProUGUI(GetGameObjectChild(fishingTerminal, "Title"));
            fishingTerminalTitle.text = LanguageManager.CurrentLanguage.fishing.fish_terminalTitle;
        }
        public void Patch7S(ref GameObject canvasObj)
        {
            //CLEAN UP YOUR MESS!
            GameObject puzzleScreen = GameObject.Find("PuzzleScreen");
            TextMeshProUGUI fakeexittext = puzzleScreen.GetComponentInChildren<TextMeshProUGUI>(true);
            fakeexittext.text = "<size=12><color=red><u><b>" + LanguageManager.CurrentLanguage.washing.wash_fakeexittext1 + "</u></b></color></size>\n\n\n"
            + LanguageManager.CurrentLanguage.washing.wash_fakeexittext2 + "\n\n"
            + LanguageManager.CurrentLanguage.washing.wash_fakeexittext3 + "\n\n"
            + LanguageManager.CurrentLanguage.washing.wash_fakeexittext4 + "\n\n"
            + LanguageManager.CurrentLanguage.washing.wash_fakeexittext5 + "\n\n"
            + LanguageManager.CurrentLanguage.washing.wash_fakeexittext6;

            //BloodCleanText
            GameObject washcanvas = GameObject.Find("WashingCanvas");
            TextMeshProUGUI BloodCleanText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(washcanvas, "Painter Completion Meter"), "Slider Group"), "Blood Cleaned"));
            BloodCleanText.text = LanguageManager.CurrentLanguage.washing.wash_bloodClean;
            GameObject chklst = GetGameObjectChild(washcanvas, "CheckList");
            Transform[] painterTransforms = chklst.GetComponentsInChildren<Transform>(true);
            List<GameObject> painterObjects = new List<GameObject>();
            foreach (Transform childTransform in painterTransforms)
            {
                painterObjects.Add(childTransform.gameObject);
            }
            foreach (GameObject painterObject in painterObjects)
            {
                TextMeshProUGUI painterText = painterObject.GetComponentInChildren<TextMeshProUGUI>(true);
                if(painterText != null)
                {
                    switch (painterText.text)
                    {
                        case "Dumpster":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_Dumpster;
                                break;
                            }
                        case "Ground":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_Ground;
                                break;
                            }
                        case "Pillars":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_Pillars;
                                break;
                            }
                        case "Walls":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_Walls;
                                break;
                            }
                        case "Back Bookshelf":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_BackBookshelf;
                                break;
                            }
                        case "Bookshelf":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_Bookshelf;
                                break;
                            }
                        case "Bookcases":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_Bookcases;
                                break;
                            }
                        case "Ceiling":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_Ceiling;
                                break;
                            }
                        case "Desks":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_Desk;
                                break;
                            }
                        case "Front Bookshelf":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_FrontBookshelf;
                                break;
                            }
                        case "Sconces":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_Sconces;
                                break;
                            }
                        case "Side Wall":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_Sidewall;
                                break;
                            }
                        case "Walkway":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_Walkway;
                                break;
                            }
                        case "Window Wall":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_WindowWall;
                                break;
                            }
                        case "Decor":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_Decor;
                                break;
                            }
                        case "Floors":
                            {
                                painterText.text = LanguageManager.CurrentLanguage.washing.wash_Floors;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        
        
        


            /*TextMeshProUGUI Clean = GetTextMeshProUGUI(GetGameObjectChild(chklst, "CLEAN"));
            Clean.text = LanguageManager.CurrentLanguage.washing.wash_Clean;
            TextMeshProUGUI Todo = GetTextMeshProUGUI(GetGameObjectChild(chklst, "ToDo"));
            Todo.text = LanguageManager.CurrentLanguage.washing.wash_ToDo;
            TextMeshProUGUI LitterCount = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Litter"), "Litter Count:"));
            LitterCount.text = LanguageManager.CurrentLanguage.washing.wash_littercount;

            TextMeshProUGUI Dumpster = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Dumpster"), "Painter Name"));
            Dumpster.text = LanguageManager.CurrentLanguage.washing.wash_Dumpster;
            TextMeshProUGUI Ground = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Ground"), "Painter Name"));
            Ground.text = LanguageManager.CurrentLanguage.washing.wash_Ground;
            TextMeshProUGUI Pillars = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Pillars"), "Painter Name"));
            Pillars.text = LanguageManager.CurrentLanguage.washing.wash_Pillars;
            TextMeshProUGUI Walls = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Walls"), "Painter Name"));
            Walls.text = LanguageManager.CurrentLanguage.washing.wash_Walls;
            TextMeshProUGUI Back_Bookshelf = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Back Bookshelf"), "Painter Name"));
            Back_Bookshelf.text = LanguageManager.CurrentLanguage.washing.wash_BackBookshelf;
            TextMeshProUGUI Bookcases = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Bookcases"), "Painter Name"));
            Bookcases.text = LanguageManager.CurrentLanguage.washing.wash_Bookcases;
            TextMeshProUGUI Desks = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Desks"), "Painter Name"));
            Desks.text = LanguageManager.CurrentLanguage.washing.wash_Desk;
            TextMeshProUGUI Front_Bookshelf = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Front Bookshelf"), "Painter Name"));
            Front_Bookshelf.text = LanguageManager.CurrentLanguage.washing.wash_FrontBookshelf;
            TextMeshProUGUI Sconces = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Sconces"), "Painter Name"));
            Sconces.text = LanguageManager.CurrentLanguage.washing.wash_Sconces;
            TextMeshProUGUI Sidewall = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Side Wall"), "Painter Name"));
            Sidewall.text = LanguageManager.CurrentLanguage.washing.wash_Sidewall;
            TextMeshProUGUI Walkway = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Walkway"), "Painter Name"));
            Walkway.text = LanguageManager.CurrentLanguage.washing.wash_Walkway;
            TextMeshProUGUI WindowWall = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Window Wall"), "Painter Name"));
            WindowWall.text = LanguageManager.CurrentLanguage.washing.wash_WindowWall;
            TextMeshProUGUI Decor = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Decor"), "Painter Name"));
            Decor.text = LanguageManager.CurrentLanguage.washing.wash_Decor;
            TextMeshProUGUI Floors = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Floors"), "Painter Name"));
            Floors.text = LanguageManager.CurrentLanguage.washing.wash_Floors;
            TextMeshProUGUI Pond = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(chklst, "Pond"), "Painter Name"));
            Pond.text = LanguageManager.CurrentLanguage.washing.wash_Pond;*/
        }
        // SecretFirstRoom/Player/Main Camera/HUD Camera/HUD/FinishCanvas/Panel/Title/Text
        // Note - it uses a separate panel that has the same name as the normal result panel.
        public SecretLevels(ref GameObject canvasObj)
        {
            GameObject player = GameObject.Find("Player");
            this.currentLevel = GetCurrentSceneName();
            GameObject testamentRoom;

            switch (this.currentLevel)
            {
                case "Level 0-S": {testamentRoom = GameObject.Find("FinalRoom 2"); PatchTestament(ref testamentRoom); break; }
                case "Level 1-S": {testamentRoom = GameObject.Find("5 - Finale"); PatchTestament(ref testamentRoom); break; }
                case "Level 2-S": {Act1Vn.PatchPrompts(ref canvasObj); break; }
                case "Level 4-S": {testamentRoom = GetInactiveRootObject("4 - Boulder Run");PatchTestament(ref testamentRoom); break; }
                case "Level 5-S": {testamentRoom = GetInactiveRootObject("FinalRoom 2");PatchTestament(ref testamentRoom); Patch5S(ref canvasObj); break; }
                case "Level 7-S": { testamentRoom = GetInactiveRootObject("RealExit");PatchTestament(ref testamentRoom); Patch7S(ref canvasObj); break; }  
            }
            GameObject secretLevelResults = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(player, "Main Camera"), "HUD Camera"), "HUD"), "FinishCanvas");

            List<GameObject> finishCanvasChildren = new List<GameObject>();
            foreach (Transform child in secretLevelResults.transform)
            {
                finishCanvasChildren.Add(child.gameObject);
            }
            GameObject secretLevelResultsPanel = finishCanvasChildren[1];

            TextMeshProUGUI secretLevelResultsName = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(secretLevelResultsPanel, "Title"), "Text"));
            secretLevelResultsName.text = GetSecretLevelName();

            TextMeshProUGUI secretLevelResultsInfo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(secretLevelResultsPanel, "Time - Info"), "Text"));
            secretLevelResultsInfo.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_complete1;

            TextMeshProUGUI secretLevelComplete = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(secretLevelResultsPanel, "Time - Rank"), "Text"));
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
                case ("Level 5-S"): { return "5-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_wrathSecret;}
                case ("Level 7-S"): { return "7-S:" + LanguageManager.CurrentLanguage.levelNames.levelName_violenceSecret; }
                default: { return "UNKNOWN"; }
            }
        }

    }
}
