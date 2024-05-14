using HarmonyLib;
using System;
using System.Globalization;
using TMPro;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(Speedometer), "FixedUpdate")]
    public static class SpeedometerPatch
    {
        [HarmonyPrefix]
        public static bool FixedUpdate_Prefix(TimeSince ___lastUpdate, bool ___classicVersion, TextMeshProUGUI ___textMesh, int ___type)
        {
            float num = 0f;
            string arg = "";
            if(!___classicVersion)
            {
                switch (___type)
                {
                    case 0:
                        return false;
                    case 1:
                        num = MonoSingleton<PlayerTracker>.Instance.GetPlayerVelocity(true).magnitude;
                        arg = "u";
                        break;
                    case 2:
                        num = Vector3.ProjectOnPlane(MonoSingleton<PlayerTracker>.Instance.GetPlayerVelocity(true), Vector3.up).magnitude;
                        arg = "hu";
                        break;
                    case 3:
                        num = Mathf.Abs(MonoSingleton<PlayerTracker>.Instance.GetPlayerVelocity(true).y);
                        arg = "vu";
                        break;
                }
                if (___lastUpdate > 0.064f)
                {
                    ___textMesh.text = string.Format(LanguageManager.CurrentLanguage.misc.classicHud_speed + ": {0:0.00} {1}/s", num, arg);
                    ___lastUpdate = 0;
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
