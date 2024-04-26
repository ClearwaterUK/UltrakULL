using HarmonyLib;
using System;
using Sandbox;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using static UltrakULL.CommonFunctions;
using UltrakULL.json;
using System.Diagnostics.Eventing.Reader;

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

            TextMeshProUGUI[] tmpList = dupeSaveList.GetComponentsInChildren<TextMeshProUGUI>();
            foreach (TextMeshProUGUI textObject in tmpList)
            {
                switch (textObject.text)
                {
                    case "DELETE": { textObject.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesDelete; break; }
                    case "SAVE": { textObject.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesSave; break; }
                    case "LOAD": { textObject.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesLoad; break; }
                }
            }
        }
    }

    [HarmonyPatch(typeof(WorldOptions), "ToggleBorder")]
    public static class SandboxWorldOptions
    {
        [HarmonyPostfix]
        public static void sandboxWorldOptions_Postfix(ref WorldOptions __instance, TextMeshProUGUI ___borderStatus, TextMeshProUGUI ___buttonText, bool ___isBorderOn)
        {
            if(isUsingEnglish())
            {
                return;
            }
            ___borderStatus.text = (___isBorderOn ? LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsEnabled : LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsDisabled);
            ___buttonText.text = (___isBorderOn ? LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsEnable : LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsDisable);
        }
    }
    
    [HarmonyPatch(typeof(AlterMenuElements))]
    public static class SandboxAlterOptions
    {
        [HarmonyPatch("CreateTitle"), HarmonyPrefix]
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
                case "Hook Point": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_hookPointTitle; break;}
                case "Breakable": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_metaBreakable; break;}
                case "v2": { name = LanguageManager.CurrentLanguage.enemyNames.enemyname_v2; break;}
                case "swordsmachine": { name = LanguageManager.CurrentLanguage.enemyNames.enemyname_swordsmachine; break;}
                case "drone": { name = LanguageManager.CurrentLanguage.enemyNames.enemyname_virtue; break;}
                case "statue": { name = LanguageManager.CurrentLanguage.enemyNames.enemyname_cerberus; break;}
                case "mindflayer": { name = LanguageManager.CurrentLanguage.enemyNames.enemyname_mindFlayer; break;}
                case "malicious face": { name = LanguageManager.CurrentLanguage.enemyNames.enemyname_malFace; break;}
                case "Material Block": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_materialBlock; break; }
                case "Dual Wield Pickup": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_dualWieldPickup; break; }
                case "Hurt Zone": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_hurtZone; break; }
                case "Sandbox": { name = LanguageManager.CurrentLanguage.frontend.chapter_sandbox; break; }
                default:{break;}
                    
            }
            return true;
        }

        [HarmonyPatch("CreateBoolRow"), HarmonyPrefix]
        public static bool sandboxAlterBoolOptions_Prefix(ref string name, bool initialState, Action<bool> callback, AlterMenuElements __instance)
        {
            if(isUsingEnglish())
            {
                return true;
            }
            switch (name)
            {
                case "Boss Health Bar": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_boss_description; break;}
                case "Enraged": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_enrage; break;}
                case "Eternal Rage": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_enrageEternal; break;}
                case "Sandified": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_sandified; break;}
                case "Puppeted": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_puppeted; break;}
                case "Ignore Player": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_ignorePlayer; break;}
                case "Attack Enemies": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_attackEnemies; break;}
                case "Force": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_power; break;}
                case "Weak": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_metaWeak; break;}
                case "Unbreakable": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_metaUnbreakable; break; }
                case "Has Skull": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_hasSkull; break; }
                //Dual Wield Pickup
                case "Infinite Uses": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_infiniteUses; break; }

                default:{break;}
                    
            }
            return true;
        }

        [HarmonyPatch("CreateFloatRow"), HarmonyPrefix]
        public static bool sandboxAlterFloatOptions_Prefix(ref string name)
        {
            if (isUsingEnglish())
            {
                return true;
            }
            switch (name)
            {
                //Dual Wield Pickup
                case "Juice": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_juice; break; }
                //Hurtzone
                case "Damage": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceDamage_tier; break; }
                case "Hurt Cooldown": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_hurtCooldown; break; }
                default: { break; }
            }
            return true;
        }
        [HarmonyPatch("CreateVector3Row"), HarmonyPrefix]
        public static bool sandboxAlterVector3Options_Prefix(ref string name)
        {
            if (isUsingEnglish())
            {
                return true;
            }
            switch (name)
            {
                //procedural block
                case "Size": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_sizeTitle; break; }
                default: { break; }
            }
            return true;
        }
        [HarmonyPatch("CreateEnumRow"), HarmonyPrefix]
        public static bool sandboxAlterEnumOptions_Prefix(ref string name)
        {
            if (isUsingEnglish())
            {
                return true;
            }
            switch (name)
            {
                //skull
                case "Altar Type": { name = LanguageManager.CurrentLanguage.misc.enemyAlter_altarType; break; }
                default: { break; }
            }
            return true;
        }
        [HarmonyPatch(typeof(Enum), "GetNames"), HarmonyPostfix]
        public static void Postfix(ref string[] __result, Type enumType)
        {
            if (enumType == typeof(AltarType))
            {
                __result = new string[] { LanguageManager.CurrentLanguage.misc.enemyAlter_altarBlue, LanguageManager.CurrentLanguage.misc.enemyAlter_altarRed, LanguageManager.CurrentLanguage.misc.enemyAlter_altarStone };
            }
        }
    }
}
