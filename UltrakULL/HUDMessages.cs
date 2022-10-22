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
        public static string getHUDToolTip(string message, JsonParser language)
        {
            Console.WriteLine(message);

            
            if (message.Contains("PUNCH"))
            {
                return "<color=red>" + language.currentLanguage.misc.hud_noArm1 + "</color>\n"
                    + language.currentLanguage.misc.hud_noArm2;
            }
            if (message.Contains("MAJOR"))
            {
                return "<color=#4C99E6>" + language.currentLanguage.misc.hud_majorAssists + "</color>";
            }
            if (message.Contains("200"))
            {
                return language.currentLanguage.misc.hud_overhealOrb1 + "\n"
                    + language.currentLanguage.misc.hud_overhealOrb2;
            }
            if (message.Contains("ERROR"))
            {
                return "<color=red>" + language.currentLanguage.misc.hud_itemGrabError + "</color>";
            }
            if (message.Contains("TAB"))
            {
                return language.currentLanguage.misc.hud_levelStats1 + "\n"
                    + language.currentLanguage.misc.hud_levelStats2;
            }
            if (message.Contains("Whoops"))
            {
                return language.currentLanguage.misc.hud_outOfBounds;
            }
            if(message.Contains("CLASH"))
            {
                return language.currentLanguage.misc.hud_clashMode;
            }
            if (message.Contains("EQUIPPED"))
            {
                return language.currentLanguage.misc.hud_weaponVariation;
            }

            //Cybergrind custom pattern fix
            if(SceneManager.GetActiveScene().name == "Endless")
            {
                return message;
            }

            Console.WriteLine(message);
            return ("Unimplemented HUD string, check the console");
        }
    }
}
