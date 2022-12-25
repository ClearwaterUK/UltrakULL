using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Shop
    {
        public static GameObject originalShop = null;
        public static GameObject bossShop = null;
        
        private static void PatchShopFrontEnd(ref List<GameObject> shopsToPatch)
        {
            foreach(GameObject shopObject in shopsToPatch)
            {
                //Tip panel
                GameObject tipPanel = GetGameObjectChild(GetGameObjectChild(shopObject, "TipBox"), "Panel");
                Text tipTitle = GetTextfromGameObject(GetGameObjectChild(tipPanel, "Title"));
                tipTitle.text = LanguageManager.CurrentLanguage.shop.shop_tipofthedayTitle;

                Text tipDescription = GetTextfromGameObject(GetGameObjectChild(tipPanel, "TipText"));
                tipDescription.text = StringsParent.GetLevelTip();

                //Weapons button
                GameObject mainButtons = GetGameObjectChild(shopObject, "Main Menu");

                Text weaponsButtonTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(mainButtons, "WeaponsButton"), "Text"));
                weaponsButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_weapons;

                //Enemies button
                Text enemiesButtonTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(mainButtons, "EnemiesButton"), "Text"));
                enemiesButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_monsters;

                //CG buttons
                Text cgButtonTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(mainButtons, "CyberGrindButton"), "Text"));
                cgButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_cybergrind;

                Text cgReturnButtonTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(mainButtons, "ReturnButton"), "Text"));
                cgReturnButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_returnToMission;

                //Sandbox button
                Text sandboxButtonTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(mainButtons, "SandboxButton"), "Text"));
                sandboxButtonTitle.text = LanguageManager.CurrentLanguage.shop.shop_sandbox;

                //Enemies title
                Text enemiesTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "Enemies"), "Panel"),"Title"));
                enemiesTitle.text = LanguageManager.CurrentLanguage.shop.shop_monsters;

                //Enemies back button
                Text enemiesBackButtonText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "Enemies"),"BackButton (2)"),"Text"));

                //Sandbox enter description
                GameObject sandboxEnter = GetGameObjectChild(GetGameObjectChild(shopObject, "Sandbox"), "Panel");

                Text sandboxTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "Sandbox"), "Panel"),"Title"));
                sandboxTitle.text = LanguageManager.CurrentLanguage.shop.shop_sandbox;

                Text sandboxEnterTitle = GetTextfromGameObject(GetGameObjectChild(sandboxEnter, "Title"));
                sandboxEnterTitle.text = sandboxButtonTitle.text;

                Text sandboxEnterDescription = GetTextfromGameObject(GetGameObjectChild(sandboxEnter, "Text"));

                sandboxEnterDescription.text = LanguageManager.CurrentLanguage.shop.shop_sandboxDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_sandboxDescription2;

                Text sandboxEnterButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(sandboxEnter, "SandboxButton (1)"), "Text"));
                sandboxEnterButton.text = LanguageManager.CurrentLanguage.shop.shop_sandboxEnter;


                //CG enter description

                GameObject cgEnter = GetGameObjectChild(GetGameObjectChild(shopObject, "The Cyber Grind"), "Panel");

                Text cgEnterTitle = GetTextfromGameObject(GetGameObjectChild(cgEnter, "Title"));
                cgEnterTitle.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindEnterTitle;

                Text cgEnterDescription = GetTextfromGameObject(GetGameObjectChild(cgEnter, "Text"));

                cgEnterDescription.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription3;

                Text cgEnterButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgEnter, "CyberGrindButton (1)"), "Text"));
                cgEnterButton.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindEnter;

                
                
                //CG exit description
                GameObject cgExit = GetGameObjectChild(GetGameObjectChild(shopObject, "Return from Cyber Grind"), "Panel");

                Text cgExitTitle = GetTextfromGameObject(GetGameObjectChild(cgExit, "Title"));
                cgExitTitle.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindExitTitle;


                //Disable the LevelNameFinder component so it doesn't remove the translated string!
                GameObject levelText = GetGameObjectChild(cgExit, "Text");

                Text cgExitDescriptionText = GetTextfromGameObject(GetGameObjectChild(cgExit, "Text"));

                Text cgExitDescription = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cgExit, "CyberGrindButton (1)"), "Text"));
                if (SceneManager.GetActiveScene().name == "uk_construct")
                {
                    cgExitDescription.text = LanguageManager.CurrentLanguage.frontend.mainmenu_quit;
                }
                else
                {
                    cgExitDescription.text = LanguageManager.CurrentLanguage.shop.shop_cybergrindExit;
                }

                //Enemies back button 
                Text enemiesBackText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "Enemies"), "BackButton (2)"), "Text"));
                enemiesBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Sandbox back button
                Text sandboxBackText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "Sandbox"), "BackButton (2)"), "Text"));
                sandboxBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //EnemyInfo back button
                Text enemyInfoBackText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "EnemyInfo"),"Button"),"Text"));
                enemyInfoBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Enter CG back text
                Text cgEnterBackButtonText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "The Cyber Grind"), "BackButton (2)"), "Text"));
                cgEnterBackButtonText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                //Exit CG back text
                Text cgExitBackButtonText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shopObject, "Return from Cyber Grind"), "BackButton (2)"), "Text"));
                cgExitBackButtonText.text = LanguageManager.CurrentLanguage.shop.shop_back;
            }
        }

        private static void PatchWeapons(ref List<GameObject> shopsToPatch)
        {
            foreach(GameObject shopObject in shopsToPatch)
            {
                GameObject shopWeaponsObject  = GetGameObjectChild(shopObject,"Weapons");

                Text weaponBackText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "BackButton (1)"), "Text"));
                weaponBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

                Text weaponRevolverText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RevolverButton"), "Text"));
                weaponRevolverText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

                Text weaponShotgunText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "ShotgunButton"), "Text"));
                weaponShotgunText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;

                Text weaponNailgunText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "NailgunButton"), "Text"));
                weaponNailgunText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

                //Slight problem - not all the text fits in the box.
                //The longer text is, the more we'll need to reduce the font size to compensate.
                Text weaponRailcannonText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RailcannonButton"), "Text"));
                weaponRailcannonText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;
                weaponRailcannonText.fontSize = 16;

                Text rocketLauncherText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "RocketLauncherButton"), "Text"));
                rocketLauncherText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;
                rocketLauncherText.fontSize = 16;

                Text weaponArmText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(shopWeaponsObject, "ArmButton"), "Text"));
                weaponArmText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsArms;

                //Revolver window and descriptions
                GameObject revolverWindow = GetGameObjectChild(shopWeaponsObject, "RevolverWindow");

                //Piercer
                GameObject piercer = GetGameObjectChild(revolverWindow, "Variation Panel (Blue)");
                Text piercerName = GetTextfromGameObject(GetGameObjectChild(piercer, "Text"));
                piercerName.text = LanguageManager.CurrentLanguage.shop.shop_revolverPiercer;

                GameObject piercerWindow = GetGameObjectChild(revolverWindow, "Variation Info (Blue)");
                Text piercerWindowName = GetTextfromGameObject(GetGameObjectChild(piercerWindow, "Name"));
                piercerWindowName.text = piercerName.text;

                Text piercerWindowDescription = GetTextfromGameObject(GetGameObjectChild(piercerWindow, "Description"));
                piercerWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription2;

                Text piercerWindowDescriptionBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(piercerWindow, "Button"),"Text"));
                piercerWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Marksman
                GameObject marksman = GetGameObjectChild(revolverWindow, "Variation Panel (Green)");
                Text marksmanName = GetTextfromGameObject(GetGameObjectChild(marksman, "Text"));
                marksmanName.text = LanguageManager.CurrentLanguage.shop.shop_revolverMarksman;
                marksmanName.fontSize = 14;

                GameObject marksmanWindow = GetGameObjectChild(revolverWindow, "Variation Info (Green)");
                Text marksmanWindowName = GetTextfromGameObject(GetGameObjectChild(marksmanWindow, "Name"));
                marksmanWindowName.text = marksmanName.text;

                Text marksmanWindowDescription = GetTextfromGameObject(GetGameObjectChild(marksmanWindow, "Description"));
                marksmanWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription3;
                marksmanWindowDescription.fontSize = 14;

                Text marksmanWindowDescriptionBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(marksmanWindow, "Button"), "Text"));
                marksmanWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Revolver red variation (under construction)
                GameObject revolverRedVariation = GetGameObjectChild(revolverWindow, "Variation Panel (Red)");
                Text revolverRedUnderConstruction = GetTextfromGameObject(GetGameObjectChild(revolverRedVariation, "Text (1)"));
                revolverRedUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

                //Revolver info & color tabs
                GameObject revolverExtra = GetGameObjectChild(revolverWindow, "Info and Color Panel");
                GameObject revolverExtraInfo = GetGameObjectChild(revolverExtra, "InfoButton");
                GameObject revolverExtraColor = GetGameObjectChild(revolverExtra, "ColorButton");

                Text revolverExtraInfoText = GetTextfromGameObject(GetGameObjectChild(revolverExtraInfo, "Text"));
                revolverExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                Text revolverExtraInfoColors = GetTextfromGameObject(GetGameObjectChild(revolverExtraColor, "Text"));
                revolverExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Revolver lore
                GameObject revolverLore = GetGameObjectChild(revolverWindow, "Info Screen");
                Text revolverLoreName = GetTextfromGameObject(GetGameObjectChild(revolverLore, "Name"));
                revolverLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

                Text revolverLoreInfo = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverLore,"Scroll View"),"Viewport"),"Text"));

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

                Text revolverLoreBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(revolverLore, "Button"), "Text"));
                revolverLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Revolver preset colors
                GameObject revolverColorWindow = GetGameObjectChild(revolverWindow, "Color Screen");

                Text revolverColorWindowTitle = GetTextfromGameObject(GetGameObjectChild(revolverColorWindow,"Title"));
                revolverColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver + "--";

                GameObject revolverStandardTemplates = GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Standard"),"Template");
                Text revolverStandardTemplate1 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "Template 1"),"Button (Selectable)"),"Text"));
                Text revolverStandardTemplate2 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                Text revolverStandardTemplate3 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                Text revolverStandardTemplate4 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                Text revolverStandardTemplate5 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                revolverStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset1;
                revolverStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset2;
                revolverStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset3;
                revolverStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset4;
                revolverStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset5;

                Text revolverColorSwitchToAlternative = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Standard"),"AlternateButton"),"Text"));
                revolverColorSwitchToAlternative.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

                Text revolverColorSwitchToStandard = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Alternate"), "AlternateButton"), "Text"));
                revolverColorSwitchToStandard.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

                GameObject revolverAlternateTemplates = GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Alternate"), "Template");
                Text revolverAlternateTemplate1 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                Text revolverAlternateTemplate2 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                Text revolverAlternateTemplate3 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                Text revolverAlternateTemplate4 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                Text revolverAlternateTemplate5 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                revolverAlternateTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset1;
                revolverAlternateTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset2;
                revolverAlternateTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset3;
                revolverAlternateTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset4;
                revolverAlternateTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset5;

                Text revolverColorStandardPreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "TemplateButton"),"Text"));
                revolverColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                Text revolverColorStandardCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(revolverStandardTemplates, "CustomButton"),"Text"));
                revolverColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                Text revolverColorAlternatePreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "TemplateButton"), "Text"));
                revolverColorAlternatePreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                Text revolverColorAlternateCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(revolverAlternateTemplates, "CustomButton"), "Text"));
                revolverColorAlternateCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                Text revolverColorDone = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Done"),"Text"));
                revolverColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Revolver custom colors
                GameObject revolverStandardCustom = GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Standard"),"Custom");
                Text revolverStandardCustomPreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(revolverStandardCustom, "TemplateButton"), "Text"));
                revolverStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                Text revolverStandardCustomCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(revolverStandardCustom, "CustomButton"), "Text"));
                revolverStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                GameObject revolverAlternateCustom = GetGameObjectChild(GetGameObjectChild(revolverColorWindow, "Alternate"), "Custom");
                Text revolverAlternateCustomPreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(revolverAlternateCustom, "TemplateButton"), "Text"));
                revolverAlternateCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                Text revolverAlternateCustomCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(revolverAlternateCustom, "CustomButton"), "Text"));
                revolverAlternateCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Revolver custom color unlock prompt
                Text revolverCustomColorPrompt = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(revolverWindow, "Color Screen"),"Standard"),"Custom"),"Locked"),"Blocker"),"Text"));

                revolverCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

                //Shotgun window and descriptions
                GameObject shotgunWindow = GetGameObjectChild(shopWeaponsObject, "ShotgunWindow");

                //Core Eject
                GameObject coreEject = GetGameObjectChild(shotgunWindow, "Variation Panel (Blue)");
                Text coreEjectName = GetTextfromGameObject(GetGameObjectChild(coreEject, "Text"));
                coreEjectName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject;

                GameObject coreEjectWindow = GetGameObjectChild(shotgunWindow, "Variation Info (Blue)");
                Text coreEjectWindowName = GetTextfromGameObject(GetGameObjectChild(coreEjectWindow, "Name"));
                coreEjectWindowName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject;

                Text coreEjectWindowDescription = GetTextfromGameObject(GetGameObjectChild(coreEjectWindow, "Description"));
                coreEjectWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription3;

                Text coreEjectWindowDescriptionBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(coreEjectWindow, "Button"), "Text"));
                coreEjectWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Pump Charge
                GameObject pumpCharge = GetGameObjectChild(shotgunWindow, "Variation Panel (Green)");
                Text pumpChargeName = GetTextfromGameObject(GetGameObjectChild(pumpCharge, "Text"));
                pumpChargeName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge;
                pumpChargeName.fontSize = 16;

                GameObject pumpChargeWindow = GetGameObjectChild(shotgunWindow, "Variation Info (Green)");
                Text pumpChargeWindowName = GetTextfromGameObject(GetGameObjectChild(pumpChargeWindow, "Name"));
                pumpChargeWindowName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge;

                Text pumpChargeWindowDescription = GetTextfromGameObject(GetGameObjectChild(pumpChargeWindow, "Description"));
                pumpChargeWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription2;
                pumpChargeWindowDescription.fontSize = 14;

                Text pumpChargeWindowDescriptionBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(pumpChargeWindow, "Button"), "Text"));
                pumpChargeWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Shotgun red variation (under construction)
                GameObject shotgunRedVariation = GetGameObjectChild(shotgunWindow, "Variation Panel (Red)");
                Text shotgunRedUnderConstruction = GetTextfromGameObject(GetGameObjectChild(shotgunRedVariation, "Text (1)"));
                shotgunRedUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

                //Shotgun info & color tabs
                GameObject shotgunExtra = GetGameObjectChild(shotgunWindow, "Info and Color Panel");
                GameObject shotgunExtraInfo = GetGameObjectChild(shotgunExtra, "InfoButton");
                GameObject shotgunExtraColor = GetGameObjectChild(shotgunExtra, "ColorButton");

                Text shotgunExtraInfoText = GetTextfromGameObject(GetGameObjectChild(shotgunExtraInfo, "Text"));
                shotgunExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                Text shotgunExtraInfoColors = GetTextfromGameObject(GetGameObjectChild(shotgunExtraColor, "Text"));
                shotgunExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Shotgun lore
                GameObject shotgunLore = GetGameObjectChild(shotgunWindow, "Info Screen");
                Text shotgunLoreName = GetTextfromGameObject(GetGameObjectChild(shotgunLore, "Name"));
                shotgunLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;

                Text shotgunLoreInfo = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunLore, "Scroll View"), "Viewport"), "Text"));

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

                Text shotgunLoreBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(shotgunLore, "Button"), "Text"));
                shotgunLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Shotgun preset colors
                GameObject shotgunColorWindow = GetGameObjectChild(shotgunWindow, "Color Screen");

                Text shotgunColorWindowTitle = GetTextfromGameObject(GetGameObjectChild(shotgunColorWindow, "Title"));
                shotgunColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun + "--";

                GameObject shotgunStandardTemplates = GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Standard"), "Template");
                Text shotgunStandardTemplate1 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                Text shotgunStandardTemplate2 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                Text shotgunStandardTemplate3 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                Text shotgunStandardTemplate4 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                Text shotgunStandardTemplate5 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                shotgunStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset1;
                shotgunStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset2;
                shotgunStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset3;
                shotgunStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset4;
                shotgunStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset5;

                Text shotgunColorStandardPreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "TemplateButton"), "Text"));
                shotgunColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                Text shotgunColorStandardCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(shotgunStandardTemplates, "CustomButton"), "Text"));
                shotgunColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                Text shotgunColorDone = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Done"), "Text"));
                shotgunColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Shotgun custom colors
                GameObject shotgunStandardCustom = GetGameObjectChild(GetGameObjectChild(shotgunColorWindow, "Standard"), "Custom");
                Text shotgunStandardCustomPreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(shotgunStandardCustom, "TemplateButton"), "Text"));
                shotgunStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                Text shotgunStandardCustomCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(shotgunStandardCustom, "CustomButton"), "Text"));
                shotgunStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Shotgun custom color unlock prompt
                Text shotgunCustomColorPrompt = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(shotgunWindow, "Color Screen"), "Standard"), "Custom"), "Locked"), "Blocker"), "Text"));

                shotgunCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

                //Nailgun window and descriptions
                GameObject nailgunWindow = GetGameObjectChild(shopWeaponsObject, "NailgunWindow");

                //Attractor
                GameObject attractor = GetGameObjectChild(nailgunWindow, "Variation Panel (Blue)");
                Text attractorName = GetTextfromGameObject(GetGameObjectChild(attractor, "Text"));
                attractorName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet;

                GameObject attractorWindow = GetGameObjectChild(nailgunWindow, "Variation Info (Blue)");
                Text attractorWindowName = GetTextfromGameObject(GetGameObjectChild(attractorWindow, "Name"));
                attractorWindowName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet;

                Text attractorWindowDescription = GetTextfromGameObject(GetGameObjectChild(attractorWindow, "Description"));
                attractorWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription2;
                attractorWindowDescription.fontSize = 16;

                Text attractorWindowDescriptionBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(attractorWindow, "Button"), "Text"));
                attractorWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Overheat
                GameObject overheat = GetGameObjectChild(nailgunWindow, "Variation Panel (Green)");
                Text overheatName = GetTextfromGameObject(GetGameObjectChild(overheat, "Text"));
                overheatName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;
                overheatName.fontSize = 16;

                GameObject overheatWindow = GetGameObjectChild(nailgunWindow, "Variation Info (Green)");
                Text overheatWindowName = GetTextfromGameObject(GetGameObjectChild(overheatWindow, "Name"));
                overheatWindowName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;

                Text overheatWindowDescription = GetTextfromGameObject(GetGameObjectChild(overheatWindow, "Description"));
                overheatWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription2;
                overheatWindowDescription.fontSize = 14;

                Text overheatWindowDescriptionBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(overheatWindow, "Button"), "Text"));
                overheatWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Nailgun red variation (under construction)
                GameObject nailgunRedVariation = GetGameObjectChild(nailgunWindow, "Variation Panel (Red)");
                Text nailgunRedUnderConstruction = GetTextfromGameObject(GetGameObjectChild(nailgunRedVariation, "Text (1)"));
                nailgunRedUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

                //Nailgun info & color tabs
                GameObject nailgunExtra = GetGameObjectChild(nailgunWindow, "Info and Color Panel");
                GameObject nailgunExtraInfo = GetGameObjectChild(nailgunExtra, "InfoButton");
                GameObject nailgunExtraColor = GetGameObjectChild(nailgunExtra, "ColorButton");

                Text nailgunExtraInfoText = GetTextfromGameObject(GetGameObjectChild(nailgunExtraInfo, "Text"));
                nailgunExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                Text nailgunExtraInfoColors = GetTextfromGameObject(GetGameObjectChild(nailgunExtraColor, "Text"));
                nailgunExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Nailgun lore
                GameObject nailgunLore = GetGameObjectChild(nailgunWindow, "Info Screen");
                Text nailgunLoreName = GetTextfromGameObject(GetGameObjectChild(nailgunLore, "Name"));
                nailgunLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

                Text nailgunLoreInfo = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunLore, "Scroll View"), "Viewport"), "Text"));
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

                Text nailgunLoreBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nailgunLore, "Button"), "Text"));
                nailgunLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;


                //Nailgun preset colors
                GameObject nailgunColorWindow = GetGameObjectChild(nailgunWindow, "Color Screen");

                Text nailgunColorWindowTitle = GetTextfromGameObject(GetGameObjectChild(nailgunColorWindow, "Title"));
                nailgunColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun + "--";

                GameObject nailgunStandardTemplates = GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Standard"), "Template");
                Text nailgunStandardTemplate1 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                Text nailgunStandardTemplate2 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                Text nailgunStandardTemplate3 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                Text nailgunStandardTemplate4 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                Text nailgunStandardTemplate5 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                nailgunStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset1;
                nailgunStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset2;
                nailgunStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset3;
                nailgunStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset4;
                nailgunStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset5;

                Text nailgunColorSwitchToAlternative = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Standard"), "AlternateButton"), "Text"));
                nailgunColorSwitchToAlternative.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

                Text nailgunColorSwitchToStandard = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Alternate"), "AlternateButton"), "Text"));
                nailgunColorSwitchToStandard.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

                GameObject nailgunAlternateTemplates = GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Alternate"), "Template");
                Text nailgunAlternateTemplate1 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                Text nailgunAlternateTemplate2 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                Text nailgunAlternateTemplate3 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                Text nailgunAlternateTemplate4 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                Text nailgunAlternateTemplate5 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                nailgunAlternateTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset1;
                nailgunAlternateTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset2;
                nailgunAlternateTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset3;
                nailgunAlternateTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset4;
                nailgunAlternateTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset5;

                Text nailgunColorStandardPreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "TemplateButton"), "Text"));
                nailgunColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                Text nailgunColorStandardCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nailgunStandardTemplates, "CustomButton"), "Text"));
                nailgunColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                Text nailgunColorAlternatePreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "TemplateButton"), "Text"));
                nailgunColorAlternatePreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                Text nailgunColorAlternateCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nailgunAlternateTemplates, "CustomButton"), "Text"));
                nailgunColorAlternateCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                Text nailgunColorDone = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Done"), "Text"));
                nailgunColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Nailgun custom colors
                GameObject nailgunStandardCustom = GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Standard"), "Custom");
                Text nailgunStandardCustomPreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nailgunStandardCustom, "TemplateButton"), "Text"));
                nailgunStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                Text nailgunStandardCustomCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nailgunStandardCustom, "CustomButton"), "Text"));
                nailgunStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                GameObject nailgunAlternateCustom = GetGameObjectChild(GetGameObjectChild(nailgunColorWindow, "Alternate"), "Custom");
                Text nailgunAlternateCustomPreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nailgunAlternateCustom, "TemplateButton"), "Text"));
                nailgunAlternateCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                Text nailgunAlternateCustomCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(nailgunAlternateCustom, "CustomButton"), "Text"));
                nailgunAlternateCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Nailgun custom color unlock prompt
                Text nailgunCustomColorPrompt = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(nailgunWindow, "Color Screen"), "Standard"), "Custom"), "Locked"), "Blocker"), "Text"));

                nailgunCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + ": " + LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

                //Railcannon window and descriptions
                GameObject railcannonWindow = GetGameObjectChild(shopWeaponsObject, "RailcannonWindow");

                //Electric
                GameObject electric = GetGameObjectChild(railcannonWindow, "Variation Panel (Blue)");
                Text electricName = GetTextfromGameObject(GetGameObjectChild(electric, "Text"));
                electricName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;

                GameObject electricWindow = GetGameObjectChild(railcannonWindow, "Variation Info (Blue)");
                Text electricWindowName = GetTextfromGameObject(GetGameObjectChild(electricWindow, "Name"));
                electricWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;

                Text electricWindowDescription = GetTextfromGameObject(GetGameObjectChild(electricWindow, "Description"));
                electricWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription2 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription3;
                electricWindowDescription.fontSize = 16;

                Text electricWindowDescriptionBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(electricWindow, "Button"), "Text"));
                electricWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Screwdriver
                GameObject screwdriver = GetGameObjectChild(railcannonWindow, "Variation Panel (Green)");
                Text screwdriverName = GetTextfromGameObject(GetGameObjectChild(screwdriver, "Text"));
                screwdriverName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;

                GameObject screwdriverWindow = GetGameObjectChild(railcannonWindow, "Variation Info (Green)");
                Text screwdriverWindowName = GetTextfromGameObject(GetGameObjectChild(screwdriverWindow, "Name"));
                screwdriverWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;

                Text screwdriverWindowDescription = GetTextfromGameObject(GetGameObjectChild(screwdriverWindow, "Description"));
                screwdriverWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription2;
                screwdriverWindowDescription.fontSize = 16;

                Text screwdriverWindowDescriptionBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(screwdriverWindow, "Button"), "Text"));
                screwdriverWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Malicious
                GameObject malicious = GetGameObjectChild(railcannonWindow, "Variation Panel (Red)");
                Text maliciousName = GetTextfromGameObject(GetGameObjectChild(malicious, "Text"));
                maliciousName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;

                GameObject maliciousWindow = GetGameObjectChild(railcannonWindow, "Variation Info (Red)");
                Text maliciousWindowName = GetTextfromGameObject(GetGameObjectChild(maliciousWindow, "Name"));
                maliciousWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;

                Text maliciousWindowDescription = GetTextfromGameObject(GetGameObjectChild(maliciousWindow, "Description"));
                maliciousWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription1 + "\n\n"
                    +  LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription2;
                maliciousWindowDescription.fontSize = 16;

                Text maliciousWindowDescriptionBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(maliciousWindow, "Button"), "Text"));
                maliciousWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Railcannon info & color tabs
                GameObject railcannonExtra = GetGameObjectChild(railcannonWindow, "Info and Color Panel");
                GameObject railcannonExtraInfo = GetGameObjectChild(railcannonExtra, "InfoButton");
                GameObject railcannonExtraColor = GetGameObjectChild(railcannonExtra, "ColorButton");

                Text railcannonExtraInfoText = GetTextfromGameObject(GetGameObjectChild(railcannonExtraInfo, "Text"));
                railcannonExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                Text railcannonExtraInfoColors = GetTextfromGameObject(GetGameObjectChild(railcannonExtraColor, "Text"));
                railcannonExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Railcannon lore
                GameObject railcannonLore = GetGameObjectChild(railcannonWindow, "Info Screen");
                Text railcannonLoreName = GetTextfromGameObject(GetGameObjectChild(railcannonLore, "Name"));
                railcannonLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;

                Text railcannonLoreInfo = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonLore, "Scroll View"), "Viewport"), "Text"));
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

                Text railcannonLoreBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(railcannonLore, "Button"), "Text"));
                railcannonLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;


                //Railcannon preset colors
                GameObject railcannonColorWindow = GetGameObjectChild(railcannonWindow, "Color Screen");

                Text railcannonColorWindowTitle = GetTextfromGameObject(GetGameObjectChild(railcannonColorWindow, "Title"));
                railcannonColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon + "--";

                GameObject railcannonStandardTemplates = GetGameObjectChild(GetGameObjectChild(railcannonColorWindow, "Standard"), "Template");
                Text railcannonStandardTemplate1 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                Text railcannonStandardTemplate2 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                Text railcannonStandardTemplate3 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                Text railcannonStandardTemplate4 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                Text railcannonStandardTemplate5 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                railcannonStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset1;
                railcannonStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset2;
                railcannonStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset3;
                railcannonStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset4;
                railcannonStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset5;

                Text railcannonColorStandardPreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "TemplateButton"), "Text"));
                railcannonColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                Text railcannonColorStandardCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(railcannonStandardTemplates, "CustomButton"), "Text"));
                railcannonColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                Text railcannonColorDone = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(railcannonColorWindow, "Done"), "Text"));
                railcannonColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Railcannon custom colors
                GameObject railcannonStandardCustom = GetGameObjectChild(GetGameObjectChild(railcannonColorWindow, "Standard"), "Custom");
                Text railcannonStandardCustomPreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(railcannonStandardCustom, "TemplateButton"), "Text"));
                railcannonStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                Text railcannonStandardCustomCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(railcannonStandardCustom, "CustomButton"), "Text"));
                railcannonStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Railcannon custom color unlock prompt
                Text railcannonCustomColorPrompt = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(railcannonWindow, "Color Screen"), "Standard"), "Custom"), "Locked"), "Blocker"), "Text"));

                railcannonCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + ": " + LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;


                //Rocket launcher window & descriptions
                GameObject rocketlauncherWindow = GetGameObjectChild(shopWeaponsObject, "RocketLauncherWindow");

                //Freezeframe
                GameObject freezeframe = GetGameObjectChild(rocketlauncherWindow, "Variation Panel (Blue)");
                Text freezeframeName = GetTextfromGameObject(GetGameObjectChild(freezeframe, "Text"));
                freezeframeName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze;

                GameObject freezeframeInfo = GetGameObjectChild(rocketlauncherWindow, "Variation Info (Blue)");
                Text freezeframeInfoName = GetTextfromGameObject(GetGameObjectChild(freezeframeInfo, "Name"));
                freezeframeInfoName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze;
                Text freezeframeDescription = GetTextfromGameObject(GetGameObjectChild(freezeframeInfo, "Description"));
                freezeframeDescription.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription1 + "\n\n" + 
                LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription2;
                freezeframeDescription.fontSize = 16;

                Text freezeframeDescriptionBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(freezeframeInfo, "Button"), "Text"));
                freezeframeDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Rocket Launcher green variation (under construction)
                GameObject rlGreenVariation = GetGameObjectChild(rocketlauncherWindow, "Variation Panel (Green) (Off)");
                Text rlGreenUnderConstruction = GetTextfromGameObject(GetGameObjectChild(rlGreenVariation, "Text (1)"));
                rlGreenUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

                //Rocket Launcher red variation (under construction)
                GameObject rlRedVariation = GetGameObjectChild(rocketlauncherWindow, "Variation Panel (Red)");
                Text rlRedUnderConstruction = GetTextfromGameObject(GetGameObjectChild(rlRedVariation, "Text (1)"));
                rlRedUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

                //Rocket launcher info & color tabs
                GameObject rocketlauncherExtra = GetGameObjectChild(rocketlauncherWindow, "Info and Color Panel");
                GameObject rocketlauncherExtraInfo = GetGameObjectChild(rocketlauncherExtra, "InfoButton");
                GameObject rocketlauncherExtraColor = GetGameObjectChild(rocketlauncherExtra, "ColorButton");

                Text rocketlauncherExtraInfoText = GetTextfromGameObject(GetGameObjectChild(rocketlauncherExtraInfo, "Text"));
                rocketlauncherExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

                Text rocketlauncherExtraInfoColors = GetTextfromGameObject(GetGameObjectChild(rocketlauncherExtraColor, "Text"));
                rocketlauncherExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

                //Rocket launcher lore
                GameObject rocketlauncherLore = GetGameObjectChild(rocketlauncherWindow, "Info Screen");
                Text rocketlauncherLoreName = GetTextfromGameObject(GetGameObjectChild(rocketlauncherLore, "Name"));
                rocketlauncherLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;

                Text rocketlauncherLoreInfo = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(rocketlauncherLore, "Scroll View"), "Viewport"), "Text"));
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


                Text rocketlauncherLoreBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(rocketlauncherLore, "Button"), "Text"));
                rocketlauncherLoreBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Rocket launcher preset colors
                GameObject RLColorWindow = GetGameObjectChild(rocketlauncherWindow, "Color Screen");

                Text RLColorWindowTitle = GetTextfromGameObject(GetGameObjectChild(RLColorWindow, "Title"));
                RLColorWindowTitle.text = "--" + LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher + "--";

                GameObject RLStandardTemplates = GetGameObjectChild(GetGameObjectChild(RLColorWindow, "Standard"), "Template");
                Text RLStandardTemplate1 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 1"), "Button (Selectable)"), "Text"));
                Text RLStandardTemplate2 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 2"), "Button (Selectable)"), "Text"));
                Text RLStandardTemplate3 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 3"), "Button (Selectable)"), "Text"));
                Text RLStandardTemplate4 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 4"), "Button (Selectable)"), "Text"));
                Text RLStandardTemplate5 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "Template 5"), "Button (Selectable)"), "Text"));

                RLStandardTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset1;
                RLStandardTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset2;
                RLStandardTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset3;
                RLStandardTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset4;
                RLStandardTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset5;

                Text RLColorStandardPreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "TemplateButton"), "Text"));
                RLColorStandardPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

                Text RLColorStandardCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(RLStandardTemplates, "CustomButton"), "Text"));
                RLColorStandardCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                Text RLColorDone = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(RLColorWindow, "Done"), "Text"));
                RLColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

                //Rocket launcher custom colors
                GameObject RLStandardCustom = GetGameObjectChild(GetGameObjectChild(RLColorWindow, "Standard"), "Custom");
                Text RLStandardCustomPreset = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(RLStandardCustom, "TemplateButton"), "Text"));
                RLStandardCustomPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;
                Text RLStandardCustomCustom = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(RLStandardCustom, "CustomButton"), "Text"));
                RLStandardCustomCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

                //Rocket launcher custom color unlock prompt
                Text RLCustomColorPrompt = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(rocketlauncherWindow, "Color Screen"), "Standard"), "Custom"), "Locked"), "Blocker"), "Text"));

                RLCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + ": " + LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;

                //Arm window and descriptions
                GameObject armWindow = GetGameObjectChild(shopWeaponsObject, "ArmWindow");

                //Feedbacker
                GameObject feedbacker = GetGameObjectChild(armWindow, "Variation Panel 1 (New)");
                Text feedbackerName = GetTextfromGameObject(GetGameObjectChild(feedbacker, "Text"));
                feedbackerName.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;

                GameObject feedbackerWindow = GetGameObjectChild(armWindow, "Variation 1 Info (New)");
                Text feedbackerWindowName = GetTextfromGameObject(GetGameObjectChild(feedbackerWindow, "Name"));
                feedbackerWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;

                Text feedbackerWindowDescription = GetTextfromGameObject(GetGameObjectChild(feedbackerWindow, "Description"));
                feedbackerWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription1 + "\n\n" + LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription2;

                Text feedbackerWindowDescriptionBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(feedbackerWindow, "Button"), "Text"));
                feedbackerWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;
                
                //Knuckleblaster
                GameObject knuckleblaster = GetGameObjectChild(armWindow, "Variation Panel 2 (New)");
                Text knuckleblasterName = GetTextfromGameObject(GetGameObjectChild(knuckleblaster, "Text"));
                knuckleblasterName.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;

                GameObject knuckleblasterWindow = GetGameObjectChild(armWindow, "Variation 2 Info (New)");
                Text knuckleblasterWindowName = GetTextfromGameObject(GetGameObjectChild(knuckleblasterWindow, "Name"));
                knuckleblasterWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;

                Text knuckleblasterWindowDescription = GetTextfromGameObject(GetGameObjectChild(knuckleblasterWindow, "Description"));
                knuckleblasterWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription1 + "\n\n" + LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription2;

                Text knuckleblasterWindowDescriptionBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(knuckleblasterWindow, "Button"), "Text"));
                knuckleblasterWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;
                
                //Whiplash
                GameObject whiplash = GetGameObjectChild(armWindow, "Variation Panel 3 (New)");
                Text whiplashName = GetTextfromGameObject(GetGameObjectChild(whiplash, "Text"));
                whiplashName.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;

                GameObject whiplashWindow = GetGameObjectChild(armWindow, "Variation 3 Info (New)");
                Text whiplashWindowName = GetTextfromGameObject(GetGameObjectChild(whiplashWindow, "Name"));
                whiplashWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;

                Text whiplashWindowDescription = GetTextfromGameObject(GetGameObjectChild(whiplashWindow, "Description"));
                whiplashWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription1 + "\n\n"
                    + LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription2;
                whiplashWindowDescription.fontSize = 16;
                
                Text whiplashWindowDescriptionBack = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(whiplashWindow, "Button"), "Text"));
                whiplashWindowDescriptionBack.text = LanguageManager.CurrentLanguage.options.options_back;

                //Gold arm (under construction)
                GameObject goldArm = GetGameObjectChild(armWindow, "Variation Panel 1 (3)");
                Text goldArmUnderConstruction = GetTextfromGameObject(GetGameObjectChild(goldArm, "Text (1)"));
                goldArmUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;
            }

        }


        public static void PatchShop(ref GameObject level)
        {
            List<GameObject> shopsToPatch = new List<GameObject>();
            //Start by finding what level we're on and what shopObjects need patching.
            if (SceneManager.GetActiveScene().name == "uk_construct")
            {
                
                shopsToPatch.Add(GetGameObjectChild(GameObject.Find("Shop"),"Canvas"));
            }
            else if(SceneManager.GetActiveScene().name.Contains("P-"))
            {
                shopsToPatch.Add(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GameObject.Find("Prime FirstRoom"),"Room"),"Shop"),"Canvas"));
            }
            //Specific fix for 6-1
            else if(SceneManager.GetActiveScene().name == "Level 6-1")
            {
                shopsToPatch.Add(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GameObject.Find("Interiors"),"FirstRoom"),"Room"),"Shop"),"Canvas"));
            }
            
            else
            {
                shopsToPatch.Add(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("FirstRoom"), "Room"), "Shop"), "Canvas"));
            } 
            
            switch(SceneManager.GetActiveScene().name)
            {
                case "Level 0-3":
                {
                    shopsToPatch.Add(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("5 - Path 1 - Hallway"),"5 Nonstuff"),"Shop"),"Canvas"));
                    shopsToPatch.Add(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("10B - Boss Staircase"),"5 Nonstuff"),"Shop"),"Canvas"));
                    break;
                }
                case "Level 0-5":
                {
                    shopsToPatch.Add(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("3 - Smallway"),"Shop"),"Canvas"));
                    break;
                }
                case "Level 1-3":
                {
                    shopsToPatch.Add(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("R1 - Courtyard"),"R1 Nonstuff"),"Shop"),"Canvas"));
                    break;
                }
                case "Level 1-4":
                {
                    shopsToPatch.Add(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("V2 - Arena"),"V2 Nonstuff"),"Shop"),"Canvas"));
                    break;
                }
                case "Level 2-4":
                {
                    shopsToPatch.Add(GetGameObjectChild(GetInactiveRootObject("Shop"),"Canvas"));
                    break;
                }
                case "Level 3-2":
                {
                    shopsToPatch.Add(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("4 - Heart Chamber"),"4 Nonstuff"),"Shop"),"Canvas"));
                    break;
                }
                case "Level 4-4":
                {
                    shopsToPatch.Add(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("6 - Boss Entrance"),"Shop"),"Canvas"));
                    break;
                }
                case "Level 5-2":
                {
                    shopsToPatch.Add(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("8 - Ship"),"Ship Nonstuff"),"Shop"),"Canvas"));
                    break;
                }
                case "Level 5-4":
                {                    
                    shopsToPatch.Add(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Surface"),"Nonstuff"),"SpawnRock"),"Shop"),"Canvas"));
                    break;
                }
                case "Level 6-2":
                {
                    shopsToPatch.Add(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("1 - Entryway"),"Grand Hall"),"Boss Room Tunnel"),"Shop"),"Canvas"));
                    break;
                }
            }
            
            
            PatchShopFrontEnd(ref shopsToPatch);
            PatchWeapons(ref shopsToPatch);
        }
    }
}
