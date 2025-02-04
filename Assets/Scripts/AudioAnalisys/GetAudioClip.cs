using System;
using System.Globalization;
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

        // Ajustar la duración del audio para que coincida con la del video
        if (audioDuration != videoDuration)
        {
            string adjustedAudioPath = Path.Combine(Application.temporaryCachePath, "adjusted_" + Path.GetFileNameWithoutExtension(inputFilePath) + ".wav");

            if (audioDuration > videoDuration)
            {
                // Recortar el audio si es más largo que el video
                IConversion trimConversion = FFmpeg.Conversions.New()
                    .AddParameter($"-t {videoDuration.ToString(CultureInfo.InvariantCulture)}")
                    .AddParameter($"-i \"{outputFilePath}\" -c copy \"{adjustedAudioPath}\"");

                await trimConversion.Start();
            }
            else
            {
                // Agregar silencio al principio del audio si es más corto que el video
                double silenceDuration = videoDuration - audioDuration;
                string silenceAudioPath = Path.Combine(Application.temporaryCachePath, "silence_" + Path.GetFileNameWithoutExtension(inputFilePath) + ".wav");

                IConversion padConversion = FFmpeg.Conversions.New()
                    .AddParameter($"-f lavfi -t {silenceDuration.ToString(CultureInfo.InvariantCulture)} -i anullsrc=r=44100:cl=mono -i \"{outputFilePath}\" -filter_complex \"[0][1]concat=n=2:v=0:a=1[out]\" -map \"[out]\" -t {videoDuration.ToString(CultureInfo.InvariantCulture)} -c:a pcm_s16le \"{silenceAudioPath}\"");

                await padConversion.Start();
                adjustedAudioPath = silenceAudioPath;
            }

            outputFilePath = adjustedAudioPath;
        }

        return await LoadAudioClip(outputFilePath);
    }

    private static async Task<AudioClip> LoadAudioClip(string filePath)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + filePath, AudioType.WAV))
        {
            var request = www.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
                return null;
            }
            else
            {
                return DownloadHandlerAudioClip.GetContent(www);
            }
        }
    }
}
