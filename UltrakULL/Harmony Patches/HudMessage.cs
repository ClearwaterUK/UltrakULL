using HarmonyLib;
using UltrakULL.json;
using UnityEngine;
using static UltrakULL.CommonFunctions;
using UnityEngine.UI;
using System.Collections;

namespace UltrakULL.Harmony_Patches
{

    //@Override
    //Overrides the PlayMessage method from the HudMessage class. This is needed for swapping text in message boxes.
    [HarmonyPatch(typeof(HudMessage), "PlayMessage")]
    public static class Localize_HudMessage
    {
        public static HudMessage currentTimedMessage;
        public static Image currentTimedMessageImg;
        public static Text currentTimedMessageText;
        public static bool currentTimedMessageActivated;
        
        [HarmonyPrefix]
        public static bool PlayMessage_MyPatch(HudMessage __instance, ref bool ___activated, HudMessageReceiver ___messageHud, Text ___text, Image ___img)
        {
            //The HUD display uses 2 kinds of messages.
            //One for messages that displays KeyCode inputs (for controls), and one that doesn't.
            //Get the string table based on the area of the game we're currently in.

            ___activated = true;
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
            ___text.enabled = true;
            ___img = ___messageHud.GetComponent<Image>();
            ___img.enabled = true;
            if (__instance.deactivating)
            {
                ___img.enabled = false;
                ___text.enabled = false;
                ___activated = false;
                if (__instance != null)
                {
                    UnityEngine.Object.Destroy(__instance);
                }
            }
            else
            {
                ___messageHud.GetComponent<AudioSource>().Play();
            }
            if (__instance.timed && __instance.notOneTime)
            {
                __instance.CancelInvoke("Done");
                __instance.StartCoroutine(clearTextBox(5f, ___text, ___img));
            }
            else if (__instance.timed)
            {
                clearMessageBox(ref __instance, ref ___activated, ref ___img, ref ___text);
            }
            else
            {
                clearMessageBox(ref __instance, ref ___activated, ref ___img, ref ___text);
            }
            ___messageHud.GetComponent<HudOpenEffect>().Force();

            return false;
        }

        public static void clearMessageBox(ref HudMessage __instance, ref bool ___activated, ref Image ___img, ref Text ___text)
        {
            currentTimedMessage = __instance;
            currentTimedMessageImg = ___img;
            currentTimedMessageText = ___text;
            currentTimedMessageActivated = ___activated;

            __instance.StartCoroutine(wait(5f));
        }

        public static IEnumerator clearTextBox(float seconds, Text text, Image img)
        {
            //Console.WriteLine("Sleeping for " + seconds + "seconds...");
            yield return new WaitForSeconds(seconds);
            text.enabled = false;
            img.enabled = false;
        }

        public static IEnumerator wait(float seconds)
        {
            //Console.WriteLine("Waiting for " + seconds + " seconds...");
            yield return new WaitForSeconds(seconds);

            currentTimedMessage.enabled = false;
            currentTimedMessageImg.enabled = false;
            currentTimedMessageText.enabled = false;
            currentTimedMessageActivated = false;
        }
    }

}
