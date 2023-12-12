using HarmonyLib;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the CreateBossBar method from the BossBarManager class. This is needed to swap in the translated boss names on their health bars.
    [HarmonyPatch(typeof(BossBarManager), "CreateBossBar")]
    public static class LocalizeBossBar
    {
        [HarmonyPrefix]
        public static bool CreateBossBar_MyPatch(ref string bossName)
        {
            if(!isUsingEnglish())
            {
                bossName = BossStrings.GetBossName(bossName);
            }
            return true;
        }
    }
}
