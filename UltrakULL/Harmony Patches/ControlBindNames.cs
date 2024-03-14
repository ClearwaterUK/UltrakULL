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
                case "REVOLVER": { return LanguageManager.CurrentLanguage.options.controls_revolver; }
                case "SHOTGUN": { return LanguageManager.CurrentLanguage.options.controls_shotgun; }
                case "NAILGUN": { return LanguageManager.CurrentLanguage.options.controls_nailgun; }
                case "RAILCANNON": { return LanguageManager.CurrentLanguage.options.controls_railcannon; }
                case "ROCKET LAUNCHER": { return LanguageManager.CurrentLanguage.options.controls_rocketLauncher; }
                case "NEXT WEAPON": { return LanguageManager.CurrentLanguage.options.controls_nextWeapon; }
                case "PREVIOUS WEAPON": { return LanguageManager.CurrentLanguage.options.controls_previousWeapon; }
                case "LAST WEAPON": { return LanguageManager.CurrentLanguage.options.controls_lastUsedWeapon; }
                case "CHANGE FIST": { return LanguageManager.CurrentLanguage.options.controls_changeArm; }
                case "PUNCH": { return LanguageManager.CurrentLanguage.options.controls_punch; }
                case "PUNCH (FEEDBACKER)": { return LanguageManager.CurrentLanguage.options.controls_punchFeedbacker; }
                case "PUNCH (KNUCKLEBLASTER)": { return LanguageManager.CurrentLanguage.options.controls_punchKnuckleblaster; }
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
