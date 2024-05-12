using HarmonyLib;
using TMPro;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(Speedometer), "FixedUpdate")]
    public static class SpeedometerPatch
    {
        [HarmonyPrefix]
        public static bool FixedUpdate_Prefix(TimeSince ___lastUpdate, bool ___classicVersion, TextMeshProUGUI ___textMesh)
        {
            Rigidbody rb = MonoSingleton<NewMovement>.Instance.rb;
            if (MonoSingleton<NewMovement>.Instance.ridingRocket)
            {
                rb = MonoSingleton<NewMovement>.Instance.ridingRocket.rb;
            }
            if ((___lastUpdate > 0.064f) && !___classicVersion)
            {
                ___textMesh.text = string.Format(LanguageManager.CurrentLanguage.misc.classicHud_speed + ": {0:0.00} u/s", Vector3.ProjectOnPlane(rb.velocity, Vector3.up).magnitude);
                ___lastUpdate = 0;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
