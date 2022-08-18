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
            tipTitle.text = "CONSEIL DU JOUR";

            Text tipDescription = getTextfromGameObject(getGameObjectChild(tipPanel, "TipText"));
            Console.WriteLine("Original tip text: \n" + tipDescription.text);
            StringsParent levelTipStrings = new StringsParent();
            tipDescription.text = levelTipStrings.getLevelTip(language);


            //Weapons button
            GameObject mainButtons = getGameObjectChild(shopObject, "Main Menu");
            Console.WriteLine(mainButtons.name);

            Text weaponsButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "WeaponsButton"), "Text"));
            weaponsButtonTitle.text = "Armes";

            //Enemies button
            Text enemiesButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "EnemiesButton"), "Text"));
            enemiesButtonTitle.text = "Monstres";

            //CG buttons
            Text cgButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "CyberGrindButton"), "Text"));
            cgButtonTitle.text = "Le Cybergrind";

            Text cgReturnButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "ReturnButton"), "Text"));
            cgReturnButtonTitle.text = "Retourner au mission";

            //Sandbox button
            Text sandboxButtonTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(mainButtons, "SandboxButton"), "Text"));
            sandboxButtonTitle.text = "BAC À SABLE";

            //Enemies title
            Text enemiesTitle = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "Enemies"), "Panel"),"Title"));
            enemiesTitle.text = "ENNEMIES";

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

            cgEnterDescription.text = "<color=red> Le Cybergrind est un mode de survie sans fin</color>.\n\n"
                + "Une bonne performance donnera beaucoup de <color=red>points</color>.\n\n"
                + "<color=red>Tout progrès dans le mission actuel sera perdu</color>.";

            Text cgEnterButton = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cgEnter, "CyberGrindButton (1)"), "Text"));
            cgEnterButton.text = "ENTREZ LE CYBERGRIND";

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
            enemiesBackText.text = "RETOUR";

            //Sandbox back button
            Text sandboxBackText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "Sandbox"), "BackButton (2)"), "Text"));
            sandboxBackText.text = "RETOUR";

            //EnemyInfo back button
            Text enemyInfoBackText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(shopObject, "EnemyInfo"),"Button"),"Text"));
            enemyInfoBackText.text = "RETOUR";


        }


        public void patchWeapons(ref GameObject coreGame)
        {
            Console.WriteLine("In patchWeapons");
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
            weaponBackText.text = "RETOUR";

            Text weaponRevolverText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "RevolverButton"), "Text"));
            weaponRevolverText.text = "PISTOLE";

            Text weaponShotgunText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "ShotgunButton"), "Text"));
            weaponShotgunText.text = "FUSIL À POMPE";

            Text weaponNailgunText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "NailgunButton"), "Text"));
            weaponNailgunText.text = "CLOUEUR";

            //Slight problem - not all the text fits in the box.
            //The longer text is, the more we'll need to reduce the font size to compensate.
            Text weaponRailcannonText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "RailcannonButton"), "Text"));
            weaponRailcannonText.text = "CANON-ÈLECTRIQUE";
            weaponRailcannonText.fontSize = 16;

            Text rocketLauncherText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "RocketLauncherButton"), "Text"));
            rocketLauncherText.text = "LANCE-ROQUETTES";
            rocketLauncherText.fontSize = 16;

            Text weaponArmText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(shopWeaponsObject, "ArmButton"), "Text"));
            weaponArmText.text = "BRAS";

            //There are SO MANY inconsistencies with the following object names in the original game code. Hakita pls fix so both our lives are made easier thx

            //Revolver window and descriptions
            GameObject revolverWindow = getGameObjectChild(shopWeaponsObject, "RevolverWindow");
            Console.WriteLine("revolverWindow: " + revolverWindow);

            //Piercer
            GameObject piercer = getGameObjectChild(revolverWindow, "Variation Panel (Blue)");
            Text piercerName = getTextfromGameObject(getGameObjectChild(piercer, "Text"));
            piercerName.text = "PERCEUSE";

            GameObject piercerWindow = getGameObjectChild(revolverWindow, "Variation Info (Blue)");
            Text piercerWindowName = getTextfromGameObject(getGameObjectChild(piercerWindow, "Name"));
            piercerWindowName.text = piercerName.text;

            Text piercerWindowDescription = getTextfromGameObject(getGameObjectChild(piercerWindow, "Description"));
            piercerWindowDescription.text = "<color=orange>Maintenir</color> le Tir Alternatif pour charger un <color=orange>laser qui frappe 3 fois</color>."
                + "\n\nNécessite un <color=orange>temps de rechargement</color>.";

            //Marksman

            GameObject marksman = getGameObjectChild(revolverWindow, "Variation Panel (Green)");
            Text marksmanName = getTextfromGameObject(getGameObjectChild(marksman, "Text"));
            marksmanName.text = "TIREUR D'ÉLITE";
            marksmanName.fontSize = 14;

            GameObject marksmanWindow = getGameObjectChild(revolverWindow, "Variation Info (Green)");
            Text marksmanWindowName = getTextfromGameObject(getGameObjectChild(marksmanWindow, "Name"));
            marksmanWindowName.text = marksmanName.text;

            Text marksmanWindowDescription = getTextfromGameObject(getGameObjectChild(marksmanWindow, "Description"));
            marksmanWindowDescription.text = "Appuyer sur le tir alternatif pour <color=orange>lancer une pièce</color>.\n\n"
            + "Frappez-le <color=orange>dans l'air</color> pour <color=orange>déflecter</color> votre tir dans le <color=orange>point faible</color> de l'ennemi le plus proche.\n\n"
            + "Les pièces peuvent être enchaînées.";
            marksmanWindowDescription.fontSize = 14;

            //Shotgun window and descriptions
            GameObject shotgunWindow = getGameObjectChild(shopWeaponsObject, "ShotgunWindow");

            GameObject coreEject = getGameObjectChild(shotgunWindow, "Variation Panel (Blue)");
            Text coreEjectName = getTextfromGameObject(getGameObjectChild(coreEject, "Text"));
            coreEjectName.text = "ÉJECTION";

            GameObject coreEjectWindow = getGameObjectChild(shotgunWindow, "Variation Info (Blue)");
            Text coreEjectWindowName = getTextfromGameObject(getGameObjectChild(coreEjectWindow, "Name"));
            coreEjectWindowName.text = coreEjectName.text;

            Text coreEjectWindowDescription = getTextfromGameObject(getGameObjectChild(coreEjectWindow, "Description"));
            coreEjectWindowDescription.text = "Appuyer sur le tir alternatif pour surchauffer et <color=orange>lancer</color> les <color=orange>noyeaux</color> du fusil.\n\n" + "<color=orange>Maintenir</color> pour augmenter la <color=orange>distance</color>.\n\n"
                + "<color=orange>Explosion sur impact.</color>";

            GameObject pumpCharge = getGameObjectChild(shotgunWindow, "Variation Panel (Green)");
            Text pumpChargeName = getTextfromGameObject(getGameObjectChild(pumpCharge, "Text"));
            pumpChargeName.text = "SURCHARGEMENT";
            pumpChargeName.fontSize = 16;

            GameObject pumpChargeWindow = getGameObjectChild(shotgunWindow, "Variation Info (Green)");
            Text pumpChargeWindowName = getTextfromGameObject(getGameObjectChild(pumpChargeWindow, "Name"));
            pumpChargeWindowName.text = pumpChargeName.text;

            Text pumpChargeWindowDescription = getTextfromGameObject(getGameObjectChild(pumpChargeWindow, "Description"));
            pumpChargeWindowDescription.text = "Appuyer sur le tir alternatif pour <color=orange>pomper</color> votre fusil, augmentant la <color=orange>puissance</color> et <color=orange>diminuant</color> la précision de votre <color=orange>prochain tir</color>.\n\n"
                + "Trop de pompes résultera dans une <color=orange>explosion</color> lorsque l'arme est tirée.";
            pumpChargeWindowDescription.fontSize = 14;

            //Nailgun window and descriptions
            GameObject nailgunWindow = getGameObjectChild(shopWeaponsObject, "NailgunWindow");

            GameObject attractor = getGameObjectChild(nailgunWindow, "Variation Panel (Blue)");
            Text attractorName = getTextfromGameObject(getGameObjectChild(attractor, "Text"));
            attractorName.text = "AIMANT";

            GameObject attractorWindow = getGameObjectChild(nailgunWindow, "Variation Info (Blue)");
            Text attractorWindowName = getTextfromGameObject(getGameObjectChild(attractorWindow, "Name"));
            attractorWindowName.text = attractorName.text;

            Text attractorWindowDescription = getTextfromGameObject(getGameObjectChild(attractorWindow, "Description"));
            attractorWindowDescription.text = "Le tir alternatif lance un <color=orange>aimant</color> qui attire les <color=orange>clous</color> à proximité.\n\n"
                + "Les aimants se collent aux <color=orange>surfaces et aux ennemies</color>, et peuvent être cassés avec des armes '<color=orange>hitscan</color>'.";
            attractorWindowDescription.fontSize = 16;


            GameObject overheat = getGameObjectChild(nailgunWindow, "Variation Panel (Green)");
            Text overheatName = getTextfromGameObject(getGameObjectChild(overheat, "Text"));
            overheatName.text = "SURCHAUFFEMENT";
            overheatName.fontSize = 16;

            GameObject overheatWindow = getGameObjectChild(nailgunWindow, "Variation Info (Green)");
            Text overheatWindowName = getTextfromGameObject(getGameObjectChild(overheatWindow, "Name"));
            overheatWindowName.text = overheatName.text;

            Text overheatWindowDescription = getTextfromGameObject(getGameObjectChild(overheatWindow, "Description"));
            overheatWindowDescription.text = "Appuyer sur le tir alternatif <color=orange>pendant le tir</color> pour une coup vite de dêgàts en utilisant un <color=orange>dissipateur thermique</color>.\n\n"
                + "Les dissipateurs se rechargent lorsque vous ne tirez pas.";
            overheatWindowDescription.fontSize = 14;

            //Railcannon window and descriptions
            GameObject railcannonWindow = getGameObjectChild(shopWeaponsObject, "RailcannonWindow");

            GameObject electric = getGameObjectChild(railcannonWindow, "Variation Panel (Blue)");
            Text electricName = getTextfromGameObject(getGameObjectChild(electric, "Text"));
            electricName.text = "ÉLECTRIQUE";

            GameObject electricWindow = getGameObjectChild(railcannonWindow, "Variation Info (Blue)");
            Text electricWindowName = getTextfromGameObject(getGameObjectChild(electricWindow, "Name"));
            electricWindowName.text = electricName.text;

            Text electricWindowDescription = getTextfromGameObject(getGameObjectChild(electricWindow, "Description"));
            electricWindowDescription.text = "Un tir puissant et pénétrant.\n\n"
                + "<color=orange>Pénétre</color> à travers <color=orange>tout</color> les ennemies. Soyez attentif à votre <color=orange>positionnement</color> pour maximiser la destruction.\n\n"
                + "Ne pas utiliser dans l'eau.";
            electricWindowDescription.fontSize = 16;


            GameObject screwdriver = getGameObjectChild(railcannonWindow, "Variation Panel (Green)");
            Text screwdriverName = getTextfromGameObject(getGameObjectChild(screwdriver, "Text"));
            screwdriverName.text = "TOURNEVIS";

            GameObject screwdriverWindow = getGameObjectChild(railcannonWindow, "Variation Info (Green)");
            Text screwdriverWindowName = getTextfromGameObject(getGameObjectChild(screwdriverWindow, "Name"));
            screwdriverWindowName.text = screwdriverName.text;

            Text screwdriverWindowDescription = getTextfromGameObject(getGameObjectChild(screwdriverWindow, "Description"));
            screwdriverWindowDescription.text = "Tirez une perceuse puissante qui <color=orange>se colle</color> à un ennemi et qui inflige des dégâts <color=orange>au fil de temps</color>.\n\n" +
                "La perceuse fait saigner les ennemies avec <color=orange>une distance de soignage augmenté</color>.";
            screwdriverWindowDescription.fontSize = 16;

            GameObject malicious = getGameObjectChild(railcannonWindow, "Variation Panel (Red)");
            Text maliciousName = getTextfromGameObject(getGameObjectChild(malicious, "Text"));
            maliciousName.text = "MALICIEUX";

            GameObject maliciousWindow = getGameObjectChild(railcannonWindow, "Variation Info (Red)");
            Text maliciousWindowName = getTextfromGameObject(getGameObjectChild(maliciousWindow, "Name"));
            maliciousWindowName.text = maliciousName.text;

            Text maliciousWindowDescription = getTextfromGameObject(getGameObjectChild(maliciousWindow, "Description"));
            maliciousWindowDescription.text = "Tirez un laser instatané qui entraîne une <color=orange>explosion large</color> sur l'impact, un peu comme un certain tête familiaire.\n\n"
                + "Efface des groupes d'enemmies faibles avec facilité.";
            maliciousWindowDescription.fontSize = 16;

            //Arm window and descriptions
            GameObject armWindow = getGameObjectChild(shopWeaponsObject, "ArmWindow");

            GameObject feedbacker = getGameObjectChild(armWindow, "Variation Panel 1 (New)");
            Text feedbackerName = getTextfromGameObject(getGameObjectChild(feedbacker, "Text"));
            feedbackerName.text = "RENVOYEUR";

            GameObject feedbackerWindow = getGameObjectChild(armWindow, "Variation 1 Info (New)");
            Text feedbackerWindowName = getTextfromGameObject(getGameObjectChild(feedbackerWindow, "Name"));
            feedbackerWindowName.text = feedbackerName.text;

            Text feedbackerWindowDescription = getTextfromGameObject(getGameObjectChild(feedbackerWindow, "Description"));
            feedbackerWindowDescription.text = "Coup de poing rapide avec des dêgàts moyens.\n\n"
                + "Peut <color=orange>renvoyer</color> les projectiles, <color=orange>tirs de fusil à pompe</color> et les <color=orange>pièces</color>.";

            GameObject knuckleblaster = getGameObjectChild(armWindow, "Variation Panel 2 (New)");
            Text knuckleblasterName = getTextfromGameObject(getGameObjectChild(knuckleblaster, "Text"));
            knuckleblasterName.text = "BOMBARDIER";

            GameObject knuckleblasterWindow = getGameObjectChild(armWindow, "Variation 2 Info (New)");
            Text knuckleblasterWindowName = getTextfromGameObject(getGameObjectChild(knuckleblasterWindow, "Name"));
            knuckleblasterWindowName.text = knuckleblasterName.text;

            Text knuckleblasterWindowDescription = getTextfromGameObject(getGameObjectChild(knuckleblasterWindow, "Description"));
            knuckleblasterWindowDescription.text = "Coup de poing lourd avec des dégâts élevés.\n\n"
                + "<color=orange>Maintenir</color> pour tirer les cartouches dans le bras, résultant dans un <color=orange>choc</color> qui repousse les ennemies.";

            GameObject whiplash = getGameObjectChild(armWindow, "Variation Panel 3 (New)");
            Text whiplashName = getTextfromGameObject(getGameObjectChild(whiplash, "Text"));
            whiplashName.text = "FOUET";

            //here
            GameObject whiplashWindow = getGameObjectChild(armWindow, "Variation 3 Info (New)");
            Text whiplashWindowName = getTextfromGameObject(getGameObjectChild(whiplashWindow, "Name"));
            whiplashWindowName.text = whiplashName.text;

            Text whiplashWindowDescription = getTextfromGameObject(getGameObjectChild(whiplashWindow, "Description"));
            whiplashWindowDescription.text = "Un winch avec une lance. <color=orange>Maintenir</color> pour lancer, <color=orange>lâcher</color> pour tirer.\n\n"
                + "Peut attirer les ennemis et objets lègers. Vous vous serez attiré aux ennemis lourds et points d'ancrage.";
            whiplashWindowDescription.fontSize = 16;

        }


        public Shop(ref GameObject level, JsonParser language)
        {

            this.patchShopFrontEnd(ref level,language);
            this.patchWeapons(ref level);

        }


    }
}
