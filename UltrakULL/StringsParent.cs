
using BepInEx;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UltrakULL;
using UltrakULL.json;

namespace UltrakULL
{
    public static class StringsParent
    {
        private static BepInEx.Logging.ManualLogSource parentStringsLogger = BepInEx.Logging.Logger.CreateLogSource("ParentStrings");

        public static string getMessage(string message, string message2, string input)
        {
            Debug.Log("Getting message...");
            Scene currentLevel = SceneManager.GetActiveScene();

            if (currentLevel.name.Contains("Tutorial"))
            {
                Debug.Log("Current scene: Tutorial");
                TutorialStrings tutStrings = new TutorialStrings();
                return tutStrings.getMessage(message, message2, input);
            }
            else if (currentLevel.name.Contains("0-"))
            {
                Debug.Log("Current scene: Prelude");
                return PreludeStrings.getMessage(message, message2, input);
            }
            else if (currentLevel.name.Contains("1-") || (currentLevel.name.Contains("2-") || (currentLevel.name.Contains("3-"))))
            {
                Debug.Log("Current scene: Act 1");
                return Act1Strings.getMessage(message, message2, input);
            }
            else if (currentLevel.name.Contains("4-") || (currentLevel.name.Contains("5-") || (currentLevel.name.Contains("6-"))))
            {
                Debug.Log("Current scene: Act 2");
                return Act2Strings.getMessage(message, message2, input);
            }
            else if (currentLevel.name.Contains("7-") || (currentLevel.name.Contains("8-") || (currentLevel.name.Contains("9-"))))
            {
                Debug.Log("Current scene: Act 3");
                return "Unimplemented Act 3 function";
            }
            else
            {
                return "Unimplemented unknown string";
            }
        }

        public static string getReturningLevelName(string input)
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

                case 999: { return ("P-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_primeFirst); }

                default: { return ("Unknown level ID. Check the console!"); }
            }
          
        }

        //Tips for each level
        public static string getLevelTip()
        {
            string currentLevel = SceneManager.GetActiveScene().name;

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

            //Cybergrind
            if (currentLevel.Contains("Endless"))
            {
                return LanguageManager.CurrentLanguage.levelTips.leveltips_cybergrind;
            }

            return ("Uninplemented level tip");
        }


    }
}
