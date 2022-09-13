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
    class Act1
    {
        public GameObject baseLevelObject;
        BepInEx.Logging.ManualLogSource a1Logger = BepInEx.Logging.Logger.CreateLogSource("Act1Patcher");

        public void patchHellmap(JsonParser language)
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

        public Act1(ref GameObject level, JsonParser language)
        {
            a1Logger.LogInfo("Now entering Act 1 class.");
            this.baseLevelObject = level;
            string currentLevel = SceneManager.GetActiveScene().name;

            this.patchHellmap(language);

            Act1Strings a1ChallengeStrings = new Act1Strings();
            string levelName = a1ChallengeStrings.getLevelName(language);
            string levelChallenge = a1ChallengeStrings.getLevelChallenge(currentLevel, language);

            patchResultsScreen(levelName, levelChallenge, language);

        }
    }
}
