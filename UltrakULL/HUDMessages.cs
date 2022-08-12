using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltrakULL
{
    class HUDMessages
    {
        public static string noArm =
            "<color=red>PAS DE COUPS DE POING SANS UN BRAS, PAUVRE CON</color>"
            + "\nLes bras peuvent être rééquipés au magasin.";

        public static string majorAssists =
            "<color=#4C99E6>LES ASSISTANCES MAJEURES SONT ACTIVÉES.</color>";

        public static string overhealOrb =
            "Les <color=red>GLOBES D'ÂMES ROUGES</color> donnent <color=lime>200 points de vie</color>."
            + "\nLes points de vie bonus ne peuvent pas être récuperées avec du sang.";

        public static string itemGrabError =
            "<color=red>ERREUR: LA PORTE BLOQUANT SE FERMERA</color>";

        public static string levelStats =
            "Maintenir <color=orange>TAB</color> pour voir les statistiques actuelles lors du <color=orange>REPASSAGE</color> d'un niveau."
            + "\n <color=orange>APPUYER DEUX FOIS</color> pour le garder ouvert.";

        public static string outOfBounds =
            "Oups, excuses pour cela.";

        public static string clashMode =
            "CODE DE TRICHE \"MODE CLASH\" DÉBLOQUÉE";

        public static string weaponVariation =
            "Changez de variations d'armes <color=orange>ÉQUIPÉES</color> avec";


        public static string getHUDToolTip(string message)
        {
            Console.WriteLine(message);
            
            if (message.Contains("PUNCH")) { return noArm; }
            if (message.Contains("MAJOR")) { return majorAssists; }
            if (message.Contains("200")) { return overhealOrb; }
            if (message.Contains("ERROR")) { return itemGrabError; }
            if (message.Contains("TAB")) { return levelStats; }
            if (message.Contains("Whoops")) { return outOfBounds; }
            if (message.Contains("CLASH")) { return clashMode; }
            if (message.Contains("EQUIPPED")) { return weaponVariation; }

            Console.WriteLine(message);
            return ("Unimplemented HUD string, check the console");


        }
    }
}
