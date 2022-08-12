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

    class PrimeSanctum
    {
        public GameObject baseLevelObject;


        public GameObject getGameObjectChild(GameObject parentObject, string childToFind)
        {
            GameObject childToReturn = parentObject.transform.Find(childToFind).gameObject;
            return childToReturn;
        }

        public Text getTextfromGameObject(GameObject objectToUse)
        {
            return objectToUse.GetComponent<Text>();
        }


        public void patchResultsScreen(ref GameObject coreGame)
        {
            PrimeSanctumStrings PrimeSanctumChallengeStrings = new PrimeSanctumStrings();

            Console.WriteLine("In patchResultsScreen, trying to patch level name on results screen...");

            coreGame = GameObject.Find("Player");

            GameObject resultsPanel = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(coreGame, "Main Camera"), "HUD Camera"), "HUD"), "FinishCanvas"), "Panel");

            Console.WriteLine("resultsPanel name: " + resultsPanel.name);

            //Level title
            GameObject resultsTitle = getGameObjectChild(resultsPanel, "Title");
            Text resultsTitleLevelName = getTextfromGameObject(getGameObjectChild(resultsTitle, "Text"));
            resultsTitleLevelName.text = PrimeSanctumChallengeStrings.getLevelName();

            //Disable the levelFinderComponent, so the level name doesn't get reverted when the results panel appears.
            Console.WriteLine("Disabling levelNameFinder component...");
            LevelNameFinder finder = resultsTitleLevelName.GetComponent<LevelNameFinder>();

            if (finder != null)
            {
                Console.WriteLine(finder.name);
                finder.enabled = false;
            }

            //Time
            //For some bizzare reason, the timer is labelled as "ff". Hakita were you cutting corners? :D
            GameObject timeTitle = getGameObjectChild(resultsPanel, "ff");
            Text timeTitleText = getTextfromGameObject(getGameObjectChild(timeTitle, "Text"));
            timeTitleText.text = "TEMPS:";

            //Kills
            GameObject killsTitle = getGameObjectChild(resultsPanel, "Kills - Info");
            Text killsTitleText = getTextfromGameObject(getGameObjectChild(killsTitle, "Text"));
            killsTitleText.text = "TUES:";

            //Style
            GameObject styleTitle = getGameObjectChild(resultsPanel, "Style - Info");
            Text styleTitleText = getTextfromGameObject(getGameObjectChild(styleTitle, "Text"));
            styleTitleText.text = "STYLE:";

            //Secrets
            GameObject secretsTitle = getGameObjectChild(resultsPanel, "Secrets -  Title");
            Text secretsTitleText = getTextfromGameObject(getGameObjectChild(secretsTitle, "Text"));
            secretsTitleText.text = "SECRÈTS";

            //Challenge title
            GameObject challengeTitle = getGameObjectChild(resultsPanel, "Challenge - Title");
            Text challengeTitleText = getTextfromGameObject(getGameObjectChild(challengeTitle, "Text"));
            challengeTitleText.text = "DÉFI";


        }





        public PrimeSanctum(ref GameObject level)
        {
            var primeLogger = BepInEx.Logging.Logger.CreateLogSource("PrimeSanctumsPatcher");
            primeLogger.LogInfo("Now entering prime sanctum class.");

            this.baseLevelObject = level;
            string currentLevel = SceneManager.GetActiveScene().name;

            if (currentLevel.Contains("P-1"))
            {
                primeLogger.LogInfo("In P-1");

                primeLogger.LogInfo("Patching results screen...");
                this.patchResultsScreen(ref level);
            }

        }


    }
}
