using System.Collections.Generic;
using Antlr4.StringTemplate;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class EnemyBios
    {
        private static readonly TemplateGroup BioTemplates = new TemplateGroupString(Resources.Bios);
        private static readonly TemplateGroup StrategyTemplates = new TemplateGroupString(Resources.Strategies);
        
        private static readonly EnemyNames EnemyNames = LanguageManager.CurrentLanguage.enemyNames;

        private static readonly Dictionary<string, string> Names = new Dictionary<string, string>
        {
            { "FILTH", EnemyNames.enemyname_filth },
            { "STRAY", EnemyNames.enemyname_stray },
            { "SCHISM", EnemyNames.enemyname_schism },
            { "SOLDIER", EnemyNames.enemyname_soldier },
            { "THE CORPSE OF KING MINOS", EnemyNames.enemyname_minos },
            { "STALKER", EnemyNames.enemyname_stalker },
            { "INSURRECTIONIST", EnemyNames.enemyname_boss_insurrectionist },
            { "SISYPHEAN INSURRECTIONIST", EnemyNames.enemyname_boss_insurrectionist },
            { "INSURRECTIONIST \"ANGRY\"", EnemyNames.enemyname_boss_insurrectionistAngry },
            { "INSURRECTIONIST \"RUDE\"", EnemyNames.enemyname_boss_insurrectionistRude },
            { "CANCEROUS RODENT", EnemyNames.enemyname_boss_cancerousRodent },
            { "VERY CANCEROUS RODENT", EnemyNames.enemyname_boss_veryCancerousRodent },
            { "FERRYMAN", EnemyNames.enemyname_ferryman },
            { "SWORDSMACHINE", EnemyNames.enemyname_swordsmachine },
            { "SWORDSMACHINE \"AGONY\"", EnemyNames.enemyname_boss_swordsmachineAgony },
            { "SWORDSMACHINE \"TUNDRA\"", EnemyNames.enemyname_boss_swordsmachineTundra },
            { "DRONE", EnemyNames.enemyname_drone },
            { "STREETCLEANER", EnemyNames.enemyname_streetCleaner },
            { "V2 (2nd)", EnemyNames.enemyname_v2Second },
            { "V2", EnemyNames.enemyname_v2 },
            { "SENTRY", EnemyNames.enemyname_sentry },
            { "MINDFLAYER", EnemyNames.enemyname_mindFlayer },
            { "MALICIOUS FACE", EnemyNames.enemyname_malFace },
            { "MALICIOUSFACE", EnemyNames.enemyname_malFace },
            { "MYSTERIOUS DRUID KNIGHT (& OWL)", EnemyNames.enemyname_boss_mandalore },
            { "IDOL", EnemyNames.enemyname_idol },
            { "LEVIATHAN", EnemyNames.enemyname_leviathan },
            { "CERBERUS", EnemyNames.enemyname_boss_cerberus },
            { "CERBERUS, GUARDIAN OF HELL", EnemyNames.enemyname_boss_cerberus },
            { "HIDEOUS MASS", EnemyNames.enemyname_hideousMass },
            { "HIDEOUSMASS", EnemyNames.enemyname_hideousMass },
            { "GABRIEL, JUDGE OF HELL", EnemyNames.enemyname_boss_gabriel },
            { "GABRIEL, APOSTATE OF HATE", EnemyNames.enemyname_boss_gabrielSecond },
            { "GABRIEL, THE APOSTATE OF HATE", EnemyNames.enemyname_boss_gabrielSecond },
            { "VIRTUE", EnemyNames.enemyname_virtue },
            { "SOMETHING WICKED", EnemyNames.enemyname_somethingWicked },
            { "FLESH PRISON", EnemyNames.enemyname_fleshPrison },
            { "MINOS PRIME", EnemyNames.enemyname_minosPrime },
            { "MINOSPRIME", EnemyNames.enemyname_minosPrime },
            { "FLESH PANOPTICON", EnemyNames.enemyname_boss_fleshPanopticon },
            { "SISYPHUS PRIME", EnemyNames.enemyname_boss_sisyphusPrime },
            { "SISYPHUSPRIME", EnemyNames.enemyname_boss_sisyphusPrime }
        };

        private static readonly Dictionary<string, string> Types = new Dictionary<string, string>
        {
            { "LESSER HUSK", EnemyNames.enemyname_type_lesserHusk },
            { "GREATER HUSK", EnemyNames.enemyname_type_greaterHusk },
            { "SUPREME HUSK", EnemyNames.enemyname_type_supremeHusk },

            { "LESSER DEMON", EnemyNames.enemyname_type_lesserDemon },
            { "GREATER DEMON", EnemyNames.enemyname_type_greaterDemon },
            { "SUPREME DEMON", EnemyNames.enemyname_type_supremeDemon },

            { "LESSER MACHINE", EnemyNames.enemyname_type_lesserMachine },
            { "GREATER MACHINE", EnemyNames.enemyname_type_greaterMachine },
            { "SUPREME MACHINE", EnemyNames.enemyname_type_supremeMachine },

            { "LESSER ANGEL", EnemyNames.enemyname_type_lesserAngel },
            { "GREATER ANGEL", EnemyNames.enemyname_type_greaterAngel },
            { "SUPREME ANGEL", EnemyNames.enemyname_type_supremeAngel },

            { "PRIME SOUL", EnemyNames.enemyname_type_primeSoul }
        };

        static EnemyBios()
        {
            BioTemplates.EnableCache = false;
            StrategyTemplates.EnableCache = false;
        }

        public static string GetName(string originalName)
        {
            return !Names.TryGetValue(originalName, out var name)
                ? "Untranslated enemy name"
                : name;
        }

        public static string GetType(string originalType)
        {
            if (originalType == "???")
                return originalType;
            
            return !Types.TryGetValue(originalType, out var type)
                ? "UNKNOWN ENEMY TYPE"
                : type;
        }

        public static string GetDescription(string originalEnemy)
        {
            var template = BioTemplates.GetInstanceOf(SanitizeTemplateName(originalEnemy));
            return template == null
                ? "UNKNOWN ENEMY BIO"
                : template.Add("bios", LanguageManager.CurrentLanguage.enemyBios).Render();
        }

        public static string GetStrategy(string originalEnemy)
        {
            var template = StrategyTemplates.GetInstanceOf(SanitizeTemplateName(originalEnemy));
            return template == null
                ? "UNKNOWN"
                : template.Add("bios", LanguageManager.CurrentLanguage.enemyBios).Render();
        }
    }
}
