using System;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

using UltrakULL.json;

using static UltrakULL.CommonFunctions;
using System.IO;
using TMPro;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch(typeof(SaveLoadFailMessage), "DisplayMergeConsentInstance")]
    public static class LocalizeSaveLoadFailMessage
    {
        [HarmonyPostfix]
        public static void DisplaySaveMergeConsentPostfix(SaveLoadFailMessage __instance, SaveSlotMenu.SlotData rootSlot, SaveSlotMenu.SlotData slotOneData, Text ___rootMergeOptionBtnText, Text ___slotOneMergeOptionBtnText) 
        {
            try
            {
                //Merge Consent Screen. this can be activated by dumping the files in the Saves/Slot(any) to the Saves folder.
                try
                {
                    GameObject mergeConsentMessage = __instance.transform.GetChild(0).GetChild(0).gameObject;
                    string dupeSaveConsentText =
                        "<b>" + LanguageManager.CurrentLanguage.options.save_failMergeError1 + "</b>\r\n\r\n"
                        + LanguageManager.CurrentLanguage.options.save_failMergeError2 + "\r\n\r\n\r\n"
                        + LanguageManager.CurrentLanguage.options.save_failMergeError3;
                    try
                    {
                        Text dupeSaveText = mergeConsentMessage.transform.GetChild(0).GetComponent<Text>();
                        dupeSaveText.text = dupeSaveConsentText;
                    }
                    catch (NullReferenceException)
                    {
                        Logging.Warn("No Text Component found in \n" +
                            "\"Canvas/Save-Load Fail Message/Merge Consent Wrapper/Message/Text\"." +
                            "This is fine to ignore, but if you reading this, report in the discord.");
                        TextMeshProUGUI dupeSaveText = mergeConsentMessage.GetComponent<TextMeshProUGUI>();
                        dupeSaveText.text = dupeSaveConsentText;
                    }
                    GameObject quitButtonTextObject = GetGameObjectChild(GetGameObjectChild(mergeConsentMessage, "Button Wrapper"), "Quit Button");
                    try
                    {
                        Text quitButtonText = quitButtonTextObject.GetComponentInChildren<Text>();
                        quitButtonText.text = LanguageManager.CurrentLanguage.options.save_failMergeErrorQuitButton;
                    }
                    catch (NullReferenceException)
                    {
                        Logging.Warn("No Text Component found in \n" +
                            "\"Canvas/Save-Load Fail Message/Merge Consent Wrapper/Message/Button Wrapper/Quit Button\"." +
                            "This is fine to ignore, but if you reading this, report in the discord.");
                        TextMeshProUGUI quitButtonText = quitButtonTextObject.GetComponentInChildren<TextMeshProUGUI>();
                        quitButtonText.text = LanguageManager.CurrentLanguage.options.save_failMergeErrorQuitButton;
                    }
                }
                catch (Exception e)
                {
                    Logging.Warn("Failed to patch Save-Load Fail Message. but this message is fine to ignore.");
                    Logging.Warn(e.ToString());
                }
                //Save Fail Message.
                try
                {
                    string saveloadFailText =
                        "<b>! " + LanguageManager.CurrentLanguage.options.save_saveloadFailError1 + " !</b>\r\n\r\n"
                        + LanguageManager.CurrentLanguage.options.save_saveloadFailError2 + "\r\n\r\n" +
                        "<b>" + LanguageManager.CurrentLanguage.options.save_saveloadFailError3 + "</b>\r\n"
                        + LanguageManager.CurrentLanguage.options.save_saveloadFailError4 + "\r\n\r\n"
                        + LanguageManager.CurrentLanguage.options.save_saveloadFailError5 + "\r\n\r\n"
                        + LanguageManager.CurrentLanguage.options.save_saveloadFailError6 + "\r\n"
                        + LanguageManager.CurrentLanguage.options.save_saveloadFailError7 + "\r\n"
                        + LanguageManager.CurrentLanguage.options.save_saveloadFailError8 + "\r\n"
                        + LanguageManager.CurrentLanguage.options.save_saveloadFailError9 + "\r\n\r\n"
                        + LanguageManager.CurrentLanguage.options.save_saveloadFailError10;
                    /*"<b>! SAVE FAILED !</b>\r\n\r\n
                     * The game is unable to finalize saving your progress.\r\n\r\n
                     * <b>COMMON REASONS FOR FAILURE:</b>\r\n
                     * 1. Third party software (such as an antivirus) stopping the game from saving a new file\r\n\r\n
                     * If this problem occurs again, make sure your antivirus or any similar software is not preventing the game from writing files\r\n\r\n
                     * If you wish to try again,
                     * press <b>\"Y\"\r\n</b>
                     * If you wish to continue without saving,\r\n
                     * press <b>\"N\"</b>\r\n\r\n
                     * Sorry and thank you for your understanding. :)"*/
                    try
                    {
                        Text saveLoadFailMessage = __instance.transform.GetChild(1).GetChild(0).GetComponent<Text>();
                        saveLoadFailMessage.text = saveloadFailText;
                    }
                    catch(NullReferenceException)
                    {
                        TextMeshProUGUI saveLoadFailMessage = __instance.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
                        saveLoadFailMessage.text = saveloadFailText;
                    }
                }
                catch (Exception e)
                {
                    Logging.Warn("Failed to patch Save-Load Fail Message. but this message is fine to ignore.");
                    Logging.Warn(e.ToString());
                }
                if (isUsingEnglish()) { return; }
                ___rootMergeOptionBtnText.text = string.Format("<b>Saves{0}</b>\n{1}", Path.DirectorySeparatorChar, LocalizeSaveSlots.SaveToString(rootSlot.exists, rootSlot.highestLvlNumber, rootSlot.highestDifficulty));
                ___slotOneMergeOptionBtnText.text = string.Format("<b>Saves{0}Slot1{1}</b>\n{2}", Path.DirectorySeparatorChar, Path.DirectorySeparatorChar, LocalizeSaveSlots.SaveToString(slotOneData.exists, slotOneData.highestLvlNumber, slotOneData.highestDifficulty));
            }
            catch(Exception e)
            {
                Logging.Warn("Failed to patch Save-Load Fail Messages. this is fine to ignore.");
                Logging.Warn(e.ToString());
            }
        }
    }

    //@Override
    //Overrides the *private* UpdateSlotState method from the SaveSlotMenu class. This is to allow save menu strings to be swapped out.
    [HarmonyPatch(typeof(SaveSlotMenu))]
    public static class LocalizeSaveSlots
    {
        [HarmonyPatch("UpdateSlotState"), HarmonyPostfix]
        public static void UpdateSlotState_Postfix(SlotRowPanel targetPanel, SaveSlotMenu.SlotData data)
        {
            if(isUsingEnglish())
            {
                return;
            }
            bool flag = GameProgressSaver.currentSlot == targetPanel.slotIndex;
            targetPanel.selectButton.GetComponentInChildren<Text>().text = (flag ? LanguageManager.CurrentLanguage.options.save_selected : LanguageManager.CurrentLanguage.options.save_select);
            targetPanel.stateLabel.text = SaveToString(data.exists, data.highestLvlNumber, data.highestDifficulty);

            GameObject deleteButtonText = targetPanel.deleteButton.gameObject;
            GameObject child = deleteButtonText.transform.GetChild(0).gameObject;

            Text deleteText = child.GetComponent<Text>();
            deleteText.text = LanguageManager.CurrentLanguage.options.save_delete;

            switch (targetPanel.slotNumberLabel.text)
            {
                case "Slot 1": { targetPanel.slotNumberLabel.text = LanguageManager.CurrentLanguage.options.save_slot1; break; }
                case "Slot 2": { targetPanel.slotNumberLabel.text = LanguageManager.CurrentLanguage.options.save_slot2; break; }
                case "Slot 3": { targetPanel.slotNumberLabel.text = LanguageManager.CurrentLanguage.options.save_slot3; break; }
                case "Slot 4": { targetPanel.slotNumberLabel.text = LanguageManager.CurrentLanguage.options.save_slot4; break; }
                case "Slot 5": { targetPanel.slotNumberLabel.text = LanguageManager.CurrentLanguage.options.save_slot5; break; }
            }
        }

        public static string SaveToString(bool exists, int highestLvlNumber, int highestDifficulty)
        {
            if (!exists)
            {
                return LanguageManager.CurrentLanguage.options.save_slotEmpty;
            }

            string highestDiff = MonoSingleton<PresenceController>.Instance.diffNames[highestDifficulty];

            switch (highestDiff)
            {
                case "HARMLESS": { highestDiff = LanguageManager.CurrentLanguage.frontend.difficulty_harmless; break; }
                case "LENIENT": { highestDiff = LanguageManager.CurrentLanguage.frontend.difficulty_lenient; break; }
                case "STANDARD": { highestDiff = LanguageManager.CurrentLanguage.frontend.difficulty_standard; break; }
                case "VIOLENT": { highestDiff = LanguageManager.CurrentLanguage.frontend.difficulty_violent; break; }
                case "BRUTAL": { highestDiff = LanguageManager.CurrentLanguage.frontend.difficulty_brutal; break; }
                case "ULTRAKILL MUST DIE": { highestDiff = LanguageManager.CurrentLanguage.frontend.difficulty_umd; break; }
                default: { highestDiff = "UNKNOWN DIFFICULTY"; break; }
            }

            return LevelNames.GetLevelName(highestLvlNumber) + " " + ((highestLvlNumber <= 0) ? string.Empty : ("(" + highestDiff + ")"));
        }

        [HarmonyPatch("ClearSlot"), HarmonyPostfix]
        public static void ClearSlotPostfix_MyPatch(int slot, Text ___wipeConsentContent)
        {
            if(isUsingEnglish())
            {
                return;
            }
            ___wipeConsentContent.text = string.Format(LanguageManager.CurrentLanguage.options.save_deleteWarning1 + " <color=red>" + LanguageManager.CurrentLanguage.options.save_deleteWarning2 + " {0}</color>?", slot + 1);
        }
    }
}
