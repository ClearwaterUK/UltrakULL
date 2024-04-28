using HarmonyLib;
using static UltrakULL.CommonFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using TMPro;
using System.IO;
using System.Reflection;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(Nailgun))]
    public static class NailgunPatch
    {
        [HarmonyPatch("Start"), HarmonyPostfix]
        public static void NailgunPostfix(Nailgun __instance, TMP_Text ___statusText)
        {
            Thread.Sleep(5);
            if ((Core.GlobalFontReady) && (__instance.gameObject.name.ToLower().Contains("magnet")))
            {
                Logging.Info("Unswapping the attractor nailgun font, font:" + TextFontSwap.originalFont);
                __instance.ammoText.font = TextFontSwap.originalFont;
            }
        }

        static bool enablezapperfix = true;
        [HarmonyPatch("UpdateZapHud"), HarmonyPostfix]
        public static void zapperpostfix(Nailgun __instance, Zapper ___currentZapper, CameraController ___cc, TMP_Text ___statusText, GameObject ___rechargingOverlay)
        {
            try
            {
                if (!enablezapperfix) { return; }
                if (___currentZapper == null)
                {
                    if (!__instance.gameObject.name.ToLower().Contains("zapper"))
                    {
                        return;
                    }
                    if (___rechargingOverlay.activeSelf)
                    {
                        TextMeshProUGUI rechargeText = GetTextMeshProUGUI(GetGameObjectChild(___rechargingOverlay, "Text (TMP)"));
                        //RECHARGING...
                        rechargeText.text = LanguageManager.CurrentLanguage.weapon.weapon_nailgunZapperRecharging;
                    }
                    RaycastHit raycastHit;
                    EnemyIdentifierIdentifier enemyIdentifierIdentifier;
                    float target;
                    if (Physics.Raycast(___cc.GetDefaultPos(), ___cc.transform.forward, out raycastHit,
                        float.PositiveInfinity, LayerMaskDefaults.Get(LMD.EnemiesAndEnvironment)) &&
                        raycastHit.collider.gameObject.layer != 8 && raycastHit.collider.gameObject.layer != 24 &&
                        raycastHit.collider.TryGetComponent<EnemyIdentifierIdentifier>(out enemyIdentifierIdentifier) &&
                        enemyIdentifierIdentifier.eid && !enemyIdentifierIdentifier.eid.dead)
                    {
                        if (raycastHit.distance < __instance.zapper.maxDistance - 5f)
                        {
                            target = 1f - (__instance.zapper.maxDistance - 5f - raycastHit.distance) / (__instance.zapper.maxDistance - 5f);
                            //READY
                            ___statusText.text = LanguageManager.CurrentLanguage.weapon.weapon_nailgunZapperReady;
                        }
                        else
                        {
                            //TOO FAR | OUT OF RANGE
                            ___statusText.text = (__instance.altVersion ? LanguageManager.CurrentLanguage.weapon.weapon_nailgunZapperAlternateTooFar : LanguageManager.CurrentLanguage.weapon.weapon_nailgunZapperOutOfRange);
                        }
                    }
                    else
                    {
                        //NULL | NO TARGET
                        ___statusText.text = (__instance.altVersion ? LanguageManager.CurrentLanguage.weapon.weapon_nailgunZapperAlternateNull : LanguageManager.CurrentLanguage.weapon.weapon_nailgunZapperNoTarget);
                    }
                    return;
                }
                if (___currentZapper.distance > ___currentZapper.maxDistance || ___currentZapper.raycastBlocked)
                {
                    //BLOCKED (TOO FAR | OUT OF RANGE)
                    ___statusText.text = (___currentZapper.raycastBlocked ? LanguageManager.CurrentLanguage.weapon.weapon_nailgunZapperBlocked : (__instance.altVersion ? LanguageManager.CurrentLanguage.weapon.weapon_nailgunZapperAlternateTooFar : LanguageManager.CurrentLanguage.weapon.weapon_nailgunZapperOutOfRange));
                    return;
                }
                //DISTANCE:
                ___statusText.text = (__instance.altVersion ? "" : LanguageManager.CurrentLanguage.weapon.weapon_nailgunZapperDistance) + ___currentZapper.distance.ToString("f1");
            }
            catch (Exception e)
            {
                Logging.Warn("Failed to Patch zapper display!");
                if (LanguageManager.CurrentLanguage.weapon == null)
                { Logging.Warn("Category \"Weapon\" is missing from the language file!"); }
                Logging.Warn("Disabling this for prevent spam");
                Logging.Warn(e.ToString());
                enablezapperfix = false;
            }
        }

    }
}
