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
using System.Linq;
using UltrakULL.json;

namespace UltrakULL
{
    public static class MainMenu
    {
        private static BepInEx.Logging.ManualLogSource MainMenuLogger = BepInEx.Logging.Logger.CreateLogSource("FrontEndPatcher");

        //Patches all text strings in the title menu.
        public static void patchMainMenu(GameObject mainMenu)
        {
            try
            {
                GameObject titleObject = getGameObjectChild(mainMenu, "Main Menu (1)");

                //Early access tag
                Text earlyAccessText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(titleObject, "Title"), "Text"));
                earlyAccessText.text = "--" + LanguageManager.CurrentLanguage.frontend.mainmenu_earlyAccess + "--";

                //Halloween
                Text halloweenText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(titleObject, "Title"), "Text (Halloween)"));
                halloweenText.text = "<color=orange>--" + LanguageManager.CurrentLanguage.frontend.mainmenu_halloween + "--</color>";

                //Easter
                Text easterText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(titleObject, "Title"), "Text (Easter)"));
                easterText.text = "<color=magenta>--" + LanguageManager.CurrentLanguage.frontend.mainmenu_easter + "--</color>";

                //Christmas
                Text christmasText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(titleObject, "Title"), "Text (Christmas)"));
                christmasText.text = "<color=red>--" + LanguageManager.CurrentLanguage.frontend.mainmenu_christmas + "--</color>";

                //Play button
                Text playButtonText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(titleObject, "Continue"), "Text"));
                playButtonText.text = LanguageManager.CurrentLanguage.frontend.mainmenu_play;

                //Options button
                Text optionsButtontext = getTextfromGameObject(getGameObjectChild(getGameObjectChild(titleObject, "Options"), "Text"));
                optionsButtontext.text = LanguageManager.CurrentLanguage.frontend.mainmenu_options;

                //Quit button
                Text quitButtontext = getTextfromGameObject(getGameObjectChild(getGameObjectChild(titleObject, "Quit"), "Text"));
                quitButtontext.text = LanguageManager.CurrentLanguage.frontend.mainmenu_quit;
            }
            catch (Exception e)
            {
                MainMenuLogger.LogError("An error occured while patching main menu. Check the console for details.");
                MainMenuLogger.LogError(e.ToString());
            }
        }

        //Patches all text strings in the difficulty selection menu.
        public static void patchDifficultyMenu(GameObject frontEnd)
        {
            try
            {
                GameObject difficultyObject = getGameObjectChild(frontEnd, "Difficulty Select (1)");

                //Difficulty header text (note: this can't fit much without reducing the default font size.)
                Text difficultyText = getTextfromGameObject(difficultyObject.transform.Find("Title").gameObject);
                difficultyText.text = LanguageManager.CurrentLanguage.frontend.difficulty_title;

                //Easy header text
                Text easyText = getTextfromGameObject(difficultyObject.transform.Find("Easy").gameObject);
                easyText.text =LanguageManager.CurrentLanguage.frontend.difficulty_easy;

                //Normal header text
                Text normalText = getTextfromGameObject(difficultyObject.transform.Find("Normal").gameObject);
                normalText.text = LanguageManager.CurrentLanguage.frontend.difficulty_normal;

                //Hard header text
                Text hardText = getTextfromGameObject(difficultyObject.transform.Find("Hard").gameObject);
                hardText.text = LanguageManager.CurrentLanguage.frontend.difficulty_hard;

                //Harmless header
                GameObject harmlessTextObject = getGameObjectChild(difficultyObject, "Casual Easy");
                Text harmlessText = getTextfromGameObject(harmlessTextObject.transform.Find("Name").gameObject);
                harmlessText.text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;

                //Lenient header
                GameObject lenientTextObject = getGameObjectChild(difficultyObject, "Casual Hard");
                Text lenientText = getTextfromGameObject(lenientTextObject.transform.Find("Name").gameObject);
                lenientText.text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;

                //Standard header
                GameObject standardTextObject = getGameObjectChild(difficultyObject, "Standard");
                Text standardText = getTextfromGameObject(standardTextObject.transform.Find("Name").gameObject);
                standardText.text = LanguageManager.CurrentLanguage.frontend.difficulty_standard;

                //Violent header
                GameObject violentTextObject = getGameObjectChild(difficultyObject, "Violent");
                Text violentText = getTextfromGameObject(violentTextObject.transform.Find("Name").gameObject);
                violentText.text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

                //Brutal header
                GameObject brutalTextObject = getGameObjectChild(difficultyObject, "Brutal");
                Text brutalText = getTextfromGameObject(brutalTextObject.transform.Find("Name").gameObject);
                brutalText.text = LanguageManager.CurrentLanguage.frontend.difficulty_brutal;

                //No need for Brutal/UMD header yet as it's not in-game

                //Tooltip
                GameObject assistTip = getGameObjectChild(difficultyObject, "Assist Tip");
                Text assistTipText = getTextfromGameObject(assistTip);
                assistTipText.text = LanguageManager.CurrentLanguage.frontend.difficulty_tweakReminder;
            }
            catch (Exception e)
            {
                MainMenuLogger.LogError("Failed to patch difficulty menu.");
                MainMenuLogger.LogError(e.ToString());
            }
        }

        //Same as above.
        public static void patchDifficultyDescriptors(GameObject frontEnd)
        {
            try
            {
                GameObject difficultyObject = getGameObjectChild(frontEnd, "Difficulty Select (1)");

                //Harmless title
                GameObject harmlessObject = getGameObjectChild(difficultyObject, "Harmless Info");
                Text harmlessTitle = getTextfromGameObject(harmlessObject.transform.Find("Title (1)").gameObject);
                harmlessTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;

                //Harmless descriptor
                Text harmlessDescriptor = getTextfromGameObject(harmlessObject.transform.Find("Text").gameObject);
                harmlessDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription2
                    + "\n\n"
                    + "<color=lime>" + LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription3 + "</color>";

                //Lenient title
                GameObject lenientObject = getGameObjectChild(difficultyObject, "Lenient Info");
                Text lenientTitle = getTextfromGameObject(lenientObject.transform.Find("Title (1)").gameObject);
                lenientTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;
                
                //Lenient descriptor
                Text lenientDescriptor = getTextfromGameObject(lenientObject.transform.Find("Text").gameObject);
                lenientDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription2
                    + "\n\n"
                    + "<color=yellow>" + LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription3 + "</color>";

                //Standard title
                GameObject standardObject = getGameObjectChild(difficultyObject, "Standard Info");
                Text standardTitle = getTextfromGameObject(standardObject.transform.Find("Title (1)").gameObject);
                standardTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_standard;

                //Standard descriptor
                Text standardDescriptor = getTextfromGameObject(standardObject.transform.Find("Text").gameObject);
                standardDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription2
                    + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription3 + "</color>";

                //Violent title
                GameObject violentObject = getGameObjectChild(difficultyObject, "Violent Info");
                Text violentTitle = getTextfromGameObject(violentObject.transform.Find("Title (1)").gameObject);
                violentTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

                //Violent descriptor
                Text violentDescriptor = getTextfromGameObject(violentObject.transform.Find("Text").gameObject);
                violentDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription2
                    + "\n\n"
                    + "<color=red>" + LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription3 + "</color>";

                Text underConstructionText = getTextfromGameObject(getGameObjectChild(difficultyObject, "Under Construction"));
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
                MainMenuLogger.LogError("Failed to patch difficulty text.");
                Console.WriteLine(e.ToString());
            }

        }

        public static void patchChapterSelect(GameObject frontEnd)
        {
            GameObject chapterObject = getGameObjectChild(frontEnd, "Chapter Select");
            Text chapterText = getTextfromGameObject(chapterObject.transform.Find("Title (1)").gameObject);
            chapterText.text = LanguageManager.CurrentLanguage.frontend.chapter_title;

            GameObject preludeObject = getGameObjectChild(chapterObject, "Prelude");
            Text preludeText = getTextfromGameObject(preludeObject.transform.Find("Name").gameObject);
            preludeText.text = LanguageManager.CurrentLanguage.frontend.chapter_prelude;

            GameObject act1Object = getGameObjectChild(chapterObject, "Act I");
            Text act1Text = getTextfromGameObject(act1Object.transform.Find("Name").gameObject);
            act1Text.text = LanguageManager.CurrentLanguage.frontend.chapter_act1;

            GameObject act2Object = getGameObjectChild(chapterObject, "Act II");
            Text act2Text = getTextfromGameObject(act2Object.transform.Find("Name").gameObject);
            act2Text.text = LanguageManager.CurrentLanguage.frontend.chapter_act2;

            GameObject act3Object = getGameObjectChild(chapterObject, "Act III");
            Text act3Text = getTextfromGameObject(act3Object.transform.Find("Name").gameObject);
            act3Text.text = LanguageManager.CurrentLanguage.frontend.chapter_act3;

            GameObject primeObject = getGameObjectChild(chapterObject, "Prime");
            Text primeText = getTextfromGameObject(primeObject.transform.Find("Name").gameObject);
            primeText.text = LanguageManager.CurrentLanguage.frontend.chapter_prime;

            GameObject cgObject = getGameObjectChild(chapterObject, "The Cyber Grind");
            Text cgText = getTextfromGameObject(cgObject.transform.Find("Name").gameObject);
            cgText.text = LanguageManager.CurrentLanguage.frontend.chapter_cyberGrind;

            GameObject sandboxObject = getGameObjectChild(chapterObject, "Sandbox");
            Text sandboxText = getTextfromGameObject(sandboxObject.transform.Find("Name").gameObject);
            sandboxText.text = LanguageManager.CurrentLanguage.frontend.chapter_sandbox;
        }

        public static void patchLevelSelectPrelude(GameObject frontEnd)
        {
            GameObject lsPreludeObject = getGameObjectChild(frontEnd, "Level Select (Prelude)");
            GameObject preludeObject = getGameObjectChild(lsPreludeObject, "Overture");

            //Prelude title
            Text preludeTitleText = getTextfromGameObject(preludeObject.transform.Find("Text").gameObject);
            preludeTitleText.text = LanguageManager.CurrentLanguage.frontend.layer_prelude;
            preludeTitleText.fontSize = 36;

            //0-1 challenge
            GameObject firstObject = getGameObjectChild(preludeObject, "0-1 Panel");

            Text firstChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(firstObject, "Stats"), "Challenge"), "Panel"), "Text"));
            firstChallenge.text = PreludeStrings.getLevelChallenge("Level 0-1");

            //0-2 challenge

            GameObject secondObject = getGameObjectChild(preludeObject, "0-2 Panel");
            Text secondChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(secondObject, "Stats"), "Challenge"), "Panel (2)"), "Text"));
            secondChallenge.text = PreludeStrings.getLevelChallenge("Level 0-2");

            //0-3 challenge
            GameObject thirdObject = getGameObjectChild(preludeObject, "0-3 Panel");
            Text thirdChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(thirdObject, "Stats"), "Challenge"), "Panel (4)"), "Text"));
            thirdChallenge.text = PreludeStrings.getLevelChallenge("Level 0-3");

            //0-4 challenge
            GameObject fourthObject = getGameObjectChild(preludeObject, "0-4 Panel");
            Text fourthChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(fourthObject, "Stats"), "Challenge"), "Panel (6)"), "Text"));
            fourthChallenge.text = PreludeStrings.getLevelChallenge("Level 0-4");

            //0-5 challenge
            GameObject fifthObject = getGameObjectChild(preludeObject, "0-5 Panel");

            Text fifthChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(fifthObject, "Stats"), "Challenge"), "Panel (6)"), "Text"));
            fifthChallenge.text = PreludeStrings.getLevelChallenge("Level 0-5");

            //Secret title
            Text secretText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(preludeObject, "Secret Mission"), "Text").gameObject);
            secretText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;

            //Full intro panel
            GameObject fullIntroObject = getGameObjectChild(getGameObjectChild(lsPreludeObject, "FullIntroPopup"), "Panel");

            Text fullIntroText = getTextfromGameObject(fullIntroObject.transform.Find("Text").gameObject);
            fullIntroText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPrompt;

            Text fullIntroYesText = getTextfromGameObject(getGameObjectChild(fullIntroObject, "Button (1)").transform.Find("Text").gameObject);
            fullIntroYesText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPromptYes;

            Text fullIntroNoText = getTextfromGameObject(getGameObjectChild(fullIntroObject, "Button").transform.Find("Text").gameObject);
            fullIntroNoText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPromptNo;

            Text fullIntroCancelText = getTextfromGameObject(getGameObjectChild(fullIntroObject, "Button (2)").transform.Find("Text").gameObject);
            fullIntroCancelText.text = LanguageManager.CurrentLanguage.frontend.level_fullIntroPromptCancel;
        }

        //Patches all text strings in the Act 1 menu.
        public static void patchLevelSelectAct1(GameObject frontEnd)
        {
            GameObject Act1Object = getGameObjectChild(getGameObjectChild(getGameObjectChild(frontEnd, "Level Select (Act I)"), "Scroll Rect"), "Contents");

            GameObject limboObject = getGameObjectChild(Act1Object, "Layer 1 Limbo");
            GameObject lustObject = getGameObjectChild(Act1Object, "Layer 2 Lust");
            GameObject gluttonyObject = getGameObjectChild(Act1Object, "Layer 3 Gluttony");

            //Layer 1 - Limbo
            Text limboTitle = getTextfromGameObject(getGameObjectChild(limboObject, "Text"));
            limboTitle.text = LanguageManager.CurrentLanguage.frontend.layer_limbo;

            Text limboSecretMissionText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(limboObject, "Secret Mission"), "Text"));
            limboSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;

            Text limboFirstChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(limboObject, "1-1 Panel"), "Stats"), "Challenge"), "Panel"), "Text"));
            limboFirstChallenge.text = Act1Strings.getLevelChallenge("Level 1-1");

            Text limboSecondChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(limboObject, "1-2 Panel"), "Stats"), "Challenge"), "Panel (2)"), "Text"));
            limboSecondChallenge.text = Act1Strings.getLevelChallenge("Level 1-2");

            Text limboThirdChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(limboObject, "1-3 Panel"), "Stats"), "Challenge"), "Panel (4)"), "Text"));
            limboThirdChallenge.text = Act1Strings.getLevelChallenge("Level 1-3");

            Text limboClimaxChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(limboObject, "1-4 Panel"), "Stats"), "Challenge"), "Panel (6)"), "Text"));
            limboClimaxChallenge.text = Act1Strings.getLevelChallenge("Level 1-4");

            //Layer 2 - Lust
            Text lustTitle = getTextfromGameObject(getGameObjectChild(lustObject, "Text"));
            lustTitle.text = LanguageManager.CurrentLanguage.frontend.layer_lust;

            Text lustSecretMissionText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(lustObject, "Secret Mission"), "Text"));
            lustSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;

            Text lustFirstChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(lustObject, "1-1 Panel"), "Stats"), "Challenge"), "Panel"), "Text"));
            lustFirstChallenge.text = Act1Strings.getLevelChallenge("Level 2-1");

            Text lustSecondChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(lustObject, "1-2 Panel"), "Stats"), "Challenge"), "Panel (2)"), "Text"));
            lustSecondChallenge.text = Act1Strings.getLevelChallenge("Level 2-2");

            Text lustThirdChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(lustObject, "1-3 Panel"), "Stats"), "Challenge"), "Panel (4)"), "Text"));
            lustThirdChallenge.text = Act1Strings.getLevelChallenge("Level 2-3");

            Text lustClimaxChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(lustObject, "1-4 Panel"), "Stats"), "Challenge"), "Panel (6)"), "Text"));
            lustClimaxChallenge.text = Act1Strings.getLevelChallenge("Level 2-4");

            //Layer 3 - Gluttony
            Text gluttonyTitle = getTextfromGameObject(getGameObjectChild(gluttonyObject, "Text"));
            gluttonyTitle.text = LanguageManager.CurrentLanguage.frontend.layer_gluttony;

            Text gluttonyFirstChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(gluttonyObject, "1-1 Panel"), "Stats"), "Challenge"), "Panel"), "Text"));
            gluttonyFirstChallenge.text = Act1Strings.getLevelChallenge("Level 3-1");

            Text gluttonySecondChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(gluttonyObject, "1-2 Panel"), "Stats"), "Challenge"), "Panel (2)"), "Text"));
            gluttonySecondChallenge.text = Act1Strings.getLevelChallenge("Level 3-2");

        }

        public static void patchLevelSelectAct2(GameObject frontEnd)
        {
            GameObject Act2Object = getGameObjectChild(getGameObjectChild(getGameObjectChild(frontEnd, "Level Select (Act II)"), "Scroll Rect"), "Contents");

            GameObject greedObject = getGameObjectChild(Act2Object, "Layer 4 Greed");
            GameObject wrathObject = getGameObjectChild(Act2Object, "Layer 5 Wrath");
            GameObject heresyObject = getGameObjectChild(Act2Object, "Layer 6 Heresy");

            //Layer 4 - Greed
            Text greedTitle = getTextfromGameObject(getGameObjectChild(greedObject, "Text"));
            greedTitle.text = LanguageManager.CurrentLanguage.frontend.layer_greed;


            Text greedFirstChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(greedObject, "1-1 Panel"), "Stats"), "Challenge"), "Panel"), "Text"));
            greedFirstChallenge.text = Act2Strings.getLevelChallenge("Level 4-1");

            Text greedSecondChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(greedObject, "1-2 Panel"), "Stats"), "Challenge"), "Panel (2)"), "Text"));
            greedSecondChallenge.text = Act2Strings.getLevelChallenge("Level 4-2");

            Text greedThirdChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(greedObject, "1-3 Panel"), "Stats"), "Challenge"), "Panel (4)"), "Text"));
            greedThirdChallenge.text = Act2Strings.getLevelChallenge("Level 4-3");

            Text greedClimaxChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(greedObject, "1-4 Panel"), "Stats"), "Challenge"), "Panel (6)"), "Text"));
            greedClimaxChallenge.text = Act2Strings.getLevelChallenge("Level 4-4");

            Text greedSecretMissionText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(greedObject, "Secret Mission"), "Text"));
            greedSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;

            //Layer 5 - Wrath
            Text wrathTitle = getTextfromGameObject(getGameObjectChild(wrathObject, "Text"));
            wrathTitle.text = LanguageManager.CurrentLanguage.frontend.layer_wrath;

            Text wrathFirstChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(wrathObject, "1-1 Panel"), "Stats"), "Challenge"), "Panel"), "Text"));
            wrathFirstChallenge.text = Act2Strings.getLevelChallenge("Level 5-1");

            Text wrathSecondChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(wrathObject, "1-2 Panel"), "Stats"), "Challenge"), "Panel (2)"), "Text"));
            wrathSecondChallenge.text = Act2Strings.getLevelChallenge("Level 5-2");

            Text wrathThirdChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(wrathObject, "1-3 Panel"), "Stats"), "Challenge"), "Panel (4)"), "Text"));
            wrathThirdChallenge.text = Act2Strings.getLevelChallenge("Level 5-3");

            Text wrathFourthChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(wrathObject, "1-4 Panel"), "Stats"), "Challenge"), "Panel (6)"), "Text"));
            wrathFourthChallenge.text = Act2Strings.getLevelChallenge("Level 5-4");

            Text wrathSecretMissionText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(wrathObject, "Secret Mission"), "Text"));
            wrathSecretMissionText.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;

            //Layer 6 - Heresy
            Text heresyTitle = getTextfromGameObject(getGameObjectChild(heresyObject, "Text"));
            heresyTitle.text = LanguageManager.CurrentLanguage.frontend.layer_heresy;

            Text heresyFirstChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(heresyObject, "1-1 Panel"), "Stats"), "Challenge"), "Panel"), "Text"));
            heresyFirstChallenge.text = Act2Strings.getLevelChallenge("Level 6-1");

            Text heresySecondChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(heresyObject, "1-2 Panel"), "Stats"), "Challenge"), "Panel (2)"), "Text"));
            heresySecondChallenge.text = Act2Strings.getLevelChallenge("Level 6-2");
        }

        public static void patchLevelSelectPrime(GameObject frontEnd)
        {
            GameObject primeObject = getGameObjectChild(getGameObjectChild(frontEnd, "Level Select (Prime)"), "Prime Sanctums");
            Text primeTitle = getTextfromGameObject(getGameObjectChild(primeObject, "Text"));
            primeTitle.text = LanguageManager.CurrentLanguage.frontend.layer_prime;
        }


        public static void patchLoadingWindow(GameObject frontEnd)
        {
            GameObject loadingObject = getGameObjectChild(getGameObjectChild(frontEnd, "LoadingScreen"),"Text");
            Text loadingText = getTextfromGameObject(loadingObject);
            loadingText.text = LanguageManager.CurrentLanguage.misc.loading;
        }

        public static void Patch(GameObject frontEnd)
        {
            patchMainMenu(frontEnd);
            patchDifficultyMenu(frontEnd);
            patchDifficultyDescriptors(frontEnd);

            patchChapterSelect(frontEnd);
            patchLevelSelectPrelude(frontEnd);
            patchLevelSelectAct1(frontEnd);
            patchLevelSelectAct2(frontEnd);
            patchLevelSelectPrime(frontEnd);
            patchLoadingWindow(frontEnd);
        }

    }
}
