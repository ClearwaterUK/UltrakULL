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

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(Nailgun))]
    public static class NailgunPatch
    {
        [HarmonyPatch("Start"), HarmonyPostfix]
        public static void NailgunPostfix(Nailgun __instance, TMP_Text ___statusText)
        {
            Thread.Sleep(3);
            if (Core.GlobalFontReady)
            {
                __instance.ammoText.font = TextFontSwap.originalFont;
            }
            /*if(__instance.gameObject.name.ToLower().Contains("zapper") && (___statusText != null))
            {
                GameObject zapperImage = ___statusText.transform.parent.gameObject;
                TextMeshProUGUI rechargeText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(zapperImage, "ZapperRecharge"), "Text (TMP)"));
                rechargeText.text = "充電中";
            }*/
        }

        [HarmonyPatch("UpdateZapHud"), HarmonyPostfix]
        public static void zapperpostfix(Nailgun __instance, Zapper ___currentZapper, CameraController ___cc, TMP_Text ___statusText)
        {
            if (___currentZapper == null)
            {
                if (!__instance.gameObject.name.ToLower().Contains("zapper"))
                {
                    return;
                }
                RaycastHit raycastHit;
                EnemyIdentifierIdentifier enemyIdentifierIdentifier;
                if (Physics.Raycast(___cc.GetDefaultPos(), ___cc.transform.forward, out raycastHit,
                    float.PositiveInfinity, LayerMaskDefaults.Get(LMD.EnemiesAndEnvironment)) &&
                    raycastHit.collider.gameObject.layer != 8 && raycastHit.collider.gameObject.layer != 24 &&
                    raycastHit.collider.TryGetComponent<EnemyIdentifierIdentifier>(out enemyIdentifierIdentifier) &&
                    enemyIdentifierIdentifier.eid && !enemyIdentifierIdentifier.eid.dead)
                {
                    if (raycastHit.distance < __instance.zapper.maxDistance - 5f)
                    {
                        ___statusText.text = "準備完了";
                    }
                    else
                    {
                        ___statusText.text = (__instance.altVersion ? "遠い" : "範囲外");
                    }
                }
                else
                {
                    Logging.Info("NMOONOMO");
                    ___statusText.text = (__instance.altVersion ? "なし" : "対象なし");
                }
            }
            if (___currentZapper.distance > ___currentZapper.maxDistance || ___currentZapper.raycastBlocked)
            {
                Logging.Info("MONMO");
                ___statusText.text = (___currentZapper.raycastBlocked ? "障害物" : (__instance.altVersion ? "遠い" : "範囲外"));
                return;
            }
            Logging.Info("NmONMO");
            ___statusText.text = (__instance.altVersion ? "" : "距離: ") + ___currentZapper.distance.ToString("f1");
        }

    }
}
