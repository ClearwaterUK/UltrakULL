using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace UltrakULL
{
    class SubtitleStrings
    {
        BepInEx.Logging.ManualLogSource subtitleStringsLogger = BepInEx.Logging.Logger.CreateLogSource("Subtitle Strings");

        //3-2 Gabriel fight
        public string gabesubtitles(string input)
        {
            //Pre-arena lines
            if (input.Contains("Machine"))
            {
                return ("Machine,");
            }
            if (input.Contains("Turn back now"))
            {
                return ("faites demi-tour maintenant.");
            }
            if (input.Contains("The layers"))
            {
                return ("Ton type n'est pas permis à rentrer dans les couches de ce palais.");
            }
            if (input.Contains("will of God"))
            {
                return ("Faites demi-tour, sinon tu franchiras la volonté de Dieu!");
            }
            if (input.Contains("Your choice"))
            {
                return ("Ton choix est fait...");
            }
            if (input.Contains("As the"))
            {
                return ("Étant la main droite du Père,");
            }
            if (input.Contains("I shall"))
            {
                return ("je vais te déchirer en morceaux!");
            }
            if (input.Contains("And you will"))
            {
                return ("Tu deviendras inanimé une fois de plus...");
            }

            //Fight lines
            if (input.Contains("BEHOLD"))
            {
                return ("VOICI! LA PUISSANCE D'UN ANGE!");
            }
            if (input.Contains("The light"))
            {
                return ("La lumière est la perfection!");
            }
            if (input.Contains("You defy"))
            {
                return ("Tu défies la lumière!");
            }
            if (input.Contains("A mere"))
            {
                return ("Tu n'est qu'un objet!");
            }
            if (input.Contains("Not."))
            {
                return ("Même, pas, mortel.");
            }
            if (input.Contains("You are less"))
            {
                return ("Tu n'est moins de rien!");
            }
            if (input.Contains("Foolishness"))
            {
                return ("Des bêtises, machine. Que des bêtises.");
            }
            if (input.Contains("You're an error"))
            {
                return ("Tu es une erreur à être corrigé!");
            }
            if (input.Contains("There can be"))
            {
                return ("Il ne peut n'y avoir qu'un seul!");
            }
            if (input.Contains("An imperfection"))
            {
                return ("Une imperfection à être nettoyé.");
            }
            if (input.Contains("Your crime"))
            {
                return ("Ton crime est l'existence!");
            }
            if (input.Contains("You make"))
            {
                return ("Tu feras pleurer même le diable!");
            }
            if (input.Contains("You are outclassed"))
            {
                return ("Tu est surclassé!");
            }

            if (input.Contains("Enough!"))
            {
                return ("ASSEZ!");
            }

            // Defeat/Outro

            if (input.Contains("What..?"))
            {
                return ("Mais...?");
            }
            if (input.Contains("How can"))
            {
                return ("Comment cela peut-il être...?");
            }
            if (input.Contains("Bested"))
            {
                return ("Battu par ce...");
            }
            if (input.Contains("this thing"))
            {
                return ("...cette chose...?");
            }
            if (input.Contains("You insignificant"))
            {
                return ("SALE. PETITE MERDE. INSIGNIFIANTE!");
            }
            if (input.Contains("THIS IS NOT OVER"))
            {
                return ("NOUS NE SOMMES PAS TERMINÉ!");
            }
            if (input.Contains("May your woes"))
            {
                return ("Que tes malheurs soient beaucoup,");
            }
            if (input.Contains("and your days"))
            {
                return ("et tes jours nombrés!");
            }

            return ("Unimplemented Gabe fight string");
        }

        public string druidsubtitles(string input)
        {
            string mandaColor = "<color=#FFC49E>";
            string owlColor = "<color=#9EE6FF>";
            string endColor = "</color>";

            //Intro
            if (input.Contains("Finally"))
            {
                return (mandaColor + "Enfin, notre casse-tête de patience est terminé!" + endColor);
            }
            if (input.Contains("What"))
            {
                return (owlColor + "Hein?" + endColor);
            }

            //Respawn intro
            if (input.Contains("I'm going to"))
            {
                return (owlColor + "Je vais t'empoisoner, sale merde!" + endColor);
            }
            if (input.Contains("I'm gonna"))
            {
                return (owlColor + "Je vais les tirer dessus avec une arme!" + endColor);
            }
            if (input.Contains("You cannot imagine"))
            {
                return (mandaColor + "Tu ne peux pas imaginer ce que tu va rencontrer ici!" + endColor);
            }
            if (input.Contains("Hold still"))
            {
                return (mandaColor + "Arrêtes de bouger!" + endColor);
            }
            if (input.Contains("Why are we"))
            {
                return (owlColor + "Pourquoi sommes-nous dans le passé?" + endColor);
            }

            //Attacks
            if (input.Contains("Full auto"))
            {
                return (mandaColor + "Automatique." + endColor);
            }
            if (input.Contains("Fuller auto"))
            {
                return (mandaColor + "Encore plus automatique!" + endColor);
            }


            //Phase transitions
            //Speed increase
            if (input.Contains("Through the"))
            {
                return (mandaColor + "J'augmentes ma vitesse grâce au magique des Druides!" + endColor);
            }
            if (input.Contains("Just fucking"))
            {
                return (owlColor + "Mais bordel, frappes-le déjà!" + endColor);
            }
            //Max speed
            if (input.Contains("Feel"))
            {
                return (mandaColor + "Témoignes ma vitesse maximum!" + endColor);
            }
            if (input.Contains("Slow down"))
            {
                return (owlColor + "C'est trop vite!" + endColor);
            }

            //Sanded
            if (input.Contains("Use the salt"))
            {
                return (owlColor + "Utilises du sel!" + endColor);
            }
            if (input.Contains("I'm reaching"))
            {
                return (mandaColor + "J'essaies!" + endColor);
            }


            //Outro
            if (input.Contains("Oh great"))
            {
                return (owlColor + "Bah chouette, on a perdu, excellent." + endColor);
            }

            
            return "Unimplemented Druid fight string";
        }

        public string minossubtitles(string input)
        {
            //Intro
            if (input.Contains("Ahh..."))
            {
                return (input);
            }
            if (input.Contains("Free at"))
            {
                return ("Enfin libéré.");
            }
            if (input.Contains("O Gabriel"))
            {
                return ("Oh, Gabriel...");
            }
            if (input.Contains("Now dawns"))
            {
                return ("Maintenant se lève votre compte,");
            }
            if (input.Contains("and thy gore"))
            {
                return ("Et votre sang luira devant les temples des hommes!");
            }
            if (input.Contains("Creature of"))
            {
                return ("Bête d'acier...");
            }
            if (input.Contains("My gratitude"))
            {
                return ("Je vous remercie pour ma déliverance.");
            }
            if (input.Contains("but the crimes"))
            {
                return ("Mais les crimes que votre type à commis sur l'humanité");
            }
            if (input.Contains("are NOT"))
            {
                return ("ne sont PAS oubliés.");
            }
            if (input.Contains("And thy punishment"))
            {
                return ("Ainsi, votre sanction est...");
            }
            if (input.Contains("is DEATH"))
            {
                return ("LA MORT!");
            }
            //Respawn intro
            if (input.Contains("Useless"))
            {
                return ("Vous êtes inutile!");
            }

            //Attacks
            if (input.Contains("Prepare"))
            {
                return ("Preparez-vous!");
            }
            if (input.Contains("Thy end"))
            {
                return ("Votre fin approche!");
            }
            if (input.Contains("Die"))
            {
                return ("MOUREZ!");
            }
            if (input.Contains("Crush"))
            {
                return ("Ècrasement!");
            }
            if (input.Contains("Judgement"))
            {
                return ("Jugement!");
            }

            //Phase 2
            if (input.Contains("WEAK"))
            {
                return ("Vous êtes FAIBLE!");
            }

            //Outro
            if (input.Contains("Aagh!"))
            {
                return (input);
            }
            if (input.Contains("Forgive"))
            {
                return ("Mes enfants... Je vous prie de me pardonner...");
            }
            if (input.Contains("for I have"))
            {
                return ("J'ai échoué de vous délivrer le salut...");
            }
            if (input.Contains("from this"))
            {
                return ("de cette monde sombre et froide.");
            }


            return "Unimplemented Minos Prime string";

        }

        public string gabeBoatSubtitles(string input)
        {
            //Intro
            if (input.Contains("Be not afraid"))
            {
                return ("N'ayez pas peur, pêcheur.");
            }
            if (input.Contains("Your devotion"))
            {
                return ("Votre dévotion au Dieu montre le bonté dans vous-même;");
            }
            if (input.Contains("Plentiful"))
            {
                return ("Bien abondant.");
            }
            if (input.Contains("The heart"))
            {
                return ("Le cœur est prêt, mais le corps doit se reposer,");
            }
            if (input.Contains("Lest"))
            {
                return ("Sinon vous gaspillierez un des créations de Dieu.");
            }
            return "Unimplemented 5-3 subtitle";
        }

        public string gabeSecondSubtitles(string input)
        {
            if (input.Contains("Machine"))
            {
                return "Machine, je sais tu est ici.";
            }
            if (input.Contains("I can smell"))
            {
                return "Je peux ressentir l'odeur insolent de tes mains sanglants.";
            }
            if (input.Contains("I await"))
            {
                return "Je t'attends en bas...";
            }
            if (input.Contains("Come"))
            {
                return "Viens à moi!";
            }

            Console.WriteLine(input);
            return "Unimplemented 6-1 subtitle";
        }

        public string gabeSecondBossSubtitles(string input)
        {
            //Level intro
            if (input.Contains("Limbo"))
            {
                return "Les Limbes.";
            }
            if (input.Contains("Lust"))
            {
                return "Luxure.";
            }
            if (input.Contains("All gone"))
            {
                return "Tout parti...";
            }
            if (input.Contains("With Gluttony"))
            {
                return "Avec la Gourmandise à bientôt suivre.";
            }
            if (input.Contains("Your kind"))
            {
                return "Ton type ne connaît que la faim,";
            }
            if (input.Contains("Purged"))
            {
                return "Effacé toute vie sur les couches supérieurs,";
            }
            if (input.Contains("And yet"))
            {
                return "Mais ils restent insatiables...";
            }
            if (input.Contains("As do"))
            {
                return "Comme toi-même.";
            }
            if (input.Contains("You've taken"))
            {
                return "Tu m'as tout pris, machine.";
            }
            if (input.Contains("And now"))
            {
                return "Maintenant, tout ce qui reste, est";
            }
            if (input.Contains("PERFECT"))
            {
                return "LA HAINE...";
            }
            if (input.Contains("HATRED"))
            {
                return "...PARFAITE!";
            }

            //Boss info
            Console.WriteLine(input);
            if (input.Contains("Machine"))
            {
                return "Machine,";
            }
            if (input.Contains("I will cut"))
            {
                return "Je vais t'abattre en morceaux,";
            }
            if (input.Contains("Break you apart"))
            {
                return "Te casser en pièces,";
            }
            if (input.Contains("Splay"))
            {
                return "Verser le sang de ton forme profane à travers LES ÉTOILES!";
            }
            if (input.Contains("MERCY"))
            {
                return "Je vais te broyer jusqu'au même les ÉTINCELLES CRIENT LA PITIÉ!";
            }
            if (input.Contains("My hands"))
            {
                return "Mes mains vont SAVORER TE DÉLIVRER LA MORT...";
            }
            if (input.Contains("HERE"))
            {
                return "ICI,";
            }
            if (input.Contains("AND"))
            {
                return "ET,";
            }
            if (input.Contains("NOW"))
            {
                return "MAINTENANT!";
            }

            //Taunts
            if (input.Contains("IS THAT"))
            {
                return "C'EST TOUT QUE TU SAIS FAIRE!?";
            }
            if (input.Contains("YOU NEED"))
            {
                return "IL TE FAUT. PLUS. DE PUISSANCE!";
            }
            if (input.Contains("Come get"))
            {
                return "VIENS CHERCHER MON SANG!";
            }
            if (input.Contains("What is this"))
            {
                return "Mais qu'est-ce que... cet SENSATION?";
            }
            if (input.Contains("NOTHING"))
            {
                return "TU N'EST QUE DU FERAILLE!";
            }
            if (input.Contains("You're getting"))
            {
                return "Tu rouilles un peu, machine!";
            }
            if (input.Contains("IS THIS WHAT"))
            {
                return "J'AI VRAIMENT PERDU CONTRE TOI?!";
            }
            if (input.Contains("TIME TO"))
            {
                return "IL EST TEMPS DE CORRIGER MON ERREUR!";
            }
            if (input.Contains("LET'S SETTLE"))
            {
                return "FINISSONS-EN!";
            }
            if (input.Contains("I'LL SHOW"))
            {
                return "JE TE MONTRERAI LA JUSTICE DIVINE!";
            }
            if (input.Contains("Come on"))
            {
                return "Aller, machine! Bats-moi comme un animal!";
            }
            if (input.Contains("I've never"))
            {
                return "Je n'ai jamais eu un tel bataille comme ceci!";
            }
            if (input.Contains("Show me"))
            {
                return "Montre moi à quoi tu serts!";
            }
            if (input.Contains("Now THIS"))
            {
                return "Ceci EST un bataille digne du volonté de Dieu!";
            }

            //Defeated
            if (input.Contains("Twice!?"))
            {
                return "Deux fois?!";
            }
            if (input.Contains("Beaten by"))
            {
                return "Battu par un Objet... DEUX FOIS?!";
            }
            if (input.Contains("I've only"))
            {
                return "Je ne connais que le goût de la victoire,";
            }
            if (input.Contains("But this"))
            {
                return "Mais ce goût... Est-ce que...";
            }
            if (input.Contains("Is this"))
            {
                return "Est-ce que c'est mon sang?";
            }
            if (input.Contains("I've never known such..."))
            {
                return "Je n'ai jamais connu un tel...";
            }
            if (input.Contains("Such"))
            {
                return "Un tel... soulagement?";
            }
            if (input.Contains("I-"))
            {
                return "Je... J'ai besoin du temps pour réfléchir...";
            }
            if (input.Contains("We will"))
            {
                return "Nous allons se rencontrer encore, machine.";
            }
            if (input.Contains("May"))
            {
                return "Que tes malheurs soit beaucoup...";
            }
            if (input.Contains("and your"))
            {
                return "...et tes jours nombrés.";
            }

            return "Unimplemented 6-2 subtitle";
        }


        public string getSubtitle(string input)
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            //3-2
            if (currentLevel.Contains("3-2"))
            {
               return gabesubtitles(input);
            }
            //4-3 secret boss
            if (currentLevel.Contains("4-3"))
                {
                return druidsubtitles(input);
            }

            //5-3
            if (currentLevel.Contains("5-3"))
            {
                return gabeBoatSubtitles(input);
            }
            //6-1
            if (currentLevel.Contains("6-1"))
            {
                return gabeSecondSubtitles(input);
            }
            //6-2
            if (currentLevel.Contains("6-2"))
            {
                return gabeSecondBossSubtitles(input);
            }

            //Prime sanctum, P-1 boss
            if (currentLevel.Contains("P-1"))
            {
                return minossubtitles(input);
            }
            return "Uninplemented subtitle string";
        }


        public SubtitleStrings()
        {

        }


    }
}
