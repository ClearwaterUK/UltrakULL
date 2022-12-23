using HarmonyLib;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches
{

    //@Override
    //Overrides the Toggle function from the CustomPatterns class for the toggle text.
    [HarmonyPatch(typeof(CustomPatterns), "Toggle")]
    public static class LocalizeCustomPatternToggle
    {
        [HarmonyPrefix]
        public static bool Toggle_MyPatch(CustomPatterns __instance, Text ___stateButtonText)
        {
            try
            {
                bool customPatternMode = MonoSingleton<EndlessGrid>.Instance.customPatternMode;
                MonoSingleton<EndlessGrid>.Instance.customPatternMode = !customPatternMode;
                ___stateButtonText.text = (customPatternMode ? LanguageManager.CurrentLanguage.misc.state_deactivated : LanguageManager.CurrentLanguage.misc.state_activated);
                GameObject gameObject = __instance.enableWhenCustom;
                if (gameObject != null)
                {
                    gameObject.SetActive(!customPatternMode);
                }
                MonoSingleton<PrefsManager>.Instance.SetBoolLocal("cyberGrind.customPool", MonoSingleton<EndlessGrid>.Instance.customPatternMode);

                return false;
            }
            catch (Exception e)
            {
                HandleError(e);
                return true;
            }
        }
    }
}
