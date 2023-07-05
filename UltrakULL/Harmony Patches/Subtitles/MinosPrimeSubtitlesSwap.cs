using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine;
using static System.Reflection.Emit.OpCodes;
using static HarmonyLib.AccessTools;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.Subtitles
{
    /**
     * Minos and Sisyphus still have to be patched with transpiler, but they're
     * significantly less tricky than Mandalore since there's only one DisplaySubtitle
     * call per method and a constant Ldstr offset from it.
     */
    [HarmonyPatch(typeof(MinosPrime))]
    public class MinosPrimeSubtitlesSwap
    {
        private const int LdstrInstructionOffset = 2;
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(MinosPrime), "Update")]
        private static IEnumerable<CodeInstruction> MinosPrime_Update(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            TraverseCodeAndReplaceSubtitles("subtitles_minosPrime_phaseChange", code);
            return code;
        }
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(MinosPrime), "Combo")]
        private static IEnumerable<CodeInstruction> MinosPrime_Combo(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            TraverseCodeAndReplaceSubtitles("subtitles_minosPrime_attack1", code);
            return code;
        }
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(MinosPrime), "Boxing")]
        private static IEnumerable<CodeInstruction> MinosPrime_Boxing(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            TraverseCodeAndReplaceSubtitles("subtitles_minosPrime_attack2", code);
            return code;
        }
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(MinosPrime), "RiderKick")]
        private static IEnumerable<CodeInstruction> MinosPrime_RiderKick(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            TraverseCodeAndReplaceSubtitles("subtitles_minosPrime_attack3", code);
            return code;
        }
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(MinosPrime), "DropAttack")]
        private static IEnumerable<CodeInstruction> MinosPrime_DropAttack(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            TraverseCodeAndReplaceSubtitles("subtitles_minosPrime_attack4", code);
            return code;
        }
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(MinosPrime), "Dropkick")]
        private static IEnumerable<CodeInstruction> MinosPrime_Dropkick(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            TraverseCodeAndReplaceSubtitles("subtitles_minosPrime_attack5", code);
            return code;
        }

        private static void TraverseCodeAndReplaceSubtitles(string subtitles, List<CodeInstruction> instructions)
        {
            for (var i = 0; i < instructions.Count; i++)
            {
                if (!DisplaySubtitleCall(instructions[i]))
                    continue;
                
                // Ldstr opcode is always 2 instructions above
                ReplaceLdstr(i - LdstrInstructionOffset, subtitles, instructions);
                break;
            }
        }

        private static bool DisplaySubtitleCall(CodeInstruction instruction)
        {
            return instruction.opcode == Callvirt
                   && instruction.OperandIs(Method(typeof(SubtitleController), "DisplaySubtitle",
                       new[] { typeof(string), typeof(AudioSource) }));
        }
        
        private static void ReplaceLdstr(int offset, string subtitles, List<CodeInstruction> instructions)
        {
            instructions.RemoveAt(offset);
            instructions.InsertRange(offset, ReplaceLdstr(subtitles));
        }
        
        private static IEnumerable<CodeInstruction> ReplaceLdstr(string subtitles)
        {
            return IL(
                (Call, Method(typeof(LanguageManager), "get_CurrentLanguage")),
                (Ldfld, Field(typeof(JsonFormat), "subtitles")),
                (Ldfld, Field(typeof(json.Subtitles), subtitles)));
        }
    }
}