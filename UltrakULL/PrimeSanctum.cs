using UltrakULL.audio;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    class PrimeSanctum
    {
        private void PatchSecretText(PrimeSanctumStrings strings)
        {
            string currentLevel = GetCurrentSceneName();

            Text secretText = null;

            if (currentLevel.Contains("P-1"))
            {
                GameObject bossRoom = GetInactiveRootObject("3 - Fuckatorium");

                secretText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(bossRoom, "3 Stuff"),"End"),"FinalRoom Prime"),"Testament Shop"),"Canvas"),"Border"),"TipBox"),"Panel"),"Scroll View"),"Viewport"),"Content"),"Text (1)"));
            }
            else if (currentLevel.Contains("P-2"))
            {
                GameObject bossRoom = GetGameObjectChild(GetInactiveRootObject("Main Section"),"9 - Boss Arena");
                
                secretText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(bossRoom, "Boss Stuff"),"Outro"),"FinalRoom Prime Variant"),"Testament Shop"),"Canvas"),"Border"),"TipBox"),"Panel"),"Scroll View"),"Viewport"),"Content"),"Text (1)"));
            }

            if (secretText != null)
            {
                secretText.fontSize = 18;
                secretText.text = strings.GetSecretText();
            }

            
        }

        public PrimeSanctum()
        {
            string currentLevel = GetCurrentSceneName();

            if (currentLevel.Contains("P-1"))
            {
                PrimeSanctumStrings primeSanctumChallengeStrings = new PrimeSanctumStrings();
                string levelname = primeSanctumChallengeStrings.GetLevelName();
                PatchResultsScreen(levelname, "");
                
                PatchSecretText(primeSanctumChallengeStrings);
            }
            else if (currentLevel.Contains("P-2"))
            {
                PrimeSanctumStrings primeSanctumChallengeStrings = new PrimeSanctumStrings();
                string levelname = primeSanctumChallengeStrings.GetLevelName();
                
                //First lock buttons
                GameObject firstLockObject = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Main Section"),"Inside"),"8 - Elevator"),"8 Stuff"),"PuzzleScreen"),"Canvas");
                
                Text firstLockLocked = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(firstLockObject,"Button"),"Text (Locked)"));
                Text firstLockUnlocked = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(firstLockObject,"Button"),"Text (Unlocked)"));
                Text secondLockLocked = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(firstLockObject,"Button (1)"),"Text (Locked)"));
                Text secondLockUnlocked = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(firstLockObject,"Button (1)"),"Text (Unlocked)"));
                Text thirdLockLocked = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(firstLockObject,"Button (2)"),"Text (Locked)"));
                Text thirdLockUnlocked = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(firstLockObject,"Button (2)"),"Text (Unlocked)"));

                firstLockLocked.text = LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockFirstLocked;
                firstLockUnlocked.text = LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockUnlocked;
                secondLockLocked.text = LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockSecondLocked;
                secondLockUnlocked.text = LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockUnlocked;
                thirdLockLocked.text = LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockThirdLocked;
                thirdLockUnlocked.text = LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockUnlocked;
                
                //Second lock buttons
                GameObject secondLockObject = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Main Section"),"Inside"),"8 - Elevator"),"8 Stuff"),"PuzzleScreen (1)"),"Canvas");

                Text secondLockOpen =
                    GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(secondLockObject, "Button"), "Text"));
                Text secondLockAreYouSure = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(secondLockObject, "AreYouSure"), "Text"));

                Text secondLockWarning = GetTextfromGameObject(GetGameObjectChild(secondLockObject, "WarningText"));
                Text secondLockAsIf = GetTextfromGameObject(GetGameObjectChild(secondLockObject, "AsIfText"));

                secondLockOpen.text = LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockOpen;
                secondLockOpen.fontSize = 20;
                secondLockAreYouSure.text = LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockAreYouSure;
                secondLockAreYouSure.fontSize = 20;
                secondLockWarning.text =
                    LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockYes1 + "\n\n"
                    + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockYes2 + "\n\n"
                    + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockYes3 + "\n\n"
                    + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockYes4 + "\n\n"
                    + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockYes5 + "\n\n";
                secondLockWarning.fontSize = 18;
                secondLockAsIf.text =
                    LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockNo1 + "\n"
                    + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockNo1 + "\n"
                    + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockNo1 + "\n"
                    + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockNo1 + "\n\n"
                    + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_lockNo2 + "\n";
                
                
                
                PatchResultsScreen(levelname, "");
                
                PatchSecretText(primeSanctumChallengeStrings);
            }
        }
    }
}
