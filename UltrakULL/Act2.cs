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
    class Act2
    {
        public GameObject baseLevelObject;
        BepInEx.Logging.ManualLogSource a2Logger = BepInEx.Logging.Logger.CreateLogSource("Act2Patcher");

        public Act2(ref GameObject level, JsonParser language)
        {
            a2Logger.LogInfo("Now entering Act 2 class.");

            a2Logger.LogInfo("Patching Act 2 hellmap");
            GameObject baseObject = GameObject.Find("Canvas");

            GameObject hellMapObject = getGameObjectChild(baseObject, "Hellmap");
            Text hellmapGreed = getTextfromGameObject(getGameObjectChild(hellMapObject, "Text"));
            hellmapGreed.text = language.currentLanguage.misc.hellmap_greed;

            Text hellmapWrath = getTextfromGameObject(getGameObjectChild(hellMapObject, "Text (1)"));
            hellmapWrath.text = language.currentLanguage.misc.hellmap_wrath;

            Text hellmapHeresy = getTextfromGameObject(getGameObjectChild(hellMapObject, "Text (2)"));
            hellmapHeresy.text = language.currentLanguage.misc.hellmap_heresy;

            this.baseLevelObject = level;
            string currentLevel = SceneManager.GetActiveScene().name;


            a2Logger.LogInfo("Patching results screen...");
            Act2Strings a2ChallengeStrings = new Act2Strings();
            string levelName = a2ChallengeStrings.getLevelName(language);
            string levelChallenge = a2ChallengeStrings.getLevelChallenge(currentLevel, language);
            patchResultsScreen(levelName, levelChallenge, language);

        }

    }
}
