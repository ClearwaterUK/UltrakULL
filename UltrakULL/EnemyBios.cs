using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltrakULL
{
    class EnemyBios
    {
        public string getName(string originalName)
        {
            switch (originalName)
            {
                case "FILTH": { return "SALETÉ"; }
                case "STRAY": { return "ERRANT"; }
                case "SCHISM": { return "SCHISME"; }
                case "SOLDIER": { return "SOLDAT"; }
                case "THE CORPSE OF KING MINOS": { return "LE CADAVRE DU ROI MINOS"; }
                case "STALKER": { return "TRAQUEUR"; }
                case "INSURRECTIONIST": { return "INSURRECTIONISTE SISYPHEANE"; }
                case "FERRYMAN": { return "NOCHER"; }
                case "SWORDSMACHINE": { return "MACHINE À ÉPÉE"; }
                case "DRONE": { return "DRONE"; }
                case "STREETCLEANER": { return "NETTOYEUR"; }
                case "V2 (2nd)": { return "V2 (2nde)"; }
                case "V2": { return "V2"; }
                case "SENTRY": { return "MITRAILLEUSE"; }
                case "MINDFLAYER": { return "ILLITHID"; }
                case "MALICIOUS FACE": { return "TÊTE MALICIEUX"; }
                case "IDOL": { return "IDOLE"; }
                case "LEVIATHAN": { return "LÉVIATHAN"; }
                case "CERBERUS": { return "CERBÈRE"; }
                case "HIDEOUS MASS": { return "MASSE HIDEUSE"; }
                case "GABRIEL, JUDGE OF HELL": { return "GABRIEL, JUGE D'ENFER"; }
                case "GABRIEL, APOSTATE OF HATE": { return "GABRIEL, APOSTAT DE HAINE"; }
                case "VIRTUE": { return "VERTU"; }
                case "SOMETHING WICKED": { return "QUELQUE MAUDIT"; }
                case "FLESH PRISON": { return "PRISON DE CHAIR"; }
                case "MINOS PRIME": { return "MINOS PRIME"; }
                default: { Console.WriteLine(originalName); return "Untranslated"; }
            }
        }

        public string getType(string originaltype)
        {
            switch (originaltype)
            {
                case "LESSER HUSK": { return "COQUE INFÈRIEURE"; }
                case "GREATER HUSK": { return "COQUE SUPÉRIEURE"; }
                case "SUPREME HUSK": { return "COQUE SUPRÊME"; }

                case "LESSER DEMON": { return "DÉMON INFÈRIEUR"; }
                case "GREATER DEMON": { return "DÉMON SUPÉRIEUR"; }
                case "SUPREME DEMON": { return "DÉMON SUPRÊME"; }

                case "LESSER MACHINE": { return "MACHINE INFÈRIEURE"; }
                case "GREATER MACHINE": { return "MACHINE SUPÉRIEURE"; }
                case "SUPREME MACHINE": { return "MACHINE SUPRÊME"; }

                case "LESSER ANGEL": { return "ANGE INFÈRIEUR"; }
                case "GREATER ANGEL": { return "ANGE SUPÉRIEUR"; }
                case "SUPREME ANGEL": { return "ANGE SUPRÊME"; }

                case "???": { return "???"; }
                case "PRIME SOUL": { return "ÂME PRIME"; }
                default: { return "UNKNOWN"; }
            }
        }

        public string getDescription(string originalenemy)
        { 
            switch(originalenemy)
            {
                case "FILTH":
                    {
                        return
                            "Les Coques sont des manifestations physiques âmes des maudits.\n\n" +

                            "La forme physique est basé sur la valeur de l'âme originale, qui est determiné par la force de son volonté, et son prévalence dans la connaissance publique: les âmes vivantes qui lui en souvient.\n\n" +

                            "Les Saletés sont la forme le plus bas d'une Coque, dont les âmes sont trop faibles et sans importance pour même pouvoir former un corps physique complet.\n\n" +

                            "Même parmi les Salétes, ils ont une intelligence trés bas, motivé purement par la famine.";
                    }
                case "STRAY":
                    {
                        return
                            "Même si leur grande stature semble être intimidant, les Errants ont peur de pleins de dangers et tenteront de rester à une distance suffisante, attaquant seulment avec des projectiles formés avec de l'Énergie d'Enfer.\n\n" +

                            "Pendant que la réalisation et le côntrole de cet énergie est une tâche complexe, les Errants portent une intellecte très pauvre, et ne peuvent faire ceci que par l'instinct pur.\n\n" +

                            "Néanmoins, les humains n'ont pas pu repliquer ce niveau de précision et côntrole, en particulier, la capacité d'un Errant de faire en sorte que les orbes d'énergie ignorent des autres Errants.";
                    }
                case "SCHISM":
                    {
                        return
                            "Le résultat de deux âmes essayant de se manifester dans le même espace, résultant dans une amalgamation de deux corps physiques.\n\n" +

                            "En raison de leur masse de corps doublé, ils sont résilient aux dégâts, mais ont beaucoup de mal à se déplacer, et donc ne peuvent pas viser avec beaucoup de précision, et doivent recourir à des tirs de barrage d'orbes d'énergie dans la direction générale de leur adversaire.";

                    }
                case "SOLDIER":
                    {
                        return
                            "Les Soldats sont une version amélioré des Errants, dont leur implants technologiques ont été fouillés des machines cassés, pour canaliser l'Énergie d'Enfer avec plus d'éfficacité.\n\n" +

                            "Cet augmentation de pouvoir donnent plus de confiance aux Soldats, leur amènant à se comporter plus aggressivement que les Errants normales.\n\n" +

                            "Malgré leurs augmentations, leur intelligence reste faible, et on ignore quoi ou qui les ont augmenté.";

                    }

                case "FERRYMAN":
                    {
                        return
                            "Les Nochers sont des coques rares auquel leur corps puissants, compétences formées et foi aveugle les ont permis la chance de devenir un transporteur des âmes entre les couches de l'Enfer.\n\n" +

                            "Ils ont été donné un tissu sacré par le Paradis comme symbole de leur dévotion à l'ordre de Dieu, qu'ils portent sur leur corps pour cacher la forme humaine qu'ils détestent comme souvenir de leur pêchés qui les êmpechent de devenir des anges.\n\n" +

                            "Grâce au puissance sacré émanant du tissu, les corps squelettiques ont été colorés de façon vibrante et radiante, et leurs crânes portent assez d'énergie latente pour ouvrir des portes qui êmpechent autrement les Coques de quitter leurs milieux de torment.\n\n" +

                            "Chaque bateau ne peut avoir qu'un seul Nocher à la fois, donc à la suite de la formation d'un nouveau Nocher, ils se lutteront à la mort pour prendre la place et hériter leur tissu. La crâne du perdant est pris comme trophée, et est utilisé pour permette au vainqueur de passer à travers les couches pour transporter les âmes des condamnés à leurs destinations.\n\n" +

                            "Les Nochers utiliseront les connaissances de leurs vies précédents pour améliorer leurs bateaux, passant la besoin des rames, qui ne sont utilisés que pour des armes.\n\n" +

                            "Puisque l'influx d'âmes a terminé avec l'extinction de l'humanité, les Nochers ont perdu leur but, et se baladent sans objectif, en espérant que les anges leur donnerent passage dans le Paradis, malgré Gabriel étant le seul qui prend soin de leurs efforts.";
                    }

                case "IDOL":
                    {
                        return
                            "Malgré la facilité d'être confondu d'être d'origine divin, les Idoles ont été crées avec le même processus que les autres demons. Contrairement à leur proche plus grand, leurs coques sont trop petits pour porter une quantité utile de Masse d'Enfer, qui les rend à créer la vie, mais n'étant pas capable de se déplacer ou d'agir.\n\n" +

                            "Les Idoles n'avait originallement aucun air divin, mais ont été sculptés attentivement pour ressembler de tels figures comme les Nochers, qui les ont collectées lors de leurs voyages à travers les couches d'Enfer. Ceci a été fait comme acte de compassion et tribut envers les anges, Gabriel en particulier, les Nochers croyant qu'ils les ont pitié." +

                            "La proximité immédiate du chiffon sacré d'un Nocher lors du processus de création ont causé la puissance sacré à rentrer dans leurs corps, leur permettant de continuer la chaîne de compassion en protegeant les autres de la préjudice physique.";


                    }

                case "LEVIATHAN":
                    {
                        return
                            "Contrairement aux autres demons, le Léviathan n'est pas formé à partir de la Masse d'Enfer, mais plutôt à partir des corps des Renfrognés, un nom utilisé pour ceux dans l'océan du Styx qui ont abandonné leur lutte, et ont coulé au fond de l'océan, se noyant pour tout éternité.\n\n" +

                            "Les Renfrognés, dans tout leur immobilité, ont été éventuellement fusionnés ensemble par la même force qui a crée les autres demons, devenant le Léviathan biblique, une abomination prophétisé améner la fin du monde.\n\n" +

                            "Le cœur, qui abrite les âmes des Renfrognés dans une angoisse sans fin tant que leurs chairs, veines et nerfs se tordent et se mutent, a tenté d'échapper de son corps, mais Gabriel l'a abattu avec ses lances divins, le collant sur l'arrière de sa tête, incapable de se déplacer.\n\n" +

                            "Malgré la fin du monde, le Léviathan reste coincé dans l'océan du Styx, s'agrandissant encore plus avec plus de pêchers de Colère abandonnent tout espoir et se coulent au fond.";
                    }

                case "THE CORPSE OF KING MINOS":
                    {
                        return
                            "Autrefois le roi grand et bien-aimé du couche Luxure, Minos a été réduit à un cadavre ruiné.\n\n" +

                            "En raison de son volonté incroyable, et son staut comme dirigiant juste qui a été rappelé même après des millénies après son mort, la manifestation dev son âme est le Coque le plus grand jamais rencontré.\n\n" +

                            "Des traces mineurs de son âme original peut toujours être trouvés dans son corps, mais le cadavre lui-même est animé et dirigé entièrement par les parasites en forme de serpent, qu'il commandait autrefois.\n\n" +

                            "Malgré ayant ramené une période de renaissance au couche de Luxure, son cadavre ne cherche maintenant qu'a punir les pécheurs.";

                    }

                case "STALKER":
                    {
                        return
                            "Comme punition dans la couche d'Avarice, les Traqueurs sont forcés à transporter des lourds rochers jusqu'en haut des momuments dediés aux avarices d'humanité pour tout éternité.\n\n" +

                            "Ils ont realisé cet punition pour si longtemps que leurs corps ont évolués, déformés et grandis pour mieux s'adapter.\n\n" +

                            "Leurs membres se sont tordus pour mieux garder son balance en portant des rochers sur leurs dos, et leurs peaux et muscles se sont complètement séchés, qui leurs permettent à survivre le combat direct avec les dunes en poussière d'or, auquel les tempèratures ont été augmentés aux niveaux insupportables par la soleil d'Avarice.\n\n" +

                            "Cependant, un force sentient non-identifié ont remplacé les rochers qu'ils portent normallement avec des bombes qui, lors de son detonation, transformera tout sang en proximité en poussière d'or qui couvre la surface du couche.\n\n" +

                            "La recherche ont demontré que cette technologie est très similaire aux augmentations des Soldats, dont il est possible que les deux modifications viennent de la même source.";
                    }
                case "INSURRECTIONIST":
                    {
                        return
                            "Les Insurrectionistes Sisypheanes sont une armée de Coques rassemblées et entraînées par le Roi Sisyphe pour renverser le côntrole du Paradis sur l'Enfer, liberant les pêcheurs de leur torment éternel.\n\n" +

                            "Durant une ère de chaos dans le Paradis, où la veille des Anges étaient absent, Sisyphe à mis son plan en motion, ses forces recrutant tous les Coques ayant assez d'intelligence pour être utile à leur cause, et ont commencé à attaquer les démons se promenant sur les dunes d'Avarice.\n\n" +

                            "Lors de l'établissement du Conseil, et le retour du paix au Paradis, Gabriel et son armée d'Anges ont été envoyés pour écraser l'insurrection et subjuguer l'armeé de Sisyphe.\n\n" +

                            "Malgre une bataille bien battu, les Insurrectionists inexpérimentés n'ont pas pu faire face aux stratègies des Anges, qui se sont descendus sur le Roi Sisyphe, et l'ont finalement vaincu et l'ont tué, laissent les insurrectionistes sans chaîne de commandemant.\n\n" +

                            "Dispersés et désorientés, les guerriers ont été facilement battus un par un, leurs corps coupés en morceaux, y laissant que les essentiels requises pour  continuer leur punition éternel de transporter des rochers lourds jusqu'en haut des momuments dediés aux avarices d'humanité.\n\n" +

                            "Bien que le sang de leurs ennemies tachent leurs corps et leurs bras portent toujours leurs ennemis tombés, leur volonté et fureur ne servant comme torment mentalle en sachent qu'ils étaient si proche de la liberté.";
                    }

                case "SWORDSMACHINE":
                    {
                        return
                            "Sa forme originale n'est pas reconnaisable après des années de récupération de feraille pour sa propre reconstruction, mais parmi les amateurs de robot, la Machine à Epée est réputée grâce à sa prouesse au combat et sa forme autodictate; Laid pour la plupart mais belle pour les enthousiastes, qui donnent suite à plein d'imitateurs.\n\n" +

                            "Elle porte une épée créé par elle-même avec un moteur y rattaché dessus, qui chauffera la lame lorsque qu'il est tourné, permettant de couper à travers la plupart de matière organique sans difficulté.\n\n" +

                            "En raison de son comportement obssesif de ramassage, c'est une des machines restant capable de la vocalisation - une capacité que la plupart ont abandonné pour économiser leurs resources.";
                    }
                case "DRONE":
                    {
                        return
                            "Un appareil de securité produit en masse, agissant comme caméra de surveillance et agent de sécurité.\n\n" +

                            "Ils ont été originallement conçus pour utiliser des munitions non-létals, mais ils ont fouillé des pièces des machines défunts de la surface, pour augmenter leur efficacité au ramassage du sang.\n\n" +

                            "Curieux par la nature, mais pour économiser les coûts de productions, leurs intelligences sont trés réduits.";
                    }
                case "STREETCLEANER":
                    {
                        return
                            "Initiallement construites pour purifier l'air contaminé des cités après la catastrophe du climat, les Nettoyeurs ont été rendues obsolètes lors de la Nouvelle Paix, et ont été réutilisés comme scouts pour les expeditions dans l'Enfer.\n\n" +

                            "Leurs urges de nettoyer se sont toutefois restés, et après la chute de l'humanité, elles ont commencé à brûler toute matière organique qu'elles ont rencontré dans un effort pour purifier le monde.";
                    }
                case "V2":
                    {
                        return
                            "Le modèle V à été conçu pour la guerre, avec V1 portant un nouveau type de blindage qui permet le ravitaillement avec le contact physique avec du sang, au lieu d'un processus de ravitaillement séparée.\n\n" +

                            "En cause de son minceur nécessaire, il est beaucoup moins durable, mais la capacité de réparer soi-même et reconstruire des pièces sur le terrain, l'emporte sur les négatifs sur un champ de bataille actif.\n\n" +

                            "Cependant, pendant la phase de prototypage, la Nouvelle Paix a été établi, et la guerre n'était plus pertinent.\n\n" +

                            "La production planifiée de V1 a été annulé et un modèle amélioré, V2, a été conçu à sa place, en y utilisant le blindage standard, puisque la durabilité était beaucoup plus important lors des temps de paix, où la violence n'était pas nécessaire.\n\n" +

                            "Aucun des deux modèles ont atteint la production en masse en cause de la manque des guerres qui ont supprimé toute demande. Il est alors très probable qu'il reste un seul prototype des deux modèles en existence.";
                    }
                case "MINDFLAYER":
                    {
                        return
                            "Rare mais extrêment dangereuse, l'Illithid est une machine qui a adapté et maîtrisé l'usage d'Énergie d'Enfer, avec sa propre prouesse technologique.\n\n" +

                            "La machine elle-même ne comporte que la partie haute de son corps, dont le reste est une coque plastique dans la forme d'un humain, ce qu'ils semblent avoir construit eux-mêmes.\n\n" +

                            "Le corps plastique ne sert à rien, et n'est utilisé que pour des raisons aesthetiques.\n\n" +

                            "Malgré le fait que ça soit une gaspillage de ressources, les Illithids utiliseront ce qui est en son pouvoir pour proteger le corpse plastique du mal, même si elle doit se détruire dans le processus.\n\n" +

                            "Les Illithids semblent préférer une forme féminine, mais des occasions rares des formes masculins ont été constatées.";

                    }

                case "SENTRY":
                    {
                        return
                            "Un parmi beaucoup de machines de guerres conçu lors du Dernière Guerre. Malgré des tentatives pendant la Nouvelle Paix, leur conception simplifié les ont rendu incapable de réamènagement avant le début des expéditions en Enfer.\n\n" +

                            "Leur jambes et pieds extrêmement puissants les permettent de creuser dans le sol, les rendant inamovible par la force physique, et les permettant de viser tout tir sans interruption.\n\n" +

                            "Malgré leur taille, ils ont été conçus pour être très lègers, qui les rendent possible de se déplacer à pas accélére avec la puissance de leurs jambes. Une telle puissance et légèreté les ont rendu une des pièces les plus recherchés par les amateurs.\n\n" +

                            "La plupart des machines n'utilisent qu'une approximation simplifié de leur environnement pour un temps de traitement optimisé, mais les Mitrailleuses utilisent des approximiations complets, leur donnent une précision parfaite, même sur des distances extrêment longs.";

                    }

                case "V2 (2nd)":
                    {
                        return
                            "Suite à son défaite et échappement, V2 a rentré plus profondement dans l'Enfer, en tuant des autres machines pour leur sang pour contribuer à son propre soignage, avec l'intention de se venger auprès de V1 et récuperer son bras originale.\n\n" +

                            "Ayant retrouvé un remplacement temporaire depuis un de ses victimes, V2 a utilisé des pièces des autres machines pour transformer le nouveau bras en outil de mobilité qui le permettra de rattraper la vitesse rapide de V1 envers les couches plus profonds.\n\n" +

                            "Pour préparer leur deuxième et dernier rencontre, il a analysé les données de combat depuis leur dernier bataille pour recopier les stratègies et techniques utilisés par V1 pour obtenir un avantage.\n\n" +

                            "Cependant, malgré tout son préparation, V2 à perdu de nouveau, et a rencontré son fin de la part de son précédent.";
                    }
                case "MALICIOUS FACE":
                    {
                        return
                            "Les démons sont des créatures nées dans la masse de l'Enfer. Ils sont facilement reconnaisables par leur extérieur dur et en forme de pierre, et leur déplacement ralenti.\n\n" +

                            "Les démons portent une intelligence supérieur que les Coques, mais ils sont toujours incapables des pensées rationelles et la communication. Aucun démon a pu passer le test du miroir, mais les études sont limités en cause de leur hostilité.\n\n" +

                            "Les Têtes Malicieux sont le type de démon le plus commun, mais sont incroyablement dangereux, surtout dans des essaims, grâce à leur maîtrissage d'Énergie d'Enfer comme arme.";
                    }
                case "CERBERUS":
                    {
                        return
                            "Même s'ils ne ressemblent pas au chien à trois têtes de la mythologie, ce nom a été choisi en raison de leur nature comme guardiens d'Enfer. Cependant, il n'est pas encore connu pourquoi certains continuent à dormer malgré la provocation.\n\n" +

                            "Malgré le fait que la conservation de stabilité d'un orbe d'énergie nécessite un effort considerable de concentration, ils semblent toujours en garder à la main, très probablement comme un présentoir de son pouvoir pour effrayer les intrus.";
                    }
                case "HIDEOUS MASS":
                    {
                        return
                            "Les Masses Hideuses sont une occurence rare, lorsqu'une quantité excessive de Masse d'Enfer est versé dans une seule coquille, le causant à déborder et s'éclater.\n\n" +

                            "En cause des coutures cassées qui permet la mobilité sans avoir besoin de plier l'extérieur, la pierre à durcit plus que la plupart des coques des démons, le rendant complètement imperméable à tout attaque actuellement connu.";
                    }
                case "GABRIEL, JUDGE OF HELL":
                    {
                        return
                            "Un des archanges le plus respectés et redoutés, Gabriel a gagné sa reputation par le pouvoir et l'éfficacité.\n\n" +

                            "Peu importe la tâche donné, Gabriel le réalisera vitement et décisivement, ce qui lui a gagné le titre de Juge d'Enfer après avoir détrôné Minos, et mis fin au renaissance du couche de Luxure.\n\n" +

                            "Malgré son loyauté au Conseil, il est beaucoup plus populaire et aimé parmu les anges, grâce au son personalité radiant et nature actif, surtout par rapport au Conseil, qui suit et maintient de manière stricte le dogme du Foi.";
                    }


                case "GABRIEL, APOSTATE OF HATE":
                    {
                        return
                            "Ayant affronté le machine et avoir perdu deux fois, Gabriel a reconnu son erreur. Le feu intense qui lui brûlait dedans n'était pas la haine, mais la passion.\n\n" +

                            "Gabriel n'a jamais connu la joie de la lutte, de faire face à un adversaire de mesure égale ou supérieure. Même ayant maintenant perdu deux fois, chaque perte n'a qu'augmenté son desir de surmonter.\n\n" +

                            "Jusqu'au présent, il n'a fait que ce qu'on lui attendait de faire, mais maintenant, pour le premier fois, il a trouvé quelque chose qu'il voulait lui-même. La Fin de l'Enfer ne lui portait plus d'importance.\n\n" +

                            "De même, ayant compris les horreurs qu'il a commis au nom du Dieu, il a resenti une grande culpabilité. Bien qu'il ne peut pas défaire ce qu'il avait fait, Gabriel savait qu'il devrait remettre les choses en ordre, et s'est dirigé vers l'Enfer pour le fernier fois.";

                    }
                case "VIRTUE":
                    {
                        return
                            "La base du formation d'un ange inférieur est assez similaire de celle des Coques, où la manifestation physique de l'âme est dépendant de son valeur, mais contrairement aux Coques, la virtuosité s'agit aussi comme facteur pour les anges.\n\n" +

                            "Les anges inférieurs viennent des âmes humaines, qui prennent des formes abstraits ou animales, qui les rend distinct des corps humanoïdes des anges supérieurs et suprêmes, qui ont été créés comme tels, et sont considérés plus purs et sont placés plus haut sur l'hierarchie sociale du Paradis.\n\n" +

                            "On ne sait peu sur les spécifiques des anges, puisque le Paradis est excluante et ségrégé en raison de ne pas voulant de contact avec l'expérience humain de Dieu.";
                    }
                case "SOMETHING WICKED":
                    {
                        return
                            "On ne connaît très peu de cette créature.\n\n" +

                            "Certains spéculent que c'est un Coque, mais en cause de son nature elusif et extrêmement hostile, personne n'a pu confirmer l'hypothèse.\n\n" +

                            "Un seul a été observé, et il n'a jamais été vu quitter la section du Bouche d'Enfer auquel il réside actuellement.";
                    }
                case "FLESH PRISON":
                    {

                        return
                            "Le Prison De Chair est un organisme non catégorisé créée par les anges, pour imprisonner l'âme de Minos après avoir été tué par Gabriel.\n\n" +

                            "Malgré son similarité aux Coques, il ne possède pas d'âme, ou tout amont de pensée. Tout ses actions sont des réactions purement prédéterminées à un stimulus, le rendant plutôt une machine organique au lieu d'un être vivant.\n\n" +

                            "Pour pouvoir le rendre aussi impénétrable que possible, il a été donné des pouvoirs divins et d'Énergie d'Enfer, qui rend ses attaques erratiques et chaotiques.";
                    }
                case "MINOS PRIME":
                    {
                        return
                            "Un âme prime est une occurence incroyablement rare, auqul un âme accumule autant tellement de pouvoir qu'il ne nécessite plus une Coque pour pouvoir se manifester physiquement.\n\n" +

                            "En tant que des manifestations du volonté pur, les âmes primes sont incroyablement puissants, jusqu'au point que même les anges les plus fiers les voient comme menace, et utilisera tout les moyens nécessaires pour les empêcher de prendre forme.\n\n" +

                            "Le Roi Minos a estimé que la souffrance éternelle était une punition injuste et déraisonnable pour ceux dont le seul pêché était l'amour d'un autre. Après la Disparition de Dieu, les anges se sont perdus et le Paradis se trouvait dans le chaos, Minos a commencé ses efforts à reformer la couche de Luxure.\n\n" +

                            "La renaissance de Luxure était prospère, avec le Roi Minos guidant ses citoyens à se réunir et bâtir une nouvelle civilisation. Les efforts combinés des innombrables qui ont été damnés au seconde couche a apporté des grandes résultats, avec la cité de Luxure se grandissant de plus en plus.\n\n" +

                            "Gabriel, le plus intelligent des anges, a été envoyé pour tuer Minos. Le roi, au lieu de se battre, a tenté de le raisonner avec, mais Gabriel l'a battu sans merci et sans l'écouter.\n\n" +

                            "Puisque la volonté de Minos a été assez fort pour tenter de faire face au règne du Paradis, les anges ont choisi d'imprisonner son âme comme tentatif de l'empêcher de devenir un âme prime, et ont nommé Gabriel comme nouveau Juge d'Enfer.\n\n" +

                            "À partir du prison dans son propre corps, Minos a regardé en toute impuissance, son corps maintenant côntrolé par des parasites, détruisant tout ce pour lequel il a travaillé si dur.En maudissant soi - même pour avoir échoué de proteger son peuple, il fait vŒu de vengeance...";

                    }

                default: {return "UNKNOWN";}

            }
        }

        public string getStrategy(string originalenemy)
        {
            switch (originalenemy)
            {
                case "FILTH":
                    {
                        return
                            "- La plupart des armes sont facilement capables d'abattre les Salétes, mais leurs mâchoires puissants et leurs chiffres grands peuvent écraser s'ils sont sous-estimés.\n\n" +

                            "- Les explosions sont le moyen le plus efficace de battre des groupes, mais toute arme qui peut frapper plus qu'un cible sera efficace.";
                    }
                case "STRAY":
                    {
                        return
                            "- La plupart des armes seront effectifs contre les Errants, mais un tir un plein tête avec le Revolver est la façon le plus vite et sûr pour éliminer un Errant.\n\n" +

                            "- En raison de leur nature statique et leur vitesse de tir ralenti, ils sont un cible excellent pour leur renvoyer des projectiles.";
                    }
                case "SCHISM":
                    {
                        return
                            "- Les tirs chargés du Perçeuse sont une outil efficace pour tuer les Schismes, mais leurs têtes deplacés peuvent rendre le visement difficile pour les inexpérimentées.\n\n" +

                            "- Un tir à bout portant du fusil à pompe, avec 2 pompes, sera assez pour les tuer en une seule attaque.\n\n" +

                            "- En raison de leur visée pauvre, ils ne sont pas un cible prioritaire, mais la quantité de projectiles tirés peuvent les rendre difficile à esquiver lors des rencontres grands.";
                    }
                case "SOLDIER":
                    {
                        return
                            "- Le fusil de pompe est une arme excellente contre les Soldats, tant que son utilisation est aussi vite pour leur empêcher de se proteger avec des attaques à mêlée.\n\n" +

                            "- Les Soldats chargent leurs tirs devant eux, au lieu de en-dessus d'eux. La charge est alors plus facile à interrompre avec un tir de Revolver, pour les exploser.";
                    }


                case "FERRYMAN":
                    {
                        return
                            "Les Nochers choisissent leurs attaques en fonction des actions de son adversaire. Quand il est approché, il se recule vers une distance sûr, et quand on lui recule, ils appliqueront la pression avec des attaques à portée augmenté.\n\n" +

                            "- Malgré son apparence, leur coup de point remontant est assez dangereux et peut être difficule à esquiver. Il est conseillé de ne pas rester dans l'air pour longtemps.\n\n" +

                            "- Certains de ses attaques peuvent être renvoyés, d'autres non. Soyez attentif au couleur de l'attaque pour comprendre si elle peut être renvoyé.\n\n" +

                            "- Les Nochers tenteront de dépasser un adversaire reculant en roulant derrière lui avant d'attaquer. Traquez leur position et s'ils roulent trop de fois, tentez de monter l'aggression.";

                    }

                case "SENTRY":
                    {
                        return
                            "- Grâce à leurs jambes puissantes, une fois creusé dans le sol, ils ne peuvent plus se déplacer.\n\n" +

                            "- Une fois dans le sol, les seuls moyens d'interrompre leur attaque sont: Le Canon-Électrique, frappant leur antenne avec le Revolver, leur lancant avec un choc au sol, ou les poignardant avec le Bombardier.\n\n" +

                            "- Tant qu'ils ne sont pas creusés, leur poids lèger les rendant facile à lancer, et les garder dans l'air, les rendant sans danger.\n\n" +

                            "- Un bon technique pour désactiver une Mitrailleuse pour plus longtemps est de le remplir avec des clous, et ensuite tirer un aimant du Cloueur dans un mur ou plafond, qui l'attirera une fois déséquilibré.";


                    }

                case "IDOL":
                    {
                        return
                            "- Malgré leur immunité aux projectiles, ils peuvent toujours être détruits par un coup de poing ou un lancement au sol.\n\n" +

                            "- Les ennemies benedits sont immunisé contre les dégâts, mais peuvent toujours êtres lancés par des foces physiques, et tués par des dangers environnmentaux, tel  que les écrasements ou chutes.\n\n" +

                            "- Ni les Idoles, ni les ennemies benedits ne peuvent être saisies avec le COUP DE FOUET.";

                    }

                case "THE CORPSE OF KING MINOS":
                    {
                        return
                            "- En raison de son grand taille, il peut être dur de reprendre son sang, mais ses mains s'accrochent d'habitude aux murs de l'arène, qui peuvent être utilisés pour le ravitaillement.\n\n" +

                            "- Tout arme sera effectif contre un ennemi de ce taille, mais les attaques à mêlée et les renvoyage des projectiles sont une façon vite de infliger des dégâts augmentés.\n\n" +

                            "Le trou noir qu'il crée, même avec un déplacement ralenti, reste toujours extrêment dangereux, et ne peux pas être détruit.";
                    }


                case "LEVIATHAN":
                    {
                        return
                            "- Le cœur du Léviathan est visible sur le sommet de sa tête, le rendant un point faible pour y viser. Il n'est pas toujours visible, mais il peut être vu après une de ses attaques, offrant une oppurtunité pour infliger des dégâts directement, ou pour lancer un aimant.\n\n" +

                            "- Bien que non conseillé, il est possible de monter sur le Léviathan pour une période courte. Un saut précis vous permettre d'esquiver la morsure de Léviathan, ainsi de grimper sur sa tête.\n\n" +

                            "- Sa queue se lancera soit en haut, soit en bas. La hauteur du lancement peut être determiné par la direction de la rotation.";
                    }

                case "STALKER":
                    {
                        return
                            "Il est conseillé de exploser un Traqueur au lieu de le laisser exploser tout-seul, puisque l'explosion de ce dernier aura une portée élargie.\n\n" +

                            "Si un Traqueur s'approche de son cible, et ne peux plus être repoussé, un lancement au sol peux les lancer hors de portée, pour qu'ils soient explosé en toute securité, puisque l'explosion est principalement horizontal.";

                    }
                case "INSURRECTIONIST":
                    {
                        return
                            "- Même s'ils ont une portée d'attaque illimité, chacun des coups de l'insurrectioniste ont ses forces et faiblesses. Il est essentiel d'apprendre les directions auquel il faut esquiver chaque attaque.\n\n" +

                            "- Le coup de pied du Insurrectioniste est vite et destructif, donc il est mal conseillé de rester proche pendant trop longtemps.\n\n" +

                            "- Les Insurrectionistes Sisypheanes baignent leurs pieds dans le sang de leurs ennemies pour leur protéger du chaleur des dunes d'Avarice, mais le reste de leurs corps est toujours de chair et os, qui peut être enflammés pour infliger des dégâts au fur et à mesure.\n\n" +

                            "- La Tête Malicieux qu'ils portent comme arme ne fais pas partie de leurs corps, donc les coups dessus n'infligeront aucun dégât à l'Insurrectioniste, mais ceci veut aussi dire qu'il est possible de vous soigner dessus, même si le sang de son porteur a été transformé en sable.";
                    }
                case "SWORDSMACHINE":
                    {
                        return
                            "Malgré sa performance excellente contre les citoyens d'Enfer, sa conception ne prend pas en compte les adversaires très mobiles, donc la meilleure façon d'esquiver sa lame est de sauter hors de sa portée verticale.\n\n" +

                            "- Son épée motorisé permet des attaques prévisibles, ce qui rend la Machine à Épée un cible excellent pour le renvoi des attaques.\n\n" +

                            "- Bien que son utilisation des attaques à distance sont primitives, ses lancement d'épées portent une précision inattendue grâce à son maîtrissage de l'arme.";
                    }
                case "DRONE":
                    {
                        return
                            "- En raison de leur poids lèger, les projectiles physiques comme des clous les bousculeront, rendant les dègâts cohérents difficile.\n\n" +

                            "- Au moment de leur mort, une Drone fera un dernier effort de blesser leur adversaire avec un autodestruction, mais les attaques puissants et les explosions les feront exploser instantanément.\n\n" +

                            "- Un coup de poing sur un Drone redirigera leur plongée de suicide, les rendant une opportunité offensive à haut risque.\n\n" +

                            "- Leur mécanisme de scannage émettent un son de pépiement, qui peut être entendu pour les rendre plus facile à traquer, puisque leur taille réduit et leur capacité de vol peuvent les méner à des endroits difficiles à atteindre.";
                    }
                case "STREETCLEANER":
                    {
                        return
                            "- En raison de leur expèrience dans le combat, elles peuvent être difficiles à battre avec les projectiles ou les explosives.\n\n" +

                            "- Le bidon de gaz sur leurs dos est un point faible majeur qui peut être brisé avec un tir précis, par exemple une pièce du Tireur d'Élite par l'arrière.\n\n" +

                            "- Les attaques à bout portant peuvent aussi être efficaces, mais doivent être vite effectués pour esquiver leur lance-flammes.";
                    }
                case "V2":
                    {
                        return
                            "- V2 est adepte au contrôle d'espace et en prendra avantage de ceci pour changer le rythmne de la bataille pour troubler son adversaire. Si vous restez proche, elle s'enfuira, mais si vous restez loin, elle s'approchera.\n\n" +

                            "- La mobilité élevée de V2 la fait d'elle un cible difficile à frapper, et en particulier la rend difficile de se soigner. Si vous avez besoin du sang, et vous n'êtes pas capable de la rattraper, il est conseillé de rester à l'écart pour qu'elle vous approche.\n\n" +

                            "- L'arme que V2 porte dépend de la distance de sa cible. Si une de ses armes est difficile à esquiver, un changement de distance va la forcer de changer d'arme.\n\n" +

                            "- La connaissance des synergies de votre arsenal peuvent vous permettre de contrer les attaques de V2.";
                    }
                case "MINDFLAYER":
                    {
                        return
                        "- Lors d'une rencontre avec une Illithid, il est impératif de traquer ses actions, soit par visuel ou par sonore.\n\n" +

                        "- En cause du fait que leurs projectiles guidés soit tirés en rafale, un explosif comme le choc du Bombardier est le moyen la plus efficace de les renvoyer.\n\n" +

                        "- Leur téléportation instantané peut rendre la possibilité d'avoir un avantage de positionnement difficile, mais un tir de Tournevis les empêchera de pouvoir se téléporter temporairement.";
                    }
                case "V2 (2nd)":
                    {
                        return
                            "- Les pièces de V2 semblent être dangereuses, mais elles permettent une opportunité d'infliger des dégâts élevés si vous les frappez en premier.\n\n" +

                            "- Le cloueur de V2 peut être utilisé contre lui-même avec des Aimants.\n\n" +

                            "- V2 sera enragé instantanément si vous le frappez avec son propre bras.";
                    }
                case "MALICIOUS FACE":
                    {
                        return
                            "- En raison de leur tir en rafale, il peut être difficile de les approcher. Malgré l'efficacité d'un tir de fusil de pompe à bout pourtant, les clous sont le meilleur plan d'action, avec les aimants qui permettent le combat à longue distance.\n\n" +

                            "- Grâce à leur résistance totale aux explosions, ils n'ont pas besoin de se retenir avec leur attaques de faisceau, il est donc conseillé d'éviter les murs et d'autres surfaces lorsqu'ils commencent à charger un faisceau d'énergie.";

                    }
                case "CERBERUS":
                    {
                        return
                            "- En raison du fait qu'ils restent entièrement stationaire jusqu'à qu'ils soit reveillé, leur déplacement est très lent, donc la distance d'engagement est facile à contrôler.\n\n" +

                            "- Ils sont assez adepte au combat à distance en lancant leur orbe, mais pour éviter les dégâts à soi-même, ils ne le lanceront pas quand leur cible est proche. Ceci peut être utilisé pour manipuler leur comportement, mais une fois un lancer est demarré, il ne peut pas être empêché.\n\n" +

                            "- En raison de leur concentration extrême sur leurs orbes d'énergie, les orbes lancés exploseront sur l'impact physique, donc il sera plus difficile d'éviter ces attaques en restant proche des surfaces, comme le sol ou les murs.";
                    }
                case "HIDEOUS MASS":
                    {
                        return
                            "- Malgré son extérieur en pierre faisant un défense impénétrable, le ventre et la queue du Masse Hideuse restent exposés et vulnérables.\n\n" +

                            "- En position debout, un coup d'éclat des dégâts à distance proche est le moyen le plus effectif pour les blesser, cependant ceci est très probable de le faire changer de position; la clé est d'être vite et décisif.\n\n" +

                            "- En position accroupi, il est conseillé de garder votre distance en cause des ses capacités de mêlée et son harpon à haute vitesse, mais les courageux (ou les suicidaires) peuvent tenter de monter sur son dos pour continuer à attaquer la queue.\n\n" +

                            "- Si l'harpon vous attrape, il est conseillé soit de frapper de le frapper, soit d'attaquer la queue pour l'enlever.";
                    }
                case "GABRIEL, JUDGE OF HELL":
                    {
                        return
                            "- Les mouvements de Gabriel sont vites, et ses attaques mortelles, mais en observant l'arme qu'il brandit, ses attaques peuvent être prévus même avant qu'il ne les fasse.\n\n" +

                            "- La fierté de Gabriel l'empêche d'attaquer lorsqu'il moque son adversaire, ce qui permet une courte période pour vous soigner.";
                    }

                case "GABRIEL, APOSTATE OF HATE":
                    {
                        return

                            "- Bien que la vitesse de Gabriel a augmenté, sa précision n'a pas. Les esquives diagonaux ou aux côtés sera plus efficace que de tenter de reculer hors de portée de ses épées.\n\n" +

                            "- Tant que son épée semble impossible à esquiver, il reste une bonne arme si elle est renvoyé.\n\n" +

                            "- Submergé par ses émotions, Gabriel s'arrêtera parfois pour moquer son adversaire, permettant une courte période pour vous soigner.";
                    }

                case "VIRTUE":
                    {
                        return
                            "- La verticalité et le couvert donne peu de sécurité contre les rayons de lumière des Vertus, donc le mouvement horizontal est encouragé, mais se revenir en arrière est dangereux, pusique les rayons restent pendant un période de temps.\n\n" +

                            "- Si on l'ignore pour trop longtemps, les Vertus s'enragent, ce qui fait que les rayons suivent leur cible. Bien qu'il soit facile d'esquiver leurs attaques avec assez d'espace, les laisser sans surveillance peut très vite leur donner un avantage.";
                    }
                case "SOMETHING WICKED":
                    {
                        return
                            "- Tout attaque le fera changer d'endroit, mais il n'y a aucun façon de le tuer.\n\n" +

                            "- Son moyen d'attaquer est inconnu déhors du fait que ça se passe sur contact physique, mais aucun quantité de protection a sauvé une de ses victimes.";
                    }
                case "FLESH PRISON":
                    {
                        return
                            "- Le Prison De Chair utilisera ses Œils pour soigner ses propres blessures. Le plus d'Œils il en restent, le plus probably il est pour le Prison De Chair de tenter de soigner ses blessures, donc il est conseillé d'éviter de le blesser jusqu'a tout les Œils soient morts.\n\n" +

                            "- La période de temps d'un tir divisé avec le Tireur d'Élite le permet d'être un bon façon d'éliminer plusieurs Œils en même temps. Un bon premier coup contre le Prison De Chair est de lancer plusieurs pièces dans l'air, et attendre l'était de tir divisé avant de les tirer.";
                    }
                case "MINOS PRIME":
                    {
                        return
                            "- Il est rare que Minos Prime donne un période de temps pour pouvoir vous soigner, donc il est vitale d'aprendre lequels de ses attaques lui laissent vulnérable pendant un court moment, et comment les esquiver dans un tel façon qui permet de vous donner une position d'avantage lors de ces moments.\n\n" +

                            "- Ses projectiles en forme de serpent peuvent être reflectés avec le Renvoyeur pour vous soigner au plein, même si le projectile ne frappe pas Minos Prime.";
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
