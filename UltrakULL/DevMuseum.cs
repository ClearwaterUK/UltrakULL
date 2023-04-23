using System;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public class DevMuseum
    {
        public static string getMuseumBook(string originalText)
        {
            if(originalText.Contains("<b><color=orange>HAKITA</color> - CREATOR OF ULTRAKILL</b>"))
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
            if(originalText.Contains("<b><color=#4AACBD>FRANCIS XIE</color> - CONCEPT AND TEXTURE ARTIST</b>"))
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
            if(originalText.Contains("<b><color=#5cc6f1>JERICHO_RUS</color> - ILLUSTRATOR, CONCEPT AND TEXTURE ARTIST</b>"))
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
            if(originalText.Contains("<b><color=#DA6B6D>BIGROCKBMP</color> - CONCEPT ARTIST</b>"))
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
            if(originalText.Contains("<b><color=#8f65da>MAXIMILIAN OVESSON</color> - UI ARTIST</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookMaximilianOvesson1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookMaximilianOvesson2 + "\n\n"
                    + "<color=#8f65da>" +  LanguageManager.CurrentLanguage.devMuseum.museum_bookMaximilianOvesson3 + "</color>\n\n";
            }
            if(originalText.Contains("<b><color=#F5ABB9>VICTORIA HOLLAND</color> - LEAD 3D ARTIST AND GRAPHICS PROGRAMMER</b>"))
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
            if(originalText.Contains("<b><color=orange>TONI STIGELL</color> - 3D ARTIST</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell2 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell3 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell4 + "\n\n"
                    + "<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell5 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell6 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookToniStigell7 + "</size>";
                    
            }

                return "";
        }
        
        
        public void patchPlaques()
        {
            //Since the dev museum uses unconventional gameObject names compared to the rest of the game, GetChild is primarily used here.
            
            GameObject museum = GetInactiveRootObject("__Room_Courtyard").transform.GetChild(4).GetChild(0).gameObject;
            Text museumTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(museum,"Canvas (2)"),"Text"));
            museumTitle.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMuseumTitle;
            
            
            GameObject lobbyRoom = GetInactiveRootObject("__Room_FrontDesk_1").transform.GetChild(1).gameObject;

            GameObject lobbyRoomHakitaPlaque = lobbyRoom.transform.GetChild(58).gameObject;
            GameObject lobbyRoomArtRoomPlaque = lobbyRoom.transform.GetChild(0).gameObject;
            GameObject lobbyRoomNerdRoomPlaque = lobbyRoom.transform.GetChild(1).gameObject;
            
            Console.WriteLine(lobbyRoomHakitaPlaque.name);
            
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
            Text FrancisPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomFrancisPlaque,"Text"));
            Text FrancisPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomFrancisPlaque,"Text (1)"));
            FrancisPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesFrancisXie1;
            FrancisPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesFrancisXie2;
            
            GameObject artRoomJerichoPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (14)"),"Dev Smalll placard"),"Canvas (4)");
            Text JerichoPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomJerichoPlaque,"Text"));
            Text JerichoPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomJerichoPlaque,"Text (1)"));
            JerichoPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJerichoRus1;
            JerichoPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJerichoRus2;
            
            GameObject artRoomBigrockPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (12)"),"Dev Smalll placard"),"Canvas (4)");
            Text BigrockPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomBigrockPlaque,"Text"));
            Text BigrockPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomBigrockPlaque,"Text (1)"));
            BigrockPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesBigRockBMP1;
            BigrockPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesBigRockBMP2;
            
            GameObject artRoomMaximilianPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (15)"),"Dev Smalll placard"),"Canvas (4)");
            Text MaximilianPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomMaximilianPlaque,"Text"));
            Text MaximilianPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomMaximilianPlaque,"Text (1)"));
            MaximilianPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMaxOvesson1;
            MaximilianPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMaxOvesson2;
            
            GameObject artRoomVictoriaPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"dev Space Large"),"Dev Large Placard"),"Canvas (4)");
            Text VictoriaPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomVictoriaPlaque,"Text"));
            Text VictoriaPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomVictoriaPlaque,"Text (1)"));
            VictoriaPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVictoriaHolland1;
            VictoriaPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVictoriaHolland2;
            
            GameObject artRoomToniPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (23)"),"Dev Smalll placard"),"Canvas (4)");
            Text ToniPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomToniPlaque,"Text"));
            Text ToniPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomToniPlaque,"Text (1)"));
            ToniPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesToniStigell1;
            ToniPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesToniStigell2;
            
            GameObject artRoomFlyingdogPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (24)"),"Dev Smalll placard"),"Canvas (4)");
            Text FlyingdogPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomFlyingdogPlaque,"Text"));
            Text FlyingdogPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomFlyingdogPlaque,"Text (1)"));
            FlyingdogPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesFlyingdog1;
            FlyingdogPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesFlyingdog2;
            
            GameObject artRoomSamuelPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (22)"),"Dev Smalll placard"),"Canvas (4)");
            Text SamuelPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomSamuelPlaque,"Text"));
            Text SamuelPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomSamuelPlaque,"Text (1)"));
            SamuelPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesSamuelJamesBryan1;
            SamuelPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesSamuelJamesBryan1;
            
            GameObject artRoomCameronPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (19)"),"Dev Smalll placard"),"Canvas (4)");
            Text CameronPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomCameronPlaque,"Text"));
            Text CameronPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomCameronPlaque,"Text (1)"));
            CameronPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesCameronMartin1;
            CameronPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesCameronMartin2;
            
            GameObject artRoomDaliaPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (16)"),"Dev Smalll placard"),"Canvas (4)");
            Text DaliaPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomDaliaPlaque,"Text"));
            Text DaliaPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomDaliaPlaque,"Text (1)"));
            DaliaPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaliaFigueroa1;
            DaliaPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaliaFigueroa2;
            
            GameObject artRoomTuckerPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (18)"),"Dev Smalll placard"),"Canvas (4)");
            Text TuckerPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomTuckerPlaque,"Text"));
            Text TuckerPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomTuckerPlaque,"Text (1)"));
            TuckerPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaliaFigueroa1;
            TuckerPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaliaFigueroa2;
            
            GameObject artRoomScottPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (17)"),"Dev Smalll placard"),"Canvas (4)");
            Text ScottPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomScottPlaque,"Text"));
            Text ScottPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomScottPlaque,"Text (1)"));
            ScottPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesScottGurney1;
            ScottPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesScottGurney2;
            
            GameObject artRoomPitrPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"dev Space Large (2)"),"Dev Large Placard"),"Canvas (4)");
            Text PitrPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomPitrPlaque,"Text"));
            Text PitrPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomPitrPlaque,"Text (1)"));
            PitrPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesPitr1;
            PitrPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesPitr2;
            
            GameObject artRoomHeckteckPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (11)"),"Dev Smalll placard"),"Canvas (4)");
            Text HeckteckPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomHeckteckPlaque,"Text"));
            Text HeckteckPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomHeckteckPlaque,"Text (1)"));
            HeckteckPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHeckteck1;
            HeckteckPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesHeckteck2;
            
            GameObject artRoomCabalcrowPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (10)"),"Dev Smalll placard"),"Canvas (4)");
            Text CabalcrowPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomCabalcrowPlaque,"Text"));
            Text CabalcrowPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomCabalcrowPlaque,"Text (1)"));
            CabalcrowPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesCabalcrow1;
            CabalcrowPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesCabalcrow2;
            
            GameObject artRoomLucasPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (9)"),"Dev Smalll placard"),"Canvas (4)");
            Text LucasPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomLucasPlaque,"Text"));
            Text LucasPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomLucasPlaque,"Text (1)"));
            LucasPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLucasVarney1;
            LucasPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLucasVarney2;
            
            GameObject artRoomBenMoirPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (1)"),"Dev Smalll placard"),"Canvas (4)");
            Text BenPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomBenMoirPlaque,"Text"));
            Text BenPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomBenMoirPlaque,"Text (1)"));
            BenPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesBenMoir1;
            BenPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesBenMoir2;
            
            GameObject centralHall = GetInactiveRootObject("__Room_Large_Lower").transform.GetChild(4).gameObject;
            Text DavePlaque1 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(centralHall,"Wing name (4)"),"Canvas (5)"),"Text"));
            Text DavePlaque2 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(centralHall,"Wing name (4)"),"Canvas (5)"),"Text (1)"));
            
            DavePlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaveOshry1;
            DavePlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesDaveOshry2;
            
            GameObject centralHallSigns = GetInactiveRootObject("__Room_Large_Lower").transform.GetChild(3).gameObject;
            
            GameObject restRoomSign = centralHallSigns.transform.GetChild(9).gameObject;
            GameObject talkRoomSign = centralHallSigns.transform.GetChild(10).gameObject;
            
            Text RestRoomPlaque = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(restRoomSign,"Canvas (3)"),"Text"));
            RestRoomPlaque.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesRestRoom;
            
            Text TalkRoomPlaque = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(talkRoomSign,"Canvas (3)"),"Text"));
            TalkRoomPlaque.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesRestRoom;
            
            GameObject RestRoomMeganekoPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (3)"),"Dev Smalll placard"),"Canvas (4)");
            Text MeganekoPlaque1 = GetTextfromGameObject(GetGameObjectChild(RestRoomMeganekoPlaque,"Text"));
            Text MeganekoPlaque2 = GetTextfromGameObject(GetGameObjectChild(RestRoomMeganekoPlaque,"Text (1)"));
            MeganekoPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMeganeko1;
            MeganekoPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMeganeko2;
            
            GameObject RestRoomKeygenChurchPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (2)"),"Dev Smalll placard"),"Canvas (4)");
            Text KeygenPlaque1 = GetTextfromGameObject(GetGameObjectChild(RestRoomKeygenChurchPlaque,"Text"));
            Text KeygenPlaque2 = GetTextfromGameObject(GetGameObjectChild(RestRoomKeygenChurchPlaque,"Text (1)"));
            KeygenPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesKeygenChurch1;
            KeygenPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesKeygenChurch2;
            
            GameObject RestRoomSaladPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (4)"),"Dev Smalll placard"),"Canvas (4)");
            Text SaladPlaque1 = GetTextfromGameObject(GetGameObjectChild(RestRoomSaladPlaque,"Text"));
            Text SaladPlaque2 = GetTextfromGameObject(GetGameObjectChild(RestRoomSaladPlaque,"Text (1)"));
            SaladPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesSalad1;
            SaladPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesSalad2;
            
            GameObject RestRoomJacobPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (5)"),"Dev Smalll placard"),"Canvas (4)");
            Text JacobPlaque1 = GetTextfromGameObject(GetGameObjectChild(RestRoomJacobPlaque,"Text"));
            Text JacobPlaque2 = GetTextfromGameObject(GetGameObjectChild(RestRoomJacobPlaque,"Text (1)"));
            JacobPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJacobHHR1;
            JacobPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJacobHHR2;
            
            GameObject RestRoomJVVizardPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (6)"),"Dev Smalll placard"),"Canvas (4)");
            Text VVizardPlaque1 = GetTextfromGameObject(GetGameObjectChild(RestRoomJVVizardPlaque,"Text"));
            Text VVizardPlaque2 = GetTextfromGameObject(GetGameObjectChild(RestRoomJVVizardPlaque,"Text (1)"));
            VVizardPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVVizard1;
            VVizardPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesVVizard2;
            
            GameObject RedRoomAdditionalMusicPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (25)"),"Dev Smalll placard"),"Canvas (4)");
            GameObject RedRoomAdditionalCreditsPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (25)"),"Dev Smalll placard (1)"),"Canvas (4)");
            Text AdditionalMusicPlaque = GetTextfromGameObject(GetGameObjectChild(RedRoomAdditionalMusicPlaque,"Text"));
            AdditionalMusicPlaque.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesAdditionalMusic;
            Text AdditionalCreditsPlaque = GetTextfromGameObject(GetGameObjectChild(RedRoomAdditionalCreditsPlaque,"Text"));
            AdditionalCreditsPlaque.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesAdditionalCredits;
            
            GameObject TalkRoomStephanPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques, "Prime 1 VA"),"Dev_Space_ (8)"),"Dev Smalll placard"),"Canvas (4)");
            Text StephanPlaque1 = GetTextfromGameObject(GetGameObjectChild(TalkRoomStephanPlaque,"Text"));
            Text StephanPlaque2 = GetTextfromGameObject(GetGameObjectChild(TalkRoomStephanPlaque,"Text (1)"));
            StephanPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesStephanWeyte1;
            StephanPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesStephanWeyte2;
            
            GameObject TalkRoomLenvalPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques, "Prime 2 VA"),"Dev_Space_ (33)"),"Dev Smalll placard"),"Canvas (4)");
            Text LenvalPlaque1 = GetTextfromGameObject(GetGameObjectChild(TalkRoomLenvalPlaque,"Text"));
            Text LenvalPlaque2 = GetTextfromGameObject(GetGameObjectChild(TalkRoomLenvalPlaque,"Text (1)"));
            LenvalPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLenvalBrown1;
            LenvalPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLenvalBrown2;
            
            GameObject RestRoomJoyPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (7)"),"Dev Smalll placard"),"Canvas (4)");
            Text JoyPlaque1 = GetTextfromGameObject(GetGameObjectChild(RestRoomJoyPlaque,"Text"));
            Text JoyPlaque2 = GetTextfromGameObject(GetGameObjectChild(RestRoomJoyPlaque,"Text (1)"));
            JoyPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJoyYoung1;
            JoyPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesJoyYoung2;
            
            GameObject RestRoomMandalorePlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"Dev_Space_ (21)"),"Dev Smalll placard"),"Canvas (4)");
            Text MandalorePlaque1 = GetTextfromGameObject(GetGameObjectChild(RestRoomMandalorePlaque,"Text"));
            Text MandalorePlaque2 = GetTextfromGameObject(GetGameObjectChild(RestRoomMandalorePlaque,"Text (1)"));
            MandalorePlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMandalore1;
            MandalorePlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesMandalore2;
            
            GameObject artRoomGianniPlaque = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques,"dev Space Large (1)"),"Dev Large Placard"),"Canvas (4)");
            Text GianniPlaque1 = GetTextfromGameObject(GetGameObjectChild(artRoomGianniPlaque,"Text"));
            Text GianniPlaque2 = GetTextfromGameObject(GetGameObjectChild(artRoomGianniPlaque,"Text (1)"));
            GianniPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesGianniMatragrano1;
            GianniPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesGianniMatragrano2;
            
            GameObject rocketRaceScreen = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("PuzzleScreen (2)"),"Canvas"),"Background"),"Start");
            
            Text rocketRaceTitle = GetTextfromGameObject(GetGameObjectChild(rocketRaceScreen,"Text"));
            rocketRaceTitle.text = LanguageManager.CurrentLanguage.devMuseum.museum_rocketRace1;
            
            Text rocketRaceStart = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(rocketRaceScreen,"OpenButton"),"Text"));
            rocketRaceStart.text = LanguageManager.CurrentLanguage.devMuseum.museum_rocketRace2;
            
            GameObject theater = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("__Room_Theater"),"Ultrakill Projector"),"PuzzleScreen"),"Canvas"),"Background");
            
            Text theaterPlay = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(theater,"PlayButton"),"Text"));
            theaterPlay.text = LanguageManager.CurrentLanguage.devMuseum.museum_cinemaPlay;
            
            Text theaterStop = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(theater,"StopButton"),"Text"));
            theaterStop.text = LanguageManager.CurrentLanguage.devMuseum.museum_cinemaStop;
            
            
        }
        
        public DevMuseum(ref GameObject canvas)
        {
            this.patchPlaques();
        }
    }
}