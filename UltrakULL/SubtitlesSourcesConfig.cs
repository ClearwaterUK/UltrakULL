using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UltrakULL.json;

namespace UltrakULL
{
    public class SubtitlesSourcesConfig
    {
        [JsonProperty("scenes")]
        public Dictionary<string, SceneReference> Scenes;
    }

    public class SceneReference
    {
        [JsonProperty("subtitledAudioSources")]
        public List<SubtitledSource> SubtitledSource;

        [JsonProperty("hudMessages")]
        public List<HudMessageSource> HudMessageSource;
    }
    
    public class SubtitledSource
    {
        [JsonProperty("objects")]
        public List<string> Objects;

        [JsonProperty("audio")]
        public string AudioPath;
        
        [JsonProperty("lines")]
        public List<Line> Lines;
        
        public SubtitledAudioSource.SubtitleData ToSubtitleData()
        {
            return new SubtitledAudioSource.SubtitleData
            {
                lines = Lines.Select(line => new SubtitledAudioSource.SubtitleDataLine
                {
                    subtitle = ColorIfNecessary(LanguageManager.CurrentLanguage.subtitles.GetField(line.Reference), line.Color),
                    time = line.Delay
                }).ToArray()
            };
        }

        private static string ColorIfNecessary(string line, string color)
        {
            if (color == null)
                return line;

            return "<color=#" + color + ">" + line + "</color>";
        }
    }

    public class Line
    {
        [JsonProperty("line")]
        public string Reference;

        [JsonProperty("delay")]
        public float Delay;
        
        [JsonProperty("color")]
        public string Color;
    }
    
    public class HudMessageSource
    {
        [JsonProperty("objects")]
        public List<string> Objects;

        [JsonProperty("message")]
        public string Message;
    }
}