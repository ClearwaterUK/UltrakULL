using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Act2Challenges
    {
        public static string GetLevelChallenge(string currentLevel)
        {
            switch (currentLevel)
            {
                case "Level 4-1": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_greedFirst; }
                case "Level 4-2": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_greedSecond; }
                case "Level 4-3": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_greedThird; }
                case "Level 4-4": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_greedFourth; }

                case "Level 5-1": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_wrathFirst; }
                case "Level 5-2": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_wrathSecond; }
                case "Level 5-3": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_wrathThird; }
                case "Level 5-4": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_wrathFourth; }

                case "Level 6-1": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_heresyFirst; }
                case "Level 6-2": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_heresySecond; }

                default: { return "Unknown challenge description"; }
            }
        }

        public static string GetLevelName()
        {
            string currentLevel = GetCurrentSceneName();

            switch (currentLevel)
            {
                case "Level 4-1": { return "4-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_greedFirst; }
                case "Level 4-2": { return "4-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_greedSecond; }
                case "Level 4-3": { return "4-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_greedThird; }
                case "Level 4-4": { return "4-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_greedFourth; }

                case "Level 5-1": { return "5-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathFirst; }
                case "Level 5-2": { return "5-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathSecond; }
                case "Level 5-3": { return "5-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathThird; }
                case "Level 5-4": { return "5-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathFourth; }

                case "Level 6-1": { return "6-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_heresyFirst; }
                case "Level 6-2": { return "6-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_heresySecond; }

                default: { return "Unknown level name"; }
            }
        }
    }
}
