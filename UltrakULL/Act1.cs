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
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Act1
    {
        private static BepInEx.Logging.ManualLogSource a1Logger = BepInEx.Logging.Logger.CreateLogSource("Act1Patcher");

        private static void patchHellmap()
        {
            a1Logger.LogInfo("Patching Act 1 hellmap");
            try
            {
                GameObject canvas = getInactiveRootObject("Canvas");

                GameObject hellMapObject = getGameObjectChild(canvas, "Hellmap");

                Text hellmapLimbo = getTextfromGameObject(getGameObjectChild(hellMapObject, "Text"));
                hellmapLimbo.text = LanguageManager.CurrentLanguage.misc.hellmap_limbo;

                Text hellmapLust = getTextfromGameObject(getGameObjectChild(hellMapObject, "Text (1)"));
                hellmapLust.text = LanguageManager.CurrentLanguage.misc.hellmap_lust;

                Text hellmapGluttony = getTextfromGameObject(getGameObjectChild(hellMapObject, "Text (2)"));
                hellmapGluttony.text = LanguageManager.CurrentLanguage.misc.hellmap_gluttony;
            }
            catch(Exception e)
            {
                a1Logger.LogError("Failed to patch Act 1 hellmap.");
                Console.WriteLine(e.ToString());
            }
        }

        public static void PatchAct1(ref GameObject level) // I've never seen the level argument used, is this meant to do something?
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            string levelName = Act1Strings.getLevelName();
            string levelChallenge = Act1Strings.getLevelChallenge(currentLevel);

            patchHellmap();
            patchResultsScreen(levelName, levelChallenge);

        }
    }
}
