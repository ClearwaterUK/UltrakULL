using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UltrakULL.json;
using static System.Reflection.Emit.OpCodes;
using static HarmonyLib.AccessTools;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.Subtitles.HUD
{
    public class StatsManagerHudSwap : AbstractTranspilingPatch
    {
        private const int LdstrInstructionOffset = 5;
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(StatsManager), "StartTimer")]
        public static IEnumerable<CodeInstruction> StatsManager_StartTimer(IEnumerable<CodeInstruction> instructions)
            => Replace(instructions);

        [HarmonyTranspiler]
        [HarmonyPatch(typeof(StatsManager), "MajorUsed")]
        public static IEnumerable<CodeInstruction> StatsManager_MajorUsed(IEnumerable<CodeInstruction> instructions)
            => Replace(instructions);

        private static IEnumerable<CodeInstruction> Replace(IEnumerable<CodeInstruction> instructions)
        {
            var code  = instructions.ToList();
            for (var i = 0; i < code.Count; i++)
            {
                if (!SendHudMessageCall(code[i]))
                    continue;
                
                ReplaceLdstr(ReplaceLdstrInstructions(), i - LdstrInstructionOffset, code);
                break;
            }
            return code;
        }
        
        private static IEnumerable<CodeInstruction> ReplaceLdstrInstructions()
        {
            return IL(
                (Ldstr, "<color=#4C99E6>"),
                (Call, Method(typeof(LanguageManager), "get_CurrentLanguage")),
                (Ldfld, Field(typeof(JsonFormat), "misc")),
                (Ldfld, Field(typeof(Misc), "hud_majorAssists")),
                (Ldstr, " '</color>"),
                (Call, Method(typeof(string), "Concat", new[] { typeof(string), typeof(string), typeof(string) })));
        }
    }
}