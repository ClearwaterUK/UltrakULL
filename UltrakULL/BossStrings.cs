using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltrakULL.json;

namespace UltrakULL
{
    class BossStrings
    {
        public string getBossName(string originalBossName,JsonParser language)
        {
            switch (originalBossName)
            {
                //Prelude bosses
                case ("MALICIOUS FACE"): { return (language.currentLanguage.enemyNames.enemyname_malFace); }
                case ("SWORDSMACHINE"): { return (language.currentLanguage.enemyNames.enemyname_swordsmachine); }
                case ("CERBERUS, GUARDIAN OF HELL"): { return (language.currentLanguage.enemyNames.enemyname_boss_cerberus); }

                //Act 1 bosses
                //Limbo
                case ("CANCEROUS RODENT"): { return (language.currentLanguage.enemyNames.enemyname_boss_cancerousRodent); }
                case ("VERY CANCEROUS RODENT"): { return (language.currentLanguage.enemyNames.enemyname_boss_veryCancerousRodent); }
                case ("HIDEOUS MASS"): { return (language.currentLanguage.enemyNames.enemyname_boss_hideousMass); }
                case ("SWORDSMACHINE \"AGONY\""): { return (language.currentLanguage.enemyNames.enemyname_boss_swordsmachineAgony); }
                case ("SWORDSMACHINE \"TUNDRA\""): { return (language.currentLanguage.enemyNames.enemyname_boss_swordsmachineTundra); }
                case ("V2"): { return (language.currentLanguage.enemyNames.enemyname_boss_v2); } //Reused for 4-4

                //Lust
                case ("THE CORPSE OF KING MINOS"): { return (language.currentLanguage.enemyNames.enemyname_boss_corpseOfKingMinos); }

                //Gluttony
                case ("GABRIEL, JUDGE OF HELL"): { return (language.currentLanguage.enemyNames.enemyname_boss_gabriel); }

                //Act 2 bosses
                //Greed
                case ("SISYPHEAN INSURRECTIONIST"): { return (language.currentLanguage.enemyNames.enemyname_boss_insurrectionist); }
                case ("MYSTERIOUS DRUID KNIGHT (& OWL)"): { return (language.currentLanguage.enemyNames.enemyname_boss_mandalore); }

                //Wrath
                case ("FERRYMAN"): { return (language.currentLanguage.enemyNames.enemyname_boss_ferryman); }
                case ("LEVIATHAN"): { return (language.currentLanguage.enemyNames.enemyname_boss_leviathan); }

                //Heresy
                case ("INSURRECTIONIST \"ANGRY\""): { return (language.currentLanguage.enemyNames.enemyname_boss_insurrectionistAngry); }
                case ("INSURRECTIONIST \"RUDE\""): { return (language.currentLanguage.enemyNames.enemyname_boss_insurrectionistRude); }
                case ("GABRIEL, THE APOSTATE OF HATE"): { return (language.currentLanguage.enemyNames.enemyname_boss_gabrielSecond); }

                //Prime Sanctums
                case ("FLESH PRISON"): { return (language.currentLanguage.enemyNames.enemyname_fleshPrison); }
                case ("MINOS PRIME"): { return (language.currentLanguage.enemyNames.enemyname_minosPrime); }

                default: { Console.WriteLine(originalBossName); return ("UNKNOWN BOSS NAME"); }
            }
        }
        public BossStrings()
        {

        }
    }
}
