using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class PreludeChallenges
    {
        public static string GetLevelChallenge(string currentLevel)
        {
            switch (currentLevel)
            {
                case "Level 0-1": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_preludeFirst; }
                case "Level 0-2": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_preludeSecond; }
                case "Level 0-3": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_preludeThird; }
                case "Level 0-4": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_preludeFourth; }
                case "Level 0-5": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_preludeFifth; }

                default: { return "Unknown challenge description"; }
            }
        }

        public static string GetLevelName()
        {
            string currentLevel = GetCurrentSceneName();

            switch (currentLevel)
            {
                case "Level 0-1": { return "0-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFirst; }
                case "Level 0-2": { return "0-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeSecond; }
                case "Level 0-3": { return "0-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeThird; }
                case "Level 0-4": { return "0-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFourth; }
                case "Level 0-5": { return "0-5 - " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFifth; }

                default: { return "Unknown level name"; }
            }
        }
    }
}
