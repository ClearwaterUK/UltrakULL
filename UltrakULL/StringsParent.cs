using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class StringsParent
    {
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
