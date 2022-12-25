﻿[![Discord](https://img.shields.io/discord/1017473804592754778?label=UltrakULL%20Discord)](https://discord.gg/ZB7jk6Djv5 "Discord Invite")
![Version](https://img.shields.io/github/v/release/ClearwaterTM/UltrakULL)
![Licence](https://img.shields.io/github/license/ClearwaterTM/UltrakULL)

<img src="https://cdn.discordapp.com/attachments/472691871806652429/1041615546514427984/unknown.png" height="400">

# UltrakULL

**UltrakULL** (ULTRAKILL Language Library) is a modification (mod) for ULTRAKILL that allows for modification of the game's text strings,
effectively allowing for translation and localization into various languages.\
This mod's primary purpose is to bridge the gap for localization and translation until ULTRAKILL receives official translations.

# Features

- Translates the entire game from English to any language
- Support for multiple languages
- JSON formatting of language files allows for easy-to-understand, simple-to-do modification of strings
- Change languages directly in-game without having to restart
- Languages are consistently developed and updated for a faithful localization and translation of the original game text
- Dubbing support allows for translated spoken dialogue
- Supports right-to-left languages such as Arabic and Persian


# Download

UltrakULL and can be be obtained either through the [Releases page](https://github.com/ClearwaterTM/UltrakULL/releases) (*recommended*),
or via the [UltrakULL Discord.](https://discord.gg/ZB7jk6Djv5)
Additional language files can be obtained in the [Languages](#Languages) section,
or via the [UltrakULL Discord](https://discord.gg/ZB7jk6Djv5) in the #language-releases channel.

# Installation

### Prerequisites:
- A [Steam copy](https://store.steampowered.com/app/1229490/ULTRAKILL/) of ULTRAKILL.<br>**Demo, GOG.com and cracked versions are NOT supported.**
- BepInEx 5 64-bit. It can be directly downloaded from [here](https://github.com/BepInEx/BepInEx/releases/download/v5.4.21/BepInEx_x64_5.4.21.0.zip).<br>**Do not download/install BepInEx 6, ULTRAKILL does not support it.**
- ULTRAKILL Mod Manager (UMM). It can be downloaded from [here](https://github.com/Temperz87/ultra-mod-manager/tags).<br>**UMM 0.5.0 is the minimum version required to use UltrakULL.**
- A release of UltrakULL. Details to obtain it are given in the [Download](#Download) section.<br>**It is highly recommended to acquire the latest version available when downloading.**
- (Optional) Any extra language files you may wish to use. View the [Download](#Download) section for information on extra language files.

### Installation:

The installation section is divided into 3 parts:
- Installing BepInEx, the modding framework
- Installing UMM, the mod loader used for the game
- Installing UltrakULL, the mod itself

#### Installing BepInEx:

- Download all of the required files from the Prerequisites section.
- Extract the contents of BepInEx to where your ULTRAKILL install folder is located.
- Launch ULTRAKILL so BepInEx can generate the required files and folders in the install folder. Quit the game once it has loaded to the main menu.

#### Installing UMM:

- Extract the contents of UMM. Place the "UMM Mods" folder in your BepInEx folder, and UMM.dll in BepInEx/plugins.
- Launch ULTRAKILL. If UMM is installed correctly, you will see a modified layout of the main menu, including new buttons.

#### Installing UltrakULL:

- Extract the contents of UltrakULL to your BepInEx folder. Overwrite any files if prompted.
- Launch ULTRAKILL and click on the Mods button in the main menu. UltrakULL should be displayed there. Click on the square icon in the corner of it to enable auto-startup of the mod, then restart ULTRAKILL (either manually or with the new Restart button added by UMM).
- If the mod has loaded correctly, you should see a new "Languages" tab in the Options menu.
  <img src="https://cdn.discordapp.com/attachments/472691871806652429/1037354187341701130/unknown.png" alt="drawing" width="650"/>
- From the Languages tab, you can select any available language based on the language files UltrakULL has found, and will load them into the game. If you have any additional language files you wish to use, click on the "OPEN LANGUAGE FOLDER" button, and place them in the folder that opens. A game restart is required for the new languages to appear.

- Optional: Enable the BepInEx console by opening the BepInEx.cfg inside the config folder. Find the Logging.Console option and set it to true. This will activate the BepInEx console every time your game launches, and will output the status of the game there. This is very helpful for tracking down problems or errors.


# Uninstallation:

### Removing UltrakULL:
- Delete UltrakULL.dll from BepInEx/UMM Mods/UltrakULL

### Removing UMM:
- Delete UMM.dll from BepInEx/plugins.
- (This will remove UMM, but not your actual mod files)

### Removing BepInEx:
- Delete the winhttp.dll file from your ULTRAKILL install folder. This is the file used for BepInEx to hook into the game, and will not break your installation if it is removed.

# Languages
| Language                                 | Contributors                                                                                            | Status         | Available?         | Notes                                  |
|------------------------------------------|---------------------------------------------------------------------------------------------------------|----------------|--------------------|----------------------------------------|
| English (U.S)                            | Hakita & New Blood                                                                                      | Finished       | :heavy_check_mark: | Grammatical improvements by Clearwater |
| French (Français)                        | Clearwater, ZedDev, Frizou, osokour                                                                     | Finished       | :heavy_check_mark: | French and Quebec variants available   |
| German (Deutsch)                         | Distrilul, JESTERB0T, Liquid Lest, Psychologemelone44, Termi2, Fabidelune                               | Finished       | :heavy_check_mark: |                                        |
| Russian (русский)                        | Nessie_A_WA97, D4N5T3P, Edith Bagel, lrddd, Brainy-Stormie, TwinT, towelie84, mctaylors, Solidus Cumcer | Finished       | :heavy_check_mark: |                                        |
| Spanish (Español)                        | LambCS, Philia, Lukah, Amarok_Lc, Radripizza, j(LRC), LEVIBOT                                           | Finished       | :heavy_check_mark: |                                        |
| Turkish (Türkçe)                         | Legitname1337, Ömer Talha, RTE, Ray_, legio, Scape                                                      | Finished       | :heavy_check_mark: |                                        |
|                                          |                                                                                                         |                |                    |                                        |
| Arabic                                   | riko, hamza666, KIMOZORIS, maria, m7mdd                                                                 | In development | :x:                |                                        |
| Brazilian Portugese (Portugês do Brasil) | Veni, Jackie, MKaid, hebert, FNChannel, Spooky, Soulvender, RAYLANDER                                   | In development | :x:                |                                        |
| Belarusian (беларуская)                  | Kiberkotleta, TopVovanplay                                                                              | In development | :x:                |                                        |
| Bulgarian (Bălgarski)                    | Dan                                                                                                     | In development | :x:                |                                        |
| Belarusian (беларуска)                   | Kiberkotleta                                                                                            | In development | :x:                |                                        |
| Czech (Čeština)                          | Mina                                                                                                    | In development | :x:                |                                        |
| Danish (Dansk)                           | OrangeField,rillebille                                                                                  | In development | :x:                |                                        |
| Dutch (Nederlands)                       | HIMkoto, Foxo, troingle                                                                                 | In development | :x:                |                                        |
| Finnish (Suomi)                          | GoreDemon, FracturedStar, troingle                                                                      | In development | :x:                |                                        |
| Filipino (Pilipino)                      | mxkyle                                                                                                  | In development | :x:                |                                        |
| Georgian (ქართული)                       | GooseNeck                                                                                               | In development | :x:                |                                        |
| Greek (Ελληνικά)                         | Mi pro, NICKOLAS78GR                                                                                    | In development | :x:                |                                        |
| Hungarian (Magyar)                       | csigachad                                                                                               | In development | :x:                |                                        |
| Italian (Italiano)                       | Dav, SimonLuck31, Paolotto Games, Cammen, snp, ImmortalChanger                                          | In development | :x:                |                                        |
| Indonesian (Bahasa Indonesia)            | Arif “Fry” Siregar, mulfok, Yume                                                                        | In development | :x:                |                                        |
| Korean (한국어)                          | ARSE™                                                                                                   | In development | :x:                |                                        |
| Japanese (日本語)                        | sc1zzla                                                                                                 | In development | :x:                |                                        |
| Portugese (Portugês)                     | Toyota AE86                                                                                             | In development | :x:                |                                        |
| Persian (Farsi)                          | Intruder                                                                                                | In development | :x:                |                                        |
| Polish (Polski)                          | SmallSeaCat, Fikou, filizanka, Patryk, Spookz, owaloid                                                  | In development | :x:                |                                        |
| Romanian (Românesc)                      | Vampuffin, Rokon                                                                                        | In development | :x:                |                                        |
| Simplified Chinese (简体中文)            | Hydracerynitis, ciinore, duke325, ponyweeb, Skugra, GoGoblin                                            | In development | :x:                |                                        |
| Thai (ภาษาไทย)                           | Skugra, Winterman, SAPAIDER                                                                             | In development | :x:                |                                        |
| Traditional Chinese(繁體中文)            | GuonuoTW(SmallNo), duke325                                                                              | In development | :x:                |                                        |
| Ukrainian (Українська)                   | Rafunny, Blitzo, Keka, ArtSabs, ak11, the ukrainian war drone, CsyeCok The Soldier, twrp                | In development | :x:                |                                        |
| Vietnamese (Tiếng Việt)                  | TimmyThePea, honkscape, Jerry, null                                                                     | In development | :x:                |                                        |
| Australian English                       | nptnk, FORTY7OUT                                                                                        | In development | :x:                |                                        |

# Documentation

GitHub documentation coming in future. Until then, documentation on how to create your own language
can be found in the [UltrakULL Discord.](https://discord.gg/ZB7jk6Djv5)

# Building

Build instructions coming in future.

# Troubleshooting

### ULTRAKILL received an update, and UltrakULL is now broken/not working correctly.
As is the case with most updates for other games,
any and all updates and hotfixes to ULTRAKILL will almost certainly break mod functionality
to some degree. Work to future-proof the mod as much as possible is done to minimise such occurrences,
but if an update breaks the mod, it will be fixed as quickly as possible.

### My language does not appear as selectable in-game in the language tab.

Language files are formatted in JSON. If it does not appear as available, it is either not formatted correctly
or does not match the minimum version required by the mod.\
To check if a file is formatted correctly, open [JSONLint](https://jsonlint.com/) in your browser, copy and paste the contents
of your file into the window and click on "Validate JSON". \
If the file is not formatted correctly, JSONLint will report any errors.
Errors can be forwarded to the UltrakULL Discord's troubleshooting channel for assistance.

### My problem is not listed here.

A dedicated troubleshooting and support channel can be found at the [UltrakULL Discord](https://discord.gg/ZB7jk6Djv5).

# FAQ

### Can I translate ULTRAKILL into my native language with this mod?

Indeed you can! Thanks to this mod, ULTRAKILL has already been translated into various foreign languages,
including French, Brazilian Portugese, Traditional Chinese, with many other languages also in development at the time of release.\
If you wish to contribute to, or begin work on a new or existing translation or language, feel free to stop by and inquire
at the [UltrakULL Discord.](https://discord.gg/ZB7jk6Djv5)

### Will this mod affect my saves?

No, this mod merely changes text in the game. It does not alter your saves in any way.

### Will this mod prevent Cybergrind highscores?

No, for the same reason as above. It does not alter any gameplay aspects that would give an unfair advantage in any way, and as such,
will be safe to set Cybergrind highscores with.
If for some reason your Cybergrind highscores are not being submitted, and you are sure they should be doing so, feel free to shoot a message
on our Discord and I will take a look at it.

### Can voice lines from characters be translated?

As of UltrakULL v1.1.0, dubbing support is available for speaking characters! To learn more about how to add your own lines, check the [dubbing documentation](https://github.com/ClearwaterTM/UltrakULL/blob/master/UltrakULL/docs/Dubbing.md).

### Where can I follow UltrakULL's development?
I usually like to post updates and news about development in multiple places, including the [UltrakULL Discord](https://discord.gg/ZB7jk6Djv5) itself,
the [New Blood Discord](https://discord.gg/newblood), and my [personal Twitter](https://twitter.com/ClearwaterHLL).

### Is UltrakULL compatible with other mods?
[UltraTweaker](https://github.com/wafflethings/ULTRAKILLtweaker): *Confirmed* to be working, but extensive testing has not been done.
If UltrakULL and UltraTweaker are being used at the same time, the Language tab in the Options menu will be moved to the right side
to avoid overlap with UltraTweaker's own Tweaker Options button.

[UltraSkins](https://github.com/The-DoomMan/ULTRASKINS): Loads, but *not fully compatible* due to UltraSkins
displaying HUD messages that UltrakULL does not correctly show.

# Credits & Contributors
UltrakULL created by **[Clearwater](https://github.com/ClearwaterTM)**\
Additional code contributions by **[Temperz87](https://github.com/Temperz87/)**\
Documentation contributions by Frizou.
Language translations by members of the **UltrakULL Translation Team** \
(view the [Languages](#Languages) section for full information and crediting)\
ULTRAKILL created by **Arsi 'Hakita' Patala** and published by **New Blood Interactive**

UltrakULL uses the following libraries:
- [JSON.Net](https://github.com/JamesNK/Newtonsoft.Json) by [NewtonSoft](https://www.newtonsoft.com/json), licenced under the MIT Licence.
- [arabic-support-unity](https://github.com/Konash/arabic-support-unity) by [Konash](https://github.com/Konash), licenced under the MIT licence.

# Links

ULTRAKILL Steam page: https://store.steampowered.com/app/1229490/ULTRAKILL/ \
ULTRAKILL/New Blood Discord:  https://discord.gg/newblood \
UltrakULL Discord: https://discord.gg/ZB7jk6Djv5
