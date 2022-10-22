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

        private static void patchHellmap(JsonParser language)
        {
            a1Logger.LogInfo("Patching Act 1 hellmap");
            try
            {
                GameObject canvas = getInactiveRootObject("Canvas");

                GameObject hellMapObject = getGameObjectChild(canvas, "Hellmap");

                Text hellmapLimbo = getTextfromGameObject(getGameObjectChild(hellMapObject, "Text"));
                hellmapLimbo.text = language.currentLanguage.misc.hellmap_limbo;

                Text hellmapLust = getTextfromGameObject(getGameObjectChild(hellMapObject, "Text (1)"));
                hellmapLust.text = language.currentLanguage.misc.hellmap_lust;

                Text hellmapGluttony = getTextfromGameObject(getGameObjectChild(hellMapObject, "Text (2)"));
                hellmapGluttony.text = language.currentLanguage.misc.hellmap_gluttony;
            }
            catch(Exception e)
            {
                a1Logger.LogError("Failed to patch Act 1 hellmap.");
                Console.WriteLine(e.ToString());
            }
        }

        public static void PatchAct1(ref GameObject level, JsonParser language) // I've never seen the level argument used, is this meant to do something?
        {
            a1Logger.LogInfo("Now entering Act 1 class.");
            //this.baseLevelObject = level; // This isn't used so it's commented out
            string currentLevel = SceneManager.GetActiveScene().name;

            patchHellmap(language);

            string levelName = Act1Strings.getLevelName(language);
            string levelChallenge = Act1Strings.getLevelChallenge(currentLevel, language);

            patchResultsScreen(levelName, levelChallenge, language);

        }
    }
}
