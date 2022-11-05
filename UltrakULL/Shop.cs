using BepInEx;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UltrakULL;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Shop
    {
        public static void patchShopFrontEnd(ref GameObject coreGame)
        {

            //NOTE
            //Harmless, but still present, exception that happens, in a normal level when trying to patch the Return From Cyber Grind button
            //since it isn't active. Will need to fix since an exception here prevents any code to come from running
            //Commented out the offending block for now. Scroll down a bit to see it.

            coreGame = GameObject.Find("FirstRoom");

            //FirstRoom/Room/Shop/Canvas
            GameObject shopObject;
            if (SceneManager.GetActiveScene().name == "uk_construct")
            {
                shopObject = getGameObjectChild(GameObject.Find("Shop"),"Canvas");
            }
            else if(SceneManager.GetActiveScene().name.Contains("P-"))
            {
                shopObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(GameObject.Find("Prime FirstRoom"),"Room"),"Shop"),"Canvas");
            }
            else
            {
                Console.WriteLine("Normal level");

                shopObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(coreGame, "Room"), "Shop"), "Canvas");
            }

            //Tip panel
            GameObject tipPanel = getGameObjectChild(getGameObjectChild(shopObject, "TipBox"), "Panel");
            Text tipTitle = getTextfromGameObject(getGameObjectChild(tipPanel, "Title"));
            tipTitle.text = LanguageManager.CurrentLanguage.shop.shop_tipofthedayTitle;

            Text tipDescription = getTextfromGameObject(getGameObjectChild(tipPanel, "TipText"));
            tipDescription.text = StringsParent.getLevelTip();

            //Weapons button
            GameObject mainButtons = getGameObjectChild(shopObject, "Main Menu");

            Text weaponsButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "WeaponsButton"), "Text"));
            weaponsButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_weapons;

            //Enemies button
            Text enemiesButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "EnemiesButton"), "Text"));
            enemiesButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_monsters;

            //CG buttons
            Text cgButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "CyberGrindButton"), "Text"));
            cgButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_cybergrind;

            Text cgReturnButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "ReturnButton"), "Text"));
            cgReturnButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_returnToMission;

            //Sandbox button
            Text sandboxButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "SandboxButton"), "Text"));
            sandboxButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_sandbox;

            //Enemies title
            Text enemiesTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "Enemies"), "Panel"),"Title"));
            enemiesTitle.text = LanguageManager.CurrentLanguage.shop.shop_monsters;

            //Enemies back button
            Text enemiesBackButtonText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "Enemies"),"BackButton (2)"),"Text"));

            //Sandbox enter description
            GameObject sandboxEnter = getGameObjectChild(getGameObjectChild(shopObject, "Sandbox"), "Panel");

            Text sandboxTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "Sandbox"), "Panel"),"Title"));
            sandboxTitle.text = LanguageManager.CurrentLanguage.shop.shop_sandbox;

            Text sandboxEnterTitle = getTextfromGameObject(getGameObjectChild(sandboxEnter, "Title"));
            sandboxButtonTitle.text = sandboxButtonTitle.text;

            Text sandboxEnterDescription = getTextfromGameObject(getGameObjectChild(sandboxEnter, "Text"));

            sandboxEnterDescription.text = LanguageManager.CurrentLanguage.shop.shop_sandboxDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_sandboxDescription2;

            Text sandboxEnterButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(sandboxEnter, "SandboxButton (1)"), "Text"));
            sandboxEnterButton.text = LanguageManager.CurrentLanguage.shop.shop_sandboxEnter;


            //CG enter description

            GameObject cgEnter = getGameObjectChild(getGameObjectChild(shopObject, "The Cyber Grind"), "Panel");

            Text cgEnterTitle = getTextfromGameObject(getGameObjectChild(cgEnter, "Title"));
            cgEnterTitle.text = "LE CYBERGRIND";

            Text cgEnterDescription = getTextfromGameObject(getGameObjectChild(cgEnter, "Text"));

            cgEnterDescription.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription3;

            Text cgEnterButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgEnter, "CyberGrindButton (1)"), "Text"));
            cgEnterButton.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindEnter;

            
            
            //CG exit description
            GameObject cgExit = getGameObjectChild(getGameObjectChild(shopObject, "Return from Cyber Grind"), "Panel");

            Text cgExitTitle = getTextfromGameObject(getGameObjectChild(cgExit, "Title"));
            cgExitTitle.text = "EXIT TITLE"; // LanguageManager.CurrentLanguage.cyberGrind.cybergrind_leavingTitle;

            
            //Disable the LevelNameFinder component so it doesn't remove the translated string!
            GameObject levelText = getGameObjectChild(cgExit, "Text");

            Text cgExitDescriptionText = getTextfromGameObject(getGameObjectChild(cgExit, "Text"));

            Text cgExitDescription = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgExit, "CyberGrindButton (1)"), "Text"));
            cgExitDescription.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindExit;


            //Enemies back button 
            Text enemiesBackText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "Enemies"), "BackButton (2)"), "Text"));
            //enemiesBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Sandbox back button
            Text sandboxBackText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "Sandbox"), "BackButton (2)"), "Text"));
            //sandboxBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //EnemyInfo back button
            Text enemyInfoBackText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "EnemyInfo"),"Button"),"Text"));
            //enemyInfoBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;


        }

        public static void patchWeapons(ref GameObject coreGame)
        {
            GameObject shopWeaponsObject;
            if (SceneManager.GetActiveScene().name == "uk_construct")
            {
                shopWeaponsObject = getGameObjectChild(getGameObjectChild(GameObject.Find("Shop"), "Canvas"),"Weapons");
            }
            else if (SceneManager.GetActiveScene().name.Contains("P-"))
            {
                shopWeaponsObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(GameObject.Find("Prime FirstRoom"), "Room"), "Shop"), "Canvas"), "Weapons");
            }
            else
            {
                shopWeaponsObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(coreGame, "Room"), "Shop"), "Canvas"), "Weapons");
            }


            Text weaponBackText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "BackButton (1)"), "Text"));
            weaponBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

            Text weaponRevolverText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "RevolverButton"), "Text"));
            weaponRevolverText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

            Text weaponShotgunText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "ShotgunButton"), "Text"));
            weaponShotgunText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;

            Text weaponNailgunText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "NailgunButton"), "Text"));
            weaponNailgunText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

            //Slight problem - not all the text fits in the box.
            //The longer text is, the more we'll need to reduce the font size to compensate.
            Text weaponRailcannonText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "RailcannonButton"), "Text"));
            weaponRailcannonText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;
            weaponRailcannonText.fontSize = 16;

            Text rocketLauncherText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "RocketLauncherButton"), "Text"));
            rocketLauncherText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;
            rocketLauncherText.fontSize = 16;

            Text weaponArmText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "ArmButton"), "Text"));
            weaponArmText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsArms;

            //Revolver window and descriptions
            GameObject revolverWindow = getGameObjectChild(shopWeaponsObject, "RevolverWindow");

            //Piercer
            GameObject piercer = getGameObjectChild(revolverWindow, "Variation Panel (Blue)");
            Text piercerName = getTextfromGameObject(getGameObjectChild(piercer, "Text"));
            piercerName.text = LanguageManager.CurrentLanguage.shop.shop_revolverPiercer;

            GameObject piercerWindow = getGameObjectChild(revolverWindow, "Variation Info (Blue)");
            Text piercerWindowName = getTextfromGameObject(getGameObjectChild(piercerWindow, "Name"));
            piercerWindowName.text = piercerName.text;

            Text piercerWindowDescription = getTextfromGameObject(getGameObjectChild(piercerWindow, "Description"));
            piercerWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription2;

            Text piercerWindowDescriptionBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(piercerWindow, "Button"),"Text"));
            piercerWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

            //Marksman
            GameObject marksman = getGameObjectChild(revolverWindow, "Variation Panel (Green)");
            Text marksmanName = getTextfromGameObject(getGameObjectChild(marksman, "Text"));
            marksmanName.text = LanguageManager.CurrentLanguage.shop.shop_revolverMarksman;
            marksmanName.fontSize = 14;

            GameObject marksmanWindow = getGameObjectChild(revolverWindow, "Variation Info (Green)");
            Text marksmanWindowName = getTextfromGameObject(getGameObjectChild(marksmanWindow, "Name"));
            marksmanWindowName.text = marksmanName.text;

            Text marksmanWindowDescription = getTextfromGameObject(getGameObjectChild(marksmanWindow, "Description"));
            marksmanWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription3;
            marksmanWindowDescription.fontSize = 14;

            Text marksmanWindowDescriptionBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(marksmanWindow, "Button"), "Text"));
            marksmanWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

            //Revolver red variation (under construction)
            GameObject revolverRedVariation = getGameObjectChild(revolverWindow, "Variation Panel (Red)");
            Text revolverRedUnderConstruction = getTextfromGameObject(getGameObjectChild(revolverRedVariation, "Text (1)"));
            revolverRedUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

            //Revolver info & color tabs
            GameObject revolverExtra = getGameObjectChild(revolverWindow, "Info and Color Panel");
            GameObject revolverExtraInfo = getGameObjectChild(revolverExtra, "InfoButton");
            GameObject revolverExtraColor = getGameObjectChild(revolverExtra, "ColorButton");

            Text revolverExtraInfoText = getTextfromGameObject(getGameObjectChild(revolverExtraInfo, "Text"));
            revolverExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

            Text revolverExtraInfoColors = getTextfromGameObject(getGameObjectChild(revolverExtraColor, "Text"));
            revolverExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

            //Revolver lore
            GameObject revolverLore = getGameObjectChild(revolverWindow, "Info Screen");
            Text revolverLoreName = getTextfromGameObject(getGameObjectChild(revolverLore, "Name"));
            revolverLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

            Text revolverLoreInfo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverLore,"Scroll View"),"Viewport"),"Text"));

            revolverLoreInfo.text =
                LanguageManager.CurrentLanguage.shop.shop_data + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver3 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver4 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver5 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_strategy + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver6 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver7 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver8 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver9 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver10;

            Text revolverLoreBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(revolverLore, "Button"), "Text"));
            revolverLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

            //Revolver preset colors
            GameObject revolverColorWindow = getGameObjectChild(revolverWindow, "Color Screen");

            Text revolverColorWindowTitle = getTextfromGameObject(getGameObjectChild(revolverColorWindow,"Title"));
            revolverColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver + "--";

            GameObject revolverStandardTemplates = getGameObjectChild(getGameObjectChild(revolverColorWindow, "Standard"),"Template");
            Text revolverStandardTemplate1 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverStandardTemplates, "Template 1"),"Button (Selectable)"),"Text"));
            Text revolverStandardTemplate2 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
            Text revolverStandardTemplate3 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
            Text revolverStandardTemplate4 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
            Text revolverStandardTemplate5 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

            revolverStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset1;
            revolverStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset2;
            revolverStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset3;
            revolverStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset4;
            revolverStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset5;

            Text revolverColorSwitchToAlternative = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverColorWindow, "Standard"),"AlternateButton"),"Text"));
            revolverColorSwitchToAlternative.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

            Text revolverColorSwitchToStandard = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverColorWindow, "Alternate"), "AlternateButton"), "Text"));
            revolverColorSwitchToStandard.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

            GameObject revolverAlternateTemplates = getGameObjectChild(getGameObjectChild(revolverColorWindow, "Alternate"), "Template");
            Text revolverAlternateTemplate1 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverAlternateTemplates, "Template 1"), "Button (Selectable)"), "Text"));
            Text revolverAlternateTemplate2 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverAlternateTemplates, "Template 2"), "Button (Selectable)"), "Text"));
            Text revolverAlternateTemplate3 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverAlternateTemplates, "Template 3"), "Button (Selectable)"), "Text"));
            Text revolverAlternateTemplate4 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverAlternateTemplates, "Template 4"), "Button (Selectable)"), "Text"));
            Text revolverAlternateTemplate5 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverAlternateTemplates, "Template 5"), "Button (Selectable)"), "Text"));

            revolverAlternateTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset1;
            revolverAlternateTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset2;
            revolverAlternateTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset3;
            revolverAlternateTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset4;
            revolverAlternateTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset5;

            Text revolverColorStandardPreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(revolverStandardTemplates, "TemplateButton"),"Text"));
            revolverColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

            Text revolverColorStandardCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(revolverStandardTemplates, "CustomButton"),"Text"));
            revolverColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            Text revolverColorAlternatePreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(revolverAlternateTemplates, "TemplateButton"), "Text"));
            revolverColorAlternatePreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

            Text revolverColorAlternateCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(revolverAlternateTemplates, "CustomButton"), "Text"));
            revolverColorAlternateCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            Text revolverColorDone = getTextfromGameObject(getGameObjectChild(getGameObjectChild(revolverColorWindow, "Done"),"Text"));
            revolverColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

            //Revolver custom colors
            GameObject revolverStandardCustom = getGameObjectChild(getGameObjectChild(revolverColorWindow, "Standard"),"Custom");
            Text revolverStandardCustomPreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(revolverStandardCustom, "TemplateButton"), "Text"));
            revolverStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
            Text revolverStandardCustomCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(revolverStandardCustom, "CustomButton"), "Text"));
            revolverStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            GameObject revolverAlternateCustom = getGameObjectChild(getGameObjectChild(revolverColorWindow, "Alternate"), "Custom");
            Text revolverAlternateCustomPreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(revolverAlternateCustom, "TemplateButton"), "Text"));
            revolverAlternateCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
            Text revolverAlternateCustomCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(revolverAlternateCustom, "CustomButton"), "Text"));
            revolverAlternateCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            //Shotgun window and descriptions
            GameObject shotgunWindow = getGameObjectChild(shopWeaponsObject, "ShotgunWindow");

            //Core Eject
            GameObject coreEject = getGameObjectChild(shotgunWindow, "Variation Panel (Blue)");
            Text coreEjectName = getTextfromGameObject(getGameObjectChild(coreEject, "Text"));
            coreEjectName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject;

            GameObject coreEjectWindow = getGameObjectChild(shotgunWindow, "Variation Info (Blue)");
            Text coreEjectWindowName = getTextfromGameObject(getGameObjectChild(coreEjectWindow, "Name"));
            coreEjectWindowName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject;

            Text coreEjectWindowDescription = getTextfromGameObject(getGameObjectChild(coreEjectWindow, "Description"));
            coreEjectWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription3;

            Text coreEjectWindowDescriptionBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(coreEjectWindow, "Button"), "Text"));
            coreEjectWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

            //Pump Charge
            GameObject pumpCharge = getGameObjectChild(shotgunWindow, "Variation Panel (Green)");
            Text pumpChargeName = getTextfromGameObject(getGameObjectChild(pumpCharge, "Text"));
            pumpChargeName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge;
            pumpChargeName.fontSize = 16;

            GameObject pumpChargeWindow = getGameObjectChild(shotgunWindow, "Variation Info (Green)");
            Text pumpChargeWindowName = getTextfromGameObject(getGameObjectChild(pumpChargeWindow, "Name"));
            pumpChargeWindowName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge;

            Text pumpChargeWindowDescription = getTextfromGameObject(getGameObjectChild(pumpChargeWindow, "Description"));
            pumpChargeWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription2;
            pumpChargeWindowDescription.fontSize = 14;

            Text pumpChargeWindowDescriptionBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pumpChargeWindow, "Button"), "Text"));
            pumpChargeWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

            //Shotgun red variation (under construction)
            GameObject shotgunRedVariation = getGameObjectChild(shotgunWindow, "Variation Panel (Red)");
            Text shotgunRedUnderConstruction = getTextfromGameObject(getGameObjectChild(shotgunRedVariation, "Text (1)"));
            shotgunRedUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

            //Shotgun info & color tabs
            GameObject shotgunExtra = getGameObjectChild(shotgunWindow, "Info and Color Panel");
            GameObject shotgunExtraInfo = getGameObjectChild(shotgunExtra, "InfoButton");
            GameObject shotgunExtraColor = getGameObjectChild(shotgunExtra, "ColorButton");

            Text shotgunExtraInfoText = getTextfromGameObject(getGameObjectChild(shotgunExtraInfo, "Text"));
            shotgunExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

            Text shotgunExtraInfoColors = getTextfromGameObject(getGameObjectChild(shotgunExtraColor, "Text"));
            shotgunExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

            //Shotgun lore
            GameObject shotgunLore = getGameObjectChild(shotgunWindow, "Info Screen");
            Text shotgunLoreName = getTextfromGameObject(getGameObjectChild(shotgunLore, "Name"));
            shotgunLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;

            Text shotgunLoreInfo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shotgunLore, "Scroll View"), "Viewport"), "Text"));

            shotgunLoreInfo.text =
                LanguageManager.CurrentLanguage.shop.shop_data + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun3 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun4 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun5 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_strategy + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun6 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun7 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun8 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun9;

            Text shotgunLoreBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shotgunLore, "Button"), "Text"));
            shotgunLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

            //Shotgun preset colors
            GameObject shotgunColorWindow = getGameObjectChild(shotgunWindow, "Color Screen");

            Text shotgunColorWindowTitle = getTextfromGameObject(getGameObjectChild(shotgunColorWindow, "Title"));
            shotgunColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun + "--";

            GameObject shotgunStandardTemplates = getGameObjectChild(getGameObjectChild(shotgunColorWindow, "Standard"), "Template");
            Text shotgunStandardTemplate1 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shotgunStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
            Text shotgunStandardTemplate2 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shotgunStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
            Text shotgunStandardTemplate3 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shotgunStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
            Text shotgunStandardTemplate4 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shotgunStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
            Text shotgunStandardTemplate5 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shotgunStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

            shotgunStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset1;
            shotgunStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset2;
            shotgunStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset3;
            shotgunStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset4;
            shotgunStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset5;

            Text shotgunColorStandardPreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shotgunStandardTemplates, "TemplateButton"), "Text"));
            shotgunColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

            Text shotgunColorStandardCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shotgunStandardTemplates, "CustomButton"), "Text"));
            shotgunColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            Text shotgunColorDone = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shotgunColorWindow, "Done"), "Text"));
            shotgunColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

            //Shotgun custom colors
            GameObject shotgunStandardCustom = getGameObjectChild(getGameObjectChild(shotgunColorWindow, "Standard"), "Custom");
            Text shotgunStandardCustomPreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shotgunStandardCustom, "TemplateButton"), "Text"));
            shotgunStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
            Text shotgunStandardCustomCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shotgunStandardCustom, "CustomButton"), "Text"));
            shotgunStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            //Nailgun window and descriptions
            GameObject nailgunWindow = getGameObjectChild(shopWeaponsObject, "NailgunWindow");

            //Attractor
            GameObject attractor = getGameObjectChild(nailgunWindow, "Variation Panel (Blue)");
            Text attractorName = getTextfromGameObject(getGameObjectChild(attractor, "Text"));
            attractorName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet;

            GameObject attractorWindow = getGameObjectChild(nailgunWindow, "Variation Info (Blue)");
            Text attractorWindowName = getTextfromGameObject(getGameObjectChild(attractorWindow, "Name"));
            attractorWindowName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet;

            Text attractorWindowDescription = getTextfromGameObject(getGameObjectChild(attractorWindow, "Description"));
            attractorWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription2;
            attractorWindowDescription.fontSize = 16;

            Text attractorWindowDescriptionBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(attractorWindow, "Button"), "Text"));
            attractorWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

            //Overheat
            GameObject overheat = getGameObjectChild(nailgunWindow, "Variation Panel (Green)");
            Text overheatName = getTextfromGameObject(getGameObjectChild(overheat, "Text"));
            overheatName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;
            overheatName.fontSize = 16;

            GameObject overheatWindow = getGameObjectChild(nailgunWindow, "Variation Info (Green)");
            Text overheatWindowName = getTextfromGameObject(getGameObjectChild(overheatWindow, "Name"));
            overheatWindowName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;

            Text overheatWindowDescription = getTextfromGameObject(getGameObjectChild(overheatWindow, "Description"));
            overheatWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription2;
            overheatWindowDescription.fontSize = 14;

            Text overheatWindowDescriptionBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(overheatWindow, "Button"), "Text"));
            overheatWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

            //Nailgun red variation (under construction)
            GameObject nailgunRedVariation = getGameObjectChild(nailgunWindow, "Variation Panel (Red)");
            Text nailgunRedUnderConstruction = getTextfromGameObject(getGameObjectChild(nailgunRedVariation, "Text (1)"));
            nailgunRedUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

            //Nailgun info & color tabs
            GameObject nailgunExtra = getGameObjectChild(nailgunWindow, "Info and Color Panel");
            GameObject nailgunExtraInfo = getGameObjectChild(nailgunExtra, "InfoButton");
            GameObject nailgunExtraColor = getGameObjectChild(nailgunExtra, "ColorButton");

            Text nailgunExtraInfoText = getTextfromGameObject(getGameObjectChild(nailgunExtraInfo, "Text"));
            nailgunExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

            Text nailgunExtraInfoColors = getTextfromGameObject(getGameObjectChild(nailgunExtraColor, "Text"));
            nailgunExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

            //Nailgun lore
            GameObject nailgunLore = getGameObjectChild(nailgunWindow, "Info Screen");
            Text nailgunLoreName = getTextfromGameObject(getGameObjectChild(nailgunLore, "Name"));
            nailgunLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

            Text nailgunLoreInfo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunLore, "Scroll View"), "Viewport"), "Text"));
            nailgunLoreInfo.text =
                LanguageManager.CurrentLanguage.shop.shop_data + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun3 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun4 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_strategy + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun5 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun6 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun7 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun8 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun9;

            Text nailgunLoreBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nailgunLore, "Button"), "Text"));
            nailgunLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;


            //Nailgun preset colors
            GameObject nailgunColorWindow = getGameObjectChild(nailgunWindow, "Color Screen");

            Text nailgunColorWindowTitle = getTextfromGameObject(getGameObjectChild(nailgunColorWindow, "Title"));
            nailgunColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun + "--";

            GameObject nailgunStandardTemplates = getGameObjectChild(getGameObjectChild(nailgunColorWindow, "Standard"), "Template");
            Text nailgunStandardTemplate1 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
            Text nailgunStandardTemplate2 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
            Text nailgunStandardTemplate3 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
            Text nailgunStandardTemplate4 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
            Text nailgunStandardTemplate5 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

            nailgunStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset1;
            nailgunStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset2;
            nailgunStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset3;
            nailgunStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset4;
            nailgunStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset5;

            Text nailgunColorSwitchToAlternative = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunColorWindow, "Standard"), "AlternateButton"), "Text"));
            nailgunColorSwitchToAlternative.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

            Text nailgunColorSwitchToStandard = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunColorWindow, "Alternate"), "AlternateButton"), "Text"));
            nailgunColorSwitchToStandard.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

            GameObject nailgunAlternateTemplates = getGameObjectChild(getGameObjectChild(nailgunColorWindow, "Alternate"), "Template");
            Text nailgunAlternateTemplate1 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunAlternateTemplates, "Template 1"), "Button (Selectable)"), "Text"));
            Text nailgunAlternateTemplate2 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunAlternateTemplates, "Template 2"), "Button (Selectable)"), "Text"));
            Text nailgunAlternateTemplate3 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunAlternateTemplates, "Template 3"), "Button (Selectable)"), "Text"));
            Text nailgunAlternateTemplate4 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunAlternateTemplates, "Template 4"), "Button (Selectable)"), "Text"));
            Text nailgunAlternateTemplate5 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunAlternateTemplates, "Template 5"), "Button (Selectable)"), "Text"));

            nailgunAlternateTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset1;
            nailgunAlternateTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset2;
            nailgunAlternateTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset3;
            nailgunAlternateTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset4;
            nailgunAlternateTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset5;

            Text nailgunColorStandardPreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nailgunStandardTemplates, "TemplateButton"), "Text"));
            nailgunColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

            Text nailgunColorStandardCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nailgunStandardTemplates, "CustomButton"), "Text"));
            nailgunColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            Text nailgunColorAlternatePreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nailgunAlternateTemplates, "TemplateButton"), "Text"));
            nailgunColorAlternatePreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

            Text nailgunColorAlternateCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nailgunAlternateTemplates, "CustomButton"), "Text"));
            nailgunColorAlternateCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            Text nailgunColorDone = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nailgunColorWindow, "Done"), "Text"));
            nailgunColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

            //Nailgun custom colors
            GameObject nailgunStandardCustom = getGameObjectChild(getGameObjectChild(nailgunColorWindow, "Standard"), "Custom");
            Text nailgunStandardCustomPreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nailgunStandardCustom, "TemplateButton"), "Text"));
            nailgunStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
            Text nailgunStandardCustomCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nailgunStandardCustom, "CustomButton"), "Text"));
            nailgunStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            GameObject nailgunAlternateCustom = getGameObjectChild(getGameObjectChild(nailgunColorWindow, "Alternate"), "Custom");
            Text nailgunAlternateCustomPreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nailgunAlternateCustom, "TemplateButton"), "Text"));
            nailgunAlternateCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
            Text nailgunAlternateCustomCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nailgunAlternateCustom, "CustomButton"), "Text"));
            nailgunAlternateCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            //Railcannon window and descriptions
            GameObject railcannonWindow = getGameObjectChild(shopWeaponsObject, "RailcannonWindow");

            //Electric
            GameObject electric = getGameObjectChild(railcannonWindow, "Variation Panel (Blue)");
            Text electricName = getTextfromGameObject(getGameObjectChild(electric, "Text"));
            electricName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;

            GameObject electricWindow = getGameObjectChild(railcannonWindow, "Variation Info (Blue)");
            Text electricWindowName = getTextfromGameObject(getGameObjectChild(electricWindow, "Name"));
            electricWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;

            Text electricWindowDescription = getTextfromGameObject(getGameObjectChild(electricWindow, "Description"));
            electricWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription3;
            electricWindowDescription.fontSize = 16;

            Text electricWindowDescriptionBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(electricWindow, "Button"), "Text"));
            electricWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

            //Screwdriver
            GameObject screwdriver = getGameObjectChild(railcannonWindow, "Variation Panel (Green)");
            Text screwdriverName = getTextfromGameObject(getGameObjectChild(screwdriver, "Text"));
            screwdriverName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;

            GameObject screwdriverWindow = getGameObjectChild(railcannonWindow, "Variation Info (Green)");
            Text screwdriverWindowName = getTextfromGameObject(getGameObjectChild(screwdriverWindow, "Name"));
            screwdriverWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;

            Text screwdriverWindowDescription = getTextfromGameObject(getGameObjectChild(screwdriverWindow, "Description"));
            screwdriverWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription2;
            screwdriverWindowDescription.fontSize = 16;

            Text screwdriverWindowDescriptionBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(screwdriverWindow, "Button"), "Text"));
            screwdriverWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

            //Malicious
            GameObject malicious = getGameObjectChild(railcannonWindow, "Variation Panel (Red)");
            Text maliciousName = getTextfromGameObject(getGameObjectChild(malicious, "Text"));
            maliciousName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;

            GameObject maliciousWindow = getGameObjectChild(railcannonWindow, "Variation Info (Red)");
            Text maliciousWindowName = getTextfromGameObject(getGameObjectChild(maliciousWindow, "Name"));
            maliciousWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;

            Text maliciousWindowDescription = getTextfromGameObject(getGameObjectChild(maliciousWindow, "Description"));
            maliciousWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription1 + "\n\n"
                +  LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription2;
            maliciousWindowDescription.fontSize = 16;

            Text maliciousWindowDescriptionBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(maliciousWindow, "Button"), "Text"));
            maliciousWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

            //Railcannon info & color tabs
            GameObject railcannonExtra = getGameObjectChild(railcannonWindow, "Info and Color Panel");
            GameObject railcannonExtraInfo = getGameObjectChild(railcannonExtra, "InfoButton");
            GameObject railcannonExtraColor = getGameObjectChild(railcannonExtra, "ColorButton");

            Text railcannonExtraInfoText = getTextfromGameObject(getGameObjectChild(railcannonExtraInfo, "Text"));
            railcannonExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

            Text railcannonExtraInfoColors = getTextfromGameObject(getGameObjectChild(railcannonExtraColor, "Text"));
            railcannonExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

            //Railcannon lore
            GameObject railcannonLore = getGameObjectChild(railcannonWindow, "Info Screen");
            Text railcannonLoreName = getTextfromGameObject(getGameObjectChild(railcannonLore, "Name"));
            railcannonLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;

            Text railcannonLoreInfo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(railcannonLore, "Scroll View"), "Viewport"), "Text"));
            railcannonLoreInfo.text =
                 LanguageManager.CurrentLanguage.shop.shop_data + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon3 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon4 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_strategy + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon5 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon6 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon7 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon8 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon9;

            Text railcannonLoreBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(railcannonLore, "Button"), "Text"));
            railcannonLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;


            //Railcannon preset colors
            GameObject railcannonColorWindow = getGameObjectChild(railcannonWindow, "Color Screen");

            Text railcannonColorWindowTitle = getTextfromGameObject(getGameObjectChild(railcannonColorWindow, "Title"));
            railcannonColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon + "--";

            GameObject railcannonStandardTemplates = getGameObjectChild(getGameObjectChild(railcannonColorWindow, "Standard"), "Template");
            Text railcannonStandardTemplate1 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(railcannonStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
            Text railcannonStandardTemplate2 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(railcannonStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
            Text railcannonStandardTemplate3 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(railcannonStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
            Text railcannonStandardTemplate4 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(railcannonStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
            Text railcannonStandardTemplate5 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(railcannonStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

            railcannonStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset1;
            railcannonStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset2;
            railcannonStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset3;
            railcannonStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset4;
            railcannonStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset5;

            Text railcannonColorStandardPreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(railcannonStandardTemplates, "TemplateButton"), "Text"));
            railcannonColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

            Text railcannonColorStandardCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(railcannonStandardTemplates, "CustomButton"), "Text"));
            railcannonColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            Text railcannonColorDone = getTextfromGameObject(getGameObjectChild(getGameObjectChild(railcannonColorWindow, "Done"), "Text"));
            railcannonColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

            //Railcannon custom colors
            GameObject railcannonStandardCustom = getGameObjectChild(getGameObjectChild(railcannonColorWindow, "Standard"), "Custom");
            Text railcannonStandardCustomPreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(railcannonStandardCustom, "TemplateButton"), "Text"));
            railcannonStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
            Text railcannonStandardCustomCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(railcannonStandardCustom, "CustomButton"), "Text"));
            railcannonStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;


            //Rocket launcher window & descriptions
            GameObject rocketlauncherWindow = getGameObjectChild(shopWeaponsObject, "RocketLauncherWindow");

            //Freezeframe
            GameObject freezeframe = getGameObjectChild(rocketlauncherWindow, "Variation Panel (Blue)");
            Text freezeframeName = getTextfromGameObject(getGameObjectChild(freezeframe, "Text"));
            freezeframeName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze;

            GameObject freezeframeInfo = getGameObjectChild(rocketlauncherWindow, "Variation Info (Blue)");
            Text freezeframeDescription = getTextfromGameObject(getGameObjectChild(freezeframeInfo, "Description"));
            freezeframeDescription.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription1 + "\n\n" + 
            LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription2;
            freezeframeDescription.fontSize = 16;

            Text freezeframeDescriptionBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(freezeframeInfo, "Button"), "Text"));
            freezeframeDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

            //Rocket Launcher green variation (under construction)
            GameObject rlGreenVariation = getGameObjectChild(rocketlauncherWindow, "Variation Panel (Green) (Off)");
            Text rlGreenUnderConstruction = getTextfromGameObject(getGameObjectChild(rlGreenVariation, "Text (1)"));
            rlGreenUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

            //Rocket Launcher red variation (under construction)
            GameObject rlRedVariation = getGameObjectChild(rocketlauncherWindow, "Variation Panel (Red)");
            Text rlRedUnderConstruction = getTextfromGameObject(getGameObjectChild(rlRedVariation, "Text (1)"));
            rlGreenUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;


            //Rocket launcher info & color tabs
            GameObject rocketlauncherExtra = getGameObjectChild(rocketlauncherWindow, "Info and Color Panel");
            GameObject rocketlauncherExtraInfo = getGameObjectChild(rocketlauncherExtra, "InfoButton");
            GameObject rocketlauncherExtraColor = getGameObjectChild(rocketlauncherExtra, "ColorButton");

            Text rocketlauncherExtraInfoText = getTextfromGameObject(getGameObjectChild(rocketlauncherExtraInfo, "Text"));
            rocketlauncherExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

            Text rocketlauncherExtraInfoColors = getTextfromGameObject(getGameObjectChild(rocketlauncherExtraColor, "Text"));
            rocketlauncherExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

            //Rocket launcher lore
            GameObject rocketlauncherLore = getGameObjectChild(rocketlauncherWindow, "Info Screen");
            Text rocketlauncherLoreName = getTextfromGameObject(getGameObjectChild(rocketlauncherLore, "Name"));
            rocketlauncherLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;

            Text rocketlauncherLoreInfo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(rocketlauncherLore, "Scroll View"), "Viewport"), "Text"));
            rocketlauncherLoreInfo.text =
                  LanguageManager.CurrentLanguage.shop.shop_data + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher3 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher4 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher5 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher6 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher7 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_strategy + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher8 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher9 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher10 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher11 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher12 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher13;

            Text rocketlauncherLoreBack = getTextfromGameObject(getGameObjectChild(getGameObjectChild(rocketlauncherLore, "Button"), "Text"));
            rocketlauncherLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;


            //Rocket launcher preset colors
            GameObject RLColorWindow = getGameObjectChild(rocketlauncherWindow, "Color Screen");

            Text RLColorWindowTitle = getTextfromGameObject(getGameObjectChild(RLColorWindow, "Title"));
            RLColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher + "--";

            GameObject RLStandardTemplates = getGameObjectChild(getGameObjectChild(RLColorWindow, "Standard"), "Template");
            Text RLStandardTemplate1 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(RLStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
            Text RLStandardTemplate2 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(RLStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
            Text RLStandardTemplate3 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(RLStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
            Text RLStandardTemplate4 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(RLStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
            Text RLStandardTemplate5 = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(RLStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

            RLStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset1;
            RLStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset2;
            RLStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset3;
            RLStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset4;
            RLStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset5;

            Text RLColorStandardPreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(RLStandardTemplates, "TemplateButton"), "Text"));
            RLColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

            Text RLColorStandardCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(RLStandardTemplates, "CustomButton"), "Text"));
            RLColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            Text RLColorDone = getTextfromGameObject(getGameObjectChild(getGameObjectChild(RLColorWindow, "Done"), "Text"));
            RLColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

            //Rocket launcher custom colors
            GameObject RLStandardCustom = getGameObjectChild(getGameObjectChild(RLColorWindow, "Standard"), "Custom");
            Text RLStandardCustomPreset = getTextfromGameObject(getGameObjectChild(getGameObjectChild(RLStandardCustom, "TemplateButton"), "Text"));
            RLStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
            Text RLStandardCustomCustom = getTextfromGameObject(getGameObjectChild(getGameObjectChild(RLStandardCustom, "CustomButton"), "Text"));
            RLStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            //Arm window and descriptions
            GameObject armWindow = getGameObjectChild(shopWeaponsObject, "ArmWindow");

            //Feedbacker
            GameObject feedbacker = getGameObjectChild(armWindow, "Variation Panel 1 (New)");
            Text feedbackerName = getTextfromGameObject(getGameObjectChild(feedbacker, "Text"));
            feedbackerName.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;

            GameObject feedbackerWindow = getGameObjectChild(armWindow, "Variation 1 Info (New)");
            Text feedbackerWindowName = getTextfromGameObject(getGameObjectChild(feedbackerWindow, "Name"));
            feedbackerWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;

            Text feedbackerWindowDescription = getTextfromGameObject(getGameObjectChild(feedbackerWindow, "Description"));
            feedbackerWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription1 + "\n\n" + LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription2;

            //Knuckleblaster
            GameObject knuckleblaster = getGameObjectChild(armWindow, "Variation Panel 2 (New)");
            Text knuckleblasterName = getTextfromGameObject(getGameObjectChild(knuckleblaster, "Text"));
            knuckleblasterName.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;

            GameObject knuckleblasterWindow = getGameObjectChild(armWindow, "Variation 2 Info (New)");
            Text knuckleblasterWindowName = getTextfromGameObject(getGameObjectChild(knuckleblasterWindow, "Name"));
            knuckleblasterWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;

            Text knuckleblasterWindowDescription = getTextfromGameObject(getGameObjectChild(knuckleblasterWindow, "Description"));
            knuckleblasterWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription1 + "\n\n" + LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription2;

            //Whiplash
            GameObject whiplash = getGameObjectChild(armWindow, "Variation Panel 3 (New)");
            Text whiplashName = getTextfromGameObject(getGameObjectChild(whiplash, "Text"));
            whiplashName.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;

            GameObject whiplashWindow = getGameObjectChild(armWindow, "Variation 3 Info (New)");
            Text whiplashWindowName = getTextfromGameObject(getGameObjectChild(whiplashWindow, "Name"));
            whiplashWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;

            Text whiplashWindowDescription = getTextfromGameObject(getGameObjectChild(whiplashWindow, "Description"));
            whiplashWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription2;
            whiplashWindowDescription.fontSize = 16;

            //Gold arm (under construction)
            GameObject goldArm = getGameObjectChild(armWindow, "Variation Panel 1 (3)");
            Text goldArmUnderConstruction = getTextfromGameObject(getGameObjectChild(goldArm, "Text (1)"));
            goldArmUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

        }

        public static void PatchShop(ref GameObject level)
        {
            patchShopFrontEnd(ref level);
            patchWeapons(ref level);
        }
    }
}
