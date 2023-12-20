using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;


namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(SceneHelper),"OnSceneLoaded")]
    public class LoadingTextPatch
    {
        public static TextMeshProUGUI loadingText;
        
        public static void updateLoadingText()
        {
            if(loadingText != null)
            {
                loadingText.text = LanguageManager.CurrentLanguage.misc.loading;
            }
        }
        [HarmonyPostfix]
        public static void LoadingTextPatch_Postfix(Scene scene, LoadSceneMode mode, ref SceneHelper __instance, ref GameObject ___loadingBlocker)
        {
            if(!isUsingEnglish())
            {
                loadingText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(___loadingBlocker,"Panel"),"Text"));
                loadingText.text = LanguageManager.CurrentLanguage.misc.loading;
            }

            
        }
    }
}