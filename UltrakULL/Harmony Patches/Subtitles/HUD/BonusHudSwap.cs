using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UltrakULL.json;
using static System.Reflection.Emit.OpCodes;
using static HarmonyLib.AccessTools;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches.Subtitles.HUD
{
    public class BonusHudSwap : AbstractTranspilingPatch
    {
        private const int LdstrInstructionOffset = 5;
        
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(Bonus), "OnTriggerEnter")]
        public static IEnumerable<CodeInstruction> Bonus_OnTriggerEnter(IEnumerable<CodeInstruction> instructions)
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
                (Call, Method(typeof(LanguageManager), "get_CurrentLanguage")),
                (Ldfld, Field(typeof(JsonFormat), "misc")),
                (Ldfld, Field(typeof(Misc), "hud_overhealOrb1")),
                (Ldstr, "\n"),
                (Call, Method(typeof(LanguageManager), "get_CurrentLanguage")),
                (Ldfld, Field(typeof(JsonFormat), "misc")),
                (Ldfld, Field(typeof(Misc), "hud_overhealOrb2")),
                (Call, Method(typeof(string), "Concat", new[] { typeof(string), typeof(string), typeof(string) })));
        }
    }
}