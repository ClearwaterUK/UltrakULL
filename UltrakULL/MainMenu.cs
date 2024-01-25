﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    public static class MainMenu
    {

        //Patches all text strings in the title menu.
        private static void PatchMainMenu(GameObject mainMenu)
        {
            try
            {
                GameObject titleObject = GetGameObjectChild(mainMenu, "Main Menu (1)");

                if (Core.ArabicUltrakillLogo != null)
                {
                    GameObject realTitleObject = GetGameObjectChild(titleObject, "Title");
                    Image logoImageObject = realTitleObject.GetComponent<Image>();
                    if (logoImageObject != null)
                    {
                        logoImageObject.sprite = Core.ArabicUltrakillLogo;
                    }
                }

                //Early access tag
                Text earlyAccessText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(titleObject, "Title"), "Text"));
                earlyAccessText.text = "--" + LanguageManager.CurrentLanguage.frontend.mainmenu_earlyAccess + "--";

                //Halloween
                Text halloweenText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(titleObject, "Title"), "Text (Halloween)"));
                halloweenText.text = "<color=orange>--" + LanguageManager.CurrentLanguage.frontend.mainmenu_halloween + "--</color>";

                //Easter
                Text easterText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(titleObject, "Title"), "Text (Easter)"));
                easterText.text = "<color=magenta>--" + LanguageManager.CurrentLanguage.frontend.mainmenu_easter + "--</color>";

                //Christmas
                Text christmasText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(titleObject, "Title"), "Text (Christmas)"));
                christmasText.text = "<color=red>--" + LanguageManager.CurrentLanguage.frontend.mainmenu_christmas + "--</color>";

                //Play button
                TextMeshProUGUI playButtonText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(titleObject, "Continue"), "Text"));
                playButtonText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_play;

                //Options button
                TextMeshProUGUI optionsButtontext = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(titleObject, "Options"), "Text"));
                optionsButtontext.text = LanguageManager.CurrentLanguage.frontend.mainmenu_options;

                //Credits button
                TextMeshProUGUI creditsButtontext = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(titleObject, "Credits"), "Text"));
                creditsButtontext.text = LanguageManager.CurrentLanguage.frontend.mainmenu_credits;

                //Quit button
                TextMeshProUGUI quitButtontext = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(titleObject, "Quit"), "Text"));
                quitButtontext.text = LanguageManager.CurrentLanguage.frontend.mainmenu_quit;

                //UMM buttons

                foreach (Transform a in titleObject.GetComponentsInChildren<Transform>())
                {
                    if(a.name == "ModsButton")
                    {
                        Text modsButtonText = GetTextfromGameObject(GetGameObjectChild(a.gameObject,"Text"));
                        modsButtonText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_mods;
                    }
                    if(a.name == "RestartButton")
                    {
                        Text restartButtonText = GetTextfromGameObject(GetGameObjectChild(a.gameObject,"Text"));
                        restartButtonText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_restart;
                    }
                }
            }
            catch (Exception e)
            {
                Logging.Error("An error occured while patching main menu. Check the console for details.");
                Logging.Error(e.ToString());
            }
        }

        //Patches all text strings in the difficulty selection menu.
        private static void PatchDifficultyMenu(GameObject frontEnd)
        {
            try
            {
                GameObject difficultyObject = GetGameObjectChild(frontEnd, "Difficulty Select (1)");

                //Difficulty header text (note: this can't fit much without reducing the default font size.)
                Text difficultyText = GetTextfromGameObject(difficultyObject.transform.Find("Title").gameObject);
                difficultyText.text = LanguageManager.CurrentLanguage.frontend.difficulty_title;

                //Easy header text
                Text easyText = GetTextfromGameObject(difficultyObject.transform.Find("Easy").gameObject);
                easyText.text =LanguageManager.CurrentLanguage.frontend.difficulty_easy;

                //Normal header text
                Text normalText = GetTextfromGameObject(difficultyObject.transform.Find("Normal").gameObject);
                normalText.text = LanguageManager.CurrentLanguage.frontend.difficulty_normal;

                //Hard header text
                Text hardText = GetTextfromGameObject(difficultyObject.transform.Find("Hard").gameObject);
                hardText.text = LanguageManager.CurrentLanguage.frontend.difficulty_hard;

                //Harmless header
                GameObject harmlessTextObject = GetGameObjectChild(difficultyObject, "Casual Easy");
                Text harmlessText = GetTextfromGameObject(harmlessTextObject.transform.Find("Name").gameObject);
                harmlessText.text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;

                //Lenient header
                GameObject lenientTextObject = GetGameObjectChild(difficultyObject, "Casual Hard");
                Text lenientText = GetTextfromGameObject(lenientTextObject.transform.Find("Name").gameObject);
                lenientText.text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;

                //Standard header
                GameObject standardTextObject = GetGameObjectChild(difficultyObject, "Standard");
                Text standardText = GetTextfromGameObject(standardTextObject.transform.Find("Name").gameObject);
                standardText.text = LanguageManager.CurrentLanguage.frontend.difficulty_standard;

                //Violent header
                GameObject violentTextObject = GetGameObjectChild(difficultyObject, "Violent");
                Text violentText = GetTextfromGameObject(violentTextObject.transform.Find("Name").gameObject);
                violentText.text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

                //Brutal header
                GameObject brutalTextObject = GetGameObjectChild(difficultyObject, "Brutal");
                Text brutalText = GetTextfromGameObject(brutalTextObject.transform.Find("Name").gameObject);
                brutalText.text = LanguageManager.CurrentLanguage.frontend.difficulty_brutal;

                //No need for Brutal/UMD header yet as it's not in-game

                //Tooltip
                GameObject assistTip = GetGameObjectChild(difficultyObject, "Assist Tip");
                Text assistTipText = GetTextfromGameObject(assistTip);
                assistTipText.text = LanguageManager.CurrentLanguage.frontend.difficulty_tweakReminder;
            }
            catch (Exception e)
            {
                Logging.Error("Failed to patch difficulty menu.");
                Logging.Error(e.ToString());
            }
        }

        //Same as above.
        private static void PatchDifficultyDescriptors(GameObject frontEnd)
        {
            try
            {
                GameObject difficultyObject = GetGameObjectChild(frontEnd, "Difficulty Select (1)");

                //Harmless title
                GameObject harmlessObject = GetGameObjectChild(difficultyObject, "Harmless Info");
                Text harmlessTitle = GetTextfromGameObject(harmlessObject.transform.Find("Title (1)").gameObject);
                harmlessTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;

                //Harmless descriptor
                Text harmlessDescriptor = GetTextfromGameObject(harmlessObject.transform.Find("Text").gameObject);
                harmlessDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription2
                    + "\n\n"
                    + "<color=green>" + LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription3 + "</color>";

                //Lenient title
                GameObject lenientObject = GetGameObjectChild(difficultyObject, "Lenient Info");
                Text lenientTitle = GetTextfromGameObject(lenientObject.transform.Find("Title (1)").gameObject);
                lenientTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;
                
                //Lenient descriptor
                Text lenientDescriptor = GetTextfromGameObject(lenientObject.transform.Find("Text").gameObject);
                lenientDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription2
                    + "\n\n"
                    + "<color=yellow>" + LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription3 + "</color>";

                //Standard title
                GameObject standardObject = GetGameObjectChild(difficultyObject, "Standard Info");
                Text standardTitle = GetTextfromGameObject(standardObject.transform.Find("Title (1)").gameObject);
                standardTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_standard;

                //Standard descriptor
                Text standardDescriptor = GetTextfromGameObject(standardObject.transform.Find("Text").gameObject);
                standardDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription2
                    + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription3 + "</color>";

                //Violent title
                GameObject violentObject = GetGameObjectChild(difficultyObject, "Violent Info");
                Text violentTitle = GetTextfromGameObject(violentObject.transform.Find("Title (1)").gameObject);
                violentTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

                //Violent descriptor
                Text violentDescriptor = GetTextfromGameObject(violentObject.transform.Find("Text").gameObject);
                violentDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription2
                    + "\n\n"
                    + "<color=red>" + LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription3 + "</color>";

                Text underConstructionText = GetTextfromGameObject(GetGameObjectChild(difficultyObject, "Under Construction"));
                underConstructionText.text = LanguageManager.CurrentLanguage.frontend.difficulty_underConstruction;


                //Brutal and UMD stuff isn't in-game yet so the below is commmented out until the devs add them.

                /*//Brutal title - not in-game yet
			    GameObject brutalObject = getGameObjectChild(difficultyObject, "Brutal Info");
			    Text brutalTitle = getTextfromGameObject(brutalObject.transform.Find("Title (1)").gameObject);
			    brutalTitle.text = "brutal title string";

			    //Brutal descriptor - not in-game yet
			    Text brutalDescriptor = getTextfromGameObject(brutalObject.transform.Find("Text").gameObject);
			    brutalDescriptor.text = "brutal difficulty descriptor. <color=red> INSIGNIFICANT FUCKING INTENSIFIES </color>";


			    //UMD title - not in-game yet

			    //UMD descriptor - not in-game yet*/
            }
            catch (Exception e)
            {
                Logging.Error("Failed to patch difficulty text.");
                Logging.Error(e.ToString());
            }

        }

        private static void PatchChapterSelect(GameObject frontEnd)
        {
            GameObject chapterObject = GetGameObjectChild(frontEnd, "Chapter Select");
            Text chapterText = GetTextfromGameObject(chapterObject.transform.Find("Title (1)").gameObject);
            chapterText.text = "--" + LanguageManager.CurrentLanguage.frontend.chapter_title + "--";

            GameObject preludeObject = GetGameObjectChild(chapterObject, "Prelude");
            Text preludeText = GetTextfromGameObject(preludeObject.transform.Find("Name").gameObject);
            preludeText.text = LanguageManager.CurrentLanguage.frontend.chapter_prelude;

            GameObject act1Object = GetGameObjectChild(chapterObject, "Act I");
            Text act1Text = GetTextfromGameObject(act1Object.transform.Find("Name").gameObject);
            act1Text.text = LanguageManager.CurrentLanguage.frontend.chapter_act1;

            GameObject act2Object = GetGameObjectChild(chapterObject, "Act II");
            Text act2Text = GetTextfromGameObject(act2Object.transform.Find("Name").gameObject);
            act2Text.text = LanguageManager.CurrentLanguage.frontend.chapter_act2;

            GameObject act3Object = GetGameObjectChild(chapterObject, "Act III");
            Text act3Text = GetTextfromGameObject(act3Object.transform.Find("Name").gameObject);
            act3Text.text = LanguageManager.CurrentLanguage.frontend.chapter_act3;

            GameObject primeObject = GetGameObjectChild(chapterObject, "Prime");
            Text primeText = GetTextfromGameObject(primeObject.transform.Find("Name").gameObject);
            primeText.text = LanguageManager.CurrentLanguage.frontend.chapter_prime;

            GameObject cgObject = GetGameObjectChild(chapterObject, "The Cyber Grind");
            Text cgText = GetTextfromGameObject(cgObject.transform.Find("Name").gameObject);
            cgText.text = LanguageManager.CurrentLanguage.frontend.chapter_cyberGrind;

            GameObject sandboxObject = GetGameObjectChild(chapterObject, "Sandbox");
            Text sandboxText = GetTextfromGameObject(sandboxObject.transform.Find("Name").gameObject);
            sandboxText.text = LanguageManager.CurrentLanguage.frontend.chapter_sandbox;
        }

        private static void PatchLevelSelectPrelude(GameObject frontEnd)
        {
            GameObject lsPreludeObject = GetGameObjectChild(frontEnd, "Level Select (Prelude)");
            
            GameObject preludeHeader = GetGameObjectChild(GetGameObjectChild(lsPreludeObject,"Overture"),"Header");
            
            //Prelude title
            Text preludeTitleText = GetTextfromGameObject(GetGameObjectChild(preludeHeader,"Text"));
            preludeTitleText.text = LanguageManager.CurrentLanguage.frontend.layer_prelude;
            preludeTitleText.fontSize = 36;
            
            //Prelude secret mission title
            Text secretText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(preludeHeader, "Secret Mission"), "Text").gameObject);
            secretText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
            

            GameObject preludeObject = GetGameObjectChild(GetGameObjectChild(lsPreludeObject, "Overture"),"Level Row");
            
            //0-1 challenge
            GameObject firstObject = GetGameObjectChild(preludeObject, "0-1 Panel");
            Text firstChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(firstObject,"Panel"), "Text"));
            firstChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-1");

            //0-2 challenge
            GameObject secondObject = GetGameObjectChild(preludeObject, "0-2 Panel");
            Text secondChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(secondObject, "Panel (2)"), "Text"));
            secondChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-2");

            //0-3 challenge
            GameObject thirdObject = GetGameObjectChild(preludeObject, "0-3 Panel");
            Text thirdChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(thirdObject, "Panel (4)"), "Text"));
            thirdChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-3");

            //0-4 challenge
            GameObject fourthObject = GetGameObjectChild(preludeObject, "0-4 Panel");
            Text fourthChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fourthObject, "Panel (6)"), "Text"));
            fourthChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-4");

            //0-5 challenge
            GameObject fifthObject = GetGameObjectChild(preludeObject, "0-5 Panel");

            Text fifthChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fifthObject, "Panel (6)"), "Text"));
            fifthChallenge.text = PreludeStrings.GetLevelChallenge("Level 0-5");
            
            //Full intro panel
            GameObject fullIntroObject = GetGameObjectChild(GetGameObjectChild(lsPreludeObject, "FullIntroPopup"), "Panel");

            Text fullIntroText = GetTextfromGameObject(fullIntroObject.transform.Find("Text").gameObject);
            fullIntroText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPrompt;

            Text fullIntroYesText = GetTextfromGameObject(GetGameObjectChild(fullIntroObject, "Button (1)").transform.Find("Text").gameObject);
            fullIntroYesText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPromptYes;

            Text fullIntroNoText = GetTextfromGameObject(GetGameObjectChild(fullIntroObject, "Button").transform.Find("Text").gameObject);
            fullIntroNoText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPromptNo;

            Text fullIntroCancelText = GetTextfromGameObject(GetGameObjectChild(fullIntroObject, "Button (2)").transform.Find("Text").gameObject);
            fullIntroCancelText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPromptCancel;
        }

        //Patches all text strings in the Act 1 menu.
        private static void PatchLevelSelectAct1(GameObject frontEnd)
        {
            GameObject act1Object = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(frontEnd, "Level Select (Act I)"), "Scroll Rect"), "Contents");

            GameObject limboObject = GetGameObjectChild(act1Object, "Layer 1 Limbo");
            GameObject lustObject = GetGameObjectChild(act1Object, "Layer 2 Lust");
            GameObject gluttonyObject = GetGameObjectChild(act1Object, "Layer 3 Gluttony");

            //Layer 1 - Limbo
            GameObject limboHeader = GetGameObjectChild(limboObject,"Header");

            Text limboTitle = GetTextfromGameObject(GetGameObjectChild(limboHeader, "Text"));
            limboTitle.text = LanguageManager.CurrentLanguage.frontend.layer_limbo;

            Text limboSecretMissionText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(limboHeader, "Secret Mission"), "Text"));
            limboSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
    
            //Main levels
            GameObject limboContent = GetGameObjectChild(limboObject,"Level Row");

            Text limboFirstChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(limboContent, "1-1 Panel"), "Panel"), "Text"));
            limboFirstChallenge.text = Act1Strings.GetLevelChallenge("Level 1-1");

            Text limboSecondChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(limboContent, "1-2 Panel"), "Panel (2)"), "Text"));
            limboSecondChallenge.text = Act1Strings.GetLevelChallenge("Level 1-2");

            Text limboThirdChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(limboContent, "1-3 Panel"), "Panel (4)"), "Text"));
            limboThirdChallenge.text = Act1Strings.GetLevelChallenge("Level 1-3");

            Text limboClimaxChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(limboContent, "1-4 Panel"), "Panel (6)"), "Text"));
            limboClimaxChallenge.text = Act1Strings.GetLevelChallenge("Level 1-4");

            //Layer 2 - Lust
            GameObject lustHeader = GetGameObjectChild(lustObject,"Header");
            
            Text lustTitle = GetTextfromGameObject(GetGameObjectChild(lustHeader, "Text"));
            lustTitle.text = LanguageManager.CurrentLanguage.frontend.layer_lust;

            Text lustSecretMissionText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(lustHeader, "Secret Mission"), "Text"));
            lustSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
            
            GameObject lustContent = GetGameObjectChild(lustObject,"Level Row");
            
            //Main levels
            Text lustFirstChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(lustContent, "2-1 Panel"),  "Panel"), "Text"));
            lustFirstChallenge.text = Act1Strings.GetLevelChallenge("Level 2-1");

            Text lustSecondChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(lustContent, "2-2 Panel"), "Panel (2)"), "Text"));
            lustSecondChallenge.text = Act1Strings.GetLevelChallenge("Level 2-2");

            Text lustThirdChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(lustContent, "2-3 Panel"), "Panel (4)"), "Text"));
            lustThirdChallenge.text = Act1Strings.GetLevelChallenge("Level 2-3");

            Text lustClimaxChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(lustContent, "2-4 Panel"), "Panel (6)"), "Text"));
            lustClimaxChallenge.text = Act1Strings.GetLevelChallenge("Level 2-4");

            //Layer 3 - Gluttony
            GameObject gluttonyHeader = GetGameObjectChild(gluttonyObject,"Header");
            
            Text gluttonyTitle = GetTextfromGameObject(GetGameObjectChild(gluttonyHeader, "Text"));
            gluttonyTitle.text = LanguageManager.CurrentLanguage.frontend.layer_gluttony;
            
            //Main levels
            GameObject gluttonyContent = GetGameObjectChild(gluttonyObject,"Level Row");

            Text gluttonyFirstChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(gluttonyContent, "3-1 Panel"), "Panel"), "Text"));
            gluttonyFirstChallenge.text = Act1Strings.GetLevelChallenge("Level 3-1");

            Text gluttonySecondChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(gluttonyContent, "3-2 Panel"),"Panel (2)"), "Text"));
            gluttonySecondChallenge.text = Act1Strings.GetLevelChallenge("Level 3-2");

        }

        private static void PatchLevelSelectAct2(GameObject frontEnd)
        {
            GameObject act2Object = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(frontEnd, "Level Select (Act II)"), "Scroll Rect"), "Contents");

            GameObject greedObject = GetGameObjectChild(act2Object, "Layer 4 Greed");
            GameObject wrathObject = GetGameObjectChild(act2Object, "Layer 5 Wrath");
            GameObject heresyObject = GetGameObjectChild(act2Object, "Layer 6 Heresy");

            //Layer 4 - Greed
            GameObject greedHeader = GetGameObjectChild(greedObject,"Header");
            
            Text greedTitle = GetTextfromGameObject(GetGameObjectChild(greedHeader, "Text"));
            greedTitle.text = LanguageManager.CurrentLanguage.frontend.layer_greed;
            
            Text greedSecretMissionText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(greedHeader, "Secret Mission"), "Text"));
            greedSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
            
            //Main levels
            GameObject greedContent = GetGameObjectChild(greedObject,"Level Row");


            Text greedFirstChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(greedContent, "4-1 Panel"), "Panel"), "Text"));
            greedFirstChallenge.text = Act2Strings.GetLevelChallenge("Level 4-1");

            Text greedSecondChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(greedContent, "4-2 Panel"), "Panel (2)"), "Text"));
            greedSecondChallenge.text = Act2Strings.GetLevelChallenge("Level 4-2");

            Text greedThirdChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(greedContent, "4-3 Panel"), "Panel (4)"), "Text"));
            greedThirdChallenge.text = Act2Strings.GetLevelChallenge("Level 4-3");

            Text greedClimaxChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(greedContent, "4-4 Panel"), "Panel (6)"), "Text"));
            greedClimaxChallenge.text = Act2Strings.GetLevelChallenge("Level 4-4");

            
            //Layer 5 - Wrath
            GameObject wrathHeader =  GetGameObjectChild(wrathObject, "Header");

            Text wrathTitle = GetTextfromGameObject(GetGameObjectChild(wrathHeader, "Text"));
            wrathTitle.text = LanguageManager.CurrentLanguage.frontend.layer_wrath;
            
            Text wrathSecretMissionText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(wrathHeader, "Secret Mission"), "Text"));
            wrathSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
            
            //Main levels
            GameObject wrathContent = GetGameObjectChild(wrathObject,"Level Row");
            
            Text wrathFirstChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(wrathContent, "5-1 Panel"), "Panel"), "Text"));
            wrathFirstChallenge.text = Act2Strings.GetLevelChallenge("Level 5-1");

            Text wrathSecondChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(wrathContent, "5-2 Panel"),"Panel (2)"), "Text"));
            wrathSecondChallenge.text = Act2Strings.GetLevelChallenge("Level 5-2");

            Text wrathThirdChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(wrathContent, "5-3 Panel"), "Panel (4)"), "Text"));
            wrathThirdChallenge.text = Act2Strings.GetLevelChallenge("Level 5-3");

            Text wrathFourthChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(wrathContent, "5-4 Panel"),"Panel (6)"), "Text"));
            wrathFourthChallenge.text = Act2Strings.GetLevelChallenge("Level 5-4");


            //Layer 6 - Heresy
            GameObject heresyHeader = GetGameObjectChild(heresyObject,"Header");
            
            Text heresyTitle = GetTextfromGameObject(GetGameObjectChild(heresyHeader, "Text"));
            heresyTitle.text = LanguageManager.CurrentLanguage.frontend.layer_heresy;
            
            //Main levels
            GameObject heresyContent = GetGameObjectChild(heresyObject,"Level Row");


            Text heresyFirstChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(heresyContent, "1-1 Panel"), "Panel"), "Text"));
            heresyFirstChallenge.text = Act2Strings.GetLevelChallenge("Level 6-1");

            Text heresySecondChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(heresyContent, "1-2 Panel"), "Panel (2)"), "Text"));
            heresySecondChallenge.text = Act2Strings.GetLevelChallenge("Level 6-2");
        }
	    
        private static void PatchLevelSelectAct3(GameObject frontEnd)
        {
            GameObject act3Object = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(frontEnd, "Level Select (Act III)"), "Scroll Rect"), "Contents");

            GameObject violenceObject = GetGameObjectChild(act3Object, "Layer 7 Violence");
            GameObject fraudObject = GetGameObjectChild(act3Object, "Layer 8 Fraud");
            GameObject treacheryObject = GetGameObjectChild(act3Object, "Layer 9 Treachery");

            //Layer 7 - Violence
            GameObject violenceHeader = GetGameObjectChild(violenceObject,"Header");
            
            Text violenceTitle = GetTextfromGameObject(GetGameObjectChild(violenceHeader, "Text"));
            violenceTitle.text = LanguageManager.CurrentLanguage.frontend.layer_violence;
            
            Text violenceSecretMissionText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(violenceHeader, "Secret Mission"), "Text"));
            violenceSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
            
            //Main levels
            GameObject violenceContent = GetGameObjectChild(violenceObject,"Level Row");


            Text violenceFirstChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(violenceContent, "7-1 Panel"), "Panel"), "Text"));
            violenceFirstChallenge.text = Act3Strings.GetLevelChallenge("Level 7-1");

            Text violenceSecondChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(violenceContent, "7-2 Panel"), "Panel (2)"), "Text"));
            violenceSecondChallenge.text = Act3Strings.GetLevelChallenge("Level 7-2");

            Text violenceThirdChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(violenceContent, "7-3 Panel"), "Panel (4)"), "Text"));
            violenceThirdChallenge.text = Act3Strings.GetLevelChallenge("Level 7-3");

            Text violenceClimaxChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(violenceContent, "7-4 Panel"), "Panel (6)"), "Text"));
            violenceClimaxChallenge.text = Act3Strings.GetLevelChallenge("Level 7-4");

            
            //Layer 8 - Fraud
            GameObject fraudHeader = GetGameObjectChild(fraudObject,"Header");
            
            Text fraudTitle = GetTextfromGameObject(GetGameObjectChild(fraudHeader, "Text"));
            fraudTitle.text = LanguageManager.CurrentLanguage.frontend.layer_fraud;
            
            Text fraudSecretMissionText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(fraudHeader, "Secret Mission"), "Text"));
            fraudSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
            
            //Main levels
            GameObject fraudContent = GetGameObjectChild(fraudObject,"Level Row");


            Text fraudFirstChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(fraudContent, "8-1 Panel"), "Panel"), "Text"));
            fraudFirstChallenge.text = Act3Strings.GetLevelChallenge("Level 8-1");

            Text fraudSecondChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(fraudContent, "8-2 Panel"), "Panel (2)"), "Text"));
            fraudSecondChallenge.text = Act3Strings.GetLevelChallenge("Level 8-2");

            Text fraudThirdChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(fraudContent, "8-3 Panel"), "Panel (4)"), "Text"));
            fraudThirdChallenge.text = Act3Strings.GetLevelChallenge("Level 8-3");

            Text fraudClimaxChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(fraudContent, "8-4 Panel"), "Panel (6)"), "Text"));
            fraudClimaxChallenge.text = Act3Strings.GetLevelChallenge("Level 8-4");


            //Layer 9 - Treachery
            GameObject treacheryHeader = GetGameObjectChild(treacheryObject,"Header");
            
            Text treacheryTitle = GetTextfromGameObject(GetGameObjectChild(treacheryHeader, "Text"));
            treacheryTitle.text = LanguageManager.CurrentLanguage.frontend.layer_treachery;
            
            //Main levels
            GameObject treacheryContent = GetGameObjectChild(treacheryObject,"Level Row");


            Text treacheryFirstChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(treacheryContent, "9-1 Panel"), "Panel"), "Text"));
            treacheryFirstChallenge.text = Act3Strings.GetLevelChallenge("Level 9-1");

            Text treacherySecondChallenge = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(treacheryContent, "9-2 Panel"), "Panel (2)"), "Text"));
            treacherySecondChallenge.text = Act3Strings.GetLevelChallenge("Level 9-2");
        }

        private static void PatchLevelSelectPrime(GameObject frontEnd)
        {
            GameObject primeObject = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(frontEnd, "Level Select (Prime)"), "Prime Sanctums"),"Header");
            Text primeTitle = GetTextfromGameObject(GetGameObjectChild(primeObject, "Text"));
            primeTitle.text = LanguageManager.CurrentLanguage.frontend.layer_prime;
        }
        

        public static void Patch(GameObject frontEnd)
        {
            try
            {
                PatchMainMenu(frontEnd);
                PatchDifficultyMenu(frontEnd);
                PatchDifficultyDescriptors(frontEnd);

                PatchChapterSelect(frontEnd);
                PatchLevelSelectPrelude(frontEnd);
                PatchLevelSelectAct1(frontEnd);
                PatchLevelSelectAct2(frontEnd);
                PatchLevelSelectAct3(frontEnd);
                PatchLevelSelectPrime(frontEnd);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

    }
}
