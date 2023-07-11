using System.Collections.Generic;
using HarmonyLib;
using static System.Reflection.Emit.OpCodes;
using static HarmonyLib.AccessTools;

namespace UltrakULL.Harmony_Patches.Subtitles
{
    public abstract class AbstractTranspilingPatch
    {
        
        protected static bool SendHudMessageCall(CodeInstruction instruction)
        {
            return instruction.opcode == Callvirt
                   && instruction.OperandIs(Method(typeof(HudMessageReceiver), "SendHudMessage",
                       new[] { typeof(string), typeof(string), typeof(string), typeof(int), typeof(bool) }));
        }
        
        protected static void ReplaceLdstr(IEnumerable<CodeInstruction> replaceWith, int start, List<CodeInstruction> instructions)
        {
            instructions.RemoveAt(start);
            instructions.InsertRange(start, replaceWith);
        }
    }
}