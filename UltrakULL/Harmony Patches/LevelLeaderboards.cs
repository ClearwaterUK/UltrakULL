using HarmonyLib;
using UnityEngine.UI;
using UltrakULL.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using TMPro;
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
            public static void LevelLeaderboardPatch_Postfix(ref TMP_Text ___anyPercentLabel, ref TMP_Text ___pRankLabel, ref GameObject ___noItemsPanel)
            {
                if(isUsingEnglish())
                {
                    return;
                }
                LeaderboardProperties.Difficulties[0] = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;
                LeaderboardProperties.Difficulties[1] =  LanguageManager.CurrentLanguage.frontend.difficulty_lenient;
                LeaderboardProperties.Difficulties[2] =  LanguageManager.CurrentLanguage.frontend.difficulty_standard;
                LeaderboardProperties.Difficulties[3] =  LanguageManager.CurrentLanguage.frontend.difficulty_violent;
                LeaderboardProperties.Difficulties[4] =  LanguageManager.CurrentLanguage.frontend.difficulty_brutal;
                //not yet
                //LeaderboardProperties.Difficulties[5] = LanguageManager.CurrentLanguage.frontend.difficulty_umd;

                ___anyPercentLabel.text = LanguageManager.CurrentLanguage.frontend.leaderboard_anyPercent;
                ___pRankLabel.text = LanguageManager.CurrentLanguage.frontend.leaderboard_pPercent;

                Text noItems = GetTextfromGameObject(GetGameObjectChild(___noItemsPanel,"Text"));
                noItems.text = LanguageManager.CurrentLanguage.frontend.leaderboard_noEntries;

            }
        }
        
        [HarmonyPatch(typeof(LevelEndLeaderboard),"Update")]
        public class LevelLeaderboardEndPatch
        {
            [HarmonyPostfix]
            public static void LevelLeaderboardEndPatch_Postfix(ref bool ___displayPRank, ref TMP_Text ___leaderboardType, ref GameObject ___loadingPanel)
            {
                if(isUsingEnglish())
                {
                    return;
                }
                ___leaderboardType.text = (___displayPRank ? LanguageManager.CurrentLanguage.frontend.leaderboard_pPercent : LanguageManager.CurrentLanguage.frontend.leaderboard_anyPercent);
                
                TextMeshProUGUI connecting = GetTextMeshProUGUI(___loadingPanel);
                connecting.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_connectingToSteam;

                TextMeshProUGUI reminder = GetTextMeshProUGUI(GetGameObjectChild(___loadingPanel.transform.parent.gameObject, "SettingsReminder"));
                reminder.text = LanguageManager.CurrentLanguage.frontend.leaderboard_reminder;
            }
        }
        
    }
}