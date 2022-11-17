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

using System.Linq;
using UltrakULL.json;

using static UltrakULL.CommonFunctions;
using static UltrakULL.ModPatches;

using UMM;

/*
 *	UltrakULL (Ultrakill Language Library)
 *	Written by Clearwater, additional code contributions by Temperz87, translations by UltrakULL Translation Team
 *	Date started: 21st April 2021
 *	Last updated: 13th November 2022
 *	
 *	This is a translation mod for Ultrakill that hooks into the game and allows for text/string replacement.
 *	This tool is primarily meant to assist with language translation.
 * 
 *  -- MAIN TODO LIST --
 *  - Add ULL credits, translation credits to main menu with help of UKUIHelper library
 *  - Error and exception handling
 *  - Divide up more stuff in try/catch functions (especially the shop and options), that way less stuff breaks if something bad happens
 * 
 *  -- LESS IMPORTANT STUFF FOR FUTURE UPDATES --
 *  - Cheat teleport menu
 *  - Terminals before bosses in levels (could copy the shop that's in the start of each level)
 *  - Organise and refactor stuff, move functions to other files to declutter Main (Factorise the act classes with an interface?)
 *  - Look into how I can do encoding for RTL languages such as Arabic
 *  - Port main class so it becomes a native UMM mod instead of BepInEx. With the way its structured, could be able to move config/lang files to same folder.
 *  - Green Rocketlauncher incoming
 *  - Could be possible to swap out rank textures in HUD for translation. Shall look into later
 *  - Attempt to replace the default font with a version that has better special char + cyrillic support
 *  
 *  
 *  -- BUGS AND QUIRKS TO FIX --
 * - Misc keys as strings (comma, period, etc) missing
 * - Inconsistencies with commas in input messages (ex: 0-1 has them but slide in tutorial doesn't)
 * - Add more sanity checks in code to prevent entire mod from breaking if something does (Caused when mod tries to get strings from json that don't exist and then just ends up breaking everything). Disable a patched function by returning true if an exception happens there, will then use original game code.
 * - Intro second page not aligned correctly (dependant on length of words from translation to translation, not really something that can be fixed globally)
 * - Freshness not translated in tutorial (ridiculously minor, I personally don't see a need to patch it but will leave here anyways)
 * 
 * - Options->Sandbox icons names (Can't seem to get the dropdown data inside of the gameObject it's linked to - keeps saying 0 elements but when viewed manually in UnityExplorer it shows them)
 * 
 *  -- STUFF REPORTED BY ULL TEAM --
 * 
 *  -- FOR NEXT HOTFIX --
 *  
 *  Add Russian translation to default languages
 *  Add download buttons to Github readme for finished languages
 * Fix up errors and typos in English template
 * 
 * Update readme with new languages+contributors, update readme to reflect UMM port and new installation guide
 * style_nailbombed typo in templates
 * Jakito uses duplicate/incorrectly swapped lines?
 * Shop: Arms back button not translated
 * Discord RPC: Not using translated difficulty names
 * Assists: enemySilhouettesOutlines not used, using enemySilhouettes twice
 * Crosshair size should be called HUD sized - check original game text
 * Movement category not rendering in cheats? Check templates 
 * Shadows on text not aligning correctly in intermissions
 * Shop: Leviathan title in bio missing
 * 
 * */

namespace UltrakULL
{
    [UKPlugin(pluginName,pluginVersion,pluginDescription,false,false)]

    public class MainPatch : UKMod
    {
        public const string pluginGuid = "clearwater.ultrakill.ultrakULL";
        public const string pluginName = "UltrakULL (Ultrakill Language Library)";
        public const string pluginVersion = "1.0.1";
        public const string pluginDescription = "A localization and translation plugin for ULTRAKILL. Created by Clearwater.";

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

        }


        public IEnumerator patchScene()
        {
            //Wait a bit to allow any other loaded mods to place their GameObjects down so we can manipulate them as need be afterwards.
            yield return new WaitForSeconds(0.10f);

            Console.WriteLine("Beginning patch");

            if (!this.ready || LanguageManager.CurrentLanguage == null)
            {
                Debug.Log("Not ready for patching");
                yield return false;
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
                        ultrakullLogo.transform.localPosition = new Vector3(1025, -425, 0);
                        Text ultrakullLogoText = getTextfromGameObject(ultrakullLogo);
                        ultrakullLogoText.text = "ultrakULL loaded.\nVersion: " + pluginVersion + "\nCurrent locale: " + LanguageManager.CurrentLanguage.metadata.langName;
                        ultrakullLogoText.alignment = TextAnchor.UpperLeft;
                        ultrakullLogoText.fontSize = 16;
                        //Get the font
                        this.vcrFont = ultrakullLogoText.font;

                        if (!LanguageManager.FileMatchesMinimumRequiredVersion(LanguageManager.CurrentLanguage.metadata.minimumModVersion, pluginVersion))
                        {
                            ultrakullLogoText.text += "\n<color=orange>WARNING - Outdated language\nloaded.</color>\nCheck console\n & use at your own risk!";
                            ultrakullLogo.transform.localPosition = new Vector3(1025, -350, 0);
                        }

                        this.addModCredits(frontEnd);
                    }
                }
                else if (currentLevel.name.Contains("P-"))
                {
                    //Prime sanctum level hook
                    GameObject coreGame = GameObject.Find("Prime FirstRoom");
                    if (coreGame == null)
                    {
                        Debug.Log("Failed to hook into Prime levels.");
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
                            Debug.Log("Failed to patch in-game elements (prime).");
                            Debug.Log(e.ToString());
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

            //Check for any other mods that are loaded that might cause conflicts. If so, do some stuff.
            ModInformation[] loadedMods = UKAPI.GetAllLoadedModInformation();
            foreach (ModInformation mod in loadedMods)
            {
                Console.WriteLine(mod.modName);
                if (mod.modName == "ULTRAKILLtweaker")
                {
                    Console.WriteLine("UltraTweaker detected, doing stuff");
                    StartCoroutine(UltraTweakerPatch());
                }
            }
        }



        //Most of the hook logic and checks go in this function.
        public void onSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            StartCoroutine(patchScene());
        }

        //Entry point for the patch.
        public void Awake()
        {
            Debug.unityLogger.filterLogType = LogType.Exception;
            Debug.Log("UltrakULL LOADING...");
            Debug.Log("Version: " + pluginVersion);
            try
            {
                Debug.Log("--- Initializing JSON parser ---");
                initJsonParser();
                Debug.Log("--- Patching vanilla game functions ---");
                Debug.Log("Patching game functions...");
                Harmony harmony = new Harmony(pluginGuid);
                harmony.PatchAll();
                Debug.Log(" --- All done. Enjoy! ---");

                SceneManager.sceneLoaded += onSceneLoaded;
                
                this.ready = true;
            }
            catch (Exception e)
            {
                Debug.Log("An error occured while initialising.");
                Console.WriteLine(e.ToString());
                return;
            }
        }
    }
}
