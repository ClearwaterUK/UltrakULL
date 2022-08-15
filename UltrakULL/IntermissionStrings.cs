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

        public string getIntermissionString(string inputString)
        {
            string currentLevel = SceneManager.GetActiveScene().name;

            //Act 2-S is being treated as an intermission. However as it's by far the most text-heavy area in the game, will redirect it to another
            //file for organisation's sake, at least for the time being.
            if (currentLevel == "Level 2-S")
            {
                Console.WriteLine("In 2-S.");
                return Act1VN.getNextString(inputString);
                
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

            return "Unknown intermission string";
        }

        public IntermissionStrings(JsonParser language)
        {
            this.act1IntermissionFirst =
                language.currentLanguage.intermission.act1_intermission_first1 + " ▼" + language.currentLanguage.intermission.act1_intermission_first2 + " ▼}"
                + language.currentLanguage.intermission.act1_intermission_first3 + " ▼" + language.currentLanguage.intermission.act1_intermission_first4 + " ▼\n\n"
                + language.currentLanguage.intermission.act1_intermission_first5 + " ▼" + language.currentLanguage.intermission.act1_intermission_first6 + " ▼"
                + language.currentLanguage.intermission.act1_intermission_first7 + " ▼" + language.currentLanguage.intermission.act1_intermission_first8 + " ▼\n\n"
                + language.currentLanguage.intermission.act1_intermission_first9 + " ▼" + language.currentLanguage.intermission.act1_intermission_first10 + " ▼"
                + language.currentLanguage.intermission.act1_intermission_first11 + " ▼" + language.currentLanguage.intermission.act1_intermission_first12 + " ▼";

            this.act1IntermissionSecond =
                language.currentLanguage.intermission.act1_intermission_second1 + " ▼" + language.currentLanguage.intermission.act1_intermission_second2 + " ▼\n\n"
                + language.currentLanguage.intermission.act1_intermission_second3 + " ▼\n\n"
                + language.currentLanguage.intermission.act1_intermission_second4 + " ▼" + language.currentLanguage.intermission.act1_intermission_second5 + " ▼"
                + language.currentLanguage.intermission.act1_intermission_second6 + " ▼" + language.currentLanguage.intermission.act1_intermission_second5 + " ▼"
                + language.currentLanguage.intermission.act1_intermission_second5 + " ▼" + language.currentLanguage.intermission.act1_intermission_second7 + " ▼\n"
                + language.currentLanguage.intermission.act1_intermission_second8 + " ▼" + language.currentLanguage.intermission.act1_intermission_second9 + " ▼\n\n"
                + language.currentLanguage.intermission.act1_intermission_second10 + " ▼" + language.currentLanguage.intermission.act1_intermission_second11 + " ▼"
                + " ▼" + language.currentLanguage.intermission.act1_intermission_second12 + " ▼";

            this.act1IntermissionThird =
                language.currentLanguage.intermission.act1_intermission_third1 + " ▼" + language.currentLanguage.intermission.act1_intermission_third2 + " ▼"
                + language.currentLanguage.intermission.act1_intermission_third3 + " ▼\n\n"
                + language.currentLanguage.intermission.act1_intermission_third4 + " ▼" + language.currentLanguage.intermission.act1_intermission_third5 + " ▼";
        }
        

    }
}
