using HarmonyLib;
using System.IO;
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
            string gabeSecondFolder =  AudioSwapper.SpeechFolder + "gabrielBossSecond" + Path.DirectorySeparatorChar;


            //Taunts
            AudioClip[] gabeSecondTaunts = ___voice.taunt;
            
            string[] tauntLines =
            {
                "gabrielSecondTaunt_IsThisWhatILostTo",
                "gabrielSecondTaunt_YoureGettingRusty",
                "gabrielSecondTaunt_LetsSettleThis",
                "gabrielSecondTaunt_NothingButScrap",
                "gabrielSecondTaunt_IllShowYouDivine",
                "gabrielSecondTaunt_TimeToRight",
                "gabrielSecondTaunt_YouNeedMorePower"
            };
            
            for(int x = 0; x < gabeSecondTaunts.Length; x++)
            {
                string gabrielSecondTauntString = gabeSecondFolder + tauntLines[x] + ".wav"; 
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
            string[] tauntLinesSecondPhase =
            {
                "gabrielSecondTaunt_IveNeverHadAFight",
                "gabrielSecondTaunt_ShowMeWhat",
                "gabrielSecondTaunt_NowThisIsAFight",
                "gabrielSecondTaunt_WhatIsThisFeeling",
                "gabrielSecondTaunt_ComeGetSomeBlood",
                "gabrielSecondTaunt_ComeOnMachine",
                "gabrielSecondTaunt_IllShowYouTrueSplendor"
            };
            
            AudioClip[] gabeSecondTauntsSecondPhase = ___voice.tauntSecondPhase;
            for(int x = 0; x < gabeSecondTauntsSecondPhase.Length; x++)
            {
                string gabeSecondTauntsSecondPhaseString = gabeSecondFolder + tauntLinesSecondPhase[x] + ".wav"; 
                gabeSecondTauntsSecondPhase[x] =  AudioSwapper.SwapClipWithFile(gabeSecondTauntsSecondPhase[x], gabeSecondTauntsSecondPhaseString);
            }
        }
    }
}
