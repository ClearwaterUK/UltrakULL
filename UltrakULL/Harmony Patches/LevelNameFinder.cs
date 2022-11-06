using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltrakULL.json;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(LevelNameFinder), "OnEnable")]
    public static class LevelNameFinder_Translation
    {
        [HarmonyPostfix]
        public static void OnEnable_Postfix(LevelNameFinder __instance, Text ___targetText)
        {
            ___targetText.text = "<color=red>" + LanguageManager.CurrentLanguage.shop.shop_cybergrindReturningTo + "</color>:\n" + LevelNames.getLevelName(__instance.otherLevelNumber);
        }
    }
}
