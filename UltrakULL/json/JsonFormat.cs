using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltrakULL.json
{
    public class JsonFormat
    {
        public Metadata metadata;
        public Body body;
        public FrontEnd frontend;
        public PauseMenu pauseMenu;
        public Option options;
        public Levels levelNames;
        public Challenges levelChallenges;
        public EnemyNames enemyNames;
        public Tutorial tutorial;
        public Overture prelude;
        public a1 act1;
        public a2 act2;
        public Misc misc;
        public LevelTips levelTips;
        public ShopStrings shop;
        public Prime primeSanctum;
        public Secret secretLevels;
        public IntermissionStrings intermission;
        public Book books;
        
    }


    public class Metadata
    {
        public string langName;
        public string langAuthor;
        public string langVersion;
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
        public string act1_intermission_second12;
        
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

    }

    public class Body
    {
        public string bodyName;
    }

    public class FrontEnd
    {
        public string mainmenu_earlyAccess;
        public string mainmenu_play;
        public string mainmenu_options;
        public string mainmenu_quit;

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

    }

    public class Book
    { 
        public string book_limboFourth;

        public string book_lustSecond1;
        public string book_lustSecond2;
        public string book_lustSecond3;
        public string book_lustSecond4;
        public string book_lustSecond5;


        public string book_greedSecond1;
        public string book_greedSecond2;
        public string book_greedSecond3;
        public string book_greedSecond4;
        public string book_greedSecond5;



        public string book_greedThird;


    }

    public class PauseMenu
    {
        public string pause_title;
        public string pause_resume;
        public string pause_respawn;
        public string pause_restart;
        public string pause_options;
        public string pause_quit;

    }
    
    public class ShopStrings
    {
        public string shop_tipoftheday;
        public string shop_weapons;
        public string shop_monsters;
        public string shop_cybergrind;
        public string shop_returnToMission;
        public string shop_sandbox;

        public string shop_cybergrindDescription;
        public string shop_cybergrindEnter;

        public string shop_sandboxDescription;
        public string shop_sandboxEnter;

        public string shop_back;

    }
    public class Levels
    {
        public string levelName_mainMenu;
        public string levelName_cybergrind;
        public string levelName_sandbox;

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

        public string leveltips_primeFirst1;
        public string leveltips_primeFirst2;

        public string leveltips_cybergrind;
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

        public string enemyname_v2;
        public string enemyname_mindFlayer;
        public string enemyname_malFace;
        public string enemyname_cerberus;
        public string enemyname_hideousMass;
        public string enemyname_gabriel;
        public string enemyname_virtue;
        public string enemyname_somethingWicked;
        public string enemyname_fleshPrison;
        public string enemyname_minosPrime;
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
        public string general_cameraTilt;
        public string general_discordRpc;
        public string general_seasonalEvent;

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
        public string graphics_textureWarping;
        public string graphics_vertexWarping;
        public string graphics_vertexWarpingNone;
        public string graphics_vertexWarpingLight;
        public string graphics_vertexWarpingMedium;
        public string graphics_vertexWarpingStrong;
        public string graphics_vertexWarpingVeryStrong;
        public string graphics_vertexWarpingAbsurd;
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

        public string hud_title;
        public string hud_type;
        public string hud_typeNone;
        public string hud_typeStandard;
        public string hud_typeClassicColor;
        public string hud_typeClassicWhite;
        public string hud_hudElements;
        public string hud_backgroundOpacity;
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
        public string assists_enemySilhouettes;
        public string assists_enemySilhouettesOutlines;
        public string assists_enemySilhouettesDistance;
        public string assists_enemySilhouettesOutlinesOnly;
        public string assists_major;
        public string assists_majorActivate;
        public string assists_gameSpeed;
        public string assists_damageTaken;
        public string assists_bossOverride;
        public string assists_bossRestartRequired;
        public string assists_bossOverrideNone;
        public string assists_infiniteEnergy;
        public string assists_disableHardDamage;
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


    }

    public class Tutorial
    {
        public string tutorial_introStartup1;
        public string tutorial_introStartup2;
        public string tutorial_introVersion1;
        public string tutorial_introVersion2;
        public string tutorial_introCalibration1;
        public string tutorial_introCalibration2;
        public string tutorial_introReminder;
        public string tutorial_introLoadStatus;
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
        public string prelude_first_revolverPierce1;
        public string prelude_first_revolverPierce2;
        public string prelude_first_parry;
        public string prelude_first_groundSlam1;
        public string prelude_first_groundSlam2;

        public string prelude_second_shop;
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
    }

    public class a1
    {
        public string act1_limboFirst_items1;
        public string act1_limboFirst_items2;
        public string act1_limboFirst_nailgun1;
        public string act1_limboFirst_nailgun2;
        public string act1_limboFirst_nailgun3;

        public string act1_limboThird_splitDoor1;
        public string act1_limboThird_splitDoor2;

        public string act1_limboFourth_book;
        public string act1_limboFourth_hank1;
        public string act1_limboFourth_hank2;
        public string act1_limboFourth_alternateRevolver;
        public string act1_limboFourth_newArm;

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

        public string act2_greedThird_troll1;
        public string act2_greedThird_troll2;

        public string act2_greedFourth_v2;
        public string act2_greedFourth_whiplash1;
        public string act2_greedFourth_whiplash2;
        public string act2_greedFourth_whiplash3;

        public string act2_greedSecret_holdToJump;

        public string act2_greed_secretDoor;

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

    }

    public class Secret
    {
        public string secretLevels_prelude_somethingWicked;
        public string secretLevels_prelude_testament1;
        public string secretLevels_prelude_testament2;
        public string secretLevels_prelude_testament3;
        public string secretLevels_prelude_testament4;

        public string secretLevels_first_testament1;
        public string secretLevels_first_testament2;
        public string secretLevels_first_testament3;
        public string secretLevels_first_testament4;

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

    public class Misc
    {
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
    }
}
