[![Discord](https://img.shields.io/discord/1017473804592754778?label=UltrakULL%20Discord)](https://discord.gg/ZB7jk6Djv5 "Discord Invite")
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
- Cyrillic character support for languages such as Russian, Ukrainian and Belarusian


# Download & Installation

UltrakULL can be obtained either through the [Releases page](https://github.com/ClearwaterTM/UltrakULL/releases) (*recommended*),
or via the [UltrakULL Discord.](https://discord.gg/ZB7jk6Djv5)

The only prerequisite is an up-to-date Steam version of ULTRAKILL. <br>**Demo, GOG.com and cracked versions are NOT supported.**

## Installation via Thunderstore

UltrakULL is available as a [ThunderStore mod.](https://thunderstore.io/c/ultrakill/p/UltrakULL/UltrakULL/)

Download and installation can be done automatically via the [R2ModManager](https://github.com/ebkr/r2modmanPlus/releases/download/v3.1.42/r2modman-3.1.42.exe).

(Downloading the mod via R2ModManager will also automatically download and install the required BepInEx dependencies.)

## Installation via GitHub

Installing UltrakULL via GitHub is divided into 2 parts:
- Installing BepInEx, the modding framework
- Installing UltrakULL, the mod itself

#### Installing BepInEx:
- Download [BepInEx 5.4.21 64-bit here.](https://github.com/BepInEx/BepInEx/releases/download/v5.4.21/BepInEx_x64_5.4.21.0.zip)
- Extract the contents of BepInEx to where your ULTRAKILL install folder is located.
- Launch ULTRAKILL once so BepInEx can generate the required files and folders in the install folder. Quit the game once it has loaded to the main menu.

#### Installing UltrakULL:
- Extract the contents of UltrakULL to your BepInEx folder. Overwrite any files if prompted.


### Usage

- If the mod has loaded correctly, you will see a new "Languages" tab in the Options menu, in the bottom-right hand corner.
  <img src="https://cdn.discordapp.com/attachments/472691871806652429/1188532184039043102/image.png?ex=659addda&is=658868da&hm=375363c76c52d1ea20c05fafef696a441f7e66a84671fe14bcc1ae9b8880eb2b&" alt="drawing" width="550"/>
- From the Languages tab, you can browse available translations for the game by selecting the "Browse Languages Online" button. Additionally, language files that are locally installed in the mod folder will be detected and made available for selection any available language based on the language files UltrakULL has found, and will load them into the game.

### Troubleshooting

If the mod does not appear to load or work correctly, or errors occur in-game, please open the BepInEx console.

#### Opening via R2ModManager
Open your mod profile in R2ModManager, and go to Config Editor -> BepInEx.cfg -> Edit Config -> Scroll to "Logging". Set both options to True.

#### Opening via GitHub
Navigate to BepInEx/config/BepInEx.cfg, and open it in any text editor of your choosing. Scroll down to Logging and set
"UnityLogListening" and "LogConsoleToUnityLog" to True.

Restart the game after applying either steps for your use case.


# Languages

## Languages available
| Language                                 | Contributors                                                                                                                       | Last update | Notes                                  |
|------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------|-------------|----------------------------------------|
| English (U.S)                            | Hakita & New Blood                                                                                                                 | Act 2       | Grammatical improvements by Clearwater |
| Brazilian Portugese (Portugês do Brasil) | Veni, Jackie, MKaid, hebert, FNChannel, Spooky, Soulvender, RAYLANDER                                                              | Act 2       |                                        |
| Czech (Čeština)                          | Mina                                                                                                                               | Act 2       |                                        |
| Filipino (Pilipino)                      | mxkyle, MecanicWithAPistol, FinnianNiko                                                                                            | Act 2       |                                        |
| French (Français)                        | Clearwater, ZedDev, Frizou, osokour, Tamary, Uranus, Lays                                                                          | Act 2       | French and Quebec variants available   |
| German (Deutsch)                         | Distrilul, JESTERB0T, Liquid Lest, Psychologemelone44, Termi2, Fabidelune, Madeleine                                               | Act 2       |                                        |
| Korean (한국어)                             | ARSE™, Susu                                                                                                                        | Act 2       |                                        |
| Russian (русский)                        | Nessie_A_WA97, D4N5T3P, Edith Bagel, lrddd, Brainy-Stormie, TwinT, towelie84, mctaylors, Solidus Cumcer, Filin, Ega1232387, Khowst | Act 2       |                                        |
| Spanish (Español)                        | LambCS, Philia, Lukah, Amarok_Lc, Santy, Radripizza, j(LRC), LEVIBOT                                                               | Act 2       |                                        |
| Simplified Chinese (简体中文)                | Hydracerynitis, ciinore, duke325, ponyweeb, Skugra, GoGoblin                                                                       | Act 2       |                                        |
| Turkish (Türkçe)                         | Legitname1337, Ömer Talha, RTE, Ray_, legio, Scape, Neige,$ERTU$TAUPTOWN                                                           | Act 2       |                                        |


Available languages may be directly downloaded for use in-game via the Languages tab in the options menu.
This list is updated on a semi-regular basis as new languages are made available.
### If you would like to submit a new language for use, please do so on our [Discord](https://discord.gg/ZB7jk6Djv5)!

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
I cannot guarantee mod compatability with other mods. Mods that do not use the HUD message display functionality
should work just fine though.


# Documentation

GitHub documentation coming in future. Until then, documentation on how to create your own language
can be found in the [UltrakULL Discord.](https://discord.gg/ZB7jk6Djv5)

# Building
###  (This info is for developers. If you only want to play/use the mod, you do not need to read this.)
1) Clone the repository.<br>`git clone https://github.com/ClearwaterUK/UltrakULL`
2) Set ULTRAKILLPath as an environment variable, which points to your game installation. <br> This is used to automatically acquire any necessary .dll files from the game location to build the mod.
3) Open the project solution in the IDE of your choice (Visual Studio, Rider, etc.)
4) Build the solution. The solution will automatically set up the folder structure, and will drop compiled mod as a DLL.dll file into BepInEx/plugins/UltrakULL.<br>
If you have any language templates or dubbing audio files, the project will automatically copy those to config/ultrakull.
5) Drop all the generated files and folders into: `[Your Steam folder]/steamapps/common/ULTRAKILL/`<br> Overwrite any files if prompted.

# Credits & Contributors
View [CREDITS.md](./CREDITS.md) for full crediting information.

# Links

ULTRAKILL Steam page: https://store.steampowered.com/app/1229490/ULTRAKILL/ \
ULTRAKILL/New Blood Discord:  https://discord.gg/newblood \
UltrakULL Discord: https://discord.gg/ZB7jk6Djv5
