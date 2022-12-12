using System;
using System.IO;
using System.Threading.Tasks;
using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.Networking;
using UltrakULL.json;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.audio
{
    public static class AudioSwapper
    {
        public static string speechFolder = Directory.GetCurrentDirectory() + "\\BepInEx\\config\\ultrakull\\audio\\" + LanguageManager.CurrentLanguage.metadata
        .langName + "\\";
        
        public static AudioClip swapClipWithFile(AudioClip sourceClip, string audioFilePath)
        {
            string file = "file://" + audioFilePath;

            UnityWebRequest fileRequest = UnityWebRequestMultimedia.GetAudioClip(file,AudioType.WAV);
            fileRequest.SendWebRequest();
            try
            {
                while (!fileRequest.isDone) {}
 
                if (fileRequest.isNetworkError || fileRequest.isHttpError) Debug.Log(fileRequest.error + "\n Expected path: " + audioFilePath);
                else
                {
                    sourceClip = DownloadHandlerAudioClip.GetContent(fileRequest);
                    //Console.WriteLine("Audio swap done");
                }
            }
            catch (Exception err)
            {
                Debug.Log("Failed to swap " + audioFilePath);
                Debug.Log($"{err.Message}, {err.StackTrace}");
            }
            return sourceClip;
        }

        public static async void audioSwap(string levelName)
        {
            if(LanguageManager.configFile.Bind("General","activeDubbing","False").Value == "False")
            {
                return;
            }
            //Since the makes a clone of the arena gameObject which is used, wait a small period of time for the new gameObject to be accessible before accessing it.
            speechFolder = Directory.GetCurrentDirectory() + "\\BepInEx\\config\\ultrakull\\audio\\" + LanguageManager.CurrentLanguage.metadata
                .langName + "\\";
                        
            Console.WriteLine("Current lang: " + LanguageManager.CurrentLanguage.metadata.langName);
            Console.WriteLine(speechFolder);
            Console.WriteLine("Waiting before audioSwapper");
            await Task.Delay(250);
        
            Console.WriteLine("In audioSwapper");
            if (levelName == "Level 3-2")
            {
                string gabeFirstFolder = speechFolder + "gabrielBossFirst\\";

                //Intro lines
                GameObject gabeIntroFirst = getInactiveRootObject("gab_Intro1");
                string gabeIntroFirstString = gabeFirstFolder + "gabrielIntro1.wav";

                GameObject gabeIntroSecond = getInactiveRootObject("gab_Intro2");
                string gabeIntroSecondString = gabeFirstFolder + "gabrielIntro2.wav";

                
                //Fight start
                GameObject gabeFightStart = getGameObjectChild(getGameObjectChild(getGameObjectChild(getInactiveRootObject("4 - Heart Chamber"),"4 Stuff(Clone)"),"GabrielOutroParent"),"gab_Intro3");
                string gabeFightStartString = gabeFirstFolder + "gabrielFightStart.wav";
                
                
                //Defeated
                GameObject gabeDefeated = getGameObjectChild(getGameObjectChild(getGameObjectChild(getInactiveRootObject("4 - Heart Chamber"),"4 Stuff(Clone)"),"GabrielOutroParent"),"gab_Intro4");
                string gabeDefeatedString = gabeFirstFolder + "gabrielDefeated.wav";
                
                //Outro
                GameObject gabeOutro = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getInactiveRootObject("4 - Heart Chamber"),"4 Stuff(Clone)"),"OutroLightSound"),"Eyeblood"),"gab_Intro5");
                string gabeOutroString = gabeFirstFolder + "gabrielOutro.wav";
                
                AudioSource gabeIntroFirstSource = gabeIntroFirst.GetComponentInChildren<AudioSource>();
                AudioSource gabeIntroSecondSource = gabeIntroSecond.GetComponentInChildren<AudioSource>();
                AudioSource gabeFightStartSource = gabeFightStart.GetComponentInChildren<AudioSource>();
                AudioSource gabeDefeatedSource = gabeDefeated.GetComponentInChildren<AudioSource>();
                AudioSource gabeOutroSource = gabeOutro.GetComponentInChildren<AudioSource>();

                gabeIntroFirstSource.clip =  swapClipWithFile(gabeIntroFirstSource.clip, gabeIntroFirstString);
                gabeIntroSecondSource.clip =  swapClipWithFile(gabeIntroSecondSource.clip, gabeIntroSecondString);
                gabeFightStartSource.clip =  swapClipWithFile(gabeFightStartSource.clip, gabeFightStartString);
                gabeDefeatedSource.clip =  swapClipWithFile(gabeDefeatedSource.clip, gabeDefeatedString);
                gabeOutroSource.clip =  swapClipWithFile(gabeOutroSource.clip, gabeOutroString);

            }
            else if(levelName == "Level P-1")
            {
                string minosPrimeFolder = speechFolder + "minosPrime\\";
                
                GameObject minosPrimeArena = getInactiveRootObject("3 - Fuckatorium");
            
                //Intro lines
                GameObject minosPrimeIntro = getGameObjectChild(getGameObjectChild(getGameObjectChild(minosPrimeArena,"3 Stuff(Clone)"),"MinosPrimeIntro"),"Voice");
                string minosPrimeIntroString = minosPrimeFolder + "minosPrimeIntro.wav";
                
                AudioSource minosPrimeIntroSource = minosPrimeIntro.GetComponentInChildren<AudioSource>();
                minosPrimeIntroSource.clip = swapClipWithFile(minosPrimeIntroSource.clip, minosPrimeIntroString);
                
                //Respawn taunt - need to do both original and clone
                GameObject minosPrimeRespawn = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(minosPrimeArena,"3 Stuff(Clone)"),"MinosPrimeWave"),"MinosPrime"),"Useless");
                string minosPrimeRespawnString = minosPrimeFolder + "minosPrimeRespawn.wav";
                
                AudioSource minosPrimeRespawnSource = minosPrimeRespawn.GetComponentInChildren<AudioSource>();
                minosPrimeRespawnSource.clip = swapClipWithFile(minosPrimeRespawnSource.clip, minosPrimeRespawnString);
                
                GameObject minosPrimeRespawnOrig = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(minosPrimeArena,"3 Stuff"),
                "MinosPrimeWave"),"MinosPrime"),"Useless");
                string minosPrimeRespawnStringOrig = minosPrimeFolder + "minosPrimeRespawn.wav";
                
                AudioSource minosPrimeRespawnSourceOrig = minosPrimeRespawnOrig.GetComponentInChildren<AudioSource>();
                minosPrimeRespawnSourceOrig.clip = swapClipWithFile(minosPrimeRespawnSourceOrig.clip, minosPrimeRespawnStringOrig);


                //Defeated lines
                GameObject minosPrimeDefeated = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(minosPrimeArena,"3 Stuff(Clone)"),"MinosPrimeWave"), "MinosPrime"),"Outro");
                string minosPrimeDefeatedString = minosPrimeFolder + "minosPrimeDefeated.wav";
                
                AudioSource minosPrimeDefeatedSource = minosPrimeDefeated.GetComponentInChildren<AudioSource>();
                minosPrimeDefeatedSource.clip = swapClipWithFile(minosPrimeDefeatedSource.clip, minosPrimeDefeatedString);
                
                GameObject minosPrimeDefeatedOrig = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(minosPrimeArena,"3 Stuff"),
                "MinosPrimeWave"), "MinosPrime"),"Outro");
                string minosPrimeDefeatedOrigString = minosPrimeFolder + "minosPrimeDefeated.wav";
                
                AudioSource minosPrimeDefeatedOrigSource = minosPrimeDefeatedOrig.GetComponentInChildren<AudioSource>();
                minosPrimeDefeatedOrigSource.clip = swapClipWithFile(minosPrimeDefeatedOrigSource.clip, minosPrimeDefeatedOrigString);
                
                
                //Scream (note: Scream plays as soon as Defeated is finished playing. So files need to be of correct length to sync with each other correctly)
                GameObject minosPrimeScream = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(minosPrimeArena,"3 Stuff(Clone)"),"MinosPrimeWave"), "MinosPrime"),"DeathScream");
                string minosPrimeScreamString = minosPrimeFolder + "minosPrimeScream.wav";
                
                AudioSource minosPrimeScreamSource = minosPrimeScream.GetComponentInChildren<AudioSource>();
                minosPrimeScreamSource.clip = swapClipWithFile(minosPrimeScreamSource.clip, minosPrimeScreamString);
                
                GameObject minosPrimeScreamOrig = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(minosPrimeArena,"3 Stuff")
                ,"MinosPrimeWave"), "MinosPrime"),"DeathScream");
                string minosPrimeScreamStringOrig = minosPrimeFolder + "minosPrimeScream.wav";
                
                AudioSource minosPrimeScreamSourceOrig = minosPrimeScreamOrig.GetComponentInChildren<AudioSource>();
                minosPrimeScreamSourceOrig.clip = swapClipWithFile(minosPrimeScreamSourceOrig.clip, minosPrimeScreamStringOrig);
            }
            else if (levelName == "Level 4-3")
            {
                //There are two used clips for intro, one for Mandalore, the other for the owl.
                //I can't find where the owl clip is though...

                string mandaloreFolder = speechFolder + "mandalore\\";
                
                GameObject mandaloreArena = getGameObjectChild(getInactiveRootObject("3 - Traitor Hallway"),"3B - Tomb of Kings");

                GameObject mandaloreIntro = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(mandaloreArena,"3B Stuff"),"Hall"),"FakeMandalore"),"IntroLine");
                string mandaloreIntroString = mandaloreFolder + "mandaloreIntro.wav";
                
                AudioSource mandaloreIntroSource = mandaloreIntro.GetComponentInChildren<AudioSource>();
                mandaloreIntroSource.clip = swapClipWithFile(mandaloreIntroSource.clip, mandaloreIntroString);
            }
            
            else if (levelName == "Level 5-3")
            {
                string gabeBoatFolder = speechFolder + "gabrielBoat\\";
                
                GameObject gabeBoatSpeechObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getInactiveRootObject("Unrotated"),"5 - Hologram Rooms"),"5 Nonstuff"),"Decorations"), "Hologram");
                
                AudioSource gabeBoat = gabeBoatSpeechObject.GetComponentInChildren<AudioSource>();
                
                string gabeBoatString = gabeBoatFolder + "gabrielBoat.wav";
                
                gabeBoat.clip = swapClipWithFile(gabeBoat.clip, gabeBoatString);
            }
            else if (levelName == "Level 6-1")
            {
                string gabeHeresyFolder = speechFolder + "gabrielHeresy\\";
                
                GameObject gabeHeresyFirst = getInactiveRootObject("GabrielVoice1");
                GameObject gabeHeresySecond = getInactiveRootObject("GabrielVoice2");
                
                AudioSource gabeHeresyFirstSource = gabeHeresyFirst.GetComponentInChildren<AudioSource>();
                AudioSource gabeHeresySecondSource = gabeHeresySecond.GetComponentInChildren<AudioSource>();
                
                string gabeHeresyFirstString = speechFolder + "gabrielHeresyFirst.wav";
                string gabeHeresySecondString = speechFolder + "gabrielHeresySecond.wav";
                
                gabeHeresyFirstSource.clip = swapClipWithFile(gabeHeresyFirstSource.clip,gabeHeresyFirstString);
                gabeHeresySecondSource.clip = swapClipWithFile(gabeHeresySecondSource.clip,gabeHeresySecondString);
            }
            else if (levelName == "Level 6-2")
            {
                string gabeSecondFolder = speechFolder + "gabrielBossSecond\\";
                
                //Intro lines
                GameObject gabeSecondSpeechObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(getInactiveRootObject("IntroSounds"),"Filler"),
                "Speech and Music"),"Speech");
                
                AudioSource gabeSecondSpeech = gabeSecondSpeechObject.GetComponentInChildren<AudioSource>();
                string gabeSecondSpeechString = gabeSecondFolder + "gabrielSecondIntro.wav";
                
                gabeSecondSpeech.clip = swapClipWithFile(gabeSecondSpeech.clip,gabeSecondSpeechString);
                
                //Fight start lines
                GameObject gabeSecondFightStartObject = getGameObjectChild(getGameObjectChild(getInactiveRootObject("2 - Organ Hall"),"2 Stuff(Clone)"),"Intro");
                
                AudioSource gabeSecondFightStart = gabeSecondFightStartObject.GetComponentInChildren<AudioSource>();
                string gabeSecondFightStartString = gabeSecondFolder + "gabrielSecondFightStart.wav";
                
                gabeSecondFightStart.clip = swapClipWithFile(gabeSecondFightStart.clip,gabeSecondFightStartString);
                
                //Defeated lines
                GameObject gabeSecondDefeated = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getInactiveRootObject("2 - Organ Hall"),"2 Stuff(Clone)"), "GabrielOutroParent"),"GabrielOutro"),"OutroVoice");
                
                AudioSource gabeSecondDefeatedSource = gabeSecondDefeated.GetComponentInChildren<AudioSource>();
                string gabeSecondDefeatedString = gabeSecondFolder + "gabrielSecondDefeated.wav";
                
                gabeSecondDefeatedSource.clip = swapClipWithFile(gabeSecondDefeatedSource.clip,gabeSecondDefeatedString);
                
                GameObject gabeSecondDefeatedOrig = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getInactiveRootObject("2 - Organ Hall"),"2 Stuff"), "GabrielOutroParent"),"GabrielOutro"),"OutroVoice");
                
                AudioSource gabeSecondDefeatedSourceOrig = gabeSecondDefeatedOrig.GetComponentInChildren<AudioSource>();
                string gabeSecondDefeatedStringOrig = gabeSecondFolder + "gabrielSecondDefeated.wav";
                
                gabeSecondDefeatedSourceOrig.clip = swapClipWithFile(gabeSecondDefeatedSourceOrig.clip,gabeSecondDefeatedStringOrig);

                //Outro lines
                GameObject gabeSecondOutro =  getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getInactiveRootObject("2 - Organ Hall"),"2 Stuff(Clone)"), "GabrielOutroParent"),"EndShatter"),"gab_Intro5");
                
                AudioSource gabeSecondOutroSource = gabeSecondOutro.GetComponentInChildren<AudioSource>();
                string gabeSecondOutroString = gabeSecondFolder + "gabrielSecondOutro.wav";
                
                gabeSecondOutroSource.clip = swapClipWithFile(gabeSecondOutroSource.clip,gabeSecondOutroString);
                
                GameObject gabeSecondOutroOrig =  getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getInactiveRootObject("2 - Organ Hall"),"2 Stuff(Clone)"), "GabrielOutroParent"),"EndShatter"),"gab_Intro5");
                
                AudioSource gabeSecondOutroSourceOrig = gabeSecondOutroOrig.GetComponentInChildren<AudioSource>();
                string gabeSecondOutroStringOrig = gabeSecondFolder + "gabrielSecondOutro.wav";
                
                gabeSecondOutroSourceOrig.clip = swapClipWithFile(gabeSecondOutroSourceOrig.clip,gabeSecondOutroStringOrig);
            }
        }
        
        
    }
}