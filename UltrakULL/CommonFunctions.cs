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
        public static ColorBlock UKButtonColors = new ColorBlock()
        {
            normalColor = new Color(0, 0, 0, 0.512f),
            highlightedColor = new Color(1, 1, 1, 0.502f),
            pressedColor = new Color(1, 0, 0, 1),
            selectedColor = new Color(0, 0, 0, 0.512f),
            disabledColor = new Color(0.7843f, 0.7843f, 0.7843f, 0.502f),
            colorMultiplier = 1f,
            fadeDuration = 0.1f
        };



        public static BepInEx.Logging.ManualLogSource modLogger = BepInEx.Logging.Logger.CreateLogSource("modLogger");

        public static void handleError(Exception e, string missingID = "")
        {
            modLogger.LogError("Could not load string. THIS POSSIBLY MEANS THERE ARE MISSING/NONEXISTANT STRINGS IN THE JSON!");
        }

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

            GameObject coreGame = GameObject.Find("Player");

            GameObject resultsPanel = getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(coreGame, "Main Camera"), "HUD Camera"), "HUD"), "FinishCanvas"), "Panel");

            Console.WriteLine("resultsPanel name: " + resultsPanel.name);

            //Level title
            GameObject resultsTitle = getGameObjectChild(resultsPanel, "Title");
            Text resultsTitleLevelName = getTextfromGameObject(getGameObjectChild(resultsTitle, "Text"));
            resultsTitleLevelName.text = levelName;

            //Disable the levelFinderComponent, so the level name doesn't get reverted when the results panel appears.
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
    }
}
