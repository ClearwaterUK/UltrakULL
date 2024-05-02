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
        [HarmonyPatch("Start"), HarmonyPostfix]
        public static void Startfix(BloodCheckerManager __instance, Dictionary<GameObject, List<BloodAbsorber>> ___rooms, GameObject ___pondToDoEntry)
        {
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
                                switch (painterNameText.text)
                                {
                                    case "Dumpster":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_Dumpster;
                                            break;
                                        }
                                    case "Ground":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_Ground;
                                            break;
                                        }
                                    case "Pillars":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_Pillars;
                                            break;
                                        }
                                    case "Walls":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_Walls;
                                            break;
                                        }
                                    case "Back Bookshelf":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_BackBookshelf;
                                            break;
                                        }
                                    case "Bookshelf":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_Bookshelf;
                                            break;
                                        }
                                    case "Bookcases":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_Bookcases;
                                            break;
                                        }
                                    case "Ceiling":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_Ceiling;
                                            break;
                                        }
                                    case "Desks":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_Desk;
                                            break;
                                        }
                                    case "Front Bookshelf":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_FrontBookshelf;
                                            break;
                                        }
                                    case "Sconces":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_Sconces;
                                            break;
                                        }
                                    case "Side Wall":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_Sidewall;
                                            break;
                                        }
                                    case "Walkway":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_Walkway;
                                            break;
                                        }
                                    case "Window Wall":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_WindowWall;
                                            break;
                                        }
                                    case "Decor":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_Decor;
                                            break;
                                        }
                                    case "Floors":
                                        {
                                            painterNameText.text = LanguageManager.CurrentLanguage.washing.wash_Floors;
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
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

        static bool enableUpdatepatch = true;
        [HarmonyPatch(nameof(BloodCheckerManager.UpdateDisplay)), HarmonyPostfix]
        public static void UpdateDisplayPostfix(BloodCheckerManager __instance, BloodAbsorber bA, string ___activePainterName)
        {
            try
            {
                if (!enableUpdatepatch) { return; }
                __instance.washingCanvas.enabled = true;
                __instance.toDoText.text = LanguageManager.CurrentLanguage.washing.wash_ToDo;
                __instance.cleanText.text = LanguageManager.CurrentLanguage.washing.wash_Clean;
                GameObject gameObject = null;
                if (bA != null)
                {
                    switch (bA.painterName)
                    {
                        case "Dumpster":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Dumpster;
                                break;
                            }
                        case "Ground":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Ground;
                                break;
                            }
                        case "Pillars":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Pillars;
                                break;
                            }
                        case "Walls":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Walls;
                                break;
                            }
                        case "Back Bookshelf":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_BackBookshelf;
                                break;
                            }
                        case "Bookshelf":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Bookshelf;
                                break;
                            }
                        case "Ceiling":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Ceiling;
                                break;
                            }
                        case "Desks":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Desk;
                                break;
                            }
                        case "Front Bookshelf":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_FrontBookshelf;
                                break;
                            }
                        case "Sconces":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Sconces;
                                break;
                            }
                        case "Side Wall":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Sidewall;
                                break;
                            }
                        case "Walkway":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Walkway;
                                break;
                            }
                        case "Window Wall":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_WindowWall;
                                break;
                            }
                        case "Decor":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Decor;
                                break;
                            }
                        case "Floors":
                            {
                                __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Floors;
                                break;
                            }
                        default:
                            {
                                __instance.activePainter.text = bA.painterName;
                                break;
                            }
                    }
                    gameObject = bA.owningRoom;
                }
                else
                {
                    gameObject = __instance.pond.owningRoom;
                    __instance.activePainter.text = LanguageManager.CurrentLanguage.washing.wash_Pond;
                }
                if (gameObject == null)
                {
                    Logging.Error("No room found on UpdateDisplay");
                }
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
            catch
            {
                Logging.Warn("Failed to Patch BloodCheckerManager.UpdateDisplay!");
                Logging.Warn("Disabling this for prevent spam");
                enableUpdatepatch = false;
            }

        }
    }
}