using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches.Subtitles.HUD
{
    [HarmonyPatch(typeof(EndlessGrid))]
    public static class EndlessGridHudSwap
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(EndlessGrid), "DisplayNoPatternWarning")]
        public static bool EndlessGrid_DisplayNoPatternWarning()
        {
            MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage(LanguageManager.CurrentLanguage.cyberGrind
                .cybergrind_noPatternsSelected);
            return false;
        }
    }
}