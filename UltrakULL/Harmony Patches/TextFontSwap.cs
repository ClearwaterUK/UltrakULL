using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    public class TextFontSwap
    {
        [HarmonyPatch(typeof(Text), "OnEnable")]
        public static class TextFontSwapper
        {
            [HarmonyPostfix]
            public static void SwapFont(ref Text __instance)
            {
                if(Core.GlobalFontReady)
                {
                    if(GetCurrentSceneName() == "CreditsMuseum2")
                    {
                        if(__instance.font.fontNames[0] == "GFS Garaldus")
                        {
                            __instance.font = Core.MuseumFont;
                        }
                        else
                        {
                            __instance.font = Core.GlobalFont;
                        }
                    }
                    else
                    {
                        __instance.font = Core.GlobalFont;
                    }
                }
            }
        }
    }
    
    public class TextMeshProFontSwap
    {
        [HarmonyPatch(typeof(TextMeshProUGUI), "OnEnable")]
        public static class TextMeshProFontSwapper
        {
            [HarmonyPostfix]
            public static void SwapFont(ref TextMeshProUGUI __instance)
            {
                
                if(Core.TMPFontReady && !isUsingEnglish())
                {
                    string currentLanguage = LanguageManager.CurrentLanguage.metadata.langDisplayName;
                    switch(currentLanguage)
                    {
                        case "Traditional Chinese":
                        case "Simplified Chinese":
                        {
                            //Swap with a Chinese font when it comes in.
                            __instance.font = Core.CJKFontTMP;
                            break;
                        }
                        case "Japanese":
                        {
                            //japanese tofu fix
                            __instance.font = Core.jaFontTMP;
                            break;
                        }
                        default:
                        {
                            if(GetCurrentSceneName() == "CreditsMuseum2")
                            {
                                if(__instance.font.name == "GFS Garaldus")
                                {
                                    __instance.font = Core.MuseumFontTMP;
                                }
                                else
                                {
                                    __instance.font = Core.GlobalFontTMP;
                                }
                            }
                            else
                            {
                                __instance.font = Core.GlobalFontTMP;
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}