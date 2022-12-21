using UltrakULL.json;

namespace UltrakULL
{
    public static class BossStrings
    {
        public static string GetBossName(string originalBossName)
        {
            switch (originalBossName)
            {
                //Prelude bosses
                case ("MALICIOUS FACE"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_malFace); }
                case ("SWORDSMACHINE"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_swordsmachine); }
                case ("CERBERUS, GUARDIAN OF HELL"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_cerberus); }

                //Act 1 bosses
                //Limbo
                case ("CANCEROUS RODENT"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_cancerousRodent); }
                case ("VERY CANCEROUS RODENT"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_veryCancerousRodent); }
                case ("HIDEOUS MASS"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_hideousMass); }
                case ("SWORDSMACHINE \"AGONY\""): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_swordsmachineAgony); }
                case ("SWORDSMACHINE \"TUNDRA\""): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_swordsmachineTundra); }
                case ("V2"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_v2); } //Reused for 4-4

                //Lust
                case ("THE CORPSE OF KING MINOS"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_corpseOfKingMinos); }

                //Gluttony
                case ("GABRIEL, JUDGE OF HELL"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_gabriel); }

                //Act 2 bosses
                //Greed
                case ("SISYPHEAN INSURRECTIONIST"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_insurrectionist); }
                case ("MYSTERIOUS DRUID KNIGHT (& OWL)"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_mandalore); }

                //Wrath
                case ("FERRYMAN"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_ferryman); }
                case ("LEVIATHAN"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_leviathan); }

                //Heresy
                case ("INSURRECTIONIST \"ANGRY\""): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_insurrectionistAngry); }
                case ("INSURRECTIONIST \"RUDE\""): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_insurrectionistRude); }
                case ("GABRIEL, THE APOSTATE OF HATE"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_gabrielSecond); }

                //Prime Sanctums
                case ("FLESH PRISON"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_fleshPrison); }
                case ("MINOS PRIME"): { return (LanguageManager.CurrentLanguage.enemyNames.enemyname_minosPrime); }

                default: { return ("UNKNOWN BOSS NAME"); }
            }
        }
    }
}
