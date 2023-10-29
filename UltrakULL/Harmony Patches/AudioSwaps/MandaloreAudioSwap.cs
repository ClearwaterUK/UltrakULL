using System;
using System.IO;
using HarmonyLib;
using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches.AudioSwaps
{
    [HarmonyPatch(typeof(Mandalore),"Start")]
    public static class MandaloreAudioSwap
    {
        [HarmonyPostfix]
        public static void Mandalore_AudioSwap(Mandalore __instance)
        {
            try
            {
                if(LanguageManager.configFile.Bind("General","activeDubbing","False").Value == "False")
                {
                    return;
                }

                //Mandalore uses an array for MandaloreVoice.
                //voices[0] - Mandalore, voices[1] = Owl.
                
                //NOTE - both audio files for Manda & Owl play at the SAME TIME.
                //This means each seperate audio file will need to have the relevant period of silence before/after speaking.
                string mandaloreFolder = AudioSwapper.SpeechFolder + "mandalore" + Path.DirectorySeparatorChar;
            
                //Attack 1 (Full auto)
                ref AudioClip mandaloreAttack1 = ref __instance.voiceFull;
                string mandaloreAttack1String = mandaloreFolder + "mandaloreFullAuto";
                mandaloreAttack1 = AudioSwapper.SwapClipWithFile(mandaloreAttack1, mandaloreAttack1String);

                //Attack 2 (Fuller auto)
                ref AudioClip mandaloreAttack2 = ref __instance.voiceFuller;
                string mandaloreAttack2String = mandaloreFolder + "mandaloreFullerAuto";
                mandaloreAttack2 = AudioSwapper.SwapClipWithFile(mandaloreAttack2, mandaloreAttack2String);

                //Phase change 1 (speed increase)
                ref AudioClip mandalorePhaseChange1Manda = ref __instance.voices[0].secondPhase;
                ref AudioClip mandalorePhaseChange1Owl = ref __instance.voices[1].secondPhase;
                
                string mandalorePhaseChange1MandaString = mandaloreFolder + "mandalorePhaseChange1Manda";
                string mandalorePhaseChange1OwlString = mandaloreFolder + "mandalorePhaseChange1Owl";
                
                mandalorePhaseChange1Manda = AudioSwapper.SwapClipWithFile(mandalorePhaseChange1Manda, mandalorePhaseChange1MandaString);
                mandalorePhaseChange1Owl = AudioSwapper.SwapClipWithFile(mandalorePhaseChange1Owl, mandalorePhaseChange1OwlString);

                //Phase change 2 (max speed)
                ref AudioClip mandalorePhaseChange2Manda = ref __instance.voices[0].thirdPhase;
                ref AudioClip mandalorePhaseChange2Owl = ref __instance.voices[1].thirdPhase;
                
                string mandalorePhaseChange2MandaString = mandaloreFolder + "mandalorePhaseChange2Manda";
                string mandalorePhaseChange2OwlString = mandaloreFolder + "mandalorePhaseChange2Owl";
                
                mandalorePhaseChange2Manda = AudioSwapper.SwapClipWithFile(mandalorePhaseChange2Manda, mandalorePhaseChange2MandaString);
                mandalorePhaseChange2Owl = AudioSwapper.SwapClipWithFile(mandalorePhaseChange2Owl, mandalorePhaseChange2OwlString);
                
                //Phase change 3 (sanded)
                ref AudioClip mandalorePhaseChange3Manda = ref __instance.voices[0].finalPhase;
                ref AudioClip mandalorePhaseChange3Owl = ref __instance.voices[1].finalPhase;
                
                string mandalorePhaseChange3MandaString = mandaloreFolder + "mandalorePhaseChangeFinalManda";
                string mandalorePhaseChange3OwlString = mandaloreFolder + "mandalorePhaseChangeFinalOwl";
                
                mandalorePhaseChange3Manda = AudioSwapper.SwapClipWithFile(mandalorePhaseChange3Manda, mandalorePhaseChange3MandaString);
                mandalorePhaseChange3Owl = AudioSwapper.SwapClipWithFile(mandalorePhaseChange3Owl, mandalorePhaseChange3OwlString);
                
                //Defeated
                ref AudioClip mandaloreDefeatedManda = ref __instance.voices[0].death;
                ref AudioClip mandaloreDefeatedOwl = ref __instance.voices[1].death;
                
                string mandaloreDefeatedMandaString = mandaloreFolder + "mandaloreDefeatedManda";
                string mandaloreDefeatedOwlString = mandaloreFolder + "mandaloreDefeatedOwl";
                
                mandaloreDefeatedManda = AudioSwapper.SwapClipWithFile(mandaloreDefeatedManda, mandaloreDefeatedMandaString);
                mandaloreDefeatedOwl = AudioSwapper.SwapClipWithFile(mandaloreDefeatedOwl, mandaloreDefeatedOwlString);
                
                //Respawn taunts
                ref AudioClip[] mandaloreTauntManda = ref __instance.voices[0].taunts;
                ref AudioClip[] mandaloreTauntOwl = ref __instance.voices[1].taunts;
                
                string[] mandaTauntLines = 
                {
                    "mandaloreTaunt_YouCannotImagine",
                    "mandaloreTaunt_What",
                    "mandaloreTaunt_HoldStill"
                };
                
                string[] owlTauntLines = 
                {
                    "mandaloreTaunt_ImGonnaShootThem",
                    "mandaloreTaunt_WhyAreWeInThePast",
                    "mandaloreTaunt_ImGonnaPoisonYou",
                };
                
                for (int x = 0; x < mandaloreTauntManda.Length-1; x++)
                {
                    switch(x)
                    {
                        case 1:
                        {
                            mandaloreTauntOwl[x] =  AudioSwapper.SwapClipWithFile(mandaloreTauntOwl[x], mandaloreFolder + owlTauntLines[x] );
                            break;
                        }
                        case 3:
                        {
                            mandaloreTauntManda[x] =  AudioSwapper.SwapClipWithFile(mandaloreTauntManda[x], mandaloreFolder + mandaTauntLines[x]);
                            break;
                        }
                        default:
                        {
                            mandaloreTauntManda[x] =  AudioSwapper.SwapClipWithFile(mandaloreTauntManda[x], mandaloreFolder + mandaTauntLines[x]);
                            mandaloreTauntOwl[x] =  AudioSwapper.SwapClipWithFile(mandaloreTauntOwl[x], mandaloreFolder + owlTauntLines[x]);
                            break;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
