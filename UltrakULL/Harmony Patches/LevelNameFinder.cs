using HarmonyLib;
using UltrakULL.json;
using UnityEngine.UI;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(LevelNameFinder), "OnEnable")]
    public static class LevelNameFinderTranslation
    {
        [HarmonyPostfix]
        public static void OnEnable_Postfix(LevelNameFinder __instance, Text ___targetText)
        {
            ___targetText.text = "<color=red>" + LanguageManager.CurrentLanguage.shop.shop_cybergrindReturningTo + "</color>:\n" + LevelNames.GetLevelName(__instance.otherLevelNumber);
        }
    }
}
