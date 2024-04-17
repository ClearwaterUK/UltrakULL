using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Net.Http;
using System.Threading.Tasks;
using HarmonyLib;
using Newtonsoft.Json;
using TMPro;
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
        public static bool TMPFontReady;
        
        public static Font GlobalFont;
        public static Font MuseumFont;
        public static TMP_FontAsset GlobalFontTMP;
        public static TMP_FontAsset MuseumFontTMP;
        public static TMP_FontAsset CJKFontTMP;
        public static TMP_FontAsset jaFontTMP;
        public static TMP_FontAsset ArabicFontTMP;
		public static TMP_FontAsset HebrewFontTMP;
        public static Sprite[] CustomRankImages;

        public static Sprite ArabicUltrakillLogo;

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
                    case -1: { Logging.Warn("UPDATE AVAILABLE!"); updateAvailable = true; break;}
                    default: { Logging.Warn("No newer version detected. Assuming current version is up to date."); updateAvailable = false;break;}
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
                TextMeshProUGUI pauseText = GetTextMeshProUGUI(GetGameObjectChild(pauseMenu, "Text"));
                pauseText.text = "-- " + LanguageManager.CurrentLanguage.pauseMenu.pause_title + " --";

                //Resume
                TextMeshProUGUI continueText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Resume"), "Text"));
                continueText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_resume;

                //Checkpoint
                TextMeshProUGUI checkpointText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Restart Checkpoint"), "Text"));
                checkpointText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_respawn;

                //Restart mission
                TextMeshProUGUI restartText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Restart Mission"), "Text"));
                restartText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restart;

                //Options
                TextMeshProUGUI optionsText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Options"), "Text"));
                optionsText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_options;

                //Quit
                TextMeshProUGUI quitText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Quit Mission"), "Text"));
                quitText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quit;

                //Quit+Restart windows
                GameObject pauseDialogs = GetGameObjectChild(canvasObj, "PauseMenuDialogs");

                //Quit
                GameObject quitDialog = GetGameObjectChild(GetGameObjectChild(pauseDialogs, "Quit Confirm"), "Panel");
                TextMeshProUGUI quitDialogText = GetTextMeshProUGUI(GetGameObjectChild(quitDialog, "Text (2)"));
                quitDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirm;

                TextMeshProUGUI quitDialogTooltip = GetTextMeshProUGUI(GetGameObjectChild(quitDialog, "Text (1)"));
                quitDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

                TextMeshProUGUI quitDialogYes = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(quitDialog, "Confirm"), "Text"));
                quitDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmYes;

                TextMeshProUGUI quitDialogNo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(quitDialog, "Cancel"), "Text"));
                quitDialogNo.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmNo;

                //Restart
                GameObject restartDialog = GetGameObjectChild(GetGameObjectChild(pauseDialogs, "Restart Confirm"), "Panel");

                TextMeshProUGUI restartDialogText = GetTextMeshProUGUI(GetGameObjectChild(restartDialog, "Text"));
                restartDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirm;

                TextMeshProUGUI restartDialogTooltip = GetTextMeshProUGUI(GetGameObjectChild(restartDialog, "Text (1)"));
                restartDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

                TextMeshProUGUI restartDialogYes = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(restartDialog, "Confirm"), "Text"));
                restartDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirmYes;

                TextMeshProUGUI restartDialogNo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(restartDialog, "Cancel"), "Text"));
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
            Logging.Message("Loading font resource bundle...");
            //Will load from the same directory that the dll is in.
            AssetBundle fontBundle = AssetBundle.LoadFromFile(Path.Combine(MainPatch.ModFolder,"ullfont.resource"));
            AssetBundle jafontBundle = AssetBundle.LoadFromFile(Path.Combine(MainPatch.ModFolder, "jafont.resource"));

            if (jafontBundle == null)
            {
                Logging.Error("FAILED TO LOAD JAPANESE TMP FONT(´・ω・`)*No AssetBundle?");
            }
            else
            {
                Logging.Message("Japanese Font AssetBundle has been loaded.");
                TMP_FontAsset jafontTMP = jafontBundle.LoadAsset<TMP_FontAsset>("jafix_TMP");
                if (jafontTMP)
                {
                    Logging.Warn("Japanese TMP font loaded.");
                    jaFontTMP = jafontTMP;
                }
                else
                {
                    Logging.Error("Why there's no Japanese TMP Font in this assetbundle(´・ω・`)");
                }
            }


                AssetBundle extraFontBundle = AssetBundle.LoadFromFile(Path.Combine(MainPatch.ModFolder, "arabfonts"));

            if (extraFontBundle == null)
            {
                Logging.Error("Failed to load Arabic / Hebrew fonts. :( (No extra AssetBundle found!)");
            }
            else
            {
                Logging.Message("Extra Fonts Asset Bundle has been loaded...");

                TMP_FontAsset arabicFontAsset = extraFontBundle.LoadAsset<TMP_FontAsset>("segoeui SDF Arabic");
				TMP_FontAsset hebrewFontAsset = extraFontBundle.LoadAsset<TMP_FontAsset>("segoeui SDF Hebrew");
				Sprite arabicLogo = extraFontBundle.LoadAsset<Sprite>("2023_improved_logo.png");

                Sprite rankD = extraFontBundle.LoadAsset<Sprite>("RankD.png");
                Sprite rankC = extraFontBundle.LoadAsset<Sprite>("RankC.png");
                Sprite rankB = extraFontBundle.LoadAsset<Sprite>("RankB.png");
                Sprite rankA = extraFontBundle.LoadAsset<Sprite>("RankA.png");
                Sprite rankS = extraFontBundle.LoadAsset<Sprite>("RankS.png");
                Sprite rankSS = extraFontBundle.LoadAsset<Sprite>("RankSS.png");
                Sprite rankSSS = extraFontBundle.LoadAsset<Sprite>("RankSSS.png");
                Sprite rankU = extraFontBundle.LoadAsset<Sprite>("RankU.png");

                CustomRankImages = new Sprite[8];
				CustomRankImages[0] = rankD;
				CustomRankImages[1] = rankC;
				CustomRankImages[2] = rankB;
				CustomRankImages[3] = rankA;
				CustomRankImages[4] = rankS;
				CustomRankImages[5] = rankSS;
				CustomRankImages[6] = rankSSS;
				CustomRankImages[7] = rankU;

				if (arabicFontAsset == null)
                {
                    Logging.Warn("There is no Arabic font in this AssetBundle!?");
                }
                else
                {
                    Logging.Message("Arabic Font has been loaded.");
                    ArabicFontTMP = arabicFontAsset;
                }

                if (arabicLogo == null)
                {
					Logging.Warn("There is no Arabic logo in this AssetBundle!?");
				}
                else
                {
                    ArabicUltrakillLogo = arabicLogo;
                }

				if (hebrewFontAsset == null)
				{
					Logging.Warn("There is no Hebrew font in this AssetBundle!?");
				}
				else
				{
					Logging.Message("Hebrew Font has been loaded.");
					HebrewFontTMP = hebrewFontAsset;
				}
			}

			if (fontBundle == null)
            {
                Logging.Error("FAILED TO LOAD");
            }
            else
            {
                Logging.Message("Font bundle loaded.");
                Logging.Message("Loading fonts from bundle...");
                
                Font font1 = fontBundle.LoadAsset<Font>("VCR_OSD_MONO_EXTENDED");
                Font font2 = fontBundle.LoadAsset<Font>("EBGaramond-Regular");
                TMP_FontAsset font1TMP = fontBundle.LoadAsset<TMP_FontAsset>("VCR_OSD_MONO_EXTENDED_TMP");
                TMP_FontAsset font2TMP = fontBundle.LoadAsset<TMP_FontAsset>("EBGaramond-Regular_TMP");
    
                
                TMP_FontAsset cjkFontTMP = fontBundle.LoadAsset<TMP_FontAsset>("NotoSerif-CJK_TMP");
                
                if(font1 && font2)
                {
                    Logging.Warn("Normal fonts loaded.");
                    GlobalFont = font1;
                    MuseumFont = font2;
                    GlobalFontReady = true;
                }
                else
                {
                    Logging.Error("FAILED TO LOAD NORMAL FONTS");
                    GlobalFontReady = false;
                }
                if(font1TMP && font2TMP && cjkFontTMP)
                {
                    Logging.Warn("Normal TMP fonts loaded.");
                    GlobalFontTMP = font1TMP;
                    MuseumFontTMP = font2TMP;
                    CJKFontTMP = cjkFontTMP;
                    
                    TMPFontReady = true;
                }
                else
                {
                    Logging.Error("FAILED TO LOAD TMP FONTS");
                    TMPFontReady = false;
                }
                
            }
        }
        
        public static void HandleSceneSwitch(Scene scene,ref GameObject canvas)
        {

            //Logging.Message("Switching scenes...");
            string levelName = GetCurrentSceneName();
            if(levelName == "Intro" || levelName == "Bootstrap")
            { 
                //Don't do anything if we're still booting up the game.
                //Logging.Warn("In intro, not hooking yet");
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

                        PatchFrontEnd(canvasObj);
                            
                        //(Re)render the UltrakULL status on screen when a language has been (re)loaded.
                        if (ultrakullLogo != null) {GameObject.Destroy(ultrakullLogo);}
                        ultrakullLogo = GameObject.Instantiate(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "Main Menu (1)"), "Title"), "Text"), canvasObj.transform);
                        ultrakullLogo.transform.localPosition = new Vector3(1075, 210, 0);
                        TextMeshProUGUI ultrakullLogoText = GetTextMeshProUGUI(ultrakullLogo);
                        ultrakullLogoText.text = "UltrakULL loaded.\nVersion: " + MainPatch.GetVersion() + "\nCurrent locale: " + LanguageManager.CurrentLanguage.metadata.langName;
                        ultrakullLogoText.alignment = TextAlignmentOptions.TopLeft;
                        ultrakullLogoText.fontSize = 16;
                        
                            
                        //Add notif if there's a mod update available
                        if(updateAvailable)
                        { 
                            ultrakullLogoText.text += "\n<color=green>UPDATE AVAILABLE!</color>";
                                
                            //Make an update button
                            GameObject buttonBase= GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj,"Main Menu (1)"),"Panel"),"Youtube");
                                
                            GameObject ultrakullUpdateButton = GameObject.Instantiate(buttonBase,buttonBase.transform.parent);
                            ultrakullUpdateButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(185, 0f);
                            ultrakullUpdateButton.GetComponentInChildren<Image>().color = new Color(0,1,0,1);
                            ultrakullUpdateButton.GetComponentInChildren<Text>().text = "VIEW UPDATE";
                            ultrakullUpdateButton.GetComponentInChildren<WebButton>().url = "https://github.com/ClearwaterTM/UltrakULL/releases/latest";
                        }
                        //Warn of a language that doesn't match the mod version
                        if (!LanguageManager.FileMatchesMinimumRequiredVersion(LanguageManager.CurrentLanguage.metadata.minimumModVersion, MainPatch.GetVersion()) && !isUsingEnglish())
                        {
                            ultrakullLogoText.text += "\n<color=orange>This language file\nwas created for\nan older version of\nUltrakULL.\nPlease check for\nan update to this file!</color>";
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
                        if (isUsingEnglish())
                        {
                            Logging.Warn("Current language is English, not patching.");
                            return;
                        }
                        
                        Logging.Message("Regular scene");
                        Logging.Message("Attempting to patch base elements");
                        try{PatchPauseMenu(ref canvasObj);} catch(Exception e){Console.WriteLine(e.ToString());}
                        try{Cheats.PatchCheatConsentPanel(ref canvasObj);;} catch(Exception e){Console.WriteLine(e.ToString());}
                        try{HUDMessages.PatchDeathScreen(ref canvasObj);} catch(Exception e){Console.WriteLine(e.ToString());}
                        try{LevelStatWindow.PatchStats(ref canvasObj);} catch(Exception e){Console.WriteLine(e.ToString());}
                        try{HUDMessages.PatchMisc(ref canvasObj);} catch(Exception e){Console.WriteLine(e.ToString());}
                        try{Options options = new Options(ref canvasObj);} catch(Exception e){Console.WriteLine(e.ToString());}
        
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
                            else if(levelName.Contains("7-") || levelName.Contains("8-") || levelName.Contains("9-"))
                            {
                                Logging.Message("Act 3");
                                Act3.PatchAct3(ref canvasObj);
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
                //Open Language Folder button in Options->Language
                TextMeshProUGUI openLangFolderText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj,"OptionsMenu"), "Language Page"),"Scroll Rect (1)"),"Contents"),"OpenLangFolder"),"Slot Text")); 
                openLangFolderText.text = "<color=#03fc07>Open language folder</color>";
                
            }
        }
    }
}
