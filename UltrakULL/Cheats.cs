using System;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    public static class Cheats
    {
        public static void PatchCheatConsentPanel(ref GameObject coreGame)
        {

            GameObject canvas = GetInactiveRootObject("Canvas");

            GameObject cheatsConsentObject = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvas, "Cheat Menu"), "Cheats Consent"), "Panel");

            GameObject cheatsConsentTextObject = GetGameObjectChild(cheatsConsentObject, "Text");

            //Consent window
            Text cheatsConsentText = GetTextfromGameObject(GetGameObjectChild(cheatsConsentObject, "Text"));
            cheatsConsentText.text =
                LanguageManager.CurrentLanguage.cheats.cheats_disclaimer1 + "\n\n"
                + LanguageManager.CurrentLanguage.cheats.cheats_disclaimer2;

            Text cheatsConsentYesText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cheatsConsentObject, "Yes"), "Text"));
            cheatsConsentYesText.text = LanguageManager.CurrentLanguage.cheats.cheats_disclaimerYes;
            cheatsConsentYesText.fontSize = 22;

            Text cheatsConsentNoText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(cheatsConsentObject, "No"), "Text"));
            cheatsConsentNoText.text = LanguageManager.CurrentLanguage.cheats.cheats_disclaimerNo;

            GameObject cheatsPanelObject = GetGameObjectChild(GetGameObjectChild(canvas, "Cheat Menu"), "Cheats Manager");

            Text cheatsPanelObjectTitle = GetTextfromGameObject(GetGameObjectChild(cheatsPanelObject, "Title"));
            cheatsPanelObjectTitle.text = LanguageManager.CurrentLanguage.cheats.cheats_panelTitle;

            //Need to disable the TextOverride component.
            Component[] test = cheatsConsentTextObject.GetComponents(typeof(Component));
            Behaviour bhvr = (Behaviour)test[3];
            bhvr.enabled = false;

            //Cheat confirmation panel
            GameObject cheatsEnabledConfirmationObject = CommonFunctions.GetGameObjectChild(CommonFunctions.GetGameObjectChild(CommonFunctions.GetGameObjectChild(canvas, "Cheat Menu"), "Cheats Overlay"),"Cheats Enabled");

            Text cheatsEnabledConfirmationTitleText = CommonFunctions.GetTextfromGameObject(CommonFunctions.GetGameObjectChild(cheatsEnabledConfirmationObject, "Title"));
            cheatsEnabledConfirmationTitleText.text = LanguageManager.CurrentLanguage.cheats.cheats_cheatsEnabled;

            //Text cheatsEnabledConfirmationButtonsText = CommonFunctions.getTextfromGameObject(CommonFunctions.getGameObjectChild(cheatsEnabledConfirmationObject, "Details Tip"));
            //cheatsEnabledConfirmationButtonsText.text = "HOME ou ~";
            
            //Teleport menu title
            Text cheatsTeleportMenuTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvas,"Cheat Menu"),"Cheats Teleport"),"Title"));
            cheatsTeleportMenuTitle.text = LanguageManager.CurrentLanguage.cheats.cheats_teleportMenu;
        }

        public static string GetCheatStatus(string cheatStatus)
        {
            if(cheatStatus == null) { return null; }
            else
            {
                try
                {
                    switch (cheatStatus)
                    {
                        case "STAY ACTIVE": { return LanguageManager.CurrentLanguage.cheats.cheats_stayActive; }
                        case "DISABLE ON RELOAD": { return LanguageManager.CurrentLanguage.cheats.cheats_disableOnReload; }
                        case "EQUIP": { return LanguageManager.CurrentLanguage.cheats.cheats_equip; }
                        case "REMOVE": { return LanguageManager.CurrentLanguage.cheats.cheats_remove; }
                        case "OPEN": { return LanguageManager.CurrentLanguage.cheats.cheats_open; }
                        case "KILL ALL": { return LanguageManager.CurrentLanguage.cheats.cheats_killAll; }
                        case "STATIC": { return LanguageManager.CurrentLanguage.cheats.cheats_static; }
                        case "DYNAMIC": { return LanguageManager.CurrentLanguage.cheats.cheats_dynamic; }
                        case "REBUILD": { return LanguageManager.CurrentLanguage.cheats.cheats_rebuild; }
                        case "REBUILDING...": { return LanguageManager.CurrentLanguage.cheats.cheats_rebuilding; }
                        default: { return null; }
                    }
                }
                catch(Exception e)
                {
                    HandleError(e, cheatStatus);
                    return ("");
                }
            }
        }

        public static string GetCheatName(string cheatIdentifier)
        {
            try
            {
                switch (cheatIdentifier)
                {
                    case "ultrakill.keep-enabled": { return LanguageManager.CurrentLanguage.cheats.cheats_keepEnabled; }

                    case "ultrakill.spawner-arm": { return LanguageManager.CurrentLanguage.cheats.cheats_spawnerArm; }
                    case "ultrakill.teleport-menu": { return LanguageManager.CurrentLanguage.cheats.cheats_teleportMenu; }
                    case "ultrakill.full-bright": { return LanguageManager.CurrentLanguage.cheats.cheats_fullBright; }

                    case "ultrakill.noclip": { return LanguageManager.CurrentLanguage.cheats.cheats_noclip; }
                    case "ultrakill.flight": { return LanguageManager.CurrentLanguage.cheats.cheats_flight; }
                    case "ultrakill.infinite-wall-jumps": { return LanguageManager.CurrentLanguage.cheats.cheats_infiniteWallJumps; }

                    case "ultrakill.no-weapon-cooldown": { return LanguageManager.CurrentLanguage.cheats.cheats_noWeaponCooldown; }
                    case "ultrakill.infinite-power-ups": { return LanguageManager.CurrentLanguage.cheats.cheats_infinitePowerUps; }

                    case "ultrakill.blind-enemies": { return LanguageManager.CurrentLanguage.cheats.cheats_blindEnemies; }
                    case "ultrakill.disable-enemy-spawns": { return LanguageManager.CurrentLanguage.cheats.cheats_disableEnemySpawns; }
                    case "ultrakill.invincible-enemies": { return LanguageManager.CurrentLanguage.cheats.cheats_invincibleEnemies; }
                    case "ultrakill.kill-all-enemies": { return LanguageManager.CurrentLanguage.cheats.cheats_killAllEnemies; }

                    case "ultrakill.sandbox.quick-save": { return LanguageManager.CurrentLanguage.cheats.cheats_quickSave; }
                    case "ultrakill.sandbox.quick-load": { return LanguageManager.CurrentLanguage.cheats.cheats_quickLoad; }
                    case "ultrakill.sandbox.save-menu": { return LanguageManager.CurrentLanguage.cheats.cheats_saveMenu; }
                    case "ultrakill.sandbox.clear": { return LanguageManager.CurrentLanguage.cheats.cheats_clear; }
                    case "ultrakill.sandbox.rebuild-nav": { return LanguageManager.CurrentLanguage.cheats.cheats_rebuildNav; }
                    case "ultrakill.sandbox.snapping": { return LanguageManager.CurrentLanguage.cheats.cheats_snapping; }
                    case "ultrakill.sandbox.physics": { return LanguageManager.CurrentLanguage.cheats.cheats_physics; }
                    case "ultrakill.sandbox.crash-mode": { return LanguageManager.CurrentLanguage.cheats.cheats_crashMode; }
                }
                return cheatIdentifier;
            }
            catch(Exception e)
            {
                HandleError(e,cheatIdentifier) ;
                return "";
            }
        }
    }
}
