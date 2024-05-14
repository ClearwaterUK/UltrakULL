using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltrakULL.json;
using UnityEngine.UI;
using TMPro;

namespace UltrakULL.Harmony_Patches
{
	[HarmonyPatch(typeof(FinalRank), "SetRank")]
	public static class FinalRank_SetRankPatch
	{
		static bool enablepatchSetRank = true;
		[HarmonyPrefix]
		public static void Patch(FinalRank __instance, ref string rank)
		{
			try
			{
				if (!enablepatchSetRank) { return; }
				Logging.Info("CALLED SET RANK :D");
				Logging.Info(rank[16].ToString());

				Rank ranks = LanguageManager.CurrentLanguage.ranks;
				string replacement = "_";

				switch (rank[15].ToString())
				{
					case "P":
						if (ranks.P != null)
						{
							// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang P!");
							replacement = ranks.P;
							// return __result;
						}
						break;
					case "C":
						if (ranks.C != null)
						{
							// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang C!");
							replacement = ranks.C;
							// return __result;
						}
						break;
					case "B":
						if (ranks.B != null)
						{
							// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang B!");
							replacement = ranks.B;
							// return __result;
						}
						break;
					case "A":
						if (ranks.A != null)
						{
							// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang A!");
							replacement = ranks.A;
							// return __result;
						}
						break;
					case "S":
						if (ranks.S != null)
						{
							// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang S!");
							replacement = ranks.S;
							// return __result;
						}
						break;
					case "D":
						if (ranks.D != null)
						{
							// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang D!");
							replacement = ranks.D;
							// return __result;
						}
						break;
				}

				char[] chars = rank.ToCharArray();
				chars[15] = replacement[0];

				rank = new string(chars);
			}
            catch (Exception e)
            {
                Logging.Warn("Failed to Patch SetRank :(");
                Logging.Warn(e.Message);
                enablepatchSetRank = false;
                return;
            }
        }

		[HarmonyPatch(typeof(StatsManager), "GetRanks")]
		public static class StatsManager_GetRanksPatch
        {
            [HarmonyPostfix]
			public static void Patch(FinalRank __instance, ref string __result, int[] ranksToCheck, float value, bool reverse, bool addToRankScore = false)
			{
                try
                {
                    string rank = __result;
					Rank ranks = LanguageManager.CurrentLanguage.ranks;
					if(ranks == null)
					{
						Logging.Warn("Ranks is null in JSON lang file! Is ranks section missing?");
						return;
					}
					string replacement = "_";
					switch (rank[15].ToString())
					{
						case "P":
							if (ranks.P != null)
							{
								// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang P!");
								replacement = ranks.P;
								// return __result;
							}
							break;
						case "C":
							if (ranks.C != null)
							{
								// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang C!");
								replacement = ranks.C;
								// return __result;
							}
							break;
						case "B":
							if (ranks.B != null)
							{
								// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang B!");
								replacement = ranks.B;
								// return __result;
							}
							break;
						case "A":
							if (ranks.A != null)
							{
								// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang A!");
								replacement = ranks.A;
								// return __result;
							}
							break;
						case "S":
							if (ranks.S != null)
							{
								// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang S!");
								replacement = ranks.S;
								// return __result;
							}
							break;
						case "D":
							if (ranks.D != null)
							{
								// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang D!");
								replacement = ranks.D;
								// return __result;
							}
							break;
					}

					char[] chars = rank.ToCharArray();
					chars[15] = replacement[0];

					__result = new string(chars);
				}
                catch (Exception e)
                {
                    Logging.Warn("Failed to Patch GetRanks :(");
                    Logging.Warn(e.ToString());
                    return;
                }
            }
		}

		[HarmonyPatch(typeof(LevelSelectPanel), nameof(LevelSelectPanel.CheckScore))]
		public static class LevelSelectPanel_CheckScorePatch
		{
            static bool enableLevelSelectfix = true;
            [HarmonyPostfix]
			public static void Postfix(LevelSelectPanel __instance)
			{
                try
				{
                    TextMeshProUGUI componentInChildren = __instance.transform.Find("Stats").Find("Rank").GetComponentInChildren<TextMeshProUGUI>();

					Rank ranks = LanguageManager.CurrentLanguage.ranks;
					string replacement = "_";
					string rank = componentInChildren.text;

					//componentInChildren.alignment = UnityEngine.TextAnchor.LowerCenter;
					//componentInChildren.resizeTextForBestFit = true;

					// at least 16 in length, otherwise its 99.999% certain to be nothing.
					if (rank.Length < 16)
						return;

					switch (rank[15].ToString())
					{
						case "P":
							if (ranks.P != null)
							{
								// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang P!");
								replacement = ranks.P;
								// return __result;
							}
							break;
						case "C":
							if (ranks.C != null)
							{
								// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang C!");
								replacement = ranks.C;
								// return __result;
							}
							break;
						case "B":
							if (ranks.B != null)
							{
								// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang B!");
								replacement = ranks.B;
								// return __result;
							}
							break;
						case "A":
							if (ranks.A != null)
							{
								// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang A!");
								replacement = ranks.A;
								// return __result;
							}
							break;
						case "S":
							if (ranks.S != null)
							{
								// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang S!");
								replacement = ranks.S;
								// return __result;
							}
							break;
						case "D":
							if (ranks.D != null)
							{
								// Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang D!");
								replacement = ranks.D;
								// return __result;
							}
							break;
						default:
							// this means that we havent played
							return;
					}

					char[] chars = rank.ToCharArray();
					chars[15] = replacement[0];

					componentInChildren.text = new string(chars);
				}
				catch (Exception e) 
				{ 
					Logging.Warn("Failed to Patch Level Menu :(");
                    if (LanguageManager.CurrentLanguage.ranks == null)
                    { Logging.Warn("Category \"Ranks\" is missing from the language file!"); return; }
                    Logging.Warn(e.ToString());
					enableLevelSelectfix = false;
                    return;
				}
			}
		}
	}
}
