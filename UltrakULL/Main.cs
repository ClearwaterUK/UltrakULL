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
 *	Last updated: 30th October 2023
 *	
 *	A translation mod for Ultrakill that hooks into the game and allows for text/string replacement. This tool is primarily meant to assist with language translation.
 * 
 *  -- LONG-TERM TASK LIST --
 * Better error handling
 * Bundle submitted voice packs with language downloads (EternalUnion recommends Google Drive)
 * Sit down and finish audio documentation
 * Figure out why online language browser breaks sometimes. Seems to happen at random with no singular cause. Quick game restart usually fixes.
 * Clean up logging, redirect or simplify non-breaking warnings & errors.
 * Expected stuff to change/break in Act 3: CG custom music, new enemies, changes in HUD font
 * Swap rank textures in HUD for translated ones (there's already a mod that allows this. Will need to either integrate or copy code from it)
 * 
 * -- STUFF FOR NEXT UPDATE --
 * Update the Github language board yet again...
 
 * -- REPORTED STUFF TO INVESTIGATE --
 * Spawning MDK+Owl while noclipped causes a crash. Function that's causing it: MandaloreSubtitlesSwap->Mandalore_Start
 *  * Offending transpiler lines have been commented out for now. Waiting for Flazhik to look at and fix.
 * 
 * -- TESTING REPORTS --
 * Some ogg files apparantly not playing correctly (Checked Spanish pack that Lukah sent, seems to be working fine... Will keep an eye on.)
 * "Home or ~" cheat string not translated
 *
 *
 * -- VIOLENCE DAMAGE REPORT --
 * Text elements now use TextMeshPro and variants
 * Options->PatchControlOptions needs to be COMPLETELY redone.
 * Options->PatchColorOptions has new entries.
 * LocalizeGameProgressCheck
 * LevelNameFinder->OnEnable needs to be redone.
 * Need to convert Fonts to FontAsset to use in TMP. Can't do until back at apartment.
 * TMP text changes now only support certain colors. Lime/cyan no longer work, need to change to green/blue.
 *
 * Books and plaques in museum.
 *
 * Virtually everything in-level is busted.
 * */

namespace UltrakULL
{
    [BepInPlugin(Guid, InternalName, InternalVersion)]
    public class MainPatch : BaseUnityPlugin
    {
        private const string Guid = "clearwater.ultrakill.ultrakull";
        private const string InternalName = "clearwater.ultrakull.ultrakULL";
        private const string InternalVersion = "1.2.3";

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
                Core.CheckForUpdates();
                
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
