using HarmonyLib;
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
        [HarmonyPostfix]
        public static void LoadingTextPatch_Postfix(Scene scene, LoadSceneMode mode, ref SceneHelper __instance, ref GameObject ___loadingBlocker)
        {
            Text loadingText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(___loadingBlocker,"Panel"),"Text"));
            loadingText.text = LanguageManager.CurrentLanguage.misc.loading;
        }
    }
}