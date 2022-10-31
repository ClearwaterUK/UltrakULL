using HarmonyLib;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the SendHudMessage function from the HudMessageReciever class for non-standard HUD messages.
    [HarmonyPatch(typeof(HudMessageReceiver), "SendHudMessage")]
    public static class Localize_SentHudMessage
    {
        [HarmonyPrefix]
        public static bool SendHudMessage_MyPatch(HudMessageReceiver __instance, HudOpenEffect ___hoe, Text ___text, Image ___img, AudioSource ___aud, string ___message, string ___input, string ___message2, bool ___noSound, string newmessage, string newinput = "", string newmessage2 = "", int delay = 0, bool silent = false)
        {
            ___message = newmessage;
            ___input = newinput;
            ___message2 = newmessage2;
            ___noSound = silent;

            if (___input == "")
            {
                ___text.text = HUDMessages.getHUDToolTip(newmessage);
            }
            else
            {
                KeyCode keyCode = MonoSingleton<InputManager>.Instance.Inputs[___input];
                string str;
                if (keyCode == KeyCode.Mouse0)
                {
                    str = LanguageManager.CurrentLanguage.misc.controls_leftClick;
                }
                else if (keyCode == KeyCode.Mouse1)
                {
                    str = LanguageManager.CurrentLanguage.misc.controls_middleClick;
                }
                else if (keyCode == KeyCode.Mouse2)
                {
                    str = LanguageManager.CurrentLanguage.misc.controls_rightClick;
                }
                else
                {
                    str = keyCode.ToString();
                }
                ___text.text = HUDMessages.getHUDToolTip(newmessage) + str + ___message2;
            }

            ___text.text = ___text.text.Replace('$', '\n');
            ___text.enabled = true;
            ___img.enabled = true;
            ___hoe.Force();
            if (!___noSound)
            {
                ___aud.Play();
            }
            __instance.StartCoroutine(Localize_HudMessage.clearTextBox(5f, ___text, ___img));
            return false;
        }
    }
}
