using HarmonyLib;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(Gabriel),"Start")]
    public static class GabrielAudioSwap
    {
        
        [HarmonyPostfix]
        public static void Gabriel_VoiceSwap(ref Gabriel __instance, ref GabrielVoice ___voice)
        {
            if(LanguageManager.configFile.Bind("General","activeDubbing","False").Value == "False")
            {
                return;
            }
        
            string gabeFirstFolder =  AudioSwapper.speechFolder + "gabrielBossFirst\\";


            //Taunts
            AudioClip[] gabeTaunts = ___voice.taunt;
            for(int x = 0; x < gabeTaunts.Length; x++)
            {
                string gabrielTauntString = gabeFirstFolder + "gabrielTaunt" + (x+1).ToString() + ".wav";
                gabeTaunts[x] =  AudioSwapper.swapClipWithFile(gabeTaunts[x], gabrielTauntString);
                
            }
            
            //Phase change - need to use ref otherwise it gets swapped back to original
            ref AudioClip gabePhaseChange = ref ___voice.phaseChange;
            string gabrielPhaseChangeString = gabeFirstFolder + "gabrielPhaseChange.wav";
            gabePhaseChange = AudioSwapper.swapClipWithFile(gabePhaseChange, gabrielPhaseChangeString);

            //Big hurt
            AudioClip[] gabeBigHurt = ___voice.bigHurt;
            for(int x = 0; x < gabeBigHurt.Length; x++)
            {
                string gabrielBigHurtString = gabeFirstFolder + "gabrielBigHurt" + (x+1).ToString() + ".wav";
                gabeBigHurt[x] =  AudioSwapper.swapClipWithFile(gabeBigHurt[x], gabrielBigHurtString);
                
            }

            //Hurt
            AudioClip[] gabeHurt = ___voice.hurt;
            for(int x = 0; x < gabeHurt.Length; x++)
            {
                string gabrielHurtString = gabeFirstFolder + "gabrielHurt" + (x+1).ToString() + ".wav";
                gabeHurt[x] =  AudioSwapper.swapClipWithFile(gabeHurt[x], gabrielHurtString);
                
            }
            
            
            
        }
    }
}