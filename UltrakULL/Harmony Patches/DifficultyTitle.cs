using HarmonyLib;
using UnityEngine.UI;
using UltrakULL.json;
using System;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides Check from the vanilla game. Used for persistant difficulty strings across all scenes.
    [HarmonyPatch(typeof(DifficultyTitle), "Check")]
    public static class LocalizeGameProgressCheck
    {
        [HarmonyPrefix]
        public static bool Check_MyPatch(DifficultyTitle __instance, Text ___txt)
        {
            if(isUsingEnglish())
            {
                return false;
            }
            try
            {
                int @int = MonoSingleton<PrefsManager>.Instance.GetInt("difficulty", 0);

                if (___txt == null)
                {
                    ___txt = __instance.GetComponent<Text>();
                }
                ___txt.text = "";

                if (__instance.lines)
                {
                    Text text = ___txt;
                    text.text = "-- ";
                }
                switch (@int)
                {
                    case 0:
                        {
                            Text text2 = ___txt;
                            text2.text += LanguageManager.CurrentLanguage.frontend.difficulty_harmless;
                            break;
                        }
                    case 1:
                        {
                            Text text3 = ___txt;
                            text3.text += LanguageManager.CurrentLanguage.frontend.difficulty_lenient;
                            break;
                        }
                    case 2:
                        {
                            Text text4 = ___txt;
                            text4.text += LanguageManager.CurrentLanguage.frontend.difficulty_standard;
                            break;
                        }
                    case 3:
                        {
                            Text text5 = ___txt;
                            text5.text += LanguageManager.CurrentLanguage.frontend.difficulty_violent;
                            break;
                        }
                    case 4:
                        {
                            Text text6 = ___txt;
                            text6.text += LanguageManager.CurrentLanguage.frontend.difficulty_brutal;
                            break;
                        }
                    case 5:
                        {
                            Text text7 = ___txt;
                            text7.text += LanguageManager.CurrentLanguage.frontend.difficulty_umd;
                            break;
                        }
                }
                if (__instance.lines)
                {
                    Text text8 = ___txt;
                    text8.text += " -- ";
                }
                return false;
            }
            catch(Exception e)
            {
                Logging.Error("Failed to get difficulty strings.");
                Logging.Error(e.ToString());
                return true;
            }
        }
    }
}
