using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the AddPoints method from the StyleHUD class. This is needed to intercept and translate any strings coming into the style meter in-game.

    [HarmonyPatch(typeof(StyleHUD), "GetLocalizedName")]
    public static class LocalizeStyleHud
    {
        [HarmonyPrefix]
        public static bool GetLocalizedName_MyPatch(string id, StyleHUD __instance, Dictionary<string, string> ___idNameDict, ref string __result)
        {
            if(isUsingEnglish())
            {
                return true;
            }
            if (___idNameDict.ContainsKey(id))
            {
                __result = StyleBonusStrings.GetStyleBonusDictionary(id);
                return false;
            }
            __result = StyleBonusStrings.GetTranslatedStyleBonus(id);
            return false;
        }
    }

    //@Override
    //Overrides the UpdateFreshnessSlider to localize freshness strings
    [HarmonyPatch(typeof(StyleHUD), "UpdateFreshnessSlider")]
    public static class LocalizeWeaponFreshnessText
    {
        [HarmonyPrefix]
        public static bool UpdateFreshnessSlider_MyPatch(StyleHUD __instance, GunControl ___gc)
        {
            StyleFreshnessState freshnessState = __instance.GetFreshnessState(___gc.currentWeapon);
            __instance.freshnessSliderText.text = StyleBonusStrings.GetWeaponFreshness(freshnessState);

            return false;
        }
    }

    [HarmonyPatch(typeof(StyleHUD), "AscendRank")]
    public static class StyleHUD_AscendRankPatch
    {
        [HarmonyPrefix]
        public static void Prefix(StyleHUD __instance)
        {
            if (!LanguageManager.IsRightToLeft && LanguageManager.CurrentLanguage.metadata.langName != "Arabic") return;

            try
			{
				int c = Mathf.Clamp(__instance.rankIndex, 0, 7);
				int i = Mathf.Clamp(__instance.rankIndex + 1, 0, 7);
				if (c - i == 0)
				{
					return; // no change
				}
				__instance.ranks[i].sprite = Core.CustomRankImages[i];
            }
            catch (Exception e)
            {
                Logging.Message($"Exception thrown in StyleHUD_AscendRankPatch: {e.Message}");
            }
        }
    }

	[HarmonyPatch(typeof(StyleHUD), "DescendRank")]
	public static class StyleHUD_DescendRankPatch
	{
		[HarmonyPrefix]
		public static void Prefix(StyleHUD __instance)
		{
			if (!LanguageManager.IsRightToLeft && LanguageManager.CurrentLanguage.metadata.langName != "Arabic") return;

			try
			{
                int c = Mathf.Clamp(__instance.rankIndex, 0, 7);
                int i = Mathf.Clamp(__instance.rankIndex - 1, 0, 7);
                if (c - i == 0)
                {
                    return; // no change
                }
                __instance.ranks[i].sprite = Core.CustomRankImages[i];
            }
            catch (Exception e)
            {
                // For some fucking reason this is called an obscene amount of times.
                //Logging.Message($"Exception thrown in StyleHUD_DescendRankPatch: {e.Message}");
            }
		}
	}
    
    /*
	[HarmonyPatch(typeof(StyleHUD), "Awake")]
	public static class StyleHUD_AwakePatch
	{
		static bool patched = false;
        [HarmonyPrefix]
        public static void Prefix(StyleHUD __instance)
        {
			if (!LanguageManager.IsRightToLeft && LanguageManager.CurrentLanguage.metadata.langName != "Arabic") return;

            try
            {
                for (int i = 0; i < 8; i++)
                {
                    __instance.ranks[i].sprite = Core.CustomRankImages[i];
                }
            }
            catch(Exception e)
			{
				Logging.Message($"Exception thrown in StyleHUD_AwakePatch: {e.Message}");
			}
        }
	}
    */
}
