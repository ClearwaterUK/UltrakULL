using System.Collections.Generic;
using HarmonyLib;
using static UltrakULL.CommonFunctions;
using static UltrakULL.json.LanguageManager;

namespace UltrakULL.Harmony_Patches.Subtitles
{
    [HarmonyPatch(typeof(GabrielVoice),"Start")]
    public static class GabrielSubtitlesSwap
    {
        private static readonly List<string> FirstEncounterTauntsOrder = new List<string>
        {
            CurrentLanguage.subtitles.subtitles_gabriel_taunt2,
            CurrentLanguage.subtitles.subtitles_gabriel_taunt3,
            CurrentLanguage.subtitles.subtitles_gabriel_taunt8,
            CurrentLanguage.subtitles.subtitles_gabriel_taunt6,
            CurrentLanguage.subtitles.subtitles_gabriel_taunt9,
            CurrentLanguage.subtitles.subtitles_gabriel_taunt4,
            CurrentLanguage.subtitles.subtitles_gabriel_taunt5,
            CurrentLanguage.subtitles.subtitles_gabriel_taunt7,
            CurrentLanguage.subtitles.subtitles_gabriel_taunt1,
            CurrentLanguage.subtitles.subtitles_gabriel_taunt12,
            CurrentLanguage.subtitles.subtitles_gabriel_taunt10,
            CurrentLanguage.subtitles.subtitles_gabriel_taunt11
        };
        
        private static readonly List<string> SecondEncounterTauntsOrder = new List<string>
        {
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt6,
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt5,
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt8,
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt4,
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt9,
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt7,
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt1
        };
        
        private static readonly List<string> SecondEncounterPhaseTwoTauntsOrder = new List<string>
        {
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt11,
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt12,
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt13,
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt3,
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt2,
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt10,
            CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt14
        };
        
        [HarmonyPostfix]
        public static void GabrielVoice_Start(ref GabrielVoice __instance, ref string[] ___taunts, ref string[] ___tauntsSecondPhase)
        {
            switch (GetCurrentSceneName())
            {
                case "Level 3-2":
                {
                    __instance.phaseChangeSubtitle = CurrentLanguage.subtitles.subtitles_gabriel_phaseChange;
                    
                    for (var i = 0; i < FirstEncounterTauntsOrder.Count; i++)
                        ___taunts[i] = FirstEncounterTauntsOrder[i];
                    
                    break;
                }
                case "Level 6-2":
                {
                    __instance.phaseChangeSubtitle = CurrentLanguage.subtitles.subtitles_gabrielSecondPhaseChange;
                    
                    for (var i = 0; i < SecondEncounterTauntsOrder.Count; i++)
                        ___taunts[i] = SecondEncounterTauntsOrder[i];
                    
                    for (var i = 0; i < SecondEncounterPhaseTwoTauntsOrder.Count; i++)
                        ___tauntsSecondPhase[i] = SecondEncounterPhaseTwoTauntsOrder[i];

                    break;
                }
            }
        }
    }
}
