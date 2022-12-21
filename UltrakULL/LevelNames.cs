using UltrakULL.json;

namespace UltrakULL
{
	public static class LevelNames
	{

		public static string GetDiscordLevelName(string missionName)
        {
			if (missionName.Contains("Main Menu")) { return LanguageManager.CurrentLanguage.levelNames.levelName_mainMenu; }
			if (missionName.Contains("Endless")) { return LanguageManager.CurrentLanguage.levelNames.levelName_cybergrind; }
			if (missionName.Contains("uk_construct")) { return LanguageManager.CurrentLanguage.levelNames.levelName_sandbox; }
			if (missionName.Contains("Tutorial")) { return LanguageManager.CurrentLanguage.levelNames.levelName_tutorial; }

			if (missionName.Contains("0-1")) { return "0-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFirst; }
			if (missionName.Contains("0-2")) { return "0-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeSecond; }
			if (missionName.Contains("0-3")) { return "0-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeThird; }
			if (missionName.Contains("0-4")) { return "0-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFourth; }
			if (missionName.Contains("0-5")) { return "0-5: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFifth; }
			if (missionName.Contains("0-S")) { return "0-S: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeSecret; }

			if (missionName.Contains("1-1")) { return "1-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboFirst; }
			if (missionName.Contains("1-2")) { return "1-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboSecond; }
			if (missionName.Contains("1-3")) { return "1-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboThird; }
			if (missionName.Contains("1-4")) { return "1-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboFourth; }
			if (missionName.Contains("1-S")) { return "1-S: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboSecret; }

			if (missionName.Contains("2-1")) { return "2-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustFirst; }
			if (missionName.Contains("2-2")) { return "2-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustSecond; }
			if (missionName.Contains("2-3")) { return "2-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustThird; }
			if (missionName.Contains("2-4")) { return "2-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustFourth; }
			if (missionName.Contains("2-S")) { return "2-S: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustSecret; }

			if (missionName.Contains("3-1")) { return "3-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_gluttonyFirst; }
			if (missionName.Contains("3-2")) { return "3-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_gluttonySecond; }
		
			if (missionName.Contains("4-1")) { return "4-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedFirst; }
			if (missionName.Contains("4-2")) { return "4-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedSecond; }
			if (missionName.Contains("4-3")) { return "4-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedThird; }
			if (missionName.Contains("4-4")) { return "4-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedFourth; }
			if (missionName.Contains("4-S")) { return "4-S: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedSecret; }

			if (missionName.Contains("5-1")) { return "5-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathFirst; }
			if (missionName.Contains("5-2")) { return "5-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathSecond; }
			if (missionName.Contains("5-3")) { return "5-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathThird; }
			if (missionName.Contains("5-4")) { return "5-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathFourth; }
			if (missionName.Contains("5-S")) { return "5-5: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathSecret; }

			if (missionName.Contains("6-1")) { return "6-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_heresyFirst; }
			if (missionName.Contains("6-2")) { return "6-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_heresySecond; }

			if (missionName.Contains("P-1")) { return "P-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_primeFirst; }

			if (missionName.Contains("Intermission")) { return "???"; }

			return ("Unknown level - " + missionName);
        }

        public static string GetLevelName(int missionNum)
        {
	        if (MonoSingleton<MapLoader>.Instance && MonoSingleton<MapLoader>.Instance.isCustomLoaded)
			{
				return MapInfoBase.InstanceAnyType.levelName;
			}
			switch (missionNum)
			{
				case 0:
					return LanguageManager.CurrentLanguage.levelNames.levelName_mainMenu;
				case 1:
					return "0-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFirst;
				case 2:
					return "0-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeSecond;
				case 3:
					return "0-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeThird;
				case 4:
					return "0-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFourth;
				case 5:
					return "0-5: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFifth;
				case 6:
					return "1-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboFirst;
				case 7:
					return "1-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboSecond;
				case 8:
					return "1-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboThird;
				case 9:
					return "1-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboFourth;
				case 10:
					return "2-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustFirst;
				case 11:
					return "2-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustSecond;
				case 12:
					return "2-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustThird;
				case 13:
					return "2-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustFourth;
				case 14:
					return "3-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_gluttonyFirst;
				case 15:
					return "3-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_gluttonySecond;
				case 16:
					return "4-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedFirst;
				case 17:
					return "4-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedSecond;
				case 18:
					return "4-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedThird;
				case 19:
					return "4-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedFourth;
				case 20:
					return "5-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathFirst;
				case 21:
					return "5-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathSecond;
				case 22:
					return "5-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathThird;
				case 23:
					return "5-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathFourth;
				case 24:
					return "6-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_heresyFirst;
				case 25:
					return "6-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_heresySecond;
				case 26:
					return "7-1: ???";
				default:
					switch (missionNum)
					{
						case 666:
							return "P-1:" + LanguageManager.CurrentLanguage.levelNames.levelName_primeFirst;
						case 667:
							return "P-2:" + LanguageManager.CurrentLanguage.levelNames.levelName_primeSecond;
						case 668:
							return "P-3:" + LanguageManager.CurrentLanguage.levelNames.levelName_primeThird;
						default:
							return "MISSION NAME NOT FOUND";
					}
			}
		}
    }
}
