using HarmonyLib;
using UnityEngine;
using TMPro;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(MoneyText), "DivideMoney")]
    public static class MoneyTextPatch
    {
        [HarmonyPostfix]
        public static void DivideMoneyPatch(int dosh, ref string __result)
        {
            if (dosh > 1000000000)
            {
                __result = LanguageManager.CurrentLanguage.shop.shop_lotsOfMoney;
            }
        }
    }
    [HarmonyPatch(typeof(MoneyText), "UpdateMoney")]
    public static class UpdateMoneyPatch
    {
        [HarmonyPostfix]
        public static void UpdateMoneyPostfix(MoneyText __instance)
        {
            TextMeshProUGUI tmtext = __instance.GetComponent<TextMeshProUGUI>();
            tmtext.text = MoneyText.DivideMoney(GameProgressSaver.GetMoney()) + LanguageManager.CurrentLanguage.shop.shop_moneyCount;
        }
    }

}
