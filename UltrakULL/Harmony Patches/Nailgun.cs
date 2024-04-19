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
            Thread.Sleep(3);
            if (Core.GlobalFontReady && __instance.gameObject.name.ToLower().Contains("Magnet"))
            {
                __instance.ammoText.font = TextFontSwap.originalFont;
            }
        }

        [HarmonyPatch("UpdateZapHud"), HarmonyPostfix]
        public static void zapperpostfix(Nailgun __instance, Zapper ___currentZapper, CameraController ___cc, TMP_Text ___statusText, GameObject ___rechargingOverlay)
        {
            if (___currentZapper == null)
            {
                if (!__instance.gameObject.name.ToLower().Contains("zapper"))
                {
                    return;
                }
                if (___rechargingOverlay.activeSelf)
                {
                    TextMeshProUGUI rechargeText = GetTextMeshProUGUI(GetGameObjectChild(___rechargingOverlay, "Text (TMP)"));
                    //rechargeText.text = LanguageManager.CurrentLanguage.
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
                        ___statusText.text = "準備完了";
                    }
                    else
                    {
                        ___statusText.text = (__instance.altVersion ? "遠い" : "範囲外");
                        target = 0f;
                    }
                }
                else
                {
                    target = 0f;
                    ___statusText.text = (__instance.altVersion ? "なし" : "対象なし");
                }
                return;
            }
            if (___currentZapper.distance > ___currentZapper.maxDistance || ___currentZapper.raycastBlocked)
            {
                ___statusText.text = (___currentZapper.raycastBlocked ? "障害物" : (__instance.altVersion ? "遠い" : "範囲外"));
                return;
            }
            ___statusText.text = (__instance.altVersion ? "" : "距離: ") + ___currentZapper.distance.ToString("f1");
        }

    }
}
