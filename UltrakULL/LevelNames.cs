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
			if (missionName.Contains("CreditsMuseum2")) { return LanguageManager.CurrentLanguage.levelNames.levelName_devMuseum; }

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
			if (missionName.Contains("5-S")) { return "5-S: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathSecret; }

			if (missionName.Contains("6-1")) { return "6-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_heresyFirst; }
			if (missionName.Contains("6-2")) { return "6-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_heresySecond; }

			if (missionName.Contains("7-1")) { return "7-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceFirst; }
			if (missionName.Contains("7-2")) { return "7-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceSecond; }
			if (missionName.Contains("7-3")) { return "7-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceThird; }
			if (missionName.Contains("7-4")) { return "7-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceFourth; }
			if (missionName.Contains("7-S")) { return "7-S: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceSecret; }

			if (missionName.Contains("8-1")) { return "8-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudFirst; }
			if (missionName.Contains("8-2")) { return "8-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudSecond; }
			if (missionName.Contains("8-3")) { return "8-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudThird; }
			if (missionName.Contains("8-4")) { return "8-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudFourth; }
			if (missionName.Contains("8-S")) { return "8-S: " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudSecret; }

			if (missionName.Contains("9-1")) { return "9-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_treacheryFirst; }
			if (missionName.Contains("9-2")) { return "9-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_treacherySecond; }
			
			if (missionName.Contains("P-1")) { return "P-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_primeFirst; }
			if (missionName.Contains("P-2")) { return "P-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_primeSecond; }
			if (missionName.Contains("P-3")) { return "P-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_primeThird; }

			if (missionName.Contains("Intermission")) { return "???"; }

	        Logging.Warn("Unknown level name: " + missionName);
			return missionName;
        }

		public static string GetLevelName(int missionNum)
		{
			if (SceneHelper.IsPlayingCustom)
			{
				return MapInfoBase.InstanceAnyType.levelName;
			}
			if (LanguageManager.CurrentLanguage.metadata.langHinduNumbers == null || LanguageManager.CurrentLanguage.metadata.langHinduNumbers != "true")
			{
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
						return "7-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceFirst;
					case 27:
						return "7-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceSecond;
					case 28:
						return "7-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceThird;
					case 29:
						return "7-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceFourth;
					case 30:
						return "8-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudFirst;
					case 31:
						return "8-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudSecond;
					case 32:
						return "8-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudThird;
					case 33:
						return "8-4: " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudFourth;
					case 34:
						return "9-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_treacheryFirst;
					case 35:
						return "9-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_treacherySecond;
					default:
						switch (missionNum)
						{
							case 666:
								return "P-1: " + LanguageManager.CurrentLanguage.levelNames.levelName_primeFirst;
							case 667:
								return "P-2: " + LanguageManager.CurrentLanguage.levelNames.levelName_primeSecond;
							case 668:
								return "P-3: " + LanguageManager.CurrentLanguage.levelNames.levelName_primeThird;
							default:
								return "MISSION NAME NOT FOUND";
						}
				}
			}
			else
			{
				switch (missionNum)
				{
					case 0:
						return LanguageManager.CurrentLanguage.levelNames.levelName_mainMenu;
					case 1:
						return "٠-١: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFirst;
					case 2:
						return "٠-٢: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeSecond;
					case 3:
						return "٠-٣: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeThird;
					case 4:
						return "٠-٤: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFourth;
					case 5:
						return "٠-٥: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeFifth;
					case 6:
						return "١-١: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboFirst;
					case 7:
						return "١-٢: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboSecond;
					case 8:
						return "١-٣: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboThird;
					case 9:
						return "١-٤: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboFourth;
					case 10:
						return "٢-١: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustFirst;
					case 11:
						return "٢-٢: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustSecond;
					case 12:
						return "٢-٣: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustThird;
					case 13:
						return "٢-٤: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustFourth;
					case 14:
						return "٣-١: " + LanguageManager.CurrentLanguage.levelNames.levelName_gluttonyFirst;
					case 15:
						return "٣-٢: " + LanguageManager.CurrentLanguage.levelNames.levelName_gluttonySecond;
					case 16:
						return "٤-١: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedFirst;
					case 17:
						return "٤-٢: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedSecond;
					case 18:
						return "٤-٣: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedThird;
					case 19:
						return "٤-٤: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedFourth;
					case 20:
						return "٥-١: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathFirst;
					case 21:
						return "٥-٢: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathSecond;
					case 22:
						return "٥-٣: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathThird;
					case 23:
						return "٥-٤: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathFourth;
					case 24:
						return "٦-١: " + LanguageManager.CurrentLanguage.levelNames.levelName_heresyFirst;
					case 25:
						return "٦-٢: " + LanguageManager.CurrentLanguage.levelNames.levelName_heresySecond;
					case 26:
						return "٧-١: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceFirst;
					case 27:
						return "٧-٢: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceSecond;
					case 28:
						return "٧-٣: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceThird;
					case 29:
						return "٧-٤: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceFourth;
					case 30:
						return "٨-١: " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudFirst;
					case 31:
						return "٨-٢: " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudSecond;
					case 32:
						return "٨-٣: " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudThird;
					case 33:
						return "٨-٤: " + LanguageManager.CurrentLanguage.levelNames.levelName_fraudFourth;
					case 34:
						return "٩-١: " + LanguageManager.CurrentLanguage.levelNames.levelName_treacheryFirst;
					case 35:
						return "٩-٢: " + LanguageManager.CurrentLanguage.levelNames.levelName_treacherySecond;
					default:
						switch (missionNum)
						{
							case 666:
								return "P-١: " + LanguageManager.CurrentLanguage.levelNames.levelName_primeFirst;
							case 667:
								return "P-٢: " + LanguageManager.CurrentLanguage.levelNames.levelName_primeSecond;
							case 668:
								return "P-٣: " + LanguageManager.CurrentLanguage.levelNames.levelName_primeThird;
							default:
								return "MISSION NAME NOT FOUND";
						}
				}
			}
		}
    }
}
