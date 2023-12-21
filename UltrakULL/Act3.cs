using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UltrakULL.audio;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    public static class Act3
    {
        private static void PatchHellmap(ref GameObject canvasObj)
        {
            GameObject hellMapObject = GetGameObjectChild(GetGameObjectChild(canvasObj, "Hellmap"),"Hellmap Act 3");
            TextMeshProUGUI hellmapViolence = GetTextMeshProUGUI(GetGameObjectChild(hellMapObject, "Text"));
            hellmapViolence.text = LanguageManager.CurrentLanguage.misc.hellmap_violence;

            TextMeshProUGUI hellmapFraud = GetTextMeshProUGUI(GetGameObjectChild(hellMapObject, "Text (1)"));
            hellmapFraud.text = LanguageManager.CurrentLanguage.misc.hellmap_fraud;

            TextMeshProUGUI hellmapTreachery = GetTextMeshProUGUI(GetGameObjectChild(hellMapObject, "Text (2)"));
            hellmapTreachery.text = LanguageManager.CurrentLanguage.misc.hellmap_treachery;
        }
    
        public static void PatchAct3(ref GameObject canvasObj)
        {
            string currentLevel = GetCurrentSceneName();
            string levelName = Act3Strings.GetLevelName();
            string levelChallenge = Act3Strings.GetLevelChallenge(currentLevel);
            
            PatchResultsScreen(levelName, levelChallenge);
            PatchHellmap(ref canvasObj);
        }
    }
}