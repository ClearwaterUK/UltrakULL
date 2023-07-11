using System.Collections.Generic;
using System.Text.RegularExpressions;
using Antlr4.StringTemplate;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the Start method to intercept and localize string in the intermissions
    [HarmonyPatch(typeof(IntermissionController), "Start")]
    public static class LocalizeIntermission
    {
        private static readonly Dictionary<string, string> Act1Intermission = new Dictionary<string, string>
        {
            { "Text", "ACT_1_INTERMISSION_1" },
            { "Text (1)", "ACT_1_INTERMISSION_2" },
            { "Text (2)", "ACT_1_INTERMISSION_3" }
        };
        
        private static readonly Dictionary<string, string> Act2Intermission = new Dictionary<string, string>
        {
            { "Scene 1: Text 1", "ACT_2_INTERMISSION_1" },
            { "Scene 1: Text 2", "ACT_2_INTERMISSION_2" },
            { "Scene 2: Text 1", "ACT_2_INTERMISSION_3" },
            { "Scene 2: Text 2", "ACT_2_INTERMISSION_4" },
            { "Scene 2: Text 3", "ACT_2_INTERMISSION_5" },
            { "Scene 3: Text 1", "ACT_2_INTERMISSION_6" }
        };

        private static readonly TemplateGroup IntermissionTemplates = new TemplateGroupString(Resources.Intermissions);
        
        [HarmonyPrefix]
        public static bool Start_MyPatch(IntermissionController __instance, ref string ___preText, ref string ___fullString, ref Text ___txt)
        {
            IntermissionTemplates.EnableCache = false;
            var currentLevel = GetCurrentSceneName();
            
            ___txt = __instance.GetComponent<Text>();
            ___fullString = ___txt.text;
            ___txt.text = "";
            
            switch (currentLevel)
            {
                case "Intermission1":
                {
                    if (!Act1Intermission.TryGetValue(__instance.name, out var template))
                        break;

                    ___fullString = IntermissionTemplates.GetInstanceOf(template)
                        .Add("intermission", LanguageManager.CurrentLanguage.intermission)
                        .Render();
                    break;
                }
                case "Intermission2":
                {
                    if (!Act2Intermission.TryGetValue(__instance.name, out var template))
                        break;
 
                    ___fullString = IntermissionTemplates.GetInstanceOf(template)
                        .Add("intermission", LanguageManager.CurrentLanguage.intermission)
                        .Render();
                    
                    break;
                }
                case "Level 2-S":
                {
                    ___fullString = Act1Vn.GetString(__instance);
                    var openingTag = "<color=grey>";
                    var closingTag = "</color>";
                    var mirageName = Regex.Replace(___preText, @"<[^>]*>", "");
                    switch (mirageName)
                    {
                        case "???:": { break; }
                        case "JUST SOMEONE:": { ___preText = openingTag + LanguageManager.CurrentLanguage.visualnovel.visualnovel_mirageName1 + closingTag + ":"; break; }
                        case "THE PRETTIEST GIRL IN TOWN:": { ___preText = openingTag + LanguageManager.CurrentLanguage.visualnovel.visualnovel_mirageName2 + closingTag + ":"; break;}
                        case "MIRAGE:": { ___preText = openingTag + LanguageManager.CurrentLanguage.visualnovel.visualnovel_mirageName3 + closingTag + ":"; break; }
                    }
                    break;
                }
            }
            ___txt.text = ___fullString;

            return true;
        }
    }
}
