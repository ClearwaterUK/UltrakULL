using System;
using System.Net.Mime;
using HarmonyLib;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    public class TextFontSwap
    {
        [HarmonyPatch(typeof(Text), "OnEnable")]
        public static class TextFontSwapper
        {
            [HarmonyPostfix]
            public static void SwapFont(ref Text __instance)
            {
                if(Core.GlobalFontReady)
                {
                    if(GetCurrentSceneName() == "CreditsMuseum2")
                    {
                        if(__instance.font.fontNames[0] == "GFS Garaldus")
                        {
                            __instance.font = Core.MuseumFont;
                        }
                        else
                        {
                            __instance.font = Core.GlobalFont;
                        }
                    }
                    else
                    {
                        __instance.font = Core.GlobalFont;
                    }
                }
            }
        }
    }
}