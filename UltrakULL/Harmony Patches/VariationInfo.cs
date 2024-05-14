using HarmonyLib;
using TMPro;
using UnityEngine.UI;
using UltrakULL.json;

using static UltrakULL.CommonFunctions;


namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the UpdateMoney method from the VariationInfo class. This is needed to patch the "ALREADY OWNED" string, and will save having to change every single seperate button containing this string in the shop.
    [HarmonyPatch(typeof(VariationInfo), "UpdateMoney")]
    public static class LocalizeVariationOwnership
    {
        [HarmonyPostfix]
        public static void UpdateMoney_Postfix(VariationInfo __instance, int ___money, bool ___alreadyOwned, TMP_Text ___buttonText)
        {
            if(isUsingEnglish())
            {
                return;
            }
                if (!___alreadyOwned)
                {
                    if (__instance.cost < 0)
                    {
                        __instance.costText.text = "<color=red>" + LanguageManager.CurrentLanguage.misc.weapons_unavailable + "</color>";
                    }
                    else if (__instance.cost > ___money)
                    {
                        __instance.costText.text = "<color=red>" + MoneyText.DivideMoney(__instance.cost) + "P</color>";
                    }
                    else
                    {
                        __instance.costText.text = "<color=white>" + MoneyText.DivideMoney(__instance.cost) + "</color><color=orange>P</color>";
                    }
                }
                else
                {
                    __instance.costText.text = LanguageManager.CurrentLanguage.misc.weapons_alreadyBought;
                }
            ___buttonText.text = (___buttonText.text == "ALREADY OWNED" ? LanguageManager.CurrentLanguage.misc.weapons_alreadyBought : ___buttonText.text);
        }
    }
}
