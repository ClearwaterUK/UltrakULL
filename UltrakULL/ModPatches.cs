using BepInEx;
using HarmonyLib;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UltrakULL;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using static UltrakULL.CommonFunctions;
using System.Linq;
using UltrakULL.json;

using UMM;

namespace UltrakULL
{
    public static class ModPatches
    {
        public static IEnumerator UltraTweakerPatch()
        {
            yield return new WaitForSeconds(0.5f);

            GameObject languageButton = getGameObjectChild(getGameObjectChild(getInactiveRootObject("Canvas"), "OptionsMenu"),"Language");
            languageButton.transform.localPosition = new Vector3(450, 200, 0);
        }

    }
}
