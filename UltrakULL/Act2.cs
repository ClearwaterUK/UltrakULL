using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

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
            string levelName = Act2Challenges.GetLevelName();
            string levelChallenge = Act2Challenges.GetLevelChallenge(currentLevel);
            
            PatchResultsScreen(levelName, levelChallenge);
            PatchHellmap(ref canvasObj);
        }
    }
}
