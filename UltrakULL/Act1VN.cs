using BepInEx;
using HarmonyLib;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UltrakULL;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UltrakULL
{
    static class Act1VN
    {
        //Import symbols to use
        //▼ - Denotes pause
        //
        //Intro strings

        public static string intro1 =
        "Des pas lourds, du respiration déchiré.▼\n"
        + "Il ne restait pas beaucoup de temps.▼\n"
        + "Il était peut-être déjà trop tard.▼\n\n"

        + "Les passages labyrinthiques des virages serrés semblent devenir de plus en plus étrange, la panique effaçant toutes les mémoires profondement incrustés qui me guidait normallemennt.▼\n\n"

        + "Chaque virage me semble étrange.▼\n"
        + "Chaque ligne droite trop longue.▼\n\n"

        + "La cloche sonne pour moi.▼";

        public static string intro2 =
            "J'ai avalé le dernier des mes rations, l'y tenant entre mes dents.▼\n"
            + "Il a à peine tenu pendant que je regardais frénétiquement autour de moi, en espérant que les derniers bouts de ma mémoire arrivent à trouver une vue familiere qui me mènera au salut.▼\n\n"

            + "Les portes doivent se fermer en cet instant.▼\n"
            + "Les derniers entre nous à peines sorties.▼\n\n"

            + "Le reste de nous n'avaient aucune chance.▼\n\n"

            + "Tout d'un soudain, depuis un angle mort, une figure m'a frappé.▼\n"
            + "Il n'y avait pas le temps de réagir avant que j'ai tombé au sol froid et dur.▼\n\n"

            + "J'ai lutté pour regagner mes sens, pour pouvoir voir quel destin m'attenderas dans mes derniers moments, mais même dans cet abîme de terreur sans fin, mon esprit n'a jamais pû imaginer l'horreur que j'ai temoigné.▼\n\n";

        //Fallen strings
        public static string fallen1 = "Oof aïe ouille ça pique▼";

        public static string fallen2_1 = "Je suis juste quelqu'un qui s'est fait renversé par un connard à demi-cerveau qui n'a même pas la politesse de me demander si ça va ou de s'excuser avant de commencer une interrogation.▼";

        public static string fallen2_2 = "Eh bien, je me suis fait renversé par un trou de cul aveugle-par-choix qui a salé ma jupe, donc en tout, putain c'est fantastique, mais je préférais de ne pas être par terre en ce moment.▼";

        public static string fallen2_3 = "Ah super, je me suis fait renversé par une fontaine vibrante, quelle chance.▼\n"
            + "Tu peux du moins m'aider à me remonter avant que le reste de vous se fondent en cause du soleil, ou se martellent dans la Terre.▼";

        public static string fallen3 = "Bon, bon.▼";

        //Start (Kind) strings
        public static string kind1 = "*soupir*▼\n"
            + "Hé, desolé d'avoir été impolie comme ça, je suis vraiment frustré que non seulment je suis en retard pour l'école, j'ai aussi arrivé à me perdre en chemin.▼";

        public static string kind2 = "Mais, d'après ce qu'on voit, toi aussi t'es dans le même bateau, et par un coup de chance qu'on trouve une seule fois dans la vie, t'a arrivé à croiser avec ~la fille la plus belle du ville~.▼";

        public static string kind3 = "Alors, si tu nous guides pour nous sortir de cette situation?▼";

        //Start (Rude) strings
        public static string rude1 = "Écoutes, tête de bite.▼\n"
            + "Je ne sais pas qui t'est mais t'as du culot de mettre quelq'un par terre et de même pas les aider à les remonter, mais puisque ta mère n'a pas appris les bonnes manières, je vais l'excuser cet fois.▼";

        public static string rude2 = kind2;

        public static string rude3 = "Donc je te pardonnes pour ton transgression extrême d'avoir mis tes mains sur cette jeune fille, si tu me dis dans quelle direction y aller, puisque je sembles m'avoir perdu en chemin.▼";

        //Middle strings
        public static string middle1_1 = "Ugh! Quelle chance.▼";
        public static string middle1_2 = "Mais en rétrospective, tu ne seras pas ici avec moi si tu n'étais pas perdu aussi...▼";
        public static string middle1_3 =
            "Tant pis, ça vaut pas la peine de se pleurer sur du sang renversé.▼\n"
            + "Nous pourrions aussi bien attendre pour qu'un autre étudiant arrive pour pouvoir les suivre.▼";
        public static string middle1_4 =
            "Je m'appelles Mirage.▼\n"
            + "Ne te donnes pas ton nom, je m'en fiches un peu.▼";

        public static string middle2_1 = "QUOI ?▼\n"
            + "MAIS BORDEL, ÇA VEUT DIRE QUOI 'PAS ENVIE'?▼";

        public static string middle2_2 = "Si tu NE montres PAS le chemin, TOI non plus tu vas jamais arriver!▼\n"
            + "Ou est-ce que cet pensée n'a jamais croisé ton cavité de cerveau bouffant des crayons!?▼";

        public static string middle3_1 = "Conneries!▼\n"
            + "Arrête de dire de la merde, je peux voir ton uniforme croûteux et aucune personne vivante osera sortir ressemblant un sac de poubelle plein par le choix!▼";

        public static string middle3_2 = "Mais en considérant la manque d'activité qu'il se trouve dans ton crâne, je suis prêt à admettre que tu sembles jamais avoir été à l'école.▼";





        //Recklessness strings
        public static string recklessness1 = "Ah ouais? Toi par contre tu pourras bien profiter d'un battement, donc va t'faire foutre.▼";
        public static string recklessness2 = "Mais oui, t'as raison.▼\n"
            +  "Je m'en fiches un peu de ce que toi ou les autres pensent de moi, donc je ne suis pas interessé en essayant d'être gentille pour que tu sois en bonne humeur.▼";

        public static string recklessness3_1 = "À quoi ça sert de l'améliorer?▼\n"
        + "À quoi ça sert de faire semblant de se soucier?▼\n"
        + "Bref, quel est l'interêt de tout cela?▼\n"
        + "Rien.▼\n"
        + "Absolument rien.▼\n";

        public static string recklessness3_2 = "Ne te flattes pas.▼\n"
            + "Le défoulement est la façon que je m'y fais face.▼";

        public static string recklessness3_3 = "Tout.▼";


        //Waiting strings

        public static string waiting1 = "On va se perdre encore plus si on se promène comme des poulets sans tête.▼";
        public static string waiting2 = "Puisqu'on se dirigeait vers l'école et on s'est rencontré ici, ça veux dire qu'il y a une forte chance que cet endroit se trouve en chemin.▼";
        public static string waiting3 = "Alors, on sera mieux si on reste ici et on attends quelqu'un qui CONNAÎT le chemin.▼\n"
            + "C'est logique, ça sera bien si tu le cherches à un moment donné.▼";

        public static string waiting4_1 = "Faits-toi le plaisir.▼"
            + "Je resterais ici jusqu'au mort thermique de l'univers si cela veut dire que je ne suis pas obligé de courir partout pour chercher un caillou permettant de retrouver mes mèmoires au sol.▼\n";

        public static string waiting4_2 = "Je m'en fiches totalement d'être en retard pour l'école.▼\n"
            + "L'école n'a pas d'importance.▼\n"
            + "Rien n'a d'importance.▼";

        public static string waiting5_1 = "Ha!▼\n"
            + "Je peux pas abandonner si je n'ai jamais essayé au début, et de ne pas prendre l'habitude d'essayer.▼";

        public static string waiting6 = "Parce que rien n'a d'importance.▼\n"
            + "Il n'y a aucune raison d'essayer si le résultat de fin restes la même.▼\n"
            + "Essaies comme tu veux, tu deviendras que du poussière oublié dans le vent, tout comme le reste.▼";


        //Nihilism strings

        public static string nihilism1 = "Ce que je demandes, c'est de prendre un moment d'y réfléchir.▼";

        public static string nihilism2 = "L'esprit humain, dans son immensité totale, est capable de reconnaître son impuissance et son inutilité totale dans la face de la non-existence incontournable, mais il est incapable de pouvoir l'accepter.▼";

        public static string nihilism3 = "On ne peux soit l'ignorer, soit d'y cacher ou soit l'échapper temporairement, mais à la fin, nous sommes tous liés au chemin de toutes choses.▼";

        public static string nihilism4 = "La mort est inévitable, pas que pour nous, mais pour tout ce qui existe, ou qui a existé.▼\n"
            + "Chaque être vivante finira par mourir.▼\n"
            + "Chaque grain de poussière se flétrira événetuellement et se dissipera dans l'entropie.▼";

        public static string nihilism5 = "Peu importe si t'a vecu une bonne vie ou si t'a construit un héritage.▼\n"
            + "Peu importe si l'humanité survit pour un millier d'années ou s'éteignent demain.▼\n"
            + "Le rèsultat de fin reste la même: Une vide absolu.▼\n";

        public static string nihilism6 = "L'intelligence humaine est bien au-delà de celle des animaux, mais ça sera une erreur d'appeler ceci un don.▼\n"
            + "Tous les autres être vivantes ont le don de l'ignorance, de ne pas pouvoir comprendre ce qu'on fait.▼";

        public static string nihilism7 = "Notre intelligence n'est pas un don.▼ C'est un défaut.▼";

        public static string nihilism8 = "C'est une surextension de l'évolution.▼\n"
        + "L'intelligence, autrefois un grand élément dans les temps passés, a continué d'agrandir sans contrainte ou surveillance, et a depassé un seuil où il ne se classifie plus comme avantage, mais un danger actif à son hôte.▼";

        public static string nihilism9 = "Comme les mégalocéros, un espèce de cerf qui, à travers les générations d'évolution non-dénombrables, a poussé des bois aussi larges et vastes qu'ils ne pouvaient plus fuir les prédateurs, qui donne suite à son extinction.▼";

        public static string nihilism10 = "L'esprit humain est une inadaptation évolutionaire causé par y allant trop loin dans une direction qui a été autrefois bénéfice et qui, à un moment donné, nous mènera à notre extinction. Sur un niveau individuel, ça se produit en ce moment.▼";

        public static string nihilism11 = "La peur existentielle s'installe.▼\n"
            + "Je suis sûr que tu l'as senti aussi.▼\n"
            + "La douleur et la peur d'être rien, de devenir rien.▼\n"
            + "La souffrance en cause de cette compréhension.▼\n";

        public static string nihilism12 = "Nous sommes incapables de l'accepter, nous nous cachons alors de notre propre intelligence.▼\n"
            + "Nous fixons des limites.▼\n"
            + "Nous nous arrêtons de trop penser de ce qui se passera quand nous mourons.▼\n";

        public static string nihilism13 = "Nous créeons des distractions.▼\n"
            + "Nous occupons nos esprits avec des activités et des divertissements quotidiens pour nous empêcher de s'affronter à la verité.▼\n";

        public static string nihilism14 = "Nous le sublimons.▼\n"
            + "Nous transformons notre souffrance auto-reflective vers une autre forme, un autre art, pour l'empêcher de nous consommer.▼\n"
            + "Quoi que ça soit pour éviter la panique.▼\n";

        public static string nihilism15 = "Mais ces façons ne sont que temporaires.▼\n"
            + "Ils existent que pour repousser le voile inévitable d'impuissance et désespoir qui nous engloberait et nous ruinait.▼\n";

        public static string nihilism16 = "À la fin, rien n'a d'importance.▼\n"
        + "Il n'y a aucune raison de trouver la joie dans nos vies, puisque la vie en elle-même est la souffrance.▼\n";

        public static string nihilismPrompt1 = "Vous avez tort.";

        public static string nihilism17 = "Hein?▼\n";

        public static string nihilismPrompt2 = "Vous critiquez ceux qui considérent notre intelligence vaste comme un don, cependant, vous vous égarez à croire que notre inutilité est un sort.";

        public static string nihilism18 = "Comment ne peut-il pas l'être?▼\n";

        public static string nihilismPrompt3 = "Rien que nous faisons ont d'importance, et ceci est précisement pourquoi nous ne sommes pas enchaînées par le poids des attentes, la peur du jugement éternel ou l'échec de satisfaire une définition arbitraire de ce qui rend notre temps limité 'non gaspillé'.";


        public static string nihilismPrompt4 = "Notre temps ne peut pas être gaspillé, puisqu'il n'y a aucun objectif dans la vie, que de le vivre.";

        public static string nihilism19 = "Mais de même, dans ce cas, l'insignificance de nos actions portent jusqu'au même conclusion -- Il n'y a aucun raison pour agir, puisque tout action n'est simplement un fluctuation temporaire qui, néanmoins, mènera jusqu'au même conclusion.▼\n";

        public static string nihilismPrompt5 = "Au contraire.";

        public static string nihilismPrompt6 = "Puisque nous n'avons aucun objectif plus important, nous sommes libres d'établir les notres. Pour créer des buts autodéfinis auquel s'efforcer.";

        public static string nihilismPrompt7 = "Pour certains, ce n'est rien. Pour d'autres, c'est le plaisir. Pour d'autres encore, c'est la création, ou même l'amélioration des vies des autres.";

        public static string nihilismPrompt8 = "C'est puisque nous n'avons aucun objectif plus important, que le temps passé sur nos buts autodéfinis n'est pas gaspillé.";

        public static string nihilismPrompt9 = "À la fin, rien ne porte d'importance, et à la suite vous n'avez aucune raison de ne pas faire ce que tu veux au lieu de l'illusion des objectifs plus importants qui vous êtes forcés dessus par vous-même, les autres, ou même vos pensés mal guidés.";

        public static string nihilism20 =
            "Je comprends bien ce que tu veux dire.▼\n"
            + "Cependant, ça ne réduit pas ma peur du fin.▼\n"
            + "Même si je tentais à retrouver un objectif, je serais toujours paralysé par le pensée de ne rien devenir.▼\n";

        public static string nihilismPrompt10 =
            "Et c'est une pensée digne d'être craint.\n"
            + "Par contre, l'abandon des objectifs, l'espoir, la choix, les buts, le plaisir et la volonté ne peut pas faire disparaître cette pensée.\n"
            + "La peur peut se calmer, par contre.\n";

        public static string nihilismPrompt11 =
       "Abandonner n'est pas l'acceptation de la fin, c'est l'acceptation du peur de ceci. C'est l'embrassement du désespoir, et non la confrontation.";

        public static string nihilism21 =
            "Je vois.▼\n"
            + "Bien que je veux l'accepter, je suis néanmoins frappé avec cette panique existentielle.▼\n";

        public static string nihilism22 =
            "Je le comprends logiquement, et je sais qu'il n'y a aucune raison de vivre avec du apathie, mais mon côté emotionel refuse de m'écouter."
            + "La peur persiste, et je ne peux pas me motiver pour rechercher un objectif, malgré la connaissance que je dois le faire.▼\n";

        public static string nihilismPrompt12 =
            "Ceci est vrai. L'émotionnel n'est pas contrôlé par la logique. Cependant, ils sont interconnectés.";

        public static string nihilismPrompt13 =
            "Tout comme les profondeurs du désespoir peut renverser la logique et raisonnement, le déformant pour que ça rentre dans la brume de la dépression, la raison peut autant influencer et maîtriser l'émotion, peu importe ses défences.";

        public static string nihilismPrompt14 =
            "En forçant le subvertissement des pensées négatives avec les pensées positives et logiques, l'esprit va éventuellement, lentement, commencer à changer pour s'adapter au logique.";

        public static string nihilismPrompt15 =
            "Ce n'est pas un devoir facile.";

        public static string nihilismPrompt16 =
            "Ce n'est pas un devoir rapide.";

        public static string nihilismPrompt17 =
           "C'est un devoir qui se sentira à certains moments impossible à réaliser.";

        public static string nihilismPrompt18 =
            "Cependant, il peut être réalisé.";

        public static string nihilismPrompt19 =
            "Avec beaucoup de temps, d'effort et d'énergie, ça va s'améliorer.";

        public static string nihilismPrompt20 =
             "Vous pouvez changer.";

        public static string nihilismPrompt21 =
             "Vous pouvez vous soigner.";

        public static string nihilismPrompt22 =
             "Et même lors des temps difficiles, quand tout semble être perdu et que vous avez envie d'abandonner, n'oubliez jamais...";

        public static string nihilismPrompt23 =
             "On vous aimera toujours.";

        //Conclusion strings

        public static string conclusion1 =
            "Quel surprise.▼\n";

        public static string conclusion2 =
            "On dirait que t'as bien une bonne tête sur tes épaules. Bon sang, je suis impressioné.▼\n";

        public static string conclusion3 =
            "Ouf...▼\n"
            + "Je me sens comme j'ai perdu tout le poids du monde entier.▼\n"
            + "Ou plutôt, tu me l'avais fait pour moi.▼\n"
            + "Honnêtement, du fond de mon cœur...▼\n";

        public static string conclusion4 = "Merci.▼\n";

        public static string conclusion5 =
            "Tu m'as beaucoup donné auquel je dois rèflechir, et même si je sais que j'ai une chemin longue et difficile devant moi, je suis optimistique.▼\n"
            + "Pour la première fois dans ce qu'il me semble être une éternité, je suis optimistique.▼\n";

        public static string conclusion6 =
            "Hé... On est déjà trop en retard pour l'école et il est devenu assez claire que personne va nous chercher, donc ça te dit de nous débarasser ce prison qui  bouffe notre énergie et aller chercher quelque chose à manger, hein?▼\n";

        public static string conclusionPrompt1_1 =
            "Ouais, pourquoi pas. J'ai rien de mieux à faire aujourd'hui. Par contre, c'est vous qui payez.";

        public static string conclusionPrompt1_2 =
            "Non, desolé. Pour être honnête je suis toujours un peu agacé à quel point vous étiez impolie vers moi.";

        public static string conclusion7_1 =
            "Ah, espece de bâtard malin! Mais bon, d'accord.▼\n"
            + "Je t'en doit comme-même, donc c'est un bon moment d'encaisser ton ticket 'à fait une bonne chose pour une dame hors de mon niveau', hein?▼\n";

        public static string conclusion7_2 =
            "Bon, comme tu veux.▼\n"
            + "L'offre reste ouvert par contre, dans le cas où tu changes d'avis.▼\n";

        public static string conclusion8 =
            "A plus, p'tit amoureux.▼\n";


        public static void patchPrompts(ref GameObject currentLevel)
        {
            List<GameObject> rootObjects = new List<GameObject>();
            SceneManager.GetActiveScene().GetRootGameObjects(rootObjects);
            GameObject canvasObject = null;
            foreach (GameObject a in rootObjects)
            {
                if (a.gameObject.name == "Canvas")
                {
                    canvasObject = a.gameObject;
                    break;
                }
            }
            GameObject choicesBaseObject = getGameObjectChild(getGameObjectChild(getGameObjectChild(canvasObject, "PowerUpVignette"),"Panel"),"Aspect Ratio Mask");

            GameObject fallenChoices = getGameObjectChild(choicesBaseObject, "Fallen");

            //Annoyingly both choice box objects in the Fallen sections are named the same. So we'll do this to pick up both of them.
            List<GameObject> fallenChoiceObjects = new List<GameObject>();
            foreach (Transform a in fallenChoices.transform)
            {
                if (a.gameObject.name == "Choices Box")
                {
                    fallenChoiceObjects.Add(a.gameObject);
                    Console.WriteLine(a.gameObject.name);
                }
            }

            GameObject fallenChoice1Object = fallenChoiceObjects[0];
            GameObject fallenChoice2Object = fallenChoiceObjects[1];

            //Fallen
            Text fallenChoice1ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(fallenChoice1Object, "Button (A)"),"Text"));
            fallenChoice1ChoiceAText.text = "Qui êtes-vous?";

            Text fallenChoice1ChoiceBText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(fallenChoice1Object, "Button (B)"), "Text"));
            fallenChoice1ChoiceBText.text = "Vous allez bien?";

            Text fallenChoice1ChoiceCText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(fallenChoice1Object, "Button (C)"), "Text"));
            fallenChoice1ChoiceCText.text = "*Remuer nerveusement et suer abondamment*";

            Text fallenChoice2ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(fallenChoice2Object, "Button (A)"), "Text"));
            fallenChoice2ChoiceAText.text = "*Aidez-la à se relever*";

            Text fallenChoice2ChoiceBText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(fallenChoice2Object, "Button (B)"), "Text"));
            fallenChoice2ChoiceBText.text = "Pas avec une telle attitude.";

            Text fallenChoice2ChoiceCText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(fallenChoice2Object, "Button (C)"), "Text"));
            fallenChoice2ChoiceCText.text = "Desolé, c'était ma faute.";

            //Middle choice 1
            GameObject middleChoices1Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Middle"), "Choices Box (1)");

            Text middleChoice1ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(middleChoices1Object, "Button (A)"), "Text"));
            middleChoice1ChoiceAText.text = "En fait, je suis perdu aussi.";

            Text middleChoice1ChoiceBText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(middleChoices1Object, "Button (B)"), "Text"));
            middleChoice1ChoiceBText.text = "Pas envie.";

            Text middleChoice1ChoiceCText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(middleChoices1Object, "Button (C)"), "Text"));
            middleChoice1ChoiceCText.text = "Je ne vais pas à l'école.";


            //Middle choice 2
            GameObject middleChoices2Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Middle"), "Choices Box (2)");

            Text middleChoice2ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(middleChoices2Object, "Button (A)"), "Text"));
            middleChoice2ChoiceAText.text = "Vous pouvez être plus polie avec les gens que vous avez venus de rencontrer..";

            Text middleChoice2ChoiceBText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(middleChoices2Object, "Button (B)"), "Text"));
            middleChoice2ChoiceBText.text = "On va nul par en attendant ici, on devrait chercher une route à l'école.";

            Text middleChoice2ChoiceCText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(middleChoices2Object, "Button (C)"), "Text"));
            middleChoice2ChoiceCText.text = "...Pourquoi sommes-nous ici?";


            //Recklessness choice 1
            GameObject recklessnessChoices1Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Recklessness"), "Choices Box");

            Text recklessnessChoice1ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(recklessnessChoices1Object, "Button (A)"), "Text"));
            recklessnessChoice1ChoiceAText.text = "Pourquoi pas? Si on est coincé ensemble ici, à quoi sert-il de rendre les choses encore pire pour nous?";

            Text recklessnessChoice2ChoiceBText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(recklessnessChoices1Object, "Button (B)"), "Text"));
            recklessnessChoice2ChoiceBText.text = "J'ai du mal à le croire vu la façon que vous vous fâchez à cause de tout ce que je dis.";

            //Recklessness choice 2
            GameObject recklessnessChoices2Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Recklessness"), "Choices Box (1)");
            Text recklessnessChoice2ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(recklessnessChoices2Object, "Button (A)"), "Text"));
            recklessnessChoice2ChoiceAText.text = "Faire face à quoi?";

            //Waiting choice 1
            GameObject waitingChoices1Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Waiting"), "Choices Box");

            Text waitingChoice1ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(waitingChoices1Object, "Button (A)"), "Text"));
            waitingChoice1ChoiceAText.text = "Logique ou non, on est déjà en retard et je n'ai pas envie d'attendre ici jusqu'au lendemain.";

            Text waitingChoice2ChoiceBText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(waitingChoices1Object, "Button (B)"), "Text"));
            waitingChoice2ChoiceBText.text = "Toute personne qui sait le chemin y seront déjà rendues. Il me semble que vous cherchez une excuse pour abandonner.";

            //Waiting choice 2
            GameObject waitingChoices2Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Waiting"), "Choices Box (1)");
            Text waitingChoice2ChoiceAText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(waitingChoices2Object, "Button (A)"), "Text"));
            waitingChoice2ChoiceAText.text = "Pourquoi?";

            //Nihilism choice
            GameObject nihilismChoices1Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (2)");
            Text nihilismChoices1Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices1Object, "Button (A)"), "Text"));
            nihilismChoices1Text.text = nihilismPrompt1;

            GameObject nihilismChoices2Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (3)");
            Text nihilismChoices2Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices2Object, "Button (A)"), "Text"));
            nihilismChoices2Text.text = nihilismPrompt2;

            GameObject nihilismChoices3Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (4)");
            Text nihilismChoices3Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices3Object, "Button (A)"), "Text"));
            nihilismChoices3Text.text = nihilismPrompt3;

            GameObject nihilismChoices4Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (5)");
            Text nihilismChoices4Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices4Object, "Button (A)"), "Text"));
            nihilismChoices4Text.text = nihilismPrompt4;

            GameObject nihilismChoices5Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (6)");
            Text nihilismChoices5Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices5Object, "Button (A)"), "Text"));
            nihilismChoices5Text.text = nihilismPrompt5;

            GameObject nihilismChoices6Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (7)");
            Text nihilismChoices6Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices6Object, "Button (A)"), "Text"));
            nihilismChoices6Text.text = nihilismPrompt6;

            GameObject nihilismChoices7Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (8)");
            Text nihilismChoices7Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices7Object, "Button (A)"), "Text"));
            nihilismChoices7Text.text = nihilismPrompt7;

            GameObject nihilismChoices8Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (9)");
            Text nihilismChoices8Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices8Object, "Button (A)"), "Text"));
            nihilismChoices8Text.text = nihilismPrompt8;

            GameObject nihilismChoices9Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (10)");
            Text nihilismChoices9Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices9Object, "Button (A)"), "Text"));
            nihilismChoices9Text.text = nihilismPrompt9;

            GameObject nihilismChoices10Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (11)");
            Text nihilismChoices10Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices10Object, "Button (A)"), "Text"));
            nihilismChoices10Text.text = nihilismPrompt10;

            GameObject nihilismChoices11Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (12)");
            Text nihilismChoices11Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices11Object, "Button (A)"), "Text"));
            nihilismChoices11Text.text = nihilismPrompt11;

            GameObject nihilismChoices12Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (13)");
            Text nihilismChoices12Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices12Object, "Button (A)"), "Text"));
            nihilismChoices12Text.text = nihilismPrompt12;

            GameObject nihilismChoices13Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (14)");
            Text nihilismChoices13Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices13Object, "Button (A)"), "Text"));
            nihilismChoices13Text.text = nihilismPrompt13;

            GameObject nihilismChoices14Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (16)");
            Text nihilismChoices14Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices14Object, "Button (A)"), "Text"));
            nihilismChoices14Text.text = nihilismPrompt14;

            GameObject nihilismChoices15Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (17)");
            Text nihilismChoices15Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices15Object, "Button (A)"), "Text"));
            nihilismChoices15Text.text = nihilismPrompt15;

            GameObject nihilismChoices16Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (18)");
            Text nihilismChoices16Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices16Object, "Button (A)"), "Text"));
            nihilismChoices16Text.text = nihilismPrompt16;

            GameObject nihilismChoices17Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (19)");
            Text nihilismChoices17Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices17Object, "Button (A)"), "Text"));
            nihilismChoices17Text.text = nihilismPrompt17;

            GameObject nihilismChoices18Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (20)");
            Text nihilismChoices18Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices18Object, "Button (A)"), "Text"));
            nihilismChoices18Text.text = nihilismPrompt18;


            GameObject nihilismChoices19Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (21)");
            Text nihilismChoices19Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices19Object, "Button (A)"), "Text"));
            nihilismChoices19Text.text = nihilismPrompt19;

            GameObject nihilismChoices20Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (22)");
            Text nihilismChoices20Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices20Object, "Button (A)"), "Text"));
            nihilismChoices20Text.text = nihilismPrompt20;

            GameObject nihilismChoices21Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (25)");
            Text nihilismChoices21Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices21Object, "Button (A)"), "Text"));
            nihilismChoices21Text.text = nihilismPrompt21;

            GameObject nihilismChoices22Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (23)");
            Text nihilismChoices22Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices22Object, "Button (A)"), "Text"));
            nihilismChoices22Text.text = nihilismPrompt22;

            GameObject nihilismChoices23Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Nihilism"), "Choices Box (24)");
            Text nihilismChoices23Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(nihilismChoices23Object, "Button (A)"), "Text"));
            nihilismChoices23Text.text = nihilismPrompt23;


            //Conclusion choice
            GameObject conclusionChoices1Object = getGameObjectChild(getGameObjectChild(choicesBaseObject, "Conclusion"), "Choices Box (2)");
            Text conclusionChoices1Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(conclusionChoices1Object, "Button (A)"), "Text"));
            Text conclusionChoices2Text = getTextfromGameObject(getGameObjectChild(getGameObjectChild(conclusionChoices1Object, "Button (B)"), "Text"));
            conclusionChoices1Text.text = conclusionPrompt1_1;
            conclusionChoices2Text.text = conclusionPrompt1_2;


        }


        public static string getNextString(string inputString)
        {
            //Intro
            if(inputString.Contains("Heavy steps")) { return intro1;}
            if(inputString.Contains("I bit down")) { return intro2; }
            //Fallen
            if (inputString.Contains("Oof ow")) { return fallen1; }
            //Fallen branch
            if (inputString.Contains("I'm just someone")) { return fallen2_1; }
            if (inputString.Contains("Well I just got")) { return fallen2_2; }
            if (inputString.Contains("Oh great")) { return fallen2_3; }

            if (inputString.Contains("Alright, alright")) { return fallen3; }
            //Kind
            if (inputString.Contains("*Sigh*")) { return kind1; }
            if (inputString.Contains("Though, by the")) { return kind2; }
            if (inputString.Contains("So how about you")) { return kind3; }

            //Rude
            if (inputString.Contains("Listen up,")) { return rude1; }
            if (inputString.Contains("By the looks of it")) { return rude2; }
            if (inputString.Contains("So I'll forgive you")) { return rude3;}

            //Middle
            if (inputString.Contains("UGH!")) { return middle1_1; }
            if (inputString.Contains("Though in retrospect")) { return middle1_2; }
            if (inputString.Contains("Oh well,")) { return middle1_3; }
            if (inputString.Contains("I'm Mirage.")) { return middle1_4; }

            if (inputString.Contains("WHAT?")) { return middle2_1; }
            if (inputString.Contains("If you DON'T")) { return middle2_2; }

            if (inputString.Contains("Bullshit!")) { return middle3_1; }
            if (inputString.Contains("Though considering")) { return middle3_2; }

            //Waiting
            if (inputString.Contains("Wandering around like")) { return waiting1; }
            if (inputString.Contains("Since we were")) { return waiting2; }
            if (inputString.Contains("Therefore,")) { return waiting3; }

            if (inputString.Contains("Suit yourself")) { return waiting4_1; }
            if (inputString.Contains("Couldn't care less")) { return waiting4_2; }

            if (inputString.Contains("Hah!")) { return waiting5_1; }
            if (inputString.Contains("Because nothing")) { return waiting6; }


            //Recklessness
            if (inputString.Contains("Yeah?")) { return recklessness1; }
            if (inputString.Contains("But yes,")) { return recklessness2; }

            if (inputString.Contains("Why not?")) { return recklessness3_1; }
            if (inputString.Contains("Don't flatter yourself")) { return recklessness3_2; }

            if (inputString.Contains("Everything.")) { return recklessness3_3; }

            //Nihilism
            if (inputString.Contains("I mean really")) { return nihilism1; }
            if (inputString.Contains("The human mind")) { return nihilism2; }
            if (inputString.Contains("We can only ever")) { return nihilism3; }
            if (inputString.Contains("Death is")) { return nihilism4; }
            if (inputString.Contains("It doesn't matter")) { return nihilism5; }
            if (inputString.Contains("Human intelligence")) { return nihilism6; }
            if (inputString.Contains("Our intelligence")) { return nihilism7; }
            if (inputString.Contains("It's an over-extension")) { return nihilism8; }
            if (inputString.Contains("Much like the Irish")) { return nihilism9; }
            if (inputString.Contains("The human mind is an")) { return nihilism10; }
            if (inputString.Contains("Existential dread")) { return nihilism11; }
            if (inputString.Contains("We are unable")) { return nihilism12; }
            if (inputString.Contains("We create distractions")) { return nihilism13; }
            if (inputString.Contains("We sublimate it")) { return nihilism14; }
            if (inputString.Contains("But these ways")) { return nihilism15; }
            if (inputString.Contains("In the end")) { return nihilism16; }

            if (inputString.Contains("Huh?")) { return nihilism17; }
            if (inputString.Contains("How could it not be?")) { return nihilism18; }
            if (inputString.Contains("But still")) { return nihilism19; }
            if (inputString.Contains("I do understand")) { return nihilism20; }
            if (inputString.Contains("I see.")) { return nihilism21; }
            if (inputString.Contains("I understand it logically")) { return nihilism22; }

            //Conclusion
            if (inputString.Contains("Well I'll be damned")) { return conclusion1; }
            if (inputString.Contains("Guess you got a good")) { return conclusion2; }
            if (inputString.Contains("Thank you.")) { return conclusion3; }
            if (inputString.Contains("Man...")) { return conclusion4; }
            if (inputString.Contains("You've given me a lot")) { return conclusion5; }
            if (inputString.Contains("Say...")) { return conclusion6; }
            if (inputString.Contains("Oh, you sneaky")) { return conclusion7_1; }
            if (inputString.Contains("Alright, suit yourself")) { return conclusion7_2; }
            if (inputString.Contains("See you around")) { return conclusion8; }



            Console.WriteLine(inputString);
            return (inputString);
        }


        public static GameObject getGameObjectChild(GameObject parentObject, string childToFind)
        {
            GameObject childToReturn = parentObject.transform.Find(childToFind).gameObject;
            return childToReturn;
        }

        public static Text getTextfromGameObject(GameObject objectToUse)
        {
            return objectToUse.GetComponent<Text>();
        }
    }
}
