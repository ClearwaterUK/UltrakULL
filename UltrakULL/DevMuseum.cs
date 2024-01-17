using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public class DevMuseum
    {
        public static string GetMessage(string message, string message2, string input)
        {
            if(message.Contains("RACE START"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_rocketRaceStart;
            }
            if(message.Contains("A R M B O Y"))
            { 
                return LanguageManager.CurrentLanguage.act2.act2_heresyFirst_armboy;
            }
            if(message.Contains("TIME"))
            {
                string time = message.Split(':')[1];
                
                return LanguageManager.CurrentLanguage.misc.levelstats_time + ": " + time;
            }
            if(message.Contains("chess"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_chessTip;
            }
            
            
            return "";
        }
        
        public static string GetMuseumBook(string originalText)
        {
            if(originalText.Contains("HAKITA</color> - CREATOR OF ULTRAKILL</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita1 + "\n\n"
                    +  LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita2 + "\n\n"
                    +  LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita3 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita5 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita6 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita7 + "\n\n"
                    + "<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita8 + "\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita9 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita10 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita11 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita12 + "</size>\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita13 + "</color>";
            }
            if(originalText.Contains("FRANCIS XIE</color> - CONCEPT AND TEXTURE ARTIST</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie1 + "\n\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie2 + "\n\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie3 + "\n\n"
                     +  "<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie4 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie5 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie6 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie7 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie8 + "</size>\n\n"
                     + "<color=#4AACBD>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie9 + "</color>";
            }
            if(originalText.Contains("JERICHO_RUS</color> - ILLUSTRATOR, CONCEPT AND TEXTURE ARTIST</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus1 + "\n\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus2 + "\n\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus3 + "\n\n"
                     + "<size=18>" +  LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus4 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus5 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus6 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus7 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus8 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus9 + "</size>\n\n"
                     + "<color=#5cc6f1>"+ LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus10 + "</color>";
            }
            if(originalText.Contains("BIGROCKBMP</color> - CONCEPT ARTIST</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP2 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP3 + "\n\n"
                    + "<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP4 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP5 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP6 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP7 + "</size>\n\n"
                    + "<color=#DA6B6D>"+ LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP8 + "</color>";
            }
            if(originalText.Contains("MAXIMILIAN OVESSON</color> - UI ARTIST</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookMaximilianOvesson1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookMaximilianOvesson2 + "\n\n"
                    + "<color=#8f65da>" +  LanguageManager.CurrentLanguage.devMuseum.museum_bookMaximilianOvesson3 + "</color>\n\n";
            }
            if(originalText.Contains("VICTORIA HOLLAND</color> - LEAD 3D ARTIST AND GRAPHICS PROGRAMMER</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland2 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland3 + "\n\n"
                    + "<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland4 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland5 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland6 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland7 + "</size>\n\n"
                    + "<color=#F5ABB9>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland8 + "</color>\n\n";
            }
            if(originalText.Contains("TONI STIGELL</color> - 3D ARTIST</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell2 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell3 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell4 + "\n\n"
                    + "<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell5 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell6 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell7 + "</size>";
                    
            }
            if(originalText.Contains("FLYINGDOG</color> - 3D ARTIST</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookFlyingDog1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookFlyingDog2 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookFlyingDog3 + "\n\n"
                    + "<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFlyingDog4 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookFlyingDog5 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookFlyingDog6 + "</size>";
            }
            if(originalText.Contains("SAMUEL JAMES BRYAN</color> - 3D ARTIST</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookSamuelJamesBryan1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookSamuelJamesBryan2 + "\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookSamuelJamesBryan3 + "</color>";
            }
            if(originalText.Contains("CAMERON MARTIN</color> - QUALITY ASSURANCE LEAD"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeam1 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeam2 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeam3 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeam4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeam5 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeam6 + "\n\n"
                    + "<color=red>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeam7 + "</color>\n\n"
                    + "<color=#6a36be>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeam8 + "</color>\n\n"
                    + "<color=#11c324>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeam9 + "</color>\n\n"
                    + "<color=#e28eb6>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQATeam10 + "</color>";
            }
            if(originalText.Contains("<b><color=orange>PITR</color> - LEAD PROGRAMMER</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr1 + "\n\n"
                    +  LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr2 + "\n\n"
                    +  LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr3 + "\n\n"
                    +  LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr4 + "\n\n"
                    +  "<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr5 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr6 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr7 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookPitr8 + "</size>";
            }
            if(originalText.Contains("HECKTECK</color> - PROGRAMMING</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookHeckteck1 + "\n\n"
                    +  LanguageManager.CurrentLanguage.devMuseum.museum_bookHeckteck2 + "\n\n"
                    +  "<i><color=orange>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHeckteck3 + "</color></i>";
            }
            if(originalText.Contains("CHIZHOV</color> - ADDITIONAL PROGRAMMER</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookCabalcrow1 + "\n\n"
                    +  LanguageManager.CurrentLanguage.devMuseum.museum_bookCabalcrow2 + "\n\n"
                    + "<color=#c0c0c0ff>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookCabalcrow3 + "</color>";
            }
            if(originalText.Contains("LUCAS VARNEY</color> - ADDITIONAL PROGRAMMER</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookLucasVarney1 + "\n\n"
                    +  LanguageManager.CurrentLanguage.devMuseum.museum_bookLucasVarney2 + "\n\n"
                    +  "<color=#BD8BF3>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookLucasVarney3 + "</color>";
            }
            if(originalText.Contains("BEN MOIR</color> - ADDITIONAL PROGRAMMER</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookBenMoir1 + "\n\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookBenMoir2 + "\n\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookBenMoir3 + "\n\n" 
                    + "<color=#3EF242>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookBenMoir4 + "</color>\n\n";
            }
            if(originalText.Contains("MEGANEKO</color> - GUEST COMPOSER</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookMeganeko1 + "\n\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookMeganeko2 + "\n\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookMeganeko3 + "\n\n" 
                    + "<color=#E93436>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookMeganeko4 + "</color>\n\n";
            }
            if(originalText.Contains("KEYGEN CHURCH</color> - GUEST COMPOSER</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookKeygenChurch1 + "\n\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookKeygenChurch2 + "\n\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookKeygenChurch3 + "\n\n" 
                    + "<color=#aa0000>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookKeygenChurch4 + "</color>\n\n";
            }
            if(originalText.Contains("HEALTH</color> - GUEST COMPOSER</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookHealth1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHealth2 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHealth3 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHealth4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHealth5 + "\n\n"
                    + "<color=red>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHealth6 + "</color>";
            }
            if(originalText.Contains("QUETZAL TIRADO</color> - GUEST MUSICIAN</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookQuetzalTirado1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookQuetzalTirado2 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookQuetzalTirado3 + "\n\n"
                    + "<color=#AA4CAD>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookQuetzalTirado4 + "</color>";
            }
            if(originalText.Contains("SALAD</color> - ARTIST OF JAKITO</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookSalad1 + "\n\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookSalad2 + "\n\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookSalad3 + "\n\n" 
                    + "<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookSalad4 + "</size>\n\n"
                    + "<color=#20FF20>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookSalad5 + "</color>";
            }
            if(originalText.Contains("JACOB H.H.R.</color> - WRITER (PROSE & DIALOGUE)</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookJacobHHR1 + "\n\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookJacobHHR2 + "\n\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookJacobHHR3;
            }
            if(originalText.Contains("VVIZARD</color> - MUSEUM DEVELOPER</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookVVizard1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookVVizard2 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookVVizard3 + "\n\n"
                    + "<color=#ee0c47>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVVizard4 + "</color>";
            }
            if(originalText.Contains("ADDITIONAL MUSIC CREDITS"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic2 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic3 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic5 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic6 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic7 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic8 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic9 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic10 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic11 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalMusic12;
            }
            if(originalText.Contains("COMMUNITY CYBER GRIND"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits2 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits3 + "\n\n"
                    
                    //CG pattern credits
                    + "NO LOAFING\nDood\nSplendidLedraps\nJandy\nStuon\nDryzalar\nWakan\nSlimer\nWilliam\nBobot\nSpruce\nJacob\n\n"
                    
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits5 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits6 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits7 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookAdditionalCredits8 + "\n\n"
                
                    //Totally not subtle self-insert for mod credits here. :D
                    + "<b><color=orange>UltrakULL CREDITS</color>:</b>\n\n"
                    + "Mod created by <color=orange>Clearwater</color>\n"
                    + "Additional code contributions by <color=orange>Temperz87</color>, <color=orange>CoatlessAli</color> and <color=orange>Frizou</color>\n"
                    + "Translations by various community members of the <color=orange>UltrakULL Translation Team</color>\n"
                    + "Documentation contributions by <color=orange>Frizou</color>\n\n"
                
                    //Get the translators of the currently loaded language and also place them here.
                    + "<color=orange>" + LanguageManager.CurrentLanguage.metadata.langDisplayName + "</color>:\n"
                    + LanguageManager.CurrentLanguage.metadata.langAuthor;
            }
            if(originalText.Contains("STEPHAN WEYTE</color> - VOICE OF MINOS PRIME</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookStephanWeyte1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookStephanWeyte2 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookStephanWeyte3 + "\n\n";
            }
            if(originalText.Contains("LENVAL BROWN</color> - VOICE OF SISYPHUS PRIME</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookLenvalBrown1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookLenvalBrown2;
            }
            if(originalText.Contains("GIANNI MATRAGRANO</color> - VOICE OF GABRIEL</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookGianniMatragrano1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookGianniMatragrano2 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookGianniMatragrano3 + "\n\n"
                    + "<color=#20afdb>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookGianniMatragrano4 + "</color>";
            }
            if(originalText.Contains("MANDALORE</color> <color=#9884bb>HERRINGTON</color> - VOICE OF MYSTERIOUS DRUID KNIGHT</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore1 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore2 +  "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore3 +  "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore4 +  "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore5 +  "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore6 +  "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookMandalore7;
            }
            
            if(originalText.Contains("FILTH</color>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth1 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth2 + "\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth3 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth5 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth6 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesFilth7;
            }
            if(originalText.Contains("STRAY</color>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_enemiesStray1 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesStray2 + "\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesStray3 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesStray4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesStray5;
            }
            if(originalText.Contains("SCHISM</color>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSchism1 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSchism2 + "\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSchism3 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSchism4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSchism5 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSchism6;
            }
            if(originalText.Contains("SWORDSMACHINE</color>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSwordsmachine1 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSwordsmachine2 + "\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSwordsmachine3 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSwordsmachine4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSwordsmachine5 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesSwordsmachine6;
            }
            if(originalText.Contains("MALICIOUS FACE</color>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace1 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace2 + "\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace3 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace5 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace6 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_enemiesMaliciousFace7;
            }
            if(originalText.Contains("BEAMCUTTER</color>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter1 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter2 + "\n\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter3 + "\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter5 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter6 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter7 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter8 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBeamcutter9;
            }
            if(originalText.Contains("BLACK HOLE CANNON</color>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon2 + "\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon3 + "\n\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon5 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon6 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon7 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsBlackHoleCannon8;
            }
            if(originalText.Contains("REVOLVER</color>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_weaponsRevolver1 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsRevolver2 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsRevolver3 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsRevolver4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsRevolver5 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsRevolver6;
            }
            if(originalText.Contains("SHOTGUN</color>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_weaponsShotgun1 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsShotgun2 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsShotgun3 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsShotgun4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsShotgun5;
            }
            if(originalText.Contains("NAILGUN</color>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_weaponsNailgun1 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsNailgun2 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsNailgun3 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsNailgun4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsNailgun5 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_weaponsNailgun6;
            }
            return "";
        }


        private void PatchPlaques()
        {
            //Since the dev museum uses unconventional gameObject names compared to the rest of the game, GetChild is primarily used here.
            GameObject museum = GetInactiveRootObject("__Room_Courtyard").transform.GetChild(4).GetChild(0).gameObject;
            Text museumTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(museum,"Canvas (2)"),"Text"));
            museumTitle.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMuseumTitle;
            
            
            GameObject lobbyRoom = GetInactiveRootObject("__Room_FrontDesk_1").transform.GetChild(1).gameObject;

            GameObject lobbyRoomHakitaPlaque = lobbyRoom.transform.GetChild(58).gameObject;
            GameObject lobbyRoomArtRoomPlaque = lobbyRoom.transform.GetChild(0).gameObject;
            GameObject lobbyRoomNerdRoomPlaque = lobbyRoom.transform.GetChild(1).gameObject;

            Text frontDeskPlaqueText1 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(lobbyRoomHakitaPlaque,"Canvas (3)"),"Text"));
            frontDeskPlaqueText1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHakita1;
            Text frontDeskPlaqueText2 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(lobbyRoomHakitaPlaque,"Canvas (3)"),"Text (1)"));
            frontDeskPlaqueText2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHakita2;
            
            Text frontDeskArtRoomText =  GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(lobbyRoomArtRoomPlaque,"Canvas (3)"),"Text"));
            frontDeskArtRoomText.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesArtRoom;
            
            Text frontDeskNerdRoomText =  GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(lobbyRoomNerdRoomPlaque,"Canvas (3)"),"Text"));
            frontDeskNerdRoomText.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesNerdRoom;
            
            GameObject plaques = GetInactiveRootObject("__DEV_SPACE_ALL");
            
            GameObject artRoomFrancisPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (13)"),"Dev Smalll placard"),"Canvas (4)");
            Text francisPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomFrancisPlaque,"Text"));
            Text francisPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomFrancisPlaque,"Text (1)"));
            francisPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesFrancisXie1;
            francisPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesFrancisXie2;
            
            GameObject artRoomJerichoPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (14)"),"Dev Smalll placard"),"Canvas (4)");
            Text jerichoPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomJerichoPlaque,"Text"));
            Text jerichoPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomJerichoPlaque,"Text (1)"));
            jerichoPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJerichoRus1;
            jerichoPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJerichoRus2;
            
            GameObject artRoomBigrockPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (12)"),"Dev Smalll placard"),"Canvas (4)");
            Text bigrockPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomBigrockPlaque,"Text"));
            Text bigrockPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomBigrockPlaque,"Text (1)"));
            bigrockPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesBigRockBMP1;
            bigrockPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesBigRockBMP2;
            
            GameObject artRoomMaximilianPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (15)"),"Dev Smalll placard"),"Canvas (4)");
            Text maximilianPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomMaximilianPlaque,"Text"));
            Text maximilianPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomMaximilianPlaque,"Text (1)"));
            maximilianPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMaxOvesson1;
            maximilianPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMaxOvesson2;
            
            GameObject artRoomVictoriaPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"dev Space Large"),"Dev Large Placard"),"Canvas (4)");
            Text victoriaPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomVictoriaPlaque,"Text"));
            Text victoriaPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomVictoriaPlaque,"Text (1)"));
            victoriaPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVictoriaHolland1;
            victoriaPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVictoriaHolland2;
            
            GameObject artRoomToniPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (23)"),"Dev Smalll placard"),"Canvas (4)");
            Text toniPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomToniPlaque,"Text"));
            Text toniPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomToniPlaque,"Text (1)"));
            toniPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesToniStigell1;
            toniPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesToniStigell2;
            
            GameObject artRoomFlyingdogPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (24)"),"Dev Smalll placard"),"Canvas (4)");
            Text flyingdogPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomFlyingdogPlaque,"Text"));
            Text flyingdogPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomFlyingdogPlaque,"Text (1)"));
            flyingdogPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesFlyingdog1;
            flyingdogPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesFlyingdog2;
            
            GameObject artRoomSamuelPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (22)"),"Dev Smalll placard"),"Canvas (4)");
            Text samuelPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomSamuelPlaque,"Text"));
            Text samuelPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomSamuelPlaque,"Text (1)"));
            samuelPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesSamuelJamesBryan1;
            samuelPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesSamuelJamesBryan2;
            
            GameObject artRoomCameronPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (19)"),"Dev Smalll placard"),"Canvas (4)");
            Text cameronPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomCameronPlaque,"Text"));
            Text cameronPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomCameronPlaque,"Text (1)"));
            cameronPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesCameronMartin1;
            cameronPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesCameronMartin2;
            
            GameObject artRoomDaliaPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (16)"),"Dev Smalll placard"),"Canvas (4)");
            Text daliaPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomDaliaPlaque,"Text"));
            Text daliaPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomDaliaPlaque,"Text (1)"));
            daliaPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaliaFigueroa1;
            daliaPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaliaFigueroa2;
            
            GameObject artRoomTuckerPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (18)"),"Dev Smalll placard"),"Canvas (4)");
            Text tuckerPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomTuckerPlaque,"Text"));
            Text tuckerPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomTuckerPlaque,"Text (1)"));
            tuckerPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesTuckerWilkin1;
            tuckerPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesTuckerWilkin2;
            
            GameObject artRoomScottPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (17)"),"Dev Smalll placard"),"Canvas (4)");
            Text scottPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomScottPlaque,"Text"));
            Text scottPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomScottPlaque,"Text (1)"));
            scottPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesScottGurney1;
            scottPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesScottGurney2;
            
            GameObject artRoomPitrPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"dev Space Large (2)"),"Dev Large Placard"),"Canvas (4)");
            Text pitrPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomPitrPlaque,"Text"));
            Text pitrPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomPitrPlaque,"Text (1)"));
            pitrPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesPitr1;
            pitrPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesPitr2;
            
            GameObject artRoomHeckteckPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (11)"),"Dev Smalll placard"),"Canvas (4)");
            Text heckteckPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomHeckteckPlaque,"Text"));
            Text heckteckPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomHeckteckPlaque,"Text (1)"));
            heckteckPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHeckteck1;
            heckteckPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHeckteck2;
            
            GameObject artRoomCabalcrowPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (10)"),"Dev Smalll placard"),"Canvas (4)");
            Text cabalcrowPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomCabalcrowPlaque,"Text"));
            Text cabalcrowPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomCabalcrowPlaque,"Text (1)"));
            cabalcrowPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesCabalcrow1;
            cabalcrowPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesCabalcrow2;
            
            GameObject artRoomLucasPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (9)"),"Dev Smalll placard"),"Canvas (4)");
            Text lucasPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomLucasPlaque,"Text"));
            Text lucasPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomLucasPlaque,"Text (1)"));
            lucasPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLucasVarney1;
            lucasPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLucasVarney2;
            
            GameObject artRoomBenMoirPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (1)"),"Dev Smalll placard"),"Canvas (4)");
            Text benPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomBenMoirPlaque,"Text"));
            Text benPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomBenMoirPlaque,"Text (1)"));
            benPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesBenMoir1;
            benPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesBenMoir2;
            
            
            //Central hall
            GameObject centralHall = GetInactiveRootObject("__Room_Large_Lower").transform.GetChild(4).gameObject;
            Text davePlaque1 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(centralHall,"Wing name (4)"),"Canvas (5)"),"Text"));
            Text davePlaque2 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(centralHall,"Wing name (4)"),"Canvas (5)"),"Text (1)"));
            
            davePlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaveOshry1;
            davePlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaveOshry2;
            
            GameObject centralHallSigns = GetInactiveRootObject("__Room_Large_Lower").transform.GetChild(3).gameObject;
            
            GameObject restRoomSign = centralHallSigns.transform.GetChild(9).gameObject;
            GameObject talkRoomSign = centralHallSigns.transform.GetChild(10).gameObject;
            
            Text restRoomPlaque = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(restRoomSign,"Canvas (3)"),"Text"));
            restRoomPlaque.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesRestRoom;
            
            Text talkRoomPlaque = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(talkRoomSign,"Canvas (3)"),"Text"));
            talkRoomPlaque.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesTalkRoom;
            
            GameObject restRoomMeganekoPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (3)"),"Dev Smalll placard"),"Canvas (4)");
            Text meganekoPlaque1 = GetTextfromGameObject(GetGameObjectChild(restRoomMeganekoPlaque,"Text"));
            Text meganekoPlaque2 = GetTextfromGameObject(GetGameObjectChild(restRoomMeganekoPlaque,"Text (1)"));
            meganekoPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMeganeko1;
            meganekoPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMeganeko2;
            
            GameObject restRoomKeygenChurchPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (2)"),"Dev Smalll placard"),"Canvas (4)");
            Text keygenPlaque1 = GetTextfromGameObject(GetGameObjectChild(restRoomKeygenChurchPlaque,"Text"));
            Text keygenPlaque2 = GetTextfromGameObject(GetGameObjectChild(restRoomKeygenChurchPlaque,"Text (1)"));
            keygenPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesKeygenChurch1;
            keygenPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesKeygenChurch2;
            
            GameObject restRoomHealthPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (26)"),"Dev Smalll placard"),"Canvas (4)");
            Text healthPlaque1 = GetTextfromGameObject(GetGameObjectChild(restRoomHealthPlaque,"Text"));
            Text healthPlaque2 = GetTextfromGameObject(GetGameObjectChild(restRoomHealthPlaque,"Text (1)"));
            healthPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHealth1;
            healthPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHealth2;
            
            GameObject restRoomQuetzalTiradoPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (8)"),"Dev Smalll placard"),"Canvas (4)");
            Text quetzalTiradoPlaque1 = GetTextfromGameObject(GetGameObjectChild(restRoomQuetzalTiradoPlaque,"Text"));
            Text quetzalTiradoPlaque2 = GetTextfromGameObject(GetGameObjectChild(restRoomQuetzalTiradoPlaque,"Text (1)"));
            quetzalTiradoPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesQuetzalTirado1;
            quetzalTiradoPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesQuetzalTirado2;
            
            GameObject restRoomSaladPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (4)"),"Dev Smalll placard"),"Canvas (4)");
            Text saladPlaque1 = GetTextfromGameObject(GetGameObjectChild(restRoomSaladPlaque,"Text"));
            Text saladPlaque2 = GetTextfromGameObject(GetGameObjectChild(restRoomSaladPlaque,"Text (1)"));
            saladPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesSalad1;
            saladPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesSalad2;
            
            GameObject restRoomJacobPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (5)"),"Dev Smalll placard"),"Canvas (4)");
            Text jacobPlaque1 = GetTextfromGameObject(GetGameObjectChild(restRoomJacobPlaque,"Text"));
            Text jacobPlaque2 = GetTextfromGameObject(GetGameObjectChild(restRoomJacobPlaque,"Text (1)"));
            jacobPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJacobHHR1;
            jacobPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJacobHHR2;
            
            GameObject restRoomJvVizardPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (6)"),"Dev Smalll placard"),"Canvas (4)");
            Text vVizardPlaque1 = GetTextfromGameObject(GetGameObjectChild(restRoomJvVizardPlaque,"Text"));
            Text vVizardPlaque2 = GetTextfromGameObject(GetGameObjectChild(restRoomJvVizardPlaque,"Text (1)"));
            vVizardPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVVizard1;
            vVizardPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVVizard2;
            
            GameObject redRoomAdditionalMusicPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (25)"),"Dev Smalll placard"),"Canvas (4)");
            GameObject redRoomAdditionalCreditsPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (25)"),"Dev Smalll placard (1)"),"Canvas (4)");
            Text additionalMusicPlaque = GetTextfromGameObject(GetGameObjectChild(redRoomAdditionalMusicPlaque,"Text"));
            additionalMusicPlaque.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesAdditionalMusic;
            Text additionalCreditsPlaque = GetTextfromGameObject(GetGameObjectChild(redRoomAdditionalCreditsPlaque,"Text"));
            additionalCreditsPlaque.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesAdditionalCredits;
            
            GameObject talkRoomStephanPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques, "Prime 1 VA"),"Dev_Space_ (8)"),"Dev Smalll placard"),"Canvas (4)");
            Text stephanPlaque1 = GetTextfromGameObject(GetGameObjectChild(talkRoomStephanPlaque,"Text"));
            Text stephanPlaque2 = GetTextfromGameObject(GetGameObjectChild(talkRoomStephanPlaque,"Text (1)"));
            stephanPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesStephanWeyte1;
            stephanPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesStephanWeyte2;
            
            GameObject talkRoomStephanSpoilerScreen = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques, "Prime 1 VA"),"SpoilerBlock"),"PuzzleScreen (1)"),"Canvas"),"Background");
            
            TextMeshProUGUI stephanSpoiler1 = GetTextMeshProUGUI(GetGameObjectChild(talkRoomStephanSpoilerScreen,"Text"));
            stephanSpoiler1.text = "<color=red>!" + LanguageManager.CurrentLanguage.devMuseum.museum_spoiler1 + " !</color>\n" 
            + LanguageManager.CurrentLanguage.devMuseum.museum_spoiler2;
            
            TextMeshProUGUI stephanSpoiler2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(talkRoomStephanSpoilerScreen,"OpenButton"),"Text"));
            stephanSpoiler2.text = LanguageManager.CurrentLanguage.devMuseum.museum_spoiler3;
            
            GameObject talkRoomLenvalPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques, "Prime 2 VA"),"Dev_Space_ (33)"),"Dev Smalll placard"),"Canvas (4)");
            Text lenvalPlaque1 = GetTextfromGameObject(GetGameObjectChild(talkRoomLenvalPlaque,"Text"));
            Text lenvalPlaque2 = GetTextfromGameObject(GetGameObjectChild(talkRoomLenvalPlaque,"Text (1)"));
            lenvalPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLenvalBrown1;
            lenvalPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLenvalBrown2;
            
            GameObject talkRoomLenvalSpoilerScreen = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques, "Prime 2 VA"),"SpoilerBlock"),"PuzzleScreen (1)"),"Canvas"),"Background");
            
            TextMeshProUGUI lenvalSpoiler1 = GetTextMeshProUGUI(GetGameObjectChild(talkRoomLenvalSpoilerScreen,"Text"));
            lenvalSpoiler1.text = "<color=red>!" + LanguageManager.CurrentLanguage.devMuseum.museum_spoiler1 + " !</color>\n" 
            + LanguageManager.CurrentLanguage.devMuseum.museum_spoiler2;
            
            TextMeshProUGUI lenvalSpoiler2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(talkRoomLenvalSpoilerScreen,"OpenButton"),"Text"));
            lenvalSpoiler2.text = LanguageManager.CurrentLanguage.devMuseum.museum_spoiler3;
            
            GameObject restRoomJoyPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (7)"),"Dev Smalll placard"),"Canvas (4)");
            Text joyPlaque1 = GetTextfromGameObject(GetGameObjectChild(restRoomJoyPlaque,"Text"));
            Text joyPlaque2 = GetTextfromGameObject(GetGameObjectChild(restRoomJoyPlaque,"Text (1)"));
            joyPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJoyYoung1;
            joyPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJoyYoung2;
            
            GameObject restRoomMandalorePlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (21)"),"Dev Smalll placard"),"Canvas (4)");
            Text mandalorePlaque1 = GetTextfromGameObject(GetGameObjectChild(restRoomMandalorePlaque,"Text"));
            Text mandalorePlaque2 = GetTextfromGameObject(GetGameObjectChild(restRoomMandalorePlaque,"Text (1)"));
            mandalorePlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMandalore1;
            mandalorePlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMandalore2;
            
            GameObject artRoomGianniPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"dev Space Large (1)"),"Dev Large Placard"),"Canvas (4)");
            Text gianniPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomGianniPlaque,"Text"));
            Text gianniPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomGianniPlaque,"Text (1)"));
            gianniPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesGianniMatragrano1;
            gianniPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesGianniMatragrano2;
            
            GameObject rocketRaceScreen = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("PuzzleScreen (2)"),"Canvas"),"Background"),"Start");
            
            TextMeshProUGUI rocketRaceTitle = GetTextMeshProUGUI(GetGameObjectChild(rocketRaceScreen,"Text"));
            rocketRaceTitle.text = LanguageManager.CurrentLanguage.devMuseum.museum_rocketRace1;
            
            TextMeshProUGUI rocketRaceStart = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(rocketRaceScreen,"OpenButton"),"Text"));
            rocketRaceStart.text = LanguageManager.CurrentLanguage.devMuseum.museum_rocketRace2;
            
            GameObject theater = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("__Room_Theater"),"Ultrakill Projector"),"PuzzleScreen"),"Canvas"),"Background");
            
            TextMeshProUGUI theaterPlay = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(theater,"PlayButton"),"Text"));
            theaterPlay.text = LanguageManager.CurrentLanguage.devMuseum.museum_cinemaPlay;
            
            TextMeshProUGUI theaterStop = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(theater,"StopButton"),"Text"));
            theaterStop.text = LanguageManager.CurrentLanguage.devMuseum.museum_cinemaStop;
            
            
        }
        
        public DevMuseum()
        {
            this.PatchPlaques();
        }
    }
}
