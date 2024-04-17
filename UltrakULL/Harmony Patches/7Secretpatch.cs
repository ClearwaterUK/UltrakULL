using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UltrakULL.CommonFunctions;
using HarmonyLib;
using UnityEngine;
using UltrakULL.json;
using TMPro;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(BloodCheckerManager))]
    public static class _7SecretPatch
    {
        [HarmonyPatch(nameof(BloodCheckerManager.UpdateDisplay)), HarmonyPostfix]
        public static void UpdateDisplayPostfix(BloodCheckerManager __instance, BloodAbsorber bA, string ___activePainterName)
        {
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
                Debug.LogError("No room found on UpdateDisplay");
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
    }
}