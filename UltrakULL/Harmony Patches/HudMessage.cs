using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using System;

using UltrakULL.json;

namespace UltrakULL.Harmony_Patches
{

    [HarmonyPatch(typeof(HudMessage), "Update")]
    public static class HudMessageUpdatePatch
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

    [HarmonyPatch(typeof(HudMessageReceiver),"SendHudMessage")]
    public static class SendHudMessagePatch
    {
        [HarmonyPrefix]
        public static bool SendHudMessage_Prefix(ref string newmessage, string newinput = "", string newmessage2 = "", int delay = 0, bool silent = false)
        {
            newmessage = HUDMessages.GetHUDToolTip(newmessage);
            return true;
        }
    }

    //@Override
    //Overrides the PlayMessage method from the HudMessage class. This is needed for swapping text in message boxes.
    [HarmonyPatch(typeof(HudMessage), "PlayMessage")]
    public static class LocalizeHudMessage
    {
        [HarmonyPostfix]
        public static void PlayMessage_MyPatch(HudMessage __instance, bool ___activated, HudMessageReceiver ___messageHud, Text ___text, Image ___img)
        {
            //The HUD display uses 2 kinds of messages.
            //One for messages that displays KeyCode inputs (for controls), and one that doesn't.
            //Get the string table based on the area of the game we're currently in.

            Logging.Warn("At start");
            ___messageHud = MonoSingleton<HudMessageReceiver>.Instance;
            ___text = ___messageHud.text;
            if (__instance.input == "")
            {
                Logging.Warn("In if");
                string newMessage = StringsParent.GetMessage(__instance.message, __instance.message2, "");
                ___text.text = newMessage;
            }
            else
            {
                Logging.Warn("In else");
                string controlButton;
                try
                {
                    KeyCode keyCode = MonoSingleton<InputManager>.Instance.Inputs[__instance.input];
                    Logging.Warn("Keycode");

                    if (keyCode == KeyCode.Mouse0)
                    {
                        Logging.Warn("If1");
                        controlButton = LanguageManager.CurrentLanguage.misc.controls_leftClick;
                    }
                    else if (keyCode == KeyCode.Mouse1)
                    {
                        Logging.Warn("If2");
                        controlButton = LanguageManager.CurrentLanguage.misc.controls_rightClick;
                    }
                    else if (keyCode == KeyCode.Mouse2)
                    {
                        Logging.Warn("If3");
                        controlButton = LanguageManager.CurrentLanguage.misc.controls_middleClick;
                    }
                    else
                    {
                        Logging.Warn("Else");
                        controlButton = keyCode.ToString();
                    }
                }
                catch (Exception e)
                {
                    Logging.Warn("Meh");
                    controlButton = "";
                }
                
                //Messages that get input.

                //Compare the start of the first message with the string table.
                Logging.Warn("Compare");
                __instance.message = StringsParent.GetMessage(__instance.message, __instance.message2, controlButton);

                Logging.Warn("Replace");
                ___text.text = __instance.message;
            }
            ___text.text = ___text.text.Replace('$', '\n');
        }
    }
}
