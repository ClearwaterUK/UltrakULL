using HarmonyLib;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the RicoshotPointsCheck from the Coin class. Used for translating additional style strings that come from ricochets.
    [HarmonyPatch(typeof(Coin), "RicoshotPointsCheck")]
    public static class LocalizeTranslateStyleStrings
    {
        [HarmonyPrefix]
        public static bool RicoshotPointsCheck_MyPatch(Coin __instance, GameObject ___altBeam, bool ___wasShotByEnemy, StyleHUD ___shud, EnemyIdentifier ___eid)
        {
            string text = "";
            int num = 50;
            RevolverBeam revolverBeam;
            if (___altBeam != null && ___altBeam.TryGetComponent<RevolverBeam>(out revolverBeam) && revolverBeam.ultraRicocheter)
            {
                text = "<color=orange>" + LanguageManager.CurrentLanguage.style.style_ricoshotUltra + "</color>";
                num += 50;
            }
            if (___wasShotByEnemy)
            {
                text += "<color=red>" + LanguageManager.CurrentLanguage.style.style_ricoshotCounter + "</color>";
                num += 50;
            }
            if (__instance.ricochets > 1)
            {
                num += __instance.ricochets * 15;
            }
            StyleHUD styleHUD = ___shud;
            int points = num;
            string pointID = "ultrakill.ricoshot";
            string prefix = text;
            styleHUD.AddPoints(points, pointID, __instance.sourceWeapon, ___eid, __instance.ricochets, prefix, "");

            return false;
        }
    }
}
