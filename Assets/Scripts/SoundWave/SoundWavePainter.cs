using UnityEngine;
using UnityEngine.UI;

public static class SoundWavePainter
{
    public static void PaintSoundWaveData(VideoFileData videoFilesDataWithMargins,Image timelineBackGround, float volumeThresholdValue)
    {
        RectTransform bckGround = timelineBackGround.GetComponent<RectTransform>();
        videoFilesDataWithMargins.completeSoundWaveSprite = Sprite.Create(PaintSoundWaveFromVideo(videoFilesDataWithMargins, volumeThresholdValue), new Rect(0, 0, bckGround.rect.width, bckGround.rect.height), new UnityEngine.Vector2(0, 0));
        
    }

    private static Texture2D PaintSoundWaveFromVideo(VideoFileData videoFileData, float volumeThresholdValue)
    {
        float maxVolume = AudioVolumeAnalyzer.maxVolumeDetected;
        int width = 1800;
        int height = 250;

        Color talkingBackGround = Color.blue;
        Color silenceBackGround = Color.red;
        Color foreground = Color.black;
        Color thresholdLineColor = Color.yellow;

        int samplesize;
        int halfheight = height / 2;
        float heightscale = (float)height * 2f;

        // get the sound data
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGBA32, false);
        float[] waveform = new float[width];

        samplesize = videoFileData.audioClip.samples * videoFileData.audioClip.channels;
        float[] samples = new float[samplesize];
        videoFileData.audioClip.GetData(samples, 0);

        int packsize = (samplesize / width);

        for (int w = 0; w < width; w++)
        {
            waveform[w] = Mathf.Abs(samples[w * packsize]);
        }

        // map the sound data to texture
        // 1 - clear
        for (int x = 0; x < width; x++)
        {
            // Determine if speaking or silence background should be used
            Color currentBackground = silenceBackGround;
            foreach (var audioData in videoFileData.audioData)
            {
                long samplePosition = (long)(x * ((float)samplesize / width));
                if (samplePosition >= audioData.StartInSamples && samplePosition < audioData.StartInSamples + audioData.DurationInSamples)
                {
                    if (audioData.IsSpeaking)
                    {
                        currentBackground = talkingBackGround;
                    }
                    else
                    {
                        currentBackground = silenceBackGround;
                    }
                    break;
                }
            }

            for (int y = 0; y < height; y++)
            {
                tex.SetPixel(x, y, currentBackground);
            }
        }

        // 2 - plot the waveform
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < waveform[x] * heightscale; y++)
            {
                tex.SetPixel(x, halfheight + y, foreground);
                tex.SetPixel(x, halfheight - y, foreground);
            }
        }

        // 3 - draw the threshold line
        int thresholdY = (int)(volumeThresholdValue * heightscale);
        for (int x = 0; x < width; x++)
        {
            tex.SetPixel(x, halfheight + thresholdY, thresholdLineColor);
            tex.SetPixel(x, halfheight - thresholdY, thresholdLineColor);
        }

        tex.Apply();

        return tex;
    }


}
