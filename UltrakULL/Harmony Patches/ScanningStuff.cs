using HarmonyLib;
using UltrakULL.json;
using UnityEngine;
using static UltrakULL.CommonFunctions;
using UnityEngine.UI;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides ScanBook from the ScanningStuff class, for the "scanning" panel and book translations.
    [HarmonyPatch(typeof(ScanningStuff), "ScanBook")]
    public static class Localize_ScanningText
    {
        [HarmonyPrefix]
        public static bool ScanBook_MyPatch(ref string text, bool noScan, int instanceId, ScanningStuff __instance)
        {
            GameObject canvas = getInactiveRootObject("Canvas");

            Text scanningText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(canvas, "ScanningStuff"), "ScanningPanel"), "Text"));
            scanningText.text = LanguageManager.CurrentLanguage.books.books_scanning;
            text = Books.getBookText();
            return true;
        }
    }
}
