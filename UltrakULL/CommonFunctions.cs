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
using UltrakULL.json;

namespace UltrakULL
{
    public static class CommonFunctions
    {

        public static GameObject getInactiveRootObject(string objectName)
        {

            List<GameObject> rootList = new List<GameObject>();
            SceneManager.GetActiveScene().GetRootGameObjects(rootList);
            foreach (GameObject child in rootList)
            {
                if (child.name == objectName)
                {
                    return child;
                }
            }
            return null;
        }


        public static void patchResultsScreen(string name, string challenge, JsonParser language)
        {
            string levelName = name;
            string levelChallenge = challenge;

            Console.WriteLine("LevelName:" + name);
            Console.WriteLine("LevelChallenge:" + challenge);

            GameObject coreGame = GameObject.Find("Player");

            GameObject resultsPanel = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(coreGame, "Main Camera"), "HUD Camera"), "HUD"), "FinishCanvas"), "Panel");

            Console.WriteLine("resultsPanel name: " + resultsPanel.name);

            //Level title
            GameObject resultsTitle = getGameObjectChild(resultsPanel, "Title");
            Text resultsTitleLevelName = getTextfromGameObject(getGameObjectChild(resultsTitle, "Text"));
            resultsTitleLevelName.text = levelName;

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
            timeTitleText.text = language.currentLanguage.misc.stats_time;

            //Kills
            GameObject killsTitle = getGameObjectChild(resultsPanel, "Kills - Info");
            Text killsTitleText = getTextfromGameObject(getGameObjectChild(killsTitle, "Text"));
            killsTitleText.text = language.currentLanguage.misc.stats_kills;

            //Style
            GameObject styleTitle = getGameObjectChild(resultsPanel, "Style - Info");
            Text styleTitleText = getTextfromGameObject(getGameObjectChild(styleTitle, "Text"));
            styleTitleText.text = language.currentLanguage.misc.stats_style;

            //Secrets
            GameObject secretsTitle = getGameObjectChild(resultsPanel, "Secrets -  Title");
            Text secretsTitleText = getTextfromGameObject(getGameObjectChild(secretsTitle, "Text"));
            secretsTitleText.text = language.currentLanguage.misc.stats_secrets;

            //Challenge title
            GameObject challengeTitle = getGameObjectChild(resultsPanel, "Challenge - Title");
            Text challengeTitleText = getTextfromGameObject(getGameObjectChild(challengeTitle, "Text"));
            challengeTitleText.text = language.currentLanguage.misc.stats_challenge;

            //Challenge description
            GameObject challengeDescription = getGameObjectChild(resultsPanel, "Challenge");
            Text challengeDescriptionText = getTextfromGameObject(getGameObjectChild(challengeDescription, "Text"));
            challengeDescriptionText.text = levelChallenge;
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

        public static List<GameObject> getgameObjectChildren(GameObject objectToUse)
        {
            Console.WriteLine("Using: " + objectToUse.name);
            List<GameObject> Children = new List<GameObject>();
            foreach (Transform child in objectToUse.transform)
            {
                Children.Add(child.gameObject);
            }
            return Children;
        }
    }
}
