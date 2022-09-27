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
using UltrakULL.json;

namespace UltrakULL
{

    class Cheats
    {
        

        public void patchCheatConsentPanel(ref GameObject coreGame,JsonParser language)
        {

            GameObject canvas = getInactiveRootObject("Canvas");

            GameObject cheatsConsentObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(canvas, "Cheat Menu"), "Cheats Consent"), "Panel");

            GameObject cheatsConsentTextObject = getGameObjectChild(cheatsConsentObject, "Text");

            //Consent window
            Text cheatsConsentText = getTextfromGameObject(getGameObjectChild(cheatsConsentObject, "Text"));
            cheatsConsentText.text =
                language.currentLanguage.cheats.cheats_disclaimer1 + "\n\n"
                + language.currentLanguage.cheats.cheats_disclaimer2;



            Text cheatsConsentYesText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cheatsConsentObject, "Yes"), "Text"));
            cheatsConsentYesText.text = language.currentLanguage.cheats.cheats_disclaimerYes;
            cheatsConsentYesText.fontSize = 22;

            Text cheatsConsentNoText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cheatsConsentObject, "No"), "Text"));
            cheatsConsentNoText.text = language.currentLanguage.cheats.cheats_disclaimerNo;

            GameObject cheatsPanelObject = getGameObjectChild(getGameObjectChild(canvas, "Cheat Menu"), "Cheats Manager");

            Text cheatsPanelObjectTitle = getTextfromGameObject(getGameObjectChild(cheatsPanelObject, "Title"));
            cheatsPanelObjectTitle.text = language.currentLanguage.cheats.cheats_panelTitle;

            //Need to disable the TextOverride component.
            Component[] test = cheatsConsentTextObject.GetComponents(typeof(Component));
            Behaviour bhvr = (Behaviour)test[3];
            bhvr.enabled = false;

            //Cheat confirmation panel
            GameObject cheatsEnabledConfirmationObject = CommonFunctions.getGameObjectChild(CommonFunctions.getGameObjectChild(CommonFunctions.getGameObjectChild(canvas, "Cheat Menu"), "Cheats Overlay"),"Cheats Enabled");

            Text cheatsEnabledConfirmationTitleText = CommonFunctions.getTextfromGameObject(CommonFunctions.getGameObjectChild(cheatsEnabledConfirmationObject, "Title"));
            cheatsEnabledConfirmationTitleText.text = language.currentLanguage.cheats.cheats_cheatsEnabled;

            //Text cheatsEnabledConfirmationButtonsText = CommonFunctions.getTextfromGameObject(CommonFunctions.getGameObjectChild(cheatsEnabledConfirmationObject, "Details Tip"));
            //cheatsEnabledConfirmationButtonsText.text = "HOME ou ~";
        }

        public static string getCheatStatus(string cheatStatus, JsonParser language)
        {
            if(cheatStatus == null) { return null; }
            else
            {
                try
                {
                    switch (cheatStatus)
                    {
                        case "STAY ACTIVE": { return language.currentLanguage.cheats.cheats_stayActive; }
                        case "DISABLE ON RELOAD": { return language.currentLanguage.cheats.cheats_disableOnReload; }
                        case "EQUIP": { return language.currentLanguage.cheats.cheats_equip; }
                        case "REMOVE": { return language.currentLanguage.cheats.cheats_remove; }
                        case "OPEN": { return language.currentLanguage.cheats.cheats_open; }
                        case "KILL ALL": { return language.currentLanguage.cheats.cheats_killAll; }
                        case "STATIC": { return language.currentLanguage.cheats.cheats_static; }
                        case "DYNAMIC": { return language.currentLanguage.cheats.cheats_dynamic; }
                        case "REBUILD": { return language.currentLanguage.cheats.cheats_rebuild; }
                        case "REBUILDING...": { return language.currentLanguage.cheats.cheats_rebuilding; }
                        default: { return null; }
                    }
                }
                catch(Exception e)
                {
                    handleError(e, cheatStatus);
                    return ("");
                }
            }
        }

        public static string getCheatName(string cheatIdentifier,JsonParser language)
        {
            try
            {
                switch (cheatIdentifier)
                {
                    case "ultrakill.keep-enabled": { return language.currentLanguage.cheats.cheats_keepEnabled; }

                    case "ultrakill.spawner-arm": { return language.currentLanguage.cheats.cheats_spawnerArm; }
                    case "ultrakill.teleport-menu": { return language.currentLanguage.cheats.cheats_teleportMenu; }
                    case "ultrakill.full-bright": { return language.currentLanguage.cheats.cheats_fullBright; }

                    case "ultrakill.noclip": { return language.currentLanguage.cheats.cheats_noclip; }
                    case "ultrakill.flight": { return language.currentLanguage.cheats.cheats_flight; }
                    case "ultrakill.infinite-wall-jumps": { return language.currentLanguage.cheats.cheats_infiniteWallJumps; }

                    case "ultrakill.no-weapon-cooldown": { return language.currentLanguage.cheats.cheats_noWeaponCooldown; }
                    case "ultrakill.infinite-power-ups": { return language.currentLanguage.cheats.cheats_infinitePowerUps; }

                    case "ultrakill.blind-enemies": { return language.currentLanguage.cheats.cheats_blindEnemies; }
                    case "ultrakill.disable-enemy-spawns": { return language.currentLanguage.cheats.cheats_disableEnemySpawns; }
                    case "ultrakill.invincible-enemies": { return language.currentLanguage.cheats.cheats_invincibleEnemies; }
                    case "ultrakill.kill-all-enemies": { return language.currentLanguage.cheats.cheats_killAllEnemies; }

                    case "ultrakill.sandbox.quick-save": { return language.currentLanguage.cheats.cheats_quickSave; }
                    case "ultrakill.sandbox.quick-load": { return language.currentLanguage.cheats.cheats_quickLoad; }
                    case "ultrakill.sandbox.save-menu": { return language.currentLanguage.cheats.cheats_saveMenu; }
                    case "ultrakill.sandbox.clear": { return language.currentLanguage.cheats.cheats_clear; }
                    case "ultrakill.sandbox.rebuild-nav": { return language.currentLanguage.cheats.cheats_rebuildNav; }
                    case "ultrakill.sandbox.snapping": { return language.currentLanguage.cheats.cheats_snapping; }
                    case "ultrakill.sandbox.physics": { return language.currentLanguage.cheats.cheats_physics; }
                    case "ultrakill.sandbox.crash-mode": { return language.currentLanguage.cheats.cheats_crashMode; }

                }

                return cheatIdentifier;
            }
            catch(Exception e)
            {
                handleError(e,cheatIdentifier) ;
                return "";
            }
        }

        public Cheats(ref GameObject coreGame,JsonParser language)
        {
            this.patchCheatConsentPanel(ref coreGame,language);
        }


    }
}
