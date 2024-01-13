using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Shop
    {
        private static void PatchShopFrontEnd(ref GameObject shopObject)
        {
            try
            {
                //Tip panel
                GameObject tipPanel = GetGameObjectChild(GetGameObjectChild(shopObject, "TipBox"), "Panel");
                TextMeshProUGUI tipTitle = GetTextMeshProUGUI(GetGameObjectChild(tipPanel, "Title"));
                tipTitle.text = LanguageManager.CurrentLanguage.shop.shop_tipofthedayTitle;

                TextMeshProUGUI tipDescription = GetTextMeshProUGUI(GetGameObjectChild(tipPanel, "TipText"));
                string tipDescriptionText = tipDescription.text;
                //V-Rank Check, do nothing if "V-Rank" is in them, otherwise replace by the correct text
                if (tipDescriptionText.Contains("V-Rank")) { }
                else { tipDescription.text = StringsParent.GetLevelTip(); }

                //Weapons button
                GameObject mainButtons = GetGameObjectChild(shopObject, "Main Menu");

                TextMeshProUGUI weaponsButtonTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(mainButtons, "WeaponsButton"), "Text"));
                weaponsButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_weapons;

                //Enemies button
                TextMeshProUGUI enemiesButtonTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(mainButtons, "EnemiesButton"), "Text"));
                enemiesButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_monsters;

                //CG buttons
                TextMeshProUGUI cgButtonTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(mainButtons, "CyberGrindButton"), "Text"));
                cgButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_cybergrind;

                TextMeshProUGUI cgReturnButtonTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(mainButtons, "ReturnButton"), "Text"));
                cgReturnButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_returnToMission;

                //Sandbox button
                TextMeshProUGUI sandboxButtonTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(mainButtons, "SandboxButton"), "Text"));
                sandboxButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_sandbox;

                //Enemies title
                TextMeshProUGUI enemiesTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "Enemies"), "Panel"),"Title"));
                enemiesTitle.text = LanguageManager.CurrentLanguage.shop.shop_monsters;

                //Sandbox enter description
                GameObject sandboxEnter = GetGameObjectChild(GetGameObjectChild(shopObject, "Sandbox"), "Panel");

                TextMeshProUGUI sandboxTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "Sandbox"), "Panel"),"Title"));
                sandboxTitle.text = LanguageManager.CurrentLanguage.shop.shop_sandbox;

                TextMeshProUGUI sandboxEnterTitle = GetTextMeshProUGUI(GetGameObjectChild(sandboxEnter, "Title"));
                sandboxEnterTitle.text = sandboxButtonTitle.text;

                TextMeshProUGUI sandboxEnterDescription = GetTextMeshProUGUI(GetGameObjectChild(sandboxEnter, "Text"));

                sandboxEnterDescription.text = LanguageManager.CurrentLanguage.shop.shop_sandboxDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_sandboxDescription2;

                TextMeshProUGUI sandboxEnterButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(sandboxEnter, "SandboxButton (1)"), "Text"));
                sandboxEnterButton.text = LanguageManager.CurrentLanguage.shop.shop_sandboxEnter;

                //CG enter description
                GameObject cgEnter = GetGameObjectChild(GetGameObjectChild(shopObject, "The Cyber Grind"), "Panel");

                TextMeshProUGUI cgEnterTitle = GetTextMeshProUGUI(GetGameObjectChild(cgEnter, "Title"));
                cgEnterTitle.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindEnterTitle;

                TextMeshProUGUI cgEnterDescription = GetTextMeshProUGUI(GetGameObjectChild(cgEnter, "Text"));

                cgEnterDescription.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription3;

                TextMeshProUGUI cgEnterButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgEnter, "CyberGrindButton (1)"), "Text"));
                cgEnterButton.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindEnter;

                //CG exit description
                GameObject cgExit = GetGameObjectChild(GetGameObjectChild(shopObject, "Return from Cyber Grind"), "Panel");

                TextMeshProUGUI cgExitTitle = GetTextMeshProUGUI(GetGameObjectChild(cgExit, "Title"));
                cgExitTitle.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindExitTitle;

                TextMeshProUGUI cgExitDescription = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(cgExit, "CyberGrindButton (1)"), "Text"));
                if (GetCurrentSceneName() == "uk_construct")
                {
                    cgExitDescription.text = LanguageManager.CurrentLanguage.frontend.mainmenu_quit;
                }
                else
                {
                    cgExitDescription.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindExit;
                }

                //Enemies back button 
                TextMeshProUGUI enemiesBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "Enemies"), "BackButton (2)"), "Text"));
                enemiesBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Sandbox back button
                TextMeshProUGUI sandboxBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "Sandbox"), "BackButton (2)"), "Text"));
                sandboxBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //EnemyInfo back button
                TextMeshProUGUI enemyInfoBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "EnemyInfo"),"Button"),"Text"));
                enemyInfoBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Enter CG back text
                TextMeshProUGUI cgEnterBackButtonText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "The Cyber Grind"), "BackButton (2)"), "Text"));
                cgEnterBackButtonText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Exit CG back text
                TextMeshProUGUI cgExitBackButtonText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "Return from Cyber Grind"), "BackButton (2)"), "Text"));
                cgExitBackButtonText.text = LanguageManager.CurrentLanguage.shop.shop_back;
            }
            catch (Exception e)
            {
                Logging.Error(e.ToString());
            }

        }
        

        private static void PatchWeapons(ref GameObject shopObject)
        {
            try
            {
                //weapons
                GameObject shopWeaponsObject  = GetGameObjectChild(shopObject, "Weapons");

                TextMeshProUGUI weaponBackText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "BackButton (1)"), "Text"));
                weaponBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                TextMeshProUGUI weaponRevolverText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RevolverButton"), "Text"));
                weaponRevolverText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

                TextMeshProUGUI weaponShotgunText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "ShotgunButton"), "Text"));
                weaponShotgunText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;

                TextMeshProUGUI weaponNailgunText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "NailgunButton"), "Text"));
                weaponNailgunText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

                //Slight problem - not all the text fits in the box.
                //The longer text is, the more we'll need to reduce the font size to compensate.
                TextMeshProUGUI weaponRailcannonText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RailcannonButton"), "Text"));
                weaponRailcannonText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;
                weaponRailcannonText.fontSize = 16;

                TextMeshProUGUI rocketLauncherText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RocketLauncherButton"), "Text"));
                rocketLauncherText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;
                rocketLauncherText.fontSize = 16;

                TextMeshProUGUI weaponArmText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "ArmButton"), "Text"));
                weaponArmText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsArms;

                //Revolver window and descriptions
                GameObject revolverWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RevolverWindow"),"Variation Screen");

                //Piercer
                GameObject piercer = GetGameObjectChild(revolverWindow, "Variation Panel (Blue)");
                TextMeshProUGUI piercerName = GetTextMeshProUGUI(GetGameObjectChild(piercer, "Text"));
                piercerName.text = LanguageManager.CurrentLanguage.shop.shop_revolverPiercer;

                GameObject piercerWindow = GetGameObjectChild(revolverWindow, "Variation Info (Blue)");
                TextMeshProUGUI piercerWindowName = GetTextMeshProUGUI(GetGameObjectChild(piercerWindow, "Name"));
                piercerWindowName.text = piercerName.text;

                TextMeshProUGUI piercerWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(piercerWindow, "Description"));
                piercerWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription2;

                TextMeshProUGUI piercerWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(piercerWindow, "Button"),"Text"));
                piercerWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Marksman
                GameObject marksman = GetGameObjectChild(revolverWindow, "Variation Panel (Green)");
                TextMeshProUGUI marksmanName = GetTextMeshProUGUI(GetGameObjectChild(marksman, "Text"));
                marksmanName.text = LanguageManager.CurrentLanguage.shop.shop_revolverMarksman;
                marksmanName.fontSize = 14;

                GameObject marksmanWindow = GetGameObjectChild(revolverWindow, "Variation Info (Green)");
                TextMeshProUGUI marksmanWindowName = GetTextMeshProUGUI(GetGameObjectChild(marksmanWindow, "Name"));
                marksmanWindowName.text = marksmanName.text;

                TextMeshProUGUI marksmanWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(marksmanWindow, "Description"));
                marksmanWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription3;
                marksmanWindowDescription.fontSize = 14;

                TextMeshProUGUI marksmanWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(marksmanWindow, "Button"), "Text"));
                marksmanWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Sharpshooter
                GameObject sharpshooter = GetGameObjectChild(revolverWindow, "Variation Panel (Red)");
                TextMeshProUGUI sharpshooterName = GetTextMeshProUGUI(GetGameObjectChild(sharpshooter, "Text"));
                sharpshooterName.text = LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooter;
                sharpshooterName.fontSize = 20;
                
                GameObject sharpshooterWindow = GetGameObjectChild(revolverWindow, "Variation Info (Red)");
                TextMeshProUGUI sharpshooterWindowName = GetTextMeshProUGUI(GetGameObjectChild(sharpshooterWindow, "Name"));
                sharpshooterWindowName.text = sharpshooterName.text;
                
                TextMeshProUGUI sharpshooterWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(sharpshooterWindow, "Description"));
                sharpshooterWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooterDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooterDescription2 + "\n\n";
                sharpshooterWindowDescription.fontSize = 20;

                //Revolver info & color tabs
                GameObject revolverExtra = GetGameObjectChild(revolverWindow, "Info and Color Panel");
                GameObject revolverExtraInfo = GetGameObjectChild(revolverExtra, "InfoButton");
                GameObject revolverExtraColor = GetGameObjectChild(revolverExtra, "ColorButton");

                TextMeshProUGUI revolverExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(revolverExtraInfo, "Text"));
                revolverExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI revolverExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(revolverExtraColor, "Text"));
                revolverExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Revolver lore
                GameObject revolverLore = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RevolverWindow"),"Info Screen");
                TextMeshProUGUI revolverLoreName = GetTextMeshProUGUI(GetGameObjectChild(revolverLore, "Name"));
                revolverLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

                TextMeshProUGUI revolverLoreInfo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverLore,"Scroll View"),"Viewport"),"Text"));

                revolverLoreInfo.text =
                    "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver3 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver4 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver5 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver6 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver7 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver8 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver9 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRevolver10;

                TextMeshProUGUI revolverLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverLore, "Button"), "Text"));
                revolverLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Revolver preset colors
                GameObject revolverColorWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RevolverWindow"),"Color Screen");

                TextMeshProUGUI revolverColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(revolverColorWindow,"Title"));
                revolverColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver + "--";

                GameObject revolverStandardTemplates = GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Standard"),"Template");
                TextMeshProUGUI revolverStandardTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "Template 1"),"Button (Selectable)"),"Text"));
                TextMeshProUGUI revolverStandardTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI revolverStandardTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI revolverStandardTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI revolverStandardTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                revolverStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset1;
                revolverStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset2;
                revolverStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset3;
                revolverStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset4;
                revolverStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset5;

                TextMeshProUGUI revolverColorSwitchToAlternative = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Standard"),"AlternateButton"),"Text"));
                revolverColorSwitchToAlternative.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

                TextMeshProUGUI revolverColorSwitchToStandard = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Alternate"), "AlternateButton"), "Text"));
                revolverColorSwitchToStandard.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

                GameObject revolverAlternateTemplates = GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Alternate"), "Template");
                TextMeshProUGUI revolverAlternateTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI revolverAlternateTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI revolverAlternateTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI revolverAlternateTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI revolverAlternateTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                revolverAlternateTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset1;
                revolverAlternateTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset2;
                revolverAlternateTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset3;
                revolverAlternateTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset4;
                revolverAlternateTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset5;

                TextMeshProUGUI revolverColorStandardPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "TemplateButton"),"Text"));
                revolverColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI revolverColorStandardCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "CustomButton"),"Text"));
                revolverColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI revolverColorAlternatePreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "TemplateButton"), "Text"));
                revolverColorAlternatePreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI revolverColorAlternateCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "CustomButton"), "Text"));
                revolverColorAlternateCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI revolverColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Done"),"Text"));
                revolverColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Revolver custom colors
                GameObject revolverStandardCustom = GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Standard"),"Custom");
                TextMeshProUGUI revolverStandardCustomPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverStandardCustom, "TemplateButton"), "Text"));
                revolverStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                TextMeshProUGUI revolverStandardCustomCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverStandardCustom, "CustomButton"), "Text"));
                revolverStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                GameObject revolverAlternateCustom = GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Alternate"), "Custom");
                TextMeshProUGUI revolverAlternateCustomPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverAlternateCustom, "TemplateButton"), "Text"));
                revolverAlternateCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                TextMeshProUGUI revolverAlternateCustomCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(revolverAlternateCustom, "CustomButton"), "Text"));
                revolverAlternateCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Revolver custom color unlock prompt
                TextMeshProUGUI revolverCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RevolverWindow"),"Color Screen"),"Standard"),"Custom"),"Locked"),"Blocker"),"Text"));
                revolverCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

                //Shotgun window and descriptions
                GameObject shotgunWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "ShotgunWindow"),"Variation Screen");

                //Core Eject
                GameObject coreEject = GetGameObjectChild(shotgunWindow, "Variation Panel (Blue)");
                TextMeshProUGUI coreEjectName = GetTextMeshProUGUI(GetGameObjectChild(coreEject, "Text"));
                coreEjectName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject;

                GameObject coreEjectWindow = GetGameObjectChild(shotgunWindow, "Variation Info (Blue)");
                TextMeshProUGUI coreEjectWindowName = GetTextMeshProUGUI(GetGameObjectChild(coreEjectWindow, "Name"));
                coreEjectWindowName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject;

                TextMeshProUGUI coreEjectWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(coreEjectWindow, "Description"));
                coreEjectWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription3;

                TextMeshProUGUI coreEjectWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(coreEjectWindow, "Button"), "Text"));
                coreEjectWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Pump Charge
                GameObject pumpCharge = GetGameObjectChild(shotgunWindow, "Variation Panel (Green)");
                TextMeshProUGUI pumpChargeName = GetTextMeshProUGUI(GetGameObjectChild(pumpCharge, "Text"));
                pumpChargeName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge;
                pumpChargeName.fontSize = 16;

                GameObject pumpChargeWindow = GetGameObjectChild(shotgunWindow, "Variation Info (Green)");
                TextMeshProUGUI pumpChargeWindowName = GetTextMeshProUGUI(GetGameObjectChild(pumpChargeWindow, "Name"));
                pumpChargeWindowName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge;

                TextMeshProUGUI pumpChargeWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(pumpChargeWindow, "Description"));
                pumpChargeWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription2;
                pumpChargeWindowDescription.fontSize = 14;

                TextMeshProUGUI pumpChargeWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pumpChargeWindow, "Button"), "Text"));
                pumpChargeWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Shotgun red variation (under construction)
                GameObject shotgunRedVariation = GetGameObjectChild(shotgunWindow, "Variation Panel (Red) (Under Construction)");
                TextMeshProUGUI shotgunRedUnderConstruction = GetTextMeshProUGUI(GetGameObjectChild(shotgunRedVariation, "Text (1)"));
                shotgunRedUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

                //Shotgun info & color tabs
                GameObject shotgunExtra = GetGameObjectChild(shotgunWindow, "Info and Color Panel");
                GameObject shotgunExtraInfo = GetGameObjectChild(shotgunExtra, "InfoButton");
                GameObject shotgunExtraColor = GetGameObjectChild(shotgunExtra, "ColorButton");

                TextMeshProUGUI shotgunExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(shotgunExtraInfo, "Text"));
                shotgunExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI shotgunExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(shotgunExtraColor, "Text"));
                shotgunExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Shotgun lore
                GameObject shotgunLore = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "ShotgunWindow"),"Info Screen");
                TextMeshProUGUI shotgunLoreName = GetTextMeshProUGUI(GetGameObjectChild(shotgunLore, "Name"));
                shotgunLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;

                TextMeshProUGUI shotgunLoreInfo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunLore, "Scroll View"), "Viewport"), "Text"));

                shotgunLoreInfo.text =
                    "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun3 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun4 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun5 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun6 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun7 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun8 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreShotgun9;

                TextMeshProUGUI shotgunLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunLore, "Button"), "Text"));
                shotgunLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Shotgun preset colors
                GameObject shotgunColorWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "ShotgunWindow"),"Color Screen");


                TextMeshProUGUI shotgunColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(shotgunColorWindow, "Title"));
                shotgunColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun + "--";

                GameObject shotgunStandardTemplates = GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Standard"), "Template");
                TextMeshProUGUI shotgunStandardTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI shotgunStandardTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI shotgunStandardTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI shotgunStandardTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI shotgunStandardTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                shotgunStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset1;
                shotgunStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset2;
                shotgunStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset3;
                shotgunStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset4;
                shotgunStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset5;

                TextMeshProUGUI shotgunColorStandardPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "TemplateButton"), "Text"));
                shotgunColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI shotgunColorStandardCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "CustomButton"), "Text"));
                shotgunColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI shotgunColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Done"), "Text"));
                shotgunColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Shotgun custom colors
                GameObject shotgunStandardCustom = GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Standard"), "Custom");
                TextMeshProUGUI shotgunStandardCustomPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunStandardCustom, "TemplateButton"), "Text"));
                shotgunStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                TextMeshProUGUI shotgunStandardCustomCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(shotgunStandardCustom, "CustomButton"), "Text"));
                shotgunStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Shotgun custom color unlock prompt
                TextMeshProUGUI shotgunCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "ShotgunWindow"),"Color Screen"),"Standard"),"Custom"),"Locked"),"Blocker"),"Text"));

                shotgunCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

                //Nailgun window and descriptions
                GameObject nailgunWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "NailgunWindow"),"Variation Screen");

                //Attractor
                GameObject attractor = GetGameObjectChild(nailgunWindow, "Variation Panel (Blue)");
                TextMeshProUGUI attractorName = GetTextMeshProUGUI(GetGameObjectChild(attractor, "Text"));
                attractorName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet;

                GameObject attractorWindow = GetGameObjectChild(nailgunWindow, "Variation Info (Blue)");
                TextMeshProUGUI attractorWindowName = GetTextMeshProUGUI(GetGameObjectChild(attractorWindow, "Name"));
                attractorWindowName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet;

                TextMeshProUGUI attractorWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(attractorWindow, "Description"));
                attractorWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription2;
                attractorWindowDescription.fontSize = 16;

                TextMeshProUGUI attractorWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(attractorWindow, "Button"), "Text"));
                attractorWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Overheat
                GameObject overheat = GetGameObjectChild(nailgunWindow, "Variation Panel (Green)");
                TextMeshProUGUI overheatName = GetTextMeshProUGUI(GetGameObjectChild(overheat, "Text"));
                overheatName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;
                overheatName.fontSize = 16;

                GameObject overheatWindow = GetGameObjectChild(nailgunWindow, "Variation Info (Green)");
                TextMeshProUGUI overheatWindowName = GetTextMeshProUGUI(GetGameObjectChild(overheatWindow, "Name"));
                overheatWindowName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;

                TextMeshProUGUI overheatWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(overheatWindow, "Description"));
                overheatWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription2;
                overheatWindowDescription.fontSize = 14;

                TextMeshProUGUI overheatWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(overheatWindow, "Button"), "Text"));
                overheatWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Nailgun red variation (under construction)
                GameObject nailgunRedVariation = GetGameObjectChild(nailgunWindow, "Variation Panel (Red) (Under Construction)");
                TextMeshProUGUI nailgunRedUnderConstruction = GetTextMeshProUGUI(GetGameObjectChild(nailgunRedVariation, "Text (1)"));
                nailgunRedUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

                //Nailgun info & color tabs
                GameObject nailgunExtra = GetGameObjectChild(nailgunWindow, "Info and Color Panel");
                GameObject nailgunExtraInfo = GetGameObjectChild(nailgunExtra, "InfoButton");
                GameObject nailgunExtraColor = GetGameObjectChild(nailgunExtra, "ColorButton");

                TextMeshProUGUI nailgunExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(nailgunExtraInfo, "Text"));
                nailgunExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI nailgunExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(nailgunExtraColor, "Text"));
                nailgunExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Nailgun lore
                GameObject nailgunLore = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "NailgunWindow"),"Info Screen");
                TextMeshProUGUI nailgunLoreName = GetTextMeshProUGUI(GetGameObjectChild(nailgunLore, "Name"));
                nailgunLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

                TextMeshProUGUI nailgunLoreInfo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunLore, "Scroll View"), "Viewport"), "Text"));
                nailgunLoreInfo.text =
                    "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun3 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun4 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun5 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun6 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun7 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun8 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreNailgun9;

                TextMeshProUGUI nailgunLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunLore, "Button"), "Text"));
                nailgunLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Nailgun preset colors
                GameObject nailgunColorWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "NailgunWindow"),"Color Screen");

                TextMeshProUGUI nailgunColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(nailgunColorWindow, "Title"));
                nailgunColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun + "--";

                GameObject nailgunStandardTemplates = GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Standard"), "Template");
                TextMeshProUGUI nailgunStandardTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunStandardTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunStandardTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunStandardTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunStandardTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                nailgunStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset1;
                nailgunStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset2;
                nailgunStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset3;
                nailgunStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset4;
                nailgunStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset5;

                TextMeshProUGUI nailgunColorSwitchToAlternative = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Standard"), "AlternateButton"), "Text"));
                nailgunColorSwitchToAlternative.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

                TextMeshProUGUI nailgunColorSwitchToStandard = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Alternate"), "AlternateButton"), "Text"));
                nailgunColorSwitchToStandard.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

                GameObject nailgunAlternateTemplates = GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Alternate"), "Template");
                TextMeshProUGUI nailgunAlternateTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunAlternateTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunAlternateTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunAlternateTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI nailgunAlternateTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                nailgunAlternateTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset1;
                nailgunAlternateTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset2;
                nailgunAlternateTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset3;
                nailgunAlternateTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset4;
                nailgunAlternateTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset5;

                TextMeshProUGUI nailgunColorStandardPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "TemplateButton"), "Text"));
                nailgunColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI nailgunColorStandardCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "CustomButton"), "Text"));
                nailgunColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI nailgunColorAlternatePreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "TemplateButton"), "Text"));
                nailgunColorAlternatePreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI nailgunColorAlternateCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "CustomButton"), "Text"));
                nailgunColorAlternateCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI nailgunColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Done"), "Text"));
                nailgunColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Nailgun custom colors
                GameObject nailgunStandardCustom = GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Standard"), "Custom");
                TextMeshProUGUI nailgunStandardCustomPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunStandardCustom, "TemplateButton"), "Text"));
                nailgunStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                TextMeshProUGUI nailgunStandardCustomCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunStandardCustom, "CustomButton"), "Text"));
                nailgunStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                GameObject nailgunAlternateCustom = GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Alternate"), "Custom");
                TextMeshProUGUI nailgunAlternateCustomPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunAlternateCustom, "TemplateButton"), "Text"));
                nailgunAlternateCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                TextMeshProUGUI nailgunAlternateCustomCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(nailgunAlternateCustom, "CustomButton"), "Text"));
                nailgunAlternateCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Nailgun custom color unlock prompt
                TextMeshProUGUI nailgunCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "NailgunWindow"),"Color Screen"),"Standard"),"Custom"),"Locked"),"Blocker"),"Text"));

                nailgunCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + ": " + LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

                //Railcannon window and descriptions
                GameObject railcannonWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RailcannonWindow"),"Variation Screen");

                //Electric
                GameObject electric = GetGameObjectChild(railcannonWindow, "Variation Panel (Blue)");
                TextMeshProUGUI electricName = GetTextMeshProUGUI(GetGameObjectChild(electric, "Text"));
                electricName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;

                GameObject electricWindow = GetGameObjectChild(railcannonWindow, "Variation Info (Blue)");
                TextMeshProUGUI electricWindowName = GetTextMeshProUGUI(GetGameObjectChild(electricWindow, "Name"));
                electricWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;

                TextMeshProUGUI electricWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(electricWindow, "Description"));
                electricWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription3;
                electricWindowDescription.fontSize = 16;

                TextMeshProUGUI electricWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(electricWindow, "Button"), "Text"));
                electricWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Screwdriver
                GameObject screwdriver = GetGameObjectChild(railcannonWindow, "Variation Panel (Green)");
                TextMeshProUGUI screwdriverName = GetTextMeshProUGUI(GetGameObjectChild(screwdriver, "Text"));
                screwdriverName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;

                GameObject screwdriverWindow = GetGameObjectChild(railcannonWindow, "Variation Info (Green)");
                TextMeshProUGUI screwdriverWindowName = GetTextMeshProUGUI(GetGameObjectChild(screwdriverWindow, "Name"));
                screwdriverWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;

                TextMeshProUGUI screwdriverWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(screwdriverWindow, "Description"));
                screwdriverWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription2;
                screwdriverWindowDescription.fontSize = 16;

                TextMeshProUGUI screwdriverWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(screwdriverWindow, "Button"), "Text"));
                screwdriverWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Malicious
                GameObject malicious = GetGameObjectChild(railcannonWindow, "Variation Panel (Red)");
                TextMeshProUGUI maliciousName = GetTextMeshProUGUI(GetGameObjectChild(malicious, "Text"));
                maliciousName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;

                GameObject maliciousWindow = GetGameObjectChild(railcannonWindow, "Variation Info (Red)");
                TextMeshProUGUI maliciousWindowName = GetTextMeshProUGUI(GetGameObjectChild(maliciousWindow, "Name"));
                maliciousWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;

                TextMeshProUGUI maliciousWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(maliciousWindow, "Description"));
                maliciousWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription1 + "\n\n"
                    +  LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription2;
                maliciousWindowDescription.fontSize = 16;

                TextMeshProUGUI maliciousWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(maliciousWindow, "Button"), "Text"));
                maliciousWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Railcannon info & color tabs
                GameObject railcannonExtra = GetGameObjectChild(railcannonWindow, "Info and Color Panel");
                GameObject railcannonExtraInfo = GetGameObjectChild(railcannonExtra, "InfoButton");
                GameObject railcannonExtraColor = GetGameObjectChild(railcannonExtra, "ColorButton");

                TextMeshProUGUI railcannonExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(railcannonExtraInfo, "Text"));
                railcannonExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI railcannonExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(railcannonExtraColor, "Text"));
                railcannonExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Railcannon lore
                GameObject railcannonLore =  GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RailcannonWindow"),"Info Screen");
                TextMeshProUGUI railcannonLoreName = GetTextMeshProUGUI(GetGameObjectChild(railcannonLore, "Name"));
                railcannonLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;

                TextMeshProUGUI railcannonLoreInfo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonLore, "Scroll View"), "Viewport"), "Text"));
                railcannonLoreInfo.text =
                     "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon3 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon4 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon5 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon6 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon7 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon8 + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon9;

                TextMeshProUGUI railcannonLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonLore, "Button"), "Text"));
                railcannonLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Railcannon preset colors
                GameObject railcannonColorWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RailcannonWindow"),"Color Screen");

                TextMeshProUGUI railcannonColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(railcannonColorWindow, "Title"));
                railcannonColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon + "--";

                GameObject railcannonStandardTemplates = GetGameObjectChild(GetGameObjectChild(railcannonColorWindow, "Standard"), "Template");
                TextMeshProUGUI railcannonStandardTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI railcannonStandardTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI railcannonStandardTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI railcannonStandardTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI railcannonStandardTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                railcannonStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset1;
                railcannonStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset2;
                railcannonStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset3;
                railcannonStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset4;
                railcannonStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset5;

                TextMeshProUGUI railcannonColorStandardPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "TemplateButton"), "Text"));
                railcannonColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI railcannonColorStandardCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "CustomButton"), "Text"));
                railcannonColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI railcannonColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonColorWindow, "Done"), "Text"));
                railcannonColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Railcannon custom colors
                GameObject railcannonStandardCustom = GetGameObjectChild(GetGameObjectChild(railcannonColorWindow, "Standard"), "Custom");
                TextMeshProUGUI railcannonStandardCustomPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonStandardCustom, "TemplateButton"), "Text"));
                railcannonStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                TextMeshProUGUI railcannonStandardCustomCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(railcannonStandardCustom, "CustomButton"), "Text"));
                railcannonStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Railcannon custom color unlock prompt
                TextMeshProUGUI railcannonCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RailcannonWindow"),"Color Screen"),"Standard"),"Custom"),"Locked"),"Blocker"),"Text"));
                railcannonCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + ": " + LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;

                //Rocket launcher window & descriptions
                GameObject rocketlauncherWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RocketLauncherWindow"),"Variation Screen");

                //Freezeframe
                GameObject freezeframe = GetGameObjectChild(rocketlauncherWindow, "Variation Panel (Blue)");
                TextMeshProUGUI freezeframeName = GetTextMeshProUGUI(GetGameObjectChild(freezeframe, "Text"));
                freezeframeName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze;

                GameObject freezeframeInfo = GetGameObjectChild(rocketlauncherWindow, "Variation Info (Blue)");
                TextMeshProUGUI freezeframeInfoName = GetTextMeshProUGUI(GetGameObjectChild(freezeframeInfo, "Name"));
                freezeframeInfoName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze;
                TextMeshProUGUI freezeframeDescription = GetTextMeshProUGUI(GetGameObjectChild(freezeframeInfo, "Description"));
                freezeframeDescription.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription1 + "\n\n" + 
                LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription2;
                freezeframeDescription.fontSize = 16;

                TextMeshProUGUI freezeframeDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(freezeframeInfo, "Button"), "Text"));
                freezeframeDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Rocket Launcher green variation
                GameObject srsCannon = GetGameObjectChild(rocketlauncherWindow, "Variation Panel (Green)");
                TextMeshProUGUI srsCannonName = GetTextMeshProUGUI(GetGameObjectChild(srsCannon, "Text"));
                srsCannonName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannon;
                
                GameObject srsCannonInfo = GetGameObjectChild(rocketlauncherWindow, "Variation Info (Green)");
                TextMeshProUGUI srsCannonInfoName = GetTextMeshProUGUI(GetGameObjectChild(srsCannonInfo, "Name"));
                srsCannonInfoName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannon;
                TextMeshProUGUI srsCannonInfoDescription = GetTextMeshProUGUI(GetGameObjectChild(srsCannonInfo, "Description"));
                srsCannonInfoDescription.text =
                    LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription1 + "\n\n" +
                    LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription2 + "\n\n" +
                    LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription3;
                srsCannonInfoDescription.fontSize = 16;

                //Rocket Launcher red variation (under construction)
                GameObject rlRedVariation = GetGameObjectChild(rocketlauncherWindow, "Variation Panel (Red) (Under Construction)");
                TextMeshProUGUI rlRedUnderConstruction = GetTextMeshProUGUI(GetGameObjectChild(rlRedVariation, "Text (1)"));
                rlRedUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

                //Rocket launcher info & color tabs
                GameObject rocketlauncherExtra = GetGameObjectChild(rocketlauncherWindow, "Info and Color Panel");
                GameObject rocketlauncherExtraInfo = GetGameObjectChild(rocketlauncherExtra, "InfoButton");
                GameObject rocketlauncherExtraColor = GetGameObjectChild(rocketlauncherExtra, "ColorButton");

                TextMeshProUGUI rocketlauncherExtraInfoText = GetTextMeshProUGUI(GetGameObjectChild(rocketlauncherExtraInfo, "Text"));
                rocketlauncherExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                TextMeshProUGUI rocketlauncherExtraInfoColors = GetTextMeshProUGUI(GetGameObjectChild(rocketlauncherExtraColor, "Text"));
                rocketlauncherExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Rocket launcher lore
                GameObject rocketlauncherLore = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RocketLauncherWindow"),"Info Screen");
                TextMeshProUGUI rocketlauncherLoreName = GetTextMeshProUGUI(GetGameObjectChild(rocketlauncherLore, "Name"));
                rocketlauncherLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;

                TextMeshProUGUI rocketlauncherLoreInfo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(rocketlauncherLore, "Scroll View"), "Viewport"), "Text"));
                rocketlauncherLoreInfo.text =
                      "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher3 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher4 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher5 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher6 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher7 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher8 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher9 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher10 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher11 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher12 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "</color>\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher13 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher14 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher15;
                
                TextMeshProUGUI rocketlauncherLoreBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(rocketlauncherLore, "Button"), "Text"));
                rocketlauncherLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Rocket launcher preset colors
                GameObject RLColorWindow = GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RocketLauncherWindow"),"Color Screen");

                TextMeshProUGUI RLColorWindowTitle = GetTextMeshProUGUI(GetGameObjectChild(RLColorWindow, "Title"));
                RLColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher + "--";

                GameObject RLStandardTemplates = GetGameObjectChild(GetGameObjectChild(RLColorWindow, "Standard"), "Template");
                TextMeshProUGUI RLStandardTemplate1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI RLStandardTemplate2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI RLStandardTemplate3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI RLStandardTemplate4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                TextMeshProUGUI RLStandardTemplate5 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                RLStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset1;
                RLStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset2;
                RLStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset3;
                RLStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset4;
                RLStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset5;

                TextMeshProUGUI RLColorStandardPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "TemplateButton"), "Text"));
                RLColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                TextMeshProUGUI RLColorStandardCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "CustomButton"), "Text"));
                RLColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                TextMeshProUGUI RLColorDone = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(RLColorWindow, "Done"), "Text"));
                RLColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Rocket launcher custom colors
                GameObject RLStandardCustom = GetGameObjectChild(GetGameObjectChild(RLColorWindow, "Standard"), "Custom");
                TextMeshProUGUI RLStandardCustomPreset = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(RLStandardCustom, "TemplateButton"), "Text"));
                RLStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                TextMeshProUGUI RLStandardCustomCustom = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(RLStandardCustom, "CustomButton"), "Text"));
                RLStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Rocket launcher custom color unlock prompt
                TextMeshProUGUI RLCustomColorPrompt = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RocketLauncherWindow"),"Color Screen"),"Standard"),"Custom"),"Locked"),"Blocker"),"Text"));

                RLCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + ": " + LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;

                //Arm window and descriptions
                GameObject armWindow = GetGameObjectChild(shopWeaponsObject, "ArmWindow");

                //Feedbacker
                GameObject feedbacker = GetGameObjectChild(armWindow, "Variation Panel 1 (New)");
                TextMeshProUGUI feedbackerName = GetTextMeshProUGUI(GetGameObjectChild(feedbacker, "Text"));
                feedbackerName.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;

                GameObject feedbackerWindow = GetGameObjectChild(armWindow, "Variation 1 Info (New)");
                TextMeshProUGUI feedbackerWindowName = GetTextMeshProUGUI(GetGameObjectChild(feedbackerWindow, "Name"));
                feedbackerWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;

                TextMeshProUGUI feedbackerWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(feedbackerWindow, "Description"));
                feedbackerWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription1 + "\n\n" + LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription2;

                TextMeshProUGUI feedbackerWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(feedbackerWindow, "Button"), "Text"));
                feedbackerWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;
                
                //Knuckleblaster
                GameObject knuckleblaster = GetGameObjectChild(armWindow, "Variation Panel 2 (New)");
                TextMeshProUGUI knuckleblasterName = GetTextMeshProUGUI(GetGameObjectChild(knuckleblaster, "Text"));
                knuckleblasterName.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;

                GameObject knuckleblasterWindow = GetGameObjectChild(armWindow, "Variation 2 Info (New)");
                TextMeshProUGUI knuckleblasterWindowName = GetTextMeshProUGUI(GetGameObjectChild(knuckleblasterWindow, "Name"));
                knuckleblasterWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;

                TextMeshProUGUI knuckleblasterWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(knuckleblasterWindow, "Description"));
                knuckleblasterWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription1 + "\n\n" + LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription2;

                TextMeshProUGUI knuckleblasterWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(knuckleblasterWindow, "Button"), "Text"));
                knuckleblasterWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;
                
                //Whiplash
                GameObject whiplash = GetGameObjectChild(armWindow, "Variation Panel 3 (New)");
                TextMeshProUGUI whiplashName = GetTextMeshProUGUI(GetGameObjectChild(whiplash, "Text"));
                whiplashName.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;

                GameObject whiplashWindow = GetGameObjectChild(armWindow, "Variation 3 Info (New)");
                TextMeshProUGUI whiplashWindowName = GetTextMeshProUGUI(GetGameObjectChild(whiplashWindow, "Name"));
                whiplashWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;

                TextMeshProUGUI whiplashWindowDescription = GetTextMeshProUGUI(GetGameObjectChild(whiplashWindow, "Description"));
                whiplashWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription2;
                whiplashWindowDescription.fontSize = 16;
                
                TextMeshProUGUI whiplashWindowDescriptionBack = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(whiplashWindow, "Button"), "Text"));
                whiplashWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Gold arm (under construction)
                GameObject goldArm = GetGameObjectChild(armWindow, "Variation Panel 1 (3)");
                TextMeshProUGUI goldArmUnderConstruction = GetTextMeshProUGUI(GetGameObjectChild(goldArm, "Text (1)"));
                goldArmUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;
            }
            catch (Exception e)
            {
                Logging.Error(e.ToString());
            }
                
        }

        public static void PatchShopRefactor(ref GameObject shopObject)
        {
            PatchShopFrontEnd(ref shopObject);
            PatchWeapons(ref shopObject);
        }
        
    }
}
