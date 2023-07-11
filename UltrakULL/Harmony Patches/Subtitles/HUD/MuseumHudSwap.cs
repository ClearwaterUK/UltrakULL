using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UltrakULL.json;
using static System.Reflection.Emit.OpCodes;
using static HarmonyLib.AccessTools;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.Subtitles.HUD
{
    /**
     * Gotta dissect Racing timer without anaesthesia 
     */
    public class MuseumHudSwap : AbstractTranspilingPatch
    {
        [HarmonyPatch(typeof(RaceRingTracker))]
        public static class RaceRingTrackerPatch
        {
            [HarmonyTranspiler]
            [HarmonyPatch(typeof(RaceRingTracker), "Start")]
            public static IEnumerable<CodeInstruction> RaceRingTracker_Start(IEnumerable<CodeInstruction> instructions)
            {
                var code  = instructions.ToList();
                for (var i = 0; i < code.Count; i++)
                {
                    if (code[i].opcode != Ldstr)
                        continue;
                
                    // This one have only one ldstr instruction, thankfully
                    ReplaceLdstr(ReplaceLdstrInstructions("museum_rocketRaceStart"), i, code);
                    break;
                }
                return code;
            }
            
            [HarmonyTranspiler]
            [HarmonyPatch(typeof(RaceRingTracker), "Victory")]
            public static IEnumerable<CodeInstruction> RaceRingTracker_Victory(IEnumerable<CodeInstruction> instructions)
            {
                var code  = instructions.ToList();
                for (var i = 0; i < code.Count; i++)
                {
                    if (code[i].opcode != Ldstr)
                        continue;
                
                    /*
                     * Eh, good enough
                     * Bad thing is, this time we must also paint the time in lime color
                     */
                    if (!(code[i].operand is string str) || !str.StartsWith("TIME"))
                        continue;
                    
                    var sourceInstructions = ReplaceLdstrInstructions("museum_rocketRaceResult");
                    var limeColoringInstructions = IL(
                        (Ldstr, " <color=lime>"),
                        (Call, Method(typeof(string), "Concat", new[] { typeof(string), typeof(string) }))
                    );
                        
                    ReplaceLdstr(sourceInstructions.Concat(limeColoringInstructions).ToList(), i, code);
                    break;
                }
                return code;
            }
        }

        private static IEnumerable<CodeInstruction> ReplaceLdstrInstructions(string subtitles)
        {
            return IL(
                (Call, Method(typeof(LanguageManager), "get_CurrentLanguage")),
                (Ldfld, Field(typeof(JsonFormat), "devMuseum")),
                (Ldfld, Field(typeof(Museum), subtitles)));
        }
    }
}