
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    public static class Act1Vn
    {
        //Import symbols to use
        //▼ - Denotes pause
        //} - stops droning noise that is present at the start of the intro
        //
        //Intro strings

        public static void PatchPrompts(ref GameObject canvasObj)
        {

            GameObject choicesBaseObject = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "PowerUpVignette"),"Panel"),"Aspect Ratio Mask");

            GameObject fallenChoices = GetGameObjectChild(choicesBaseObject, "Fallen");

            //Annoyingly both choice box objects in the Fallen sections are named the same. So we'll do this to pick up both of them.
            List<GameObject> fallenChoiceObjects = new List<GameObject>();
            foreach (Transform a in fallenChoices.transform)
            {
                if (a.gameObject.name == "Choices Box")
                {
                    fallenChoiceObjects.Add(a.gameObject);
                }
            }

            GameObject fallenChoice1Object = fallenChoiceObjects[0];
            GameObject fallenChoice2Object = fallenChoiceObjects[1];

            //Fallen
            Text fallenChoice1ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fallenChoice1Object, "Button (A)"),"Text"));
            fallenChoice1ChoiceAText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_fallenPromptFirst1;

            Text fallenChoice1ChoiceBText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fallenChoice1Object, "Button (B)"), "Text"));
            fallenChoice1ChoiceBText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_fallenPromptFirst2;

            Text fallenChoice1ChoiceCText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fallenChoice1Object, "Button (C)"), "Text"));
            fallenChoice1ChoiceCText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_fallenPromptFirst3;

            Text fallenChoice2ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fallenChoice2Object, "Button (A)"), "Text"));
            fallenChoice2ChoiceAText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_fallenPromptSecond1;

            Text fallenChoice2ChoiceBText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fallenChoice2Object, "Button (B)"), "Text"));
            fallenChoice2ChoiceBText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_fallenPromptSecond2;

            Text fallenChoice2ChoiceCText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fallenChoice2Object, "Button (C)"), "Text"));
            fallenChoice2ChoiceCText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_fallenPromptSecond3;

            //Middle choice 1
            GameObject middleChoices1Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Middle"), "Choices Box (1)");

            Text middleChoice1ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(middleChoices1Object, "Button (A)"), "Text"));
            middleChoice1ChoiceAText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_middlePrompt1;

            Text middleChoice1ChoiceBText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(middleChoices1Object, "Button (B)"), "Text"));
            middleChoice1ChoiceBText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_middlePrompt2;

            Text middleChoice1ChoiceCText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(middleChoices1Object, "Button (C)"), "Text"));
            middleChoice1ChoiceCText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_middlePrompt3;


            //Middle choice 2
            GameObject middleChoices2Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Middle"), "Choices Box (2)");

            Text middleChoice2ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(middleChoices2Object, "Button (A)"), "Text"));
            middleChoice2ChoiceAText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_middlePromptSecondRecklessness;

            Text middleChoice2ChoiceBText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(middleChoices2Object, "Button (B)"), "Text"));
            middleChoice2ChoiceBText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_middlePromptSecondWaiting;

            Text middleChoice2ChoiceCText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(middleChoices2Object, "Button (C)"), "Text"));
            middleChoice2ChoiceCText.text = "...Pourquoi sommes-nous ici?";


            //Recklessness choice 1
            GameObject recklessnessChoices1Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Recklessness"), "Choices Box");

            Text recklessnessChoice1ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(recklessnessChoices1Object, "Button (A)"), "Text"));
            recklessnessChoice1ChoiceAText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessPrompt1;

            Text recklessnessChoice2ChoiceBText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(recklessnessChoices1Object, "Button (B)"), "Text"));
            recklessnessChoice2ChoiceBText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessPrompt2;

            //Recklessness choice 2
            GameObject recklessnessChoices2Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Recklessness"), "Choices Box (1)");
            Text recklessnessChoice2ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(recklessnessChoices2Object, "Button (A)"), "Text"));
            recklessnessChoice2ChoiceAText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessPrompt3;

            //Waiting choice 1
            GameObject waitingChoices1Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Waiting"), "Choices Box");

            Text waitingChoice1ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(waitingChoices1Object, "Button (A)"), "Text"));
            waitingChoice1ChoiceAText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingPromptFirst1;

            Text waitingChoice2ChoiceBText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(waitingChoices1Object, "Button (B)"), "Text"));
            waitingChoice2ChoiceBText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingPromptFirst2;

            //Waiting choice 2
            GameObject waitingChoices2Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Waiting"), "Choices Box (1)");
            Text waitingChoice2ChoiceAText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(waitingChoices2Object, "Button (A)"), "Text"));
            waitingChoice2ChoiceAText.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingPromptThird;

            //Nihilism choice
            GameObject nihilismChoices1Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (2)");
            Text nihilismChoices1Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices1Object, "Button (A)"), "Text"));
            nihilismChoices1Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt1;

            GameObject nihilismChoices2Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (3)");
            Text nihilismChoices2Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices2Object, "Button (A)"), "Text"));
            nihilismChoices2Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt2;

            GameObject nihilismChoices3Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (4)");
            Text nihilismChoices3Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices3Object, "Button (A)"), "Text"));
            nihilismChoices3Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt3;

            GameObject nihilismChoices4Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (5)");
            Text nihilismChoices4Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices4Object, "Button (A)"), "Text"));
            nihilismChoices4Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt4;

            GameObject nihilismChoices5Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (6)");
            Text nihilismChoices5Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices5Object, "Button (A)"), "Text"));
            nihilismChoices5Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt5;

            GameObject nihilismChoices6Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (7)");
            Text nihilismChoices6Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices6Object, "Button (A)"), "Text"));
            nihilismChoices6Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt6;

            GameObject nihilismChoices7Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (8)");
            Text nihilismChoices7Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices7Object, "Button (A)"), "Text"));
            nihilismChoices7Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt7;

            GameObject nihilismChoices8Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (9)");
            Text nihilismChoices8Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices8Object, "Button (A)"), "Text"));
            nihilismChoices8Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt8;

            GameObject nihilismChoices9Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (10)");
            Text nihilismChoices9Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices9Object, "Button (A)"), "Text"));
            nihilismChoices9Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt9;

            GameObject nihilismChoices10Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (11)");
            Text nihilismChoices10Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices10Object, "Button (A)"), "Text"));
            nihilismChoices10Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt10;

            GameObject nihilismChoices11Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (12)");
            Text nihilismChoices11Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices11Object, "Button (A)"), "Text"));
            nihilismChoices11Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt11;

            GameObject nihilismChoices12Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (13)");
            Text nihilismChoices12Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices12Object, "Button (A)"), "Text"));
            nihilismChoices12Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt12;

            GameObject nihilismChoices13Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (14)");
            Text nihilismChoices13Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices13Object, "Button (A)"), "Text"));
            nihilismChoices13Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt13;

            GameObject nihilismChoices14Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (16)");
            Text nihilismChoices14Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices14Object, "Button (A)"), "Text"));
            nihilismChoices14Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt14;

            GameObject nihilismChoices15Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (17)");
            Text nihilismChoices15Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices15Object, "Button (A)"), "Text"));
            nihilismChoices15Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt15;

            GameObject nihilismChoices16Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (18)");
            Text nihilismChoices16Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices16Object, "Button (A)"), "Text"));
            nihilismChoices16Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt16;

            GameObject nihilismChoices17Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (19)");
            Text nihilismChoices17Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices17Object, "Button (A)"), "Text"));
            nihilismChoices17Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt17;

            GameObject nihilismChoices18Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (20)");
            Text nihilismChoices18Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices18Object, "Button (A)"), "Text"));
            nihilismChoices18Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt18;

            GameObject nihilismChoices19Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (21)");
            Text nihilismChoices19Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices19Object, "Button (A)"), "Text"));
            nihilismChoices19Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt19;

            GameObject nihilismChoices20Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (22)");
            Text nihilismChoices20Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices20Object, "Button (A)"), "Text"));
            nihilismChoices20Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt20;

            GameObject nihilismChoices21Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (25)");
            Text nihilismChoices21Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices21Object, "Button (A)"), "Text"));
            nihilismChoices21Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt21;

            GameObject nihilismChoices22Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (23)");
            Text nihilismChoices22Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices22Object, "Button (A)"), "Text"));
            nihilismChoices22Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt22;

            GameObject nihilismChoices23Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (24)");
            Text nihilismChoices23Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nihilismChoices23Object, "Button (A)"), "Text"));
            nihilismChoices23Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilismPrompt23;

            //Conclusion choice
            GameObject conclusionChoices1Object = GetGameObjectChild(GetGameObjectChild(choicesBaseObject, "Conclusion"), "Choices Box (2)");
            Text conclusionChoices1Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(conclusionChoices1Object, "Button (A)"), "Text"));
            Text conclusionChoices2Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(conclusionChoices1Object, "Button (B)"), "Text"));
            conclusionChoices1Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusionPrompt1;
            conclusionChoices2Text.text = LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusionPrompt2;

        }

        public static string GetNextString(string inputString)
        {
            //Intro
            if(inputString.Contains("Heavy steps"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_introFirst1 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_introFirst2 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_introFirst3
                    + "▼\n\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_introFirst4
                    + "▼\n\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_introFirst5 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_introFirst6 + "▼\n\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_introFirst7 + "▼\n";
            }
            if(inputString.Contains("I bit down"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_introSecond1 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_introSecond2 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_introSecond3 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_introSecond4 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_introSecond5
                    + "▼}\n\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_introSecond6 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_introSecond7 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_introSecond8 + "▼";
            }
            //Fallen
            if (inputString.Contains("Oof ow")) {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_fallen1 + "▼";
            }
            //Fallen branch
            if (inputString.Contains("I'm just someone"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_fallenResponseFirst + "▼";
            }
            if (inputString.Contains("Well I just got"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_fallenResponseSecond + "▼";
            }
            if (inputString.Contains("Oh great"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_fallenResponseThird1
                    + "▼\n" + LanguageManager.CurrentLanguage.visualnovel.visualnovel_fallenResponseThird2 + "▼";
            }

            if (inputString.Contains("Alright, alright"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_fallenResponseFourth + "▼";
            }

            if (inputString.Contains("UGH?"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_fallenResponseFifth + "▼";
            }
            //Kind
            if (inputString.Contains("*Sigh*"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_kindFirst1 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_kindFirst2 + "▼";
            }
            if (inputString.Contains("Though, by the"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_kindSecond + "▼";
            }
            if (inputString.Contains("So how about you"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_kindThird + "▼";
            }

            //Rude
            if (inputString.Contains("Listen up,"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_rudeFirst1 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_rudeFirst2 + "▼";
            }
            if (inputString.Contains("By the looks of it"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_rudeSecond + "▼";
            }
            if (inputString.Contains("So I'll forgive you"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_rudeThird + "▼";
            }

            //Middle
            if (inputString.Contains("UGH!"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_middleResponseFirst1 + "▼";
            }
            if (inputString.Contains("Though in retrospect"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_middleResponseFirst2 + "▼";
            }
            if (inputString.Contains("Oh well,"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_middleResponseFirst3 + "▼\n" +
                    LanguageManager.CurrentLanguage.visualnovel.visualnovel_middleResponseFirst4 + "▼\n";
            }
            if (inputString.Contains("I'm Mirage.")) {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_middleResponseFirst5 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_middleResponseFirst6 + "▼";
            }

            if (inputString.Contains("WHAT?"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_middleResponseSecond1 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_middleResponseSecond2 + "▼";
            }
            if (inputString.Contains("If you DON'T"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_middleResponseSecond3 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_middleResponseSecond4 + "▼";
            }

            if (inputString.Contains("Bullshit!"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_middleResponseThird1 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_middleResponseThird2 + "▼";
            }
            if (inputString.Contains("Though considering"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_middleResponseThird3 + "▼";
            }

            //Waiting
            if (inputString.Contains("Wandering around like"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingFirst + "▼";
            }
            if (inputString.Contains("Since we were"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingSecond + "▼";
            }
            if (inputString.Contains("Therefore,"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingThird1 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingThird2 + "▼";
            }


            //First response
            if (inputString.Contains("Suit yourself"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingResponseFirst1 + "▼\n";
            }
            if (inputString.Contains("Couldn't care less"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingResponseFirst2 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingResponseFirst3 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingResponseFirst4 + "▼";
            }



            //Second response
            if (inputString.Contains("Hah!"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingResponseSecond1 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingResponseSecond2 + "▼";
            }
            if (inputString.Contains("Because nothing"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingResponseThird1 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingResponseThird2 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_waitingResponseThird3 + "▼";
            }


            //Recklessness
            if (inputString.Contains("Yeah?"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessFirst + "▼";
            }
            if (inputString.Contains("But yes,"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessSecond1 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessSecond2 + "▼";
            }

            //First response
            if (inputString.Contains("What's the point of making"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessResponseFirst1 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessResponseFirst2 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessResponseFirst3 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessResponseFirst4 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessResponseFirst5 + "▼\n";
            }

            //Second response
            if (inputString.Contains("Don't flatter yourself"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessResponseSecond1 + "▼\n" + LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessResponseSecond2 + "▼"; 
            }

            if (inputString.Contains("Everything."))
            {
               return LanguageManager.CurrentLanguage.visualnovel.visualnovel_recklessnessResponseThird + "▼";
            }

            //Nihilism
            if (inputString.Contains("I mean really"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism1 + "▼";
            }
            if (inputString.Contains("The human mind"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism2 + "▼";
            }
            if (inputString.Contains("We can only ever"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism3 + "▼";
            }
            if (inputString.Contains("Death is"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism4 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism5 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism6 + "▼";
            }
            if (inputString.Contains("It doesn't matter"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism7 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism8 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism9 + "▼";
            }
            if (inputString.Contains("Human intelligence"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism10 + "▼\n"
                + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism11 + "▼";
            }
            if (inputString.Contains("Our intelligence"))
            {
                    return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism12 + "▼";
            }
            if (inputString.Contains("It's an over-extension"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism13 + "▼\n"
                 + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism14 + "▼\n";
            }
            if (inputString.Contains("Much like the Irish"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism15 + "▼";
            }
            if (inputString.Contains("The human mind is an"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism16 + "▼\n" +
                    LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism17 + "▼\n";
            }
            if (inputString.Contains("Existential dread"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism18 + "▼\n"
                 + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism19 + "▼\n"
                 + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism20 + "▼\n"
                 + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism21 + "▼";
            }
            if (inputString.Contains("We are unable"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism22 + "▼\n"
                 + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism23 + "▼\n"
                 + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism24 + "▼";
            }
            if (inputString.Contains("We create distractions"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism25 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism26 + "▼";
            }
            if (inputString.Contains("We sublimate it"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism27 + "▼\n"
                 + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism28 + "▼\n"
                 + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism29 + "▼";
            }
            if (inputString.Contains("But these ways"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism30 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism31 + "▼";
            }
            if (inputString.Contains("In the end"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism32 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism33 + "▼";
            }

            if (inputString.Contains("Huh?"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism34 + "▼";
            }
            if (inputString.Contains("How could it not be?"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism35 + "▼";
            }
            if (inputString.Contains("But still"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism36 + "▼";
            }
            if (inputString.Contains("I do understand"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism37 + "▼\n"
                  + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism38 + "▼\n"
                  + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism39 + "▼";
            }
            if (inputString.Contains("I see."))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism40 + "▼\n"
                + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism41 + "▼";
            }
            if (inputString.Contains("I understand it logically"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism42 + "▼\n"
                + LanguageManager.CurrentLanguage.visualnovel.visualnovel_nihilism43 + "▼";
            }

            //Conclusion
            if (inputString.Contains("Well I'll be damned"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusion1 + "▼";
            }
            if (inputString.Contains("Guess you got a good"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusion2 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusion3 + "▼";
            }
            if (inputString.Contains("Man..."))
            {
                return  LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusion4 + "▼\n"
                + LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusion5 + "▼\n"
                + LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusion6 + "▼\n"
                + LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusion7 + "▼";

            }
            if (inputString.Contains("Thank you."))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusion8 + "▼\n";
            }

            if (inputString.Contains("You've given me a lot"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusion9 + "▼\n"
                + LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusion10 + "▼\n";
            }
            if (inputString.Contains("Say..."))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusion11 + "▼";
            }
            if (inputString.Contains("Oh, you sneaky"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusionResponseFirst1 + "▼";
            }
            if (inputString.Contains("But alright"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusionResponseFirst2 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusionResponseFirst3 + "▼";
            }
            if (inputString.Contains("Alright, suit yourself"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusionResponseSecond1 + "▼\n"
                    + LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusionResponseSecond2 + "▼";
            }
            if (inputString.Contains("See you around"))
            {
                return LanguageManager.CurrentLanguage.visualnovel.visualnovel_conclusionResponseSecond3 + "▼";
            }

            return (inputString);
        }

    }
}
