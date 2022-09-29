using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltrakULL;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using UltrakULL.json;

namespace UltrakULL
{
    public static class Books
    {
        public static string getBookText(JsonParser language)
        {
            string currentLevel = SceneManager.GetActiveScene().name;

            switch(currentLevel)
            {
                case "Level 1-4": {
                        return "<b>" + language.currentLanguage.books.books_limboFourth1 + "</b>\n\n"
                        + "<i>" + language.currentLanguage.books.books_limboFourth2 + "\n\n"
                        + language.currentLanguage.books.books_limboFourth3 + "\n\n"
                        + language.currentLanguage.books.books_limboFourth4 + "</i>\n\n"
                        + "<b>" + language.currentLanguage.books.books_limboFourth5 + "</b>";

                    }
                case "Level 2-2":
                    {
                        return "<b>" + language.currentLanguage.books.books_lustSecond1 + "</b>\n\n"
                        + "<i>" + language.currentLanguage.books.books_lustSecond2 + "\n\n"
                        + language.currentLanguage.books.books_lustSecond3 + "\n\n"
                        + language.currentLanguage.books.books_lustSecond4 + "</i>\n\n"
                        + "<b>" + language.currentLanguage.books.books_lustSecond5 + "<b>";
                    }

                case "Level 4-2": {
                        return "<b>" + language.currentLanguage.books.books_greedSecond1 + "</b>\n\n"
                        + "<i>" + language.currentLanguage.books.books_greedSecond2 + "\n\n"
                        + language.currentLanguage.books.books_greedSecond3 + "\n\n"
                        + language.currentLanguage.books.books_greedSecond4 + "\n\n"
                        + language.currentLanguage.books.books_greedSecond5 + "</i>\n\n"
                        + "<b>" + language.currentLanguage.books.books_greedSecond6 + "</b>\n";
                    }

                case "Level 4-3": {
                        return language.currentLanguage.books.books_greedThird1 + "\n\n"
                            + language.currentLanguage.books.books_greedThird2 + "\n\n"
                            + language.currentLanguage.books.books_greedThird3 + "\n\n"
                            + language.currentLanguage.books.books_greedThird4 + "\n\n";
                    }

                case "Level 5-2": {
                        return
                            "<b>" + language.currentLanguage.books.books_wrathSecond1 + "</b>\n\n"
                            + "<b>" + language.currentLanguage.books.books_wrathSecond2 + "</b>\n\n"
                            + language.currentLanguage.books.books_wrathSecond3 + "\n\n"
                            + language.currentLanguage.books.books_wrathSecond4 + "\n\n"
                            + language.currentLanguage.books.books_wrathSecond5 + "\n\n"
                            + "<i>" + language.currentLanguage.books.books_wrathSecond6 + "</i>\n\n"
                            + language.currentLanguage.books.books_wrathSecond7 + "\n\n"
                            + language.currentLanguage.books.books_wrathSecond8 + "\n\n"
                            + "<b>" + language.currentLanguage.books.books_wrathSecond9 + "</b>";
                    }

                default: { return "Unknown book"; }
            }
        }

    }
}
