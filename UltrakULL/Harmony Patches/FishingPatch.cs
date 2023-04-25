using HarmonyLib;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(FishingHUD),"ShowHUD")]
    public class FishingHUDPatch
    {
        [HarmonyPostfix]
        public static void FishingHUDPatch_Postfix(ref GameObject ___outOfWaterMessage, ref GameObject ___hookedContainer)
        {
            Text outOfWaterText = GetTextfromGameObject(GetGameObjectChild(___outOfWaterMessage,"Text"));
            outOfWaterText.text = LanguageManager.CurrentLanguage.fishing.fish_outOfWater;
            
            Text hookedText = GetTextfromGameObject(GetGameObjectChild(___hookedContainer,"Text"));
            hookedText.text = LanguageManager.CurrentLanguage.fishing.fish_rodHooked;
        }
    }

    [HarmonyPatch(typeof(FishingHUD),"ShowFishCaught")]
    public class ShowFishPatch
    {
        [HarmonyPostfix]
        public static void ShowFish_Postfix(ref Text ___fishCaughtText,ref GameObject ___fishSizeContainer,bool show = true, FishObject fish = null)
        {
            if(show && fish != null)
            {
                string fishName = "";
                switch(fish.fishName)
                { 
                    case "Funny Stupid Fish (Friend)":
                    {
                        fishName = LanguageManager.CurrentLanguage.fishing.fish_funnyStupidFish;
                        break;
                    }
                    case "PITR Fish":
                    {
                        fishName = LanguageManager.CurrentLanguage.fishing.fish_pitrFish;
                        break;
                    }
                    case "Trout":
                    {
                        fishName = LanguageManager.CurrentLanguage.fishing.fish_trout;
                        break;
                    }
                    case "Metal Fish":
                    {
                        fishName = LanguageManager.CurrentLanguage.fishing.fish_amidEvilFish;
                        break;
                    }
                    case "Chomper":
                    {
                        fishName = LanguageManager.CurrentLanguage.fishing.fish_chomper;
                        break;
                    }
                    case "Bomb Fish":
                    {
                        fishName = LanguageManager.CurrentLanguage.fishing.fish_bombFish;
                        break;
                    }
                    case "Eyeball":
                    {
                        fishName = LanguageManager.CurrentLanguage.fishing.fish_gibeye;
                        break;
                    }
                    case "Frog (?)":
                    {
                        fishName = LanguageManager.CurrentLanguage.fishing.fish_ironLungFish;
                        break;
                    }
                    case "Dope Fish":
                    {
                        fishName = LanguageManager.CurrentLanguage.fishing.fish_dopeFish;
                        break;
                    }
                    case "Stickfish":
                    {
                        fishName = LanguageManager.CurrentLanguage.fishing.fish_stickFish;
                        break;
                    }
                    case "Cooked Fish":
                    {
                        fishName = LanguageManager.CurrentLanguage.fishing.fish_cookedFish;
                        break;
                    }
                    case "Shark":
                    {
                        fishName = LanguageManager.CurrentLanguage.fishing.fish_shark;
                        break;
                    }
                }
                ___fishCaughtText.text ="<size=28>" + LanguageManager.CurrentLanguage.fishing.fish_fishCaught + "</size> <color=orange>" + fishName + "</color>";
                
                Text fishSizeText = GetTextfromGameObject(___fishSizeContainer);
                fishSizeText.text = LanguageManager.CurrentLanguage.fishing.fish_size;
            }
        }
    }

    [HarmonyPatch(typeof(FishDB),"SetupWater")]
    public class DisplayWaterType
    {
        [HarmonyPostfix]
        public static void DisplayWaterType_Postfix(ref FishDB __instance)
        {
            switch(__instance.fullName)
            {
                case "The Ocean": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_ocean; break;}
                case "Cave Pool": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_cavePool; break;}
                case "Stream": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_stream; break;}
                case "Lake Waters": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_lake; break;}
                case "Lower Bloods": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_lakeBloodLower; break;}
                case "Lake Of Blood": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_lakeBlood; break;}
                case "Water Well": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_waterWell; break;}
                case "Pan Oil": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_panOil; break;}
                case "Holy Lake": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_lakeHoly; break;}
                case "Deeper Lake Waters": {__instance.fullName = LanguageManager.CurrentLanguage.fishing.fish_lakeDeep; break;}
            }
        }
    }
    
    [HarmonyPatch(typeof(FishEncyclopedia),"DisplayFish")]
    public class DisplayFish
    {
        [HarmonyPrefix]
        public static bool DisplayFish_Prefix(ref FishObject fish, FishEncyclopedia __instance)
        {
            switch(fish.fishName)
            {
                case "Funny Stupid Fish (Friend)":
                {
                    fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_funnyStupidFish;
                    fish.description = LanguageManager.CurrentLanguage.fishing.fish_funnyStupidFishDescription1 + "\n\n"
                                        + LanguageManager.CurrentLanguage.fishing.fish_funnyStupidFishDescription2;
                    break;
                }
                case "PITR Fish":
                {
                    fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_pitrFish;
                    fish.description = LanguageManager.CurrentLanguage.fishing.fish_pitrFishDescription1 + "\n\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_pitrFishDescription2;
                    break;
                }
                case "Trout":
                {
                    fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_trout;
                    fish.description = LanguageManager.CurrentLanguage.fishing.fish_troutDescription1 + "\n\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_troutDescription2;
                    break;
                }
                case "Metal Fish":
                {
                    fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_amidEvilFish;
                    fish.description = LanguageManager.CurrentLanguage.fishing.fish_amidEvilFishDescription1 + "\n\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_amidEvilFishDescription2;
                    break;
                }
                case "Chomper":
                {
                    fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_chomper;
                    fish.description = LanguageManager.CurrentLanguage.fishing.fish_chomperDescription1 + "\n\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_chomperDescription2;
                    break;
                }
                case "Bomb Fish":
                {
                    fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_bombFish;
                    fish.description = LanguageManager.CurrentLanguage.fishing.fish_bombFishDescription1 + "\n\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_bombFishDescription2;
                    break;
                }
                case "Eyeball":
                {
                    fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_gibeye;
                    fish.description = LanguageManager.CurrentLanguage.fishing.fish_gibeyeDescription1 + "\n\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_gibeyeDescription2;
                    break;
                }
                case "Frog (?)":
                {
                    fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_ironLungFish;
                    fish.description = LanguageManager.CurrentLanguage.fishing.fish_ironLungFishDescription1 + "\n\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_ironLungFishDescription2;
                    break;
                }
                case "Dope Fish":
                {
                    fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_dopeFish;
                    fish.description = LanguageManager.CurrentLanguage.fishing.fish_dopeFishDescription1 + "\n\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_dopeFishDescription2;
                    break;
                }
                case "Stickfish":
                {
                    fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_stickFish;
                    fish.description = LanguageManager.CurrentLanguage.fishing.fish_stickFishDescription1 + "\n\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_stickFishDescription2;
                    break;
                }
                case "Cooked Fish":
                {
                    fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_cookedFish;
                    fish.description = LanguageManager.CurrentLanguage.fishing.fish_cookedFishDescription1 + "\n\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_cookedFishDescription2;
                    break;
                }
                case "Shark":
                {
                    fish.fishName = LanguageManager.CurrentLanguage.fishing.fish_shark;
                    fish.description = LanguageManager.CurrentLanguage.fishing.fish_sharkDescription1 + "\n\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_sharkDescription2;
                    break;
                }
                default:
                {
                    break;
                }
            }
            return true;
        }
    }
}