using HarmonyLib;
using UltrakULL.audio;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace UltrakULL.Harmony_Patches
{
    //Tentative fix for audio being unswapped when respawning. Needs testing.

    [HarmonyPatch(typeof(NewMovement),"Respawn")]
    public class RespawnAudioFixer
    {
        [HarmonyPostfix]
        public static void Respawn_SwapperFix()
        {
            AudioSwapper.audioSwap(SceneManager.GetActiveScene().name);
        }
        
    }
}