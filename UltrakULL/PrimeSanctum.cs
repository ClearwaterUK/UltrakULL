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

        public void patchSecretText(PrimeSanctumStrings strings)
        {
            GameObject bossRoom = getInactiveRootObject("3 - Fuckatorium");

            Text secretText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(getGameObjectChild(bossRoom, "3 Stuff"),"End"),"FinalRoom Prime"),"Testament Shop"),"Canvas"),"Border"),"TipBox"),"Panel"),"Scroll View"),"Viewport"),"Content"),"Text (1)"));
            secretText.fontSize = 18;
            secretText.text = strings.getSecretText();
        }

        public PrimeSanctum(ref GameObject level)
        {
            var primeLogger = BepInEx.Logging.Logger.CreateLogSource("PrimeSanctumsPatcher");
            
            this.baseLevelObject = level;
            string currentLevel = SceneManager.GetActiveScene().name;

            if (currentLevel.Contains("P-1"))
            {
                Debug.Log("In P-1");

                Debug.Log("Patching results screen...");
                PrimeSanctumStrings PrimeSanctumChallengeStrings = new PrimeSanctumStrings();
                //this.patchResultsScreen(ref level);
                string levelname = PrimeSanctumChallengeStrings.getLevelName();
                patchResultsScreen(levelname, "");

                Debug.Log("Patching secret text...");
                this.patchSecretText(PrimeSanctumChallengeStrings);
            }
        }
    }
}
