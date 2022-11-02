using HarmonyLib;
using UltrakULL.json;
using UnityEngine;
using static UltrakULL.CommonFunctions;
using UnityEngine.UI;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the Start function from IntroText. This is needed for patched text to appear on the tutorial.
    [HarmonyPatch(typeof(IntroText), "Start")]
    public static class Localize_IntroText
    {
        [HarmonyPrefix]
        public static bool IntroTextStart_MyPatch(IntroText __instance, Text ___txt, string ___fullString)
        {
            ___txt = __instance.GetComponent<Text>();

            TutorialStrings tutStrings = new TutorialStrings();
            ___fullString = ___txt.text;

            if (___fullString[0] == 'B') { ___fullString = tutStrings.introFirstPage; }
            else { ___fullString = tutStrings.introSecondPage; }
            ___txt.text = ___fullString;

            return true;
        }
    }
}
