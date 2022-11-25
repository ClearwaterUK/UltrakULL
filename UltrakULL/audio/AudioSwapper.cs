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
        public static string speechFolder = Directory.GetCurrentDirectory() + "\\BepInEx\\config\\ultrakull\\audio\\" + LanguageManager.CurrentLanguage.metadata
        .langName + "\\";
        
        public static AudioClip swapClipWithFile(AudioClip sourceClip, string audioFilePath)
        {
            string file = "file://" + audioFilePath;
            
            UnityWebRequest fileRequest = UnityWebRequestMultimedia.GetAudioClip(file,AudioType.WAV);
            fileRequest.SendWebRequest();
            try
            {
                //while (!fileRequest.isDone) await Task.Delay(1);
                while (!fileRequest.isDone) {}
 
                if (fileRequest.isNetworkError || fileRequest.isHttpError) Debug.Log(fileRequest.error + "\n Expected path: " + audioFilePath);
                else
                {
                    sourceClip = DownloadHandlerAudioClip.GetContent(fileRequest);
                    Console.WriteLine("Audio swap done!");
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
 
            //Since the makes a clone of the arena gameObject which is used, wait a small period of time for the new gameObject to be accessible before accessing it.
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
        }
        
        
    }
}