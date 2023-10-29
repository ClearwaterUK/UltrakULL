using HarmonyLib;
using System.IO;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches.AudioSwaps
{
    [HarmonyPatch(typeof(Gabriel),"Start")]
    public static class GabrielAudioSwap
    {
        [HarmonyPostfix]
        public static void Gabriel_VoiceSwap(ref Gabriel __instance, ref GabrielVoice ___voice)
        {
            if(LanguageManager.configFile.Bind("General","activeDubbing","False").Value == "False")
                return;

            string gabeFirstFolder =  AudioSwapper.SpeechFolder + "gabrielBossFirst" + Path.DirectorySeparatorChar;
            
            //Taunts
            
            //Going to redo this.
            //Going to change it from taunt1, taunt2, taunt3 etc so each file name is more easily recognisable.
            // "GabeYouMakeEven", "GaveYouAreOutclassed" etc.
            AudioClip[] gabeTaunts = ___voice.taunt;
            
            //Line order is based on line order of the, so it's not alphabetical.
            string[] tauntLines = 
            {
                "gabrielTaunt_YouDefyTheLight",
                "gabrielTaunt_AMereObject",
                "gabrielTaunt_ThereCanBeOnlyLight",
                "gabrielTaunt_Foolishness",
                "gabrielTaunt_AnImperfection",
                "gabrielTaunt_NotEvenMortal",
                "gabrielTaunt_YouAreLessThanNothing",
                "gabrielTaunt_YoureAnError",
                "gabrielTaunt_TheLightIsPerfection",
                "gabrielTaunt_YouAreOutclassed",
                "gabrielTaunt_YourCrimeIsExistence",
                "gabrielTaunt_YouMakeEven"
            };
            for(int x = 0; x < gabeTaunts.Length; x++)
            {
                string gabrielTauntString = gabeFirstFolder + tauntLines[x];
                gabeTaunts[x] =  AudioSwapper.SwapClipWithFile(gabeTaunts[x], gabrielTauntString);
            }
            
            //Phase change - need to use ref otherwise it gets swapped back to original
            ref AudioClip gabePhaseChange = ref ___voice.phaseChange;
            string gabrielPhaseChangeString = gabeFirstFolder + "gabrielPhaseChange";
            gabePhaseChange = AudioSwapper.SwapClipWithFile(gabePhaseChange, gabrielPhaseChangeString);

            //Big hurt
            AudioClip[] gabeBigHurt = ___voice.bigHurt;
            for(int x = 0; x < gabeBigHurt.Length; x++)
            {
                string gabrielBigHurtString = gabeFirstFolder + "gabrielBigHurt" + (x+1).ToString();
                gabeBigHurt[x] =  AudioSwapper.SwapClipWithFile(gabeBigHurt[x], gabrielBigHurtString);
                
            }

            //Hurt
            AudioClip[] gabeHurt = ___voice.hurt;
            for(int x = 0; x < gabeHurt.Length; x++)
            {
                string gabrielHurtString = gabeFirstFolder + "gabrielHurt" + (x+1).ToString();
                gabeHurt[x] =  AudioSwapper.SwapClipWithFile(gabeHurt[x], gabrielHurtString);
            }
        }
    }
}
