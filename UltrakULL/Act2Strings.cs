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
    public static class Act2Strings
    {
        private static BepInEx.Logging.ManualLogSource a2StringsLogger = BepInEx.Logging.Logger.CreateLogSource("Act 2 Strings");

        public static string level41(string message, string message2, string input)
        {
            return "Unknown 4-1 string";
        }

        public static string level42(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            a2StringsLogger.LogInfo(fullMessage);
            if (fullMessage.Contains("BLEED"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_greedSecond_sand);
            }
            return "Unknown 4-2 string";
        }

        public static string level43(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            a2StringsLogger.LogInfo(fullMessage);
            if (fullMessage.Contains("wicked"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_greedThird_troll1);
            }
            if (fullMessage.Contains("kidding"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_greedThird_troll2);
            }
            if (fullMessage.Contains("TOMB"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_greedThird_tombOfKings);
            }
            return "Unknown 4-3 string";
        }

        public static string level44(string message, string message2, string input)
        {
            string fullMessage = message + message2;

            if (fullMessage.Contains("ALTERNATE"))
            {
                return LanguageManager.CurrentLanguage.act1.act1_limboFourth_alternateRevolver;
            }

            if (fullMessage.Contains("You're"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_greedFourth_v2);
            }
            if (fullMessage.Contains("Hold"))
            {
                return LanguageManager.CurrentLanguage.act2.act2_greedFourth_whiplash1 + " <color=orange>" + input + "</color> " + LanguageManager.CurrentLanguage.act2.act2_greedFourth_whiplash2;
            }
            if (fullMessage.Contains("HEAVY"))
            {
                return LanguageManager.CurrentLanguage.act2.act2_greedFourth_whiplash3;
            }
            if (fullMessage.Contains("HARD DAMAGE"))
            {
                return LanguageManager.CurrentLanguage.act2.act2_greedFourth_whiplashHardDamage1 + "\n"
                    + LanguageManager.CurrentLanguage.act2.act2_greedFourth_whiplashHardDamage2;
            }
            return "Unknown 4-4 string";
        }

        public static string level4secret(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("HOLD"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_greedSecret_holdToJump1 + "<color=orange> " + input + " </color>" + LanguageManager.CurrentLanguage.act2.act2_greedSecret_holdToJump2);
            }

            return (LanguageManager.CurrentLanguage.act2.act2_greedSecret_holdToJump1 + "<color=orange> " + input + " </color>" + LanguageManager.CurrentLanguage.act2.act2_greedSecret_holdToJump2);
        }

        public static string level51(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("HOOKPOINT"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_wrathFirst_slingshot);
            }
            if (fullMessage.Contains("WHIPLASH"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_wrathFirst_whiplashUnderwater);
            }
            if (fullMessage.Contains("SENTRIES"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_wrathFirst_sentry);
            }
            if (fullMessage.Contains("drained"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_wrathFirst_waterDrained);
            }

            return "Unknown 5-1 string";
        }

        public static string level52(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("JAKITO"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_wrathSecond_jakito1);
            }
            if (fullMessage.Contains("NO"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_wrathSecond_jakito2);
            }
            if (fullMessage.Contains("THANK"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_wrathSecond_jakito3);
            }
            if (fullMessage.Contains("Hark"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_wrathSecond_neptune);
            }
            if (fullMessage.Contains("IDOL"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_wrathSecond_idol);
            }
            return "Unknown 5-2 string";
        }

        public static string level53(string message, string message2, string input)
        {
            string fullMessage = message + message2;

            if (fullMessage.Contains("Indirect"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_wrathThird_rocketLauncher);
            }
            if (fullMessage.Contains("FALLING"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_wrathThird_rocketLauncherMidair);
            }
            if (fullMessage.Contains("Soldiers"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_wrathThird_soldierBlock);
            }
            if (fullMessage.Contains("Hank"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_wrathThird_hank);
            }

            return "Unknown 5-3 string";
        }

        public static string level54(string message, string message2, string input)
        {
            string fullMessage = message + message2;

            return "Unknown 5-4 string";
        }

        public static string level5secret(string message, string message2, string input)
        {
            return "Unknown 5-S string";
        }

        public static string level61(string message, string message2, string input)
        {
            return "Unknown 6-1 string";
        }

        public static string level62(string message, string message2, string input)
        {
            return "Unknown 6-2 string";
        }

        public static string getMessage(string message, string message2, string input)
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            string fullMessage = message + message2;

            if(fullMessage.Contains("opens"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_greed_secretDoor);
            }
            if (fullMessage.Contains("YOU'RE"))
            {
                return (LanguageManager.CurrentLanguage.act2.act2_secretNotReady);
            }

            switch (currentLevel)
            {
                case "Level 4-1":
                    {
                        return level41(message, message2, input);
                    }
                case "Level 4-2":
                    {
                        return level42(message, message2, input);
                    }
                case "Level 4-3":
                    {
                        return level43(message, message2, input);
                    }
                case "Level 4-4":
                    {
                        return level44(message, message2, input);
                    }
                case "Level 4-S":
                    {
                        return level4secret(message, message2, input);
                    }
                case "Level 5-1":
                    {
                        return level51(message, message2, input);
                    }
                case "Level 5-2":
                    {
                        return level52(message, message2, input);
                    }
                case "Level 5-3":
                    {
                        return level53(message, message2, input);
                    }
                case "Level 5-4":
                    {
                        return level54(message, message2, input);
                    }
                case "Level 5-S":
                    {
                        return level5secret(message, message2, input);
                    }
                case "Level 6-1":
                    {
                        return level61(message, message2, input);
                    }
                case "Level 6-2":
                    {
                        return level62(message, message2, input);
                    }
                default: return "Unimplemented Act 2 string";
            }

        }

        public static string getLevelChallenge(string currentLevel)
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

        public static string getLevelName()
        {
            string currentLevel = SceneManager.GetActiveScene().name;

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
