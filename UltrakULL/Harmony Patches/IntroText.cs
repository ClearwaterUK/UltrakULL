using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the Start function from IntroText. This is needed for patched text to appear on the tutorial.
    [HarmonyPatch(typeof(IntroText), "Start")]
    public static class LocalizeIntroText
    {
        [HarmonyPrefix]
        public static bool IntroTextStart_MyPatch(IntroText __instance, Text ___txt, string ___fullString)
        {
            GameObject canvasObj = GetInactiveRootObject("Canvas");
            ___txt = __instance.GetComponent<Text>();

            TutorialStrings tutStrings = new TutorialStrings(ref canvasObj);
            ___fullString = ___txt.text;

            if (___fullString[0] == 'B') { ___fullString = tutStrings.introFirstPage; }
            else { ___fullString = tutStrings.introSecondPage; }
            ___txt.text = ___fullString;

            return true;
        }
    }
}
