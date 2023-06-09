using System;
using HarmonyLib;
using UltrakULL.audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.AudioSwaps
{
    //Fix for audio being unswapped when respawning. Needs testing.
    [HarmonyPatch(typeof(NewMovement),"Respawn")]
    public class RespawnAudioFixer
    {
        [HarmonyPostfix]
        public static void Respawn_SwapperFix()
        {
            AudioSwapper.AudioSwap(GetCurrentSceneName());
        }
        
    }
    

}