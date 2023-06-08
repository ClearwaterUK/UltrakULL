using HarmonyLib;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UltrakULL.json;
using BepInEx;
using static UltrakULL.CommonFunctions;
using System.Reflection;

/*
 *	UltrakULL (Ultrakill Language Library)
 *	Written by Clearwater, additional code contributions by Temperz87 and CoatlessAli, translations by UltrakULL Translation Team
 *	Date started: 21st April 2021
 *	Last updated: 28th May 2023
 *	
 *	A translation mod for Ultrakill that hooks into the game and allows for text/string replacement. This tool is primarily meant to assist with language translation.
 * 
 *  -- MAIN TASK LIST --
 * 
 *  -- STUFF FOR FUTURE UPDATES --
 *  - Swap out rank textures in HUD for translation (there's a mod already for this, shall look into)
 *  - Finish audio dubbing documentation
 *  - Swap audio file format for dubbing from .wav to .ogg, will reduce overall mod size.
 *  
 *  -- FOR NEXT HOTFIX --
 * Make language button disappear like other option buttons when save menu is opened
 * Add authors of current language loaded into credits book
 * CG: High score disable warning when using custom patterns (https://cdn.discordapp.com/attachments/1029506724035575928/1112482795638497351/Screenshot_2.png)
 * Fishing guide terminal sometimes not translated (doesn't translate when first appears, second time is fine)
 * "Unlocked" string in CG jukebox not translated
 * Update custom font
 *
 *- REPORTED BY USERS
 * 
 * Some of MDK/Owl's lines are still borked
 * 
 * */

namespace UltrakULL
{
    [BepInPlugin(Guid, InternalName, InternalVersion)]
    public class MainPatch : BaseUnityPlugin
    {
        private const string Guid = "clearwater.ultrakill.ultrakull";
        private const string InternalName = "clearwater.ultrakull.ultrakULL";
        private const string InternalVersion = "1.2.0";

        public static MainPatch Instance;
        public GameObject ultrakullLogo;
        
        public bool ready;
        public bool updateAvailable;
        public bool updateFailed;
        public static bool GlobalFontReady;
        
        public static Font VcrFont;
        private static readonly HttpClient Client = new HttpClient();
        
        public static Font GlobalFont;

        public static string ModFolder => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public MainPatch()
        {
            Instance = this;

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
            GameObject classicHudBw = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "Crosshair Filler"), "AltHud"), "Filler");
            GameObject classicHudColor = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "Crosshair Filler"), "AltHud (2)"), "Filler");

            Text classicHudBwHealth = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Health"), "Title"));
            Text classicHudBwHealthShow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Health"), "Title (1)"));
            Text classicHudColorHealth = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Health"), "Title"));
            Text classicHudColorHealthShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Health"), "Title (1)"));
            classicHudBwHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudColorHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudBwHealthShow.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudColorHealthShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_health;

            Text classicHudBwStamina = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Stamina"), "Title"));
            Text classicHudColorStamina = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Stamina"), "Title"));
            Text classicHudBwStaminaShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Stamina"), "Title (1)"));
            Text classicHudColorStaminaShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Stamina"), "Title (1)"));
            classicHudBwStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudColorStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudBwStaminaShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudColorStaminaShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;

            Text classicHudBwWeapon = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Weapon"), "Title"));
            Text classicHudColorWeapon = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Weapon"), "Title"));
            Text classicHudBwWeaponShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Weapon"), "Title (1)"));
            Text classicHudColorWeaponShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Weapon"), "Title (1)"));
            classicHudBwWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudColorWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudBwWeaponShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudColorWeaponShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;

            Text classicHudBwArm = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Arm"), "Title"));
            Text classicHudColorArm = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Arm"), "Title"));
            Text classicHudBwArmShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Arm"), "Title (1)"));
            Text classicHudColorArmShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Arm"), "Title (1)"));
            classicHudBwArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudColorArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudBwArmShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudColorArmShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;

            Text classicHudBwRailcannon = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "RailcannonMeter (1)"), "Title"));
            Text classicHudColorRailcannon = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "RailcannonMeter"), "Title"));
            Text classicHudBwRailcannonShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "RailcannonMeter (1)"), "Title (1)"));
            Text classicHudColorRailcannonShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "RailcannonMeter"), "Title (1)"));
            classicHudBwRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudColorRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudBwRailcannonShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudColorRailcannonShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;

            //Close prompt when reading book
            TextBinds bookPanelBinds = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "ScanningStuff"), "ReadingScanned"), "Panel"), "Text (1)").GetComponent<TextBinds>();
            bookPanelBinds.text1 = LanguageManager.CurrentLanguage.books.books_pressToClose1 + " <color=orange>";
            bookPanelBinds.text2 = "</color> " + LanguageManager.CurrentLanguage.books.books_pressToClose2;



        }
        
        //Most of the hook logic and checks go in this function.
        public void onSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (!this.ready || LanguageManager.CurrentLanguage == null)
            {
                Logging.Error("UltrakULL has been deactivated to prevent crashing. Check the console for any errors!");
            }
            else
            {
                Logging.Message("Switching scenes...");
                string levelName = GetCurrentSceneName();
                
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
                            try
                            {
                                VcrFont = GameObject.Find(canvasObj.name + "/Main Menu (1)/Title/Text").GetComponentInParent<Text>().font;
                            }
                            catch (Exception e)
                            {
                                Logging.Warn("VCR font already defined");
                            }
                            
                            
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
                            VcrFont = ultrakullLogoText.font;

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
                                ultrakullLogoText.text += "\n<color=orange>Language version\noutdated.\nPlease update the\nlanguage file\nif one is available!</color>";
                            }
                            //Warn of a failed updated check
                            else if (!(updateAvailable) && updateFailed)
                            {
                                ultrakullLogoText.text += "\n<color=red>Unable to check for updates.\nCheck console for info.</color>";
                            }
                            
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
                                else if (levelName.Contains("-S"))
                                {
                                    Logging.Message("Secret");
                                    SecretLevels secretLevels = new SecretLevels(ref canvasObj);
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
                                    PrimeSanctum primeSanctumClass = new PrimeSanctum();
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
                                    DevMuseum devMuseum = new DevMuseum();
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
            if (GetCurrentSceneName() == "Main Menu")
            {
                 yield return new WaitForSeconds(0.50f);
                 
            //Open Language Folder button in Options->Langauge
            
            Text openLangFolderText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(frontEnd,"OptionsMenu"), "Language Page"),"Scroll Rect (1)"),"Contents"),"OpenLangFolder"),"Slot Text"));
            openLangFolderText.text = "<color=#03fc07>Open language folder</color>";

            //Get the mods/restart buttons...
            GameObject ummModsButton = null;
            GameObject ummRestartButton = null;

            
            if(GetCurrentSceneName() == "Main Menu")
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

            /*ModInformation[] loadedMods = UKAPI.AllLoadedModInfoClone.Values.ToArray();
            foreach (ModInformation mod in loadedMods)
            {
                if (mod.modName.ToLower() == "ultrakilltweaker" || mod.modName == "ULTRAKILLtweaker") //Experimental to see if it helps with reports of it not working for some people
                {
                    Logging.Info("UltraTweaker detected, applying options patch");
                    StartCoroutine(UltraTweakerPatch());
                }
            }*/
            }
           
        }
        
        private async Task CheckForUpdates()
        {
            string updateUrl = "https://api.github.com/repos/clearwateruk/ultrakull/releases/latest";
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
        
        public void LoadFonts()
        {
            Logging.Warn("Loading font resource bundle...");
            //Will file from the same directory that the dll is in.
            AssetBundle fontBundle = AssetBundle.LoadFromFile(Path.Combine(MainPatch.ModFolder,"ullfont.resource"));

            if(fontBundle == null)
            {
                Logging.Error("FAILED TO LOAD");
            }
            else
            {
                Logging.Warn("Font bundle loaded.");
                Logging.Warn("Loading fonts from bundle...");
                
                Font loadedFont = fontBundle.LoadAsset<Font>("VCR_OSD_MONO");
                if(loadedFont == null)
                {
                    Logging.Error("FAILED TO LOAD FONT");
                }
                else
                {
                    Logging.Warn("Font loaded.");
                    GlobalFont = loadedFont;
                    GlobalFontReady = true;
                }
            }
                
            
        }

        //Entry point for the mod.
        private void Awake()
        {
            Debug.unityLogger.filterLogType = LogType.Exception;

            Logging.Warn("UltrakULL Loading... | Version v." + InternalVersion);
            try
            {
                Logging.Warn("--- Checking for updates ---");
                #pragma warning disable 4014
                CheckForUpdates();
                
                Logging.Warn("--- Loading external fonts ---");
                LoadFonts();
            
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
