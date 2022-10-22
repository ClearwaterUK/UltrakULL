using BepInEx;
using HarmonyLib;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UltrakULL;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    public static class Act1VN
    {
        //Import symbols to use
        //▼ - Denotes pause
        //} - stops droning noise that is present at the start of the intro
        //
        //Intro strings

        public static void patchPrompts(ref GameObject currentLevel, JsonParser language)
        {
            List<GameObject> rootObjects = new List<GameObject>();
            SceneManager.GetActiveScene().GetRootGameObjects(rootObjects);
            GameObject canvasObject = null;
            foreach (GameObject a in rootObjects)
            {
                if (a.gameObject.name == "Canvas")
                {
                    canvasObject = a.gameObject;
                    break;
                }
            }
            GameObject choicesBaseObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(canvasObject, "PowerUpVignette"),"Panel"),"Aspect Ratio Mask");

            GameObject fallenChoices = getGameObjectChild(choicesBaseObject, "Fallen");

            //Annoyingly both choice box objects in the Fallen sections are named the same. So we'll do this to pick up both of them.
            List<GameObject> fallenChoiceObjects = new List<GameObject>();
            foreach (Transform a in fallenChoices.transform)
            {
                if (a.gameObject.name == "Choices Box")
                {
                    fallenChoiceObjects.Add(a.gameObject);
                    Console.WriteLine(a.gameObject.name);
                }
            }

            GameObject fallenChoice1Object = fallenChoiceObjects[0];
            GameObject fallenChoice2Object = fallenChoiceObjects[1];

            //Fallen
            Text fallenChoice1ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(fallenChoice1Object, "Button (A)"),"Text"));
            fallenChoice1ChoiceAText.text = language.currentLanguage.visualnovel.visualnovel_fallenPromptFirst1;

            Text fallenChoice1ChoiceBText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(fallenChoice1Object, "Button (B)"), "Text"));
            fallenChoice1ChoiceBText.text = language.currentLanguage.visualnovel.visualnovel_fallenPromptFirst2;

            Text fallenChoice1ChoiceCText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(fallenChoice1Object, "Button (C)"), "Text"));
            fallenChoice1ChoiceCText.text = language.currentLanguage.visualnovel.visualnovel_fallenPromptFirst3;

            Text fallenChoice2ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(fallenChoice2Object, "Button (A)"), "Text"));
            fallenChoice2ChoiceAText.text = language.currentLanguage.visualnovel.visualnovel_fallenPromptSecond1;

            Text fallenChoice2ChoiceBText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(fallenChoice2Object, "Button (B)"), "Text"));
            fallenChoice2ChoiceBText.text = language.currentLanguage.visualnovel.visualnovel_fallenPromptSecond2;

            Text fallenChoice2ChoiceCText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(fallenChoice2Object, "Button (C)"), "Text"));
            fallenChoice2ChoiceCText.text = language.currentLanguage.visualnovel.visualnovel_fallenPromptSecond3;

            //Middle choice 1
            GameObject middleChoices1Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Middle"), "Choices Box (1)");

            Text middleChoice1ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(middleChoices1Object, "Button (A)"), "Text"));
            middleChoice1ChoiceAText.text = language.currentLanguage.visualnovel.visualnovel_middlePrompt1;

            Text middleChoice1ChoiceBText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(middleChoices1Object, "Button (B)"), "Text"));
            middleChoice1ChoiceBText.text = language.currentLanguage.visualnovel.visualnovel_middlePrompt2;

            Text middleChoice1ChoiceCText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(middleChoices1Object, "Button (C)"), "Text"));
            middleChoice1ChoiceCText.text = language.currentLanguage.visualnovel.visualnovel_middlePrompt3;


            //Middle choice 2
            GameObject middleChoices2Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Middle"), "Choices Box (2)");

            Text middleChoice2ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(middleChoices2Object, "Button (A)"), "Text"));
            middleChoice2ChoiceAText.text = language.currentLanguage.visualnovel.visualnovel_middlePromptSecondRecklessness;

            Text middleChoice2ChoiceBText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(middleChoices2Object, "Button (B)"), "Text"));
            middleChoice2ChoiceBText.text = language.currentLanguage.visualnovel.visualnovel_middlePromptSecondWaiting;

            Text middleChoice2ChoiceCText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(middleChoices2Object, "Button (C)"), "Text"));
            middleChoice2ChoiceCText.text = "...Pourquoi sommes-nous ici?";


            //Recklessness choice 1
            GameObject recklessnessChoices1Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Recklessness"), "Choices Box");

            Text recklessnessChoice1ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(recklessnessChoices1Object, "Button (A)"), "Text"));
            recklessnessChoice1ChoiceAText.text = language.currentLanguage.visualnovel.visualnovel_recklessnessPrompt1;

            Text recklessnessChoice2ChoiceBText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(recklessnessChoices1Object, "Button (B)"), "Text"));
            recklessnessChoice2ChoiceBText.text = language.currentLanguage.visualnovel.visualnovel_recklessnessPrompt2;

            //Recklessness choice 2
            GameObject recklessnessChoices2Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Recklessness"), "Choices Box (1)");
            Text recklessnessChoice2ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(recklessnessChoices2Object, "Button (A)"), "Text"));
            recklessnessChoice2ChoiceAText.text = language.currentLanguage.visualnovel.visualnovel_recklessnessPrompt3;

            //Waiting choice 1
            GameObject waitingChoices1Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Waiting"), "Choices Box");

            Text waitingChoice1ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(waitingChoices1Object, "Button (A)"), "Text"));
            waitingChoice1ChoiceAText.text = language.currentLanguage.visualnovel.visualnovel_waitingPromptFirst1;

            Text waitingChoice2ChoiceBText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(waitingChoices1Object, "Button (B)"), "Text"));
            waitingChoice2ChoiceBText.text = language.currentLanguage.visualnovel.visualnovel_waitingPromptFirst2;

            //Waiting choice 2
            GameObject waitingChoices2Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Waiting"), "Choices Box (1)");
            Text waitingChoice2ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(waitingChoices2Object, "Button (A)"), "Text"));
            waitingChoice2ChoiceAText.text = language.currentLanguage.visualnovel.visualnovel_waitingPromptThird;

            //Nihilism choice
            GameObject nihilismChoices1Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (2)");
            Text nihilismChoices1Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices1Object, "Button (A)"), "Text"));
            nihilismChoices1Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt1;

            GameObject nihilismChoices2Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (3)");
            Text nihilismChoices2Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices2Object, "Button (A)"), "Text"));
            nihilismChoices2Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt2;

            GameObject nihilismChoices3Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (4)");
            Text nihilismChoices3Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices3Object, "Button (A)"), "Text"));
            nihilismChoices3Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt3;

            GameObject nihilismChoices4Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (5)");
            Text nihilismChoices4Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices4Object, "Button (A)"), "Text"));
            nihilismChoices4Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt4;

            GameObject nihilismChoices5Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (6)");
            Text nihilismChoices5Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices5Object, "Button (A)"), "Text"));
            nihilismChoices5Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt5;

            GameObject nihilismChoices6Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (7)");
            Text nihilismChoices6Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices6Object, "Button (A)"), "Text"));
            nihilismChoices6Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt6;

            GameObject nihilismChoices7Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (8)");
            Text nihilismChoices7Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices7Object, "Button (A)"), "Text"));
            nihilismChoices7Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt7;

            GameObject nihilismChoices8Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (9)");
            Text nihilismChoices8Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices8Object, "Button (A)"), "Text"));
            nihilismChoices8Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt8;

            GameObject nihilismChoices9Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (10)");
            Text nihilismChoices9Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices9Object, "Button (A)"), "Text"));
            nihilismChoices9Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt9;

            GameObject nihilismChoices10Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (11)");
            Text nihilismChoices10Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices10Object, "Button (A)"), "Text"));
            nihilismChoices10Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt10;

            GameObject nihilismChoices11Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (12)");
            Text nihilismChoices11Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices11Object, "Button (A)"), "Text"));
            nihilismChoices11Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt11;

            GameObject nihilismChoices12Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (13)");
            Text nihilismChoices12Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices12Object, "Button (A)"), "Text"));
            nihilismChoices12Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt12;

            GameObject nihilismChoices13Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (14)");
            Text nihilismChoices13Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices13Object, "Button (A)"), "Text"));
            nihilismChoices13Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt13;

            GameObject nihilismChoices14Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (16)");
            Text nihilismChoices14Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices14Object, "Button (A)"), "Text"));
            nihilismChoices14Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt14;

            GameObject nihilismChoices15Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (17)");
            Text nihilismChoices15Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices15Object, "Button (A)"), "Text"));
            nihilismChoices15Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt15;

            GameObject nihilismChoices16Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (18)");
            Text nihilismChoices16Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices16Object, "Button (A)"), "Text"));
            nihilismChoices16Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt16;

            GameObject nihilismChoices17Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (19)");
            Text nihilismChoices17Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices17Object, "Button (A)"), "Text"));
            nihilismChoices17Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt17;

            GameObject nihilismChoices18Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (20)");
            Text nihilismChoices18Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices18Object, "Button (A)"), "Text"));
            nihilismChoices18Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt18;

            GameObject nihilismChoices19Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (21)");
            Text nihilismChoices19Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices19Object, "Button (A)"), "Text"));
            nihilismChoices19Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt19;

            GameObject nihilismChoices20Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (22)");
            Text nihilismChoices20Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices20Object, "Button (A)"), "Text"));
            nihilismChoices20Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt20;

            GameObject nihilismChoices21Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (25)");
            Text nihilismChoices21Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices21Object, "Button (A)"), "Text"));
            nihilismChoices21Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt21;

            GameObject nihilismChoices22Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (23)");
            Text nihilismChoices22Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices22Object, "Button (A)"), "Text"));
            nihilismChoices22Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt22;

            GameObject nihilismChoices23Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (24)");
            Text nihilismChoices23Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices23Object, "Button (A)"), "Text"));
            nihilismChoices23Text.text = language.currentLanguage.visualnovel.visualnovel_nihilismPrompt25;


            //Conclusion choice
            GameObject conclusionChoices1Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Conclusion"), "Choices Box (2)");
            Text conclusionChoices1Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(conclusionChoices1Object, "Button (A)"), "Text"));
            Text conclusionChoices2Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(conclusionChoices1Object, "Button (B)"), "Text"));
            conclusionChoices1Text.text = language.currentLanguage.visualnovel.visualnovel_conclusionPrompt1;
            conclusionChoices2Text.text = language.currentLanguage.visualnovel.visualnovel_conclusionPrompt2;


        }

        public static string getNextString(string inputString, JsonParser language)
        {
            //Intro
            if(inputString.Contains("Heavy steps"))
            {
                return language.currentLanguage.visualnovel.visualnovel_introFirst1 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_introFirst2 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_introFirst3
                    + "▼\n\n"
                    + language.currentLanguage.visualnovel.visualnovel_introFirst4
                    + "▼\n\n"
                    + language.currentLanguage.visualnovel.visualnovel_introFirst5 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_introFirst6 + "▼\n\n"
                    + language.currentLanguage.visualnovel.visualnovel_introFirst7 + "▼\n";
            }
            if(inputString.Contains("I bit down"))
            {
                return language.currentLanguage.visualnovel.visualnovel_introSecond1 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_introSecond2 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_introSecond3 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_introSecond4 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_introSecond5
                    + "▼}\n\n"
                    + language.currentLanguage.visualnovel.visualnovel_introSecond6 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_introSecond7 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_introSecond8 + "▼";
            }
            //Fallen
            if (inputString.Contains("Oof ow")) {
                return language.currentLanguage.visualnovel.visualnovel_fallen1 + "▼";
            }
            //Fallen branch
            if (inputString.Contains("I'm just someone"))
            {
                return language.currentLanguage.visualnovel.visualnovel_fallenResponseFirst + "▼";
            }
            if (inputString.Contains("Well I just got"))
            {
                return language.currentLanguage.visualnovel.visualnovel_fallenResponseSecond + "▼";
            }
            if (inputString.Contains("Oh great"))
            {
                return language.currentLanguage.visualnovel.visualnovel_fallenResponseThird1
                    + "▼\n" + language.currentLanguage.visualnovel.visualnovel_fallenResponseThird2 + "▼";
            }

            if (inputString.Contains("Alright, alright"))
            {
                return language.currentLanguage.visualnovel.visualnovel_fallenResponseFourth + "▼";
            }
            //Kind
            if (inputString.Contains("*Sigh*"))
            {
                return language.currentLanguage.visualnovel.visualnovel_kindFirst1 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_kindFirst2 + "▼";
            }
            if (inputString.Contains("Though, by the"))
            {
                return language.currentLanguage.visualnovel.visualnovel_kindSecond + "▼";
            }
            if (inputString.Contains("So how about you"))
            {
                return language.currentLanguage.visualnovel.visualnovel_kindThird + "▼";
            }

            //Rude
            if (inputString.Contains("Listen up,"))
            {
                return language.currentLanguage.visualnovel.visualnovel_rudeFirst1 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_rudeFirst2 + "▼";
            }
            if (inputString.Contains("By the looks of it"))
            {
                return language.currentLanguage.visualnovel.visualnovel_rudeSecond + "▼";
            }
            if (inputString.Contains("So I'll forgive you"))
            {
                return language.currentLanguage.visualnovel.visualnovel_rudeThird + "▼";
            }

            //Middle
            if (inputString.Contains("UGH!"))
            {
                return language.currentLanguage.visualnovel.visualnovel_middleResponseFirst1 + "▼";
            }
            if (inputString.Contains("Though in retrospect"))
            {
                return language.currentLanguage.visualnovel.visualnovel_middleResponseFirst2 + "▼";
            }
            if (inputString.Contains("Oh well,"))
            {
                return language.currentLanguage.visualnovel.visualnovel_middleResponseFirst3 + "▼\n" +
                    language.currentLanguage.visualnovel.visualnovel_middleResponseFirst4 + "▼\n";
            }
            if (inputString.Contains("I'm Mirage.")) {
                return language.currentLanguage.visualnovel.visualnovel_middleResponseFirst5 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_middleResponseFirst6 + "▼";
            }

            if (inputString.Contains("WHAT?"))
            {
                return language.currentLanguage.visualnovel.visualnovel_middleResponseSecond1 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_middleResponseSecond2 + "▼";
            }
            if (inputString.Contains("If you DON'T"))
            {
                return language.currentLanguage.visualnovel.visualnovel_middleResponseSecond3 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_middleResponseSecond4 + "▼";
            }

            if (inputString.Contains("Bullshit!"))
            {
                return language.currentLanguage.visualnovel.visualnovel_middleResponseThird1 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_middleResponseThird2 + "▼";
            }
            if (inputString.Contains("Though considering"))
            {
                return language.currentLanguage.visualnovel.visualnovel_middleResponseThird3 + "▼";
            }

            //Waiting
            if (inputString.Contains("Wandering around like"))
            {
                return language.currentLanguage.visualnovel.visualnovel_waitingFirst + "▼";
            }
            if (inputString.Contains("Since we were"))
            {
                return language.currentLanguage.visualnovel.visualnovel_waitingSecond + "▼";
            }
            if (inputString.Contains("Therefore,"))
            {
                return language.currentLanguage.visualnovel.visualnovel_waitingThird1 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_waitingThird2 + "▼";
            }


            //First response
            if (inputString.Contains("Suit yourself"))
            {
                return language.currentLanguage.visualnovel.visualnovel_waitingResponseFirst1 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_waitingResponseFirst2 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_waitingResponseFirst3 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_waitingResponseFirst4 + "▼";
            }


            //Second response
            if (inputString.Contains("Hah!"))
            {
                return language.currentLanguage.visualnovel.visualnovel_waitingResponseSecond1 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_waitingResponseSecond2 + "▼";
            }
            if (inputString.Contains("Because nothing"))
            {
                return language.currentLanguage.visualnovel.visualnovel_waitingResponseThird1 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_waitingResponseThird2 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_waitingResponseThird3 + "▼";
            }


            //Recklessness
            if (inputString.Contains("Yeah?"))
            {
                return language.currentLanguage.visualnovel.visualnovel_recklessnessFirst + "▼";
            }
            if (inputString.Contains("But yes,"))
            {
                return language.currentLanguage.visualnovel.visualnovel_recklessnessSecond1 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_recklessnessSecond2 + "▼";
            }

            //First response
            if (inputString.Contains("What's the point of making"))
            {
                return language.currentLanguage.visualnovel.visualnovel_recklessnessResponseFirst1 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_recklessnessResponseFirst2 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_recklessnessResponseFirst3 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_recklessnessResponseFirst4 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_recklessnessResponseFirst5 + "▼\n";
            }

            //Second response
            if (inputString.Contains("Don't flatter yourself"))
            {
                return language.currentLanguage.visualnovel.visualnovel_recklessnessResponseSecond1 + "▼\n" + language.currentLanguage.visualnovel.visualnovel_recklessnessResponseSecond2 + "▼"; 
            }

            if (inputString.Contains("Everything."))
            {
               return language.currentLanguage.visualnovel.visualnovel_recklessnessResponseThird + "▼";
            }

            //Nihilism
            if (inputString.Contains("I mean really"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism1 + "▼";
            }
            if (inputString.Contains("The human mind"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism2 + "▼";
            }
            if (inputString.Contains("We can only ever"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism3 + "▼";
            }
            if (inputString.Contains("Death is"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism4 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_nihilism5 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_nihilism6 + "▼";
            }
            if (inputString.Contains("It doesn't matter"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism7 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_nihilism8 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_nihilism9 + "▼";
            }
            if (inputString.Contains("Human intelligence"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism10 + "▼\n"
                + language.currentLanguage.visualnovel.visualnovel_nihilism11;
            }
            if (inputString.Contains("Our intelligence"))
            {
                    return language.currentLanguage.visualnovel.visualnovel_nihilism12 + "▼";
            }
            if (inputString.Contains("It's an over-extension"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism13 + "▼\n"
                 + language.currentLanguage.visualnovel.visualnovel_nihilism14 + "▼\n";
            }
            if (inputString.Contains("Much like the Irish"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism15 + "▼";
            }
            if (inputString.Contains("The human mind is an"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism16 + "▼\n" +
                    language.currentLanguage.visualnovel.visualnovel_nihilism17 + "▼\n";
            }
            if (inputString.Contains("Existential dread"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism18 + "▼\n"
                 + language.currentLanguage.visualnovel.visualnovel_nihilism19 + "▼\n"
                 + language.currentLanguage.visualnovel.visualnovel_nihilism20 + "▼\n"
                 + language.currentLanguage.visualnovel.visualnovel_nihilism21 + "▼";
            }
            if (inputString.Contains("We are unable"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism22 + "▼\n"
                 + language.currentLanguage.visualnovel.visualnovel_nihilism23 + "▼\n"
                 + language.currentLanguage.visualnovel.visualnovel_nihilism24 + "▼";
            }
            if (inputString.Contains("We create distractions"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism25 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_nihilism26 + "▼";
            }
            if (inputString.Contains("We sublimate it"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism27 + "▼\n"
                 + language.currentLanguage.visualnovel.visualnovel_nihilism28 + "▼\n"
                 + language.currentLanguage.visualnovel.visualnovel_nihilism29 + "▼";
            }
            if (inputString.Contains("But these ways"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism30 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_nihilism31 + "▼";
            }
            if (inputString.Contains("In the end"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism32 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_nihilism33 + "▼";
            }

            if (inputString.Contains("Huh?"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism34 + "▼";
            }
            if (inputString.Contains("How could it not be?"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism35 + "▼";
            }
            if (inputString.Contains("But still"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism36 + "▼";
            }
            if (inputString.Contains("I do understand"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism37 + "▼\n"
                  + language.currentLanguage.visualnovel.visualnovel_nihilism38 + "▼\n"
                  + language.currentLanguage.visualnovel.visualnovel_nihilism39 + "▼";
            }
            if (inputString.Contains("I see."))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism40 + "▼\n"
                + language.currentLanguage.visualnovel.visualnovel_nihilism41 + "▼";
            }
            if (inputString.Contains("I understand it logically"))
            {
                return language.currentLanguage.visualnovel.visualnovel_nihilism42 + "▼\n"
                + language.currentLanguage.visualnovel.visualnovel_nihilism43 + "▼";
            }

            //Conclusion
            if (inputString.Contains("Well I'll be damned"))
            {
                return language.currentLanguage.visualnovel.visualnovel_conclusion1 + "▼";
            }
            if (inputString.Contains("Guess you got a good"))
            {
                return language.currentLanguage.visualnovel.visualnovel_conclusion2 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_conclusion3;
            }
            if (inputString.Contains("Man..."))
            {
                return  language.currentLanguage.visualnovel.visualnovel_conclusion4 + "▼\n"
                + language.currentLanguage.visualnovel.visualnovel_conclusion5 + "▼\n"
                + language.currentLanguage.visualnovel.visualnovel_conclusion6 + "▼\n"
                + language.currentLanguage.visualnovel.visualnovel_conclusion7 + "▼";

            }
            if (inputString.Contains("Thank you."))
            {
                return language.currentLanguage.visualnovel.visualnovel_conclusion8 + "▼\n";
            }

            if (inputString.Contains("You've given me a lot"))
            {
                return language.currentLanguage.visualnovel.visualnovel_conclusion9 + "▼\n"
                + language.currentLanguage.visualnovel.visualnovel_conclusion10 + "▼\n";
            }
            if (inputString.Contains("Say..."))
            {
                return language.currentLanguage.visualnovel.visualnovel_conclusion11 + "▼";
            }
            if (inputString.Contains("Oh, you sneaky"))
            {
                return language.currentLanguage.visualnovel.visualnovel_conclusionResponseFirst1 + "▼";
            }
            if (inputString.Contains("But alright"))
            {
                return language.currentLanguage.visualnovel.visualnovel_conclusionResponseFirst2 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_conclusionResponseFirst3 + "▼";
            }
            if (inputString.Contains("Alright, suit yourself"))
            {
                return language.currentLanguage.visualnovel.visualnovel_conclusionResponseSecond1 + "▼\n"
                    + language.currentLanguage.visualnovel.visualnovel_conclusionResponseSecond2 + "▼";
            }
            if (inputString.Contains("See you around"))
            {
                return language.currentLanguage.visualnovel.visualnovel_conclusionResponseSecond3 + "▼";
            }

            return (inputString);
        }

    }
}
