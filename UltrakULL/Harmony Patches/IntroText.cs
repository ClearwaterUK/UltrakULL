using System.Text;
using Antlr4.StringTemplate;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the Start function from IntroText. This is needed for patched text to appear on the tutorial.
    [HarmonyPatch(typeof(IntroText), "Start")]
    public static class LocalizeIntroText
    {
        private const string Tutorial = "tutorial";
        private const string FirstScreen = "FIRST_SCREEN";
        private const string SecondScreen = "SECOND_SCREEN";
        
        [HarmonyPrefix]
        public static bool IntroTextStart_MyPatch(IntroText __instance, Text ___txt, string ___fullString)
        {
            var introTemplateGroup = new TemplateGroupString(Resources.Intro);
            introTemplateGroup.SetDelimiters('$', '$');
            introTemplateGroup.Encoding = Encoding.Unicode;

            var canvasObj = GetInactiveRootObject("Canvas");
            ___txt = __instance.GetComponent<Text>();
            TutorialStrings.PatchCalibrationWindows(ref canvasObj);

            var template = ___txt.text[0] == 'B'
                ? FirstScreen
                : SecondScreen;
            
            ___fullString = introTemplateGroup
                .GetInstanceOf(template)
                .Add(Tutorial, LanguageManager.CurrentLanguage.tutorial)
                .Render();

            ___txt.text = ___fullString;

            return true;
        }
    }
}
