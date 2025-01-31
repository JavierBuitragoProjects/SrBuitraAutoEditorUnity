using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using System.Linq;

public static class AudioVolumeAnalyzer
{
    public static float maxVolumeDetected;
    public static async Task<List<SpeakAndSilenceAudioData>> AnalyzeAudio(AudioClip audioClip, float volumeThreshold, float precissionInSeconds, Slider progressBar, Toggle[] channelBools)
    {
        List<SpeakAndSilenceAudioData> volumeChangesVar = new List<SpeakAndSilenceAudioData>();
        maxVolumeDetected = 0;
        float totalDuration = 0;

        if (audioClip != null)
        {
            // AudioData
            float[] samples = new float[audioClip.samples * audioClip.channels];
            audioClip.GetData(samples, 0);
            List<float> samplesInListFormat = samples.ToList();
            int sampleRate = audioClip.frequency;
            int windowSamples = (int)(precissionInSeconds * sampleRate);

            // flags
            bool isSpeaking = false;
            long speakingStartSample = 0;
            long silenceStartSample = 0;

            List<float> audioSamples = new List<float>();
            int lastIndex = 0;
            for (int actualSampleIndex = 0; actualSampleIndex < samples.Length; actualSampleIndex += windowSamples)
            {

                float averageVolumeInSegment = CalculateAverageVolumeInFragment(samples, windowSamples, actualSampleIndex,channelBools);

                audioSamples.AddRange(samplesInListFormat.GetRange(lastIndex, actualSampleIndex-lastIndex));
                
                lastIndex = actualSampleIndex;
                if (averageVolumeInSegment > maxVolumeDetected) maxVolumeDetected = averageVolumeInSegment;

                if (averageVolumeInSegment > volumeThreshold)
                {
                    if (!isSpeaking)
                    {
                        // Save Silence Fragment
                        SaveFragment(volumeChangesVar, sampleRate, silenceStartSample, actualSampleIndex, isSpeaking,audioSamples.ToArray());
                        audioSamples = new List<float>();
                        // Start Speaking Fragment
                        isSpeaking = true;
                        speakingStartSample = actualSampleIndex;
                    }
                }
                else
                {
                    if (isSpeaking)
                    {
                        // Save Speaking Fragment
                        SaveFragment(volumeChangesVar, sampleRate, speakingStartSample, actualSampleIndex, isSpeaking,audioSamples.ToArray());
                        audioSamples= new List<float>();
                        // Start Silence Fragment
                        isSpeaking = false;
                        silenceStartSample = actualSampleIndex;
                    }
                }
                totalDuration += windowSamples / (float)sampleRate;
                int progress = (int)(((float)actualSampleIndex / (float)samples.Length) * 100);
                progressBar.value = progress;
            }
            SaveFragment(volumeChangesVar, sampleRate, silenceStartSample, samples.Length, isSpeaking, audioSamples.ToArray());
        }

        Debug.Log($"Total Duration: {totalDuration} seconds");
        progressBar.value = 100;
        return volumeChangesVar;
    }


    private static void SaveFragment(List<SpeakAndSilenceAudioData> volumeChangesVar, int sampleRate, long startSample, int actualSampleIndex,bool isSpeaking,float[] samples)
    {
        long endSample = actualSampleIndex;
        long durationInSamples = endSample - startSample;

        long startInMiliseconds = startSample / sampleRate;
        long durationInMiliseconds = durationInSamples / sampleRate;

        SpeakAndSilenceAudioData fragmentAudioVideoData = new SpeakAndSilenceAudioData
        {
            StartInSeconds = startInMiliseconds,
            StartInSamples = startSample,
            DurationInSeconds = durationInMiliseconds,
            DurationInSamples = durationInSamples,
            AudioSampleRate = sampleRate,
            IsSpeaking = isSpeaking,
            audioSamples = samples
        };
        volumeChangesVar.Add(fragmentAudioVideoData);
    }

    private static float CalculateAverageVolumeInFragment(float[] samples, int windowSize, int startIndex, Toggle[] channelToggles)
    {
        float totalVolume = 0f;
        int sampleCount = 0;
        int channelCount = channelToggles.Length; // Number of channels based on the toggles

        for (int i = startIndex; i < startIndex + windowSize && i < samples.Length; i += channelCount)
        {
            for (int channel = 0; channel < channelCount; channel++)
            {
                int sampleIndex = i + channel;
                if (sampleIndex < samples.Length && channelToggles[channel].isOn) // Check if the channel is selected and index is within range
                {
                    totalVolume += Mathf.Abs(samples[sampleIndex]);
                    sampleCount++;
                }
            }
        }

        float averageVolumeInSegment = sampleCount > 0 ? totalVolume / sampleCount : 0;
        return averageVolumeInSegment;
    }
    public static List<VideoFileData> AddSilenceMarginstoVideoAudioData(List<VideoFileData> videoFilesWithoutMargins, float marginInMilliseconds)
    {
        List<VideoFileData> finalVideoFileDataWithMargins = new List<VideoFileData>();

        foreach (VideoFileData videoFile in videoFilesWithoutMargins)
        {
            List<SpeakAndSilenceAudioData> speakAndSilenceWithMargins = new List<SpeakAndSilenceAudioData>();
            float marginInSamples = marginInMilliseconds * videoFile.audioData[0].AudioSampleRate;
            float speakingSegmentDuration = marginInSamples * 2;
            float silenceSegmentDuration = marginInSamples / 2;
            bool previousWasSpeaking = false;
            SpeakAndSilenceAudioData currentSegment = null;

            float currentStartSample = marginInSamples / 2;
            float addedExtraDuration = 0;

            // Obtener los datos de audio del AudioClip
            float[] samples = new float[videoFile.audioClip.samples * videoFile.audioClip.channels];
            videoFile.audioClip.GetData(samples, 0);

            List<float> segmentSamples = new List<float>();

            for (int index = 0; index < videoFile.audioData.Count; index++)
            {
                SpeakAndSilenceAudioData audioData = videoFile.audioData[index];

                // Extraer los samples del segmento actual de audio
                segmentSamples.AddRange(audioData.audioSamples);

                if (audioData.IsSpeaking)
                {
                    if (index == videoFile.audioData.Count - 2 || (!videoFile.audioData[index + 1].IsSpeaking && videoFile.audioData[index + 1].DurationInSamples > marginInSamples))
                    {
                        currentSegment = new SpeakAndSilenceAudioData
                        {
                            StartInSamples = currentStartSample,
                            DurationInSamples = audioData.DurationInSamples + marginInSamples + addedExtraDuration,
                            StartInSeconds = currentStartSample / audioData.AudioSampleRate,
                            DurationInSeconds = (audioData.DurationInSamples + marginInSamples + addedExtraDuration) / audioData.AudioSampleRate,
                            AudioSampleRate = audioData.AudioSampleRate,
                            IsSpeaking = true,
                            audioSamples =segmentSamples.ToArray()// Combina los samples
                        };
                        speakAndSilenceWithMargins.Add(currentSegment);
                        segmentSamples = new List<float>();
                        addedExtraDuration = 0;
                        currentStartSample += currentSegment.DurationInSamples;
                        continue;
                    }
                }
                else
                {
                    if (audioData.DurationInSamples > marginInSamples)
                    {
                        currentSegment = new SpeakAndSilenceAudioData
                        {
                            StartInSamples = currentStartSample,
                            DurationInSamples = audioData.DurationInSamples - marginInSamples + addedExtraDuration,
                            StartInSeconds = currentStartSample / audioData.AudioSampleRate,
                            DurationInSeconds = (audioData.DurationInSamples - marginInSamples + addedExtraDuration) / audioData.AudioSampleRate,
                            AudioSampleRate = audioData.AudioSampleRate,
                            IsSpeaking = false,
                            audioSamples =  segmentSamples.ToArray() // Combina los samples
                        };
                        speakAndSilenceWithMargins.Add(currentSegment);
                        segmentSamples = new List<float>();
                        addedExtraDuration = 0;
                        currentStartSample += currentSegment.DurationInSamples;
                        continue;
                    }
                }
                addedExtraDuration += videoFile.audioData[index].DurationInSamples;
            }

            VideoFileData videoFileData = new VideoFileData
            {
                videoFilePath = videoFile.videoFilePath,
                fileTitle = videoFile.fileTitle,
                audioChannelsNumber = videoFile.audioChannelsNumber,
                audioData = speakAndSilenceWithMargins,
                audioClip = videoFile.audioClip,
            };

            finalVideoFileDataWithMargins.Add(videoFileData);
        }

        var oldSegment = videoFilesWithoutMargins[0].audioData[videoFilesWithoutMargins[0].audioData.Count - 1];
        var newSegment = finalVideoFileDataWithMargins[0].audioData[finalVideoFileDataWithMargins[0].audioData.Count - 1];
        float maxOldDuration = oldSegment.DurationInSamples + oldSegment.StartInSamples;
        float maxNewDuration = newSegment.DurationInSamples + newSegment.StartInSamples;

        return finalVideoFileDataWithMargins;
    }

    private static float[] CombineSegmentsSamples(float[] previousSamples, float[] currentSamples, float marginInSamples)
    {
        if (previousSamples == null)
        {
            return currentSamples;
        }

        int previousSamplesLength = previousSamples.Length - (int)marginInSamples;
        int combinedSamplesLength = previousSamplesLength + currentSamples.Length;
        float[] combinedSamples = new float[combinedSamplesLength];

        Array.Copy(previousSamples, 0, combinedSamples, 0, previousSamplesLength);
        Array.Copy(currentSamples, 0, combinedSamples, previousSamplesLength, currentSamples.Length);

        return combinedSamples;
    }


}