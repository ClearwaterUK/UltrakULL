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
using static UltrakULL.CommonFunctions;
using UltrakULL.json;


namespace UltrakULL
{
    class PrimeSanctum
    {
        public GameObject baseLevelObject;
        public Text secretText = null;

        public void patchSecretText(PrimeSanctumStrings strings, JsonParser language)
        {
            GameObject baseObj = null;

            //I hate having to do it like this...
            List<GameObject> a = new List<GameObject>();
            SceneManager.GetActiveScene().GetRootGameObjects(a);
            Console.WriteLine(a.Count);
            foreach (GameObject child in a)
            {
                if (child.name == "3 - Fuckatorium")
                {
                    baseObj = child;
                }
            }

            Text secretText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(baseObj, "3 Stuff"),"End"),"FinalRoom Prime"),"Testament Shop"),"Canvas"),"Border"),"TipBox"),"Panel"),"Scroll View"),"Viewport"),"Content"),"Text (1)"));
            Console.WriteLine(secretText.text);
            secretText.fontSize = 18;
            secretText.text = strings.getSecretText();
        }

        public PrimeSanctum(ref GameObject level,JsonParser language)
        {
            var primeLogger = BepInEx.Logging.Logger.CreateLogSource("PrimeSanctumsPatcher");
            primeLogger.LogInfo("Now entering prime sanctum class.");
            
            this.baseLevelObject = level;
            string currentLevel = SceneManager.GetActiveScene().name;

            if (currentLevel.Contains("P-1"))
            {
                primeLogger.LogInfo("In P-1");

                primeLogger.LogInfo("Patching results screen...");
                PrimeSanctumStrings PrimeSanctumChallengeStrings = new PrimeSanctumStrings(language);
                //this.patchResultsScreen(ref level);
                string levelname = PrimeSanctumChallengeStrings.getLevelName(language);
                patchResultsScreen(levelname, "", language);

                primeLogger.LogInfo("Patching secret text...");
                this.patchSecretText(PrimeSanctumChallengeStrings, language);
            }
        }
    }
}
