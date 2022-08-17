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
                        return "a";

                    }
                case "Level 2-2":
                    {
                        return "<b>" + language.currentLanguage.books.book_lustSecond1 + "</b>\n"
                        + "<i>" + language.currentLanguage.books.book_lustSecond2 + "\n"
                        + language.currentLanguage.books.book_lustSecond3 + "\n"
                        + language.currentLanguage.books.book_lustSecond4 + "<i>\n"
                        + "<b>" + language.currentLanguage.books.book_lustSecond5 + "<b>";
                    }
                case "Level 4-3": { return "4-3 tablet"; }

                default: { return "Unknown book"; }
            }
        }

    }
}
