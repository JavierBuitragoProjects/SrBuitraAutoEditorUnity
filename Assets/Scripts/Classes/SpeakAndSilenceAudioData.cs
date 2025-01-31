public class SpeakAndSilenceAudioData
{
    public float StartInSeconds { get; set; }
    public float StartInSamples { get; set; }
    public float DurationInSeconds { get; set; }
    public float DurationInSamples { get; set; }
    public float AudioSampleRate { get; set; }
    public bool IsSpeaking { get; set; }
    public string equivalentAudioTempFilePath { get; set; }
    public string subtitle { get; set; }
    public float[] audioSamples { get; set; }

}
