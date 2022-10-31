using HarmonyLib;
using UltrakULL.json;
using UnityEngine;
using static UltrakULL.CommonFunctions;
using UnityEngine.UI;
using System;
using System.Linq;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides Check from the vanilla game. Used for persistant difficulty strings across all scenes.
    [HarmonyPatch(typeof(GameProgressSaver), "Check")]
    public static class Localize_GameprogressCheck
    {
        [HarmonyPrefix]
        public static bool Check_MyPatch(DifficultyTitle __instance, Text ___txt)
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
    }

    //@Override
    //Overrides checkScore function from the vanilla game. This translates level names, as well as if challenges have been completed or not. POSTFIX.
    [HarmonyPatch(typeof(GameProgressSaver), "CheckScore")]
    public static class Localize_GameProgressChallenges
    {
        [HarmonyPostfix]
        public static void CheckScore_MyPatchPostFix(LevelSelectPanel __instance)
        {
            int num = __instance.levelNumber;
            RankData rank = GameProgressSaver.GetRank(num, false);

            //Bandaid fix for P-2 and P-3 for now since they share the same level id as P-1 for some reason. Shall need to change/remove when they release.
            if (__instance.transform.Find("Name").GetComponent<Text>().text.Contains("P-2"))
            {
                __instance.transform.Find("Name").GetComponent<Text>().text = "P-2: ???";
            }
            else if (__instance.transform.Find("Name").GetComponent<Text>().text.Contains("P-3"))
            {
                __instance.transform.Find("Name").GetComponent<Text>().text = "P-3: ???";
            }
            else
            {
                __instance.transform.Find("Name").GetComponent<Text>().text = LevelNames.getLevelName(num); //Level Name
            }
            if (rank.levelNumber == __instance.levelNumber || (__instance.levelNumber == 666 && rank.levelNumber == __instance.levelNumber + __instance.levelNumberInLayer - 1))
            {
                if (__instance.challengeIcon)
                {
                    if (LanguageManager.CurrentLanguage.frontend.level_challengeCompleted == null)
                        return;
                    if (rank.challenge)
                    {
                        __instance.challengeIcon.fillCenter = true;
                        Text componentInChildren2 = __instance.challengeIcon.GetComponentInChildren<Text>();
                        componentInChildren2.text = String.Join(" ", LanguageManager.CurrentLanguage.frontend.level_challengeCompleted.ToList()); //Challenge completed
                    }
                    else
                    {
                        __instance.challengeIcon.fillCenter = false;
                        Text componentInChildren3 = __instance.challengeIcon.GetComponentInChildren<Text>();
                        componentInChildren3.text = String.Join(" ", LanguageManager.CurrentLanguage.frontend.level_challenge.ToList()); //Challenge not completed
                        componentInChildren3.color = Color.white;
                    }
                }
            }
            return;
        }
    }
}
