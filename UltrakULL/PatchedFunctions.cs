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
using UltrakULL.json;
using System.Linq;

namespace UltrakULL
{
    class PatchedFunctions
    {
        public PatchedFunctions(JsonParser json)
        {
            language = json;
        }

        private static JsonParser language;

        public static bool doneWithDots = false;
        public static bool waitingForInput = false;

        public static HudMessage currentTimedMessage;
        public static Image currentTimedMessageImg;
        public static Text currentTimedMessageText;
        public static bool currentTimedMessageActivated;

        public static Discord.Activity rankCachedActivity;

        public static StatsManager cachedStatsManager;
        public static bool cachedStatsReady;

        //@Override
        //Overrides ScanBook from the ScanningStuff class. Used to translate books found in some levels.
        public static bool ScanBook_MyPatch(string text, bool noScan, int instanceId, ScanningStuff __instance, Text ___readingText, int ___currentBookId, GameObject ___scanningPanel, GameObject ___readingPanel, bool ___scanning)
        {
            __instance.oldWeaponState = !MonoSingleton<GunControl>.Instance.noWeapons;
            MonoSingleton<GunControl>.Instance.NoWeapon();

            ___readingText.text = Books.getBookText(language);
            ___currentBookId = instanceId;
            ___scanningPanel.SetActive(false);
            ___readingPanel.SetActive(true);
            ___scanning = false;

            return false;
        }


        //@Override
        //Overrides Check from the vanilla game. Used for persistant difficulty strings across all scenes.
        public static bool Check_MyPatch(DifficultyTitle __instance, Text ___txt)
            {
                int @int = MonoSingleton<PrefsManager>.Instance.GetInt("difficulty", 0);
                MonoBehaviour mono = new MonoBehaviour();

                if (___txt == null)
                {
                    ___txt = __instance.GetComponent<Text>();
                }
                ___txt.text = "";

                if (__instance.lines)
                {
                    Text text = ___txt;
                    text.text = "-- ";
                }
                switch (@int)
                {
                    case 0:
                        {
                            Text text2 = ___txt;
                            text2.text += language.currentLanguage.frontend.difficulty_harmless;
                            break;
                        }
                    case 1:
                        {
                            Text text3 = ___txt;
                            text3.text += language.currentLanguage.frontend.difficulty_lenient;
                            break;
                        }
                    case 2:
                        {
                            Text text4 = ___txt;
                            text4.text += language.currentLanguage.frontend.difficulty_standard;
                            break;
                        }
                    case 3:
                        {
                            Text text5 = ___txt;
                            text5.text += language.currentLanguage.frontend.difficulty_violent;
                            break;
                        }
                    case 4:
                        {
                            Text text6 = ___txt;
                            text6.text += language.currentLanguage.frontend.difficulty_brutal;
                            break;
                        }
                    case 5:
                        {
                            Text text7 = ___txt;
                            text7.text += language.currentLanguage.frontend.difficulty_umd;
                            break;
                        }
                }
                if (__instance.lines)
                {
                    Text text8 = ___txt;
                    text8.text += " -- ";
                }
                return false;
            }


        //@Override
        //Overrides checkScore function from the vanilla game. This translates level names, as well as if challenges have been completed or not. POSTFIX.
        public static void CheckScore_MyPatchPostFix(LevelSelectPanel __instance)
        {
            int num = __instance.levelNumber;
            RankData rank = GameProgressSaver.GetRank(num, false);

            LevelNames ln = new LevelNames();
            __instance.transform.Find("Name").GetComponent<Text>().text = ln.getLevelName(num, language); //Level Name

            if (rank.levelNumber == __instance.levelNumber || (__instance.levelNumber == 666 && rank.levelNumber == __instance.levelNumber + __instance.levelNumberInLayer - 1))
            {
                if (__instance.challengeIcon)
                {
                    if (rank.challenge)
                    {
                        __instance.challengeIcon.fillCenter = true;
                        Text componentInChildren2 = __instance.challengeIcon.GetComponentInChildren<Text>();
                        componentInChildren2.text = String.Join(" ", language.currentLanguage.frontend.level_challengeCompleted.ToList()); //Challenge completed
                    }
                    else
                    {
                        __instance.challengeIcon.fillCenter = false;
                        Text componentInChildren3 = __instance.challengeIcon.GetComponentInChildren<Text>();
                        componentInChildren3.text = String.Join(" ", language.currentLanguage.frontend.level_challenge.ToList()); //Challenge not completed
                        componentInChildren3.color = Color.white;
                    }
                }
            }
                return;
        }

        //@Override
        //Overrides the NameAppear function from LevelSelectPopup. This allows changes level names to appear in-game.
        //By extension, showLayer and showName also need to be patched in here, as they're originally private functions.
        public static bool NameAppear_MyPatch(LevelNamePopup __instance, bool ___activated, AudioSource ___aud, string ___layerString, string ___nameString, bool ___fadingOut, Text[] ___layerText, Text[] ___nameText)
        {
            TitleManager titleManager = new TitleManager();

            //Layer string is composed of layer name - level *number*.
            //Example: PRELUDE /// FIRST, LUST /// SECOND, etc
            ___layerString = titleManager.getLayer(___layerString,language);

            ___nameString = titleManager.getName(___nameString,language);

            if (!___activated)
            {
                ___activated = true;
                ___aud.Play();
                __instance.StartCoroutine(showLayer(__instance, ___layerString, ___layerText, ___nameString, ___nameText, ___aud, ___fadingOut));
            }
            return false;
        }

        public static IEnumerator showName(LevelNamePopup instance, string nameString, Text[] nameText, AudioSource aud, bool fadingOut)
        {
            aud.Play();
            int j;
            Text[] array = nameText;
            for (int i = 0; i <= nameString.Length; i = j + 1)
            {
                for (j = 0; j < array.Length; j++)
                {
                    array[j].text = nameString.Substring(0, i);
                }
                yield return new WaitForSeconds(0.001f);
                j = i;
            }
            aud.Stop();
            yield return new WaitForSeconds(0.5f);

            foreach (Text text in nameText)
            {
                text.CrossFadeAlpha(0f, 3.0f, false);
            }

            fadingOut = true;
            yield break;
        }

        public static IEnumerator showLayer(LevelNamePopup instance, string layerString, Text[] layerText, string nameString, Text[] nameText, AudioSource aud, bool fadingOut)
        {
            aud.Play();
            int j;
            for (int i = 0; i <= layerString.Length; i = j + 1)
            {
                Text[] array = layerText;
                for (j = 0; j < array.Length; j++)
                {
                    array[j].text = layerString.Substring(0, i);
                }
                yield return new WaitForSeconds(0.001f);
                j = i;
            }
            aud.Stop();

            yield return new WaitForSeconds(0.5f);

            foreach (Text text in layerText)
            {
                text.CrossFadeAlpha(0f, 2.5f, false);
            }
            instance.StartCoroutine(showName(instance, nameString, nameText, aud, fadingOut));
            yield break;
        }

        //@Override
        //Overrides the Start function from IntroText. This is needed for patched text to appear on the 0-0 tutorial.
        //By extension, TextAppear, PlaceColor and DotsAppear will also need to be patched due to coroutine calls.
        public static bool IntroTextStart_MyPatch(IntroText __instance, Text ___txt, string ___fullString, AudioSource ___aud, StringBuilder ___sb, string ___tempString, bool ___doneWithDots, string ___colorString, bool ___readyToContinue, int ___calibrated, int ___dotsAmount, bool ___waitingForInput, List<int> ___colorsPositions, List<int> ___colorsClosePositions)
        {
            ___txt = __instance.GetComponent<Text>();
            ___aud = __instance.GetComponent<AudioSource>();

            TutorialStrings tutStrings = new TutorialStrings(language);

            //fullString is used twice:
            //once for the first page of the intro, and again for the second page.
            //We can check which page it's on by checking the first letter.
            //If it's B (BOOT UP), then first page, if it's S (STATUS UPDATE), then second page.

            ___fullString = ___txt.text;
            Console.WriteLine(___fullString);

            if (___fullString[0] == 'B')
            {
                ___fullString = tutStrings.introFirstPage;
            }
            else
            {
                ___fullString = tutStrings.introSecondPage;
            }

            __instance.StartCoroutine(TextAppear(__instance, ___fullString, ___sb, ___txt, ___tempString, ___doneWithDots, ___readyToContinue, ___calibrated, ___dotsAmount, ___colorString, ___waitingForInput, ___aud, ___colorsPositions, ___colorsClosePositions));

            return false;
        }

        public static IEnumerator DotsAppear(AudioSource ___aud, Text ___txt, string ___tempString)
        {
            int num;
            for (int i = 0; i < 1; i = num + 1)
            {
                ___txt.text = ___tempString;
                ___aud.Play();
                yield return new WaitForSecondsRealtime(0.25f);
                ___txt.text = ___tempString + ".";
                ___aud.Play();
                yield return new WaitForSecondsRealtime(0.25f);
                ___txt.text = ___tempString + "..";
                ___aud.Play();
                yield return new WaitForSecondsRealtime(0.25f);
                ___txt.text = ___tempString + "...";
                ___aud.Play();
                yield return new WaitForSecondsRealtime(0.25f);
                num = i;
            }
            doneWithDots = true;
            yield break;
        }

        public static void Over(IntroText __instance)
        {
            GameObject[] array = __instance.activateOnEnd;
            for (int i = 0; i < array.Length; i++)
            {
                array[i].SetActive(true);
            }
            array = __instance.deactivateOnEnd;
            for (int i = 0; i < array.Length; i++)
            {
                array[i].SetActive(false);
            }
        }

        public static void PlaceColor(int i, IntroText __instance, StringBuilder ___sb, string ___fullString, string ___colorString, List<int> ___colorsPositions)
        {
            ___colorsPositions.Add(i);
            ___sb = new StringBuilder(___fullString);
            ___sb[i - 1] = ' ';
            ___fullString = ___sb.ToString();
            ___fullString = ___fullString.Insert(i, ___colorString);
        }


        public static IEnumerator TextAppear(IntroText __instance, string ___fullString, StringBuilder ___sb, Text ___txt, string ___tempString, bool ___doneWithDots, bool ___readyToContinue, int ___calibrated, int ___dotsAmount, string ___colorString, bool ___waitingForInput, AudioSource ___aud, List<int> ___colorsPositions, List<int> ___colorsClosePositions)
        {
            int i = ___fullString.Length;
            int j = 0;
            while (j < i + 1)
            {
                //Vanilla code makes a call for fullString.get_Chars(j), but get_Chars doesn't exist in C#, so here's an alternative.
                //Gets the first char of fullString as a char, and removes it via substring.
                char c;
                if (j == 0) { c = ___fullString[j]; }
                else { c = ___fullString[j - 1]; }

                float waitTime = 0.035f;
                bool playSound = true;
                int k;
                if (c <= '@')
                {
                    if (c <= '&')
                    {
                        if (c != ' ')
                        {
                            if (c != '#')
                            {
                                if (c != '&')
                                {
                                    goto IL_82D;
                                }
                                //End of intro text here
                                else if (c == '&')
                                {
                                    __instance.GetComponentInParent<IntroTextController>().introOver = true;
                                    GameProgressSaver.SetIntro(true);
                                    waitTime = 0f;
                                    ___sb = new StringBuilder(___fullString);
                                    ___sb[j - 1] = ' ';
                                    ___fullString = ___sb.ToString();
                                    ___txt.text = ___fullString.Substring(0, j);
                                }
                            }
                            else
                            {
                                // 3 dots segment here
                                ___sb = new StringBuilder(___fullString);
                                ___sb[j - 1] = ' ';
                                ___fullString = ___sb.ToString();
                                ___txt.text = ___fullString.Substring(0, j);
                                ___tempString = ___txt.text;
                                ___doneWithDots = false;
                                doneWithDots = ___doneWithDots;
                                ___dotsAmount = 1;
                                __instance.StartCoroutine(DotsAppear(___aud, ___txt, ___tempString));
                                yield return new WaitUntil(() => doneWithDots);
                                doneWithDots = false;
                            }
                        }
                        else
                        {
                            waitTime = 0f;
                            ___txt.text = ___fullString.Substring(0, j);
                        }
                    }
                    else if (c != '*')
                    {
                        if (c != '+')
                        {
                            if (c != '@')
                            {
                                goto IL_82D;
                            }
                            waitTime = 0f;
                            ___sb = new StringBuilder(___fullString);
                            ___sb[j - 1] = ' ';
                            ___fullString = ___sb.ToString();
                            ___txt.text = ___fullString.Substring(0, j);
                            GameObject[] array = __instance.activateOnTextTrigger;
                            for (k = 0; k < array.Length; k++)
                            {
                                array[k].SetActive(true);
                            }
                        }
                        else
                        {
                            //Lime color here
                            ___sb = new StringBuilder(___fullString);
                            ___sb[j - 1] = ' ';
                            ___fullString = ___sb.ToString();
                            ___colorString = "<color=lime>";
                            PlaceColor(j, __instance, ___sb, ___fullString, ___colorString, ___colorsPositions);
                            ___fullString = ___fullString.Insert(j, ___colorString);

                            j += ___colorString.Length;
                            i += ___colorString.Length;
                            ___txt.text = ___fullString.Substring(0, j);
                        }
                    }
                    else
                    {
                        //Red color here
                        ___sb = new StringBuilder(___fullString);
                        ___sb[j - 1] = ' ';
                        ___fullString = ___sb.ToString();
                        ___colorString = "<color=red>";
                        PlaceColor(j, __instance, ___sb, ___fullString, ___colorString, ___colorsPositions);
                        ___fullString = ___fullString.Insert(j, ___colorString);
                        j += ___colorString.Length;
                        i += ___colorString.Length;
                        ___txt.text = ___fullString.Substring(0, j);
                    }
                }
                else if (c <= '~')
                {
                    if (c != '^')
                    {
                        if (c != '_')
                        {
                            if (c != '~')
                            {
                                goto IL_82D;
                            }

                            //Recalibration prompt
                            Console.WriteLine("~ character, calling Over");
                            waitTime = 0f;
                            ___sb = new StringBuilder(___fullString);
                            ___sb[j - 1] = ' ';
                            ___fullString = ___sb.ToString();
                            ___txt.text = ___fullString.Substring(0, j);
                            Over(__instance);
                        }
                        else
                        {
                            ___colorsClosePositions.Add(j);
                            ___sb = new StringBuilder(___fullString);
                            ___sb[j - 1] = ' ';
                            ___fullString = ___sb.ToString();
                            string text = "</color>";
                            ___fullString = ___fullString.Insert(j, text);
                            j += text.Length;
                            i += text.Length;
                            ___txt.text = ___fullString.Substring(0, j);
                        }
                    }
                    else
                    {
                        ___colorString = "<color=grey>";
                        ___fullString = ___fullString.Insert(j, ___colorString);
                        j += ___colorString.Length;
                        i += ___colorString.Length;
                        ___txt.text = ___fullString.Substring(0, j);
                    }
                }
                else if (c <= '±')
                {
                    if (c != '§')
                    {
                        if (c != '±')
                        {
                            goto IL_82D;
                        }
                        ___colorString = "<color=#4C99E6>";
                        ___fullString = ___fullString.Insert(j, ___colorString);
                        j += ___colorString.Length;
                        i += ___colorString.Length;
                        ___txt.text = ___fullString.Substring(0, j);
                    }
                    else
                    {
                        ___sb = new StringBuilder(___fullString);
                        ___sb[j - 1] = ' ';
                        ___fullString = ___sb.ToString();
                        ___txt.text = ___fullString.Substring(0, j);
                        ___tempString = ___txt.text;
                        ___doneWithDots = false;
                        ___dotsAmount = 2;
                        DotsAppear(___aud, ___txt, ___tempString);
                    }
                }
                else if (c != '½')
                {
                    if (c != '¢') //Was originally an Ä but changed it to prevent conflicts with languages using these characters (German etc)
                    {
                        goto IL_82D;
                    }
                    ___sb = new StringBuilder(___fullString);
                    ___sb[j - 1] = ' ';
                    ___fullString = ___sb.ToString();
                    ___txt.text = ___fullString.Substring(0, j) + "<color=red>ERROR</color>";
                    yield return new WaitForSecondsRealtime(1f);
                    __instance.calibrationWindows[___calibrated].SetActive(true);
                    ___readyToContinue = false;
                    Cursor.lockState = 0;
                    Cursor.visible = true;
                    yield return new WaitUntil(() => ___readyToContinue);
                    Cursor.lockState = (CursorLockMode)1;
                    Cursor.visible = false;
                    ___tempString = "<color=lime>OK</color>";
                    ___fullString = ___fullString.Insert(j, ___tempString);
                    j += ___tempString.Length;
                    i += ___tempString.Length;
                    ___txt.text = ___fullString.Substring(0, j);
                }
                else
                {
                    //Second page of intro
                    ___sb = new StringBuilder(___fullString);
                    ___sb[j - 1] = ' ';
                    ___fullString = ___sb.ToString();
                    playSound = false;
                    waitTime = 0.75f;
                    ___txt.text = ___fullString.Substring(0, j);
                }
            IL_8FA:
                i = ___fullString.Length;
                if (waitTime != 0f && playSound)
                {
                    ___aud.Play();
                }
                if (___colorsPositions.Count > ___colorsClosePositions.Count)
                {
                    Text text2 = ___txt;
                    text2.text += "</color>";
                }
                yield return new WaitForSecondsRealtime(waitTime);
                k = j;
                j = k + 1;
                continue;
            IL_82D:
                ___txt.text = ___fullString.Substring(0, j);
                goto IL_8FA;
            }
            Over(__instance);
            //Add a check to make sure we're on the second page of the intro and don't trigger the level load too early.
            yield break;
            //__instance.GetComponentInParent<IntroTextController>().introOver = true;
        }

        //@Override
        //Overrides the PlayMessage method from the HudMessage class. This is needed for swapping text in message boxes.
        public static bool PlayMessage_MyPatch(HudMessage __instance, bool ___activated, HudMessageReceiver ___messageHud, Text ___text, Image ___img)
        {
            //The HUD display uses 2 kinds of messages.
            //One for messages that displays KeyCode inputs (for controls), and one that doesn't.

            //Get the string table based on the area of the game we're currently in.
            StringsParent lvlStrings = new StringsParent();

            ___activated = true;
            ___messageHud = MonoSingleton<HudMessageReceiver>.Instance;
            ___text = ___messageHud.text;
            if (__instance.input == "")
            {
                string newMessage = lvlStrings.getMessage(__instance.message, __instance.message2, "", language);

                ___text.text = newMessage;
            }
            else
            {
                KeyCode keyCode = MonoSingleton<InputManager>.Instance.Inputs[__instance.input];
                string controlButton;
                if (keyCode == KeyCode.Mouse0)
                {
                    controlButton = language.currentLanguage.misc.controls_leftClick;
                }
                else if (keyCode == KeyCode.Mouse1)
                {
                    controlButton = language.currentLanguage.misc.controls_rightClick;
                }
                else if (keyCode == KeyCode.Mouse2)
                {
                    controlButton = language.currentLanguage.misc.controls_middleClick;
                }
                else
                {
                    controlButton = keyCode.ToString();
                }

                //Messages that get input.
                Console.Write("Input message: " + __instance.message + controlButton + __instance.message2);

                //Compare the start of the first message with the string table.
                __instance.message = lvlStrings.getMessage(__instance.message, __instance.message2, controlButton.ToString(), language);

                ___text.text = __instance.message;
            }
            ___text.text = ___text.text.Replace('$', '\n');
            ___text.enabled = true;
            ___img = ___messageHud.GetComponent<Image>();
            ___img.enabled = true;
            if (__instance.deactivating)
            {
                ___img.enabled = false;
                ___text.enabled = false;
                ___activated = false;
                if (__instance != null)
                {
                    UnityEngine.Object.Destroy(__instance);
                }
            }
            else
            {
                ___messageHud.GetComponent<AudioSource>().Play();
            }
            if (__instance.timed && __instance.notOneTime)
            {
                __instance.CancelInvoke("Done");
                __instance.StartCoroutine(clearTextBox(5f, ___text, ___img));
            }
            else if (__instance.timed)
            {
                clearMessageBox(ref __instance, ref ___activated, ref ___img, ref ___text);
            }
            else
            {
                clearMessageBox(ref __instance, ref ___activated, ref ___img, ref ___text);
            }
            ___messageHud.GetComponent<HudOpenEffect>().Force();

            return false;
        }

        public static void clearMessageBox(ref HudMessage __instance, ref bool ___activated, ref Image ___img, ref Text ___text)
        {
            currentTimedMessage = __instance;
            currentTimedMessageImg = ___img;
            currentTimedMessageText = ___text;
            currentTimedMessageActivated = ___activated;

            __instance.StartCoroutine(wait(5f));
        }

        public static IEnumerator clearTextBox(float seconds, Text text, Image img)
        {
            Console.WriteLine("Sleeping for " + seconds + "seconds...");
            yield return new WaitForSeconds(seconds);
            text.enabled = false;
            img.enabled = false;
        }

        public static IEnumerator wait(float seconds)
        {
            Console.WriteLine("Waiting for " + seconds + " seconds...");
            yield return new WaitForSeconds(seconds);

            currentTimedMessage.enabled = false;
            currentTimedMessageImg.enabled = false;
            currentTimedMessageText.enabled = false;
            currentTimedMessageActivated = false;
        }

        //@Override
        //Overrides the SendHudMessage function from the HudMessageReciever class for non-standard HUD messages.
        public static bool SendHudMessage_MyPatch(HudMessageReceiver __instance, HudOpenEffect ___hoe, Text ___text, Image ___img, AudioSource ___aud, string ___message, string ___input, string ___message2, bool ___noSound, string newmessage, string newinput = "", string newmessage2 = "", int delay = 0, bool silent = false)
        {
            ___message = newmessage;
            ___input = newinput;
            ___message2 = newmessage2;
            ___noSound = silent;

            if (___input == "")
            {
                ___text.text = HUDMessages.getHUDToolTip(newmessage,language);
            }
            else
            {
                KeyCode keyCode = MonoSingleton<InputManager>.Instance.Inputs[___input];
                string str;
                if (keyCode == KeyCode.Mouse0)
                {
                    str = language.currentLanguage.misc.controls_leftClick;
                }
                else if (keyCode == KeyCode.Mouse1)
                {
                    str = language.currentLanguage.misc.controls_middleClick;
                }
                else if (keyCode == KeyCode.Mouse2)
                {
                    str = language.currentLanguage.misc.controls_rightClick;
                }
                else
                {
                    str = keyCode.ToString();
                }
                ___text.text = HUDMessages.getHUDToolTip(newmessage,language) + str + ___message2;
            }

            ___text.text = ___text.text.Replace('$', '\n');
            ___text.enabled = true;
            ___img.enabled = true;
            ___hoe.Force();
            if (!___noSound)
            {

                ___aud.Play();
            }

            __instance.StartCoroutine(clearTextBox(5f, ___text, ___img));
            return false;
        }

        //@Override
        //Overrides the SetInfo method from the FinalRank class. This is needed to swap text in the extra into box on the results screen.
        public static bool SetInfo_MyPatch(int restarts, bool damage, bool majorUsed, bool cheatsUsed, FinalRank __instance, bool ___noRestarts, bool ___majorAssists, bool ___noDamage)
        {
            __instance.extraInfo.text = "";
            int num = 1;
            if (!damage)
            {
                num++;
            }
            if (majorUsed)
            {
                num++;
            }
            if (cheatsUsed)
            {
                num++;
            }

            if (cheatsUsed)
            {
                Text text = __instance.extraInfo;
                text.text += "- <color=#44FF45>" + language.currentLanguage.misc.endstats_cheatsUsed +"</color>\n";
            }
            if (majorUsed)
            {
                Text text2 = __instance.extraInfo;
                text2.text += "- <color=#4C99E6>" + language.currentLanguage.misc.endstats_assistsUsed + "</color>\n";
                ___majorAssists = true;
            }
            if (restarts == 0)
            {
                if (num >= 3)
                {
                    Text text3 = __instance.extraInfo;
                    text3.text += "+ " + language.currentLanguage.misc.endstats_noRestarts + "\n";
                }
                else
                {
                    Text text4 = __instance.extraInfo;
                    text4.text += "+ " + language.currentLanguage.misc.endstats_noRestarts + "\n  (+500<color=orange>P</color>)\n";
                }
                ___noRestarts = true;
            }
            else
            {
                Text text5 = __instance.extraInfo;
                text5.text = string.Concat(new object[]
                {
                text5.text,
                "- <color=red>",
                restarts,
                "</color> " + language.currentLanguage.misc.endstats_restarts +"\n"
                });
            }
            if (!damage)
            {
                if (num >= 3)
                {
                    Text text6 = __instance.extraInfo;
                    text6.text += "+ <color=orange>" + language.currentLanguage.misc.endstats_noDamage + "</color>\n";
                }
                else
                {
                    Text text7 = __instance.extraInfo;
                    text7.text += "+ <color=orange>" + language.currentLanguage.misc.endstats_noDamage + "\n  (</color>+5,000<color=orange>P)</color>\n";
                }
                ___noDamage = true;
            }
            return false;
        }


        //@Override
        //Overrides the CreateBossBar method from the BossBarManager class. This is needed to swap in the translated boss names on their health bars.
        public static bool CreateBossBar_MyPatch(string bossName, BossBarManager.HealthLayer[] healthLayers, ref BossHealthBarTemplate createdBossBar, ref Slider[] hpSliders, ref Slider[] hpAfterImages, ref GameObject bossBar, BossBarManager __instance, BossHealthBarTemplate ___template, BossBarManager.SliderLayer[] ___layers)
        {
            BossStrings bossNames = new BossStrings();
            bossName = bossNames.getBossName(bossName,language);

            Debug.Log("Creating boss bar for " + bossName);
            List<Slider> list = new List<Slider>();
            List<Slider> list2 = new List<Slider>();
            createdBossBar = UnityEngine.Object.Instantiate<BossHealthBarTemplate>(___template, ___template.transform.parent, true);
            bossBar = createdBossBar.gameObject;
            bossBar.SetActive(true);
            createdBossBar.bossNameText.text = bossName;
            float num = 0f;
            for (int i = 0; i < healthLayers.Length; i++)
            {
                BossHealthSliderTemplate bossHealthSliderTemplate = UnityEngine.Object.Instantiate<BossHealthSliderTemplate>(createdBossBar.sliderTemplate, createdBossBar.sliderTemplate.transform.parent);
                list2.Add(bossHealthSliderTemplate.slider);
                bossHealthSliderTemplate.slider.minValue = num;
                bossHealthSliderTemplate.slider.maxValue = num + healthLayers[i].health;
                bossHealthSliderTemplate.gameObject.SetActive(true);
                bossHealthSliderTemplate.background.SetActive(i == 0);
                bossHealthSliderTemplate.fill.color = ___layers[i].afterImageColor;
                BossHealthSliderTemplate bossHealthSliderTemplate2 = UnityEngine.Object.Instantiate<BossHealthSliderTemplate>(createdBossBar.sliderTemplate, createdBossBar.sliderTemplate.transform.parent);
                list.Add(bossHealthSliderTemplate2.slider);
                bossHealthSliderTemplate2.slider.minValue = num;
                bossHealthSliderTemplate2.slider.maxValue = num + healthLayers[i].health;
                bossHealthSliderTemplate2.gameObject.SetActive(true);
                bossHealthSliderTemplate2.background.SetActive(false);
                bossHealthSliderTemplate2.fill.color = ___layers[i].color;
                num += healthLayers[i].health;
            }
            hpSliders = list.ToArray();
            hpAfterImages = list2.ToArray();
            ___template.sliderTemplate.gameObject.SetActive(false);
            ___template.gameObject.SetActive(false);
            bossBar.SetActive(false);
            __instance.StartCoroutine(FitAsync(___template.transform.parent.GetComponent<RectTransform>()));

            return false;
        }

        public static IEnumerator FitAsync(RectTransform layoutRoot)
        {
            yield return new WaitForFixedUpdate();
            LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot);
            yield break;
        }

        //@Override
        //Overrides the UpdateMoney method from the VariationInfo class. This is needed to patch the "ALREADY OWNED" string, and will save having to change every single seperate button containing this string in the shop.
        public static bool UpdateMoney_MyPatch(VariationInfo __instance, int ___money, Text ___buttonText, Image ___equipImage, int ___equipStatus, bool ___alreadyOwned)
        {
            ___money = GameProgressSaver.GetMoney();
            __instance.moneyText.text = MoneyText.DivideMoney(___money) + "<color=orange>P</color>";
            if (!___alreadyOwned && __instance.cost < 0 && GameProgressSaver.CheckGear(__instance.weaponName) > 0)
            {
                ___alreadyOwned = true;
            }
            if (!___alreadyOwned)
            {
                if (__instance.cost < 0)
                {
                    __instance.costText.text = "<color=red>" + language.currentLanguage.misc.weapons_unavailable + "</color>";
                    if (___buttonText == null)
                    {
                        ___buttonText = __instance.buyButton.GetComponentInChildren<Text>();
                    }
                    ___buttonText.text = __instance.costText.text;
                    __instance.buyButton.failure = true;
                    __instance.buyButton.GetComponent<Button>().interactable = false;
                    __instance.buyButton.GetComponent<Image>().color = Color.red;
                    ShopButton shopButton;
                    if (__instance.TryGetComponent<ShopButton>(out shopButton))
                    {
                        shopButton.failure = true;
                    }
                }
                else if (__instance.cost > ___money)
                {
                    __instance.costText.text = "<color=red>" + MoneyText.DivideMoney(__instance.cost) + "P</color>";
                    if (___buttonText == null)
                    {
                        ___buttonText = __instance.buyButton.GetComponentInChildren<Text>();
                    }
                    ___buttonText.text = __instance.costText.text;
                    __instance.buyButton.failure = true;
                    __instance.buyButton.GetComponent<Button>().interactable = false;
                    __instance.buyButton.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    __instance.costText.text = "<color=white>" + MoneyText.DivideMoney(__instance.cost) + "</color><color=orange>P</color>";
                    if (___buttonText == null)
                    {
                        ___buttonText = __instance.buyButton.GetComponentInChildren<Text>();
                    }
                    ___buttonText.text = __instance.costText.text;
                    __instance.buyButton.failure = false;
                    __instance.buyButton.GetComponent<Button>().interactable = true;
                    __instance.buyButton.GetComponent<Image>().color = Color.white;
                }
                __instance.equipButton.gameObject.SetActive(false);
                return false;
            }
            __instance.costText.text = language.currentLanguage.misc.weapons_alreadyBought;
            if (___buttonText == null)
            {
                ___buttonText = __instance.buyButton.GetComponentInChildren<Text>();
            }
            ___buttonText.text = __instance.costText.text;
            __instance.buyButton.failure = true;
            __instance.buyButton.GetComponent<Button>().interactable = false;
            __instance.buyButton.GetComponent<Image>().color = Color.white;
            __instance.equipButton.gameObject.SetActive(true);
            __instance.equipButton.interactable = true;
            if (___equipImage == null)
            {
                ___equipImage = __instance.equipButton.transform.GetChild(0).GetComponent<Image>();
            }
            int @int = MonoSingleton<PrefsManager>.Instance.GetInt("weapon." + __instance.weaponName, 1);
            if (@int == 2 && GameProgressSaver.CheckGear(__instance.weaponName.Substring(0, __instance.weaponName.Length - 1) + "alt") > 0)
            {
                ___equipStatus = 2;
            }
            else if (@int > 0)
            {
                ___equipStatus = 1;
            }
            else
            {
                ___equipStatus = 0;
            }
            if (__instance.orderButtons)
            {
                if (___equipStatus != 0)
                {
                    __instance.orderButtons.SetActive(true);
                }
                else
                {
                    __instance.orderButtons.SetActive(false);
                }
            }
            ___equipImage.sprite = __instance.equipSprites[___equipStatus];
            ShopButton shopButton2;
            if (__instance.cost < 0 && __instance.TryGetComponent<ShopButton>(out shopButton2))
            {
                shopButton2.failure = false;
            }
            return false;
        }

        
        //@Override
        //Overrides the AddPoints method from the StyleHUD class. This is needed to intercept and translate any strings coming into the style meter in-game.
        public static bool AddPoints_MyPatch(StyleHUD __instance, GunControl ___gc, StatsManager ___sman, Dictionary<StyleFreshnessState, StyleFreshnessData> ___freshnessStateDict, float ___currentMeter, float ___rankScale, Queue<string> ___hudItemsQueue, int points, string pointID, GameObject sourceWeapon = null, EnemyIdentifier eid = null, int count = -1, string prefix = "", string postfix = "")
        {
            return true;
        }


        //@Override
        //Coin->RicoshotPointsCheck()

        public static bool RicoshotPointsCheck_MyPatch(Coin __instance, GameObject ___altBeam, bool ___wasShotByEnemy, StyleHUD ___shud, EnemyIdentifier ___eid)
        {
            string text = "";
            int num = 50;
            RevolverBeam revolverBeam;
            if (___altBeam != null && ___altBeam.TryGetComponent<RevolverBeam>(out revolverBeam) && revolverBeam.ultraRicocheter)
            {
                text = "<color=orange>" + language.currentLanguage.style.style_ricoshotUltra +  "</color>";
                num += 50;
            }
            if (___wasShotByEnemy)
            {
                text += "<color=red>" + language.currentLanguage.style.style_ricoshotCounter + "</color>";
                num += 50;
            }
            if (__instance.ricochets > 1)
            {
                num += __instance.ricochets * 15;
            }
            StyleHUD styleHUD = ___shud;
            int points = num;
            string pointID = "ultrakill.ricoshot";
            string prefix = text;
            styleHUD.AddPoints(points, pointID, __instance.sourceWeapon, ___eid, __instance.ricochets, prefix, "");


            return false;
        }

        public static bool GetLocalizedName_MyPatch(string id, StyleHUD __instance, Dictionary<string,string> ___idNameDict, ref string __result)
        {
            StyleBonusStrings bonusStrings = new StyleBonusStrings();
            
            if (___idNameDict.ContainsKey(id))
            {
                __result = bonusStrings.getStyleBonusDictionary(id,language);
                return false;
            }
            __result = bonusStrings.getTranslatedStyleBonus(id,language);
            return false;
        }

        public static bool UpdateFreshnessSlider_MyPatch(StyleHUD __instance, GunControl ___gc)
        {
            StyleFreshnessState freshnessState = __instance.GetFreshnessState(___gc.currentWeapon);
            __instance.freshnessSliderText.text = StyleBonusStrings.getWeaponFreshness(freshnessState,language);

            return false;
        }

        //@Override
        //Overrides the Start method from the IntermissionController class. This is needed to swap out strings on the act intermission screens.
        public static bool Start_MyPatch(IntermissionController __instance, string ___fullString, StringBuilder ___sb, Text ___txt, string ___tempString, bool ___skipToInput, bool ___waitingForInput, string ___preText, AudioSource ___aud, float ___origPitch)
        {
            ___txt = __instance.GetComponent<Text>();
            ___fullString = ___txt.text;
            ___txt.text = "";
            ___aud = __instance.GetComponent<AudioSource>();
            ___origPitch = ___aud.pitch;

            IntermissionStrings intStrings = new IntermissionStrings(language);
            ___fullString = intStrings.getIntermissionString(___fullString,language);

            __instance.StartCoroutine(TextAppearMain(__instance, ___fullString, ___sb, ___txt, ___tempString, ___skipToInput, ___waitingForInput, ___preText, ___aud, ___origPitch));

            return false;
        }

        //Two small leftover problems - Can't hold down left click to speed up text (See just below), and it takes two clicks to switch paragraphs (?)
        public static IEnumerator TextAppearMain(IntermissionController __instance, string ___fullString, StringBuilder ___sb, Text ___txt, string ___tempString, bool ___skipToInput, bool ___waitingForInput, string ___preText, AudioSource ___aud, float ___origPitch)
        {
            int i = ___fullString.Length;
            int num = 0;

            for (int j = 0; j < i; j = num + 1)
            {
                char c = ___fullString[j];
                float waitTime = 0.02f;
                bool playSound = true;
                if (MonoSingleton<OptionsManager>.Instance.paused)
                {
                    yield return new WaitUntil(() => MonoSingleton<OptionsManager>.Instance == null || !MonoSingleton<OptionsManager>.Instance.paused);
                }
                char c2 = c;

                if (c2 != ' ')
                {
                    if (c2 != '}')
                    {
                        if (c2 == '▼')
                        {
                            ___sb = new StringBuilder(___fullString);
                            ___sb[j] = ' ';
                            ___fullString = ___sb.ToString();
                            ___txt.text = ___preText + ___fullString.Substring(0, j);
                            ___tempString = ___txt.text;
                            ___skipToInput = false;
                            ___waitingForInput = true;

                            Coroutine nextLine = __instance.StartCoroutine(IntermissionDotsAppear(__instance, ___waitingForInput, ___txt, ___tempString));
                            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                            __instance.StopCoroutine(nextLine);

                            //The above works better than the below, but unable to speed up text.
                            //yield return new WaitForSecondsRealtime(0.8f);
                        }
                        else
                        {
                            ___txt.text = ___preText + ___fullString.Substring(0, j);
                        }
                    }
                    else
                    {
                        ___sb = new StringBuilder(___fullString);
                        ___sb[j] = ' ';
                        ___fullString = ___sb.ToString();
                        playSound = false;
                        waitTime = 0f;
                        ___txt.text = ___preText + ___fullString.Substring(0, j);
                        UnityEvent unityEvent = __instance.onTextEvent;
                        if (unityEvent != null)
                        {
                            unityEvent.Invoke();
                        }
                    }
                }
                else
                {
                    waitTime = 0f;
                    ___txt.text = ___preText + ___fullString.Substring(0, j);
                }
                i = ___fullString.Length;
                if (waitTime != 0f && playSound)
                {
                    ___aud.pitch = UnityEngine.Random.Range(___origPitch - 0.05f, ___origPitch + 0.05f);
                    ___aud.Play();
                }
                if (___skipToInput)
                {
                    waitTime = 0f;
                }
                yield return new WaitForSecondsRealtime(waitTime);
                num = j;
            }
            UnityEvent unityEvent2 = __instance.onComplete;
            if (unityEvent2 != null)
            {
                unityEvent2.Invoke();
            }
            yield break;
        }

        public static IEnumerator IntermissionDotsAppear(IntermissionController __instance, bool waitingForInput, Text txt, string tempString)
        {
            while (waitingForInput)
            {
                if (MonoSingleton<OptionsManager>.Instance.paused)
                {
                    yield return new WaitUntil(() => !MonoSingleton<OptionsManager>.Instance.paused || !__instance.gameObject.scene.isLoaded);
                }

                txt.text = txt.text + "▼";
                yield return new WaitForSecondsRealtime(0.25f);
                if (waitingForInput)
                {
                    txt.text = txt.text.Remove(txt.text.Length - 1);
                    yield return new WaitForSecondsRealtime(0.25f);
                }
            }
            yield break;
        }

        public static bool DisplaySubtitle_MyPatch(SubtitleController __instance, Subtitle ___subtitleLine, Transform ___container, Subtitle ___previousSubtitle, string caption, AudioSource audioSource = null)
        {
            SubtitleStrings subtitleStrings = new SubtitleStrings();
            if (!__instance.subtitlesEnabled)
            {
                return false;
            }
            Subtitle subtitle = UnityEngine.Object.Instantiate<Subtitle>(___subtitleLine, ___container, true);
            subtitle.GetComponentInChildren<Text>().text = subtitleStrings.getSubtitle(caption,language);
            if (audioSource != null)
            {
                subtitle.distanceCheckObject = audioSource;
            }
            subtitle.gameObject.SetActive(true);
            if (!___previousSubtitle)
            {
                subtitle.ContinueChain();
            }
            else
            {
                ___previousSubtitle.nextInChain = subtitle;
            }
            ___previousSubtitle = subtitle;

            return false;
        }

        //@Override
        //Overrides the UpdateInfo method from the EnemyInfoPage class. This is to allow swapping out of monster bios in the shop.
        public static bool UpdateInfo_MyPatch(EnemyInfoPage __instance, Transform ___enemyList, SpawnableObjectsDatabase ___objects, Image ___buttonTemplateBackground, Image ___buttonTemplateForeground, Sprite ___lockedSprite, SpawnableObject ___currentSpawnable, GameObject ___buttonTemplate, Text ___enemyPageTitle, Text ___enemyPageContent, Transform ___enemyPreviewWrapper)
        {
            if (___enemyList.childCount > 1)
            {
                for (int i = ___enemyList.childCount - 1; i > 0; i--)
                {
                    UnityEngine.Object.Destroy(___enemyList.GetChild(i).gameObject);
                }
            }
            SpawnableObject[] enemies = ___objects.enemies;
            for (int j = 0; j < enemies.Length; j++)
            {
                SpawnableObject spawnableObject = enemies[j];
                bool flag = true;
                if (MonoSingleton<BestiaryData>.Instance.GetEnemy(spawnableObject.enemyType) < 1)
                {
                    flag = false;
                }
                if (flag)
                {
                    ___buttonTemplateBackground.color = spawnableObject.backgroundColor;
                    ___buttonTemplateForeground.sprite = spawnableObject.gridIcon;
                }
                else
                {
                    ___buttonTemplateBackground.color = Color.gray;
                    ___buttonTemplateForeground.sprite = ___lockedSprite;
                }
                GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(___buttonTemplate, ___enemyList);
                gameObject.SetActive(true);
                if (flag)
                {
                    gameObject.GetComponentInChildren<ShopButton>().deactivated = false;
                    gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate ()
                    {
                        ___currentSpawnable = spawnableObject;
                        //Nest the original private DisplayInfo in here.
                        EnemyBios enemyBios = new EnemyBios();

                        string enemyName = enemyBios.getName(spawnableObject.objectName,language);
                        string enemyType = enemyBios.getType(spawnableObject.type,language);
                        string enemyDescription = enemyBios.getDescription(spawnableObject.objectName,language);
                        string enemyStrategy = enemyBios.getStrategy(spawnableObject.objectName,language);

                        ___enemyPageTitle.text = enemyName;
                        string text = "<color=orange>" + language.currentLanguage.enemyBios.enemyBios_type + ": " + enemyType + "\n\n" + language.currentLanguage.enemyBios.enemyBios_data + "</color>\n";
                        if (MonoSingleton<BestiaryData>.Instance.GetEnemy(spawnableObject.enemyType) > 1)
                        {
                            text += enemyDescription;
                        }
                        else
                        {
                            text += "???";
                        }
                        text = text + "\n\n<color=orange>" + language.currentLanguage.enemyBios.enemyBios_strategy + ":</color>\n" + enemyStrategy;
                        ___enemyPageContent.text = text;
                        ___enemyPageContent.rectTransform.localPosition = new Vector3(___enemyPageContent.rectTransform.localPosition.x, 0f, ___enemyPageContent.rectTransform.localPosition.z);
                        for (int i = 0; i < ___enemyPreviewWrapper.childCount; i++)
                        {
                            UnityEngine.Object.Destroy(___enemyPreviewWrapper.GetChild(i).gameObject);
                        }
                        GameObject go = UnityEngine.Object.Instantiate<GameObject>(spawnableObject.preview, ___enemyPreviewWrapper);
                        int layer = ___enemyPreviewWrapper.gameObject.layer;
                        SwapLayers(go.transform, layer);
                        go.layer = layer;
                        go.transform.localPosition = spawnableObject.menuOffset;
                        Spin spin = go.AddComponent<Spin>();
                        spin.spinDirection = new Vector3(0f, 1f, 0f);
                        spin.speed = 10f;
                    });
                    //End of nested DisplayInfo here
                }
                else
                {
                    gameObject.GetComponentInChildren<ShopButton>().deactivated = true;
                }
            }
            ___buttonTemplate.SetActive(false);

            return false;
        }
        public static void SwapLayers(Transform target, int layer)
        {
            foreach (object obj in target)
            {
                Transform transform = (Transform)obj;
                transform.gameObject.layer = layer;
                if (transform.childCount > 0)
                {
                    SwapLayers(transform, layer);
                }
            }
        }

        //@Override
        //Overrides the *private* UpdateSlotState method from the SaveSlotMenu class. This is to allow save menu strings to be swapped out.
        public static bool UpdateSlotState_MyPatch(SlotRowPanel targetPanel, SaveSlotMenu.SlotData data, SaveSlotMenu __instance, Color ___ActiveColor)
        {
            bool flag = GameProgressSaver.currentSlot == targetPanel.slotIndex;
            targetPanel.backgroundPanel.color = (flag ? ___ActiveColor : Color.black);
            targetPanel.slotNumberLabel.color = (flag ? Color.black : (data.exists ? Color.white : Color.red));
            targetPanel.stateLabel.color = (flag ? Color.black : (data.exists ? Color.white : Color.red));
            targetPanel.selectButton.interactable = !flag;
            targetPanel.selectButton.GetComponentInChildren<Text>().text = (flag ? language.currentLanguage.options.save_selected : language.currentLanguage.options.save_select);
            targetPanel.deleteButton.interactable = data.exists;
            targetPanel.slotNumberLabel.text = string.Format("Slot {0}", targetPanel.slotIndex + 1);
            targetPanel.stateLabel.text = SaveToString(data.exists, data.highestLvlNumber, data.highestDifficulty);

            GameObject deleteButtonText = targetPanel.deleteButton.gameObject;
            GameObject child = deleteButtonText.transform.GetChild(0).gameObject;

            Text deleteText = child.GetComponent<Text>();
            deleteText.text = language.currentLanguage.options.save_delete;

            return false;
        }
        public static string SaveToString(bool exists, int highestLvlNumber, int highestDifficulty)
        {
            if (!exists)
            {
                return language.currentLanguage.options.save_slotEmpty;
            }

            LevelNames levelStrings = new LevelNames();

            return levelStrings.getLevelName(highestLvlNumber, language) + " " + ((highestLvlNumber <= 0) ? string.Empty : ("(" + MonoSingleton<PresenceController>.Instance.diffNames[highestDifficulty] + ")"));
        }

        //@Override
        //Overrides the *private* ClearSlot method from the SaveSlotMenu class. This is to swap out the delete confirmation string.
        public static bool ClearSlot_MyPatch(int slot, SaveSlotMenu __instance, int ___queuedSlot, Text ___wipeConsentContent, GameObject ___wipeConsentWrapper)
        {
            Console.WriteLine("DELETING SLOT" + slot);

            ___queuedSlot = slot;
            //___wipeConsentContent.text = string.Format(language.currentLanguage.options.save_deleteWarning1+ "<color=red>" + language.currentLanguage.options.save_deleteWarning2 + "{0}</color>?", slot + 1);

            ___wipeConsentContent.text = string.Format("Are you sure you want to <color=red>DELETE SLOT {0}</color>?", slot + 1);
            ___wipeConsentWrapper.SetActive(true);

            return false;
        }

        //@Override
        //DiscordController->Update
        public static bool DC_UpdateMyPatch(DiscordController __instance, bool ___disabled, Discord.Discord ___discord)
        {
            if (___discord == null || ___disabled)
            {
                Console.WriteLine("Null or disabled, exiting early");
                return false;
            }
            try
            {
                ___discord.RunCallbacks();
            }
            catch (Exception e)
            {
                Debug.Log("Discord lost");
                Debug.Log(e.ToString());
                ___disabled = true;
                //___discord.Dispose();
            }
            return false;
        }

        //@Override
        //Overrides the FetchSceneActivity function from the DiscordController class. This is to swap out strings in Discord Rich Presence.
        public static bool FetchSceneActivity_MyPatch(string scene, DiscordController __instance, DiscordController ___Instance, bool ___disabled, Discord.Discord ___discord, Discord.ActivityManager ___activityManager, Discord.Activity ___cachedActivity, SerializedActivityAssets ___missingActivityAssets)
        {
            //Console.WriteLine("Fetching scene activity");

            if (!___Instance || ___disabled || ___discord == null)
            {
                //Console.WriteLine("Pre-exiting");
                if(!___Instance)
                {
                   // Console.WriteLine("Instance is disabled");
                }
                if (___disabled)
                {
                    //Console.WriteLine("Disabled is true");
                }
                if (___discord == null)
                {
                    Console.WriteLine("Discord instance is null");
                }
                return false;
            }


            if (___discord == null || ___activityManager == null || ___disabled)
            {
                Console.WriteLine("Post-exiting");
                return false;
            }
            StockMapInfo instance = StockMapInfo.Instance;

            if (instance)
            {
                ___cachedActivity.Assets = instance.assets.Deserialize();
                if (string.IsNullOrEmpty(___cachedActivity.Assets.LargeImage))
                {
                    ___cachedActivity.Assets.LargeImage = ___missingActivityAssets.Deserialize().LargeImage;
                }
            }
            else
            {
                Console.WriteLine("Instance is null, shouldn't be...");
            }

            ___cachedActivity.Assets.LargeText = LevelNames.getDiscordLevelName(SceneManager.GetActiveScene().name, language);
            ___cachedActivity.State = "Running UltrakULL";

            Discord.ActivityAssets currentLevel = ___missingActivityAssets.Deserialize();
            if (scene == "Main Menu")
            {
                ___cachedActivity.Details = "Menu Principal";
            }

            DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long start = (long)(DateTime.UtcNow - d).TotalSeconds;
            ___cachedActivity.Timestamps = new Discord.ActivityTimestamps
            {
                Start = start
            };

            ___activityManager.UpdateActivity(___cachedActivity, delegate (Discord.Result result)
            {
            });

            return false;
        }

        //@Override
        //Overrides the UpdateStyle function from the DiscordController class.
        //Have to use AccessTools functions because for some reason using arguments causes illegal IL code errors.
        public static bool UpdateStyle_MyPatch(int points, DiscordController __instance)
        {
            DiscordController privateInstance = (DiscordController)AccessTools.Field(typeof(DiscordController), "Instance").GetValue(__instance);
            bool privateDisabled = (bool)AccessTools.Field(typeof(DiscordController), "disabled").GetValue(privateInstance);
            int privatelastPoints = (int)AccessTools.Field(typeof(DiscordController), "lastPoints").GetValue(privateInstance);

            Discord.Activity privateCachedActivity = (Discord.Activity)AccessTools.Field(typeof(DiscordController), "cachedActivity").GetValue(privateInstance);

            Discord.ActivityManager privateActivityManager = (Discord.ActivityManager)AccessTools.Field(typeof(DiscordController), "activityManager").GetValue(privateInstance);

            if (!privateInstance)
            {
                return false;
            }
            if (points == privatelastPoints)
            {
                return false;
            }

            int diffInt = MonoSingleton<PrefsManager>.Instance.GetInt("difficulty", 0);
            string diffString = language.currentLanguage.frontend.difficulty_title + ": ";
            switch (diffInt)
            {
                case 0: { diffString += language.currentLanguage.frontend.difficulty_harmless; break; }
                case 1: { diffString += language.currentLanguage.frontend.difficulty_lenient; break; }
                case 2: { diffString += language.currentLanguage.frontend.difficulty_standard; break; }
                case 3: { diffString += language.currentLanguage.frontend.difficulty_violent; break; }
                case 4: { diffString += language.currentLanguage.frontend.difficulty_brutal; break; }
                case 5: { diffString += language.currentLanguage.frontend.difficulty_umd; break; }
                default: { diffString += "UNKNOWN"; break; }
            }

            StockMapInfo instance = StockMapInfo.Instance;
            if (instance)
            {
                string currentLevel = LevelNames.getDiscordLevelName(SceneManager.GetActiveScene().name, language);
                Discord.ActivityAssets levelInfo = instance.assets.Deserialize();

                privatelastPoints = points;
                privateCachedActivity.Assets.LargeText = currentLevel; //Level name
                privateCachedActivity.Assets.LargeImage = levelInfo.LargeImage;//Level photo
                privateCachedActivity.State = diffString; //UltrakuLL label
                privateCachedActivity.Details = "STYLE: " + points; //Style

                if (rankCachedActivity.Assets.SmallText != null && rankCachedActivity.Assets.SmallImage != null)
                {
                    privateCachedActivity.Assets.SmallImage = rankCachedActivity.Assets.SmallImage;
                    privateCachedActivity.Assets.SmallText = StyleBonusStrings.getTranslatedRankString(rankCachedActivity.Assets.SmallText,language);
                }

                if (privateCachedActivity.Assets.SmallText != null && privateCachedActivity.Assets.SmallImage != null)
                {
                    privateActivityManager.UpdateActivity(privateCachedActivity, delegate (Discord.Result result)
                    {
                    });
                }
            }
            return false;
        }
        //@Override
        //Overrides the UpdateRank function from the DiscordController class.
        public static bool UpdateRank_MyPatch(int rank, DiscordController __instance)
        {
            DiscordController privateInstance = (DiscordController)AccessTools.Field(typeof(DiscordController), "Instance").GetValue(__instance);
            bool privateDisabled = (bool)AccessTools.Field(typeof(DiscordController), "disabled").GetValue(privateInstance);

            RankIcon[] privateRankIcons = (RankIcon[])AccessTools.Field(typeof(DiscordController), "rankIcons").GetValue(privateInstance);

            Discord.Activity privateCachedActivity = (Discord.Activity)AccessTools.Field(typeof(DiscordController), "cachedActivity").GetValue(privateInstance);

            Discord.ActivityManager privateActivityManager = (Discord.ActivityManager)AccessTools.Field(typeof(DiscordController), "activityManager").GetValue(privateInstance);

            if (!privateInstance)
            {
                Console.WriteLine("Instance not ready");
                return false;
            }
            if (privateDisabled)
            {
                Console.WriteLine("Instance Disabled");
                return false;
            }
            if (privateRankIcons.Length <= rank)
            {
                Debug.LogError("Discord Controller is missing rank names/icons!");
                return false;
            }

            privateCachedActivity.Assets.SmallText = privateRankIcons[rank].Text;
            privateCachedActivity.Details = privateRankIcons[rank].Text;
            privateCachedActivity.Assets.SmallImage = privateRankIcons[rank].Image;
            Console.WriteLine(privateCachedActivity.Assets.SmallText);
            Console.WriteLine(privateCachedActivity.Assets.SmallImage);

            rankCachedActivity.Assets.SmallText = privateRankIcons[rank].Text;
            rankCachedActivity.Assets.SmallImage = privateRankIcons[rank].Image;

            return false;
        }

        //@Override
        //Overrides the UpdateWave function from the DiscordController class, for Cybergrind Discord Rich Presence.
        public static bool UpdateWave_MyPatch(int wave, DiscordController __instance)
        {
            try
            {
                DiscordController privateInstance = (DiscordController)AccessTools.Field(typeof(DiscordController), "Instance").GetValue(__instance);
                Discord.Activity privateCachedActivity = (Discord.Activity)AccessTools.Field(typeof(DiscordController), "cachedActivity").GetValue(privateInstance);
                bool privateDisabled = (bool)AccessTools.Field(typeof(DiscordController), "disabled").GetValue(privateInstance);

                Discord.ActivityManager privateActivityManager = (Discord.ActivityManager)AccessTools.Field(typeof(DiscordController), "activityManager").GetValue(privateInstance);

                int privatelastPoints = (int)AccessTools.Field(typeof(DiscordController), "lastPoints").GetValue(privateInstance);
                
                if (!DiscordController.Instance)
                {
                    return false;
                }
                if (privateDisabled)
                {
                    return false;
                }
                if (privatelastPoints == wave)
                {
                    return false;
                }

                StockMapInfo instance = StockMapInfo.Instance;
                if (instance)
                {
                    string currentLevel = LevelNames.getDiscordLevelName(SceneManager.GetActiveScene().name, language);
                    Discord.ActivityAssets levelInfo = instance.assets.Deserialize();

                    privateCachedActivity.Assets.LargeText = currentLevel; //Level name
                    privateCachedActivity.Assets.LargeImage = levelInfo.LargeImage;//Level photo
                                                                                   //privateCachedActivity.State = diffString; //UltrakuLL label

                    privateCachedActivity.Assets.SmallImage = rankCachedActivity.Assets.SmallImage;
                    privateCachedActivity.Assets.SmallText = StyleBonusStrings.getTranslatedRankString(rankCachedActivity.Assets.SmallText, language);

                }

                privatelastPoints = wave;
                privateCachedActivity.Details = language.currentLanguage.cyberGrind.cybergrind_wave + ": " + wave;

                privateActivityManager.UpdateActivity(privateCachedActivity, delegate (Discord.Result result)
                {
                });

                return false;
            }
            catch(Exception e)
            {
                modLogger.LogWarning("Something went wrong while updating Discord RPC. Falling back to vanilla function.");
                return true;
            }
        }

        //@Override
        //Overrides the *private* Start function from the LevelStats class for the in-game level stats window.
        public static bool LevelStatsStart_MyPatch(LevelStats __instance, StatsManager ___sman, bool ___ready, float ___seconds, float ___minutes)
        {
            ___sman = MonoSingleton<StatsManager>.Instance;
            cachedStatsManager = MonoSingleton<StatsManager>.Instance;
            if (__instance.secretLevel)
            {
                Console.WriteLine("Secret mission detected");
                __instance.levelName.text = language.currentLanguage.frontend.chapter_secretMission;
                ___ready = true;
                cachedStatsReady = true;
                CheckStats_Defer(ref __instance, ref ___sman, ref ___seconds, ref ___minutes);
                return false;
            }
            if (MonoSingleton<MapLoader>.Instance && MonoSingleton<MapLoader>.Instance.isCustomLoaded)
            {
                MapInfo instance = MapInfo.Instance;
                __instance.levelName.text = "Custom LevelName";
                ___ready = true;
                cachedStatsReady = true;
                //CheckStats_Defer(ref __instance, ref ___sman, ref ___seconds, ref ___minutes);
            }
            RankData rankData = null;
            if (___sman.levelNumber != 0 && !Debug.isDebugBuild)
            {
                rankData = GameProgressSaver.GetRank(true);
            }
            if (___sman.levelNumber != 0 && (Debug.isDebugBuild || (rankData != null && rankData.levelNumber == ___sman.levelNumber)))
            {
                StockMapInfo instance2 = StockMapInfo.Instance;
                if (instance2 != null)
                {
                    __instance.levelName.text = LevelNames.getDiscordLevelName(SceneManager.GetActiveScene().name, language);
                }
                else
                {
                    __instance.levelName.text = "???";
                }
                ___ready = true;
                cachedStatsReady = true;
                CheckStats_Defer(ref __instance, ref ___sman, ref ___seconds, ref ___minutes);

                return false;
            }
            __instance.gameObject.SetActive(false);
            return false;
        }

        public static void CheckStats_Defer(ref LevelStats instance, ref StatsManager sman, ref float seconds, ref float minutes)
        {

            if (instance.time)
            {
                Console.WriteLine(sman.seconds);
                seconds = sman.seconds;
                minutes = 0f;
                while (seconds >= 60f)
                {
                    seconds -= 60f;
                    minutes += 1f;
                }
                instance.time.text = minutes + ":" + seconds.ToString("00.000");
            }
            if (instance.timeRank)
            {
                instance.timeRank.text = sman.GetRanks(sman.timeRanks, sman.seconds, true, false);
            }
            if (instance.kills)
            {
                instance.kills.text = sman.kills.ToString();
            }
            if (instance.killsRank)
            {
                instance.killsRank.text = sman.GetRanks(sman.killRanks, (float)sman.kills, false, false);
            }
            if (instance.style)
            {
                instance.style.text = sman.stylePoints.ToString();
            }
            if (instance.styleRank)
            {
                instance.styleRank.text = sman.GetRanks(sman.styleRanks, (float)sman.stylePoints, false, false);
            }
            if (instance.secrets)
            {
                int num = sman.secrets + sman.prevSecrets.Count;
                instance.secrets.text = num + "/" + sman.secretObjects.Length;
            }
            if (instance.challenge)
            {
                if (MonoSingleton<ChallengeManager>.Instance.challengeDone && !MonoSingleton<ChallengeManager>.Instance.challengeFailed)
                {
                    instance.challenge.text = "<color=#FFAF00>" + language.currentLanguage.misc.state_yes + "</color>";
                }
                else
                {
                    instance.challenge.text = language.currentLanguage.misc.state_no;
                }
            }
            if (instance.majorAssists)
            {
                if (sman.majorUsed)
                {
                    instance.majorAssists.text = "<color=#4C99E6>" + language.currentLanguage.misc.state_yes + "</color>";
                    return;
                }
                instance.majorAssists.text = language.currentLanguage.misc.state_no;
            }
        }

        public static bool LevelStatsUpdate_MyPatch(LevelStats __instance, StatsManager ___sman, bool ___ready, float ___seconds, float ___minutes)
        {
            if (cachedStatsReady)
            {
                ___seconds = cachedStatsManager.seconds;
                ___minutes = 0f;
                while (___seconds >= 60f)
                {
                    ___seconds -= 60f;
                    ___minutes += 1f;
                }
                __instance.time.text = ___minutes + ":" + ___seconds.ToString("00.000");

                if (__instance.timeRank)
                {
                    __instance.timeRank.text = cachedStatsManager.GetRanks(cachedStatsManager.timeRanks, cachedStatsManager.seconds, true, false);
                }
                if (__instance.kills)
                {
                    __instance.kills.text = cachedStatsManager.kills.ToString();
                }
                if (__instance.killsRank)
                {
                    __instance.killsRank.text = cachedStatsManager.GetRanks(cachedStatsManager.killRanks, (float)cachedStatsManager.kills, false, false);
                }
                if (__instance.style)
                {
                    __instance.style.text = cachedStatsManager.stylePoints.ToString();
                }
                if (__instance.styleRank)
                {
                    __instance.styleRank.text = cachedStatsManager.GetRanks(cachedStatsManager.styleRanks, (float)cachedStatsManager.stylePoints, false, false);
                }
                if (__instance.secrets)
                {
                    int num = cachedStatsManager.secrets + cachedStatsManager.prevSecrets.Count;
                    __instance.secrets.text = num + "/" + cachedStatsManager.secretObjects.Length;
                }
                if (__instance.challenge)
                {
                    if (MonoSingleton<ChallengeManager>.Instance.challengeDone && !MonoSingleton<ChallengeManager>.Instance.challengeFailed)
                    {
                        __instance.challenge.text = "<color=#FFAF00>" + language.currentLanguage.misc.state_yes + "</color>";
                    }
                    else
                    {
                        __instance.challenge.text = language.currentLanguage.misc.state_no;
                    }
                }
                if (__instance.majorAssists)
                {
                    if (cachedStatsManager.majorUsed)
                    {
                        __instance.majorAssists.text = "<color=#4C99E6>" + language.currentLanguage.misc.state_yes +"</color>";
                        return false;
                    }
                    __instance.majorAssists.text = language.currentLanguage.misc.state_no;
                }
            }
            return false;
        }

        //@Override
        //Overrides the *private* UpdateCheatState function from the CheatsManager class for translating the cheat menu.
        public static bool UpdateCheatState_MyPatch(CheatMenuItem item, ICheat cheat, CheatsManager __instance, Color ___enabledColor, Color ___disabledColor)
        {
            try
            {
                item.longName.text = Cheats.getCheatName(cheat.Identifier, language);
                item.stateBackground.color = (cheat.IsActive ? ___enabledColor : ___disabledColor);

                string cheatDisabledStatus = Cheats.getCheatStatus(cheat.ButtonDisabledOverride, language);
                string cheatEnabledStatus = Cheats.getCheatStatus(cheat.ButtonEnabledOverride, language);

                item.stateText.text = (cheat.IsActive ? (cheatEnabledStatus ?? language.currentLanguage.cheats.cheats_activated) : (cheatDisabledStatus ?? language.currentLanguage.cheats.cheats_deactivated)); //Cheat status
                item.bindButtonBack.gameObject.SetActive(false);
                string text = MonoSingleton<CheatBinds>.Instance.ResolveCheatKey(cheat.Identifier);
                if (string.IsNullOrEmpty(text))
                {
                    item.bindButtonText.text = language.currentLanguage.cheats.cheats_pressToBind; //Press to bind
                }
                else
                {
                    item.bindButtonText.text = text.ToUpper();
                }
                GameObject parentResetButton = item.resetBindButton.gameObject;
                Text parentResetText = CommonFunctions.getTextfromGameObject(CommonFunctions.getGameObjectChild(parentResetButton, "Text"));
                parentResetText.text = language.currentLanguage.cheats.cheats_delete;
                __instance.RenderCheatsInfo();
                return false;
            }
            catch(Exception e)
            {
                handleError(e);
                return true;
            }

        }

        //@Override
        //Overrides the RenderCheatsInfo function from the CheatsManager class for displaying the active cheats on the HUD.
        public static bool RenderCheatsInfo_MyPatch(CheatsManager __instance, Dictionary<string, List<ICheat>> ___allRegisteredCheats)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (MonoSingleton<SandboxNavmesh>.Instance && MonoSingleton<SandboxNavmesh>.Instance.isDirty)
            {
                stringBuilder.AppendLine(language.currentLanguage.cheats.cheats_navmeshOutdated1 + "\n\n" + language.currentLanguage.cheats.cheats_navmeshOutdated2);
            }
            if (__instance.GetCheatState("ultrakill.spawner-arm"))
            {
                stringBuilder.AppendLine(language.currentLanguage.cheats.cheats_spawnerArmSlot);
            }
            foreach (KeyValuePair<string, List<ICheat>> keyValuePair in ___allRegisteredCheats)
            {
                foreach (ICheat cheat2 in from cheat in keyValuePair.Value
                                          where cheat.IsActive
                                          select cheat)
                {
                    string text = MonoSingleton<CheatBinds>.Instance.ResolveCheatKey(cheat2.Identifier);
                    if (!string.IsNullOrEmpty(text))
                    {
                        stringBuilder.Append("[<color=orange>" + text.ToUpper() + "</color>] ");
                    }
                    else
                    {
                        stringBuilder.Append("[ ] ");
                    }
                    stringBuilder.Append("<color=white>" + Cheats.getCheatName(cheat2.Identifier,language) + "</color>\n");
                }
            }
            MonoSingleton<CheatsController>.Instance.cheatsInfo.text = stringBuilder.ToString();
            return false;
        }

        //@Override
        //Overrides the Toggle function from the CustomPatterns class for the toggle text.
        public static bool Toggle_MyPatch(CustomPatterns __instance, Text ___stateButtonText)
        {
            try
            {
                Debug.Log("Toggling custom patterns");
                bool customPatternMode = MonoSingleton<EndlessGrid>.Instance.customPatternMode;
                MonoSingleton<EndlessGrid>.Instance.customPatternMode = !customPatternMode;
                ___stateButtonText.text = (customPatternMode ? language.currentLanguage.misc.state_deactivated : language.currentLanguage.misc.state_activated);
                GameObject gameObject = __instance.enableWhenCustom;
                if (gameObject != null)
                {
                    gameObject.SetActive(!customPatternMode);
                }
                MonoSingleton<PrefsManager>.Instance.SetBoolLocal("cyberGrind.customPool", MonoSingleton<EndlessGrid>.Instance.customPatternMode);

                return false;
            }
            catch(Exception e)
            {
                handleError(e);
                return true;
            }
        }

    }
}
