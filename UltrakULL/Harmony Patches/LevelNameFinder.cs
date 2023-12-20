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
        public static void OnEnable_Postfix(LevelNameFinder __instance, TextMeshProUGUI ___txt)
        {
            if(!isUsingEnglish())
            {
                ___txt.text = "<color=red>" + LanguageManager.CurrentLanguage.shop.shop_cybergrindReturningTo + "</color>:\n" + LevelNames.GetLevelName(__instance.otherLevelNumber);
            }
           
        }
    }
}
