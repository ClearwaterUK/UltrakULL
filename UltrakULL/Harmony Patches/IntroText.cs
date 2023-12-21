using HarmonyLib;
using TMPro;
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
        public static bool IntroTextStart_MyPatch(IntroText __instance, TMP_Text ___txt, string ___fullString)
        {
            if(isUsingEnglish())
            {
                return true;
            }
            GameObject canvasObj = GetInactiveRootObject("Canvas");
            ___txt = __instance.GetComponent<TMP_Text>();

            TutorialStrings tutStrings = new TutorialStrings(ref canvasObj);
            ___fullString = ___txt.text;

            if (___fullString[0] == 'B') { ___fullString = tutStrings.IntroFirstPage; }
            else { ___fullString = tutStrings.IntroSecondPage; }
            ___txt.text = ___fullString;

            return true;
        }
    }
}
