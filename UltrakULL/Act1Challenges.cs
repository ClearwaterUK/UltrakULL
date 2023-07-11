using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Act1Challenges
    {
        public static string GetLevelChallenge(string currentLevel)
        {
            switch (currentLevel)
            {
                case "Level 1-1": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_limboFirst; }
                case "Level 1-2": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_limboSecond; }
                case "Level 1-3": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_limboThird; }
                case "Level 1-4": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_limboFourth; }

                case "Level 2-1": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_lustFirst; }
                case "Level 2-2": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_lustSecond; }
                case "Level 2-3": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_lustThird; }
                case "Level 2-4": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_lustFourth; }

                case "Level 3-1": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_gluttonyFirst; }
                case "Level 3-2": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_gluttonySecond; }

                default: { return "Unknown challenge description"; }
            }
        }

        public static string GetLevelName()
        {
            string currentLevel = GetCurrentSceneName();

            switch (currentLevel)
            {
                case "Level 1-1": { return "1-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_limboFirst; }
                case "Level 1-2": { return "1-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_limboSecond; }
                case "Level 1-3": { return "1-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_limboThird; }
                case "Level 1-4": { return "1-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_limboFourth; }
                case "Level 1-S": { return "1-S - " + LanguageManager.CurrentLanguage.levelNames.levelName_limboSecret; }

                case "Level 2-1": { return "2-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_lustFirst; }
                case "Level 2-2": { return "2-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_lustSecond; }
                case "Level 2-3": { return "2-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_lustThird; }
                case "Level 2-4": { return "2-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_lustFourth; }
                case "Level 2-S": { return "2-S - " + LanguageManager.CurrentLanguage.levelNames.levelName_lustSecret; }

                case "Level 3-1": { return "3-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_gluttonyFirst; }
                case "Level 3-2": { return "3-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_gluttonySecond; }

                default: { return "Unknown level name"; }
            }
        }
    }
}
