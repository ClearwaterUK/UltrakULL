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
using System.Linq;

using static UltrakULL.CommonFunctions;
using static UltrakULL.ModPatches;
using UMM;

/*
 *	UltrakULL (Ultrakill Language Library)
 *	Written by Clearwater, additional code contributions by Temperz87, translations by UltrakULL Translation Team
 *	Date started: 21st April 2021
 *	Last updated: 23rd December 2022
 *	
 *	This is a translation mod for Ultrakill that hooks into the game and allows for text/string replacement.
 *	This tool is primarily meant to assist with language translation.
 * 
 *  -- MAIN TASK LIST --
 *  - Add ULL credits, translation credits to main menu with help of UKUIHelper library
 *  - Error and exception handling
 *  - Divide up more stuff in try/catch functions (especially the shop), that way less stuff breaks if something bad happens
 * 
 *  -- STUFF FOR FUTURE UPDATES --
 *  - Next game update scheduled for early 2023. P-2, 5-S, radient enemies, rumble support and green rocket launcher
 *  - Swap out rank textures in HUD for translation
 *  - Replace the default font with a version that has better special char + cyrillic support
 *  - Finish audio dubbing documentation
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
 *
 *
 * P-2 UPDATE DAMAGE REPORT
 *
 * ALL MODS ARE BROKEN. WILL NEED TO WAIT FOR UMM FIXES.
 * Credits shuffled to actual leveL. Current credits stuff on main menu will need to be moved to a new class.
 * P-2 stuff, 5-S stuff.
 * Rumble support and other new options.
 * New sandbox settings.
 * Green R.
 *
 *
 *Intro:
 * Loading message no longer appears, get rid of that
 * 
 * Main menu:
 * ApplyPostFixes error
 * PatchLoadingWindow error
 * 
 * */

namespace UltrakULL
{
    [UKPlugin(InternalName, "UltrakULL (Ultrakill Language Library)", InternalVersion,"A localization and translation plugin for ULTRAKILL. Created by Clearwater.", true,false)]

    public class MainPatch : UKMod
    {
        public static MainPatch instance;
        public GameObject ultrakullLogo;
        
        public bool ready;
        public bool updateAvailable;
        public bool updateFailed;
        
        public Font vcrFont;

        private const string InternalName = "clearwater.ultrakull.ultrakULL";
        private const string InternalVersion = "1.1.1";
        
        private static readonly HttpClient Client = new HttpClient();
        

        public MainPatch()
        {
            instance = this;

        }

        public void OnApplicationQuit()
        {
            LanguageManager.DumpLastLanguage();
        }

        public void DisableMod()
        {
            this.ready = false;
        }

        //Patches all text strings in the pause menu.
        public void PatchPauseMenu(ref GameObject canvasObj)
        {
            try
            {
                GameObject pauseMenu = GetGameObjectChild(canvasObj, "PauseMenu");

                //Title
                Text pauseText = GetTextfromGameObject(GetGameObjectChild(pauseMenu, "Text"));
                pauseText.text = "-- " + LanguageManager.CurrentLanguage.pauseMenu.pause_title + " --";

                //Resume
                Text continueText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Resume"), "Text"));
                continueText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_resume;

                //Checkpoint
                Text checkpointText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Restart Checkpoint"), "Text"));
                checkpointText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_respawn;

                //Restart mission
                Text restartText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Restart Mission"), "Text"));
                restartText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restart;

                //Options
                Text optionsText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Options"), "Text"));
                optionsText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_options;

                //Quit
                Text quitText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Quit Mission"), "Text"));
                quitText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quit;

                //Quit+Restart windows
                GameObject pauseDialogs = GetGameObjectChild(canvasObj, "PauseMenuDialogs");

                //Quit
                GameObject quitDialog = GetGameObjectChild(GetGameObjectChild(pauseDialogs, "Quit Confirm"), "Panel");
                Text quitDialogText = GetTextfromGameObject(GetGameObjectChild(quitDialog, "Text"));
                quitDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirm;

                Text quitDialogTooltip = GetTextfromGameObject(GetGameObjectChild(quitDialog, "Text (1)"));
                quitDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

                Text quitDialogYes = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(quitDialog, "Confirm"), "Text"));
                quitDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmYes;

                Text quitDialogNo = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(quitDialog, "Cancel"), "Text"));
                quitDialogNo.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmNo;

                //Restart
                GameObject restartDialog = GetGameObjectChild(GetGameObjectChild(pauseDialogs, "Restart Confirm"), "Panel");

                Text restartDialogText = GetTextfromGameObject(GetGameObjectChild(restartDialog, "Text"));
                restartDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirm;

                Text restartDialogTooltip = GetTextfromGameObject(GetGameObjectChild(restartDialog, "Text (1)"));
                restartDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

                Text restartDialogYes = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(restartDialog, "Confirm"), "Text"));
                restartDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirmYes;

                Text restartDialogNo = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(restartDialog, "Cancel"), "Text"));
                restartDialogNo.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirmNo;
            }
            catch (Exception e)
            {
                Logging.Error("Failed to patch pause menu.");
                Logging.Error(e.ToString());
            }
        }

        public void PatchCheats(ref GameObject canvasObj)
        {
            Cheats.PatchCheatConsentPanel(ref canvasObj);
        }

        public void PatchDeathScreen(ref GameObject canvasObj)
        {
            try
            {
                GameObject deathScreen = GetGameObjectChild(GetGameObjectChild(canvasObj, "BlackScreen"), "YouDiedText");
                //Need to disable the TextOverride component.
                Component[] test = deathScreen.GetComponents(typeof(Component));
                Behaviour bhvr = (Behaviour)test[3];
                bhvr.enabled = false;

                Text youDiedText = GetTextfromGameObject(deathScreen);
                youDiedText.text = LanguageManager.CurrentLanguage.misc.youDied1 + "\n\n\n\n\n" + LanguageManager.CurrentLanguage.misc.youDied2;
            }
            catch (Exception e)
            {
                Logging.Error("Failed to patch death screen");
                Logging.Error(e.ToString());
            }
        }

        public void InitJsonParser()
        {
            LanguageManager.InitializeManager(InternalVersion);
        }

        //Encapsulation function to patch the shop.
        public void PatchShop(ref GameObject canvasObj)
        {
            Shop.PatchShop(ref canvasObj);
        }

        public void PatchLevelStats(ref GameObject canvasObj)
        {
            LevelStatWindow.PatchStats(ref canvasObj);
        }

        //Encapsulation function to patch all of the front end.
        public void PatchFrontEnd(GameObject frontEnd)
        {
            MainMenu.Patch(frontEnd);
            Options options = new Options(ref frontEnd);
        }

        public void PatchMisc(ref GameObject canvasObj)
        {
            GameObject player = GameObject.Find("Player");
            GameObject styleMeter = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(player, "Main Camera"), "HUD Camera"), "HUD"), "StyleCanvas"), "Panel (1)"), "Panel"), "Text (1)"), "Text");
            Text styleMeterMultiplierText = GetTextfromGameObject(styleMeter);
            styleMeterMultiplierText.text = LanguageManager.CurrentLanguage.style.stylemeter_multiplier;
            
            GameObject pressToSkip = GetGameObjectChild(canvasObj, "CutsceneSkipText");

            //Need to disable the TextOverride component.
            Component[] test = pressToSkip.GetComponents(typeof(Component));
            Behaviour bhvr = (Behaviour)test[4];
            bhvr.enabled = false;

            Text pressToSkipText = GetTextfromGameObject(pressToSkip);
            pressToSkipText.text = LanguageManager.CurrentLanguage.misc.pressToSkip;

            //Classic HUD
            GameObject classicHudBW = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "Crosshair Filler"), "AltHud"), "Filler");
            GameObject classicHudColor = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "Crosshair Filler"), "AltHud (2)"), "Filler");

            Text classicHudBWHealth = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBW, "Health"), "Title"));
            Text classicHudBWHealthShow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBW, "Health"), "Title (1)"));
            Text classicHudColorHealth = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Health"), "Title"));
            Text classicHudColorHealthShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Health"), "Title (1)"));
            classicHudBWHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudColorHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudBWHealthShow.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudColorHealthShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_health;

            Text classicHudBWStamina = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBW, "Stamina"), "Title"));
            Text classicHudColorStamina = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Stamina"), "Title"));
            Text classicHudBWStaminaShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBW, "Stamina"), "Title (1)"));
            Text classicHudColorStaminaShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Stamina"), "Title (1)"));
            classicHudBWStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudColorStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudBWStaminaShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudColorStaminaShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;

            Text classicHudBWWeapon = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBW, "Weapon"), "Title"));
            Text classicHudColorWeapon = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Weapon"), "Title"));
            Text classicHudBWWeaponShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBW, "Weapon"), "Title (1)"));
            Text classicHudColorWeaponShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Weapon"), "Title (1)"));
            classicHudBWWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudColorWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudBWWeaponShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudColorWeaponShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;

            Text classicHudBWArm = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBW, "Arm"), "Title"));
            Text classicHudColorArm = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Arm"), "Title"));
            Text classicHudBWArmShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBW, "Arm"), "Title (1)"));
            Text classicHudColorArmShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Arm"), "Title (1)"));
            classicHudBWArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudColorArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudBWArmShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudColorArmShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;

            Text classicHudBWRailcannon = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBW, "RailcannonMeter (1)"), "Title"));
            Text classicHudColorRailcannon = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "RailcannonMeter"), "Title"));
            Text classicHudBWRailcannonShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBW, "RailcannonMeter (1)"), "Title (1)"));
            Text classicHudColorRailcannonShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "RailcannonMeter"), "Title (1)"));
            classicHudBWRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudColorRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudBWRailcannonShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudColorRailcannonShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;

            //Close prompt when reading book
            TextBinds bookPanelBinds = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "ScanningStuff"), "ReadingScanned"), "Panel"), "Text (1)").GetComponent<TextBinds>();
            bookPanelBinds.text1 = LanguageManager.CurrentLanguage.books.books_pressToClose1 + " <color=orange>";
            bookPanelBinds.text2 = "</color> " + LanguageManager.CurrentLanguage.books.books_pressToClose2;



        }


        public void addModCredits(GameObject frontEnd)
        {
            Text creditsFirst = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(frontEnd, "Credits"), "Text (1)"));
            Text creditsSecond = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(frontEnd, "Credits"), "Text (2)"));

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
            
            Text creditsBackButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(frontEnd, "Credits"),"Back (1)"),"Text"));
            creditsBackButton.text = LanguageManager.CurrentLanguage.shop.shop_back;

        }

        //Most of the hook logic and checks go in this function.
        public void onSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (!this.ready || LanguageManager.CurrentLanguage == null)
            {
                Logging.Error("UltrakULL has been deactivated to prevent crashing. Check the console for any errors!");
                return;
            }
            else
            {
                Logging.Message("Switching scenes...");
                Scene currentLevel = SceneManager.GetActiveScene();
                string levelName = currentLevel.name;

                if (Harmony_Patches.InjectLanguageButton.languageButtonText != null)
                {
                    Harmony_Patches.InjectLanguageButton.languageButtonText.text = LanguageManager.CurrentLanguage.options.language_languages;
                    Harmony_Patches.InjectLanguageButton.languageButtonTitleText.text = "--" + LanguageManager.CurrentLanguage.options.language_title + "--";
                }
                //Each scene (level) has an object called Canvas. Most game objects are there.
                GameObject canvasObj = GetInactiveRootObject("Canvas");
                if (!canvasObj)
                {
                    Logging.Fatal("UNABLE TO FIND CANVAS IN CURRENT SCENE");
                    return;
                }
                else
                {
                    switch(levelName)
                    {
                        case "Intro": { break; }
                        case "Main Menu":
                        {
                            PatchFrontEnd(canvasObj);
                            
                            //(Re)render the UltrakULL status on screen when a language has been (re)loaded.
                            if (ultrakullLogo != null) {GameObject.Destroy(ultrakullLogo);}
                            ultrakullLogo = GameObject.Instantiate(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "Main Menu (1)"), "Title"), "Text"), canvasObj.transform);
                            ultrakullLogo.transform.localPosition = new Vector3(1075, 210, 0);
                            Text ultrakullLogoText = GetTextfromGameObject(ultrakullLogo);
                            ultrakullLogoText.text = "ultrakULL loaded.\nVersion: " + InternalVersion + "\nCurrent locale: " + LanguageManager.CurrentLanguage.metadata.langName;
                            ultrakullLogoText.alignment = TextAnchor.UpperLeft;
                            ultrakullLogoText.fontSize = 16;
                            
                            //Get the font so it can applied to any generated buttons
                            this.vcrFont = ultrakullLogoText.font;

                            //Add notif if there's a mod update available
                            if(updateAvailable)
                            {
                                ultrakullLogoText.text += "\n<color=lime>UPDATE AVAILABLE!</color>";
                                
                                //Make an update button
                                GameObject buttonBase= GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj,"Main Menu (1)"),"Panel"),"Youtube");
                                
                                GameObject ultrakullUpdateButton = GameObject.Instantiate(buttonBase,buttonBase.transform.parent);
                                ultrakullUpdateButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(185, 0f);
                                ultrakullUpdateButton.GetComponentInChildren<Image>().color = new Color(0,1,0,1);
                                ultrakullUpdateButton.GetComponentInChildren<Text>().text = "VIEW UPDATE";
                                ultrakullUpdateButton.GetComponentInChildren<WebButton>().url = "https://github.com/ClearwaterTM/UltrakULL/releases/latest";
                            }
                            //Warn of a language that doesn't match the mod version
                            if (!LanguageManager.FileMatchesMinimumRequiredVersion(LanguageManager.CurrentLanguage.metadata.minimumModVersion, InternalVersion))
                            {
                                ultrakullLogoText.text += "\n<color=orange>Outdated language\nloaded.\nCheck console and\nuse at your own risk!</color>";
                            }
                            //Warn of a failed updated check
                            else if (!(updateAvailable) && updateFailed)
                            {
                                ultrakullLogoText.text += "\n<color=red>Unable to check for updates. Check console for info.</color>";
                            }

                            this.addModCredits(canvasObj);
                            break;
                        }

                        default:
                        {
                            Logging.Message("Regular scene");
                            try
                            {
                                Logging.Message("Attempting to patch base elements");
                                PatchPauseMenu(ref canvasObj);
                                PatchCheats(ref canvasObj);
                                PatchDeathScreen(ref canvasObj);
                                PatchLevelStats(ref canvasObj);
                                PatchMisc(ref canvasObj);
                                PatchShop(ref canvasObj);
                                Options options = new Options(ref canvasObj);
                                Logging.Message("Base elements patched");
                            }
                            catch (Exception e)
                            {
                               Logging.Error("Something went wrong while patching base elements.");
                               Logging.Error(e.ToString());
                            }
                            finally
                            {
                                if (levelName.Contains("Tutorial"))
                                {
                                    Logging.Message("Tutorial");
                                }
                                if(levelName.Contains("0-"))
                                {
                                    Logging.Message("Prelude");
                                    Prelude preludePatchClass = new Prelude(ref canvasObj);
                                }
                                else if(levelName.Contains("1-") || levelName.Contains("2-") || levelName.Contains("3-"))
                                {
                                    Logging.Message("Act 1");
                                    Act1.PatchAct1(ref canvasObj);
                                }
                                else if(levelName.Contains("4-") || levelName.Contains("5-") || levelName.Contains("6-"))
                                {
                                    Logging.Message("Act 2");
                                    Act2.PatchAct2(ref canvasObj);
                                }
                                else if (levelName.Contains("P-"))
                                {
                                    Logging.Message("Prime");
                                    PrimeSanctum primeSanctumClass = new PrimeSanctum(ref canvasObj);
                                }
                                else if (levelName.Contains("-S"))
                                {
                                    Logging.Message("Secret");
                                    SecretLevels secretLevels = new SecretLevels(ref canvasObj);
                                }
                                else if (levelName == "uk_construct")
                                {
                                    Logging.Message("Sandbox");
                                    Sandbox sandbox = new Sandbox(ref canvasObj);
                                }
                                else if (levelName == "Endless")
                                {
                                    Logging.Message("CyberGrind");
                                    CyberGrind.PatchCg();
                                }
                                else if (levelName.Contains("Intermission"))
                                {
                                    Logging.Message("Intermission");
                                    Intermission intermission = new Intermission(ref canvasObj);
                                }
                                else if (levelName == "CreditsMuseum2")
                                {
                                    Logging.Message("DevMuseum");
                                    DevMuseum devMuseum = new DevMuseum(ref canvasObj);
                                }

                            }
                            break;
                        }
                    }
                }
                //Bunch of things the mod should do *after* loading to avoid problems.
                PostInitPatches(canvasObj);
            }

        }

        public void PostInitPatches(GameObject frontEnd)
        {
            StartCoroutine(ApplyPostFixes(frontEnd));
        }

        private IEnumerator ApplyPostFixes(GameObject frontEnd)
        {
            Console.WriteLine(SceneManager.GetActiveScene().name);
            Console.WriteLine(SceneManager.GetActiveScene().name == "Main Menu");
            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                 yield return new WaitForSeconds(0.50f);

            Console.WriteLine("init");
            Console.WriteLine(frontEnd.name);
            //Open Language Folder button in Options->Langauge
            
            Text openLangFolderText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(frontEnd,"OptionsMenu"), "Language Page"),"Scroll Rect (1)"),"Contents"),"OpenLangFolder"),"Slot Text"));
            Console.WriteLine("slot text");
            openLangFolderText.text = LanguageManager.CurrentLanguage.options
            .language_openLanguageFolder;

            //Get the mods/restart buttons...
            GameObject ummModsButton = null;
            GameObject ummRestartButton = null;

            
            if(SceneManager.GetActiveScene().name == "Main Menu")
            {
                GameObject titleObject = GetGameObjectChild(frontEnd, "Main Menu (1)");

                foreach (Transform button in titleObject.GetComponentsInChildren<Transform>())
                {
                    if(button.name == "Continue(Clone)")
                    {
                        Text ummButton = GetTextfromGameObject(GetGameObjectChild(button.gameObject, "Text"));
                        switch(ummButton.text)
                        {
                            case "MODS":
                            {
                                button.name = "ModsButton";
                                ummModsButton = button.gameObject;
                                break;
                            }
                            case "RESTART":
                            {
                                button.name = "RestartButton";
                                ummRestartButton = button.gameObject;
                                break;
                            }
                        }
                    }
                }
            }
            
            //...and from here we can translate the UMM buttons.
            if(ummModsButton && ummRestartButton)
            {
                Text ummModsText = GetTextfromGameObject(GetGameObjectChild(ummModsButton,"Text"));
                ummModsText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_mods;
                
                Text ummRestartText = GetTextfromGameObject(GetGameObjectChild(ummRestartButton,"Text"));
                ummRestartText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_restart;
            }

            //Check for any other mods that are loaded that might cause conflicts. If so, apply cross-mod patches and changes.
            Logging.Info("Scanning for mods...");

            ModInformation[] loadedMods = UKAPI.AllLoadedModInfoClone.Values.ToArray();
            foreach (ModInformation mod in loadedMods)
            {
                if (mod.modName.ToLower() == "ultrakilltweaker" || mod.modName == "ULTRAKILLtweaker") //Experimental to see if it helps with reports of it not working for some people
                {
                    Logging.Info("UltraTweaker detected, applying options patch");
                    StartCoroutine(UltraTweakerPatch());
                }
            }
            }
           
        }
        
        private async Task CheckForUpdates()
        {
            string updateUrl = "https://api.github.com/repos/clearwatertm/ultrakull/releases/latest";
            Client.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            Client.Timeout = TimeSpan.FromSeconds(5);
            
            try
            {
                string responseJsonRaw = await Client.GetStringAsync(updateUrl);
                UpdateInfo responseJson = JsonConvert.DeserializeObject<UpdateInfo>(responseJsonRaw);
                
                Logging.Message("Latest version on GitHub: " + responseJson.tag_name.Substring(1));
                Logging.Message("Current local version: " + InternalVersion);
                
                Version onlineVersion = new Version(responseJson.tag_name.Substring(1));
                Version localVersion = new Version(InternalVersion);
                
                switch(localVersion.CompareTo(onlineVersion))
                {
                    case -1: { Logging.Message("NEWER VERSION AVAILABLE ON GITHUB!");this.updateAvailable = true; break;}
                    default: { Logging.Message("No newer version detected. Assuming current version is up to date."); this.updateAvailable = false;break;}
                }
            }
            catch (Exception e)
            {
                Logging.Error("Unable to acquire version info from GitHub.");
                Logging.Error(e.ToString()); 
                updateAvailable = false;
                updateFailed = true;
            }
        }

        //Entry point for the mod.
        public void Awake()
        {
            Debug.unityLogger.filterLogType = LogType.Exception;

            Logging.Warn("UltrakULL Loading... | Version v." + InternalVersion);
            try
            {
                Logging.Warn("--- Checking for updates ---");
                #pragma warning disable 4014
                CheckForUpdates();
            
                Logging.Warn("--- Initializing JSON parser ---");
                InitJsonParser();
                
                Logging.Warn("--- Patching vanilla game functions ---");
                Harmony harmony = new Harmony(InternalName);
                harmony.PatchAll();

                Logging.Warn(" --- All done. Enjoy! ---");
                SceneManager.sceneLoaded += onSceneLoaded;
                this.ready = true;
            }
            catch (Exception e)
            {
                Logging.Fatal("An error occured while initialising!");
                Logging.Fatal(e.ToString());
                this.ready = false;
            }
        }
    }
}
