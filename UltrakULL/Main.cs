using HarmonyLib;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UltrakULL.json;
using BepInEx;
using BepInEx.Configuration;
using System.Reflection;

using static UltrakULL.CommonFunctions;
using UltrakULL.Commands;

/*
 *	UltrakULL (Ultrakill Language Library)
 *	Written by Clearwater
 *  	Additional code contributions by Temperz87, Flazhik, BitKoven, CoatlessAli and others
 *  	Translations by UltrakULL Translation Team
 *	Date started: 21st April 2021
 *	Last updated: 12th March 2024
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
 * r2modman messes up font files with extentions that makes the detection skip them (https://discord.com/channels/1017473804592754778/1017898261660565675/1228095247163068567)
 * 
 *
 * -- TODO --
 * Make 2 materials for the font, one with a shadow and the other without, and only apply the shadow version on level title pop-ups
 * 
 *
 * -- TESTING REPORTS --
 * "Home or ~" cheat string isn't translated
 * The arm alter menu isn't fully translated and mostly doesn't work outside of the Sandbox
 * '0' has weird spacing with the font
 * 
 * */

namespace UltrakULL
{
    [BepInPlugin(Guid, InternalName, InternalVersion)]
    public class MainPatch : BaseUnityPlugin
    {
        private const string Guid = "clearwater.ultrakill.ultrakull";
        private const string InternalName = "clearwater.ultrakull.ultrakULL";
        private const string InternalVersion = "1.3.1"; //Why was the mod version still 1.3.0?

        public static MainPatch Instance;
        public bool ready;
        public (string statu, string e) initializeErrorMessage;
        // Using inherited Config from BaseUnityPlugin

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

        private void HandleInitialzeError(string statu, string errorMessage)
        {
            Logging.Fatal("An error occured while initialising!");
            this.initializeErrorMessage.statu = statu;
            this.initializeErrorMessage.e = errorMessage;
            Logging.Fatal("Reason: " + initializeErrorMessage.statu);
            Logging.Fatal(initializeErrorMessage.e);
        }

        public (InitializationStatu, Exception) Initialize()
        {
            // You can find this enmu class in this file
            Harmony harmony = new Harmony(InternalName);
            try
            {
                Logging.Warn("--- Patching in-game terminal commands ---");
                harmony.PatchAll(typeof(ConsolePatcher));
            }
            catch (Exception e)
            {
                return (InitializationStatu.PatchTerminalCommands, e);
            }

            try
            {
                Logging.Warn("--- Loading external fonts ---");
                Core.LoadFonts();
            } 
            catch (Exception e)
            {
                return (InitializationStatu.LoadFonts, e);
            }

            try
            { 
                Logging.Warn("--- Initializing language manager ---");
                LanguageManager.InitializeManager(InternalVersion);
            }
            catch (Exception e)
            {
                return (InitializationStatu.InitializeLanguageManager, e);
            }

            try
            {   
                Logging.Warn("--- Patching vanilla game functions ---");
                harmony.PatchAll();
            }
            catch (Exception e)
            {
                return (InitializationStatu.PatchGameFunctions, e);
            }

            return (InitializationStatu.Success, null);
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
                if (GetCurrentSceneName() != "Bootstrap" || GetCurrentSceneName() != "Intro")
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
            this.ready = false;
            Debug.unityLogger.filterLogType = LogType.Exception;

            Logging.Warn("UltrakULL Loading... | Version v." + InternalVersion);

            Logging.Warn("--- Checking for updates ---");
            Task.Run(() =>
            {
                try
                {
                    return Core.CheckForUpdates();
                }
                catch (Exception e)
                {
                    Logging.Message($"Failed to read version info! {e.Message}");
                    return null;
                }
            });

            var (initializeStatu, exception) = Initialize();
            if (initializeStatu != InitializationStatu.Success)
            {
                HandleInitialzeError(initializeStatu.ToString(), exception.Message);
                return;
            }

            Logging.Warn(" --- All done. Enjoy! ---");
            SceneManager.sceneLoaded += onSceneLoaded;
            SceneManager.sceneLoaded += SubtitledAudioSourcesReplacer.OnSceneLoaded;
            this.ready = true;

        }
    }

    public enum InitializationStatu
    {
        PatchTerminalCommands,
        LoadFonts,
        InitializeLanguageManager,
        PatchGameFunctions,
        Success
    }
}
