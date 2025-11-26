using GameConsole;
using HarmonyLib;

namespace UltrakULL.Commands
{
    [HarmonyPatch(typeof(Console))]
    public class ConsolePatcher
    {
        [HarmonyPrefix]
        [HarmonyPatch("Awake")]
        public static void AddConsoleCommands(Console __instance)
        {
            var Command = new CommandToRegister(__instance);
            __instance.RegisterCommand(Command);
        }
    }
}


