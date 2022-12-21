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

        public void PatchOpeningCredits()
        {
            GameObject level = GetInactiveRootObject("Canvas");

            GameObject openingCredsParent = GetGameObjectChild(level, "HurtScreen");

            Text openingCredsFirst = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(openingCredsParent, "Text 1 Sound"), "Text (1)"));
            openingCredsFirst.text = LanguageManager.CurrentLanguage.prelude.prelude_first_openingCredits1;

            Text openingCredsSecond = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(openingCredsParent, "Text 2 Sound"), "Text (2)"));
            openingCredsSecond.text = LanguageManager.CurrentLanguage.prelude.prelude_first_openingCredits2;
        }


        public Prelude(ref GameObject level)
        {
            this.baseLevelObject = level;
            string currentLevel = SceneManager.GetActiveScene().name;

            if (currentLevel.Contains("-1"))
            {
                Debug.Log("In 0-1");
                try
                {
                    this.PatchOpeningCredits();
                }
                catch(Exception e)
                {
                    Debug.Log("Failed to patch opening credits in 0-1");
                    Console.Write(e.ToString());
                }
            }

            Debug.Log("Patching results screen...");
            string levelName = PreludeStrings.GetLevelName();
            string levelChallenge = PreludeStrings.GetLevelChallenge(currentLevel);

            PatchResultsScreen(levelName,levelChallenge);

        }
    }
}
