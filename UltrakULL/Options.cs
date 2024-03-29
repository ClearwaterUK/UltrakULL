﻿using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    class Options
    {
        private GameObject optionsMenu;

        private void PatchGeneralOptions(GameObject generalOptions)
        {
            //General options
            TextMeshProUGUI generalText = GetTextMeshProUGUI(GetGameObjectChild(generalOptions, "Text"));
            generalText.text = "--" + LanguageManager.CurrentLanguage.options.category_general + "--";

            GameObject generalContent = GetGameObjectChild(GetGameObjectChild(generalOptions, "Scroll Rect (1)"), "Contents");

            TextMeshProUGUI mouseSensitivityText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(generalContent, "Mouse Sensitivity"), "Text"));
            mouseSensitivityText.text = LanguageManager.CurrentLanguage.options.general_mouseSensitivity;

            TextMeshProUGUI invertXAxisText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(generalContent, "Invert Axis"), "Text"));
            invertXAxisText.text = LanguageManager.CurrentLanguage.options.general_xInversion;

            TextMeshProUGUI invertYAxisText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(generalContent, "Invert Axis"), "Text (1)"));
            invertYAxisText.text = LanguageManager.CurrentLanguage.options.general_yInversion;

            TextMeshProUGUI fovText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(generalContent, "FOV"), "Text"));
            fovText.text = LanguageManager.CurrentLanguage.options.general_fieldOfVision;

            TextMeshProUGUI weaponPosText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(generalContent, "Weapon Position"), "Text"));
            weaponPosText.text = LanguageManager.CurrentLanguage.options.general_weaponPosition;
            
            //Have to patch directly from the Dropdown.OptionData list.
            GameObject weaponPosList = GetGameObjectChild(GetGameObjectChild(generalContent, "Weapon Position"), "Dropdown");
            TMP_Dropdown weaponPosDropdown = weaponPosList.GetComponent<TMP_Dropdown>();
            List<TMP_Dropdown.OptionData> weaponPosListText = weaponPosDropdown.options;
            weaponPosListText[0].text = LanguageManager.CurrentLanguage.options.general_weaponPositionRight;
            weaponPosListText[1].text = LanguageManager.CurrentLanguage.options.general_weaponPositionMiddle;
            weaponPosListText[2].text = LanguageManager.CurrentLanguage.options.general_weaponPositionLeft;

            TextMeshProUGUI rememberWeaponText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(generalContent, "Variation Memory"), "Text"));
            rememberWeaponText.text = LanguageManager.CurrentLanguage.options.general_rememberWeapon;

            TextMeshProUGUI screenshakeText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(generalContent, "Screenshake"), "Text"));
            screenshakeText.text = LanguageManager.CurrentLanguage.options.general_screenShake;

            SliderValueToText screenshakeSlider = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(generalContent, "Screenshake"), "Button"), "Slider (1)"), "Text (2)").GetComponentInChildren<SliderValueToText>();
            screenshakeSlider.ifMin = LanguageManager.CurrentLanguage.options.general_screenShakeMinimum;
            screenshakeSlider.ifMax = LanguageManager.CurrentLanguage.options.general_screenShakeMaximum;

            TextMeshProUGUI controllerRumbleText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(generalContent, "Controller Rumble"), "Text"));
            controllerRumbleText.text = LanguageManager.CurrentLanguage.options.general_controllerRumble;
            
            TextMeshProUGUI controllerRumbleTextCustomize =  GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(generalContent, "Controller Rumble"),"Select"), "Text"));
            controllerRumbleTextCustomize.text = LanguageManager.CurrentLanguage.options.general_controllerRumbleCustomize;
            
            TextMeshProUGUI restartWarningText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(generalContent, "Restart Warning"), "Text"));
            restartWarningText.text = LanguageManager.CurrentLanguage.options.general_restartWarning;

            TextMeshProUGUI cameraTiltText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(generalContent, "Camera Tilt"), "Text"));
            cameraTiltText.text = LanguageManager.CurrentLanguage.options.general_cameraTilt;

            TextMeshProUGUI discordText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(generalContent, "Discord Integration"), "Text"));
            discordText.text = LanguageManager.CurrentLanguage.options.general_discordRpc;

            TextMeshProUGUI seasonEventText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(generalContent, "Seasonal Events"), "Text"));
            seasonEventText.text = LanguageManager.CurrentLanguage.options.general_seasonalEvent;
            
            TextMeshProUGUI levelLeaderboardsText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(generalContent, "Level Leaderboards"), "Text"));
            levelLeaderboardsText.text = LanguageManager.CurrentLanguage.options.general_levelLeaderboards;
        }
        private void PatchControlOptions(GameObject optionsMenu)
        {
                //THIS NEEDS TO BE COMPLETELY REDONE.
            
                //Control options
                TextMeshProUGUI controlText = GetTextMeshProUGUI(GetGameObjectChild(optionsMenu, "Text (1)"));
                controlText.text = "-- "+ LanguageManager.CurrentLanguage.options.category_controls + " --";

                GameObject controlContent = GetGameObjectChild(GetGameObjectChild(optionsMenu, "Scroll Rect"), "Contents");

                TextMeshProUGUI weaponsTitle = GetTextMeshProUGUI(controlContent.transform.GetChild(0).gameObject);
                weaponsTitle.text = "-- " + LanguageManager.CurrentLanguage.options.controls_weapons +" --";
                
                GameObject mouseWheelContent = GetGameObjectChild(controlContent, "Mouse Wheel to Change Weapon");
                TextMeshProUGUI changeWeaponMouseWheel = GetTextMeshProUGUI(GetGameObjectChild(mouseWheelContent, "Text"));
                changeWeaponMouseWheel.text = LanguageManager.CurrentLanguage.options.controls_mouseWheelToChangeWeapon;

                TextMeshProUGUI weaponScrollType = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(controlContent, "Weapon Scroll Type"),"Text (1)"));
                weaponScrollType.text = LanguageManager.CurrentLanguage.options.controls_scrollType;
                
                //Dropdown here
                GameObject scrollTypeList = (GetGameObjectChild(GetGameObjectChild(controlContent, "Weapon Scroll Type"),"Dropdown (1)"));

                TMP_Dropdown scrollTypeDropdown = scrollTypeList.GetComponent<TMP_Dropdown>();
                List<TMP_Dropdown.OptionData> scrollTypeDropdownText = scrollTypeDropdown.options;
                scrollTypeDropdownText[0].text = LanguageManager.CurrentLanguage.options.controls_scrollTypeWeapons;
                scrollTypeDropdownText[1].text = LanguageManager.CurrentLanguage.options.controls_scrollTypeVariations;
                scrollTypeDropdownText[2].text = LanguageManager.CurrentLanguage.options.controls_scrollTypeAll;
                
                TextMeshProUGUI reverseScrollDirection = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(controlContent, "Scroll Reversed"),"Text"));
                reverseScrollDirection.text = LanguageManager.CurrentLanguage.options.controls_reverseScroll;
                
                //Bindings
                TextMeshProUGUI bindingsTitle = GetTextMeshProUGUI(controlContent.transform.GetChild(4).gameObject);
                bindingsTitle.text = "-- " + LanguageManager.CurrentLanguage.options.controls_bindings + " --";
                
        }
        private void PatchGraphicsOptions(GameObject optionsMenu)
        {
                //Order of elements have changed about
                //Graphics options
                TextMeshProUGUI graphicsText = GetTextMeshProUGUI(GetGameObjectChild(optionsMenu, "Text (1)"));
                graphicsText.text = "--"+ LanguageManager.CurrentLanguage.options.category_graphics+ "--";

                GameObject graphicsContent = GetGameObjectChild(GetGameObjectChild(optionsMenu, "Scroll Rect"), "Contents");

                TextMeshProUGUI resolutionText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Resolution"), "Text"));
                resolutionText.text = LanguageManager.CurrentLanguage.options.graphics_resolution;

                TextMeshProUGUI fullscreenText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "FullScreen"), "Text"));
                fullscreenText.text = LanguageManager.CurrentLanguage.options.graphics_fullscreen;

                TextMeshProUGUI fpslimitText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Framerate Limiter"), "Text"));
                fpslimitText.text = LanguageManager.CurrentLanguage.options.graphics_maxFps;

                GameObject fpsObject = GetGameObjectChild(GetGameObjectChild(graphicsContent, "Framerate Limiter"), "Dropdown");
                TMP_Dropdown fpsDropdown = fpsObject.GetComponent<TMP_Dropdown>();
                List<TMP_Dropdown.OptionData> fpsDropdownListText = fpsDropdown.options;
                fpsDropdownListText[0].text = LanguageManager.CurrentLanguage.options.graphics_maxFpsNone;
                fpsDropdownListText[1].text = LanguageManager.CurrentLanguage.options.graphics_maxFps2x;
                
                TextMeshProUGUI vsyncText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "VSync"), "Text"));
                vsyncText.text = LanguageManager.CurrentLanguage.options.graphics_vsync;
                
                TextMeshProUGUI gammaCorrectionText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Gamma Correction"), "Text"));
                gammaCorrectionText.text = "GAMMA_CORRECTION";
                
                TextMeshProUGUI psxFilterSettingsText = GetTextMeshProUGUI(GetGameObjectChild(graphicsContent, "Text (5)"));
                psxFilterSettingsText.text = "--"+ LanguageManager.CurrentLanguage.options.graphics_filters+"--";

                //(Not shown by default anymore, safe to get rid of?)
                //TextMeshProUGUI psxFilterSettingsDescription = GetTextMeshProUGUI(GetGameObjectChild(graphicsContent, "Text (6)"));
                //psxFilterSettingsDescription.text = LanguageManager.CurrentLanguage.options.graphics_filtersDescription;

                TextMeshProUGUI downscalingText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Pixelization"), "Text"));
                downscalingText.text = LanguageManager.CurrentLanguage.options.graphics_pixelisation;

                GameObject resolution = GetGameObjectChild(GetGameObjectChild(graphicsContent, "Pixelization"), "Dropdown (1)");
                TMP_Dropdown resolutionDropdown = resolution.GetComponent<TMP_Dropdown>();
                List<TMP_Dropdown.OptionData> resolutionDropdownListText = resolutionDropdown.options;

                resolutionDropdownListText[0].text = LanguageManager.CurrentLanguage.options.graphics_pixelisationNone;
                resolutionDropdownListText[1].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation720p;
                resolutionDropdownListText[2].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation480p;
                resolutionDropdownListText[3].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation360p;
                resolutionDropdownListText[4].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation240p;
                resolutionDropdownListText[5].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation144p;
                resolutionDropdownListText[6].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation36p;


                TextMeshProUGUI ditheringText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Dithering (1)"), "Text"));
                ditheringText.text = LanguageManager.CurrentLanguage.options.graphics_dithering;

                SliderValueToText ditheringSlider = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Dithering (1)"), "Button"),"Slider (2)"),"Text (3)").GetComponentInChildren<SliderValueToText>();
                ditheringSlider.ifMin = LanguageManager.CurrentLanguage.options.graphics_ditheringMinimum;

                TextMeshProUGUI textureWarpingText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Texture Warping (1)"), "Text"));
                textureWarpingText.text = LanguageManager.CurrentLanguage.options.graphics_textureWarping;

                TextMeshProUGUI vertexWarpingText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Vertex Warping"), "Text"));
                vertexWarpingText.text = LanguageManager.CurrentLanguage.options.graphics_vertexWarping;

                GameObject vertexWarping = GetGameObjectChild(GetGameObjectChild(graphicsContent, "Vertex Warping"),"Dropdown");
                TMP_Dropdown vertexWarpingDropdown = vertexWarping.GetComponent<TMP_Dropdown>();
                List<TMP_Dropdown.OptionData> vertexWarpingDropdownListText = vertexWarpingDropdown.options;

                vertexWarpingDropdownListText[0].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingNone;
                vertexWarpingDropdownListText[1].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingLight;
                vertexWarpingDropdownListText[2].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingMedium;
                vertexWarpingDropdownListText[3].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingStrong;
                vertexWarpingDropdownListText[4].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingVeryStrong;
                vertexWarpingDropdownListText[5].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingAbsurd;

                TextMeshProUGUI customColorPalette = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Custom Color Palette"), "Text"));
                customColorPalette.text = LanguageManager.CurrentLanguage.options.graphics_customColorPalette;

                Text customColorPaletteSelect = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Custom Color Palette"), "Select"),"Text"));
                customColorPaletteSelect.text = LanguageManager.CurrentLanguage.options.graphics_customColorPaletteSelect;

                TextMeshProUGUI colorCompressionText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Color Compression"), "Text"));
                colorCompressionText.text = LanguageManager.CurrentLanguage.options.graphics_colorCompression;

                GameObject colorCompression = GetGameObjectChild(GetGameObjectChild(graphicsContent, "Color Compression"),"Dropdown");
                TMP_Dropdown colorCompressionDropdown = colorCompression.GetComponent<TMP_Dropdown>();
                List<TMP_Dropdown.OptionData> colorCompressionDropdownListText = colorCompressionDropdown.options;

                colorCompressionDropdownListText[0].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionNone;
                colorCompressionDropdownListText[1].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionLight;
                colorCompressionDropdownListText[2].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionMedium;
                colorCompressionDropdownListText[3].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionStrong;
                colorCompressionDropdownListText[4].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionVeryStrong;
                colorCompressionDropdownListText[5].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionAbsurd;

                TextMeshProUGUI performanceText = GetTextMeshProUGUI(GetGameObjectChild(graphicsContent, "Text (4)"));
                performanceText.text = "--"+ LanguageManager.CurrentLanguage.options.graphics_performance + "--";

                TextMeshProUGUI simplifiedExplosionsText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Simplified Explosions"), "Text"));
                simplifiedExplosionsText.text = LanguageManager.CurrentLanguage.options.graphics_performanceSimpleExplosions;

                TextMeshProUGUI simplifiedFireText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Simplified Fire"), "Text"));
                simplifiedFireText.text = LanguageManager.CurrentLanguage.options.graphics_performanceSimpleFire;

                TextMeshProUGUI simplifiedSpawnText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Simplified Spawn Effects"), "Text"));
                simplifiedSpawnText.text = LanguageManager.CurrentLanguage.options.graphics_performanceSimpleSpawn;

                TextMeshProUGUI disabledParticlesText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Disable Environmental Particles"), "Text"));
                disabledParticlesText.text = LanguageManager.CurrentLanguage.options.graphics_performanceDisableEnviParticles;

                TextMeshProUGUI simpleNailPhysicsText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Simple Nail Physics"), "Text"));
                simpleNailPhysicsText.text = LanguageManager.CurrentLanguage.options.graphics_performanceSimpleNails;

                TextMeshProUGUI goreSettingsText = GetTextMeshProUGUI(GetGameObjectChild(graphicsContent, "Text (2)"));
                goreSettingsText.text = "--"+ LanguageManager.CurrentLanguage.options.graphics_gore+ "--";

                TextMeshProUGUI goreSettingsDescription = GetTextMeshProUGUI(GetGameObjectChild(graphicsContent, "Text (3)"));
                goreSettingsDescription.text = LanguageManager.CurrentLanguage.options.graphics_goreNote;

                TextMeshProUGUI enableBloodandGoreText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "BloodAndGore"), "Text"));
                enableBloodandGoreText.text = LanguageManager.CurrentLanguage.options.graphics_goreEnable;

                TextMeshProUGUI freezeGoreText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Freeze Gore"), "Text"));
                freezeGoreText.text = LanguageManager.CurrentLanguage.options.graphics_goreDisablePhysics;

                TextMeshProUGUI bloodstainChanceText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Bloodstain Chance"), "Text"));
                bloodstainChanceText.text = LanguageManager.CurrentLanguage.options.graphics_goreBloodChance;

                TextMeshProUGUI maxBloodText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Max Gore"), "Text"));
                maxBloodText.text = LanguageManager.CurrentLanguage.options.graphics_goreMaxGore;
        }
        private void PatchAudioOptions(GameObject optionsMenu)
        {
            //Audio options
            TextMeshProUGUI audioTitle = GetTextMeshProUGUI(GetGameObjectChild(optionsMenu, "Text (2)"));
            audioTitle.text = "--" + LanguageManager.CurrentLanguage.options.audio_title + "--";

            GameObject audioContent = GetGameObjectChild(optionsMenu, "Image");

            TextMeshProUGUI subtitlesText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(audioContent, "Subtitles Checkbox"), "Text"));
            subtitlesText.text = LanguageManager.CurrentLanguage.options.audio_subtitles;

            TextMeshProUGUI masterVolumeText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(audioContent, "Master Volume"), "Text"));
            masterVolumeText.text = LanguageManager.CurrentLanguage.options.audio_globalVolume;

            TextMeshProUGUI musicVolumeText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(audioContent, "Music Volume"), "Text"));
            musicVolumeText.text = LanguageManager.CurrentLanguage.options.audio_musicVolume;
        }
        private void PatchHUDOptions(GameObject optionsMenu)
        {
        //HUD options
                TextMeshProUGUI hudTitle = GetTextMeshProUGUI(GetGameObjectChild(optionsMenu, "Text"));
                hudTitle.text = "--"+ LanguageManager.CurrentLanguage.options.hud_title + "--";

                GameObject hudContent = GetGameObjectChild(GetGameObjectChild(optionsMenu, "Scroll Rect (1)"), "Contents");

                TextMeshProUGUI hudTypeText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "HUD Type"), "Text"));
                hudTypeText.text = LanguageManager.CurrentLanguage.options.hud_type;

                GameObject hudType = GetGameObjectChild(GetGameObjectChild(hudContent, "HUD Type"), "Dropdown");
                TMP_Dropdown hudTypeDropdown = hudType.GetComponent<TMP_Dropdown>();
                List<TMP_Dropdown.OptionData> hudTypeDropdownListText = hudTypeDropdown.options;

                hudTypeDropdownListText[0].text = LanguageManager.CurrentLanguage.options.hud_typeNone;
                hudTypeDropdownListText[1].text = LanguageManager.CurrentLanguage.options.hud_typeStandard;
                hudTypeDropdownListText[2].text = LanguageManager.CurrentLanguage.options.hud_typeClassicColor;
                hudTypeDropdownListText[3].text = LanguageManager.CurrentLanguage.options.hud_typeClassicWhite;


                TextMeshProUGUI backgroundOpacityText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "Background Opacity"), "Text"));
                backgroundOpacityText.text = LanguageManager.CurrentLanguage.options.hud_backgroundOpacity;

                SliderValueToText backgroundOpacitySlider = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(hudContent, "Background Opacity"), "Button"),"Slider (1)").GetComponentInChildren<SliderValueToText>();

                backgroundOpacitySlider.ifMin = LanguageManager.CurrentLanguage.options.hud_backgroundOpacityMinimum;
                backgroundOpacitySlider.ifMax = LanguageManager.CurrentLanguage.options.hud_backgroundOpacityMaximum;

                TextMeshProUGUI alwaysOnTopText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "Always On Top"), "Text"));
                alwaysOnTopText.text = LanguageManager.CurrentLanguage.options.hud_alwaysOnTop;

                TextMeshProUGUI iconsText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "Icons"), "Text"));
                iconsText.text = LanguageManager.CurrentLanguage.options.hud_icons;

                TextMeshProUGUI hudElements = GetTextMeshProUGUI(GetGameObjectChild(hudContent, "-- HUD Elements -- "));
                hudElements.text = "--" + LanguageManager.CurrentLanguage.options.hud_hudElements + "--";

                TextMeshProUGUI weaponIconText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "Weapon Icon"), "Text"));
                weaponIconText.text = LanguageManager.CurrentLanguage.options.hud_weaponIcon;

                TextMeshProUGUI armIconText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "Arm Icon"), "Text"));
                armIconText.text = LanguageManager.CurrentLanguage.options.hud_armIcon;

                TextMeshProUGUI railcannonMeterText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "Railcannon Meter"), "Text"));
                railcannonMeterText.text = LanguageManager.CurrentLanguage.options.hud_railcannonMeter;

                TextMeshProUGUI styleMeterText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "Style Meter"), "Text"));
                styleMeterText.text = LanguageManager.CurrentLanguage.options.hud_styleMeter;

                TextMeshProUGUI styleInfoText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "Style Info"), "Text"));
                styleInfoText.text = LanguageManager.CurrentLanguage.options.hud_styleInfo;

                //Crosshair settings

                TextMeshProUGUI crosshairTitle = GetTextMeshProUGUI(GetGameObjectChild(hudContent, "-- Crosshair Settings --"));
                crosshairTitle.text = "--"+ LanguageManager.CurrentLanguage.options.crosshair_title+ "--";

                TextMeshProUGUI crosshairTypeText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair Type"), "Text"));
                crosshairTypeText.text = LanguageManager.CurrentLanguage.options.crosshair_type;

                GameObject crosshairType = GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair Type"), "Dropdown");
                TMP_Dropdown crosshairTypeDropdown = crosshairType.GetComponent<TMP_Dropdown>();
                List<TMP_Dropdown.OptionData> crosshairTypeDropdownListText = crosshairTypeDropdown.options;

                crosshairTypeDropdownListText[0].text = LanguageManager.CurrentLanguage.options.crosshair_typeNone;
                crosshairTypeDropdownListText[1].text = LanguageManager.CurrentLanguage.options.crosshair_typeSmall;
                crosshairTypeDropdownListText[2].text = LanguageManager.CurrentLanguage.options.crosshair_typeLarge;

                TextMeshProUGUI crosshairColorText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair Color"), "Text"));
                crosshairColorText.text = LanguageManager.CurrentLanguage.options.crosshair_color;

                GameObject crosshairColor = GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair Color"), "Dropdown");
                TMP_Dropdown crosshairColorDropdown = crosshairColor.GetComponent<TMP_Dropdown>();
                List<TMP_Dropdown.OptionData> crosshairColorDropdownListText = crosshairColorDropdown.options;

                crosshairColorDropdownListText[0].text = LanguageManager.CurrentLanguage.options.crosshair_colorInverted;
                crosshairColorDropdownListText[1].text = LanguageManager.CurrentLanguage.options.crosshair_colorWhite;
                crosshairColorDropdownListText[2].text = LanguageManager.CurrentLanguage.options.crosshair_colorGrey;
                crosshairColorDropdownListText[3].text = LanguageManager.CurrentLanguage.options.crosshair_colorBlack;
                crosshairColorDropdownListText[4].text = LanguageManager.CurrentLanguage.options.crosshair_colorRed;
                crosshairColorDropdownListText[5].text = LanguageManager.CurrentLanguage.options.crosshair_colorGreen;
                crosshairColorDropdownListText[6].text = LanguageManager.CurrentLanguage.options.crosshair_colorBlue;
                crosshairColorDropdownListText[7].text = LanguageManager.CurrentLanguage.options.crosshair_colorCyan;
                crosshairColorDropdownListText[8].text = LanguageManager.CurrentLanguage.options.crosshair_colorYellow;
                crosshairColorDropdownListText[9].text = LanguageManager.CurrentLanguage.options.crosshair_colorMagenta;

                TextMeshProUGUI crosshairHudSizeText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair HUD"), "Text"));
                crosshairHudSizeText.text = LanguageManager.CurrentLanguage.options.crosshair_size;

                GameObject crosshairSize = GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair HUD"), "Dropdown");
                TMP_Dropdown crosshairSizeDropdown = crosshairSize.GetComponent<TMP_Dropdown>();
                List<TMP_Dropdown.OptionData> crosshairSizeDropdownListText = crosshairSizeDropdown.options;

                crosshairSizeDropdownListText[0].text = LanguageManager.CurrentLanguage.options.crosshair_sizeNone;
                crosshairSizeDropdownListText[1].text = LanguageManager.CurrentLanguage.options.crosshair_sizeThin;
                crosshairSizeDropdownListText[2].text = LanguageManager.CurrentLanguage.options.crosshair_sizeMedium;
                crosshairSizeDropdownListText[3].text = LanguageManager.CurrentLanguage.options.crosshair_sizeThick;
                crosshairSizeDropdownListText[4].text = LanguageManager.CurrentLanguage.options.crosshair_sizeVeryThick;

                TextMeshProUGUI crosshairHudFadeText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair HUD Fade Out"), "Text"));
                crosshairHudFadeText.text = LanguageManager.CurrentLanguage.options.crosshair_hudFade;

                TextMeshProUGUI crosshairPowerupText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair PowerUp Meter"), "Text"));
                crosshairPowerupText.text = LanguageManager.CurrentLanguage.options.crosshair_powerupBar;

        }
        private void PatchAssistOptions(GameObject optionsMenu)
        {
                //Assist options
                TextMeshProUGUI assistTitle = GetTextMeshProUGUI(GetGameObjectChild(optionsMenu, "Text (1)"));
                assistTitle.text = "--"+ LanguageManager.CurrentLanguage.options.assists_title + "--";

                GameObject assistMajorAssistPanel = GetGameObjectChild(GetGameObjectChild(optionsMenu, "Panel"),"Panel");

                Text assistDisclaimerText = GetTextfromGameObject(GetGameObjectChild(assistMajorAssistPanel, "Text (2)"));
                assistDisclaimerText.text =

                    LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer2
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer3;
                assistDisclaimerText.fontSize = 18;

                Text assistDisclaimerConfirmText = GetTextfromGameObject(GetGameObjectChild(assistMajorAssistPanel, "Text (1)"));
                assistDisclaimerConfirmText.text = LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirm;
                assistDisclaimerConfirmText.fontSize = 24;

                Text assistDisclaimerYesText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistMajorAssistPanel, "Yes"),"Text"));
                assistDisclaimerYesText.text = LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirmYes;

                Text assistDisclaimerNoText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistMajorAssistPanel, "No"), "Text"));
                assistDisclaimerNoText.text = LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirmNo;

                GameObject assistContent = GetGameObjectChild(GetGameObjectChild(optionsMenu, "Scroll Rect"), "Contents");

                TextMeshProUGUI assistMinorAssistText = GetTextMeshProUGUI(GetGameObjectChild(assistContent, "Text (5)"));
                assistMinorAssistText.text = "--"+ LanguageManager.CurrentLanguage.options.assists_minor +"--";

                TextMeshProUGUI assistAutoAimText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(assistContent, "Auto Aim"),"Text (1)"));
                assistAutoAimText.text = LanguageManager.CurrentLanguage.options.assists_autoAim;

                TextMeshProUGUI assistAutoAimAmountText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(assistContent, "Auto Aim Amount"), "Text (1)"));
                assistAutoAimAmountText.text = LanguageManager.CurrentLanguage.options.assists_autoAimPercent;

                SliderValueToText autoAimSlider = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(assistContent, "Auto Aim Amount"), "Button"), "Slider"), "Text (2)").GetComponentInChildren<SliderValueToText>();
                autoAimSlider.ifMin = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMinimum;
                autoAimSlider.ifMax = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMaximum;

                TextMeshProUGUI assistEnemySilhouettesTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(assistContent, "Enemy Simplifier (1)"),"Option"), "Text (1)"));
                assistEnemySilhouettesTitle.text = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlines;

                GameObject assistEnemySilhouettes = GetGameObjectChild(GetGameObjectChild(assistContent, "Enemy Simplifier (1)"),"Option"); //

                TextMeshProUGUI assistEnemySilhouettesOutlineText = GetTextMeshProUGUI(GetGameObjectChild(assistEnemySilhouettes, "Text (1)"));
                assistEnemySilhouettesOutlineText.text =  LanguageManager.CurrentLanguage.options.assists_enemySilhouettes;

                GameObject assistEnemySilhouettesExtra = GetGameObjectChild(assistContent, "Activation Distance");

                TextMeshProUGUI assistEnemySilhouettesDistance = GetTextMeshProUGUI(GetGameObjectChild(assistEnemySilhouettesExtra, "Text (1)"));
                assistEnemySilhouettesDistance.text = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesDistance;

                TextMeshProUGUI assistEnemySilhouettesOutlineThickness = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(assistEnemySilhouettesExtra, "Outline Thickness"), "Text (1)"));
                assistEnemySilhouettesOutlineThickness.text =
                    LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlineThickness;
                

                SliderValueToText assistEnemySilhouettesDistanceSlider = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(assistContent, "Activation Distance"),"Button"),"Slider"),"Text (2)").GetComponentInChildren<SliderValueToText>();
                assistEnemySilhouettesDistanceSlider.ifMin = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesDistanceMinimum;

                TextMeshProUGUI assistEnemySilhouettesOutlinesOnlyText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(assistEnemySilhouettesExtra, "Extra"),"Text (2)"));
                assistEnemySilhouettesOutlinesOnlyText.text = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlinesOnly;

                GameObject assistsMajor = GetGameObjectChild(assistContent, "Major Assists");
                TextMeshProUGUI assistsMajorTitle = GetTextMeshProUGUI(assistsMajor);

                assistsMajorTitle.text = "--"+ LanguageManager.CurrentLanguage.options.assists_major +"--";
                assistsMajorTitle.fontSize = 20;

                TextMeshProUGUI assistsMajorActivateText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Enable"),"Text (1)"));
                assistsMajorActivateText.text = LanguageManager.CurrentLanguage.options.assists_majorActivate;

                TextMeshProUGUI assistsMajorGameSpeedText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Game Speed"), "Text (1)"));
                assistsMajorGameSpeedText.text = LanguageManager.CurrentLanguage.options.assists_gameSpeed;

                TextMeshProUGUI assistsDamageTakenText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Damage Taken"), "Text (1)"));
                assistsDamageTakenText.text = LanguageManager.CurrentLanguage.options.assists_damageTaken;

                TextMeshProUGUI assistsBossOverrideText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Boss Difficulty Override"), "Text"));
                assistsBossOverrideText.text = LanguageManager.CurrentLanguage.options.assists_bossOverride;

                GameObject bossOverride = GetGameObjectChild(GetGameObjectChild(assistsMajor, "Boss Difficulty Override"), "Dropdown");
                TMP_Dropdown bossOverrideDropdown = bossOverride.GetComponent<TMP_Dropdown>();
                List<TMP_Dropdown.OptionData> bossOverrideDropdownListText = bossOverrideDropdown.options;

                bossOverrideDropdownListText[0].text = LanguageManager.CurrentLanguage.options.assists_bossOverrideNone;
                bossOverrideDropdownListText[1].text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;
                bossOverrideDropdownListText[2].text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;
                bossOverrideDropdownListText[3].text = LanguageManager.CurrentLanguage.frontend.difficulty_standard;
                bossOverrideDropdownListText[4].text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

                Text assistsBossRestartText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Boss Difficulty Override"), "Text (1)"));
                assistsBossRestartText.text = LanguageManager.CurrentLanguage.options.assists_bossRestartRequired;

                TextMeshProUGUI assistsInfiniteStaminaText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Infinite Stamina"), "Text (1)"));
                assistsInfiniteStaminaText.text = LanguageManager.CurrentLanguage.options.assists_infiniteEnergy;

                TextMeshProUGUI assistsDisableWhiplashHardDamageText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Disable Whiplash Hard Damage"), "Text (1)"));
                assistsDisableWhiplashHardDamageText.text = LanguageManager.CurrentLanguage.options.assists_disableWhiplashHardDamage;

                TextMeshProUGUI assistsDisableHardDamageText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Disable Hard Damage"), "Text (1)"));
                assistsDisableHardDamageText.text = LanguageManager.CurrentLanguage.options.assists_disableHardDamage;

                TextMeshProUGUI assistsDisableWeaponFreshnessText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Disable Weapon Freshness"), "Text (1)"));
                assistsDisableWeaponFreshnessText.text = LanguageManager.CurrentLanguage.options.assists_disableWeaponFreshness;

                TextMeshProUGUI assistsDisablePopupText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Disable Popup"), "Text (1)"));
                assistsDisablePopupText.text = LanguageManager.CurrentLanguage.options.assists_disablePopupHints;

        }
        private void PatchColorsOptions(GameObject optionsMenu)
        {
                //Colors options
                TextMeshProUGUI colorsPanel = GetTextMeshProUGUI(GetGameObjectChild(optionsMenu, "Text (1)"));
                colorsPanel.text = "--" + LanguageManager.CurrentLanguage.options.colors_title + "--";

                TextMeshProUGUI colorsResetDefaultText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(optionsMenu,"Scroll Rect"),"Contents"),"Default"),"Text"));
                colorsResetDefaultText.text = LanguageManager.CurrentLanguage.options.colors_reset;

                //HUD Text
                GameObject colorsHudObject = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Scroll Rect"),"Contents"),"HUD");

                TextMeshProUGUI colorsHudHealthText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject,"Health"),"Text"));
                colorsHudHealthText.text = LanguageManager.CurrentLanguage.options.colors_hudHealth;

                TextMeshProUGUI colorsHudHealthNumberText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "HpText"), "Text"));
                colorsHudHealthNumberText.text = LanguageManager.CurrentLanguage.options.colors_hudHealthNumber;

                TextMeshProUGUI colorsHudSoftDamageText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "AfterImage"), "Text"));
                colorsHudSoftDamageText.text = LanguageManager.CurrentLanguage.options.colors_hudDamage;

                TextMeshProUGUI colorsHudHardDamageText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "AntiHp"), "Text"));
                colorsHudHardDamageText.text = LanguageManager.CurrentLanguage.options.colors_hudHardDamage;

                TextMeshProUGUI colorsHudOverhealText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "Overheal"), "Text"));
                colorsHudOverhealText.text = LanguageManager.CurrentLanguage.options.colors_hudOverheal;

                TextMeshProUGUI colorsHudStaminaText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "Stamina"), "Text"));
                colorsHudStaminaText.text = LanguageManager.CurrentLanguage.options.colors_hudEnergyFull;

                TextMeshProUGUI colorsHudStaminaChargingText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "StaminaCharging"), "Text"));
                colorsHudStaminaChargingText.text = LanguageManager.CurrentLanguage.options.colors_hudEnergyPartial;

                TextMeshProUGUI colorsHudStaminaEmptyText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "StaminaEmpty"), "Text"));
                colorsHudStaminaEmptyText.text = LanguageManager.CurrentLanguage.options.colors_hudEnergyEmpty;

                TextMeshProUGUI colorsHudRailcannonFullText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "RailcannonFull"), "Text"));
                colorsHudRailcannonFullText.text = LanguageManager.CurrentLanguage.options.colors_railcannonFull;

                TextMeshProUGUI colorsHudRailcannonChargingText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "RailcannonCharging"), "Text"));
                colorsHudRailcannonChargingText.text = LanguageManager.CurrentLanguage.options.colors_railcannonPartial;

                TextMeshProUGUI colorsHudVarBlueText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "Blue Variation"), "Text"));
                colorsHudVarBlueText.text = LanguageManager.CurrentLanguage.options.colors_variationBlue;

                TextMeshProUGUI colorsHudVarGreenText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "Green Variation"), "Text"));
                colorsHudVarGreenText.text = LanguageManager.CurrentLanguage.options.colors_variationGreen;

                TextMeshProUGUI colorsHudVarRedText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "Red Variation"), "Text"));
                colorsHudVarRedText.text = LanguageManager.CurrentLanguage.options.colors_variationRed;

                TextMeshProUGUI colorsHudVarGoldText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "Gold Variation"), "Text"));
                colorsHudVarGoldText.text = LanguageManager.CurrentLanguage.options.colors_variationGold;

                //Enemy names text
                //Later down the line, could be better to get the names from EnemyBios.
                GameObject colorsEnemiesObject = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Scroll Rect"), "Contents"), "Enemies");

                TextMeshProUGUI colorsEnemiesText = GetTextMeshProUGUI(colorsEnemiesObject);

                colorsEnemiesText.text = LanguageManager.CurrentLanguage.options.colors_enemies;

                TextMeshProUGUI colorsEnemiesFilthText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Filth"), "Text"));
                colorsEnemiesFilthText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_filth;

                TextMeshProUGUI colorsEnemiesStrayText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Stray"), "Text"));
                colorsEnemiesStrayText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_stray;

                TextMeshProUGUI colorsEnemiesMalFaceText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Malicious Face"), "Text"));
                colorsEnemiesMalFaceText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_malFace;

                TextMeshProUGUI colorsEnemiesSchismText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Schism"), "Text"));
                colorsEnemiesSchismText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_schism;

                TextMeshProUGUI colorsEnemiesSwordsmachineText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Swordsmachine"), "Text"));
                colorsEnemiesSwordsmachineText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_swordsmachine;

                TextMeshProUGUI colorsEnemiesCerberusText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Cerberus"), "Text"));
                colorsEnemiesCerberusText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_cerberus;

                TextMeshProUGUI colorsEnemiesDroneText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Drone"), "Text"));
                colorsEnemiesDroneText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_drone;

                TextMeshProUGUI colorsEnemiesStreetcleanerText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Streetcleaner"), "Text"));
                colorsEnemiesStreetcleanerText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_streetCleaner;

                TextMeshProUGUI colorsEnemiesSoldierText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Shotgunner"), "Text"));
                colorsEnemiesSoldierText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_soldier;

                TextMeshProUGUI colorsEnemiesV2Text = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "V2"), "Text"));
                colorsEnemiesV2Text.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_v2;

                TextMeshProUGUI colorsEnemiesMindflayerText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Mindflayer"), "Text"));
                colorsEnemiesMindflayerText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_mindFlayer;

                TextMeshProUGUI colorsEnemiesVirtueText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Virtue"), "Text"));
                colorsEnemiesVirtueText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_virtue;

                TextMeshProUGUI colorsEnemiesStalkerText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Stalker"), "Text"));
                colorsEnemiesStalkerText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_stalker;

                TextMeshProUGUI colorsEnemiesSisyphusText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Sisyphus"), "Text"));
                colorsEnemiesSisyphusText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_insurrectionist;

                TextMeshProUGUI colorsEnemiesSentryText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Sentry"), "Text"));
                colorsEnemiesSentryText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_sentry;

                TextMeshProUGUI colorsEnemiesIdolText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Idol"), "Text"));
                colorsEnemiesIdolText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_idol;

                TextMeshProUGUI colorsEnemiesFerrymanText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Ferryman"), "Text"));
                colorsEnemiesFerrymanText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_ferryman;

        }
        private void PatchSavesOptions(GameObject optionsMenu)
        {
            //Save options

            GameObject saveReloadPanel = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Reload Consent Blocker"),"Consent"),"Panel");

            Text saveReloadText = GetTextfromGameObject(GetGameObjectChild(saveReloadPanel, "Text"));
            Text saveReloadYes = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(saveReloadPanel, "Yes"),"Text"));
            Text saveReloadNo = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(saveReloadPanel, "No"), "Text"));

            saveReloadText.text =
                "<color=red>" + LanguageManager.CurrentLanguage.options.save_warning1 + "</color>\n\n" +
                LanguageManager.CurrentLanguage.options.save_warning2;

            saveReloadYes.text = LanguageManager.CurrentLanguage.options.save_reloadYes;
            saveReloadNo.text = LanguageManager.CurrentLanguage.options.save_reloadNo;

            GameObject saveDeletePanel = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Wipe Consent Blocker"), "Consent"), "Panel");

            Text saveDeleteYes = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(saveDeletePanel, "Yes"), "Text"));
            saveDeleteYes.text = "<color=red>"+ LanguageManager.CurrentLanguage.options.save_deleteYes +"</color>";

            Text saveDeleteNo = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(saveDeletePanel, "No"), "Text"));
            saveDeleteNo.text = LanguageManager.CurrentLanguage.options.save_deleteNo;

            Text saveSlotsClose = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Close"),"Text"));
            saveSlotsClose.text = LanguageManager.CurrentLanguage.options.save_close;
        }

        private void PatchRumbleOptions(GameObject optionsMenu)
        {
            TextMeshProUGUI rumbleSettingsTitle = GetTextMeshProUGUI(GetGameObjectChild(optionsMenu, "Text (1)"));
            rumbleSettingsTitle.text = LanguageManager.CurrentLanguage.options.rumble_title;

            TextMeshProUGUI rumbleFinalMultiplier = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Total"), "Text"));
            rumbleFinalMultiplier.text = LanguageManager.CurrentLanguage.options.rumble_finalMultiplier;

            TextMeshProUGUI rumbleCloseButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Close"), "Text"));
            rumbleCloseButton.text = LanguageManager.CurrentLanguage.options.save_close;
            
            //Loop through each entry
            GameObject rumbleEntryList = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(optionsMenu,"Scroll View"),"Viewport"),"Content");
            try
            {
                for(int x = 0; x < 19; x++) //Hardcoded, amount may increase in future updates
                {
                    GameObject entry = rumbleEntryList.transform.GetChild(x).gameObject;
                    //Throws an out of bounds error, but still swaps the text correctly...
                    TextMeshProUGUI entryIntensity = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(entry,"Button"),"Text (1)"));
                    entryIntensity.text = LanguageManager.CurrentLanguage.options.rumble_intensity;
                
                    TextMeshProUGUI entryResetIntensity = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(entry,"Default Button (1)"),"Text"));
                    entryResetIntensity.text = LanguageManager.CurrentLanguage.options.rumble_reset;
                
                    TextMeshProUGUI entryEndDelay = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(entry,"End Delay Container"),"Text (2)"));
                    entryEndDelay.text = LanguageManager.CurrentLanguage.options.rumble_endDelay;
                
                    TextMeshProUGUI entryResetEndDelay = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(entry,"End Delay Container"),"Default Button"),"Text"));
                    entryResetEndDelay.text = LanguageManager.CurrentLanguage.options.rumble_reset;
                }
            }
            catch (Exception e)
            {
               Logging.Warn("Rumble options exception, should be harmless unless if console is spammed with this");
            }
            
        }

        private void PatchOptions(GameObject optionsMenu)
        {
            if (optionsMenu != null)
            {
                GameObject generalOptions = GetGameObjectChild(optionsMenu, "Gameplay Options");
                GameObject controlOptions = GetGameObjectChild(optionsMenu, "Controls Options");
                GameObject graphicsOptions = GetGameObjectChild(optionsMenu, "Video Options");
                GameObject audioOptions = GetGameObjectChild(optionsMenu, "Audio Options");
                GameObject hudOptions = GetGameObjectChild(optionsMenu, "HUD Options");
                GameObject assistOptions = GetGameObjectChild(optionsMenu, "Assist Options");
                GameObject colorsOptions = GetGameObjectChild(optionsMenu, "ColorBlindness Options");
                GameObject savesOptions = GetGameObjectChild(optionsMenu, "Save Slots");
                GameObject rumbleOptions = GetGameObjectChild(optionsMenu, "Rumble Settings");

                //Main buttons and text
                TextMeshProUGUI optionsText = GetTextMeshProUGUI(GetGameObjectChild(optionsMenu, "Text"));
                optionsText.text = LanguageManager.CurrentLanguage.options.options_title;

                TextMeshProUGUI backText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Back"),"Text"));
                backText.text = LanguageManager.CurrentLanguage.options.options_back;

                TextMeshProUGUI generalButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Gameplay"), "Text"));
                generalButton.text = LanguageManager.CurrentLanguage.options.category_general;

                TextMeshProUGUI controlButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Controls"), "Text"));
                controlButton.text = LanguageManager.CurrentLanguage.options.category_controls;

                TextMeshProUGUI graphicsButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Video"), "Text"));
                graphicsButton.text = LanguageManager.CurrentLanguage.options.category_graphics;

                TextMeshProUGUI audioButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Audio"), "Text"));
                audioButton.text = LanguageManager.CurrentLanguage.options.category_sound;

                TextMeshProUGUI hudButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(optionsMenu, "HUD"), "Text"));
                hudButton.text = LanguageManager.CurrentLanguage.options.category_display;

                TextMeshProUGUI assistButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Assist"), "Text"));
                assistButton.text = LanguageManager.CurrentLanguage.options.category_assists;

                TextMeshProUGUI colorsButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Colors"), "Text"));
                colorsButton.text = LanguageManager.CurrentLanguage.options.category_colors;

                TextMeshProUGUI savesButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Saves"), "Text"));
                savesButton.text = LanguageManager.CurrentLanguage.options.category_saves;
                
                

                try
                {
                    try { this.PatchGeneralOptions(generalOptions); }catch (Exception e) { Console.WriteLine("Failed to patch general options."); Console.WriteLine(e.ToString()); }
                    try { this.PatchControlOptions(controlOptions); }catch (Exception e) { Console.WriteLine("Failed to patch control options."); Console.WriteLine(e.ToString()); }
                    try { this.PatchGraphicsOptions(graphicsOptions); }catch (Exception e) { Console.WriteLine("Failed to patch graphics options."); Console.WriteLine(e.ToString()); }
                    try { this.PatchAudioOptions(audioOptions); }catch (Exception e) { Console.WriteLine("Failed to patch audio options."); Console.WriteLine(e.ToString()); }
                    try { this.PatchHUDOptions(hudOptions); }catch (Exception e) { Console.WriteLine("Failed to patch HUD options."); Console.WriteLine(e.ToString()); }
                    try { this.PatchAssistOptions(assistOptions); }catch (Exception e) { Console.WriteLine("Failed to patch assist options."); Console.WriteLine(e.ToString()); }
                    try { this.PatchColorsOptions(colorsOptions); }catch (Exception e) { Console.WriteLine("Failed to patch colors options."); Console.WriteLine(e.ToString()); }
                    try { this.PatchSavesOptions(savesOptions); }catch (Exception e) { Console.WriteLine("Failed to patch save options."); Console.WriteLine(e.ToString()); }
                }
                catch(Exception e)
                {
                    Logging.Error("Something went wrong while patching options.");
                    Logging.Error(e.ToString());
                }

            }
        }

        public Options(ref GameObject game)
        {
            //Options are in two different locations.
            //On the main menu, it's root/Canvas/OptionsMenu.
            //In-game it's root/Canvas/OptionsMenu.
            if (GetCurrentSceneName() == "Main Menu")
            {
                this.optionsMenu = GetGameObjectChild(game, "OptionsMenu");
            }
            else
            {
                List<GameObject> rootObjects = new List<GameObject>();
                SceneManager.GetActiveScene().GetRootGameObjects(rootObjects);
                GameObject pauseObject = null;
                foreach (GameObject a in rootObjects)
                {
                    if (a.gameObject.name == "Canvas")
                    {
                        pauseObject = a.gameObject;
                        break;
                    }
                }
                this.optionsMenu = GetGameObjectChild(pauseObject, "OptionsMenu");
            }
            this.PatchOptions(this.optionsMenu);
        }
    }
}
