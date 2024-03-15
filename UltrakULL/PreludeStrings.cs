using System;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class PreludeStrings
    {
        //0-1 - Into The Fire
        private static string Level1(string message, string message2, string input)
        {
            string fullMessage = message + message2;

            if (fullMessage.Contains("PIPE CLIP"))
            {
                return (LanguageManager.CurrentLanguage.prelude.prelude_first_pipeClip);
            }

            if (fullMessage.Contains("REVOLVER"))
            {
                return (LanguageManager.CurrentLanguage.prelude.prelude_first_revolverPierce1 + " '<color=orange>" + input + "</color>'" + LanguageManager.CurrentLanguage.prelude.prelude_first_revolverPierce2);
            }
            if (fullMessage.Contains("DEFLECT"))
            {
                return (LanguageManager.CurrentLanguage.prelude.prelude_first_parry);
            }
            if (fullMessage.Contains("HARD DAMAGE"))
            {
                return (LanguageManager.CurrentLanguage.prelude.prelude_first_hardDamage1 + "\n"
                + LanguageManager.CurrentLanguage.prelude.prelude_first_hardDamage2);
            }
            if (fullMessage.Contains("GROUND SLAM"))
            {
                return (LanguageManager.CurrentLanguage.prelude.prelude_first_groundSlam1 + "'<color=orange>" + input + "</color>'" + LanguageManager.CurrentLanguage.prelude.prelude_first_groundSlam2);
            }
            return "Unimplemented 0-1 string";
        }
        //0-2 - The Meatgrinder
        private static string Level2(string message, string message2, string input)
        {
            string fullMessage = message + message2;

            if (fullMessage.Contains("POINTS"))
            {
                return LanguageManager.CurrentLanguage.prelude.prelude_second_shop;
            }
            if (fullMessage.Contains("UPDOOR"))
            {
                return (LanguageManager.CurrentLanguage.prelude.prelude_second_doorClip);
            }
            if (fullMessage.Contains("EQUIPPED"))
            {
                return (LanguageManager.CurrentLanguage.prelude.prelude_second_changeEquipped + "'<color=orange>" + input + "</color>.'");
            }
            return "Unimplemented 0-2 string";
        }

        //0-3 - Double Down
        private static string Level3(string message, string message2, string input)
        {
            string fullMessage = message + message2;

            if (fullMessage.Contains("FIREPOWER"))
            {
                return "<color=red>" + LanguageManager.CurrentLanguage.prelude.prelude_third_needShotgun + "</color>";
            }
            if (fullMessage.Contains("explosive"))
            {
                return LanguageManager.CurrentLanguage.prelude.prelude_third_shotgun1 + "'<color=orange>" + input + "</color>'" + LanguageManager.CurrentLanguage.prelude.prelude_third_shotgun2 + "\n" + LanguageManager.CurrentLanguage.prelude.prelude_third_shotgun3;
            }
            if (fullMessage.Contains("pierces"))
            {
                return LanguageManager.CurrentLanguage.prelude.prelude_third_shotgunPierce;
            }
            return "Unimplemented 0-3 string";
        }

        //0-4 - A One-Machine Army
        //This level has no HUD box strings, apart from maybe the overheal.
        private static string Level4()
        {
            return "Unimplemented 0-4 string";
        }

        //0-5 - Cerberus
        //This level has no HUD box strings
        private static string Level5()
        {
            return "Unimplemented 0-5 string";
        }


        //0-S - Something Wicked
        private static string LevelSecret(string message, string message2)
        {
            string fullMessage = message + message2;

            if (fullMessage.Contains("wicked"))
            {
                return LanguageManager.CurrentLanguage.prelude.prelude_secret_somethingWicked;
            }
            return "unimplemented 0-S string";
        }


        public static string GetMessage(string message, string message2, string input)
        {
            string currentLevel = GetCurrentSceneName();
            switch (currentLevel)
            {
                case "Level 0-1":
                    {
                        return Level1(message, message2, input);
                    }
                case "Level 0-2":
                    {
                        return Level2(message, message2, input);
                    }
                case "Level 0-3":
                    {
                        return Level3(message, message2, input);
                    }
                case "Level 0-4":
                    {
                        return Level4();
                    }
                case "Level 0-5":
                    {
                        return Level5();
                    }
                case "Level 0-S":
                    {
                        return LevelSecret(message, message2);
                    }
                default:
                {
                    Console.WriteLine("Unknown Prelude string: \n" + message + message2);
                    return message + message2;
                }
                    
            }

        }

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
