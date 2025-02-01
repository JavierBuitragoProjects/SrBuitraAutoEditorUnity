using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] static VideoPlayer videoPlayer;
    [SerializeField] static Slider timeline;
    [SerializeField] static Image timelineBkg;
    public bool isChangedByUser { get; set; }
    [SerializeField] VideoPlayer videoPlayerRef;
    [SerializeField] Slider timelineRef;
    [SerializeField] Image timelineBkgRef;


    void Start()
    {
        videoPlayer = videoPlayerRef;
        timeline = timelineRef;
        timelineBkg = timelineBkgRef;
        if (videoPlayer != null && timeline != null)
        {
            videoPlayer.playOnAwake = false;
        }
    }
    public static void ChangeVideoPreview(VideoFileData videoFileData)
    {
        videoPlayer.url = videoFileData.videoFilePath;
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.Prepare();
        timelineBkg.sprite = videoFileData.completeSoundWaveSprite;
    }

    private static void OnVideoPrepared(VideoPlayer source)
    {
        source.frame = 0;
        timeline.minValue = 0;
        timeline.maxValue = (float)source.frameCount;
        Debug.Log(videoPlayer.frameCount);

        // Desuscribirse del evento para evitar múltiples llamadas en futuros videos.
        source.prepareCompleted -= OnVideoPrepared;
    }

    public void SetVideoValueFromTimeLine()
    {
        if (videoPlayer != null && isChangedByUser)
        {
            videoPlayer.frame = (long)timeline.value;
        }
    }
    public void SetTimeLineValue()
    {
        if (videoPlayer != null && timeline != null )
        {
            timeline.value = (float)videoPlayer.frame;
        }
    }

    void Update()
    {
        if (videoPlayer != null && timeline != null && videoPlayer.isPlaying)
        {
            SetTimeLineValue();
        }
    }
}
