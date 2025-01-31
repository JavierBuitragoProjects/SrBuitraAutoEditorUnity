using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Whisper.Utils;

namespace Whisper.Samples
{
    /// <summary>
    /// Takes audio clip and make a transcription.
    /// </summary>
    public class AudioClipDemo : MonoBehaviour
    {
        public WhisperManager manager;
        public bool streamSegments = true;
        public bool echoSound = true;
        public bool printLanguage = true;
        public AudioSource audioSource;
        private string _buffer;
        
        private void Awake()
        {
            manager.OnNewSegment += OnNewSegment;
            manager.OnProgress += OnProgressHandler;
        }

        public async Task<string> SpeechToTextFromClip(AudioClip clip)
        {
            _buffer = "";
            if (echoSound)
                audioSource.PlayOneShot(clip);

            var sw = new Stopwatch();
            sw.Start();
            
            var res = await manager.GetTextAsync(clip);

            var time = sw.ElapsedMilliseconds;
            var rate = clip.length / (time * 0.001f);
            UnityEngine.Debug.Log($"Time: {time} ms\nRate: {rate:F1}x");

            var text = res.Result;
            if (printLanguage)
                text += $"\n\nLanguage: {res.Language}";
            return text;
        }
        
        private void OnProgressHandler(int progress)
        {
            UnityEngine.Debug.Log($"Progress: {progress}%");
        }
        
        private void OnNewSegment(WhisperSegment segment)
        {
           
            _buffer += segment.Text;
            UnityEngine.Debug.Log(_buffer + "...");
        }
    }
}


