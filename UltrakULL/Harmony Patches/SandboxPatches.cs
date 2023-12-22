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
            if(isUsingEnglish())
            {
                return;
            }
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

    [HarmonyPatch(typeof(WorldOptions), "ToggleBorder")]
    public static class SandboxWorldOptions
    {
        [HarmonyPostfix]
        public static void sandboxWorldOptions_Postfix(ref WorldOptions __instance, Text ___borderStatus, Text ___buttonText, bool ___isBorderOn)
        {
            if(isUsingEnglish())
            {
                return;
            }
            ___borderStatus.text = (___isBorderOn ? LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsEnabled : LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsDisabled);
            ___buttonText.text = (___isBorderOn ? LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsEnable : LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsDisable);
        }
    }
    
    [HarmonyPatch(typeof(AlterMenuElements),"CreateTitle")]
    public static class SandboxAlterOptionsTitles
    {
        [HarmonyPrefix]
        public static bool sandboxAlterOptionsTitles_Prefix(ref string name)
        {
            if(isUsingEnglish())
            {
                return true;
            }
            switch (name)
            {
                case "enemy": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_boss_title; break;}
                case "Jump Pad": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_jumpPadTitle; break;}
                case "Breakable": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_metaBreakable; break;}
                default:{break;}
                    
            }
            return true;
        }
    }
    
    [HarmonyPatch(typeof(AlterMenuElements),"CreateBoolRow")]
    public static class SandboxAlterOptionsBoxes
    {
        [HarmonyPrefix]
        public static bool sandboxAlterOptions_Prefix(ref string name, bool initialState, Action<bool> callback, AlterMenuElements __instance)
        {
            if(isUsingEnglish())
            {
                return true;
            }
            switch (name)
            {
                case "Boss Health Bar": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_boss_description; break;}
                case "Force": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_jumpPadTitle; break;}
                case "Weak": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_metaWeak; break;}
                case "Unbreakable": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_metaUnbreakable; break;}
                default:{break;}
                    
            }
            return true;
        }
    }
}
