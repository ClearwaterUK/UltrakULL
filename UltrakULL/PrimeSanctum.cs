using System.Collections.Generic;
using Antlr4.StringTemplate;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public class PrimeSanctum
    {
        private const string FirstLockYes = "SANCTUM_SECOND_LOCK_YES";
        private const string FirstLockNo = "SANCTUM_SECOND_LOCK_NO";
        
        private static readonly Dictionary<string, string> TemplateNames = new Dictionary<string, string>
        {
            { "Level P-1", "SANCTUM_FIRST" },
            { "Level P-2", "SANCTUM_SECOND" }
        };
        
        private TemplateGroup templates = new TemplateGroupString(Resources.PrimeSanctums);
        private Prime sanctum = LanguageManager.CurrentLanguage.primeSanctum;
        
        public PrimeSanctum()
        {
            templates.EnableCache = false;
            var currentLevel = GetCurrentSceneName();
            var levelName = GetLevelName(currentLevel);
            Text secretTextObject = null;

            switch (currentLevel)
            {
                case "Level P-1":
                {
                    secretTextObject = GetObject(
                            "3 - Fuckatorium/3 Stuff/End/FinalRoom Prime/Testament Shop/Canvas/Border/TipBox/Panel/Scroll View/Viewport/Content/Text (1)")
                        .GetComponent<Text>();
                    break;
                }
                case "Level P-2":
                {
                    //First lock buttons
                    var lockObject = GetObject("Main Section/Inside/8 - Elevator/8 Stuff/PuzzleScreen/Canvas");

                    var firstLockLocked = GetText(lockObject, "Button/Text (Locked)");
                    var firstLockUnlocked = GetText(lockObject, "Button/Text (Unlocked)");
                    var secondLockLocked = GetText(lockObject, "Button (1)/Text (Locked)");
                    var secondLockUnlocked = GetText(lockObject, "Button (1)/Text (Unlocked)");
                    var thirdLockLocked = GetText(lockObject, "Button (2)/Text (Locked)");
                    var thirdLockUnlocked = GetText(lockObject, "Button (2)/Text (Unlocked)");

                    firstLockLocked.text = sanctum.primeSanctum_second_lockFirstLocked;
                    firstLockUnlocked.text = sanctum.primeSanctum_second_lockUnlocked;
                    secondLockLocked.text = sanctum.primeSanctum_second_lockSecondLocked;
                    secondLockUnlocked.text = sanctum.primeSanctum_second_lockUnlocked;
                    thirdLockLocked.text = sanctum.primeSanctum_second_lockThirdLocked;
                    thirdLockUnlocked.text = sanctum.primeSanctum_second_lockUnlocked;
                
                    var secondLockObject =
                        GetObject("Main Section/Inside/8 - Elevator/8 Stuff/PuzzleScreen (1)/Canvas");

                    var secondLockOpen = GetText(secondLockObject, "Button/Text");
                    var secondLockAreYouSure = GetText(secondLockObject, "AreYouSure/Text");

                    var secondLockWarning = GetText(secondLockObject, "WarningText");
                    var secondLockAsIf = GetText(secondLockObject, "AsIfText");
                
                    secretTextObject = GetObject("Main Section/9 - Boss Arena/Boss Stuff/Outro/FinalRoom Prime Variant/Testament Shop/Canvas/Border/TipBox/Panel/Scroll View/Viewport/Content/Text (1)")
                        .GetComponent<Text>();
                    
                    secondLockOpen.text = sanctum.primeSanctum_second_lockOpen;
                    secondLockOpen.fontSize = 20;
                    secondLockAreYouSure.text = sanctum.primeSanctum_second_lockAreYouSure;
                    secondLockAreYouSure.fontSize = 20;
                    secondLockWarning.text = templates
                        .GetInstanceOf(FirstLockYes)
                        .Add("sanctum", sanctum)
                        .Render();
                    
                    secondLockWarning.fontSize = 18;
                    secondLockAsIf.text = templates
                        .GetInstanceOf(FirstLockNo)
                        .Add("sanctum", sanctum)
                        .Render();
                    break;
                }
            }

            PatchResultsScreen(levelName, "");
            if (secretTextObject == null)
                return;
            
            secretTextObject.fontSize = 18;
            secretTextObject.text = GetSecretText(currentLevel);
        }

        private static Text GetText(GameObject rootObject, string path)
        {
            return rootObject.transform.Find(path).GetComponent<Text>();
        }
        
        private static string GetLevelName(string currentLevel)
        {
            switch (currentLevel)
            {
                case "Level P-1": { return "P-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_primeFirst; }
                case "Level P-2": { return "P-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_primeSecond; }

                default: { return "Unknown level name"; }
            }
        }

        private string GetSecretText(string currentLevel)
        {
            if (!TemplateNames.ContainsKey(currentLevel))
                return string.Empty;

            return templates.GetInstanceOf(TemplateNames[currentLevel])
                .Add("sanctum", sanctum)
                .Render();
        }
    }
}
