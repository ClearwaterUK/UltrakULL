using HarmonyLib;
using UnityEngine;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the DisplaySubtitle method from the SubtitleController class to localize the subtitles
    [HarmonyPatch(typeof(SubtitleController), "DisplaySubtitle")]
    public static class Localize_Subtitles
    {
        [HarmonyPrefix]
        public static bool DisplaySubtitle_MyPatch(SubtitleController __instance, Subtitle ___subtitleLine, Transform ___container, Subtitle ___previousSubtitle, ref string caption, AudioSource audioSource = null)
        {
            caption = SubtitleStrings.getSubtitle(caption);
            return true;
        }
    }
}
