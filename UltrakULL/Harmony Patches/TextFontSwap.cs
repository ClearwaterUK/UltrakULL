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
                if (MainPatch.GlobalFontReady)
                {
                    if (GetCurrentSceneName() == "CreditsMuseum2")
                    {
                        Text[] allTextElements = UnityEngine.Object.FindObjectsOfType<Text>();

                        foreach (Text textElement in allTextElements)
                        {
                            if (textElement.font.fontNames[0] == "GFS Garaldus")
                            {
                                // Changes the font for all text elements that have the font "GFS Garaldus".

                                //Checks for an alternative font and prevents a bug which can cause all fonts to break, even if they should not be replaced. (maybe already fixed)
                                if (MainPatch.SecondFont != null)
                                {
                                    textElement.font = MainPatch.SecondFont;
                                }
                                else
                                {
                                    Logging.Error("The second font is not loaded. Cancelling the change of the font of this object.");
                                }
                            }
                            else
                            {
                                if (textElement.font != MainPatch.SecondFont)
                                {
                                    textElement.font = MainPatch.GlobalFont; // Doesn't let you replace fonts that have already been replaced with another font.
                                }
                                
                            }
                        }
                    }
                    else
                    {
                        // Change the font for all items at other locations
                        Text[] allTextElements = UnityEngine.Object.FindObjectsOfType<Text>();
                        foreach (Text textElement in allTextElements)
                        {
                            textElement.font = MainPatch.GlobalFont;
                        }
                    }
                }
            }
        }
    }
}