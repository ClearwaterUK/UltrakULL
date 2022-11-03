using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    class TutorialStrings
    {
        public string introFirstPage;

        //+ "Y/N ~ \n \n"
        //+ " AUDIO§         Ä½ \n"
        //+ " VIDEO§         Ä½ \n"
        //+ "MECHANICS§     Ä½ \n"
        //+ "+ CALIBRATION COMPLETE_ \n"
        //+ "+PRIMARY SETTINGS UPDATED_ \n"
        //+ "(±ASSIST OPTIONS_ AVAILABLE IN PAUSE MENU)½ \n"
        //+ "+ALL SYSTEMS OPERATIONAL_½ \n"
        //+ "LOADING STATUS UPDATE§ \n";

        public string introSecondPage;

        /*
         *  MACHINE ID:            V1½½
            LOCATION:              APPROACHING HELL½½@
            CURRENT OBJECTIVE:     FIND A WEAPON½½

            *MANKIND IS DEAD._½½
            *BLOOD IS FUEL._½½
            *HELL IS FULL._½½&
         */

        public string getMessage(string inputMessage, string inputMessage2, string input)
        {

            string fullMessage = inputMessage + inputMessage2;

            if (fullMessage.Contains("PUNCH"))
            {
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_punch1 + " <color=orange>" + input + "</color> " + LanguageManager.CurrentLanguage.tutorial.tutorial_punch2);
            }
            else if (fullMessage.Contains("SLIDE"))
            {
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_slide1 + " <color=orange>" + input + "</color> " + LanguageManager.CurrentLanguage.tutorial.tutorial_slide2);
            }
            else if (fullMessage.Contains("DASH"))
            {
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_dash1 + "<color=orange>" + input + "</color> " + LanguageManager.CurrentLanguage.tutorial.tutorial_dash2 + "\n" + LanguageManager.CurrentLanguage.tutorial.tutorial_dash3);
            }
            else if (fullMessage.Contains("HEALTH"))
            {
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_health1 + "\n" + LanguageManager.CurrentLanguage.tutorial.tutorial_health2);
            }
            else if (fullMessage.Contains("JUMP"))
            {
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_walljump);
            }
            else if (fullMessage.Contains("SHOCKWAVE"))
            {
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_shockwave1 + " <color=orange>" + input + "</color> " + LanguageManager.CurrentLanguage.tutorial.tutorial_shockwave2 + "\n" + LanguageManager.CurrentLanguage.tutorial.tutorial_shockwave3);
            }
            else if (fullMessage.Contains("ORBS"))
            {
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_orb1 + "\n" + LanguageManager.CurrentLanguage.tutorial.tutorial_orb2);
            }
            else
            {
                return ("Unimplemented tutorial string");
            }
        }

        //IMPORTANT CHARACTERS TO USE:
        // # - 3 repeating dots
        // § - Indent
        // + - Lime green text
        // * - Red text
        // ± - Blue text
        // _ - Close color
        // ½ - Half second pause
        // @ - Begins to fade out intro music
        // ~ - Wait for recalibration input
        // & - Ends intro text and loads the tutorial
        // β - Recalibration yes (automatically shows keyboard or controller button depending on what the player is using)
        // δ - Recalibration no (automatically shows keyboard or controller button depending on what the player is using)

        public void patchCalibrationWindows()
        {
            try
            {
                GameObject canvas = getInactiveRootObject("Canvas");

                GameObject calibrationAudioWindow = getGameObjectChild(getGameObjectChild(canvas, "Intro"), "Audio Calibration");
                GameObject calibrationAudioWindowWarning = getGameObjectChild(calibrationAudioWindow, "Warning");
                GameObject calibrationVideoWindow = getGameObjectChild(getGameObjectChild(canvas, "Intro"), "Video Calibration");
                GameObject calibrationMechanicsWindow = getGameObjectChild(getGameObjectChild(canvas, "Intro"), "Difficulty Select");
                GameObject calibrationControllerWindow = getGameObjectChild(getGameObjectChild(canvas, "Intro"), "Auto-Aim Settings");

                //Audio
                Text calibrationAudioTitle = getTextfromGameObject(getGameObjectChild(calibrationAudioWindow, "Text"));
                calibrationAudioTitle.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationTitle;

                Text calibrationAudioMaster = getTextfromGameObject(getGameObjectChild(getGameObjectChild(calibrationAudioWindow, "Master Volume (1)"), "Text"));
                calibrationAudioMaster.text = LanguageManager.CurrentLanguage.options.audio_globalVolume;

                Text calibrationAudioMusic = getTextfromGameObject(getGameObjectChild(getGameObjectChild(calibrationAudioWindow, "Music Volume (1)"), "Text"));
                calibrationAudioMusic.text = LanguageManager.CurrentLanguage.options.audio_musicVolume;

                Text calibrationAudioDone = getTextfromGameObject(getGameObjectChild(getGameObjectChild(calibrationAudioWindow, "Bone (1)"), "Text"));
                calibrationAudioDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Audio warning
                Text calibrationAudioWarningPrompt = getTextfromGameObject(getGameObjectChild(calibrationAudioWindowWarning, "Text"));
                calibrationAudioWarningPrompt.text =
                    "<color=red>" + LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarning1 +"</color>" + "\n\n"
                     + LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarning2 + "\n\n" +
                     LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarning3;

                Text calibrationAudioWarningPromptYes = getTextfromGameObject(getGameObjectChild(getGameObjectChild(calibrationAudioWindowWarning, "Done (1)"), "Text"));
                calibrationAudioWarningPromptYes.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarningPromptYes;

                Text calibrationAudioWarningPromptNo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(calibrationAudioWindowWarning, "Done (2)"), "Text"));
                calibrationAudioWarningPromptNo.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarningPromptNo;

                //Video
                Text calibrationVideoTitle = getTextfromGameObject(getGameObjectChild(calibrationVideoWindow, "Text"));
                calibrationVideoTitle.text = LanguageManager.CurrentLanguage.tutorial.tutorial_videoCalibrationTitle;

                Text calibrationVideoPcDescription = getTextfromGameObject(getGameObjectChild(calibrationVideoWindow, "Text (1)"));
                calibrationVideoPcDescription.text = LanguageManager.CurrentLanguage.tutorial.tutorial_videoCalibrationPcDescription;

                Text calibrationVideoPsxDescription = getTextfromGameObject(getGameObjectChild(calibrationVideoWindow, "Text (2)"));
                calibrationVideoPsxDescription.text = LanguageManager.CurrentLanguage.tutorial.tutorial_videoCalibrationPsxDescription;

                //Mechanics (difficulty)
                Text calibrationMechanicsTitle = getTextfromGameObject(getGameObjectChild(calibrationMechanicsWindow, "Title"));
                calibrationMechanicsTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_title + "--";

                Text calibrationMechanicsEasy = getTextfromGameObject(getGameObjectChild(calibrationMechanicsWindow, "Easy"));
                calibrationMechanicsEasy.text = LanguageManager.CurrentLanguage.frontend.difficulty_easy;

                Text calibrationMechanicsMedium = getTextfromGameObject(getGameObjectChild(calibrationMechanicsWindow, "Normal"));
                calibrationMechanicsMedium.text = LanguageManager.CurrentLanguage.frontend.difficulty_normal;

                Text calibrationMechanicsHard = getTextfromGameObject(getGameObjectChild(calibrationMechanicsWindow, "Hard"));
                calibrationMechanicsHard.text = LanguageManager.CurrentLanguage.frontend.difficulty_hard;

                Text calibrationMechanicsHarmless = getTextfromGameObject(getGameObjectChild(getGameObjectChild(calibrationMechanicsWindow, "Casual Easy"), "Name"));
                calibrationMechanicsHarmless.text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;

                Text calibrationMechanicsLenient = getTextfromGameObject(getGameObjectChild(getGameObjectChild(calibrationMechanicsWindow, "Casual Hard"), "Name"));
                calibrationMechanicsLenient.text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;

                Text calibrationMechanicsStandard = getTextfromGameObject(getGameObjectChild(getGameObjectChild(calibrationMechanicsWindow, "Standard"), "Name"));
                calibrationMechanicsStandard.text = LanguageManager.CurrentLanguage.frontend.difficulty_standard;

                Text calibrationMechanicsViolent = getTextfromGameObject(getGameObjectChild(getGameObjectChild(calibrationMechanicsWindow, "Violent"), "Name"));
                calibrationMechanicsViolent.text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

                Text calibrationMechanicsBrutal = getTextfromGameObject(getGameObjectChild(getGameObjectChild(calibrationMechanicsWindow, "Brutal"), "Name"));
                calibrationMechanicsBrutal.text = LanguageManager.CurrentLanguage.frontend.difficulty_brutal;

                Text calibrationMechanicsUMD = getTextfromGameObject(getGameObjectChild(getGameObjectChild(calibrationMechanicsWindow, "V1 Must Die"), "Name"));
                calibrationMechanicsUMD.text = LanguageManager.CurrentLanguage.frontend.difficulty_umd;

                //Harmless info
                GameObject calibrationHarmlessInfo = getGameObjectChild(calibrationMechanicsWindow, "Harmless Info");
                Text harmlessTitle = getTextfromGameObject(getGameObjectChild(calibrationHarmlessInfo, "Title (1)"));
                harmlessTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;

                //Harmless descriptor
                Text harmlessDescriptor = getTextfromGameObject(getGameObjectChild(calibrationHarmlessInfo, "Text"));
                harmlessDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription2
                    + "\n\n"
                    + "<color=lime>" + LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription3 + "</color>";

                //Lenient title
                GameObject calibrationLenientInfo = getGameObjectChild(calibrationMechanicsWindow, "Lenient Info");
                Text lenientTitle = getTextfromGameObject(getGameObjectChild(calibrationLenientInfo, "Title (1)"));
                lenientTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;

                //Lenient descriptor
                Text lenientDescriptor = getTextfromGameObject(getGameObjectChild(calibrationLenientInfo, "Text"));
                lenientDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription2
                    + "\n\n"
                    + "<color=yellow>" + LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription3 + "</color>";

                //Standard title
                GameObject calibrationStandardInfo = getGameObjectChild(calibrationMechanicsWindow, "Standard Info");
                Text standardTitle = getTextfromGameObject(getGameObjectChild(calibrationStandardInfo, "Title (1)"));
                standardTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_standard;

                //Standard descriptor
                Text standardDescriptor = getTextfromGameObject(getGameObjectChild(calibrationStandardInfo, "Text"));
                standardDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription2
                    + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription3 + "</color>";

                //Violent title
                GameObject calibrationViolentInfo = getGameObjectChild(calibrationMechanicsWindow, "Violent Info");
                Text violentTitle = getTextfromGameObject(getGameObjectChild(calibrationViolentInfo, "Title (1)"));
                violentTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

                //Violent descriptor
                Text violentDescriptor = getTextfromGameObject(getGameObjectChild(calibrationViolentInfo, "Text"));
                violentDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription2
                    + "\n\n"
                    + "<color=red>" + LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription3 + "</color>";

                Text underConstructionText = getTextfromGameObject(getGameObjectChild(calibrationMechanicsWindow, "Under Construction"));
                underConstructionText.text = LanguageManager.CurrentLanguage.frontend.difficulty_underConstruction;

                //Controller/autoaim settings
                Text calibrationControllerTitle = getTextfromGameObject(getGameObjectChild(calibrationControllerWindow, "Text"));
                calibrationControllerTitle.text = "! " + LanguageManager.CurrentLanguage.tutorial.tutorial_controllerCalibrationTitle + " !";

                Text calibrationControllerSubtitle = getTextfromGameObject(getGameObjectChild(calibrationControllerWindow, "Text (1)"));
                calibrationControllerSubtitle.text = LanguageManager.CurrentLanguage.tutorial.tutorial_controllerCalibrationSubtitle;

                Text calibrationControllerAutoAimToggle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(calibrationControllerWindow, "Auto Aim (1)"),"Text (1)"));
                calibrationControllerAutoAimToggle.text = LanguageManager.CurrentLanguage.options.assists_autoAim;

                Text calibrationControllerAutoAimPercent = getTextfromGameObject(getGameObjectChild(getGameObjectChild(calibrationControllerWindow, "Auto Aim Amount (1)"),"Text (1)"));
                calibrationControllerAutoAimPercent.text = LanguageManager.CurrentLanguage.options.assists_autoAimPercent;

                Text calibrationControllerAutoAimReminder = getTextfromGameObject(getGameObjectChild(calibrationControllerWindow, "Text (2)"));
                calibrationControllerAutoAimReminder.text = LanguageManager.CurrentLanguage.tutorial.tutorial_controllerCalibrationTooltip;

                //Tooltip
                GameObject assistTip = getGameObjectChild(calibrationMechanicsWindow, "Assist Tip");
                Text assistTipText = getTextfromGameObject(assistTip);
                assistTipText.text = LanguageManager.CurrentLanguage.frontend.difficulty_tweakReminder;
            }
            catch(Exception e)
            {

            }

        }

        public TutorialStrings()
        {
            this.introFirstPage =
                LanguageManager.CurrentLanguage.tutorial.tutorial_introStartup1 + "#" + LanguageManager.CurrentLanguage.tutorial.tutorial_introStartup2 + "½ \n\n"

                + LanguageManager.CurrentLanguage.tutorial.tutorial_introVersion1 + "# \n"
                + "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_introVersion2 + "_½ \n\n"

                + LanguageManager.CurrentLanguage.tutorial.tutorial_introCalibration1 + "#\n"
                + "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_introCalibration2 + "_\n\n"

                + LanguageManager.CurrentLanguage.tutorial.tutorial_recalibrationPrompt + "\n β/δ~ \n"

                + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationAudio + "§Ä½ \n"
                + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationVideo + "§Ä½ \n"
                + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationMechanics + "§Ä½ \n\n"

                + "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationComplete1 + "_ \n"
                + "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationComplete2 + "_ \n"
                + "(±" + LanguageManager.CurrentLanguage.tutorial.tutorial_introReminder + " _)½ \n\n"

                + "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_systemsOperational + "_½ \n"
                + LanguageManager.CurrentLanguage.tutorial.tutorial_introLoadStatus + "§";

            this.introSecondPage =
            LanguageManager.CurrentLanguage.tutorial.tutorial_introID1 + ":     " + LanguageManager.CurrentLanguage.tutorial.tutorial_introID2 + "½½ \n"
            + LanguageManager.CurrentLanguage.tutorial.tutorial_introLocation1 + ":     " + LanguageManager.CurrentLanguage.tutorial.tutorial_introLocation2 + "@½½ \n"
            + LanguageManager.CurrentLanguage.tutorial.tutorial_introObjective1 + ":    " + LanguageManager.CurrentLanguage.tutorial.tutorial_introObjective2 + "½½ \n\n"
            + "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed1 + "_½½ \n"
            + "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed2 + "_½½ \n"
            + "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed3 + "_½½&";


            patchCalibrationWindows();

        }
    }
}
