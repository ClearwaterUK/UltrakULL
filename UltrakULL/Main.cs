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
 *	UltrakULL (Ultrakill Language Library)
 *	Written by Clearwater, additional code contributions by Temperz87, translations by UltrakULL Translation Team
 *	Date started: 21st April 2021
 *	Last updated: 2nd November 2022
 *	
 *	This is a translation mod for Ultrakill that hooks into the game and allows for text/string replacement.
 *	This tool is primarily meant to assist with language translation.
 * 
 *  -- MAIN TODO LIST --
 *  - Add ULL credits, translation credits to main menu with help of UKUIHelper library
 *  - Error and exception handling
 *  - Divide up more stuff in try/catch functions (especially the shop and options), that way less stuff breaks if something bad happens
 * 
 *  -- Less important stuff for future updates --
 *  - Cheat teleport menu
 *  - Sandbox stuff (time of day shop, spawn/cheat menu categories, dupe save/load menu)
 *  - Terminals before bosses in levels (could copy the shop that's in the start of each level)
 *  - Organise and refactor stuff, move functions to other files to declutter Main (Factorise the act classes with an interface?)
 *  - Look into how I can do encoding for RTL languages such as Arabic
 *  - Port main class so it becomes a native UMM mod instead of BepInEx. With the way its structured, could be able to move config/lang files to same folder.
 *  - Green Rocketlauncher incoming
 *  - Could be possible to swap out rank textures in HUD for translation. Shall look into later
 *  - Attempt to replace the default font with a version that has better special char + cyrillic support
 *  
 *  -- BUGS AND QUIRKS TO FIX --
 * 
 *  -- STUFF REPORTED BY ULL TEAM --
 * 
 *  -- FOR NEXT HOTFIX --
 * - Add more sanity checks in code to prevent entire mod from breaking if something does (Caused when mod tries to get strings from json that don't exist and then just ends up breaking everything). Disable a patched function by returning true if an exception happens there, will then use original game code.
 * - Inconsistencies with commas in input messages (ex: 0-1 has them but slide in tutorial doesn't)
 * Options->Sandbox icons names
 * - Misc keys as strings (comma, period, etc)
 * - English template seems to have some problems. The file "loads" but then immediately throws not ready for patching. (Switching to it in-game seems to work though)
 * */

namespace UltrakULL
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    [BepInProcess("ULTRAKILL.exe")]
    public class MainPatch : BaseUnityPlugin
    {
        public const string pluginGuid = "clearwater.ultrakill.ultrakULL";
        public const string pluginName = "UltrakULL - Ultrakill Language Library";
        public const string pluginVersion = "0.9.1";

        public static MainPatch instance = null;
        private GameObject ultrakullLogo = null;

        private bool ready = false;
        public Font vcrFont;

        public MainPatch()
        {
            instance = this;
        }

        public void OnApplicationQuit()
        {
            LanguageManager.DumpLastLanguage();
        }

        public void disableMod()
        {
            this.ready = false;
        }

        //Patches all text strings in the pause menu.
        public void patchPauseMenu(ref GameObject level)
        {
            try
            {
                GameObject pauseObject = getInactiveRootObject("Canvas");
                GameObject pauseMenu = getGameObjectChild(pauseObject, "PauseMenu");

                //Title
                Text pauseText = getTextfromGameObject(getGameObjectChild(pauseMenu, "Text"));
                pauseText.text = "-- " + LanguageManager.CurrentLanguage.pauseMenu.pause_title + " --";

                //Resume
                Text continueText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Resume"), "Text"));
                continueText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_resume;

                //Checkpoint
                Text checkpointText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Restart Checkpoint"), "Text"));
                checkpointText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_respawn;

                //Restart mission
                Text restartText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Restart Mission"), "Text"));
                restartText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restart;

                //Options
                Text optionsText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Options"), "Text"));
                optionsText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_options;

                //Quit
                Text quitText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Quit Mission"), "Text"));
                quitText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quit;

                //Quit+Restart windows
                GameObject pauseDialogs = getGameObjectChild(pauseObject, "PauseMenuDialogs");

                //Quit
                GameObject quitDialog = getGameObjectChild(getGameObjectChild(pauseDialogs, "Quit Confirm"), "Panel");
                Text quitDialogText = getTextfromGameObject(getGameObjectChild(quitDialog, "Text"));
                quitDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirm;

                Text quitDialogTooltip = getTextfromGameObject(getGameObjectChild(quitDialog, "Text (1)"));
                quitDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

                Text quitDialogYes = getTextfromGameObject(getGameObjectChild(getGameObjectChild(quitDialog, "Confirm"), "Text"));
                quitDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmYes;

                Text quitDialogNo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(quitDialog, "Cancel"), "Text"));
                quitDialogNo.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmNo;

                //Restart
                GameObject restartDialog = getGameObjectChild(getGameObjectChild(pauseDialogs, "Restart Confirm"), "Panel");

                Text restartDialogText = getTextfromGameObject(getGameObjectChild(restartDialog, "Text"));
                restartDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirm;

                Text restartDialogTooltip = getTextfromGameObject(getGameObjectChild(restartDialog, "Text (1)"));
                restartDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

                Text restartDialogYes = getTextfromGameObject(getGameObjectChild(getGameObjectChild(restartDialog, "Confirm"), "Text"));
                restartDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirmYes;

                Text restartDialogNo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(restartDialog, "Cancel"), "Text"));
                restartDialogNo.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirmNo;
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to patch pause menu");
                Logger.LogError(e.ToString());
            }
        }

        public void patchCheats(ref GameObject coreGame)
        {
            coreGame = GameObject.Find("Canvas");
            Cheats.patchCheatConsentPanel(ref coreGame);
        }

        public void patchDeathScreen(ref GameObject coreGame)
        {
            coreGame = getInactiveRootObject("Canvas");

            try
            {
                GameObject deathScreen = getGameObjectChild(getGameObjectChild(coreGame, "BlackScreen"), "YouDiedText");
                //Need to disable the TextOverride component.
                Component[] test = deathScreen.GetComponents(typeof(Component));
                Behaviour bhvr = (Behaviour)test[3];
                bhvr.enabled = false;

                Text youDiedText = getTextfromGameObject(deathScreen);
                youDiedText.text = LanguageManager.CurrentLanguage.misc.youDied1 + "\n\n\n\n\n" + LanguageManager.CurrentLanguage.misc.youDied2;
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to patch death screen");
                Console.WriteLine(e.ToString());
            }
        }

        public void initJsonParser()
        {
            LanguageManager.InitializeManager(pluginVersion);
        }

        //Encapsulation function to patch the shop.
        public void patchShop(ref GameObject coreGame)
        {
            Shop.PatchShop(ref coreGame);
        }

        public void patchLevelStats(ref GameObject coreGame)
        {
            LevelStatWindow.patchStats();
        }

        //Encapsulation function to patch all of the front end.
        public void patchFrontEnd(GameObject frontEnd)
        {
            MainMenu.Patch(frontEnd);
            Options options = new Options(ref frontEnd);
        }

        public void patchMisc(ref GameObject coreGame)
        {
            GameObject player = GameObject.Find("Player");
            GameObject styleMeter = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(player, "Main Camera"), "HUD Camera"), "HUD"), "StyleCanvas"), "Panel (1)"), "Panel"), "Text (1)"), "Text");
            Text styleMeterMultiplierText = getTextfromGameObject(styleMeter);
            styleMeterMultiplierText.text = LanguageManager.CurrentLanguage.style.stylemeter_multiplier;

            GameObject canvas = getInactiveRootObject("Canvas");
            GameObject pressToSkip = getGameObjectChild(canvas, "CutsceneSkipText");

            //Need to disable the TextOverride component.
            Component[] test = pressToSkip.GetComponents(typeof(Component));
            Behaviour bhvr = (Behaviour)test[4];
            bhvr.enabled = false;

            Text pressToSkipText = getTextfromGameObject(pressToSkip);
            pressToSkipText.text = LanguageManager.CurrentLanguage.misc.pressToSkip;

            //Classic HUD
            GameObject classicHudBW = getGameObjectChild(getGameObjectChild(getGameObjectChild(canvas, "Crosshair Filler"), "AltHud"), "Filler");
            GameObject classicHudColor = getGameObjectChild(getGameObjectChild(getGameObjectChild(canvas, "Crosshair Filler"), "AltHud (2)"), "Filler");

            Text classicHudBWHealth = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Health"), "Title"));
            Text classicHudBWHealthShow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Health"), "Title (1)"));
            Text classicHudColorHealth = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Health"), "Title"));
            Text classicHudColorHealthShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Health"), "Title (1)"));
            classicHudBWHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudColorHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudBWHealthShow.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudColorHealthShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_health;

            Text classicHudBWStamina = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Stamina"), "Title"));
            Text classicHudColorStamina = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Stamina"), "Title"));
            Text classicHudBWStaminaShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Stamina"), "Title (1)"));
            Text classicHudColorStaminaShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Stamina"), "Title (1)"));
            classicHudBWStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudColorStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudBWStaminaShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudColorStaminaShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;

            Text classicHudBWWeapon = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Weapon"), "Title"));
            Text classicHudColorWeapon = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Weapon"), "Title"));
            Text classicHudBWWeaponShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Weapon"), "Title (1)"));
            Text classicHudColorWeaponShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Weapon"), "Title (1)"));
            classicHudBWWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudColorWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudBWWeaponShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudColorWeaponShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;

            Text classicHudBWArm = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Arm"), "Title"));
            Text classicHudColorArm = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Arm"), "Title"));
            Text classicHudBWArmShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Arm"), "Title (1)"));
            Text classicHudColorArmShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Arm"), "Title (1)"));
            classicHudBWArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudColorArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudBWArmShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudColorArmShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;

            Text classicHudBWRailcannon = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "RailcannonMeter (1)"), "Title"));
            Text classicHudColorRailcannon = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "RailcannonMeter"), "Title"));
            Text classicHudBWRailcannonShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "RailcannonMeter (1)"), "Title (1)"));
            Text classicHudColorRailcannonShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "RailcannonMeter"), "Title (1)"));
            classicHudBWRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudColorRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudBWRailcannonShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudColorRailcannonShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;

            //Close prompt when reading book
            TextBinds bookPanelBinds = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(canvas, "ScanningStuff"), "ReadingScanned"), "Panel"), "Text (1)").GetComponent<TextBinds>();
            bookPanelBinds.text1 = LanguageManager.CurrentLanguage.books.books_pressToClose1 + " <color=orange>";
            bookPanelBinds.text2 = "</color> " + LanguageManager.CurrentLanguage.books.books_pressToClose2;
        }

        //Adds the Discord link to the UltrakULL Discord on the main menu.
        public void addDiscord(GameObject frontEnd)
        {
            GameObject mainMenuCanvas = getGameObjectChild(frontEnd, "Main Menu (1)");

            GameObject mainMenuButtons = getGameObjectChild(getGameObjectChild(frontEnd, "Main Menu (1)"), "Panel");
            GameObject ultrakullDiscordButton = GameObject.Instantiate(getGameObjectChild(mainMenuButtons, "Discord"), mainMenuButtons.transform);

            ultrakullDiscordButton.SetActive(true);
            ultrakullDiscordButton.GetComponent<RectTransform>().localPosition = new Vector2(450f, 250f);
            ultrakullDiscordButton.GetComponentInChildren<Text>().text = "UltrakULL DISCORD";
            ultrakullDiscordButton.GetComponentInChildren<WebButton>().url = "https://discord.gg/ZB7jk6Djv5";

            ultrakullDiscordButton.transform.parent = mainMenuButtons.transform;
            ultrakullDiscordButton.GetComponent<RectTransform>().SetParent(mainMenuButtons.GetComponent<RectTransform>());
        }

        public void addModCredits(GameObject frontEnd)
        {
            Text credits = getTextfromGameObject(getGameObjectChild(getGameObjectChild(frontEnd, "Credits"), "Text (2)"));

            credits.text =
                "WITH VOICE ACTING BY:" + "\n"
                + "<color=orange>GIANNI MATRAGRANO</color> (GABRIEL)" + "\n"
                + "<color=orange> STEPHAN WEYTE </color> (MINOS PRIME)" + "\n"
                + "<color=orange>MANDALORE HERRINGTON</color> (MDK)" + "\n"
                + "<color=orange>JUST SHAMMY </color> (&OWL)" + "\n\n"

                + "AND QUALITY ASSURANCE BY:" + "\n"
                + "<color=orange>CAMERON MARTIN</color> (LEAD QA)" + "\n"
                + "<color=orange>TUCKER WILKIN </color> (SENIOR QA)" + "\n"
                + "<color=orange>SCOTT GURNEY </color> (TECHNICAL QA)" + "\n"
                + "<color=orange>DALIA FIGUEROA </color> (QA & PROMO MATERIAL)" + "\n\n\n"

                + "<color=orange>UltrakULL (ULTRAKILL Language Library)</color>" + "\n"
                + "A TRANSLATION MOD FOR ULTRAKILL" + "\n"
                + "CREATED BY <color=orange>CLEARWATER</color> AND THE <color=orange>UltrakULL TRANSLATION TEAM</color>" + "\n"
                + "CODE CONTRIBUTIONS BY <color=orange>TEMPERZ87</color>" + "\n"
                + "FULL LANGUAGE CREDITS IN THE MOD README (to come later)" + "\n";
        }

        //Most of the hook logic and checks go in this function.
        public void onSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (!this.ready || LanguageManager.CurrentLanguage == null)
            {
                Logger.LogError("Not ready for patching");
                return;
            }
            else
            {
                Scene currentLevel = SceneManager.GetActiveScene();
                string levelName = currentLevel.name;

                if (Harmony_Patches.Inject_LanguageButton.languageButtonText != null)
                {
                    Harmony_Patches.Inject_LanguageButton.languageButtonText.text = LanguageManager.CurrentLanguage.options.language_languages;
                    Harmony_Patches.Inject_LanguageButton.languageButtonTitleText.text = "--" + LanguageManager.CurrentLanguage.options.language_title + "--";
                }
                //Each scene (level) has an object called Canvas. Most game objects are there.
                if (currentLevel.name == "Intro")
                {
                    GameObject frontEnd = getInactiveRootObject("Canvas");
                    if (frontEnd != null)
                    {
                        Text loadingText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(frontEnd, "LoadingScreen"), "Intro"), "Text"));
                        loadingText.text = LanguageManager.CurrentLanguage.misc.loading;
                    }
                }
                //Main menu hook
                else if (currentLevel.name == "Main Menu")
                {
                    GameObject frontEnd = getInactiveRootObject("Canvas");

                    if (frontEnd == null)
                    {
                        Logger.LogError("Failed to hook into main menu.");
                    }
                    else
                    {
                        patchFrontEnd(frontEnd);

                        if (ultrakullLogo != null)
                            GameObject.Destroy(ultrakullLogo);
                        ultrakullLogo = GameObject.Instantiate(getGameObjectChild(getGameObjectChild(getGameObjectChild(frontEnd, "Main Menu (1)"), "Title"), "Text"), frontEnd.transform);
                        ultrakullLogo.transform.localPosition = new Vector3(1025, -425, 0);
                        Text ultrakullLogoText = getTextfromGameObject(ultrakullLogo);
                        ultrakullLogoText.text = "ultrakULL loaded.\nVersion: " + pluginVersion + "\nLocale: " + LanguageManager.CurrentLanguage.metadata.langName + "\nWIP build\nFor internal testing only";
                        ultrakullLogoText.alignment = TextAnchor.UpperLeft;
                        ultrakullLogoText.fontSize = 16;
                        //Get the font
                        this.vcrFont = ultrakullLogoText.font;

                        if (!LanguageManager.FileMatchesMinimumRequiredVersion(LanguageManager.CurrentLanguage.metadata.minimumModVersion, pluginVersion))
                        {
                            ultrakullLogoText.text += "\n<color=orange>WARNING - Outdated language\nloaded.</color>\nCheck console\n & use at your own risk!";
                            ultrakullLogo.transform.localPosition = new Vector3(1025, -350, 0);
                        }

                        this.addDiscord(frontEnd);
                        this.addModCredits(frontEnd);
                    }
                }
                else if (currentLevel.name.Contains("P-"))
                {
                    //Prime sanctum level hook
                    GameObject coreGame = GameObject.Find("Prime FirstRoom");
                    if (coreGame == null)
                    {
                        Logger.LogError("Failed to hook into Prime levels.");
                    }
                    else
                    {
                        try
                        {
                            patchPauseMenu(ref coreGame);
                            patchCheats(ref coreGame);
                            patchDeathScreen(ref coreGame);
                            patchLevelStats(ref coreGame);
                            patchMisc(ref coreGame);
                        }
                        catch (Exception e)
                        {
                            Logger.LogError("Failed to patch in-game elements (prime).");
                            Logger.LogInfo(e.ToString());
                        }
                        Options options = new Options(ref coreGame);
                        PrimeSanctum primeSanctumClass = new PrimeSanctum(ref coreGame);
                    }
                }
                else if (currentLevel.name.Contains("-S"))
                {
                    //In secret level hook

                    //Potential problem here - we're hooking via Secret FirstRoom, but the words are swapped between secret levels...
                    GameObject coreGame = getInactiveRootObject("Canvas");
                    if (coreGame == null)
                    {
                        Logger.LogError("Failed to hook into secret level.");
                    }
                    else
                    {
                        patchPauseMenu(ref coreGame);
                        patchCheats(ref coreGame);
                        patchLevelStats(ref coreGame);
                        Options options = new Options(ref coreGame);
                        SecretLevels secretLevels = new SecretLevels(ref coreGame);
                    }
                }
                else if (currentLevel.name == "uk_construct")
                //Sandbox hook
                {
                    GameObject coreGame = getInactiveRootObject("Canvas");
                    if (coreGame == null)
                    {
                        Logger.LogError("Failed to hook into sandbox.");
                    }
                    else
                    {
                        patchPauseMenu(ref coreGame);
                        patchCheats(ref coreGame);
                        patchShop(ref coreGame);
                        patchDeathScreen(ref coreGame);
                        patchMisc(ref coreGame);
                        Options options = new Options(ref coreGame);
                    }
                }
                else
                //General in-level hook
                {
                    GameObject coreGame = GameObject.Find("FirstRoom");
                    if (coreGame == null)
                    {
                        Logger.LogError("Failed to hook into in-game elements.");
                    }
                    else
                    {
                        try
                        {
                            patchPauseMenu(ref coreGame);
                            patchShop(ref coreGame);
                            patchCheats(ref coreGame);
                            patchDeathScreen(ref coreGame);
                            patchLevelStats(ref coreGame);
                            patchMisc(ref coreGame);

                            Options options = new Options(ref coreGame);
                        }
                        catch (Exception e)
                        {
                            Logger.LogError("Failed to patch in-game elements.");
                            Console.WriteLine(e.ToString());
                        }

                        //Tutorial
                        if (levelName.Contains("Tutorial"))
                        {
                            TutorialStrings tutorialPatchClass = new TutorialStrings();
                        }

                        //Prelude
                        else if (levelName.Contains("0-"))
                        {
                            Prelude preludePatchClass = new Prelude(ref coreGame);
                        }
                        //Act 1
                        else if (levelName.Contains("1-") || levelName.Contains("2-") || levelName.Contains("3-"))
                        {
                            Act1.PatchAct1(ref coreGame);
                        }
                        //Act 2
                        else if (levelName.Contains("4-") || levelName.Contains("5-") || levelName.Contains("6-"))
                        {
                            Act2.PatchAct2(ref coreGame);
                        }
                        //Cyber Grind
                        else if (SceneManager.GetActiveScene().name.Contains("Endless"))
                        {
                            CyberGrind.PatchCG(ref coreGame);
                        }
                        //End of act intermission
                        else if (SceneManager.GetActiveScene().name.Contains("Intermission"))
                        {
                            Intermission intermission = new Intermission(ref coreGame);
                        }
                    }
                }
            }
        }

        //Entry point for the patch.
        public void Awake()
        {
            Debug.unityLogger.filterLogType = LogType.Exception;
            Logger.LogInfo("UltrakULL LOADING...");
            Logger.LogInfo("Version: " + pluginVersion);
            try
            {
                Logger.LogInfo("--- Initializing JSON parser ---");
                initJsonParser();
                Logger.LogInfo("--- Patching vanilla game functions ---");
                Logger.LogMessage("Patching game functions...");
                Harmony harmony = new Harmony(pluginGuid);
                harmony.PatchAll();
                Logger.LogInfo(" --- All done. Enjoy! ---");

                SceneManager.sceneLoaded += onSceneLoaded;
                
                this.ready = true;
            }
            catch (Exception e)
            {
                Logger.LogError("An error occured while initialising.");
                Console.WriteLine(e.ToString());
                return;
            }
        }
    }
}
