using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using UltrakULL.json;

namespace UltrakULL
{
    class StyleBonusStrings
    {
        public string getBonusColor(string inputBonus)
        {
            if (inputBonus.Contains("blue")) { return "<color=blue>"; }
            if (inputBonus.Contains("green")) { return "<color=green>"; }
            if (inputBonus.Contains("yellow")) { return "<color=yellow>"; }
            if (inputBonus.Contains("red")) { return "<color=red>"; }
            if (inputBonus.Contains("orange")) { return "<color=orange>"; }
            if (inputBonus.Contains("cyan")) { return "<color=cyan>"; }
            if (inputBonus.Contains("lime")) { return "<color=lime>"; }
            if (inputBonus.Contains("grey")) { return "<color=grey>"; }
            return ("");
        }

        public string getStyleBonusDictionary(string inputBonus,JsonParser language)
        {

            string regexinput = Regex.Replace(inputBonus, @"<[^>]*>", "");
            
            switch(inputBonus)
            {
                case "ultrakill.airslam": { return "<color=cyan>" + language.currentLanguage.style.style_airslam + "</color>"; }
                case "ultrakill.airshot": { return language.currentLanguage.style.style_airshot; }
                case "ultrakill.attripator": { return "<color=cyan>" + language.currentLanguage.style.style_attraptor + "</color>"; }
                case "ultrakill.arsenal": { return "<color=cyan>" + language.currentLanguage.style.style_arsenal + "</color>"; }
                case "ultrakill.bigheadshot": { return language.currentLanguage.style.style_bigheadshot; }
                case "ultrakill.bigkill": { return language.currentLanguage.style.style_bigkill; }
                case "ultrakill.bigfistkill": { return language.currentLanguage.style.style_bigfistkill; }
                case "ultrakill.bipolar": { return language.currentLanguage.style.style_bipolar; }
                case "ultrakill.cannonballed": { return language.currentLanguage.style.style_cannonballed; }
                case "ultrakill.catapaulted": { return "<color=cyan>" + language.currentLanguage.style.style_catapaulted + "</color>"; }
                case "ultrakill.chargeback": { return language.currentLanguage.style.style_chargeback; }
                case "ultrakill.compressed": { return language.currentLanguage.style.style_compressed; }
                case "ultrakill.criticalpunch": { return language.currentLanguage.style.style_criticalpunch; }
                case "ultrakill.disrespect": { return language.currentLanguage.style.style_disrespect; }
                case "ultrakill.doublekill": { return "<color=orange>" + language.currentLanguage.style.style_doublekill + "</color>"; }
                case "ultrakill.downtosize": { return "<color=cyan>" + language.currentLanguage.style.style_downtosize + "</color>"; }
                case "ultrakill.enraged": { return "<color=red>" + language.currentLanguage.style.style_enraged + "</color>"; }
                case "ultrakill.exploded": { return language.currentLanguage.style.style_exploded; }
                case "ultrakill.finishedoff": { return "<color=cyan>" + language.currentLanguage.style.style_finishedoff + "</color>"; }
                case "ultrakill.fireworks": { return "<color=cyan>" + language.currentLanguage.style.style_fireworks + "</color>"; }
                case "ultrakill.fistfullofdollar": { return "<color=cyan>" + language.currentLanguage.style.style_fistfulofdollar + "</color>"; }
                case "ultrakill.fried": { return language.currentLanguage.style.style_fried; }
                case "ultrakill.friendlyfire": { return language.currentLanguage.style.style_friendlyfire; }
                case "ultrakill.groundslam": { return language.currentLanguage.style.style_groundslam; }
                case "ultrakill.halfoff": { return "<color=cyan>" + language.currentLanguage.style.style_halfoff + "</color>"; }
                case "ultrakill.headshot": { return language.currentLanguage.style.style_headshot; }
                case "ultrakill.headshotcombo": { return "<color=cyan>" + language.currentLanguage.style.style_headshot + "</color>"; }
                case "ultrakill.homerun": { return language.currentLanguage.style.style_homerun; }
                case "ultrakill.instakill": { return "<color=lime>" + language.currentLanguage.style.style_instakill + "</color>"; }
                case "ultrakill.interruption": { return "<color=lime>" + language.currentLanguage.style.style_interruption + "</color>"; }
                case "ultrakill.kill": { return language.currentLanguage.style.style_kill; }
                case "ultrakill.limbshot": { return language.currentLanguage.style.style_limbshot; }
                case "ultrakill.mauriced": { return language.currentLanguage.style.style_mauriced; }
                case "ultrakill.multikill": { return "<color=orange>" + language.currentLanguage.style.style_multikill + "</color>"; }
                case "ultrakill.nailbombed": { return language.currentLanguage.style.style_nailbombed; }
                case "ultrakill.nailbombedalive": { return "<color=grey>" + language.currentLanguage.style.style_nailbombed + "</color>"; }
                case "ultrakill.parry": { return "<color=lime>" + language.currentLanguage.style.style_parry + "</color>"; }
                case "ultrakill.projectileboost": { return "<color=lime>" + language.currentLanguage.style.style_projectileboost + "</color>"; }
                case "ultrakill.quickdraw": { return "<color=cyan>" + language.currentLanguage.style.style_quickdraw + "</color>"; }
                case "ultrakill.ricoshot": { return "<color=cyan>" + language.currentLanguage.style.style_ricoshot + "</color>"; }
                case "ultrakill.secret": { return "<color=cyan>" + language.currentLanguage.style.style_secret + "</color>"; }
                case "ultrakill.splattered": { return language.currentLanguage.style.style_splattered; }
                case "ultrakill.triplekill": { return "<color=orange>" + language.currentLanguage.style.style_triplekill + "</color>"; }

                default: return "";

            }
        }

        public string getStyleBonus(bool isColor, string inputBonus,JsonParser language)
        {

            string regexinput = Regex.Replace(inputBonus, @"<[^>]*>", "");

            //Try and keep this alphabetical as it gets bigger over time.
                switch (regexinput)
                {
                    case "CONDUCTOR": { return language.currentLanguage.style.style_conductor; }
                    case "CRUSHED": { return language.currentLanguage.style.style_crushed; }
                    case "FALL": { return language.currentLanguage.style.style_fall; }
                    case "FRIED": { return language.currentLanguage.style.style_fried; }
                    case "MINCED": { return language.currentLanguage.style.style_minced; }
                    case "OUT OF BOUNDS": { return language.currentLanguage.style.style_outofbounds; }
                    case "RICOSHOT": { return language.currentLanguage.style.style_ricoshot; }
                    case "SHREDDED": { return language.currentLanguage.style.style_shredded; }
                    case "ZAPPED": { return language.currentLanguage.style.style_zapped; }
                    case "why are you even spawning enemies here": { return language.currentLanguage.style.style_why; }
                    case "": { return ""; }
                    default: { Console.WriteLine("Missing style translation: " + regexinput); return regexinput; }
             }
        }

        public static string getTranslatedRankString(string inputString,JsonParser language)
        {
            switch (inputString)
            {
                case "Destructive": { return language.currentLanguage.style.style_d; }
                case "Chaotic": { return language.currentLanguage.style.style_c; }
                case "Brutal": { return language.currentLanguage.style.style_b; }
                case "Anarchic": { return language.currentLanguage.style.style_a; }
                case "Supreme": { return language.currentLanguage.style.style_s; }
                case "SSadistic": { return language.currentLanguage.style.style_ss; }
                case "SSShitstorm": { return language.currentLanguage.style.style_sss; }
                case "ULTRAKILL": { return language.currentLanguage.style.style_ultrakill; }
                default: { return "Unknown"; }
            }
        }

        public string getTranslatedStyleBonus(string inputBonus,JsonParser language)
        {
            //Bonus string is split up into 3 parts: the opening color tag if there is one, the bonus name, and the closing color tag if there is one.

                    
            bool hasColorTag = (inputBonus.Contains("<color="));
            string openingColorTag;
            string closingColorTag = "</color>";
            string styleBonus = this.getStyleBonus(hasColorTag, inputBonus,language);

            if (hasColorTag)
            {
                openingColorTag = this.getBonusColor(inputBonus);
                return (openingColorTag + styleBonus + closingColorTag);
            }
            else
            {
                return(styleBonus);
            }
            
        }
        
        public static string getWeaponFreshness(StyleFreshnessState weaponState,JsonParser language)
        {
            switch(weaponState)
            {
                case StyleFreshnessState.Fresh: { return language.currentLanguage.style.style_weaponFresh + ": 1.50X"; }
                case StyleFreshnessState.Used: { return language.currentLanguage.style.style_weaponUsed + ": 1.00X"; }
                case StyleFreshnessState.Stale: { return language.currentLanguage.style.style_weaponStale + ": 0.50X"; }
                case StyleFreshnessState.Dull: { return language.currentLanguage.style.style_weaponDull + ": 0.00X"; }
                default: { return "Unknown state"; }
            }
        }

        public StyleBonusStrings()
        {

        }

    }
}
