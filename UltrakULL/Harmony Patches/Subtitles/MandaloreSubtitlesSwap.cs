using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UltrakULL.json;
using static System.Reflection.Emit.OpCodes;
using static HarmonyLib.AccessTools;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.Subtitles
{
    /**
     * Mandalore is a tricky one since we can't just use Harmony prefixes here.
     * So we're going to have to replace IL instructions of hardcoded strings with our own.
     */
    [HarmonyPatch(typeof(Mandalore))]
    public static class MandaloreSubtitlesSwap
    {
        private const string MandaloreColor = "FFC49E";
        private const string OwlColor = "9EE6FF";

        private const int ReplacementInstructionsLength = 5;

        private static readonly Dictionary<string, (string, string)> MandaloreBattleDialogs =
            new Dictionary<string, (string, string)>
            {
                { "now we lost", ("subtitles_mandalore_defeated", OwlColor) },
                { "Full auto", ("subtitles_mandalore_attack1", MandaloreColor) },
                { "Fuller auto", ("subtitles_mandalore_attack2", MandaloreColor) },
                { "Use the salt", ("subtitles_mandalore_phaseChangeThird1", OwlColor) },
                { "I'm reaching", ("subtitles_mandalore_phaseChangeThird2", MandaloreColor) },
                { "Feel my maximum speed", ("subtitles_mandalore_phaseChangeSecond1", MandaloreColor) },
                { "Slow down", ("subtitles_mandalore_phaseChangeSecond2", OwlColor) },
                { "I increase my speed", ("subtitles_mandalore_phaseChangeFirst1", OwlColor) },
                { "Just fucking", ("subtitles_mandalore_phaseChangeFirst2", OwlColor) }
            };


        [HarmonyTranspiler]
        [HarmonyPatch(typeof(Mandalore), "Start")]
        private static IEnumerable<CodeInstruction> Mandalore_Start(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            var switchOffset = code.FindIndex(instruction => instruction.opcode == Switch);

            // Second argument is an offset from switch IL instruction, it's a constant
            //NOTE: Don't touch this order. The game won't like it otherwise
            ReplaceLdstr(switchOffset, 0x03, "subtitles_mandalore_taunt3", MandaloreColor, code); //works
            ReplaceLdstr(switchOffset, 0x0C, "subtitles_mandalore_taunt2", OwlColor, code); //works
            ReplaceLdstr(switchOffset, 0x18, "subtitles_mandalore_taunt5", OwlColor, code); //works
            
            //TODO: Commented out these two lines for now as they're causing crashes. Waiting for Flazhik to investigate and fix.
            //ReplaceLdstr(switchOffset, 0x22, "subtitles_mandalore_taunt1", OwlColor, code);
            //ReplaceLdstr(switchOffset, 0x28, "subtitles_mandalore_intro2", MandaloreColor, code);
            
            //Commented line is the offset when the above two lines are uncommented. Waiting for fix.
            //ReplaceLdstr(switchOffset, 0x37, "subtitles_mandalore_taunt4", MandaloreColor, code); //works
            ReplaceLdstr(switchOffset, 0x2D, "subtitles_mandalore_taunt4", MandaloreColor, code); //works

            return code;
        }
        
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(Mandalore), "Update")]
        private static IEnumerable<CodeInstruction> Mandalore_Update(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();

            for (var i = 0; i < code.Count; i++)
            {
                if (code[i].opcode != Ldstr)
                    continue;
                
                var dialogOption = MandaloreBattleDialogs
                    .Where(entry => code[i].operand is string str && str.Contains(entry.Key))
                    .Select(entry => entry.Value)
                    .FirstOrDefault();
                
                if (dialogOption == default)
                    continue;
                
                ReplaceLdstr(i, 0, dialogOption.Item1, dialogOption.Item2, code);
                i += ReplacementInstructionsLength - 1;
            }
            return code;
        }

        private static void ReplaceLdstr(int start, int offset, string subtitles, string color, List<CodeInstruction> instructions)
        {
            instructions.RemoveAt(start + offset);
            instructions.InsertRange(start + offset, ReplaceLdstr(subtitles, color));
        }
        
        /**
         * Basically, equivalent to LanguageManager.CurrentLanguage.subtitles.some_subtitles_string + color tags
         */
        private static IEnumerable<CodeInstruction> ReplaceLdstr(string subtitles, string color)
        {
            return IL(
                (Ldstr, $"<color=\"#{color}\">"),
                (Call, Method(typeof(LanguageManager), "get_CurrentLanguage")),
                (Ldfld, Field(typeof(JsonFormat), "subtitles")),
                (Ldfld, Field(typeof(json.Subtitles), subtitles)),
                (Ldstr, "</color>"),
                (Call, Method(typeof(string), "Concat", new [] { typeof(string), typeof(string), typeof(string) })));
        }
    }
}
