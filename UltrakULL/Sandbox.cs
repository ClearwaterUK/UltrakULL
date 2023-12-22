using TMPro;
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

            TextMeshProUGUI dupeMenuTitle = GetTextMeshProUGUI(GetGameObjectChild(dupeMenu, "Title"));
            dupeMenuTitle.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesTitle;

            TextMeshProUGUI dupeMenuOpenFolder = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(dupeMenu, "Directory Button Wrapper"),"Directory Button"),"Text"));
            dupeMenuOpenFolder.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesOpenFolder;

            TextMeshProUGUI dupeMenuPlaceholder = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(dupeMenu, "Button"), "InputField"), "Placeholder"));
            dupeMenuPlaceholder.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesSaveNamePrompt;

            TextMeshProUGUI dupeMenuSave = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(dupeMenu, "New Save Wrapper"), "Save Button"), "Text"));
            dupeMenuSave.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesNewSave;
        }

        private void PatchMisc()
        {
            GameObject sandboxShop = GameObject.Find("Sandbox Shop");
            
            
            GameObject sandboxShopCanvas =
                GetGameObjectChild(GetGameObjectChild(sandboxShop, "Canvas"), "Border");
            
            //Main menu
            GameObject sandboxShopMenu = GetGameObjectChild(sandboxShopCanvas, "Main Menu");

            TextMeshProUGUI sandboxShopTitle = GetTextMeshProUGUI(GetGameObjectChild(sandboxShopMenu, "Menu Title"));
            sandboxShopTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.chapter_sandbox + "--";

            TextMeshProUGUI sandboxShopTimeOfDayButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(sandboxShopMenu, "TimeOfDayButton"), "Text"));
            sandboxShopTimeOfDayButton.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_timeOfDay;
            
            TextMeshProUGUI sandboxShopWorldOptionsButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(sandboxShopMenu, "WorldOptionsButton"), "Text"));
            sandboxShopWorldOptionsButton.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptions;
            
            TextMeshProUGUI sandboxShopIconsButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(sandboxShopMenu, "IconsButton"), "Text"));
            sandboxShopIconsButton.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_icons;
            
            //Time of day
            GameObject sandboxShopTimeOfDay = GetGameObjectChild(GetGameObjectChild(sandboxShopCanvas, "TOD Changer"),"Panel");
            TextMeshProUGUI sandboxShopTimeOfDayLoading =
                GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(sandboxShopTimeOfDay, "Blocker"), "Panel"), "Text"));
            sandboxShopTimeOfDayLoading.text = LanguageManager.CurrentLanguage.misc.loading;
            TextMeshProUGUI sandboxShopTimeOfDayClose = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(sandboxShopTimeOfDay, "Close Button"),"Text"));
            sandboxShopTimeOfDayClose.text = LanguageManager.CurrentLanguage.options.save_close;
            
            //World options
            GameObject sandboxShopWorldOptions = GetGameObjectChild(GetGameObjectChild(sandboxShopCanvas, "World Options"),"Panel");
            TextMeshProUGUI sandboxShopWorldOptionsTitle = GetTextMeshProUGUI(GetGameObjectChild(sandboxShopWorldOptions, "Title"));
            sandboxShopWorldOptionsTitle.text =
                "--" + LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsTitle + "--";
            TextMeshProUGUI sandboxWorldOptionsClose = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(sandboxShopWorldOptions, "Close Button"),"Text"));
            sandboxWorldOptionsClose.text = LanguageManager.CurrentLanguage.options.save_close;
            
            GameObject sandboxShopWorldOptionsMapBorder = GetGameObjectChild(GetGameObjectChild(sandboxShopWorldOptions,"Image"),"Map Border");
            TextMeshProUGUI sandboxShopWorldOptionsMapBorderTitle = GetTextMeshProUGUI(GetGameObjectChild(sandboxShopWorldOptionsMapBorder, "Text"));
            sandboxShopWorldOptionsMapBorderTitle.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_mapBorder;
            
            //Icons
            GameObject sandboxShopIcons = GetGameObjectChild(GetGameObjectChild(sandboxShopMenu, "Icons Menu"),"Panel");
            TextMeshProUGUI sandboxShopIconsTitle = GetTextMeshProUGUI(GetGameObjectChild(sandboxShopIcons, "Title"));
            sandboxShopIconsTitle.text =
                "--" + LanguageManager.CurrentLanguage.sandbox.sandbox_shop_iconsTitle + "--";
            
            TextMeshProUGUI sandboxShopIconsDefault = GetTextMeshProUGUI(GetGameObjectChild(sandboxShopIcons, "TipText"));
            sandboxShopIconsDefault.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_default;
            
            TextMeshProUGUI sandboxShopIconsPitr = GetTextMeshProUGUI(GetGameObjectChild(sandboxShopIcons, "TipText (1)"));
            sandboxShopIconsPitr.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_pitr;
            
            TextMeshProUGUI sandboxIconsClose = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(sandboxShopIcons, "Close Button"),"Text"));
            sandboxIconsClose.text = LanguageManager.CurrentLanguage.options.save_close;
            
            
            // Sandbox enemy modifier menu

            GameObject panel = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Canvas"),"Alter Menu Wrapper"),"Sandbox Alter Menu"),"Spawning Menu");
            
            GameObject enemyAlterMenu = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(panel,"Scroll View"),"Viewport"),"Content");
            
            TextMeshProUGUI enemyAlterMenuTitle = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(enemyAlterMenu, "Header"),"Title"));
            enemyAlterMenuTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_title;

            GameObject enemyAlterSizeMenu = GetGameObjectChild(enemyAlterMenu, "Size Options");
            TextMeshProUGUI enemyAlterSizeTitle = GetTextMeshProUGUI(GetGameObjectChild(enemyAlterSizeMenu, "Title (1)"));
            enemyAlterSizeTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_sizeTitle;

            TextMeshProUGUI enemyAlterSizeUniform = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(enemyAlterSizeMenu, "Toggle"), "Label"));
            enemyAlterSizeUniform.text = LanguageManager.CurrentLanguage.misc.enemyAlter_uniformToggle;

            GameObject enemyAlterSizeUniformContainer = GetGameObjectChild(GetGameObjectChild(enemyAlterSizeMenu, "Uniform Container"),"Image");
            TextMeshProUGUI enemyAlterSizeUniformContainerSmaller = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(enemyAlterSizeUniformContainer, "Divide By Two Button"), "Text"));
            TextMeshProUGUI enemyAlterSizeUniformContainerDefault = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(enemyAlterSizeUniformContainer, "Default Size Button"), "Text"));
            TextMeshProUGUI enemyAlterSizeUniformContainerLarger = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(enemyAlterSizeUniformContainer, "Time Two Button"), "Text"));
            enemyAlterSizeUniformContainerSmaller.text = LanguageManager.CurrentLanguage.misc.enemyAlter_uniformSmall;
            enemyAlterSizeUniformContainerDefault.text = LanguageManager.CurrentLanguage.misc.enemyAlter_uniformDefault;
            enemyAlterSizeUniformContainerLarger.text = LanguageManager.CurrentLanguage.misc.enemyAlter_uniformLarge;
            
            GameObject enemyAlterMeta = GetGameObjectChild(enemyAlterMenu, "Meta Options");
            TextMeshProUGUI enemyAlterMetaTitle = GetTextMeshProUGUI(GetGameObjectChild(enemyAlterMeta, "Title (1)"));
            enemyAlterMetaTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_metaTitle;
            
            TextMeshProUGUI enemyAlterMetaFrozen = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(enemyAlterMeta, "Toggle"),"Label"));
            enemyAlterMetaFrozen.text = LanguageManager.CurrentLanguage.misc.enemyAlter_metaFrozen;
            
            GameObject enemyAlterJumpPad = GetGameObjectChild(enemyAlterMenu, "Jump Pad Options");
            TextMeshProUGUI enemyAlterJumpPadTitle = GetTextMeshProUGUI(GetGameObjectChild(enemyAlterJumpPad, "Title (1)"));
            enemyAlterJumpPadTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_jumpPadTitle;

            //Radiance options
            GameObject enemyAlterRadiance = GetGameObjectChild(enemyAlterMenu, "Radiance Options");
            TextMeshProUGUI enemyAlterRadianceTitle = GetTextMeshProUGUI(GetGameObjectChild(enemyAlterRadiance, "Title (1)"));
            enemyAlterRadianceTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceTitle;
            
            TextMeshProUGUI enemyAlterRadianceEnable = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(enemyAlterRadiance,"Toggle"),"Label"));
            enemyAlterRadianceEnable.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceEnable;

            //Radiance details
            GameObject enemyAlterRadianceDetails = GetGameObjectChild(GetGameObjectChild(enemyAlterMenu, "Radiance Details"),"Radiance Settings");
            TextMeshProUGUI enemyAlterRadianceDetailsTier = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(enemyAlterRadianceDetails,"Radiance Tier Container"),"Title (4)"));
            enemyAlterRadianceDetailsTier.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceDetails_tier;

            TextMeshProUGUI enemyAlterRadianceHealth = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(enemyAlterRadianceDetails,"Health Multi Container"),"Title (4)"));
            enemyAlterRadianceHealth.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceHealth_tier;
            
            TextMeshProUGUI enemyAlterRadianceDamage = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(enemyAlterRadianceDetails,"Damage Multi Container"),"Title (4)"));
            enemyAlterRadianceDamage.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceDamage_tier;
            
            TextMeshProUGUI enemyAlterRadianceSpeed = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(enemyAlterRadianceDetails,"Speed Multi Container"),"Title (4)"));
            enemyAlterRadianceSpeed.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceSpeed_tier;
            
            //Close button
            TextMeshProUGUI enemyAlterClose = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(panel, "Close Button"), "Text"));
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
