using HarmonyLib;
using Sandbox;
using TMPro;
using UnityEngine;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(StatsDisplay), "UpdateDisplay")]
    public static class StatsPatchclass
    {
        [HarmonyPostfix]
        public static void StatsPostfix(StatsDisplay __instance, TMP_Text ___textContent)
        {
            if (SteamController.Instance == null)
            {
                return;
            }
            SandboxStats sandboxStats = SteamController.Instance.GetSandboxStats();
            ___textContent.text = string.Format("<color=orange>{0}</color> - " + LanguageManager.CurrentLanguage.sandbox.sandbox_shop_totalBoxes + "\n", sandboxStats.brushesBuilt)
                + string.Format("<color=orange>{0}</color> - "+ LanguageManager.CurrentLanguage.sandbox.sandbox_shop_totalProps + "\n", sandboxStats.propsSpawned)
                + string.Format("<color=orange>{0}</color> - " + LanguageManager.CurrentLanguage.sandbox.sandbox_shop_totalEnemies + "\n", sandboxStats.enemiesSpawned)
                + string.Format("<color=orange>{0:F1}h</color> - " + LanguageManager.CurrentLanguage.sandbox.sandbox_shop_totalTime + "\n", sandboxStats.hoursSpend);
        }
    }
}
