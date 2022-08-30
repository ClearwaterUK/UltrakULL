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
    class Shop
    {
        public void patchShopFrontEnd(ref GameObject coreGame, JsonParser language)
        {
            Console.WriteLine("Starting patchShop");

            //NOTE
            //Harmless, but still present, exception that happens, in a normal level when trying to patch the Return From Cyber Grind button
            //since it isn't active. Will need to fix since an exception here prevents any code to come from running
            //Commented out the offending block for now. Scroll down a bit to see it.

            //FirstRoom/Room/Shop/Canvas
            GameObject shopObject;
            if (SceneManager.GetActiveScene().name == "uk_construct")
            {
                Console.WriteLine("Using sandbox shop");
                shopObject = getGameObjectChild(GameObject.Find("Shop"),"Canvas");
            }
            else
            {
                shopObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(coreGame, "Room"), "Shop"), "Canvas");
            }



            //Tip panel
            GameObject tipPanel = getGameObjectChild(getGameObjectChild(shopObject, "TipBox"), "Panel");
            Text tipTitle = getTextfromGameObject(getGameObjectChild(tipPanel, "Title"));
            tipTitle.text = language.currentLanguage.shop.shop_tipofthedayTitle;

            Text tipDescription = getTextfromGameObject(getGameObjectChild(tipPanel, "TipText"));
            Console.WriteLine("Original tip text: \n" + tipDescription.text);
            StringsParent levelTipStrings = new StringsParent();
            tipDescription.text = levelTipStrings.getLevelTip(language);


            //Weapons button
            GameObject mainButtons = getGameObjectChild(shopObject, "Main Menu");
            Console.WriteLine(mainButtons.name);

            Text weaponsButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "WeaponsButton"), "Text"));
            weaponsButtonTitle.text = language.currentLanguage.shop.shop_weapons;

            //Enemies button
            Text enemiesButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "EnemiesButton"), "Text"));
            enemiesButtonTitle.text = language.currentLanguage.shop.shop_monsters;

            //CG buttons
            Text cgButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "CyberGrindButton"), "Text"));
            cgButtonTitle.text = language.currentLanguage.shop.shop_cybergrind;

            Text cgReturnButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "ReturnButton"), "Text"));
            cgReturnButtonTitle.text = language.currentLanguage.shop.shop_returnToMission;

            //Sandbox button
            Text sandboxButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "SandboxButton"), "Text"));
            sandboxButtonTitle.text = language.currentLanguage.shop.shop_sandbox;

            //Enemies title
            Text enemiesTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "Enemies"), "Panel"),"Title"));
            enemiesTitle.text = language.currentLanguage.shop.shop_monsters;

            //Enemies back button
            Text enemiesBackButtonText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "Enemies"),"BackButton (2)"),"Text"));

            //Sandbox enter description
            GameObject sandboxEnter = getGameObjectChild(getGameObjectChild(shopObject, "Sandbox"), "Panel");

            Text sandboxEnterTitle = getTextfromGameObject(getGameObjectChild(sandboxEnter, "Title"));
            sandboxButtonTitle.text = sandboxButtonTitle.text;

            Text sandboxEnterDescription = getTextfromGameObject(getGameObjectChild(sandboxEnter, "Text"));

            sandboxEnterDescription.text = "Le <color=#4C99E6>Bac à sable</color> est un niveau vide qui peut être utilisé pour l'entraînement.\n\n" +
                "<color=red>Tout progrès dans le mission actuel sera perdu.</color>";

            Text sandboxEnterButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(sandboxEnter, "SandboxButton (1)"), "Text"));
            sandboxEnterButton.text = "ENTREZ LE BAC À SABLE";


            //CG enter description

            GameObject cgEnter = getGameObjectChild(getGameObjectChild(shopObject, "The Cyber Grind"), "Panel");

            Text cgEnterTitle = getTextfromGameObject(getGameObjectChild(cgEnter, "Title"));
            cgEnterTitle.text = "LE CYBERGRIND";

            Text cgEnterDescription = getTextfromGameObject(getGameObjectChild(cgEnter, "Text"));

            cgEnterDescription.text = language.currentLanguage.shop.shop_cybergrindDescription1 + "\n\n"
                + language.currentLanguage.shop.shop_cybergrindDescription2 + "\n\n"
                + language.currentLanguage.shop.shop_cybergrindDescription3;

            Text cgEnterButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgEnter, "CyberGrindButton (1)"), "Text"));
            cgEnterButton.text = language.currentLanguage.shop.shop_cybergrindEnter;

            /*
            //CG exit description
            GameObject cgExit = getGameObjectChild(getGameObjectChild(shopObject, "Return from Cyber Grind"), "Panel");

            Text cgExitTitle = getTextfromGameObject(getGameObjectChild(cgExit, "Title"));
            cgExitTitle.text = "FUCK FUCK GO BACK";

            //Disable the LevelNameFinder component so it doesn't remove the translated string!
            GameObject levelText = getGameObjectChild(cgExit, "Text");
            LevelNameFinder comp = levelText.GetComponent<LevelNameFinder>();
            comp.enabled = false;

            Text cgExitDescriptionText = getTextfromGameObject(getGameObjectChild(cgExit, "Text"));
            StringsParent returningLevel = new StringsParent();
            cgExitDescriptionText.text = "<color=red> Going back to </color>: \n" + returningLevel.getReturningLevelName(cgExitDescriptionText.text);

            Text cgExitDescription = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgExit, "CyberGrindButton (1)"), "Text"));
            cgExitDescription.text = "SEE YOU NEXT UPDATE pepePoint";
            */


            //Enemies back button 
            Text enemiesBackText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "Enemies"), "BackButton (2)"), "Text"));
            enemiesBackText.text = language.currentLanguage.shop.shop_back;

            //Sandbox back button
            Text sandboxBackText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "Sandbox"), "BackButton (2)"), "Text"));
            sandboxBackText.text = language.currentLanguage.shop.shop_back;

            //EnemyInfo back button
            Text enemyInfoBackText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "EnemyInfo"),"Button"),"Text"));
            enemyInfoBackText.text = language.currentLanguage.shop.shop_back;


        }


        public void patchWeapons(ref GameObject coreGame, JsonParser language)
        {
            GameObject shopWeaponsObject;
            if (SceneManager.GetActiveScene().name == "uk_construct")
            {
                Console.WriteLine("Using sandbox shop");
                shopWeaponsObject = getGameObjectChild(getGameObjectChild(GameObject.Find("Shop"), "Canvas"),"Weapons");
            }
            else
            {
                shopWeaponsObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(coreGame, "Room"), "Shop"), "Canvas"), "Weapons");
            }


            Text weaponBackText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "BackButton (1)"), "Text"));
            weaponBackText.text = language.currentLanguage.shop.shop_back;

            Text weaponRevolverText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "RevolverButton"), "Text"));
            weaponRevolverText.text = language.currentLanguage.shop.shop_weaponsRevolver;

            Text weaponShotgunText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "ShotgunButton"), "Text"));
            weaponShotgunText.text = language.currentLanguage.shop.shop_weaponsShotgun;

            Text weaponNailgunText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "NailgunButton"), "Text"));
            weaponNailgunText.text = language.currentLanguage.shop.shop_weaponsNailgun;

            //Slight problem - not all the text fits in the box.
            //The longer text is, the more we'll need to reduce the font size to compensate.
            Text weaponRailcannonText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "RailcannonButton"), "Text"));
            weaponRailcannonText.text = language.currentLanguage.shop.shop_weaponsRailcannon;
            weaponRailcannonText.fontSize = 16;

            Text rocketLauncherText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "RocketLauncherButton"), "Text"));
            rocketLauncherText.text = language.currentLanguage.shop.shop_weaponsRocketLauncher;
            rocketLauncherText.fontSize = 16;

            Text weaponArmText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "ArmButton"), "Text"));
            weaponArmText.text = language.currentLanguage.shop.shop_weaponsArms;

            //Revolver window and descriptions
            GameObject revolverWindow = getGameObjectChild(shopWeaponsObject, "RevolverWindow");

            //Piercer
            GameObject piercer = getGameObjectChild(revolverWindow, "Variation Panel (Blue)");
            Text piercerName = getTextfromGameObject(getGameObjectChild(piercer, "Text"));
            piercerName.text = language.currentLanguage.shop.shop_revolverPiercer;

            GameObject piercerWindow = getGameObjectChild(revolverWindow, "Variation Info (Blue)");
            Text piercerWindowName = getTextfromGameObject(getGameObjectChild(piercerWindow, "Name"));
            piercerWindowName.text = piercerName.text;

            Text piercerWindowDescription = getTextfromGameObject(getGameObjectChild(piercerWindow, "Description"));
            piercerWindowDescription.text = language.currentLanguage.shop.shop_revolverPiercerDescription1 + "\n\n"
                + language.currentLanguage.shop.shop_revolverPiercerDescription2;

            //Marksman

            GameObject marksman = getGameObjectChild(revolverWindow, "Variation Panel (Green)");
            Text marksmanName = getTextfromGameObject(getGameObjectChild(marksman, "Text"));
            marksmanName.text = language.currentLanguage.shop.shop_revolverMarksman;
            marksmanName.fontSize = 14;

            GameObject marksmanWindow = getGameObjectChild(revolverWindow, "Variation Info (Green)");
            Text marksmanWindowName = getTextfromGameObject(getGameObjectChild(marksmanWindow, "Name"));
            marksmanWindowName.text = marksmanName.text;

            Text marksmanWindowDescription = getTextfromGameObject(getGameObjectChild(marksmanWindow, "Description"));
            marksmanWindowDescription.text = language.currentLanguage.shop.shop_revolverMarksmanDescription1 + "\n\n"
                + language.currentLanguage.shop.shop_revolverMarksmanDescription2 + "\n\n"
                + language.currentLanguage.shop.shop_revolverMarksmanDescription3;
            marksmanWindowDescription.fontSize = 14;

            //Revolver info & color tabs
            GameObject revolverExtra = getGameObjectChild(revolverWindow, "Info and Color Panel");
            GameObject revolverExtraInfo = getGameObjectChild(revolverExtra, "InfoButton");
            GameObject revolverExtraColor = getGameObjectChild(revolverExtra, "ColorButton");

            Text revolverExtraInfoText = getTextfromGameObject(getGameObjectChild(revolverExtraInfo, "Text"));
            revolverExtraInfoText.text = language.currentLanguage.shop.shop_weaponInfo;

            Text revolverExtraInfoColors = getTextfromGameObject(getGameObjectChild(revolverExtraColor, "Text"));
            revolverExtraInfoColors.text = language.currentLanguage.shop.shop_weaponColors;

            //Revolver lore
            GameObject revolverLore = getGameObjectChild(revolverWindow, "Info Screen");
            Text revolverLoreName = getTextfromGameObject(getGameObjectChild(revolverLore, "Name"));
            revolverLoreName.text = language.currentLanguage.shop.shop_weaponsRevolver;

            Text revolverLoreInfo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(revolverLore,"Scroll View"),"Viewport"),"Text"));
            revolverLoreInfo.text = "lore";

            //Shotgun window and descriptions
            GameObject shotgunWindow = getGameObjectChild(shopWeaponsObject, "ShotgunWindow");

            GameObject coreEject = getGameObjectChild(shotgunWindow, "Variation Panel (Blue)");
            Text coreEjectName = getTextfromGameObject(getGameObjectChild(coreEject, "Text"));
            coreEjectName.text = language.currentLanguage.shop.shop_shotgunCoreEject;

            GameObject coreEjectWindow = getGameObjectChild(shotgunWindow, "Variation Info (Blue)");
            Text coreEjectWindowName = getTextfromGameObject(getGameObjectChild(coreEjectWindow, "Name"));
            coreEjectWindowName.text = language.currentLanguage.shop.shop_shotgunCoreEject;

            Text coreEjectWindowDescription = getTextfromGameObject(getGameObjectChild(coreEjectWindow, "Description"));
            coreEjectWindowDescription.text = language.currentLanguage.shop.shop_shotgunCoreEjectDescription1 + "\n\n"
                + language.currentLanguage.shop.shop_shotgunCoreEjectDescription2 + "\n\n"
                + language.currentLanguage.shop.shop_shotgunCoreEjectDescription3;

            GameObject pumpCharge = getGameObjectChild(shotgunWindow, "Variation Panel (Green)");
            Text pumpChargeName = getTextfromGameObject(getGameObjectChild(pumpCharge, "Text"));
            pumpChargeName.text = language.currentLanguage.shop.shop_shotgunPumpCharge;
            pumpChargeName.fontSize = 16;

            GameObject pumpChargeWindow = getGameObjectChild(shotgunWindow, "Variation Info (Green)");
            Text pumpChargeWindowName = getTextfromGameObject(getGameObjectChild(pumpChargeWindow, "Name"));
            pumpChargeWindowName.text = language.currentLanguage.shop.shop_shotgunPumpCharge;

            Text pumpChargeWindowDescription = getTextfromGameObject(getGameObjectChild(pumpChargeWindow, "Description"));
            pumpChargeWindowDescription.text = language.currentLanguage.shop.shop_shotgunPumpChargeDescription1 + "\n\n"
                + language.currentLanguage.shop.shop_shotgunPumpChargeDescription2;
            pumpChargeWindowDescription.fontSize = 14;

            //Shotgun info & color tabs
            GameObject shotgunExtra = getGameObjectChild(shotgunWindow, "Info and Color Panel");
            GameObject shotgunExtraInfo = getGameObjectChild(shotgunExtra, "InfoButton");
            GameObject shotgunExtraColor = getGameObjectChild(shotgunExtra, "ColorButton");

            Text shotgunExtraInfoText = getTextfromGameObject(getGameObjectChild(shotgunExtraInfo, "Text"));
            shotgunExtraInfoText.text = language.currentLanguage.shop.shop_weaponInfo;

            Text shotgunExtraInfoColors = getTextfromGameObject(getGameObjectChild(shotgunExtraColor, "Text"));
            shotgunExtraInfoColors.text = language.currentLanguage.shop.shop_weaponColors;

            //Shotgun lore
            GameObject shotgunLore = getGameObjectChild(shotgunWindow, "Info Screen");
            Text shotgunLoreName = getTextfromGameObject(getGameObjectChild(shotgunLore, "Name"));
            shotgunLoreName.text = language.currentLanguage.shop.shop_weaponsShotgun;

            Text shotgunLoreInfo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shotgunLore, "Scroll View"), "Viewport"), "Text"));
            shotgunLoreInfo.text = "lore";

            //Nailgun window and descriptions
            GameObject nailgunWindow = getGameObjectChild(shopWeaponsObject, "NailgunWindow");

            GameObject attractor = getGameObjectChild(nailgunWindow, "Variation Panel (Blue)");
            Text attractorName = getTextfromGameObject(getGameObjectChild(attractor, "Text"));
            attractorName.text = language.currentLanguage.shop.shop_nailgunMagnet;

            GameObject attractorWindow = getGameObjectChild(nailgunWindow, "Variation Info (Blue)");
            Text attractorWindowName = getTextfromGameObject(getGameObjectChild(attractorWindow, "Name"));
            attractorWindowName.text = language.currentLanguage.shop.shop_nailgunMagnet;

            Text attractorWindowDescription = getTextfromGameObject(getGameObjectChild(attractorWindow, "Description"));
            attractorWindowDescription.text = language.currentLanguage.shop.shop_nailgunMagnetDescription1 + "\n\n"
                + language.currentLanguage.shop.shop_nailgunMagnetDescription2;
            attractorWindowDescription.fontSize = 16;


            GameObject overheat = getGameObjectChild(nailgunWindow, "Variation Panel (Green)");
            Text overheatName = getTextfromGameObject(getGameObjectChild(overheat, "Text"));
            overheatName.text = language.currentLanguage.shop.shop_nailgunOverheat;
            overheatName.fontSize = 16;

            GameObject overheatWindow = getGameObjectChild(nailgunWindow, "Variation Info (Green)");
            Text overheatWindowName = getTextfromGameObject(getGameObjectChild(overheatWindow, "Name"));
            overheatWindowName.text = language.currentLanguage.shop.shop_nailgunOverheat;

            Text overheatWindowDescription = getTextfromGameObject(getGameObjectChild(overheatWindow, "Description"));
            overheatWindowDescription.text = language.currentLanguage.shop.shop_nailgunOverheatDescription1 + "\n\n"
                + language.currentLanguage.shop.shop_nailgunOverheatDescription2;
            overheatWindowDescription.fontSize = 14;

            //Nailgun info & color tabs
            GameObject nailgunExtra = getGameObjectChild(nailgunWindow, "Info and Color Panel");
            GameObject nailgunExtraInfo = getGameObjectChild(nailgunExtra, "InfoButton");
            GameObject nailgunExtraColor = getGameObjectChild(nailgunExtra, "ColorButton");

            Text nailgunExtraInfoText = getTextfromGameObject(getGameObjectChild(nailgunExtraInfo, "Text"));
            nailgunExtraInfoText.text = language.currentLanguage.shop.shop_weaponInfo;

            Text nailgunExtraInfoColors = getTextfromGameObject(getGameObjectChild(nailgunExtraColor, "Text"));
            nailgunExtraInfoColors.text = language.currentLanguage.shop.shop_weaponColors;

            //Nailgun lore
            GameObject nailgunLore = getGameObjectChild(nailgunWindow, "Info Screen");
            Text nailgunLoreName = getTextfromGameObject(getGameObjectChild(nailgunLore, "Name"));
            nailgunLoreName.text = language.currentLanguage.shop.shop_weaponsNailgun;

            Text nailgunLoreInfo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(nailgunLore, "Scroll View"), "Viewport"), "Text"));
            nailgunLoreInfo.text = "lore";



            //Railcannon window and descriptions
            GameObject railcannonWindow = getGameObjectChild(shopWeaponsObject, "RailcannonWindow");

            GameObject electric = getGameObjectChild(railcannonWindow, "Variation Panel (Blue)");
            Text electricName = getTextfromGameObject(getGameObjectChild(electric, "Text"));
            electricName.text = language.currentLanguage.shop.shop_railcannonElectric;

            GameObject electricWindow = getGameObjectChild(railcannonWindow, "Variation Info (Blue)");
            Text electricWindowName = getTextfromGameObject(getGameObjectChild(electricWindow, "Name"));
            electricWindowName.text = language.currentLanguage.shop.shop_railcannonElectric;

            Text electricWindowDescription = getTextfromGameObject(getGameObjectChild(electricWindow, "Description"));
            electricWindowDescription.text = language.currentLanguage.shop.shop_railcannonElectricDescription1 + "\n\n"
                + language.currentLanguage.shop.shop_railcannonElectricDescription2 + "\n\n"
                + language.currentLanguage.shop.shop_railcannonElectricDescription3;
            electricWindowDescription.fontSize = 16;

            GameObject screwdriver = getGameObjectChild(railcannonWindow, "Variation Panel (Green)");
            Text screwdriverName = getTextfromGameObject(getGameObjectChild(screwdriver, "Text"));
            screwdriverName.text = language.currentLanguage.shop.shop_railcannonScrewdriver;

            GameObject screwdriverWindow = getGameObjectChild(railcannonWindow, "Variation Info (Green)");
            Text screwdriverWindowName = getTextfromGameObject(getGameObjectChild(screwdriverWindow, "Name"));
            screwdriverWindowName.text = language.currentLanguage.shop.shop_railcannonScrewdriver;

            Text screwdriverWindowDescription = getTextfromGameObject(getGameObjectChild(screwdriverWindow, "Description"));
            screwdriverWindowDescription.text = language.currentLanguage.shop.shop_railcannonScrewdriverDescription1 + "\n\n"
                + language.currentLanguage.shop.shop_railcannonScrewdriverDescription2;
            screwdriverWindowDescription.fontSize = 16;

            GameObject malicious = getGameObjectChild(railcannonWindow, "Variation Panel (Red)");
            Text maliciousName = getTextfromGameObject(getGameObjectChild(malicious, "Text"));
            maliciousName.text = "MALICIEUX";

            GameObject maliciousWindow = getGameObjectChild(railcannonWindow, "Variation Info (Red)");
            Text maliciousWindowName = getTextfromGameObject(getGameObjectChild(maliciousWindow, "Name"));
            maliciousWindowName.text = maliciousName.text;

            Text maliciousWindowDescription = getTextfromGameObject(getGameObjectChild(maliciousWindow, "Description"));
            maliciousWindowDescription.text = language.currentLanguage.shop.shop_railcannonMaliciousDescription1 + "\n\n"
                +  language.currentLanguage.shop.shop_railcannonMaliciousDescription2;
            maliciousWindowDescription.fontSize = 16;

            //Railcannon info & color tabs
            GameObject railcannonExtra = getGameObjectChild(railcannonWindow, "Info and Color Panel");
            GameObject railcannonExtraInfo = getGameObjectChild(railcannonExtra, "InfoButton");
            GameObject railcannonExtraColor = getGameObjectChild(railcannonExtra, "ColorButton");

            Text railcannonExtraInfoText = getTextfromGameObject(getGameObjectChild(railcannonExtraInfo, "Text"));
            railcannonExtraInfoText.text = language.currentLanguage.shop.shop_weaponInfo;

            Text railcannonExtraInfoColors = getTextfromGameObject(getGameObjectChild(railcannonExtraColor, "Text"));
            railcannonExtraInfoColors.text = language.currentLanguage.shop.shop_weaponColors;

            //Railcannon lore
            GameObject railcannonLore = getGameObjectChild(railcannonWindow, "Info Screen");
            Text railcannonLoreName = getTextfromGameObject(getGameObjectChild(railcannonLore, "Name"));
            railcannonLoreName.text = language.currentLanguage.shop.shop_weaponsRailcannon;

            Text railcannonLoreInfo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(railcannonLore, "Scroll View"), "Viewport"), "Text"));
            railcannonLoreInfo.text = "lore";


            //Rocket launcher window & descriptions
            GameObject rocketlauncherWindow = getGameObjectChild(shopWeaponsObject, "RocketLauncherWindow");

            GameObject freezeframe = getGameObjectChild(rocketlauncherWindow, "Variation Panel (Blue)");
            Text freezeframeName = getTextfromGameObject(getGameObjectChild(freezeframe, "Text"));
            freezeframeName.text = language.currentLanguage.shop.shop_rocketLauncherFreeze;

            GameObject freezeframeInfo = getGameObjectChild(rocketlauncherWindow, "Variation Info (Blue)");
            Text freezeframeDescription = getTextfromGameObject(getGameObjectChild(freezeframeInfo, "Description"));
            freezeframeDescription.text = language.currentLanguage.shop.shop_rocketLauncherFreezeDescription1 + "\n\n" + 
            language.currentLanguage.shop.shop_rocketLauncherFreezeDescription2;
            freezeframeDescription.fontSize = 16;

            //Rocket launcher info & color tabs
            GameObject rocketlauncherExtra = getGameObjectChild(rocketlauncherWindow, "Info and Color Panel");
            GameObject rocketlauncherExtraInfo = getGameObjectChild(rocketlauncherExtra, "InfoButton");
            GameObject rocketlauncherExtraColor = getGameObjectChild(rocketlauncherExtra, "ColorButton");

            Text rocketlauncherExtraInfoText = getTextfromGameObject(getGameObjectChild(rocketlauncherExtraInfo, "Text"));
            rocketlauncherExtraInfoText.text = language.currentLanguage.shop.shop_weaponInfo;

            Text rocketlauncherExtraInfoColors = getTextfromGameObject(getGameObjectChild(rocketlauncherExtraColor, "Text"));
            rocketlauncherExtraInfoColors.text = language.currentLanguage.shop.shop_weaponColors;

            //Rocket launcher lore
            GameObject rocketlauncherLore = getGameObjectChild(rocketlauncherWindow, "Info Screen");
            Text rocketlauncherLoreName = getTextfromGameObject(getGameObjectChild(rocketlauncherLore, "Name"));
            rocketlauncherLoreName.text = language.currentLanguage.shop.shop_weaponsRocketLauncher;

            Text rocketlauncherLoreInfo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(rocketlauncherLore, "Scroll View"), "Viewport"), "Text"));
            rocketlauncherLoreInfo.text = "lore";

            //Arm window and descriptions
            GameObject armWindow = getGameObjectChild(shopWeaponsObject, "ArmWindow");

            GameObject feedbacker = getGameObjectChild(armWindow, "Variation Panel 1 (New)");
            Text feedbackerName = getTextfromGameObject(getGameObjectChild(feedbacker, "Text"));
            feedbackerName.text = language.currentLanguage.shop.shop_armFeedbacker;

            GameObject feedbackerWindow = getGameObjectChild(armWindow, "Variation 1 Info (New)");
            Text feedbackerWindowName = getTextfromGameObject(getGameObjectChild(feedbackerWindow, "Name"));
            feedbackerWindowName.text = language.currentLanguage.shop.shop_armFeedbacker;

            Text feedbackerWindowDescription = getTextfromGameObject(getGameObjectChild(feedbackerWindow, "Description"));
            feedbackerWindowDescription.text = language.currentLanguage.shop.shop_armFeedbackerDescription1 + "\n\n" + language.currentLanguage.shop.shop_armFeedbackerDescription2;

            GameObject knuckleblaster = getGameObjectChild(armWindow, "Variation Panel 2 (New)");
            Text knuckleblasterName = getTextfromGameObject(getGameObjectChild(knuckleblaster, "Text"));
            knuckleblasterName.text = language.currentLanguage.shop.shop_armKnuckleblaster;

            GameObject knuckleblasterWindow = getGameObjectChild(armWindow, "Variation 2 Info (New)");
            Text knuckleblasterWindowName = getTextfromGameObject(getGameObjectChild(knuckleblasterWindow, "Name"));
            knuckleblasterWindowName.text = language.currentLanguage.shop.shop_armKnuckleblaster;

            Text knuckleblasterWindowDescription = getTextfromGameObject(getGameObjectChild(knuckleblasterWindow, "Description"));
            knuckleblasterWindowDescription.text = language.currentLanguage.shop.shop_armKnuckleblasterDescription1 + "\n\n" + language.currentLanguage.shop.shop_armKnuckleblasterDescription2;

            GameObject whiplash = getGameObjectChild(armWindow, "Variation Panel 3 (New)");
            Text whiplashName = getTextfromGameObject(getGameObjectChild(whiplash, "Text"));
            whiplashName.text = language.currentLanguage.shop.shop_armWhiplash;

            //here
            GameObject whiplashWindow = getGameObjectChild(armWindow, "Variation 3 Info (New)");
            Text whiplashWindowName = getTextfromGameObject(getGameObjectChild(whiplashWindow, "Name"));
            whiplashWindowName.text = language.currentLanguage.shop.shop_armWhiplash;

            Text whiplashWindowDescription = getTextfromGameObject(getGameObjectChild(whiplashWindow, "Description"));
            whiplashWindowDescription.text = language.currentLanguage.shop.shop_armWhiplashDescription1 + "\n\n"
                + language.currentLanguage.shop.shop_armWhiplashDescription2;
            whiplashWindowDescription.fontSize = 16;

        }


        public Shop(ref GameObject level, JsonParser language)
        {

            this.patchShopFrontEnd(ref level,language);
            this.patchWeapons(ref level,language);

        }


    }
}
