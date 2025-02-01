using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class VideoPreviewButton : MonoBehaviour
{
    public TMP_Text title;
    public Image previewImage;
    public VideoFileData videoData;

    public void SelectVideoPreview()
    {
        VideoController.ChangeVideoPreview(videoData);
    }
}
