using System;
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

            GameObject panel = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Canvas"),"Alter Menu Wrapper"),"Sandbox Alter Menu"),"Spawning Menu");
            
            GameObject enemyAlterMenu = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(panel,"Scroll View"),"Viewport"),"Content");
            
            Text enemyAlterMenuTitle = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(enemyAlterMenu, "Header"),"Title"));
            enemyAlterMenuTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_title;

            GameObject enemyAlterSizeMenu = GetGameObjectChild(enemyAlterMenu, "Size Options");
            Text enemyAlterSizeTitle = GetTextfromGameObject(GetGameObjectChild(enemyAlterSizeMenu, "Title (1)"));
            enemyAlterSizeTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_sizeTitle;

            Text enemyAlterSizeUniform = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(enemyAlterSizeMenu, "Toggle"), "Label"));
            enemyAlterSizeUniform.text = LanguageManager.CurrentLanguage.misc.enemyAlter_uniformToggle;

            GameObject enemyAlterSizeUniformContainer = GetGameObjectChild(GetGameObjectChild(enemyAlterSizeMenu, "Uniform Container"),"Image");
            Text enemyAlterSizeUniformContainerSmaller = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(enemyAlterSizeUniformContainer, "Divide By Two Button"), "Text"));
            Text enemyAlterSizeUniformContainerDefault = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(enemyAlterSizeUniformContainer, "Default Size Button"), "Text"));
            Text enemyAlterSizeUniformContainerLarger = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(enemyAlterSizeUniformContainer, "Time Two Button"), "Text"));
            enemyAlterSizeUniformContainerSmaller.text = LanguageManager.CurrentLanguage.misc.enemyAlter_uniformSmall;
            enemyAlterSizeUniformContainerDefault.text = LanguageManager.CurrentLanguage.misc.enemyAlter_uniformDefault;
            enemyAlterSizeUniformContainerLarger.text = LanguageManager.CurrentLanguage.misc.enemyAlter_uniformLarge;
            
            GameObject enemyAlterMeta = GetGameObjectChild(enemyAlterMenu, "Meta Options");
            Text enemyAlterMetaTitle = GetTextfromGameObject(GetGameObjectChild(enemyAlterMeta, "Title (1)"));
            enemyAlterMetaTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_metaTitle;
            
            Text enemyAlterMetaFrozen = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(enemyAlterMeta, "Toggle"),"Label"));
            enemyAlterMetaFrozen.text = LanguageManager.CurrentLanguage.misc.enemyAlter_metaFrozen;
            
            GameObject enemyAlterJumpPad = GetGameObjectChild(enemyAlterMenu, "Jump Pad Options");
            Text enemyAlterJumpPadTitle = GetTextfromGameObject(GetGameObjectChild(enemyAlterJumpPad, "Title (1)"));
            enemyAlterJumpPadTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_jumpPadTitle;

            //Radiance options
            GameObject enemyAlterRadiance = GetGameObjectChild(enemyAlterMenu, "Radiance Options");
            Text enemyAlterRadianceTitle = GetTextfromGameObject(GetGameObjectChild(enemyAlterRadiance, "Title (1)"));
            enemyAlterRadianceTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceTitle;
            
            Text enemyAlterRadianceEnable = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(enemyAlterRadiance,"Toggle"),"Label"));
            enemyAlterRadianceEnable.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceEnable;

            //Radiance details
            GameObject enemyAlterRadianceDetails = GetGameObjectChild(GetGameObjectChild(enemyAlterMenu, "Radiance Details"),"Radiance Settings");
            Text enemyAlterRadianceDetailsTier = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(enemyAlterRadianceDetails,"Radiance Tier Container"),"Title (4)"));
            enemyAlterRadianceDetailsTier.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceDetails_tier;

            Text enemyAlterRadianceHealth = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(enemyAlterRadianceDetails,"Health Multi Container"),"Title (4)"));
            enemyAlterRadianceHealth.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceHealth_tier;
            
            Text enemyAlterRadianceDamage = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(enemyAlterRadianceDetails,"Damage Multi Container"),"Title (4)"));
            enemyAlterRadianceDamage.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceDamage_tier;
            
            Text enemyAlterRadianceSpeed = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(enemyAlterRadianceDetails,"Speed Multi Container"),"Title (4)"));
            enemyAlterRadianceSpeed.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceSpeed_tier;
            
            //Close button
            Text enemyAlterClose = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(panel, "Close Button"), "Text"));
            enemyAlterClose.text = LanguageManager.CurrentLanguage.options.save_close;

            //Note: Stuff for jump pads, props and enemy boss HP bars are located in SandboxPatches because of dynamic object creation by the game

        }

        public Sandbox(ref GameObject canvasObj)
        {
            PatchSandboxDupeMenu(ref canvasObj);    
            PatchMisc();
        }

    }
}
