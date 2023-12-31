﻿using UnityEngine;

using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    public static class StringsParent
    {
        public static string GetMessage(string message, string message2, string input)
        {
            string level = GetCurrentSceneName();
            
            if (level.Contains("Tutorial"))
            {
                GameObject canvasObj = GetInactiveRootObject("Canvas");
                TutorialStrings tutStrings = new TutorialStrings(ref canvasObj);
                return TutorialStrings.GetMessage(message, message2, input);
            }
            else if (level.Contains("0-"))
            {
                return PreludeStrings.GetMessage(message, message2, input);
            }
            else if (level.Contains("1-") || (level.Contains("2-") || (level.Contains("3-"))))
            {
                return Act1Strings.GetMessage(message, message2, input);
            }
            else if (level.Contains("4-") || (level.Contains("5-") || (level.Contains("6-"))))
            {
                return Act2Strings.GetMessage(message, message2, input);
            }
            else if (level.Contains("7-") || (level.Contains("8-") || (level.Contains("9-"))))
            {
                return Act3Strings.GetMessage(message, message2, input);
            }
            else if (level.Contains("CreditsMuseum2"))
            {
                return DevMuseum.GetMessage(message,message2,input);
            }
            else
            {
                return "Unimplemented unknown string";
            }
        }

        public static string GetReturningLevelName(string input)
        {
            PreviousMissionSaver instance = MonoSingleton<PreviousMissionSaver>.Instance;

            switch(instance.previousMission)
            {
                //Prelude
                case 2: { return ("0-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeSecond);}
                case 3: { return ("0-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeThird); }
                case 4: { return ("0-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFourth); }
                case 5: { return ("0-5 - " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFifth); }

                //Act 1
                //Limbo
                case 6: { return ("1-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_limboFirst); }
                case 7: { return ("1-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_limboSecond); }
                case 8: { return ("1-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_limboThird); }
                case 9: { return ("1-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_limboFourth); }

                //Lust
                case 10: { return ("2-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_lustFirst); }
                case 11: { return ("2-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_lustSecond); }
                case 12: { return ("2-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_lustThird); }
                case 13: { return ("2-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_lustFourth); }

                //Gluttony
                case 14: { return ("3-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_gluttonyFirst); }
                case 15: { return ("3-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_gluttonySecond); }

                //Act 2
                //Greed
                case 16: { return ("4-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_greedFirst); }
                case 17: { return ("4-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_greedSecond); }
                case 18: { return ("4-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_greedThird); }
                case 19: { return ("4-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_greedFourth); }

                //Wrath
                case 20: { return ("5-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathFirst); }
                case 21: { return ("5-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathSecond); }
                case 22: { return ("5-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathThird); }
                case 23: { return ("5-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathFourth); }
                    
                //Heresy
                case 24: { return ("6-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_heresyFirst); }
                case 25: { return ("6-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_heresySecond); }
                    
                //Act 3
                //Violence
                case 26: { return ("4-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceFirst); }
                case 27: { return ("4-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceSecond); }
                case 28: { return ("4-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceThird); }
                case 29: { return ("4-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceFourth); }

                //Fraud
                case 30: { return ("5-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudFirst); }
                case 31: { return ("5-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudSecond); }
                case 32: { return ("5-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudThird); }
                case 33: { return ("5-4 - " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudFourth); }
                    
                //Treachery
                case 34: { return ("6-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_treacheryFirst); }
                case 35: { return ("6-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_treacherySecond); }

                //Prime Sanctums
                case 997: { return ("P-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_primeFirst); }
                case 998: { return ("P-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_primeSecond); }
                case 999: { return ("P-3 - " + LanguageManager.CurrentLanguage.levelNames.levelName_primeThird); }

                default: { return ("Unknown level ID. Check the console!"); }
            }
          
        }

        //Tips for each level
        public static string GetLevelTip()
        {
            string currentLevel = GetCurrentSceneName();

            //***Prelude***
            if (currentLevel.Contains("0-2"))
            {
                return(LanguageManager.CurrentLanguage.levelTips.leveltips_preludeSecond1 + "\n\n"
                    + LanguageManager.CurrentLanguage.levelTips.leveltips_preludeSecond2);
            }
            if (currentLevel.Contains("0-3"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_preludeThird1 + "\n\n"
                    + LanguageManager.CurrentLanguage.levelTips.leveltips_preludeThird2 +"\n\n"
                    + LanguageManager.CurrentLanguage.levelTips.leveltips_preludeThird3;

            }
            if (currentLevel.Contains("0-4"))
            {

                return LanguageManager.CurrentLanguage.levelTips.leveltips_preludeFourth1 + "\n\n" + LanguageManager.CurrentLanguage.levelTips.leveltips_preludeFourth2;
            }
            if (currentLevel.Contains("0-5"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_preludeFifth;
            }

            //***Act1***
            //Limbo
            if (currentLevel.Contains("1-1"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_limboFirst;
            }
            if (currentLevel.Contains("1-2"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_limboSecond;
            }
            if (currentLevel.Contains("1-3"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_limboThird1 + "\n\n"
                    + LanguageManager.CurrentLanguage.levelTips.leveltips_limboThird2;
            }
            if (currentLevel.Contains("1-4"))
            { 
                return LanguageManager.CurrentLanguage.levelTips.leveltips_limboFourth;
            }

            //Lust
            if (currentLevel.Contains("2-1"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_lustFirst;
            }
            if (currentLevel.Contains("2-2"))
            {

                return LanguageManager.CurrentLanguage.levelTips.leveltips_lustSecond1 + "\n\n"
                    + LanguageManager.CurrentLanguage.levelTips.leveltips_lustSecond2 + "\n\n"
                    + LanguageManager.CurrentLanguage.levelTips.leveltips_lustSecond3;
            }
            if (currentLevel.Contains("2-3"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_lustThird;
            }
            if (currentLevel.Contains("2-4")) {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_lustFourth1 + "\n\n" + LanguageManager.CurrentLanguage.levelTips.leveltips_lustFourth2;
            }

            //Gluttony
            if (currentLevel.Contains("3-1"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_gluttonyFirst;
            }
            if (currentLevel.Contains("3-2"))
            {

                return LanguageManager.CurrentLanguage.levelTips.leveltips_gluttonySecond1 + "\n\n" + LanguageManager.CurrentLanguage.levelTips.leveltips_gluttonySecond2;
            }

            //***Act 2***
            //Greed
            if (currentLevel.Contains("4-1"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_greedFirst;
            }
            if (currentLevel.Contains("4-2"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_greedSecond;
            }
            if (currentLevel.Contains("4-3"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_greedThird;
            }
            if (currentLevel.Contains("4-4"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_greedFourth;
            }

            //Wrath
            if (currentLevel.Contains("5-1"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_wrathFirst;
            }
            if (currentLevel.Contains("5-2"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_wrathSecond;
            }
            if (currentLevel.Contains("5-3"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_wrathThird;
            }
            if (currentLevel.Contains("5-4"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_wrathFourth1 + "\n" + LanguageManager.CurrentLanguage.levelTips.leveltips_wrathFourth2;
            }

            //Heresy
            if (currentLevel.Contains("6-1"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_heresyFirst1 + "\n" + LanguageManager.CurrentLanguage.levelTips.leveltips_heresyFirst2;
            }
            if (currentLevel.Contains("6-2"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_heresySecond1 + "\n" + LanguageManager.CurrentLanguage.levelTips.leveltips_heresySecond2;
            }
            
            //Violence
            if (currentLevel.Contains("7-1"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_violenceFirst;
            }
            if (currentLevel.Contains("7-2"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_violenceSecond;
            }
            if (currentLevel.Contains("7-3"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_violenceThird;
            }
            if (currentLevel.Contains("7-4"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_violenceFourth;
            }
            
            //Fraud
            if (currentLevel.Contains("8-1"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_fraudFirst;
            }
            if (currentLevel.Contains("8-2"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_fraudSecond;
            }
            if (currentLevel.Contains("8-3"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_fraudThird;
            }
            if (currentLevel.Contains("8-4"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_fraudFourth;
            }
            
            //Treachery
            if (currentLevel.Contains("9-1"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_treacheryFirst;
            }
            if (currentLevel.Contains("9-2"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_treacherySecond;
            }

            //Sandbox
            if (currentLevel.Contains("uk_construct"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_sandbox1 +
                    "\n<color=orange>↑ ↑ ↓ ↓ ← → ← → B A</color>\n"
                    + LanguageManager.CurrentLanguage.levelTips.leveltips_sandbox2;
            }


            //Prime sanctums
            if (currentLevel.Contains("P-1"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_primeFirst1 + "\n\n" + LanguageManager.CurrentLanguage.levelTips.leveltips_primeFirst2;
            }
            if (currentLevel.Contains("P-2"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_primeSecond;
            }

            //Cybergrind
            if (currentLevel.Contains("Endless"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_cybergrind;
            }
            
            //Dev museum
            if(currentLevel.Contains("CreditsMuseum2"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_devMuseum;
            }

            return ("Uninplemented level tip");
        }


    }
}
