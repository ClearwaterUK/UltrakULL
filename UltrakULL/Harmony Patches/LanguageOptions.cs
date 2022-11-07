using HarmonyLib;
using System;
using UnityEngine;
using UnityEngine.UI;
using UltrakULL.json;


namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(OptionsMenuToManager), "Start")]
    public static class Inject_LanguageButton
    {
        public static Text languageButtonText = null;
        public static Text languageButtonTitleText = null;

        public static bool Prefix(OptionsMenuToManager __instance)
        {
            Console.WriteLine("Adding language option to options menu...");

            Transform optionsParent = __instance.optionsMenu.transform;
            GameObject languageButton = GameObject.Instantiate(optionsParent.Find("Gameplay").gameObject, optionsParent);
            languageButton.transform.localPosition += new Vector3(0f, 60f, 0f);
            languageButtonText = languageButton.transform.GetChild(0).gameObject.GetComponent<Text>();


            Button button = languageButton.GetComponent<Button>();
            GameObject pageToDisable = optionsParent.Find("Gameplay Options").gameObject;
            button.onClick.AddListener(delegate
            {
                pageToDisable.SetActive(false);
            });

            GameObject languagePage = GameObject.Instantiate(pageToDisable, optionsParent);
            languagePage.SetActive(false);
            languageButtonTitleText = languagePage.transform.Find("Text").GetComponent<Text>();

            Transform contentParent = languagePage.transform.Find("Scroll Rect (1)").Find("Contents");
            foreach (Transform child in contentParent.GetComponentInChildren<Transform>(true))
                child.gameObject.SetActive(false);
            VerticalLayoutGroup vGroup = contentParent.GetComponent<VerticalLayoutGroup>();
            vGroup.spacing = 7.5f;
            vGroup.childAlignment = TextAnchor.UpperCenter;

            GameObject languageButtonPrefab = optionsParent.Find("Save Slots").Find("Grid").Find("Slot Row").gameObject;

            foreach (string language in LanguageManager.AllLanguages.Keys)
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
                slotText.text = language;
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


            RectTransform cRect = languagePage.transform.Find("Scroll Rect (1)").Find("Contents").GetComponent<RectTransform>();
            cRect.sizeDelta = new Vector2(600f, LanguageManager.AllLanguages.Keys.Count * 100);

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
            catch (Exception e)
            {
                languageButtonText.text = "LANGUAGES";
                languageButtonTitleText.text = "--" + "LANGUAGES" + "--";
            }


            return true;
        }
    }
}