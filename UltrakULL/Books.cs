using System.Collections.Generic;
using Antlr4.StringTemplate;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Books
    {
        private const string WantToBelieve = "I_WANT_TO_BELIEVE";
        private const string BottleMessage = "BOTTLE_MESSAGE";

        private static readonly TemplateGroup BooksTemplates = new TemplateGroupString(Resources.Books);
        private static readonly Dictionary<string, string> TemplatePerLevel = new Dictionary<string, string>()
        {
            { "Level 1-4", "CLAIR_DE_LUNE" },
            { "Level 2-2", "DEATH_AT_20000_VOLTS" },
            { "Level 4-2", "GOD_DAMN_THE_SUN" },
            { "Level 4-3", "SHOT_IN_THE_DARK" },
            { "Level 5-2", "WAVES_OF_THE_STARLESS_SEA" }
        };

        static Books()
        {
            BooksTemplates.SetDelimiters('$', '$');
            BooksTemplates.EnableCache = false;
        }
        
        public static string GetBookText(string originalText)
        {
            var currentLevel = GetCurrentSceneName();
            if (currentLevel == "CreditsMuseum2")
                return DevMuseum.GetMuseumBook(originalText);
            
            if (TemplatePerLevel.TryGetValue(currentLevel, out var t))
                return BooksTemplates.GetInstanceOf(t)
                    .Add("books", LanguageManager.CurrentLanguage.books)
                    .Render();

            string template = default;
            if (currentLevel == "Level 5-S")
                template = originalText.Contains("DAY 529")
                    ? WantToBelieve
                    : BottleMessage;
            
            
            return template != default
                ? BooksTemplates
                    .GetInstanceOf(template)
                    .Add("fishing", LanguageManager.CurrentLanguage.fishing)
                    .Render()
                : "Unknown book";
        }
    }
}
