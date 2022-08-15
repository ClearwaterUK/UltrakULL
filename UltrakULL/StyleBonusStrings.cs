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

        public string getStyleBonus(bool isColor, string inputBonus)
        {

            string regexinput = Regex.Replace(inputBonus, @"<[^>]*>", "");


            if (regexinput.Contains("MULTIKILL"))
            { string multiKills = regexinput.Substring(10); Console.WriteLine(multiKills); return "MULTI" + multiKills; }

            else if (regexinput.Contains("HEADSHOT COMBO"))
            { string multiKills = regexinput.Substring(15); Console.WriteLine(multiKills); return "EN PLEINE TÊTE " + multiKills; }

            else
            { 

            //Try and keep this alphabetical as it gets bigger over time.
                switch (regexinput)
                {
					case "AIRSHOT": { return "DANS L'AIR"; }
                    case "AIR SLAM": { return "ÉCRASEMENT DANS L'AIR"; }
                    case "ATTRAPTOR": { return "ATTRACTEUR"; }
					case "ARSENAL": { return "ARSENAL"; }
					case "BIG HEADSHOT": { return "GRAND TUE EN PLEINE TÊTE"; }
                    case "BIG FISTKILL": { return "GROS POIGNARDAGE"; }
                    case "BIG KILL": { return "GRAND TUE"; }
                    case "BIPOLAR": { return "BIPOLAIRE"; }
                    case "CATAPAULTED": { return "BOULE DE CANON"; }
                    case "CANNONBALLED": { return "BOULE DE CANON"; }
                    case "CHARGEBACK": { return "FACTURATION"; }
                    case "COMPRESSED": { return "COMPRIMÉ"; }
                    case "CONDUCTOR": { return "CONDUCTEUR"; }
                    case "CRITICAL PUNCH": { return "POIGNARD CRITIQUE"; }
                    case "CRUSHED": { return "ÉCRASÉ"; }
                    case "DISRESPECT": { return "MÉPRISAGE"; }
                    case "DOUBLE KILL": { return "DOUBLE"; }
                    case "ENRAGED": { return "ENRAGÉ"; }
                    case "EXPLODED": { return "EXPLOSÉ"; }
                    case "FALL": { return "TOMBÉ"; }
                    case "FINISHED OFF": { return "ACHEVÉ"; }
                    case "FIREWORKS": { return "FEU D'ARTIFICES"; };
                    case "FISTFUL OF DOLLAR": { return "POIGNÉE DE DOLLARS"; }
                    case "FISTIKILL": { return "POIGNARDAGE"; }
                    case "FRIED": { return "GRILLÉ"; }
                    case "FRIENDLY FIRE": { return "TIR AMICALE"; }
                    case "GROUND SLAM": { return "ÉCRASEMENT"; }
                    case "HALF OFF": { return "EN MOITIÉ"; }
                    case "HEADSHOT": { return "EN PLEINE TÊTE"; }
                    case "HOMERUN": { return "COUP DE CIRCUIT"; }
                    case "INSTAKILL": { return "TUE INSTATANÉ"; }
                    case "INTERRUPTION": { return "INTERRUPTION"; }
                    case "KILL": { return "TUÉ"; }
                    case "LIMB HIT": { return "EN MEMBRE"; }
                    case "MAURICED": { return "MAURICED"; } //What do I even put here lmao
                    case "MINCED": { return "EMINCÉ"; }
                    case "NAILBOMBED": { return "CLOUÉ"; }
                    case "OUT OF BOUNDS": { return "HORS LIMITES"; }
                    case "OVERKILL": { return "SURPUISSANCE"; }
                    case "PARRY": { return "RENVOI"; }
                    case "PROJECTILE BOOST": { return "BOOST PROJECTILE"; }
                    case "QUICKDRAW": { return "AGILITÉ"; }
                    case "RICOSHOT": { return "RICOCHET"; }
                    case "SHREDDED": { return "RÂPÉ"; }
                    case "SPLATTERED": { return "ÉCLABOUSSÉ"; }
                    case "TRIPLE KILL": { return "TRIPLE"; }
                    case "ZAPPED": { return "ZAPPÉ"; }
                    default: { Console.WriteLine("Missing style translation: " + regexinput); return regexinput; }
                }
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

        public StyleBonusStrings()
        {

        }

    }
}
