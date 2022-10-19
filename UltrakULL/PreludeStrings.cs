using System;

using UnityEngine;
using UnityEngine.SceneManagement;
using UltrakULL.json;

namespace UltrakULL
{
    class PreludeStrings : MonoBehaviour
    {

        BepInEx.Logging.ManualLogSource preludeStringsLogger = BepInEx.Logging.Logger.CreateLogSource("PreludeStrings");

        //0-1 - Into The Fire
        public string level1(string message, string message2, string input, JsonParser language)
        {
            string fullMessage = message + message2;
            preludeStringsLogger.LogInfo(fullMessage);
            if (fullMessage.Contains("REVOLVER"))
            {
                return (language.currentLanguage.prelude.prelude_first_revolverPierce1 + " '<color=orange>" + input + "</color>'" + language.currentLanguage.prelude.prelude_first_revolverPierce2);
            }
            if (fullMessage.Contains("DEFLECT"))
            {
                return (language.currentLanguage.prelude.prelude_first_parry);
            }
            if (fullMessage.Contains("HARD DAMAGE"))
            {
                return (language.currentLanguage.prelude.prelude_first_hardDamage1 + "\n"
                + language.currentLanguage.prelude.prelude_first_hardDamage2);
            }
            if (fullMessage.Contains("GROUND SLAM"))
            {
                return (language.currentLanguage.prelude.prelude_first_groundSlam1 + "'<color=orange>" + input + "</color>'" + language.currentLanguage.prelude.prelude_first_groundSlam2);
            }
            Console.WriteLine("Unimplemented 0-1 string \n Text: " + fullMessage);
            return "unimplemented 0-1 string";
        }
        //0-2 - The Meatgrinder
        public string level2(string message, string message2, string input, JsonParser language)
        {
            string fullMessage = message + message2;
            preludeStringsLogger.LogInfo(fullMessage);

            if (fullMessage.Contains("POINTS"))
            {
                return language.currentLanguage.prelude.prelude_second_shop;
            }
            if (fullMessage.Contains("EQUIPPED"))
            {
                return (language.currentLanguage.prelude.prelude_second_changeEquipped + "'<color=orange>" + input + "</color>.'");
            }
            return "unimplemented 0-2 string";
        }

        //0-3 - Double Down
        public string level3(string message, string message2, string input, JsonParser language)
        {
            string fullMessage = message + message2;
            preludeStringsLogger.LogInfo(fullMessage);

            if (fullMessage.Contains("FIREPOWER"))
            {
                return language.currentLanguage.prelude.prelude_third_needShotgun;
            }
            if (fullMessage.Contains("explosive"))
            {
                return language.currentLanguage.prelude.prelude_third_shotgun1 + "'<color=orange>" + input + "</color>'" + language.currentLanguage.prelude.prelude_third_shotgun2 + "\n" + language.currentLanguage.prelude.prelude_third_shotgun3;
            }
            if (fullMessage.Contains("pierces"))
            {
                return language.currentLanguage.prelude.prelude_third_shotgunPierce;
            }
            return "unimplemented 0-3 string";
        }

        //0-4 - A One-Machine Army
        //This level has no HUD box strings, apart from maybe the overheal.
        public string level4(string message, string message2, string input)
        {
            return "unimplemented 0-4 string";
        }

        //0-5 - Cerberus
        //This level has no HUD box strings
        public string level5(string message, string message2, string input)
        {
            return "unimplemented 0-5 string";
        }


        //0-S - Something Wicked
        public string levelSecret(string message, string message2, string input, JsonParser language)
        {
            string fullMessage = message + message2;
            preludeStringsLogger.LogInfo(fullMessage);

            if (fullMessage.Contains("wicked"))
            {
                return language.currentLanguage.prelude.prelude_secret_somethingWicked;
            }
            return "unimplemented 0-S string";
        }



        public string getMessage(string message, string message2, string input,JsonParser language)
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            string fullMessage = message + message2;

            switch (currentLevel)
            {
                case "Level 0-1":
                    {
                        return this.level1(message, message2, input, language);
                    }
                case "Level 0-2":
                    {
                        return this.level2(message, message2, input, language);
                    }
                case "Level 0-3":
                    {
                        return this.level3(message, message2, input, language);
                    }
                case "Level 0-4":
                    {
                        return this.level4(message, message2, input);
                    }
                case "Level 0-5":
                    {
                        return this.level5(message, message2, input);
                    }
                case "Level 0-S":
                    {
                        return this.levelSecret(message, message2, input, language);
                    }
                default: return "Unimplemented Prelude string";
            }

        }

        public string getLevelChallenge(string currentLevel, JsonParser language)
        {

            switch (currentLevel)
            {
                case "Level 0-1": { return language.currentLanguage.levelChallenges.challenges_preludeFirst; }
                case "Level 0-2": { return language.currentLanguage.levelChallenges.challenges_preludeSecond; }
                case "Level 0-3": { return language.currentLanguage.levelChallenges.challenges_preludeThird; }
                case "Level 0-4": { return language.currentLanguage.levelChallenges.challenges_preludeFourth; }
                case "Level 0-5": { return language.currentLanguage.levelChallenges.challenges_preludeFifth; }

                default: { return "Unknown challenge description"; }
            }
        }


        public string getLevelName(JsonParser language)
        {
            string currentLevel = SceneManager.GetActiveScene().name;

            switch (currentLevel)
            {
                case "Level 0-1": { return "0-1 - " + language.currentLanguage.levelNames.levelName_preludeFirst; }
                case "Level 0-2": { return "0-2 - " + language.currentLanguage.levelNames.levelName_preludeSecond; }
                case "Level 0-3": { return "0-3 - " + language.currentLanguage.levelNames.levelName_preludeThird; }
                case "Level 0-4": { return "0-4 - " + language.currentLanguage.levelNames.levelName_preludeFourth; }
                case "Level 0-5": { return "0-5 - " + language.currentLanguage.levelNames.levelName_preludeFifth; }

                default: { return "Unknown level name"; }
            }
        }


    }
}
