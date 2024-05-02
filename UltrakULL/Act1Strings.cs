using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Act1Strings
    {
        //1-1 - Heart Of The Sunrise
        private static string Level11(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("ITEMS"))
            {
                PreviousHudMessage = LanguageManager.CurrentLanguage.act1.act1_limboFirst_items1 + " '<color=orange>" + input + "'</color> " + LanguageManager.CurrentLanguage.act1.act1_limboFirst_items2;
                return LanguageManager.CurrentLanguage.act1.act1_limboFirst_items1 + " '<color=orange>" + input + "'</color> " + LanguageManager.CurrentLanguage.act1.act1_limboFirst_items2;
            }
            if (fullMessage.Contains("NAILGUN"))
            {
                PreviousHudMessage = LanguageManager.CurrentLanguage.act1.act1_limboFirst_nailgun1 + " '<color=orange>" + input + "'</color> " + LanguageManager.CurrentLanguage.act1.act1_limboFirst_nailgun2 + "\n" + LanguageManager.CurrentLanguage.act1.act1_limboFirst_nailgun3;
                return LanguageManager.CurrentLanguage.act1.act1_limboFirst_nailgun1 + " '<color=orange>" + input + "'</color> " + LanguageManager.CurrentLanguage.act1.act1_limboFirst_nailgun2 + "\n" + LanguageManager.CurrentLanguage.act1.act1_limboFirst_nailgun3;
            }

            //Band-aid fix
            return PreviousHudMessage;
        }
        //1-2 - The Burning World
        private static string Level12(string message, string message2)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("BLUE"))
            {
                return LanguageManager.CurrentLanguage.act1.act1_limboSecond_blueAttack;
            }
            return "Unknown 1-2 string";
        }
        //1-3 - Hall Of Sacred Remains
        private static string Level13(string message, string message2)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("SPLIT"))
            {
                return LanguageManager.CurrentLanguage.act1.act1_limboThird_splitDoor1 + "\n" + LanguageManager.CurrentLanguage.act1.act1_limboThird_splitDoor2;
            }
            return "Unknown 1-3 string";
        }
        //1-4 - Clair De Lune
        private static string Level14(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("PICK"))
            {
                return LanguageManager.CurrentLanguage.act1.act1_limboFourth_book;
            }
            if (fullMessage.Contains("Hank"))
            {
                return LanguageManager.CurrentLanguage.act1.act1_limboFourth_hank1 + "\n" + LanguageManager.CurrentLanguage.act1.act1_limboFourth_hank2;
            }

            if (message.Contains("versions"))
            {
                return LanguageManager.CurrentLanguage.misc.hud_alternateVersion;
            }

            if (fullMessage.Contains("ALTERNATE REVOLVER"))
            {
                return LanguageManager.CurrentLanguage.act1.act1_limboFourth_alternateRevolver;
            }

            if (fullMessage.Contains("EQUIPPED"))
            {
                return LanguageManager.CurrentLanguage.act1.act1_limboFourth_newArm + " '<color=orange>" + input + "'</color>.";
            }

            return "Unknown 1-4 string";
        }
        //1-S - The Witless
        private static string Level1Secret(string message, string message2)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("LOOKS"))
            {
                return LanguageManager.CurrentLanguage.act1.act1_limboSecret_noclipSkip;
            }

            return "Unknown 1-S string";
        }
        //2-1 - Bridgeburner
        private static string Level21(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("KNUCKLE"))
            {
                return (LanguageManager.CurrentLanguage.act1.act1_lustFirst_knuckleblaster1 + " '<color=orange>"+input+"</color>' " + LanguageManager.CurrentLanguage.act1.act1_lustFirst_knuckleblaster2);
            }
            if (fullMessage.Contains("DASH"))
            {
                return (LanguageManager.CurrentLanguage.act1.act1_lustFirst_dashJump);
            }

            return "Unknown 2-1 string";
        }
        //2-2 - Death at 20,000 Volts
        private static string Level22(string message, string message2, string input)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("FEEDBACKER"))
            {
                return LanguageManager.CurrentLanguage.act1.act1_lustSecond_feedbacker1 + "\n" + LanguageManager.CurrentLanguage.act1.act1_lustSecond_feedbacker2 + " '<color=orange>" + input + "</color>'.";
            }
            if (fullMessage.Contains("RAILCANNON"))
            {
                return (LanguageManager.CurrentLanguage.act1.act1_lustSecond_railcannon);
            }

            return ("Unknown 2-2 string");
        }
        //2-3 - Sheer Heart Attack
        private static string Level23(string message, string message2)
        {
            string fullMessage = message + message2;
            if (fullMessage.Contains("water"))
            {
                return (LanguageManager.CurrentLanguage.act1.act1_lustThird_water);
            }
            return "Unknown 2-3 string";
        }
        //2-4 - Court Of The Corpse King
        //This level has no HUD box strings.
        private static string Level24()
        {
            return "Unknown 2-4 string";
        }
        //2-S
        private static string Level2Secret()
        {
            return "Unknown 2-S string";
        }
        //3-1 - Belly Of The Beast
        //This level has no HUD box strings.
        private static string Level31()
        {
            return "Unknown 3-1 string";
        }
        //3-2 - In The Flesh
        //This level has no HUD box strings.
        private static string Level32()
        {
            return "Unknown 3-2 string";
        }


        public static string GetMessage(string message, string message2, string input)
        {
            string currentLevel = GetCurrentSceneName();
            string fullMessage = message + message2;


            //Common strings

            //Slab revolver switch
            if (fullMessage.Contains("mechanism"))
            {
                return (LanguageManager.CurrentLanguage.act1.act1_secret);
            }


            switch (currentLevel)
            {
                case "Level 1-1":
                    {
                        return Level11(message, message2, input);
                    }
                case "Level 1-2":
                    {
                        return Level12(message, message2);
                    }
                case "Level 1-3":
                    {
                        return Level13(message, message2);
                    }
                case "Level 1-4":
                    {
                        return Level14(message, message2, input);
                    }
                case "Level 1-S":
                    {
                        return Level1Secret(message, message2);
                    }
                case "Level 2-1":
                    {
                        return Level21(message, message2, input);
                    }
                case "Level 2-2":
                    {
                        return Level22(message, message2, input);
                    }
                case "Level 2-3":
                    {
                        return Level23(message, message2);
                    }
                case "Level 2-4":
                    {
                        return Level24();
                    }
                case "Level 2-S":
                    {
                        return Level2Secret();
                    }
                case "Level 3-1":
                    {
                        return Level31();
                    }
                case "Level 3-2":
                    {
                        return Level32();
                    }
                default: return "Unimplemented Act 1 string";
            }
        }

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
