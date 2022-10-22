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
    class IntermissionStrings
    {
        //In the intermission, the ▼ symbol in strings is used to denote pauses.
        //The } symbol fades in the background panel used.

        public string act1IntermissionFirst;
        public string act1IntermissionSecond;
        public string act1IntermissionThird;

        public string act2IntermissionFirst;
        public string act2IntermissionSecond;
        public string act2IntermissionThird;
        public string act2IntermissionFourth;
        public string act2IntermissionFifth;
        public string act2IntermissionSixth;

        public string getIntermissionString(string inputString, JsonParser language)
        {
            string currentLevel = SceneManager.GetActiveScene().name;

            //Act 2-S is being treated as an intermission. However as it's by far the most text-heavy area in the game, will redirect it to another
            //file for organisation's sake, at least for the time being.
            if (currentLevel == "Level 2-S")
            {
                return Act1VN.getNextString(inputString, language);
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
                Console.WriteLine(inputString);
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

        public IntermissionStrings(JsonParser language)
        {

            //Act 1
            this.act1IntermissionFirst =
                language.currentLanguage.intermission.act1_intermission_first1 + " ▼" + language.currentLanguage.intermission.act1_intermission_first2 + " ▼}"
                + language.currentLanguage.intermission.act1_intermission_first3 + " ▼" + language.currentLanguage.intermission.act1_intermission_first4 + " ▼\n\n"
                + language.currentLanguage.intermission.act1_intermission_first5 + " ▼" + language.currentLanguage.intermission.act1_intermission_first6 + " ▼"
                + language.currentLanguage.intermission.act1_intermission_first7 + " ▼" + language.currentLanguage.intermission.act1_intermission_first8 + " ▼\n\n"
                + language.currentLanguage.intermission.act1_intermission_first9 + " ▼" + language.currentLanguage.intermission.act1_intermission_first10 + " ▼"
                + language.currentLanguage.intermission.act1_intermission_first11 + " ▼" + language.currentLanguage.intermission.act1_intermission_first12 + " ▼";

            this.act1IntermissionSecond =
                language.currentLanguage.intermission.act1_intermission_second1 + " ▼\n\n"
                + language.currentLanguage.intermission.act1_intermission_second3 + " ▼\n\n"
                + language.currentLanguage.intermission.act1_intermission_second4 + " ▼" + language.currentLanguage.intermission.act1_intermission_second5 + " ▼"
                + language.currentLanguage.intermission.act1_intermission_second6 + " ▼" + language.currentLanguage.intermission.act1_intermission_second5 + " ▼"
                + language.currentLanguage.intermission.act1_intermission_second5 + " ▼" + language.currentLanguage.intermission.act1_intermission_second7 + " ▼\n"
                + language.currentLanguage.intermission.act1_intermission_second8 + " ▼" + language.currentLanguage.intermission.act1_intermission_second9 + " ▼\n\n"
                + language.currentLanguage.intermission.act1_intermission_second10 + " ▼" + language.currentLanguage.intermission.act1_intermission_second11 + " ▼";

            this.act1IntermissionThird =
                language.currentLanguage.intermission.act1_intermission_third1 + " ▼" + language.currentLanguage.intermission.act1_intermission_third2 + " ▼"
                + language.currentLanguage.intermission.act1_intermission_third3 + " ▼\n\n"
                + language.currentLanguage.intermission.act1_intermission_third4 + " ▼" + language.currentLanguage.intermission.act1_intermission_third5 + " ▼";

            //Act 2
            this.act2IntermissionFirst =
                language.currentLanguage.intermission.act2_intermission_first1 + " ▼" + language.currentLanguage.intermission.act2_intermission_first2 + " ▼"
                + language.currentLanguage.intermission.act2_intermission_first3 + " ▼" + language.currentLanguage.intermission.act2_intermission_first4 + " ▼"
                + language.currentLanguage.intermission.act2_intermission_first5 + " ▼" + language.currentLanguage.intermission.act2_intermission_first6 + " ▼"
                + "}\n\n"

                + language.currentLanguage.intermission.act2_intermission_first7 + " ▼" + language.currentLanguage.intermission.act2_intermission_first8
                + " ▼" + language.currentLanguage.intermission.act2_intermission_first9 + " ▼\n\n"

                + language.currentLanguage.intermission.act2_intermission_first10 + " ▼";

            this.act2IntermissionSecond =
                language.currentLanguage.intermission.act2_intermission_second1 + " ▼}" + language.currentLanguage.intermission.act2_intermission_second2 + " ▼"
                + language.currentLanguage.intermission.act2_intermission_second3 + " ▼" + language.currentLanguage.intermission.act2_intermission_second4 + " ▼"
                + language.currentLanguage.intermission.act2_intermission_second5 + " ▼\n\n"

                + language.currentLanguage.intermission.act2_intermission_second6 + " ▼" + language.currentLanguage.intermission.act2_intermission_second7
                + " ▼" + language.currentLanguage.intermission.act2_intermission_second8 + " ▼\n\n"

                + language.currentLanguage.intermission.act2_intermission_second9 + " ▼\n\n"

                + language.currentLanguage.intermission.act2_intermission_second10 + " ▼" + language.currentLanguage.intermission.act2_intermission_second11 + " ▼";


            this.act2IntermissionThird =
                language.currentLanguage.intermission.act2_intermission_third1 + " ▼}" + language.currentLanguage.intermission.act2_intermission_third2
                + " ▼\n\n"

                + language.currentLanguage.intermission.act2_intermission_third3 + " ▼" + language.currentLanguage.intermission.act2_intermission_third4
                + " ▼\n\n"

                + language.currentLanguage.intermission.act2_intermission_third5 + " ▼" + language.currentLanguage.intermission.act2_intermission_third6 + " ▼"
                + language.currentLanguage.intermission.act2_intermission_third7 + " ▼\n\n"

                + language.currentLanguage.intermission.act2_intermission_third8 + " ▼" + language.currentLanguage.intermission.act2_intermission_third9 + " ▼" +
                language.currentLanguage.intermission.act2_intermission_third10 + "▼";

            this.act2IntermissionFourth =
            language.currentLanguage.intermission.act2_intermission_fourth1 + " ▼" + language.currentLanguage.intermission.act2_intermission_fourth2
            + " ▼\n\n"
            + language.currentLanguage.intermission.act2_intermission_fourth3 + " ▼" + language.currentLanguage.intermission.act2_intermission_fourth4

            + " ▼\n\n" + language.currentLanguage.intermission.act2_intermission_fourth5 + " ▼\n\n"

            + language.currentLanguage.intermission.act2_intermission_fourth6 + " ▼" + language.currentLanguage.intermission.act2_intermission_fourth7 + " ▼"
            + language.currentLanguage.intermission.act2_intermission_fourth8 + " ▼\n\n"

            + language.currentLanguage.intermission.act2_intermission_fourth9 + " ▼" + language.currentLanguage.intermission.act2_intermission_fourth10 + " ▼"
            + language.currentLanguage.intermission.act2_intermission_fourth11 + language.currentLanguage.intermission.act2_intermission_fourth12 + " ▼\n\n"

            + language.currentLanguage.intermission.act2_intermission_fourth13 + " ▼";

            this.act2IntermissionFifth =
                language.currentLanguage.intermission.act2_intermission_fifth1 + " ▼\n\n"
                + language.currentLanguage.intermission.act2_intermission_fifth2 + " ▼" + language.currentLanguage.intermission.act2_intermission_fifth3 + " ▼\n\n"

                + "...▼\n\n"

                + language.currentLanguage.intermission.act2_intermission_fifth4 + " ▼\n\n"

                + language.currentLanguage.intermission.act2_intermission_fifth5 + " ▼" + language.currentLanguage.intermission.act2_intermission_fifth6 + " ▼";

            this.act2IntermissionSixth =
                language.currentLanguage.intermission.act2_intermission_sixth1
                + " ▼\n\n" + language.currentLanguage.intermission.act2_intermission_sixth2 + " ▼" + language.currentLanguage.intermission.act2_intermission_sixth3
                + " ▼";
        }
    }
}
