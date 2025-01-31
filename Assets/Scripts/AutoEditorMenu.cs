using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Whisper.Samples;
using Xabe.FFmpeg;

public class AutoEditorMenu : MonoBehaviour
{
    #region UX

    [SerializeField]
    public AnalisysSettings analisysSettings;
    public ScrollRect videoButtonsVisualizer;
    public TMP_Text progressText;
    public Slider progressBar;

    #endregion UX

    public string[] videoPaths;
    public List<VideoFileData> videoFilesDataWithoutMargins;
    public List<VideoFileData> videoFilesDataWithMargins;
    public List<VideoFileData> finalVideoFilesDataWithMargins;


    #region prefabs
    [SerializeField] GameObject previewButtonPrefab;
    List<GameObject> previewButtons= new List<GameObject>();
    #endregion prefabs

    #region components
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClipDemo whisper;
    #endregion components

    public async void OnVideosLoaded()
    {
        RestartVideoData();
        foreach (string videoPath in videoPaths)
        {
            AudioClip audioFromVideo = await GetAudioClip.ExtractAudioAndAnalyze(videoPath);
            RectTransform rectTr = analisysSettings.videoTimeline.GetComponent<RectTransform>();
            VideoFileData videoFileData = new VideoFileData
            {
                videoFilePath = videoPath,
                fileTitle = Path.GetFileNameWithoutExtension(videoPath),
                audioChannelsNumber = audioFromVideo.channels,
                audioData = await AudioVolumeAnalyzer.AnalyzeAudio(audioFromVideo, analisysSettings.volumeThreshold.value / 1000, 0.01f, progressBar, analisysSettings.channels),
                audioClip = audioFromVideo
            };
            videoFilesDataWithoutMargins.Add(videoFileData);
        }
        PrevisualizeAnalysisData();
        foreach (VideoFileData videoFileData in videoFilesDataWithMargins)
        {
            CreatePreviewButton(videoFileData);
            VideoController.ChangeVideoPreview(videoFileData);
        }
        progressText.text = "carga de videos y primer análisis completado con éxito";
    }
    public void PrevisualizeAnalysisData()
    {
        videoFilesDataWithMargins = AudioVolumeAnalyzer.AddSilenceMarginstoVideoAudioData(videoFilesDataWithoutMargins, analisysSettings.marginInSecondsThreshold.value);
        finalVideoFilesDataWithMargins = videoFilesDataWithMargins;
        foreach (VideoFileData videoFileData in videoFilesDataWithMargins)
        {
            SoundWavePainter.PaintSoundWaveData(videoFileData, analisysSettings.timelineBackGround,analisysSettings.volumeThreshold.value);
            analisysSettings.timelineBackGround.sprite = videoFileData.completeSoundWaveSprite;
        }
    }

    public async void AddSubtitleToVideos()
    {
        foreach (VideoFileData videoFileData in videoFilesDataWithMargins)
        {
            for (int index = 0; index < videoFileData.audioData.Count; index++)
            {
                SpeakAndSilenceAudioData clipFragment = videoFileData.audioData[index];
                if (clipFragment.IsSpeaking)
                {
                    // Crear un AudioClip usando los datos de la clase
                    AudioClip audioClip = CreateAudioClip(clipFragment,videoFileData.audioChannelsNumber);
                    AudioSource.PlayClipAtPoint(audioClip,transform.position);
                    clipFragment.subtitle = await whisper.SpeechToTextFromClip(audioClip);
                }
                progressBar.value = (int)(index/videoFileData.audioData.Count*100);
            }
        }
        analisysSettings.orderFromDialogButton.SetActive(true);
        Debug.Log(videoFilesDataWithMargins);
    }

    private AudioClip CreateAudioClip(SpeakAndSilenceAudioData clipFragment,int channels)
    {
        int sampleCount = clipFragment.audioSamples.Length;
        AudioClip audioClip = AudioClip.Create("GeneratedClip" + Guid.NewGuid().ToString(), sampleCount, channels, (int)clipFragment.AudioSampleRate, false);
        audioClip.SetData(clipFragment.audioSamples, 0);
        return audioClip;
    }

#region Tools 

public async Task<Sprite> GetVideoPreviewImage(string videoPath)
    {
        string outputImagePath = Path.Combine(UnityEngine.Application.temporaryCachePath,"tmp_", Path.GetFileNameWithoutExtension(videoPath),".png");

        // Extraer el primer fotograma usando Xabe.FFmpeg
        IConversionResult result = await FFmpeg.Conversions.New()
            .AddParameter($"-i \"{videoPath}\" -vf \"select=eq(n\\,0)\" -vsync vfr -q:v 2")
            .SetOutput(outputImagePath)
            .Start();

        if (File.Exists(outputImagePath))
        {
            byte[] imageBytes = File.ReadAllBytes(outputImagePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageBytes);

            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new UnityEngine.Vector2(0.5f, 0.5f));
        }
        else
        {
            UnityEngine.Debug.LogError("Failed to extract frame.");
            return null;
        }
    }
    private void RestartVideoData()
    {
        analisysSettings.reanalyzeButton.SetActive(false);
        videoFilesDataWithoutMargins = new List<VideoFileData>();
        DestroyGameObjectsInList(previewButtons);
        previewButtons = new List<GameObject>();

    }

    public void DestroyGameObjectsInList(List<GameObject> contentToDestroy)
    {
        foreach (GameObject content in contentToDestroy)
        {
            Destroy(content);
        }
    }

    private async void CreatePreviewButton(VideoFileData videoFileData)
    {
        GameObject previewButton = Instantiate(previewButtonPrefab, videoButtonsVisualizer.content);
        VideoPreviewButton previewButtonData = previewButton.GetComponent<VideoPreviewButton>();
        previewButtonData.title.text = Path.GetFileNameWithoutExtension(videoFileData.videoFilePath);
        previewButtonData.previewImage.sprite = await GetVideoPreviewImage(videoFileData.videoFilePath);
        previewButtonData.videoData = videoFileData;

        previewButtons.Add(previewButton);
    }

    #endregion Tools
    
}
