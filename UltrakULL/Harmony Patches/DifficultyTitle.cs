﻿using HarmonyLib;
using UnityEngine.UI;
using UltrakULL.json;
using System;
using TMPro;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides Check from the vanilla game. Used for persistant difficulty strings across all scenes.
    [HarmonyPatch(typeof(DifficultyTitle), "Check")]
    public static class LocalizeGameProgressCheck
    {
        [HarmonyPrefix]
        public static bool Check_MyPatch(DifficultyTitle __instance, ref Text ___txt, ref TMP_Text ___txt2)
        {
            if(isUsingEnglish())
            {
                return false;
            }

            try
            {
                int @int = MonoSingleton<PrefsManager>.Instance.GetInt("difficulty", 0);
                string text = "";
                if (__instance.lines)
                {
                    text += "-- ";

                }

                switch (@int)
                {
                    case 0:
                        text += LanguageManager.CurrentLanguage.frontend.difficulty_harmless;
                        break;
                    case 1:
                        text += LanguageManager.CurrentLanguage.frontend.difficulty_lenient;
                        break;
                    case 2:
                        text += LanguageManager.CurrentLanguage.frontend.difficulty_standard;
                        break;
                    case 3:
                        text += LanguageManager.CurrentLanguage.frontend.difficulty_violent;
                        break;
                    case 4:
                        text += LanguageManager.CurrentLanguage.frontend.difficulty_brutal;
                        break;
                    case 5:
                        text += LanguageManager.CurrentLanguage.frontend.difficulty_umd;
                        break;
                }

                if (__instance.lines)
                {
                    text += " --";
                }

                if (!___txt2)
                {
                    ___txt2 = __instance.GetComponent<TMP_Text>();
                }

                if (___txt2)
                {
                    ___txt2.text = text;
                    return false;
                }

                if (!___txt)
                {
                    ___txt = __instance.GetComponent<Text>();
                }

                if (___txt)
                {
                    ___txt.text = text;
                }

                return false;
            }



            catch (Exception e)
            {
                Logging.Error("Failed to get difficulty strings.");
                Logging.Error(e.ToString());
                return true;
            }
        }
    }
}
