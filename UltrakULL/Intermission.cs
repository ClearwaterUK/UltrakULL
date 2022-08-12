using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    class Intermission
    {

        public Intermission(ref GameObject level)
        {
            level = GameObject.Find("Canvas");
            GameObject intermissionObject = getGameObjectChild(getGameObjectChild(level, "PowerUpVignette"), "Panel");

            Console.WriteLine("IntermissionObject:" + intermissionObject.name);

            //Two I need to patch: Foreground and background shadow.
            Text toBeContinued = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(intermissionObject, "Panel (1)"), "Text"), "Text (1)"));
            toBeContinued.text = "À SUIVRE DANS ACTE II: <color=red>LA HAINE IMPARFAIT</color>";

            Text tobeContinuedShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(intermissionObject, "Panel (1)"), "Text"));
            tobeContinuedShadow.text = "À SUIVRE DANS ACTE II: LA HAINE IMPARFAIT";

            GameObject Act1EndObject = getGameObjectChild(getGameObjectChild(intermissionObject, "Act End Message"),"Sound 1");

            Text Act1EndText = getTextfromGameObject(getGameObjectChild(Act1EndObject, "Text"));
            Act1EndText.text =
                "ACTE I TERMINÉ\n\n"
                + "INSÈREZ DISQUE 2 pour\n \"ACTE II: LA HAINE IMPARFAIT\"";

            //here
            Text Act1EndMenu = getTextfromGameObject(getGameObjectChild(getGameObjectChild(Act1EndObject, "Menu"),"Text"));
            Act1EndMenu.text = "RETOURNEZ AU MENU";

            Text Act1EndInsert = getTextfromGameObject(getGameObjectChild(getGameObjectChild(Act1EndObject, "Insert"),"Text"));
            Act1EndInsert.text = "INSÈRER";


        }


    }
}
