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



            public string getSubtitle(string input)
            {
            string currentLevel = SceneManager.GetActiveScene().name;
            //Act 1, 3-2
            if (currentLevel.Contains("3-2"))
            {
               
               return gabesubtitles(input);
            }
            //Act 2, 4-3 secret boss
            if (currentLevel.Contains("4-3"))
            {
                return druidsubtitles(input);
            }
            //Prime sanctum, P-1 boss
            if (currentLevel.Contains("P-1"))
            {
                return minossubtitles(input);
            }
            return "Uninplemented boss subtitle string";
        }


        public SubtitleStrings()
        {

        }


    }
}
