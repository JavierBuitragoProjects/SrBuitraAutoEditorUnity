using System.Collections.Generic;
using UnityEngine;
public class VideoFileData
{
    public string videoFilePath { get; set; }
    public string fileTitle { get; set; }
    public List<SpeakAndSilenceAudioData> audioData { get; set; }
    public Sprite completeSoundWaveSprite { get; set; }
    public AudioClip audioClip { get; set; }
    public int audioChannelsNumber { get; set; }
}
