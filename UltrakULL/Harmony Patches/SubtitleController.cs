using HarmonyLib;
using System;
using UnityEngine;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the DisplaySubtitle method from the SubtitleController class to localize the subtitles
    [HarmonyPatch(typeof(SubtitleController), "DisplaySubtitle", new Type[] { typeof(string), typeof(AudioSource) })]
    public static class LocalizeSubtitles
    {
        [HarmonyPrefix]
        public static bool DisplaySubtitle_MyPatch(SubtitleController __instance, Subtitle ___subtitleLine, Transform ___container, Subtitle ___previousSubtitle, ref string caption, AudioSource audioSource = null)
        {
            caption = SubtitleStrings.GetSubtitle(caption);
            return true;
        }
    }
}
