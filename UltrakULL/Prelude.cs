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

        public void patchOpeningCredits()
        {
            GameObject level = getInactiveRootObject("Canvas");

            GameObject openingCredsParent = getGameObjectChild(level, "HurtScreen");

            Text openingCredsFirst = getTextfromGameObject(getGameObjectChild(getGameObjectChild(openingCredsParent, "Text 1 Sound"), "Text (1)"));
            openingCredsFirst.text = LanguageManager.CurrentLanguage.prelude.prelude_first_openingCredits1;

            Text openingCredsSecond = getTextfromGameObject(getGameObjectChild(getGameObjectChild(openingCredsParent, "Text 2 Sound"), "Text (2)"));
            openingCredsSecond.text = LanguageManager.CurrentLanguage.prelude.prelude_first_openingCredits2;
        }


        public Prelude(ref GameObject level)
        {
            BepInEx.Logging.ManualLogSource preludeLogger = BepInEx.Logging.Logger.CreateLogSource("PreludePatcher");
            this.baseLevelObject = level;
            string currentLevel = SceneManager.GetActiveScene().name;

            if (currentLevel.Contains("-1"))
            {
                preludeLogger.LogInfo("In 0-1");
                try
                {
                    this.patchOpeningCredits();
                }
                catch(Exception e)
                {
                    preludeLogger.LogError("Failed to patch opening credits in 0-1");
                    Console.Write(e.ToString());
                }
            }

            preludeLogger.LogInfo("Patching results screen...");
            string levelName = PreludeStrings.getLevelName();
            string levelChallenge = PreludeStrings.getLevelChallenge(currentLevel);

            patchResultsScreen(levelName,levelChallenge);

        }
    }
}
