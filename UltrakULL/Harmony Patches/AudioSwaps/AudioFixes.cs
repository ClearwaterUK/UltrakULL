using System;
using HarmonyLib;
using UltrakULL.audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;


namespace UltrakULL.Harmony_Patches
{
    //Fix for audio being unswapped when respawning. Needs testing.
    [HarmonyPatch(typeof(NewMovement),"Respawn")]
    public class RespawnAudioFixer
    {
        [HarmonyPostfix]
        public static void Respawn_SwapperFix()
        {
            AudioSwapper.audioSwap(SceneManager.GetActiveScene().name);
        }
        
    }
    
    //Fix for subtitle toggle always being affected by dubbing toggle.
    [HarmonyPatch(typeof(OptionsMenuToManager),"SetSubtitles")]
    public class OptionsSubtitleFixer
    {
        [HarmonyPrefix]
        public static bool Options_SubtitleFix(ref bool state)
        {
            state = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getInactiveRootObject("Canvas"),
            "OptionsMenu"),"Audio Options"),"Image"),"Subtitles Checkbox").GetComponentInChildren<Toggle>().isOn;
            return true;
        }
    }
}