using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    class Sandbox
    {
        private void PatchSandboxDupeMenu(ref GameObject canvasObj)
        {
            GameObject dupeMenu = GetGameObjectChild(GetGameObjectChild(canvasObj, "Cheat Menu"), "Sandbox Saves");

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
            GameObject sandboxShop = GameObject.Find("Sandbox Shop");
            
            GameObject sandboxShopCanvas =
                GetGameObjectChild(GetGameObjectChild(sandboxShop, "Canvas"), "Border");
            
            //Main menu
            GameObject sandboxShopMenu = GetGameObjectChild(sandboxShopCanvas, "Main Menu");

            Text sandboxShopTitle = GetTextfromGameObject(GetGameObjectChild(sandboxShopMenu, "Menu Title"));
            sandboxShopTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.chapter_sandbox + "--";

            Text sandboxShopTimeOfDayButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(sandboxShopMenu, "TimeOfDayButton"), "Text"));
            sandboxShopTimeOfDayButton.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_timeOfDay;
            
            Text sandboxShopWorldOptionsButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(sandboxShopMenu, "WorldOptionsButton"), "Text"));
            sandboxShopWorldOptionsButton.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptions;
            
            Text sandboxShopIconsButton = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(sandboxShopMenu, "IconsButton"), "Text"));
            sandboxShopIconsButton.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_icons;
            
            //Time of day
            GameObject sandboxShopTimeOfDay = GetGameObjectChild(GetGameObjectChild(sandboxShopCanvas, "TOD Changer"),"Panel");
            Text sandboxShopTimeOfDayLoading =
                GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(sandboxShopTimeOfDay, "Blocker"), "Panel"), "Text"));
            sandboxShopTimeOfDayLoading.text = LanguageManager.CurrentLanguage.misc.loading;
            Text sandboxShopTimeOfDayClose = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(sandboxShopTimeOfDay, "Close Button"),"Text"));
            sandboxShopTimeOfDayClose.text = LanguageManager.CurrentLanguage.options.save_close;
            
            //World options
            GameObject sandboxShopWorldOptions = GetGameObjectChild(GetGameObjectChild(sandboxShopCanvas, "World Options"),"Panel");
            Text sandboxShopWorldOptionsTitle = GetTextfromGameObject(GetGameObjectChild(sandboxShopWorldOptions, "Title"));
            sandboxShopWorldOptionsTitle.text =
                "--" + LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsTitle + "--";
            Text sandboxWorldOptionsClose = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(sandboxShopWorldOptions, "Close Button"),"Text"));
            sandboxWorldOptionsClose.text = LanguageManager.CurrentLanguage.options.save_close;
            
            GameObject sandboxShopWorldOptionsMapBorder = GetGameObjectChild(GetGameObjectChild(sandboxShopWorldOptions,"Image"),"Map Border");
            Text sandboxShopWorldOptionsMapBorderTitle = GetTextfromGameObject(GetGameObjectChild(sandboxShopWorldOptionsMapBorder, "Text"));
            sandboxShopWorldOptionsMapBorderTitle.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_mapBorder;
            
            //Icons
            GameObject sandboxShopIcons = GetGameObjectChild(GetGameObjectChild(sandboxShopMenu, "Icons Menu"),"Panel");
            Text sandboxShopIconsTitle = GetTextfromGameObject(GetGameObjectChild(sandboxShopIcons, "Title"));
            sandboxShopIconsTitle.text =
                "--" + LanguageManager.CurrentLanguage.sandbox.sandbox_shop_iconsTitle + "--";
            
            Text sandboxShopIconsDefault = GetTextfromGameObject(GetGameObjectChild(sandboxShopIcons, "TipText"));
            sandboxShopIconsDefault.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_default;
            
            Text sandboxShopIconsPitr = GetTextfromGameObject(GetGameObjectChild(sandboxShopIcons, "TipText (1)"));
            sandboxShopIconsPitr.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_pitr;
            
            Text sandboxIconsClose = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(sandboxShopIcons, "Close Button"),"Text"));
            sandboxIconsClose.text = LanguageManager.CurrentLanguage.options.save_close;
            
            
            // Sandbox enemy modifier menu
            
            GameObject enemyAlterMenu = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Canvas"),"Alter Menu Wrapper"),"Sandbox Alter Menu"),"Spawning Menu"),"Scroll View"),"Viewport");

        }

        public Sandbox(ref GameObject canvasObj)
        {
            PatchSandboxDupeMenu(ref canvasObj);    
            PatchMisc();
        }

    }
}
