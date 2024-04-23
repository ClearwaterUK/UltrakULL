using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using UltrakULL.json;
using static System.Reflection.Emit.OpCodes;
using static HarmonyLib.AccessTools;
using static UltrakULL.CommonFunctions;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;

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
        private const string MandaloreColour = "<color=#FFC49E>";
        private const string OwlColour = "<color=#9EE6FF>";

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

        [HarmonyPatch("Start"), HarmonyTranspiler]
        static IEnumerable<CodeInstruction> MandaloreStartTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
            for (int i = 0; i < codes.Count; i++)
            {
                bool isLdstr = (codes[i].opcode == OpCodes.Ldstr);
                if (isLdstr)
                {
                    if (((string)codes[i].operand).Contains("You cannot"))
                    {
                        codes[i].operand = MandaloreColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_taunt3 + "</color>";
                    }
                    else if (((string)codes[i].operand).Contains("I'm gonna"))
                    {
                        codes[i].operand = OwlColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_taunt2 + "</color>";
                    }
                    else if (((string)codes[i].operand).Contains("Why"))
                    {
                        codes[i].operand = OwlColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_taunt5 + "</color>";
                    }
                    else if (((string)codes[i].operand).Contains("fucking poison"))
                    {
                        codes[i].operand = OwlColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_taunt1 + "</color>";
                    }
                    else if (((string)codes[i].operand).Contains("What"))
                    {
                        codes[i].operand = MandaloreColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_intro2 + "</color>";
                    }
                    else if (((string)codes[i].operand).Contains("Hold still"))
                    {
                        codes[i].operand = MandaloreColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_taunt4 + "</color>";
                    }
                }
            }
            return codes;
        }
        /*
        [HarmonyPatch("Start"), HarmonyPostfix]
        public static void Mandalore_Start(ref Mandalore __instance, ref bool ___taunt)
        {
            if (___taunt)
            {
                int num = UnityEngine.Random.Range(0, __instance.voices[0].taunts.Length);
                MandaloreVoice[] array = __instance.voices;
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].Taunt(num);
                }
                switch (num)
                {
                    case 0:
                        MonoSingleton<SubtitleController>.Instance.DisplaySubtitle("<color=#FFC49E>[NMO]You cannot imagine what you'll face here</color>", null, false);
                        MonoSingleton<SubtitleController>.Instance.DisplaySubtitle("<color=#9EE6FF>[NMO]I'm gonna shoot em with a gun</color>", 2.5f, __instance.GetComponentInParent<Transform>().gameObject);
                        return;
                    case 1:
                        MonoSingleton<SubtitleController>.Instance.DisplaySubtitle("<color=#9EE6FF>[NMO]Why are we in the past</color>", null, false);
                        return;
                    case 2:
                        MonoSingleton<SubtitleController>.Instance.DisplaySubtitle("<color=#9EE6FF>[NMO]I'm going to fucking poison you</color>", null, false);
                        MonoSingleton<SubtitleController>.Instance.DisplaySubtitle("<color=#FFC49E>[MO]What</color>", 2f, __instance.GetComponentInParent<Transform>().gameObject);
                        return;
                    case 3:
                        MonoSingleton<SubtitleController>.Instance.DisplaySubtitle("<color=#FFC49E>[MO]Hold still</color>", 0.6f, __instance.GetComponentInParent<Transform>().gameObject);
                        break;
                    default:
                        return;
                }
            }
        }*/
        [HarmonyPatch("Update"), HarmonyTranspiler]
        static IEnumerable<CodeInstruction> MandaloreUpdateTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
            for (int i = 0; i < codes.Count; i++)
            {
                bool isLdstr = (codes[i].opcode == OpCodes.Ldstr);
                if (isLdstr)
                {
                    if (((string)codes[i].operand).Contains("now we lost"))
                    {
                        codes[i].operand = OwlColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_defeated + "</color>";
                    }
                    else if (((string)codes[i].operand).Contains("Full auto"))
                    {
                        codes[i].operand = MandaloreColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_attack1 + "</color>";
                    } 
                    else if (((string)codes[i].operand).Contains("Fuller auto"))
                    {
                        codes[i].operand = MandaloreColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_attack2 + "</color>";
                    }
                    else if (((string)codes[i].operand).Contains("Use the salt"))
                    {
                        codes[i].operand = OwlColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_phaseChangeThird1 + "</color>";
                    }
                    else if (((string)codes[i].operand).Contains("I'm reaching"))
                    {
                        codes[i].operand = MandaloreColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_phaseChangeThird2 + "</color>";
                    }
                    else if (((string)codes[i].operand).Contains("Feel my maximum speed"))
                    {
                        codes[i].operand = MandaloreColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_phaseChangeSecond1 + "</color>";
                    }
                    else if (((string)codes[i].operand).Contains("Slow down"))
                    {
                        codes[i].operand = OwlColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_phaseChangeSecond2 + "</color>";
                    }
                    else if (((string)codes[i].operand).Contains("I increase my speed"))
                    {
                        codes[i].operand = MandaloreColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_phaseChangeFirst1 + "</color>";
                    }
                    else if (((string)codes[i].operand).Contains("Just fucking"))
                    {
                        codes[i].operand = OwlColour + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_phaseChangeFirst2 + "</color>";
                    }
                }
            }
            return codes;
        }
        /*[HarmonyTranspiler]
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
            //ReplaceLdstr(switchOffset, 0x2D, "subtitles_mandalore_taunt4", MandaloreColor, code); //works

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
            (Call, Method(typeof(string), "Concat", new[] { typeof(string), typeof(string), typeof(string) })));
            }
    }
}
