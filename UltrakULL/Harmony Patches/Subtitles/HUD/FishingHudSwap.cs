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
     * As it was mentioned before, 5-S sends its messages directly via SendHudMessage,
     * so we'll have to manage it here.
     *
     * Luckily, it's all about a dumb replacement of ldstr instruction once again.
     */
    public class FishingHudSwap
    {
        private const int ReplacementInstructionsLength = 3;
        
        private static readonly Dictionary<string, string> BaitMessages = new Dictionary<string, string>
        {
            { "This bait", "fish_baitNotWork" },
            { "A fish took", "fish_baitTaken" }
        };
        
        private static readonly Dictionary<string, string> FishingRodMessages = new Dictionary<string, string>
        {
            { "interrupted", "fish_interrupted" },
            { "to be biting here", "fish_noFishBiting" }
        };
        
        private static readonly Dictionary<string, string> FishCookerMessages = new Dictionary<string, string>
        {
            { "Too small for", "fish_tooSmall" },
            { "Cooking failed", "fish_cookingFailed" }
        };

        [HarmonyPatch(typeof(BaitItem), "OnTriggerEnter")]
        public static class BaitItemPatch
        {
            [HarmonyTranspiler]
            public static IEnumerable<CodeInstruction> BaitItem_OnTriggerEvent(IEnumerable<CodeInstruction> instructions)
                => ReplaceDialogs(instructions, BaitMessages);
        }        
        
        [HarmonyPatch(typeof(FishingRodWeapon), "Update")]
        public static class FishingRodWeaponPatch
        {
            [HarmonyTranspiler]
            public static IEnumerable<CodeInstruction> BaitItem_Update(IEnumerable<CodeInstruction> instructions)
                => ReplaceDialogs(instructions, FishingRodMessages);
        }
        
        [HarmonyPatch(typeof(FishCooker), "OnTriggerEnter")]
        public static class FishCookerPatch
        {
            [HarmonyTranspiler]
            public static IEnumerable<CodeInstruction> FishCooker_OnTriggerEnter(IEnumerable<CodeInstruction> instructions)
                => ReplaceDialogs(instructions, FishCookerMessages);
        }

        private static IEnumerable<CodeInstruction> ReplaceDialogs(IEnumerable<CodeInstruction> instructions, Dictionary<string, string> replacement)
        {
            var code  = instructions.ToList();
            for (var i = 0; i < code.Count; i++)
            {
                if (code[i].opcode != Ldstr)
                    continue;
                
                var dialogOption = replacement
                    .Where(entry => code[i].operand is string str && str.Contains(entry.Key))
                    .Select(entry => entry.Value)
                    .FirstOrDefault();
                
                if (dialogOption == default)
                    continue;
                
                ReplaceLdstr(i, dialogOption, code);
                i += ReplacementInstructionsLength - 1;
            }
            return code;
        }

        private static void ReplaceLdstr(int start, string subtitles, List<CodeInstruction> instructions)
        {
            instructions.RemoveAt(start);
            instructions.InsertRange(start, ReplaceLdstr(subtitles));
        }
        
        private static IEnumerable<CodeInstruction> ReplaceLdstr(string subtitles)
        {
            return IL(
                (Call, Method(typeof(LanguageManager), "get_CurrentLanguage")),
                (Ldfld, Field(typeof(JsonFormat), "fishing")),
                (Ldfld, Field(typeof(FishingStrings), subtitles)));
        }
    }
}