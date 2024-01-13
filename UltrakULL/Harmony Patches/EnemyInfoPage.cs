using HarmonyLib;
using UnityEngine.UI;
using UltrakULL.json;
using System;
using TMPro;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the DisplayInfo method from the EnemyInfoPage class. This is to allow swapping out of monster bios in the shop.
    [HarmonyPatch(typeof(EnemyInfoPage), "DisplayInfo", new Type[] { typeof(SpawnableObject) })]
    public static class LocalizeEnemyInfo
    {
        [HarmonyPostfix]
        public static void DisplayInfo_Postfix(SpawnableObject source, EnemyInfoPage __instance, TMP_Text ___enemyPageTitle, TMP_Text ___enemyPageContent)
        {
            if(isUsingEnglish())
            {
                return;
            }

            string enemyName;
            if (___enemyPageTitle.text == "SWORDSMACHINE" || ___enemyPageTitle.text == "INSURRECTIONIST")
            {
                source.objectName += " DEFAULT";
                enemyName = EnemyBios.GetName(source.objectName);
                if (source.objectName == "SWORDSMACHINE DEFAULT") { source.objectName = "SWORDSMACHINE"; }
                if (source.objectName == "INSURRECTIONIST DEFAULT") { source.objectName = "INSURRECTIONIST"; }
            }
            else { enemyName = EnemyBios.GetName(source.objectName); }

            string enemyType = EnemyBios.GetType(source.type);
            string enemyDescription = EnemyBios.GetDescription(source.objectName);
            string enemyStrategy = EnemyBios.GetStrategy(source.objectName);

            ___enemyPageTitle.text = enemyName;
            string text = "</s><color=orange>" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_type + enemyType + "\n\n" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_data + "</color>\n";
            if (MonoSingleton<BestiaryData>.Instance.GetEnemy(source.enemyType) > 1)
            {
                text += enemyDescription;
            }
            else
            {
                text += "???";
            }
            text = text + "\n\n</s><color=orange>" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_strategy + "</color>\n" + enemyStrategy;
            ___enemyPageContent.text = text;
        }
    }
}
