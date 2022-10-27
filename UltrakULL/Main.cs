using BepInEx;
using HarmonyLib;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UltrakULL;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using static UltrakULL.CommonFunctions;
using System.Linq;
using UltrakULL.json;

//using UKUIHelper;
/*
 *	UltrakULL (Ultrakill Language Library)
 *	Written by Clearwater
 *	Date started: 21st April 2021
 *	Last updated: 26th October 2022
 *	
 *	This is a translation mod for Ultrakill that hooks into the game and allows for text/string replacement.
 *	This tool is primarily meant to assist with language translation.
 * 
 *  MAIN TODO LIST
 *  - Fill the JSON template and class as progress happens, moving hardcoded text out as it goes
 *  - Add ULL credits, translation credits to main menu with help of UKUIHelper library
 *  - Error and exception handling
 *  - Divide up more stuff in try/catch functions (especially the shop and options), that way less stuff breaks if something bad happens
 *  - Discord RPC (Persistant timestamp and general corrections)
 *  - Look at everything in PatchedFunctions and refactor anything from prefix to postfix.
 *  - Could be possible to swap out rank textures in HUD for translation. Shall look into later
 *  - Attempt to replace the default font with a version that has better special char + cyrillic support
 * 
 * - Less important stuff for future updates:
 *  - Cheat teleport menu
 *  - Sandbox stuff (time of day shop, spawn/cheat menu categories, dupe save/load menu)
 *  - Terminals before bosses in levels (could copy the shop that's in the start of each level)
 *  - Organise and refactor stuff, move functions to other files to declutter Main (Simplify getGameObjectChild and getTextFromgameObject in each file, take itfrom CommonFunctions) (Factorise the act classes with an interface?)
 *  - Look into how I can do encoding for RTL languages such as Arabic
 *  - Port main class so it becomes a native UMM mod instead of BepInEx. With the way its structured, could be able to move config/lang files to same folder.
 *  - Green Rocketlauncher incoming
 *  
 *  BUGS AND QUIRKS TO FIX:
 * - Bosses spawned with the spawner arm outside of their normal level have unimplemented string messages (currently due to current subtitle implentation. Will need to change some things)
 * - Discord RPC: Style meter in CG
 * 
 *  STUFF REPORTED BY ULL TEAM
 * - 2-1 dash jump panel seems to be broken again (Timmy) (seems to be fine for me but others have reported it. Need to keep an eye on)
 * 
 *  FOR NEXT HOTFIX:
 * - Add more sanity checks in code to prevent entire mod from breaking if something does (Caused when mod tries to get strings from json that don't exist and then just ends up breaking everything). Disable patchedFunctions by returning true if an exception happens there, will then use original game code.
 * - Find a more robust solution for HUD messages not displaying correctly when player goes back and forth to a trigger. Maybe store last string, then if no match, reload the stored string?
 * - Inconsistencies with commas in input messages (ex: 0-1 has them but slide in tutorial doesn't)
 * 
 * Options->Sandbox icons names
 * - 2-S arrow bugs, act 2 intermissions
 * - CG high scores aren't saved?
 * */

namespace UltrakULL
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    //[BepInDependency("zed.uk.uihelper")]
    [BepInProcess("ULTRAKILL.exe")]
    public class MainPatch : BaseUnityPlugin
    {
        public const string pluginGuid = "clearwater.ultrakill.ultrakULL";
        public const string pluginName = "UltrakULL - Ultrakill Language Library";
        public const string pluginVersion = "0.8.4";

        public static MainPatch instance = null;
        private PatchedFunctions patchedFuncs;
        private GameObject ultrakullLogo = null;

        private bool ready = false;

        public Font vcrFont;
        public MainPatch()
        {
            instance = this;
        }

        public void OnApplicationQuit()
        {
            LanguageManager.DumpLastLanguage();
        }

        public void disableMod()
        {
            this.ready = false;
        }

        //Patches all text strings in the pause menu.
        public void patchPauseMenu(ref GameObject level)
        {
            try
            {
                GameObject pauseObject = getInactiveRootObject("Canvas");
                GameObject pauseMenu = getGameObjectChild(pauseObject, "PauseMenu");

                //Title
                Text pauseText = getTextfromGameObject(getGameObjectChild(pauseMenu, "Text"));
                pauseText.text = "-- " + LanguageManager.CurrentLanguage.pauseMenu.pause_title + " --";

                //Resume
                Text continueText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Resume"), "Text"));
                continueText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_resume;

                //Checkpoint
                Text checkpointText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Restart Checkpoint"), "Text"));
                checkpointText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_respawn;

                //Restart mission
                Text restartText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Restart Mission"), "Text"));
                restartText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restart;

                //Options
                Text optionsText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Options"), "Text"));
                optionsText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_options;

                //Quit
                Text quitText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(pauseMenu, "Quit Mission"), "Text"));
                quitText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quit;

                //Quit+Restart windows
                GameObject pauseDialogs = getGameObjectChild(pauseObject, "PauseMenuDialogs");

                //Quit
                GameObject quitDialog = getGameObjectChild(getGameObjectChild(pauseDialogs, "Quit Confirm"), "Panel");
                Text quitDialogText = getTextfromGameObject(getGameObjectChild(quitDialog, "Text"));
                quitDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirm;

                Text quitDialogTooltip = getTextfromGameObject(getGameObjectChild(quitDialog, "Text (1)"));
                quitDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

                Text quitDialogYes = getTextfromGameObject(getGameObjectChild(getGameObjectChild(quitDialog, "Confirm"), "Text"));
                quitDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmYes;

                Text quitDialogNo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(quitDialog, "Cancel"), "Text"));
                quitDialogNo.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmNo;

                //Restart
                GameObject restartDialog = getGameObjectChild(getGameObjectChild(pauseDialogs, "Restart Confirm"), "Panel");

                Text restartDialogText = getTextfromGameObject(getGameObjectChild(restartDialog, "Text"));
                restartDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirm;

                Text restartDialogTooltip = getTextfromGameObject(getGameObjectChild(restartDialog, "Text (1)"));
                restartDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

                Text restartDialogYes = getTextfromGameObject(getGameObjectChild(getGameObjectChild(restartDialog, "Confirm"), "Text"));
                restartDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirmYes;

                Text restartDialogNo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(restartDialog, "Cancel"), "Text"));
                restartDialogNo.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirmNo;
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to patch pause menu");
                Logger.LogError(e.ToString());
            }
        }

        public void patchCheats(ref GameObject coreGame)
        {
            coreGame = GameObject.Find("Canvas");
            Cheats.patchCheatConsentPanel(ref coreGame);
        }

        public void patchDeathScreen(ref GameObject coreGame)
        {
            coreGame = getInactiveRootObject("Canvas");

            try
            {
                GameObject deathScreen = getGameObjectChild(getGameObjectChild(coreGame, "BlackScreen"), "YouDiedText");
                //Need to disable the TextOverride component.
                Component[] test = deathScreen.GetComponents(typeof(Component));
                Behaviour bhvr = (Behaviour)test[3];
                bhvr.enabled = false;

                Text youDiedText = getTextfromGameObject(deathScreen);
                youDiedText.text = LanguageManager.CurrentLanguage.misc.youDied1 + "\n\n\n\n\n" + LanguageManager.CurrentLanguage.misc.youDied2;
            }
            catch (Exception e)
            {
                Logger.LogError("Failed to patch death screen");
                Console.WriteLine(e.ToString());
            }
        }

        public void initJsonParser()
        {
            LanguageManager.InitializeManager(pluginVersion);
        }

        //Encapsulation function to patch the shop.
        public void patchShop(ref GameObject coreGame)
        {
            Shop.PatchShop(ref coreGame);
        }

        public void patchLevelStats(ref GameObject coreGame)
        {
            LevelStatWindow.patchStats();
        }

        //Encapsulation function to patch all of the front end.
        public void patchFrontEnd(GameObject frontEnd)
        {
            MainMenu.Patch(frontEnd);
            Options options = new Options(ref frontEnd);
        }

        public void patchMisc(ref GameObject coreGame)
        {
            GameObject player = GameObject.Find("Player");
            GameObject styleMeter = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(player, "Main Camera"), "HUD Camera"), "HUD"), "StyleCanvas"), "Panel (1)"), "Panel"), "Text (1)"), "Text");
            Text styleMeterMultiplierText = getTextfromGameObject(styleMeter);
            styleMeterMultiplierText.text = LanguageManager.CurrentLanguage.style.stylemeter_multiplier;

            GameObject canvas = getInactiveRootObject("Canvas");
            GameObject pressToSkip = getGameObjectChild(canvas, "CutsceneSkipText");

            //Need to disable the TextOverride component.
            Component[] test = pressToSkip.GetComponents(typeof(Component));
            Behaviour bhvr = (Behaviour)test[4];
            bhvr.enabled = false;

            Text pressToSkipText = getTextfromGameObject(pressToSkip);
            pressToSkipText.text = LanguageManager.CurrentLanguage.misc.pressToSkip;

            //Classic HUD
            GameObject classicHudBW = getGameObjectChild(getGameObjectChild(getGameObjectChild(canvas, "Crosshair Filler"), "AltHud"), "Filler");
            GameObject classicHudColor = getGameObjectChild(getGameObjectChild(getGameObjectChild(canvas, "Crosshair Filler"), "AltHud (2)"), "Filler");

            Text classicHudBWHealth = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Health"), "Title"));
            Text classicHudBWHealthShow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Health"), "Title (1)"));
            Text classicHudColorHealth = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Health"), "Title"));
            Text classicHudColorHealthShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Health"), "Title (1)"));
            classicHudBWHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudColorHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudBWHealthShow.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
            classicHudColorHealthShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_health;

            Text classicHudBWStamina = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Stamina"), "Title"));
            Text classicHudColorStamina = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Stamina"), "Title"));
            Text classicHudBWStaminaShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Stamina"), "Title (1)"));
            Text classicHudColorStaminaShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Stamina"), "Title (1)"));
            classicHudBWStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudColorStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudBWStaminaShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
            classicHudColorStaminaShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;

            Text classicHudBWWeapon = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Weapon"), "Title"));
            Text classicHudColorWeapon = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Weapon"), "Title"));
            Text classicHudBWWeaponShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Weapon"), "Title (1)"));
            Text classicHudColorWeaponShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Weapon"), "Title (1)"));
            classicHudBWWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudColorWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudBWWeaponShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
            classicHudColorWeaponShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;

            Text classicHudBWArm = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Arm"), "Title"));
            Text classicHudColorArm = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Arm"), "Title"));
            Text classicHudBWArmShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "Arm"), "Title (1)"));
            Text classicHudColorArmShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "Arm"), "Title (1)"));
            classicHudBWArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudColorArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudBWArmShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
            classicHudColorArmShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;

            Text classicHudBWRailcannon = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "RailcannonMeter (1)"), "Title"));
            Text classicHudColorRailcannon = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "RailcannonMeter"), "Title"));
            Text classicHudBWRailcannonShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudBW, "RailcannonMeter (1)"), "Title (1)"));
            Text classicHudColorRailcannonShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(classicHudColor, "RailcannonMeter"), "Title (1)"));
            classicHudBWRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudColorRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudBWRailcannonShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
            classicHudColorRailcannonShadow.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;

        }

        //Adds the Discord link to the UltrakULL Discord on the main menu.
        public void addDiscord(GameObject frontEnd)
        {
            GameObject mainMenuCanvas = getGameObjectChild(frontEnd, "Main Menu (1)");

            GameObject mainMenuButtons = getGameObjectChild(getGameObjectChild(frontEnd, "Main Menu (1)"), "Panel");
            GameObject ultrakullDiscordButton = GameObject.Instantiate(getGameObjectChild(mainMenuButtons, "Discord"), mainMenuButtons.transform);

            ultrakullDiscordButton.SetActive(true);
            ultrakullDiscordButton.GetComponent<RectTransform>().localPosition = new Vector2(450f, 250f);
            ultrakullDiscordButton.GetComponentInChildren<Text>().text = "UltrakULL DISCORD";
            ultrakullDiscordButton.GetComponentInChildren<WebButton>().url = "https://discord.gg/ZB7jk6Djv5";

            ultrakullDiscordButton.transform.parent = mainMenuButtons.transform;
            ultrakullDiscordButton.GetComponent<RectTransform>().SetParent(mainMenuButtons.GetComponent<RectTransform>());
        }

        public void addModCredits(GameObject frontEnd)
        {
            Text credits = getTextfromGameObject(getGameObjectChild(getGameObjectChild(frontEnd, "Credits"), "Text (2)"));

            credits.text =
                "WITH VOICE ACTING BY:" + "\n"
                + "<color=orange>GIANNI MATRAGRANO</color> (GABRIEL)" + "\n"
                + "<color=orange> STEPHAN WEYTE </color> (MINOS PRIME)" + "\n"
                + "<color=orange>MANDALORE HERRINGTON</color> (MDK)" + "\n"
                + "<color=orange>JUST SHAMMY </color> (&OWL)" + "\n\n"

                + "AND QUALITY ASSURANCE BY:" + "\n"
                + "<color=orange>CAMERON MARTIN</color> (LEAD QA)" + "\n"
                + "<color=orange>TUCKER WILKIN </color> (SENIOR QA)" + "\n"
                + "<color=orange>SCOTT GURNEY </color> (TECHNICAL QA)" + "\n"
                + "<color=orange>DALIA FIGUEROA </color> (QA & PROMO MATERIAL)" + "\n\n\n"

                + "<color=orange>UltrakULL (ULTRAKILL Language Library)</color>" + "\n"
                + "A TRANSLATION MOD FOR ULTRAKILL" + "\n"
                + "CREATED BY <color=orange>CLEARWATER</color> AND THE <color=orange>UltrakULL TRANSLATION TEAM</color>" + "\n"
                + "CODE CONTRIBUTIONS BY <color=orange>TEMPERZ87</color>" + "\n"
                + "FULL LANGUAGE CREDITS IN THE MOD README (to come later)" + "\n";

        }

        //Parent function to patch the vanilla game functions.
        public void patchVanillaFunctions()
        {
            Logger.LogMessage("Patching game functions...");

            Harmony harmony = new Harmony(pluginGuid);

            Logger.LogInfo("OptionsMenuToManager->Start");
            MethodInfo originalOptions = typeof(OptionsMenuToManager).GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null);
            MethodInfo patchedOptions = AccessTools.Method(typeof(Inject_LanguageButton), "Prefix");
            harmony.Patch(originalOptions, new HarmonyMethod(patchedOptions));

            Logger.LogInfo("CrateCounter->CoinsToPoints");
            MethodInfo originalCoinsToPoints = typeof(CrateCounter).GetMethod("CoinsToPoints");
            MethodInfo patchedCoinsToPoints = AccessTools.Method(typeof(PatchedFunctions), "CoinsToPoints_MyPatch");
            harmony.Patch(originalCoinsToPoints, new HarmonyMethod(patchedCoinsToPoints));

            Logger.LogInfo("DifficultyTitle->Check");
            MethodInfo originalCheckFunction = AccessTools.Method(typeof(DifficultyTitle), "Check");
            MethodInfo patchedCheckFunction = AccessTools.Method(typeof(PatchedFunctions), "Check_MyPatch");
            harmony.Patch(originalCheckFunction, new HarmonyMethod(patchedCheckFunction));

            Logger.LogInfo("LevelSelectPanel->CheckScore (PostFix)");
            MethodInfo originalCheckScoreFunction = AccessTools.Method(typeof(LevelSelectPanel), "CheckScore");
            MethodInfo patchedCheckScoreFunctionPostfix = AccessTools.Method(typeof(PatchedFunctions), "CheckScore_MyPatchPostFix");
            harmony.Patch(originalCheckScoreFunction, null, new HarmonyMethod(patchedCheckScoreFunctionPostfix));

            Logger.LogInfo("LevelNamePopup->NameAppear");
            MethodInfo originalNameAppearFunction = AccessTools.Method(typeof(LevelNamePopup), "NameAppear");
            MethodInfo patchedNameAppearFunction = AccessTools.Method(typeof(PatchedFunctions), "NameAppear_MyPatch");
            harmony.Patch(originalNameAppearFunction, new HarmonyMethod(patchedNameAppearFunction));

            Logger.LogInfo("IntroText->Start");
            MethodInfo originalIntroFunction = AccessTools.Method(typeof(IntroText), "Start");
            MethodInfo patchedIntroFunction = AccessTools.Method(typeof(PatchedFunctions), "IntroTextStart_MyPatch");
            harmony.Patch(originalIntroFunction, new HarmonyMethod(patchedIntroFunction));

            Logger.LogInfo("HudMessage->PlayMessage");
            MethodInfo originalPlayMessage = typeof(HudMessage).GetMethod("PlayMessage");
            MethodInfo patchedPlayMessage = AccessTools.Method(typeof(PatchedFunctions), "PlayMessage_MyPatch");
            harmony.Patch(originalPlayMessage, new HarmonyMethod(patchedPlayMessage));

            Logger.LogInfo("FinalRank->SetInfo");
            MethodInfo originalSetInfo = AccessTools.Method(typeof(FinalRank), "SetInfo");
            MethodInfo patchedSetInfo = AccessTools.Method(typeof(PatchedFunctions), "SetInfo_MyPatch");
            harmony.Patch(originalSetInfo, new HarmonyMethod(patchedSetInfo));

            Logger.LogInfo("BossBarManager->CreateBossBar");
            MethodInfo originalCreateBossBar = AccessTools.Method(typeof(BossBarManager), "CreateBossBar");
            MethodInfo patchedCreateBossBar = AccessTools.Method(typeof(PatchedFunctions), "CreateBossBar_MyPatch");
            harmony.Patch(originalCreateBossBar, new HarmonyMethod(patchedCreateBossBar));

            Logger.LogInfo("VariationInfo->UpdateMoney");
            MethodInfo originalUpdateMoney = AccessTools.Method(typeof(VariationInfo), "UpdateMoney");
            MethodInfo patchedUpdateMoney = AccessTools.Method(typeof(PatchedFunctions), "UpdateMoney_MyPatch");
            harmony.Patch(originalUpdateMoney, new HarmonyMethod(patchedUpdateMoney));

            Logger.LogInfo("StyleHUD->AddPoints");
            MethodInfo originalAddPoints = AccessTools.Method(typeof(StyleHUD), "AddPoints", new Type[] { typeof(int), typeof(string), typeof(GameObject), typeof(EnemyIdentifier), typeof(int), typeof(string), typeof(string) });
            MethodInfo patchedAddPoints = AccessTools.Method(typeof(PatchedFunctions), "AddPoints_MyPatch");
            harmony.Patch(originalAddPoints, new HarmonyMethod(patchedAddPoints));

            Logger.LogInfo("StyleHUD->GetLocalizedName");
            MethodInfo originalGetLocalizedName = AccessTools.Method(typeof(StyleHUD), "GetLocalizedName", new Type[] { typeof(string) });
            MethodInfo patchedGetLocalizedName = AccessTools.Method(typeof(PatchedFunctions), "GetLocalizedName_MyPatch");
            harmony.Patch(originalGetLocalizedName, new HarmonyMethod(patchedGetLocalizedName));

            Logger.LogInfo("StyleHUD->UpdateFreshnessSlider");
            MethodInfo originalUpdateFreshnessSlider = AccessTools.Method(typeof(StyleHUD), "UpdateFreshnessSlider");
            MethodInfo patchedUpdateFreshnessSlider = AccessTools.Method(typeof(PatchedFunctions), "UpdateFreshnessSlider_MyPatch");
            harmony.Patch(originalUpdateFreshnessSlider, new HarmonyMethod(patchedUpdateFreshnessSlider));

            Logger.LogInfo("IntermissionController->Start");
            MethodInfo originalIntermissionStart = AccessTools.Method(typeof(IntermissionController), "Start");
            MethodInfo patchedIntermissionStart = AccessTools.Method(typeof(PatchedFunctions), "Start_MyPatch");
            harmony.Patch(originalIntermissionStart, new HarmonyMethod(patchedIntermissionStart));

            Logger.LogInfo("SubtitleController->DisplaySubtitle");
            MethodInfo originalDisplaySubtitle = AccessTools.Method(typeof(SubtitleController), "DisplaySubtitle", new Type[] { typeof(string), typeof(AudioSource) });
            MethodInfo patchedDisplaySubtitle = AccessTools.Method(typeof(PatchedFunctions), "DisplaySubtitle_MyPatch");
            harmony.Patch(originalDisplaySubtitle, new HarmonyMethod(patchedDisplaySubtitle));

            Logger.LogInfo("EnemyInfoPage->UpdateInfo");
            MethodInfo originalUpdateInfo = AccessTools.Method(typeof(EnemyInfoPage), "UpdateInfo");
            MethodInfo patchedUpdateInfo = AccessTools.Method(typeof(PatchedFunctions), "UpdateInfo_MyPatch");
            harmony.Patch(originalUpdateInfo, new HarmonyMethod(patchedUpdateInfo));

            Logger.LogInfo("SaveSlotMenu->UpdateSlotState");
            MethodInfo originalUpdateSlotState = typeof(SaveSlotMenu).GetMethod("UpdateSlotState", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(SlotRowPanel), typeof(SaveSlotMenu.SlotData) }, null);
            MethodInfo patchedUpdateSlotState = AccessTools.Method(typeof(PatchedFunctions), "UpdateSlotState_MyPatch");
            harmony.Patch(originalUpdateSlotState, new HarmonyMethod(patchedUpdateSlotState));

            Logger.LogInfo("SaveSlotMenu->ClearSlot (Postfix)");
            MethodInfo originalClearSlot = typeof(SaveSlotMenu).GetMethod("ClearSlot", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(int) }, null);
            MethodInfo patchedClearSlotPostfix = AccessTools.Method(typeof(PatchedFunctions), "ClearSlotPostfix_MyPatch");
            harmony.Patch(originalClearSlot, null, new HarmonyMethod(patchedClearSlotPostfix));

            Logger.LogInfo("DiscordController->FetchSceneActivity");
            MethodInfo originalFetchScene = AccessTools.Method(typeof(DiscordController), "FetchSceneActivity", new Type[] { typeof(string) });
            MethodInfo patchedFetchScene = AccessTools.Method(typeof(PatchedFunctions), "FetchSceneActivity_MyPatch");
            harmony.Patch(originalFetchScene, new HarmonyMethod(patchedFetchScene));

            Logger.LogInfo("DiscordController->UpdateStyle");
            MethodInfo originalUpdateStyle = AccessTools.Method(typeof(DiscordController), "UpdateStyle", new Type[] { typeof(int) });
            MethodInfo patchedUpdateStyle = AccessTools.Method(typeof(PatchedFunctions), "UpdateStyle_MyPatch");
            harmony.Patch(originalUpdateStyle, new HarmonyMethod(patchedUpdateStyle));

            Logger.LogInfo("DiscordController->UpdateRank");
            MethodInfo originalUpdateRank = AccessTools.Method(typeof(DiscordController), "UpdateRank", new Type[] { typeof(int) });
            MethodInfo patchedUpdateRank = AccessTools.Method(typeof(PatchedFunctions), "UpdateRank_MyPatch");
            harmony.Patch(originalUpdateRank, new HarmonyMethod(patchedUpdateRank));

            Logger.LogInfo("DiscordController->UpdateWave");
            MethodInfo originalUpdateWave = AccessTools.Method(typeof(DiscordController), "UpdateWave", new Type[] { typeof(int) });
            MethodInfo patchedUpdateWave = AccessTools.Method(typeof(PatchedFunctions), "UpdateWave_MyPatch");
            harmony.Patch(originalUpdateWave, new HarmonyMethod(patchedUpdateWave));

            Logger.LogInfo("Coin->RicoshotPointsCheck");
            MethodInfo originalRicoshotPointsCheck = typeof(Coin).GetMethod("RicoshotPointsCheck");
            MethodInfo patchedRicoshotPointsCheck = AccessTools.Method(typeof(PatchedFunctions), "RicoshotPointsCheck_MyPatch");
            harmony.Patch(originalRicoshotPointsCheck, new HarmonyMethod(patchedRicoshotPointsCheck));

            Logger.LogInfo("HudMessageReciever->SendHudMessage");
            MethodInfo originalShowHudMessage = typeof(HudMessageReceiver).GetMethod("SendHudMessage");
            MethodInfo patchedShowHudMessage = AccessTools.Method(typeof(PatchedFunctions), "SendHudMessage_MyPatch");
            harmony.Patch(originalShowHudMessage, new HarmonyMethod(patchedShowHudMessage));

            Logger.LogInfo("CheatsManager->UpdateCheatState");
            MethodInfo originalUpdateCheatState = typeof(CheatsManager).GetMethod("UpdateCheatState", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(CheatMenuItem), typeof(ICheat) }, null);
            MethodInfo patchedUpdateCheatState = AccessTools.Method(typeof(PatchedFunctions), "UpdateCheatState_MyPatch");
            harmony.Patch(originalUpdateCheatState, new HarmonyMethod(patchedUpdateCheatState));

            Logger.LogInfo("CheatsManager->RenderCheatsInfo");
            MethodInfo originalRenderCheatsInfo = typeof(CheatsManager).GetMethod("RenderCheatsInfo");
            MethodInfo patchedRenderCheatsInfo = AccessTools.Method(typeof(PatchedFunctions), "RenderCheatsInfo_MyPatch");
            harmony.Patch(originalRenderCheatsInfo, new HarmonyMethod(patchedRenderCheatsInfo));

            Logger.LogInfo("LevelStats->Start");
            MethodInfo originalStart = typeof(LevelStats).GetMethod("Start", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null);
            MethodInfo patchedStart = AccessTools.Method(typeof(PatchedFunctions), "LevelStatsStart_MyPatch");
            harmony.Patch(originalStart, new HarmonyMethod(patchedStart));

            Logger.LogInfo("LevelStats->Update");
            MethodInfo originalUpdate = typeof(LevelStats).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null);
            MethodInfo patchedUpdate = AccessTools.Method(typeof(PatchedFunctions), "LevelStatsUpdate_MyPatch");
            harmony.Patch(originalUpdate, new HarmonyMethod(patchedUpdate));

            Logger.LogInfo("CustomPatterns->Toggle");
            MethodInfo originalToggle = typeof(CustomPatterns).GetMethod("Toggle");
            MethodInfo patchedToggle = AccessTools.Method(typeof(PatchedFunctions), "Toggle_MyPatch");
            harmony.Patch(originalToggle, new HarmonyMethod(patchedToggle));

            Logger.LogInfo("ScanningStuff->ScanBook");
            MethodInfo originalScanBook = typeof(ScanningStuff).GetMethod("ScanBook", new Type[] { typeof(string), typeof(bool), typeof(int) });
            MethodInfo patchedScanBook = AccessTools.Method(typeof(PatchedFunctions), "ScanBook_MyPatch");
            harmony.Patch(originalScanBook, new HarmonyMethod(patchedScanBook));

            Logger.LogInfo("GunTypeColorGetter->OnEnable (Postfix)");
            MethodInfo originalGunTypeColorGetterOnEnable = typeof(GunColorTypeGetter).GetMethod("OnEnable", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null);
            MethodInfo patchedGunTypeColorGetterOnEnable = AccessTools.Method(typeof(PatchedFunctions), "OnEnablePostFix_MyPatch");
            harmony.Patch(originalGunTypeColorGetterOnEnable, null, new HarmonyMethod(patchedGunTypeColorGetterOnEnable));

            Logger.LogInfo("Done");
        }

        //Most of the hook logic and checks go in this function.
        public void onSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (!this.ready || LanguageManager.CurrentLanguage == null)
            {
                Logger.LogError("Not ready for patching");
                return;
            }
            else
            {
                Scene currentLevel = SceneManager.GetActiveScene();
                string levelName = currentLevel.name;

                if (Inject_LanguageButton.languageButtonText != null)
                {
                    Inject_LanguageButton.languageButtonText.text = LanguageManager.CurrentLanguage.options.language_languages;
                    Inject_LanguageButton.languageButtonTitleText.text = "--" + LanguageManager.CurrentLanguage.options.language_title + "--";
                }
                //Each scene (level) has an object called Canvas. Most game objects are there.
                if (currentLevel.name == "Intro")
                {
                    GameObject frontEnd = getInactiveRootObject("Canvas");
                    Logger.LogInfo("Intro screen detected");
                    if (frontEnd != null)
                    {
                        Text loadingText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(frontEnd, "LoadingScreen"), "Intro"), "Text"));
                        loadingText.text = LanguageManager.CurrentLanguage.misc.loading;
                    }
                }
                //Main menu hook
                else if (currentLevel.name == "Main Menu")
                {
                    Logger.LogInfo("Hooking into main menu...");
                    GameObject frontEnd = getInactiveRootObject("Canvas");

                    if (frontEnd == null)
                    {
                        Logger.LogError("Failed to hook.");
                    }
                    else
                    {
                        Logger.LogInfo("Hooked into front end, patching...");
                        patchFrontEnd(frontEnd);

                        if (ultrakullLogo != null)
                            GameObject.Destroy(ultrakullLogo);
                        ultrakullLogo = GameObject.Instantiate(getGameObjectChild(getGameObjectChild(getGameObjectChild(frontEnd, "Main Menu (1)"), "Title"), "Text"), frontEnd.transform);
                        ultrakullLogo.transform.localPosition = new Vector3(1025, -425, 0);
                        Text ultrakullLogoText = getTextfromGameObject(ultrakullLogo);
                        ultrakullLogoText.text = "ultrakULL loaded.\nVersion: " + pluginVersion + "\nLocale: " + LanguageManager.CurrentLanguage.metadata.langName + "\nWIP build\nFor internal testing only";
                        ultrakullLogoText.alignment = TextAnchor.UpperLeft;
                        ultrakullLogoText.fontSize = 16;
                        //Get the font
                        this.vcrFont = ultrakullLogoText.font;

                        if (!LanguageManager.FileMatchesMinimumRequiredVersion(LanguageManager.CurrentLanguage.metadata.minimumModVersion, pluginVersion))
                        {
                            ultrakullLogoText.text += "\n<color=orange>WARNING - Outdated language\nloaded.</color>\nCheck console\n & use at your own risk!";
                            ultrakullLogo.transform.localPosition = new Vector3(1025, -350, 0);
                        }

                        this.addDiscord(frontEnd);
                        this.addModCredits(frontEnd);
                    }
                }
                else if (currentLevel.name.Contains("P-"))
                {
                    //Prime sanctum level hook
                    Logger.LogInfo("Prime sanctum, attempting to hook via Prime FirstRoom...");
                    GameObject coreGame = GameObject.Find("Prime FirstRoom");
                    if (coreGame == null)
                    {
                        Logger.LogError("Failed to hook.");
                    }
                    else
                    {
                        try
                        {
                            patchPauseMenu(ref coreGame);
                            patchCheats(ref coreGame);
                            patchDeathScreen(ref coreGame);
                            patchLevelStats(ref coreGame);
                            patchMisc(ref coreGame);
                        }
                        catch (Exception e)
                        {
                            Logger.LogError("Failed to patch in-game elements (prime).");
                            Logger.LogInfo(e.ToString());
                        }
                        Options options = new Options(ref coreGame);
                        PrimeSanctum primeSanctumClass = new PrimeSanctum(ref coreGame);
                    }
                }
                else if (currentLevel.name.Contains("-S"))
                {
                    //In secret level hook
                    Logger.LogInfo("In secret level detected, attempting to hook via Canvas...");

                    //Potential problem here - we're hooking via Secret FirstRoom, but the words are swapped between secret levels...
                    GameObject coreGame = getInactiveRootObject("Canvas");
                    if (coreGame == null)
                    {
                        Logger.LogError("Failed to hook into secret level.");
                    }
                    else
                    {
                        Logger.LogInfo("Hooked, patching secret level");
                        patchPauseMenu(ref coreGame);
                        patchCheats(ref coreGame);
                        patchLevelStats(ref coreGame);
                        Options options = new Options(ref coreGame);
                        SecretLevels secretLevels = new SecretLevels(ref coreGame);
                    }
                }
                else if (currentLevel.name == "uk_construct")
                //Sandbox hook
                {
                    Logger.LogInfo("Sandbox detected, hooking via Canvas");
                    GameObject coreGame = GameObject.Find("Canvas");
                    if (coreGame == null)
                    {
                        Logger.LogError("Failed to hook into sandbox");
                    }
                    else
                    {
                        patchPauseMenu(ref coreGame);
                        patchCheats(ref coreGame);
                        patchShop(ref coreGame);
                        patchDeathScreen(ref coreGame);
                        patchMisc(ref coreGame);
                        Options options = new Options(ref coreGame);
                        //SandboxEnemy sandbox = new SandboxEnemy(ref coreGame);
                    }
                }
                else
                //General in-level hook
                {
                    Logger.LogInfo("In-level detected, attempting to hook...");
                    GameObject coreGame = GameObject.Find("FirstRoom");
                    if (coreGame == null)
                    {
                        Logger.LogError("Failed to hook.");
                    }
                    else
                    {
                        Logger.LogInfo("Currently in: " + SceneManager.GetActiveScene().name);

                        Logger.LogInfo("Patching in-game elements...");
                        try
                        {
                            patchPauseMenu(ref coreGame);
                            patchShop(ref coreGame);
                            patchCheats(ref coreGame);
                            patchDeathScreen(ref coreGame);
                            patchLevelStats(ref coreGame);
                            patchMisc(ref coreGame);

                            Options options = new Options(ref coreGame);
                        }
                        catch (Exception e)
                        {
                            Logger.LogError("Failed to patch in-game elements.");
                            Console.WriteLine(e.ToString());
                        }

                        //Tutorial
                        if (levelName.Contains("Tutorial"))
                        {
                            Logger.LogInfo("Currently on tutorial. Now deferring patch to tutorial class.");
                            TutorialStrings tutorialPatchClass = new TutorialStrings();
                        }

                        //Prelude
                        else if (levelName.Contains("0-"))
                        {
                            Logger.LogInfo("Currently on prelude. Now deferring patch to prelude class.");
                            Prelude preludePatchClass = new Prelude(ref coreGame);
                        }
                        //Act 1
                        else if (levelName.Contains("1-") || levelName.Contains("2-") || levelName.Contains("3-"))
                        {
                            Logger.LogInfo("Currently on Act 1. Now deferring patch to Act 1 class.");
                            Act1.PatchAct1(ref coreGame);
                        }
                        //Act 2
                        else if (levelName.Contains("4-") || levelName.Contains("5-") || levelName.Contains("6-"))
                        {
                            Logger.LogInfo("Currently on Act 2. Now deferring patch to Act 2 class.");
                            Act2.PatchAct2(ref coreGame);
                        }
                        //Cyber Grind
                        else if (SceneManager.GetActiveScene().name.Contains("Endless"))
                        {
                            Logger.LogInfo("Currently in the Cyber Grind.");
                            CyberGrind.PatchCG(ref coreGame);
                        }
                        //End of act intermission
                        else if (SceneManager.GetActiveScene().name.Contains("Intermission"))
                        {
                            Logger.LogInfo("Currently on intermission.");
                            Intermission intermission = new Intermission(ref coreGame);
                        }
                    }
                }
            }
        }
        //Entry point for the patch.
        public void Awake()
        {
            Debug.unityLogger.filterLogType = LogType.Exception;
            Logger.LogInfo("UltrakULL LOADING...");
            Logger.LogInfo("Version: " + pluginVersion);
            try
            {
                Logger.LogInfo("--- Initializing JSON parser ---");
                initJsonParser();
                Logger.LogInfo("--- Inserting loaded language into patched functions ---");
                this.patchedFuncs = new PatchedFunctions();
                Logger.LogInfo("--- Patching vanilla game functions ---");
                patchVanillaFunctions();
                Logger.LogInfo(" --- All done. Enjoy! ---");
                this.ready = true;
            }
            catch (Exception e)
            {
                Logger.LogError("An error occured while initialising.");
                Console.WriteLine(e.ToString());
                return;
            }
        }
        void OnEnable()
        {
            SceneManager.sceneLoaded += onSceneLoaded;
        }

        void onDisable()
        {
            SceneManager.sceneLoaded -= onSceneLoaded;
        }

        void Update()
        {

        }
    }
}
