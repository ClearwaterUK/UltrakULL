using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    class TutorialStrings
    {
        public string IntroFirstPage;

        //+ "Y/N ~ \n \n"
        //+ " AUDIO§         Ä½ \n"
        //+ " VIDEO§         Ä½ \n"
        //+ "MECHANICS§     Ä½ \n"
        //+ "+ CALIBRATION COMPLETE_ \n"
        //+ "+PRIMARY SETTINGS UPDATED_ \n"
        //+ "(±ASSIST OPTIONS_ AVAILABLE IN PAUSE MENU)½ \n"
        //+ "+ALL SYSTEMS OPERATIONAL_½ \n"
        //+ "LOADING STATUS UPDATE§ \n";

        public string IntroSecondPage;

        /*
         *  MACHINE ID:            V1½½
            LOCATION:              APPROACHING HELL½½@
            CURRENT OBJECTIVE:     FIND A WEAPON½½

            *MANKIND IS DEAD._½½
            *BLOOD IS FUEL._½½
            *HELL IS FULL._½½&
         */

        public static string GetMessage(string inputMessage, string inputMessage2, string input)
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

        public void PatchCalibrationWindows(ref GameObject canvasObj)
        {
            try
            {
                GameObject calibrationAudioWindow = GetGameObjectChild(GetGameObjectChild(canvasObj, "Intro"), "Audio Calibration");
                GameObject calibrationAudioWindowWarning = GetGameObjectChild(calibrationAudioWindow, "Warning");
                GameObject calibrationVideoWindow = GetGameObjectChild(GetGameObjectChild(canvasObj, "Intro"), "Video Calibration");
                GameObject calibrationMechanicsWindow = GetGameObjectChild(GetGameObjectChild(canvasObj, "Intro"), "Difficulty Select");
                GameObject calibrationControllerWindow = GetGameObjectChild(GetGameObjectChild(canvasObj, "Intro"), "Auto-Aim Settings");

                //Audio
                TextMeshProUGUI calibrationAudioTitle = GetTextMeshProUGUI(GetGameObjectChild(calibrationAudioWindow, "Text"));
                calibrationAudioTitle.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationTitle;

                TextMeshProUGUI calibrationAudioMaster = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(calibrationAudioWindow, "Master Volume (1)"), "Text"));
                calibrationAudioMaster.text = LanguageManager.CurrentLanguage.options.audio_globalVolume;

                TextMeshProUGUI calibrationAudioMusic = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(calibrationAudioWindow, "Music Volume (1)"), "Text"));
                calibrationAudioMusic.text = LanguageManager.CurrentLanguage.options.audio_musicVolume;

                TextMeshProUGUI calibrationAudioDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(calibrationAudioWindow, "Bone (1)"), "Text"));
                calibrationAudioDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;
                
                TextMeshProUGUI calibrationAudioDoneAlt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(calibrationAudioWindow, "Done"), "Text"));
                calibrationAudioDoneAlt.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Audio warning
                TextMeshProUGUI calibrationAudioWarningPrompt = GetTextMeshProUGUI(GetGameObjectChild(calibrationAudioWindowWarning, "Text"));
                calibrationAudioWarningPrompt.text =
                    "<color=red>" + LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarning1 +"</color>" + "\n\n"
                     + LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarning2 + "\n\n" +
                     LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarning3;

                TextMeshProUGUI calibrationAudioWarningPromptYes = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(calibrationAudioWindowWarning, "Done (1)"), "Text"));
                calibrationAudioWarningPromptYes.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarningPromptYes;

                TextMeshProUGUI calibrationAudioWarningPromptNo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(calibrationAudioWindowWarning, "Done (2)"), "Text"));
                calibrationAudioWarningPromptNo.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarningPromptNo;

                //Video
                TextMeshProUGUI calibrationVideoTitle = GetTextMeshProUGUI(GetGameObjectChild(calibrationVideoWindow, "Text"));
                calibrationVideoTitle.text = LanguageManager.CurrentLanguage.tutorial.tutorial_videoCalibrationTitle;

                TextMeshProUGUI calibrationVideoPcDescription = GetTextMeshProUGUI(GetGameObjectChild(calibrationVideoWindow, "Text (1)"));
                calibrationVideoPcDescription.text = LanguageManager.CurrentLanguage.tutorial.tutorial_videoCalibrationPcDescription;

                TextMeshProUGUI calibrationVideoPsxDescription = GetTextMeshProUGUI(GetGameObjectChild(calibrationVideoWindow, "Text (2)"));
                calibrationVideoPsxDescription.text = LanguageManager.CurrentLanguage.tutorial.tutorial_videoCalibrationPsxDescription;

                //Mechanics (difficulty)
                Text calibrationMechanicsTitle = GetTextfromGameObject(GetGameObjectChild(calibrationMechanicsWindow, "Title"));
                calibrationMechanicsTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_title + "--";

                Text calibrationMechanicsEasy = GetTextfromGameObject(GetGameObjectChild(calibrationMechanicsWindow, "Easy"));
                calibrationMechanicsEasy.text = LanguageManager.CurrentLanguage.frontend.difficulty_easy;

                Text calibrationMechanicsMedium = GetTextfromGameObject(GetGameObjectChild(calibrationMechanicsWindow, "Normal"));
                calibrationMechanicsMedium.text = LanguageManager.CurrentLanguage.frontend.difficulty_normal;

                Text calibrationMechanicsHard = GetTextfromGameObject(GetGameObjectChild(calibrationMechanicsWindow, "Hard"));
                calibrationMechanicsHard.text = LanguageManager.CurrentLanguage.frontend.difficulty_hard;

                Text calibrationMechanicsHarmless = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationMechanicsWindow, "Casual Easy"), "Name"));
                calibrationMechanicsHarmless.text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;

                Text calibrationMechanicsLenient = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationMechanicsWindow, "Casual Hard"), "Name"));
                calibrationMechanicsLenient.text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;

                Text calibrationMechanicsStandard = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationMechanicsWindow, "Standard"), "Name"));
                calibrationMechanicsStandard.text = LanguageManager.CurrentLanguage.frontend.difficulty_standard;

                Text calibrationMechanicsViolent = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationMechanicsWindow, "Violent"), "Name"));
                calibrationMechanicsViolent.text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

                Text calibrationMechanicsBrutal = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationMechanicsWindow, "Brutal"), "Name"));
                calibrationMechanicsBrutal.text = LanguageManager.CurrentLanguage.frontend.difficulty_brutal;

                Text calibrationMechanicsUmd = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationMechanicsWindow, "V1 Must Die"), "Name"));
                calibrationMechanicsUmd.text = LanguageManager.CurrentLanguage.frontend.difficulty_umd;

                //Harmless info
                GameObject calibrationHarmlessInfo = GetGameObjectChild(calibrationMechanicsWindow, "Harmless Info");
                Text harmlessTitle = GetTextfromGameObject(GetGameObjectChild(calibrationHarmlessInfo, "Title (1)"));
                harmlessTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;

                //Harmless descriptor
                Text harmlessDescriptor = GetTextfromGameObject(GetGameObjectChild(calibrationHarmlessInfo, "Text"));
                harmlessDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription2
                    + "\n\n"
                    + "<color=lime>" + LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription3 + "</color>";

                //Lenient title
                GameObject calibrationLenientInfo = GetGameObjectChild(calibrationMechanicsWindow, "Lenient Info");
                Text lenientTitle = GetTextfromGameObject(GetGameObjectChild(calibrationLenientInfo, "Title (1)"));
                lenientTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;

                //Lenient descriptor
                Text lenientDescriptor = GetTextfromGameObject(GetGameObjectChild(calibrationLenientInfo, "Text"));
                lenientDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription2
                    + "\n\n"
                    + "<color=yellow>" + LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription3 + "</color>";

                //Standard title
                GameObject calibrationStandardInfo = GetGameObjectChild(calibrationMechanicsWindow, "Standard Info");
                Text standardTitle = GetTextfromGameObject(GetGameObjectChild(calibrationStandardInfo, "Title (1)"));
                standardTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_standard;

                //Standard descriptor
                Text standardDescriptor = GetTextfromGameObject(GetGameObjectChild(calibrationStandardInfo, "Text"));
                standardDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription2
                    + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription3 + "</color>";

                //Violent title
                GameObject calibrationViolentInfo = GetGameObjectChild(calibrationMechanicsWindow, "Violent Info");
                Text violentTitle = GetTextfromGameObject(GetGameObjectChild(calibrationViolentInfo, "Title (1)"));
                violentTitle.text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

                //Violent descriptor
                Text violentDescriptor = GetTextfromGameObject(GetGameObjectChild(calibrationViolentInfo, "Text"));
                violentDescriptor.text =
                    LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription2
                    + "\n\n"
                    + "<color=red>" + LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription3 + "</color>";

                Text underConstructionText = GetTextfromGameObject(GetGameObjectChild(calibrationMechanicsWindow, "Under Construction"));
                underConstructionText.text = LanguageManager.CurrentLanguage.frontend.difficulty_underConstruction;

                //Controller/autoaim settings
                TextMeshProUGUI calibrationControllerTitle = GetTextMeshProUGUI(GetGameObjectChild(calibrationControllerWindow, "Text"));
                calibrationControllerTitle.text = "! " + LanguageManager.CurrentLanguage.tutorial.tutorial_controllerCalibrationTitle + " !";

                TextMeshProUGUI calibrationControllerSubtitle = GetTextMeshProUGUI(GetGameObjectChild(calibrationControllerWindow, "Text (1)"));
                calibrationControllerSubtitle.text = LanguageManager.CurrentLanguage.tutorial.tutorial_controllerCalibrationSubtitle;

                TextMeshProUGUI calibrationControllerAutoAimToggle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(calibrationControllerWindow, "Auto Aim (1)"),"Text (1)"));
                calibrationControllerAutoAimToggle.text = LanguageManager.CurrentLanguage.options.assists_autoAim;

                TextMeshProUGUI calibrationControllerAutoAimPercent = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(calibrationControllerWindow, "Auto Aim Amount (1)"),"Text (1)"));
                calibrationControllerAutoAimPercent.text = LanguageManager.CurrentLanguage.options.assists_autoAimPercent;

                TextMeshProUGUI calibrationControllerAutoAimReminder = GetTextMeshProUGUI(GetGameObjectChild(calibrationControllerWindow, "Text (2)"));
                calibrationControllerAutoAimReminder.text = LanguageManager.CurrentLanguage.tutorial.tutorial_controllerCalibrationTooltip;

                //Tooltip
                GameObject assistTip = GetGameObjectChild(calibrationMechanicsWindow, "Assist Tip");
                Text assistTipText = GetTextfromGameObject(assistTip);
                assistTipText.text = LanguageManager.CurrentLanguage.frontend.difficulty_tweakReminder;
            }
            catch(Exception e)
            {
                Logging.Error("Failed to patch tutorial panels");
                Logging.Error(e.ToString());
            }
        }

        public TutorialStrings(ref GameObject canvasObj)
        {
            this.IntroFirstPage =
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

            this.IntroSecondPage =
            LanguageManager.CurrentLanguage.tutorial.tutorial_introID1 + ":     " + LanguageManager.CurrentLanguage.tutorial.tutorial_introID2 + "½½ \n"
            + LanguageManager.CurrentLanguage.tutorial.tutorial_introLocation1 + ":     " + LanguageManager.CurrentLanguage.tutorial.tutorial_introLocation2 + "@½½ \n"
            + LanguageManager.CurrentLanguage.tutorial.tutorial_introObjective1 + ":    " + LanguageManager.CurrentLanguage.tutorial.tutorial_introObjective2 + "½½ \n\n"
            + "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed1 + "_½½ \n"
            + "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed2 + "_½½ \n"
            + "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed3 + "_½½&";

            PatchCalibrationWindows(ref canvasObj);

        }
    }
}
