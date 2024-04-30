using System;
using HarmonyLib;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the NameAppear function from LevelNamePopup. Used for showing layer and level names at the start of a level.
    [HarmonyPatch(typeof(LevelNamePopup), "NameAppear")]
    public static class LocalizeLevelPopup
    {
        [HarmonyPrefix]
        public static bool NameAppear_MyPatch(LevelNamePopup __instance, ref string ___layerString, ref string ___nameString)
        {
            if(isUsingEnglish())
            {
                return true;
            }
            try
            {
                if (TitleManager.GetName(___nameString) == null)
                {
                    Logging.Warn("There's no translated level name here!");
                    Logging.Warn("Layer Name is:" + ___layerString);
                    Logging.Warn("Level Name is:" + ___nameString);
                    return true;
                }
                ___layerString = TitleManager.GetLayer(___layerString);
                ___nameString = TitleManager.GetName(___nameString);
            }
            catch (Exception e)
            {
                Logging.Warn("Failed to Patch Level Name Popup!");
                Logging.Warn(e.ToString());
            }
            return true;
        }
    }
}
