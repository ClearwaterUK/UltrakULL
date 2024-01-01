using UltrakULL.json;

namespace UltrakULL
{
    public static class EnemyBios
    {
        public static string GetName(string originalName)
        {
            Logging.Warn(originalName);
            switch (originalName)
            {
                case "FILTH": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_filth; }
                case "STRAY": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_stray; }
                case "SCHISM": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_schism; }
                case "SOLDIER": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_soldier; }
                case "THE CORPSE OF KING MINOS": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_minos; }
                case "STALKER": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_stalker; }
                case "INSURRECTIONIST": case "SISYPHEAN INSURRECTIONIST": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_insurrectionist; }
                case "INSURRECTIONIST \"ANGRY\"": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_insurrectionistAngry;}
                case "INSURRECTIONIST \"RUDE\"": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_insurrectionistRude;}
                case "CANCEROUS RODENT": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_cancerousRodent;}
                case "VERY CANCEROUS RODENT": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_veryCancerousRodent;}
                case "FERRYMAN": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_ferryman; }
                case "SWORDSMACHINE": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_swordsmachine; }
                case "SWORDSMACHINE \"AGONY\"": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_swordsmachineAgony;}
                case "SWORDSMACHINE \"TUNDRA\"": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_swordsmachineTundra;}
                case "DRONE": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_drone; }
                case "STREETCLEANER": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_streetCleaner; }
                case "V2 (2nd)": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_v2Second; }
                case "V2": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_v2; }
                case "SENTRY": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_sentry; }
                case "GUTTERMAN": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_gutterman; }
                case "GUTTERTANK": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_guttertank; }
                case "MINDFLAYER": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_mindFlayer; }
                case "EARTHMOVER": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_earthmover; }
                case "1000-THR \"EARTHMOVER\"": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_earthmover; }
                case "1000-THR DEFENCE SYSTEM": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_earthmoverDefence; }
                case "MALICIOUS FACE": case "MALICIOUSFACE": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_malFace; }
                case "MYSTERIOUS DRUID KNIGHT (& OWL)": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_mandalore; }
                case "IDOL": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_idol; }
                case "LEVIATHAN": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_leviathan; }
                case "CERBERUS, GUARDIAN OF HELL": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_cerberus; }
                case "CERBERUS": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_cerberus; }
                case "HIDEOUS MASS": case "HIDEOUSMASS":{ return LanguageManager.CurrentLanguage.enemyNames.enemyname_hideousMass; }
                case "MANNEQUIN": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_mannequin; }
                case "MINOTAUR": { return "<s>" + LanguageManager.CurrentLanguage.enemyNames.enemyname_minotaur + "</s>"; }
                case "GABRIEL, JUDGE OF HELL": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_gabriel; }
                case "GABRIEL, APOSTATE OF HATE": case "GABRIEL, THE APOSTATE OF HATE": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_gabrielSecond; }
                case "VIRTUE": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_virtue; }
                case "SOMETHING WICKED": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_somethingWicked; }
                case "FLESH PRISON": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_fleshPrison; }
                case "MINOS PRIME": case "MINOSPRIME":{ return LanguageManager.CurrentLanguage.enemyNames.enemyname_minosPrime; }
                case "FLESH PANOPTICON": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_fleshPanopticon; }
                case "SISYPHUS PRIME": case "SISYPHUSPRIME":{ return LanguageManager.CurrentLanguage.enemyNames.enemyname_boss_sisyphusPrime; }
                default: { return "Untranslated enemy name"; }
            }
        }

        public static string GetType(string originaltype)
        {
            switch (originaltype)
            {
                case "LESSER HUSK": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_type_lesserHusk; }
                case "GREATER HUSK": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_type_greaterHusk; }
                case "SUPREME HUSK": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_type_supremeHusk; }

                case "LESSER DEMON": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_type_lesserDemon; }
                case "GREATER DEMON": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_type_greaterDemon; }
                case "SUPREME DEMON": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_type_supremeDemon; }

                case "LESSER MACHINE": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_type_lesserMachine; }
                case "GREATER MACHINE": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_type_greaterMachine; }
                case "SUPREME MACHINE": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_type_supremeMachine; }

                case "LESSER ANGEL": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_type_lesserAngel; }
                case "GREATER ANGEL": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_type_greaterAngel; }
                case "SUPREME ANGEL": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_type_supremeAngel; }

                case "???": { return "???"; }
                case "PRIME SOUL": { return LanguageManager.CurrentLanguage.enemyNames.enemyname_type_primeSoul; }
                default: { Logging.Warn("Unknown enemy type");return originaltype; }
            }
        }

        public static string GetDescription(string originalenemy)
        { 
            switch(originalenemy)
            {
                case "FILTH":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_filth_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_filth_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_filth_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_filth_4;
                    }
                case "STRAY":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_stray_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_stray_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_stray_3;
                    }
                case "SCHISM":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_schism_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_schism_2;

                    }
                case "SOLDIER":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_soldier_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_soldier_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_soldier_3;

                    }

                case "IDOL":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_idol_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_idol_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_idol_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_idol_4;
                    }

                case "THE CORPSE OF KING MINOS":
                    {
                         return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_corpseOfKingMinos_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_corpseOfKingMinos_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_corpseOfKingMinos_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_corpseOfKingMinos_4;

                    }

                case "STALKER":
                    {
                      return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_stalker_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_stalker_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_stalker_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_stalker_4 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_stalker_5;
                    }
                case "INSURRECTIONIST":
                    {
                      return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_insurrectionist_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_insurrectionist_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_insurrectionist_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_insurrectionist_4 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_insurrectionist_5 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_insurrectionist_6;
                    }

                case "FERRYMAN":
                    {
                           return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_ferryman_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_ferryman_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_ferryman_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_ferryman_4 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_ferryman_5 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_ferryman_6;
                    }

                case "SWORDSMACHINE":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_swordsmachine_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_swordsmachine_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_swordsmachine_3;
                    }
                case "DRONE":
                    {
                        return
                        
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_drone_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_drone_2 + "\n\n";
                    }
                case "STREETCLEANER":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_streetcleaner_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_streetcleaner_2;
                    }
                case "V2":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2_4 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2_5 + "\n\n";
                    }
                case "MINDFLAYER":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_mindflayer_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_mindflayer_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_mindflayer_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_mindflayer_4 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_mindflayer_5;

                    }

                case "V2 (2nd)":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2Second_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2Second_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2Second_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2Second_4;
                    }

                case "SENTRY":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_sentry_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_sentry_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_sentry_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_sentry_4;
                    }
                case "GUTTERMAN":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_gutterman_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_gutterman_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_gutterman_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_gutterman_4;
                    }
                case "GUTTERTANK":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_guttertank_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_guttertank_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_guttertank_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_guttertank_4 + "\n"   +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_guttertank_5 + "\n"   +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_guttertank_6 + "\n"   +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_guttertank_7;
                    }
                case "EARTHMOVER":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_earthmover_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_earthmover_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_earthmover_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_earthmover_4 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_earthmover_5 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_earthmover_6;
                    }
                case "MALICIOUS FACE":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_maliciousFace_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_maliciousFace_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_maliciousFace_3;
                    }
                case "CERBERUS":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_cerberus_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_cerberus_2;
                    }
                case "HIDEOUS MASS":
                    {
                        return
                          LanguageManager.CurrentLanguage.enemyBios.enemyBios_hideousMass_1 + "\n\n" +
                          LanguageManager.CurrentLanguage.enemyBios.enemyBios_hideousMass_2;
                    }
                case "LEVIATHAN":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_leviathan_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_leviathan_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_leviathan_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_leviathan_4;
                    }
                case "MANNEQUIN":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_mannequin_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_mannequin_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_mannequin_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_mannequin_4 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_mannequin_5;
                    }
                case "MINOTAUR":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_minotaur_1 + "\n\n...\n\n...\n\n...\n\n" +
                            "<color=red><s>" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_minotaur_2 + "\n\n" +
                            "<color=red><s>" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_minotaur_3 + "\n\n" +
                            "<color=red><s>" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_minotaur_4 + "</color></s>";
                    }
                case "GABRIEL, JUDGE OF HELL":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_gabriel_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_gabriel_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_gabriel_3;
                    }

                case "GABRIEL, APOSTATE OF HATE":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_gabrielSecond_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_gabrielSecond_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_gabrielSecond_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_gabrielSecond_4;
                    }
                case "VIRTUE":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_virtue_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_virtue_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_virtue_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_virtue_4 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_virtue_5;
                    }
                case "SOMETHING WICKED":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_somethingWicked_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_somethingWicked_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_somethingWicked_3;
                    }
                case "FLESH PRISON":
                    {
                        return
                           LanguageManager.CurrentLanguage.enemyBios.enemyBios_fleshPrison_1 + "\n\n" +
                           LanguageManager.CurrentLanguage.enemyBios.enemyBios_fleshPrison_2 + "\n\n" +
                           LanguageManager.CurrentLanguage.enemyBios.enemyBios_fleshPrison_3;
                    }
                case "MINOS PRIME":
                    {
                        return
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_minosPrime_1 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_minosPrime_2 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_minosPrime_3 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_minosPrime_4 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_minosPrime_5 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_minosPrime_6 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_minosPrime_7 + "\n\n" +
                            LanguageManager.CurrentLanguage.enemyBios.enemyBios_minosPrime_8;
                    }
                case "FLESH PANOPTICON":
                {
                    return
                        LanguageManager.CurrentLanguage.enemyBios.enemyBios_fleshPanopticon_1 + "\n\n" +
                        LanguageManager.CurrentLanguage.enemyBios.enemyBios_fleshPanopticon_2;
                }
                case "SISYPHUS PRIME":
                {
                    return
                        LanguageManager.CurrentLanguage.enemyBios.enemyBios_sisyphusPrime_1 + "\n\n" +
                        LanguageManager.CurrentLanguage.enemyBios.enemyBios_sisyphusPrime_2 + "\n\n" +
                        LanguageManager.CurrentLanguage.enemyBios.enemyBios_sisyphusPrime_3 + "\n\n" +
                        LanguageManager.CurrentLanguage.enemyBios.enemyBios_sisyphusPrime_4 + "\n\n" +
                        LanguageManager.CurrentLanguage.enemyBios.enemyBios_sisyphusPrime_5 + "\n\n" +
                        LanguageManager.CurrentLanguage.enemyBios.enemyBios_sisyphusPrime_6 + "\n\n" +
                        LanguageManager.CurrentLanguage.enemyBios.enemyBios_sisyphusPrime_7 + "\n\n" +
                        LanguageManager.CurrentLanguage.enemyBios.enemyBios_sisyphusPrime_8;
                }
                default: {Logging.Warn( "UNKNOWN ENEMY BIO: " + originalenemy);
                    return originalenemy;
                }
            }
        }

        public static string GetStrategy(string originalenemy)
        {
            switch (originalenemy)
            {
                case "FILTH":
                    {
                        return
                              "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_filth_strategy1 + "\n\n"
                            + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_filth_strategy2;
                    }
                case "STRAY":
                    {
                        return
                              "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_stray_strategy1 + "\n\n"
                            + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_stray_strategy2;
                    }
                case "SCHISM":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_schism_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_schism_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_schism_strategy3;
                    }
                case "SOLDIER":
                    {
                        return
                              "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_soldier_strategy1 + "\n\n"
                            + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_soldier_strategy2 + "\n\n" +
                              "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_soldier_strategy3;
                    }


                case "FERRYMAN":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_ferryman_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_ferryman_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_ferryman_strategy3 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_ferryman_strategy4;

                    }

                case "SENTRY":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_sentry_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_sentry_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_sentry_strategy3 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_sentry_strategy4;


                    }

                case "IDOL":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_idol_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_idol_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_idol_strategy3;

                    }

                case "THE CORPSE OF KING MINOS":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_corpseOfKingMinos_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_corpseOfKingMinos_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_corpseOfKingMinos_strategy3;
                    }
                
                case "LEVIATHAN":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_leviathan_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_leviathan_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_leviathan_strategy3;
                    }

                case "STALKER":
                    {
                        return
                              "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_stalker_strategy1 + "\n\n"
                            + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_stalker_strategy2 + "\n\n"
                            + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_stalker_strategy3 + "\n\n"
                            + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_stalker_strategy4;
                    }
                case "INSURRECTIONIST":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_insurrectionist_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_insurrectionist_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_insurrectionist_strategy3 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_insurrectionist_strategy4;
                    }
                case "SWORDSMACHINE":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_swordsmachine_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_swordsmachine_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_swordsmachine_strategy3;
                    }
                case "DRONE":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_drone_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_drone_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_drone_strategy3 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_drone_strategy4;
                    }
                case "STREETCLEANER":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_streetcleaner_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_streetcleaner_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_streetcleaner_strategy3;
                    }
                case "V2":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2_strategy3 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2_strategy4;
                    }
                case "MINDFLAYER":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_mindflayer_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_mindflayer_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_mindflayer_strategy3;
                    }
                case "V2 (2nd)":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2Second_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2Second_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_v2Second_strategy3;
                    }
                case "GUTTERMAN":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_gutterman_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_gutterman_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_gutterman_strategy3 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_gutterman_strategy4;
                    }
                case "GUTTERTANK":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_guttertank_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_guttertank_strategy2;
                    }
                case "EARTHMOVER":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_earthmover_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_earthmover_strategy2;
                    }
                case "MALICIOUS FACE":
                    {
                        return
                        "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_maliciousFace_strategy1 + "\n\n"
                      + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_maliciousFace_strategy2;
                    }
                case "CERBERUS":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_cerberus_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_cerberus_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_cerberus_strategy3;
                    }
                case "HIDEOUS MASS":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_hideousMass_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_hideousMass_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_hideousMass_strategy3 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_hideousMass_strategy4;
                    }
                case "MANNEQUIN":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_mannequin_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_mannequin_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_mannequin_strategy3;
                    }
                case "MINOTAUR":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_minotaur_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_minotaur_strategy2;
                    }
                case "GABRIEL, JUDGE OF HELL":
                    {
                        return
                        "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_gabriel_strategy1 + "\n\n"
                      + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_gabriel_strategy2;
                    }

                case "GABRIEL, APOSTATE OF HATE":
                    {
                        return
                            "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_gabrielSecond_strategy1 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_gabrielSecond_strategy2 + "\n\n"
                          + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_gabrielSecond_strategy3;
                    }

                case "VIRTUE":
                    {
                        return
                           "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_virtue_strategy1 + "\n\n"
                         + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_virtue_strategy2;
                    }
                case "SOMETHING WICKED":
                    {
                        return
                        "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_somethingWicked_strategy1 + "\n\n"
                      + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_somethingWicked_strategy2;

                    }
                case "FLESH PRISON":
                    {
                        return
                        "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_fleshPrison_strategy1 + "\n\n"
                      + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_fleshPrison_strategy2;
                    }
                case "MINOS PRIME":
                    {
                        return
                        "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_minosPrime_strategy1 + "\n\n"
                      + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_minosPrime_strategy2;
                    }
                case "FLESH PANOPTICON":
                {
                    return
                        "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_fleshPanopticon_strategy1 + "\n\n"
                        + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_fleshPanopticon_strategy2;
                }
                case "SISYPHUS PRIME":
                {
                    return
                        "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_sisyphusPrime_strategy1 + "\n\n"
                        + "- " + LanguageManager.CurrentLanguage.enemyBios.enemyBios_sisyphusPrime_strategy2;
                }
                default: { return "UNKNOWN"; }
            }
        }
    }
}
