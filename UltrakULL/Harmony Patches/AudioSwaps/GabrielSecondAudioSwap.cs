using HarmonyLib;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches.AudioSwaps
{
    [HarmonyPatch(typeof(GabrielSecond),"Start")]
    public static class GabrielSecondAudioSwap
    {
        
        [HarmonyPostfix]
        public static void GabrielSecond_VoiceSwap(ref GabrielSecond __instance, ref GabrielVoice ___voice)
        {
            if(LanguageManager.configFile.Bind("General","activeDubbing","False").Value == "False")
            {
                return;
            }
            string gabeSecondFolder =  AudioSwapper.speechFolder + "gabrielBossSecond\\";


            //Taunts
            AudioClip[] gabeSecondTaunts = ___voice.taunt;
            for(int x = 0; x < gabeSecondTaunts.Length; x++)
            {
                string gabrielSecondTauntString = gabeSecondFolder + "gabrielSecondTaunt" + (x+1).ToString() + ".wav";
                gabeSecondTaunts[x] =  AudioSwapper.SwapClipWithFile(gabeSecondTaunts[x], gabrielSecondTauntString);
                
            }
            
            //Phase change - need to use ref otherwise it gets swapped back to original
            ref AudioClip gabeSecondPhaseChange = ref ___voice.phaseChange;
            string gabrielSecondPhaseChangeString = gabeSecondFolder + "gabrielSecondPhaseChange.wav";
            gabeSecondPhaseChange = AudioSwapper.SwapClipWithFile(gabeSecondPhaseChange, gabrielSecondPhaseChangeString);

            //Big hurt
            AudioClip[] gabeSecondBigHurt = ___voice.bigHurt;
            for(int x = 0; x < gabeSecondBigHurt.Length; x++)
            {
                string gabrielSecondBigHurtString = gabeSecondFolder + "gabrielSecondBigHurt" + (x+1).ToString() + ".wav";
                gabeSecondBigHurt[x] =  AudioSwapper.SwapClipWithFile(gabeSecondBigHurt[x], gabrielSecondBigHurtString);
                
            }

            //Hurt
            AudioClip[] gabeSecondHurt = ___voice.hurt;
            for(int x = 0; x < gabeSecondHurt.Length; x++)
            {
                string gabrielSecondHurtString = gabeSecondFolder + "gabrielSecondHurt" + (x+1).ToString() + ".wav";
                gabeSecondHurt[x] =  AudioSwapper.SwapClipWithFile(gabeSecondHurt[x], gabrielSecondHurtString);
                
            }
            
            //Taunts second phase
            AudioClip[] gabeSecondTauntsSecondPhase = ___voice.tauntSecondPhase;
            for(int x = 0; x < gabeSecondTauntsSecondPhase.Length; x++)
            {
                string gabeSecondTauntsSecondPhaseString = gabeSecondFolder + "gabrielSecondTauntSecondPhase" + (x+1).ToString() + ".wav";
                gabeSecondTauntsSecondPhase[x] =  AudioSwapper.SwapClipWithFile(gabeSecondTauntsSecondPhase[x], gabeSecondTauntsSecondPhaseString);
                
            }
            
            
            
        }
    }
}