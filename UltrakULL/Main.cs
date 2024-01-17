using HarmonyLib;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UltrakULL.json;
using BepInEx;
using static UltrakULL.CommonFunctions;
using System.Reflection;

/*
 *	UltrakULL (Ultrakill Language Library)
 *	Written by Clearwater
 *  Additional code contributions by Temperz87, Flazhik, BitKoven, CoatlessAli and others
 *  Translations by UltrakULL Translation Team
 *	Date started: 21st April 2021
 *	Last updated: 11th January 2024
 *	
 *	A translation mod for Ultrakill that hooks into the game and allows for text/string replacement. This tool is primarily meant to assist with language translation.
 * 
 * 
 *  -- LONG-TERM TASK LIST --
 * Better error handling
 * Bundle submitted voice packs with language downloads (EternalUnion recommends Google Drive)
 * Sit down and finish audio documentation
 * Figure out why online language browser breaks sometimes. Seems to happen at random with no singular cause. Quick game restart usually fixes.
 * Clean up logging, redirect or simplify non-breaking warnings & errors.
 * Swap rank textures in HUD for translated ones (there's already a mod that allows this. Will need to either integrate or copy code from it)
 * 
 * 
 * -- STUFF FOR NEXT UPDATE --
 * Nothing yet :)
 * 
 * 
 * -- REPORTED STUFF TO INVESTIGATE --
 * Spawning MDK+Owl while noclipped causes a crash. Function that's causing it: MandaloreSubtitlesSwap->Mandalore_Start
 * Offending transpiler lines have been commented out for now. Waiting for Flazhik to look at and fix.
 * 14c Update completely messed up MDK/Owl. Yet again. Pain. 
 * 
 *
 * -- TODO --
 * Patch the chess panel in the museum
 * Add all of the style bonuses in the museum
 * 
 *
 * -- TESTING REPORTS --
 * -- 1.3.0 BUGS TO FIX BEFORE RELEASE --
 * Cheats consent explaination isn't translated, the code behind it seems much more protected than anything else in the game for some reason
 * "Home or ~" cheat string isn't translated
 * The arm alter menu isn't fully translated and mostly doesn't work outside of the Sandbox
 * "Lots of P" implementation doesn't work, would likely need to be directly patched
 * 7-2 and 7-3 panels aren't translated
 * 7-4 unique HUD stuff isn't translated
 *
 * */

namespace UltrakULL
{
    [BepInPlugin(Guid, InternalName, InternalVersion)]
    public class MainPatch : BaseUnityPlugin
    {
        private const string Guid = "clearwater.ultrakill.ultrakull";
        private const string InternalName = "clearwater.ultrakull.ultrakULL";
        private const string InternalVersion = "1.3.0";

        public static MainPatch Instance;
        public bool ready;

        public static string ModFolder => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public MainPatch()
        {
            Instance = this;
        }
        
        public static string GetVersion()
        {
            return InternalVersion;
        }

        public void OnApplicationQuit()
        {
            LanguageManager.DumpLastLanguage();
        }

        public void DisableMod()
        {
            this.ready = false;
        }
        
        //Most of the hook logic and checks go in this function.
        public void onSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            
            
            if (!this.ready || LanguageManager.CurrentLanguage == null)
            {
                Logging.Error("UltrakULL has been deactivated to prevent crashing. Check the console for any errors!");
            }
            else
            {
                GameObject canvasObj = GetInactiveRootObject("Canvas");
                Core.HandleSceneSwitch(scene, ref canvasObj);
                //Bunch of things the mod should do *after* loading to avoid problems.
                if(GetCurrentSceneName() != "Bootstrap" || GetCurrentSceneName() != "Intro")
                {
                    PostInitPatches(canvasObj);
                }

            }
        }

        public async void PostInitPatches(GameObject canvasObj)
        {
            await Task.Delay(250);
            Core.ApplyPostInitFixes(canvasObj);
        }

        //Entry point for the mod.
        private void Awake()
        {
            Debug.unityLogger.filterLogType = LogType.Exception;

            Logging.Warn("UltrakULL Loading... | Version v." + InternalVersion);
            try
            {
                Logging.Warn("--- Checking for updates ---");
                Task.Run(() =>
                {
                    return Core.CheckForUpdates();
                });
                
                Logging.Warn("--- Loading external fonts ---");
                Core.LoadFonts();
            
                Logging.Warn("--- Initializing language manager ---");
                LanguageManager.InitializeManager(InternalVersion);
                
                Logging.Warn("--- Patching vanilla game functions ---");
                Harmony harmony = new Harmony(InternalName);
                harmony.PatchAll();

                Logging.Warn(" --- All done. Enjoy! ---");
                SceneManager.sceneLoaded += onSceneLoaded;
                SceneManager.sceneLoaded += SubtitledAudioSourcesReplacer.OnSceneLoaded;
                this.ready = true;
            }
            catch (Exception e)
            {
                Logging.Fatal("An error occured while initialising!");
                Logging.Fatal(e.ToString());
                this.ready = false;
            }
        }
    }
}
