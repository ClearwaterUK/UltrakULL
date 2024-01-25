using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches
{
	public static class RankHelperPatch
	{
		[HarmonyPrefix]
		[HarmonyPatch(typeof(RankHelper), nameof(RankHelper.GetRankLetter))]
		public static string GetRankLetter(int rank)
		{
			Rank ranks = LanguageManager.CurrentLanguage.ranks;
			if (rank < 0)
			{
				return "";
			}

			switch (rank)
			{
				case 12:
					if (ranks.P != null)
						return ranks.P;
					return "P";
				case 1:
					if (ranks.C != null)
						return ranks.C;
					return "C";
				case 2:
					if (ranks.B != null)
						return ranks.B;
					return "B";
				case 3:
					if (ranks.A != null)
						return ranks.A;
					return "A";
				case 4:
				case 5:
				case 6:
					if (ranks.S != null)
						return ranks.S;
					return "S";
				default:
					if (ranks.D != null)
						return ranks.D;
					return "D";
			}
		}
	}
}
