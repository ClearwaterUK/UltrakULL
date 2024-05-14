﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(CheatsManager))]
    public static class CheatsManagerPatch
    {
        /*[HarmonyPatch("StartRebind"), HarmonyPostfix]
        public static void StartRebind_Postfix(Dictionary<ICheat, CheatMenuItem> ___menuItems, ref ICheat cheat) 
        {
            ___menuItems[cheat].bindButtonText.text = LanguageManager.CurrentLanguage.cheats.cheats_pressAnyKey;//Press any key
        }*/

        [HarmonyPatch("RebuildMenu"), HarmonyPostfix]
        public static void RebuildMenu_Postfix()
        {
            if(isUsingEnglish())
            {
                return;
            }
            
            GameObject canvas = GetInactiveRootObject("Canvas");

            GameObject cheatMenu = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvas, "Cheat Menu"), "Cheats Manager"), "Scroll View"), "Viewport");

            CheatMenuItem[] cheatList = cheatMenu.GetComponentsInChildren<CheatMenuItem>();
            foreach (CheatMenuItem category in cheatList)
            {
                switch(category.longName.text)
                {
                    case "META": { category.longName.text = LanguageManager.CurrentLanguage.cheats.cheats_categoryMeta; break; }
                    case "SANDBOX": { category.longName.text = LanguageManager.CurrentLanguage.cheats.cheats_categorySandbox; break; }
                    case "GENERAL": { category.longName.text = LanguageManager.CurrentLanguage.cheats.cheats_categoryGeneral; break; }
                    case "MOVEMENT": { category.longName.text = LanguageManager.CurrentLanguage.cheats.cheats_categoryMovement; break; }
                    case "WEAPONS": { category.longName.text = LanguageManager.CurrentLanguage.cheats.cheats_categoryWeapons; break; }
                    case "ENEMIES": { category.longName.text = LanguageManager.CurrentLanguage.cheats.cheats_categoryEnemies; break; }
                    case "VISUAL": { category.longName.text = LanguageManager.CurrentLanguage.cheats.cheats_categoryVisual; break; }
                    case "SPECIAL": { category.longName.text = LanguageManager.CurrentLanguage.cheats.cheats_categorySpecial; break; }
                }
            }
        }


        //@Override
        //Overrides the *private* UpdateCheatState function from the CheatsManager class for translating the cheat menu.
        [HarmonyPatch("UpdateCheatState", new Type[] { typeof(CheatMenuItem), typeof(ICheat) }), HarmonyPrefix]
        public static bool UpdateCheatState_MyPatch(CheatMenuItem item, ICheat cheat, CheatsManager __instance, Color ___enabledColor, Color ___disabledColor)
        {
            try
            {
                item.longName.text = Cheats.GetCheatName(cheat.Identifier);
                item.stateBackground.color = (cheat.IsActive ? ___enabledColor : ___disabledColor);
                
                string cheatDisabledStatus = Cheats.GetCheatStatus(cheat.ButtonDisabledOverride);
                string cheatEnabledStatus = Cheats.GetCheatStatus(cheat.ButtonEnabledOverride);
                
                item.stateText.text = (cheat.IsActive ? (cheatEnabledStatus ?? LanguageManager.CurrentLanguage.cheats.cheats_activated) : (cheatDisabledStatus ?? LanguageManager.CurrentLanguage.cheats.cheats_deactivated)); //Cheat status
                item.bindButtonBack.gameObject.SetActive(false);
                
                string text = MonoSingleton<CheatBinds>.Instance.ResolveCheatKey(cheat.Identifier);
                if (string.IsNullOrEmpty(text))
                {
                    item.bindButtonText.text = LanguageManager.CurrentLanguage.cheats.cheats_pressToBind; //Press to bind
                }
                else
                {
                    item.bindButtonText.text = text.ToUpper();
                }
                GameObject parentResetButton = item.resetBindButton.gameObject;
                TextMeshProUGUI parentResetText = CommonFunctions.GetTextMeshProUGUI(CommonFunctions.GetGameObjectChild(parentResetButton, "Text"));
                parentResetText.text = LanguageManager.CurrentLanguage.cheats.cheats_delete;
                __instance.RenderCheatsInfo();
                return false;
            }
            catch (Exception e)
            {
                HandleError(e);
                return true;
            }
        }

        //@Override
        //Overrides the RenderCheatsInfo function from the CheatsManager class for displaying the active cheats on the HUD.
        [HarmonyPatch("RenderCheatsInfo"), HarmonyPrefix]
        public static bool RenderCheatsInfo_MyPatch(CheatsManager __instance, Dictionary<string, List<ICheat>> ___allRegisteredCheats)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (MonoSingleton<SandboxNavmesh>.Instance && MonoSingleton<SandboxNavmesh>.Instance.isDirty)
            {
                stringBuilder.AppendLine("<color=red>" + LanguageManager.CurrentLanguage.cheats.cheats_navmeshOutdated1 + "\n<size=12>" + LanguageManager.CurrentLanguage.cheats.cheats_navmeshOutdated2 + "</size></color>\n");
            }
            if (__instance.GetCheatState("ultrakill.spawner-arm"))
            {
                stringBuilder.AppendLine("<color=#C2D7FF>" + LanguageManager.CurrentLanguage.cheats.cheats_spawnerArmSlot + "</color>\n");
            }
            foreach (KeyValuePair<string, List<ICheat>> keyValuePair in ___allRegisteredCheats)
            {
                foreach (ICheat cheat2 in from cheat in keyValuePair.Value
                                          where cheat.IsActive
                                          select cheat)
                {
                    string text = MonoSingleton<CheatBinds>.Instance.ResolveCheatKey(cheat2.Identifier);
                    if (!string.IsNullOrEmpty(text))
                    {
                        stringBuilder.Append("[<color=orange>" + text.ToUpper() + "</color>] ");
                    }
                    else
                    {
                        stringBuilder.Append("[ ] ");
                    }
                    stringBuilder.Append("<color=white>" + Cheats.GetCheatName(cheat2.Identifier) + "</color>\n");
                }
            }
            MonoSingleton<CheatsController>.Instance.cheatsInfo.text = stringBuilder.ToString();
            return false;
        }
    }
}
