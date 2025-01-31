using UnityEngine;
using AnotherFileBrowser.Windows;

public class VideoLoader : MonoBehaviour
{
    [SerializeField]
    AutoEditorMenu menu;
    public void SearchVideos()
    {
        var bp = new BrowserProperties();
        bp.filter = "Video files (*.mp4, *.avi, *.mov, *.mkv) | *.mp4; *.avi; *.mov; *.mkv";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, paths =>
        {
            menu.videoPaths = paths;
            menu.OnVideosLoaded();
        }); 
    }

}
