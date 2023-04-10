using System;
using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the CreateButtons function from the SpawnMenu class for translating spawner arm menu sections.
    [HarmonyPatch(typeof(SpawnMenu), "CreateButtons")]
    public static class SpawnMenuPatch
    {
        [HarmonyPrefix]
        public static bool CreateButtons_Prefix(SpawnableObject[] list, ref string sectionName, ref SpawnMenu __instance)
        {
            Console.WriteLine(sectionName);
            switch(sectionName)
            {
                case "SANDBOX TOOLS :^)": { sectionName = LanguageManager.CurrentLanguage.misc.spawner_sandboxTools; break; }
                case "SANDBOX": { sectionName = LanguageManager.CurrentLanguage.misc.spawner_sandbox; break; }
                case "ENEMIES": { sectionName = LanguageManager.CurrentLanguage.misc.spawner_enemies; break; }
                case "ITEMS": { sectionName = LanguageManager.CurrentLanguage.misc.spawner_items; break; }
                case "SPECIAL": { sectionName = LanguageManager.CurrentLanguage.misc.spawner_special; break; }
                case "UNLOCKABLES": { sectionName = LanguageManager.CurrentLanguage.misc.spawner_unlockables; break; }
            }
            Console.WriteLine(sectionName);

            return true;
        }

    }
}
