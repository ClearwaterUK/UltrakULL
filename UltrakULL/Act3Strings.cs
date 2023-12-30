using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Act3Strings
    {
        public static string Level71(string message, string message2)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("A door opens."))
            {
                return (LanguageManager.CurrentLanguage.act3.act3_violenceFirst_doorOpens);
            }
            return "Unknown 7-1 string";
        }
        
        public static string Level72(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("Swap arms with"))
            {
                return LanguageManager.CurrentLanguage.act3.act3_violenceSecond_guttermanTutorial + " '<color=orange>" + input + "</color>'";
            }
            if (fullMessage.Contains("BIGGER BOOM"))
            {
                return ("<color=red>" + LanguageManager.CurrentLanguage.act3.act3_violenceSecond_biggerBoom + "</color>");
            }
            return "Unknown 7-2 string";
        }
        
        public static string Level73(string message, string message2)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("F E E D"))
            {
                return ("<color=red>" + LanguageManager.CurrentLanguage.act3.act3_violenceThird_feedIt + "</color>");
            }
            return "Unknown 7-3 string";
        }
        
        public static string Level74()
        {
            return "Unknown 7-4 string";
        }
        
        public static string Level7Secret()
        {
            return "Unknown 7-S string";
        }
        
        public static string Level81()
        {
            return "Unknown 8-1 string";
        }

        public static string Level82()
        {
            return "Unknown 8-2 string";
        }

        public static string Level83()
        {
            return "Unknown 8-3 string";
        }
        
        public static string Level84()
        {
            return "Unknown 8-4 string";
        }
        
        public static string Level8Secret()
        {
            return "Unknown 8-S string";
        }
        
        public static string Level91()
        {
            return "Unknown 9-1 string";
        }
        
        public static string Level92()
        {
            return "Unknown 9-2 string";
        }

        public static string GetMessage(string message, string message2, string input)
        {
            string currentLevel = GetCurrentSceneName();
            string fullMessage = message + message2;
            
            switch (currentLevel)
            {
                case "Level 7-1":
                    {
                        return Level71();
                    }
                case "Level 7-2":
                    {
                        return Level72();
                    }
                case "Level 7-3":
                    {
                        return Level73();
                    }
                case "Level 7-4":
                    {
                        return Level74();
                    }
                case "Level 7-S":
                    {
                        return Level7Secret();
                    }
                case "Level 8-1":
                    {
                        return Level81();
                    }
                case "Level 8-2":
                    {
                        return Level82();
                    }
                case "Level 8-3":
                    {
                        return Level83();
                    }
                case "Level 8-4":
                    {
                        return Level84();
                    }
                case "Level 8-S":
                    {
                        return Level8Secret();
                    }
                case "Level 9-1":
                    {
                        return Level91();
                    }
                case "Level 9-2":
                    {
                        return Level92();
                    }
                default: return "Unimplemented Act 3 string";
            }
        }

        public static string GetLevelChallenge(string currentLevel)
        {
            switch (currentLevel)
            {
                case "Level 7-1": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_violenceFirst; }
                case "Level 7-2": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_violenceSecond; }
                case "Level 7-3": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_violenceThird; }
                case "Level 7-4": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_violenceFourth; }

                case "Level 8-1": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_fraudFirst; }
                case "Level 8-2": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_fraudSecond; }
                case "Level 8-3": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_fraudThird; }
                case "Level 8-4": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_fraudFourth; }

                case "Level 9-1": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_treacheryFirst; }
                case "Level 9-2": { return LanguageManager.CurrentLanguage.levelChallenges.challenges_treacherySecond; }

                default: { return "Unknown challenge description"; }
            }
        }

        public static string GetLevelName()
        {
            string currentLevel = GetCurrentSceneName();

            switch (currentLevel)
            {
                case "Level 7-1": { return "7-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceFirst; }
                case "Level 7-2": { return "7-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceSecond; }
                case "Level 7-3": { return "7-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceThird; }
                case "Level 7-4": { return "7-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceFourth; }

                case "Level 8-1": { return "8-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudFirst; }
                case "Level 8-2": { return "8-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudSecond; }
                case "Level 8-3": { return "8-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudThird; }
                case "Level 8-4": { return "8-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudFourth; }

                case "Level 9-1": { return "9-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_treacheryFirst; }
                case "Level 9-2": { return "9-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_treacherySecond; }

                default: { return "Unknown level name"; }
            }
        }
    }
}
