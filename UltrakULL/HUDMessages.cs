using System;
using TMPro;
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
            //Cross-compatibility with V-Ranks, pretty sure every HUD message has at least one time "V-Rank" in them
            if (message.Contains("V-Rank"))
            {
                return message;
            }

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
            if (message.Contains("Altered"))
            {
                return "<color=red>" + LanguageManager.CurrentLanguage.misc.enemyAlter_alteredDestroyed + "</color>";
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
            
            //chessTip
            if(GetCurrentSceneName() == "CreditsMuseum2")
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
            TextMeshProUGUI styleMeterMultiplierText = GetTextMeshProUGUI(styleMeter);
            styleMeterMultiplierText.text = LanguageManager.CurrentLanguage.style.stylemeter_multiplier;
            
            //Classic HUD
            GameObject classicHudBw = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "Crosshair Filler"), "AltHud"), "Filler");
            GameObject classicHudColor = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "Crosshair Filler"), "AltHud (2)"), "Filler");
            
            TextMeshProUGUI classicHudBwHealth = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Health"), "Title"));
            TextMeshProUGUI classicHudColorHealth = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Health (1)"), "Title"));
            classicHudBwHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudColorHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;

            TextMeshProUGUI classicHudBwStamina = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Stamina"), "Title"));
            TextMeshProUGUI classicHudColorStamina = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Stamina (1)"), "Title"));
            classicHudBwStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudColorStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            
            TextMeshProUGUI classicHudBwWeapon = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Weapon"), "Title"));
            TextMeshProUGUI classicHudColorWeapon = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Weapon (1)"), "Title"));
            classicHudBwWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudColorWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;

            TextMeshProUGUI classicHudBwArm = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(classicHudBw, "Arm"), "Title"));
            TextMeshProUGUI classicHudColorArm = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(classicHudColor, "Arm (1)"), "Title"));
            classicHudBwArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudColorArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;

            TextMeshProUGUI classicHudBwRailcannon = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(classicHudBw, "RailcannonMeter (1)"), "Title"));
            TextMeshProUGUI classicHudColorRailcannon = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(classicHudColor, "RailcannonMeter (2)"), "Title"));
            classicHudBwRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudColorRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;

            //Close prompt when reading book
            TextBinds bookPanelBinds = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj, "ScanningStuff"), "ReadingScanned"), "Panel"), "Text (1)").GetComponent<TextBinds>();
            bookPanelBinds.text1 = LanguageManager.CurrentLanguage.books.books_pressToClose1 + " <color=orange>";
            bookPanelBinds.text2 = "</color> " + LanguageManager.CurrentLanguage.books.books_pressToClose2;

        }
    }
}
