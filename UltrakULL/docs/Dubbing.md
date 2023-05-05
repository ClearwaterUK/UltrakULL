# IMPORTANT: THIS DOCUMENTATION IS A WORK IN PROGRESS AND NOT FULLY COMPLETE. Contributions, feedback or suggestions are appreciated.
 
 # Audio documentation

This document serves to record and categorize technical information and data regarding audio files for spoken character dialogue.

# Original dialog

Information about lines that use multiple subtitles, or work in a certain way, have their information noted in below tables to assist with audio assembly. <br>
Any lines not denoted here do not contain any specific particularities that require them to work, and should work correctly without requiring any major changes.

| Voice line                 | Subtitle delay (in seconds)                                                                                                                                                                                                                                                                               | Other notes                                                 |
|----------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------|
| The name of the voice line | The amount of time seconds that passes before the next subtitle relevant to the line is played. Timestamps are relative to the beginning of the file. Example: (0.5;2.0) means the first subtitle will display 0.5 seconds after the start; the second subtitle will display 2.0 seconds after the start. | Any other particular notes relevant to the line in question |




## 3-2: "IN THE FLESH"

| Voice line      | Subtitle delay (in seconds) | Other notes                                                   |
|-----------------|-----------------------------|---------------------------------------------------------------|
| gabrielIntro1   | 1.2;2.4;5.1;10;7            | 1.2 seconds of echo fade-in at start                          |
| gabrielIntro2   | 0.1;2.8;5.85;10.15          |                                                               |
| gabrielDefeated | 0.1;1.4;4.15;6.4;9.2;13     |                                                               |
| gabrielOutro    | 0.3,3.3                     | Reverb effect is done by the game, no need to add it in clips |

## 4-3: "A SHOT IN THE DARK"

*IMPORTANT NOTE*:

The lines here have some very specific pecularities.
For example, 2 lines may have the same linked subtitles, but one line may have a period of silence before/after it to give way to the other paired line.(Explain this better later)

| Voice line             | Subtitle delay (in seconds) | Other notes                                                                                            |
|------------------------|-----------------------------|--------------------------------------------------------------------------------------------------------|
| mandaloreIntro         | 0.0;3.1                     | mandalore_introOwl has 3.1 seconds of silence at the start; plays at same time as mandalore_introManda |
| mandalore_phaseChange1 | NEEDS FINISHING             |                                                                                                        |
|                        |                             |                                                                                                        |
|                        |                             |                                                                                                        |

### 5-3: "SHIP OF FOOLS"

| Voice line  | Subtitle delay (in seconds) | Other notes                                                       |
|-------------|-----------------------------|-------------------------------------------------------------------|
| gabrielBoat | 0.0;2.0;5.0;6.5;9.5         | Rewinds and repeats at the end, file contains rewind sound effect |

### 6-1: "CRY FOR THE WEEPER"

| Voice line          | Subtitle delay (in seconds) | Other notes                        |
|---------------------|-----------------------------|------------------------------------|
| gabrielHeresyFirst  | 2.0;5.0;6.5;9.5             | 2 seconds of echo fade-in at start |
| gabrielHeresySecond | 0.0                         |                                    |

### 6-2: "AESTHETICS OF HATE"
| Voice line              | Subtitle delay (in seconds)                              | Other notes                        |
|-------------------------|----------------------------------------------------------|------------------------------------|
| gabrielSecondIntro      | 1.85;3.3;4.7;6.3;10.1;12.7;15.3;18.5;22.3;25.8;28.8;30.5 | 2 seconds of echo fade-in at start |
| gabrielSecondFightStart | 1.5;3.1;6.1;7.4;11.3;15.1;18.2;18.9;19.6                 | 1.5 seconds of silence at start    |
| gabrielSecondDefeated   | 0.0;1.1;4.2;7.0;9.3;12.8;14.8;17.2;20.0;                 |                                    |
| gabrielSecondOutro      | 0.0;4.0                                                  |                                    |

### P-1: "SOUL SURVIVOR"
| Voice line            | Subtitle delay (in seconds)                          | Other notes                                                                                                               |
|-----------------------|------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------|
| minosPrimeIntro       | 0.0;2.4;7.0;10.0;13.8;22.0;25.5;30.5;37.0;40.7;44.0; |                                                                                                                           |
| minosPrimeDefeated    | 0.0;4.25;7.3;11.3                                    |                                                                                                                           |
| minosPrimeDeathScream |                                                      | This line plays *immediately* after minosPrimeDefeated, instead of waiting for the relevant point in his death animation. |


### P-2: "WAIT OF THE WORLD"
| Voice line         | Subtitle delay (in seconds)                         | Other notes |
|--------------------|-----------------------------------------------------|-------------|
| sisyphusThisPrison | 0.0;1.5;2.8                                         |             |
| sisyphusIntro      | 0.0;1.7;6.6;10.3;15.8;17.2;22.0;25.9;31.4;35.0;37.4 |             |
| sisyphusOutro      | 0.0;1.6;6.3;12.1;15.3                               |             |


___


# Dubbed dialog

## Adding your own audio files

Audio files should be in .wav format. Depending on compatability, feedback and future updates, the audio format used may change in future.

## Reproducing voice effects for each character
You will first need [Audacity](https://www.audacityteam.org/download/). This tool is highly recommended to follow the steps given here.

### Gabriel
Gabriel requires a small reverb effect. First up, open Audacity and insert your Gabriel line that you've recorded.
Then, click further after the sound file (look similar to waves) and drag your click up until the left side of the screen to select the relevant portion of the audio clip.
After this, go to "Effect" and select "Reverse". This will make the sound play from end to start.
Go back to "Effect" and select "Reverb", the settings are as follows: <br>

|              |      |
|--------------|------|
| Pre-Delay    | 10ms |
| Reverberance | 70%  |
| Damping      | 40%  |
| Tone Low     | 100% |
| Tone High    | 80%  |
| Wet Gain     | -1dB |
| Dry Gain     | -1dB |
| Stereo Width | 100% |


After applying this, go in "Effect" and apply "Reverse" again.

### Minos Prime
Full details to be confirmed.


### Mandalore
Full details to be confirmed.

### Sisyphus Prime
Full details to be confirmed.

## Where to place audio files

UltrakULL expects audio files for characters to be found in: <br>
**BepInEx/config/ultrakull/audio/[languageName]**.

**Example for French/Français**  (uses FR-fr):

<img src="https://cdn.discordapp.com/attachments/472691871806652429/1049359697985163335/image.png" alt="drawing" width="650"/>


If UltrakULL is unable to load a specific file for any reason, the spoken language for that line will default back to English.


Documentation written by Clearwater, contributions by Frizou.
