using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    public class Intermission
    {
        public void act1Int(ref GameObject level, GameObject intermissionObject)
        {
            //ACT 1
            //Two I need to patch: Foreground and background shadow.
            Text toBeContinued = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(intermissionObject, "Panel (1)"), "Text"), "Text (1)"));
            toBeContinued.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_tobecontinued;

            Text tobeContinuedShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(intermissionObject, "Panel (1)"), "Text"));
            tobeContinuedShadow.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_tobecontinuedshadow;

            GameObject Act1EndObject = getGameObjectChild(getGameObjectChild(intermissionObject, "Act End Message"), "Sound 1");

            Text Act1EndText = getTextfromGameObject(getGameObjectChild(Act1EndObject, "Text"));
            Act1EndText.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_endof + "\n\n" + LanguageManager.CurrentLanguage.intermission.act1_intermission_insertAct2;

            //here
            Text Act1EndMenu = getTextfromGameObject(getGameObjectChild(getGameObjectChild(Act1EndObject, "Menu"), "Text"));
            Act1EndMenu.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_returnToMenu;

            Text Act1EndInsert = getTextfromGameObject(getGameObjectChild(getGameObjectChild(Act1EndObject, "Insert"), "Text"));
            Act1EndInsert.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_insert;
        }

        public void act2Int(ref GameObject level, GameObject intermissionObject)
        {
            Text toBeContinued = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(intermissionObject, "Panel (1)"), "Text"), "Text (1)"));
            toBeContinued.text = LanguageManager.CurrentLanguage.intermission.act2_intermission_tobecontinued;

            Text tobeContinuedShadow = getTextfromGameObject(getGameObjectChild(getGameObjectChild(intermissionObject, "Panel (1)"), "Text"));
            tobeContinuedShadow.text = LanguageManager.CurrentLanguage.intermission.act2_intermission_tobecontinuedshadow;

            GameObject earlyAccessEnd = getGameObjectChild(intermissionObject, "Early Access End Screen");
            if(earlyAccessEnd != null)
            {
                Text earlyAccessEndText = getTextfromGameObject(getGameObjectChild(earlyAccessEnd, "Text"));

                earlyAccessEndText.text =
                    "<size=48><b>" + LanguageManager.CurrentLanguage.misc.earlyAccessEnd1 + "</b></size>" + "\n\n"
                    + LanguageManager.CurrentLanguage.misc.earlyAccessEnd2 + "\n\n"
                    + LanguageManager.CurrentLanguage.misc.earlyAccessEnd3;

                Text earlyAccessQuitToMenu = getTextfromGameObject(getGameObjectChild(getGameObjectChild(earlyAccessEnd, "Quit Mission"),"Text"));
                earlyAccessQuitToMenu.text = LanguageManager.CurrentLanguage.intermission.act1_intermission_returnToMenu;

            }
        }

        public Intermission(ref GameObject level)
        {
            level = getInactiveRootObject("Canvas");
            GameObject intermissionObject = getGameObjectChild(getGameObjectChild(level, "PowerUpVignette"), "Panel");

            string levelName = SceneManager.GetActiveScene().name;

            switch (levelName)
            {
                case "Intermission1": { act1Int(ref level,intermissionObject);  break; }
                case "Intermission2": { act2Int(ref level, intermissionObject);  break; }
                default: { break; }
            }
        }
    }
}
