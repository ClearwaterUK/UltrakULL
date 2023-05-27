using UltrakULL.json;
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
    }
}
