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

        public void patchGeneralOptions(GameObject generalOptions, JsonParser language)
        {
            //General options
            Text generalText = getTextfromGameObject(getGameObjectChild(generalOptions, "Text"));
            generalText.text = "--" + language.currentLanguage.options.category_general + "--";

            GameObject generalContent = getGameObjectChild(getGameObjectChild(generalOptions, "Scroll Rect (1)"), "Contents");

            Text mouseSensitivityText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Mouse Sensitivity"), "Text"));
            mouseSensitivityText.text = language.currentLanguage.options.general_mouseSensitivity;

            Text invertXAxisText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Invert Axis"), "Text"));
            invertXAxisText.text = language.currentLanguage.options.general_xInversion;

            Text invertYAxisText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Invert Axis"), "Text (1)"));
            invertYAxisText.text = language.currentLanguage.options.general_yInversion;

            Text fovText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "FOV"), "Text"));
            fovText.text = language.currentLanguage.options.general_fieldOfVision;

            Text weaponPosText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Weapon Position"), "Text"));
            weaponPosText.text = language.currentLanguage.options.general_weaponPosition;


            //Have to patch directly from the Dropdown.OptionData list.
            GameObject weaponPosList = getGameObjectChild(getGameObjectChild(generalContent, "Weapon Position"), "Dropdown");
            Dropdown weaponPosDropdown = weaponPosList.GetComponent<Dropdown>();
            System.Collections.Generic.List<Dropdown.OptionData> weaponPosListText = weaponPosDropdown.options;
            weaponPosListText[0].text = language.currentLanguage.options.general_weaponPositionRight;
            weaponPosListText[1].text = language.currentLanguage.options.general_weaponPositionMiddle;
            weaponPosListText[2].text = language.currentLanguage.options.general_weaponPositionLeft;

            Text rememberWeaponText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Variation Memory"), "Text"));
            rememberWeaponText.text = language.currentLanguage.options.general_rememberWeapon;

            Text screenshakeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Screenshake"), "Text"));
            screenshakeText.text = language.currentLanguage.options.general_screenShake;

            Text restartWarningText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Restart Warning"), "Text"));
            restartWarningText.text = language.currentLanguage.options.general_restartWarning;

            Text cameraTiltText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Camera Tilt"), "Text"));
            cameraTiltText.text = language.currentLanguage.options.general_cameraTilt;

            Text discordText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Discord Integration"), "Text"));
            discordText.text = language.currentLanguage.options.general_discordRpc;

            Text seasonEventText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(generalContent, "Seasonal Events"), "Text"));
            seasonEventText.text = language.currentLanguage.options.general_seasonalEvent;
        }
        public void patchControlOptions(GameObject optionsMenu, JsonParser language)
        {

        }
        public void patchGraphicsOptions(GameObject optionsMenu, JsonParser language)
        {

        }
        public void patchAudioOptions(GameObject optionsMenu, JsonParser language)
        {

        }
        public void patchHUDOptions(GameObject optionsMenu, JsonParser language)
        {

        }
        public void patchAssistOptions(GameObject optionsMenu, JsonParser language)
        {

        }
        public void patchColorsOptions(GameObject optionsMenu, JsonParser language)
        {

        }
        public void patchSavesOptions(GameObject optionsMenu, JsonParser language)
        {

        }

        public void patchOptions(GameObject optionsMenu, JsonParser language)
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
                optionsText.text = language.currentLanguage.options.options_title;

                Text backText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Back"),"Text"));
                backText.text = language.currentLanguage.options.options_back;

                Text generalButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Gameplay"), "Text"));
                generalButton.text = language.currentLanguage.options.category_general;

                Text controlButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Controls"), "Text"));
                controlButton.text = language.currentLanguage.options.category_controls;

                Text graphicsButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Video"), "Text"));
                graphicsButton.text = language.currentLanguage.options.category_graphics;

                Text audioButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Audio"), "Text"));
                audioButton.text = language.currentLanguage.options.category_sound;

                Text hudButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "HUD"), "Text"));
                hudButton.text = language.currentLanguage.options.category_display;

                Text assistButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Assist"), "Text"));
                assistButton.text = language.currentLanguage.options.category_assists;

                Text colorsButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Colors"), "Text"));
                colorsButton.text = language.currentLanguage.options.category_colors;

                Text savesButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(optionsMenu, "Saves"), "Text"));
                savesButton.text = language.currentLanguage.options.category_saves;

                try
                {
                    this.patchGeneralOptions(generalOptions, language);
                    this.patchControlOptions(controlOptions, language);
                    this.patchGraphicsOptions(graphicsOptions, language);
                    this.patchAudioOptions(audioOptions, language);
                    this.patchHUDOptions(hudOptions, language);
                    this.patchAssistOptions(assistOptions, language);
                    this.patchColorsOptions(colorsOptions, language);
                    this.patchSavesOptions(savesOptions, language);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                

                //Control options

                Text controlText = getTextfromGameObject(getGameObjectChild(controlOptions, "Text (1)"));
                controlText.text = "--"+ language.currentLanguage.options.category_controls + "--";

                GameObject controlContent = getGameObjectChild(getGameObjectChild(controlOptions, "Scroll Rect"), "Contents");

                Text resetToDefaultText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Default"), "Text"));
                resetToDefaultText.text = language.currentLanguage.options.controls_resetDefault;

                Text movementText = getTextfromGameObject(getGameObjectChild(controlContent, "Text"));
                movementText.text = "--"+ language.currentLanguage.options.controls_movement+"--";

                Text moveforwardText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Forward"), "Text"));
                moveforwardText.text = language.currentLanguage.options.controls_forward;

                Text movebackText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Back"), "Text"));
                movebackText.text = language.currentLanguage.options.controls_back;

                Text moveleftText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Left"), "Text"));
                moveleftText.text = language.currentLanguage.options.controls_left;

                Text moverightText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Right"), "Text"));
                moverightText.text = language.currentLanguage.options.controls_right;

                Text jumpText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Jump"), "Text"));
                jumpText.text = language.currentLanguage.options.controls_jump;

                Text dashText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Dash"), "Text"));
                dashText.text = language.currentLanguage.options.controls_dash;

                Text actionsText = getTextfromGameObject(getGameObjectChild(controlContent, "Text (1)"));
                actionsText.text = "--"+ language.currentLanguage.options.controls_actions+ "--";

                Text primaryFireText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Fire"), "Text"));
                primaryFireText.text = language.currentLanguage.options.controls_primaryFire;

                Text secondaryFireText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Alt Fire"), "Text"));
                secondaryFireText.text = language.currentLanguage.options.controls_secondaryFire;
                secondaryFireText.fontSize = 11;

                Text punchText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Punch"), "Text"));
                punchText.text = language.currentLanguage.options.controls_punch;
                punchText.fontSize = 12;

                Text lastUsedWeaponText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Last Used Weapon"), "Text"));
                lastUsedWeaponText.text = language.currentLanguage.options.controls_lastUsedWeapon;
                lastUsedWeaponText.fontSize = 10;

                Text switchVariationText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Change Variation"), "Text"));
                switchVariationText.text = language.currentLanguage.options.controls_changeVariation;
                switchVariationText.fontSize = 11;

                Text switchArmText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Change Arm"), "Text"));
                switchArmText.text = language.currentLanguage.options.controls_changeArm;
                switchArmText.fontSize = 11;

                Text slideText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Slide"), "Text"));
                slideText.text = language.currentLanguage.options.controls_slide;

                Text whiplashText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(controlContent, "Whiplash"), "Text"));
                whiplashText.text = language.currentLanguage.options.controls_whiplash;

                GameObject weaponSettings = getGameObjectChild(controlContent, "Weapons Settings");

                Text weaponSettingsText = getTextfromGameObject(getGameObjectChild(weaponSettings, "Text (1)"));
                weaponSettingsText.text = "--"+ language.currentLanguage.options.controls_weapons + "--";

                Text slot1Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(weaponSettings, "Slot 1"),"Text"));
                slot1Text.text = language.currentLanguage.options.controls_slot1;

                Text slot2Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(weaponSettings, "Slot 2"), "Text"));
                slot2Text.text = language.currentLanguage.options.controls_slot2;

                Text slot3Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(weaponSettings, "Slot 3"), "Text"));
                slot3Text.text = language.currentLanguage.options.controls_slot3;

                Text slot4Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(weaponSettings, "Slot 4"), "Text"));
                slot4Text.text = language.currentLanguage.options.controls_slot4;

                Text slot5Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(weaponSettings, "Slot 5"), "Text"));
                slot5Text.text = language.currentLanguage.options.controls_slot5;


                GameObject mouseWheelSettings = getGameObjectChild(weaponSettings, "Mouse Wheel Settings");

                Text scrollTypeText = getTextfromGameObject(getGameObjectChild(mouseWheelSettings, "Text (1)"));
                scrollTypeText.text = language.currentLanguage.options.controls_scrollType;


                GameObject scrollTypeList = getGameObjectChild(mouseWheelSettings, "Dropdown (1)");

                Dropdown scrollTypeDropdown = scrollTypeList.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> scrollTypeDropdownText = scrollTypeDropdown.options;
                scrollTypeDropdownText[0].text = language.currentLanguage.options.controls_scrollTypeWeapons;
                scrollTypeDropdownText[1].text = language.currentLanguage.options.controls_scrollTypeVariations;
                scrollTypeDropdownText[2].text = language.currentLanguage.options.controls_scrollTypeAll;

                GameObject mouseWheelContent = getGameObjectChild(mouseWheelSettings, "Mouse Wheel to Change Weapon");

                Text changeWeaponMouseWheel = getTextfromGameObject(getGameObjectChild(mouseWheelContent, "Text"));
                changeWeaponMouseWheel.text = language.currentLanguage.options.controls_mouseWheelToChangeWeapon;

                Text reverseScrollText = getTextfromGameObject(getGameObjectChild(mouseWheelSettings, "Text"));
                reverseScrollText.text = language.currentLanguage.options.controls_reverseScroll;

                //Graphics options

                Text graphicsText = getTextfromGameObject(getGameObjectChild(graphicsOptions, "Text (1)"));
                graphicsText.text = "--"+ language.currentLanguage.options.category_graphics+ "--";

                GameObject graphicsContent = getGameObjectChild(getGameObjectChild(graphicsOptions, "Scroll Rect"), "Contents");

                Text resolutionText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Resolution"), "Text"));
                resolutionText.text = language.currentLanguage.options.graphics_resolution;

                Text fullscreenText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "FullScreen"), "Text"));
                fullscreenText.text = language.currentLanguage.options.graphics_fullscreen;

                Text fpslimitText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Framerate Limiter"), "Text"));
                fpslimitText.text = language.currentLanguage.options.graphics_maxFps;

                GameObject fpsObject = getGameObjectChild(getGameObjectChild(graphicsContent, "Framerate Limiter"), "Dropdown");
                Dropdown fpsDropdown = fpsObject.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> fpsDropdownListText = fpsDropdown.options;
                fpsDropdownListText[0].text = language.currentLanguage.options.graphics_maxFpsNone;
                fpsDropdownListText[1].text = language.currentLanguage.options.graphics_maxFps2x;


                Text vsyncText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "VSync"), "Text"));
                vsyncText.text = language.currentLanguage.options.graphics_vsync;

                Text psxFilterSettingsText = getTextfromGameObject(getGameObjectChild(graphicsContent, "Text (5)"));
                psxFilterSettingsText.text = "--"+ language.currentLanguage.options.graphics_filters+"--";

                Text psxFilterSettingsDescription = getTextfromGameObject(getGameObjectChild(graphicsContent, "Text (6)"));
                psxFilterSettingsDescription.text = language.currentLanguage.options.graphics_filtersDescription;

                Text downscalingText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Pixelization"), "Text"));
                downscalingText.text = language.currentLanguage.options.graphics_pixelisation;

                GameObject resolution = getGameObjectChild(getGameObjectChild(graphicsContent, "Pixelization"), "Dropdown (1)");
                Dropdown resolutionDropdown = resolution.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> resolutionDropdownListText = resolutionDropdown.options;

                resolutionDropdownListText[0].text = language.currentLanguage.options.graphics_pixelisationNone;
                resolutionDropdownListText[1].text = language.currentLanguage.options.graphics_pixelisation720p;
                resolutionDropdownListText[2].text = language.currentLanguage.options.graphics_pixelisation480p;
                resolutionDropdownListText[3].text = language.currentLanguage.options.graphics_pixelisation360p;
                resolutionDropdownListText[4].text = language.currentLanguage.options.graphics_pixelisation240p;
                resolutionDropdownListText[5].text = language.currentLanguage.options.graphics_pixelisation144p;
                resolutionDropdownListText[6].text = language.currentLanguage.options.graphics_pixelisation36p;


                Text ditheringText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Dithering (1)"), "Text"));
                ditheringText.text = language.currentLanguage.options.graphics_dithering;

                Text textureWarpingText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Texture Warping (1)"), "Text"));
                textureWarpingText.text = language.currentLanguage.options.graphics_textureWarping;


                Text vertexWarpingText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Vertex Warping"), "Text"));
                vertexWarpingText.text = language.currentLanguage.options.graphics_vertexWarping;

                GameObject vertexWarping = getGameObjectChild(getGameObjectChild(graphicsContent, "Vertex Warping"),"Dropdown");
                Dropdown vertexWarpingDropdown = vertexWarping.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> vertexWarpingDropdownListText = vertexWarpingDropdown.options;

                vertexWarpingDropdownListText[0].text = language.currentLanguage.options.graphics_vertexWarpingNone;
                vertexWarpingDropdownListText[1].text = language.currentLanguage.options.graphics_vertexWarpingLight;
                vertexWarpingDropdownListText[2].text = language.currentLanguage.options.graphics_vertexWarpingMedium;
                vertexWarpingDropdownListText[3].text = language.currentLanguage.options.graphics_vertexWarpingStrong;
                vertexWarpingDropdownListText[4].text = language.currentLanguage.options.graphics_vertexWarpingVeryStrong;
                vertexWarpingDropdownListText[5].text = language.currentLanguage.options.graphics_vertexWarpingAbsurd;

                Text customColorPalette = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Custom Color Palette"), "Text"));
                customColorPalette.text = language.currentLanguage.options.graphics_customColorPalette;

                Text customColorPaletteSelect = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(graphicsContent, "Custom Color Palette"), "Select"),"Text"));
                customColorPaletteSelect.text = language.currentLanguage.options.graphics_customColorPaletteSelect;


                Text colorCompressionText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Color Compression"), "Text"));
                colorCompressionText.text = language.currentLanguage.options.graphics_colorCompression;

                GameObject colorCompression = getGameObjectChild(getGameObjectChild(graphicsContent, "Color Compression"),"Dropdown");
                Dropdown colorCompressionDropdown = colorCompression.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> colorCompressionDropdownListText = colorCompressionDropdown.options;

                colorCompressionDropdownListText[0].text = language.currentLanguage.options.graphics_colorCompressionNone;
                colorCompressionDropdownListText[1].text = language.currentLanguage.options.graphics_colorCompressionLight;
                colorCompressionDropdownListText[2].text = language.currentLanguage.options.graphics_colorCompressionMedium;
                colorCompressionDropdownListText[3].text = language.currentLanguage.options.graphics_colorCompressionStrong;
                colorCompressionDropdownListText[4].text = language.currentLanguage.options.graphics_colorCompressionVeryStrong;
                colorCompressionDropdownListText[5].text = language.currentLanguage.options.graphics_colorCompressionAbsurd;

                Text performanceText = getTextfromGameObject(getGameObjectChild(graphicsContent, "Text (4)"));
                performanceText.text = "--"+ language.currentLanguage.options.graphics_performance + "--";

                Text simplifiedExplosionsText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Simplified Explosions"), "Text"));
                simplifiedExplosionsText.text = language.currentLanguage.options.graphics_performanceSimpleExplosions;

                Text simplifiedFireText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Simplified Fire"), "Text"));
                simplifiedFireText.text = language.currentLanguage.options.graphics_performanceSimpleFire;

                Text simplifiedSpawnText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Simplified Spawn Effects"), "Text"));
                simplifiedSpawnText.text = language.currentLanguage.options.graphics_performanceSimpleSpawn;

                Text disabledParticlesText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Disable Environmental Particles"), "Text"));
                disabledParticlesText.text = language.currentLanguage.options.graphics_performanceDisableEnviParticles;

                Text simpleNailPhysicsText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Simple Nail Physics"), "Text"));
                simpleNailPhysicsText.text = language.currentLanguage.options.graphics_performanceSimpleNails;

                Text goreSettingsText = getTextfromGameObject(getGameObjectChild(graphicsContent, "Text (2)"));
                goreSettingsText.text = "--"+ language.currentLanguage.options.graphics_gore+ "--";

                Text goreSettingsDescription = getTextfromGameObject(getGameObjectChild(graphicsContent, "Text (3)"));
                goreSettingsDescription.text = language.currentLanguage.options.graphics_goreNote;

                Text enableBloodandGoreText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "BloodAndGore"), "Text"));
                enableBloodandGoreText.text = language.currentLanguage.options.graphics_goreEnable;

                Text freezeGoreText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Freeze Gore"), "Text"));
                freezeGoreText.text = language.currentLanguage.options.graphics_goreDisablePhysics;

                Text bloodstainChanceText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Bloodstain Chance"), "Text"));
                bloodstainChanceText.text = language.currentLanguage.options.graphics_goreBloodChance;

                Text maxBloodText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(graphicsContent, "Max Gore"), "Text"));
                maxBloodText.text = language.currentLanguage.options.graphics_goreMaxGore;


                //Audio options
                Text audioTitle = getTextfromGameObject(getGameObjectChild(audioOptions, "Text (2)"));
                audioTitle.text = "--" + language.currentLanguage.options.audio_title + "--";

                GameObject audioContent = getGameObjectChild(audioOptions, "Image");

                Text subtitlesText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(audioContent, "Subtitles Checkbox"), "Text"));
                subtitlesText.text = language.currentLanguage.options.audio_subtitles;

                Text masterVolumeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(audioContent, "Master Volume"), "Text"));
                masterVolumeText.text = language.currentLanguage.options.audio_globalVolume;

                Text musicVolumeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(audioContent, "Music Volume"), "Text"));
                musicVolumeText.text = language.currentLanguage.options.audio_musicVolume;

                //HUD options
                Text hudTitle = getTextfromGameObject(getGameObjectChild(hudOptions, "Text"));
                hudTitle.text = "--"+ language.currentLanguage.options.hud_title + "--";

                GameObject hudContent = getGameObjectChild(getGameObjectChild(hudOptions, "Scroll Rect (1)"), "Contents");

                Text hudTypeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "HUD Type"), "Text"));
                hudTypeText.text = language.currentLanguage.options.hud_type;

                GameObject hudType = getGameObjectChild(getGameObjectChild(hudContent, "HUD Type"), "Dropdown");
                Dropdown hudTypeDropdown = hudType.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> hudTypeDropdownListText = hudTypeDropdown.options;

                hudTypeDropdownListText[0].text = language.currentLanguage.options.hud_typeNone;
                hudTypeDropdownListText[1].text = language.currentLanguage.options.hud_typeStandard;
                hudTypeDropdownListText[2].text = language.currentLanguage.options.hud_typeClassicColor;
                hudTypeDropdownListText[3].text = language.currentLanguage.options.hud_typeClassicWhite;


                Text backgroundOpacityText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Background Opacity"), "Text"));
                backgroundOpacityText.text = language.currentLanguage.options.hud_backgroundOpacity;

                Text alwaysOnTopText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Always On Top"), "Text"));
                alwaysOnTopText.text = language.currentLanguage.options.hud_alwaysOnTop;

                Text iconsText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Icons"), "Text"));
                iconsText.text = language.currentLanguage.options.hud_icons;

                Text hudElements = getTextfromGameObject(getGameObjectChild(hudContent, "-- HUD Elements -- "));
                hudElements.text = "--" + language.currentLanguage.options.hud_hudElements + "--";

                Text weaponIconText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Weapon Icon"), "Text"));
                weaponIconText.text = language.currentLanguage.options.hud_weaponIcon;

                Text armIconText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Arm Icon"), "Text"));
                armIconText.text = language.currentLanguage.options.hud_armIcon;

                Text railcannonMeterText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Railcannon Meter"), "Text"));
                railcannonMeterText.text = language.currentLanguage.options.hud_railcannonMeter;

                Text styleMeterText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Style Meter"), "Text"));
                styleMeterText.text = language.currentLanguage.options.hud_styleMeter;

                Text styleInfoText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Style Info"), "Text"));
                styleInfoText.text = language.currentLanguage.options.hud_styleInfo;

                //Crosshair settings

                Text crosshairTitle = getTextfromGameObject(getGameObjectChild(hudContent, "-- Crosshair Settings --"));
                crosshairTitle.text = "--"+ language.currentLanguage.options.crosshair_title+ "--";

                Text crosshairTypeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Crosshair Type"), "Text"));
                crosshairTypeText.text = language.currentLanguage.options.crosshair_type;

                GameObject crosshairType = getGameObjectChild(getGameObjectChild(hudContent, "Crosshair Type"), "Dropdown");
                Dropdown crosshairTypeDropdown = crosshairType.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> crosshairTypeDropdownListText = crosshairTypeDropdown.options;

                crosshairTypeDropdownListText[0].text = language.currentLanguage.options.crosshair_typeNone;
                crosshairTypeDropdownListText[1].text = language.currentLanguage.options.crosshair_typeSmall;
                crosshairTypeDropdownListText[2].text = language.currentLanguage.options.crosshair_typeLarge;

                Text crosshairColorText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Crosshair Color"), "Text"));
                crosshairColorText.text = language.currentLanguage.options.crosshair_color;

                GameObject crosshairColor = getGameObjectChild(getGameObjectChild(hudContent, "Crosshair Color"), "Dropdown");
                Dropdown crosshairColorDropdown = crosshairColor.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> crosshairColorDropdownListText = crosshairColorDropdown.options;

                crosshairColorDropdownListText[0].text = language.currentLanguage.options.crosshair_colorInverted;
                crosshairColorDropdownListText[1].text = language.currentLanguage.options.crosshair_colorWhite;
                crosshairColorDropdownListText[2].text = language.currentLanguage.options.crosshair_colorGrey;
                crosshairColorDropdownListText[3].text = language.currentLanguage.options.crosshair_colorBlack;
                crosshairColorDropdownListText[4].text = language.currentLanguage.options.crosshair_colorRed;
                crosshairColorDropdownListText[5].text = language.currentLanguage.options.crosshair_colorGreen;
                crosshairColorDropdownListText[6].text = language.currentLanguage.options.crosshair_colorBlue;
                crosshairColorDropdownListText[7].text = language.currentLanguage.options.crosshair_colorCyan;
                crosshairColorDropdownListText[8].text = language.currentLanguage.options.crosshair_colorYellow;
                crosshairColorDropdownListText[9].text = language.currentLanguage.options.crosshair_colorMagenta;

                Text crosshairHudSizeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Crosshair HUD"), "Text"));
                crosshairHudSizeText.text = language.currentLanguage.options.crosshair_size;

                GameObject crosshairSize = getGameObjectChild(getGameObjectChild(hudContent, "Crosshair HUD"), "Dropdown");
                Dropdown crosshairSizeDropdown = crosshairSize.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> crosshairSizeDropdownListText = crosshairSizeDropdown.options;

                crosshairSizeDropdownListText[0].text = language.currentLanguage.options.crosshair_sizeNone;
                crosshairSizeDropdownListText[1].text = language.currentLanguage.options.crosshair_sizeThin;
                crosshairSizeDropdownListText[2].text = language.currentLanguage.options.crosshair_sizeMedium;
                crosshairSizeDropdownListText[3].text = language.currentLanguage.options.crosshair_sizeThick;
                crosshairSizeDropdownListText[4].text = language.currentLanguage.options.crosshair_sizeVeryThick;


                Text crosshairHudFadeText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Crosshair HUD Fade Out"), "Text"));
                crosshairHudFadeText.text = language.currentLanguage.options.crosshair_hudFade;

                Text crosshairPowerupText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(hudContent, "Crosshair PowerUp Meter"), "Text"));
                crosshairPowerupText.text = language.currentLanguage.options.crosshair_powerupBar;

                //Assist options

                Text assistTitle = getTextfromGameObject(getGameObjectChild(assistOptions, "Text (1)"));
                assistTitle.text = "--"+ language.currentLanguage.options.assists_title + "--";

                GameObject assistMajorAssistPanel = getGameObjectChild(getGameObjectChild(assistOptions, "Panel"),"Panel");

                Text assistDisclaimerText = getTextfromGameObject(getGameObjectChild(assistMajorAssistPanel, "Text (2)"));
                assistDisclaimerText.text =

                    language.currentLanguage.options.assists_majorAssistsDisclaimer1
                    + "\n\n"
                    + language.currentLanguage.options.assists_majorAssistsDisclaimer2
                    + "\n\n"
                    + language.currentLanguage.options.assists_majorAssistsDisclaimer3;
                assistDisclaimerText.fontSize = 18;

                Text assistDisclaimerConfirmText = getTextfromGameObject(getGameObjectChild(assistMajorAssistPanel, "Text (1)"));
                assistDisclaimerConfirmText.text = language.currentLanguage.options.assists_majorAssistsDisclaimerConfirm;

                assistDisclaimerConfirmText.fontSize = 24;

                Text assistDisclaimerYesText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistMajorAssistPanel, "Yes"),"Text"));
                assistDisclaimerYesText.text = language.currentLanguage.options.assists_majorAssistsDisclaimerConfirmYes;

                Text assistDisclaimerNoText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistMajorAssistPanel, "No"), "Text"));
                assistDisclaimerNoText.text = language.currentLanguage.options.assists_majorAssistsDisclaimerConfirmNo;

                GameObject assistContent = getGameObjectChild(getGameObjectChild(assistOptions, "Scroll Rect"), "Contents");

                Text assistMinorAssistText = getTextfromGameObject(getGameObjectChild(assistContent, "Text (5)"));
                assistMinorAssistText.text = "--"+ language.currentLanguage.options.assists_minor +"--";

                Text assistAutoAimText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistContent, "Auto Aim"),"Text (1)"));
                assistAutoAimText.text = language.currentLanguage.options.assists_autoAim;

                Text assistAutoAimAmountText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistContent, "Auto Aim Amount"), "Text (1)"));
                assistAutoAimAmountText.text = language.currentLanguage.options.assists_autoAimPercent;

                Text assistEnemySilhouettesTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistContent, "Enemy Simplifier (1)"), "Text (1)"));
                assistEnemySilhouettesTitle.text = language.currentLanguage.options.assists_enemySilhouettes;

                GameObject assistEnemySilhouettes = getGameObjectChild(assistContent, "Enemy Simplifier (1)");

                Text assistEnemySilhouettesOutlineText = getTextfromGameObject(getGameObjectChild(assistEnemySilhouettes, "Text (1)"));
                assistEnemySilhouettesOutlineText.text = language.currentLanguage.options.assists_enemySilhouettesOutlines;

                GameObject assistEnemySilhouettesExtra = getGameObjectChild(assistContent, "Enemy Simplifier");

                Text assistEnemySilhouettesDistance = getTextfromGameObject(getGameObjectChild(assistEnemySilhouettesExtra, "Text (1)"));
                assistEnemySilhouettesDistance.text = language.currentLanguage.options.assists_enemySilhouettesDistance;

                Text assistEnemySilhouettesOutlinesOnlyText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistEnemySilhouettesExtra, "Extra"),"Text (2)"));
                assistEnemySilhouettesOutlinesOnlyText.text = language.currentLanguage.options.assists_enemySilhouettes;

                GameObject assistsMajor = getGameObjectChild(assistContent, "Major Assists");
                Text assistsMajorTitle = getTextfromGameObject(assistsMajor);

                assistsMajorTitle.text = "--"+ language.currentLanguage.options.assists_major +"--";
                assistsMajorTitle.fontSize = 20;

                Text assistsMajorActivateText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Enable"),"Text (1)"));
                assistsMajorActivateText.text = language.currentLanguage.options.assists_majorActivate;

                Text assistsMajorGameSpeedText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Game Speed"), "Text (1)"));
                assistsMajorGameSpeedText.text = language.currentLanguage.options.assists_gameSpeed;

                Text assistsDamageTakenText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Damage Taken"), "Text (1)"));
                assistsDamageTakenText.text = language.currentLanguage.options.assists_damageTaken;

                Text assistsBossOverrideText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Boss Difficulty Override"), "Text"));
                assistsBossOverrideText.text = language.currentLanguage.options.assists_bossOverride;

                GameObject bossOverride = getGameObjectChild(getGameObjectChild(assistsMajor, "Boss Difficulty Override"), "Dropdown");
                Dropdown bossOverrideDropdown = bossOverride.GetComponent<Dropdown>();
                System.Collections.Generic.List<Dropdown.OptionData> bossOverrideDropdownListText = bossOverrideDropdown.options;

                bossOverrideDropdownListText[0].text = language.currentLanguage.options.assists_bossOverrideNone;
                bossOverrideDropdownListText[1].text = language.currentLanguage.frontend.difficulty_harmless;
                bossOverrideDropdownListText[2].text = language.currentLanguage.frontend.difficulty_lenient;
                bossOverrideDropdownListText[3].text = language.currentLanguage.frontend.difficulty_standard;
                bossOverrideDropdownListText[4].text = language.currentLanguage.frontend.difficulty_violent;

                Text assistsBossRestartText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Boss Difficulty Override"), "Text (1)"));
                assistsBossRestartText.text = language.currentLanguage.options.assists_bossRestartRequired;

                Text assistsInfiniteStaminaText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Infinite Stamina"), "Text (1)"));
                assistsInfiniteStaminaText.text = language.currentLanguage.options.assists_infiniteEnergy;

                Text assistsDisableWhiplashHardDamageText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Disable Whiplash Hard Damage"), "Text (1)"));
                assistsDisableWhiplashHardDamageText.text = language.currentLanguage.options.assists_disableWhiplashHardDamage;

                Text assistsDisableHardDamageText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Disable Hard Damage"), "Text (1)"));
                assistsDisableHardDamageText.text = language.currentLanguage.options.assists_disableHardDamage;

                Text assistsDisableWeaponFreshnessText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Disable Weapon Freshness"), "Text (1)"));
                assistsDisableWeaponFreshnessText.text = language.currentLanguage.options.assists_disableWeaponFreshness;

                Text assistsDisablePopupText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(assistsMajor, "Disable Popup"), "Text (1)"));
                assistsDisablePopupText.text = language.currentLanguage.options.assists_disablePopupHints;

                //Colors options
                Text colorsPanel = getTextfromGameObject(getGameObjectChild(colorsOptions, "Text (1)"));
                colorsPanel.text = "--" + colorsButton.text + "--";

                Text colorsResetDefaultText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(colorsOptions,"Scroll Rect"),"Contents"),"Default"),"Text"));
                colorsResetDefaultText.text = language.currentLanguage.options.colors_reset;

                //HUD Text
                GameObject colorsHudObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(colorsOptions, "Scroll Rect"),"Contents"),"HUD");

                Text colorsHudHealthText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject,"Health"),"Text"));
                colorsHudHealthText.text = language.currentLanguage.options.colors_hudHealth;

                Text colorsHudHealthNumberText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "HpText"), "Text"));
                colorsHudHealthNumberText.text = language.currentLanguage.options.colors_hudHealthNumber;

                Text colorsHudSoftDamageText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "AfterImage"), "Text"));
                colorsHudSoftDamageText.text = language.currentLanguage.options.colors_hudDamage;

                Text colorsHudHardDamageText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "AntiHp"), "Text"));
                colorsHudHardDamageText.text = language.currentLanguage.options.colors_hudHardDamage;

                Text colorsHudOverhealText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "Overheal"), "Text"));
                colorsHudOverhealText.text = language.currentLanguage.options.colors_hudOverheal;

                Text colorsHudStaminaText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "Stamina"), "Text"));
                colorsHudStaminaText.text = language.currentLanguage.options.colors_hudEnergyFull;

                Text colorsHudStaminaChargingText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "StaminaCharging"), "Text"));
                colorsHudStaminaChargingText.text = language.currentLanguage.options.colors_hudEnergyPartial;

                Text colorsHudStaminaEmptyText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "StaminaEmpty"), "Text"));
                colorsHudStaminaEmptyText.text = language.currentLanguage.options.colors_hudEnergyEmpty;

                Text colorsHudRailcannonFullText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "RailcannonFull"), "Text"));
                colorsHudRailcannonFullText.text = language.currentLanguage.options.colors_railcannonFull;

                Text colorsHudRailcannonChargingText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "RailcannonCharging"), "Text"));
                colorsHudRailcannonChargingText.text = language.currentLanguage.options.colors_railcannonPartial;

                Text colorsHudVarBlueText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "Blue Variation"), "Text"));
                colorsHudVarBlueText.text = language.currentLanguage.options.colors_variationBlue;

                Text colorsHudVarGreenText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "Green Variation"), "Text"));
                colorsHudVarGreenText.text = language.currentLanguage.options.colors_variationGreen;

                Text colorsHudVarRedText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "Red Variation"), "Text"));
                colorsHudVarRedText.text = language.currentLanguage.options.colors_variationRed;

                Text colorsHudVarGoldText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsHudObject, "Gold Variation"), "Text"));
                colorsHudVarGoldText.text = language.currentLanguage.options.colors_variationGold;

                //Enemy names text
                //Later down the line, could be better to get the names from EnemyBios.
                GameObject colorsEnemiesObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(colorsOptions, "Scroll Rect"), "Contents"), "Enemies");

                Text colorsEnemiesText = getTextfromGameObject(colorsEnemiesObject);

                colorsEnemiesText.text = language.currentLanguage.options.colors_enemies;

                Text colorsEnemiesFilthText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Filth"), "Text"));
                colorsEnemiesFilthText.text = language.currentLanguage.enemyNames.enemyname_filth;

                Text colorsEnemiesStrayText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Stray"), "Text"));
                colorsEnemiesStrayText.text = language.currentLanguage.enemyNames.enemyname_stray;

                Text colorsEnemiesMalFaceText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Malicious Face"), "Text"));
                colorsEnemiesMalFaceText.text = language.currentLanguage.enemyNames.enemyname_malFace;

                Text colorsEnemiesSchismText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Schism"), "Text"));
                colorsEnemiesSchismText.text = language.currentLanguage.enemyNames.enemyname_schism;

                Text colorsEnemiesSwordsmachineText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Swordsmachine"), "Text"));
                colorsEnemiesSwordsmachineText.text = language.currentLanguage.enemyNames.enemyname_swordsmachine;

                Text colorsEnemiesCerberusText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Cerberus"), "Text"));
                colorsEnemiesCerberusText.text = language.currentLanguage.enemyNames.enemyname_cerberus;

                Text colorsEnemiesDroneText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Drone"), "Text"));
                colorsEnemiesDroneText.text = language.currentLanguage.enemyNames.enemyname_drone;

                Text colorsEnemiesStreetcleanerText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Streetcleaner"), "Text"));
                colorsEnemiesStreetcleanerText.text = language.currentLanguage.enemyNames.enemyname_streetCleaner;

                Text colorsEnemiesSoldierText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Shotgunner"), "Text"));
                colorsEnemiesSoldierText.text = language.currentLanguage.enemyNames.enemyname_soldier;

                Text colorsEnemiesV2Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "V2"), "Text"));
                colorsEnemiesV2Text.text = language.currentLanguage.enemyNames.enemyname_v2;

                Text colorsEnemiesMindflayerText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Mindflayer"), "Text"));
                colorsEnemiesMindflayerText.text = language.currentLanguage.enemyNames.enemyname_mindFlayer;

                Text colorsEnemiesVirtueText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Virtue"), "Text"));
                colorsEnemiesVirtueText.text = language.currentLanguage.enemyNames.enemyname_virtue;

                Text colorsEnemiesStalkerText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Stalker"), "Text"));
                colorsEnemiesStalkerText.text = language.currentLanguage.enemyNames.enemyname_stalker;

                Text colorsEnemiesSisyphusText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Sisyphus"), "Text"));
                colorsEnemiesSisyphusText.text = language.currentLanguage.enemyNames.enemyname_insurrectionist;

                Text colorsEnemiesSentryText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Sentry"), "Text"));
                colorsEnemiesSentryText.text = language.currentLanguage.enemyNames.enemyname_sentry;

                Text colorsEnemiesIdolText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Idol"), "Text"));
                colorsEnemiesIdolText.text = language.currentLanguage.enemyNames.enemyname_idol;

                Text colorsEnemiesFerrymanText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(colorsEnemiesObject, "Ferryman"), "Text"));
                colorsEnemiesFerrymanText.text = language.currentLanguage.enemyNames.enemyname_ferryman;

                //Save options

                GameObject saveReloadPanel = getGameObjectChild(getGameObjectChild(getGameObjectChild(savesOptions, "Reload Consent Blocker"),"Consent"),"Panel");

                Text saveReloadText = getTextfromGameObject(getGameObjectChild(saveReloadPanel, "Text"));
                Text saveReloadYes = getTextfromGameObject(getGameObjectChild(getGameObjectChild(saveReloadPanel, "Yes"),"Text"));
                Text saveReloadNo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(saveReloadPanel, "No"), "Text"));

                saveReloadText.text =
                    "<color=red>" + language.currentLanguage.options.save_warning1 + "</color>\n\n" +
                    language.currentLanguage.options.save_warning2;

                saveReloadYes.text = language.currentLanguage.options.save_reloadYes;
                saveReloadNo.text = language.currentLanguage.options.save_reloadNo;

                GameObject saveDeletePanel = getGameObjectChild(getGameObjectChild(getGameObjectChild(savesOptions, "Wipe Consent Blocker"), "Consent"), "Panel");

                Text saveDeleteYes = getTextfromGameObject(getGameObjectChild(getGameObjectChild(saveDeletePanel, "Yes"), "Text"));
                saveDeleteYes.text = "<color=red>"+ language.currentLanguage.options.save_deleteYes +"</color>";

                Text saveDeleteNo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(saveDeletePanel, "No"), "Text"));
                saveDeleteNo.text = language.currentLanguage.options.save_deleteNo;

                Text saveSlotsClose = getTextfromGameObject(getGameObjectChild(getGameObjectChild(savesOptions, "Close"),"Text"));
                saveSlotsClose.text = language.currentLanguage.options.save_close;
            }
        }

        public Options(ref GameObject game, JsonParser language)
        {
            //Options are in two different locations.
            //On the main menu, it's root/Canvas/OptionsMenu.
            //In-game it's root/Canvas/OptionsMenu.
            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                Console.WriteLine("Patching options menu from Main Menu");
                this.optionsMenu = getGameObjectChild(game, "OptionsMenu");
            }
            else
            {
                Console.WriteLine("Patching options menu from in-level");

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
            this.patchOptions(this.optionsMenu,language);
        }
    }
}
