using System;
using System.Text;

using UltrakULL.json;

//This class is for managing and returning the layer names, and level names, of each scene.
//This is in a seperate class and not part of scene classes, as the layer/lavel strings are private and can't simply be put in the
//corresponding classes.

namespace UltrakULL
{
    class TitleManager
    {
        public TitleManager()
        {

        }
        public string getName(string inputName, JsonParser language)
        {
            //Prelude titles
            if (inputName.Contains("INTO THE FIRE")) { return (language.currentLanguage.levelNames.levelName_preludeFirst); }
            if (inputName.Contains("THE MEATGRINDER")) { return (language.currentLanguage.levelNames.levelName_preludeSecond); }
            if (inputName.Contains("DOUBLE DOWN")) { return (language.currentLanguage.levelNames.levelName_preludeThird); }
            if (inputName.Contains("A ONE-MACHINE ARMY")) { return (language.currentLanguage.levelNames.levelName_preludeFourth); }
            if (inputName.Contains("CERBERUS")) { return (language.currentLanguage.levelNames.levelName_preludeFifth); }

            //Act 1 titles
            //Limbo
            if (inputName.Contains("HEART OF THE SUNRISE")) { return (language.currentLanguage.levelNames.levelName_limboFirst); }
            if (inputName.Contains("THE BURNING WORLD")) { return (language.currentLanguage.levelNames.levelName_limboSecond); }
            if (inputName.Contains("HALLS OF SACRED REMAINS")) { return (language.currentLanguage.levelNames.levelName_limboThird); }
            if (inputName.Contains("CLAIR DE LUNE")) { return (language.currentLanguage.levelNames.levelName_limboFourth); }

            //Lust
            if (inputName.Contains("BRIDGEBURNER")) { return (language.currentLanguage.levelNames.levelName_lustFirst); }
            if (inputName.Contains("DEATH AT 20,000 VOLTS")) { return (language.currentLanguage.levelNames.levelName_lustSecond); }
            if (inputName.Contains("SHEER HEART ATTACK")) { return (language.currentLanguage.levelNames.levelName_lustThird); }
            if (inputName.Contains("COURT OF THE CORPSE KING")) { return (language.currentLanguage.levelNames.levelName_lustFourth); }

            //Gluttony
            if (inputName.Contains("BELLY OF THE BEAST")) { return (language.currentLanguage.levelNames.levelName_gluttonyFirst); }
            if (inputName.Contains("IN THE FLESH")) { return (language.currentLanguage.levelNames.levelName_gluttonySecond); }

            //Act 2 titles
            //Greed
            if (inputName.Contains("SLAVES TO POWER")) { return (language.currentLanguage.levelNames.levelName_greedFirst); }
            if (inputName.Contains("GOD DAMN THE SUN")) { return (language.currentLanguage.levelNames.levelName_greedSecond); }
            if (inputName.Contains("A SHOT IN THE DARK")) { return (language.currentLanguage.levelNames.levelName_greedThird); }
            if (inputName.Contains("CLAIR DE SOLEIL")) { return (language.currentLanguage.levelNames.levelName_greedFourth); }

            //Wrath titles
            if (inputName.Contains("IN THE WAKE OF POSEIDON")) { return (language.currentLanguage.levelNames.levelName_wrathFirst); }
            if (inputName.Contains("WAVES OF THE STARLESS SEA")) { return (language.currentLanguage.levelNames.levelName_wrathSecond); }
            if (inputName.Contains("SHIP OF FOOLS")) { return (language.currentLanguage.levelNames.levelName_wrathThird); }
            if (inputName.Contains("LEVIATHAN")) { return (language.currentLanguage.levelNames.levelName_wrathFourth); }

            //Heresy titles
            if (inputName.Contains("CRY FOR THE WEEPER")) { return (language.currentLanguage.levelNames.levelName_heresyFirst); }
            if (inputName.Contains("AESTHETICS OF HATE")) { return (language.currentLanguage.levelNames.levelName_heresySecond); }

            //Prime titles
            if (inputName.Contains("SOUL SURVIVOR")) { return (language.currentLanguage.levelNames.levelName_primeFirst); }

            return "";
        }

        public string getLayer(string inputTitle, JsonParser language)
        {
            StringBuilder titleToReturn = new StringBuilder();

            //Grab the layer name...
            if (inputTitle.Contains("PRELUDE"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_prelude);
            }
            else if (inputTitle.Contains("LIMBO"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_limbo);
            }
            else if (inputTitle.Contains("LUST"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_lust);
            }
            else if (inputTitle.Contains("GLUTTONY"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_gluttony);
            }
            else if (inputTitle.Contains("GREED"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_greed);
            }
            else if (inputTitle.Contains("WRATH"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_wrath);
            }
            else if (inputTitle.Contains("HERESY"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_heresy);
            }
            else if (inputTitle.Contains("PRIME"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_prime);
            }

            titleToReturn.Append(" /// ");

            //...and then the number
            if (inputTitle.Contains("ACT I CRESCENDO"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_act1crescendo);
            }
            else if (inputTitle.Contains("ACT I CLIMAX"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_act1climax);
                return titleToReturn.ToString();
            }
            if (inputTitle.Contains("ACT II CRESCENDO"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_act2crescendo);
            }
            else if (inputTitle.Contains("ACT II CLIMAX"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_act1climax);
                return titleToReturn.ToString();
            }

            else if (inputTitle.Contains("FIRST"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_first);
            }
            else if (inputTitle.Contains("SECOND"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_second);
            }
            else if (inputTitle.Contains("THIRD"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_third);
            }
            else if (inputTitle.Contains("FOURTH"))
            {
                titleToReturn.Append(language.currentLanguage.misc.hellmap_fourth);
            }
            else if (inputTitle.Contains("CLIMAX"))
            {


                titleToReturn.Append(language.currentLanguage.misc.hellmap_climax);
            }
            return titleToReturn.ToString();
        }

    }
}
