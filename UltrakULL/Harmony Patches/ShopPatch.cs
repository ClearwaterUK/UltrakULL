using HarmonyLib;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(ShopZone),"TurnOn")]
    public class ShopPatch
    {
        [HarmonyPostfix]
        public static void shopPatch(ShopZone __instance, ref Canvas ___shopCanvas)
        { 
            if(___shopCanvas != null)
            {
                Text origTip = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(___shopCanvas.gameObject,"TipBox"),"Panel"),"TipText"));
                
                GameObject shopObject = ___shopCanvas.gameObject;
                
                //Redirect for the 5-3 end shop.
                if(GetCurrentSceneName() == "Level 5-3" && origTip.text == "Ow.")
                {
                    origTip.text = LanguageManager.CurrentLanguage.levelTips.leveltips_wrathThirdBroken;
                }
                else
                {
                    Shop.PatchShopRefactor(ref shopObject);
                }
                
               
            }
        }
    }
}