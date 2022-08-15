using BepInEx;
using HarmonyLib;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UltrakULL;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using static UltrakULL.CommonFunctions;
using System.Linq;
using UltrakULL.json;


/*
 * 
 *	UltrakULL (Ultrakill Language Library)
 *	Written by Clearwater
 *	Date started: 21st April 2021
 *	Last updated: 31st July 2022
 *	
 *	This is a translation mod for Ultrakill that hooks into the game and allows for text/string replacement.
 *	This tool is primarily meant to assist with language translation.
 * 
 * 
 * 
 *  MAIN TODO LIST
 *  - Organise and refactor stuff, move functions to other files to declutter Main (Simplify getGameObjectChild and getTextFromgameObject in each file, take it from CommonFunctions) (Factorise the act classes with an interface?)
 *  - Fill the JSON template and class
 *  - Error and exception handling
 *  - Discord RPC (Persistant timestamp and general corrections)
 *  - Cheat teleport menu
 *  - Sandbox stuff (time of day shop, spawn/cheat menu categories)
 *  - Terminals before bosses in levels (could copy the shop that's in the start of each level)
 *  - Settings -> graphics -> custom palettes
 * 
 *  BUGS AND QUIRKS TO FIX:
 *  
 * -  MEMORY LEAK THAT OCCURS OVER TIME IF YOU HOP IN AND OUT OF LEVELS. SHALL NEED TO MONITOR.
 *  
 * - Reexamine the intro text. See if I can get input working again...
 * - Note - 2-S uses intermission style strings. Is there a way I can patch the text without having to patch the IntermissionController class?
 * - Add in missing style meter bonuses as they appear.
 * - Some of the enemy bios as the INSURRECTIONIST and VIRTUE were updated, will need to retranslate and update on this end.
 * - 2-S: See if I can rename Mirage's names.
 * - Bosses spawned with the spawner arm outside of their normal level have unimplemented string messages
 * - Discord RPC: Style meter in CG
 * - Part of the first page on the intro has changed (from green to blue). Check the new text
 * - Size/color tag isn't working on the prime testament
 * 
 * OTHER NOTES:
 * Whiplash is getting a hard damage nerf in Act 2 update. 4-4 Whiplash message will be updated accordingly.
 * Change of style meter mechanic.
 * 
 * */

namespace UltrakULL
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    [BepInProcess("ULTRAKILL.exe")]

    public class MainPatch : BaseUnityPlugin
    {
        public const string pluginGuid = "clearwater.ultrakill.ultrakULL";
        public const string pluginName = "UltrakULL - Ultrakill Language Library";
        public const string pluginVersion = "0.7.0";

        private JsonParser jsonParser;
        private PatchedFunctions patchedFuncs;

        private bool ready = false;

        public MainPatch()
        {

        }

        //Patches all text strings in the pause menu.
        public void patchPauseMenu(ref GameObject level)
        {
            try
            {
                List<GameObject> rootObjects = new List<GameObject>();
                SceneManager.GetActiveScene().GetRootGameObjects(rootObjects);

                GameObject pauseObject = null;
                foreach (GameObject a in rootObjects)
                {
                    if (a.gameObject.name == "Canvas")
                    {
                        pauseObject = a.gameObject;
                        break;
                    }

                }

                GameObject pauseMenu = getGameObjectChild(pauseObject, "PauseMenu");

                //Title

                Console.WriteLine("title");
                Text pauseText = getTextfromGameObject(getGameObjectChild(pauseMenu, "Text"));
                pauseText.text = "-- " + this.jsonParser.currentLanguage.pauseMenu.pause_title + " --";

                //Resume
                Console.WriteLine("resume");
                Text continueText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Resume"), "Text"));
                continueText.text = this.jsonParser.currentLanguage.pauseMenu.pause_resume;

                //Checkpoint
                Console.WriteLine("respawn");
                Text checkpointText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Restart Checkpoint"), "Text"));
                checkpointText.text = this.jsonParser.currentLanguage.pauseMenu.pause_respawn;

                //Restart mission
                Console.WriteLine("restart");
                Text restartText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Restart Mission"), "Text"));
                restartText.text = this.jsonParser.currentLanguage.pauseMenu.pause_restart;

                //Options
                Console.WriteLine("options");
                Text optionsText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Options"), "Text"));
                optionsText.text = this.jsonParser.currentLanguage.pauseMenu.pause_options;

                //Quit
                Text quitText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Quit Mission"), "Text"));
                quitText.text = this.jsonParser.currentLanguage.pauseMenu.pause_quit;
            }
            catch(Exception e)
            {
                Logger.LogError("Failed to patch pause menu");
                Logger.LogError(e.ToString());
            }

        }

        public void patchCheats(ref GameObject coreGame)
        {
            coreGame = GameObject.Find("Canvas");
            Cheats cheats = new Cheats(ref coreGame);
        }

        public void patchDeathScreen(ref GameObject coreGame)
        {
            GameObject deathScreen = null;
            try
            {
                deathScreen = getGameObjectChild(getGameObjectChild(GameObject.Find("Canvas"), "BlackScreen"), "YouDiedText");
                //Need to disable the TextOverride component.
                Component[] test = deathScreen.GetComponents(typeof(Component));
                Behaviour bhvr = (Behaviour)test[3];
                bhvr.enabled = false;

                Text youDiedText = getTextfromGameObject(deathScreen);
                youDiedText.text = "[VOUS ÊTES MORT]\n\n\n\n\n[R] POUR RECOMMENCER";
            }
            catch
            {
                Logger.LogError("Failed to patch death screen");
            }
            
        }
        
        public void initJsonParser()
        {
            this.jsonParser = new JsonParser();
        }

        //Encapsulation function to patch the shop.
        public void patchShop(ref GameObject coreGame)
        {
            Shop patchShop = new Shop(ref coreGame,this.jsonParser);
        }
        
        public void patchLevelStats(ref GameObject coreGame)
        {
            LevelStatWindow patchStats = new LevelStatWindow(ref coreGame);
        }

        //Encapsulation function to patch all of the front end.
        public void patchFrontEnd(GameObject frontEnd)
        {
            MainMenu mainMenu = new MainMenu(frontEnd, jsonParser);
            Options options = new Options(ref frontEnd, this.jsonParser);

        }

        //Parent function to patch the vanilla game functions.
        public void patchVanillaFunctions()
        {
            Harmony harmony = new Harmony(pluginGuid);
            Logger.LogInfo("Patching Check for difficulty strings...");
            MethodInfo originalCheckFunction = AccessTools.Method(typeof(DifficultyTitle), "Check");
            MethodInfo patchedCheckFunction = AccessTools.Method(typeof(PatchedFunctions), "Check_MyPatch");
            harmony.Patch(originalCheckFunction, new HarmonyMethod(patchedCheckFunction));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching checkScore for act select strings...");
            MethodInfo originalCheckScoreFunction = AccessTools.Method(typeof(LevelSelectPanel), "CheckScore");
            MethodInfo patchedCheckScoreFunction = AccessTools.Method(typeof(PatchedFunctions), "CheckScore_MyPatch");
            harmony.Patch(originalCheckScoreFunction, new HarmonyMethod(patchedCheckScoreFunction));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching nameAppear for in-level title strings...");
            MethodInfo originalNameAppearFunction = AccessTools.Method(typeof(LevelNamePopup), "NameAppear");
            MethodInfo patchedNameAppearFunction = AccessTools.Method(typeof(PatchedFunctions), "NameAppear_MyPatch");
            harmony.Patch(originalNameAppearFunction, new HarmonyMethod(patchedNameAppearFunction));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching tutorial intro text...");
            MethodInfo originalIntroFunction = AccessTools.Method(typeof(IntroText), "Start");
            MethodInfo patchedIntroFunction = AccessTools.Method(typeof(PatchedFunctions), "IntroTextStart_MyPatch");
            harmony.Patch(originalIntroFunction, new HarmonyMethod(patchedIntroFunction));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching HUD message box functions...");
            MethodInfo originalPlayMessage = typeof(HudMessage).GetMethod("PlayMessage");
            MethodInfo patchedPlayMessage = AccessTools.Method(typeof(PatchedFunctions), "PlayMessage_MyPatch");
            harmony.Patch(originalPlayMessage, new HarmonyMethod(patchedPlayMessage));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching SetInfo for results screen...");
            MethodInfo originalSetInfo = AccessTools.Method(typeof(FinalRank), "SetInfo");
            MethodInfo patchedSetInfo = AccessTools.Method(typeof(PatchedFunctions), "SetInfo_MyPatch");
            harmony.Patch(originalSetInfo, new HarmonyMethod(patchedSetInfo));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching Boss bar names...");
            MethodInfo originalCreateBossBar = AccessTools.Method(typeof(BossBarManager), "CreateBossBar");
            MethodInfo patchedCreateBossBar = AccessTools.Method(typeof(PatchedFunctions), "CreateBossBar_MyPatch");
            harmony.Patch(originalCreateBossBar, new HarmonyMethod(patchedCreateBossBar));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching UpdateMoney for the shop...");
            MethodInfo originalUpdateMoney = AccessTools.Method(typeof(VariationInfo), "UpdateMoney");
            MethodInfo patchedUpdateMoney = AccessTools.Method(typeof(PatchedFunctions), "UpdateMoney_MyPatch");
            harmony.Patch(originalUpdateMoney, new HarmonyMethod(patchedUpdateMoney));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching AddPoints for the style meter...");
            MethodInfo originalAddPoints = AccessTools.Method(typeof(StyleHUD), "AddPoints");
            MethodInfo patchedAddPoints = AccessTools.Method(typeof(PatchedFunctions), "AddPoints_MyPatch");
            harmony.Patch(originalAddPoints, new HarmonyMethod(patchedAddPoints));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching Start in TextAppear intermission strings...");
            MethodInfo originalIntermissionStart = AccessTools.Method(typeof(IntermissionController), "Start");
            MethodInfo patchedIntermissionStart = AccessTools.Method(typeof(PatchedFunctions), "Start_MyPatch");
            harmony.Patch(originalIntermissionStart, new HarmonyMethod(patchedIntermissionStart));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching DisplaySubtitle for subtitles...");
            MethodInfo originalDisplaySubtitle = AccessTools.Method(typeof(SubtitleController), "DisplaySubtitle", new Type[] { typeof(string) });
            MethodInfo patchedDisplaySubtitle = AccessTools.Method(typeof(PatchedFunctions), "DisplaySubtitle_MyPatch");
            harmony.Patch(originalDisplaySubtitle, new HarmonyMethod(patchedDisplaySubtitle));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching EnemyInfoPage for enemy bios...");
            MethodInfo originalUpdateInfo = AccessTools.Method(typeof(EnemyInfoPage), "UpdateInfo");
            MethodInfo patchedUpdateInfo = AccessTools.Method(typeof(PatchedFunctions), "UpdateInfo_MyPatch");
            harmony.Patch(originalUpdateInfo, new HarmonyMethod(patchedUpdateInfo));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching OnEnable for save menu...");
            MethodInfo originalUpdateSlotState = typeof(SaveSlotMenu).GetMethod("UpdateSlotState", BindingFlags.NonPublic | BindingFlags.Instance, null,new Type[] {typeof(SlotRowPanel),typeof(SaveSlotMenu.SlotData)}, null);
            MethodInfo patchedUpdateSlotState = AccessTools.Method(typeof(PatchedFunctions), "UpdateSlotState_MyPatch");
            harmony.Patch(originalUpdateSlotState, new HarmonyMethod(patchedUpdateSlotState));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching originalClearSlot for save menu...");
            MethodInfo originalClearSlot = typeof(SaveSlotMenu).GetMethod("ClearSlot", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(int) }, null);
            MethodInfo patchedClearSlot = AccessTools.Method(typeof(PatchedFunctions), "ClearSlot_MyPatch");
            harmony.Patch(originalClearSlot, new HarmonyMethod(patchedClearSlot));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching FetchSceneActivity for Discord Rich Presence...");
            MethodInfo originalFetchScene = AccessTools.Method(typeof(DiscordController), "FetchSceneActivity", new Type[] { typeof(string) });
            MethodInfo patchedFetchScene = AccessTools.Method(typeof(PatchedFunctions), "FetchSceneActivity_MyPatch");
            harmony.Patch(originalFetchScene, new HarmonyMethod(patchedFetchScene));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching updateStyle for Discord Rich Presence...");
            MethodInfo originalUpdateStyle = AccessTools.Method(typeof(DiscordController), "UpdateStyle", new Type[] { typeof(int) });
            MethodInfo patchedUpdateStyle = AccessTools.Method(typeof(PatchedFunctions), "UpdateStyle_MyPatch");
            harmony.Patch(originalUpdateStyle, new HarmonyMethod(patchedUpdateStyle));

            Logger.LogInfo("Patching updateRank for Discord Rich Presence...");
            MethodInfo originalUpdateRank = AccessTools.Method(typeof(DiscordController), "UpdateRank", new Type[] { typeof(int) });
            MethodInfo patchedUpdateRank = AccessTools.Method(typeof(PatchedFunctions), "UpdateRank_MyPatch");
            harmony.Patch(originalUpdateRank, new HarmonyMethod(patchedUpdateRank));

            Logger.LogInfo("Patching updateWave for Discord Rich Presence...");
            MethodInfo originalUpdateWave = AccessTools.Method(typeof(DiscordController), "UpdateWave", new Type[] { typeof(int) });
            MethodInfo patchedUpdateWave = AccessTools.Method(typeof(PatchedFunctions), "UpdateWave_MyPatch");
            harmony.Patch(originalUpdateWave, new HarmonyMethod(patchedUpdateWave));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching ShowHudMessage in HudMessageReceiver ...");
            MethodInfo originalShowHudMessage = typeof(HudMessageReceiver).GetMethod("SendHudMessage");
            MethodInfo patchedShowHudMessage = AccessTools.Method(typeof(PatchedFunctions), "SendHudMessage_MyPatch");
            harmony.Patch(originalShowHudMessage, new HarmonyMethod(patchedShowHudMessage));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching UpdateCheatState for cheat menu...");
            MethodInfo originalUpdateCheatState = typeof(CheatsManager).GetMethod("UpdateCheatState", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(CheatMenuItem),typeof(ICheat) }, null);
            MethodInfo patchedUpdateCheatState = AccessTools.Method(typeof(PatchedFunctions), "UpdateCheatState_MyPatch");
            harmony.Patch(originalUpdateCheatState, new HarmonyMethod(patchedUpdateCheatState));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching RenderCheatsInfo for cheat display HUD...");
            MethodInfo originalRenderCheatsInfo = typeof(CheatsManager).GetMethod("RenderCheatsInfo");
            MethodInfo patchedRenderCheatsInfo = AccessTools.Method(typeof(PatchedFunctions), "RenderCheatsInfo_MyPatch");
            harmony.Patch(originalRenderCheatsInfo, new HarmonyMethod(patchedRenderCheatsInfo));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching Start for level stat window...");
            MethodInfo originalStart = typeof(LevelStats).GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] {}, null);
            MethodInfo patchedStart = AccessTools.Method(typeof(PatchedFunctions), "LevelStatsStart_MyPatch");
            harmony.Patch(originalStart, new HarmonyMethod(patchedStart));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching Update for level stat window...");
            MethodInfo originalUpdate = typeof(LevelStats).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] {}, null);
            MethodInfo patchedUpdate = AccessTools.Method(typeof(PatchedFunctions), "LevelStatsUpdate_MyPatch");
            harmony.Patch(originalUpdate, new HarmonyMethod(patchedUpdate));
            Logger.LogInfo("Done");

            Logger.LogInfo("Patching Toggle for CG...");
            MethodInfo originalToggle = typeof(CustomPatterns).GetMethod("Toggle");
            MethodInfo patchedToggle = AccessTools.Method(typeof(PatchedFunctions), "Toggle_MyPatch");
            harmony.Patch(originalToggle, new HarmonyMethod(patchedToggle));
            Logger.LogInfo("Done");
        }

        //Most of the hook logic and checks go in this function.
        void onSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (!this.ready || this.jsonParser == null)
            {
                Logger.LogError("Not ready for patching");
                return;
            }
            else
            { 
            Scene currentLevel = SceneManager.GetActiveScene();
            Logger.LogInfo("Current scene: " + currentLevel.name);

            //Each scene (level) has an object called Canvas. Most game objects are there.
            //Don't hook if it's still the intro, as it doesn't use Canvas.
            if (currentLevel.name == "Intro")
            {
                Logger.LogInfo("Intro screen detected, not hooking.");

                //TEMPORARY REDIRECT TO THE MAIN MENU TO SAVE TIME WHILE TESTING.
                SceneManager.LoadScene("Main Menu");
            }
            //Main menu hook
            else if (currentLevel.name == "Main Menu")
            {
                Logger.LogInfo("Hooking into main menu text...");
                GameObject frontEnd = GameObject.Find("Canvas");
                if (frontEnd == null)
                {
                    Logger.LogError("Failed to hook.");
                }
                else
                {
                    Logger.LogInfo("Hooked into front end, patching...");
                    patchFrontEnd(frontEnd);


                    GameObject ultrakullLogo = GameObject.Instantiate(getGameObjectChild(getGameObjectChild(getGameObjectChild(frontEnd, "Main Menu (1)"), "Title"),"Text"), frontEnd.transform);
                        ultrakullLogo.transform.localPosition = new Vector3(1100, -470, 0);
                        Text ultrakullLogoText = getTextfromGameObject(ultrakullLogo);
                        ultrakullLogoText.text = "ultrakULL loaded.\nLocale: " + this.jsonParser.currentLanguage.metadata.langName;
                        ultrakullLogoText.alignment = TextAnchor.UpperLeft;
                        ultrakullLogoText.fontSize = 16;
                    }
            }
            else if (currentLevel.name.Contains("P-"))
            {
                //Prime sanctum level hook
                Logger.LogInfo("Prime sanctum, attempting to hook via Prime FirstRoom...");
                GameObject coreGame = GameObject.Find("Prime FirstRoom");
                if (coreGame == null)
                {
                    Logger.LogError("Failed to hook.");
                }
                else
                {
                    patchPauseMenu(ref coreGame);
                    patchCheats(ref coreGame);
                    patchDeathScreen(ref coreGame);
                    patchLevelStats(ref coreGame);
                    Options options = new Options(ref coreGame,this.jsonParser) ;
                    PrimeSanctum primeSanctumClass = new PrimeSanctum(ref coreGame,this.jsonParser);
                }
            }
            else if (currentLevel.name.Contains("-S"))
            {
                //In secret level hook
                Logger.LogInfo("In secret level detected, attempting to hook via Canvas...");

                //Potential problem here - we're hooking via Secret FirstRoom, but the words are swapped between secret levels...
                GameObject coreGame = GameObject.Find("Canvas");
                if (coreGame == null)
                {
                    Logger.LogError("Failed to hook into secret level.");
                }
                else
                {
                    Logger.LogInfo("Hooked, patching secret level");
                    patchPauseMenu(ref coreGame);
                    patchCheats(ref coreGame);
                    patchLevelStats(ref coreGame);
                    Options options = new Options(ref coreGame, this.jsonParser);
                    SecretLevels secretLevels = new SecretLevels(ref coreGame,this.jsonParser);
                }
            }
            else if (currentLevel.name == "uk_construct")
            //Sandbox hook
            {
                Logger.LogInfo("Sandbox detected, hooking via Canvas");
                GameObject coreGame = GameObject.Find("Canvas");
                if (coreGame == null)
                {
                    Logger.LogError("Failed to hook into sandbox");
                }
                else
                {
                    patchPauseMenu(ref coreGame);
                    patchCheats(ref coreGame);
                    patchShop(ref coreGame);
                    Options options = new Options(ref coreGame, this.jsonParser);
                    //SandboxEnemy sandbox = new SandboxEnemy(ref coreGame);
                }
            }

            else
            //In-level hook
            {
                Logger.LogInfo("In-level detected, attempting to hook...");
                GameObject coreGame = GameObject.Find("FirstRoom");
                if (coreGame == null)
                {
                    Logger.LogError("Failed to hook.");
                }
                else
                {
                    Logger.LogInfo("Retrieving current level name...");
                    Logger.LogInfo("Currently in: " + SceneManager.GetActiveScene().name);
                    Logger.LogInfo("Patching common pause menu...");
                    patchPauseMenu(ref coreGame);
                    Logger.LogInfo("Patching shop...");
                    patchShop(ref coreGame);
                    Logger.LogInfo("Patching options...");
                    Options options = new Options(ref coreGame, this.jsonParser);
                    Logger.LogInfo("Patching cheat consent box...");
                    patchCheats(ref coreGame);
                    Logger.LogInfo("Patching death screen...");
                    patchDeathScreen(ref coreGame);
                    Logger.LogInfo("Patching in-game stats...");
                    patchLevelStats(ref coreGame);
                    

                    //Tutorial
                    if (SceneManager.GetActiveScene().name.Contains("Tutorial"))
                    {
                        Logger.LogInfo("Currently on tutorial. Now deferring patch to tutorial class.");
                        TutorialStrings tutorialPatchClass = new TutorialStrings(this.jsonParser);
                    }

                    //Prelude
                    else if (SceneManager.GetActiveScene().name.Contains("0-"))
                    {
                        Logger.LogInfo("Currently on prelude. Now deferring patch to prelude class.");
                        Prelude preludePatchClass = new Prelude(ref coreGame, this.jsonParser);
                    }
                    //Act 1
                    else if (SceneManager.GetActiveScene().name.Contains("1-") || SceneManager.GetActiveScene().name.Contains("2-") || SceneManager.GetActiveScene().name.Contains("3-"))
                    {
                        Logger.LogInfo("Currently on Act 1. Now deferring patch to Act 1 class.");
                        Act1 act1Class = new Act1(ref coreGame,this.jsonParser);
                    }
                    //Act intermission

                    else if (SceneManager.GetActiveScene().name.Contains("Intermission1"))
                    {
                        Logger.LogInfo("Currently on Act 1 intermission.");
                        Intermission intermission = new Intermission(ref coreGame,this.jsonParser);
                    }

                    //Act 2
                    else if (SceneManager.GetActiveScene().name.Contains("4-") || SceneManager.GetActiveScene().name.Contains("5-") || SceneManager.GetActiveScene().name.Contains("6-"))
                    {
                        Logger.LogInfo("Currently on Act 2. Now deferring patch to Act 2 class.");
                        Act2 act2Class = new Act2(ref coreGame, this.jsonParser);
                    }

                    //Cyber Grind
                    else if (SceneManager.GetActiveScene().name.Contains("Endless"))
                    {
                        Logger.LogInfo("Currently in the Cyber Grind.");
                        CyberGrind cybergrind = new CyberGrind(ref coreGame);
                    }
                }
            }
            }
        }
        //Entry point for the patch.
        public void Awake()
        {
            Debug.unityLogger.filterLogType = LogType.Exception;
            Logger.LogInfo("UltrakULL LOADING...)");
            Logger.LogInfo("Version: " + pluginVersion);

            try
            {
                Logger.LogInfo("--- Initializing JSON parser ---");
                initJsonParser();
                Logger.LogInfo("--- Inserting loaded language into patched functions ---");
                this.patchedFuncs = new PatchedFunctions(this.jsonParser);
                Logger.LogInfo("--- Patching vanilla game functions ---");
                patchVanillaFunctions();
                Logger.LogInfo(" --- All done. Enjoy! ---");
                this.ready = true;
            }
            catch(Exception e)
            {
                Logger.LogError("An error occured while initialising.");
                Console.WriteLine(e.ToString());
                return;
            }



        }
        void OnEnable()
        {
            SceneManager.sceneLoaded += onSceneLoaded;
        }

        void onDisable()
        {
            SceneManager.sceneLoaded -= onSceneLoaded;
        }

        void Update()
        {

        }

    }
}
