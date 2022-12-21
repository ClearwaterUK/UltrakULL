using HarmonyLib;
using System;
using UnityEngine.SceneManagement;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the SendActivity method from the DiscordController class to localize strings
    [HarmonyPatch(typeof(DiscordController), "SendActivity")]
    public static class PatchDiscordActivity
    {
        [HarmonyPrefix]
        public static bool SendActivity_MyPatch(DiscordController __instance, Discord.Activity ___cachedActivity, RankIcon[] ___rankIcons, Discord.ActivityManager ___activityManager)
        {
            if (___activityManager == null) // I don't know how this happens, but it somehow does?
                return false;
            //Details: Contains total style if in a normal level or wave number if in CG.
            if (SceneManager.GetActiveScene().name != "Main Menu")
            {
                try
                {
                    string[] splitDetails = ___cachedActivity.Details.Split(' ');
                    string[] splitState = ___cachedActivity.Details.Split(' ');

                    if (splitDetails[0] == "STYLE:")
                    {
                        ___cachedActivity.Details = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_style + ": " + splitDetails[1];
                    }
                    else if (splitDetails[0] == "WAVE:")
                    {
                        ___cachedActivity.Details = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wave + ": " + splitDetails[1];
                    }
                }
                catch (Exception splitException)
                {
                    Console.WriteLine("Exception occured in SendActivity, should be harmless unless if the console gets spammed with this");
                }
            }
            else
            {
                ___cachedActivity.Details = "";
            }

            //State: Contains current difficulty if in-level, or only displays "Main Menu"
            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                ___cachedActivity.State = LanguageManager.CurrentLanguage.levelNames.levelName_mainMenu;
            }
            else
            {
                string translatedDifficulty = MonoSingleton<PresenceController>.Instance.diffNames[MonoSingleton<PrefsManager>.Instance.GetInt("difficulty", 0)];
                switch(translatedDifficulty)
                {
                    case "HARMLESS": { translatedDifficulty = LanguageManager.CurrentLanguage.frontend.difficulty_harmless; break; }
                    case "LENIENT": { translatedDifficulty = LanguageManager.CurrentLanguage.frontend.difficulty_lenient; break; }
                    case "STANDARD": { translatedDifficulty = LanguageManager.CurrentLanguage.frontend.difficulty_standard; break; }
                    case "VIOLENT": { translatedDifficulty = LanguageManager.CurrentLanguage.frontend.difficulty_violent; break; }
                    case "BRUTAL": { translatedDifficulty = LanguageManager.CurrentLanguage.frontend.difficulty_brutal; break; }
                    case "ULTRAKILL MUST DIE": { translatedDifficulty = LanguageManager.CurrentLanguage.frontend.difficulty_umd; break; }
                }
                ___cachedActivity.State = LanguageManager.CurrentLanguage.frontend.difficulty_title + ": " + translatedDifficulty;
            }

            //Assets.SmallText: Rank name
            switch (___cachedActivity.Assets.SmallText)
            {
                case "Destructive": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_d; break; }
                case "Chaotic": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_c; break; }
                case "Brutal": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_b; break; }
                case "Anarchic": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_a; break; }
                case "Supreme": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_s; break; }
                case "SSadistic": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_ss; break; }
                case "SSShitstorm": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_sss; break; }
                case "ULTRAKILL": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_ultrakill; break; }
            }

            //Assets.LargeText = Level name
            ___cachedActivity.Assets.LargeText = LevelNames.GetDiscordLevelName(SceneManager.GetActiveScene().name);

            //Shoot the data off to Discord RPC.
            ___activityManager.UpdateActivity(___cachedActivity, delegate (Discord.Result result)
            {
            });

            return false;
        }
    }
}
