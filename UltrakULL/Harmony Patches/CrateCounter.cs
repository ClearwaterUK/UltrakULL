using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltrakULL.json;
using UnityEngine.SceneManagement;

namespace UltrakULL.Harmony_Patches
{

    //@Override
    //Overrides the private CoinsToPoints function in the CrateCounter class
    [HarmonyPatch(typeof(CrateCounter), "CoinsToPoints")]
    public static class Localize_CoinTranslation
    {
        [HarmonyPrefix]
        public static bool CoinsToPoints_MyPatch(CrateCounter __instance, int ___savedCoins)
        {
            if (SceneManager.GetActiveScene().name == "Level 4-S")
            {
                GameProgressSaver.AddMoney(___savedCoins * 100);

                MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage(string.Concat(new object[]
                {
                    "<color=grey>" + LanguageManager.CurrentLanguage.act2.act2_greedSecret_transactionComplete1 + ":</color> ",
                    ___savedCoins,
                    " " + LanguageManager.CurrentLanguage.act2.act2_greedSecret_transactionComplete2 +" <color=orange>=></color> ",
                    StatsManager.DivideMoney(___savedCoins * 100),
                    "<color=orange>P</color>"
                }), "", "", 0, false);
                ___savedCoins = 0;
            }
            return false;
        }
    }
}
