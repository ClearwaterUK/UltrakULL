using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    class Prelude
    {
        public GameObject baseLevelObject;

        public void patchOpeningCredits(JsonParser language)
        {
            GameObject level = GameObject.Find("Canvas");
            GameObject openingCredsParent = getGameObjectChild(getGameObjectChild(level, "Canvas"), "HurtScreen");

            Text openingCredsFirst = getTextfromGameObject(getGameObjectChild(getGameObjectChild(openingCredsParent, "Text 1 Sound"), "Text (1)"));
            openingCredsFirst.text = language.currentLanguage.prelude.prelude_first_openingCredits1;

            Text openingCredsSecond = getTextfromGameObject(getGameObjectChild(getGameObjectChild(openingCredsParent, "Text 2 Sound"), "Text (2)"));
            openingCredsSecond.text = language.currentLanguage.prelude.prelude_first_openingCredits2;
        }


        public Prelude(ref GameObject level, JsonParser language)
        {
            BepInEx.Logging.ManualLogSource preludeLogger = BepInEx.Logging.Logger.CreateLogSource("PreludePatcher");

            preludeLogger.LogInfo("Now entering prelude class.");
            this.baseLevelObject = level;
            string currentLevel = SceneManager.GetActiveScene().name;

            if (currentLevel.Contains("-1"))
            {
                preludeLogger.LogInfo("In 0-1");
                try
                {
                    this.patchOpeningCredits(language);
                }
                catch(Exception e)
                {
                    preludeLogger.LogError("Failed to patch opening credits in 0-1");
                    Console.Write(e.ToString());
                }
            }

            preludeLogger.LogInfo("Patching results screen...");
            PreludeStrings preludeChallengeStrings = new PreludeStrings();
            string levelName = preludeChallengeStrings.getLevelName(language);
            string levelChallenge = preludeChallengeStrings.getLevelChallenge(currentLevel, language);

            patchResultsScreen(levelName,levelChallenge,language);

        }
    }
}
