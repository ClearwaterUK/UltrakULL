using BepInEx;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace UltrakULL
{
    class IntermissionStrings
    {


        //In the intermission, the ▼ symbol in strings is used to denote pauses.
        //The } symbol fades in the background panel used.

        public string act1IntermissionFirst =
            "La honte. ▼L'humiliation.▼}Inconvenant et malvenu aux pieds du Conseil. ▼Leurs yeux s'emflamment avec de la haine, ciblant les blessures de corps et d'âme de Gabriel, s'étendant pour que tous puissent voir. ▼\n\n" +
            "\"Celui-ci a-t-il abondonné le chemin de notre Créateur?\" ▼\"Il n'est pas digne de son Lumière Sacré.\" ▼\"La Lumière du Père est imbattable.\" ▼\"Celui-ci le juge approprié de le gaspiller.\"▼\n\n" +
            "Leurs mots resonnent dans les os de Gabriel, le traversant comme du électricité dans du fil, un sifflement qui renderait les inférieurs sourd et aveugle. ▼La Lumière Sacré une tempête inarrêtable du fureur divin. ▼Insurmontable pour les simples Objets. ▼Il savait ceci. ▼▼";

        public string act1IntermissionSecond =

            "\"Conseil Sacré, ma devotion à notre Créateur est absolue. ▼Je ne me suis jamais s'égaré du volonté du Père, mais une machine-\"▼\n\n"
            + "\"Osez-vous impliquer que la force du Père peut être choqué par des simples Objets?\"▼\n"
            + "\"Impossible.\" ▼\"Hérésie.\" ▼\"Indicible.\" ▼\"Hérésie.\" ▼\"Hérésie.\"▼\n"
            + "\"Silence.\"▼\n"
            + "\"Votre échec ne sera pas toléré. ▼La Lumière du Père sera rompu de vote corps comme punition. ▼Vous avez 24 heures avant que le dernier de ses embres s'éteignent.\"▼\n"
            + "\"Et vous parmi eux.\" ▼\"Faits preuve de votre loyauté.\" ▼\"Corrigez vos erreurs.\"▼▼";

        public string act1IntermissionThird =
            "Pendant que la Lumière s'arrachait de son esprit, les hurlements de Gabriel ont été réduits au silence dans les évangiles des louanges à Dieu. ▼Une angoisse bouillante auquel même les feus d'Enfer ne puissent y comparer. ▼À travers le tourment, une nouvelle haine brûlante a été forgé.▼\n\n"
            + "Si les machines cherchent du sang, il le donnera librement; ▼avec une tel fureur que même le métal saignera.▼▼";

        public string getIntermissionString(string inputString)
        {
            string currentLevel = SceneManager.GetActiveScene().name;

            //Act 2-S is being treated as an intermission. However as it's by far the most text-heavy area in the game, will redirect it to another
            //file for organisation's sake, at least for the time being.
            if (currentLevel == "Level 2-S")
            {
                Console.WriteLine("In 2-S.");
                return Act1VN.getNextString(inputString);
                
            }

            //Act 1 intermission
            if (currentLevel == "Intermission1")
            {
                //Paragraph 1
                if (inputString.Contains("Disgrace")) { return this.act1IntermissionFirst; }

                //Paragraph 2
                if (inputString.Contains("24")) { return this.act1IntermissionSecond; }

                //Paragraph 3
                if (inputString.Contains("gospel")) { return this.act1IntermissionThird; }
            }

            return "Unknown intermission string";
        }



        public IntermissionStrings()
        { 

        }
        

    }
}
