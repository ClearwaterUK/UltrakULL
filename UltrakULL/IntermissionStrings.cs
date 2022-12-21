using UnityEngine.SceneManagement;
using UltrakULL.json;

namespace UltrakULL
{
    class IntermissionStrings
    {
        //In the intermission, the ▼ symbol in strings is used to denote pauses.
        //The } symbol fades in the background panel used.

        private string act1IntermissionFirst;
        private string act1IntermissionSecond;
        private string act1IntermissionThird;

        private string act2IntermissionFirst;
        private string act2IntermissionSecond;
        private string act2IntermissionThird;
        private string act2IntermissionFourth;
        private string act2IntermissionFifth;
        private string act2IntermissionSixth;

        public string GetIntermissionString(string inputString)
        {
            string currentLevel = SceneManager.GetActiveScene().name;

            //Act 2-S is being treated as an intermission. However as it's by far the most text-heavy area in the game, will redirect it to another
            //file for organisation's sake, at least for the time being.
            if (currentLevel == "Level 2-S")
            {
                return Act1Vn.GetNextString(inputString);
            }

            //Act 1 intermission
            if (currentLevel == "Intermission1")
            {
                //Paragraph 1
                if (inputString.Contains("Disgrace")) { return this.act1IntermissionFirst; }

                //Paragraph 2
                if (inputString.Contains("24")) { return this.act1IntermissionSecond; }

                //Paragraph 3
                if (inputString.Contains("gospel")) { return this.act1IntermissionThird; }
            }

            //Act 2 intermission
            if(currentLevel == "Intermission2")
            {
                //1 P1
                if (inputString.Contains("Silence")) { return this.act2IntermissionFirst; }

                if (inputString.Contains("The supposed")) { return this.act2IntermissionSecond; }

                if (inputString.Contains("Death stains")) { return this.act2IntermissionThird; }

                if (inputString.Contains("B-but")) { return this.act2IntermissionFourth; }

                if (inputString.Contains("matter of hours")) { return this.act2IntermissionFifth; }

                if (inputString.Contains("Bereft")) { return this.act2IntermissionSixth ; }
            }

            return "Unknown intermission string";
        }

        public IntermissionStrings()
        {

            //Act 1
            this.act1IntermissionFirst =
                LanguageManager.CurrentLanguage.intermission.act1_intermission_first1 + " ▼" + LanguageManager.CurrentLanguage.intermission.act1_intermission_first2 + " ▼}"
                + LanguageManager.CurrentLanguage.intermission.act1_intermission_first3 + " ▼" + LanguageManager.CurrentLanguage.intermission.act1_intermission_first4 + " ▼\n\n"
                + LanguageManager.CurrentLanguage.intermission.act1_intermission_first5 + " ▼" + LanguageManager.CurrentLanguage.intermission.act1_intermission_first6 + " ▼"
                + LanguageManager.CurrentLanguage.intermission.act1_intermission_first7 + " ▼" + LanguageManager.CurrentLanguage.intermission.act1_intermission_first8 + " ▼\n\n"
                + LanguageManager.CurrentLanguage.intermission.act1_intermission_first9 + " ▼" + LanguageManager.CurrentLanguage.intermission.act1_intermission_first10 + " ▼"
                + LanguageManager.CurrentLanguage.intermission.act1_intermission_first11 + " ▼" + LanguageManager.CurrentLanguage.intermission.act1_intermission_first12 + " ▼";

            this.act1IntermissionSecond =
                LanguageManager.CurrentLanguage.intermission.act1_intermission_second1 + " ▼\n\n"
                + LanguageManager.CurrentLanguage.intermission.act1_intermission_second3 + " ▼\n\n"
                + LanguageManager.CurrentLanguage.intermission.act1_intermission_second4 + " ▼" + LanguageManager.CurrentLanguage.intermission.act1_intermission_second5 + " ▼"
                + LanguageManager.CurrentLanguage.intermission.act1_intermission_second6 + " ▼" + LanguageManager.CurrentLanguage.intermission.act1_intermission_second5 + " ▼"
                + LanguageManager.CurrentLanguage.intermission.act1_intermission_second5 + " ▼" + LanguageManager.CurrentLanguage.intermission.act1_intermission_second7 + " ▼\n"
                + LanguageManager.CurrentLanguage.intermission.act1_intermission_second8 + " ▼" + LanguageManager.CurrentLanguage.intermission.act1_intermission_second9 + " ▼\n\n"
                + LanguageManager.CurrentLanguage.intermission.act1_intermission_second10 + " ▼" + LanguageManager.CurrentLanguage.intermission.act1_intermission_second11 + " ▼";

            this.act1IntermissionThird =
                LanguageManager.CurrentLanguage.intermission.act1_intermission_third1 + " ▼" + LanguageManager.CurrentLanguage.intermission.act1_intermission_third2 + " ▼"
                + LanguageManager.CurrentLanguage.intermission.act1_intermission_third3 + " ▼\n\n"
                + LanguageManager.CurrentLanguage.intermission.act1_intermission_third4 + " ▼" + LanguageManager.CurrentLanguage.intermission.act1_intermission_third5 + " ▼";

            //Act 2
            this.act2IntermissionFirst =
                LanguageManager.CurrentLanguage.intermission.act2_intermission_first1 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_first2 + " ▼"
                + LanguageManager.CurrentLanguage.intermission.act2_intermission_first3 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_first4 + " ▼"
                + LanguageManager.CurrentLanguage.intermission.act2_intermission_first5 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_first6 + " ▼"
                + "}\n\n"

                + LanguageManager.CurrentLanguage.intermission.act2_intermission_first7 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_first8
                + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_first9 + " ▼\n\n"

                + LanguageManager.CurrentLanguage.intermission.act2_intermission_first10 + " ▼";

            this.act2IntermissionSecond =
                LanguageManager.CurrentLanguage.intermission.act2_intermission_second1 + " ▼}" + LanguageManager.CurrentLanguage.intermission.act2_intermission_second2 + " ▼"
                + LanguageManager.CurrentLanguage.intermission.act2_intermission_second3 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_second4 + " ▼"
                + LanguageManager.CurrentLanguage.intermission.act2_intermission_second5 + " ▼\n\n"

                + LanguageManager.CurrentLanguage.intermission.act2_intermission_second6 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_second7
                + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_second8 + " ▼\n\n"

                + LanguageManager.CurrentLanguage.intermission.act2_intermission_second9 + " ▼\n\n"

                + LanguageManager.CurrentLanguage.intermission.act2_intermission_second10 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_second11 + " ▼";


            this.act2IntermissionThird =
                LanguageManager.CurrentLanguage.intermission.act2_intermission_third1 + " ▼}" + LanguageManager.CurrentLanguage.intermission.act2_intermission_third2
                + " ▼\n\n"

                + LanguageManager.CurrentLanguage.intermission.act2_intermission_third3 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_third4
                + " ▼\n\n"

                + LanguageManager.CurrentLanguage.intermission.act2_intermission_third5 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_third6 + " ▼"
                + LanguageManager.CurrentLanguage.intermission.act2_intermission_third7 + " ▼\n\n"

                + LanguageManager.CurrentLanguage.intermission.act2_intermission_third8 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_third9 + " ▼" +
                LanguageManager.CurrentLanguage.intermission.act2_intermission_third10 + "▼";

            this.act2IntermissionFourth =
            LanguageManager.CurrentLanguage.intermission.act2_intermission_fourth1 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_fourth2
            + " ▼\n\n"
            + LanguageManager.CurrentLanguage.intermission.act2_intermission_fourth3 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_fourth4

            + " ▼\n\n" + LanguageManager.CurrentLanguage.intermission.act2_intermission_fourth5 + " ▼\n\n"

            + LanguageManager.CurrentLanguage.intermission.act2_intermission_fourth6 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_fourth7 + " ▼"
            + LanguageManager.CurrentLanguage.intermission.act2_intermission_fourth8 + " ▼\n\n"

            + LanguageManager.CurrentLanguage.intermission.act2_intermission_fourth9 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_fourth10 + " ▼"
            + LanguageManager.CurrentLanguage.intermission.act2_intermission_fourth11 + LanguageManager.CurrentLanguage.intermission.act2_intermission_fourth12 + " ▼\n\n"

            + LanguageManager.CurrentLanguage.intermission.act2_intermission_fourth13 + " ▼";

            this.act2IntermissionFifth =
                LanguageManager.CurrentLanguage.intermission.act2_intermission_fifth1 + " ▼\n\n"
                + LanguageManager.CurrentLanguage.intermission.act2_intermission_fifth2 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_fifth3 + " ▼\n\n"

                + "...▼\n\n"

                + LanguageManager.CurrentLanguage.intermission.act2_intermission_fifth4 + " ▼\n\n"

                + LanguageManager.CurrentLanguage.intermission.act2_intermission_fifth5 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_fifth6 + " ▼";

            this.act2IntermissionSixth =
                LanguageManager.CurrentLanguage.intermission.act2_intermission_sixth1
                + " ▼\n\n" + LanguageManager.CurrentLanguage.intermission.act2_intermission_sixth2 + " ▼" + LanguageManager.CurrentLanguage.intermission.act2_intermission_sixth3
                + " ▼";
        }
    }
}
