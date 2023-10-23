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
 *	Last updated: 8th July 2023
 *	
 *	A translation mod for Ultrakill that hooks into the game and allows for text/string replacement. This tool is primarily meant to assist with language translation.
 * 
 *  -- MAIN TASK LIST --
 * 
 *  -- STUFF FOR FUTURE UPDATES --
 *  - Swap out rank textures in HUD for translation (there's a mod already for this, shall look into)
 *  - Finish audio dubbing documentation
 *  - Swap audio file format for dubbing from .wav to .ogg, will reduce overall mod size.
 *  - Prep work for next update: Act 3 (at least Violence), change in some HUD font displaying, enemy infighting, CG custom music among other things
 *      - Mannequins, 7-1 titles, 7-2 titles, yellow hookpoints
 *  - 2 PRs to have a look at that have just been sitting on the repo because I've been busy Despair
 *  - There's a much better way to patch the shop terminals. Check the code used in V-Ranks!
 * 
 *  -- FOR NEXT HOTFIX --
 * Make language button disappear like other option buttons when save menu is opened
 * Update custom font
 *
 * Look through all text and maybe set it all to adjust size automatically?
 * Flyingdog's book text not seeming to appear
 * Move the languages button from top left to top right so it doesn't conflict with any other mods. Was done in past with mod patches but will now hardcode it.
 * Clean up main a bit. Move most logic out to a seperate file
 *
 * 
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
                PostInitPatches(canvasObj);
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
            
                Logging.Warn("--- Initializing JSON parser ---");
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
