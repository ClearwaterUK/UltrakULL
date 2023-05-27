using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    class PrimeSanctumStrings
    {
        private string p1SecretText;
        private string p2SecretText;
        //private string p3SecretText;

        public string GetSecretText()
        {
            string currentLevel = GetCurrentSceneName();

            switch (currentLevel)
            {
                case "Level P-1": { return this.p1SecretText; }
                case "Level P-2": { return this.p2SecretText; }

                default: { return "Unknown secret text"; }
            }
        }

        public string GetLevelName()
        {
            string currentLevel = GetCurrentSceneName();

            switch (currentLevel)
            {
                case "Level P-1": { return "P-1 - " + LanguageManager.CurrentLanguage.levelNames.levelName_primeFirst; }
                case "Level P-2": { return "P-2 - " + LanguageManager.CurrentLanguage.levelNames.levelName_primeSecond; }

                default: { return "Unknown level name"; }
            }
        }

        public PrimeSanctumStrings()
        {
            this.p1SecretText =
                LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_first_secretText1 + "\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_first_secretText2 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_first_secretText3 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_first_secretText4 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_first_secretText5 + "\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_first_secretText6 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_first_secretText7 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_first_secretText8 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_first_secretText9;

            this.p2SecretText =
                LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_secretText1 + "\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_secretText2 + "\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_secretText3 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_secretText4 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_secretText5 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_secretText6 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_secretText7 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_secretText8 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_secretText9 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_secretText10 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_secretText11 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_secretText12 + "\n\n"
                + LanguageManager.CurrentLanguage.primeSanctum.primeSanctum_second_secretText13 + "\n\n";
        }
    }
}
