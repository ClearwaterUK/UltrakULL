using BepInEx.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace UltrakULL.json
{
    public class JsonParser
    {
        BepInEx.Logging.ManualLogSource jsonLogger = BepInEx.Logging.Logger.CreateLogSource("JSONParser");

        bool bepReady;

        public bool loadedLanguageIsOudated = false;

        ConfigFile configFile;

        public static string dir = Directory.GetCurrentDirectory() + "\\BepInEx\\config\\";
        public static string languageDir = dir + "ultrakull\\";
        public static string cfgFile = "BepInEx\\config\\ultrakull\\lastLang.cfg";

        private ConfigEntry<string> cfgLastLanguage;

        public JsonFormat currentLanguage;

        private bool languageFolderExists()
        {
            return (Directory.Exists(languageDir));
        }

        private bool validateFile(string fileName, string modVersion)
        {
            jsonLogger.LogInfo("Opening file: " + fileName + "...");
            try
            {
                //Following conditions to validate a file:
                //Must be JSON-deserializable
                //Must have a metadata attribute and a body attribute
                //Version logged in the JSON file must match or be newer than the current mod version
                //Will need to implement further sanity checks.

                string jsonFile = File.ReadAllText(fileName);

                jsonLogger.LogInfo("Deserializing...");
                JsonFormat deserialisedLang = JsonConvert.DeserializeObject<JsonFormat>(jsonFile);

                jsonLogger.LogInfo("Checking version...");

                if (!(this.fileMatchesMinimumRequiredVersion(deserialisedLang.metadata.minimumModVersion, modVersion)))
                {
                    jsonLogger.LogError(fileName + " does not match the version required by the mod. Skipping.");
                    jsonLogger.LogError("(If you wish to force load this file, you may do so via manually editing lastLang.cfg and setting the language to this filename. Expect in-game errors if you do this, you have been warned.)");
                    return false;
                }

                jsonLogger.LogInfo("Checking contents...");
                if(deserialisedLang.metadata != null && deserialisedLang.body != null)
                {
                    jsonLogger.LogMessage("File " + deserialisedLang.metadata.langName + " validated.");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                jsonLogger.LogError("An error occured while validating. It's possible the language file is not correctly formatted in .json.\n"
                    + "Please use https://jsonlint.com/ to make sure your .json file is correctly formatted!");
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public Dictionary<string,bool> enumerateLanguages(string modVersion)
        {
            if(languageFolderExists())
            {
                string[] files = Directory.GetFiles(languageDir, "*.json");
                Dictionary<string, bool> validatedFiles = new Dictionary<string, bool>();
                if(files.Length == 0)
                {
                    jsonLogger.LogError("No language files detected. Falling back to default game language.");
                    return null;
                }
                else
                {
                    Console.WriteLine(files.Length + " language file(s) detected.");
                    foreach(string file in files)
                    {
                        if(validateFile(file,modVersion))
                        {
                            validatedFiles.Add(file, true);
                        }
                    }
                    if (validatedFiles.Count == 0)
                    {
                        jsonLogger.LogError("No detected language files have been validated!");
                        return null;
                    }
                    else
                    {
                        Console.WriteLine(validatedFiles.Count + " language file(s) validated.");
                    }
                    return validatedFiles;
                }
            }
            else
            {
                jsonLogger.LogError("Unable to access language folder, falling back to default game language.");
                return null;
            }
        }

        public bool checkSavedLanguage(Dictionary<string, bool> languages)
        {
            //Read the saved language in the config file, check if it's validated.
            //If it is, load it.
            jsonLogger.LogInfo("Opening config file...");

            Console.WriteLine("Lang in config file:" + this.cfgLastLanguage.Value);
            string absoluteLangPath = languageDir + this.cfgLastLanguage.Value + ".json";

            if (File.Exists(absoluteLangPath))
            {
                jsonLogger.LogMessage("File exists. Loading it");
                return true;
            }
            else
            {
                jsonLogger.LogError("Language file " + this.cfgLastLanguage.Value + ".json does not exist.");
                return false;
            }
        }

        public void loadLanguage(string fileName, string modVersion)
        {
            Console.WriteLine("Loading strings from " + fileName);
            string file = languageDir + this.cfgLastLanguage.Value + ".json";
            Console.WriteLine(file);

            this.currentLanguage = JsonConvert.DeserializeObject<JsonFormat>(File.ReadAllText(file));

            if(!this.fileMatchesMinimumRequiredVersion(this.currentLanguage.metadata.minimumModVersion, modVersion))
            {
                jsonLogger.LogWarning("WARNING: JSON version is outdated or does not match the current mod version.\n Since this file was force loaded, you may get errors or abnormal behavior related to missing strings.");
                jsonLogger.LogWarning("JSON version:" + this.currentLanguage.metadata.minimumModVersion);
                jsonLogger.LogWarning("Mod version:" + modVersion);
                this.loadedLanguageIsOudated = true;
            }
        }

        public bool fileMatchesMinimumRequiredVersion(string requiredModVersion, string actualModVersion)
        {
            if (requiredModVersion == "")
            {
                jsonLogger.LogError("Language file has not defined the minimum mod version required!");
                return false;
            }

            Version jsonVersion = new Version(requiredModVersion);
            Version ultrakullVersion = new Version(actualModVersion);
            int isCompatible = jsonVersion.CompareTo(ultrakullVersion);

            //JSON version is greater or matches mod version
            if (jsonVersion == ultrakullVersion || isCompatible > 0) 
            {
                jsonLogger.LogMessage("Matches current mod version.");
                return true;
            }
            //JSON version is lower than mod version
            else
            {
                return false;
            }
        }

        public JsonParser(string modVersion)
        {
            jsonLogger.LogInfo("Checking if base BepInEx exists");
            if(Directory.Exists(dir))
            {
                this.bepReady = true;
            }

           if(this.bepReady)
           {
                try
                {
                    Console.WriteLine("Reading config file...");
                    this.configFile = new ConfigFile(cfgFile, true);
                    this.cfgLastLanguage = this.configFile.Bind("General", "lastLanguage", "ab-cd", "The language file to load");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to open/create config file, aborting.");
                    Console.WriteLine(e.Message);
                    return;
                }

                if (languageFolderExists())
                {
                    jsonLogger.LogMessage("Language folder detected, getting languages");
                    Dictionary<string,bool> languages = enumerateLanguages(modVersion);
                    if(checkSavedLanguage(languages))
                    {
                        loadLanguage(this.cfgLastLanguage.Value,modVersion);
                    }
                    else
                    {
                        throw new Exception("Unable to load saved language from config file, falling back to default game language.");
                    }
                }
                else
                {
                    jsonLogger.LogWarning("Language folder not detected, doing first-time setup");
                    //firstTimeConfig();
                }
            }
        }
    }
}
