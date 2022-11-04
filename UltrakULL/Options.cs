using BepInEx;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    class Options
    {
        public GameObject optionsMenu;

        public void patchGeneralOptions(GameObject generalOptions)
        {
            //General options
            Text generalText = getTextfromGameObject(getGameObjectChild(generalOptions, "Text"));
            generalText.text = "--" + LanguageManager.CurrentLanguage.options.category_general + "--";

            GameObject generalContent = getGameObjectChild(getGameObjectChild(generalOptions, "Scroll Rect (1)"), "Contents");

            Text mouseSensitivityText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Mouse Sensitivity"), "Text"));
            mouseSensitivityText.text = LanguageManager.CurrentLanguage.options.general_mouseSensitivity;

            Text invertXAxisText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Invert Axis"), "Text"));
            invertXAxisText.text = LanguageManager.CurrentLanguage.options.general_xInversion;

            Text invertYAxisText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Invert Axis"), "Text (1)"));
            invertYAxisText.text = LanguageManager.CurrentLanguage.options.general_yInversion;

            Text fovText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "FOV"), "Text"));
            fovText.text = LanguageManager.CurrentLanguage.options.general_fieldOfVision;

            Text weaponPosText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Weapon Position"), "Text"));
            weaponPosText.text = LanguageManager.CurrentLanguage.options.general_weaponPosition;


            //Have to patch directly from the Dropdown.OptionData list.
            GameObject weaponPosList = getGameObjectChild(getGameObjectChild(generalContent, "Weapon Position"), "Dropdown");
            Dropdown weaponPosDropdown = weaponPosList.GetComponent<Dropdown>();
            System.Collections.Generic.List<Dropdown.OptionData> weaponPosListText = weaponPosDropdown.options;
            weaponPosListText[0].text = LanguageManager.CurrentLanguage.options.general_weaponPositionRight;
            weaponPosListText[1].text = LanguageManager.CurrentLanguage.options.general_weaponPositionMiddle;
            weaponPosListText[2].text = LanguageManager.CurrentLanguage.options.general_weaponPositionLeft;

            Text rememberWeaponText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Variation Memory"), "Text"));
            rememberWeaponText.text = LanguageManager.CurrentLanguage.options.general_rememberWeapon;

            Text screenshakeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Screenshake"), "Text"));
            screenshakeText.text = LanguageManager.CurrentLanguage.options.general_screenShake;

            SliderValueToText screenshakeSlider = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(generalContent, "Screenshake"), "Button"), "Slider (1)"), "Text (2)").GetComponentInChildren<SliderValueToText>();
            screenshakeSlider.ifMin = LanguageManager.CurrentLanguage.options.general_screenShakeMinimum;
            screenshakeSlider.ifMax = LanguageManager.CurrentLanguage.options.general_screenShakeMaximum;

            Text restartWarningText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Restart Warning"), "Text"));
            restartWarningText.text = LanguageManager.CurrentLanguage.options.general_restartWarning;

            Text cameraTiltText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Camera Tilt"), "Text"));
            cameraTiltText.text = LanguageManager.CurrentLanguage.options.general_cameraTilt;

            Text discordText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Discord Integration"), "Text"));
            discordText.text = LanguageManager.CurrentLanguage.options.general_discordRpc;

            Text seasonEventText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Seasonal Events"), "Text"));
            seasonEventText.text = LanguageManager.CurrentLanguage.options.general_seasonalEvent;
        }
        public void patchControlOptions(GameObject optionsMenu)
        {

        }
        public void patchGraphicsOptions(GameObject optionsMenu)
        {

        }
        public void patchAudioOptions(GameObject optionsMenu)
        {

        }
        public void patchHUDOptions(GameObject optionsMenu)
        {

        }
        public void patchAssistOptions(GameObject optionsMenu)
        {

        }
        public void patchColorsOptions(GameObject optionsMenu)
        {

        }
        public void patchSavesOptions(GameObject optionsMenu)
        {

        }

        public void patchOptions(GameObject optionsMenu)
        {
            //Best to divide each section into it's own function.
            //Makes it easier to maintain as well as make it easier to narrow down error-causing lines of code.

            if (optionsMenu != null)
            {


                GameObject generalOptions = getGameObjectChild(optionsMenu, "Gameplay Options");
                GameObject controlOptions = getGameObjectChild(optionsMenu, "Controls Options");
                GameObject graphicsOptions = getGameObjectChild(optionsMenu, "Video Options");
                GameObject audioOptions = getGameObjectChild(optionsMenu, "Audio Options");
                GameObject hudOptions = getGameObjectChild(optionsMenu, "HUD Options");
                GameObject assistOptions = getGameObjectChild(optionsMenu, "Assist Options");
                GameObject colorsOptions = getGameObjectChild(optionsMenu, "ColorBlindness Options");
                GameObject savesOptions = getGameObjectChild(optionsMenu, "Save Slots");

                //Main buttons and text
                Text optionsText = getTextfromGameObject(getGameObjectChild(optionsMenu, "Text"));
                //optionsText.text = "--OPTIONS--";
                optionsText.text = LanguageManager.CurrentLanguage.options.options_title;

                Text backText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Back"),"Text"));
                backText.text = LanguageManager.CurrentLanguage.options.options_back;

                Text generalButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Gameplay"), "Text"));
                generalButton.text = LanguageManager.CurrentLanguage.options.category_general;

                Text controlButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Controls"), "Text"));
                controlButton.text = LanguageManager.CurrentLanguage.options.category_controls;

                Text graphicsButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Video"), "Text"));
                graphicsButton.text = LanguageManager.CurrentLanguage.options.category_graphics;

                Text audioButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Audio"), "Text"));
                audioButton.text = LanguageManager.CurrentLanguage.options.category_sound;

                Text hudButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "HUD"), "Text"));
                hudButton.text = LanguageManager.CurrentLanguage.options.category_display;

                Text assistButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Assist"), "Text"));
                assistButton.text = LanguageManager.CurrentLanguage.options.category_assists;

                Text colorsButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Colors"), "Text"));
                colorsButton.text = LanguageManager.CurrentLanguage.options.category_colors;

                Text savesButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Saves"), "Text"));
                savesButton.text = LanguageManager.CurrentLanguage.options.category_saves;

                try
                {
                    this.patchGeneralOptions(generalOptions);
                    this.patchControlOptions(controlOptions);
                    this.patchGraphicsOptions(graphicsOptions);
                    this.patchAudioOptions(audioOptions);
                    this.patchHUDOptions(hudOptions);
                    this.patchAssistOptions(assistOptions);
                    this.patchColorsOptions(colorsOptions);
                    this.patchSavesOptions(savesOptions);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                

                //Control options

                Text controlText = getTextfromGameObject(getGameObjectChild(controlOptions, "Text (1)"));
                controlText.text = "--"+ LanguageManager.CurrentLanguage.options.category_controls + "--";

                GameObject controlContent = getGameObjectChild(getGameObjectChild(controlOptions, "Scroll Rect"), "Contents");

                Text resetToDefaultText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Default"), "Text"));
                resetToDefaultText.text = LanguageManager.CurrentLanguage.options.controls_resetDefault;

                Text movementText = getTextfromGameObject(getGameObjectChild(controlContent, "Text"));
                movementText.text = "--"+ LanguageManager.CurrentLanguage.options.controls_movement+"--";

                Text moveforwardText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Forward"), "Text"));
                moveforwardText.text = LanguageManager.CurrentLanguage.options.controls_forward;

                Text movebackText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Back"), "Text"));
                movebackText.text = LanguageManager.CurrentLanguage.options.controls_back;

                Text moveleftText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Left"), "Text"));
                moveleftText.text = LanguageManager.CurrentLanguage.options.controls_left;

                Text moverightText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Right"), "Text"));
                moverightText.text = LanguageManager.CurrentLanguage.options.controls_right;

                Text jumpText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Jump"), "Text"));
                jumpText.text = LanguageManager.CurrentLanguage.options.controls_jump;

                Text dashText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Dash"), "Text"));
                dashText.text = LanguageManager.CurrentLanguage.options.controls_dash;

                Text actionsText = getTextfromGameObject(getGameObjectChild(controlContent, "Text (1)"));
                actionsText.text = "--"+ LanguageManager.CurrentLanguage.options.controls_actions+ "--";

                Text primaryFireText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Fire"), "Text"));
                primaryFireText.text = LanguageManager.CurrentLanguage.options.controls_primaryFire;

                Text secondaryFireText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Alt Fire"), "Text"));
                secondaryFireText.text = LanguageManager.CurrentLanguage.options.controls_secondaryFire;
                secondaryFireText.fontSize = 11;

                Text punchText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Punch"), "Text"));
                punchText.text = LanguageManager.CurrentLanguage.options.controls_punch;
                punchText.fontSize = 12;

                Text lastUsedWeaponText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Last Used Weapon"), "Text"));
                lastUsedWeaponText.text = LanguageManager.CurrentLanguage.options.controls_lastUsedWeapon;
                lastUsedWeaponText.fontSize = 10;

                Text switchVariationText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Change Variation"), "Text"));
                switchVariationText.text = LanguageManager.CurrentLanguage.options.controls_changeVariation;
                switchVariationText.fontSize = 11;

                Text switchArmText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Change Arm"), "Text"));
                switchArmText.text = LanguageManager.CurrentLanguage.options.controls_changeArm;
                switchArmText.fontSize = 11;

                Text slideText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Slide"), "Text"));
                slideText.text = LanguageManager.CurrentLanguage.options.controls_slide;

                Text whiplashText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Whiplash"), "Text"));
                whiplashText.text = LanguageManager.CurrentLanguage.options.controls_whiplash;

                GameObject weaponSettings = getGameObjectChild(controlContent, "Weapons Settings");

                Text weaponSettingsText = getTextfromGameObject(getGameObjectChild(weaponSettings, "Text (1)"));
                weaponSettingsText.text = "--"+ LanguageManager.CurrentLanguage.options.controls_weapons + "--";

                Text slot1Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(weaponSettings, "Slot 1"),"Text"));
                slot1Text.text = LanguageManager.CurrentLanguage.options.controls_slot1;

                Text slot2Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(weaponSettings, "Slot 2"), "Text"));
                slot2Text.text = LanguageManager.CurrentLanguage.options.controls_slot2;

                Text slot3Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(weaponSettings, "Slot 3"), "Text"));
                slot3Text.text = LanguageManager.CurrentLanguage.options.controls_slot3;

                Text slot4Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(weaponSettings, "Slot 4"), "Text"));
                slot4Text.text = LanguageManager.CurrentLanguage.options.controls_slot4;

                Text slot5Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(weaponSettings, "Slot 5"), "Text"));
                slot5Text.text = LanguageManager.CurrentLanguage.options.controls_slot5;


                GameObject mouseWheelSettings = getGameObjectChild(weaponSettings, "Mouse Wheel Settings");

                Text scrollTypeText = getTextfromGameObject(getGameObjectChild(mouseWheelSettings, "Text (1)"));
                scrollTypeText.text = LanguageManager.CurrentLanguage.options.controls_scrollType;


                GameObject scrollTypeList = getGameObjectChild(mouseWheelSettings, "Dropdown (1)");

                Dropdown scrollTypeDropdown = scrollTypeList.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> scrollTypeDropdownText = scrollTypeDropdown.options;
                scrollTypeDropdownText[0].text = LanguageManager.CurrentLanguage.options.controls_scrollTypeWeapons;
                scrollTypeDropdownText[1].text = LanguageManager.CurrentLanguage.options.controls_scrollTypeVariations;
                scrollTypeDropdownText[2].text = LanguageManager.CurrentLanguage.options.controls_scrollTypeAll;

                GameObject mouseWheelContent = getGameObjectChild(mouseWheelSettings, "Mouse Wheel to Change Weapon");

                Text changeWeaponMouseWheel = getTextfromGameObject(getGameObjectChild(mouseWheelContent, "Text"));
                changeWeaponMouseWheel.text = LanguageManager.CurrentLanguage.options.controls_mouseWheelToChangeWeapon;

                Text reverseScrollText = getTextfromGameObject(getGameObjectChild(mouseWheelSettings, "Text"));
                reverseScrollText.text = LanguageManager.CurrentLanguage.options.controls_reverseScroll;

                //Graphics options

                Text graphicsText = getTextfromGameObject(getGameObjectChild(graphicsOptions, "Text (1)"));
                graphicsText.text = "--"+ LanguageManager.CurrentLanguage.options.category_graphics+ "--";

                GameObject graphicsContent = getGameObjectChild(getGameObjectChild(graphicsOptions, "Scroll Rect"), "Contents");

                Text resolutionText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Resolution"), "Text"));
                resolutionText.text = LanguageManager.CurrentLanguage.options.graphics_resolution;

                Text fullscreenText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "FullScreen"), "Text"));
                fullscreenText.text = LanguageManager.CurrentLanguage.options.graphics_fullscreen;

                Text fpslimitText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Framerate Limiter"), "Text"));
                fpslimitText.text = LanguageManager.CurrentLanguage.options.graphics_maxFps;

                GameObject fpsObject = getGameObjectChild(getGameObjectChild(graphicsContent, "Framerate Limiter"), "Dropdown");
                Dropdown fpsDropdown = fpsObject.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> fpsDropdownListText = fpsDropdown.options;
                fpsDropdownListText[0].text = LanguageManager.CurrentLanguage.options.graphics_maxFpsNone;
                fpsDropdownListText[1].text = LanguageManager.CurrentLanguage.options.graphics_maxFps2x;


                Text vsyncText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "VSync"), "Text"));
                vsyncText.text = LanguageManager.CurrentLanguage.options.graphics_vsync;

                Text psxFilterSettingsText = getTextfromGameObject(getGameObjectChild(graphicsContent, "Text (5)"));
                psxFilterSettingsText.text = "--"+ LanguageManager.CurrentLanguage.options.graphics_filters+"--";

                Text psxFilterSettingsDescription = getTextfromGameObject(getGameObjectChild(graphicsContent, "Text (6)"));
                psxFilterSettingsDescription.text = LanguageManager.CurrentLanguage.options.graphics_filtersDescription;

                Text downscalingText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Pixelization"), "Text"));
                downscalingText.text = LanguageManager.CurrentLanguage.options.graphics_pixelisation;

                GameObject resolution = getGameObjectChild(getGameObjectChild(graphicsContent, "Pixelization"), "Dropdown (1)");
                Dropdown resolutionDropdown = resolution.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> resolutionDropdownListText = resolutionDropdown.options;

                resolutionDropdownListText[0].text = LanguageManager.CurrentLanguage.options.graphics_pixelisationNone;
                resolutionDropdownListText[1].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation720p;
                resolutionDropdownListText[2].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation480p;
                resolutionDropdownListText[3].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation360p;
                resolutionDropdownListText[4].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation240p;
                resolutionDropdownListText[5].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation144p;
                resolutionDropdownListText[6].text = LanguageManager.CurrentLanguage.options.graphics_pixelisation36p;


                Text ditheringText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Dithering (1)"), "Text"));
                ditheringText.text = LanguageManager.CurrentLanguage.options.graphics_dithering;

                SliderValueToText ditheringSlider = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(graphicsContent, "Dithering (1)"), "Button"),"Slider (2)"),"Text (3)").GetComponentInChildren<SliderValueToText>();
                ditheringSlider.ifMin = LanguageManager.CurrentLanguage.options.graphics_ditheringMinimum;



                Text textureWarpingText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Texture Warping (1)"), "Text"));
                textureWarpingText.text = LanguageManager.CurrentLanguage.options.graphics_textureWarping;


                Text vertexWarpingText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Vertex Warping"), "Text"));
                vertexWarpingText.text = LanguageManager.CurrentLanguage.options.graphics_vertexWarping;

                GameObject vertexWarping = getGameObjectChild(getGameObjectChild(graphicsContent, "Vertex Warping"),"Dropdown");
                Dropdown vertexWarpingDropdown = vertexWarping.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> vertexWarpingDropdownListText = vertexWarpingDropdown.options;

                vertexWarpingDropdownListText[0].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingNone;
                vertexWarpingDropdownListText[1].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingLight;
                vertexWarpingDropdownListText[2].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingMedium;
                vertexWarpingDropdownListText[3].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingStrong;
                vertexWarpingDropdownListText[4].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingVeryStrong;
                vertexWarpingDropdownListText[5].text = LanguageManager.CurrentLanguage.options.graphics_vertexWarpingAbsurd;

                Text customColorPalette = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Custom Color Palette"), "Text"));
                customColorPalette.text = LanguageManager.CurrentLanguage.options.graphics_customColorPalette;

                Text customColorPaletteSelect = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(graphicsContent, "Custom Color Palette"), "Select"),"Text"));
                customColorPaletteSelect.text = LanguageManager.CurrentLanguage.options.graphics_customColorPaletteSelect;


                Text colorCompressionText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Color Compression"), "Text"));
                colorCompressionText.text = LanguageManager.CurrentLanguage.options.graphics_colorCompression;

                GameObject colorCompression = getGameObjectChild(getGameObjectChild(graphicsContent, "Color Compression"),"Dropdown");
                Dropdown colorCompressionDropdown = colorCompression.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> colorCompressionDropdownListText = colorCompressionDropdown.options;

                colorCompressionDropdownListText[0].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionNone;
                colorCompressionDropdownListText[1].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionLight;
                colorCompressionDropdownListText[2].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionMedium;
                colorCompressionDropdownListText[3].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionStrong;
                colorCompressionDropdownListText[4].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionVeryStrong;
                colorCompressionDropdownListText[5].text = LanguageManager.CurrentLanguage.options.graphics_colorCompressionAbsurd;

                Text performanceText = getTextfromGameObject(getGameObjectChild(graphicsContent, "Text (4)"));
                performanceText.text = "--"+ LanguageManager.CurrentLanguage.options.graphics_performance + "--";

                Text simplifiedExplosionsText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Simplified Explosions"), "Text"));
                simplifiedExplosionsText.text = LanguageManager.CurrentLanguage.options.graphics_performanceSimpleExplosions;

                Text simplifiedFireText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Simplified Fire"), "Text"));
                simplifiedFireText.text = LanguageManager.CurrentLanguage.options.graphics_performanceSimpleFire;

                Text simplifiedSpawnText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Simplified Spawn Effects"), "Text"));
                simplifiedSpawnText.text = LanguageManager.CurrentLanguage.options.graphics_performanceSimpleSpawn;

                Text disabledParticlesText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Disable Environmental Particles"), "Text"));
                disabledParticlesText.text = LanguageManager.CurrentLanguage.options.graphics_performanceDisableEnviParticles;

                Text simpleNailPhysicsText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Simple Nail Physics"), "Text"));
                simpleNailPhysicsText.text = LanguageManager.CurrentLanguage.options.graphics_performanceSimpleNails;

                Text goreSettingsText = getTextfromGameObject(getGameObjectChild(graphicsContent, "Text (2)"));
                goreSettingsText.text = "--"+ LanguageManager.CurrentLanguage.options.graphics_gore+ "--";

                Text goreSettingsDescription = getTextfromGameObject(getGameObjectChild(graphicsContent, "Text (3)"));
                goreSettingsDescription.text = LanguageManager.CurrentLanguage.options.graphics_goreNote;

                Text enableBloodandGoreText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "BloodAndGore"), "Text"));
                enableBloodandGoreText.text = LanguageManager.CurrentLanguage.options.graphics_goreEnable;

                Text freezeGoreText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Freeze Gore"), "Text"));
                freezeGoreText.text = LanguageManager.CurrentLanguage.options.graphics_goreDisablePhysics;

                Text bloodstainChanceText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Bloodstain Chance"), "Text"));
                bloodstainChanceText.text = LanguageManager.CurrentLanguage.options.graphics_goreBloodChance;

                Text maxBloodText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Max Gore"), "Text"));
                maxBloodText.text = LanguageManager.CurrentLanguage.options.graphics_goreMaxGore;


                //Audio options
                Text audioTitle = getTextfromGameObject(getGameObjectChild(audioOptions, "Text (2)"));
                audioTitle.text = "--" + LanguageManager.CurrentLanguage.options.audio_title + "--";

                GameObject audioContent = getGameObjectChild(audioOptions, "Image");

                Text subtitlesText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(audioContent, "Subtitles Checkbox"), "Text"));
                subtitlesText.text = LanguageManager.CurrentLanguage.options.audio_subtitles;

                Text masterVolumeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(audioContent, "Master Volume"), "Text"));
                masterVolumeText.text = LanguageManager.CurrentLanguage.options.audio_globalVolume;

                Text musicVolumeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(audioContent, "Music Volume"), "Text"));
                musicVolumeText.text = LanguageManager.CurrentLanguage.options.audio_musicVolume;

                //HUD options
                Text hudTitle = getTextfromGameObject(getGameObjectChild(hudOptions, "Text"));
                hudTitle.text = "--"+ LanguageManager.CurrentLanguage.options.hud_title + "--";

                GameObject hudContent = getGameObjectChild(getGameObjectChild(hudOptions, "Scroll Rect (1)"), "Contents");

                Text hudTypeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "HUD Type"), "Text"));
                hudTypeText.text = LanguageManager.CurrentLanguage.options.hud_type;

                GameObject hudType = getGameObjectChild(getGameObjectChild(hudContent, "HUD Type"), "Dropdown");
                Dropdown hudTypeDropdown = hudType.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> hudTypeDropdownListText = hudTypeDropdown.options;

                hudTypeDropdownListText[0].text = LanguageManager.CurrentLanguage.options.hud_typeNone;
                hudTypeDropdownListText[1].text = LanguageManager.CurrentLanguage.options.hud_typeStandard;
                hudTypeDropdownListText[2].text = LanguageManager.CurrentLanguage.options.hud_typeClassicColor;
                hudTypeDropdownListText[3].text = LanguageManager.CurrentLanguage.options.hud_typeClassicWhite;


                Text backgroundOpacityText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Background Opacity"), "Text"));
                backgroundOpacityText.text = LanguageManager.CurrentLanguage.options.hud_backgroundOpacity;

                SliderValueToText backgroundOpacitySlider = getGameObjectChild(getGameObjectChild(getGameObjectChild(hudContent, "Background Opacity"), "Button"),"Slider (1)").GetComponentInChildren<SliderValueToText>();

                backgroundOpacitySlider.ifMin = LanguageManager.CurrentLanguage.options.hud_backgroundOpacityMinimum;
                backgroundOpacitySlider.ifMax = LanguageManager.CurrentLanguage.options.hud_backgroundOpacityMaximum;

                Text alwaysOnTopText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Always On Top"), "Text"));
                alwaysOnTopText.text = LanguageManager.CurrentLanguage.options.hud_alwaysOnTop;

                Text iconsText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Icons"), "Text"));
                iconsText.text = LanguageManager.CurrentLanguage.options.hud_icons;

                Text hudElements = getTextfromGameObject(getGameObjectChild(hudContent, "-- HUD Elements -- "));
                hudElements.text = "--" + LanguageManager.CurrentLanguage.options.hud_hudElements + "--";

                Text weaponIconText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Weapon Icon"), "Text"));
                weaponIconText.text = LanguageManager.CurrentLanguage.options.hud_weaponIcon;

                Text armIconText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Arm Icon"), "Text"));
                armIconText.text = LanguageManager.CurrentLanguage.options.hud_armIcon;

                Text railcannonMeterText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Railcannon Meter"), "Text"));
                railcannonMeterText.text = LanguageManager.CurrentLanguage.options.hud_railcannonMeter;

                Text styleMeterText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Style Meter"), "Text"));
                styleMeterText.text = LanguageManager.CurrentLanguage.options.hud_styleMeter;

                Text styleInfoText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Style Info"), "Text"));
                styleInfoText.text = LanguageManager.CurrentLanguage.options.hud_styleInfo;

                //Crosshair settings

                Text crosshairTitle = getTextfromGameObject(getGameObjectChild(hudContent, "-- Crosshair Settings --"));
                crosshairTitle.text = "--"+ LanguageManager.CurrentLanguage.options.crosshair_title+ "--";

                Text crosshairTypeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Crosshair Type"), "Text"));
                crosshairTypeText.text = LanguageManager.CurrentLanguage.options.crosshair_type;

                GameObject crosshairType = getGameObjectChild(getGameObjectChild(hudContent, "Crosshair Type"), "Dropdown");
                Dropdown crosshairTypeDropdown = crosshairType.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> crosshairTypeDropdownListText = crosshairTypeDropdown.options;

                crosshairTypeDropdownListText[0].text = LanguageManager.CurrentLanguage.options.crosshair_typeNone;
                crosshairTypeDropdownListText[1].text = LanguageManager.CurrentLanguage.options.crosshair_typeSmall;
                crosshairTypeDropdownListText[2].text = LanguageManager.CurrentLanguage.options.crosshair_typeLarge;

                Text crosshairColorText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Crosshair Color"), "Text"));
                crosshairColorText.text = LanguageManager.CurrentLanguage.options.crosshair_color;

                GameObject crosshairColor = getGameObjectChild(getGameObjectChild(hudContent, "Crosshair Color"), "Dropdown");
                Dropdown crosshairColorDropdown = crosshairColor.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> crosshairColorDropdownListText = crosshairColorDropdown.options;

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

                Text crosshairHudSizeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Crosshair HUD"), "Text"));
                crosshairHudSizeText.text = LanguageManager.CurrentLanguage.options.crosshair_size;

                GameObject crosshairSize = getGameObjectChild(getGameObjectChild(hudContent, "Crosshair HUD"), "Dropdown");
                Dropdown crosshairSizeDropdown = crosshairSize.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> crosshairSizeDropdownListText = crosshairSizeDropdown.options;

                crosshairSizeDropdownListText[0].text = LanguageManager.CurrentLanguage.options.crosshair_sizeNone;
                crosshairSizeDropdownListText[1].text = LanguageManager.CurrentLanguage.options.crosshair_sizeThin;
                crosshairSizeDropdownListText[2].text = LanguageManager.CurrentLanguage.options.crosshair_sizeMedium;
                crosshairSizeDropdownListText[3].text = LanguageManager.CurrentLanguage.options.crosshair_sizeThick;
                crosshairSizeDropdownListText[4].text = LanguageManager.CurrentLanguage.options.crosshair_sizeVeryThick;


                Text crosshairHudFadeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Crosshair HUD Fade Out"), "Text"));
                crosshairHudFadeText.text = LanguageManager.CurrentLanguage.options.crosshair_hudFade;

                Text crosshairPowerupText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Crosshair PowerUp Meter"), "Text"));
                crosshairPowerupText.text = LanguageManager.CurrentLanguage.options.crosshair_powerupBar;

                //Assist options

                Text assistTitle = getTextfromGameObject(getGameObjectChild(assistOptions, "Text (1)"));
                assistTitle.text = "--"+ LanguageManager.CurrentLanguage.options.assists_title + "--";

                GameObject assistMajorAssistPanel = getGameObjectChild(getGameObjectChild(assistOptions, "Panel"),"Panel");

                Text assistDisclaimerText = getTextfromGameObject(getGameObjectChild(assistMajorAssistPanel, "Text (2)"));
                assistDisclaimerText.text =

                    LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer1
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer2
                    + "\n\n"
                    + LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimer3;
                assistDisclaimerText.fontSize = 18;

                Text assistDisclaimerConfirmText = getTextfromGameObject(getGameObjectChild(assistMajorAssistPanel, "Text (1)"));
                assistDisclaimerConfirmText.text = LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirm;

                assistDisclaimerConfirmText.fontSize = 24;

                Text assistDisclaimerYesText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistMajorAssistPanel, "Yes"),"Text"));
                assistDisclaimerYesText.text = LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirmYes;

                Text assistDisclaimerNoText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistMajorAssistPanel, "No"), "Text"));
                assistDisclaimerNoText.text = LanguageManager.CurrentLanguage.options.assists_majorAssistsDisclaimerConfirmNo;

                GameObject assistContent = getGameObjectChild(getGameObjectChild(assistOptions, "Scroll Rect"), "Contents");

                Text assistMinorAssistText = getTextfromGameObject(getGameObjectChild(assistContent, "Text (5)"));
                assistMinorAssistText.text = "--"+ LanguageManager.CurrentLanguage.options.assists_minor +"--";

                Text assistAutoAimText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistContent, "Auto Aim"),"Text (1)"));
                assistAutoAimText.text = LanguageManager.CurrentLanguage.options.assists_autoAim;

                Text assistAutoAimAmountText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistContent, "Auto Aim Amount"), "Text (1)"));
                assistAutoAimAmountText.text = LanguageManager.CurrentLanguage.options.assists_autoAimPercent;

                SliderValueToText autoAimSlider = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(assistContent, "Auto Aim Amount"), "Button"), "Slider"), "Text (2)").GetComponentInChildren<SliderValueToText>();
                autoAimSlider.ifMin = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMinimum;
                autoAimSlider.ifMax = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMaximum;

                Text assistEnemySilhouettesTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistContent, "Enemy Simplifier (1)"), "Text (1)"));
                assistEnemySilhouettesTitle.text = LanguageManager.CurrentLanguage.options.assists_enemySilhouettes;

                GameObject assistEnemySilhouettes = getGameObjectChild(assistContent, "Enemy Simplifier (1)");

                Text assistEnemySilhouettesOutlineText = getTextfromGameObject(getGameObjectChild(assistEnemySilhouettes, "Text (1)"));
                assistEnemySilhouettesOutlineText.text = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesOutlines;

                GameObject assistEnemySilhouettesExtra = getGameObjectChild(assistContent, "Enemy Simplifier");

                Text assistEnemySilhouettesDistance = getTextfromGameObject(getGameObjectChild(assistEnemySilhouettesExtra, "Text (1)"));
                assistEnemySilhouettesDistance.text = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesDistance;

                SliderValueToText assistEnemySilhouettesDistanceSlider = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(assistContent, "Enemy Simplifier"),"Button"),"Slider"),"Text (2)").GetComponentInChildren<SliderValueToText>();
                assistEnemySilhouettesDistanceSlider.ifMin = LanguageManager.CurrentLanguage.options.assists_enemySilhouettesDistanceMinimum;

                Text assistEnemySilhouettesOutlinesOnlyText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistEnemySilhouettesExtra, "Extra"),"Text (2)"));
                assistEnemySilhouettesOutlinesOnlyText.text = LanguageManager.CurrentLanguage.options.assists_enemySilhouettes;

                GameObject assistsMajor = getGameObjectChild(assistContent, "Major Assists");
                Text assistsMajorTitle = getTextfromGameObject(assistsMajor);

                assistsMajorTitle.text = "--"+ LanguageManager.CurrentLanguage.options.assists_major +"--";
                assistsMajorTitle.fontSize = 20;

                Text assistsMajorActivateText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Enable"),"Text (1)"));
                assistsMajorActivateText.text = LanguageManager.CurrentLanguage.options.assists_majorActivate;

                Text assistsMajorGameSpeedText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Game Speed"), "Text (1)"));
                assistsMajorGameSpeedText.text = LanguageManager.CurrentLanguage.options.assists_gameSpeed;

                Text assistsDamageTakenText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Damage Taken"), "Text (1)"));
                assistsDamageTakenText.text = LanguageManager.CurrentLanguage.options.assists_damageTaken;

                Text assistsBossOverrideText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Boss Difficulty Override"), "Text"));
                assistsBossOverrideText.text = LanguageManager.CurrentLanguage.options.assists_bossOverride;

                GameObject bossOverride = getGameObjectChild(getGameObjectChild(assistsMajor, "Boss Difficulty Override"), "Dropdown");
                Dropdown bossOverrideDropdown = bossOverride.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> bossOverrideDropdownListText = bossOverrideDropdown.options;

                bossOverrideDropdownListText[0].text = LanguageManager.CurrentLanguage.options.assists_bossOverrideNone;
                bossOverrideDropdownListText[1].text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;
                bossOverrideDropdownListText[2].text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;
                bossOverrideDropdownListText[3].text = LanguageManager.CurrentLanguage.frontend.difficulty_standard;
                bossOverrideDropdownListText[4].text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

                Text assistsBossRestartText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Boss Difficulty Override"), "Text (1)"));
                assistsBossRestartText.text = LanguageManager.CurrentLanguage.options.assists_bossRestartRequired;

                Text assistsInfiniteStaminaText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Infinite Stamina"), "Text (1)"));
                assistsInfiniteStaminaText.text = LanguageManager.CurrentLanguage.options.assists_infiniteEnergy;

                Text assistsDisableWhiplashHardDamageText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Disable Whiplash Hard Damage"), "Text (1)"));
                assistsDisableWhiplashHardDamageText.text = LanguageManager.CurrentLanguage.options.assists_disableWhiplashHardDamage;

                Text assistsDisableHardDamageText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Disable Hard Damage"), "Text (1)"));
                assistsDisableHardDamageText.text = LanguageManager.CurrentLanguage.options.assists_disableHardDamage;

                Text assistsDisableWeaponFreshnessText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Disable Weapon Freshness"), "Text (1)"));
                assistsDisableWeaponFreshnessText.text = LanguageManager.CurrentLanguage.options.assists_disableWeaponFreshness;

                Text assistsDisablePopupText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Disable Popup"), "Text (1)"));
                assistsDisablePopupText.text = LanguageManager.CurrentLanguage.options.assists_disablePopupHints;

                //Colors options
                Text colorsPanel = getTextfromGameObject(getGameObjectChild(colorsOptions, "Text (1)"));
                colorsPanel.text = "--" + colorsButton.text + "--";

                Text colorsResetDefaultText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(colorsOptions,"Scroll Rect"),"Contents"),"Default"),"Text"));
                colorsResetDefaultText.text = LanguageManager.CurrentLanguage.options.colors_reset;

                //HUD Text
                GameObject colorsHudObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(colorsOptions, "Scroll Rect"),"Contents"),"HUD");

                Text colorsHudHealthText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject,"Health"),"Text"));
                colorsHudHealthText.text = LanguageManager.CurrentLanguage.options.colors_hudHealth;

                Text colorsHudHealthNumberText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "HpText"), "Text"));
                colorsHudHealthNumberText.text = LanguageManager.CurrentLanguage.options.colors_hudHealthNumber;

                Text colorsHudSoftDamageText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "AfterImage"), "Text"));
                colorsHudSoftDamageText.text = LanguageManager.CurrentLanguage.options.colors_hudDamage;

                Text colorsHudHardDamageText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "AntiHp"), "Text"));
                colorsHudHardDamageText.text = LanguageManager.CurrentLanguage.options.colors_hudHardDamage;

                Text colorsHudOverhealText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "Overheal"), "Text"));
                colorsHudOverhealText.text = LanguageManager.CurrentLanguage.options.colors_hudOverheal;

                Text colorsHudStaminaText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "Stamina"), "Text"));
                colorsHudStaminaText.text = LanguageManager.CurrentLanguage.options.colors_hudEnergyFull;

                Text colorsHudStaminaChargingText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "StaminaCharging"), "Text"));
                colorsHudStaminaChargingText.text = LanguageManager.CurrentLanguage.options.colors_hudEnergyPartial;

                Text colorsHudStaminaEmptyText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "StaminaEmpty"), "Text"));
                colorsHudStaminaEmptyText.text = LanguageManager.CurrentLanguage.options.colors_hudEnergyEmpty;

                Text colorsHudRailcannonFullText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "RailcannonFull"), "Text"));
                colorsHudRailcannonFullText.text = LanguageManager.CurrentLanguage.options.colors_railcannonFull;

                Text colorsHudRailcannonChargingText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "RailcannonCharging"), "Text"));
                colorsHudRailcannonChargingText.text = LanguageManager.CurrentLanguage.options.colors_railcannonPartial;

                Text colorsHudVarBlueText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "Blue Variation"), "Text"));
                colorsHudVarBlueText.text = LanguageManager.CurrentLanguage.options.colors_variationBlue;

                Text colorsHudVarGreenText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "Green Variation"), "Text"));
                colorsHudVarGreenText.text = LanguageManager.CurrentLanguage.options.colors_variationGreen;

                Text colorsHudVarRedText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "Red Variation"), "Text"));
                colorsHudVarRedText.text = LanguageManager.CurrentLanguage.options.colors_variationRed;

                Text colorsHudVarGoldText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "Gold Variation"), "Text"));
                colorsHudVarGoldText.text = LanguageManager.CurrentLanguage.options.colors_variationGold;

                //Enemy names text
                //Later down the line, could be better to get the names from EnemyBios.
                GameObject colorsEnemiesObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(colorsOptions, "Scroll Rect"), "Contents"), "Enemies");

                Text colorsEnemiesText = getTextfromGameObject(colorsEnemiesObject);

                colorsEnemiesText.text = LanguageManager.CurrentLanguage.options.colors_enemies;

                Text colorsEnemiesFilthText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Filth"), "Text"));
                colorsEnemiesFilthText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_filth;

                Text colorsEnemiesStrayText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Stray"), "Text"));
                colorsEnemiesStrayText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_stray;

                Text colorsEnemiesMalFaceText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Malicious Face"), "Text"));
                colorsEnemiesMalFaceText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_malFace;

                Text colorsEnemiesSchismText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Schism"), "Text"));
                colorsEnemiesSchismText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_schism;

                Text colorsEnemiesSwordsmachineText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Swordsmachine"), "Text"));
                colorsEnemiesSwordsmachineText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_swordsmachine;

                Text colorsEnemiesCerberusText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Cerberus"), "Text"));
                colorsEnemiesCerberusText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_cerberus;

                Text colorsEnemiesDroneText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Drone"), "Text"));
                colorsEnemiesDroneText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_drone;

                Text colorsEnemiesStreetcleanerText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Streetcleaner"), "Text"));
                colorsEnemiesStreetcleanerText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_streetCleaner;

                Text colorsEnemiesSoldierText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Shotgunner"), "Text"));
                colorsEnemiesSoldierText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_soldier;

                Text colorsEnemiesV2Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "V2"), "Text"));
                colorsEnemiesV2Text.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_v2;

                Text colorsEnemiesMindflayerText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Mindflayer"), "Text"));
                colorsEnemiesMindflayerText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_mindFlayer;

                Text colorsEnemiesVirtueText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Virtue"), "Text"));
                colorsEnemiesVirtueText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_virtue;

                Text colorsEnemiesStalkerText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Stalker"), "Text"));
                colorsEnemiesStalkerText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_stalker;

                Text colorsEnemiesSisyphusText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Sisyphus"), "Text"));
                colorsEnemiesSisyphusText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_insurrectionist;

                Text colorsEnemiesSentryText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Sentry"), "Text"));
                colorsEnemiesSentryText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_sentry;

                Text colorsEnemiesIdolText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Idol"), "Text"));
                colorsEnemiesIdolText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_idol;

                Text colorsEnemiesFerrymanText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Ferryman"), "Text"));
                colorsEnemiesFerrymanText.text = LanguageManager.CurrentLanguage.enemyNames.enemyname_ferryman;

                //Save options

                GameObject saveReloadPanel = getGameObjectChild(getGameObjectChild(getGameObjectChild(savesOptions, "Reload Consent Blocker"),"Consent"),"Panel");

                Text saveReloadText = getTextfromGameObject(getGameObjectChild(saveReloadPanel, "Text"));
                Text saveReloadYes = getTextfromGameObject(getGameObjectChild(getGameObjectChild(saveReloadPanel, "Yes"),"Text"));
                Text saveReloadNo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(saveReloadPanel, "No"), "Text"));

                saveReloadText.text =
                    "<color=red>" + LanguageManager.CurrentLanguage.options.save_warning1 + "</color>\n\n" +
                    LanguageManager.CurrentLanguage.options.save_warning2;

                saveReloadYes.text = LanguageManager.CurrentLanguage.options.save_reloadYes;
                saveReloadNo.text = LanguageManager.CurrentLanguage.options.save_reloadNo;

                GameObject saveDeletePanel = getGameObjectChild(getGameObjectChild(getGameObjectChild(savesOptions, "Wipe Consent Blocker"), "Consent"), "Panel");

                Text saveDeleteYes = getTextfromGameObject(getGameObjectChild(getGameObjectChild(saveDeletePanel, "Yes"), "Text"));
                saveDeleteYes.text = "<color=red>"+ LanguageManager.CurrentLanguage.options.save_deleteYes +"</color>";

                Text saveDeleteNo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(saveDeletePanel, "No"), "Text"));
                saveDeleteNo.text = LanguageManager.CurrentLanguage.options.save_deleteNo;

                Text saveSlotsClose = getTextfromGameObject(getGameObjectChild(getGameObjectChild(savesOptions, "Close"),"Text"));
                saveSlotsClose.text = LanguageManager.CurrentLanguage.options.save_close;
            }
        }

        public Options(ref GameObject game)
        {
            //Options are in two different locations.
            //On the main menu, it's root/Canvas/OptionsMenu.
            //In-game it's root/Canvas/OptionsMenu.
            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                this.optionsMenu = getGameObjectChild(game, "OptionsMenu");
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
                this.optionsMenu = getGameObjectChild(pauseObject, "OptionsMenu");
            }
            this.patchOptions(this.optionsMenu);
        }
    }
}
