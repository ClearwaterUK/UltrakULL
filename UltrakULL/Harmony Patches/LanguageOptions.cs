using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(OptionsMenuToManager), "Start")]
    public static class InjectLanguageButton
    {
        public static Text languageButtonText;
        public static Text languageButtonTitleText;
        private static readonly HttpClient Client = new HttpClient();
        
        private static bool hasAlreadyFetchedLanguages = false;
        private static List<GameObject> languageButtons = new List<GameObject>();
        
        private static GameObject langBrowserPage;
        private static GameObject langLocalPage;
        private static GameObject redownloadConfirmPanel;
        
        public static bool langFileLocallyExists(string languageTag)
        {
            string expectedFileLocation = Path.Combine(Directory.GetCurrentDirectory() + "\\BepInEx\\config\\ultrakull\\") + languageTag + ".json";
            return File.Exists(expectedFileLocation);
        }
        
        public static void warnBeforeDownload(LanguageInfo lInfo)
        {

            GameObject difficultySelectMenu = GetGameObjectChild(GetInactiveRootObject("Canvas"),"Difficulty Select (1)");

            GameObject panelToUse = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Canvas"),"OptionsMenu"),"Assist Options"),"Panel");
            
            if(redownloadConfirmPanel == null)
            {
                redownloadConfirmPanel = GameObject.Instantiate(panelToUse,difficultySelectMenu.transform.parent);
            }

            redownloadConfirmPanel.name = "ConfirmDownloadPanel";
            
            Text confirmDownloadText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(redownloadConfirmPanel,"Panel"),"Text (2)"));
            
            confirmDownloadText.fontSize = 22;
            confirmDownloadText.text =
            "This language has already been downloaded. <color=#34e1eb>Redownload?</color>\n\n" 
                +"<color=orange>The current file's contents will be overwritten.</color>";

            Text confirmDownloadTextConfirm = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(redownloadConfirmPanel,"Panel"),"Text (1)"));
            confirmDownloadTextConfirm.text = "";
            
            //Destroy the original buttons and replace them with new ones (at least until I can figure out how to change the listeners of the original buttons)
            GameObject origYes = GetGameObjectChild(GetGameObjectChild(redownloadConfirmPanel,"Panel"),"Yes");
            GameObject origNo = GetGameObjectChild(GetGameObjectChild(redownloadConfirmPanel,"Panel"),"No");
            origYes.SetActive(false);
            origNo.SetActive(false);
            
            //Make new buttons here
            GameObject DownloadYes = CreateButton("YES","DownloadYes");
            DownloadYes.name = "DownloadYes";
            DownloadYes.transform.position = new Vector3(1150, 300, 0);
            DownloadYes.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(300f, 50f);
            DownloadYes.GetComponentInChildren<Text>().text = "YES";
            DownloadYes.transform.SetParent(redownloadConfirmPanel.transform);
            
            GameObject DownloadNo = CreateButton("NO","DownloadNo");
            DownloadNo.name = "DownloadNo";
            DownloadNo.transform.position = new Vector3(750, 300, 0);
            DownloadNo.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(300f, 50f);
            DownloadNo.GetComponentInChildren<Text>().text = "NO";
            DownloadNo.transform.SetParent(redownloadConfirmPanel.transform);
            
            DownloadYes.GetComponentInChildren<Button>().onClick.AddListener(delegate { redownloadConfirmPanel.SetActive(false); downloadLanguageFile(lInfo.languageTag,lInfo.languageFullName); });
            DownloadNo.GetComponentInChildren<Button>().onClick.AddListener(delegate { redownloadConfirmPanel.SetActive(false); });
            
            redownloadConfirmPanel.SetActive(true);
        }

        public async static Task getOnlineLanguages(GameObject canvasToCopy, Transform optionsParent)
        {
            string masterLanguageUrl = "https://clearwateruk.github.io/mods/ultrakULL/languagesMaster.json";
            
            //Hide the local page, get the list of available languages from the remote repo. Make buttons for each entry found and color code them.
            //Blue - Installed locally. Green - Not installed, available. Yellow - Installed, update available.
            
            
            //Set up the browser page here.
            if(langBrowserPage == null)
            {
                langBrowserPage =  GameObject.Instantiate(canvasToCopy, optionsParent);
            }
            
            langBrowserPage.name = "Language Browser";
            langBrowserPage.SetActive(true);

            Text langBrowserTitle = GetTextfromGameObject(GetGameObjectChild(langBrowserPage,"Text"));
            langBrowserTitle.text = "--LANGUAGE BROWSER--";
            langBrowserTitle.resizeTextForBestFit = true;
            
            Transform contentParent = langBrowserPage.transform.Find("Scroll Rect (1)").Find("Contents");
            foreach (Transform child in contentParent.GetComponentInChildren<Transform>(true))
                child.gameObject.SetActive(false);
            VerticalLayoutGroup vGroup = contentParent.GetComponent<VerticalLayoutGroup>();
            vGroup.spacing = 7.5f;
            vGroup.childAlignment = TextAnchor.UpperCenter;

            GameObject languageButtonPrefab = optionsParent.Find("Save Slots").Find("Grid").Find("Slot Row").gameObject;
            
            
            //Fetch the language master file from the remote repo
            if(hasAlreadyFetchedLanguages)
            {
                //If languages were already fetched once, redisplay them
                foreach(GameObject button in languageButtons)
                {
                    button.SetActive(true);
                }
            }
            else
            { 
                try
                {
                    Logging.Warn("Obtaining online languages from UltrakULL repo...");
                    string responseJsonRaw = await Client.GetStringAsync(masterLanguageUrl);
                    MasterLanguages responseJson = JsonConvert.DeserializeObject<MasterLanguages>(responseJsonRaw);
                    
                    Console.WriteLine(responseJson.availableLanguages.ToString());
                    //Enumerate across all of the langs obtained from the master lang file online, and create download buttons for them.
                    foreach(LanguageInfo langInfo in responseJson.availableLanguages)
                    {
                        Logging.Warn(langInfo.languageTag);
                        bool fileLocallyExists = langFileLocallyExists(langInfo.languageTag);
                        
                        GameObject languageBrowserButtonInstance = GameObject.Instantiate(languageButtonPrefab, contentParent);
                        languageBrowserButtonInstance.transform.localScale = new Vector3(0.2188482f, 1.123569f, 0.5088629f);
                        languageBrowserButtonInstance.transform.Find("Select Wrapper").gameObject.SetActive(false);
                        languageBrowserButtonInstance.transform.Find("Delete Wrapper").gameObject.SetActive(false);
                        languageBrowserButtonInstance.transform.Find("State Text").gameObject.SetActive(false);
                        GameObject.Destroy(languageBrowserButtonInstance.GetComponent<SlotRowPanel>());

                        Transform slotTextTf = languageBrowserButtonInstance.transform.Find("Slot Text");
                        slotTextTf.localScale = new Vector3(4.983107f, 0.970607f, 2.1431f);
                        slotTextTf.localPosition = new Vector3(0f, 0f, 0f);
                        Text slotText = slotTextTf.GetComponent<Text>();
                        slotText.text = langInfo.languageFullName;
                        slotText.alignment = TextAnchor.MiddleCenter;
                        slotText.fontSize = 16;
                        
                        if(langFileLocallyExists(langInfo.languageTag))
                        {
                            //If the language file already exists, compare its version with the version found online.
                            //If the online version has a newer version, display that an update is available.
                            //Otherwise just display that the language has already been downloaded.
                            
                            string langFilePath = Path.Combine(Directory.GetCurrentDirectory(), "BepInEx","config","ultrakull") + Path.DirectorySeparatorChar + langInfo.languageTag + ".json";

                            string jsonFile = File.ReadAllText(langFilePath);
                            JsonFormat json = JsonConvert.DeserializeObject<JsonFormat>(jsonFile);
                            
                            Version onlineCurrentVersion = new Version(json.metadata.langVersion);
                            Version localCurrentVersion = new Version(langInfo.versionNumber);
                            
                            switch(onlineCurrentVersion.CompareTo(localCurrentVersion))
                            {

                                case -1: { slotText.text += "\n(<color=green>Update available</color>)";break;}
                                default: { slotText.text += "\n(<color=green>Downloaded</color>)";break;}
                            }

                        }

                        Button langButton = languageBrowserButtonInstance.AddComponent<Button>();
                        langButton.transition = Selectable.Transition.ColorTint;
                        langButton.colors = new ColorBlock()
                        {
                            normalColor = new Color32(255, 255, 255, 255),
                            highlightedColor = new Color32(255, 0, 0, 255),
                            pressedColor = new Color32(255, 255, 0, 255),
                            disabledColor = new Color32(255, 255, 0, 255),
                            colorMultiplier = 1f,
                            fadeDuration = 0.1f
                        };
                        langButton.targetGraphic = languageBrowserButtonInstance.transform.Find("Panel").GetComponent<Graphic>();
                        
                        languageBrowserButtonInstance.SetActive(true);
                        
                        //Add click listener to download the file when clicked on.
                        langButton.onClick.AddListener(delegate
                        {
                            if(GetCurrentSceneName() != "Main Menu")
                            {
                                MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage("<color=orange>Languages can not be downloaded while in-game. Please return to the main menu first.</color>");
                            }
                            else
                            {
                                if(langFileLocallyExists(langInfo.languageTag))
                                {
                                    Logging.Warn("File already exists, warning before download");
                                    warnBeforeDownload(langInfo);
                                }
                                else
                                {
                                    Logging.Warn("Downloading language file - " + langInfo.languageTag + ".json...");
                                    downloadLanguageFile(langInfo.languageTag,langInfo.languageFullName);
                                }
                            }
    
                        });
                        
                        //Pop the button into a list, so when the page is exited and reopened, obtained lang buttons will reappear.
                        languageButtons.Add(languageBrowserButtonInstance);
                    }
                }
                catch (Exception e)
                {
                    Logging.Error("Oops");
                    Logging.Error(e.ToString());
                }
                hasAlreadyFetchedLanguages = true;
            }

            Client.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            Client.Timeout = TimeSpan.FromSeconds(5);
            
            //Back button to return to the local language list.
            GameObject returnToLocalList = GameObject.Instantiate(languageButtonPrefab, contentParent);
            returnToLocalList.transform.localScale = new Vector3(0.2188482f, 1.123569f, 0.5088629f);
            returnToLocalList.transform.Find("Select Wrapper").gameObject.SetActive(false);
            returnToLocalList.transform.Find("Delete Wrapper").gameObject.SetActive(false);
            returnToLocalList.transform.Find("State Text").gameObject.SetActive(false);
            GameObject.Destroy(returnToLocalList.GetComponent<SlotRowPanel>());

            Transform returnToList = returnToLocalList.transform.Find("Slot Text");
            returnToList.localScale = new Vector3(4.983107f, 0.970607f, 2.1431f);
            returnToList.localPosition = new Vector3(0f, 0f, 0f);
            Text returnToListText = returnToList.GetComponent<Text>();
            returnToListText.text = "<color=#03fc07>Return</color>";
            returnToListText.alignment = TextAnchor.MiddleCenter;
            returnToListText.fontSize = 16;

            Button returnToListButton = returnToLocalList.AddComponent<Button>();
            returnToListButton.transition = Selectable.Transition.ColorTint;
            returnToListButton.colors = new ColorBlock()
            {
                normalColor = new Color32(255, 255, 255, 255),
                highlightedColor = new Color32(255, 0, 0, 255),
                pressedColor = new Color32(255, 255, 0, 255),
                disabledColor = new Color32(255, 255, 0, 255),
                colorMultiplier = 1f,
                fadeDuration = 0.1f
            };
            returnToListButton.targetGraphic = returnToLocalList.transform.Find("Panel").GetComponent<Graphic>();
                    
            returnToLocalList.SetActive(true);
            
            returnToListButton.onClick.AddListener(delegate
            {
                langBrowserPage.SetActive(false);
                langLocalPage.SetActive(true);
                
            });
        }
        
        public static async void downloadLanguageFile(string languageTag, string languageName)
        {
            string fileName = languageTag + ".json";
            
            string languageFileUrl = "https://clearwateruk.github.io/mods/ultrakULL/" + fileName;
            
            string localLanguageFolder = Path.Combine(Directory.GetCurrentDirectory() + "\\BepInEx\\config\\ultrakull\\");
            
            string fullPath = localLanguageFolder + fileName;
            
            Client.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            Client.Timeout = TimeSpan.FromSeconds(5);
            
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    string messageNotif;
              
                    //If the file was simply updated, it can be used straightaway.
                    //If a new lang file was downloaded, display a notif to the user to enter a level or reload the menu.
                    Console.WriteLine(languageTag);
                    if(langFileLocallyExists(languageTag))
                    {
                        messageNotif = "Language file \"" + languageName + "\" has been updated. It can be used immediately.";
                    }
                    else
                    {
                        messageNotif = "A new language file \"" + languageName + "\" has been downloaded. It will be available for use upon entering a mission, or reloading the main menu.";
                    }
                    
                    MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage("<color=orange>DOWNLOADING...</color>");
                    
                    webClient.DownloadFile(languageFileUrl, fullPath);
                    string jsonFile = File.ReadAllText(fullPath);
                    JsonFormat file = JsonConvert.DeserializeObject<JsonFormat>(jsonFile);
                    
                    Console.WriteLine("Lang file saved.");
                       
                    MonoSingleton<HudMessageReceiver>.Instance.ClearMessage();
                    MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage("<color=lime>" + messageNotif + "</color>");

                    if(!(langFileLocallyExists(languageTag)))
                    {
                        LanguageManager.allLanguages.Add(languageTag, file);
                    }

                    //LanguageManager.allLanguagesDisplayNames.Add(languageName, lang);
                }
            }
            catch(Exception e)
            {
                MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage("<color=red>A download error occured, file has not been saved.</color>");
                Console.WriteLine("Attempted to download from: " + languageFileUrl);
                Console.WriteLine(e.ToString());
            }

        }
        
        public static bool Prefix(OptionsMenuToManager __instance)
        {
            hasAlreadyFetchedLanguages = false;
            languageButtons.Clear();
            
            if (GetCurrentSceneName() == "Main Menu")
            {
                Transform panel = __instance.pauseMenu.transform.Find("Panel");
                GameObject discordButton = panel.Find("Discord").gameObject;

                GameObject ultrakullDiscordButton = GameObject.Instantiate(discordButton, discordButton.transform.parent);
                ultrakullDiscordButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(492f, -295f);
                ultrakullDiscordButton.GetComponentInChildren<Text>().text = "UltrakULL DISCORD";
                ultrakullDiscordButton.GetComponentInChildren<Image>().color = discordButton.GetComponentInChildren<Image>().color;
                ultrakullDiscordButton.GetComponentInChildren<WebButton>().url = "https://discord.gg/ZB7jk6Djv5";
            }

            Logging.Message("Adding language option to options menu...");

            Transform optionsParent = __instance.optionsMenu.transform;
            GameObject languageButton = GameObject.Instantiate(optionsParent.Find("Gameplay").gameObject, optionsParent);
            languageButton.name = "Language";
            languageButton.transform.localPosition += new Vector3(0f, 60f, 0f);
            languageButtonText = languageButton.transform.GetChild(0).gameObject.GetComponent<Text>();

            Button button = languageButton.GetComponent<Button>();
            GameObject pageToDisable = optionsParent.Find("Gameplay Options").gameObject;
            button.onClick.AddListener(delegate
            {
                pageToDisable.SetActive(false);
            });

            if(langLocalPage == null)
            {
                langLocalPage = GameObject.Instantiate(pageToDisable, optionsParent);
            }
            
            langLocalPage.name = "Language Page";
            langLocalPage.SetActive(false);
            languageButtonTitleText = langLocalPage.transform.Find("Text").GetComponent<Text>();

            Transform contentParent = langLocalPage.transform.Find("Scroll Rect (1)").Find("Contents");
            foreach (Transform child in contentParent.GetComponentInChildren<Transform>(true))
                child.gameObject.SetActive(false);
            VerticalLayoutGroup vGroup = contentParent.GetComponent<VerticalLayoutGroup>();
            vGroup.spacing = 7.5f;
            vGroup.childAlignment = TextAnchor.UpperCenter;

            GameObject languageButtonPrefab = optionsParent.Find("Save Slots").Find("Grid").Find("Slot Row").gameObject;

            foreach (string language in LanguageManager.allLanguages.Keys)
            {
                GameObject languageButtonInstance = GameObject.Instantiate(languageButtonPrefab, contentParent);
                languageButtonInstance.transform.localScale = new Vector3(0.2188482f, 1.123569f, 0.5088629f);
                languageButtonInstance.transform.Find("Select Wrapper").gameObject.SetActive(false);
                languageButtonInstance.transform.Find("Delete Wrapper").gameObject.SetActive(false);
                languageButtonInstance.transform.Find("State Text").gameObject.SetActive(false);
                GameObject.Destroy(languageButtonInstance.GetComponent<SlotRowPanel>());

                Transform slotTextTf = languageButtonInstance.transform.Find("Slot Text");
                slotTextTf.localScale = new Vector3(4.983107f, 0.970607f, 2.1431f);
                slotTextTf.localPosition = new Vector3(0f, 0f, 0f);
                Text slotText = slotTextTf.GetComponent<Text>();
                slotText.text = LanguageManager.allLanguages[language].metadata.langDisplayName;
                slotText.alignment = TextAnchor.MiddleCenter;
                slotText.fontSize = 16;

                Button langButton = languageButtonInstance.AddComponent<Button>();
                langButton.transition = Selectable.Transition.ColorTint;
                langButton.colors = new ColorBlock()
                {
                    normalColor = new Color32(255, 255, 255, 255),
                    highlightedColor = new Color32(255, 0, 0, 255),
                    pressedColor = new Color32(255, 255, 0, 255),
                    disabledColor = new Color32(255, 255, 0, 255),
                    colorMultiplier = 1f,
                    fadeDuration = 0.1f
                };
                langButton.targetGraphic = languageButtonInstance.transform.Find("Panel").GetComponent<Graphic>();


                langButton.onClick.AddListener(delegate
                {
                    LanguageManager.SetCurrentLanguage(language);
                });

                languageButtonInstance.SetActive(true);
            }
            button.onClick.AddListener(delegate { langLocalPage.SetActive(true); });

            // "Open language folder" button
            GameObject openLangFolder = GameObject.Instantiate(languageButtonPrefab, contentParent);
            openLangFolder.name = "OpenLangFolder";
            openLangFolder.transform.localScale = new Vector3(0.2188482f, 1.123569f, 0.5088629f);
            openLangFolder.transform.Find("Select Wrapper").gameObject.SetActive(false);
            openLangFolder.transform.Find("Delete Wrapper").gameObject.SetActive(false);
            openLangFolder.transform.Find("State Text").gameObject.SetActive(false);
            GameObject.Destroy(openLangFolder.GetComponent<SlotRowPanel>());

            Transform slotTextLangButton = openLangFolder.transform.Find("Slot Text");
            slotTextLangButton.localScale = new Vector3(4.983107f, 0.970607f, 2.1431f);
            slotTextLangButton.localPosition = new Vector3(0f, 0f, 0f);
            Text openLangFolderText = slotTextLangButton.GetComponent<Text>();
            openLangFolderText.text = "<color=#03fc07>Open language folder</color>";
            openLangFolderText.fontSize = 16;
            Button openLangFolderButton = openLangFolder.AddComponent<Button>();
            openLangFolderButton.colors = new ColorBlock()
            {
                normalColor = new Color32(255, 255, 255, 255),
                highlightedColor = new Color32(255, 0, 0, 255),
                pressedColor = new Color32(255, 255, 0, 255),
                disabledColor = new Color32(255, 255, 0, 255),
                colorMultiplier = 1f,
                fadeDuration = 0.1f
            };
            openLangFolderButton.onClick.AddListener(delegate { Application.OpenURL(Path.Combine(Directory.GetCurrentDirectory(), "BepInEx", "config", "ultrakull")); });
            RectTransform cRect = langLocalPage.transform.Find("Scroll Rect (1)").Find("Contents").GetComponent<RectTransform>();
            cRect.sizeDelta = new Vector2(600f, (LanguageManager.allLanguages.Keys.Count) * 100);

            optionsParent.Find("Gameplay").GetComponent<Button>().onClick.AddListener(delegate { langLocalPage.SetActive(false); langBrowserPage.SetActive(false); });
            optionsParent.Find("Controls").GetComponent<Button>().onClick.AddListener(delegate { langLocalPage.SetActive(false); langBrowserPage.SetActive(false); });
            optionsParent.Find("Video").GetComponent<Button>().onClick.AddListener(delegate { langLocalPage.SetActive(false); langBrowserPage.SetActive(false); });
            optionsParent.Find("Audio").GetComponent<Button>().onClick.AddListener(delegate { langLocalPage.SetActive(false); langBrowserPage.SetActive(false); });
            optionsParent.Find("HUD").GetComponent<Button>().onClick.AddListener(delegate { langLocalPage.SetActive(false); langBrowserPage.SetActive(false); });
            optionsParent.Find("Assist").GetComponent<Button>().onClick.AddListener(delegate { langLocalPage.SetActive(false); langBrowserPage.SetActive(false); });
            optionsParent.Find("Colors").GetComponent<Button>().onClick.AddListener(delegate { langLocalPage.SetActive(false); langBrowserPage.SetActive(false); });
            optionsParent.Find("Saves").GetComponent<Button>().onClick.AddListener(delegate { langLocalPage.SetActive(false); langBrowserPage.SetActive(false); });

            try
            {
                languageButtonText.text = LanguageManager.CurrentLanguage.options.language_languages;
                languageButtonTitleText.text = "--" + LanguageManager.CurrentLanguage.options.language_title + "--";
            }
            #pragma warning disable 0168
            catch (Exception e)
            {
                languageButtonText.text = "LANGUAGES";
                languageButtonTitleText.text = "--" + "LANGUAGES" + "--";
            }
            
            //Language browser button
            GameObject langBrowseFolder = GameObject.Instantiate(languageButtonPrefab, contentParent);
            langBrowseFolder.name = "LangBrowser";
            langBrowseFolder.transform.localScale = new Vector3(0.2188482f, 1.123569f, 0.5088629f);
            langBrowseFolder.transform.Find("Select Wrapper").gameObject.SetActive(false);
            langBrowseFolder.transform.Find("Delete Wrapper").gameObject.SetActive(false);
            langBrowseFolder.transform.Find("State Text").gameObject.SetActive(false);
            GameObject.Destroy(langBrowseFolder.GetComponent<SlotRowPanel>());

            Transform slotTextLangBrowseButton = langBrowseFolder.transform.Find("Slot Text");
            slotTextLangBrowseButton.localScale = new Vector3(4.983107f, 0.970607f, 2.1431f);
            slotTextLangBrowseButton.localPosition = new Vector3(0f, 0f, 0f);
            Text langBrowseText = slotTextLangBrowseButton.GetComponent<Text>();
            langBrowseText.text = "<color=#03fc07>→Browse langs online←</color>";
            langBrowseText.fontSize = 16;
            Button browseLangButton = langBrowseFolder.AddComponent<Button>();
            browseLangButton.colors = new ColorBlock()
            {
                normalColor = new Color32(255, 255, 255, 255),
                highlightedColor = new Color32(255, 0, 0, 255),
                pressedColor = new Color32(255, 255, 0, 255),
                disabledColor = new Color32(255, 255, 0, 255),
                colorMultiplier = 1f,
                fadeDuration = 0.1f
            };
            browseLangButton.targetGraphic = langBrowseFolder.transform.Find("Panel").GetComponent<Graphic>();
            browseLangButton.onClick.AddListener(delegate { langLocalPage.SetActive(false); getOnlineLanguages(pageToDisable,__instance.optionsMenu.transform); });

            //Add toggle to the audio tab that allows for enabling/disabling of swapping for spoken dialogue.
            //Instantiate from the original subtitles panel, but the toggle will need to be swapped for a new one, otherwise it will also toggle subtitles.
            
            GameObject originalSlider = optionsParent.Find("Audio Options/Image/Subtitles Checkbox").gameObject;

            GameObject dubSlider = GameObject.Instantiate(originalSlider, optionsParent.Find("Audio Options/Image"));
            dubSlider.GetComponent<RectTransform>().anchoredPosition = new Vector2(300f, -225f);
            dubSlider.name = "Dialogue Dub";
            
            Toggle oldToggle = GetGameObjectChild(dubSlider,"Toggle").GetComponentInChildren<Toggle>();
            oldToggle.enabled = false;
            
            Toggle dubToggle = dubSlider.AddComponent<Toggle>();
            dubToggle.enabled = true;
            dubToggle.transform.localPosition = oldToggle.transform.localPosition;

            dubToggle.isOn = Convert.ToBoolean(LanguageManager.configFile.Bind("General", "activeDubbing", "False").Value);
            GameObject toggleCheckmark = GetGameObjectChild(GetGameObjectChild(dubSlider,"Toggle"),"Background");
            
            if(dubToggle.isOn) { toggleCheckmark.SetActive(true); }
            else { toggleCheckmark.SetActive(false); }
            
            dubToggle.onValueChanged.AddListener(delegate
            {
                LanguageManager.configFile.Bind("General", "activeDubbing", "False").Value = dubToggle.isOn.ToString();
                if(dubToggle.isOn) { toggleCheckmark.SetActive(true); }
                else { toggleCheckmark.SetActive(false); }
            });
            
            try
            {
                GetTextfromGameObject(GetGameObjectChild(dubSlider,"Text")).text = LanguageManager.CurrentLanguage.options.audio_dubbing;
            }
            #pragma warning disable 0168
            catch (Exception e)
            {
                GetTextfromGameObject(GetGameObjectChild(dubSlider,"Text")).text = "DUBBED AUDIO";
            }
            
            return true;
        }
    }
}
