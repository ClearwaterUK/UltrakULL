using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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

        public string getStyleBonusDictionary(string inputBonus)
        {
            string regexinput = Regex.Replace(inputBonus, @"<[^>]*>", "");
            
            switch(inputBonus)
            {
                case "ultrakill.airslam": { return "<color=cyan>ÉCRASEMENT DANS L'AIR</color>"; }
                case "ultrakill.airshot": { return "DANS L'AIR"; }
                case "ultrakill.attripator": { return "<color=cyan>ATTRACTEUR</color>"; }
                case "ultrakill.arsenal": { return "<color=cyan>ARSENAL</color>"; }
                case "ultrakill.bigheadshot": { return "GROS TUE EN PLEIN TÊTE"; }
                case "ultrakill.bigkill": { return "GRAND TUE"; }
                case "ultrakill.bigfistkill": { return "GRAND POIGNARD"; }
                case "ultrakill.bipolar": { return "BIPOLAIRE"; }
                case "ultrakill.cannonballed": { return "BOULE DE CANON"; }
                case "ultrakill.catapaulted": { return "<color=cyan>CATAPAULTÉ</color>"; }
                case "ultrakill.chargeback": { return "FACTURATION"; }
                case "ultrakill.compressed": { return "COMPRIMÉ"; }
                case "ultrakill.criticalpunch": { return "POIGNARD CRITIQUE"; }
                case "ultrakill.disrespect": { return "MÉPRISAGE"; }
                case "ultrakill.doublekill": { return "<color=orange>DOUBLE</color>"; }
                case "ultrakill.downtosize": { return "<color=cyan>GROS RENVOI</color>"; }
                case "ultrakill.enraged": { return "<color=red>ENRAGÉ</color>"; }
                case "ultrakill.exploded": { return "EXPLOSÉ"; }
                case "ultrakill.finishedoff": { return "<color=cyan>ACHÉVÉ</color>"; }
                case "ultrakill.fireworks": { return "<color=cyan>FEU D'ARTIFICES</color>"; }
                case "ultrakill.fistfullofdollar": { return "<color=cyan>POIGNÉE DE DOLLARS</color>"; }
                case "ultrakill.fried": { return "GRILLÉ"; }
                case "ultrakill.friendlyfire": { return "TIR AMICAL"; }
                case "ultrakill.groundslam": { return "ÉCRASEMENT"; }
                case "ultrakill.halfoff": { return "<color=cyan>EN MOITIÉ</color>"; }
                case "ultrakill.headshot": { return "EN PLEIN TÊTE"; }
                case "ultrakill.headshotcombo": { return "<color=cyan>EN PLEIN TÊTE</color>"; }
                case "ultrakill.homerun": { return "COUP DE CIRCUIT"; }
                case "ultrakill.instakill": { return "<color=lime>TUE INSTATANÉ</color>"; }
                case "ultrakill.interruption": { return "<color=lime>INTERROMPU</color>"; }
                case "ultrakill.kill": { return "TUÉ"; }
                case "ultrakill.limbshot": { return "EN MEMBRE"; }
                case "ultrakill.mauriced": { return "MAURICE"; }
                case "ultrakill.multikill": { return "<color=orange>MULTI</color>"; }
                case "ultrakill.nailbombed": { return "CLOUÉ"; }
                case "ultrakill.nailbombedalive": { return "<color=grey>CLOUÉ</color>"; }
                case "ultrakill.parry": { return "<color=lime>RENVOI</color>"; }
                case "ultrakill.projectileboost": { return "<color=lime>BOOST PROJECTILE</color>"; }
                case "ultrakill.quickdraw": { return "<color=cyan>AGILITÉ</color>"; }
                case "ultrakill.ricoshot": { return "<color=cyan>RICOCHET</color>"; }
                case "ultrakill.secret": { return "<color=cyan>SÉCRET</color>"; }
                case "ultrakill.splattered": { return "ÉCLABOUSSÉ"; }
                case "ultrakill.triplekill": { return "<color=orange>TRIPLE</color>"; }

                default: return "";

            }
        }

        public string getStyleBonus(bool isColor, string inputBonus)
        {

            string regexinput = Regex.Replace(inputBonus, @"<[^>]*>", "");

            //Try and keep this alphabetical as it gets bigger over time.
                switch (regexinput)
                {
                    case "CONDUCTOR": { return "CONDUCTEUR"; }
                    case "CRUSHED": { return "ÉCRASÉ"; }
                    case "FALL": { return "TOMBÉ"; }
                    case "FRIED": { return "GRILLÉ"; }
                    case "MINCED": { return "EMINCÉ"; }
                    case "OUT OF BOUNDS": { return "HORS LIMITES"; }
                    case "RICOSHOT": { return "RICOCHET"; }
                    case "SHREDDED": { return "RÂPÉ"; }
                    case "ZAPPED": { return "ZAPPÉ"; }
                    default: { Console.WriteLine("Missing style translation: " + regexinput); return regexinput; }
             }
        }

        public static string getTranslatedRankString(string inputString)
        {
            switch (inputString)
            {
                case "Destructive": { return "Destructif"; }
                case "Chaotic": { return "Chaotique"; }
                case "Brutal": { return "Brutale"; }
                case "Anarchic": { return "Anarchique"; }
                case "Supreme": { return "Suprême"; }
                case "SSadistic": { return "SSadistique"; }
                case "SSShitstorm": { return "SSSanglant"; }
                case "ULTRAKILL": { return "ULTRAKILL"; }
                default: { return "Unknown"; }
            }
        }

        public string getTranslatedStyleBonus(string inputBonus)
        {
            //Bonus string is split up into 3 parts: the opening color tag if there is one, the bonus name, and the closing color tag if there is one.

                    
            bool hasColorTag = (inputBonus.Contains("<color="));
            string openingColorTag;
            string closingColorTag = "</color>";
            string styleBonus = this.getStyleBonus(hasColorTag, inputBonus);

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
        
        public static string getWeaponFreshness(StyleFreshnessState weaponState)
        {
            switch(weaponState)
            {
                case StyleFreshnessState.Fresh: { return "FRAIS: 1.50X"; }
                case StyleFreshnessState.Used: { return "NEUF: 1.00X"; }
                case StyleFreshnessState.Stale: { return "ANCIEN: 0.50X"; }
                case StyleFreshnessState.Dull: { return "NUL: 0.00X"; }
                default: { return "Unknown state"; }
            }
        }

        public StyleBonusStrings()
        {

        }

    }
}
