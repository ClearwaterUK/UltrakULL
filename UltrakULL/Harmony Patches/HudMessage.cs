using System.Collections.Generic;
using System.Linq;
using Antlr4.StringTemplate;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using static UnityEngine.KeyCode;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(HudMessage), "Update")]
    public static class HudMessageUpdatePatch
    {
        [HarmonyPrefix]
        public static bool Update_MyPatch(HudMessage __instance, Image ___img, Text ___text)
        {
            if(___img != null && ___text != null)
            {
                return true;
            }
            return false;
        }
    }

    // Overrides the PlayMessage method from the HudMessage class. This is needed for swapping text in message boxes.
    [HarmonyPatch(typeof(HudMessage), "PlayMessage")]
    public static class LocalizeHudMessage
    {
        
        private const string Tutorial = "Tutorial";
        private const string WrathSecret = "Level 5-S";
        private const string DevMuseum = "CreditsMuseum2";
        private const string PreludePrefix = "0-";
        private const char TemplateDelimiter = '$';
        
        private static readonly List<string> Act1Prefixes = new List<string> { "1-", "2-", "3-" };
        private static readonly List<string> Act2Prefixes = new List<string> { "4-", "5-", "6-" };
        
        [HarmonyPrefix]
        public static bool PlayMessage_MyPatch(HudMessage __instance)
        {
            if (!TryGetTranslationObject(out var translation))
                return true;

            if (!TryLoadMetadata(out var sceneReference) || sceneReference.HudMessageSource == null) 
                return true;
            
            foreach (var hudSource in sceneReference.HudMessageSource)
                foreach (var hudObject in hudSource.Objects)
                {
                    if (!hudObject.Equals(GetGameObjectPath(__instance.gameObject)))
                        continue;

                    var template = RepopulateIfNecessary(new Template(hudSource.Message, TemplateDelimiter, TemplateDelimiter)
                        .Add("translation", translation)
                        .Add("input", LocalizeInput(__instance)));

                    __instance.message = template.Render().Replace('$', '\n');
                    __instance.input = string.Empty;
                    __instance.message2 = string.Empty;
                    break;
                }
            
            return true;
        }
        
        private static bool TryGetTranslationObject(out TraversableTranslation translation)
        {
            var currentLanguage = LanguageManager.CurrentLanguage;
            var currentScene = GetCurrentSceneName();

            switch (currentScene)
            {
                case Tutorial: translation = currentLanguage.tutorial;
                    return true;
                case WrathSecret: translation = currentLanguage.fishing;
                    return true;
                case DevMuseum: translation = currentLanguage.devMuseum;
                    return true;
            }

            if (currentScene.Contains(PreludePrefix)) {
                translation = currentLanguage.prelude;
                return true;
            }

            if (Act1Prefixes.Any(prefix => currentScene.Contains(prefix))) {
                translation = currentLanguage.act1;
                return true;
            }

            if (Act2Prefixes.Any(prefix => currentScene.Contains(prefix))) {
                translation = currentLanguage.act2;
                return true;
            }

            translation = default;
            return false;
        }
        
        private static Template RepopulateIfNecessary(Template template)
        {
            if (GetCurrentSceneName() == "Level 4-4")
                return template.Add("altRevolver", LanguageManager.CurrentLanguage.act1.act1_limboFourth_alternateRevolver);
            
            if (GetCurrentSceneName() == "CreditsMuseum2")
                return template.Add("armboy", LanguageManager.CurrentLanguage.act2.act2_heresyFirst_armboy);

            return template;
        }

        private static string LocalizeInput(HudMessage hudMessage)
        {
            try
            {
                if (hudMessage == null || hudMessage.input == string.Empty)
                    return string.Empty;
                
                var misc = LanguageManager.CurrentLanguage.misc;
                var keyCode = MonoSingleton<InputManager>.Instance.Inputs[hudMessage.input];

                switch (keyCode)
                {
                    case Mouse0: return misc.controls_leftClick;
                    case Mouse1: return misc.controls_rightClick;
                    case Mouse2: return misc.controls_middleClick;
                    default: return keyCode.ToString();
                }
            }
            catch (KeyNotFoundException e)
            {
                return string.Empty;
            }
        }
        
        private static bool TryLoadMetadata(out SceneReference reference)
        {
            if (LanguageManager.SubtitlesConfig != null
                && LanguageManager.SubtitlesConfig.Scenes.TryGetValue(GetCurrentSceneName(), out reference))
                return true;

            reference = default;
            return false;
        }
    }
}
