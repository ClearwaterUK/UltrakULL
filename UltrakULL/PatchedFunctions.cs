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
using System.Text.RegularExpressions;

namespace UltrakULL
{
    class PatchedFunctions
    {
        public static HudMessage currentTimedMessage;
        public static Image currentTimedMessageImg;
        public static Text currentTimedMessageText;
        public static bool currentTimedMessageActivated;

        public static Discord.Activity rankCachedActivity;

        //@Override
        //Overrides the private CoinsToPoints function in the CrateCounter class
        public static bool CoinsToPoints_MyPatch(CrateCounter __instance, int ___savedCoins)
        {
            if (SceneManager.GetActiveScene().name == "Level 4-S")
            {
                GameProgressSaver.AddMoney(___savedCoins * 100);

                MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage(string.Concat(new object[]
                {
                    "<color=grey>" + LanguageManager.CurrentLanguage.act2.act2_greedSecret_transactionComplete1 + ":</color> ",
                    ___savedCoins,
                    " " + LanguageManager.CurrentLanguage.act2.act2_greedSecret_transactionComplete2 +" <color=orange>=></color> ",
                    StatsManager.DivideMoney(___savedCoins * 100),
                    "<color=orange>P</color>"
                }), "", "", 0, false);
            ___savedCoins = 0;
            }
            return false;
        }

        //@Override
        //Overrides OnEnable from the GunColorTypeGetter class. Used for the Soul Orb checker.
        public static void OnEnablePostFix_MyPatch(GunColorTypeGetter __instance)
        {
            for (int i = 1; i < 5; i++)
            {
                bool flag = GameProgressSaver.GetTotalSecretsFound() >= GunColorController.requiredSecrets[i];
                if(!flag)
                { 
                    __instance.templateTexts[i].text = string.Concat(new object[]
                    {
                        LanguageManager.CurrentLanguage.shop.shop_soulOrbs + ": ",
                        GameProgressSaver.GetTotalSecretsFound(),
                        " / ",
                        GunColorController.requiredSecrets[i]
                    });
                }
            }
        }

        //@Override
        //Overrides ScanBook from the ScanningStuff class, for the "scanning" panel and book translations.
        public static bool ScanBook_MyPatch(ref string text, bool noScan, int instanceId, ScanningStuff __instance)
        {
            GameObject canvas = getInactiveRootObject("Canvas");

            Text scanningText = getTextfromGameObject(getGameObjectChild(getGameObjectChild(getGameObjectChild(canvas, "ScanningStuff"),"ScanningPanel"),"Text"));
            scanningText.text = LanguageManager.CurrentLanguage.books.books_scanning;
            text = Books.getBookText();
            return true;
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
                        text2.text += LanguageManager.CurrentLanguage.frontend.difficulty_harmless;
                        break;
                    }
                case 1:
                    {
                        Text text3 = ___txt;
                        text3.text += LanguageManager.CurrentLanguage.frontend.difficulty_lenient;
                        break;
                    }
                case 2:
                    {
                        Text text4 = ___txt;
                        text4.text += LanguageManager.CurrentLanguage.frontend.difficulty_standard;
                        break;
                    }
                case 3:
                    {
                        Text text5 = ___txt;
                        text5.text += LanguageManager.CurrentLanguage.frontend.difficulty_violent;
                        break;
                    }
                case 4:
                    {
                        Text text6 = ___txt;
                        text6.text += LanguageManager.CurrentLanguage.frontend.difficulty_brutal;
                        break;
                    }
                case 5:
                    {
                        Text text7 = ___txt;
                        text7.text += LanguageManager.CurrentLanguage.frontend.difficulty_umd;
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

            //Bandaid fix for P-2 and P-3 for now since they share the same level id as P-1 for some reason. Shall need to change/remove when they release.
            if (__instance.transform.Find("Name").GetComponent<Text>().text.Contains("P-2"))
            {
                __instance.transform.Find("Name").GetComponent<Text>().text = "P-2: ???";
            }
            else if (__instance.transform.Find("Name").GetComponent<Text>().text.Contains("P-3"))
            {
                __instance.transform.Find("Name").GetComponent<Text>().text = "P-3: ???";
            }
            else
            {
                __instance.transform.Find("Name").GetComponent<Text>().text = LevelNames.getLevelName(num); //Level Name
            }
            if (rank.levelNumber == __instance.levelNumber || (__instance.levelNumber == 666 && rank.levelNumber == __instance.levelNumber + __instance.levelNumberInLayer - 1))
            {
                if (__instance.challengeIcon)
                {
                    if (LanguageManager.CurrentLanguage.frontend.level_challengeCompleted == null)
                        return;
                    if (rank.challenge)
                    {
                        __instance.challengeIcon.fillCenter = true;
                        Text componentInChildren2 = __instance.challengeIcon.GetComponentInChildren<Text>();
                        componentInChildren2.text = String.Join(" ", LanguageManager.CurrentLanguage.frontend.level_challengeCompleted.ToList()); //Challenge completed
                    }
                    else
                    {
                        __instance.challengeIcon.fillCenter = false;
                        Text componentInChildren3 = __instance.challengeIcon.GetComponentInChildren<Text>();
                        componentInChildren3.text = String.Join(" ", LanguageManager.CurrentLanguage.frontend.level_challenge.ToList()); //Challenge not completed
                        componentInChildren3.color = Color.white;
                    }
                }
            }
            return;
        }

        //@Override
        //Overrides the NameAppear function from LevelNamePopup. Used for showing layer and level names at the start of a level.
        public static bool NameAppear_MyPatch(LevelNamePopup __instance, ref string ___layerString, ref string ___nameString)
        {
            ___layerString = TitleManager.getLayer(___layerString);
            ___nameString = TitleManager.getName(___nameString);

            return true;
        }

        //@Override
        //Overrides the Start function from IntroText. This is needed for patched text to appear on the tutorial.
        public static bool IntroTextStart_MyPatch(IntroText __instance, Text ___txt, string ___fullString)
        {
            ___txt = __instance.GetComponent<Text>();

            TutorialStrings tutStrings = new TutorialStrings();
            ___fullString = ___txt.text;

            if (___fullString[0] == 'B') { ___fullString = tutStrings.introFirstPage; }
            else { ___fullString = tutStrings.introSecondPage; }
            ___txt.text = ___fullString;

            return true;
        }

        //@Override
        //Overrides the PlayMessage method from the HudMessage class. This is needed for swapping text in message boxes.
        public static bool PlayMessage_MyPatch(HudMessage __instance, bool ___activated, HudMessageReceiver ___messageHud, Text ___text, Image ___img)
        {
            //The HUD display uses 2 kinds of messages.
            //One for messages that displays KeyCode inputs (for controls), and one that doesn't.
            //Get the string table based on the area of the game we're currently in.

            ___activated = true;
            ___messageHud = MonoSingleton<HudMessageReceiver>.Instance;
            ___text = ___messageHud.text;
            if (__instance.input == "")
            {
                string newMessage = StringsParent.getMessage(__instance.message, __instance.message2, "");

                ___text.text = newMessage;
            }
            else
            {
                KeyCode keyCode = MonoSingleton<InputManager>.Instance.Inputs[__instance.input];
                string controlButton;
                if (keyCode == KeyCode.Mouse0)
                {
                    controlButton = LanguageManager.CurrentLanguage.misc.controls_leftClick;
                }
                else if (keyCode == KeyCode.Mouse1)
                {
                    controlButton = LanguageManager.CurrentLanguage.misc.controls_rightClick;
                }
                else if (keyCode == KeyCode.Mouse2)
                {
                    controlButton = LanguageManager.CurrentLanguage.misc.controls_middleClick;
                }
                else
                {
                    controlButton = keyCode.ToString();
                }

                //Messages that get input.
                Console.Write("Input message: " + __instance.message + controlButton + __instance.message2);

                //Compare the start of the first message with the string table.
                __instance.message = StringsParent.getMessage(__instance.message, __instance.message2, controlButton.ToString());

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
                ___text.text = HUDMessages.getHUDToolTip(newmessage);
            }
            else
            {
                KeyCode keyCode = MonoSingleton<InputManager>.Instance.Inputs[___input];
                string str;
                if (keyCode == KeyCode.Mouse0)
                {
                    str = LanguageManager.CurrentLanguage.misc.controls_leftClick;
                }
                else if (keyCode == KeyCode.Mouse1)
                {
                    str = LanguageManager.CurrentLanguage.misc.controls_middleClick;
                }
                else if (keyCode == KeyCode.Mouse2)
                {
                    str = LanguageManager.CurrentLanguage.misc.controls_rightClick;
                }
                else
                {
                    str = keyCode.ToString();
                }
                ___text.text = HUDMessages.getHUDToolTip(newmessage) + str + ___message2;
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
                text.text += "- <color=#44FF45>" + LanguageManager.CurrentLanguage.misc.endstats_cheatsUsed + "</color>\n";
            }
            if (majorUsed)
            {
                Text text2 = __instance.extraInfo;
                text2.text += "- <color=#4C99E6>" + LanguageManager.CurrentLanguage.misc.endstats_assistsUsed + "</color>\n";
                ___majorAssists = true;
            }
            if (restarts == 0)
            {
                if (num >= 3)
                {
                    Text text3 = __instance.extraInfo;
                    text3.text += "+ " + LanguageManager.CurrentLanguage.misc.endstats_noRestarts + "\n";
                }
                else
                {
                    Text text4 = __instance.extraInfo;
                    text4.text += "+ " + LanguageManager.CurrentLanguage.misc.endstats_noRestarts + "\n  (+500<color=orange>P</color>)\n";
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
                "</color> " + LanguageManager.CurrentLanguage.misc.endstats_restarts +"\n"
                });
            }
            if (!damage)
            {
                if (num >= 3)
                {
                    Text text6 = __instance.extraInfo;
                    text6.text += "+ <color=orange>" + LanguageManager.CurrentLanguage.misc.endstats_noDamage + "</color>\n";
                }
                else
                {
                    Text text7 = __instance.extraInfo;
                    text7.text += "+ <color=orange>" + LanguageManager.CurrentLanguage.misc.endstats_noDamage + "\n  (</color>+5,000<color=orange>P)</color>\n";
                }
                ___noDamage = true;
            }
            return false;
        }

        //@Override
        //Overrides the CreateBossBar method from the BossBarManager class. This is needed to swap in the translated boss names on their health bars.
        public static bool CreateBossBar_MyPatch(ref string bossName)
        {
            bossName = BossStrings.getBossName(bossName);
            return true;
        }

        //@Override
        //Overrides the UpdateMoney method from the VariationInfo class. This is needed to patch the "ALREADY OWNED" string, and will save having to change every single seperate button containing this string in the shop.

        public static void UpdateMoney_Postfix(VariationInfo __instance, int ___money, bool ___alreadyOwned)
        {
            if (!___alreadyOwned)
            {
                if (__instance.cost < 0)
                {
                    __instance.costText.text = "<color=red>" + LanguageManager.CurrentLanguage.misc.weapons_unavailable + "</color>";
                }
            }
            __instance.costText.text = LanguageManager.CurrentLanguage.misc.weapons_alreadyBought;
        }

        //@Override
        //Overrides the AddPoints method from the StyleHUD class. This is needed to intercept and translate any strings coming into the style meter in-game.
        public static bool AddPoints_MyPatch(StyleHUD __instance, GunControl ___gc, StatsManager ___sman, Dictionary<StyleFreshnessState, StyleFreshnessData> ___freshnessStateDict, float ___currentMeter, float ___rankScale, Queue<string> ___hudItemsQueue, int points, string pointID, GameObject sourceWeapon = null, EnemyIdentifier eid = null, int count = -1, string prefix = "", string postfix = "")
        {
            return true;
        }

        //@Override
        //Overrides the RicoshotPointsCheck from the Coin class. Used for translating additional style strings that come from ricochets.
        public static bool RicoshotPointsCheck_MyPatch(Coin __instance, GameObject ___altBeam, bool ___wasShotByEnemy, StyleHUD ___shud, EnemyIdentifier ___eid)
        {
            string text = "";
            int num = 50;
            RevolverBeam revolverBeam;
            if (___altBeam != null && ___altBeam.TryGetComponent<RevolverBeam>(out revolverBeam) && revolverBeam.ultraRicocheter)
            {
                text = "<color=orange>" + LanguageManager.CurrentLanguage.style.style_ricoshotUltra + "</color>";
                num += 50;
            }
            if (___wasShotByEnemy)
            {
                text += "<color=red>" + LanguageManager.CurrentLanguage.style.style_ricoshotCounter + "</color>";
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

        public static bool GetLocalizedName_MyPatch(string id, StyleHUD __instance, Dictionary<string, string> ___idNameDict, ref string __result)
        {
            if (___idNameDict.ContainsKey(id))
            {
                __result = StyleBonusStrings.getStyleBonusDictionary(id);
                return false;
            }
            __result = StyleBonusStrings.getTranslatedStyleBonus(id);
            return false;
        }

        public static bool UpdateFreshnessSlider_MyPatch(StyleHUD __instance, GunControl ___gc)
        {
            StyleFreshnessState freshnessState = __instance.GetFreshnessState(___gc.currentWeapon);
            __instance.freshnessSliderText.text = StyleBonusStrings.getWeaponFreshness(freshnessState);

            return false;
        }

        public static bool Start_MyPatch(IntermissionController __instance, ref string ___preText, ref string ___fullString, ref Text ___txt)
        {
            ___txt = __instance.GetComponent<Text>();
            ___fullString = ___txt.text;
            ___txt.text = "";

            IntermissionStrings intStrings = new IntermissionStrings();
            ___fullString = intStrings.getIntermissionString(___fullString);
            ___txt.text = ___fullString;

            //Section for 2-S Mirage's names.
            if (SceneManager.GetActiveScene().name == "Level 2-S")
            {
                string openingTag = "<color=grey>";
                string closingTag = "</color>";
                string mirageName = Regex.Replace(___preText, @"<[^>]*>", "");
                Console.WriteLine(mirageName);
                switch (mirageName)
                {
                    case ("???:"): { break; }
                    case ("JUST SOMEONE:"): { ___preText = openingTag + LanguageManager.CurrentLanguage.visualnovel.visualnovel_mirageName1 + closingTag + ":"; break; }
                    case ("THE PRETTIEST GIRL IN TOWN:"): { ___preText = openingTag + LanguageManager.CurrentLanguage.visualnovel.visualnovel_mirageName2 + closingTag + ":"; break; }
                    case ("MIRAGE:"): { ___preText = openingTag + LanguageManager.CurrentLanguage.visualnovel.visualnovel_mirageName3 + closingTag + ":"; break; }
                    default: { break; }
                }
            }
                return true;
        }

        public static bool DisplaySubtitle_MyPatch(SubtitleController __instance, Subtitle ___subtitleLine, Transform ___container, Subtitle ___previousSubtitle, ref string caption, AudioSource audioSource = null)
        {
            caption = SubtitleStrings.getSubtitle(caption);
            return true;
        }


        //@Override
        //Overrides the DisplayInfo method from the EnemyInfoPage class. This is to allow swapping out of monster bios in the shop.
        public static void DisplayInfo_Postfix(SpawnableObject source, EnemyInfoPage __instance, Text ___enemyPageTitle, Text ___enemyPageContent)
        {
            string enemyName = EnemyBios.getName(source.objectName);
            string enemyType = EnemyBios.getType(source.type);
            string enemyDescription = EnemyBios.getDescription(source.objectName);
            string enemyStrategy = EnemyBios.getStrategy(source.objectName);

            ___enemyPageTitle.text = enemyName;
            string text = "<color=orange>" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_type + ": " + enemyType + "\n\n" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_data + "</color>\n";
            if (MonoSingleton<BestiaryData>.Instance.GetEnemy(source.enemyType) > 1)
            {
                text += enemyDescription;
            }
            else
            {
                text += "???";
            }
            text = text + "\n\n<color=orange>" + LanguageManager.CurrentLanguage.enemyBios.enemyBios_strategy + ":</color>\n" + enemyStrategy;
            ___enemyPageContent.text = text;

        }

        //@Override
        //Overrides the *private* UpdateSlotState method from the SaveSlotMenu class. This is to allow save menu strings to be swapped out.
        public static void UpdateSlotState_Postfix(SlotRowPanel targetPanel, SaveSlotMenu.SlotData data)
        {
            bool flag = GameProgressSaver.currentSlot == targetPanel.slotIndex;
            targetPanel.selectButton.GetComponentInChildren<Text>().text = (flag ? LanguageManager.CurrentLanguage.options.save_selected : LanguageManager.CurrentLanguage.options.save_select);
            targetPanel.stateLabel.text = SaveToString(data.exists, data.highestLvlNumber, data.highestDifficulty);

            GameObject deleteButtonText = targetPanel.deleteButton.gameObject;
            GameObject child = deleteButtonText.transform.GetChild(0).gameObject;

            Text deleteText = child.GetComponent<Text>();
            deleteText.text = LanguageManager.CurrentLanguage.options.save_delete;
        }

        public static string SaveToString(bool exists, int highestLvlNumber, int highestDifficulty)
        {
            if (!exists)
            {
                return LanguageManager.CurrentLanguage.options.save_slotEmpty;
            }

            string highestDiff = MonoSingleton<PresenceController>.Instance.diffNames[highestDifficulty];
            Console.WriteLine(highestDiff);

            switch(highestDiff)
            {
                case "HARMLESS": { highestDiff = LanguageManager.CurrentLanguage.frontend.difficulty_harmless; break; }
                case "LENIENT": { highestDiff = LanguageManager.CurrentLanguage.frontend.difficulty_lenient; break; }
                case "STANDARD": { highestDiff = LanguageManager.CurrentLanguage.frontend.difficulty_standard; break; }
                case "VIOLENT": { highestDiff = LanguageManager.CurrentLanguage.frontend.difficulty_violent; break; }
                case "BRUTAL": { highestDiff = LanguageManager.CurrentLanguage.frontend.difficulty_brutal; break; }
                case "ULTRAKILL MUST DIE": { highestDiff = LanguageManager.CurrentLanguage.frontend.difficulty_umd; break; }
                default: { highestDiff = "UNKNOWN DIFFICULTY"; break; }
            }

            return LevelNames.getLevelName(highestLvlNumber) + " " + ((highestLvlNumber <= 0) ? string.Empty : ("(" + highestDiff + ")"));
        }

        //@Override
        //Overrides the *private* ClearSlot method from the SaveSlotMenu class. This is to swap out the delete confirmation string.
        public static void ClearSlotPostfix_MyPatch(int slot, Text ___wipeConsentContent)
        {
            ___wipeConsentContent.text = string.Format(LanguageManager.CurrentLanguage.options.save_deleteWarning1 + " <color=red>" + LanguageManager.CurrentLanguage.options.save_deleteWarning2 + " {0}</color>?", slot + 1);
            return;
        }


        public static bool SendActivity_MyPatch(DiscordController __instance, Discord.Activity ___cachedActivity, RankIcon[] ___rankIcons, Discord.ActivityManager ___activityManager)
        {
            //Details: Contains total style if in a normal level or wave number if in CG.
            if (SceneManager.GetActiveScene().name != "Main Menu")
            {
                try 
                { 
                    string[] splitDetails = ___cachedActivity.Details.Split(' ');
                    string[] splitState = ___cachedActivity.Details.Split(' ');

                    if (splitDetails[0] == "STYLE:")
                    {
                        ___cachedActivity.Details = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_style + ": " + splitDetails[1];
                    }
                    else if (splitDetails[0] == "WAVE:")
                    {
                        ___cachedActivity.Details = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wave + ": " + splitDetails[1];
                    }
                }
                catch(Exception splitException)
                {
                    Console.WriteLine("Exception occured in SendActivity, should be harmless unless if the console gets spammed with this");
                }
            }
            else
            {
                ___cachedActivity.Details = "";
            }

            //State: Contains current difficulty if in-level, or only displays "Main Menu"
            if(SceneManager.GetActiveScene().name == "Main Menu")
            {
                ___cachedActivity.State = LanguageManager.CurrentLanguage.levelNames.levelName_mainMenu;
            }
            else
            {
                string translatedDifficulty = MonoSingleton<PresenceController>.Instance.diffNames[MonoSingleton<PrefsManager>.Instance.GetInt("difficulty", 0)];
                ___cachedActivity.State = LanguageManager.CurrentLanguage.frontend.difficulty_title + ": " + translatedDifficulty;
            }

            //Assets.SmallText: Rank name
            switch (___cachedActivity.Assets.SmallText)
            {
                case "Destructive": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_d;break; }
                case "Chaotic": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_c; break; }
                case "Brutal": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_b; break; }
                case "Anarchic": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_a; break; }
                case "Supreme": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_s; break; }
                case "SSadistic": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_ss; break; }
                case "SSShitstorm": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_sss; break; }
                case "ULTRAKILL": { ___cachedActivity.Assets.SmallText = LanguageManager.CurrentLanguage.style.style_ultrakill; break; }
                default: { break; }
            }

            //Assets.LargeText = Level name
            ___cachedActivity.Assets.LargeText = LevelNames.getDiscordLevelName(SceneManager.GetActiveScene().name);

            //Shoot the data off to Discord RPC.
            ___activityManager.UpdateActivity(___cachedActivity, delegate (Discord.Result result)
            {
            });

            return false;
        }

        public static void LevelStatsStart_Postfix(LevelStats __instance, StatsManager ___sman)
        {
            if (__instance.secretLevel)
            {
                __instance.levelName.text = LanguageManager.CurrentLanguage.frontend.chapter_secretMission;
            }
            if (MonoSingleton<MapLoader>.Instance && MonoSingleton<MapLoader>.Instance.isCustomLoaded)
            {
                MapInfo instance = MapInfo.Instance;
                __instance.levelName.text = ((instance != null) ? instance.levelName : "???");
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
                    __instance.levelName.text = LevelNames.getDiscordLevelName(SceneManager.GetActiveScene().name);
                }
            }
        }

        public static void CheckStats_Postfix(LevelStats __instance, StatsManager ___sman)
        {
            if (__instance.challenge)
            {
                if (MonoSingleton<ChallengeManager>.Instance.challengeDone && !MonoSingleton<ChallengeManager>.Instance.challengeFailed)
                {
                    __instance.challenge.text = "<color=#FFAF00>" + LanguageManager.CurrentLanguage.misc.state_yes + "</color>";
                }
                else
                {
                    __instance.challenge.text = LanguageManager.CurrentLanguage.misc.state_no;
                }
            }
            if (__instance.majorAssists)
            {
                if (___sman.majorUsed)
                {
                    __instance.majorAssists.text = "<color=#4C99E6>" + LanguageManager.CurrentLanguage.misc.state_yes + "</color>";
                    return;
                }
                __instance.majorAssists.text = LanguageManager.CurrentLanguage.misc.state_no;
            }
        }

        //@Override
        //Overrides the *private* UpdateCheatState function from the CheatsManager class for translating the cheat menu.
        public static bool UpdateCheatState_MyPatch(CheatMenuItem item, ICheat cheat, CheatsManager __instance, Color ___enabledColor, Color ___disabledColor)
        {
            try
            {
                item.longName.text = Cheats.getCheatName(cheat.Identifier);
                item.stateBackground.color = (cheat.IsActive ? ___enabledColor : ___disabledColor);

                string cheatDisabledStatus = Cheats.getCheatStatus(cheat.ButtonDisabledOverride);
                string cheatEnabledStatus = Cheats.getCheatStatus(cheat.ButtonEnabledOverride);

                item.stateText.text = (cheat.IsActive ? (cheatEnabledStatus ?? LanguageManager.CurrentLanguage.cheats.cheats_activated) : (cheatDisabledStatus ?? LanguageManager.CurrentLanguage.cheats.cheats_deactivated)); //Cheat status
                item.bindButtonBack.gameObject.SetActive(false);
                string text = MonoSingleton<CheatBinds>.Instance.ResolveCheatKey(cheat.Identifier);
                if (string.IsNullOrEmpty(text))
                {
                    item.bindButtonText.text = LanguageManager.CurrentLanguage.cheats.cheats_pressToBind; //Press to bind
                }
                else
                {
                    item.bindButtonText.text = text.ToUpper();
                }
                GameObject parentResetButton = item.resetBindButton.gameObject;
                Text parentResetText = CommonFunctions.getTextfromGameObject(CommonFunctions.getGameObjectChild(parentResetButton, "Text"));
                parentResetText.text = LanguageManager.CurrentLanguage.cheats.cheats_delete;
                __instance.RenderCheatsInfo();
                return false;
            }
            catch (Exception e)
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
                stringBuilder.AppendLine(LanguageManager.CurrentLanguage.cheats.cheats_navmeshOutdated1 + "\n\n" + LanguageManager.CurrentLanguage.cheats.cheats_navmeshOutdated2);
            }
            if (__instance.GetCheatState("ultrakill.spawner-arm"))
            {
                stringBuilder.AppendLine(LanguageManager.CurrentLanguage.cheats.cheats_spawnerArmSlot);
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
                    stringBuilder.Append("<color=white>" + Cheats.getCheatName(cheat2.Identifier) + "</color>\n");
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
                ___stateButtonText.text = (customPatternMode ? LanguageManager.CurrentLanguage.misc.state_deactivated : LanguageManager.CurrentLanguage.misc.state_activated);
                GameObject gameObject = __instance.enableWhenCustom;
                if (gameObject != null)
                {
                    gameObject.SetActive(!customPatternMode);
                }
                MonoSingleton<PrefsManager>.Instance.SetBoolLocal("cyberGrind.customPool", MonoSingleton<EndlessGrid>.Instance.customPatternMode);

                return false;
            }
            catch (Exception e)
            {
                handleError(e);
                return true;
            }
        }
    }
}
