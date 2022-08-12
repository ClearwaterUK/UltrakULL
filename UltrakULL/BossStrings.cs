using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltrakULL
{
    class BossStrings
    {
        public string getBossName(string originalBossName)
        {
            switch (originalBossName)
            {
                //Prelude bosses
                case ("MALICIOUS FACE"): { return ("TÊTE MALICIEUX"); }
                case ("SWORDSMACHINE"): { return ("MACHINE À EPÉE"); }
                case ("CERBERUS, GUARDIAN OF HELL"): { return ("CERBÈRE - GARDIEN D'ENFER"); }

                //Act 1 bosses
                //Limbo
                case ("CANCEROUS RODENT"): { return ("RONGEUR CANCÉREUX"); }
                case ("VERY CANCEROUS RODENT"): { return ("RONGEUR TRÈS CANCÉREUX"); }
                case ("HIDEOUS MASS"): { return ("MASSE HIDEUSE"); }
                case ("SWORDSMACHINE \"AGONY\""): { return ("MACHINE À EPÉE \"AGONIE\""); }
                case ("SWORDSMACHINE \"TUNDRA\""): { return ("MACHINE À EPÉE \"TOUNDRA\""); }
                case ("V2"): { return ("V2"); } //Reused for 4-4

                //Lust
                case ("THE CORPSE OF KING MINOS"): { return ("CADAVRE DU ROI MINOS"); }

                //Gluttony
                case ("GABRIEL, JUDGE OF HELL"): { return ("GABRIEL, JUGE D'ENFER"); }

                //Act 2 bosses
                //Greed
                case ("SISYPHEAN INSURRECTIONIST"): { return ("INSURRECTIONNALISTE SISYPHEANE"); }
                case ("MYSTERIOUS DRUID KNIGHT (& OWL)"): { return ("CHEVALIER-DRUIDE MYSTERIEUX (& HIBOU)"); }

                //Prime Sanctums
                case ("FLESH PRISON"): { return ("PRISON DE CHAIR"); }
                case ("MINOS PRIME"): { return ("MINOS PRIME"); }

                default: {return ("UNKNOWN BOSS NAME"); }


            }
        }
        public BossStrings()
        {

        }
    }
}
