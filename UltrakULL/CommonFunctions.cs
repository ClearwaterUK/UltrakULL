using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UltrakULL.json;

namespace UltrakULL
{
    public static class CommonFunctions
    {
        public static ColorBlock ukButtonColors = new ColorBlock()
        {
            normalColor = new Color(0, 0, 0, 0.512f),
            highlightedColor = new Color(1, 1, 1, 0.502f),
            pressedColor = new Color(1, 0, 0, 1),
            selectedColor = new Color(0, 0, 0, 0.512f),
            disabledColor = new Color(0.7843f, 0.7843f, 0.7843f, 0.502f),
            colorMultiplier = 1f,
            fadeDuration = 0.1f
        };
        
        public static string previousHudMessage;
        
        public static IEnumerator WaitforSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }

        public static void HandleError(Exception e, string missingID = "")
        {  
            Console.WriteLine(e.ToString());
        }

        public static GameObject GetInactiveRootObject(string objectName)
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

        public static void PatchResultsScreen(string name, string challenge)
        {
            string levelName = name;
            string levelChallenge = challenge;

            GameObject coreGame = GameObject.Find("Player");

            GameObject resultsPanel = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(coreGame, "Main Camera"), "HUD Camera"), "HUD"), "FinishCanvas"), "Panel"); // What happened here?

            //Level title
            GameObject resultsTitle = GetGameObjectChild(resultsPanel, "Title");
            Text resultsTitleLevelName = GetTextfromGameObject(GetGameObjectChild(resultsTitle, "Text"));
            resultsTitleLevelName.text = levelName;

            //Disable the levelFinderComponent, so the level name doesn't get reverted when the results panel appears.
            LevelNameFinder finder = resultsTitleLevelName.GetComponent<LevelNameFinder>();

            if (finder != null)
            {
                finder.enabled = false;
            }

            //Time
            //For some bizzare reason, the timer is labelled as "ff". Hakita were you cutting corners? :D
            GameObject timeTitle = GetGameObjectChild(resultsPanel, "ff");
            Text timeTitleText = GetTextfromGameObject(GetGameObjectChild(timeTitle, "Text"));
            timeTitleText.text = LanguageManager.CurrentLanguage.misc.stats_time;

            //Kills
            GameObject killsTitle = GetGameObjectChild(resultsPanel, "Kills - Info");
            Text killsTitleText = GetTextfromGameObject(GetGameObjectChild(killsTitle, "Text"));
            killsTitleText.text = LanguageManager.CurrentLanguage.misc.stats_kills;

            //Style
            GameObject styleTitle = GetGameObjectChild(resultsPanel, "Style - Info");
            Text styleTitleText = GetTextfromGameObject(GetGameObjectChild(styleTitle, "Text"));
            styleTitleText.text = LanguageManager.CurrentLanguage.misc.stats_style;

            //Secrets
            GameObject secretsTitle = GetGameObjectChild(resultsPanel, "Secrets -  Title");
            Text secretsTitleText = GetTextfromGameObject(GetGameObjectChild(secretsTitle, "Text"));
            secretsTitleText.text = LanguageManager.CurrentLanguage.misc.stats_secrets;

            //Challenge title
            GameObject challengeTitle = GetGameObjectChild(resultsPanel, "Challenge - Title");
            Text challengeTitleText = GetTextfromGameObject(GetGameObjectChild(challengeTitle, "Text"));
            challengeTitleText.text = LanguageManager.CurrentLanguage.misc.stats_challenge;

            //Challenge description
            GameObject challengeDescription = GetGameObjectChild(resultsPanel, "Challenge");
            Text challengeDescriptionText = GetTextfromGameObject(GetGameObjectChild(challengeDescription, "Text"));
            challengeDescriptionText.text = levelChallenge;

            //Total points
            Text totalPointsText = GetTextfromGameObject(GetGameObjectChild(GetGameObjectChild(resultsPanel, "Total Points"),"Text (1)"));
            totalPointsText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_total + ":";
        }


        public static GameObject GetGameObjectChild(GameObject parentObject, string childToFind) // Why does this exist if we're just doing a single function call? 
        {
            GameObject childToReturn = parentObject.transform.Find(childToFind).gameObject;
            return childToReturn;
        }
        public static Text GetTextfromGameObject(GameObject objectToUse)
        {
            return objectToUse.GetComponent<Text>();
        }
    }
}
