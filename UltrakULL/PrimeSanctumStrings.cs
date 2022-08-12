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
    class PrimeSanctumStrings
    {
        public string getLevelName()
        {
            string currentLevel = SceneManager.GetActiveScene().name;

            switch (currentLevel)
            {
                case "Level P-1": { return "P-1 - L'ÂME SURVIVANTE"; }

                default: { return "Unknown level name"; }
            }
        }



    }
}
