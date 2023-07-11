using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UltrakULL.json;
using static System.Reflection.Emit.OpCodes;
using static HarmonyLib.AccessTools;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.Subtitles.HUD
{
    [HarmonyPatch(typeof(FistControl))]
    public class FistControlHudSwap : AbstractTranspilingPatch
    {
        private const int LdstrInstructionOffset = 5;
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(FistControl), "Update")]
        public static IEnumerable<CodeInstruction> FistControl_Update(IEnumerable<CodeInstruction> instructions)
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
                (Ldstr, "<color=red>"),
                (Call, Method(typeof(LanguageManager), "get_CurrentLanguage")),
                (Ldfld, Field(typeof(JsonFormat), "misc")),
                (Ldfld, Field(typeof(Misc), "hud_noArm1")),
                (Ldstr, "</color>\n"),
                (Call, Method(typeof(LanguageManager), "get_CurrentLanguage")),
                (Ldfld, Field(typeof(JsonFormat), "misc")),
                (Ldfld, Field(typeof(Misc), "hud_noArm2")),
                (Call, Method(typeof(string), "Concat", new[] { typeof(string), typeof(string), typeof(string), typeof(string) })));
        }
    }
}