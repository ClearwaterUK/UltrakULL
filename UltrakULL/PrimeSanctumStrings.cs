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
    class PrimeSanctumStrings
    {
        private string p1SecretText;
        //private string p2SecretText;
        //private string p3SecretText;

        public string getSecretText()
        {
            string currentLevel = SceneManager.GetActiveScene().name;

            switch (currentLevel)
            {
                case "Level P-1": { return this.p1SecretText; }

                default: { return "Unknown secret text"; }
            }
        }

        public string getLevelName(JsonParser language)
        {
            string currentLevel = SceneManager.GetActiveScene().name;

            switch (currentLevel)
            {
                case "Level P-1": { return "P-1 - " + language.currentLanguage.levelNames.levelName_primeFirst; }

                default: { return "Unknown level name"; }
            }
        }

        public PrimeSanctumStrings(JsonParser language)
        {
            this.p1SecretText =
                language.currentLanguage.primeSanctum.primeSanctum_first_secretText1 + "\n"
                + language.currentLanguage.primeSanctum.primeSanctum_first_secretText2 + "\n\n"
                + language.currentLanguage.primeSanctum.primeSanctum_first_secretText3 + "\n\n"
                + language.currentLanguage.primeSanctum.primeSanctum_first_secretText4 + "\n\n"
                + language.currentLanguage.primeSanctum.primeSanctum_first_secretText5 + "\n"
                + language.currentLanguage.primeSanctum.primeSanctum_first_secretText6 + "\n\n"
                + language.currentLanguage.primeSanctum.primeSanctum_first_secretText7 + "\n\n"
                + language.currentLanguage.primeSanctum.primeSanctum_first_secretText8 + "\n\n"
                + language.currentLanguage.primeSanctum.primeSanctum_first_secretText9;
        }
    }
}
