using System.Collections.Generic;
using System.Linq;
using Antlr4.StringTemplate;
using Newtonsoft.Json;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public class DevMuseum
    {
        private static readonly TemplateGroup DevMuseumTemplates = new TemplateGroupString(Resources.DevMuseum);
        private static readonly Dictionary<string, string> BookSamplePerTemplateId;

        static DevMuseum()
        {
            DevMuseumTemplates.EnableCache = false;
            DevMuseumTemplates.SetDelimiters('$', '$');
            var mapperDefinition = new
            {
                books = new Dictionary<string, string>(),
            };
            BookSamplePerTemplateId  = JsonConvert.DeserializeAnonymousType(Resources.MuseumBooks, mapperDefinition).books;
        }

        public static string GetMuseumBook(string originalText)
        {
            var templatePattern = BookSamplePerTemplateId.Keys.FirstOrDefault(originalText.Contains);
            if (templatePattern == default || !BookSamplePerTemplateId.TryGetValue(templatePattern, out var templateName))
                return string.Empty;
            
            var template = DevMuseumTemplates.GetInstanceOf(templateName);

            return template != null
                ? template
                    .Add("devMuseum", LanguageManager.CurrentLanguage.devMuseum)
                    .Add("metadata", LanguageManager.CurrentLanguage.metadata)
                    .Render()
                : string.Empty;
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
            
            Text stephanSpoiler1 = GetTextfromGameObject(GetGameObjectChild(talkRoomStephanSpoilerScreen,"Text"));
            stephanSpoiler1.text = "<color=red>!" + LanguageManager.CurrentLanguage.devMuseum.museum_spoiler1 + " !</color>\n" 
            + LanguageManager.CurrentLanguage.devMuseum.museum_spoiler2;
            
            Text stephanSpoiler2 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(talkRoomStephanSpoilerScreen,"OpenButton"),"Text"));
            stephanSpoiler2.text = LanguageManager.CurrentLanguage.devMuseum.museum_spoiler3;
            
            GameObject talkRoomLenvalPlaque =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques, "Prime 2 VA"),"Dev_Space_ (33)"),"Dev Smalll placard"),"Canvas (4)");
            Text lenvalPlaque1 = GetTextfromGameObject(GetGameObjectChild(talkRoomLenvalPlaque,"Text"));
            Text lenvalPlaque2 = GetTextfromGameObject(GetGameObjectChild(talkRoomLenvalPlaque,"Text (1)"));
            lenvalPlaque1.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLenvalBrown1;
            lenvalPlaque2.text = LanguageManager.CurrentLanguage.devMuseum.museum_plaquesLenvalBrown2;
            
            GameObject talkRoomLenvalSpoilerScreen = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(plaques, "Prime 2 VA"),"SpoilerBlock"),"PuzzleScreen (1)"),"Canvas"),"Background");
            
            Text lenvalSpoiler1 = GetTextfromGameObject(GetGameObjectChild(talkRoomLenvalSpoilerScreen,"Text"));
            lenvalSpoiler1.text = "<color=red>!" + LanguageManager.CurrentLanguage.devMuseum.museum_spoiler1 + " !</color>\n" 
            + LanguageManager.CurrentLanguage.devMuseum.museum_spoiler2;
            
            Text lenvalSpoiler2 = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(talkRoomLenvalSpoilerScreen,"OpenButton"),"Text"));
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
        
        public DevMuseum()
        {
            PatchPlaques();
        }
    }
}