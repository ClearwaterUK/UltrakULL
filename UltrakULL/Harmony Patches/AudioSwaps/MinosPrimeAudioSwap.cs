using HarmonyLib;
using System.IO;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches.AudioSwaps
{
    [HarmonyPatch(typeof(MinosPrime),"Start")]
    public class MinosPrimeAudioSwap
    {
        [HarmonyPostfix]
        public static void MinosPrime_VoiceSwap(ref MinosPrime __instance)
        {
            if(LanguageManager.configFile.Bind("General","activeDubbing","False").Value == "False")
            {
                return;
            }
            string minosPrimeFolder =  AudioSwapper.SpeechFolder + "minosPrime" + Path.DirectorySeparatorChar;


            //Kicks (Prepare thyself)
            AudioClip[] minosPrimeKick = __instance.riderKickVoice;
            for(int x = 0; x < minosPrimeKick.Length; x++)
            {
                string minosPrimeKickString = minosPrimeFolder + "minosPrimeKick" + (x+1).ToString() + ".wav";
                minosPrimeKick[x] =  AudioSwapper.SwapClipWithFile(minosPrimeKick[x], minosPrimeKickString);
            }
            
            //Dropkick (Judgement)
            AudioClip[] minosPrimeJudgement = __instance.dropkickVoice;
            for(int x = 0; x < minosPrimeJudgement.Length; x++)
            {
                string minosPrimeJudgementString = minosPrimeFolder + "minosPrimeJudgement" + (x+1).ToString() + ".wav";
                minosPrimeJudgement[x] =  AudioSwapper.SwapClipWithFile(minosPrimeJudgement[x], minosPrimeJudgementString);
                
            }
            
            //Crush attack (Crush)
            AudioClip[] minosPrimeCrush = __instance.dropAttackVoice;
            for(int x = 0; x < minosPrimeCrush.Length; x++)
            {
                string minosPrimeCrushString = minosPrimeFolder + "minosPrimeCrush" + (x+1).ToString() + ".wav";
                minosPrimeCrush[x] =  AudioSwapper.SwapClipWithFile(minosPrimeCrush[x], minosPrimeCrushString);
            }
            
            //Punches (Thy end is now)
            AudioClip[] minosPrimePunch = __instance.boxingVoice;
            for(int x = 0; x < minosPrimePunch.Length; x++)
            {
                string minosPrimePunchString = minosPrimeFolder + "minosPrimePunch" + (x+1).ToString() + ".wav";
                minosPrimePunch[x] =  AudioSwapper.SwapClipWithFile(minosPrimePunch[x], minosPrimePunchString);
            }
            
            //Combo (prepare thyself)
            AudioClip[] minosPrimeCombo = __instance.comboVoice;
            for(int x = 0; x < minosPrimeCombo.Length; x++)
            {
                string minosPrimeComboString = minosPrimeFolder + "minosPrimeCombo" + (x+1).ToString() + ".wav";
                minosPrimeCombo[x] =  AudioSwapper.SwapClipWithFile(minosPrimeCombo[x], minosPrimeComboString);
            }
            
            //Overhead (Die)
            AudioClip[] minosPrimeOverhead = __instance.overheadVoice;
            for(int x = 0; x < minosPrimeOverhead.Length; x++)
            {
                string minosPrimeOverheadString = minosPrimeFolder + "minosPrimeOverhead" + (x+1).ToString() + ".wav";
                minosPrimeOverhead[x] =  AudioSwapper.SwapClipWithFile(minosPrimeOverhead[x], minosPrimeOverheadString);
            }



            //Phase change - need to use ref otherwise it gets swapped back to original
            ref AudioClip minosPrimePhaseChange = ref __instance.phaseChangeVoice;
            string minosPrimePhaseChangeString = minosPrimeFolder + "minosPrimePhaseChange.wav";
            minosPrimePhaseChange = AudioSwapper.SwapClipWithFile(minosPrimePhaseChange, minosPrimePhaseChangeString);
            
            
            //Hurt
            AudioClip[] minosPrimeHurt = __instance.hurtVoice;
            for(int x = 0; x < minosPrimeHurt.Length; x++)
            {
                string minosPrimeHurtString = minosPrimeFolder + "minosPrimeHurt" + (x+1).ToString() + ".wav";
                minosPrimeHurt[x] =  AudioSwapper.SwapClipWithFile(minosPrimeHurt[x], minosPrimeHurtString);
            }

        }
        
    }
}
