using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using ArabicSupportUnity;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using Newtonsoft.Json;
using UltrakULL.audio;
using UltrakULL.Harmony_Patches;
using UnityEngine.SceneManagement;
using static UltrakULL.CommonFunctions;

namespace UltrakULL.json
{
    public static class LanguageManager
    {
        public static Dictionary<string, JsonFormat> allLanguages = new Dictionary<string, JsonFormat>();
        private static Dictionary<string, JsonFormat> allLanguagesDisplayNames = new Dictionary<string, JsonFormat>();
        public static JsonFormat CurrentLanguage { get; private set; }
        private static ManualLogSource jsonLogger = Logger.CreateLogSource("LanguageManager");
        public static ConfigFile configFile;

        public static void InitializeManager(string modVersion)
        {
            LoadLanguages(modVersion);

            configFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "ultrakull", "lastLang.cfg"), true);

            string value = configFile.Bind("General", "LastLanguage", "en-GB").Value;
            string dubValue = configFile.Bind("General","activeDubbing","False").Value;

            if (allLanguages.ContainsKey(value))
            {
                jsonLogger.Log(LogLevel.Message, "Setting language to " + value);
                CurrentLanguage = allLanguages[value];
                if(CurrentLanguage.metadata.langRTL == "true")
                {
                    Logging.Message("Language is set as RTL - applying fix!");
                    CurrentLanguage = ApplyRtl(CurrentLanguage);
                }
            }
            else
            {
                jsonLogger.Log(LogLevel.Message, "Previous lang file is missing from disk: " + value);
                Logging.Warn("Setting language back to en-GB to avoid problems");
                Core.wasLanguageReset = true;
                CurrentLanguage = allLanguages["en-GB"];
                SetCurrentLanguage("en-GB");
            }
            
            LoadSubtitledSourcesConfig();
        }

        public static void DumpLastLanguage()
        {
            configFile.Bind("General", "LastLanguage", "en-GB").Value = CurrentLanguage.metadata.langName; // Thank you copilot
        }

        public static void LoadLanguagesInDirectory(string modVersion, string path)
        {
            Logging.Info($"Loading all language files in \"{path}\"");

            string[] files = Directory.GetFiles(path, "*.json");
            string[] subdirectories = Directory.GetDirectories(path);

			foreach (string file in files)
			{
                Logging.Info($"Trying to load \"{file}\"");
				if (TryLoad(file, out JsonFormat lang) && !allLanguages.ContainsKey(lang.metadata.langName) && lang.metadata.langName != "te-mp")
				{
					allLanguages.Add(lang.metadata.langName, lang);
					allLanguagesDisplayNames.Add(lang.metadata.langDisplayName, lang);
					if (!ValidateFile(lang, modVersion))
						jsonLogger.Log(LogLevel.Debug, "Failed to validate " + lang.metadata.langName);
				}
			}

            foreach (string directory in  subdirectories)
            {
                LoadLanguagesInDirectory(modVersion, directory);
            }
		}

        public static void LoadLanguages(string modVersion)
        {
            Logging.Message("Loading language files stored locally on disk...");
            
            allLanguages = new Dictionary<string, JsonFormat>();

            LoadLanguagesInDirectory(modVersion, Path.Combine(Paths.ConfigPath, "ultrakull"));
        }

        private static void LoadSubtitledSourcesConfig()
        {
            var config = Encoding.Default.GetString(Resources.SubtitledSources);
            SubtitledAudioSourcesReplacer.Config = JsonConvert.DeserializeObject<SubtitledSourcesConfig>(config);
        }

        private static bool TryLoad<T>(string pathName, out T file)
        {
            file = default;
            try
            {
                string jsonFile = File.ReadAllText(pathName);
                file = JsonConvert.DeserializeObject<T>(jsonFile);
                return true;
            }
            catch (Exception e)
            {
                Logging.Error("Failed to load language file " + pathName + ": " + e.Message);
                return false;
            }
        }

        private static bool ValidateFile(JsonFormat language, string modVersion)
        {
            try
            {
                //Following conditions to validate a file:
                //Must be JSON-deserializable
                //Must have a metadata attribute and a body attribute
                //Version logged in the JSON file must match or be newer than the current mod version
                //Will need to implement further sanity checks.
                //Logging.Message("Checking version...");

                if (!FileMatchesMinimumRequiredVersion(language.metadata.minimumModVersion, modVersion))
                {
                    Logging.Warn(language.metadata.langName + " was made for an older game version.");
                    return false;
                }

                Logging.Message("Checking contents...");
                if (language.metadata != null && language.body != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Logging.Error("An error occured while validating. It's possible the language file is not correctly formatted in .json.\n"
                    + "Please use https://jsonlint.com/ to make sure your .json file is correctly formatted!");
                Logging.Error(e.ToString());
                return false;
            }
        }

        public static bool FileMatchesMinimumRequiredVersion(string requiredModVersion, string actualModVersion)
        {
            if (requiredModVersion == "")
            {
                Logging.Error("Language file has not defined the minimum mod version required!");
                return false;
            }

            Version jsonVersion = new Version(requiredModVersion);
            Version ultrakullVersion = new Version(actualModVersion);
            int isCompatible = jsonVersion.CompareTo(ultrakullVersion);

            //JSON version is greater or matches mod version
            if (jsonVersion == ultrakullVersion || isCompatible > 0)
            {
                return true;
            }
            //JSON version is lower than mod version
            else
            {
                return false;
            }
        }

        private static JsonFormat ApplyRtl(JsonFormat language)
		{
			//Logging.Warn("ApplyRtl Breakpoint #1");


			List<object> translationComponents = new List<object>
            {
                language.frontend,
                language.tutorial,
                language.prelude,
                language.act1,
                language.act2,
                language.act3,
                language.cyberGrind,
                language.primeSanctum,
                language.secretLevels,
                language.intermission,
                language.pauseMenu,
                language.options,
                language.levelNames,
                language.levelChallenges,
                language.enemyNames,
                language.enemyBios,
                language.shop,
                language.levelTips,
                language.books,
                language.visualnovel,
                language.subtitles,
                language.style,
                language.cheats,
                language.misc,
                language.devMuseum
            };


			//Logging.Warn("ApplyRtl Breakpoint #2");

			foreach (object component in translationComponents)
			{
                try
                {
                    Type type = component.GetType();
                    FieldInfo[] fields = type.GetFields();
                    foreach (FieldInfo field in fields)
                    {
                        string originalString = (string)field.GetValue(component);
                        string translatedString = null;

                        if (originalString != null)
                        {

                            //Logging.Warn("ApplyRtl Breakpoint #3");
                            //Apply the RTL fix here
                            translatedString = ArabicFixer.Fix(originalString);
                        }
                        if (translatedString != null)
                        {

                            //Logging.Warn("ApplyRtl Breakpoint #4");
                            field.SetValue(component, translatedString);
                        }
                    }



                    //Logging.Warn("ApplyRtl Breakpoint #5");
                }
                catch (Exception ex)
                {
                    Logging.Warn($"ULL caught an exception while trying to fix a RTL language! {ex.Message} \nSource: {ex.Source}\nStack Trace:{ex.StackTrace}");
                }

				//Logging.Warn("ApplyRtl Breakpoint #6");
			}

			//Logging.Warn("ApplyRtl Breakpoint #7");
			return language;
        }

        public static void SetCurrentLanguage(string langName)
        {
            if (CurrentLanguage != null && CurrentLanguage.metadata.langName == langName)
            {
                Logging.Warn("Tried to switch language to " + langName + " but it was already set as that!");
                return;
            }
            if (allLanguages.ContainsKey(langName))
            {
                CurrentLanguage = allLanguages[langName];
                Logging.Message( "Setting language to " + langName);
                
                if(CurrentLanguage.metadata.langRTL == "true")
                {
                    Logging.Message("Language is an RTL - applying fix!");
                    CurrentLanguage = ApplyRtl(CurrentLanguage);
                }
                
                MainPatch.Instance.onSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
                DumpLastLanguage();
                AudioSwapper.SpeechFolder = Path.Combine(Paths.ConfigPath,"ultrakull", "audio", CurrentLanguage.metadata.langName) + Path.DirectorySeparatorChar;
                SubtitledAudioSourcesReplacer.SpeechFolder = AudioSwapper.SpeechFolder;
                
                //Patch some leftover components that aren't caught in the main change wave...
                InjectLanguageButton.updateLanguageButtonText();
                LoadingTextPatch.updateLoadingText();
					
                if(GetCurrentSceneName() != "Main Menu")
                {
                    MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage("<color=orange>Language changes will not fully take effect until the current mission is quit or restarted.</color>");
                }
            }
            else
                Logging.Warn("No language found with name " + langName);
        }
    }
}
