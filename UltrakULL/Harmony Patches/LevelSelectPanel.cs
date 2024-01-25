﻿using HarmonyLib;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

using static UltrakULL.CommonFunctions;

namespace UltrakULL.Harmony_Patches
{
	//@Override
	//Overrides checkScore function from the vanilla game. This translates level names, as well as if challenges have been completed or not. POSTFIX.
	[HarmonyPatch(typeof(LevelSelectPanel), "CheckScore")]
	public static class LocalizeGameProgressChallenges
	{
		[HarmonyPostfix]
		public static void CheckScore_MyPatchPostFix(LevelSelectPanel __instance)
		{
			if(isUsingEnglish())
			{
				return;
			}
			int num = __instance.levelNumber;
			RankData rank = GameProgressSaver.GetRank(num, false);

			//Bandaid fix for P-2 and P-3 for now since they share the same level id as P-1 for some reason. Shall need to change/remove when they release.
			if (__instance.transform.Find("Name").GetComponent<Text>().text.Contains("P-2"))
			{
				__instance.transform.Find("Name").GetComponent<Text>().text =
					"P-2:" + (LanguageManager.CurrentLanguage.levelNames.levelName_primeSecond);
			}
			else if (__instance.transform.Find("Name").GetComponent<Text>().text.Contains("P-3"))
			{
				__instance.transform.Find("Name").GetComponent<Text>().text = "P-3: ???";
			}
			else
			{
				string levelName = LevelNames.GetLevelName(num);
				if (LanguageManager.IsRightToLeft)
				{
					string lvlNumber = "";
					char[] lnum = levelName.Substring(0, 3).ToCharArray();

					lvlNumber+=lnum[2];
					lvlNumber+=lnum[1];
					lvlNumber+=lnum[0];

					string lvlTitle = levelName.Substring(5);

					levelName = $"{lvlTitle} :{lvlNumber}";
				}
				__instance.transform.Find("Name").GetComponent<Text>().text = levelName; //Level Name
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
			else
			{

				Text componentInChildren3 = __instance.challengeIcon.GetComponentInChildren<Text>();
				componentInChildren3.text = String.Join(" ", LanguageManager.CurrentLanguage.frontend.level_challenge.ToList()); //Challenge not completed
				componentInChildren3.color = Color.white;
			}
		}
	}
}
