using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using HarmonyLib;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(RumbleManager), "ResolveFullName")]
    public class RumbleOptionsPatch
    {
        [HarmonyPrefix]
        public static bool RumbleOptionsFullname(ref string key)
        {
            if(isUsingEnglish())
            {
                return true;
            }
            switch (key)
            {
                case "rumble.coin_toss": {key = LanguageManager.CurrentLanguage.options.rumble_coinToss;break;}
                case "rumble.dash": {key = LanguageManager.CurrentLanguage.options.rumble_dash;break;}
                case "rumble.fall_impact_heave": {key = LanguageManager.CurrentLanguage.options.rumble_heavyFallImpact;break;}
                case "rumble.fall_impact": {key = LanguageManager.CurrentLanguage.options.rumble_heavyFall;break;}
                case "rumble.gun.fire": {key = LanguageManager.CurrentLanguage.options.rumble_gunFire;break;}
                case "rumble.gun.fire_projectiles": {key = LanguageManager.CurrentLanguage.options.rumble_gunFireProjectile;break;}
                case "rumble.gun.fire_strong": {key = LanguageManager.CurrentLanguage.options.rumble_gunFireStrong;break;}
                case "rumble.gun.nailgun_fire": {key = LanguageManager.CurrentLanguage.options.rumble_nailgunFire;break;}
                case "rumble.gun.railcannon_idle": {key = LanguageManager.CurrentLanguage.options.rumble_railcannonIdle;break;}
                case "rumble.gun.revolver_charge": {key = LanguageManager.CurrentLanguage.options.rumble_revolverCharge;break;}
                case "rumble.gun.sawblade": {key = LanguageManager.CurrentLanguage.options.rumble_sawblade;break;}
                case "rumble.gun.shotgun_charge": {key = LanguageManager.CurrentLanguage.options.rumble_shotgunCharge;break;}
                case "rumble.gun.super_saw": {key = LanguageManager.CurrentLanguage.options.rumble_superSaw;break;}
                case "rumble.jump": {key = LanguageManager.CurrentLanguage.options.rumble_jump;break;}
                case "rumble.magnet_released": {key = LanguageManager.CurrentLanguage.options.rumble_magnet;break;}
                case "rumble.parry_flash": {key = LanguageManager.CurrentLanguage.options.rumble_parryFlash;break;}
                case "rumble.punch": {key = LanguageManager.CurrentLanguage.options.rumble_punch;break;}
                case "rumble.slide": {key = LanguageManager.CurrentLanguage.options.rumble_slide;break;}
                case "rumble.whiplash.throw": {key = LanguageManager.CurrentLanguage.options.rumble_whiplashThrow;break;}
                case "rumble.whiplash.pull": {key = LanguageManager.CurrentLanguage.options.rumble_whiplashPull;break;}
                case "rumble.weapon_wheel_tick": {key = LanguageManager.CurrentLanguage.options.rumble_weaponWheel;break;}
                default:{Logging.Warn(key);break;}
            }
            return true;
        }
    }
}