using System.Net.Mime;
using HarmonyLib;
using UnityEngine.UI;

namespace UltrakULL.Harmony_Patches
{
    public class TextFontSwap
    {
        [HarmonyPatch(typeof(Text), "OnEnable")]
        public static class TextFontSwapper
        {
            [HarmonyPostfix]
            public static void SwapFont(Text __instance)
            {
                if(MainPatch.GlobalFontReady)
                {
                    __instance.font = MainPatch.GlobalFont;
                }
            }
        }
    }
}