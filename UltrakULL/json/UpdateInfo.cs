namespace UltrakULL.json
{
    public class UpdateInfo
    {
        public string tag_name;
    }
    
    public class LanguageInfo
    {
        public string languageTag;
        public string languageFullName;
        public string author;
        
    }
    public class MasterLanguages
    {
        public LanguageInfo[] availableLanguages;
    }
}