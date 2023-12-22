using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    class Prelude
    {
        public void PatchOpeningCredits(ref GameObject canvasObj)
        {
            GameObject openingCredsParent = GetGameObjectChild(canvasObj, "HurtScreen");

            TextMeshProUGUI openingCredsFirst = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(openingCredsParent, "Text 1 Sound"), "Text (1)"));
            openingCredsFirst.text = LanguageManager.CurrentLanguage.prelude.prelude_first_openingCredits1;

            TextMeshProUGUI openingCredsSecond = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(openingCredsParent, "Text 2 Sound"), "Text (2)"));
            openingCredsSecond.text = LanguageManager.CurrentLanguage.prelude.prelude_first_openingCredits2;
        }

        public Prelude(ref GameObject level)
        {
            string currentLevel = GetCurrentSceneName();

            if (currentLevel == "Level 0-1")
            {
                try
                {
                    this.PatchOpeningCredits(ref level);

                }
                catch(Exception e)
                {
                    Logging.Warn("Failed to patch opening credits in 0-1");
                    Logging.Warn(e.ToString());
                }
            }
            
            string levelName = PreludeStrings.GetLevelName();
            string levelChallenge = PreludeStrings.GetLevelChallenge(currentLevel);

            PatchResultsScreen(levelName,levelChallenge);
        }
    }
}