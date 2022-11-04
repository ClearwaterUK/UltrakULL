using HarmonyLib;
using UltrakULL.json;
using UnityEngine;
using static UltrakULL.CommonFunctions;
using UnityEngine.UI;
using System.Collections;
using System;

namespace UltrakULL.Harmony_Patches
{

    [HarmonyPatch(typeof(HudMessage), "Update")]
    public static class Update_Patch
    {
        [HarmonyPrefix]
        public static bool Update_MyPatch(HudMessage __instance, Image ___img, Text ___text)
        {
            if(___img != null && ___text != null)
            {
                return true;
            }
            return false;
        }
    }

    //@Override
    //Overrides the PlayMessage method from the HudMessage class. This is needed for swapping text in message boxes.
    [HarmonyPatch(typeof(HudMessage), "PlayMessage")]
    public static class Localize_HudMessage
    {

        [HarmonyPostfix]
        public static void PlayMessage_MyPatch(HudMessage __instance, bool ___activated, HudMessageReceiver ___messageHud, Text ___text, Image ___img)
        {
            //The HUD display uses 2 kinds of messages.
            //One for messages that displays KeyCode inputs (for controls), and one that doesn't.
            //Get the string table based on the area of the game we're currently in.

            ___messageHud = MonoSingleton<HudMessageReceiver>.Instance;
            ___text = ___messageHud.text;
            if (__instance.input == "")
            {
                string newMessage = StringsParent.getMessage(__instance.message, __instance.message2, "");
                ___text.text = newMessage;
            }
            else
            {
                KeyCode keyCode = MonoSingleton<InputManager>.Instance.Inputs[__instance.input];
                string controlButton;
                if (keyCode == KeyCode.Mouse0)
                {
                    controlButton = LanguageManager.CurrentLanguage.misc.controls_leftClick;
                }
                else if (keyCode == KeyCode.Mouse1)
                {
                    controlButton = LanguageManager.CurrentLanguage.misc.controls_rightClick;
                }
                else if (keyCode == KeyCode.Mouse2)
                {
                    controlButton = LanguageManager.CurrentLanguage.misc.controls_middleClick;
                }
                else
                {
                    controlButton = keyCode.ToString();
                }

                //Messages that get input.
                //Console.Write("Input message: " + __instance.message + controlButton + __instance.message2);

                //Compare the start of the first message with the string table.
                __instance.message = StringsParent.getMessage(__instance.message, __instance.message2, controlButton.ToString());

                ___text.text = __instance.message;
            }
            ___text.text = ___text.text.Replace('$', '\n');
        }
    }

}
