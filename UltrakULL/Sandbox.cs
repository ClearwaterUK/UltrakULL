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

namespace UltrakULL
{
    class Sandbox
    {
        public void patchSandboxDupeMenu()
        {
            GameObject canvas = getInactiveRootObject("Canvas");

            GameObject dupeMenu = getGameObjectChild(getGameObjectChild(canvas, "Cheat Menu"), "Sandbox Saves");

            Text dupeMenuTitle = getTextfromGameObject(getGameObjectChild(dupeMenu, "Title"));
            dupeMenuTitle.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesTitle;

            Text dupeMenuOpenFolder = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(dupeMenu, "Directory Button Wrapper"),"Directory Button"),"Text"));
            dupeMenuOpenFolder.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesOpenFolder;

            Text dupeMenuPlaceholder = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(dupeMenu, "Button"), "InputField"), "Placeholder"));
            dupeMenuPlaceholder.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesSaveNamePrompt;

            Text dupeMenuSave = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(dupeMenu, "New Save Wrapper"), "Save Button"), "Text"));
            dupeMenuSave.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesNewSave;
        }


        public Sandbox()
        {
            patchSandboxDupeMenu();
        }

    }
}
