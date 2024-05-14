using HarmonyLib;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(RumbleManager), "ResolveFullName")]
    public class RumbleOptionsPatch
    {
        [HarmonyPrefix]
        public static bool RumbleOptionsFullname(RumbleKey key, ref string __result)
        {
            if(isUsingEnglish())
            {
                return true;
            }
            switch (key.name)
            {
                case "rumble.coin_toss": {__result = LanguageManager.CurrentLanguage.options.rumble_coinToss;break;}
                case "rumble.dash": {__result = LanguageManager.CurrentLanguage.options.rumble_dash;break;}
                case "rumble.fall_impact_heave": {__result = LanguageManager.CurrentLanguage.options.rumble_heavyFallImpact;break;}
                case "rumble.fall_impact": {__result = LanguageManager.CurrentLanguage.options.rumble_heavyFall;break;}
                case "rumble.gun.fire": {__result = LanguageManager.CurrentLanguage.options.rumble_gunFire;break;}
                case "rumble.gun.fire_projectiles": {__result = LanguageManager.CurrentLanguage.options.rumble_gunFireProjectile;break;}
                case "rumble.gun.fire_strong": {__result = LanguageManager.CurrentLanguage.options.rumble_gunFireStrong;break;}
                case "rumble.gun.nailgun_fire": {__result = LanguageManager.CurrentLanguage.options.rumble_nailgunFire;break;}
                case "rumble.gun.railcannon_idle": {__result = LanguageManager.CurrentLanguage.options.rumble_railcannonIdle;break;}
                case "rumble.gun.revolver_charge": {__result = LanguageManager.CurrentLanguage.options.rumble_revolverCharge;break;}
                case "rumble.gun.sawblade": {__result = LanguageManager.CurrentLanguage.options.rumble_sawblade;break;}
                case "rumble.gun.shotgun_charge": {__result = LanguageManager.CurrentLanguage.options.rumble_shotgunCharge;break;}
                case "rumble.gun.super_saw": {__result = LanguageManager.CurrentLanguage.options.rumble_superSaw;break;}
                case "rumble.jump": {__result = LanguageManager.CurrentLanguage.options.rumble_jump;break;}
                case "rumble.magnet_released": {__result = LanguageManager.CurrentLanguage.options.rumble_magnet;break;}
                case "rumble.parry_flash": {__result = LanguageManager.CurrentLanguage.options.rumble_parryFlash;break;}
                case "rumble.punch": {__result = LanguageManager.CurrentLanguage.options.rumble_punch;break;}
                case "rumble.slide": {__result = LanguageManager.CurrentLanguage.options.rumble_slide;break;}
                case "rumble.whiplash.throw": {__result = LanguageManager.CurrentLanguage.options.rumble_whiplashThrow;break;}
                case "rumble.whiplash.pull": {__result = LanguageManager.CurrentLanguage.options.rumble_whiplashPull;break;}
                case "rumble.weapon_wheel_tick": {__result = LanguageManager.CurrentLanguage.options.rumble_weaponWheel;break;}
                default:{Logging.Warn(key.name);break;}
            }
            return false;
        }
    }
}