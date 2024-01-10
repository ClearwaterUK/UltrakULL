using System.Text;

using UltrakULL.json;

//This class is for managing and returning the layer names, and level names, of each scene.
//This is in a seperate class and not part of scene classes, as the layer/lavel strings are private and can't simply be put in the
//corresponding classes.

namespace UltrakULL
{
    public static class TitleManager
    {
        public static string GetName(string inputName)
        {
            //Prelude titles
            if (inputName.Contains("INTO THE FIRE")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_preludeFirst); }
            if (inputName.Contains("THE MEATGRINDER")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_preludeSecond); }
            if (inputName.Contains("DOUBLE DOWN")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_preludeThird); }
            if (inputName.Contains("A ONE-MACHINE ARMY")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_preludeFourth); }
            if (inputName.Contains("CERBERUS")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_preludeFifth); }

            //Act 1 titles
            //Limbo
            if (inputName.Contains("HEART OF THE SUNRISE")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_limboFirst); }
            if (inputName.Contains("THE BURNING WORLD")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_limboSecond); }
            if (inputName.Contains("HALLS OF SACRED REMAINS")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_limboThird); }
            if (inputName.Contains("CLAIR DE LUNE")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_limboFourth); }

            //Lust
            if (inputName.Contains("BRIDGEBURNER")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_lustFirst); }
            if (inputName.Contains("DEATH AT 20,000 VOLTS")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_lustSecond); }
            if (inputName.Contains("SHEER HEART ATTACK")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_lustThird); }
            if (inputName.Contains("COURT OF THE CORPSE KING")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_lustFourth); }

            //Gluttony
            if (inputName.Contains("BELLY OF THE BEAST")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_gluttonyFirst); }
            if (inputName.Contains("IN THE FLESH")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_gluttonySecond); }

            //Act 2 titles
            //Greed
            if (inputName.Contains("SLAVES TO POWER")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_greedFirst); }
            if (inputName.Contains("GOD DAMN THE SUN")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_greedSecond); }
            if (inputName.Contains("A SHOT IN THE DARK")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_greedThird); }
            if (inputName.Contains("CLAIR DE SOLEIL")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_greedFourth); }

            //Wrath titles
            if (inputName.Contains("IN THE WAKE OF POSEIDON")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_wrathFirst); }
            if (inputName.Contains("WAVES OF THE STARLESS SEA")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_wrathSecond); }
            if (inputName.Contains("SHIP OF FOOLS")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_wrathThird); }
            if (inputName.Contains("LEVIATHAN")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_wrathFourth); }

            //Heresy titles
            if (inputName.Contains("CRY FOR THE WEEPER")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_heresyFirst); }
            if (inputName.Contains("AESTHETICS OF HATE")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_heresySecond); }
            
            //Violence titles
            if (inputName.Contains(("GARDEN OF FORKING PATHS"))) { return (LanguageManager.CurrentLanguage.levelNames.levelName_violenceFirst); }
            if (inputName.Contains(("LIGHT UP THE NIGHT"))) { return (LanguageManager.CurrentLanguage.levelNames.levelName_violenceSecond); }
            if (inputName.Contains(("NO SOUND, NO MEMORY"))) { return (LanguageManager.CurrentLanguage.levelNames.levelName_violenceThird); }
            if (inputName.Contains(("...LIKE ANTENNAS TO HEAVEN"))) { return (LanguageManager.CurrentLanguage.levelNames.levelName_violenceFourth); }
            
            //Fraud titles
            if (inputName.Contains(("FRAUD FIRST"))) { return (LanguageManager.CurrentLanguage.levelNames.levelName_fraudFirst); }
            if (inputName.Contains(("FRAUD SECOND"))) { return (LanguageManager.CurrentLanguage.levelNames.levelName_fraudSecond); }
            if (inputName.Contains(("FRAUD THIRD"))) { return (LanguageManager.CurrentLanguage.levelNames.levelName_fraudThird); }
            if (inputName.Contains(("FRAUD CLIMAX"))) { return (LanguageManager.CurrentLanguage.levelNames.levelName_fraudFourth); }
            
            //Treachery titles
            if (inputName.Contains("TREACHERY FIRST")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_treacheryFirst); }
            if (inputName.Contains("TREACHERY SECOND")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_treacherySecond); }

            //Prime titles
            if (inputName.Contains("SOUL SURVIVOR")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_primeFirst); }
            if (inputName.Contains("WAIT OF THE WORLD")) { return (LanguageManager.CurrentLanguage.levelNames.levelName_primeSecond); }

            return "";
        }

        public static string GetLayer(string inputTitle)
        {
            StringBuilder titleToReturn = new StringBuilder();

            //Grab the layer name...
            if (inputTitle.Contains("PRELUDE"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_prelude);
            }
            else if (inputTitle.Contains("LIMBO"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_limbo);
            }
            else if (inputTitle.Contains("LUST"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_lust);
            }
            else if (inputTitle.Contains("GLUTTONY"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_gluttony);
            }
            else if (inputTitle.Contains("GREED"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_greed);
            }
            else if (inputTitle.Contains("WRATH"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_wrath);
            }
            else if (inputTitle.Contains("HERESY"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_heresy);
            }
            else if (inputTitle.Contains("VIOLENCE"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_violence);
            }
            else if (inputTitle.Contains("FRAUD"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_fraud);
            }
            else if (inputTitle.Contains("TREACHERY"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_treachery);
            }
            else if (inputTitle.Contains("PRIME"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_prime);
            }

            titleToReturn.Append(" /// ");

            //...and then the number
            if (inputTitle.Contains("ACT I CRESCENDO"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_act1crescendo);
            }
            else if (inputTitle.Contains("ACT I CLIMAX"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_act1climax);
                return titleToReturn.ToString();
            }
            if (inputTitle.Contains("ACT II CRESCENDO"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_act2crescendo);
            }
            else if (inputTitle.Contains("ACT II CLIMAX"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_act2climax);
                return titleToReturn.ToString();
            }
            if (inputTitle.Contains("ACT III CRESCENDO"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_act3crescendo);
            }
            else if (inputTitle.Contains("ACT III CLIMAX"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_act3climax);
                return titleToReturn.ToString();
            }

            else if (inputTitle.Contains("FIRST"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_first);
            }
            else if (inputTitle.Contains("SECOND"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_second);
            }
            else if (inputTitle.Contains("THIRD"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_third);
            }
            else if (inputTitle.Contains("FOURTH"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_fourth);
            }
            else if (inputTitle.Contains("CLIMAX"))
            {
                titleToReturn.Append(LanguageManager.CurrentLanguage.misc.hellmap_climax);
            }
            return titleToReturn.ToString();
        }
    }
}
