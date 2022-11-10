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

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(SandboxHud), "BuildSavesMenu")]
    public static class SandboxHud_Patch
    {
        [HarmonyPostfix]
        public static void BuildSavesMenu_Postfix(ref SandboxHud __instance, ref SandboxSaveItem ___sandboxSaveTemplate)
        {
            Console.WriteLine("BuildSavesMenu Postfix");

            //This is ugly af but I can't do it the optimal way, so f it, let's try this
            GameObject canvas = getInactiveRootObject("Canvas");
            
            GameObject dupeSaveList = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(canvas,"Cheat Menu"),"Sandbox Saves"),"Scroll View"),"Viewport"),"Content");

            Transform[] transformList = dupeSaveList.GetComponentsInChildren<Transform>();

            foreach (Transform t in transformList)
            {
                if(t.gameObject.name == "Text")
                {
                    Text textObject = getTextfromGameObject(t.gameObject);
                    switch(textObject.text)
                    {
                        case "Delete": { textObject.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesDelete; break; }
                        case "Save": { textObject.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesSave; break; }
                        case "Load": { textObject.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesLoad; break; }
                    }

                }
            }
        }
    }
}
