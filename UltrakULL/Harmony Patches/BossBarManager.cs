using HarmonyLib;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the CreateBossBar method from the BossBarManager class. This is needed to swap in the translated boss names on their health bars.
    [HarmonyPatch(typeof(BossBarManager), "CreateBossBar")]
    public static class Localize_BossBar
    {
        [HarmonyPrefix]
        public static bool CreateBossBar_MyPatch(ref string bossName)
        {
            bossName = BossStrings.getBossName(bossName);
            return true;
        }
    }
}
