﻿using System;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class TutorialStrings
    {
        public static void PatchCalibrationWindows(ref GameObject canvasObj)
        {
            try
            {
                GameObject calibrationAudioWindow = GetGameObjectChild(GetGameObjectChild(canvasObj, "Intro"), "Audio Calibration");
                GameObject calibrationAudioWindowWarning = GetGameObjectChild(calibrationAudioWindow, "Warning");
                GameObject calibrationVideoWindow = GetGameObjectChild(GetGameObjectChild(canvasObj, "Intro"), "Video Calibration");
                GameObject calibrationMechanicsWindow = GetGameObjectChild(GetGameObjectChild(canvasObj, "Intro"), "Difficulty Select");
                GameObject calibrationControllerWindow = GetGameObjectChild(GetGameObjectChild(canvasObj, "Intro"), "Auto-Aim Settings");

                //Audio
                Text calibrationAudioTitle = GetTextfromGameObject(GetGameObjectChild(calibrationAudioWindow, "Text"));
                calibrationAudioTitle.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationTitle;

                Text calibrationAudioMaster = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationAudioWindow, "Master Volume (1)"), "Text"));
                calibrationAudioMaster.text = LanguageManager.CurrentLanguage.options.audio_globalVolume;

                Text calibrationAudioMusic = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationAudioWindow, "Music Volume (1)"), "Text"));
                calibrationAudioMusic.text = LanguageManager.CurrentLanguage.options.audio_musicVolume;

                Text calibrationAudioDone = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationAudioWindow, "Bone (1)"), "Text"));
                calibrationAudioDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;
                
                Text calibrationAudioDoneAlt = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationAudioWindow, "Done"), "Text"));
                calibrationAudioDoneAlt.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Audio warning
                Text calibrationAudioWarningPrompt = GetTextfromGameObject(GetGameObjectChild(calibrationAudioWindowWarning, "Text"));
                calibrationAudioWarningPrompt.text =
                    "<color=red>" + LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarning1 +"</color>" + "\n\n"
                     + LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarning2 + "\n\n" +
                     LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarning3;

                Text calibrationAudioWarningPromptYes = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationAudioWindowWarning, "Done (1)"), "Text"));
                calibrationAudioWarningPromptYes.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarningPromptYes;

                Text calibrationAudioWarningPromptNo = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationAudioWindowWarning, "Done (2)"), "Text"));
                calibrationAudioWarningPromptNo.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarningPromptNo;

                //Video
                Text calibrationVideoTitle = GetTextfromGameObject(GetGameObjectChild(calibrationVideoWindow, "Text"));
                calibrationVideoTitle.text = LanguageManager.CurrentLanguage.tutorial.tutorial_videoCalibrationTitle;

                Text calibrationVideoPcDescription = GetTextfromGameObject(GetGameObjectChild(calibrationVideoWindow, "Text (1)"));
                calibrationVideoPcDescription.text = LanguageManager.CurrentLanguage.tutorial.tutorial_videoCalibrationPcDescription;

                Text calibrationVideoPsxDescription = GetTextfromGameObject(GetGameObjectChild(calibrationVideoWindow, "Text (2)"));
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
                Text calibrationControllerTitle = GetTextfromGameObject(GetGameObjectChild(calibrationControllerWindow, "Text"));
                calibrationControllerTitle.text = "! " + LanguageManager.CurrentLanguage.tutorial.tutorial_controllerCalibrationTitle + " !";

                Text calibrationControllerSubtitle = GetTextfromGameObject(GetGameObjectChild(calibrationControllerWindow, "Text (1)"));
                calibrationControllerSubtitle.text = LanguageManager.CurrentLanguage.tutorial.tutorial_controllerCalibrationSubtitle;

                Text calibrationControllerAutoAimToggle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationControllerWindow, "Auto Aim (1)"),"Text (1)"));
                calibrationControllerAutoAimToggle.text = LanguageManager.CurrentLanguage.options.assists_autoAim;

                Text calibrationControllerAutoAimPercent = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(calibrationControllerWindow, "Auto Aim Amount (1)"),"Text (1)"));
                calibrationControllerAutoAimPercent.text = LanguageManager.CurrentLanguage.options.assists_autoAimPercent;

                Text calibrationControllerAutoAimReminder = GetTextfromGameObject(GetGameObjectChild(calibrationControllerWindow, "Text (2)"));
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
    }
}
