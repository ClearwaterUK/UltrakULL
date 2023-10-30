using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Core
    {
        public static Font VcrFont;
        public static GameObject ultrakullLogo;
        
        public static bool updateAvailable;
        public static bool updateFailed;
        
        public static bool GlobalFontReady;
        public static Font GlobalFont;
        
        public static bool wasLanguageReset = false;
        
        private static readonly HttpClient Client = new HttpClient();
        
        //Encapsulation function to patch all of the front end.
        public static void PatchFrontEnd(GameObject frontEnd)
        {
            MainMenu.Patch(frontEnd);
            Options options = new Options(ref frontEnd);
        }
        
        public static async Task CheckForUpdates()
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
                Logging.Message("Current local version: " + MainPatch.GetVersion());
                
                Version onlineVersion = new Version(responseJson.tag_name.Substring(1));
                Version localVersion = new Version(MainPatch.GetVersion());
                
                switch(localVersion.CompareTo(onlineVersion))
                {
                    case -1: { Logging.Message("NEWER VERSION AVAILABLE ON GITHUB!"); updateAvailable = true; break;}
                    default: { Logging.Message("No newer version detected. Assuming current version is up to date."); updateAvailable = false;break;}
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
        
        //Patches all text strings in the pause menu.
        public static void PatchPauseMenu(ref GameObject canvasObj)
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
        
        public static void LoadFonts()
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
        
        public static void HandleSceneSwitch(Scene scene,ref GameObject canvas)
        {
            Logging.Message("Switching scenes...");
            string levelName = GetCurrentSceneName();
            if(levelName == "Intro" || levelName == "Bootstrap")
            { 
                Logging.Warn("In intro, not hooking yet");
                return;
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
                        if(Core.wasLanguageReset)
                        {
                            Core.wasLanguageReset = false;
                            MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage("<color=orange>The currently set language file could not be loaded.\nLanguage has been reset to English to avoid problems.</color>");
                        }
                        
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
                        ultrakullLogoText.text = "ultrakULL loaded.\nVersion: " + MainPatch.GetVersion() + "\nCurrent locale: " + LanguageManager.CurrentLanguage.metadata.langName;
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
                        if (!LanguageManager.FileMatchesMinimumRequiredVersion(LanguageManager.CurrentLanguage.metadata.minimumModVersion, MainPatch.GetVersion()))
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
                        Logging.Message("Attempting to patch base elements");
                        PatchPauseMenu(ref canvasObj);
                        Cheats.PatchCheatConsentPanel(ref canvasObj);
                        HUDMessages.PatchDeathScreen(ref canvasObj);
                        LevelStatWindow.PatchStats(ref canvasObj);
                        HUDMessages.PatchMisc(ref canvasObj);
                        Options options = new Options(ref canvasObj);
                        Logging.Message("Base elements patched");
                        }
                        
                        
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
                        break;
                }
            }
        }

        public static async void ApplyPostInitFixes(GameObject canvasObj)
        {
            await Task.Delay(250);
            if (GetCurrentSceneName() == "Main Menu")
            {
                //Open Language Folder button in Options->Langauge
                Text openLangFolderText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj,"OptionsMenu"), "Language Page"),"Scroll Rect (1)"),"Contents"),"OpenLangFolder"),"Slot Text")); 
                openLangFolderText.text = "<color=#03fc07>Open language folder</color>";

                //Get the mods/restart buttons...
                GameObject ummModsButton = null;
                GameObject ummRestartButton = null;

                GameObject titleObject = GetGameObjectChild(canvasObj, "Main Menu (1)");

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
                //...and from here we can translate the UMM buttons.
                if(ummModsButton && ummRestartButton)
                {
                    Text ummModsText = GetTextfromGameObject(GetGameObjectChild(ummModsButton,"Text"));
                    ummModsText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_mods;
                
                    Text ummRestartText = GetTextfromGameObject(GetGameObjectChild(ummRestartButton,"Text"));
                    ummRestartText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_restart;
                }
            }
        }
    }
}