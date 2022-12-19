using HarmonyLib;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UltrakULL.json;

using static UltrakULL.CommonFunctions;
using static UltrakULL.ModPatches;
 
using UMM;
using System.Linq;

/*
 *	UltrakULL (Ultrakill Language Library)
 *	Written by Clearwater, additional code contributions by Temperz87, translations by UltrakULL Translation Team
 *	Date started: 21st April 2021
 *	Last updated: 15th December 2022
 *	
 *	This is a translation mod for Ultrakill that hooks into the game and allows for text/string replacement.
 *	This tool is primarily meant to assist with language translation.
 * 
 *  -- MAIN TASK LIST --
 *  - Add ULL credits, translation credits to main menu with help of UKUIHelper library
 *  - Error and exception handling
 *  - Divide up more stuff in try/catch functions (especially the shop and options), that way less stuff breaks if something bad happens
 * 
 *  -- STUFF FOR FUTURE UPDATES --
 *  - Next game update scheduled for early 2023. P-2, 5-S, radient enemies and green rocket launcher
 *  - Look into how I can do encoding for RTL languages such as Arabic (https://github.com/Konash/arabic-support-unity/ - could be useful)
 *  - Swap out rank textures in HUD for translation
 *  - Replace the default font with a version that has better special char + cyrillic support
 *  
 *  -- BUGS AND QUIRKS TO FIX --
 * - Misc keys as strings (comma, period, etc) missing
 * - Inconsistencies with commas in input messages (ex: 0-1 has them but slide in tutorial doesn't)
 * - Add more sanity checks in code to prevent entire mod from breaking if something does (Caused when mod tries to get strings from json that don't exist and then just ends up breaking everything). Disable a patched function by returning true if an exception happens there, will then use original game code.
 * - Options->Sandbox icons names (Can't seem to get the dropdown data inside of the gameObject it's linked to - keeps saying 0 elements but when viewed manually in UnityExplorer it shows them)
 * 
 *  -- STUFF REPORTED BY ULL TEAM --
 * 
 *  -- FOR NEXT HOTFIX --
 * Fix up errors and typos in English template that are reported
 * UltraTweaker not always being detected for cross-mod fix? (tentative fix, shall need to monitor)
 * Finish audio dubbing documentation
 * 
 * */

namespace UltrakULL
{
    [UKPlugin(internalName, "UltrakULL (Ultrakill Language Library)", internalVersion,"A localization and translation plugin for ULTRAKILL. Created by Clearwater.", true,false)]

    public class MainPatch : UKMod
    {

        public static MainPatch instance = null;
        private GameObject ultrakullLogo = null;
        
        private bool ready = false;
        private bool updateAvailable = false;
        private bool updateFailed = false;
        
        public Font vcrFont;

        public const string internalName = "clearwater.ultrakull.ultrakULL";
        public const string internalVersion = "1.1.0";
        
        private static readonly HttpClient client = new HttpClient();

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
                Debug.Log(e.ToString());
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
                Debug.Log("Failed to patch death screen");
                Console.WriteLine(e.ToString());
            }
        }

        public void initJsonParser()
        {
            LanguageManager.InitializeManager(internalVersion);
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


        public void addModCredits(GameObject frontEnd)
        {
            Text creditsFirst = getTextfromGameObject(getGameObjectChild(getGameObjectChild(frontEnd, "Credits"), "Text (1)"));
            Text creditsSecond = getTextfromGameObject(getGameObjectChild(getGameObjectChild(frontEnd, "Credits"), "Text (2)"));

            creditsFirst.text =
                LanguageManager.CurrentLanguage.credits.credits_title + "\n\n"
                + LanguageManager.CurrentLanguage.credits.credits_createdBy + "\n\n"

                + LanguageManager.CurrentLanguage.credits.credits_helpedByTitle + "\n\n"

                + LanguageManager.CurrentLanguage.credits.credits_helpedBy1 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_helpedBy2 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_helpedBy3 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_helpedBy4 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_helpedBy5 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_helpedBy6 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_helpedBy7 + "\n\n\n\n"

                + LanguageManager.CurrentLanguage.credits.credits_contributionsTitle + "\n\n"
                + LanguageManager.CurrentLanguage.credits.credits_contributions1 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_contributions2 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_contributions3 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_contributions4 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_contributions5 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_contributions6 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_contributions7 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_contributions8 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_contributions9 + "\n";

            creditsSecond.text =  "\n" 
                + LanguageManager.CurrentLanguage.credits.credits_VATitle + "\n\n"

                + LanguageManager.CurrentLanguage.credits.credits_VA1 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_VA2 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_VA3 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_VA4 + "\n\n\n\n\n\n\n"

                + LanguageManager.CurrentLanguage.credits.credits_QATitle + "\n\n"
                + LanguageManager.CurrentLanguage.credits.credits_QA1 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_QA2 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_QA3 + "\n"
                + LanguageManager.CurrentLanguage.credits.credits_QA4 + "\n";
            
            Text creditsBackButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(frontEnd, "Credits"),"Back (1)"),"Text"));
            creditsBackButton.text = LanguageManager.CurrentLanguage.shop.shop_back;

        }

        //Most of the hook logic and checks go in this function.
        public void onSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (!this.ready || LanguageManager.CurrentLanguage == null)
            {
                Debug.Log("Not ready for patching");
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
                        Debug.Log("Failed to hook into main menu.");
                    }
                    else
                    {
                        patchFrontEnd(frontEnd);

                        if (ultrakullLogo != null)
                            GameObject.Destroy(ultrakullLogo);
                        ultrakullLogo = GameObject.Instantiate(getGameObjectChild(getGameObjectChild(getGameObjectChild(frontEnd, "Main Menu (1)"), "Title"), "Text"), frontEnd.transform);
                        ultrakullLogo.transform.localPosition = new Vector3(1075, 210, 0);
                        Text ultrakullLogoText = getTextfromGameObject(ultrakullLogo);
                        ultrakullLogoText.text = "ultrakULL loaded.\nVersion: " + internalVersion + "\nCurrent locale: " + LanguageManager.CurrentLanguage.metadata.langName;
                        ultrakullLogoText.alignment = TextAnchor.UpperLeft;
                        ultrakullLogoText.fontSize = 16;
                        
                        //Get the font
                        this.vcrFont = ultrakullLogoText.font;

                        if(updateAvailable)
                        {
                            ultrakullLogoText.text += "\n<color=lime>UPDATE AVAILABLE!</color>";
                            
                            //Make an update button
                            GameObject buttonBase= getGameObjectChild(getGameObjectChild(getGameObjectChild(frontEnd,"Main Menu (1)"),"Panel"),"Youtube");
                            
                            GameObject ultrakullUpdateButton = GameObject.Instantiate(buttonBase,buttonBase.transform.parent);
                            ultrakullUpdateButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(185, 0f);
                            ultrakullUpdateButton.GetComponentInChildren<Image>().color = new Color(0,1,0,1);
                            ultrakullUpdateButton.GetComponentInChildren<Text>().text = "VIEW UPDATE";
                            ultrakullUpdateButton.GetComponentInChildren<WebButton>().url = "https://github.com/ClearwaterTM/UltrakULL/releases/latest";

                        }
                        if (!LanguageManager.FileMatchesMinimumRequiredVersion(LanguageManager.CurrentLanguage.metadata.minimumModVersion, internalVersion))
                        {
                            ultrakullLogoText.text += "\n<color=orange>Outdated language\nloaded.\nCheck console and\nuse at your own risk!</color>";
                        }
                        else if (!(updateAvailable) && updateFailed)
                        {
                            ultrakullLogoText.text += "\n<color=red>Unable to check for updates. Check console for info.</color>";
                        }

                        this.addModCredits(frontEnd);
                    }
                }
                else if (currentLevel.name.Contains("P-"))
                {
                    Console.WriteLine("Hooking into prime levels");
                    //Prime sanctum level hook
                    GameObject coreGame = GameObject.Find("Prime FirstRoom");
                    if (coreGame == null)
                    {
                        Console.WriteLine("Failed to hook into Prime levels.");
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
                            patchShop(ref coreGame);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Failed to patch in-game elements (prime).");
                            Console.WriteLine(e.ToString());
                        }
                        Options options = new Options(ref coreGame);
                        PrimeSanctum primeSanctumClass = new PrimeSanctum(ref coreGame);
                    }
                }
                else if (currentLevel.name.Contains("-S"))
                {
                    //Potential problem here - we're hooking via Secret FirstRoom, but the words are swapped between secret levels...
                    GameObject coreGame = getInactiveRootObject("Canvas");
                    if (coreGame == null)
                    {
                        Debug.Log("Failed to hook into secret level.");
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
                        Debug.Log("Failed to hook into sandbox.");
                    }
                    else
                    {
                        patchPauseMenu(ref coreGame);
                        patchCheats(ref coreGame);
                        patchShop(ref coreGame);
                        patchDeathScreen(ref coreGame);
                        patchMisc(ref coreGame);
                        Options options = new Options(ref coreGame);
                        Sandbox sandbox = new Sandbox();
                    }
                }
                else
                //General in-level hook
                {
                    GameObject coreGame = GameObject.Find("FirstRoom");
                    if (coreGame == null)
                    {
                        Debug.Log("Failed to hook into in-game elements.");
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
                            Debug.Log("Failed to patch in-game elements.");
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
                            //if (UKAPI.CanSubmitCybergrindScore)
                            //{
                            //    Console.WriteLine("Should be able to submit CG highscores");
                            //}
                            //else
                            //{
                            //    Console.WriteLine(("UNABLE TO SUBMIT CYBERGRIND HIGHSCORE, THIS SHOULDN'T BE HAPPENING UNLESS IF ANOTHER MOD HAS DISABLED IT OR SOMETHING ELSE HAPPENED."));
                            //    Console.WriteLine(UKAPI.CanSubmitCybergrindScore);    
                            //}
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

            //Bunch of things the mod should do *after* loading to avoid problems.
            PostInitPatches(getInactiveRootObject("Canvas"));

        }

        public void PostInitPatches(GameObject frontEnd)
        {
            StartCoroutine(applyPostFixes(frontEnd));
        }

        public IEnumerator applyPostFixes(GameObject frontEnd)
        {
            yield return new WaitForSeconds(0.05f);

            //Open Language Folder button in Options->Langauge
            Text openLangFolderText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(frontEnd,"OptionsMenu"), "Language Page"),"Scroll Rect (1)"),"Contents"),"OpenLangFolder"),"Slot Text"));
            openLangFolderText.text = LanguageManager.CurrentLanguage.options
            .language_openLanguageFolder;

            //Get the mods/restart buttons...
            GameObject ummModsButton = null;
            GameObject ummRestartButton = null;

            if(SceneManager.GetActiveScene().name == "Main Menu")
            {
                GameObject titleObject = getGameObjectChild(frontEnd, "Main Menu (1)");

                foreach (Transform a in titleObject.GetComponentsInChildren<Transform>())
                {
                    if(a.name == "Continue(Clone)")
                    {
                        Text ummButton = getTextfromGameObject(getGameObjectChild(a.gameObject, "Text"));
                        switch(ummButton.text)
                        {
                            case "MODS":
                            {
                                a.name = "ModsButton";
                                ummModsButton = a.gameObject;
                                break;
                            }
                            case "RESTART":
                            {
                                a.name = "RestartButton";
                                ummRestartButton = a.gameObject;
                                break;
                            }
                        }
                    }
                }
            }
            
            //...and from here we can translate the UMM buttons.
            if(ummModsButton && ummRestartButton)
            {
                Text ummModsText = getTextfromGameObject(getGameObjectChild(ummModsButton,"Text"));
                ummModsText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_mods;
                
                Text ummRestartText = getTextfromGameObject(getGameObjectChild(ummRestartButton,"Text"));
                ummRestartText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_restart;
            }

            //Check for any other mods that are loaded that might cause conflicts. If so, apply cross-mod patches and changes.
            Console.WriteLine("Scanning for mods...");

            ModInformation[] loadedMods = UKAPI.AllLoadedModInfoClone.Values.ToArray();
            foreach (ModInformation mod in loadedMods)
            {
                if (mod.modName.ToLower() == "ultrakilltweaker" || mod.modName == "ULTRAKILLtweaker") //Experimental to see if it helps with reports of it not working for some people
                {
                    Console.WriteLine("UltraTweaker detected, applying options patch");
                    StartCoroutine(UltraTweakerPatch());
                }
            }
        }
        
        public async Task checkForUpdates()
        {
            client.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            client.Timeout = TimeSpan.FromSeconds(5);
            string updateUrl = "https://api.github.com/repos/clearwatertm/ultrakull/releases/latest";
            try
            {
                string responseJsonRaw = await client.GetStringAsync(updateUrl);
                
                UpdateInfo responseJson = JsonConvert.DeserializeObject<UpdateInfo>(responseJsonRaw);
                Console.WriteLine("Latest version on GitHub: " + responseJson.tag_name.Substring(1));
                Console.WriteLine("Current local version: " + internalVersion);
                
                Version onlineVersion = new Version(responseJson.tag_name.Substring(1));
                Version localVersion = new Version(internalVersion);
                
                switch(localVersion.CompareTo(onlineVersion))
                {
                    case -1: {Console.WriteLine("NEWER VERSION AVAILABLE ON GITHUB!");this.updateAvailable = true; break;}
                    default: {Console.WriteLine("No newer version detected. Assuming current version is up to date."); this.updateAvailable = false;break;}
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to acquire version info from GitHub.");
                Console.WriteLine(e.ToString()); 
                updateAvailable = false;
                updateFailed = true;
            }

            
        }

        //Entry point for the mod.
        public void Awake()
        {
            Debug.unityLogger.filterLogType = LogType.Exception;
            Debug.Log("UltrakULL LOADING...");
            Debug.Log("Version: " + internalVersion);
            try
            {
            
            
                Debug.Log("--- Checking for updates ---");
                checkForUpdates();
            
                Debug.Log("--- Initializing JSON parser ---");
                initJsonParser();
                Debug.Log("--- Patching vanilla game functions ---");
                Debug.Log("Patching game functions...");
                Harmony harmony = new Harmony(internalName);
                harmony.PatchAll();

                Debug.Log(" --- All done. Enjoy! ---");

                SceneManager.sceneLoaded += onSceneLoaded;
                
                this.ready = true;
            }
            catch (Exception e)
            {
                Debug.Log("An error occured while initialising.");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
