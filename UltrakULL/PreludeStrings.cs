using System;

using UnityEngine;
using UnityEngine.SceneManagement;
using UltrakULL.json;

namespace UltrakULL
{
    public static class PreludeStrings
    {

        private static BepInEx.Logging.ManualLogSource preludeStringsLogger = BepInEx.Logging.Logger.CreateLogSource("PreludeStrings");

        //0-1 - Into The Fire
        public static string level1(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            preludeStringsLogger.LogInfo(fullMessage);

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
            Console.WriteLine("Unimplemented 0-1 string \n Text: " + fullMessage);
            return "unimplemented 0-1 string";
        }
        //0-2 - The Meatgrinder
        public static string level2(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            preludeStringsLogger.LogInfo(fullMessage);

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
            return "unimplemented 0-2 string";
        }

        //0-3 - Double Down
        public static string level3(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            preludeStringsLogger.LogInfo(fullMessage);

            if (fullMessage.Contains("FIREPOWER"))
            {
                return LanguageManager.CurrentLanguage.prelude.prelude_third_needShotgun;
            }
            if (fullMessage.Contains("explosive"))
            {
                return LanguageManager.CurrentLanguage.prelude.prelude_third_shotgun1 + "'<color=orange>" + input + "</color>'" + LanguageManager.CurrentLanguage.prelude.prelude_third_shotgun2 + "\n" + LanguageManager.CurrentLanguage.prelude.prelude_third_shotgun3;
            }
            if (fullMessage.Contains("pierces"))
            {
                return LanguageManager.CurrentLanguage.prelude.prelude_third_shotgunPierce;
            }
            return "unimplemented 0-3 string";
        }

        //0-4 - A One-Machine Army
        //This level has no HUD box strings, apart from maybe the overheal.
        public static string level4(string message, string message2, string input)
        {
            return "unimplemented 0-4 string";
        }

        //0-5 - Cerberus
        //This level has no HUD box strings
        public static string level5(string message, string message2, string input)
        {
            return "unimplemented 0-5 string";
        }


        //0-S - Something Wicked
        public static string levelSecret(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            preludeStringsLogger.LogInfo(fullMessage);

            if (fullMessage.Contains("wicked"))
            {
                return LanguageManager.CurrentLanguage.prelude.prelude_secret_somethingWicked;
            }
            return "unimplemented 0-S string";
        }


        public static string getMessage(string message, string message2, string input)
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            string fullMessage = message + message2;

            switch (currentLevel)
            {
                case "Level 0-1":
                    {
                        return level1(message, message2, input);
                    }
                case "Level 0-2":
                    {
                        return level2(message, message2, input);
                    }
                case "Level 0-3":
                    {
                        return level3(message, message2, input);
                    }
                case "Level 0-4":
                    {
                        return level4(message, message2, input);
                    }
                case "Level 0-5":
                    {
                        return level5(message, message2, input);
                    }
                case "Level 0-S":
                    {
                        return levelSecret(message, message2, input);
                    }
                default: return "Unimplemented Prelude string";
            }

        }

        public static string getLevelChallenge(string currentLevel)
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

        public static string getLevelName()
        {
            string currentLevel = SceneManager.GetActiveScene().name;

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
