using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Xabe.FFmpeg;

public static class GetAudioClip
{
    public static async Task<AudioClip> ExtractAudioAndAnalyze(string inputFilePath)
    {
        string outputFilePath = Path.Combine(Application.temporaryCachePath, "tmp_" + Path.GetFileNameWithoutExtension(inputFilePath) + ".wav");

        // Extraer el audio
        IConversion conversion = await FFmpeg.Conversions.FromSnippet.ExtractAudio(inputFilePath, outputFilePath);
        IConversionResult result = await conversion.Start();

        // Obtener la duración del video
        IMediaInfo mediaInfo = await FFmpeg.GetMediaInfo(inputFilePath);
        var videoDuration = mediaInfo.Duration.TotalSeconds;

        // Obtener la duración del audio extraído
        IMediaInfo audioInfo = await FFmpeg.GetMediaInfo(outputFilePath);
        var audioDuration = audioInfo.Duration.TotalSeconds;

        return await LoadAudioClip(outputFilePath);
    }

    private static async Task<AudioClip> LoadAudioClip(string filePath)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + filePath, AudioType.WAV))
        {
            await www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                return DownloadHandlerAudioClip.GetContent(www);
            }
            else
            {
                Debug.LogError("Failed to load audio clip: " + www.error);
                return null;
            }
        }
    }
}
