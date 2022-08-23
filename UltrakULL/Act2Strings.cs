using BepInEx;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UltrakULL.json;

namespace UltrakULL
{
    class Act2Strings
    {
        BepInEx.Logging.ManualLogSource a2StringsLogger = BepInEx.Logging.Logger.CreateLogSource("Act 2 Strings");

        public Act2Strings()
        {

        }

        public string level41(string message, string message2, string input)
        {
            return "Unknown 4-1 string";
        }

        public string level42(string message, string message2, string input, JsonParser language)
        {
            string fullMessage = message + message2;
            a2StringsLogger.LogInfo(fullMessage);
            if (fullMessage.Contains("BLEED"))
            {
                return (language.currentLanguage.act2.act2_greedSecond_sand);
            }
            return "Unknown 4-2 string";
        }

        public string level43(string message, string message2, string input, JsonParser language)
        {
            string fullMessage = message + message2;
            a2StringsLogger.LogInfo(fullMessage);
            if (fullMessage.Contains("wicked"))
            {
                return (language.currentLanguage.act2.act2_greedThird_troll1);
            }
            if (fullMessage.Contains("kidding"))
            {
                return (language.currentLanguage.act2.act2_greedThird_troll2);
            }
            return "Unknown 4-3 string";
        }

        public string level44(string message, string message2, string input, JsonParser language)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("You're"))
            {
                return (language.currentLanguage.act2.act2_greedFourth_v2);
            }
            if (fullMessage.Contains("Hold"))
            {
                return language.currentLanguage.act2.act2_greedFourth_whiplash2 + " <color=orange>" + input + "</color> " + language.currentLanguage.act2.act2_greedFourth_whiplash3;
            }
            if (fullMessage.Contains("HEAVY"))
            {
                return language.currentLanguage.act2.act2_greedFourth_whiplash3;
            }
            if (fullMessage.Contains("HARD DAMAGE"))
            {
                return language.currentLanguage.act2.act2_greedFourth_whiplashHardDamage1 + "\n"
                    + language.currentLanguage.act2.act2_greedFourth_whiplashHardDamage2;
            }
            return "Unknown 4-4 string";
        }

        public string level4secret(string message, string message2, string input, JsonParser language)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("HOLD"))
            {
                return (language.currentLanguage.act2.act2_greedSecret_holdToJump);
            }

            return "Unknown 4-S string";
        }

        public string getMessage(string message, string message2, string input,JsonParser language)
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            string fullMessage = message + message2;

            if(fullMessage.Contains("opens"))
            {
                return (language.currentLanguage.act2.act2_greed_secretDoor);
            }

            switch (currentLevel)
            {
                case "Level 4-1":
                    {
                        return this.level41(message, message2, input);
                    }
                case "Level 4-2":
                    {
                        return this.level42(message, message2, input,language);
                    }
                case "Level 4-3":
                    {
                        return this.level43(message, message2, input,language);
                    }
                case "Level 4-4":
                    {
                        return this.level44(message, message2, input,language);
                    }
                case "Level 4-S":
                    {
                        return this.level4secret(message, message2, input, language);
                    }
                default: return "Unimplemented Act 2 string";
            }

        }

        public string getLevelChallenge(string currentLevel, JsonParser language)
        {
            switch (currentLevel)
            {
                case "Level 4-1": { return language.currentLanguage.levelChallenges.challenges_greedFirst; }
                case "Level 4-2": { return language.currentLanguage.levelChallenges.challenges_greedSecond; }
                case "Level 4-3": { return language.currentLanguage.levelChallenges.challenges_greedThird; }
                case "Level 4-4": { return language.currentLanguage.levelChallenges.challenges_greedFourth; }

                default: { return "Unknown challenge description"; }
            }
        }

        public string getLevelName(JsonParser language)
        {
            string currentLevel = SceneManager.GetActiveScene().name;

            switch (currentLevel)
            {
                case "Level 4-1": { return "4-1 - " + language.currentLanguage.levelNames.levelName_greedFirst; }
                case "Level 4-2": { return "4-2 - " + language.currentLanguage.levelNames.levelName_greedSecond; }
                case "Level 4-3": { return "4-3 - " + language.currentLanguage.levelNames.levelName_greedThird; }
                case "Level 4-4": { return "4-4 - " + language.currentLanguage.levelNames.levelName_greedFourth; }
        
                default: { return "Unknown level name"; }
            }
        }

    }



}
