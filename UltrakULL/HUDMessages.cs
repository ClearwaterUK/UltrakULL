using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UltrakULL
{
    public static class HUDMessages
    {
        public static string getHUDToolTip(string message)
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
            if (message.Contains("=>"))
            {
                return message; //4-S transaction complete
            }

            //Cybergrind custom pattern fix
            if (SceneManager.GetActiveScene().name == "Endless")
            {
                return message;
            }

            Console.WriteLine(message);
            return ("Unimplemented HUD string, check the console");
        }
    }
}
