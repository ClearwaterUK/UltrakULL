using HarmonyLib;
using UnityEngine.UI;
using UltrakULL.json;
using System;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the DisplayInfo method from the EnemyInfoPage class. This is to allow swapping out of monster bios in the shop.
    [HarmonyPatch(typeof(EnemyInfoPage), "DisplayInfo", new Type[] { typeof(SpawnableObject) })]
    public static class Localize_EnemyInfo
    {
        [HarmonyPostfix]
        public static void DisplayInfo_Postfix(SpawnableObject source, EnemyInfoPage __instance, Text ___enemyPageTitle, Text ___enemyPageContent)
        {
            string enemyName = EnemyBios.getName(source.objectName);
            string enemyType = EnemyBios.getType(source.type);
            string enemyDescription = EnemyBios.getDescription(source.objectName);
            string enemyStrategy = EnemyBios.getStrategy(source.objectName);

            ___enemyPageTitle.text = enemyName;
            string text = "<color=orange>" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_type + ": " + enemyType + "\n\n" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_data + ":</color>\n";
            if (MonoSingleton<BestiaryData>.Instance.GetEnemy(source.enemyType) > 1)
            {
                text += enemyDescription;
            }
            else
            {
                text += "???";
            }
            text = text + "\n\n<color=orange>" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_strategy + ":</color>\n" + enemyStrategy;
            ___enemyPageContent.text = text;

        }
    }
}
