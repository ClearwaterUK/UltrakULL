using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL
{
    public static class Books
    {
        public static string GetBookText(string originalText)
        {
            string currentLevel = GetCurrentSceneName();

            switch(currentLevel)
            {
                case "CreditsMuseum2":
                {
                    return DevMuseum.GetMuseumBook(originalText);
                }
                case "Level 1-4": {
                        return "<b>" + LanguageManager.CurrentLanguage.books.books_limboFourth1 + "</b>\n\n"
                        + "<i>" + LanguageManager.CurrentLanguage.books.books_limboFourth2 + "\n\n"
                        + LanguageManager.CurrentLanguage.books.books_limboFourth3 + "\n\n"
                        + LanguageManager.CurrentLanguage.books.books_limboFourth4 + "</i>\n\n"
                        + "<b>" + LanguageManager.CurrentLanguage.books.books_limboFourth5 + "</b>";
                    }
                case "Level 2-2":
                    {
                        return "<b>" + LanguageManager.CurrentLanguage.books.books_lustSecond1 + "</b>\n\n"
                        + "<i>" + LanguageManager.CurrentLanguage.books.books_lustSecond2 + "\n\n"
                        + LanguageManager.CurrentLanguage.books.books_lustSecond3 + "\n\n"
                        + LanguageManager.CurrentLanguage.books.books_lustSecond4 + "</i>\n\n"
                        + "<b>" + LanguageManager.CurrentLanguage.books.books_lustSecond5 + "</b>";
                    }

                case "Level 4-2": {
                        return "<b>" + LanguageManager.CurrentLanguage.books.books_greedSecond1 + "</b>\n\n"
                        + "<i>" + LanguageManager.CurrentLanguage.books.books_greedSecond2 + "\n\n"
                        + LanguageManager.CurrentLanguage.books.books_greedSecond3 + "\n\n"
                        + LanguageManager.CurrentLanguage.books.books_greedSecond4 + "\n\n"
                        + LanguageManager.CurrentLanguage.books.books_greedSecond5 + "</i>\n\n"
                        + "<b>" + LanguageManager.CurrentLanguage.books.books_greedSecond6 + "</b>";
                    }

                case "Level 4-3": {
                        return LanguageManager.CurrentLanguage.books.books_greedThird1 + "\n\n"
                            + LanguageManager.CurrentLanguage.books.books_greedThird2 + "\n\n"
                            + LanguageManager.CurrentLanguage.books.books_greedThird3 + "\n\n"
                            + LanguageManager.CurrentLanguage.books.books_greedThird4;
                    }

                case "Level 5-2": {
                        return
                            "<b>" + LanguageManager.CurrentLanguage.books.books_wrathSecond1 + "</b>\n\n"
                            + "<b>" + LanguageManager.CurrentLanguage.books.books_wrathSecond2 + "</b>\n\n"
                            + LanguageManager.CurrentLanguage.books.books_wrathSecond3 + "\n\n"
                            + LanguageManager.CurrentLanguage.books.books_wrathSecond4 + "\n\n"
                            + LanguageManager.CurrentLanguage.books.books_wrathSecond5 + "\n\n"
                            + "<i>" + LanguageManager.CurrentLanguage.books.books_wrathSecond6 + "</i>\n\n"
                            + LanguageManager.CurrentLanguage.books.books_wrathSecond7 + "\n\n"
                            + LanguageManager.CurrentLanguage.books.books_wrathSecond8 + "\n\n"
                            + "<b>" + LanguageManager.CurrentLanguage.books.books_wrathSecond9 + "</b>";
                    }
                
                case "Level 5-S":
                {
                    //Book
                    if(originalText.Contains("DAY 529"))
                    {
                        return 
                        LanguageManager.CurrentLanguage.fishing.fish_book1 + "\n\n"
                                                                           
                        + LanguageManager.CurrentLanguage.fishing.fish_book2 + "\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_book3 + "\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_book4 + "\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_book8 + "\n\n"
                        
                        + LanguageManager.CurrentLanguage.fishing.fish_book5 + "\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_book6 + "\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_book7 + "\n\n"
                        
                        + LanguageManager.CurrentLanguage.fishing.fish_book8 + "\n\n"
                        
                        + LanguageManager.CurrentLanguage.fishing.fish_book7 + "\n"
                        + LanguageManager.CurrentLanguage.fishing.fish_book8 + "\n\n"
                        
                        + LanguageManager.CurrentLanguage.fishing.fish_book7 + " "
                        + LanguageManager.CurrentLanguage.fishing.fish_book8
                        
                        + "<size=47>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=45>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=43>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=41>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=39>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=37>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=35>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=33>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=31>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=29>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=27>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=25>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=23>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=21>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=19>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=17>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=15>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=13>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=11>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=9>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=7>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=5>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=3>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>\n"
                        + "<size=1>" + LanguageManager.CurrentLanguage.fishing.fish_book9 + "</size>"
                        
                        +  LanguageManager.CurrentLanguage.fishing.fish_book10;
                    }
                    //Bottle message
                    else
                    {
                        return LanguageManager.CurrentLanguage.fishing.fish_bottleMessage1 + "\n\n\n"
                            + LanguageManager.CurrentLanguage.fishing.fish_bottleMessage2 + "\n\n\n"
                            + LanguageManager.CurrentLanguage.fishing.fish_bottleMessage3 + "\n\n\n"
                            + LanguageManager.CurrentLanguage.fishing.fish_bottleMessage4 + "\n\n\n"
                            + LanguageManager.CurrentLanguage.fishing.fish_bottleMessage5 + "\n\n\n"
                            + LanguageManager.CurrentLanguage.fishing.fish_bottleMessage6;
                    }
                    
                    
                }
                
                case "Level 7-1": {
                    //Book
                    if(originalText.Contains("The unending halls of")) {
                        return "<b>" + LanguageManager.CurrentLanguage.books.books_violenceFirst1 + "</b>\n"
                        + "<b>" + LanguageManager.CurrentLanguage.books.books_violenceFirst2 + "</b>\n\n"
                        + LanguageManager.CurrentLanguage.books.books_violenceFirst3 + "\n\n"
                        + LanguageManager.CurrentLanguage.books.books_violenceFirst4 + "\n\n\n"
                        + LanguageManager.CurrentLanguage.books.books_violenceFirst5 + "\n\n"
                        + LanguageManager.CurrentLanguage.books.books_violenceFirst6 + "\n\n"
                        + LanguageManager.CurrentLanguage.books.books_violenceFirst7 + "\n\n"
                        + LanguageManager.CurrentLanguage.books.books_violenceFirst8 + "\n\n"
                        + "<color=red>" + LanguageManager.CurrentLanguage.books.books_violenceFirst9 + "</color>";
                    }
                    
                    //Johninator Slate thing...?
                    else {
                        return LanguageManager.CurrentLanguage.books.books_violenceFirst_Slate1 + "\n\n"
                            + LanguageManager.CurrentLanguage.books.books_violenceFirst_Slate2 + "\n\n"
                            + LanguageManager.CurrentLanguage.books.books_violenceFirst_Slate3 + "\n\n"
                            + LanguageManager.CurrentLanguage.books.books_violenceFirst_Slate4;
                    }
                }

                case "Level 7-2": {
                        return LanguageManager.CurrentLanguage.books.books_violenceSecond1 + "\n\n"
                            + LanguageManager.CurrentLanguage.books.books_violenceSecond2 + "\n\n"
                            + "> < < > < < > > < > > < >";
                    }

                case "Level 7-4": {
                        return "<size=20><color=red>" + LanguageManager.CurrentLanguage.books.books_violenceFourth1 + "</color></size>\n\n\n"
                            + "<size=20><color=red>" + LanguageManager.CurrentLanguage.books.books_violenceFourth2 + "</color></size>\n\n\n"
                            + "<size=20><color=red>" + LanguageManager.CurrentLanguage.books.books_violenceFourth3 + "</color></size>\n\n\n"
                            + "<size=20><color=red>" + LanguageManager.CurrentLanguage.books.books_violenceFourth4 + "</color></size>\n\n"
                            + "<size=20>" + LanguageManager.CurrentLanguage.books.books_violenceFourth5 + "</size>";
                    }
                
                default: { return "Unknown book"; }
            }
        }
    }
}
