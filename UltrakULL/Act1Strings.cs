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
    class Act1Strings : MonoBehaviour
    {
        BepInEx.Logging.ManualLogSource a1StringsLogger = BepInEx.Logging.Logger.CreateLogSource("Act 1 Strings");

        //1-1 - Heart Of The Sunrise
        public string level11(string message, string message2, string input,JsonParser language)
        {
            string fullMessage = message + message2;
            a1StringsLogger.LogInfo(fullMessage);
            if (fullMessage.Contains("ITEMS"))
            { 
                return language.currentLanguage.act1.act1_limboFirst_items1 + " '<color=orange>" + input + "'</color> " + language.currentLanguage.act1.act1_limboFirst_items2;
            }
            if (fullMessage.Contains("NAILGUN"))
            {
                return language.currentLanguage.act1.act1_limboFirst_nailgun1 + " '<color=orange>" + input + "'</color> " + language.currentLanguage.act1.act1_limboFirst_nailgun2 + "\n" + language.currentLanguage.act1.act1_limboFirst_nailgun3;
            }
            return message + message2 + input;
        }
        //1-2 - The Burning World
        public string level12(string message, string message2, string input,JsonParser language)
        {
            string fullMessage = message + message2;
            a1StringsLogger.LogInfo(fullMessage);
            if (fullMessage.Contains("BLUE"))
            {
                return language.currentLanguage.act1.act1_limboSecond_blueAttack;
            }
            return "Unknown 1-2 string";
        }
        //1-3 - Hall Of Sacred Remains
        public string level13(string message, string message2, string input, JsonParser language)
        {
            string fullMessage = message + message2;
            a1StringsLogger.LogInfo(fullMessage);
            if (fullMessage.Contains("SPLIT"))
            {
                return language.currentLanguage.act1.act1_limboThird_splitDoor1 + "\n" + language.currentLanguage.act1.act1_limboThird_splitDoor2;
            }
            return "Unknown 1-3 string";
        }
            //1-4 - Clair De Lune
            public string level14(string message, string message2, string input, JsonParser language)
            {
            string fullMessage = message + message2;
            a1StringsLogger.LogInfo(fullMessage);
            if (fullMessage.Contains("PICK"))
            {
                return language.currentLanguage.act1.act1_limboFourth_book;
            }
            if (fullMessage.Contains("Hank"))
            {
                return language.currentLanguage.act1.act1_limboFourth_hank1 + "\n" + language.currentLanguage.act1.act1_limboFourth_hank2;
            }
            if (fullMessage.Contains("ALTERNATE"))
            {
                return language.currentLanguage.act1.act1_limboFourth_alternateRevolver;
            }
            if (fullMessage.Contains("EQUIPPED"))
            {
                return language.currentLanguage.act1.act1_limboFourth_newArm + " '<color=orange>" + input + "'</color>.";
            }

            return "Unknown 1-4 string";
        }
        //1-S - The Witless
        //This level has no HUD box strings.
        public string level1Secret(string message, string message2, string input)
        {
            return "Unknown 1-S string";
        }
        //2-1 - Bridgeburner
        public string level21(string message, string message2, string input, JsonParser language)
        {
            string fullMessage = message + message2;
            a1StringsLogger.LogInfo(fullMessage);
            if (fullMessage.Contains("KNUCKLE"))
            {
                return (language.currentLanguage.act1.act1_lustFirst_knuckleblaster1 + " '<color=orange>"+input+"</color>' " + language.currentLanguage.act1.act1_lustFirst_knuckleblaster2);
            }
            if (fullMessage.Contains("DASH"))
            {
                return (language.currentLanguage.act1.act1_lustFirst_dashJump);
            }

            return "Unknown 2-1 string";
        }
        //2-2 - Death at 20,000 Volts
        public string level22(string message, string message2, string input, JsonParser language)
        {
            string fullMessage = message + message2;
            a1StringsLogger.LogInfo(fullMessage);
            if (fullMessage.Contains("FEEDBACKER"))
            {
                return language.currentLanguage.act1.act1_lustSecond_feedbacker1 + "\n" + language.currentLanguage.act1.act1_lustSecond_feedbacker2 + " '<color=orange>" + input + "</color>'.";
            }
            if (fullMessage.Contains("RAILCANNON"))
            {
                return (language.currentLanguage.act1.act1_lustSecond_railcannon);
            }

            return ("Unknown 2-2 string");
        }
        //2-3 - Sheer Heart Attack
        public string level23(string message, string message2, string input, JsonParser language)
        {
            string fullMessage = message + message2;
            a1StringsLogger.LogInfo(fullMessage);
            if (fullMessage.Contains("water"))
            {
                return (language.currentLanguage.act1.act1_lustThird_water);
            }
            return "Unknown 2-3 string";
        }
        //2-4 - Court Of The Corpse King
        //This level has no HUD box strings.
        public string level24(string message, string message2, string input)
        {
            return "Unknown 2-4 string";
        }
        //2-S
        public string level2Secret(string message, string message2, string input)
        {
            return "Unknown 2-S string";
        }
        //3-1 - Belly Of The Beast
        //This level has no HUD box strings.
        public string level31(string message, string message2, string input)
        {
            return "Unknown 3-1 string";
        }
        //3-2 - In The Flesh
        //This level has no HUD box strings.
        public string level32(string message, string message2, string input)
        {
            return "Unknown 3-2 string";
        }


        public string getMessage(string message, string message2, string input, JsonParser language)
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            string fullMessage = message + message2;


            //Common strings

            //Slab revolver switch
            if (fullMessage.Contains("mechanism"))
            {
                return (language.currentLanguage.act1.act1_secret);
            }


            switch (currentLevel)
            {
                case "Level 1-1":
                    {
                        return this.level11(message, message2, input, language);
                    }
                case "Level 1-2":
                    {
                        return this.level12(message, message2, input, language);
                    }
                case "Level 1-3":
                    {
                        return this.level13(message, message2, input, language);
                    }
                case "Level 1-4":
                    {
                        return this.level14(message, message2, input, language);
                    }
                case "Level 1-S":
                    {
                        return this.level1Secret(message, message2, input);
                    }
                case "Level 2-1":
                    {
                        return this.level21(message, message2, input,language);
                    }
                case "Level 2-2":
                    {
                        return this.level22(message, message2, input, language);
                    }
                case "Level 2-3":
                    {
                        return this.level23(message, message2, input,language);
                    }
                case "Level 2-4":
                    {
                        return this.level24(message, message2, input);
                    }
                case "Level 2-S":
                    {
                        return this.level2Secret(message, message2, input);
                    }
                case "Level 3-1":
                    {
                        return this.level31(message, message2, input);
                    }
                case "Level 3-2":
                    {
                        return this.level32(message, message2, input);
                    }
                default: return "Unimplemented Act 1 string";
            }
        }

        public string getLevelChallenge(string currentLevel, JsonParser language)
        {
            switch (currentLevel)
            {
                case "Level 1-1": { return language.currentLanguage.levelChallenges.challenges_limboFirst; }
                case "Level 1-2": { return language.currentLanguage.levelChallenges.challenges_limboSecond; }
                case "Level 1-3": { return language.currentLanguage.levelChallenges.challenges_limboThird; }
                case "Level 1-4": { return language.currentLanguage.levelChallenges.challenges_limboFourth; }

                case "Level 2-1": { return language.currentLanguage.levelChallenges.challenges_lustFirst; }
                case "Level 2-2": { return language.currentLanguage.levelChallenges.challenges_lustSecond; }
                case "Level 2-3": { return language.currentLanguage.levelChallenges.challenges_lustThird; }
                case "Level 2-4": { return language.currentLanguage.levelChallenges.challenges_lustFourth; }

                case "Level 3-1": { return language.currentLanguage.levelChallenges.challenges_gluttonyFirst; }
                case "Level 3-2": { return language.currentLanguage.levelChallenges.challenges_gluttonySecond; }

                default: { return "Unknown challenge description"; }
            }
        }

        public string getLevelName(JsonParser language)
        {
            string currentLevel = SceneManager.GetActiveScene().name;

            switch (currentLevel)
            {
                case "Level 1-1": { return "1-1 - " + language.currentLanguage.levelNames.levelName_limboFirst; }
                case "Level 1-2": { return "1-2 - " + language.currentLanguage.levelNames.levelName_limboSecond; }
                case "Level 1-3": { return "1-3 - " + language.currentLanguage.levelNames.levelName_limboThird; }
                case "Level 1-4": { return "1-4 - " + language.currentLanguage.levelNames.levelName_limboFourth; }
                case "Level 1-S": { return "1-S - " + language.currentLanguage.levelNames.levelName_limboSecret; }

                case "Level 2-1": { return "2-1 - " + language.currentLanguage.levelNames.levelName_lustFirst; }
                case "Level 2-2": { return "2-2 - " + language.currentLanguage.levelNames.levelName_lustSecond; }
                case "Level 2-3": { return "2-3 - " + language.currentLanguage.levelNames.levelName_lustThird; }
                case "Level 2-4": { return "2-4 - " + language.currentLanguage.levelNames.levelName_lustFourth; }
                case "Level 2-S": { return "2-S - " + language.currentLanguage.levelNames.levelName_lustSecret; }

                case "Level 3-1": { return "3-1 - " + language.currentLanguage.levelNames.levelName_gluttonyFirst; }
                case "Level 3-2": { return "3-2 - " + language.currentLanguage.levelNames.levelName_gluttonySecond; }

                default: { return "Unknown level name"; }
            }
        }
    }
}
