using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the SetInfo method from the FinalRank class. This is needed to swap text in the extra into box on the results screen.
    [HarmonyPatch(typeof(FinalRank), "SetInfo")]
    public static class LocalizeFinalRankInfo
    {
        [HarmonyPrefix]
        public static bool SetInfo_MyPatch(int restarts, bool damage, bool majorUsed, bool cheatsUsed, FinalRank __instance, bool ___noRestarts, bool ___majorAssists, bool ___noDamage)
        {
            if(isUsingEnglish())
            {
                return true;
            }
            
            __instance.extraInfo.text = "";
            int num = 1;
            if (!damage)
            {
                num++;
            }
            if (majorUsed)
            {
                num++;
            }
            if (cheatsUsed)
            {
                num++;
            }
            if (cheatsUsed)
            {
                TMP_Text text = __instance.extraInfo;
                text.text += "- <color=#44FF45>" + LanguageManager.CurrentLanguage.misc.endstats_cheatsUsed + "</color>\n";
            }
            if (majorUsed)
            {
                TMP_Text text2 = __instance.extraInfo;
                text2.text += "- <color=#4C99E6>" + LanguageManager.CurrentLanguage.misc.endstats_assistsUsed + "</color>\n";
                ___majorAssists = true;
            }
            if (restarts == 0)
            {
                if (num >= 3)
                {
                    TMP_Text text3 = __instance.extraInfo;
                    text3.text += "+ " + LanguageManager.CurrentLanguage.misc.endstats_noRestarts + "\n";
                }
                else
                {
                    TMP_Text text4 = __instance.extraInfo;
                    if (LanguageManager.CurrentLanguage.metadata.langHinduNumbers)
                    {
                        text4.text += "+ " + LanguageManager.CurrentLanguage.misc.endstats_noRestarts + "\n  (+500<color=orange>P</color>)\n";
                    }
                    else
                    {
						text4.text += "+ " + LanguageManager.CurrentLanguage.misc.endstats_noRestarts + "\n  (+500<color=orange>P</color>)\n";
					}
                }
                ___noRestarts = true;
            }
            else
            {
                TMP_Text text5 = __instance.extraInfo;
                text5.text = string.Concat(new object[]
                {
                text5.text,
                "- <color=red>",
                ArabicFixerTool.FixLine(restarts.ToString()),
                "</color> " + LanguageManager.CurrentLanguage.misc.endstats_restarts +"\n"
                });
            }
            if (!damage)
            {
                if (num >= 3)
                {
                    TMP_Text text6 = __instance.extraInfo;
                    text6.text += "+ <color=orange>" + LanguageManager.CurrentLanguage.misc.endstats_noDamage + "</color>\n";
                }
                else
                {
                    TMP_Text text7 = __instance.extraInfo;
                    text7.text += "+ <color=orange>" + LanguageManager.CurrentLanguage.misc.endstats_noDamage + "\n  (</color>+5,000<color=orange>P)</color>\n";
                }
                ___noDamage = true;
            }
            return false;
        }
    }
}
