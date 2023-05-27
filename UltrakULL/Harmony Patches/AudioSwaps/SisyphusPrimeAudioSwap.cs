using HarmonyLib;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.AudioSwaps
{
    [HarmonyPatch(typeof(SisyphusPrime),"Start")]
    public class SisyphusPrimeAudioSwap
    {
        [HarmonyPostfix]
        public static void SisyphusPrimeAudioSwapPatch(ref SisyphusPrime __instance)
        {
            if(LanguageManager.configFile.Bind("General","activeDubbing","False").Value == "False")
            {
                return;
            }
            
            string sisyphusPrimeFolder =  AudioSwapper.SpeechFolder + "sisyphusPrime\\";
            
            AudioClip[] begoneAttacks  = __instance.clapVoice;
            for(int x = 0; x < begoneAttacks.Length; x++)
            {
                string minosPrimeKickString = sisyphusPrimeFolder + "sisyphusBegone" + (x+1).ToString() + ".wav";
                begoneAttacks[x] =  AudioSwapper.SwapClipWithFile(begoneAttacks[x], minosPrimeKickString);
            }
            
            AudioClip[] thisWillHurtAttack = __instance.explosionVoice;
            for(int x = 0; x < thisWillHurtAttack.Length; x++)
            {
                string thisWillHurtString = sisyphusPrimeFolder + "sisyphusThisWillHurt.wav";
                begoneAttacks[x] =  AudioSwapper.SwapClipWithFile(begoneAttacks[x], thisWillHurtString);
            }
            
            AudioClip[] grunt = __instance.hurtVoice;
            for(int x = 0; x < grunt.Length; x++)
            {
                string gruntString = sisyphusPrimeFolder + "sisyphusGrunt.wav";
                grunt[x] =  AudioSwapper.SwapClipWithFile(grunt[x], gruntString);
            }
            
            AudioClip[] stompAttacks = __instance.stompComboVoice;
            for(int x = 0; x < stompAttacks.Length; x++)
            {
                string sisyphusPrimeStompString = sisyphusPrimeFolder + "sisyphusYouCantEscape" + (x+1).ToString() + ".wav";
                stompAttacks[x] =  AudioSwapper.SwapClipWithFile(stompAttacks[x], sisyphusPrimeStompString);
            }
            
            AudioClip[] taunts = __instance.tauntVoice;
            for(int x = 0; x < taunts.Length; x++)
            {
                string sisyphusPrimeTauntString = sisyphusPrimeFolder + "sisyphusNiceTry" + (x+1).ToString() + ".wav";
                stompAttacks[x] =  AudioSwapper.SwapClipWithFile(stompAttacks[x], sisyphusPrimeTauntString);
            }
            
            AudioClip[] uppercutAttacks = __instance.uppercutComboVoice;
            for(int x = 0; x < uppercutAttacks.Length; x++)
            {
                string sisyphusPrimeUppercutString = sisyphusPrimeFolder + "sisyphusDestroy" + (x+1).ToString() + ".wav";
                stompAttacks[x] =  AudioSwapper.SwapClipWithFile(uppercutAttacks[x], sisyphusPrimeUppercutString);
            }
        }
    }
}