using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;
using UltrakULL.json;

namespace UltrakULL
{
    public static class SubtitleStrings
    {
        private static BepInEx.Logging.ManualLogSource subtitleStringsLogger = BepInEx.Logging.Logger.CreateLogSource("Subtitle Strings");

        //3-2 Gabriel fight
        public static string gabesubtitles(string input, JsonParser language)
        {
            //Pre-arena lines
            if (input.Contains("Machine"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_intro1);
            }
            if (input.Contains("Turn back now"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_intro2);
            }
            if (input.Contains("The layers"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_intro3);
            }
            if (input.Contains("will of God"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_intro4);
            }
            if (input.Contains("Your choice"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_intro5);
            }
            if (input.Contains("As the"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_intro6);
            }
            if (input.Contains("I shall"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_intro7);
            }
            if (input.Contains("And you will"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_intro8);
            }

            //Fight lines
            if (input.Contains("BEHOLD"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_fightStart);
            }
            if (input.Contains("The light"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_taunt1);
            }
            if (input.Contains("You defy"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_taunt2);
            }
            if (input.Contains("A mere"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_taunt3);
            }
            if (input.Contains("Not."))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_taunt4);
            }
            if (input.Contains("You are less"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_taunt5);
            }
            if (input.Contains("Foolishness"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_taunt6);
            }
            if (input.Contains("You're an error"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_taunt7);
            }
            if (input.Contains("There can be"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_taunt8);
            }
            if (input.Contains("An imperfection"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_taunt9);
            }
            if (input.Contains("Your crime"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_taunt10);
            }
            if (input.Contains("You make"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_taunt11);
            }
            if (input.Contains("You are outclassed"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_taunt12);
            }

            if (input.Contains("Enough!"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_phaseChange);
            }

            // Defeat/Outro
            if (input.Contains("What..?"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_defeated1);
            }
            if (input.Contains("How can"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_defeated2);
            }
            if (input.Contains("Bested"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_defeated3);
            }
            if (input.Contains("this thing"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_defeated4);
            }
            if (input.Contains("You insignificant"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_defeated5);
            }
            if (input.Contains("THIS IS NOT OVER"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_defeated6);
            }
            if (input.Contains("May your woes"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_defeated7);
            }
            if (input.Contains("and your days"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabriel_defeated8);
            }

            return ("Unimplemented Gabe fight string");
        }

        public static string druidsubtitles(string input,JsonParser language)
        {
            string mandaColor = "<color=#FFC49E>";
            string owlColor = "<color=#9EE6FF>";
            string endColor = "</color>";

            //Intro
            if (input.Contains("Finally"))
            {
                return (mandaColor + language.currentLanguage.subtitles.subtitles_mandalore_intro1 + endColor);
            }
            if (input.Contains("What"))
            {
                return (owlColor + language.currentLanguage.subtitles.subtitles_mandalore_intro2 + endColor);
            }

            //Respawn intro
            if (input.Contains("I'm going to"))
            {
                return (owlColor + language.currentLanguage.subtitles.subtitles_mandalore_taunt1 + endColor);
            }
            if (input.Contains("I'm gonna"))
            {
                return (owlColor + language.currentLanguage.subtitles.subtitles_mandalore_taunt2 + endColor);
            }
            if (input.Contains("You cannot imagine"))
            {
                return (mandaColor + language.currentLanguage.subtitles.subtitles_mandalore_taunt3 + endColor);
            }
            if (input.Contains("Hold still"))
            {
                return (mandaColor + language.currentLanguage.subtitles.subtitles_mandalore_taunt4 + endColor);
            }
            if (input.Contains("Why are we"))
            {
                return (owlColor + language.currentLanguage.subtitles.subtitles_mandalore_taunt5 + endColor);
            }

            //Attacks
            if (input.Contains("Full auto"))
            {
                return (mandaColor + language.currentLanguage.subtitles.subtitles_mandalore_attack1 + endColor);
            }
            if (input.Contains("Fuller auto"))
            {
                return (mandaColor + language.currentLanguage.subtitles.subtitles_mandalore_attack2 + endColor);
            }

            //Phase transitions
            //Speed increase
            if (input.Contains("Through the"))
            {
                return (mandaColor + language.currentLanguage.subtitles.subtitles_mandalore_phaseChangeFirst1 + endColor);
            }
            if (input.Contains("Just fucking"))
            {
                return (owlColor + language.currentLanguage.subtitles.subtitles_mandalore_phaseChangeFirst2 + endColor);
            }
            //Max speed
            if (input.Contains("Feel"))
            {
                return (mandaColor + language.currentLanguage.subtitles.subtitles_mandalore_phaseChangeSecond1 + endColor);
            }
            if (input.Contains("Slow down"))
            {
                return (owlColor + language.currentLanguage.subtitles.subtitles_mandalore_phaseChangeSecond2 + endColor);
            }

            //Sanded
            if (input.Contains("Use the salt"))
            {
                return (owlColor + language.currentLanguage.subtitles.subtitles_mandalore_phaseChangeThird1 + endColor);
            }
            if (input.Contains("I'm reaching"))
            {
                return (mandaColor + language.currentLanguage.subtitles.subtitles_mandalore_phaseChangeThird2 + endColor);
            }

            //Outro
            if (input.Contains("Oh great"))
            {
                return (owlColor + language.currentLanguage.subtitles.subtitles_mandalore_defeated + endColor);
            }
            
            return "Unimplemented Druid fight string";
        }

        public static string minossubtitles(string input, JsonParser language)
        {
            //Intro
            if (input.Contains("Ahh..."))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_intro1);
            }
            if (input.Contains("Free at"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_intro2);
            }
            if (input.Contains("O Gabriel"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_intro3);
            }
            if (input.Contains("Now dawns"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_intro4);
            }
            if (input.Contains("and thy gore"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_intro5);
            }
            if (input.Contains("Creature of"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_intro6);
            }
            if (input.Contains("My gratitude"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_intro7);
            }
            if (input.Contains("but the crimes"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_intro8);
            }
            if (input.Contains("are NOT"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_intro9);
            }
            if (input.Contains("And thy punishment"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_intro10);
            }
            if (input.Contains("is DEATH"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_intro11);
            }
            //Respawn intro
            if (input.Contains("Useless"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_taunt1);
            }
            //Attacks
            if (input.Contains("Prepare"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_attack1);
            }
            if (input.Contains("Thy end"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_attack2);
            }
            if (input.Contains("Die"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_attack3);
            }
            if (input.Contains("Crush"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_attack4);
            }
            if (input.Contains("Judgement"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_attack5);
            }
            //Phase 2
            if (input.Contains("WEAK"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_phaseChange);
            }
            //Outro
            if (input.Contains("Aagh!"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_defeated1);
            }
            if (input.Contains("Forgive"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_defeated2);
            }
            if (input.Contains("for I have"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_defeated3);
            }
            if (input.Contains("from this"))
            {
                return (language.currentLanguage.subtitles.subtitles_minosPrime_defeated4);
            }
            return "Unimplemented Minos Prime string";
        }
        
        public static string gabeBoatSubtitles(string input,JsonParser language)
        {
            //Intro
            if (input.Contains("Be not afraid"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabrielBoat1);
            }
            if (input.Contains("Your devotion"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabrielBoat2);
            }
            if (input.Contains("Plentiful"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabrielBoat3);
            }
            if (input.Contains("The heart"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabrielBoat4);
            }
            if (input.Contains("Lest"))
            {
                return (language.currentLanguage.subtitles.subtitles_gabrielBoat5);
            }
            return "Unimplemented 5-3 subtitle";
        }

        public static string gabeSecondSubtitles(string input,JsonParser language)
        {

            if (input.Contains("Machine"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielHeresy1;
            }
            if (input.Contains("I can smell"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielHeresy2;
            }
            if (input.Contains("I await"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielHeresy3;
            }
            if (input.Contains("COME"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielHeresy4;
            }

            return "Unimplemented 6-1 subtitle";
        }

        public static string gabeSecondBossSubtitles(string input,JsonParser language)
        {
            //Level intro
            if (input.Contains("Limbo"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondIntro1;
            }
            if (input.Contains("Lust"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondIntro2;
            }
            if (input.Contains("All gone"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondIntro3;
            }
            if (input.Contains("With Gluttony"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondIntro4;
            }
            if (input.Contains("Your kind"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondIntro5;
            }
            if (input.Contains("Purged"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondIntro6;
            }
            if (input.Contains("And yet"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondIntro7;
            }
            if (input.Contains("As do"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondIntro8;
            }
            if (input.Contains("You've taken"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondIntro9;
            }
            if (input.Contains("And now"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondIntro10;
            }
            if (input.Contains("PERFECT"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondIntro11;
            }
            if (input.Contains("HATRED"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondIntro12;
            }

            //Boss intro
            if (input.Contains("Machine"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondFight1;
            }
            if (input.Contains("I will cut"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondFight2;
            }
            if (input.Contains("Break you apart"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondFight3;
            }
            if (input.Contains("Splay"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondFight4;
            }
            if (input.Contains("MERCY"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondFight5;
            }
            if (input.Contains("My hands"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondFight6;
            }
            if (input.Contains("HERE"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondFight7;
            }
            if (input.Contains("AND"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondFight8;
            }
            if (input.Contains("NOW"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondFight9;
            }

            //Phase 2
            if (input.Contains("IS THAT"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondPhaseChange;
            }

            //Taunts
            if (input.Contains("YOU NEED"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt1;
            }
            if (input.Contains("Come get"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt2;
            }
            if (input.Contains("What is this"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt3;
            }
            if (input.Contains("NOTHING"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt4;
            }
            if (input.Contains("YOU'RE GETTING"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt5;
            }
            if (input.Contains("IS THIS WHAT"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt6;
            }
            if (input.Contains("TIME TO"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt7;
            }
            if (input.Contains("LET'S SETTLE"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt8;
            }
            if (input.Contains("I'LL SHOW"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt9;
            }
            if (input.Contains("Come on"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt10;
            }
            if (input.Contains("I've never had"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt11;
            }
            if (input.Contains("Show me"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt12;
            }
            if (input.Contains("Now THIS"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt13;
            }
            if (input.Contains("splendor"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondTaunt14;
            }

            //Defeated
            if (input.Contains("Twice!?"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondDefeated1;
            }
            if (input.Contains("Beaten by"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondDefeated2;
            }
            if (input.Contains("I've only"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondDefeated3;
            }
            if (input.Contains("But this"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondDefeated4;
            }
            if (input.Contains("Is this"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondDefeated5;
            }
            if (input.Contains("I've never known such..."))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondDefeated6;
            }
            if (input.Contains("Such"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondDefeated7;
            }
            if (input.Contains("I-"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondDefeated8;
            }
            if (input.Contains("We will"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondDefeated9;
            }
            if (input.Contains("May"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondDefeated10;
            }
            if (input.Contains("and your"))
            {
                return language.currentLanguage.subtitles.subtitles_gabrielSecondDefeated11;
            }

            return "Unimplemented 6-2 subtitle";
        }

        public static string getSubtitle(string input,JsonParser language)
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            //3-2
            if (currentLevel.Contains("3-2"))
            {
               return gabesubtitles(input,language);
            }
            //4-3 secret boss
            if (currentLevel.Contains("4-3"))
                {
                return druidsubtitles(input, language);
            }
            //5-3
            if (currentLevel.Contains("5-3"))
            {
                return gabeBoatSubtitles(input, language);
            }
            //6-1
            if (currentLevel.Contains("6-1"))
            {
                return gabeSecondSubtitles(input, language);
            }
            //6-2
            if (currentLevel.Contains("6-2"))
            {
                return gabeSecondBossSubtitles(input, language);
            }

            //Prime sanctum, P-1 boss
            if (currentLevel.Contains("P-1"))
            {
                return minossubtitles(input, language);
            }
            return "Uninplemented subtitle string";
        }
    }
}
