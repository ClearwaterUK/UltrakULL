using System;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
                                                                                 
namespace UltrakULL
{
    public static class HUDMessages
    {
        public static string GetHUDToolTip(string message)
        {
            if (message.Contains("PUNCH"))
            {
                return "<color=red>" + LanguageManager.CurrentLanguage.misc.hud_noArm1 + "</color>\n"
                    + LanguageManager.CurrentLanguage.misc.hud_noArm2;
            }
            if (message.Contains("MAJOR"))
            {
                return "<color=#4C99E6>" + LanguageManager.CurrentLanguage.misc.hud_majorAssists + "</color>";
            }
            if (message.Contains("200"))
            {
                return LanguageManager.CurrentLanguage.misc.hud_overhealOrb1 + "\n"
                    + LanguageManager.CurrentLanguage.misc.hud_overhealOrb2;
            }
            if (message.Contains("ERROR"))
            {
                return "<color=red>" + LanguageManager.CurrentLanguage.misc.hud_itemGrabError + "</color>";
            }
            if (message.Contains("TAB"))
            {
                return LanguageManager.CurrentLanguage.misc.hud_levelStats1 + "\n"
                    + LanguageManager.CurrentLanguage.misc.hud_levelStats2;
            }
            if (message.Contains("Whoops"))
            {
                return LanguageManager.CurrentLanguage.misc.hud_outOfBounds;
            }
            if(message.Contains("CLASH"))
            {
                return LanguageManager.CurrentLanguage.misc.hud_clashMode;
            }
            if (message.Contains("EQUIPPED"))
            {
                return LanguageManager.CurrentLanguage.misc.hud_weaponVariation;
            }
            if (message.Contains("=>")) //4-S transaction complete
            {
                return message; //4-S transaction complete
            }
            //For some reason 5-S passes through this function instead of passing through HudMessage. So we'll do this
            if(GetCurrentSceneName() == "Level 5-S")
            {
                return StringsParent.GetMessage(message, "", "");
            }
            

            //Cybergrind custom pattern fix
            if (GetCurrentSceneName() == "Endless")
            {
                if(message.Contains("NO PATTERNS"))
                {
                    return LanguageManager.CurrentLanguage.cyberGrind.cybergrind_noPatternsSelected;
                }
                return message;
            }

            Logging.Warn("Couldn't find string for message: " + message);
            return message;
        }
        public static void PatchDeathScreen(ref GameObject canvasObj)
        {
            try
            {
                GameObject deathScreen = GetGameObjectChild(GetGameObjectChild(canvasObj, "BlackScreen"), "YouDiedText");
                //Need to disable the TextOverride component.
                Component[] test = deathScreen.GetComponents(typeof(Component));
                Behaviour bhvr = (Behaviour)test[3];
                bhvr.enabled = false;

                Text youDiedText = GetTextfromGameObject(deathScreen);
                youDiedText.text = LanguageManager.CurrentLanguage.misc.youDied1 + "\n\n\n\n\n" + LanguageManager.CurrentLanguage.misc.youDied2;
            }
            catch (Exception e)
            {
                Logging.Error("Failed to patch death screen");
                Logging.Error(e.ToString());
            }
        }
        
        

        public static void PatchMisc(ref GameObject canvasObj)
        {
            GameObject player = GameObject.Find("Player");
            GameObject styleMeter = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(player, "Main Camera"), "HUD Camera"), "HUD"), "StyleCanvas"), "Panel (1)"), "Panel"), "Text (1)"), "Text");
            Text styleMeterMultiplierText = GetTextfromGameObject(styleMeter);
            styleMeterMultiplierText.text = LanguageManager.CurrentLanguage.style.stylemeter_multiplier;
            
            GameObject pressToSkip = GetGameObjectChild(canvasObj, "CutsceneSkipText");

            //Need to disable the TextOverride component.
            Component[] test = pressToSkip.GetComponents(typeof(Component));
            Behaviour bhvr = (Behaviour)test[4];
            bhvr.enabled = false;

            Text pressToSkipText = GetTextfromGameObject(pressToSkip);
            pressToSkipText.text = LanguageManager.CurrentLanguage.misc.pressToSkip;

            //Classic HUD
            GameObject classicHudBw = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "Crosshair Filler"), "AltHud"), "Filler");
            GameObject classicHudColor = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "Crosshair Filler"), "AltHud (2)"), "Filler");

            Text classicHudBwHealth = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Health"), "Title"));
            Text classicHudBwHealthShow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Health"), "Title (1)"));
            Text classicHudColorHealth = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Health"), "Title"));
            Text classicHudColorHealthShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Health"), "Title (1)"));
            classicHudBwHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudColorHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudBwHealthShow.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudColorHealthShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_health;

            Text classicHudBwStamina = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Stamina"), "Title"));
            Text classicHudColorStamina = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Stamina"), "Title"));
            Text classicHudBwStaminaShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Stamina"), "Title (1)"));
            Text classicHudColorStaminaShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Stamina"), "Title (1)"));
            classicHudBwStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudColorStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudBwStaminaShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudColorStaminaShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;

            Text classicHudBwWeapon = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Weapon"), "Title"));
            Text classicHudColorWeapon = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Weapon"), "Title"));
            Text classicHudBwWeaponShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Weapon"), "Title (1)"));
            Text classicHudColorWeaponShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Weapon"), "Title (1)"));
            classicHudBwWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudColorWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudBwWeaponShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudColorWeaponShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;

            Text classicHudBwArm = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Arm"), "Title"));
            Text classicHudColorArm = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Arm"), "Title"));
            Text classicHudBwArmShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Arm"), "Title (1)"));
            Text classicHudColorArmShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Arm"), "Title (1)"));
            classicHudBwArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudColorArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudBwArmShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudColorArmShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;

            Text classicHudBwRailcannon = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "RailcannonMeter (1)"), "Title"));
            Text classicHudColorRailcannon = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "RailcannonMeter"), "Title"));
            Text classicHudBwRailcannonShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudBw, "RailcannonMeter (1)"), "Title (1)"));
            Text classicHudColorRailcannonShadow = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(classicHudColor, "RailcannonMeter"), "Title (1)"));
            classicHudBwRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudColorRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudBwRailcannonShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudColorRailcannonShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;

            //Close prompt when reading book
            TextBinds bookPanelBinds = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "ScanningStuff"), "ReadingScanned"), "Panel"), "Text (1)").GetComponent<TextBinds>();
            bookPanelBinds.text1 = LanguageManager.CurrentLanguage.books.books_pressToClose1 + " <color=orange>";
            bookPanelBinds.text2 = "</color> " + LanguageManager.CurrentLanguage.books.books_pressToClose2;
        }
    }
}
