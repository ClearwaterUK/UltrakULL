using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.audio
{
    public static class AudioSwapper
    {
        public static string SpeechFolder = Path.Combine(Directory.GetCurrentDirectory(), "BepInEx", "config", "ultrakull", "audio", LanguageManager.CurrentLanguage.metadata
        .langName) + Path.DirectorySeparatorChar;
        
        public static AudioClip SwapClipWithFile(AudioClip sourceClip, string audioFilePath)
        {
            string file = "file://" + audioFilePath;
            Logging.Message("Swapping: " + file);

            UnityWebRequest fileRequest = UnityWebRequestMultimedia.GetAudioClip(file,AudioType.WAV);
            fileRequest.SendWebRequest();
            try
            {
                while (!fileRequest.isDone) {}
 
                if (fileRequest.isNetworkError || fileRequest.isHttpError) Logging.Warn(fileRequest.error + "\n Expected path: " + audioFilePath);
                else
                {
                    sourceClip = DownloadHandlerAudioClip.GetContent(fileRequest);
                }
            }
            catch (Exception err)
            {
                Logging.Warn("Failed to swap " + audioFilePath);
                Logging.Warn($"{err.Message}, {err.StackTrace}");
            }
            return sourceClip;
        }

        public static async void AudioSwap(string levelName)
        {
            Console.WriteLine("Level: " + levelName);
            if(LanguageManager.configFile.Bind("General","activeDubbing","False").Value == "False")
            {
                return;
            }
            
            SpeechFolder = Path.Combine(Directory.GetCurrentDirectory(), "BepInEx", "config", "ultrakull", "audio", LanguageManager.CurrentLanguage.metadata
                .langName) + Path.DirectorySeparatorChar;
            
            //Since the makes a clone of the arena gameObject which is used, wait a small period of time for the new gameObject to be accessible before accessing it.
            await Task.Delay(250);
            
            if (levelName == "Level 3-2")
            {
                string gabeFirstFolder = SpeechFolder + "gabrielBossFirst" + Path.DirectorySeparatorChar;

                //Intro lines
                GameObject gabeIntroFirst = GetInactiveRootObject("gab_Intro1");
                string gabeIntroFirstString = gabeFirstFolder + "gabrielIntro1.wav";

                GameObject gabeIntroSecond = GetInactiveRootObject("gab_Intro2");
                string gabeIntroSecondString = gabeFirstFolder + "gabrielIntro2.wav";

                
                //Fight start
                GameObject gabeFightStart = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("4 - Heart Chamber"),"4 Stuff(Clone)"),"GabrielOutroParent"),"gab_Intro3");
                string gabeFightStartString = gabeFirstFolder + "gabrielFightStart.wav";
                
                
                //Defeated
                GameObject gabeDefeated = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("4 - Heart Chamber"),"4 Stuff(Clone)"),"GabrielOutroParent"),"gab_Intro4");
                string gabeDefeatedString = gabeFirstFolder + "gabrielDefeated.wav";
                
                //Outro
                GameObject gabeOutro = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("4 - Heart Chamber"),"4 Stuff(Clone)"),"OutroLightSound"),"Eyeblood"),"gab_Intro5");
                string gabeOutroString = gabeFirstFolder + "gabrielOutro.wav";
                
                AudioSource gabeIntroFirstSource = gabeIntroFirst.GetComponentInChildren<AudioSource>();
                AudioSource gabeIntroSecondSource = gabeIntroSecond.GetComponentInChildren<AudioSource>();
                AudioSource gabeFightStartSource = gabeFightStart.GetComponentInChildren<AudioSource>();
                AudioSource gabeDefeatedSource = gabeDefeated.GetComponentInChildren<AudioSource>();
                AudioSource gabeOutroSource = gabeOutro.GetComponentInChildren<AudioSource>();

                gabeIntroFirstSource.clip =  SwapClipWithFile(gabeIntroFirstSource.clip, gabeIntroFirstString);
                gabeIntroSecondSource.clip =  SwapClipWithFile(gabeIntroSecondSource.clip, gabeIntroSecondString);
                gabeFightStartSource.clip =  SwapClipWithFile(gabeFightStartSource.clip, gabeFightStartString);
                gabeDefeatedSource.clip =  SwapClipWithFile(gabeDefeatedSource.clip, gabeDefeatedString);
                gabeOutroSource.clip =  SwapClipWithFile(gabeOutroSource.clip, gabeOutroString);

            }
            else if(levelName == "Level P-1")
            {
                string minosPrimeFolder = SpeechFolder + "minosPrime" + Path.DirectorySeparatorChar;
                
                GameObject minosPrimeArena = GetInactiveRootObject("3 - Fuckatorium");
            
                //Intro lines
                GameObject minosPrimeIntro = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(minosPrimeArena,"3 Stuff(Clone)"),"MinosPrimeIntro"),"Voice");
                string minosPrimeIntroString = minosPrimeFolder + "minosPrimeIntro.wav";
                
                AudioSource minosPrimeIntroSource = minosPrimeIntro.GetComponentInChildren<AudioSource>();
                minosPrimeIntroSource.clip = SwapClipWithFile(minosPrimeIntroSource.clip, minosPrimeIntroString);
                
                //Respawn taunt - need to do both original and clone
                GameObject minosPrimeRespawn = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(minosPrimeArena,"3 Stuff(Clone)"),"MinosPrimeWave"),"MinosPrime"),"Useless");
                string minosPrimeRespawnString = minosPrimeFolder + "minosPrimeRespawn.wav";
                
                AudioSource minosPrimeRespawnSource = minosPrimeRespawn.GetComponentInChildren<AudioSource>();
                minosPrimeRespawnSource.clip = SwapClipWithFile(minosPrimeRespawnSource.clip, minosPrimeRespawnString);
                
                GameObject minosPrimeRespawnOrig = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(minosPrimeArena,"3 Stuff"),
                "MinosPrimeWave"),"MinosPrime"),"Useless");
                string minosPrimeRespawnStringOrig = minosPrimeFolder + "minosPrimeRespawn.wav";
                
                AudioSource minosPrimeRespawnSourceOrig = minosPrimeRespawnOrig.GetComponentInChildren<AudioSource>();
                minosPrimeRespawnSourceOrig.clip = SwapClipWithFile(minosPrimeRespawnSourceOrig.clip, minosPrimeRespawnStringOrig);


                //Defeated lines
                GameObject minosPrimeDefeated = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(minosPrimeArena,"3 Stuff(Clone)"),"MinosPrimeWave"), "MinosPrime"),"Outro");
                string minosPrimeDefeatedString = minosPrimeFolder + "minosPrimeDefeated.wav";
                
                AudioSource minosPrimeDefeatedSource = minosPrimeDefeated.GetComponentInChildren<AudioSource>();
                minosPrimeDefeatedSource.clip = SwapClipWithFile(minosPrimeDefeatedSource.clip, minosPrimeDefeatedString);
                
                GameObject minosPrimeDefeatedOrig = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(minosPrimeArena,"3 Stuff"),
                "MinosPrimeWave"), "MinosPrime"),"Outro");
                string minosPrimeDefeatedOrigString = minosPrimeFolder + "minosPrimeDefeated.wav";
                
                AudioSource minosPrimeDefeatedOrigSource = minosPrimeDefeatedOrig.GetComponentInChildren<AudioSource>();
                minosPrimeDefeatedOrigSource.clip = SwapClipWithFile(minosPrimeDefeatedOrigSource.clip, minosPrimeDefeatedOrigString);
                
                
                //Scream (note: Scream plays as soon as Defeated is finished playing. So files need to be of correct length to sync with each other correctly)
                GameObject minosPrimeScream = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(minosPrimeArena,"3 Stuff(Clone)"),"MinosPrimeWave"), "MinosPrime"),"DeathScream");
                string minosPrimeScreamString = minosPrimeFolder + "minosPrimeDeathScream.wav";
                
                AudioSource minosPrimeScreamSource = minosPrimeScream.GetComponentInChildren<AudioSource>();
                minosPrimeScreamSource.clip = SwapClipWithFile(minosPrimeScreamSource.clip, minosPrimeScreamString);
                
                GameObject minosPrimeScreamOrig = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(minosPrimeArena,"3 Stuff")
                ,"MinosPrimeWave"), "MinosPrime"),"DeathScream");
                string minosPrimeScreamStringOrig = minosPrimeFolder + "minosPrimeScream.wav";
                
                AudioSource minosPrimeScreamSourceOrig = minosPrimeScreamOrig.GetComponentInChildren<AudioSource>();
                minosPrimeScreamSourceOrig.clip = SwapClipWithFile(minosPrimeScreamSourceOrig.clip, minosPrimeScreamStringOrig);
            }
            else if (levelName == "Level P-2")
            {
                string sisyphusPrimeFolder =  AudioSwapper.SpeechFolder + "sisyphusPrime\\";
                
                
                GameObject sisyphusBreakout = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Main Section"),"9 - Boss Arena"),"Boss Stuff(Clone)"),"PrisonPhase"),"Flesh Prison 2"),"DelayedInstakill"),"Voice");
                
                AudioSource sisyphusBreakoutSource =  sisyphusBreakout.GetComponent<AudioSource>();
                string sisyphusBreakoutString = sisyphusPrimeFolder + "sisyphusThisPrison.wav";
                sisyphusBreakoutSource.clip = SwapClipWithFile(sisyphusBreakoutSource.clip, sisyphusBreakoutString);
                
                GameObject sisyphusIntro = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Main Section"),"9 - Boss Arena"),"Boss Stuff(Clone)"),"PrimeIntro"),"SisyphusPrimeIntro"),"VoiceDelayer"),"Voice");
                
                AudioSource sisyphusIntroSource =  sisyphusIntro.GetComponent<AudioSource>();
                string sisyphusIntroString = sisyphusPrimeFolder + "sisyphusIntro.wav";
                sisyphusIntroSource.clip = SwapClipWithFile(sisyphusIntroSource.clip, sisyphusIntroString);
                
                GameObject sisyphusOutro =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Main Section"),"9 - Boss Arena"),"Boss Stuff(Clone)"),"PrimePhase"),"SisyphusPrime"),"OutroDelay"),"Outro");
                
                AudioSource sisyphusOutroSource =  sisyphusOutro.GetComponent<AudioSource>();
                string sisyphusOutroString = sisyphusPrimeFolder + "sisyphusOutro.wav";
                sisyphusOutroSource.clip = SwapClipWithFile(sisyphusOutroSource.clip, sisyphusOutroString);
                
                GameObject sisyphusRespawn = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Main Section"),"9 - Boss Arena"),"Boss Stuff(Clone)"),"PrimePhase"),"SisyphusPrime"),"KeepThemComing");
                
                AudioSource sisyphusRespawnSource =  sisyphusRespawn.GetComponent<AudioSource>();
                string sisyphusRespawnString = sisyphusPrimeFolder + "sisyphusKeepThemComing.wav";
                sisyphusRespawnSource.clip = SwapClipWithFile(sisyphusRespawnSource.clip, sisyphusRespawnString);
                

                

                

                
                
                
                
            }
            else if (levelName == "Level 4-3")
            {
                //There are two used clips for intro, one for Mandalore, the other for the owl.
                //I can't find where the owl clip is though...

                string mandaloreFolder = SpeechFolder + "mandalore" + Path.DirectorySeparatorChar;
                
                GameObject mandaloreArena = GetGameObjectChild(GetInactiveRootObject("3 - Traitor Hallway"),"3B - Tomb of Kings");

                GameObject mandaloreIntro = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(mandaloreArena,"3B Stuff"),"Hall"),"FakeMandalore"),"IntroLine");
                string mandaloreIntroString = mandaloreFolder + "mandaloreIntro.wav";
                
                AudioSource mandaloreIntroSource = mandaloreIntro.GetComponentInChildren<AudioSource>();
                mandaloreIntroSource.clip = SwapClipWithFile(mandaloreIntroSource.clip, mandaloreIntroString);
            }
            
            else if (levelName == "Level 5-3")
            {
                string gabeBoatFolder = SpeechFolder + "gabrielBoat" + Path.DirectorySeparatorChar;
                
                GameObject gabeBoatSpeechObject = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Unrotated"),"5 - Hologram Room"),"5 Nonstuff"),"Decorations"), "Hologram");

                AudioSource gabeBoat = gabeBoatSpeechObject.GetComponentInChildren<AudioSource>();

                string gabeBoatString = gabeBoatFolder + "gabrielBoat.wav";

                gabeBoat.clip = SwapClipWithFile(gabeBoat.clip, gabeBoatString);
            }
            else if (levelName == "Level 6-1")
            {
                string gabeHeresyFolder = SpeechFolder + "gabrielHeresy" + Path.DirectorySeparatorChar;
                
                GameObject gabeHeresyFirst = GetInactiveRootObject("GabrielVoice1");
                GameObject gabeHeresySecond = GetInactiveRootObject("GabrielVoice2");
                
                AudioSource gabeHeresyFirstSource = gabeHeresyFirst.GetComponentInChildren<AudioSource>();
                AudioSource gabeHeresySecondSource = gabeHeresySecond.GetComponentInChildren<AudioSource>();
                
                string gabeHeresyFirstString = gabeHeresyFolder + "gabrielHeresyFirst.wav";
                string gabeHeresySecondString = gabeHeresyFolder + "gabrielHeresySecond.wav";
                
                gabeHeresyFirstSource.clip = SwapClipWithFile(gabeHeresyFirstSource.clip,gabeHeresyFirstString);
                gabeHeresySecondSource.clip = SwapClipWithFile(gabeHeresySecondSource.clip,gabeHeresySecondString);
            }
            else if (levelName == "Level 6-2")
            {
                string gabeSecondFolder = SpeechFolder + "gabrielBossSecond" + Path.DirectorySeparatorChar;
                
                //Intro lines
                GameObject gabeSecondSpeechObject = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("IntroSounds"),"Filler"),
                "Speech and Music"),"Speech");
                
                AudioSource gabeSecondSpeech = gabeSecondSpeechObject.GetComponentInChildren<AudioSource>();
                string gabeSecondSpeechString = gabeSecondFolder + "gabrielSecondIntro.wav";
                
                gabeSecondSpeech.clip = SwapClipWithFile(gabeSecondSpeech.clip,gabeSecondSpeechString);
                
                //Fight start lines
                GameObject gabeSecondFightStartObject = GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("2 - Organ Hall"),"2 Stuff(Clone)"),"Intro");
                
                AudioSource gabeSecondFightStart = gabeSecondFightStartObject.GetComponentInChildren<AudioSource>();
                string gabeSecondFightStartString = gabeSecondFolder + "gabrielSecondFightStart.wav";
                
                gabeSecondFightStart.clip = SwapClipWithFile(gabeSecondFightStart.clip,gabeSecondFightStartString);
                
                //Defeated lines
                GameObject gabeSecondDefeated = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("2 - Organ Hall"),"2 Stuff(Clone)"), "GabrielOutroParent"),"GabrielOutro"),"OutroVoice");
                
                AudioSource gabeSecondDefeatedSource = gabeSecondDefeated.GetComponentInChildren<AudioSource>();
                string gabeSecondDefeatedString = gabeSecondFolder + "gabrielSecondDefeated.wav";
                
                gabeSecondDefeatedSource.clip = SwapClipWithFile(gabeSecondDefeatedSource.clip,gabeSecondDefeatedString);
                
                GameObject gabeSecondDefeatedOrig = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("2 - Organ Hall"),"2 Stuff"), "GabrielOutroParent"),"GabrielOutro"),"OutroVoice");
                
                AudioSource gabeSecondDefeatedSourceOrig = gabeSecondDefeatedOrig.GetComponentInChildren<AudioSource>();
                string gabeSecondDefeatedStringOrig = gabeSecondFolder + "gabrielSecondDefeated.wav";
                
                gabeSecondDefeatedSourceOrig.clip = SwapClipWithFile(gabeSecondDefeatedSourceOrig.clip,gabeSecondDefeatedStringOrig);

                //Outro lines
                GameObject gabeSecondOutro =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("2 - Organ Hall"),"2 Stuff(Clone)"), "GabrielOutroParent"),"EndShatter"),"gab_Intro5");
                
                AudioSource gabeSecondOutroSource = gabeSecondOutro.GetComponentInChildren<AudioSource>();
                string gabeSecondOutroString = gabeSecondFolder + "gabrielSecondOutro.wav";
                
                gabeSecondOutroSource.clip = SwapClipWithFile(gabeSecondOutroSource.clip,gabeSecondOutroString);
                
                GameObject gabeSecondOutroOrig =  GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("2 - Organ Hall"),"2 Stuff(Clone)"), "GabrielOutroParent"),"EndShatter"),"gab_Intro5");
                
                AudioSource gabeSecondOutroSourceOrig = gabeSecondOutroOrig.GetComponentInChildren<AudioSource>();
                string gabeSecondOutroStringOrig = gabeSecondFolder + "gabrielSecondOutro.wav";
                
                gabeSecondOutroSourceOrig.clip = SwapClipWithFile(gabeSecondOutroSourceOrig.clip,gabeSecondOutroStringOrig);
            }
        }
        
        
    }
}
