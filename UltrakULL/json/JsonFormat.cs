
namespace UltrakULL.json
{
    public class JsonFormat
    {
        public Metadata metadata;
        public Body body;
        
        
        public FrontEnd frontend;
        
        public Tutorial tutorial;
        public Overture prelude;
        public a1 act1;
        public a2 act2;
        public CG cyberGrind;
        public Prime primeSanctum;
        public Secret secretLevels;
        public IntermissionStrings intermission;
        public Museum devMuseum;
        
        public PauseMenu pauseMenu;
        public Option options;
        
        public Levels levelNames;
        public Challenges levelChallenges;
        public EnemyNames enemyNames;
        public EnemyBioStrings enemyBios;
        public ShopStrings shop;
        public LevelTips levelTips;

        public Book books;
        public VisualNovel visualnovel;
        public Subtitles subtitles;
        
        public Style style;
        public CheatStrings cheats;
        public Credits credits;
        public Misc misc;

        public SandboxStrings sandbox;

    }

    public class Credits
    {
        public string credits_title;
        public string credits_createdBy;

        public string credits_helpedByTitle;
        public string credits_helpedBy1;
        public string credits_helpedBy2;
        public string credits_helpedBy3;
        public string credits_helpedBy4;
        public string credits_helpedBy5;
        public string credits_helpedBy6;
        public string credits_helpedBy7;

        public string credits_contributionsTitle;
        public string credits_contributions1;
        public string credits_contributions2;
        public string credits_contributions3;
        public string credits_contributions4;
        public string credits_contributions5;
        public string credits_contributions6;
        public string credits_contributions7;
        public string credits_contributions8;
        public string credits_contributions9;

        public string credits_VATitle;
        public string credits_VA1;
        public string credits_VA2;
        public string credits_VA3;
        public string credits_VA4;

        public string credits_QATitle;
        public string credits_QA1;
        public string credits_QA2;
        public string credits_QA3;
        public string credits_QA4;

    }

    public class CG
    {
        public string cybergrind_currentWave;
        public string cybergrind_enemiesRemaining;

        public string cybergrind_wave;
        public string cybergrind_kills;
        public string cybergrind_style;
        public string cybergrind_time;

        public string cybergrind_cgTitle;
        public string cybergrind_previousRun;
        public string cybergrind_bestRun;

        public string cybergrind_total;

        public string cybergrind_connectingToSteam;

        public string cybergrind_friendScores;
        public string cybergrind_globalScores;

        public string cybergrind_settings;
        public string cybergrind_settingsDescription;
        public string cybergrind_themes;
        public string cybergrind_patterns;
        public string cybergrind_waves;

        public string cybergrind_themesTitle;
        public string cybergrind_themesDescription;
        public string cybergrind_themesLight;
        public string cybergrind_themesDark;
        public string cybergrind_themesCustom;
        public string cybergrind_themesModify;

        public string cybergrind_themesCustomGrid;
        public string cybergrind_themesCustomGridGlow;
        public string cybergrind_themesCustomSkybox;
        public string cybergrind_themesCustomBack;
        public string cybergrind_themesCustomReload;
        public string cybergrind_themesCustomBase;
        public string cybergrind_themesCustomTopRow;
        public string cybergrind_themesCustomTop;
        public string cybergrind_themesCustomGlowIntensity;

        public string cybergrind_patternsTitle;
        public string cybergrind_patternsRefresh;
        public string cybergrind_patternsLaunchExternalEditor;

        public string cybergrind_wavesTitle;
        public string cybergrind_wavesDescription1;
        public string cybergrind_wavesDescription2;

        public string cybergrind_noPatternsSelected;
    }

    public class CheatStrings
    {
        public string cheats_disclaimer1;
        public string cheats_disclaimer2;
        public string cheats_disclaimerConfirm;
        public string cheats_disclaimerYes;
        public string cheats_disclaimerNo;

        public string cheats_panelTitle;

        public string cheats_cheatsEnabled;

        public string cheats_keepEnabled;
        public string cheats_spawnerArm;
        public string cheats_teleportMenu;
        public string cheats_fullBright;
        public string cheats_noclip;
        public string cheats_flight;
        public string cheats_infiniteWallJumps;
        public string cheats_noWeaponCooldown;
        public string cheats_infinitePowerUps;
        public string cheats_blindEnemies;
        public string cheats_disableEnemySpawns;
        public string cheats_invincibleEnemies;
        public string cheats_killAllEnemies;
        public string cheats_quickSave;
        public string cheats_quickLoad;
        public string cheats_saveMenu;
        public string cheats_clear;
        public string cheats_rebuildNav;
        public string cheats_snapping;
        public string cheats_physics;
        public string cheats_crashMode;

        public string cheats_stayActive;
        public string cheats_disableOnReload;
        public string cheats_equip;
        public string cheats_remove;
        public string cheats_open;
        public string cheats_killAll;
        public string cheats_static;
        public string cheats_dynamic;
        public string cheats_rebuild;
        public string cheats_rebuilding;

        public string cheats_activated;
        public string cheats_deactivated;

        public string cheats_pressToBind;
        public string cheats_delete;

        public string cheats_navmeshOutdated1;
        public string cheats_navmeshOutdated2;

        public string cheats_spawnerArmSlot;

        public string cheats_dupesTitle;
        public string cheats_dupesSaveNamePrompt;
        public string cheats_dupesNewSave;
        public string cheats_dupesOpenFolder;
        public string cheats_dupesDelete;
        public string cheats_dupesSave;
        public string cheats_dupesLoad;

        public string cheats_categoryMeta;
        public string cheats_categorySandbox;
        public string cheats_categoryGeneral;
        public string cheats_categoryMovement;
        public string cheats_categoryWeapons;
        public string cheats_categoryEnemies;
        public string cheats_categoryItems;
        public string cheats_categorySpecial;

    }


    public class Style
    {
        public string style_airslam;
        public string style_airshot;
        public string style_attraptor;
        public string style_arsenal;
        public string style_bigheadshot;
        public string style_bigkill;
        public string style_bigfistkill;
        public string style_bipolar;
        public string style_cannonballed;
        public string style_catapaulted;
        public string style_chargeback;
        public string style_compressed;
        public string style_criticalpunch;
        public string style_disrespect;
        public string style_doublekill;
        public string style_downtosize;
        public string style_enraged;
        public string style_exploded;
        public string style_finishedoff;
        public string style_fireworks;
        public string style_fistfulofdollar;
        public string style_fried;
        public string style_friendlyfire;
        public string style_groundslam;
        public string style_halfoff;
        public string style_headshot;
        public string style_headshotcombo;
        public string style_homerun;
        public string style_instakill;
        public string style_interruption;
        public string style_kill;
        public string style_limbshot;
        public string style_mauriced;
        public string style_multikill;
        public string style_nailbombed;
        public string style_parry;
        public string style_projectileboost;
        public string style_quickdraw;
        public string style_ricoshot;
        public string style_ricoshotUltra;
        public string style_ricoshotCounter;
        public string style_secret;
        public string style_splattered;
        public string style_triplekill;

        public string style_why;

        public string style_conductor;
        public string style_crushed;
        public string style_fall;
        public string style_minced;
        public string style_outofbounds;
        public string style_shredded;
        public string style_zapped;

        public string style_d;
        public string style_c;
        public string style_b;
        public string style_a;
        public string style_s;
        public string style_ss;
        public string style_sss;
        public string style_ultrakill;

        public string style_weaponFresh;
        public string style_weaponUsed;
        public string style_weaponStale;
        public string style_weaponDull;

        public string stylemeter_multiplier;
    }


    public class EnemyBioStrings
    {
        public string enemyBios_type;
        public string enemyBios_data;
        public string enemyBios_strategy;

        public string enemyBios_filth_1;
        public string enemyBios_filth_2;
        public string enemyBios_filth_3;
        public string enemyBios_filth_4;

        public string enemyBios_filth_strategy1;
        public string enemyBios_filth_strategy2;

        public string enemyBios_stray_1;
        public string enemyBios_stray_2;
        public string enemyBios_stray_3;

        public string enemyBios_stray_strategy1;
        public string enemyBios_stray_strategy2;

        public string enemyBios_schism_1;
        public string enemyBios_schism_2;

        public string enemyBios_schism_strategy1;
        public string enemyBios_schism_strategy2;
        public string enemyBios_schism_strategy3;

        public string enemyBios_soldier_1;
        public string enemyBios_soldier_2;
        public string enemyBios_soldier_3;

        public string enemyBios_soldier_strategy1;
        public string enemyBios_soldier_strategy2;
        public string enemyBios_soldier_strategy3;

        public string enemyBios_ferryman_1;
        public string enemyBios_ferryman_2;
        public string enemyBios_ferryman_3;
        public string enemyBios_ferryman_4;
        public string enemyBios_ferryman_5;
        public string enemyBios_ferryman_6;

        public string enemyBios_ferryman_strategy1;
        public string enemyBios_ferryman_strategy2;
        public string enemyBios_ferryman_strategy3;
        public string enemyBios_ferryman_strategy4;

        public string enemyBios_idol_1;
        public string enemyBios_idol_2;
        public string enemyBios_idol_3;
        public string enemyBios_idol_4;

        public string enemyBios_idol_strategy1;
        public string enemyBios_idol_strategy2;
        public string enemyBios_idol_strategy3;

        public string enemyBios_leviathan_1;
        public string enemyBios_leviathan_2;
        public string enemyBios_leviathan_3;
        public string enemyBios_leviathan_4;

        public string enemyBios_leviathan_strategy1;
        public string enemyBios_leviathan_strategy2;
        public string enemyBios_leviathan_strategy3;

        public string enemyBios_corpseOfKingMinos_1;
        public string enemyBios_corpseOfKingMinos_2;
        public string enemyBios_corpseOfKingMinos_3;
        public string enemyBios_corpseOfKingMinos_4;

        public string enemyBios_corpseOfKingMinos_strategy1;
        public string enemyBios_corpseOfKingMinos_strategy2;
        public string enemyBios_corpseOfKingMinos_strategy3;

        public string enemyBios_stalker_1;
        public string enemyBios_stalker_2;
        public string enemyBios_stalker_3;
        public string enemyBios_stalker_4;
        public string enemyBios_stalker_5;

        public string enemyBios_stalker_strategy1;
        public string enemyBios_stalker_strategy2;
        public string enemyBios_stalker_strategy3;

        public string enemyBios_insurrectionist_1;
        public string enemyBios_insurrectionist_2;
        public string enemyBios_insurrectionist_3;
        public string enemyBios_insurrectionist_4;
        public string enemyBios_insurrectionist_5;
        public string enemyBios_insurrectionist_6;

        public string enemyBios_insurrectionist_strategy1;
        public string enemyBios_insurrectionist_strategy2;
        public string enemyBios_insurrectionist_strategy3;
        public string enemyBios_insurrectionist_strategy4;

        public string enemyBios_swordsmachine_1;
        public string enemyBios_swordsmachine_2;
        public string enemyBios_swordsmachine_3;

        public string enemyBios_swordsmachine_strategy1;
        public string enemyBios_swordsmachine_strategy2;
        public string enemyBios_swordsmachine_strategy3;

        public string enemyBios_drone_1;
        public string enemyBios_drone_2;

        public string enemyBios_drone_strategy1;
        public string enemyBios_drone_strategy2;
        public string enemyBios_drone_strategy3;
        public string enemyBios_drone_strategy4;

        public string enemyBios_streetcleaner_1;
        public string enemyBios_streetcleaner_2;

        public string enemyBios_streetcleaner_strategy1;
        public string enemyBios_streetcleaner_strategy2;
        public string enemyBios_streetcleaner_strategy3;

        public string enemyBios_v2_1;
        public string enemyBios_v2_2;
        public string enemyBios_v2_3;
        public string enemyBios_v2_4;
        public string enemyBios_v2_5;

        public string enemyBios_v2_strategy1;
        public string enemyBios_v2_strategy2;
        public string enemyBios_v2_strategy3;
        public string enemyBios_v2_strategy4;

        public string enemyBios_mindflayer_1;
        public string enemyBios_mindflayer_2;
        public string enemyBios_mindflayer_3;
        public string enemyBios_mindflayer_4;
        public string enemyBios_mindflayer_5;

        public string enemyBios_mindflayer_strategy1;
        public string enemyBios_mindflayer_strategy2;
        public string enemyBios_mindflayer_strategy3;

        public string enemyBios_sentry_1;
        public string enemyBios_sentry_2;
        public string enemyBios_sentry_3;
        public string enemyBios_sentry_4;

        public string enemyBios_sentry_strategy1;
        public string enemyBios_sentry_strategy2;
        public string enemyBios_sentry_strategy3;
        public string enemyBios_sentry_strategy4;


        public string enemyBios_v2Second_1;
        public string enemyBios_v2Second_2;
        public string enemyBios_v2Second_3;
        public string enemyBios_v2Second_4;

        public string enemyBios_v2Second_strategy1;
        public string enemyBios_v2Second_strategy2;
        public string enemyBios_v2Second_strategy3;

        public string enemyBios_maliciousFace_1;
        public string enemyBios_maliciousFace_2;
        public string enemyBios_maliciousFace_3;

        public string enemyBios_maliciousFace_strategy1;
        public string enemyBios_maliciousFace_strategy2;

        public string enemyBios_cerberus_1;
        public string enemyBios_cerberus_2;

        public string enemyBios_cerberus_strategy1;
        public string enemyBios_cerberus_strategy2;
        public string enemyBios_cerberus_strategy3;

        public string enemyBios_hideousMass_1;
        public string enemyBios_hideousMass_2;

        public string enemyBios_hideousMass_strategy1;
        public string enemyBios_hideousMass_strategy2;
        public string enemyBios_hideousMass_strategy3;
        public string enemyBios_hideousMass_strategy4;

        public string enemyBios_gabriel_1;
        public string enemyBios_gabriel_2;
        public string enemyBios_gabriel_3;

        public string enemyBios_gabriel_strategy1;
        public string enemyBios_gabriel_strategy2;

        public string enemyBios_gabrielSecond_1;
        public string enemyBios_gabrielSecond_2;
        public string enemyBios_gabrielSecond_3;
        public string enemyBios_gabrielSecond_4;

        public string enemyBios_gabrielSecond_strategy1;
        public string enemyBios_gabrielSecond_strategy2;
        public string enemyBios_gabrielSecond_strategy3;

        public string enemyBios_virtue_1;
        public string enemyBios_virtue_2;
        public string enemyBios_virtue_3;
        public string enemyBios_virtue_4;
        public string enemyBios_virtue_5;

        public string enemyBios_virtue_strategy1;
        public string enemyBios_virtue_strategy2;

        public string enemyBios_somethingWicked_1;
        public string enemyBios_somethingWicked_2;
        public string enemyBios_somethingWicked_3;

        public string enemyBios_somethingWicked_strategy1;
        public string enemyBios_somethingWicked_strategy2;

        public string enemyBios_fleshPrison_1;
        public string enemyBios_fleshPrison_2;
        public string enemyBios_fleshPrison_3;

        public string enemyBios_fleshPrison_strategy1;
        public string enemyBios_fleshPrison_strategy2;

        public string enemyBios_minosPrime_1;
        public string enemyBios_minosPrime_2;
        public string enemyBios_minosPrime_3;
        public string enemyBios_minosPrime_4;
        public string enemyBios_minosPrime_5;
        public string enemyBios_minosPrime_6;
        public string enemyBios_minosPrime_7;
        public string enemyBios_minosPrime_8;

        public string enemyBios_minosPrime_strategy1;
        public string enemyBios_minosPrime_strategy2;
        
        public string enemyBios_fleshPanopticon_1;
        public string enemyBios_fleshPanopticon_2;
        
        public string enemyBios_fleshPanopticon_strategy1;
        public string enemyBios_fleshPanopticon_strategy2;
        
        public string enemyBios_sisyphusPrime_1;
        public string enemyBios_sisyphusPrime_2;
        public string enemyBios_sisyphusPrime_3;
        public string enemyBios_sisyphusPrime_4;
        public string enemyBios_sisyphusPrime_5;
        public string enemyBios_sisyphusPrime_6;
        public string enemyBios_sisyphusPrime_7;
        public string enemyBios_sisyphusPrime_8;
        
        public string enemyBios_sisyphusPrime_strategy1;
        public string enemyBios_sisyphusPrime_strategy2;
    }

    public class Subtitles
    {
        public string subtitles_gabriel_intro1;
        public string subtitles_gabriel_intro2;
        public string subtitles_gabriel_intro3;
        public string subtitles_gabriel_intro4;
        public string subtitles_gabriel_intro5;
        public string subtitles_gabriel_intro6;
        public string subtitles_gabriel_intro7;
        public string subtitles_gabriel_intro8;
        public string subtitles_gabriel_intro9;
        public string subtitles_gabriel_fightStart;
        
        public string subtitles_gabriel_taunt1;
        public string subtitles_gabriel_taunt2;
        public string subtitles_gabriel_taunt3;
        public string subtitles_gabriel_taunt4;
        public string subtitles_gabriel_taunt5;
        public string subtitles_gabriel_taunt6;
        public string subtitles_gabriel_taunt7;
        public string subtitles_gabriel_taunt8;
        public string subtitles_gabriel_taunt9;
        public string subtitles_gabriel_taunt10;
        public string subtitles_gabriel_taunt11;
        public string subtitles_gabriel_taunt12;

        public string subtitles_gabriel_phaseChange;
        
        public string subtitles_gabriel_defeated1;
        public string subtitles_gabriel_defeated2;
        public string subtitles_gabriel_defeated3;
        public string subtitles_gabriel_defeated4;
        public string subtitles_gabriel_defeated5;
        public string subtitles_gabriel_defeated6;
        public string subtitles_gabriel_defeated7;
        public string subtitles_gabriel_defeated8;
        
        public string subtitles_mandalore_intro1;
        public string subtitles_mandalore_intro2;
        
        public string subtitles_mandalore_attack1;
        public string subtitles_mandalore_attack2;

        public string subtitles_mandalore_taunt1;
        public string subtitles_mandalore_taunt2;
        public string subtitles_mandalore_taunt3;
        public string subtitles_mandalore_taunt4;
        public string subtitles_mandalore_taunt5;

        public string subtitles_mandalore_phaseChangeFirst1;
        public string subtitles_mandalore_phaseChangeFirst2;
        public string subtitles_mandalore_phaseChangeSecond1;
        public string subtitles_mandalore_phaseChangeSecond2;
        public string subtitles_mandalore_phaseChangeThird1;
        public string subtitles_mandalore_phaseChangeThird2;
        
        public string subtitles_mandalore_defeated;
        
        public string subtitles_minosPrime_intro1;
        public string subtitles_minosPrime_intro2;
        public string subtitles_minosPrime_intro3;
        public string subtitles_minosPrime_intro4;
        public string subtitles_minosPrime_intro5;
        public string subtitles_minosPrime_intro6;
        public string subtitles_minosPrime_intro7;
        public string subtitles_minosPrime_intro8;
        public string subtitles_minosPrime_intro9;
        public string subtitles_minosPrime_intro10;
        public string subtitles_minosPrime_intro11;
        
        public string subtitles_minosPrime_attack1;
        public string subtitles_minosPrime_attack2;
        public string subtitles_minosPrime_attack3;
        public string subtitles_minosPrime_attack4;
        public string subtitles_minosPrime_attack5;
        
        public string subtitles_minosPrime_taunt1;
        
        public string subtitles_minosPrime_phaseChange;
        
        public string subtitles_minosPrime_defeated1;
        public string subtitles_minosPrime_defeated2;
        public string subtitles_minosPrime_defeated3;
        public string subtitles_minosPrime_defeated4;

        public string subtitles_sisyphusPrime_preIntro1;
        public string subtitles_sisyphusPrime_preIntro2;
        public string subtitles_sisyphusPrime_preIntro3;
        
        public string subtitles_sisyphusPrime_intro1;
        public string subtitles_sisyphusPrime_intro2;
        public string subtitles_sisyphusPrime_intro3;
        public string subtitles_sisyphusPrime_intro4;
        public string subtitles_sisyphusPrime_intro5;
        public string subtitles_sisyphusPrime_intro6;
        public string subtitles_sisyphusPrime_intro7;
        public string subtitles_sisyphusPrime_intro8;
        public string subtitles_sisyphusPrime_intro9;
        public string subtitles_sisyphusPrime_intro10;
        public string subtitles_sisyphusPrime_intro11;
        
        public string subtitles_sisyphusPrime_attack1;
        public string subtitles_sisyphusPrime_attack2;
        public string subtitles_sisyphusPrime_attack3;
        public string subtitles_sisyphusPrime_attack4;
        public string subtitles_sisyphusPrime_attack5;
            
        public string subtitles_sisyphusPrime_phaseChange;
        public string subtitles_sisyphusPrime_respawnIntro;
        
        public string subtitles_sisyphusPrime_defeated1;
        public string subtitles_sisyphusPrime_defeated2;
        public string subtitles_sisyphusPrime_defeated3;
        public string subtitles_sisyphusPrime_defeated4;
        public string subtitles_sisyphusPrime_defeated5;

        public string subtitles_gabrielBoat1;
        public string subtitles_gabrielBoat2;
        public string subtitles_gabrielBoat3;
        public string subtitles_gabrielBoat4;
        public string subtitles_gabrielBoat5;

        public string subtitles_gabrielHeresy1;
        public string subtitles_gabrielHeresy2;
        public string subtitles_gabrielHeresy3;
        public string subtitles_gabrielHeresy4;
        
        public string subtitles_gabrielSecondIntro1;
        public string subtitles_gabrielSecondIntro2;
        public string subtitles_gabrielSecondIntro3;
        public string subtitles_gabrielSecondIntro4;
        public string subtitles_gabrielSecondIntro5;
        public string subtitles_gabrielSecondIntro6;
        public string subtitles_gabrielSecondIntro7;
        public string subtitles_gabrielSecondIntro8;
        public string subtitles_gabrielSecondIntro9;
        public string subtitles_gabrielSecondIntro10;
        public string subtitles_gabrielSecondIntro11;
        public string subtitles_gabrielSecondIntro12;
        
        public string subtitles_gabrielSecondFight1;
        public string subtitles_gabrielSecondFight2;
        public string subtitles_gabrielSecondFight3;
        public string subtitles_gabrielSecondFight4;
        public string subtitles_gabrielSecondFight5;
        public string subtitles_gabrielSecondFight6;
        public string subtitles_gabrielSecondFight7;
        public string subtitles_gabrielSecondFight8;
        public string subtitles_gabrielSecondFight9;
        
        public string subtitles_gabrielSecondPhaseChange;
        
        public string subtitles_gabrielSecondTaunt1;
        public string subtitles_gabrielSecondTaunt2;
        public string subtitles_gabrielSecondTaunt3;
        public string subtitles_gabrielSecondTaunt4;
        public string subtitles_gabrielSecondTaunt5;
        public string subtitles_gabrielSecondTaunt6;
        public string subtitles_gabrielSecondTaunt7;
        public string subtitles_gabrielSecondTaunt8;
        public string subtitles_gabrielSecondTaunt9;
        public string subtitles_gabrielSecondTaunt10;
        public string subtitles_gabrielSecondTaunt11;
        public string subtitles_gabrielSecondTaunt12;
        public string subtitles_gabrielSecondTaunt13;
        public string subtitles_gabrielSecondTaunt14;

        public string subtitles_gabrielSecondDefeated1;
        public string subtitles_gabrielSecondDefeated2;
        public string subtitles_gabrielSecondDefeated3;
        public string subtitles_gabrielSecondDefeated4;
        public string subtitles_gabrielSecondDefeated5;
        public string subtitles_gabrielSecondDefeated6;
        public string subtitles_gabrielSecondDefeated7;
        public string subtitles_gabrielSecondDefeated8;
        public string subtitles_gabrielSecondDefeated9;
        public string subtitles_gabrielSecondDefeated10;
        public string subtitles_gabrielSecondDefeated11;
        public string subtitles_gabrielSecondDefeated12;

    }

    public class VisualNovel
    {
        public string visualnovel_mirageName1;
        public string visualnovel_mirageName2;
        public string visualnovel_mirageName3;

        public string visualnovel_introFirst1;
        public string visualnovel_introFirst2;
        public string visualnovel_introFirst3;
        public string visualnovel_introFirst4;
        public string visualnovel_introFirst5;
        public string visualnovel_introFirst6;
        public string visualnovel_introFirst7;

        public string visualnovel_introSecond1;
        public string visualnovel_introSecond2;
        public string visualnovel_introSecond3;
        public string visualnovel_introSecond4;
        public string visualnovel_introSecond5;
        public string visualnovel_introSecond6;
        public string visualnovel_introSecond7;
        public string visualnovel_introSecond8;

        public string visualnovel_fallen1;
        public string visualnovel_fallenPromptFirst1;
        public string visualnovel_fallenPromptFirst2;
        public string visualnovel_fallenPromptFirst3;

        public string visualnovel_fallenResponseFirst;
        public string visualnovel_fallenResponseSecond;
        public string visualnovel_fallenResponseThird1;
        public string visualnovel_fallenResponseThird2;

        public string visualnovel_fallenPromptSecond1;
        public string visualnovel_fallenPromptSecond2;
        public string visualnovel_fallenPromptSecond3;

        public string visualnovel_fallenResponseFourth;
        public string visualnovel_fallenResponseFifth;



        public string visualnovel_kindFirst1;
        public string visualnovel_kindFirst2;
        public string visualnovel_kindSecond;
        public string visualnovel_kindThird;

        public string visualnovel_rudeFirst1;
        public string visualnovel_rudeFirst2;
        public string visualnovel_rudeSecond;
        public string visualnovel_rudeThird;

        public string visualnovel_middlePrompt1;
        public string visualnovel_middlePrompt2;
        public string visualnovel_middlePrompt3;

        public string visualnovel_middleResponseFirst1;
        public string visualnovel_middleResponseFirst2;
        public string visualnovel_middleResponseFirst3;
        public string visualnovel_middleResponseFirst4;
        public string visualnovel_middleResponseFirst5;
        public string visualnovel_middleResponseFirst6;

        public string visualnovel_middleResponseSecond1;
        public string visualnovel_middleResponseSecond2;
        public string visualnovel_middleResponseSecond3;
        public string visualnovel_middleResponseSecond4;

        public string visualnovel_middleResponseThird1;
        public string visualnovel_middleResponseThird2;
        public string visualnovel_middleResponseThird3;

        public string visualnovel_middlePromptSecondRecklessness;
        public string visualnovel_middlePromptSecondWaiting;

        public string visualnovel_recklessnessFirst;
        public string visualnovel_recklessnessSecond1;
        public string visualnovel_recklessnessSecond2;

        public string visualnovel_recklessnessPrompt1;
        public string visualnovel_recklessnessPrompt2;

        public string visualnovel_recklessnessResponseFirst1;
        public string visualnovel_recklessnessResponseFirst2;
        public string visualnovel_recklessnessResponseFirst3;
        public string visualnovel_recklessnessResponseFirst4;
        public string visualnovel_recklessnessResponseFirst5;

        public string visualnovel_recklessnessResponseSecond1;
        public string visualnovel_recklessnessResponseSecond2;

        public string visualnovel_recklessnessPrompt3;

        public string visualnovel_recklessnessResponseThird;

        public string visualnovel_waitingFirst;
        public string visualnovel_waitingSecond;
        public string visualnovel_waitingThird1;
        public string visualnovel_waitingThird2;

        public string visualnovel_waitingPromptFirst1;
        public string visualnovel_waitingPromptFirst2;

        public string visualnovel_waitingResponseFirst1;
        public string visualnovel_waitingResponseFirst2;
        public string visualnovel_waitingResponseFirst3;
        public string visualnovel_waitingResponseFirst4;

        public string visualnovel_waitingResponseSecond1;
        public string visualnovel_waitingResponseSecond2;

        public string visualnovel_waitingPromptThird;
        public string visualnovel_waitingResponseThird1;
        public string visualnovel_waitingResponseThird2;
        public string visualnovel_waitingResponseThird3;

        public string visualnovel_nihilism1;
        public string visualnovel_nihilism2;
        public string visualnovel_nihilism3;
        public string visualnovel_nihilism4;
        public string visualnovel_nihilism5;
        public string visualnovel_nihilism6;
        public string visualnovel_nihilism7;
        public string visualnovel_nihilism8;
        public string visualnovel_nihilism9;
        public string visualnovel_nihilism10;
        public string visualnovel_nihilism11;
        public string visualnovel_nihilism12;
        public string visualnovel_nihilism13;
        public string visualnovel_nihilism14;
        public string visualnovel_nihilism15;
        public string visualnovel_nihilism16;
        public string visualnovel_nihilism17;
        public string visualnovel_nihilism18;
        public string visualnovel_nihilism19;
        public string visualnovel_nihilism20;
        public string visualnovel_nihilism21;
        public string visualnovel_nihilism22;
        public string visualnovel_nihilism23;
        public string visualnovel_nihilism24;
        public string visualnovel_nihilism25;
        public string visualnovel_nihilism26;
        public string visualnovel_nihilism27;
        public string visualnovel_nihilism28;
        public string visualnovel_nihilism29;
        public string visualnovel_nihilism30;
        public string visualnovel_nihilism31;
        public string visualnovel_nihilism32;
        public string visualnovel_nihilism33;
        public string visualnovel_nihilism34;
        public string visualnovel_nihilism35;
        public string visualnovel_nihilism36;
        public string visualnovel_nihilism37;
        public string visualnovel_nihilism38;
        public string visualnovel_nihilism39;
        public string visualnovel_nihilism40;
        public string visualnovel_nihilism41;
        public string visualnovel_nihilism42;
        public string visualnovel_nihilism43;

        public string visualnovel_nihilismPrompt1;
        public string visualnovel_nihilismPrompt2;
        public string visualnovel_nihilismPrompt3;
        public string visualnovel_nihilismPrompt4;
        public string visualnovel_nihilismPrompt5;
        public string visualnovel_nihilismPrompt6;
        public string visualnovel_nihilismPrompt7;
        public string visualnovel_nihilismPrompt8;
        public string visualnovel_nihilismPrompt9;
        public string visualnovel_nihilismPrompt10;
        public string visualnovel_nihilismPrompt11;
        public string visualnovel_nihilismPrompt12;
        public string visualnovel_nihilismPrompt13;
        public string visualnovel_nihilismPrompt14;
        public string visualnovel_nihilismPrompt15;
        public string visualnovel_nihilismPrompt16;
        public string visualnovel_nihilismPrompt17;
        public string visualnovel_nihilismPrompt18;
        public string visualnovel_nihilismPrompt19;
        public string visualnovel_nihilismPrompt20;
        public string visualnovel_nihilismPrompt21;
        public string visualnovel_nihilismPrompt22;
        public string visualnovel_nihilismPrompt23;
        public string visualnovel_nihilismPrompt24;
        public string visualnovel_nihilismPrompt25;

        public string visualnovel_conclusion1;
        public string visualnovel_conclusion2;
        public string visualnovel_conclusion3;
        public string visualnovel_conclusion4;
        public string visualnovel_conclusion5;
        public string visualnovel_conclusion6;
        public string visualnovel_conclusion7;
        public string visualnovel_conclusion8;
        public string visualnovel_conclusion9;
        public string visualnovel_conclusion10;
        public string visualnovel_conclusion11;

        public string visualnovel_conclusionPrompt1;
        public string visualnovel_conclusionPrompt2;

        public string visualnovel_conclusionResponseFirst1;
        public string visualnovel_conclusionResponseFirst2;
        public string visualnovel_conclusionResponseFirst3;

        public string visualnovel_conclusionResponseSecond1;
        public string visualnovel_conclusionResponseSecond2;
        public string visualnovel_conclusionResponseSecond3;
    }

    public class Metadata
    {
        public string langName;
        public string langAuthor;
        public string langVersion;
        public string langDisplayName;
        public string langRTL;

        public string minimumModVersion;

    }

    public class IntermissionStrings
    {
        public string act1_intermission_first1;
        public string act1_intermission_first2;
        public string act1_intermission_first3;
        public string act1_intermission_first4;
        public string act1_intermission_first5;
        public string act1_intermission_first6;
        public string act1_intermission_first7;
        public string act1_intermission_first8;
        public string act1_intermission_first9;
        public string act1_intermission_first10;
        public string act1_intermission_first11;
        public string act1_intermission_first12;

        public string act1_intermission_second1;
        public string act1_intermission_second2;
        public string act1_intermission_second3;
        public string act1_intermission_second4;
        public string act1_intermission_second5;
        public string act1_intermission_second6;
        public string act1_intermission_second7;
        public string act1_intermission_second8;
        public string act1_intermission_second9;
        public string act1_intermission_second10;
        public string act1_intermission_second11;
        
        public string act1_intermission_third1;
        public string act1_intermission_third2;
        public string act1_intermission_third3;
        public string act1_intermission_third4;
        public string act1_intermission_third5;

        public string act1_intermission_tobecontinued;
        public string act1_intermission_tobecontinuedshadow;
        public string act1_intermission_endof;
        public string act1_intermission_insertAct2;
        public string act1_intermission_insert;
        public string act1_intermission_returnToMenu;


        public string act2_intermission_first1;
        public string act2_intermission_first2;
        public string act2_intermission_first3;
        public string act2_intermission_first4;
        public string act2_intermission_first5;
        public string act2_intermission_first6;
        public string act2_intermission_first7;
        public string act2_intermission_first8;
        public string act2_intermission_first9;

        public string act2_intermission_first10;

        public string act2_intermission_second1;
        public string act2_intermission_second2;
        public string act2_intermission_second3;
        public string act2_intermission_second4;
        public string act2_intermission_second5;

        public string act2_intermission_second6;
        public string act2_intermission_second7;
        public string act2_intermission_second8;

        public string act2_intermission_second9;
        public string act2_intermission_second10;
        public string act2_intermission_second11;

        public string act2_intermission_third1;
        public string act2_intermission_third2;

        public string act2_intermission_third3;
        public string act2_intermission_third4;
        public string act2_intermission_third5;
        public string act2_intermission_third6;
        public string act2_intermission_third7;

        public string act2_intermission_third8;
        public string act2_intermission_third9;
        public string act2_intermission_third10;

        public string act2_intermission_fourth1;
        public string act2_intermission_fourth2;
        public string act2_intermission_fourth3;
        public string act2_intermission_fourth4;
        
        public string act2_intermission_fourth5;

        public string act2_intermission_fourth6;
        public string act2_intermission_fourth7;
        public string act2_intermission_fourth8;

        public string act2_intermission_fourth9;
        public string act2_intermission_fourth10;
        public string act2_intermission_fourth11;
        public string act2_intermission_fourth12;

        public string act2_intermission_fourth13;

        public string act2_intermission_fifth1;

        public string act2_intermission_fifth2;
        public string act2_intermission_fifth3;
        public string act2_intermission_fifth4;

        public string act2_intermission_fifth5;
        public string act2_intermission_fifth6;

        public string act2_intermission_sixth1;

        public string act2_intermission_sixth2;
        public string act2_intermission_sixth3;

        public string act2_intermission_tobecontinued;
        public string act2_intermission_tobecontinuedshadow;

    }

    public class Body
    {
        public string bodyName;
    }

    public class FrontEnd
    {
        public string mainmenu_earlyAccess;
        public string mainmenu_halloween;
        public string mainmenu_easter;
        public string mainmenu_christmas;
        public string mainmenu_play;
        public string mainmenu_options;
        public string mainmenu_credits;
        public string mainmenu_quit;
        public string mainmenu_mods;
        public string mainmenu_restart;

        public string difficulty_title;
        public string difficulty_easy;
        public string difficulty_normal;
        public string difficulty_hard;
        public string difficulty_harmless;
        public string difficulty_lenient;
        public string difficulty_standard;
        public string difficulty_violent;
        public string difficulty_brutal;
        public string difficulty_umd;

        public string difficulty_harmlessDescription1;
        public string difficulty_harmlessDescription2;
        public string difficulty_harmlessDescription3;
        public string difficulty_lenientDescription1;
        public string difficulty_lenientDescription2;
        public string difficulty_lenientDescription3;
        public string difficulty_standardDescription1;
        public string difficulty_standardDescription2;
        public string difficulty_standardDescription3;
        public string difficulty_violentDescription1;
        public string difficulty_violentDescription2;
        public string difficulty_violentDescription3;

        public string difficulty_tweakReminder;
        public string difficulty_underConstruction;

        public string chapter_title;
        public string chapter_prelude;
        public string chapter_act1;
        public string chapter_act2;
        public string chapter_act3;
        public string chapter_prime;
        public string chapter_cyberGrind;
        public string chapter_sandbox;
        public string chapter_secretMission;

        public string layer_prelude;
        public string layer_limbo;
        public string layer_lust;
        public string layer_gluttony;
        public string layer_greed;
        public string layer_wrath;
        public string layer_heresy;
        public string layer_prime;

        public string level_challenge;
        public string level_challengeCompleted;

        public string level_fullIntroPrompt;
        public string level_fullIntroPromptYes;
        public string level_fullIntroPromptNo;
        public string level_fullIntroPromptCancel;

    }

    public class Book
    {
        public string books_scanning;

        public string books_pressToClose1;
        public string books_pressToClose2;

        public string books_limboFourth1;
        public string books_limboFourth2;
        public string books_limboFourth3;
        public string books_limboFourth4;
        public string books_limboFourth5;

        public string books_lustSecond1;
        public string books_lustSecond2;
        public string books_lustSecond3;
        public string books_lustSecond4;
        public string books_lustSecond5;


        public string books_greedSecond1;
        public string books_greedSecond2;
        public string books_greedSecond3;
        public string books_greedSecond4;
        public string books_greedSecond5;
        public string books_greedSecond6;

        public string books_greedThird1;
        public string books_greedThird2;
        public string books_greedThird3;
        public string books_greedThird4;

        public string books_wrathSecond1;
        public string books_wrathSecond2;
        public string books_wrathSecond3;
        public string books_wrathSecond4;
        public string books_wrathSecond5;
        public string books_wrathSecond6;
        public string books_wrathSecond7;
        public string books_wrathSecond8;
        public string books_wrathSecond9;

    }

    public class PauseMenu
    {
        public string pause_title;
        public string pause_resume;
        public string pause_respawn;
        public string pause_restart;
        public string pause_options;
        public string pause_quit;

        public string pause_restartConfirm;
        public string pause_quitConfirm;
        public string pause_restartConfirmYes;
        public string pause_restartConfirmNo;
        public string pause_quitConfirmYes;
        public string pause_quitConfirmNo;

        public string pause_disableWindow;

    }
    

    public class ShopStrings
    {
        public string shop_tipofthedayTitle;
        public string shop_tipoftheday;
        public string shop_weapons;
        public string shop_monsters;
        public string shop_cybergrind;
        public string shop_returnToMission;
        public string shop_sandbox;
        public string shop_soulOrbs;

        public string shop_cybergrindDescription1;
        public string shop_cybergrindDescription2;
        public string shop_cybergrindDescription3;
        public string shop_cybergrindEnterTitle;
        public string shop_cybergrindEnter;
        public string shop_cybergrindReturningTo;
        public string shop_cybergrindExitTitle;
        public string shop_cybergrindExit;

        public string shop_sandboxTitle;
        public string shop_sandboxDescription1;
        public string shop_sandboxDescription2;
        public string shop_sandboxEnter;

        public string shop_back;
        public string shop_weaponInfo;
        public string shop_weaponColors;

        public string shop_weaponsRevolver;
        public string shop_weaponsShotgun;
        public string shop_weaponsNailgun;
        public string shop_weaponsRailcannon;
        public string shop_weaponsRocketLauncher;
        public string shop_weaponsArms;

        public string shop_revolverPiercer;
        public string shop_revolverPiercerDescription1;
        public string shop_revolverPiercerDescription2;
        public string shop_revolverMarksman;
        public string shop_revolverMarksmanDescription1;
        public string shop_revolverMarksmanDescription2;
        public string shop_revolverMarksmanDescription3;

        public string shop_shotgunCoreEject;
        public string shop_shotgunCoreEjectDescription1;
        public string shop_shotgunCoreEjectDescription2;
        public string shop_shotgunCoreEjectDescription3;

        public string shop_shotgunPumpCharge;
        public string shop_shotgunPumpChargeDescription1;
        public string shop_shotgunPumpChargeDescription2;

        public string shop_nailgunMagnet;
        public string shop_nailgunMagnetDescription1;
        public string shop_nailgunMagnetDescription2;

        public string shop_nailgunOverheat;
        public string shop_nailgunOverheatDescription1;
        public string shop_nailgunOverheatDescription2;

        public string shop_railcannonElectric;
        public string shop_railcannonElectricDescription1;
        public string shop_railcannonElectricDescription2;
        public string shop_railcannonElectricDescription3;

        public string shop_railcannonScrewdriver;
        public string shop_railcannonScrewdriverDescription1;
        public string shop_railcannonScrewdriverDescription2;

        public string shop_railcannonMalicious;
        public string shop_railcannonMaliciousDescription1;
        public string shop_railcannonMaliciousDescription2;

        public string shop_rocketLauncherFreeze;
        public string shop_rocketLauncherFreezeDescription1;
        public string shop_rocketLauncherFreezeDescription2;
        public string shop_rocketLauncherFreezeDescription3;
        
        public string shop_rocketLauncherSrsCannon;
        public string shop_rocketLauncherSrsCannonDescription1;
        public string shop_rocketLauncherSrsCannonDescription2;
        public string shop_rocketLauncherSrsCannonDescription3;

        public string shop_armFeedbacker;
        public string shop_armFeedbackerDescription1;
        public string shop_armFeedbackerDescription2;

        public string shop_armKnuckleblaster;
        public string shop_armKnuckleblasterDescription1;
        public string shop_armKnuckleblasterDescription2;

        public string shop_armWhiplash;
        public string shop_armWhiplashDescription1;
        public string shop_armWhiplashDescription2;

        public string shop_data;
        public string shop_strategy;
        public string shop_advancedStrategy;

        public string shop_loreRevolver1;
        public string shop_loreRevolver2;
        public string shop_loreRevolver3;
        public string shop_loreRevolver4;
        public string shop_loreRevolver5;
        public string shop_loreRevolver6;
        public string shop_loreRevolver7;
        public string shop_loreRevolver8;
        public string shop_loreRevolver9;
        public string shop_loreRevolver10;

        public string shop_loreShotgun1;
        public string shop_loreShotgun2;
        public string shop_loreShotgun3;
        public string shop_loreShotgun4;
        public string shop_loreShotgun5;
        public string shop_loreShotgun6;
        public string shop_loreShotgun7;
        public string shop_loreShotgun8;
        public string shop_loreShotgun9;

        public string shop_loreNailgun1;
        public string shop_loreNailgun2;
        public string shop_loreNailgun3;
        public string shop_loreNailgun4;
        public string shop_loreNailgun5;
        public string shop_loreNailgun6;
        public string shop_loreNailgun7;
        public string shop_loreNailgun8;
        public string shop_loreNailgun9;

        public string shop_loreRailcannon1;
        public string shop_loreRailcannon2;
        public string shop_loreRailcannon3;
        public string shop_loreRailcannon4;
        public string shop_loreRailcannon5;
        public string shop_loreRailcannon6;
        public string shop_loreRailcannon7;
        public string shop_loreRailcannon8;
        public string shop_loreRailcannon9;

        public string shop_loreRocketLauncher1;
        public string shop_loreRocketLauncher2;
        public string shop_loreRocketLauncher3;
        public string shop_loreRocketLauncher4;
        public string shop_loreRocketLauncher5;
        public string shop_loreRocketLauncher6;
        public string shop_loreRocketLauncher7;
        public string shop_loreRocketLauncher8;
        public string shop_loreRocketLauncher9;
        public string shop_loreRocketLauncher10;
        public string shop_loreRocketLauncher11;
        public string shop_loreRocketLauncher12;
        public string shop_loreRocketLauncher13;

        public string shop_revolverPreset1;
        public string shop_revolverPreset2;
        public string shop_revolverPreset3;
        public string shop_revolverPreset4;
        public string shop_revolverPreset5;

        public string shop_shotgunPreset1;
        public string shop_shotgunPreset2;
        public string shop_shotgunPreset3;
        public string shop_shotgunPreset4;
        public string shop_shotgunPreset5;

        public string shop_nailgunPreset1;
        public string shop_nailgunPreset2;
        public string shop_nailgunPreset3;
        public string shop_nailgunPreset4;
        public string shop_nailgunPreset5;

        public string shop_railcannonPreset1;
        public string shop_railcannonPreset2;
        public string shop_railcannonPreset3;
        public string shop_railcannonPreset4;
        public string shop_railcannonPreset5;

        public string shop_rocketlauncherPreset1;
        public string shop_rocketlauncherPreset2;
        public string shop_rocketlauncherPreset3;
        public string shop_rocketlauncherPreset4;
        public string shop_rocketlauncherPreset5;

        public string shop_colorsPreset;
        public string shop_colorsCustom;
        public string shop_colorsDone;
        public string shop_colorsAlternative;
        public string shop_colorsCustomUnlockPrompt;



    }
    public class Levels
    {
        public string levelName_mainMenu;
        public string levelName_cybergrind;
        public string levelName_sandbox;
        public string levelName_tutorial;

        public string levelName_preludeFirst;
        public string levelName_preludeSecond;
        public string levelName_preludeThird;
        public string levelName_preludeFourth;
        public string levelName_preludeFifth;
        public string levelName_preludeSecret;

        public string levelName_limboFirst;
        public string levelName_limboSecond;
        public string levelName_limboThird;
        public string levelName_limboFourth;
        public string levelName_limboSecret;

        public string levelName_lustFirst;
        public string levelName_lustSecond;
        public string levelName_lustThird;
        public string levelName_lustFourth;
        public string levelName_lustSecret;

        public string levelName_gluttonyFirst;
        public string levelName_gluttonySecond;

        public string levelName_greedFirst;
        public string levelName_greedSecond;
        public string levelName_greedThird;
        public string levelName_greedFourth;
        public string levelName_greedSecret;

        public string levelName_wrathFirst;
        public string levelName_wrathSecond;
        public string levelName_wrathThird;
        public string levelName_wrathFourth;
        public string levelName_wrathSecret;

        public string levelName_heresyFirst;
        public string levelName_heresySecond;

        public string levelName_primeFirst;
        public string levelName_primeSecond;
        public string levelName_primeThird;
    }

    public class LevelTips
    {
        public string leveltips_preludeSecond1;
        public string leveltips_preludeSecond2;
        public string leveltips_preludeThird1;
        public string leveltips_preludeThird2;
        public string leveltips_preludeThird3;
        public string leveltips_preludeFourth1;
        public string leveltips_preludeFourth2;
        public string leveltips_preludeFifth;

        public string leveltips_limboFirst;
        public string leveltips_limboSecond;
        public string leveltips_limboThird1;
        public string leveltips_limboThird2;
        public string leveltips_limboFourth;

        public string leveltips_lustFirst;
        public string leveltips_lustSecond1;
        public string leveltips_lustSecond2;
        public string leveltips_lustSecond3;
        public string leveltips_lustThird;
        public string leveltips_lustFourth1;
        public string leveltips_lustFourth2;

        public string leveltips_gluttonyFirst;
        public string leveltips_gluttonySecond1;
        public string leveltips_gluttonySecond2;

        public string leveltips_greedFirst;
        public string leveltips_greedSecond;
        public string leveltips_greedThird;
        public string leveltips_greedFourth;

        public string leveltips_wrathFirst;
        public string leveltips_wrathSecond;
        public string leveltips_wrathThird;
        public string leveltips_wrathFourth1;
        public string leveltips_wrathFourth2;

        public string leveltips_heresyFirst1;
        public string leveltips_heresyFirst2;
        public string leveltips_heresySecond1;
        public string leveltips_heresySecond2;

        public string leveltips_primeFirst1;
        public string leveltips_primeFirst2;
        public string leveltips_primeSecond;

        public string leveltips_cybergrind;
        public string leveltips_sandbox1;
        public string leveltips_sandbox2;
        
        public string leveltips_devMuseum;
    }

    public class EnemyNames
    {
        public string enemyname_filth;
        public string enemyname_stray;
        public string enemyname_schism;

        public string enemyname_soldier;
        public string enemyname_minos;
        public string enemyname_stalker;
        public string enemyname_insurrectionist;
        public string enemyname_swordsmachine;
        public string enemyname_drone;
        public string enemyname_streetCleaner;

        public string enemyname_sentry;
        public string enemyname_idol;
        public string enemyname_ferryman;
        public string enemyname_leviathan;


        public string enemyname_v2;
        public string enemyname_v2Second;
        public string enemyname_mindFlayer;
        public string enemyname_malFace;
        public string enemyname_cerberus;
        public string enemyname_hideousMass;
        public string enemyname_gabriel;
        public string enemyname_gabrielSecond;
        public string enemyname_virtue;
        public string enemyname_somethingWicked;
        public string enemyname_fleshPrison;
        public string enemyname_minosPrime;

        public string enemyname_boss_cerberus;
        public string enemyname_boss_cancerousRodent;
        public string enemyname_boss_veryCancerousRodent;
        public string enemyname_boss_hideousMass;
        public string enemyname_boss_swordsmachineAgony;
        public string enemyname_boss_swordsmachineTundra;
        public string enemyname_boss_corpseOfKingMinos;
        public string enemyname_boss_gabriel;
        public string enemyname_boss_insurrectionist;
        public string enemyname_boss_mandalore;
        public string enemyname_boss_v2;
        public string enemyname_boss_ferryman;
        public string enemyname_boss_leviathan;
        public string enemyname_boss_insurrectionistRude;
        public string enemyname_boss_insurrectionistAngry;
        public string enemyname_boss_gabrielSecond;
        public string enemyname_boss_fleshPanopticon;
        public string enemyname_boss_sisyphusPrime;


        public string enemyname_type_lesserHusk;
        public string enemyname_type_greaterHusk;
        public string enemyname_type_supremeHusk;
        public string enemyname_type_lesserDemon;
        public string enemyname_type_greaterDemon;
        public string enemyname_type_supremeDemon;
        public string enemyname_type_lesserMachine;
        public string enemyname_type_greaterMachine;
        public string enemyname_type_supremeMachine;
        public string enemyname_type_lesserAngel;
        public string enemyname_type_greaterAngel;
        public string enemyname_type_supremeAngel;
        public string enemyname_type_primeSoul;

    }

    public class Option
    {
        public string options_title;
        public string options_back;

        public string category_general;
        public string category_controls;
        public string category_graphics;
        public string category_sound;
        public string category_display;
        public string category_assists;
        public string category_colors;
        public string category_saves;

        public string general_mouseSensitivity;
        public string general_xInversion;
        public string general_yInversion;
        public string general_fieldOfVision;
        public string general_weaponPosition;
        public string general_weaponPositionRight;
        public string general_weaponPositionMiddle;
        public string general_weaponPositionLeft;
        public string general_rememberWeapon;
        public string general_screenShake;
        public string general_screenShakeMinimum;
        public string general_screenShakeMaximum;
        public string general_cameraTilt;
        public string general_restartWarning;
        public string general_discordRpc;
        public string general_seasonalEvent;
        public string general_controllerRumble;
        public string general_controllerRumbleCustomize;

        public string controls_resetDefault;
        public string controls_movement;
        public string controls_forward;
        public string controls_back;
        public string controls_left;
        public string controls_right;
        public string controls_jump;
        public string controls_dash;
        public string controls_actions;
        public string controls_primaryFire;
        public string controls_secondaryFire;
        public string controls_punch;
        public string controls_lastUsedWeapon;
        public string controls_changeVariation;
        public string controls_changeArm;
        public string controls_slide;
        public string controls_whiplash;
        public string controls_weapons;
        public string controls_slot1;
        public string controls_slot2;
        public string controls_slot3;
        public string controls_slot4;
        public string controls_slot5;
        public string controls_scrollType;
        public string controls_scrollTypeWeapons;
        public string controls_scrollTypeVariations;
        public string controls_scrollTypeAll;
        public string controls_mouseWheelToChangeWeapon;
        public string controls_reverseScroll;

        public string graphics_title;
        public string graphics_resolution;
        public string graphics_fullscreen;
        public string graphics_maxFps;
        public string graphics_maxFpsNone;
        public string graphics_maxFps2x;
        public string graphics_vsync;
        public string graphics_filters;
        public string graphics_filtersDescription;
        public string graphics_pixelisation;
        public string graphics_pixelisationNone;
        public string graphics_pixelisation720p;
        public string graphics_pixelisation480p;
        public string graphics_pixelisation360p;
        public string graphics_pixelisation240p;
        public string graphics_pixelisation144p;
        public string graphics_pixelisation36p;
        public string graphics_dithering;
        public string graphics_ditheringMinimum;
        public string graphics_textureWarping;
        public string graphics_vertexWarping;
        public string graphics_vertexWarpingNone;
        public string graphics_vertexWarpingLight;
        public string graphics_vertexWarpingMedium;
        public string graphics_vertexWarpingStrong;
        public string graphics_vertexWarpingVeryStrong;
        public string graphics_vertexWarpingAbsurd;

        public string graphics_customColorPalette;
        public string graphics_customColorPaletteSelect;

        public string graphics_colorCompression;
        public string graphics_colorCompressionNone;
        public string graphics_colorCompressionLight;
        public string graphics_colorCompressionMedium;
        public string graphics_colorCompressionStrong;
        public string graphics_colorCompressionVeryStrong;
        public string graphics_colorCompressionAbsurd;
        public string graphics_performance;
        public string graphics_performanceSimpleExplosions;
        public string graphics_performanceSimpleFire;
        public string graphics_performanceSimpleSpawn;
        public string graphics_performanceDisableEnviParticles;
        public string graphics_performanceSimpleNails;
        public string graphics_gore;
        public string graphics_goreNote;
        public string graphics_goreEnable;
        public string graphics_goreDisablePhysics;
        public string graphics_goreBloodChance;
        public string graphics_goreMaxGore;

        public string audio_title;
        public string audio_subtitles;
        public string audio_globalVolume;
        public string audio_musicVolume;
        public string audio_dubbing;

        public string hud_title;
        public string hud_type;
        public string hud_typeNone;
        public string hud_typeStandard;
        public string hud_typeClassicColor;
        public string hud_typeClassicWhite;
        public string hud_hudElements;
        public string hud_backgroundOpacity;
        public string hud_backgroundOpacityMinimum;
        public string hud_backgroundOpacityMaximum;
        public string hud_alwaysOnTop;
        public string hud_icons;
        public string hud_weaponIcon;
        public string hud_armIcon;
        public string hud_railcannonMeter;
        public string hud_styleMeter;
        public string hud_styleInfo;

        public string crosshair_title;
        public string crosshair_type;
        public string crosshair_typeNone;
        public string crosshair_typeSmall;
        public string crosshair_typeLarge;
        public string crosshair_color;
        public string crosshair_colorInverted;
        public string crosshair_colorWhite;
        public string crosshair_colorGrey;
        public string crosshair_colorBlack;
        public string crosshair_colorRed;
        public string crosshair_colorGreen;
        public string crosshair_colorBlue;
        public string crosshair_colorCyan;
        public string crosshair_colorYellow;
        public string crosshair_colorMagenta;

        public string crosshair_size;
        public string crosshair_sizeNone;
        public string crosshair_sizeThin;
        public string crosshair_sizeMedium;
        public string crosshair_sizeThick;
        public string crosshair_sizeVeryThick;
        public string crosshair_hudFade;
        public string crosshair_powerupBar;

        public string assists_title;
        public string assists_majorAssistsDisclaimer1;
        public string assists_majorAssistsDisclaimer2;
        public string assists_majorAssistsDisclaimer3;
        public string assists_majorAssistsDisclaimerConfirm;
        public string assists_majorAssistsDisclaimerConfirmYes;
        public string assists_majorAssistsDisclaimerConfirmNo;
        public string assists_minorAssistsTitle;
        public string assists_minor;
        public string assists_autoAim;
        public string assists_autoAimPercent;
        public string assists_autoAimPercentMinimum;
        public string assists_autoAimPercentMaximum;
        public string assists_enemySilhouettes;
        public string assists_enemySilhouettesOutlines;
        public string assists_enemySilhouettesDistance;
        public string assists_enemySilhouettesDistanceMinimum;
        public string assists_enemySilhouettesOutlinesOnly;
        public string assists_enemySilhouettesOutlineThickness;
        public string assists_major;
        public string assists_majorActivate;
        public string assists_gameSpeed;
        public string assists_damageTaken;
        public string assists_bossOverride;
        public string assists_bossRestartRequired;
        public string assists_bossOverrideNone;
        public string assists_infiniteEnergy;
        public string assists_disableWhiplashHardDamage;
        public string assists_disableHardDamage;
        public string assists_disableWeaponFreshness;
        public string assists_disablePopupHints;

        public string colors_title;
        public string colors_reset;
        public string colors_hudHealth;
        public string colors_hudHealthNumber;
        public string colors_hudDamage;
        public string colors_hudHardDamage;
        public string colors_hudOverheal;
        public string colors_hudEnergyFull;
        public string colors_hudEnergyPartial;
        public string colors_hudEnergyEmpty;
        public string colors_railcannonFull;
        public string colors_railcannonPartial;
        public string colors_variationBlue;
        public string colors_variationGreen;
        public string colors_variationRed;
        public string colors_variationGold;
        public string colors_enemies;

        public string save_select;
        public string save_selected;
        public string save_delete;
        public string save_warning1;
        public string save_warning2;
        public string save_reloadYes;
        public string save_reloadNo;
        public string save_deleteWarning1;
        public string save_deleteWarning2;
        public string save_deleteYes;
        public string save_deleteNo;
        public string save_close;
        public string save_slotEmpty;
        
        public string rumble_title;
        public string rumble_finalMultiplier;
        public string rumble_coinToss;
        public string rumble_dash;
        public string rumble_heavyFallImpact;
        public string rumble_heavyFall;
        public string rumble_gunFire;
        public string rumble_gunFireProjectile;
        public string rumble_gunFireStrong;
        public string rumble_nailgunFire;
        public string rumble_railcannonIdle;
        public string rumble_revolverCharge;
        public string rumble_sawblade;
        public string rumble_shotgunCharge;
        public string rumble_superSaw;
        public string rumble_jump;
        public string rumble_magnet;
        public string rumble_parryFlash;
        public string rumble_punch;
        public string rumble_slide;
        public string rumble_whiplashThrow;
        public string rumble_whiplashPull;
        public string rumble_intensity;
        public string rumble_endDelay;
        public string rumble_reset;
        
        public string language_title;
        public string language_languages;
        public string language_openLanguageFolder;
    }

    public class Tutorial
    {
        public string tutorial_introStartup1;
        public string tutorial_introStartup2;
        public string tutorial_introVersion1;
        public string tutorial_introVersion2;
        public string tutorial_introCalibration1;
        public string tutorial_introCalibration2;
        public string tutorial_recalibrationPrompt;
        public string tutorial_calibrationAudio;
        public string tutorial_calibrationVideo;
        public string tutorial_calibrationMechanics;
        public string tutorial_calibrationComplete1;
        public string tutorial_calibrationComplete2;
        public string tutorial_introReminder;
        public string tutorial_systemsOperational;
        public string tutorial_introLoadStatus;

        public string tutorial_audioCalibrationTitle;
        public string tutorial_audioCalibrationWarning1;
        public string tutorial_audioCalibrationWarning2;
        public string tutorial_audioCalibrationWarning3;
        public string tutorial_audioCalibrationWarningPromptYes;
        public string tutorial_audioCalibrationWarningPromptNo;

        public string tutorial_videoCalibrationTitle;
        public string tutorial_videoCalibrationPcDescription;
        public string tutorial_videoCalibrationPsxDescription;

        public string tutorial_controllerCalibrationTitle;
        public string tutorial_controllerCalibrationSubtitle;
        public string tutorial_controllerCalibrationTooltip;

        public string tutorial_introID1;
        public string tutorial_introID2;
        public string tutorial_introLocation1;
        public string tutorial_introLocation2;
        public string tutorial_introObjective1;
        public string tutorial_introObjective2;
        public string tutorial_introRed1;
        public string tutorial_introRed2;
        public string tutorial_introRed3;

        public string tutorial_punch1;
        public string tutorial_punch2;
        public string tutorial_slide1;
        public string tutorial_slide2;
        public string tutorial_dash1;
        public string tutorial_dash2;
        public string tutorial_dash3;
        public string tutorial_health1;
        public string tutorial_health2;
        public string tutorial_walljump;
        public string tutorial_shockwave1;
        public string tutorial_shockwave2;
        public string tutorial_shockwave3;
        public string tutorial_orb1;
        public string tutorial_orb2;

    }

    public class Overture
    {
        public string prelude_first_openingCredits1;
        public string prelude_first_openingCredits2;
        public string prelude_first_pipeClip;
        public string prelude_first_revolverPierce1;
        public string prelude_first_revolverPierce2;
        public string prelude_first_parry;
        public string prelude_first_hardDamage1;
        public string prelude_first_hardDamage2;

        public string prelude_first_groundSlam1;
        public string prelude_first_groundSlam2;

        public string prelude_second_shop;
        public string prelude_second_doorClip;
        public string prelude_second_changeEquipped;

        public string prelude_third_needShotgun;
        public string prelude_third_shotgun1;
        public string prelude_third_shotgun2;
        public string prelude_third_shotgun3;
        public string prelude_third_shotgunPierce;

        public string prelude_secret_somethingWicked;
    }

    public class Challenges
    {
        public string challenges_preludeFirst;
        public string challenges_preludeSecond;
        public string challenges_preludeThird;
        public string challenges_preludeFourth;
        public string challenges_preludeFifth;

        public string challenges_limboFirst;
        public string challenges_limboSecond;
        public string challenges_limboThird;
        public string challenges_limboFourth;

        public string challenges_lustFirst;
        public string challenges_lustSecond;
        public string challenges_lustThird;
        public string challenges_lustFourth;

        public string challenges_gluttonyFirst;
        public string challenges_gluttonySecond;

        public string challenges_greedFirst;
        public string challenges_greedSecond;
        public string challenges_greedThird;
        public string challenges_greedFourth;

        public string challenges_wrathFirst;
        public string challenges_wrathSecond;
        public string challenges_wrathThird;
        public string challenges_wrathFourth;

        public string challenges_heresyFirst;
        public string challenges_heresySecond;
    }

    public class a1
    {
        public string act1_limboFirst_items1;
        public string act1_limboFirst_items2;
        public string act1_limboFirst_nailgun1;
        public string act1_limboFirst_nailgun2;
        public string act1_limboFirst_nailgun3;

        public string act1_limboSecond_blueAttack;

        public string act1_limboThird_splitDoor1;
        public string act1_limboThird_splitDoor2;

        public string act1_limboFourth_book;
        public string act1_limboFourth_hank1;
        public string act1_limboFourth_hank2;
        public string act1_limboFourth_alternateRevolver;
        public string act1_limboFourth_newArm;

        public string act1_limboSecret_noclipSkip;

        public string act1_lustFirst_knuckleblaster1;
        public string act1_lustFirst_knuckleblaster2;
        public string act1_lustFirst_dashJump;

        public string act1_lustSecond_feedbacker1;
        public string act1_lustSecond_feedbacker2;
        public string act1_lustSecond_railcannon;

        public string act1_lustThird_water;


        public string act1_secret;


    }
    public class a2
    {
        public string act2_greedSecond_sand;

        public string act2_greedThird_wallClip;
        public string act2_greedThird_troll1;
        public string act2_greedThird_troll2;
        public string act2_greedThird_tombOfKings;

        public string act2_greedFourth_v2;
        public string act2_greedFourth_whiplash1;
        public string act2_greedFourth_whiplash2;
        public string act2_greedFourth_whiplash3;

        public string act2_greedFourth_whiplashHardDamage1;
        public string act2_greedFourth_whiplashHardDamage2;

        public string act2_greedSecret_holdToJump1;
        public string act2_greedSecret_holdToJump2;

        public string act2_greedSecret_transactionComplete1;
        public string act2_greedSecret_transactionComplete2;

        public string act2_greed_secretDoor;

        public string act2_wrathFirst_slingshot;
        public string act2_wrathFirst_whiplashUnderwater;
        public string act2_wrathFirst_waterDrained;
        public string act2_wrathFirst_sentry;

        public string act2_wrathSecond_jakito1;
        public string act2_wrathSecond_jakito2;
        public string act2_wrathSecond_jakito3;
        public string act2_wrathSecond_neptune;
        public string act2_wrathSecond_hark;
        public string act2_wrathSecond_idol;

        public string act2_wrathThird_rocketLauncher;
        public string act2_wrathThird_rocketLauncherMidair;
        public string act2_wrathThird_soldierBlock;
        public string act2_wrathThird_hank;

        public string act2_heresyFirst_armboy;

        public string act2_secretNotReady;

    }

    public class Prime
    {
        public string primeSanctum_first_secretText1;
        public string primeSanctum_first_secretText2;
        public string primeSanctum_first_secretText3;
        public string primeSanctum_first_secretText4;
        public string primeSanctum_first_secretText5;
        public string primeSanctum_first_secretText6;
        public string primeSanctum_first_secretText7;
        public string primeSanctum_first_secretText8;
        public string primeSanctum_first_secretText9;

        public string primeSanctum_second_lockFirstLocked;
        public string primeSanctum_second_lockSecondLocked;
        public string primeSanctum_second_lockThirdLocked;
        public string primeSanctum_second_lockUnlocked;
        
        public string primeSanctum_second_lockOpen;
        public string primeSanctum_second_lockAreYouSure;
        public string primeSanctum_second_lockYes1;
        public string primeSanctum_second_lockYes2;
        public string primeSanctum_second_lockYes3;
        public string primeSanctum_second_lockYes4;
        public string primeSanctum_second_lockYes5;
        public string primeSanctum_second_lockNo1;
        public string primeSanctum_second_lockNo2;
        
        
        public string primeSanctum_second_secretText1;
        public string primeSanctum_second_secretText2;
        public string primeSanctum_second_secretText3;
        public string primeSanctum_second_secretText4;
        public string primeSanctum_second_secretText5;
        public string primeSanctum_second_secretText6;
        public string primeSanctum_second_secretText7;
        public string primeSanctum_second_secretText8;
        public string primeSanctum_second_secretText9;
        public string primeSanctum_second_secretText10;
        public string primeSanctum_second_secretText11;
        public string primeSanctum_second_secretText12;
        public string primeSanctum_second_secretText13;

    }

    public class Secret
    {


        public string secretLevels_prelude_somethingWicked;
        public string secretLevels_prelude_testamentTitle;
        public string secretLevels_prelude_testament1;
        public string secretLevels_prelude_testament2;
        public string secretLevels_prelude_testament3;
        public string secretLevels_prelude_testament4;

        public string secretLevels_first_testamentTitle;
        public string secretLevels_first_testament1;
        public string secretLevels_first_testament2;
        public string secretLevels_first_testament3;
        public string secretLevels_first_testament4;

        public string secretLevels_fourth_testamentTitle;
        public string secretLevels_fourth_testament1;
        public string secretLevels_fourth_testament2;
        public string secretLevels_fourth_testament3;
        public string secretLevels_fourth_testament4;
        public string secretLevels_fourth_testament5;
        public string secretLevels_fourth_testament6;
        public string secretLevels_fourth_testament7;

        public string secretLevels_complete1;
        public string secretLevels_complete2;
    }

    public class Museum
    {
        public string museum_bookHakita1;
        public string museum_bookHakita2;
        public string museum_bookHakita3;
        public string museum_bookHakita4;
        public string museum_bookHakita5;
        public string museum_bookHakita6;
        public string museum_bookHakita7;
        public string museum_bookHakita8;
        public string museum_bookHakita9;
        public string museum_bookHakita10;
        public string museum_bookHakita11;
        public string museum_bookHakita12;
        public string museum_bookHakita13;

        public string museum_bookFrancisXie1;
        public string museum_bookFrancisXie2;
        public string museum_bookFrancisXie3;
        public string museum_bookFrancisXie4;
        public string museum_bookFrancisXie5;
        public string museum_bookFrancisXie6;
        public string museum_bookFrancisXie7;
        public string museum_bookFrancisXie8;
        public string museum_bookFrancisXie9;
        
        public string museum_bookJerichoRus1;
        public string museum_bookJerichoRus2;
        public string museum_bookJerichoRus3;
        public string museum_bookJerichoRus4;
        public string museum_bookJerichoRus5;
        public string museum_bookJerichoRus6;
        public string museum_bookJerichoRus7;
        public string museum_bookJerichoRus8;
        public string museum_bookJerichoRus9;
        public string museum_bookJerichoRus10;
        
        public string museum_bookBigRockBMP1;
        public string museum_bookBigRockBMP2;
        public string museum_bookBigRockBMP3;
        public string museum_bookBigRockBMP4;
        public string museum_bookBigRockBMP5;
        public string museum_bookBigRockBMP6;
        public string museum_bookBigRockBMP7;
        public string museum_bookBigRockBMP8;
        
        public string museum_bookMaximilianOvesson1;
        public string museum_bookMaximilianOvesson2;
        public string museum_bookMaximilianOvesson3;
        
        public string museum_bookVictoriaHolland1;
        public string museum_bookVictoriaHolland2;
        public string museum_bookVictoriaHolland3;
        public string museum_bookVictoriaHolland4;
        public string museum_bookVictoriaHolland5;
        public string museum_bookVictoriaHolland6;
        public string museum_bookVictoriaHolland7;
        public string museum_bookVictoriaHolland8;
        
        public string museum_bookToniStigell1;
        public string museum_bookToniStigell2;
        public string museum_bookToniStigell3;
        public string museum_bookToniStigell4;
        public string museum_bookToniStigell5;
        public string museum_bookToniStigell6;
        public string museum_bookToniStigell7;
        
        public string museum_bookFlyingDog1;
        public string museum_bookFlyingDog2;
        public string museum_bookFlyingDog3;
        public string museum_bookFlyingDog4;
        public string museum_bookFlyingDog5;
        public string museum_bookFlyingDog6;
        
        public string museum_bookSamuelJamesBryan1;
        public string museum_bookSamuelJamesBryan2;
        public string museum_bookSamuelJamesBryan3;
        
        public string museum_bookQATeam1;
        public string museum_bookQATeam2;
        public string museum_bookQATeam3;
        public string museum_bookQATeam4;
        public string museum_bookQATeam5;
        public string museum_bookQATeam6;
        public string museum_bookQATeam7;
        public string museum_bookQATeam8;
        public string museum_bookQATeam9;
        public string museum_bookQATeam10;
        
        public string museum_bookPitr1;
        public string museum_bookPitr2;
        public string museum_bookPitr3;
        public string museum_bookPitr4;
        public string museum_bookPitr5;
        public string museum_bookPitr6;
        public string museum_bookPitr7;
        public string museum_bookPitr8;
        
        public string museum_bookHeckteck1;
        public string museum_bookHeckteck2;
        public string museum_bookHeckteck3;
        
        public string museum_bookCabalcrow1;
        public string museum_bookCabalcrow2;
        public string museum_bookCabalcrow3;
        
        public string museum_bookLucasVarney1;
        public string museum_bookLucasVarney2;
        public string museum_bookLucasVarney3;
        
        public string museum_bookBenMoir1;
        public string museum_bookBenMoir2;
        public string museum_bookBenMoir3;
        public string museum_bookBenMoir4;
        
        public string museum_bookMeganeko1;
        public string museum_bookMeganeko2;
        public string museum_bookMeganeko3;
        
        public string museum_bookKeygenChurch1;
        public string museum_bookKeygenChurch2;
        public string museum_bookKeygenChurch3;
        public string museum_bookKeygenChurch4;
        
        public string museum_bookSalad1;
        public string museum_bookSalad2;
        public string museum_bookSalad3;
        public string museum_bookSalad4;
        public string museum_bookSalad5;
        
        public string museum_bookJacobHHR1;
        public string museum_bookJacobHHR2;
        public string museum_bookJacobHHR3;
        
        public string museum_bookVVizard1;
        public string museum_bookVVizard2;
        public string museum_bookVVizard3;
        public string museum_bookVVizard4;
        
        public string museum_bookAdditionalMusic1;
        public string museum_bookAdditionalMusic2;
        public string museum_bookAdditionalMusic3;
        public string museum_bookAdditionalMusic4;
        public string museum_bookAdditionalMusic5;
        public string museum_bookAdditionalMusic6;
        public string museum_bookAdditionalMusic7;
        public string museum_bookAdditionalMusic8;
        public string museum_bookAdditionalMusic9;
        public string museum_bookAdditionalMusic10;
        
        public string museum_bookAdditionalCredits1;
        public string museum_bookAdditionalCredits2;
        public string museum_bookAdditionalCredits3;
        public string museum_bookAdditionalCredits4;
        public string museum_bookAdditionalCredits5;
        
        public string museum_bookStephanWeyte1;
        public string museum_bookStephanWeyte2;
        public string museum_bookStephanWeyte3;
        
        public string museum_bookLenvalBrown1;
        public string museum_bookLenvalBrown2;
        
        public string museum_bookGianniMatragrano1;
        public string museum_bookGianniMatragrano2;
        public string museum_bookGianniMatragrano3;
        public string museum_bookGianniMatragrano4;
        
        public string museum_bookMandalore1;
        public string museum_bookMandalore2;
        public string museum_bookMandalore3;
        public string museum_bookMandalore4;
        public string museum_bookMandalore5;
        public string museum_bookMandalore6;
        
        public string museum_weaponsBeamcutter1;
        public string museum_weaponsBeamcutter2;
        public string museum_weaponsBeamcutter3;
        public string museum_weaponsBeamcutter4;
        public string museum_weaponsBeamcutter5;
        public string museum_weaponsBeamcutter6;
        public string museum_weaponsBeamcutter7;
        public string museum_weaponsBeamcutter8;
        public string museum_weaponsBeamcutter9;
        
        public string museum_weaponsBlackHoleCannon1;
        public string museum_weaponsBlackHoleCannon2;
        public string museum_weaponsBlackHoleCannon3;
        public string museum_weaponsBlackHoleCannon4;
        public string museum_weaponsBlackHoleCannon5;
        public string museum_weaponsBlackHoleCannon6;
        public string museum_weaponsBlackHoleCannon7;
        public string museum_weaponsBlackHoleCannon8;
        
        public string museum_weaponsRevolver1;
        public string museum_weaponsRevolver2;
        public string museum_weaponsRevolver3;
        public string museum_weaponsRevolver4;
        public string museum_weaponsRevolver5;
        public string museum_weaponsRevolver6;
        
        public string museum_weaponsShotgun1;
        public string museum_weaponsShotgun2;
        public string museum_weaponsShotgun3;
        public string museum_weaponsShotgun4;
        public string museum_weaponsShotgun5;
        
        public string museum_weaponsNailgun1;
        public string museum_weaponsNailgun2;
        public string museum_weaponsNailgun3;
        public string museum_weaponsNailgun4;
        public string museum_weaponsNailgun5;
        public string museum_weaponsNailgun6;
        
        public string museum_enemiesFilth1;
        public string museum_enemiesFilth2;
        public string museum_enemiesFilth3;
        public string museum_enemiesFilth4;
        public string museum_enemiesFilth5;
        public string museum_enemiesFilth6;
        public string museum_enemiesFilth7;
        
        public string museum_enemiesStray1;
        public string museum_enemiesStray2;
        public string museum_enemiesStray3;
        public string museum_enemiesStray4;
        public string museum_enemiesStray5;
        
        public string museum_enemiesSchism1;
        public string museum_enemiesSchism2;
        public string museum_enemiesSchism3;
        public string museum_enemiesSchism4;
        public string museum_enemiesSchism5;
        public string museum_enemiesSchism6;
        
        public string museum_enemiesSwordsmachine1;
        public string museum_enemiesSwordsmachine2;
        public string museum_enemiesSwordsmachine3;
        public string museum_enemiesSwordsmachine4;
        public string museum_enemiesSwordsmachine5;
        public string museum_enemiesSwordsmachine6;
        
        public string museum_enemiesMaliciousFace1;
        public string museum_enemiesMaliciousFace2;
        public string museum_enemiesMaliciousFace3;
        public string museum_enemiesMaliciousFace4;
        public string museum_enemiesMaliciousFace5;
        public string museum_enemiesMaliciousFace6;
        public string museum_enemiesMaliciousFace7;

        public string museum_plaquesMuseumTitle;
        
        public string museum_plaquesHakita1;
        public string museum_plaquesHakita2;
        
        public string museum_plaquesArtRoom;
        public string museum_plaquesNerdRoom;
        public string museum_plaquesRestRoom;
        public string museum_plaquesTalkRoom;
        
        public string museum_plaquesFrancisXie1;
        public string museum_plaquesFrancisXie2;
        
        public string museum_plaquesJerichoRus1;
        public string museum_plaquesJerichoRus2;
        
        public string museum_plaquesBigRockBMP1;
        public string museum_plaquesBigRockBMP2;
        
        public string museum_plaquesMaxOvesson1;
        public string museum_plaquesMaxOvesson2;
        
        public string museum_plaquesVictoriaHolland1;
        public string museum_plaquesVictoriaHolland2;
        
        public string museum_plaquesToniStigell1;
        public string museum_plaquesToniStigell2;
        
        public string museum_plaquesFlyingdog1;
        public string museum_plaquesFlyingdog2;
        
        public string museum_plaquesSamuelJamesBryan1;
        public string museum_plaquesSamuelJamesBryan2;
        
        public string museum_plaquesCameronMartin1;
        public string museum_plaquesCameronMartin2;
        
        public string museum_plaquesDaliaFigueroa1;
        public string museum_plaquesDaliaFigueroa2;
        
        public string museum_plaquesTuckerWilkin1;
        public string museum_plaquesTuckerWilkin2;
        
        public string museum_plaquesScottGurney1;
        public string museum_plaquesScottGurney2;
        
        public string museum_plaquesPitr1;
        public string museum_plaquesPitr2;
        
        public string museum_plaquesHeckteck1;
        public string museum_plaquesHeckteck2;
        
        public string museum_plaquesCabalcrow1;
        public string museum_plaquesCabalcrow2;
        
        public string museum_plaquesLucasVarney1;
        public string museum_plaquesLucasVarney2;
        
        public string museum_plaquesBenMoir1;
        public string museum_plaquesBenMoir2;
        
        public string museum_plaquesDaveOshry1;
        public string museum_plaquesDaveOshry2;
        
        public string museum_plaquesMeganeko1;
        public string museum_plaquesMeganeko2;
        
        public string museum_plaquesKeygenChurch1;
        public string museum_plaquesKeygenChurch2;
        
        public string museum_plaquesSalad1;
        public string museum_plaquesSalad2;
        
        public string museum_plaquesJacobHHR1;
        public string museum_plaquesJacobHHR2;
        
        public string museum_plaquesVVizard1;
        public string museum_plaquesVVizard2;
        
        public string museum_plaquesAdditionalMusic;
        public string museum_plaquesAdditionalCredits;
        
        public string museum_plaquesStephanWeyte1;
        public string museum_plaquesStephanWeyte2;
        
        public string museum_plaquesLenvalBrown1;
        public string museum_plaquesLenvalBrown2;
        
        public string museum_plaquesGianniMatragrano1;
        public string museum_plaquesGianniMatragrano2;
        
        public string museum_plaquesJoyYoung1;
        public string museum_plaquesJoyYoung2;
        
        public string museum_plaquesMandalore1;
        public string museum_plaquesMandalore2;
        
        public string museum_rocketRace1;
        public string museum_rocketRace2;
        public string museum_rocketRaceResult;
        
        public string museum_cinemaPlay;
        public string museum_cinemaStop;

    }

    public class Misc
    {
        public string hud_noArm1;
        public string hud_noArm2;
        public string hud_majorAssists;
        public string hud_overhealOrb1;
        public string hud_overhealOrb2;
        public string hud_itemGrabError;
        public string hud_levelStats1;
        public string hud_levelStats2;
        public string hud_outOfBounds;
        public string hud_clashMode;
        public string hud_weaponVariation;

        public string spawner_sandboxTools;
        public string spawner_sandbox;
        public string spawner_enemies;
        public string spawner_items;
        public string spawner_special;
        public string spawner_unlockables;

        public string stats_time;
        public string stats_kills;
        public string stats_style;
        public string stats_secrets;
        public string stats_challenge;

        public string hellmap_prelude;
        public string hellmap_limbo;
        public string hellmap_lust;
        public string hellmap_gluttony;
        public string hellmap_greed;
        public string hellmap_wrath;
        public string hellmap_heresy;
        public string hellmap_prime;

        public string hellmap_first;
        public string hellmap_second;
        public string hellmap_third;
        public string hellmap_fourth;
        public string hellmap_climax;
        public string hellmap_act1crescendo;
        public string hellmap_act1climax;
        public string hellmap_act2crescendo;
        public string hellmap_act2climax;

        public string loading;

        public string levelstats_time;
        public string levelstats_kills;
        public string levelstats_style;
        public string levelstats_challenge;
        public string levelstats_secrets;
        public string levelstats_majorAssists;
        public string levelstats_boxes;

        public string state_activated;
        public string state_deactivated;
        public string state_yes;
        public string state_no;

        public string controls_leftClick;
        public string controls_middleClick;
        public string controls_rightClick;

        public string endstats_cheatsUsed;
        public string endstats_assistsUsed;
        public string endstats_noRestarts;
        public string endstats_restarts;
        public string endstats_noDamage;

        public string weapons_unavailable;
        public string weapons_alreadyBought;
        public string weapons_underConstruction;

        public string pressToSkip;

        public string youDied1;
        public string youDied2;

        public string classicHud_health;
        public string classicHud_weapon;
        public string classicHud_stamina;
        public string classicHud_arm;
        public string classicHud_railcannonMeter;

        public string enemyAlter_title;
        public string enemyAlter_sizeTitle;
        public string enemyAlter_uniformToggle;
        public string enemyAlter_uniformSmall;
        public string enemyAlter_uniformDefault;
        public string enemyAlter_uniformLarge;
        public string enemyAlter_metaTitle;
        public string enemyAlter_metaFrozen;
        public string enemyAlter_metaBreakable;
        public string enemyAlter_metaUnbreakable;
        public string enemyAlter_metaWeak;
        public string enemyAlter_jumpPadTitle;
        public string enemyAlter_jumpPadPower;
        public string enemyAlter_radianceTitle;
        public string enemyAlter_radianceEnable;
        public string enemyAlter_radianceDetails_tier;
        public string enemyAlter_radianceDamage_tier;
        public string enemyAlter_radianceHealth_tier;
        public string enemyAlter_radianceSpeed_tier;
        public string enemyAlter_boss_title;
        public string enemyAlter_boss_description;
        
        public string earlyAccessEnd1;
        public string earlyAccessEnd2;
        public string earlyAccessEnd3;

    }

    public class SandboxStrings
    {
        public string sandbox_shop_timeOfDay;
        public string sandbox_shop_worldOptions;
        public string sandbox_shop_icons;

        public string sandbox_shop_totalBoxes;
        public string sandbox_shop_totalProps;
        public string sandbox_shop_totalEnemies;
        public string sandbox_shop_totalTime;

        public string sandbox_shop_worldOptionsTitle;
        public string sandbox_shop_worldOptionsEnable;
        public string sandbox_shop_worldOptionsDisable;
        public string sandbox_shop_worldOptionsEnabled;
        public string sandbox_shop_worldOptionsDisabled;

        public string sandbox_shop_mapBorder;

        public string sandbox_shop_iconsTitle;
        public string sandbox_shop_default;
        public string sandbox_shop_pitr;
    }
}
