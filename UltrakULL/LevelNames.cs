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
using UltrakULL.json;

namespace UltrakULL
{
	class LevelNames
	{

		public static string getDiscordLevelName(string missionName, JsonParser language)
        {
			if (missionName.Contains("Main Menu")) { return language.currentLanguage.levelNames.levelName_mainMenu; }
			if (missionName.Contains("Endless")) { return language.currentLanguage.levelNames.levelName_cybergrind; }
			if (missionName.Contains("uk_construct")) { return language.currentLanguage.levelNames.levelName_sandbox; }

			if (missionName.Contains("0-1")){ return language.currentLanguage.levelNames.levelName_preludeFirst; }
			if (missionName.Contains("0-2")) { return language.currentLanguage.levelNames.levelName_preludeSecond; }
			if (missionName.Contains("0-3")) { return language.currentLanguage.levelNames.levelName_preludeThird; }
			if (missionName.Contains("0-4")) { return language.currentLanguage.levelNames.levelName_preludeFourth; }
			if (missionName.Contains("0-5")) { return language.currentLanguage.levelNames.levelName_preludeFifth; }
			if (missionName.Contains("0-S")) { return language.currentLanguage.levelNames.levelName_preludeSecret; }

			if (missionName.Contains("1-1")) { return language.currentLanguage.levelNames.levelName_limboFirst; }
			if (missionName.Contains("1-2")) { return language.currentLanguage.levelNames.levelName_limboSecond; }
			if (missionName.Contains("1-3")) { return language.currentLanguage.levelNames.levelName_limboThird; }
			if (missionName.Contains("1-4")) { return language.currentLanguage.levelNames.levelName_limboFourth; }
			if (missionName.Contains("1-S")) { return language.currentLanguage.levelNames.levelName_limboSecret; }

			if (missionName.Contains("2-1")) { return language.currentLanguage.levelNames.levelName_lustFirst; }
			if (missionName.Contains("2-2")) { return language.currentLanguage.levelNames.levelName_lustSecond; }
			if (missionName.Contains("2-3")) { return language.currentLanguage.levelNames.levelName_lustThird; }
			if (missionName.Contains("2-4")) { return language.currentLanguage.levelNames.levelName_lustFourth; }
			if (missionName.Contains("2-S")) { return language.currentLanguage.levelNames.levelName_lustSecret; }

			if (missionName.Contains("3-1")) { return language.currentLanguage.levelNames.levelName_gluttonyFirst; }
			if (missionName.Contains("3-2")) { return language.currentLanguage.levelNames.levelName_gluttonySecond; }
		
			if (missionName.Contains("4-1")) { return language.currentLanguage.levelNames.levelName_greedFirst; }
			if (missionName.Contains("4-2")) { return language.currentLanguage.levelNames.levelName_greedSecond; }
			if (missionName.Contains("4-3")) { return language.currentLanguage.levelNames.levelName_greedThird; }
			if (missionName.Contains("4-4")) { return language.currentLanguage.levelNames.levelName_greedFourth; }
			if (missionName.Contains("4-S")) { return language.currentLanguage.levelNames.levelName_greedSecret; }

			if (missionName.Contains("P-1")) { return language.currentLanguage.levelNames.levelName_primeFirst; }

			return ("Unknown level - " + missionName);
        }

        public string getLevelName(int missionNum, JsonParser language)
        {
			
			if (MonoSingleton<MapLoader>.Instance && MonoSingleton<MapLoader>.Instance.isCustomLoaded)
			{
				return MapInfoBase.InstanceAnyType.levelName;
			}
			switch (missionNum)
			{
				case 0:
					return language.currentLanguage.levelNames.levelName_mainMenu;
				case 1:
					return "0-1: " + language.currentLanguage.levelNames.levelName_preludeFirst;
				case 2:
					return "0-2: " + language.currentLanguage.levelNames.levelName_preludeSecond;
				case 3:
					return "0-3: " + language.currentLanguage.levelNames.levelName_preludeThird;
				case 4:
					return "0-4: " + language.currentLanguage.levelNames.levelName_preludeFourth;
				case 5:
					return "0-5: " + language.currentLanguage.levelNames.levelName_preludeFifth;
				case 6:
					return "1-1: " + language.currentLanguage.levelNames.levelName_limboFirst;
				case 7:
					return "1-2: " + language.currentLanguage.levelNames.levelName_limboSecond;
				case 8:
					return "1-3: " + language.currentLanguage.levelNames.levelName_limboThird;
				case 9:
					return "1-4: " + language.currentLanguage.levelNames.levelName_limboFourth;
				case 10:
					return "2-1: " + language.currentLanguage.levelNames.levelName_lustFirst;
				case 11:
					return "2-2: " + language.currentLanguage.levelNames.levelName_lustSecond;
				case 12:
					return "2-3: " + language.currentLanguage.levelNames.levelName_lustThird;
				case 13:
					return "2-4: " + language.currentLanguage.levelNames.levelName_lustFourth;
				case 14:
					return "3-1: " + language.currentLanguage.levelNames.levelName_gluttonyFirst;
				case 15:
					return "3-2: " + language.currentLanguage.levelNames.levelName_gluttonySecond;
				case 16:
					return "4-1: " + language.currentLanguage.levelNames.levelName_greedFirst;
				case 17:
					return "4-2: " + language.currentLanguage.levelNames.levelName_greedSecond;
				case 18:
					return "4-3: " + language.currentLanguage.levelNames.levelName_greedThird;
				case 19:
					return "4-4: " + language.currentLanguage.levelNames.levelName_greedFourth;
				case 20:
					return "5-1: " + language.currentLanguage.levelNames.levelName_wrathFirst;
				default:
					switch (missionNum)
					{
						case 666:
							return "P-1:" + language.currentLanguage.levelNames.levelName_primeFirst;
						case 667:
							return "P-2:" + language.currentLanguage.levelNames.levelName_primeSecond;
						case 668:
							return "P-3:" + language.currentLanguage.levelNames.levelName_primeThird;
						default:
							return "MISSION NAME NOT FOUND";
					}
			}
		}

        public LevelNames()
        {

        }


    }
}
