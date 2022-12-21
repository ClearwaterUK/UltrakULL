using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    class Sandbox
    {
        private void PatchSandboxDupeMenu()
        {
            GameObject canvas = GetInactiveRootObject("Canvas");

            GameObject dupeMenu = GetGameObjectChild(GetGameObjectChild(canvas, "Cheat Menu"), "Sandbox Saves");

            Text dupeMenuTitle = GetTextfromGameObject(GetGameObjectChild(dupeMenu, "Title"));
            dupeMenuTitle.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesTitle;

            Text dupeMenuOpenFolder = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(dupeMenu, "Directory Button Wrapper"),"Directory Button"),"Text"));
            dupeMenuOpenFolder.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesOpenFolder;

            Text dupeMenuPlaceholder = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(dupeMenu, "Button"), "InputField"), "Placeholder"));
            dupeMenuPlaceholder.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesSaveNamePrompt;

            Text dupeMenuSave = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(dupeMenu, "New Save Wrapper"), "Save Button"), "Text"));
            dupeMenuSave.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesNewSave;
        }

        private void PatchMisc()
        {
            GameObject todShop = GameObject.Find("Time of day Shop");

            //Time of day loading message
            Text todShopLoadingText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(todShop,"Canvas"),"Border"), "TipBox"),"Panel"),"Blocker"),"Panel"),"Text"));

            todShopLoadingText.text = LanguageManager.CurrentLanguage.misc.loading;
        }

        public Sandbox()
        {
            PatchSandboxDupeMenu();
            PatchMisc();
        }

    }
}
