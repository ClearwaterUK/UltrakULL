using System;
using UltrakULL.audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Act1
    {
        private static void PatchHellmap()
        {
            Debug.Log("Patching Act 1 hellmap");
            try
            {
                GameObject canvas = GetInactiveRootObject("Canvas");

                GameObject hellMapObject = GetGameObjectChild(canvas, "Hellmap");

                Text hellmapLimbo = GetTextfromGameObject(GetGameObjectChild(hellMapObject, "Text"));
                hellmapLimbo.text = LanguageManager.CurrentLanguage.misc.hellmap_limbo;

                Text hellmapLust = GetTextfromGameObject(GetGameObjectChild(hellMapObject, "Text (1)"));
                hellmapLust.text = LanguageManager.CurrentLanguage.misc.hellmap_lust;

                Text hellmapGluttony = GetTextfromGameObject(GetGameObjectChild(hellMapObject, "Text (2)"));
                hellmapGluttony.text = LanguageManager.CurrentLanguage.misc.hellmap_gluttony;
            }
            catch(Exception e)
            {
                Debug.Log("Failed to patch Act 1 hellmap.");
                Console.WriteLine(e.ToString());
            }
        }

        public static void PatchAct1(ref GameObject level) // I've never seen the level argument used, is this meant to do something?
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            string levelName = Act1Strings.GetLevelName();
            string levelChallenge = Act1Strings.GetLevelChallenge(currentLevel);

            PatchHellmap();
            PatchResultsScreen(levelName, levelChallenge);
            AudioSwapper.AudioSwap(SceneManager.GetActiveScene().name);

        }
    }
}
