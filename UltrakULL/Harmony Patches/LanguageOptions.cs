using HarmonyLib;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(OptionsMenuToManager), "Start")]
    public static class InjectLanguageButton
    {
        public static Text languageButtonText;
        public static Text languageButtonTitleText;

        public static bool Prefix(OptionsMenuToManager __instance)
        {
            if (SceneManager.GetActiveScene().name == "Main Menu")
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

            GameObject languagePage = GameObject.Instantiate(pageToDisable, optionsParent);
            languagePage.name = "Language Page";
            languagePage.SetActive(false);
            languageButtonTitleText = languagePage.transform.Find("Text").GetComponent<Text>();

            Transform contentParent = languagePage.transform.Find("Scroll Rect (1)").Find("Contents");
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
                slotText.fontSize = 27;

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
            button.onClick.AddListener(delegate { languagePage.SetActive(true); });

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
            openLangFolderText.text = LanguageManager.CurrentLanguage.options.language_openLanguageFolder;
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
            openLangFolderButton.onClick.AddListener(delegate { Application.OpenURL(Path.Combine(Directory.GetCurrentDirectory() + "\\BepInEx\\config\\ultrakull")); });


            RectTransform cRect = languagePage.transform.Find("Scroll Rect (1)").Find("Contents").GetComponent<RectTransform>();
            cRect.sizeDelta = new Vector2(600f, LanguageManager.allLanguages.Keys.Count * 100);

            optionsParent.Find("Gameplay").GetComponent<Button>().onClick.AddListener(delegate { languagePage.SetActive(false); });
            optionsParent.Find("Controls").GetComponent<Button>().onClick.AddListener(delegate { languagePage.SetActive(false); });
            optionsParent.Find("Video").GetComponent<Button>().onClick.AddListener(delegate { languagePage.SetActive(false); });
            optionsParent.Find("Audio").GetComponent<Button>().onClick.AddListener(delegate { languagePage.SetActive(false); });
            optionsParent.Find("HUD").GetComponent<Button>().onClick.AddListener(delegate { languagePage.SetActive(false); });
            optionsParent.Find("Assist").GetComponent<Button>().onClick.AddListener(delegate { languagePage.SetActive(false); });
            optionsParent.Find("Colors").GetComponent<Button>().onClick.AddListener(delegate { languagePage.SetActive(false); });
            optionsParent.Find("Saves").GetComponent<Button>().onClick.AddListener(delegate { languagePage.SetActive(false); });

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