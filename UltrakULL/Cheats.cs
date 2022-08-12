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

namespace UltrakULL
{

    class Cheats
    {

        public void patchCheatConsentPanel(ref GameObject coreGame)
        {
            //Code in this function is a bandaid solution to get stuff patched correctly in secret levels.
            //I freakin hate it, it makes me cringe as much as anyone else who may eventually look at this, but if there's a better solution, then please let me know.

           
            GameObject canvas = GameObject.Find("Canvas");

            List<GameObject> a = new List<GameObject>();
            SceneManager.GetActiveScene().GetRootGameObjects(a);
            Console.WriteLine(a.Count);
            GameObject tst = null;
            foreach (GameObject child in a)
            {
               if(child.name == "Canvas")
                {
                    tst = child;
                }
            }

            GameObject cheatsConsentObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(tst, "Cheat Menu"), "Cheats Consent"), "Panel");

            GameObject cheatsConsentTextObject = getGameObjectChild(cheatsConsentObject, "Text");

            //Consent window
            Text cheatsConsentText = getTextfromGameObject(getGameObjectChild(cheatsConsentObject, "Text"));
            cheatsConsentText.text =
                "L'activation des codes de triche vous empêchera d'obtenir un rang à la fin du niveau, et désactivera les meilleurs scores au Cybergrind.\n\n" +
                "<color=green>Appuyer sur</color> ~ <color=green>ou</color> HOME <color=green> après avoir activé les codes de triche pour activer le menu.</color>";

            Text cheatsConsentYesText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cheatsConsentObject, "Yes"), "Text"));
            cheatsConsentYesText.text = "ACTIVER LES CODES DE TRICHE";
            cheatsConsentYesText.fontSize = 22;

            Text cheatsConsentNoText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(cheatsConsentObject, "No"), "Text"));
            cheatsConsentNoText.text = "ANNULER";

            GameObject cheatsPanelObject = getGameObjectChild(getGameObjectChild(tst, "Cheat Menu"), "Cheats Manager");

            Text cheatsPanelObjectTitle = getTextfromGameObject(getGameObjectChild(cheatsPanelObject, "Title"));
            cheatsPanelObjectTitle.text = "GESTION DES CODES DE TRICHES";

            //Need to disable the TextOverride component.
            Component[] test = cheatsConsentTextObject.GetComponents(typeof(Component));
            Behaviour bhvr = (Behaviour)test[3];
            bhvr.enabled = false;

            //Cheat confirmation panel
            GameObject cheatsEnabledConfirmationObject = CommonFunctions.getGameObjectChild(CommonFunctions.getGameObjectChild(CommonFunctions.getGameObjectChild(tst, "Cheat Menu"), "Cheats Overlay"),"Cheats Enabled");

            Text cheatsEnabledConfirmationTitleText = CommonFunctions.getTextfromGameObject(CommonFunctions.getGameObjectChild(cheatsEnabledConfirmationObject, "Title"));
            cheatsEnabledConfirmationTitleText.text = "<color=lime>TRICHES</color> ACTIVÉS :^)";

            //Text cheatsEnabledConfirmationButtonsText = CommonFunctions.getTextfromGameObject(CommonFunctions.getGameObjectChild(cheatsEnabledConfirmationObject, "Details Tip"));
            //cheatsEnabledConfirmationButtonsText.text = "HOME ou ~";
        }

        public static string getCheatStatus(string cheatStatus)
        {
            if(cheatStatus == null) { return null; }
            else
            {
                switch(cheatStatus)
                {
                    case "STAY ACTIVE": { return "GARDER ACTIVÉ"; }
                    case "DISABLE ON RELOAD": { return "DÉSACTIVER SUR RECHARGEMENT"; }
                    case "EQUIP": { return "ÉQUIPPER"; }
                    case "REMOVE": { return "SUPPRIMER"; }
                    case "OPEN": { return "OUVRIR"; }
                    case "KILL ALL": { return "TUE TOUS"; }
                    case "STATIC": { return "STATIQUE"; }
                    case "DYNAMIC": { return "DYNAMIQUE"; }
                    case "REBUILD": { return "RECONSTRUIRE"; }
                    case "REBUILDING...": { return "EN COURS..."; }
                    default: { return null; }
                }
            }
        }

        public static string getCheatName(string cheatIdentifier)
        {
            switch(cheatIdentifier)
            {
                case "ultrakill.keep-enabled": { return "GARDER CODES DE TRICHES ACTIVÉS"; }

                case "ultrakill.spawner-arm": { return "BRAS DE SPAWN"; }
                case "ultrakill.teleport-menu": { return "MENU TELEPORTATION"; }
                case "ultrakill.full-bright": { return "LUMINOSITÉ MAXIMUM"; }

                case "ultrakill.noclip": { return "NOCLIP"; }
                case "ultrakill.flight": { return "VOL"; }
                case "ultrakill.infinite-wall-jumps": { return "SAUTS MURS INFINIS"; }

                case "ultrakill.no-weapon-cooldown": { return "AUCUNE TEMPS DE RECHARGEMENT"; }
                case "ultrakill.infinite-power-ups": { return "BONUS INFINIS"; }

                case "ultrakill.blind-enemies": { return "ENNEMIS AVEUGLES"; }
                case "ultrakill.disable-enemy-spawns": { return "DÉSACTIVER LES ENNEMIS"; }
                case "ultrakill.invincible-enemies": { return "ENNEMIS INVINCIBLES"; }
                case "ultrakill.kill-all-enemies": { return "TUER TOUS LES ENNEMIS"; }

                case "ultrakill.sandbox.quick-save": { return "SAUVEGARDE RAPIDE"; }
                case "ultrakill.sandbox.quick-load": { return "CHARGEMENT RAPIDE"; }
                case "ultrakill.sandbox.save-menu": { return "GESTION DE SAUVEGARDES"; }
                case "ultrakill.sandbox.clear": { return "EFFACER LA MAP"; }
                case "ultrakill.sandbox.rebuild-nav": { return "NAVIGATION DES ENNEMIES"; }
                case "ultrakill.sandbox.snapping": { return "COLLAGE DES OBJETS"; }
                case "ultrakill.sandbox.physics": { return "PHYSIQUES DES OBJETS"; }
                case "ultrakill.sandbox.crash-mode": { return "MODE CLASH"; }

            }

            return cheatIdentifier;
        }

        public Cheats(ref GameObject coreGame)
        {
            this.patchCheatConsentPanel(ref coreGame);

        }


    }
}
