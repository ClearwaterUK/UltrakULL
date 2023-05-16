using BepInEx.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ArabicSupportUnity;
using Discord;
using UltrakULL.audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UltrakULL.json
{
    public static class LanguageManager
    {
        public static Dictionary<string, JsonFormat> allLanguages = new Dictionary<string, JsonFormat>();
        private static Dictionary<string, JsonFormat> allLanguagesDisplayNames = new Dictionary<string, JsonFormat>();
        public static JsonFormat CurrentLanguage { get; private set; }
        private static BepInEx.Logging.ManualLogSource jsonLogger = BepInEx.Logging.Logger.CreateLogSource("LanguageManager");
        public static ConfigFile configFile;

        public static void InitializeManager(string modVersion)
        {
            LoadLanguages(modVersion);

            configFile = new ConfigFile("BepInEx\\config\\ultrakull\\lastLang.cfg", true);

            string value = configFile.Bind("General", "LastLanguage", "en-GB").Value;
            string dubValue = configFile.Bind("General","activeDubbing","False").Value;

            if (allLanguages.ContainsKey(value))
            {
                jsonLogger.Log(BepInEx.Logging.LogLevel.Message, "Setting language to " + value);
                CurrentLanguage = allLanguages[value];
                if(CurrentLanguage.metadata.langRTL == "true")
                {
                    Logging.Message("Language is set as RTL - applying fix!");
                    CurrentLanguage = ApplyRtl(CurrentLanguage);
                }
            }
            else
            {
                jsonLogger.Log(BepInEx.Logging.LogLevel.Message, "No last language found, value was " + value);
            }
        }

        public static void DumpLastLanguage()
        {
            configFile.Bind("General", "LastLanguage", "en-GB").Value = CurrentLanguage.metadata.langName; // Thank you copilot
        }

        public static void LoadLanguages(string modVersion)
        {
            Logging.Warn("Loading language files stored locally on disk...");
            
            allLanguages = new Dictionary<string, JsonFormat>();
            string[] files = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory() + "\\BepInEx\\config\\", "UltrakULL"), "*.json");
            foreach (string file in files)
            {
                if (TryLoadLang(file, out JsonFormat lang) && !allLanguages.ContainsKey(lang.metadata.langName) && lang.metadata.langName != "te-mp")
                {
                    allLanguages.Add(lang.metadata.langName, lang);
                    allLanguagesDisplayNames.Add(lang.metadata.langDisplayName, lang);
                    if (!ValidateFile(lang, modVersion))
                        jsonLogger.Log(BepInEx.Logging.LogLevel.Debug ,"Failed to validate " + lang.metadata.langName + " however I don't really care");
                }
            }
        }

        private static bool TryLoadLang(string pathName, out JsonFormat file)
        {
            file = null;
            try
            {
                string jsonFile = File.ReadAllText(pathName);
                file = JsonConvert.DeserializeObject<JsonFormat>(jsonFile);
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
            Logging.Message("Opening file: " + language.metadata.langName + "...");
            try
            {
                //Following conditions to validate a file:
                //Must be JSON-deserializable
                //Must have a metadata attribute and a body attribute
                //Version logged in the JSON file must match or be newer than the current mod version
                //Will need to implement further sanity checks.
                Logging.Message("Checking version...");

                if (!FileMatchesMinimumRequiredVersion(language.metadata.minimumModVersion, modVersion))
                {
                    Logging.Warn(language.metadata.langName + " does not match the version required by the mod. Please check for an update to this file.");
                    Logging.Warn("You can still use this file, but expect errors and weirdness related to missing strings. Consider yourself warned.");
                    return false;
                }

                Logging.Message("Checking contents...");
                if (language.metadata != null && language.body != null)
                {
                    Logging.Message("File " + language.metadata.langName + " validated.");
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
                Logging.Warn("File does not current mod version.");
                return false;
            }
        }

        private static JsonFormat ApplyRtl(JsonFormat language)
        {
            List<object> translationComponents = new List<object>
            {
                language.frontend,
                language.tutorial,
                language.prelude,
                language.act1,
                language.act2,
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
            
            foreach(object component in translationComponents)
            {
                Type type = component.GetType();
                FieldInfo[] fields = type.GetFields();
                foreach (FieldInfo field in fields)
                {
                    string originalString = (string)field.GetValue(component); 
                    string translatedString = null;
                    
                    if(originalString != null)
                    {
                        //Apply the RTL fix here
                        translatedString = ArabicFixer.Fix(originalString);
                    }
                    if(translatedString != null)
                    {
                        field.SetValue(component,translatedString);
                    }
                }
            }
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
                
                MainPatch.instance.onSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
                LanguageManager.DumpLastLanguage();
                AudioSwapper.speechFolder = Directory.GetCurrentDirectory() + "\\BepInEx\\config\\ultrakull\\audio\\" + LanguageManager.CurrentLanguage.metadata
                    .langName + "\\";
            }
            else
                Logging.Warn("No language found with name " + langName);
        }
    }
}
