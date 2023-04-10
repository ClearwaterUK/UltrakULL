using HarmonyLib;
using System;
using Sandbox;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(SandboxHud), "BuildSavesMenu")]
    public static class SandboxHudPatch
    {
        [HarmonyPostfix]
        public static void BuildSavesMenu_Postfix(ref SandboxHud __instance, ref SandboxSaveItem ___sandboxSaveTemplate)
        {
            GameObject canvas = GetInactiveRootObject("Canvas");
            
            GameObject dupeSaveList = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvas,"Cheat Menu"),"Sandbox Saves"),"Scroll View"),"Viewport"),"Content");

            Transform[] transformList = dupeSaveList.GetComponentsInChildren<Transform>();

            foreach (Transform t in transformList)
            {
                if(t.gameObject.name == "Text")
                {
                    Text textObject = GetTextfromGameObject(t.gameObject);
                    switch(textObject.text)
                    {
                        case "Delete": { textObject.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesDelete; break; }
                        case "Save": { textObject.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesSave; break; }
                        case "Load": { textObject.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesLoad; break; }
                    }

                }
            }
        }
    }

    [HarmonyPatch(typeof(StatsDisplay), "UpdateDisplay")]
    public static class SandboxShopPatch
    {
        [HarmonyPostfix]
        public static void SandboxShopPatch_Postfix(StatsDisplay __instance, ref Text ___textContent)
        {
            SandboxStats sandboxStats = SteamController.Instance.GetSandboxStats();
            ___textContent.text = string.Format("<color=orange>{0}</color> - " + LanguageManager.CurrentLanguage.sandbox.sandbox_shop_totalBoxes + "\n",sandboxStats.brushesBuilt)
                                  + string.Format("<color=orange>{0}</color> - " + LanguageManager.CurrentLanguage.sandbox.sandbox_shop_totalProps +  "\n",sandboxStats.propsSpawned)
                                  + string.Format("<color=orange>{0}</color> - " + LanguageManager.CurrentLanguage.sandbox.sandbox_shop_totalEnemies + "\n",sandboxStats.enemiesSpawned)
                                  + string.Format("<color=orange>{0:F1}h</color> - " +  LanguageManager.CurrentLanguage.sandbox.sandbox_shop_totalTime + "\n", sandboxStats.hoursSpend);
        }
    }

    [HarmonyPatch(typeof(WorldOptions), "ToggleBorder")]
    public static class SandboxWorldOptions
    {
        [HarmonyPostfix]
        public static void sandboxWorldOptions_Postfix(ref WorldOptions __instance, Text ___borderStatus, Text ___buttonText, bool ___isBorderOn)
        {
            ___borderStatus.text = (___isBorderOn ? LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsEnabled : LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsDisabled);
            ___buttonText.text = (___isBorderOn ? LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsEnable : LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsDisable);
        }
    }
}
