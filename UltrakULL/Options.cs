using System;
using System.Collections.Generic;

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
            Text generalText = GetTextfromGameObject(GetGameObjectChild(generalOptions, "Text"));
            generalText.text = "--" + LanguageManager.CurrentLanguage.options.category_general + "--";

            GameObject generalContent = GetGameObjectChild(GetGameObjectChild(generalOptions, "Scroll Rect (1)"), "Contents");

            Text mouseSensitivityText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(generalContent, "Mouse Sensitivity"), "Text"));
            mouseSensitivityText.text = LanguageManager.CurrentLanguage.options.general_mouseSensitivity;

            Text invertXAxisText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(generalContent, "Invert Axis"), "Text"));
            invertXAxisText.text = LanguageManager.CurrentLanguage.options.general_xInversion;

            Text invertYAxisText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(generalContent, "Invert Axis"), "Text (1)"));
            invertYAxisText.text = LanguageManager.CurrentLanguage.options.general_yInversion;

            Text fovText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(generalContent, "FOV"), "Text"));
            fovText.text = LanguageManager.CurrentLanguage.options.general_fieldOfVision;

            Text weaponPosText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(generalContent, "Weapon Position"), "Text"));
            weaponPosText.text = LanguageManager.CurrentLanguage.options.general_weaponPosition;
            
            //Have to patch directly from the Dropdown.OptionData list.
            GameObject weaponPosList = GetGameObjectChild(GetGameObjectChild(generalContent, "Weapon Position"), "Dropdown");
            Dropdown weaponPosDropdown = weaponPosList.GetComponent<Dropdown>();
            List<Dropdown.OptionData> weaponPosListText = weaponPosDropdown.options;
            weaponPosListText[0].text = LanguageManager.CurrentLanguage.options.general_weaponPositionRight;
            weaponPosListText[1].text = LanguageManager.CurrentLanguage.options.general_weaponPositionMiddle;
            weaponPosListText[2].text = LanguageManager.CurrentLanguage.options.general_weaponPositionLeft;

            Text rememberWeaponText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(generalContent, "Variation Memory"), "Text"));
            rememberWeaponText.text = LanguageManager.CurrentLanguage.options.general_rememberWeapon;

            Text screenshakeText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(generalContent, "Screenshake"), "Text"));
            screenshakeText.text = LanguageManager.CurrentLanguage.options.general_screenShake;

            SliderValueToText screenshakeSlider = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(generalContent, "Screenshake"), "Button"), "Slider (1)"), "Text (2)").GetComponentInChildren<SliderValueToText>();
            screenshakeSlider.ifMin = LanguageManager.CurrentLanguage.options.general_screenShakeMinimum;
            screenshakeSlider.ifMax = LanguageManager.CurrentLanguage.options.general_screenShakeMaximum;

            Text restartWarningText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(generalContent, "Restart Warning"), "Text"));
            restartWarningText.text = LanguageManager.CurrentLanguage.options.general_restartWarning;

            Text cameraTiltText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(generalContent, "Camera Tilt"), "Text"));
            cameraTiltText.text = LanguageManager.CurrentLanguage.options.general_cameraTilt;

            Text discordText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(generalContent, "Discord Integration"), "Text"));
            discordText.text = LanguageManager.CurrentLanguage.options.general_discordRpc;

            Text seasonEventText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(generalContent, "Seasonal Events"), "Text"));
            seasonEventText.text = LanguageManager.CurrentLanguage.options.general_seasonalEvent;
        }
        private void PatchControlOptions(GameObject optionsMenu)
        {
                //Control options

                Text controlText = GetTextfromGameObject(GetGameObjectChild(optionsMenu, "Text (1)"));
                controlText.text = "--"+ LanguageManager.CurrentLanguage.options.category_controls + "--";

                GameObject controlContent = GetGameObjectChild(GetGameObjectChild(optionsMenu, "Scroll Rect"), "Contents");

                Text resetToDefaultText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Default"), "Text"));
                resetToDefaultText.text = LanguageManager.CurrentLanguage.options.controls_resetDefault;

                Text movementText = GetTextfromGameObject(GetGameObjectChild(controlContent, "Text"));
                movementText.text = "--"+ LanguageManager.CurrentLanguage.options.controls_movement+"--";

                Text moveforwardText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Forward"), "Text"));
                moveforwardText.text = LanguageManager.CurrentLanguage.options.controls_forward;

                Text movebackText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Back"), "Text"));
                movebackText.text = LanguageManager.CurrentLanguage.options.controls_back;

                Text moveleftText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Left"), "Text"));
                moveleftText.text = LanguageManager.CurrentLanguage.options.controls_left;

                Text moverightText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Right"), "Text"));
                moverightText.text = LanguageManager.CurrentLanguage.options.controls_right;

                Text jumpText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Jump"), "Text"));
                jumpText.text = LanguageManager.CurrentLanguage.options.controls_jump;

                Text dashText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Dash"), "Text"));
                dashText.text = LanguageManager.CurrentLanguage.options.controls_dash;

                Text actionsText = GetTextfromGameObject(GetGameObjectChild(controlContent, "Text (1)"));
                actionsText.text = "--"+ LanguageManager.CurrentLanguage.options.controls_actions+ "--";

                Text primaryFireText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Fire"), "Text"));
                primaryFireText.text = LanguageManager.CurrentLanguage.options.controls_primaryFire;

                Text secondaryFireText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Alt Fire"), "Text"));
                secondaryFireText.text = LanguageManager.CurrentLanguage.options.controls_secondaryFire;
                secondaryFireText.fontSize = 11;

                Text punchText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Punch"), "Text"));
                punchText.text = LanguageManager.CurrentLanguage.options.controls_punch;
                punchText.fontSize = 12;

                Text lastUsedWeaponText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Last Used Weapon"), "Text"));
                lastUsedWeaponText.text = LanguageManager.CurrentLanguage.options.controls_lastUsedWeapon;
                lastUsedWeaponText.fontSize = 10;

                Text switchVariationText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Change Variation"), "Text"));
                switchVariationText.text = LanguageManager.CurrentLanguage.options.controls_changeVariation;
                switchVariationText.fontSize = 11;

                Text switchArmText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Change Arm"), "Text"));
                switchArmText.text = LanguageManager.CurrentLanguage.options.controls_changeArm;
                switchArmText.fontSize = 11;

                Text slideText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Slide"), "Text"));
                slideText.text = LanguageManager.CurrentLanguage.options.controls_slide;

                Text whiplashText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(controlContent, "Whiplash"), "Text"));
                whiplashText.text = LanguageManager.CurrentLanguage.options.controls_whiplash;

                GameObject weaponSettings = GetGameObjectChild(controlContent, "Weapons Settings");

                Text weaponSettingsText = GetTextfromGameObject(GetGameObjectChild(weaponSettings, "Text (1)"));
                weaponSettingsText.text = "--"+ LanguageManager.CurrentLanguage.options.controls_weapons + "--";

                Text slot1Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(weaponSettings, "Slot 1"),"Text"));
                slot1Text.text = LanguageManager.CurrentLanguage.options.controls_slot1;

                Text slot2Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(weaponSettings, "Slot 2"), "Text"));
                slot2Text.text = LanguageManager.CurrentLanguage.options.controls_slot2;

                Text slot3Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(weaponSettings, "Slot 3"), "Text"));
                slot3Text.text = LanguageManager.CurrentLanguage.options.controls_slot3;

                Text slot4Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(weaponSettings, "Slot 4"), "Text"));
                slot4Text.text = LanguageManager.CurrentLanguage.options.controls_slot4;

                Text slot5Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(weaponSettings, "Slot 5"), "Text"));
                slot5Text.text = LanguageManager.CurrentLanguage.options.controls_slot5;


                GameObject mouseWheelSettings = GetGameObjectChild(weaponSettings, "Mouse Wheel Settings");

                Text scrollTypeText = GetTextfromGameObject(GetGameObjectChild(mouseWheelSettings, "Text (1)"));
                scrollTypeText.text = LanguageManager.CurrentLanguage.options.controls_scrollType;


                GameObject scrollTypeList = GetGameObjectChild(mouseWheelSettings, "Dropdown (1)");

                Dropdown scrollTypeDropdown = scrollTypeList.GetComponent<Dropdown>();
                List<Dropdown.OptionData> scrollTypeDropdownText = scrollTypeDropdown.options;
                scrollTypeDropdownText[0].text = LanguageManager.CurrentLanguage.options.controls_scrollTypeWeapons;
                scrollTypeDropdownText[1].text = LanguageManager.CurrentLanguage.options.controls_scrollTypeVariations;
                scrollTypeDropdownText[2].text = LanguageManager.CurrentLanguage.options.controls_scrollTypeAll;

                GameObject mouseWheelContent = GetGameObjectChild(mouseWheelSettings, "Mouse Wheel to Change Weapon");

                Text changeWeaponMouseWheel = GetTextfromGameObject(GetGameObjectChild(mouseWheelContent, "Text"));
                changeWeaponMouseWheel.text = LanguageManager.CurrentLanguage.options.controls_mouseWheelToChangeWeapon;

                Text reverseScrollText = GetTextfromGameObject(GetGameObjectChild(mouseWheelSettings, "Text"));
                reverseScrollText.text = LanguageManager.CurrentLanguage.options.controls_reverseScroll;
        }
        private void PatchGraphicsOptions(GameObject optionsMenu)
        {
                //Graphics options

                Text graphicsText = GetTextfromGameObject(GetGameObjectChild(optionsMenu, "Text (1)"));
                graphicsText.text = "--"+ LanguageManager.CurrentLanguage.options.category_graphics+ "--";

                GameObject graphicsContent = GetGameObjectChild(GetGameObjectChild(optionsMenu, "Scroll Rect"), "Contents");

                Text resolutionText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Resolution"), "Text"));
                resolutionText.text = LanguageManager.CurrentLanguage.options.graphics_resolution;

                Text fullscreenText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "FullScreen"), "Text"));
                fullscreenText.text = LanguageManager.CurrentLanguage.options.graphics_fullscreen;

                Text fpslimitText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Framerate Limiter"), "Text"));
                fpslimitText.text = LanguageManager.CurrentLanguage.options.graphics_maxFps;

                GameObject fpsObject = GetGameObjectChild(GetGameObjectChild(graphicsContent, "Framerate Limiter"), "Dropdown");
                Dropdown fpsDropdown = fpsObject.GetComponent<Dropdown>();
                List<Dropdown.OptionData> fpsDropdownListText = fpsDropdown.options;
                fpsDropdownListText[0].text = LanguageManager.CurrentLanguage.options.graphics_maxFpsNone;
                fpsDropdownListText[1].text = LanguageManager.CurrentLanguage.options.graphics_maxFps2x;


                Text vsyncText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "VSync"), "Text"));
                vsyncText.text = LanguageManager.CurrentLanguage.options.graphics_vsync;

                Text psxFilterSettingsText = GetTextfromGameObject(GetGameObjectChild(graphicsContent, "Text (5)"));
                psxFilterSettingsText.text = "--"+ LanguageManager.CurrentLanguage.options.graphics_filters+"--";

                Text psxFilterSettingsDescription = GetTextfromGameObject(GetGameObjectChild(graphicsContent, "Text (6)"));
                psxFilterSettingsDescription.text = LanguageManager.CurrentLanguage.options.graphics_filtersDescription;

                Text downscalingText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Pixelization"), "Text"));
                downscalingText.text = LanguageManager.CurrentLanguage.options.graphics_pixelisation;

                GameObject resolution = GetGameObjectChild(GetGameObjectChild(graphicsContent, "Pixelization"), "Dropdown (1)");
                Dropdown resolutionDropdown = resolution.GetComponent<Dropdown>();
                List<Dropdown.OptionData> resolutionDropdownListText = resolutionDropdown.options;

                resolutionDropdownListText[0].text = LanguageManager.CurrentLanguage.options.graphics_pixelisationNone;
                resolutionDropdownListText[1].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation720p;
                resolutionDropdownListText[2].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation480p;
                resolutionDropdownListText[3].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation360p;
                resolutionDropdownListText[4].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation240p;
                resolutionDropdownListText[5].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation144p;
                resolutionDropdownListText[6].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation36p;


                Text ditheringText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Dithering (1)"), "Text"));
                ditheringText.text = LanguageManager.CurrentLanguage.options.graphics_dithering;

                SliderValueToText ditheringSlider = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Dithering (1)"), "Button"),"Slider (2)"),"Text (3)").GetComponentInChildren<SliderValueToText>();
                ditheringSlider.ifMin = LanguageManager.CurrentLanguage.options.graphics_ditheringMinimum;

                Text textureWarpingText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Texture Warping (1)"), "Text"));
                textureWarpingText.text = LanguageManager.CurrentLanguage.options.graphics_textureWarping;

                Text vertexWarpingText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Vertex Warping"), "Text"));
                vertexWarpingText.text = LanguageManager.CurrentLanguage.options.graphics_vertexWarping;

                GameObject vertexWarping = GetGameObjectChild(GetGameObjectChild(graphicsContent, "Vertex Warping"),"Dropdown");
                Dropdown vertexWarpingDropdown = vertexWarping.GetComponent<Dropdown>();
                List<Dropdown.OptionData> vertexWarpingDropdownListText = vertexWarpingDropdown.options;

                vertexWarpingDropdownListText[0].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingNone;
                vertexWarpingDropdownListText[1].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingLight;
                vertexWarpingDropdownListText[2].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingMedium;
                vertexWarpingDropdownListText[3].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingStrong;
                vertexWarpingDropdownListText[4].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingVeryStrong;
                vertexWarpingDropdownListText[5].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingAbsurd;

                Text customColorPalette = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Custom Color Palette"), "Text"));
                customColorPalette.text = LanguageManager.CurrentLanguage.options.graphics_customColorPalette;

                Text customColorPaletteSelect = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Custom Color Palette"), "Select"),"Text"));
                customColorPaletteSelect.text = LanguageManager.CurrentLanguage.options.graphics_customColorPaletteSelect;

                Text colorCompressionText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Color Compression"), "Text"));
                colorCompressionText.text = LanguageManager.CurrentLanguage.options.graphics_colorCompression;

                GameObject colorCompression = GetGameObjectChild(GetGameObjectChild(graphicsContent, "Color Compression"),"Dropdown");
                Dropdown colorCompressionDropdown = colorCompression.GetComponent<Dropdown>();
                List<Dropdown.OptionData> colorCompressionDropdownListText = colorCompressionDropdown.options;

                colorCompressionDropdownListText[0].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionNone;
                colorCompressionDropdownListText[1].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionLight;
                colorCompressionDropdownListText[2].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionMedium;
                colorCompressionDropdownListText[3].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionStrong;
                colorCompressionDropdownListText[4].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionVeryStrong;
                colorCompressionDropdownListText[5].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionAbsurd;

                Text performanceText = GetTextfromGameObject(GetGameObjectChild(graphicsContent, "Text (4)"));
                performanceText.text = "--"+ LanguageManager.CurrentLanguage.options.graphics_performance + "--";

                Text simplifiedExplosionsText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Simplified Explosions"), "Text"));
                simplifiedExplosionsText.text = LanguageManager.CurrentLanguage.options.graphics_performanceSimpleExplosions;

                Text simplifiedFireText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Simplified Fire"), "Text"));
                simplifiedFireText.text = LanguageManager.CurrentLanguage.options.graphics_performanceSimpleFire;

                Text simplifiedSpawnText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Simplified Spawn Effects"), "Text"));
                simplifiedSpawnText.text = LanguageManager.CurrentLanguage.options.graphics_performanceSimpleSpawn;

                Text disabledParticlesText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Disable Environmental Particles"), "Text"));
                disabledParticlesText.text = LanguageManager.CurrentLanguage.options.graphics_performanceDisableEnviParticles;

                Text simpleNailPhysicsText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Simple Nail Physics"), "Text"));
                simpleNailPhysicsText.text = LanguageManager.CurrentLanguage.options.graphics_performanceSimpleNails;

                Text goreSettingsText = GetTextfromGameObject(GetGameObjectChild(graphicsContent, "Text (2)"));
                goreSettingsText.text = "--"+ LanguageManager.CurrentLanguage.options.graphics_gore+ "--";

                Text goreSettingsDescription = GetTextfromGameObject(GetGameObjectChild(graphicsContent, "Text (3)"));
                goreSettingsDescription.text = LanguageManager.CurrentLanguage.options.graphics_goreNote;

                Text enableBloodandGoreText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "BloodAndGore"), "Text"));
                enableBloodandGoreText.text = LanguageManager.CurrentLanguage.options.graphics_goreEnable;

                Text freezeGoreText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Freeze Gore"), "Text"));
                freezeGoreText.text = LanguageManager.CurrentLanguage.options.graphics_goreDisablePhysics;

                Text bloodstainChanceText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Bloodstain Chance"), "Text"));
                bloodstainChanceText.text = LanguageManager.CurrentLanguage.options.graphics_goreBloodChance;

                Text maxBloodText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(graphicsContent, "Max Gore"), "Text"));
                maxBloodText.text = LanguageManager.CurrentLanguage.options.graphics_goreMaxGore;
        }
        private void PatchAudioOptions(GameObject optionsMenu)
        {
            //Audio options
            Text audioTitle = GetTextfromGameObject(GetGameObjectChild(optionsMenu, "Text (2)"));
            audioTitle.text = "--" + LanguageManager.CurrentLanguage.options.audio_title + "--";

            GameObject audioContent = GetGameObjectChild(optionsMenu, "Image");

            Text subtitlesText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(audioContent, "Subtitles Checkbox"), "Text"));
            subtitlesText.text = LanguageManager.CurrentLanguage.options.audio_subtitles;

            Text masterVolumeText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(audioContent, "Master Volume"), "Text"));
            masterVolumeText.text = LanguageManager.CurrentLanguage.options.audio_globalVolume;

            Text musicVolumeText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(audioContent, "Music Volume"), "Text"));
            musicVolumeText.text = LanguageManager.CurrentLanguage.options.audio_musicVolume;
        }
        private void PatchHUDOptions(GameObject optionsMenu)
        {
        //HUD options
                Text hudTitle = GetTextfromGameObject(GetGameObjectChild(optionsMenu, "Text"));
                hudTitle.text = "--"+ LanguageManager.CurrentLanguage.options.hud_title + "--";

                GameObject hudContent = GetGameObjectChild(GetGameObjectChild(optionsMenu, "Scroll Rect (1)"), "Contents");

                Text hudTypeText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "HUD Type"), "Text"));
                hudTypeText.text = LanguageManager.CurrentLanguage.options.hud_type;

                GameObject hudType = GetGameObjectChild(GetGameObjectChild(hudContent, "HUD Type"), "Dropdown");
                Dropdown hudTypeDropdown = hudType.GetComponent<Dropdown>();
                List<Dropdown.OptionData> hudTypeDropdownListText = hudTypeDropdown.options;

                hudTypeDropdownListText[0].text = LanguageManager.CurrentLanguage.options.hud_typeNone;
                hudTypeDropdownListText[1].text = LanguageManager.CurrentLanguage.options.hud_typeStandard;
                hudTypeDropdownListText[2].text = LanguageManager.CurrentLanguage.options.hud_typeClassicColor;
                hudTypeDropdownListText[3].text = LanguageManager.CurrentLanguage.options.hud_typeClassicWhite;


                Text backgroundOpacityText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "Background Opacity"), "Text"));
                backgroundOpacityText.text = LanguageManager.CurrentLanguage.options.hud_backgroundOpacity;

                SliderValueToText backgroundOpacitySlider = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(hudContent, "Background Opacity"), "Button"),"Slider (1)").GetComponentInChildren<SliderValueToText>();

                backgroundOpacitySlider.ifMin = LanguageManager.CurrentLanguage.options.hud_backgroundOpacityMinimum;
                backgroundOpacitySlider.ifMax = LanguageManager.CurrentLanguage.options.hud_backgroundOpacityMaximum;

                Text alwaysOnTopText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "Always On Top"), "Text"));
                alwaysOnTopText.text = LanguageManager.CurrentLanguage.options.hud_alwaysOnTop;

                Text iconsText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "Icons"), "Text"));
                iconsText.text = LanguageManager.CurrentLanguage.options.hud_icons;

                Text hudElements = GetTextfromGameObject(GetGameObjectChild(hudContent, "-- HUD Elements -- "));
                hudElements.text = "--" + LanguageManager.CurrentLanguage.options.hud_hudElements + "--";

                Text weaponIconText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "Weapon Icon"), "Text"));
                weaponIconText.text = LanguageManager.CurrentLanguage.options.hud_weaponIcon;

                Text armIconText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "Arm Icon"), "Text"));
                armIconText.text = LanguageManager.CurrentLanguage.options.hud_armIcon;

                Text railcannonMeterText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "Railcannon Meter"), "Text"));
                railcannonMeterText.text = LanguageManager.CurrentLanguage.options.hud_railcannonMeter;

                Text styleMeterText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "Style Meter"), "Text"));
                styleMeterText.text = LanguageManager.CurrentLanguage.options.hud_styleMeter;

                Text styleInfoText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "Style Info"), "Text"));
                styleInfoText.text = LanguageManager.CurrentLanguage.options.hud_styleInfo;

                //Crosshair settings

                Text crosshairTitle = GetTextfromGameObject(GetGameObjectChild(hudContent, "-- Crosshair Settings --"));
                crosshairTitle.text = "--"+ LanguageManager.CurrentLanguage.options.crosshair_title+ "--";

                Text crosshairTypeText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair Type"), "Text"));
                crosshairTypeText.text = LanguageManager.CurrentLanguage.options.crosshair_type;

                GameObject crosshairType = GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair Type"), "Dropdown");
                Dropdown crosshairTypeDropdown = crosshairType.GetComponent<Dropdown>();
                List<Dropdown.OptionData> crosshairTypeDropdownListText = crosshairTypeDropdown.options;

                crosshairTypeDropdownListText[0].text = LanguageManager.CurrentLanguage.options.crosshair_typeNone;
                crosshairTypeDropdownListText[1].text = LanguageManager.CurrentLanguage.options.crosshair_typeSmall;
                crosshairTypeDropdownListText[2].text = LanguageManager.CurrentLanguage.options.crosshair_typeLarge;

                Text crosshairColorText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair Color"), "Text"));
                crosshairColorText.text = LanguageManager.CurrentLanguage.options.crosshair_color;

                GameObject crosshairColor = GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair Color"), "Dropdown");
                Dropdown crosshairColorDropdown = crosshairColor.GetComponent<Dropdown>();
                List<Dropdown.OptionData> crosshairColorDropdownListText = crosshairColorDropdown.options;

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

                Text crosshairHudSizeText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair HUD"), "Text"));
                crosshairHudSizeText.text = LanguageManager.CurrentLanguage.options.crosshair_size;

                GameObject crosshairSize = GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair HUD"), "Dropdown");
                Dropdown crosshairSizeDropdown = crosshairSize.GetComponent<Dropdown>();
                List<Dropdown.OptionData> crosshairSizeDropdownListText = crosshairSizeDropdown.options;

                crosshairSizeDropdownListText[0].text = LanguageManager.CurrentLanguage.options.crosshair_sizeNone;
                crosshairSizeDropdownListText[1].text = LanguageManager.CurrentLanguage.options.crosshair_sizeThin;
                crosshairSizeDropdownListText[2].text = LanguageManager.CurrentLanguage.options.crosshair_sizeMedium;
                crosshairSizeDropdownListText[3].text = LanguageManager.CurrentLanguage.options.crosshair_sizeThick;
                crosshairSizeDropdownListText[4].text = LanguageManager.CurrentLanguage.options.crosshair_sizeVeryThick;


                Text crosshairHudFadeText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair HUD Fade Out"), "Text"));
                crosshairHudFadeText.text = LanguageManager.CurrentLanguage.options.crosshair_hudFade;

                Text crosshairPowerupText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(hudContent, "Crosshair PowerUp Meter"), "Text"));
                crosshairPowerupText.text = LanguageManager.CurrentLanguage.options.crosshair_powerupBar;

        }
        private void PatchAssistOptions(GameObject optionsMenu)
        {
                //Assist options

                Text assistTitle = GetTextfromGameObject(GetGameObjectChild(optionsMenu, "Text (1)"));
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

                Text assistMinorAssistText = GetTextfromGameObject(GetGameObjectChild(assistContent, "Text (5)"));
                assistMinorAssistText.text = "--"+ LanguageManager.CurrentLanguage.options.assists_minor +"--";

                Text assistAutoAimText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistContent, "Auto Aim"),"Text (1)"));
                assistAutoAimText.text = LanguageManager.CurrentLanguage.options.assists_autoAim;

                Text assistAutoAimAmountText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistContent, "Auto Aim Amount"), "Text (1)"));
                assistAutoAimAmountText.text = LanguageManager.CurrentLanguage.options.assists_autoAimPercent;

                SliderValueToText autoAimSlider = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(assistContent, "Auto Aim Amount"), "Button"), "Slider"), "Text (2)").GetComponentInChildren<SliderValueToText>();
                autoAimSlider.ifMin = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMinimum;
                autoAimSlider.ifMax = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMaximum;

                Text assistEnemySilhouettesTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(assistContent, "Enemy Simplifier (1)"),"Option"), "Text (1)"));
                assistEnemySilhouettesTitle.text = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlines;

                GameObject assistEnemySilhouettes = GetGameObjectChild(GetGameObjectChild(assistContent, "Enemy Simplifier (1)"),"Option"); //

                Text assistEnemySilhouettesOutlineText = GetTextfromGameObject(GetGameObjectChild(assistEnemySilhouettes, "Text (1)"));
                assistEnemySilhouettesOutlineText.text =  LanguageManager.CurrentLanguage.options.assists_enemySilhouettes;

                GameObject assistEnemySilhouettesExtra = GetGameObjectChild(assistContent, "Activation Distance");

                Text assistEnemySilhouettesDistance = GetTextfromGameObject(GetGameObjectChild(assistEnemySilhouettesExtra, "Text (1)"));
                assistEnemySilhouettesDistance.text = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesDistance;

                Text assistEnemySilhouettesOutlineThickness = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistEnemySilhouettesExtra, "Outline Thickness"), "Text (1)"));
                assistEnemySilhouettesOutlineThickness.text =
                    LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlineThickness;
                

                SliderValueToText assistEnemySilhouettesDistanceSlider = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(assistContent, "Activation Distance"),"Button"),"Slider"),"Text (2)").GetComponentInChildren<SliderValueToText>();
                assistEnemySilhouettesDistanceSlider.ifMin = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesDistanceMinimum;

                Text assistEnemySilhouettesOutlinesOnlyText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistEnemySilhouettesExtra, "Extra"),"Text (2)"));
                assistEnemySilhouettesOutlinesOnlyText.text = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlinesOnly;

                GameObject assistsMajor = GetGameObjectChild(assistContent, "Major Assists");
                Text assistsMajorTitle = GetTextfromGameObject(assistsMajor);

                assistsMajorTitle.text = "--"+ LanguageManager.CurrentLanguage.options.assists_major +"--";
                assistsMajorTitle.fontSize = 20;

                Text assistsMajorActivateText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Enable"),"Text (1)"));
                assistsMajorActivateText.text = LanguageManager.CurrentLanguage.options.assists_majorActivate;

                Text assistsMajorGameSpeedText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Game Speed"), "Text (1)"));
                assistsMajorGameSpeedText.text = LanguageManager.CurrentLanguage.options.assists_gameSpeed;

                Text assistsDamageTakenText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Damage Taken"), "Text (1)"));
                assistsDamageTakenText.text = LanguageManager.CurrentLanguage.options.assists_damageTaken;

                Text assistsBossOverrideText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Boss Difficulty Override"), "Text"));
                assistsBossOverrideText.text = LanguageManager.CurrentLanguage.options.assists_bossOverride;

                GameObject bossOverride = GetGameObjectChild(GetGameObjectChild(assistsMajor, "Boss Difficulty Override"), "Dropdown");
                Dropdown bossOverrideDropdown = bossOverride.GetComponent<Dropdown>();
                List<Dropdown.OptionData> bossOverrideDropdownListText = bossOverrideDropdown.options;

                bossOverrideDropdownListText[0].text = LanguageManager.CurrentLanguage.options.assists_bossOverrideNone;
                bossOverrideDropdownListText[1].text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;
                bossOverrideDropdownListText[2].text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;
                bossOverrideDropdownListText[3].text = LanguageManager.CurrentLanguage.frontend.difficulty_standard;
                bossOverrideDropdownListText[4].text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

                Text assistsBossRestartText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Boss Difficulty Override"), "Text (1)"));
                assistsBossRestartText.text = LanguageManager.CurrentLanguage.options.assists_bossRestartRequired;

                Text assistsInfiniteStaminaText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Infinite Stamina"), "Text (1)"));
                assistsInfiniteStaminaText.text = LanguageManager.CurrentLanguage.options.assists_infiniteEnergy;

                Text assistsDisableWhiplashHardDamageText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Disable Whiplash Hard Damage"), "Text (1)"));
                assistsDisableWhiplashHardDamageText.text = LanguageManager.CurrentLanguage.options.assists_disableWhiplashHardDamage;

                Text assistsDisableHardDamageText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Disable Hard Damage"), "Text (1)"));
                assistsDisableHardDamageText.text = LanguageManager.CurrentLanguage.options.assists_disableHardDamage;

                Text assistsDisableWeaponFreshnessText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Disable Weapon Freshness"), "Text (1)"));
                assistsDisableWeaponFreshnessText.text = LanguageManager.CurrentLanguage.options.assists_disableWeaponFreshness;

                Text assistsDisablePopupText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(assistsMajor, "Disable Popup"), "Text (1)"));
                assistsDisablePopupText.text = LanguageManager.CurrentLanguage.options.assists_disablePopupHints;

        }
        private void PatchColorsOptions(GameObject optionsMenu)
        {
                //Colors options
                Text colorsPanel = GetTextfromGameObject(GetGameObjectChild(optionsMenu, "Text (1)"));
                colorsPanel.text = "--" + LanguageManager.CurrentLanguage.options.colors_title + "--";

                Text colorsResetDefaultText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(optionsMenu,"Scroll Rect"),"Contents"),"Default"),"Text"));
                colorsResetDefaultText.text = LanguageManager.CurrentLanguage.options.colors_reset;

                //HUD Text
                GameObject colorsHudObject = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Scroll Rect"),"Contents"),"HUD");

                Text colorsHudHealthText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject,"Health"),"Text"));
                colorsHudHealthText.text = LanguageManager.CurrentLanguage.options.colors_hudHealth;

                Text colorsHudHealthNumberText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "HpText"), "Text"));
                colorsHudHealthNumberText.text = LanguageManager.CurrentLanguage.options.colors_hudHealthNumber;

                Text colorsHudSoftDamageText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "AfterImage"), "Text"));
                colorsHudSoftDamageText.text = LanguageManager.CurrentLanguage.options.colors_hudDamage;

                Text colorsHudHardDamageText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "AntiHp"), "Text"));
                colorsHudHardDamageText.text = LanguageManager.CurrentLanguage.options.colors_hudHardDamage;

                Text colorsHudOverhealText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "Overheal"), "Text"));
                colorsHudOverhealText.text = LanguageManager.CurrentLanguage.options.colors_hudOverheal;

                Text colorsHudStaminaText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "Stamina"), "Text"));
                colorsHudStaminaText.text = LanguageManager.CurrentLanguage.options.colors_hudEnergyFull;

                Text colorsHudStaminaChargingText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "StaminaCharging"), "Text"));
                colorsHudStaminaChargingText.text = LanguageManager.CurrentLanguage.options.colors_hudEnergyPartial;

                Text colorsHudStaminaEmptyText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "StaminaEmpty"), "Text"));
                colorsHudStaminaEmptyText.text = LanguageManager.CurrentLanguage.options.colors_hudEnergyEmpty;

                Text colorsHudRailcannonFullText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "RailcannonFull"), "Text"));
                colorsHudRailcannonFullText.text = LanguageManager.CurrentLanguage.options.colors_railcannonFull;

                Text colorsHudRailcannonChargingText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "RailcannonCharging"), "Text"));
                colorsHudRailcannonChargingText.text = LanguageManager.CurrentLanguage.options.colors_railcannonPartial;

                Text colorsHudVarBlueText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "Blue Variation"), "Text"));
                colorsHudVarBlueText.text = LanguageManager.CurrentLanguage.options.colors_variationBlue;

                Text colorsHudVarGreenText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "Green Variation"), "Text"));
                colorsHudVarGreenText.text = LanguageManager.CurrentLanguage.options.colors_variationGreen;

                Text colorsHudVarRedText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "Red Variation"), "Text"));
                colorsHudVarRedText.text = LanguageManager.CurrentLanguage.options.colors_variationRed;

                Text colorsHudVarGoldText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsHudObject, "Gold Variation"), "Text"));
                colorsHudVarGoldText.text = LanguageManager.CurrentLanguage.options.colors_variationGold;

                //Enemy names text
                //Later down the line, could be better to get the names from EnemyBios.
                GameObject colorsEnemiesObject = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Scroll Rect"), "Contents"), "Enemies");

                Text colorsEnemiesText = GetTextfromGameObject(colorsEnemiesObject);

                colorsEnemiesText.text = LanguageManager.CurrentLanguage.options.colors_enemies;

                Text colorsEnemiesFilthText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Filth"), "Text"));
                colorsEnemiesFilthText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_filth;

                Text colorsEnemiesStrayText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Stray"), "Text"));
                colorsEnemiesStrayText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_stray;

                Text colorsEnemiesMalFaceText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Malicious Face"), "Text"));
                colorsEnemiesMalFaceText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_malFace;

                Text colorsEnemiesSchismText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Schism"), "Text"));
                colorsEnemiesSchismText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_schism;

                Text colorsEnemiesSwordsmachineText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Swordsmachine"), "Text"));
                colorsEnemiesSwordsmachineText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_swordsmachine;

                Text colorsEnemiesCerberusText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Cerberus"), "Text"));
                colorsEnemiesCerberusText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_cerberus;

                Text colorsEnemiesDroneText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Drone"), "Text"));
                colorsEnemiesDroneText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_drone;

                Text colorsEnemiesStreetcleanerText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Streetcleaner"), "Text"));
                colorsEnemiesStreetcleanerText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_streetCleaner;

                Text colorsEnemiesSoldierText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Shotgunner"), "Text"));
                colorsEnemiesSoldierText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_soldier;

                Text colorsEnemiesV2Text = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "V2"), "Text"));
                colorsEnemiesV2Text.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_v2;

                Text colorsEnemiesMindflayerText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Mindflayer"), "Text"));
                colorsEnemiesMindflayerText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_mindFlayer;

                Text colorsEnemiesVirtueText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Virtue"), "Text"));
                colorsEnemiesVirtueText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_virtue;

                Text colorsEnemiesStalkerText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Stalker"), "Text"));
                colorsEnemiesStalkerText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_stalker;

                Text colorsEnemiesSisyphusText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Sisyphus"), "Text"));
                colorsEnemiesSisyphusText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_insurrectionist;

                Text colorsEnemiesSentryText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Sentry"), "Text"));
                colorsEnemiesSentryText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_sentry;

                Text colorsEnemiesIdolText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Idol"), "Text"));
                colorsEnemiesIdolText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_idol;

                Text colorsEnemiesFerrymanText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(colorsEnemiesObject, "Ferryman"), "Text"));
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

        private void PatchOptions(GameObject optionsMenu)
        {
            //Best to divide each section into it's own function.
            //Makes it easier to maintain as well as make it easier to narrow down error-causing lines of code.

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

                //Main buttons and text
                Text optionsText = GetTextfromGameObject(GetGameObjectChild(optionsMenu, "Text"));
                optionsText.text = LanguageManager.CurrentLanguage.options.options_title;

                Text backText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Back"),"Text"));
                backText.text = LanguageManager.CurrentLanguage.options.options_back;

                Text generalButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Gameplay"), "Text"));
                generalButton.text = LanguageManager.CurrentLanguage.options.category_general;

                Text controlButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Controls"), "Text"));
                controlButton.text = LanguageManager.CurrentLanguage.options.category_controls;

                Text graphicsButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Video"), "Text"));
                graphicsButton.text = LanguageManager.CurrentLanguage.options.category_graphics;

                Text audioButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Audio"), "Text"));
                audioButton.text = LanguageManager.CurrentLanguage.options.category_sound;

                Text hudButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(optionsMenu, "HUD"), "Text"));
                hudButton.text = LanguageManager.CurrentLanguage.options.category_display;

                Text assistButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Assist"), "Text"));
                assistButton.text = LanguageManager.CurrentLanguage.options.category_assists;

                Text colorsButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Colors"), "Text"));
                colorsButton.text = LanguageManager.CurrentLanguage.options.category_colors;

                Text savesButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(optionsMenu, "Saves"), "Text"));
                savesButton.text = LanguageManager.CurrentLanguage.options.category_saves;

                try
                {
                    this.PatchGeneralOptions(generalOptions);
                    this.PatchControlOptions(controlOptions);
                    this.PatchGraphicsOptions(graphicsOptions);
                    this.PatchAudioOptions(audioOptions);
                    this.PatchHUDOptions(hudOptions);
                    this.PatchAssistOptions(assistOptions);
                    this.PatchColorsOptions(colorsOptions);
                    this.PatchSavesOptions(savesOptions);
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
            if (SceneManager.GetActiveScene().name == "Main Menu")
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
