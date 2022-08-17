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
    class MainMenu
    {

        BepInEx.Logging.ManualLogSource MainMenuLogger = BepInEx.Logging.Logger.CreateLogSource("FrontEndPatcher");

        //Patches all text strings in the title menu.
        public void patchMainMenu(GameObject mainMenu, JsonParser jsonParser)
        {
            try
            {

                GameObject titleObject = getGameObjectChild(mainMenu, "Main Menu (1)");
                Console.WriteLine("got");

                //Early access/seasonal tag
                Console.WriteLine("EA Text");
                Text earlyAccessText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(titleObject, "Title"), "Text"));
                earlyAccessText.text = "--" + jsonParser.currentLanguage.frontend.mainmenu_earlyAccess + "--";

                //Play button
                Console.WriteLine("Play");
                Text playButtonText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(titleObject, "Continue"), "Text"));
                playButtonText.text = jsonParser.currentLanguage.frontend.mainmenu_play;

                //Options button
                Console.WriteLine("Options");
                Text optionsButtontext = getTextfromGameObject(getGameObjectChild(getGameObjectChild(titleObject, "Options"), "Text"));
                optionsButtontext.text = jsonParser.currentLanguage.frontend.mainmenu_options;

                //Quit button
                Console.WriteLine("Quit");
                Text quitButtontext = getTextfromGameObject(getGameObjectChild(getGameObjectChild(titleObject, "Quit"), "Text"));
                quitButtontext.text = jsonParser.currentLanguage.frontend.mainmenu_quit;
            }
            catch (Exception e)
            {
                MainMenuLogger.LogError("An error occured while patching main menu. Check the console for details.");
                MainMenuLogger.LogError(e.ToString());
            }
        }

        //Patches all text strings in the difficulty selection menu.
        public void patchDifficultyMenu(GameObject frontEnd, JsonParser jsonParser)
        {
            try
            {
                GameObject difficultyObject = getGameObjectChild(frontEnd, "Difficulty Select");

                //Difficulty header text (note: this can't fit much without reducing the default font size.)
                Text difficultyText = getTextfromGameObject(difficultyObject.transform.Find("Title").gameObject);
                difficultyText.text = jsonParser.currentLanguage.frontend.difficulty_title;

                //Easy header text
                Text easyText = getTextfromGameObject(difficultyObject.transform.Find("Easy").gameObject);
                easyText.text =jsonParser.currentLanguage.frontend.difficulty_easy;

                //Normal header text
                Text normalText = getTextfromGameObject(difficultyObject.transform.Find("Normal").gameObject);
                normalText.text = jsonParser.currentLanguage.frontend.difficulty_normal;

                //Hard header text
                Text hardText = getTextfromGameObject(difficultyObject.transform.Find("Hard").gameObject);
                hardText.text = jsonParser.currentLanguage.frontend.difficulty_hard;

                //Harmless header
                GameObject harmlessTextObject = getGameObjectChild(difficultyObject, "Casual Easy");
                Text harmlessText = getTextfromGameObject(harmlessTextObject.transform.Find("Name").gameObject);
                harmlessText.text = jsonParser.currentLanguage.frontend.difficulty_harmless;

                //Lenient header
                GameObject lenientTextObject = getGameObjectChild(difficultyObject, "Casual Hard");
                Text lenientText = getTextfromGameObject(lenientTextObject.transform.Find("Name").gameObject);
                lenientText.text = jsonParser.currentLanguage.frontend.difficulty_lenient;

                //Standard header
                GameObject standardTextObject = getGameObjectChild(difficultyObject, "Standard");
                Text standardText = getTextfromGameObject(standardTextObject.transform.Find("Name").gameObject);
                standardText.text = jsonParser.currentLanguage.frontend.difficulty_standard;

                //Violent header - this is appearing in harmless for some reason?
                GameObject violentTextObject = getGameObjectChild(difficultyObject, "Violent");
                Text violentText = getTextfromGameObject(violentTextObject.transform.Find("Name").gameObject);
                violentText.text = jsonParser.currentLanguage.frontend.difficulty_violent;

                //Brutal header
                GameObject brutalTextObject = getGameObjectChild(difficultyObject, "Brutal");
                Text brutalText = getTextfromGameObject(brutalTextObject.transform.Find("Name").gameObject);
                brutalText.text = jsonParser.currentLanguage.frontend.difficulty_brutal;

                //No need for UMD header yet as it's not in-game
            }
            catch (Exception e)
            {
                MainMenuLogger.LogError("Failed to patch difficulty menu.");
                MainMenuLogger.LogError(e.ToString());
            }

        }

        //Same as above.
        public void patchDifficultyDescriptors(GameObject frontEnd, JsonParser jsonParser)
        {
            try
            {
                GameObject difficultyObject = getGameObjectChild(frontEnd, "Difficulty Select");

                //Harmless title
                GameObject harmlessObject = getGameObjectChild(difficultyObject, "Harmless Info");
                Text harmlessTitle = getTextfromGameObject(harmlessObject.transform.Find("Title (1)").gameObject);
                harmlessTitle.text = jsonParser.currentLanguage.frontend.difficulty_harmless;

                //Harmless descriptor
                Text harmlessDescriptor = getTextfromGameObject(harmlessObject.transform.Find("Text").gameObject);
                harmlessDescriptor.text =
                    jsonParser.currentLanguage.frontend.difficulty_harmlessDescription1
                    + "\n\n"
                    + jsonParser.currentLanguage.frontend.difficulty_harmlessDescription2
                    + "\n\n"
                    + "<color=lime>" + jsonParser.currentLanguage.frontend.difficulty_harmlessDescription3 + "</color>";

                //Lenient title
                GameObject lenientObject = getGameObjectChild(difficultyObject, "Lenient Info");
                Text lenientTitle = getTextfromGameObject(lenientObject.transform.Find("Title (1)").gameObject);
                lenientTitle.text = jsonParser.currentLanguage.frontend.difficulty_lenient;
                
                //Lenient descriptor
                Text lenientDescriptor = getTextfromGameObject(lenientObject.transform.Find("Text").gameObject);
                lenientDescriptor.text =
                    jsonParser.currentLanguage.frontend.difficulty_lenientDescription1
                    + "\n\n"
                    + jsonParser.currentLanguage.frontend.difficulty_lenientDescription2
                    + "\n\n"
                    + "<color=yellow>" + jsonParser.currentLanguage.frontend.difficulty_lenientDescription3 + "</color>";

                //Standard title
                GameObject standardObject = getGameObjectChild(difficultyObject, "Standard Info");
                Text standardTitle = getTextfromGameObject(standardObject.transform.Find("Title (1)").gameObject);
                standardTitle.text = jsonParser.currentLanguage.frontend.difficulty_standard;

                //Standard descriptor
                Text standardDescriptor = getTextfromGameObject(standardObject.transform.Find("Text").gameObject);
                standardDescriptor.text =
                    jsonParser.currentLanguage.frontend.difficulty_standardDescription1
                    + "\n\n"
                    + jsonParser.currentLanguage.frontend.difficulty_standardDescription2
                    + "\n\n"
                    + "<color=orange>" + jsonParser.currentLanguage.frontend.difficulty_standardDescription3 + "</color>";

                //Violent title
                GameObject violentObject = getGameObjectChild(difficultyObject, "Violent Info");
                Text violentTitle = getTextfromGameObject(violentObject.transform.Find("Title (1)").gameObject);
                standardTitle.text = jsonParser.currentLanguage.frontend.difficulty_violent;

                //Violent descriptor
                Text violentDescriptor = getTextfromGameObject(violentObject.transform.Find("Text").gameObject);
                violentDescriptor.text =
                    jsonParser.currentLanguage.frontend.difficulty_violentDescription1
                    + "\n\n"
                    + jsonParser.currentLanguage.frontend.difficulty_violentDescription2
                    + "\n\n"
                    + "<color=red>" + jsonParser.currentLanguage.frontend.difficulty_violentDescription3 + "</color>";


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

        public void patchChapterSelect(GameObject frontEnd, JsonParser jsonParser)
        {
            GameObject chapterObject = getGameObjectChild(frontEnd, "Chapter Select");
            Text chapterText = getTextfromGameObject(chapterObject.transform.Find("Title (1)").gameObject);
            chapterText.text = jsonParser.currentLanguage.frontend.chapter_title;

            GameObject preludeObject = getGameObjectChild(chapterObject, "Prelude");
            Text preludeText = getTextfromGameObject(preludeObject.transform.Find("Name").gameObject);
            preludeText.text = jsonParser.currentLanguage.frontend.chapter_prelude;

            GameObject act1Object = getGameObjectChild(chapterObject, "Act I");
            Text act1Text = getTextfromGameObject(act1Object.transform.Find("Name").gameObject);
            act1Text.text = jsonParser.currentLanguage.frontend.chapter_act1;

            GameObject act2Object = getGameObjectChild(chapterObject, "Act II");
            Text act2Text = getTextfromGameObject(act2Object.transform.Find("Name").gameObject);
            act2Text.text = jsonParser.currentLanguage.frontend.chapter_act2;

            GameObject act3Object = getGameObjectChild(chapterObject, "Act III");
            Text act3Text = getTextfromGameObject(act3Object.transform.Find("Name").gameObject);
            act3Text.text = jsonParser.currentLanguage.frontend.chapter_act3;

            GameObject primeObject = getGameObjectChild(chapterObject, "Prime");
            Text primeText = getTextfromGameObject(primeObject.transform.Find("Name").gameObject);
            primeText.text = jsonParser.currentLanguage.frontend.chapter_prime;

            GameObject cgObject = getGameObjectChild(chapterObject, "The Cyber Grind");
            Text cgText = getTextfromGameObject(cgObject.transform.Find("Name").gameObject);
            cgText.text = jsonParser.currentLanguage.frontend.chapter_cyberGrind;

            GameObject sandboxObject = getGameObjectChild(chapterObject, "Sandbox");
            Text sandboxText = getTextfromGameObject(sandboxObject.transform.Find("Name").gameObject);
            sandboxText.text = jsonParser.currentLanguage.frontend.chapter_sandbox;
        }

        public void patchLevelSelectPrelude(GameObject frontEnd, JsonParser language)
        {
            PreludeStrings challengeStrings = new PreludeStrings();

            GameObject lsPreludeObject = getGameObjectChild(frontEnd, "Level Select (Prelude)");
            GameObject preludeObject = getGameObjectChild(lsPreludeObject, "Overture");

            //Prelude title
            Text preludeTitleText = getTextfromGameObject(preludeObject.transform.Find("Text").gameObject);
            preludeTitleText.text = language.currentLanguage.frontend.layer_prelude;
            preludeTitleText.fontSize = 36;

            //0-1 challenge
            GameObject firstObject = getGameObjectChild(preludeObject, "0-1 Panel");

            Text firstChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(firstObject, "Stats"), "Challenge"), "Panel"), "Text"));
            firstChallenge.text = challengeStrings.getLevelChallenge("Level 0-1", language);

            //0-2 challenge

            GameObject secondObject = getGameObjectChild(preludeObject, "0-2 Panel");
            Text secondChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(secondObject, "Stats"), "Challenge"), "Panel (2)"), "Text"));
            secondChallenge.text = challengeStrings.getLevelChallenge("Level 0-2", language);

            //0-3 challenge
            GameObject thirdObject = getGameObjectChild(preludeObject, "0-3 Panel");
            Text thirdChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(thirdObject, "Stats"), "Challenge"), "Panel (4)"), "Text"));
            thirdChallenge.text = challengeStrings.getLevelChallenge("Level 0-3", language);

            //0-4 challenge
            GameObject fourthObject = getGameObjectChild(preludeObject, "0-4 Panel");
            Text fourthChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(fourthObject, "Stats"), "Challenge"), "Panel (6)"), "Text"));
            fourthChallenge.text = challengeStrings.getLevelChallenge("Level 0-4", language);

            //0-5 challenge
            GameObject fifthObject = getGameObjectChild(preludeObject, "0-5 Panel");

            Text fifthChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(fifthObject, "Stats"), "Challenge"), "Panel (6)"), "Text"));
            fifthChallenge.text = challengeStrings.getLevelChallenge("Level 0-5", language);

            //Secret title
            Text secretText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(preludeObject, "Secret Mission"), "Text").gameObject);
            secretText.text = language.currentLanguage.frontend.chapter_secretMission;

            //Full intro panel
            GameObject fullIntroObject = getGameObjectChild(getGameObjectChild(lsPreludeObject, "FullIntroPopup"), "Panel");

            Text fullIntroText = getTextfromGameObject(fullIntroObject.transform.Find("Text").gameObject);
            fullIntroText.text = "INTRO COMPLET?";

            Text fullIntroYesText = getTextfromGameObject(getGameObjectChild(fullIntroObject, "Button (1)").transform.Find("Text").gameObject);
            fullIntroYesText.text = "OUI";

            Text fullIntroNoText = getTextfromGameObject(getGameObjectChild(fullIntroObject, "Button").transform.Find("Text").gameObject);
            fullIntroNoText.text = "NON";

            Text fullIntroCancelText = getTextfromGameObject(getGameObjectChild(fullIntroObject, "Button (2)").transform.Find("Text").gameObject);
            fullIntroCancelText.text = "ANNULER";
        }

        //Patches all text strings in the Act 1 menu.
        public void patchLevelSelectAct1(GameObject frontEnd, JsonParser language)
        {
            GameObject Act1Object = getGameObjectChild(getGameObjectChild(getGameObjectChild(frontEnd, "Level Select (Act I)"), "Scroll Rect"), "Contents");

            GameObject limboObject = getGameObjectChild(Act1Object, "Layer 1 Limbo");
            GameObject lustObject = getGameObjectChild(Act1Object, "Layer 2 Lust");
            GameObject gluttonyObject = getGameObjectChild(Act1Object, "Layer 3 Gluttony");

            Act1Strings act1Challenges = new Act1Strings();

            //Layer 1 - Limbo
            Text limboTitle = getTextfromGameObject(getGameObjectChild(limboObject, "Text"));
            limboTitle.text = language.currentLanguage.frontend.layer_limbo;

            Text limboSecretMissionText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(limboObject, "Secret Mission"), "Text"));
            limboSecretMissionText.text = language.currentLanguage.frontend.chapter_secretMission;

            Text limboFirstChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(limboObject, "1-1 Panel"), "Stats"), "Challenge"), "Panel"), "Text"));
            limboFirstChallenge.text = act1Challenges.getLevelChallenge("Level 1-1",language);

            Text limboSecondChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(limboObject, "1-2 Panel"), "Stats"), "Challenge"), "Panel (2)"), "Text"));
            limboSecondChallenge.text = act1Challenges.getLevelChallenge("Level 1-2", language);

            Text limboThirdChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(limboObject, "1-3 Panel"), "Stats"), "Challenge"), "Panel (4)"), "Text"));
            limboThirdChallenge.text = act1Challenges.getLevelChallenge("Level 1-3", language);

            Text limboClimaxChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(limboObject, "1-4 Panel"), "Stats"), "Challenge"), "Panel (6)"), "Text"));
            limboClimaxChallenge.text = act1Challenges.getLevelChallenge("Level 1-4", language);

            //Layer 2 - Lust
            Text lustTitle = getTextfromGameObject(getGameObjectChild(lustObject, "Text"));
            lustTitle.text = language.currentLanguage.frontend.layer_lust;

            Text lustSecretMissionText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(lustObject, "Secret Mission"), "Text"));
            lustSecretMissionText.text = language.currentLanguage.frontend.chapter_secretMission;

            Text lustFirstChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(lustObject, "1-1 Panel"), "Stats"), "Challenge"), "Panel"), "Text"));
            lustFirstChallenge.text = act1Challenges.getLevelChallenge("Level 2-1", language);

            Text lustSecondChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(lustObject, "1-2 Panel"), "Stats"), "Challenge"), "Panel (2)"), "Text"));
            lustSecondChallenge.text = act1Challenges.getLevelChallenge("Level 2-2", language);

            Text lustThirdChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(lustObject, "1-3 Panel"), "Stats"), "Challenge"), "Panel (4)"), "Text"));
            lustThirdChallenge.text = act1Challenges.getLevelChallenge("Level 2-3", language);

            Text lustClimaxChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(lustObject, "1-4 Panel"), "Stats"), "Challenge"), "Panel (6)"), "Text"));
            lustClimaxChallenge.text = act1Challenges.getLevelChallenge("Level 2-4", language);

            //Layer 3 - Gluttony
            Text gluttonyTitle = getTextfromGameObject(getGameObjectChild(gluttonyObject, "Text"));
            gluttonyTitle.text = language.currentLanguage.frontend.layer_gluttony;

            Text gluttonyFirstChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(gluttonyObject, "1-1 Panel"), "Stats"), "Challenge"), "Panel"), "Text"));
            gluttonyFirstChallenge.text = act1Challenges.getLevelChallenge("Level 3-1", language);

            Text gluttonySecondChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(gluttonyObject, "1-2 Panel"), "Stats"), "Challenge"), "Panel (2)"), "Text"));
            gluttonySecondChallenge.text = act1Challenges.getLevelChallenge("Level 3-2", language);

        }

        public void patchLevelSelectAct2(GameObject frontEnd, JsonParser language)
        {
            GameObject Act2Object = getGameObjectChild(getGameObjectChild(getGameObjectChild(frontEnd, "Level Select (Act II)"), "Scroll Rect"), "Contents");

            GameObject greedObject = getGameObjectChild(Act2Object, "Layer 4 Greed");
            GameObject wrathObject = getGameObjectChild(Act2Object, "Layer 5 Wrath");
            GameObject heresyObject = getGameObjectChild(Act2Object, "Layer 6 Heresy");

            Act2Strings act2Challenges = new Act2Strings();

            //Layer 4 - Greed
            Text greedTitle = getTextfromGameObject(getGameObjectChild(greedObject, "Text"));
            greedTitle.text = language.currentLanguage.frontend.layer_greed;


            Text greedFirstChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(greedObject, "1-1 Panel"), "Stats"), "Challenge"), "Panel"), "Text"));
            greedFirstChallenge.text = act2Challenges.getLevelChallenge("Level 4-1", language);

            Text greedSecondChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(greedObject, "1-2 Panel"), "Stats"), "Challenge"), "Panel (2)"), "Text"));
            greedSecondChallenge.text = act2Challenges.getLevelChallenge("Level 4-2", language);

            Text greedThirdChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(greedObject, "1-3 Panel"), "Stats"), "Challenge"), "Panel (4)"), "Text"));
            greedThirdChallenge.text = act2Challenges.getLevelChallenge("Level 4-3", language);

            Text greedClimaxChallenge = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(greedObject, "1-4 Panel"), "Stats"), "Challenge"), "Panel (6)"), "Text"));
            greedClimaxChallenge.text = act2Challenges.getLevelChallenge("Level 4-4", language);

            //Layer 5 - Wrath
            Text wrathTitle = getTextfromGameObject(getGameObjectChild(wrathObject, "Text"));
            wrathTitle.text = language.currentLanguage.frontend.layer_wrath;

            Text wraithSecretMissionText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(wrathObject, "Secret Mission"), "Text"));
            wraithSecretMissionText.text = language.currentLanguage.frontend.chapter_secretMission;

            //Layer 6 - Heresy
            Text heresyTitle = getTextfromGameObject(getGameObjectChild(heresyObject, "Text"));
            heresyTitle.text = language.currentLanguage.frontend.layer_heresy;

        }

        public void patchLevelSelectPrime(GameObject frontEnd, JsonParser jsonParser)
        {
            GameObject primeObject = getGameObjectChild(getGameObjectChild(frontEnd, "Level Select (Prime)"), "Prime Sanctums");
            Text primeTitle = getTextfromGameObject(getGameObjectChild(primeObject, "Text"));
            primeTitle.text = jsonParser.currentLanguage.frontend.layer_prime;

        }

        public MainMenu(GameObject frontEnd, JsonParser jsonParser)
        {
            this.patchMainMenu(frontEnd,jsonParser);
            this.patchDifficultyMenu(frontEnd, jsonParser);
            this.patchDifficultyDescriptors(frontEnd, jsonParser);

            this.patchChapterSelect(frontEnd,jsonParser);
            this.patchLevelSelectPrelude(frontEnd,jsonParser);
            this.patchLevelSelectAct1(frontEnd,jsonParser);
            this.patchLevelSelectAct2(frontEnd,jsonParser);
            this.patchLevelSelectPrime(frontEnd,jsonParser);
        }

    }
}
