using BepInEx;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    public static class Act2
    {
        private static BepInEx.Logging.ManualLogSource a2Logger = BepInEx.Logging.Logger.CreateLogSource("Act2Patcher");

        public static void PatchAct2(ref GameObject level, JsonParser language)
        {
            a2Logger.LogInfo("Now entering Act 2 class.");

            a2Logger.LogInfo("Patching Act 2 hellmap");


            List<GameObject> a = new List<GameObject>();
            SceneManager.GetActiveScene().GetRootGameObjects(a);
            Console.WriteLine(a.Count);
            GameObject canvas = null;
            foreach (GameObject child in a)
            {
                if (child.name == "Canvas")
                {
                    canvas = child;
                }
            }

            GameObject hellMapObject = getGameObjectChild(canvas, "Hellmap");
            Text hellmapGreed = getTextfromGameObject(getGameObjectChild(hellMapObject, "Text"));
            hellmapGreed.text = language.currentLanguage.misc.hellmap_greed;

            Text hellmapWrath = getTextfromGameObject(getGameObjectChild(hellMapObject, "Text (1)"));
            hellmapWrath.text = language.currentLanguage.misc.hellmap_wrath;

            Text hellmapHeresy = getTextfromGameObject(getGameObjectChild(hellMapObject, "Text (2)"));
            hellmapHeresy.text = language.currentLanguage.misc.hellmap_heresy;

            // this.baseLevelObject = level; // This hasn't been used yet so it's commented out
            string currentLevel = SceneManager.GetActiveScene().name;


            a2Logger.LogInfo("Patching results screen...");
            string levelName = Act2Strings.getLevelName(language);
            string levelChallenge = Act2Strings.getLevelChallenge(currentLevel, language);
            patchResultsScreen(levelName, levelChallenge, language);

        }

    }
}
