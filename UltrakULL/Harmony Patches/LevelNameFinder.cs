using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(LevelNameFinder), "OnEnable")]
    public static class LevelNameFinderTranslation
    {
        [HarmonyPostfix]
        public static void OnEnable_Postfix(LevelNameFinder __instance, Text ___txt, TMP_Text ___txt2)
        {
            if(!isUsingEnglish())
            {
                if (!___txt)
                {
                    Logging.Warn("1");
                    ___txt = __instance.GetComponent<Text>();
                    Logging.Warn("2");
                }

                if (!___txt2)
                {
                    Logging.Warn("3");
                    ___txt2 = __instance.GetComponent<TMP_Text>();
                    Logging.Warn("4");
                }
                Logging.Warn("5");
                //___txt.text = "RETURNINGTOTEXTHERE"; //"<color=red>" + LanguageManager.CurrentLanguage.shop.shop_cybergrindReturningTo +
                              //"</color>:\n" + "LEVELNAMEHERE";//LevelNames.GetLevelName(__instance.otherLevelNumber);
                Logging.Warn("6");
                //___txt2.text = ___txt.text;
                Logging.Warn("7");
            }
           
        }
    }
}
