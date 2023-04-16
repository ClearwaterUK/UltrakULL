using UltrakULL.json;
using UnityEngine;

namespace UltrakULL
{
    public class DevMuseum
    {
        public static string getMuseumBook(string originalText)
        {
            if(originalText.Contains("<b><color=orange>HAKITA</color> - CREATOR OF ULTRAKILL</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita1 + "\n\n"
                    +  LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita2 + "\n\n"
                    +  LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita3 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita4 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita5 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita6 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita7 + "\n\n"
                    + "<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita8 + "\n" 
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita9 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita10 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita11 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita12 + "</size>\n\n"
                    + "<color=orange>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookHakita13 + "</color>";
            }
            if(originalText.Contains("<b><color=#4AACBD>FRANCIS XIE</color> - CONCEPT AND TEXTURE ARTIST</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie1 + "\n\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie2 + "\n\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie3 + "\n\n"
                     +  "<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie4 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie5 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie6 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie7 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie8 + "</size>\n\n"
                     + "<color=#4AACBD>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookFrancisXie9 + "</color>";
            }
            if(originalText.Contains("<b><color=#5cc6f1>JERICHO_RUS</color> - ILLUSTRATOR, CONCEPT AND TEXTURE ARTIST</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus1 + "\n\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus2 + "\n\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus3 + "\n\n"
                     + "<size=18>" +  LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus4 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus5 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus6 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus7 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus8 + "\n"
                     + LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus9 + "</size>\n\n"
                     + "<color=#5cc6f1>"+ LanguageManager.CurrentLanguage.devMuseum.museum_bookJerichoRus10 + "</color>";
            }
            if(originalText.Contains("<b><color=#DA6B6D>BIGROCKBMP</color> - CONCEPT ARTIST</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP2 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP3 + "\n\n"
                    + "<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP4 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP5 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP6 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP7 + "</size>\n\n"
                    + "<color=#DA6B6D>"+ LanguageManager.CurrentLanguage.devMuseum.museum_bookBigRockBMP8 + "</color>";
            }
            if(originalText.Contains("<b><color=#8f65da>MAXIMILIAN OVESSON</color> - UI ARTIST</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookMaximilianOvesson1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookMaximilianOvesson2 + "\n\n"
                    + "<color=#8f65da>" +  LanguageManager.CurrentLanguage.devMuseum.museum_bookMaximilianOvesson3 + "\n\n";
            }
            if(originalText.Contains("<b><color=#F5ABB9>VICTORIA HOLLAND</color> - LEAD 3D ARTIST AND GRAPHICS PROGRAMMER</b>"))
            {
                return LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland1 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland2 + "\n\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland3 + "\n\n"
                    + "<size=18>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland4 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland5 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland6 + "\n"
                    + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland7 + "</size>\n\n"
                    + "<color=#F5ABB9>" + LanguageManager.CurrentLanguage.devMuseum.museum_bookVictoriaHolland8 + "</color>\n\n";
            }

                return "";
        }
        
        public DevMuseum(ref GameObject canvas)
        {
            
        }
    }
}

/*<b>Heya!</b> Welcome to the developer museum. I'm Hakita, the lead developer of the game. I started off working on the game mostly by myself, but overtime the game has grown a lot and I've gotten so many wonderful people helping me out over the years, so here they all are!

This museum was mostly created by Vvizard, with just touchups, iteration, writing and additional easter eggs by me. You can find him in the "Rest Room" down the hall and to the left.

Take a look around! The first floor is for all the people who have helped out with the game's development and the second floor is all kinds of other neat development related things, like cut content and early versions of stuff. There's also plenty easter eggs hidden around the museum!

Most developers will have a book like this in front of them, in which you can read details of how they helped in the creation of this game. Here's mine!



I started development on the game on February 1st, 2018. At the time it was just me, with FlyingDog and Toni Stigell making an occasional 3D model. While the development team has changed and grown since then, I still do the majority of the work myself... Just closer to like 60% of it now than the old 99%.

My contributions include:
<size=18>
- All direction, game design, sound design, story and animation
- All level design, except this museum, the Sandbox and 5-S
- All music, except some public domain songs and songs by guest composers (who you'll find down the hall and to the left)
- Most writing, programming and 
art direction
- Just in general, if it's in the game, I had my finger in that pie
</size>
<color=orange><i>"Thank you for playing, and hopefully enjoying, ULTRAKILL. It's insane to me that a passion project I started just based on what I thought was fun in games has grown to be such a massive success. I've met so many amazing people thanks to this game and the community that has grown around it has been a source of much joy (and plenty of anguish) in my life. It's a rare gift to be able to not only create a work like this with full creative control, but also to be able to make a living off my own art without having to compromise on my vision, and it's all thanks to New Blood, all the developers here in this museum, and most importantly... <b>YOU!</b>"</i></color>*/