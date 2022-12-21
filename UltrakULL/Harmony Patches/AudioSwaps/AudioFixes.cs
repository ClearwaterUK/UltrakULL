using HarmonyLib;
using UltrakULL.audio;
using UnityEngine.SceneManagement;

namespace UltrakULL.Harmony_Patches.AudioSwaps
{
    //Fix for audio being unswapped when respawning. Needs testing.
    [HarmonyPatch(typeof(NewMovement),"Respawn")]
    public class RespawnAudioFixer
    {
        [HarmonyPostfix]
        public static void Respawn_SwapperFix()
        {
            AudioSwapper.AudioSwap(SceneManager.GetActiveScene().name);
        }
        
    }
}