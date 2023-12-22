using HarmonyLib;
using TMPro;
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
            if(isUsingEnglish())
            {
                return;
            }
            if(___shopCanvas != null)
            {
                //Secret testaments (Don't do anything here since it's taken care of elsewhere
                if (__instance.gameObject.name == "Testament Shop" && GetCurrentSceneName().Contains("-S"))
                {
                    return;
                }

                //Prime testaments
                if (__instance.gameObject.name == "Testament Shop" && GetCurrentSceneName().Contains("P-"))
                {
                    Logging.Warn("Prime end testament, getting text");
                    TextMeshProUGUI primeEndText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(___shopCanvas.gameObject,"Border"),"TipBox"),
                        "Panel"),"Scroll View"),"Viewport"),"Content"),"Text (1)"));
                    PrimeSanctumStrings pss = new PrimeSanctumStrings();
                    primeEndText.text = pss.GetSecretText();
                    return;
                }
                
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