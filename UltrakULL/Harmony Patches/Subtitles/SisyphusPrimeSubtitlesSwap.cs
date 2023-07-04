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
    [HarmonyPatch(typeof(SisyphusPrime))]
    public class SisyphusPrimeSubtitlesSwap
    {
        private const int LdstrInstructionOffset = 2;
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(SisyphusPrime), "Update")]
        private static IEnumerable<CodeInstruction> SisyphusPrime_Update(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            TraverseCodeAndReplaceSubtitles("subtitles_sisyphusPrime_phaseChange", code);
            return code;
        }
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(SisyphusPrime), "Taunt")]
        private static IEnumerable<CodeInstruction> SisyphusPrime_Taunt(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            TraverseCodeAndReplaceSubtitles("subtitles_sisyphusPrime_attack1", code);
            return code;
        }
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(SisyphusPrime), "Clap")]
        private static IEnumerable<CodeInstruction> SisyphusPrime_Clap(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            TraverseCodeAndReplaceSubtitles("subtitles_sisyphusPrime_attack2", code);
            return code;
        }
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(SisyphusPrime), "StompCombo")]
        private static IEnumerable<CodeInstruction> SisyphusPrime_StompCombo(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            TraverseCodeAndReplaceSubtitles("subtitles_sisyphusPrime_attack3", code);
            return code;
        }
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(SisyphusPrime), "UppercutCombo")]
        private static IEnumerable<CodeInstruction> SisyphusPrime_UppercutCombo(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            TraverseCodeAndReplaceSubtitles("subtitles_sisyphusPrime_attack4", code);
            return code;
        }
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(SisyphusPrime), "ExplodeAttack")]
        private static IEnumerable<CodeInstruction> SisyphusPrime_ExplodeAttack(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            TraverseCodeAndReplaceSubtitles("subtitles_sisyphusPrime_attack5", code);
            return code;
        }

        private static void TraverseCodeAndReplaceSubtitles(string subtitles, List<CodeInstruction> instructions)
        {
            for (var i = 0; i < instructions.Count; i++)
            {
                if (!DisplaySubtitleCall(instructions[i]))
                    continue;

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