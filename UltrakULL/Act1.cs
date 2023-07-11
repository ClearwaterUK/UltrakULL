﻿using System;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Act1
    {
        private static void PatchHellmap(ref GameObject canvasObj)
        {
            try
            {
                GameObject hellMapObject = GetGameObjectChild(canvasObj, "Hellmap");

                Text hellmapLimbo = GetTextfromGameObject(GetGameObjectChild(hellMapObject, "Text"));
                hellmapLimbo.text = LanguageManager.CurrentLanguage.misc.hellmap_limbo;

                Text hellmapLust = GetTextfromGameObject(GetGameObjectChild(hellMapObject, "Text (1)"));
                hellmapLust.text = LanguageManager.CurrentLanguage.misc.hellmap_lust;

                Text hellmapGluttony = GetTextfromGameObject(GetGameObjectChild(hellMapObject, "Text (2)"));
                hellmapGluttony.text = LanguageManager.CurrentLanguage.misc.hellmap_gluttony;
            }
            catch(Exception e)
            {
                Logging.Warn("Failed to patch Act 1 hellmap.");
                Logging.Warn(e.ToString());
            }
        }

        public static void PatchAct1(ref GameObject canvasObj)
        {
            string currentLevel = GetCurrentSceneName();
            string levelName = Act1Challenges.GetLevelName();
            string levelChallenge = Act1Challenges.GetLevelChallenge(currentLevel);

            PatchHellmap(ref canvasObj);
            PatchResultsScreen(levelName, levelChallenge);
        }
    }
}
