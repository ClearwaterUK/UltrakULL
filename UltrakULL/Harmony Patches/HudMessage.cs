using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UltrakULL.json;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(CutsceneSkipText),"Show")]
    public static class CutsceneSkipTextPatch
    {
        [HarmonyPostfix]
        public static void CutsceneSkipText_Patch(CutsceneSkipText __instance, ref TMP_Text ___txt)
        {
            Console.WriteLine(___txt.text);
            //Need to disable the TextOverride component. Slightly hacky but we can't access TextOverride directly.
            Component[] test = __instance.GetComponents(typeof(Component));
            Behaviour bhvr = (Behaviour)test[3];
            bhvr.enabled = false;
            ___txt.text = LanguageManager.CurrentLanguage.misc.pressToSkip;
        }
    }

    [HarmonyPatch(typeof(HudMessage), "Update")]
    public static class HudMessageUpdatePatch
    {
        [HarmonyPrefix]
        public static bool Update_MyPatch(HudMessage __instance, Image ___img, Text ___text)
        {
            if(isUsingEnglish())
            {
                return false;
            }
            
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
            if(!isUsingEnglish())
            {
                newmessage = HUDMessages.GetHUDToolTip(newmessage);
            }
            
            return true;
        }
    }

    //@Override
    //Overrides the PlayMessage method from the HudMessage class. This is needed for swapping text in message boxes.
    [HarmonyPatch(typeof(HudMessage), "PlayMessage")]
    public static class LocalizeHudMessage
    {
        [HarmonyPostfix]
        public static void PlayMessage_MyPatch(HudMessage __instance, bool ___activated, HudMessageReceiver ___messageHud, TMP_Text ___text, Image ___img)
        {
            if(isUsingEnglish())
            {
                return;
            }
            //The HUD display uses 2 kinds of messages.
            //One for messages that displays KeyCode inputs (for controls), and one that doesn't.
            //Get the string table based on the area of the game we're currently in.
            
            ___messageHud = MonoSingleton<HudMessageReceiver>.Instance;
            ___text = ___messageHud.text;
            if(__instance.actionReference == null)
            {
                string newMessage = StringsParent.GetMessage(__instance.message, __instance.message2, "");
                ___text.text = newMessage;
            }
            
            else
            {
                string bindingString = MonoSingleton<InputManager>.Instance.GetBindingString(__instance.actionReference.action.id);

                //Messages that get input.
                //Compare the start of the first message with the string table.
                __instance.message = StringsParent.GetMessage(__instance.message, __instance.message2, bindingString);
                
                ___text.text = __instance.message;
            }
            ___text.text = ___text.text.Replace('$', '\n');
        }
    }
}
