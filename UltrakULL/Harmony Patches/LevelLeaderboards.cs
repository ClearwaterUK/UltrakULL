using HarmonyLib;
using UnityEngine.UI;
using UltrakULL.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using UnityEngine;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    public class LevelLeaderboards
    {
        [HarmonyPatch(typeof(LevelSelectLeaderboard),"OnEnable")]
        public class LevelLeaderboardPatch
        {
            [HarmonyPostfix]
            public static void LevelLeaderboardPatch_Postfix(ref Text ___anyPercentLabel, ref Text ___pRankLabel, ref GameObject ___noItemsPanel)
            {
                LeaderboardProperties.Difficulties[0] = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;
                LeaderboardProperties.Difficulties[1] =  LanguageManager.CurrentLanguage.frontend.difficulty_lenient;
                LeaderboardProperties.Difficulties[2] =  LanguageManager.CurrentLanguage.frontend.difficulty_standard;
                LeaderboardProperties.Difficulties[3] =  LanguageManager.CurrentLanguage.frontend.difficulty_violent;
                
                ___anyPercentLabel.text = LanguageManager.CurrentLanguage.frontend.leaderboard_anyPercent;
                ___pRankLabel.text = LanguageManager.CurrentLanguage.frontend.leaderboard_pPercent;
                
                Text noItems = GetTextfromGameObject(GetGameObjectChild(___noItemsPanel,"Text"));
                noItems.text = LanguageManager.CurrentLanguage.frontend.leaderboard_noEntries;
            }
        }
        
        [HarmonyPatch(typeof(LevelEndLeaderboard),"OnEnable")]
        public class LevelLeaderboardEndPatch
        {
            [HarmonyPostfix]
            public static void LevelLeaderboardEndPatch_Postfix(ref bool ___displayPRank, ref Text ___leaderboardType, ref GameObject ___loadingPanel)
            {
                ___leaderboardType.text = (___displayPRank ? LanguageManager.CurrentLanguage.frontend.leaderboard_pPercent : LanguageManager.CurrentLanguage.frontend.leaderboard_anyPercent);
                
                Text connecting = GetTextfromGameObject(___loadingPanel);
                connecting.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_connectingToSteam;
            }
        }
        
    }
}