using UnityEngine.SceneManagement;
using UltrakULL.json;

namespace UltrakULL
{
    public static class SubtitleStrings
    {

        private static string mandaColor = "<color=#FFC49E>";
        private static string owlColor = "<color=#9EE6FF>";
        private static string endColor = "</color>";

        //3-2 Gabriel fight
        private static string Gabesubtitles(string input)
        {
            //Pre-arena lines
            if (input.Contains("Machine"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_intro1);
            }
            if (input.Contains("Turn back now"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_intro2);
            }
            if (input.Contains("The layers"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_intro3);
            }
            if (input.Contains("will of God"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_intro4);
            }
            if (input.Contains("Your choice"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_intro5);
            }
            if (input.Contains("As the"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_intro6);
            }
            if (input.Contains("I shall"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_intro7);
            }
            if (input.Contains("And you will"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_intro8);
            }

            if (input.Contains("BEHOLD"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_fightStart);
            }

            

            // Defeat/Outro
            if (input.Contains("What..?"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_defeated1);
            }
            if (input.Contains("How can"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_defeated2);
            }
            if (input.Contains("Bested"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_defeated3);
            }
            if (input.Contains("this thing"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_defeated4);
            }
            if (input.Contains("You insignificant"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_defeated5);
            }
            if (input.Contains("THIS IS NOT OVER"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_defeated6);
            }
            if (input.Contains("May your woes"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_defeated7);
            }
            if (input.Contains("and your days"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_defeated8);
            }

            return ("Unimplemented Gabe fight string");
        }

        private static string Druidsubtitles(string input)
        {
            //Intro
            if (input.Contains("Finally"))
            {
                return (mandaColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_intro1 + endColor);
            }
            if (input.Contains("What"))
            {
                return (owlColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_intro2 + endColor);
            }
            
            return "Unimplemented Druid fight string";
        }

        private static string Minossubtitles(string input)
        {
            //Intro
            if (input.Contains("Ahh..."))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_intro1);
            }
            if (input.Contains("Free at"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_intro2);
            }
            if (input.Contains("O Gabriel"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_intro3);
            }
            if (input.Contains("Now dawns"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_intro4);
            }
            if (input.Contains("and thy gore"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_intro5);
            }
            if (input.Contains("Creature of"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_intro6);
            }
            if (input.Contains("My gratitude"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_intro7);
            }
            if (input.Contains("but the crimes"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_intro8);
            }
            if (input.Contains("are NOT"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_intro9);
            }
            if (input.Contains("And thy punishment"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_intro10);
            }
            if (input.Contains("is DEATH"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_intro11);
            }
            //Outro
            if (input.Contains("Aagh!"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_defeated1);
            }
            if (input.Contains("Forgive"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_defeated2);
            }
            if (input.Contains("for I have"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_defeated3);
            }
            if (input.Contains("from this"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_defeated4);
            }
            return "Unimplemented Minos Prime string";
        }

        private static string SisyphusSubtitles(string input)
        {
            //Pre-Intro
            if (input.Contains("This prison"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_preIntro1);
            }
            if (input.Contains("To hold"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_preIntro2);
            }
            if (input.Contains("ME?"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_preIntro3);
            }
            
            //Intro
            if (input.Contains("A visitor?"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_intro1);
            }
            if (input.Contains("Hmm..."))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_intro2);
            }
            if (input.Contains("The kingdom"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_intro3);
            }
            if (input.Contains("And I am EAGER"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_intro4);
            }
            if (input.Contains("However"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_intro5);
            }
            if (input.Contains("The blood of Minos"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_intro6);
            }
            if (input.Contains("I'm curious"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_intro7);
            }
            if (input.Contains("And so,"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_intro8);
            }
            if (input.Contains("You shall do"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_intro9);
            }
            if (input.Contains("Come forth"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_intro10);
            }
            if (input.Contains("And DIE"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_intro11);
            }
            
            //Outro
            if (input.Contains("Ahh..."))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_defeated1);
            }
            if (input.Contains("So concludes the"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_defeated2);
            }
            if (input.Contains("A fitting end"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_defeated3);
            }
            if (input.Contains("Doomed from the"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_defeated4);
            }
            if (input.Contains("And I don't"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_defeated5);
            }
            
            return "Unimplemented P-2 subtitle";
        }
        
        private static string GabeBoatSubtitles(string input)
        {
            //Intro
            if (input.Contains("Be not afraid"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielBoat1);
            }
            if (input.Contains("Your devotion"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielBoat2);
            }
            if (input.Contains("Plentiful"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielBoat3);
            }
            if (input.Contains("The heart"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielBoat4);
            }
            if (input.Contains("Lest"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielBoat5);
            }
            return "Unimplemented 5-3 subtitle";
        }

        private static string GabeSecondSubtitles(string input)
        {

            if (input.Contains("Machine"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielHeresy1;
            }
            if (input.Contains("I can smell"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielHeresy2;
            }
            if (input.Contains("I await"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielHeresy3;
            }
            if (input.Contains("COME"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielHeresy4;
            }

            return "Unimplemented 6-1 subtitle";
        }

        private static string GabeSecondBossSubtitles(string input)
        {
            //Level intro
            if (input.Contains("Limbo"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondIntro1;
            }
            if (input.Contains("Lust"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondIntro2;
            }
            if (input.Contains("All gone"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondIntro3;
            }
            if (input.Contains("With Gluttony"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondIntro4;
            }
            if (input.Contains("Your kind"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondIntro5;
            }
            if (input.Contains("Purged"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondIntro6;
            }
            if (input.Contains("And yet"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondIntro7;
            }
            if (input.Contains("As do"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondIntro8;
            }
            if (input.Contains("You've taken"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondIntro9;
            }
            if (input.Contains("And now"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondIntro10;
            }
            if (input.Contains("PERFECT"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondIntro11;
            }
            if (input.Contains("HATRED"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondIntro12;
            }

            //Boss intro
            if (input.Contains("Machine"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondFight1;
            }
            if (input.Contains("I will cut"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondFight2;
            }
            if (input.Contains("Break you apart"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondFight3;
            }
            if (input.Contains("Splay"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondFight4;
            }
            if (input.Contains("MERCY"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondFight5;
            }
            if (input.Contains("My hands"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondFight6;
            }
            if (input.Contains("HERE"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondFight7;
            }
            if (input.Contains("AND"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondFight8;
            }
            if (input.Contains("NOW"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondFight9;
            }

            //Defeated
            if (input.Contains("Twice!?"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondDefeated1;
            }
            if (input.Contains("Beaten by"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondDefeated2;
            }
            if (input.Contains("I've only"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondDefeated3;
            }
            if (input.Contains("But this"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondDefeated4;
            }
            if (input.Contains("Is this"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondDefeated5;
            }
            if (input.Contains("I've never known such..."))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondDefeated6;
            }
            if (input.Contains("Such"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondDefeated7;
            }
            if (input.Contains("I-"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondDefeated8;
            }
            if (input.Contains("We will"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondDefeated9;
            }
            if (input.Contains("May"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondDefeated10;
            }
            if (input.Contains("and your"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondDefeated11;
            }

            return "Unimplemented 6-2 subtitle";
        }

        private static string GetFightLine(string input)
        {

            //-- Gabriel 1st
            if (input.Contains("The light"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_taunt1);
            }
            if (input.Contains("You defy"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_taunt2);
            }
            if (input.Contains("A mere"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_taunt3);
            }
            if (input.Contains("Not."))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_taunt4);
            }
            if (input.Contains("You are less"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_taunt5);
            }
            if (input.Contains("Foolishness"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_taunt6);
            }
            if (input.Contains("You're an error"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_taunt7);
            }
            if (input.Contains("There can be"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_taunt8);
            }
            if (input.Contains("An imperfection"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_taunt9);
            }
            if (input.Contains("Your crime"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_taunt10);
            }
            if (input.Contains("You make"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_taunt11);
            }
            if (input.Contains("You are outclassed"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_taunt12);
            }

            if (input.Contains("Enough!"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_gabriel_phaseChange);
            }

            // -- MDK
            //Respawn intro
            if (input.Contains("I'm going to"))
            {
                return (owlColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_taunt1 + endColor);
            }
            if (input.Contains("I'm gonna"))
            {
                return (owlColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_taunt2 + endColor);
            }
            if (input.Contains(mandaColor + "What"))
            {
                return (mandaColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_intro2 + endColor);
            }


            if (input.Contains("You cannot imagine"))
            {
                return (mandaColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_taunt3 + endColor);
            }
            if (input.Contains("Hold still"))
            {
                return (mandaColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_taunt4 + endColor);
            }
            if (input.Contains("Why are we"))
            {
                return (owlColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_taunt5 + endColor);
            }

            //Attacks
            if (input.Contains("Full auto"))
            {
                return (mandaColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_attack1 + endColor);
            }
            if (input.Contains("Fuller auto"))
            {
                return (mandaColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_attack2 + endColor);
            }

            //Phase transitions
            //Speed increase
            if (input.Contains("Through the"))
            {
                return (mandaColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_phaseChangeFirst1 + endColor);
            }
            if (input.Contains("Just fucking"))
            {
                return (owlColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_phaseChangeFirst2 + endColor);
            }
            //Max speed
            if (input.Contains("Feel"))
            {
                return (mandaColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_phaseChangeSecond1 + endColor);
            }
            if (input.Contains("Slow down"))
            {
                return (owlColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_phaseChangeSecond2 + endColor);
            }

            //Sanded
            if (input.Contains("Use the salt"))
            {
                return (owlColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_phaseChangeThird1 + endColor);
            }
            if (input.Contains("I'm reaching"))
            {
                return (mandaColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_phaseChangeThird2 + endColor);
            }

            //Outro
            if (input.Contains("Oh great"))
            {
                return (owlColor + LanguageManager.CurrentLanguage.subtitles.subtitles_mandalore_defeated + endColor);
            }

            //--Gabriel 2nd

            //Phase 2
            if (input.Contains("IS THAT"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondPhaseChange;
            }

            //Taunts
            if (input.Contains("YOU NEED"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt1;
            }
            if (input.Contains("Come get"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt2;
            }
            if (input.Contains("What is this"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt3;
            }
            if (input.Contains("NOTHING"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt4;
            }
            if (input.Contains("YOU'RE GETTING"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt5;
            }
            if (input.Contains("IS THIS WHAT"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt6;
            }
            if (input.Contains("TIME TO"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt7;
            }
            if (input.Contains("LET'S SETTLE"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt8;
            }
            if (input.Contains("I'LL SHOW"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt9;
            }
            if (input.Contains("Come on"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt10;
            }
            if (input.Contains("I've never had"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt11;
            }
            if (input.Contains("Show me"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt12;
            }
            if (input.Contains("Now THIS"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt13;
            }
            if (input.Contains("splendor"))
            {
                return LanguageManager.CurrentLanguage.subtitles.subtitles_gabrielSecondTaunt14;
            }

            //--Minos Prime

            //Respawn intro
            if (input.Contains("Useless"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_taunt1);
            }
            //Attacks
            if (input.Contains("Prepare"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_attack1);
            }
            if (input.Contains("Thy end"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_attack2);
            }
            if (input.Contains("Die"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_attack3);
            }
            if (input.Contains("Crush"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_attack4);
            }
            if (input.Contains("Judgement"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_attack5);
            }
            //Phase 2
            if (input.Contains("WEAK"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_phaseChange);
            }

            // --Sisyphus Prime
            //Attacks
            if (input.Contains("Keep them coming!"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_respawnIntro);
            }
            //Attacks
            if (input.Contains("Nice try!"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_attack1);
            }
            if (input.Contains("BE GONE!"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_attack2);
            }
            if (input.Contains("You can't escape!"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_attack3);
            }
            if (input.Contains("DESTROY!"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_attack4);
            }
            if (input.Contains("This will hurt"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_attack5);
            }
            //Phase 2
            if (input.Contains("YES! That's it"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_sisyphusPrime_phaseChange);
            }
            
            //Respawn
            if (input.Contains("Keep them"))
            {
                return (LanguageManager.CurrentLanguage.subtitles.subtitles_minosPrime_phaseChange);
            }
            

            
            return null;
        }

        public static string GetSubtitle(string input)
        {
            if(GetFightLine(input) != null)
            {
                return GetFightLine(input);
            }
            string currentLevel = SceneManager.GetActiveScene().name;
            //3-2
            if (currentLevel.Contains("3-2"))
            {
               return Gabesubtitles(input);
            }
            //4-3 secret boss
            if (currentLevel.Contains("4-3"))
            {
                return Druidsubtitles(input);
            }
            //5-3
            if (currentLevel.Contains("5-3"))
            {
                return GabeBoatSubtitles(input);
            }
            //6-1
            if (currentLevel.Contains("6-1"))
            {
                return GabeSecondSubtitles(input);
            }
            //6-2
            if (currentLevel.Contains("6-2"))
            {
                return GabeSecondBossSubtitles(input);
            }

            //Prime sanctum, P-1 boss
            if (currentLevel.Contains("P-1"))
            {
                return Minossubtitles(input);
            }

            if (currentLevel.Contains("P-2"))
            {
                return SisyphusSubtitles(input);
            }
            return "Uninplemented subtitle string";
        }
    }
}
