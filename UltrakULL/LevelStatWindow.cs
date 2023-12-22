using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    public static class LevelStatWindow
    {
        public static void PatchStats(ref GameObject canvasObj)
        {
            GameObject levelStatsWindow = GetGameObjectChild(GetGameObjectChild(canvasObj, "Level Stats Controller"), "Level Stats (1)");
            
            TextMeshProUGUI levelName = GetTextMeshProUGUI(GetGameObjectChild(levelStatsWindow, "Title"));
            levelName.text = LevelNames.GetDiscordLevelName(GetCurrentSceneName());

            //Secret levels will only have a timer, or something else.
            TextMeshProUGUI timeName = GetTextMeshProUGUI(GetGameObjectChild(levelStatsWindow, "Time Title"));
            timeName.text = LanguageManager.CurrentLanguage.misc.levelstats_time; 

            TextMeshProUGUI killsName = GetTextMeshProUGUI(GetGameObjectChild(levelStatsWindow, "Kills Title"));
            killsName.text = LanguageManager.CurrentLanguage.misc.levelstats_kills;

            TextMeshProUGUI styleName = GetTextMeshProUGUI(GetGameObjectChild(levelStatsWindow, "Style Title"));
            styleName.text = LanguageManager.CurrentLanguage.misc.levelstats_style;

            TextMeshProUGUI secretsName = GetTextMeshProUGUI(GetGameObjectChild(levelStatsWindow, "Secrets Title"));
            secretsName.text = LanguageManager.CurrentLanguage.misc.levelstats_secrets;

            TextMeshProUGUI challengesName = GetTextMeshProUGUI(GetGameObjectChild(levelStatsWindow, "Challenge Title"));
            challengesName.text = LanguageManager.CurrentLanguage.misc.levelstats_challenge;

            TextMeshProUGUI assistsName = GetTextMeshProUGUI(GetGameObjectChild(levelStatsWindow, "Assists Title"));
            assistsName.text = LanguageManager.CurrentLanguage.misc.levelstats_majorAssists;

            if (GetCurrentSceneName() == "Level 4-S")
            {
                TextMeshProUGUI cratesName = GetTextMeshProUGUI(GetGameObjectChild(levelStatsWindow, "Crates Counter"));
                cratesName.text = LanguageManager.CurrentLanguage.misc.levelstats_boxes;
            }
        }
    }
}
