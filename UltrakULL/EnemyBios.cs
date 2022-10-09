using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltrakULL.json;

namespace UltrakULL
{
    class EnemyBios
    {
        public string getName(string originalName,JsonParser language)
        {
            switch (originalName)
            {
                case "FILTH": { return language.currentLanguage.enemyNames.enemyname_filth; }
                case "STRAY": { return language.currentLanguage.enemyNames.enemyname_stray; }
                case "SCHISM": { return language.currentLanguage.enemyNames.enemyname_schism; }
                case "SOLDIER": { return language.currentLanguage.enemyNames.enemyname_soldier; }
                case "THE CORPSE OF KING MINOS": { return language.currentLanguage.enemyNames.enemyname_minos; }
                case "STALKER": { return language.currentLanguage.enemyNames.enemyname_stalker; }
                case "INSURRECTIONIST": { return language.currentLanguage.enemyNames.enemyname_boss_insurrectionist; }
                case "FERRYMAN": { return language.currentLanguage.enemyNames.enemyname_ferryman; }
                case "SWORDSMACHINE": { return language.currentLanguage.enemyNames.enemyname_swordsmachine; }
                case "DRONE": { return language.currentLanguage.enemyNames.enemyname_drone; }
                case "STREETCLEANER": { return language.currentLanguage.enemyNames.enemyname_streetCleaner; }
                case "V2 (2nd)": { return language.currentLanguage.enemyNames.enemyname_v2Second; }
                case "V2": { return language.currentLanguage.enemyNames.enemyname_v2; }
                case "SENTRY": { return language.currentLanguage.enemyNames.enemyname_sentry; }
                case "MINDFLAYER": { return language.currentLanguage.enemyNames.enemyname_mindFlayer; }
                case "MALICIOUS FACE": { return language.currentLanguage.enemyNames.enemyname_malFace; }
                case "IDOL": { return language.currentLanguage.enemyNames.enemyname_idol; }
                case "LEVIATHAN": { return language.currentLanguage.enemyNames.enemyname_leviathan; }
                case "CERBERUS": { return language.currentLanguage.enemyNames.enemyname_cerberus; }
                case "HIDEOUS MASS": { return language.currentLanguage.enemyNames.enemyname_hideousMass; }
                case "GABRIEL, JUDGE OF HELL": { return language.currentLanguage.enemyNames.enemyname_gabriel; }
                case "GABRIEL, APOSTATE OF HATE": { return language.currentLanguage.enemyNames.enemyname_boss_gabrielSecond; }
                case "VIRTUE": { return language.currentLanguage.enemyNames.enemyname_virtue; }
                case "SOMETHING WICKED": { return language.currentLanguage.enemyNames.enemyname_somethingWicked; }
                case "FLESH PRISON": { return language.currentLanguage.enemyNames.enemyname_fleshPrison; }
                case "MINOS PRIME": { return language.currentLanguage.enemyNames.enemyname_minosPrime; }
                default: { Console.WriteLine(originalName); return "Untranslated"; }
            }
        }

        public string getType(string originaltype,JsonParser language)
        {
            switch (originaltype)
            {
                case "LESSER HUSK": { return language.currentLanguage.enemyNames.enemyname_type_lesserHusk; }
                case "GREATER HUSK": { return language.currentLanguage.enemyNames.enemyname_type_greaterHusk; }
                case "SUPREME HUSK": { return language.currentLanguage.enemyNames.enemyname_type_supremeHusk; }

                case "LESSER DEMON": { return language.currentLanguage.enemyNames.enemyname_type_lesserDemon; }
                case "GREATER DEMON": { return language.currentLanguage.enemyNames.enemyname_type_greaterDemon; }
                case "SUPREME DEMON": { return language.currentLanguage.enemyNames.enemyname_type_supremeDemon; }

                case "LESSER MACHINE": { return language.currentLanguage.enemyNames.enemyname_type_lesserMachine; }
                case "GREATER MACHINE": { return language.currentLanguage.enemyNames.enemyname_type_greaterMachine; }
                case "SUPREME MACHINE": { return language.currentLanguage.enemyNames.enemyname_type_supremeMachine; }

                case "LESSER ANGEL": { return language.currentLanguage.enemyNames.enemyname_type_lesserAngel; }
                case "GREATER ANGEL": { return language.currentLanguage.enemyNames.enemyname_type_greaterAngel; }
                case "SUPREME ANGEL": { return language.currentLanguage.enemyNames.enemyname_type_supremeAngel; }

                case "???": { return "???"; }
                case "PRIME SOUL": { return language.currentLanguage.enemyNames.enemyname_type_primeSoul; }
                default: { return "UNKNOWN"; }
            }
        }

        public string getDescription(string originalenemy,JsonParser language)
        { 
            switch(originalenemy)
            {
                case "FILTH":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_filth_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_filth_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_filth_3 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_filth_4;
                    }
                case "STRAY":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_stray_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_stray_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_stray_3;
                    }
                case "SCHISM":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_schism_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_schism_2;

                    }
                case "SOLDIER":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_soldier_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_soldier_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_soldier_3;

                    }

                case "FERRYMAN":
                    {
                           return
                            language.currentLanguage.enemyBios.enemyBios_ferryman_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_ferryman_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_ferryman_3 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_ferryman_4 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_ferryman_5 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_ferryman_6;
                    }

                case "IDOL":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_idol_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_idol_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_idol_3 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_idol_4;

                    }

                case "LEVIATHAN":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_leviathan_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_leviathan_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_leviathan_3 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_leviathan_4;
                    }

                case "THE CORPSE OF KING MINOS":
                    {
                         return
                            language.currentLanguage.enemyBios.enemyBios_corpseOfKingMinos_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_corpseOfKingMinos_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_corpseOfKingMinos_3 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_corpseOfKingMinos_4;

                    }

                case "STALKER":
                    {
                      return
                            language.currentLanguage.enemyBios.enemyBios_stalker_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_stalker_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_stalker_3 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_stalker_4 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_stalker_5;
                    }
                case "INSURRECTIONIST":
                    {
                      return
                            language.currentLanguage.enemyBios.enemyBios_insurrectionist_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_insurrectionist_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_insurrectionist_3 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_insurrectionist_4 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_insurrectionist_5 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_insurrectionist_6;
                    }

                case "SWORDSMACHINE":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_swordsmachine_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_swordsmachine_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_swordsmachine_3;
                    }
                case "DRONE":
                    {
                        return
                        
                            language.currentLanguage.enemyBios.enemyBios_drone_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_drone_2 + "\n\n";
                    }
                case "STREETCLEANER":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_streetcleaner_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_streetcleaner_2;
                    }
                case "V2":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_v2_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_v2_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_v2_3 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_v2_4 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_v2_5 + "\n\n";
                    }
                case "MINDFLAYER":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_mindflayer_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_mindflayer_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_mindflayer_3 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_mindflayer_4;

                    }

                case "SENTRY":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_sentry_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_sentry_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_sentry_3 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_sentry_4;

                    }

                case "V2 (2nd)":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_v2Second_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_v2Second_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_v2Second_3 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_v2Second_4;
                    }
                case "MALICIOUS FACE":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_maliciousFace_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_maliciousFace_2;
                    }
                case "CERBERUS":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_cerberus_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_cerberus_2;
                    }
                case "HIDEOUS MASS":
                    {
                        return
                          language.currentLanguage.enemyBios.enemyBios_hideousMass_1 + "\n\n" +
                          language.currentLanguage.enemyBios.enemyBios_hideousMass_2;
                    }
                case "GABRIEL, JUDGE OF HELL":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_gabriel_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_gabriel_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_gabriel_3;
                    }


                case "GABRIEL, APOSTATE OF HATE":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_gabrielSecond_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_gabrielSecond_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_gabrielSecond_3 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_gabrielSecond_4;

                    }
                case "VIRTUE":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_virtue_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_virtue_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_virtue_3;
                    }
                case "SOMETHING WICKED":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_somethingWicked_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_somethingWicked_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_somethingWicked_3;
                    }
                case "FLESH PRISON":
                    {

                        return
                           language.currentLanguage.enemyBios.enemyBios_fleshPrison_1 + "\n\n" +
                           language.currentLanguage.enemyBios.enemyBios_fleshPrison_2 + "\n\n" +
                           language.currentLanguage.enemyBios.enemyBios_fleshPrison_3;
                    }
                case "MINOS PRIME":
                    {
                        return
                            language.currentLanguage.enemyBios.enemyBios_minosPrime_1 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_minosPrime_2 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_minosPrime_3 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_minosPrime_4 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_minosPrime_5 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_minosPrime_6 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_minosPrime_7 + "\n\n" +
                            language.currentLanguage.enemyBios.enemyBios_minosPrime_8;

                    }

                default: {return "UNKNOWN";}

            }
        }

        public string getStrategy(string originalenemy,JsonParser language)
        {
            switch (originalenemy)
            {
                case "FILTH":
                    {
                        return
                              "- " + language.currentLanguage.enemyBios.enemyBios_filth_strategy1 + "\n\n"
                            + "- " + language.currentLanguage.enemyBios.enemyBios_filth_strategy2;
                    }
                case "STRAY":
                    {
                        return
                              "- " + language.currentLanguage.enemyBios.enemyBios_stray_strategy1 + "\n\n"
                            + "- " + language.currentLanguage.enemyBios.enemyBios_stray_strategy2;
                    }
                case "SCHISM":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_schism_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_schism_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_schism_strategy3;
                    }
                case "SOLDIER":
                    {
                        return
                              "- " + language.currentLanguage.enemyBios.enemyBios_soldier_strategy1 + "\n\n"
                            + "- " + language.currentLanguage.enemyBios.enemyBios_soldier_strategy2 + "\n\n" +
                              "- " + language.currentLanguage.enemyBios.enemyBios_soldier_strategy3;
                    }


                case "FERRYMAN":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_ferryman_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_ferryman_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_ferryman_strategy3 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_ferryman_strategy4;

                    }

                case "SENTRY":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_sentry_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_sentry_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_sentry_strategy3 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_sentry_strategy4;


                    }

                case "IDOL":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_idol_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_idol_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_idol_strategy3;

                    }

                case "THE CORPSE OF KING MINOS":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_corpseOfKingMinos_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_corpseOfKingMinos_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_corpseOfKingMinos_strategy3;
                    }


                case "LEVIATHAN":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_leviathan_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_leviathan_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_leviathan_strategy3;
                    }

                case "STALKER":
                    {
                        return
                              "- " + language.currentLanguage.enemyBios.enemyBios_stalker_strategy1 + "\n\n"
                            + "- " + language.currentLanguage.enemyBios.enemyBios_stalker_strategy2 + "\n\n"
                            + "- " + language.currentLanguage.enemyBios.enemyBios_stalker_strategy3;

                    }
                case "INSURRECTIONIST":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_insurrectionist_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_insurrectionist_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_insurrectionist_strategy3 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_insurrectionist_strategy4;
                    }
                case "SWORDSMACHINE":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_swordsmachine_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_swordsmachine_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_swordsmachine_strategy3;
                    }
                case "DRONE":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_drone_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_drone_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_drone_strategy3 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_drone_strategy4;
                    }
                case "STREETCLEANER":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_streetcleaner_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_streetcleaner_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_streetcleaner_strategy3;
                    }
                case "V2":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_v2_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_v2_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_v2_strategy3 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_v2_strategy4;
                    }
                case "MINDFLAYER":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_mindflayer_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_mindflayer_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_mindflayer_strategy3;
                    }
                case "V2 (2nd)":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_v2Second_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_v2Second_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_v2Second_strategy3;
                    }
                case "MALICIOUS FACE":
                    {
                        return
                        "- " + language.currentLanguage.enemyBios.enemyBios_maliciousFace_strategy1 + "\n\n"
                      + "- " + language.currentLanguage.enemyBios.enemyBios_maliciousFace_strategy2;

                    }
                case "CERBERUS":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_cerberus_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_cerberus_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_cerberus_strategy3;
                    }
                case "HIDEOUS MASS":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_hideousMass_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_hideousMass_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_hideousMass_strategy3 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_hideousMass_strategy4;
                    }
                case "GABRIEL, JUDGE OF HELL":
                    {
                        return
                        "- " + language.currentLanguage.enemyBios.enemyBios_gabriel_strategy1 + "\n\n"
                      + "- " + language.currentLanguage.enemyBios.enemyBios_gabriel_strategy2;
                    }

                case "GABRIEL, APOSTATE OF HATE":
                    {
                        return
                            "- " + language.currentLanguage.enemyBios.enemyBios_gabrielSecond_strategy1 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_gabrielSecond_strategy2 + "\n\n"
                          + "- " + language.currentLanguage.enemyBios.enemyBios_gabrielSecond_strategy3;
                    }

                case "VIRTUE":
                    {
                        return
                           "- " + language.currentLanguage.enemyBios.enemyBios_virtue_strategy1 + "\n\n"
                         + "- " + language.currentLanguage.enemyBios.enemyBios_virtue_strategy2;
                    }
                case "SOMETHING WICKED":
                    {
                        return
                        "- " + language.currentLanguage.enemyBios.enemyBios_somethingWicked_strategy1 + "\n\n"
                      + "- " + language.currentLanguage.enemyBios.enemyBios_somethingWicked_strategy2;

                    }
                case "FLESH PRISON":
                    {
                        return
                        "- " + language.currentLanguage.enemyBios.enemyBios_fleshPrison_strategy1 + "\n\n"
                      + "- " + language.currentLanguage.enemyBios.enemyBios_fleshPrison_strategy2;
                    }
                case "MINOS PRIME":
                    {
                        return
                        "- " + language.currentLanguage.enemyBios.enemyBios_minosPrime_strategy1 + "\n\n"
                      + "- " + language.currentLanguage.enemyBios.enemyBios_minosPrime_strategy2;
                    }
                default: { return "UNKNOWN"; }
            }
        }
        public EnemyBios()
        {
            ;
        }


    }
}
