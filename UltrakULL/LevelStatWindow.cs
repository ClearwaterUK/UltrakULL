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

namespace UltrakULL
{
    public class LevelStatWindow
    {
        public static void patchStats()
        {
                GameObject tst = null;
                GameObject canvas = GameObject.Find("Canvas");

                List<GameObject> a = new List<GameObject>();
                SceneManager.GetActiveScene().GetRootGameObjects(a);
                Console.WriteLine(a.Count);
                foreach (GameObject child in a)
                {
                    if (child.name == "Canvas")
                    {
                        tst = child;
                    }
                }

                GameObject levelStatsWindow = getGameObjectChild(getGameObjectChild(tst, "Level Stats Controller"), "Level Stats (1)");
                //Secret levels will only have a timer, or something else.
                Text timeName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Time Title"));
                timeName.text = "TEMPS:";

                Text killsName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Kills Title"));
                killsName.text = "TUES:";

                Text styleName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Style Title"));
                styleName.text = "STYLE:";

                Text secretsName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Secrets Title"));
                secretsName.text = "SÈCRETS:";

                Text challengesName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Challenge Title"));
                challengesName.text = "DÉFI:";

                Text assistsName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Assists Title"));
                assistsName.text = "ASS. MAJ.:";

                if(SceneManager.GetActiveScene().name == "Level 4-S")
                {
                    Text cratesName = getTextfromGameObject(getGameObjectChild(levelStatsWindow, "Crates Counter"));
                    cratesName.text = "BOÎTES:";
                }
        }

        public LevelStatWindow(ref GameObject coreGame)
        {
            patchStats();
        }


    }
}
