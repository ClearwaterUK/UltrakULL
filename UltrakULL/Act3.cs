using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UltrakULL.audio;
using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL
{
    public static class Act3
    {
        private static void PatchHellmap(ref GameObject canvasObj)
        {
            GameObject hellMapObject = GetGameObjectChild(GetGameObjectChild(canvasObj, "Hellmap"),"Hellmap Act 3");
            TextMeshProUGUI hellmapViolence = GetTextMeshProUGUI(GetGameObjectChild(hellMapObject, "Text"));
            hellmapViolence.text = LanguageManager.CurrentLanguage.misc.hellmap_violence;

            TextMeshProUGUI hellmapFraud = GetTextMeshProUGUI(GetGameObjectChild(hellMapObject, "Text (1)"));
            hellmapFraud.text = LanguageManager.CurrentLanguage.misc.hellmap_fraud;

            TextMeshProUGUI hellmapTreachery = GetTextMeshProUGUI(GetGameObjectChild(hellMapObject, "Text (2)"));
            hellmapTreachery.text = LanguageManager.CurrentLanguage.misc.hellmap_treachery;
        }
    
        public static void PatchAct3(ref GameObject canvasObj)
        {
            string currentLevel = GetCurrentSceneName();
            string levelName = Act3Strings.GetLevelName();
            string levelChallenge = Act3Strings.GetLevelChallenge(currentLevel);
            
            PatchResultsScreen(levelName, levelChallenge);
            PatchHellmap(ref canvasObj);

            //7-2 has 3 panels, they get all patched here
            if (currentLevel.Contains("7-2")) {
                
                    //Panel that controls the 4 gates in the inside section
                GameObject fourGatesControl = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Other Interiors"),"9 - Tram Station"),"9 Stuff(Clone)"),"9A"),"PuzzleScreen"), "Canvas");

                TextMeshProUGUI gatesControlTitle = GetTextMeshProUGUI(GetGameObjectChild(fourGatesControl, "Text (TMP) (1)"));
                //First Button
                TextMeshProUGUI gatesControlButtonOpen1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(fourGatesControl, "Button A"), "On"), "Text");
                TextMeshProUGUI gatesControlButtonClosed1 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(fourGatesControl, "Button A"), "Off"), "Text");
                //Second Button
                TextMeshProUGUI gatesControlButtonOpen2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(fourGatesControl, "Button B"), "On"), "Text");
                TextMeshProUGUI gatesControlButtonClosed2 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(fourGatesControl, "Button B"), "Off"), "Text");
                //Third Button
                TextMeshProUGUI gatesControlButtonOpen3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(fourGatesControl, "Button C"), "On"), "Text");
                TextMeshProUGUI gatesControlButtonClosed3 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(fourGatesControl, "Button C"), "Off"), "Text");
                //Fourth Button
                TextMeshProUGUI gatesControlButtonOpen4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(fourGatesControl, "Button D"), "On"), "Text");
                TextMeshProUGUI gatesControlButtonClosed4 = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(fourGatesControl, "Button D"), "Off"), "Text");

                gatesControlTitle.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlTitle;

                gatesControlButtonOpen1.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlOpen;
                gatesControlButtonClosed1.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlClosed;
                gatesControlButtonOpen2.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlOpen;
                gatesControlButtonClosed2.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlClosed;
                gatesControlButtonOpen3.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlOpen;
                gatesControlButtonClosed3.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlClosed;
                gatesControlButtonOpen4.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlOpen;
                gatesControlButtonClosed4.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlClosed;


                    //That one panel to lift the cart blocker
                GameObject cartGateControl = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Outdoors"),"10 - Ambush Station"),"10 Nonstuff"),"UsableScreen"),"PuzzleScreen (1)"), "Canvas");
                TextMeshProUGUI cartGateControlTitle = GetTextMeshProUGUI(cartGateControl, "Text (TMP)");
                TextMeshProUGUI cartGateControlOpen = GetTextMeshProUGUI(GetGameObjectChild(cartGateControl, "Button (Open)"), "Text (TMP)");
                TextMeshProUGUI cartGateControlClosed = GetTextMeshProUGUI(GetGameObjectChild(cartGateControl, "Button (Closed)"), "Text (TMP)");
                
                cartGateControlTitle.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_cartGateControlTitle;
                cartGateControlOpen.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_cartGateControlOpen;
                cartGateControlClosed.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_cartGateControlClosed;

                
                    //Payload panel (fuckin' finland container)
                GameObject payloadControl = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetInactiveRootObject("Outdoors"),"11 - Bomb Station"),"11 Nonstuff"),"Bomb Mechanisms"),"UsableScreen (1)"),"PuzzleScreen (1)"),"Canvas");
                TextMeshProUGUI payloadControlLower = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(payloadControl, "UsableButtons"), "Button (Closed)"), "Text (TMP)");
                TextMeshProUGUI payloadControlWait = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(payloadControl, "UsableButtons"), "Button (Open)"), "Text (TMP)");
                TextMeshProUGUI payloadControlEmpty = GetTextMeshProUGUI(GetGameObjectChild(payloadControl, "Button (Done)"), "Text (TMP)");
                
                payloadControlTitle.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_payloadControlTitle;
                payloadControlLower.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_payloadControlLower;
                payloadControlWait.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_payloadControlWait;
                payloadControlEmpty.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_payloadControlEmpty;
            }
                                                                         
            //You're the star of the show now, baby!
            else if (currentLevel.Contains("7-3")) {
                GameObject secretScreenArea = GetGameObjectChild(GetInactiveRootObject("Main Section"), "8 - Upper Garden Battlefield");
                GameObject secretScreen = GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(secretScreenArea, "8 Stuff(Clone)"), "Destructible Tunnel"), "Puzzle Screen"), "Canvas");

                TextMeshProUGUI becomeMarked = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(secretScreen, "PreActivation"), "Text (TMP) (1)"));
                TextMeshProUGUI becomeMarkedButton = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(secretScreen, "PreActivation"), "Button A"), "On"), "Text"));
                TextMeshProUGUI becomeMarkedButtonClosed = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(secretScreen, "PreActivation"), "Button A"), "Off"), "Text"));
                TextMeshProUGUI starOfTheShow = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(secretScreen, "PostActivation"), "Text (TMP) (1)"));

                becomeMarked.text = LanguageManager.CurrentLanguage.act3.act3_violenceThird_becomeMarked;
                becomeMarkedButton.text = LanguageManager.CurrentLanguage.act3.act3_violenceThird_becomeMarkedButton;
                becomeMarkedButtonClosed.text = LanguageManager.CurrentLanguage.act3.act3_violenceThird_becomeMarkedButtonClosed;
                starOfTheShow.text = LanguageManager.CurrentLanguage.act3.act3_violenceThird_starOfTheShow;
            }
            
            //7-4 Flooding and Countdown
            else if (currentLevel.Contains("7-4")) {
                //Flooding warning
                GameObject floodingWarnText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(canvasObj, "Warning"), "Text (TMP)"));
                floodingWarnText.text = LanguageManager.CurrentLanguage.act3.act3_floodingWarning;

                //Countdown title before blowing up
                GameObject countdownTitleText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(canvasObj, "Countdown"), "Text (TMP)"));
                countdownTitleText.text = LanguageManager.CurrentLanguage.act3.act3_countdownTitle;
            }
        }
    }
}
}
