using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

using UltrakULL.json;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
    //@Override
    //Overrides the *private* UpdateSlotState method from the SaveSlotMenu class. This is to allow save menu strings to be swapped out.
    [HarmonyPatch(typeof(SaveSlotMenu), "UpdateSlotState")]
    public static class LocalizeSaveSlots
    {
        [HarmonyPostfix]
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
    }

    //@Override
    //Overrides the *private* ClearSlot method from the SaveSlotMenu class. This is to swap out the delete confirmation string.
    [HarmonyPatch(typeof(SaveSlotMenu), "ClearSlot")]
    public static class LocalizeSaveSlotDeleteConsent
    {
        [HarmonyPostfix]
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
