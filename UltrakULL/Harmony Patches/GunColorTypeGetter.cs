using HarmonyLib;
using UltrakULL.json;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides OnEnable from the GunColorTypeGetter class. Used for the Soul Orb checker.
    [HarmonyPatch(typeof(GunColorTypeGetter), "OnEnable")]
    public static class LocalizeGunColorTypeShop
    {
        [HarmonyPostfix]
        public static void OnEnablePostFix_MyPatch(GunColorTypeGetter __instance)
        {
            if(isUsingEnglish())
            {
                return;
            }
            
            for (int i = 1; i < 5; i++)
            {
                bool flag = GameProgressSaver.GetTotalSecretsFound() >= GunColorController.requiredSecrets[i];
                if (!flag)
                {
                    __instance.templateTexts[i].text = string.Concat(new object[]
                    {
                        LanguageManager.CurrentLanguage.shop.shop_soulOrbs + ": ",
                        GameProgressSaver.GetTotalSecretsFound(),
                        " / ",
                        GunColorController.requiredSecrets[i]
                    });
                }
            }
        }
    }
}
