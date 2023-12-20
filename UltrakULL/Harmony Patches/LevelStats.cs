using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches
{

    //@Override
    //Overrides the Start method from LevelStats class to localize level names
    [HarmonyPatch(typeof(LevelStats), "Start")]
    public static class LocalizeLevelStatNames
    {
        private static StatsManager sman = MonoSingleton<StatsManager>.Instance;
        
        [HarmonyPostfix]
        public static void LevelStatsStart_Postfix(LevelStats __instance)//, StatsManager ___sman)
        {
            if(isUsingEnglish())
            {
                return;
            }
            if (__instance.secretLevel)
            {
                __instance.levelName.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
            }
            if (SceneHelper.IsPlayingCustom)
            {
                MapInfo instance = MapInfo.Instance;
                __instance.levelName.text = ((instance != null) ? instance.levelName : "???");
            }
            RankData rankData = null;
            if (sman.levelNumber != 0 && !Debug.isDebugBuild)
            {
                rankData = GameProgressSaver.GetRank(true);
            }
            if (sman.levelNumber != 0 && (Debug.isDebugBuild || (rankData != null && rankData.levelNumber == sman.levelNumber)))
            {
                StockMapInfo instance2 = StockMapInfo.Instance;
                if (instance2 != null)
                {
                    __instance.levelName.text = LevelNames.GetDiscordLevelName(GetCurrentSceneName());
                }
            }
        }
    }

    //@Override
    //Overrides the CheckStats method from the LevelStats class to localize the stats screen
    [HarmonyPatch(typeof(LevelStats), "CheckStats")]
    public static class LocalizeStatsScreen
    {
        private static StatsManager sman = MonoSingleton<StatsManager>.Instance;
        
        [HarmonyPostfix]
        public static void CheckStats_Postfix(LevelStats __instance)
        {
            if(isUsingEnglish())
            {
                return;
            }
            if (__instance.challenge)
            {
                if (MonoSingleton<ChallengeManager>.Instance.challengeDone && !MonoSingleton<ChallengeManager>.Instance.challengeFailed)
                {
                    __instance.challenge.text = "<color=#FFAF00>" + LanguageManager.CurrentLanguage.misc.state_yes + "</color>";
                }
                else
                {
                    __instance.challenge.text = LanguageManager.CurrentLanguage.misc.state_no;
                }
            }
            if (__instance.majorAssists)
            {
                if (sman.majorUsed)
                {
                    __instance.majorAssists.text = "<color=#4C99E6>" + LanguageManager.CurrentLanguage.misc.state_yes + "</color>";
                    return;
                }
                __instance.majorAssists.text = LanguageManager.CurrentLanguage.misc.state_no;
            }
        }
    }
}
