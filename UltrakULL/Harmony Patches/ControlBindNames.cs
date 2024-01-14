using System;
using System.Collections.Generic;
using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(ControlsOptions), "Rebuild")]
    public class ControlSections
    {
        [HarmonyPostfix]
        public static void controlSectionsPatch_Postfix(ControlSections __instance, List<GameObject> ___rebindUIObjects)
        {
            foreach(GameObject section in ___rebindUIObjects)
            {
                if (section.name == "SectionTemplate(Clone)")
                {
                    TextMeshProUGUI sectionText = GetTextMeshProUGUI(section);
                    switch (sectionText.text)
                    {
                        case "-- MOVEMENT --":
                        {
                            sectionText.text = "-- " + LanguageManager.CurrentLanguage.options.controls_movement + " --";
                            break;
                        }
                        case "-- WEAPON --":
                        {
                            sectionText.text = "-- " + LanguageManager.CurrentLanguage.options.controls_weapons + " --";
                            break;
                        }
                        case "-- FIST --":
                        {
                            sectionText.text = "-- " + LanguageManager.CurrentLanguage.options.controls_arms + " --";
                            break;
                        }
                        default:{ break; }
                    }
                }
            }
        }
    }
    

    [HarmonyPatch(typeof(ControlsOptionsKey),"OnEnable")]
    public class ControlBindNames
    {
        static string getActionName(string originalText)
        {
            switch (originalText)
            {
                case "MOVE": { return LanguageManager.CurrentLanguage.options.controls_move; }
                case "DODGE": { return LanguageManager.CurrentLanguage.options.controls_dash; }
                case "SLIDE": { return LanguageManager.CurrentLanguage.options.controls_slide; }
                case "JUMP": { return LanguageManager.CurrentLanguage.options.controls_jump; }
                case "PRIMARY FIRE": { return LanguageManager.CurrentLanguage.options.controls_primaryFire; }
                case "SECONDARY FIRE": { return LanguageManager.CurrentLanguage.options.controls_secondaryFire; }
                case "CHANGE VARIATION": { return LanguageManager.CurrentLanguage.options.controls_changeVariation; }
                case "SLOT 0": { return LanguageManager.CurrentLanguage.options.controls_slot0; }
                case "SLOT 1": { return LanguageManager.CurrentLanguage.options.controls_slot1; }
                case "SLOT 2": { return LanguageManager.CurrentLanguage.options.controls_slot2; }
                case "SLOT 3": { return LanguageManager.CurrentLanguage.options.controls_slot3; }
                case "SLOT 4": { return LanguageManager.CurrentLanguage.options.controls_slot4; }
                case "SLOT 5": { return LanguageManager.CurrentLanguage.options.controls_slot5; }
                case "SLOT 6": { return LanguageManager.CurrentLanguage.options.controls_slot6; }
                case "SLOT 7": { return LanguageManager.CurrentLanguage.options.controls_slot7; }
                case "SLOT 8": { return LanguageManager.CurrentLanguage.options.controls_slot8; }
                case "SLOT 9": { return LanguageManager.CurrentLanguage.options.controls_slot9; }
                case "NEXT WEAPON": { return LanguageManager.CurrentLanguage.options.controls_nextWeapon; }
                case "PREVIOUS WEAPON": { return LanguageManager.CurrentLanguage.options.controls_previousWeapon; }
                case "LAST WEAPON": { return LanguageManager.CurrentLanguage.options.controls_lastUsedWeapon; }
                case "CHANGE FIST": { return LanguageManager.CurrentLanguage.options.controls_changeArm; }
                case "PUNCH": { return LanguageManager.CurrentLanguage.options.controls_punch; }
                case "HOOK": { return LanguageManager.CurrentLanguage.options.controls_whiplash; }
                default: return originalText;
            }
        }
        
        [HarmonyPostfix]
        public static void controlBindNamesPatch_Postfix(ControlsOptionsKey __instance)
        {
            __instance.actionText.text = getActionName(__instance.actionText.text);
        }
    }
}