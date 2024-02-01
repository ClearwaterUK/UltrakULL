using System.Text.RegularExpressions;

using UltrakULL.json;

namespace UltrakULL
{
    public static class StyleBonusStrings
    {
        private static string GetBonusColor(string inputBonus)
        {
            if (inputBonus.Contains("blue")) { return "<color=#00ffff>"; }
            if (inputBonus.Contains("cyan")) { return "<color=#00ffff>"; }
            if (inputBonus.Contains("green")) { return "<color=green>"; }
            if (inputBonus.Contains("lime")) { return "<color=green>"; }
            if (inputBonus.Contains("yellow")) { return "<color=yellow>"; }
            if (inputBonus.Contains("red")) { return "<color=red>"; }
            if (inputBonus.Contains("orange")) { return "<color=orange>"; }
            if (inputBonus.Contains("grey")) { return "<color=grey>"; }
            return ("");
        }

        public static string GetStyleBonusDictionary(string inputBonus)
        {
            switch(inputBonus)
            {
                case "ultrakill.airslam": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_airslam + "</color>"; }
                case "ultrakill.airshot": { return LanguageManager.CurrentLanguage.style.style_airshot; }
                case "ultrakill.attripator": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_attraptor + "</color>"; }
                case "ultrakill.arsenal": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_arsenal + "</color>"; }
                case "ultrakill.bigheadshot": { return LanguageManager.CurrentLanguage.style.style_bigheadshot; }
                case "ultrakill.bigkill": { return LanguageManager.CurrentLanguage.style.style_bigkill; }
                case "ultrakill.bigfistkill": { return LanguageManager.CurrentLanguage.style.style_bigfistkill; }
                case "ultrakill.bipolar": { return LanguageManager.CurrentLanguage.style.style_bipolar; }
                case "ultrakill.cannonballed": { return LanguageManager.CurrentLanguage.style.style_cannonballed; }
                case "ultrakill.catapaulted": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_catapaulted + "</color>"; }
                case "ultrakill.chargeback": { return LanguageManager.CurrentLanguage.style.style_chargeback; }
                case "ultrakill.compressed": { return LanguageManager.CurrentLanguage.style.style_compressed; }
                case "ultrakill.criticalpunch": { return LanguageManager.CurrentLanguage.style.style_criticalpunch; }
                case "ultrakill.disrespect": { return LanguageManager.CurrentLanguage.style.style_disrespect; }
                case "ultrakill.doublekill": { return "<color=orange>" + LanguageManager.CurrentLanguage.style.style_doublekill + "</color>"; }
                case "ultrakill.downtosize": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_downtosize + "</color>"; }
                case "ultrakill.enraged": { return "<color=red>" + LanguageManager.CurrentLanguage.style.style_enraged + "</color>"; }
                case "ultrakill.exploded": { return LanguageManager.CurrentLanguage.style.style_exploded; }
                case "ultrakill.finishedoff": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_finishedoff + "</color>"; }
                case "ultrakill.fireworks": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_fireworks + "</color>"; }
                case "ultrakill.fistfullofdollar": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_fistfulofdollar + "</color>"; }
                case "ultrakill.fried": { return LanguageManager.CurrentLanguage.style.style_fried; }
                case "ultrakill.friendlyfire": { return LanguageManager.CurrentLanguage.style.style_friendlyfire; }
                case "ultrakill.groundslam": { return LanguageManager.CurrentLanguage.style.style_groundslam; }
                case "ultrakill.halfoff": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_halfoff + "</color>"; }
                case "ultrakill.headshot": { return LanguageManager.CurrentLanguage.style.style_headshot; }
                case "ultrakill.headshotcombo": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_headshot + "</color>"; }
                case "ultrakill.homerun": { return LanguageManager.CurrentLanguage.style.style_homerun; }
                case "ultrakill.instakill": { return "<color=green>" + LanguageManager.CurrentLanguage.style.style_instakill + "</color>"; }
                case "ultrakill.interruption": { return "<color=green>" + LanguageManager.CurrentLanguage.style.style_interruption + "</color>"; }
                case "ultrakill.kill": { return LanguageManager.CurrentLanguage.style.style_kill; }
                case "ultrakill.landyours": { return "<color=green>" + LanguageManager.CurrentLanguage.style.style_landyours + "</color>"; }
                case "ultrakill.limbhit": { return LanguageManager.CurrentLanguage.style.style_limbshot; }
                case "ultrakill.mauriced": { return LanguageManager.CurrentLanguage.style.style_mauriced; }
                case "ultrakill.multikill": { return "<color=orange>" + LanguageManager.CurrentLanguage.style.style_multikill + "</color>"; }
                case "ultrakill.nailbombed": { return LanguageManager.CurrentLanguage.style.style_nailbombed; }
                case "ultrakill.nailbombedalive": { return "<color=grey>" + LanguageManager.CurrentLanguage.style.style_nailbombed + "</color>"; }
                case "ultrakill.overkill": { return LanguageManager.CurrentLanguage.style.style_overkill; }
                case "ultrakill.parry": { return "<color=green>" + LanguageManager.CurrentLanguage.style.style_parry + "</color>"; }
                case "ultrakill.projectileboost": { return "<color=green>" + LanguageManager.CurrentLanguage.style.style_projectileboost + "</color>"; }
                case "ultrakill.quickdraw": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_quickdraw + "</color>"; }
                case "ultrakill.ricoshot": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_ricoshot + "</color>"; }
                case "ultrakill.rocketreturn": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_rocketreturn + "</color>"; }
                case "ultrakill.roundtrip": { return "<color=green>" + LanguageManager.CurrentLanguage.style.style_roundtrip + "</color>"; }
                case "ultrakill.secret": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_secret + "</color>"; }
                case "ultrakill.serve": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_served + "</color>"; }
                case "ultrakill.strike": { return "<color=#00ffff>" + LanguageManager.CurrentLanguage.style.style_strike + "</color>"; }
                case "ultrakill.splattered": { return LanguageManager.CurrentLanguage.style.style_splattered; }
                case "ultrakill.triplekill": { return "<color=orange>" + LanguageManager.CurrentLanguage.style.style_triplekill + "</color>"; }

                case "ultrakill.firehit": { return ""; }
                case "ultrakill.shotgunhit": { return ""; }
                case "ultrakill.nailhit": { return ""; }
                case "ultrakill.explosionhit": { return ""; }

                case "": { return ""; }
                default: { Logging.Warn("Missing style translation: " + inputBonus); return inputBonus; }
            }
        }

        private static string GetStyleBonus(string inputBonus)
        {
            string regexinput = Regex.Replace(inputBonus, @"<[^>]*>", "");

            //Try and keep this alphabetical as it gets bigger over time.
                switch (regexinput)
                {
                    case "BISHOP CAPTURE": { return "<color=green>" + LanguageManager.CurrentLanguage.style.style_bishopcapture + "</color>"; }
                    case "BISHOP PROMOTION": { return "<color=green>" + LanguageManager.CurrentLanguage.style.style_bishoppromo + "</color>"; }
                    case "BLACK WINS": { return "<color=orange>" + LanguageManager.CurrentLanguage.style.style_blackwins + "</color>"; }
                    case "BOILED": { return LanguageManager.CurrentLanguage.style.style_boiled; }
                    case "BONGCLOUD": { return "<color=orange>" + LanguageManager.CurrentLanguage.style.style_bongcloud + "</color>"; }
                    case "CASTLED": { return "<color=blue>" + LanguageManager.CurrentLanguage.style.style_castled + "</color>"; }
                    case "CONDUCTOR": { return LanguageManager.CurrentLanguage.style.style_conductor; }
                    case "CRUSHED": { return LanguageManager.CurrentLanguage.style.style_crushed; } 
                    case "EN PASSANT": { return "<color=blue>" + LanguageManager.CurrentLanguage.style.style_enpassant + "</color>";}
                    case "ENVIROKILL": { return LanguageManager.CurrentLanguage.style.style_envirokill; }
                    case "FALL": { return LanguageManager.CurrentLanguage.style.style_fall; }
                    case "FOOLS MATE": { return "<color=red>" + LanguageManager.CurrentLanguage.style.style_foolsmate + "</color>"; }
                    case "FOR THEE": { return LanguageManager.CurrentLanguage.style.style_forthee; }
                    case "FRIED": { return LanguageManager.CurrentLanguage.style.style_fried; }
                    case "GUARD BREAK": { return "<color=green>" + LanguageManager.CurrentLanguage.style.style_guardbreak + "</color>"; }
                    case "KNIGHT CAPTURE": { return "<color=green>" + LanguageManager.CurrentLanguage.style.style_knightcapture + "</color>"; }
                    case "KNIGHT PROMOTION": { return "<color=green>" + LanguageManager.CurrentLanguage.style.style_knightpromo + "</color>"; }
                    case "LONG WAY DOWN": { return LanguageManager.CurrentLanguage.style.style_longwaydown; }
                    case "LOST": { return LanguageManager.CurrentLanguage.style.style_lost; }
                    case "M.A.D.": { return LanguageManager.CurrentLanguage.style.style_m_a_d; }
                    case "MINCED": { return LanguageManager.CurrentLanguage.style.style_minced; }
                    case "OUT OF BOUNDS": { return LanguageManager.CurrentLanguage.style.style_outofbounds; }
                    case "PANCAKED": { return LanguageManager.CurrentLanguage.style.style_pancaked; }
                    case "PAWN CAPTURE": { return LanguageManager.CurrentLanguage.style.style_pawncapture; }
                    case "QUEEN CAPTURE": { return "<color=red>" + LanguageManager.CurrentLanguage.style.style_queencapture + "</color>"; }
                    case "QUEEN PROMOTION": { return "<color=green>" + LanguageManager.CurrentLanguage.style.style_queenpromo + "</color>"; }
                    case "RICOSHOT": { return LanguageManager.CurrentLanguage.style.style_ricoshot; }
                    case "ROADKILL": { return LanguageManager.CurrentLanguage.style.style_roadkill; }
                    case "ROOK CAPTURE": { return "<color=orange>" + LanguageManager.CurrentLanguage.style.style_rookcapture + "</color>"; }
                    case "ROOK PROMOTION": { return "<color=green>" + LanguageManager.CurrentLanguage.style.style_rookpromo + "</color>"; }
                    case "SCRONGLED": { return LanguageManager.CurrentLanguage.style.style_scrongled; }
                    case "SCRONGBONGLED": { return LanguageManager.CurrentLanguage.style.style_scrongbongled; }
                    case "SCRINDONGULODED": { return LanguageManager.CurrentLanguage.style.style_scrindonguloded; }
                    case "SHREDDED": { return LanguageManager.CurrentLanguage.style.style_shredded; }
                    case "SLIPPED": { return LanguageManager.CurrentLanguage.style.style_slipped; }
                    case "TRAMPLED": { return LanguageManager.CurrentLanguage.style.style_trampled; }
                    case "ULTRAVICTORY": { return "<color=red>" + LanguageManager.CurrentLanguage.style.style_ultravictory + "</color>"; }
                    case "WHITE WINS": { return "<color=orange>" + LanguageManager.CurrentLanguage.style.style_whitewins + "</color>"; }
                    case "ZAPPED": { return LanguageManager.CurrentLanguage.style.style_zapped; }
                    case "why are you even spawning enemies here": { return LanguageManager.CurrentLanguage.style.style_why; }
                        
                    case "": { return ""; }
                    default: { Logging.Warn("Missing style translation: " + regexinput); return regexinput; }
             }
        }

        public static string GetTranslatedStyleBonus(string inputBonus)
        {
            //Bonus string is split up into 3 parts: the opening color tag if there is one, the bonus name, and the closing color tag if there is one.

                    
            bool hasColorTag = (inputBonus.Contains("<color="));
            string openingColorTag;
            string closingColorTag = "</color>";
            string styleBonus = GetStyleBonus(inputBonus);

            if (hasColorTag)
            {
                openingColorTag = GetBonusColor(inputBonus);
                return (openingColorTag + styleBonus + closingColorTag);
            }
            else
            {
                return(styleBonus);
            }
        }
        
        public static string GetWeaponFreshness(StyleFreshnessState weaponState)
        {
            switch(weaponState)
            {
                case StyleFreshnessState.Fresh: { return LanguageManager.CurrentLanguage.style.style_weaponFresh + ": 1.50X"; }
                case StyleFreshnessState.Used: { return LanguageManager.CurrentLanguage.style.style_weaponUsed + ": 1.00X"; }
                case StyleFreshnessState.Stale: { return LanguageManager.CurrentLanguage.style.style_weaponStale + ": 0.50X"; }
                case StyleFreshnessState.Dull: { return LanguageManager.CurrentLanguage.style.style_weaponDull + ": 0.00X"; }
                default: { Logging.Warn("Missing weapon states detected"); return "Unknown state"; }
            }
        }
    }
}
