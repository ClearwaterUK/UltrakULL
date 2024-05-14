using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using UltrakULL.json;
using TMPro;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(BloodCheckerManager))]
    public static class _7SecretPatch
    {
        private static string ReplacePainterName(string a)
        {
            switch (a)
            {
                case "Dumpster":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_Dumpster;
                    }
                case "Ground":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_Ground;
                    }
                case "Pillars":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_Pillars;
                    }
                case "Walls":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_Walls;
                    }
                case "Back Bookshelf":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_BackBookshelf;
                    }
                case "Bookshelf":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_Bookshelf;
                    }
                case "Bookcases":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_Bookcases;
                    }
                case "Ceiling":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_Ceiling;
                    }
                case "Desks":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_Desk;
                    }
                case "Front Bookshelf":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_FrontBookshelf;
                    }
                case "Sconces":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_Sconces;
                    }
                case "Side Wall":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_Sidewall;
                    }
                case "Walkway":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_Walkway;
                    }
                case "Window Wall":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_WindowWall;
                    }
                case "Decor":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_Decor;
                    }
                case "Floors":
                    {
                        return LanguageManager.CurrentLanguage.washing.wash_Floors;
                    }
                default:
                    {
                        Logging.Warn("Unknown painter name: \"" + a + "\"");
                        return a;
                    }
            }
        }
        [HarmonyPatch("Start"), HarmonyPostfix]
        public static void Start_Postfix(BloodCheckerManager __instance, Dictionary<GameObject, List<BloodAbsorber>> ___rooms, GameObject ___pondToDoEntry)
        {
            //Patching Checklist names here
            try
            {
                Transform parent = __instance.painterGUITemplate.transform.parent;

                Transform[] painterTransforms = parent.GetComponentsInChildren<Transform>(true);
                Logging.Debug("[painterscount]: " + painterTransforms.Length.ToString() + " [painters]");
                foreach (Transform painterTransform in painterTransforms)
                {
                    Logging.Debug("[patching painter name]: " + painterTransform.gameObject.name + "[a]");
                    if (painterTransform.childCount >= 2)
                    {
                        Transform painterObject = painterTransform.GetChild(1);
                        TextMeshProUGUI painterNameText = painterObject.GetComponent<TextMeshProUGUI>();
                        {
                            if (painterNameText != null)
                            {
                                painterNameText.text = ReplacePainterName(painterNameText.text);
                            }
                            else
                            {
                                Logging.Warn("no tmp here");
                            }
                        }
                    }
                }
                ___pondToDoEntry.transform.GetChild(0).gameObject.SetActive(false);
                ___pondToDoEntry.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = LanguageManager.CurrentLanguage.washing.wash_Pond;
            }
            catch(Exception e) 
            {
                Logging.Warn("Failed to Patch 7-S(7Secretpatch.cs)");
                if(LanguageManager.CurrentLanguage.washing == null)
                { Logging.Warn("Category is missing from the language file! Please Update it!"); return; }
                Logging.Warn(e.ToString());
            }
        }


        [HarmonyPatch("UpdateDisplay"), HarmonyPostfix]
        public static void UpdateDisplayPostfix(BloodCheckerManager __instance, BloodAbsorber bA)
        {
            try
            {
                __instance.toDoText.text = LanguageManager.CurrentLanguage.washing.wash_ToDo;
                __instance.cleanText.text = LanguageManager.CurrentLanguage.washing.wash_Clean;
                GameObject gameObject = null;
                if (bA != null)
                {
                    __instance.activePainter.text = ReplacePainterName(bA.painterName);
                    gameObject = bA.owningRoom;
                }
                else
                {
                    gameObject = __instance.pond.owningRoom;
                    __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Pond;
                }
                if (!(gameObject == null))
                {
                    switch (gameObject.name)
                    {
                        case "Courtyard":
                            {
                                __instance.roomName.SetText(LanguageManager.CurrentLanguage.washing.wash_roomCourtyard, true);
                                break;
                            }
                        case "Library":
                            {
                                __instance.roomName.SetText(LanguageManager.CurrentLanguage.washing.wash_roomLibrary, true);
                                break;
                            }
                        case "Lobby":
                            {
                                __instance.roomName.SetText(LanguageManager.CurrentLanguage.washing.wash_roomLobby, true);
                                break;
                            }
                        case "Lounge":
                            {
                                __instance.roomName.SetText(LanguageManager.CurrentLanguage.washing.wash_roomLounge, true);
                                break;
                            }
                        case "Side Room":
                            {
                                __instance.roomName.SetText(LanguageManager.CurrentLanguage.washing.wash_roomSideroom, true);
                                break;
                            }
                        default:
                            {
                                __instance.roomName.SetText(gameObject.name, true);
                                break;
                            }
                    }
                }
                //There's a bug in patch 15c that showing "CLEAN" even after you enter the uncleaned room so we'll gonna fix it here.
                int num = __instance.trackedRooms.IndexOf(gameObject);
                if (!__instance.roomCompletions[num])
                {
                    __instance.cleanText.gameObject.SetActive(false);
                }
                //bugfix end
            }
            catch (Exception e)
            {
                Logging.Warn("Failed to Patch BloodCheckerManager.UpdateDisplay!");
                Logging.Warn(e.ToString());
            }

        }
    }
}