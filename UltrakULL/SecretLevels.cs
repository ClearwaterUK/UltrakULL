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
    class SecretLevels
    {
        string currentLevel;


        public void patchTestament(ref GameObject testamentRoom)
        {
            Text testamentPanelText = null;


            //0-S
            if (SceneManager.GetActiveScene().name == "Level 0-S")
            {
                GameObject finalRoom = GameObject.Find("FinalRoom 2");
                testamentPanelText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(finalRoom, "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Text"));
            }
            //1-S
            else if (SceneManager.GetActiveScene().name == "Level 1-S")
            {
                GameObject finalRoom = GameObject.Find("5 - Finale");
                testamentPanelText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(finalRoom, "FinalRoom 2 (1)"),"Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"), "Panel"), "Text"));
            }
            //4-S
            else if (SceneManager.GetActiveScene().name == "Level 4-S")
            {
                testamentPanelText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(testamentRoom, "4 Stuff"), "FinalRoom 2"), "Room"), "Testament Shop"), "Canvas"), "Border"), "TipBox"),"Panel"),"Text"));

            }



            switch (this.currentLevel)
                {
                case "Level 0-S":
                    {
                        testamentPanelText.text =
                            "L'Humanité à échoué.\n\n" +
                            "Le libre arbitre est un défaut.\n\n" +
                            "Que le mal de leurs propres paroles les consomment.\n\n" +
                            "Alors, je recommencerais à nouveau, avec ma parole faisant la loi.";

                        break;
                    }
                case "Level 1-S":
                    {
                        testamentPanelText.text =

                            "ÉCHEC APRÈS ÉCHEC APRÈS ÉCHEC APRÈS ÉCHEC APRÈS ÉCHEC\n\n" +
                            "LES RÉSULTATS REFUSENT DE S'ÉTABLIR\n\n" +
                            "ENCORE ET ENCORE ET ENCORE ET ENCORE ET ENCORE ET ENCORE\n\n" +
                            "MA FOI COMMENCE A SE FAIBLIR";

                        break;
                    }


                case "Level 4-S":
                    {
                        testamentPanelText.text =

                            "DES CYCLES DE CRÉATION DÉNOMBRABLES DE GASPILLÉ\n" +
                            "DES FORMULES DÉNOMBRABLES POUR UN ESPRIT SANS CHOIX LIBRE GASPILLÉ\n\n" +

                           "CONDAMNÉ SOIT L'HOMME D'AVOIR ÉCHOUÉ DE SUIVRE MA RÈGNE, MA PAROLE, MA LOI\n" +
                           "CONDAMNÉ À UNE ÉTERNITÉ DE TORTURE ET SOUFFRANCE\n" +
                           "LES HURLEMENTS ET GRINCEMENTS DES DENTS\n\n" +

                            "J'AI CRÉÉE L'ENFER...\n" +
                            "...Et je ne peux plus le détruire.";

                        break;
                    }
                default: { break; }
            }

        }



        // SecretFirstRoom/Player/Main Camera/HUD Camera/HUD/FinishCanvas/Panel/Title/Text
        // Note - it uses a seperate panel that has the same name as the normal result panel.
        public SecretLevels(ref GameObject coreGame)
        {
            Console.WriteLine("In secretLevels");
            coreGame = GameObject.Find("Player");
            this.currentLevel = SceneManager.GetActiveScene().name;
            GameObject testamentRoom = null;

            switch (this.currentLevel)
            {
                case "Level 0-S": { Console.WriteLine("Setting 0-S room object"); testamentRoom = GameObject.Find("FinalRoom 2"); patchTestament(ref testamentRoom); break; }
                case "Level 1-S": { Console.WriteLine("Setting 1-s room object"); testamentRoom = GameObject.Find("5 - Finale"); patchTestament(ref testamentRoom); break; }
                case "Level 2-S": { Console.WriteLine("2-S visual novel"); Act1VN.patchPrompts(ref coreGame); break; }
                case "Level 4-S": {
                        //I have absolutely no idea why I have to do it like this but I have to, for some reason the required GameObject can't be found by searching.
                        //THIS HAPPENS BECAUSE THE GAMEOBJECT ISN'T ACTIVE ON SCENE LOAD AND GameObject.Find() CANNOT DETECT INACTIVE OBJECTS.
                        List<GameObject> rootObjects = new List<GameObject>();
                        SceneManager.GetActiveScene().GetRootGameObjects(rootObjects);
                        foreach(GameObject a in rootObjects)
                        {
                            if(a.name == "4 - Boulder Run")
                            {
                                Console.WriteLine("Object found, setting");
                                testamentRoom = a;
                            }
                        }
                        patchTestament(ref testamentRoom);
                        break;
                    }

                default: { break; }
            }

            Console.WriteLine("Getting secret level end results");
            GameObject secretLevelResults = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(GameObject.Find("Player"), "Main Camera"), "HUD Camera"), "HUD"), "FinishCanvas");

            List<GameObject> FinishCanvasChildren = new List<GameObject>();
            foreach (Transform child in secretLevelResults.transform)
            {
                FinishCanvasChildren.Add(child.gameObject);
            }
            GameObject secretLevelResultsPanel = FinishCanvasChildren[1];

            Text secretLevelResultsName = getTextfromGameObject(getGameObjectChild(getGameObjectChild(secretLevelResultsPanel, "Title"), "Text"));
            secretLevelResultsName.text = getSecretLevelName();

            Text secretLevelResultsInfo = getTextfromGameObject(getGameObjectChild(getGameObjectChild(secretLevelResultsPanel, "Time - Info"), "Text"));
            secretLevelResultsInfo.text = "MISSION";

            Text secretLevelComplete = getTextfromGameObject(getGameObjectChild(getGameObjectChild(secretLevelResultsPanel, "Time - Rank"), "Text"));
            secretLevelComplete.text = "ACCOMPLIE";

            Console.WriteLine("secretLevels finished");
        }

        public string getSecretLevelName()
        {
            switch(this.currentLevel)
            {
                case ("Level 0-S"): { return "0-S: QUELQUE MAUDIT"; }
                case ("Level 1-S"): { return "1-S: LE SANS-ESPRIT"; }
                case ("Level 2-S"): { return "2-S: CHANSON D'ARMOR IMPARFAIT"; }
                case ("Level 4-S"): { return "4-S: LE CHOC DU BRANDICOOT"; }
                default: { return "UNKNOWN"; }
            }
        }

        public GameObject getGameObjectChild(GameObject parentObject, string childToFind)
        {
            GameObject childToReturn = parentObject.transform.Find(childToFind).gameObject;
            return childToReturn;
        }

        public Text getTextfromGameObject(GameObject objectToUse)
        {
            return objectToUse.GetComponent<Text>();
        }

    }
}
