using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UltrakULL.audio;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    public static class Act2
    {
        private static void PatchHellmap(ref GameObject canvasObj)
        {
            GameObject hellMapObject = GetGameObjectChild(canvasObj, "Hellmap");
            Text hellmapGreed = GetTextfromGameObject(GetGameObjectChild(hellMapObject, "Text"));
            hellmapGreed.text = LanguageManager.CurrentLanguage.misc.hellmap_greed;

            Text hellmapWrath = GetTextfromGameObject(GetGameObjectChild(hellMapObject, "Text (1)"));
            hellmapWrath.text = LanguageManager.CurrentLanguage.misc.hellmap_wrath;

            Text hellmapHeresy = GetTextfromGameObject(GetGameObjectChild(hellMapObject, "Text (2)"));
            hellmapHeresy.text = LanguageManager.CurrentLanguage.misc.hellmap_heresy;
        }
    
        public static void PatchAct2(ref GameObject canvasObj)
        {
            string currentLevel = GetCurrentSceneName();
            string levelName = Act2Strings.GetLevelName();
            string levelChallenge = Act2Strings.GetLevelChallenge(currentLevel);
            
            PatchResultsScreen(levelName, levelChallenge);
            PatchHellmap(ref canvasObj);
            AudioSwapper.AudioSwap(currentLevel);
        }
    }
}
