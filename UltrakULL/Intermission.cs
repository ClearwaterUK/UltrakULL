using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    class Intermission
    {
        public Intermission(ref GameObject level, JsonParser language)
        {
            level = GameObject.Find("Canvas");
            GameObject intermissionObject = getGameObjectChild(getGameObjectChild(level, "PowerUpVignette"), "Panel");

            Console.WriteLine("IntermissionObject:" + intermissionObject.name);

            //Two I need to patch: Foreground and background shadow.
            Text toBeContinued = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(intermissionObject, "Panel (1)"), "Text"), "Text (1)"));
            toBeContinued.text = language.currentLanguage.intermission.act1_intermission_tobecontinued;

            Text tobeContinuedShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(intermissionObject, "Panel (1)"), "Text"));
            tobeContinuedShadow.text = language.currentLanguage.intermission.act1_intermission_tobecontinuedshadow;

            GameObject Act1EndObject = getGameObjectChild(getGameObjectChild(intermissionObject, "Act End Message"),"Sound 1");

            Text Act1EndText = getTextfromGameObject(getGameObjectChild(Act1EndObject, "Text"));
            Act1EndText.text = language.currentLanguage.intermission.act1_intermission_endof + "\n\n" + language.currentLanguage.intermission.act1_intermission_insertAct2;

            //here
            Text Act1EndMenu = getTextfromGameObject(getGameObjectChild(getGameObjectChild(Act1EndObject, "Menu"),"Text"));
            Act1EndMenu.text = language.currentLanguage.intermission.act1_intermission_returnToMenu;

            Text Act1EndInsert = getTextfromGameObject(getGameObjectChild(getGameObjectChild(Act1EndObject, "Insert"),"Text"));
            Act1EndInsert.text = language.currentLanguage.intermission.act1_intermission_insert;
        }


    }
}
