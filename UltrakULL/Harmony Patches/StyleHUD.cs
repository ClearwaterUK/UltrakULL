using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the AddPoints method from the StyleHUD class. This is needed to intercept and translate any strings coming into the style meter in-game.

    [HarmonyPatch(typeof(StyleHUD), "GetLocalizedName")]
    public static class Localize_StyleHud
    {
        [HarmonyPrefix]
        public static bool GetLocalizedName_MyPatch(string id, StyleHUD __instance, Dictionary<string, string> ___idNameDict, ref string __result)
        {
            if (___idNameDict.ContainsKey(id))
            {
                __result = StyleBonusStrings.getStyleBonusDictionary(id);
                return false;
            }
            __result = StyleBonusStrings.getTranslatedStyleBonus(id);
            return false;
        }
    }

    //@Override
    //Overrides the UpdateFreshnessSlider to localize freshness strings
    [HarmonyPatch(typeof(StyleHUD), "UpdateFreshnessSlider")]
    public static class Localize_WeaponFreshnessText
    {
        [HarmonyPrefix]
        public static bool UpdateFreshnessSlider_MyPatch(StyleHUD __instance, GunControl ___gc)
        {
            StyleFreshnessState freshnessState = __instance.GetFreshnessState(___gc.currentWeapon);
            __instance.freshnessSliderText.text = StyleBonusStrings.getWeaponFreshness(freshnessState);

            return false;
        }
    }
}
