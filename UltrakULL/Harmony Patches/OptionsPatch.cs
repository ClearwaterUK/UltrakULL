﻿using HarmonyLib;
using System.Collections.Generic;
using System;
using TMPro;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(HUDOptions))]
    public static class HUDOptionsPatch
    {
        [HarmonyPatch("Start"), HarmonyPostfix]
        public static void HUDOptionsStartPostfix(TMP_Dropdown ___iconPackDropdown)
        {
            List<TMP_Dropdown.OptionData> iconsDropdownListText = ___iconPackDropdown.options;
            try
            {
                iconsDropdownListText[0].text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_default;
                iconsDropdownListText[1].text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_pitr;
            }
            catch (Exception e)
            { Logging.Warn("Failed to patch icons text in HUD options.");
                Logging.Warn(e.ToString());
            }
        }
    }
    [HarmonyPatch(typeof(HudController))]
    public static class HudControllerPatch
    {
        [HarmonyPatch("SetAlwaysOnTop"), HarmonyPrefix]
        public static bool SetAlwaysOnTop_Prefix(TMP_Text[] ___textElements)
        {
            if (___textElements == null)
            {
                return false;
            }
            TMP_Text[] array = ___textElements;
            for (int i = 0; i < array.Length; i++)
            {
                if(!array[i].font.name.Contains("VCR_OSD_MONO_EXTENDED") && array[i].font.name.Contains("VCR_OSD_MONO"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }

}
