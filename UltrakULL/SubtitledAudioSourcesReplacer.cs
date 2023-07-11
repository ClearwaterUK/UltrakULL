using System.Threading.Tasks;
using BepInEx;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UltrakULL.ReflectionUtils;
using static UltrakULL.CommonFunctions;
using static UltrakULL.audio.AudioSwapper;
using static System.IO.Path;

namespace UltrakULL
{
    public static class SubtitledAudioSourcesReplacer
    {
        public static string SpeechFolder = Combine(Paths.ConfigPath,"ultrakull", "audio", LanguageManager.CurrentLanguage.metadata
            .langName);

        public static async void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            await Task.Delay(250);
            ReplaceSubsAndAudio();
        }

        public static void ReplaceSubsAndAudio()
        {
            if (!TryLoadMetadata(out var sceneReference) || sceneReference.SubtitledSource == null) 
                return;
            
            foreach (var subtitledSource in sceneReference.SubtitledSource)
            {
                foreach (var objectReference in subtitledSource.Objects)
                {
                    var subtitledAudioSource = GetObject(objectReference).GetComponent<SubtitledAudioSource>();
                    var audioSource = GetObject(objectReference).GetComponentInChildren<AudioSource>();

                    if (ActiveDubbingEnabled())
                        audioSource.clip = SwapClipWithFile(audioSource.clip, Combine(SpeechFolder, subtitledSource.AudioPath));
                
                    if (subtitledAudioSource != null)
                        SetPrivate(subtitledAudioSource, typeof(SubtitledAudioSource), "subtitles", subtitledSource.ToSubtitleData());
                }
            }
        }

        private static bool ActiveDubbingEnabled()
        {
            return LanguageManager.configFile.Bind("General", "activeDubbing", "False").Value != "False";
        }

        private static bool TryLoadMetadata(out SceneReference reference)
        {
            if (LanguageManager.SubtitlesConfig != null
                && LanguageManager.SubtitlesConfig.Scenes.TryGetValue(GetCurrentSceneName(), out reference))
                return true;

            reference = default;
            return false;
        }
    }
}