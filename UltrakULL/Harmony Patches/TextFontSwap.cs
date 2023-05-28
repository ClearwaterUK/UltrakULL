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
            public static void SwapFont(Text __instance)
            {
                if(MainPatch.GlobalFontReady)
                {
                    if(GetCurrentSceneName() == "CreditsMuseum2")
                    {
                        //Fix for the museum to prevent plaque fonts from being changed.
                        if(__instance.font.fontNames[0] == "GFS Garaldus") 
                        {
                            //Do nothing xd
                        }
                    }
                    else
                    {
                        __instance.font = MainPatch.GlobalFont;
                    }

                }
            }
        }
    }
}