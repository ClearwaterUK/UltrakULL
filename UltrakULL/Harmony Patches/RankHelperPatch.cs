using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches
{

	[HarmonyPatch(typeof(RankHelper), nameof(RankHelper.GetRankLetter))]
	public static class RankHelperPatch
	{
		[HarmonyPostfix]
		public static void Patch(ref string __result, int rank)
		{
			// string __result;
#if DEBUG
			Logging.Info("[DEBUG] RankHelper::GetRankLetter -> CALLED");
#endif
			Rank ranks = LanguageManager.CurrentLanguage.ranks;
			if (rank < 0)
			{
				// return "";
				return;
			}

			switch (rank)
			{
				case 12:
					if (ranks.P != null)
					{
						Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang P!");
						__result = ranks.P;
						// return __result;
					}
					break;
				case 1:
					if (ranks.C != null)
					{
						Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang C!");
						__result = ranks.C;
						// return __result;
					}
					break;
				case 2:
					if (ranks.B != null)
					{
						Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang B!");
						__result = ranks.B;
						// return __result;
					}
					break;
				case 3:
					if (ranks.A != null)
					{
						Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang A!");
						__result = ranks.A;
						// return __result;
					}
					break;
				case 4:
				case 5:
				case 6:
					if (ranks.S != null)
					{
						Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang S!");
						__result = ranks.S;
						// return __result;
					}
					break;
				default:
					if (ranks.D != null)
					{
						Logging.Info("[DEBUG] RankHelper::GetRankLetter -> Result is lang D!");
						__result = ranks.D;
						// return __result;
					}
					break;
			}
			// return "";
		}
	}
}
