using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using BepInEx;
using BepInEx.Configuration;

namespace UltrakULL.json
{
    public class JsonParser
    {
        BepInEx.Logging.ManualLogSource jsonLogger = BepInEx.Logging.Logger.CreateLogSource("JSONParser");

        bool bepReady;

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

        private bool validateFile(string fileName)
        {
            jsonLogger.LogInfo(fileName);
            jsonLogger.LogInfo("Opening file...");
            try
            {
                //Following conditions to validate a file:
                //Must be JSON-deserializable
                //Must have a metadata attribute and a body attribute
                //Will need to implement further sanity checks.

                string jsonFile = File.ReadAllText(fileName);

                jsonLogger.LogInfo("Deserializing...");
                JsonFormat deserialisedLang = JsonConvert.DeserializeObject<JsonFormat>(jsonFile);

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
                //Console.WriteLine(e.ToString());
                return false;
            }
        }

        public Dictionary<string,bool> enumerateLanguages()
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
                        if(validateFile(file))
                        {
                            validatedFiles.Add(file, true);
                        }
                    }
                    if (validatedFiles.Count == 0)
                    {
                        jsonLogger.LogError("No language files have been validated. Falling back to default game language.");
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
                if(languages[absoluteLangPath])
                { 
                    jsonLogger.LogMessage("File exists and is validated. Loading it");
                    return true;
                }
                else
                {
                    jsonLogger.LogError("Language file " + this.cfgLastLanguage.Value + " is not validated.");
                    return false;
                }
            }
            else
            {
                jsonLogger.LogError("Language file " + this.cfgLastLanguage.Value + ".json does not exist.");
                return false;
            }
        }

        public void loadLanguage(string fileName)
        {
            Console.WriteLine("Loading strings from " + fileName);
            string file = languageDir + this.cfgLastLanguage.Value + ".json";
            Console.WriteLine(file);

            this.currentLanguage = JsonConvert.DeserializeObject<JsonFormat>(File.ReadAllText(file));
        }

        public JsonParser()
        {
            Console.WriteLine(dir);
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
                    Dictionary<string,bool> languages = enumerateLanguages();
                    if(checkSavedLanguage(languages))
                    {
                        loadLanguage(this.cfgLastLanguage.Value);
                    }
                    else
                    {
                        jsonLogger.LogError("Unable to load saved language from config file, falling back to default game language.");
                        throw new Exception("Unable to load language. Falling back to default");
                    }
                }
                else
                {
                    jsonLogger.LogWarning("Language folder not detected, doing first-time setup");
                    //firstTimeConfig();
                }
            }
           else
            {

            }
        }
    }
}
