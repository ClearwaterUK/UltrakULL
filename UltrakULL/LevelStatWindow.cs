using UnityEngine;
using UnityEngine.SceneManagement;
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
            
            //Secret levels will only have a timer, or something else.
            Text timeName = GetTextfromGameObject(GetGameObjectChild(levelStatsWindow, "Time Title"));
            timeName.text = LanguageManager.CurrentLanguage.misc.levelstats_time; 

            Text killsName = GetTextfromGameObject(GetGameObjectChild(levelStatsWindow, "Kills Title"));
            killsName.text = LanguageManager.CurrentLanguage.misc.levelstats_kills;

            Text styleName = GetTextfromGameObject(GetGameObjectChild(levelStatsWindow, "Style Title"));
            styleName.text = LanguageManager.CurrentLanguage.misc.levelstats_style;

            Text secretsName = GetTextfromGameObject(GetGameObjectChild(levelStatsWindow, "Secrets Title"));
            secretsName.text = LanguageManager.CurrentLanguage.misc.levelstats_secrets;

            Text challengesName = GetTextfromGameObject(GetGameObjectChild(levelStatsWindow, "Challenge Title"));
            challengesName.text = LanguageManager.CurrentLanguage.misc.levelstats_challenge;

            Text assistsName = GetTextfromGameObject(GetGameObjectChild(levelStatsWindow, "Assists Title"));
            assistsName.text = LanguageManager.CurrentLanguage.misc.levelstats_majorAssists;

            if (SceneManager.GetActiveScene().name == "Level 4-S")
            {
                Text cratesName = GetTextfromGameObject(GetGameObjectChild(levelStatsWindow, "Crates Counter"));
                cratesName.text = LanguageManager.CurrentLanguage.misc.levelstats_boxes;
            }
        }
    }
}
