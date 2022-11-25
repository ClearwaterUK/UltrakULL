using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UltrakULL.json;

using static UltrakULL.CommonFunctions;
using static UltrakULL.ModPatches;
 
using UMM;
using UnityEngine.PlayerLoop;

namespace UltrakULL.audio
{
    public  class AudioSwapper
    {
        private static string speechFolder = Directory.GetCurrentDirectory() + "\\BepInEx\\config\\ultrakull\\audio\\" + LanguageManager.CurrentLanguage.metadata.langName;
        
        public async static Task<AudioClip> swapClipWithFile(AudioClip sourceClip, string audioFilePath)
        {
            string file = "file://" + audioFilePath;
            
            UnityWebRequest fileRequest = UnityWebRequestMultimedia.GetAudioClip(file,AudioType.WAV);
            fileRequest.SendWebRequest();
            try
            {
                while (!fileRequest.isDone) await Task.Delay(1);
 
                if (fileRequest.isNetworkError || fileRequest.isHttpError) Debug.Log($"{fileRequest.error}");
                else
                {
                    sourceClip = DownloadHandlerAudioClip.GetContent(fileRequest);
                    Console.WriteLine("Audio swap done!");
                }
            }
            catch (Exception err)
            {
                Debug.Log($"{err.Message}, {err.StackTrace}");
            }
            return sourceClip;
        }

        public async static void audioSwap(string levelName)
        {
        
            //Since the makes a clone of the arena gameObject which is used, wait a small period of time for the new gameObject to be accessible before accessing it.
            Console.WriteLine("Waiting before audioSwapper");
            await Task.Delay(1000);
        
            Console.WriteLine("In audioSwapper");
            if (levelName == "Level 3-2")
            {
                Console.WriteLine("Attempting audio swap");
                
                Console.WriteLine(speechFolder);
                
                //Intro lines
                GameObject gabeIntroFirst = getInactiveRootObject("gab_Intro1");
                string gabeIntroFirstString = speechFolder + "//gabrielIntro1.wav";

                GameObject gabeIntroSecond = getInactiveRootObject("gab_Intro2");
                string gabeIntroSecondString = speechFolder + "//gabrielIntro2.wav";

                
                //Fight start
                GameObject gabeFightStart = getGameObjectChild(getGameObjectChild(getGameObjectChild(getInactiveRootObject("4 - Heart Chamber"),"4 Stuff(Clone)"),"GabrielOutroParent"),"gab_Intro3");
                string gabeFightStartString = speechFolder + "//gabrielFightStart.wav";
                
                
                //Defeated
                GameObject gabeDefeated = getGameObjectChild(getGameObjectChild(getGameObjectChild(getInactiveRootObject("4 - Heart Chamber"),"4 Stuff(Clone)"),"GabrielOutroParent"),"gab_Intro4");
                string gabeDefeatedString = speechFolder + "//gabrielDefeated.wav";
                
                //Outro
                GameObject gabeOutro = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getInactiveRootObject("4 - Heart Chamber"),"4 Stuff(Clone)"),"OutroLightSound"),"Eyeblood"),"gab_Intro5");
                string gabeOutroString = speechFolder + "//gabrielOutro.wav";
                
                AudioSource gabeIntroFirstSource = gabeIntroFirst.GetComponentInChildren<AudioSource>();
                AudioSource gabeIntroSecondSource = gabeIntroSecond.GetComponentInChildren<AudioSource>();
                AudioSource gabeFightStartSource = gabeFightStart.GetComponentInChildren<AudioSource>();
                AudioSource gabeDefeatedSource = gabeDefeated.GetComponentInChildren<AudioSource>();
                AudioSource gabeOutroSource = gabeOutro.GetComponentInChildren<AudioSource>();

                gabeIntroFirstSource.clip = await swapClipWithFile(gabeIntroFirstSource.clip, gabeIntroFirstString);
                gabeIntroSecondSource.clip = await swapClipWithFile(gabeIntroSecondSource.clip, gabeIntroSecondString);
                gabeFightStartSource.clip = await swapClipWithFile(gabeFightStartSource.clip, gabeFightStartString);
                gabeDefeatedSource.clip = await swapClipWithFile(gabeDefeatedSource.clip, gabeDefeatedString);
                gabeOutroSource.clip = await swapClipWithFile(gabeOutroSource.clip, gabeOutroString);




            }
        }
        
        
    }
}