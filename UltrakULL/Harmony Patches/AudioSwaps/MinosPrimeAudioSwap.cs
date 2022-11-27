using HarmonyLib;
using UltrakULL.audio;
using UnityEngine;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(MinosPrime),"Start")]
    public class MinosPrimeAudioSwap
    {
        [HarmonyPostfix]
        public static void MinosPrime_VoiceSwap(ref MinosPrime __instance)
        {
            string minosPrimeFolder =  AudioSwapper.speechFolder + "minosPrime\\";
            
            //Defeated lines aren't patched
            
            //Overhead (Prepare thyself)
            AudioClip[] minosPrimeKick = __instance.riderKickVoice;
            for(int x = 0; x < minosPrimeKick.Length; x++)
            {
                string minosPrimeKickString = minosPrimeFolder + "minosPrimeKick" + (x+1).ToString() + ".wav";
                minosPrimeKick[x] =  AudioSwapper.swapClipWithFile(minosPrimeKick[x], minosPrimeKickString);
            }
            
            //Dropkick (Judgement)
            AudioClip[] minosPrimeJudgement = __instance.dropkickVoice;
            for(int x = 0; x < minosPrimeJudgement.Length; x++)
            {
                string minosPrimeJudgementString = minosPrimeFolder + "minosPrimeJudgement" + (x+1).ToString() + ".wav";
                minosPrimeJudgement[x] =  AudioSwapper.swapClipWithFile(minosPrimeJudgement[x], minosPrimeJudgementString);
                
                
            }
            
            //Crush attack (Crush)
            AudioClip[] minosPrimeCrush = __instance.dropAttackVoice;
            for(int x = 0; x < minosPrimeCrush.Length; x++)
            {
                string minosPrimeCrushString = minosPrimeFolder + "minosPrimeCrush" + (x+1).ToString() + ".wav";
                minosPrimeCrush[x] =  AudioSwapper.swapClipWithFile(minosPrimeCrush[x], minosPrimeCrushString);
            }
            
            //Punches (Thy end is now)
            AudioClip[] minosPrimePunch = __instance.boxingVoice;
            for(int x = 0; x < minosPrimePunch.Length; x++)
            {
                string minosPrimePunchString = minosPrimeFolder + "minosPrimePunch" + (x+1).ToString() + ".wav";
                minosPrimePunch[x] =  AudioSwapper.swapClipWithFile(minosPrimePunch[x], minosPrimePunchString);
            }
            
            //Combo (prepare thyself)
            AudioClip[] minosPrimeCombo = __instance.comboVoice;
            for(int x = 0; x < minosPrimeCombo.Length; x++)
            {
                string minosPrimeComboString = minosPrimeFolder + "minosPrimeCombo" + (x+1).ToString() + ".wav";
                minosPrimeCombo[x] =  AudioSwapper.swapClipWithFile(minosPrimeCombo[x], minosPrimeComboString);
            }
            
            //Overhead (Die)
            AudioClip[] minosPrimeOverhead = __instance.overheadVoice;
            for(int x = 0; x < minosPrimeOverhead.Length; x++)
            {
                string minosPrimeOverheadString = minosPrimeFolder + "minosPrimeOverhead" + (x+1).ToString() + ".wav";
                minosPrimeOverhead[x] =  AudioSwapper.swapClipWithFile(minosPrimeOverhead[x], minosPrimeOverheadString);
            }



            //Phase change - need to use ref otherwise it gets swapped back to original
            ref AudioClip minosPrimePhaseChange = ref __instance.phaseChangeVoice;
            string minosPrimePhaseChangeString = minosPrimeFolder + "minosPrimePhaseChange.wav";
            minosPrimePhaseChange = AudioSwapper.swapClipWithFile(minosPrimePhaseChange, minosPrimePhaseChangeString);
            
            
            //Hurt
            AudioClip[] minosPrimeHurt = __instance.hurtVoice;
            for(int x = 0; x < minosPrimeHurt.Length; x++)
            {
                string minosPrimeHurtString = minosPrimeFolder + "minosPrimeHurt" + (x+1).ToString() + ".wav";
                minosPrimeHurt[x] =  AudioSwapper.swapClipWithFile(minosPrimeHurt[x], minosPrimeHurtString);
            }

        }
        
    }
}