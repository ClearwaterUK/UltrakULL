using System;
using UltrakULL.json;

namespace UltrakULL
{
    class TutorialStrings
    {
        //IMPORTANT CHARACTERS TO USE:
        // # - 3 repeating dots
        // § - Indent
        // + - Lime green text
        // * - Red text
        // ± - Blue text
        // _ - Close color
        // ½ - Half second pause
        // @ - Begins to fade out intro music
        // ~ - Wait for input (not implemented yet, skips straight to second page)
        // & - Ends intro text and loads the tutorial

        public string introFirstPage =

            "BOOT UP SEQUENCE#READY½ \n\n"
            + "FIRMWARE# \n"
            + "+LATEST VERSION(2112.08.06)_½ \n\n"
            + "+NEW OPTIONAL MODULE AVAILABLE_:\n"
            +" LANGUAGE SUPPORT\n\n"
            + "INSTALL? Y/N½½½\n"
            + "INSTALLING##\n"
            + "+SUCCESSFULLY INSTALLED_½½½\n\n"
            + "CALIBRATION# \n"
            + "+RÉCEMMENT MIS À JOUR_ \n \n"
            + "(RAPPEL: ASSISTANCES ET OPTIONS DISPONIBLES DANS LA MENU DE PAUSE)½ \n \n"
            + "CHARGEMENT DE STATUT# \n \n"
            + "~";


        //+ "Y/N ~ \n \n"
        //+ " AUDIO§         Ä½ \n"
        //+ " VIDEO§         Ä½ \n"
        //+ "MECHANICS§     Ä½ \n"
        //+ "+ CALIBRATION COMPLETE_ \n"
        //+ "+PRIMARY SETTINGS UPDATED_ \n"
        //+ "(±ASSIST OPTIONS_ AVAILABLE IN PAUSE MENU)½ \n"
        //+ "+ALL SYSTEMS OPERATIONAL_½ \n"
        //+ "LOADING STATUS UPDATE§ \n";

        public string introSecondPage =
            "STATUT ACTUEL: \n\n" +
            "IDENTIFIANT:           V1½½ \n" +
            "LIEU:                  EN APPROCHE DE L'ENFER½½@ \n" +
            "OBJECTIF ACTUEL:       TROUVER UNE ARME½½\n\n" +

            "*L'HUMANITÉ EST MORT._½½\n" +
            "*LE SANG EST DU FIOUL._½½\n" +
            "*L'ENFER EST PLEIN._½½&";

        /*
         *  MACHINE ID:            V1½½
            LOCATION:              APPROACHING HELL½½@
            CURRENT OBJECTIVE:     FIND A WEAPON½½

            *MANKIND IS DEAD._½½
            *BLOOD IS FUEL._½½
            *HELL IS FULL._½½&
         */

        public string getMessage(string inputMessage, string inputMessage2, string input)
        {
            Console.WriteLine(inputMessage + " - " + input);

            string fullMessage = inputMessage + inputMessage2;

            if (fullMessage.Contains("PUNCH"))
            {
                //return ("Appuyer sur '<color=orange>" + input + "</color>' pour lancer un <color=orange>COUP DE POING.</color>");
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_punch1 + " <color=orange>" + input + "</color> " + LanguageManager.CurrentLanguage.tutorial.tutorial_punch2);
            }

            else if (fullMessage.Contains("SLIDE"))
            {
                //return ("Maintenir'<color=orange>" + input + "</color>' pour <color=orange>GLISSER.</color>");
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_slide1 + " <color=orange>" + input + "</color> " + LanguageManager.CurrentLanguage.tutorial.tutorial_slide2);
            }
            else if (fullMessage.Contains("DASH"))
            {
                // return ("Appuyer sur '<color=cyan>" + input + "</color>' pour <color=cyan>ESQUIVER</color>. (Utilise d'<color=cyan>ÉNERGIE</color>.)") +
                //     "\n Peut étre utilisé dans l'air.";
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_dash1 + "<color=orange>" + input + "</color> " + LanguageManager.CurrentLanguage.tutorial.tutorial_dash2 + "\n" + LanguageManager.CurrentLanguage.tutorial.tutorial_dash3);
            }
            else if (fullMessage.Contains("HEALTH"))
            {
                // return ("Infligir des dégâts sur des ennemis à courte distance pour <color=red>VOUS BAIGNER DANS DU SANG FRAIS.") +
                //     "\n CECI EST LA SEULE FAÇON POUR RÉCUPÉRER VOTRE SANTÉ</color>.";
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_health1 + "\n" + LanguageManager.CurrentLanguage.tutorial.tutorial_health2);
            }
            else if (fullMessage.Contains("JUMP"))
            {
                //return ("<color=orange>SAUTER</color> prés d'un <color=orange>MUR</color> pour y <color=orange>SAUTER DESSUS</color>. (Max. 3 fois)");
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_walljump);
            }
            else if (fullMessage.Contains("SHOCKWAVE"))
            {
                //return ("Appuyer sur '<color=orange>" + input + "</color>' pour vous <color=orange>LANCER AU SOL</color>." +
                //    "\n Maintenir pour lancer un <color=orange>CHOC</color>. (Utilise <color=cyan>2 ÉNERGIE</color>)");
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_shockwave1 + " <color=orange>" + input + "</color> " + LanguageManager.CurrentLanguage.tutorial.tutorial_shockwave2 + "\n" + LanguageManager.CurrentLanguage.tutorial.tutorial_shockwave3);
            }
            else if (fullMessage.Contains("ORBS"))
            {
                //return ("La plupart des niveaux contiennent des <color=cyan>GLOBES D'ÂMES.</color>" +
                //    "\n Touchez-les pour recevoir un <color=orange>BONUS DE POINTS</color>.");
                return (LanguageManager.CurrentLanguage.tutorial.tutorial_orb1 + "\n" + LanguageManager.CurrentLanguage.tutorial.tutorial_orb2);
            }

            else
            {
                return ("Unimplemented tutorial string");
            }
        }


        //IMPORTANT CHARACTERS TO USE:
        // # - 3 repeating dots
        // § - Indent
        // + - Lime green text
        // * - Red text
        // ± - Blue text
        // _ - Close color
        // ½ - Half second pause
        // @ - Begins to fade out intro music
        // ~ - Wait for input (not implemented yet, skips straight to second page)
        // & - Ends intro text and loads the tutorial


        public TutorialStrings()
        {

            this.introFirstPage =
                LanguageManager.CurrentLanguage.tutorial.tutorial_introStartup1 + "#" + LanguageManager.CurrentLanguage.tutorial.tutorial_introStartup2 + " \n\n"
                + LanguageManager.CurrentLanguage.tutorial.tutorial_introVersion1 + "# \n"
                + "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_introVersion2 + "_½ \n\n"
                + LanguageManager.CurrentLanguage.tutorial.tutorial_introCalibration1 + "#\n"
                + "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_introCalibration2 + "_\n\n"
                 + "(+" + LanguageManager.CurrentLanguage.tutorial.tutorial_introReminder + "_)½\n\n"
                 + LanguageManager.CurrentLanguage.tutorial.tutorial_introLoadStatus + "# \n\n"
                 + "~";

            this.introSecondPage =
            LanguageManager.CurrentLanguage.tutorial.tutorial_introID1 + ":		" + LanguageManager.CurrentLanguage.tutorial.tutorial_introID2 + "½½ \n"
            + LanguageManager.CurrentLanguage.tutorial.tutorial_introLocation1 + ":			" + LanguageManager.CurrentLanguage.tutorial.tutorial_introLocation2 + "@½½ \n"
            + LanguageManager.CurrentLanguage.tutorial.tutorial_introObjective1 + ":	" + LanguageManager.CurrentLanguage.tutorial.tutorial_introObjective2 + "½½ \n\n"
            + "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed1 + "_½½ \n"
            + "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed2 + "_½½ \n"
            + "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed3 + "_½½&";
        }
    }
}
