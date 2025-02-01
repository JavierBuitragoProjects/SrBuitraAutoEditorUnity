using AnotherFileBrowser.Windows;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
public class ExportToCapcut : MonoBehaviour
{
    [SerializeField]
    AutoEditorMenu menu;
    CapcutFormatClass capcutProject = new CapcutFormatClass();
    public void SearchCapcutFile()
    {
        var bp = new BrowserProperties();
        bp.filter = "Draft Content (*.json) | *.json;";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            CompoundGroupExportToCapcut(path);
            //StandardLoadAndExportToCapcut(path);
        });
    }

    private void CompoundGroupExportToCapcut(string[] path)
    {
        if (path.Length == 0) return;
        string capcutProjectContent = File.ReadAllText(path[0]);
        capcutProject = JsonConvert.DeserializeObject<CapcutFormatClass>(capcutProjectContent);
        CapcutFormatClass capcutDeserialized = JsonConvert.DeserializeObject<CapcutFormatClass>(capcutProjectContent);
        string capcutProjectOriginal = JsonConvert.SerializeObject(capcutProject, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        });


        CapcutFormatClass groupedCapcutClass = CompoundGroupEditedFileOrder(capcutDeserialized, path[0]);

        File.WriteAllText(path[0], JsonConvert.SerializeObject(groupedCapcutClass));

        SimplifiedCapcutFormatClass simplified = JsonConvert.DeserializeObject<SimplifiedCapcutFormatClass>(capcutProjectContent);
        File.WriteAllText("D:\\descargas\\original.json", JsonConvert.SerializeObject(simplified));

        string simplifiedString = JsonConvert.SerializeObject(groupedCapcutClass);
        simplified = JsonConvert.DeserializeObject<SimplifiedCapcutFormatClass>(simplifiedString);
        File.WriteAllText("D:\\descargas\\converted.json", JsonConvert.SerializeObject(simplified));
        Debug.Log("Export completed");
    }
    private CapcutFormatClass CompoundGroupEditedFileOrder(CapcutFormatClass capcutDeserialized,string capcutfilePath)
    {
        List<Drafts> allCompoundGroups = new List<Drafts>();
        Dictionary<string,string> fileNameID = new Dictionary<string,string>();

        Drafts previewDraft = capcutDeserialized.materials.drafts[0];

        Dictionary<string,string> draftID = new Dictionary<string, string>();
        for (int loadedVideosIndex = 0; loadedVideosIndex < menu.videoFilesDataWithMargins.Count; loadedVideosIndex++)
        {
            VideoFileData videoFileData = menu.videoFilesDataWithMargins[loadedVideosIndex];

            allCompoundGroups.Add(CreateDraftsContent(previewDraft, videoFileData,draftID,capcutfilePath));
           
        }
        capcutDeserialized.materials.drafts = allCompoundGroups.ToArray();

        List<Video> videoReferencesToGroups = new List<Video>();
        List<Segment> videoTimesGroups = new List<Segment>();

        int lastVideoEndingMilisecond = 25000;
        int lastFragmentEndedMilisecond = 0;
        foreach (VideoFileData videoFileData in menu.finalVideoFilesDataWithMargins)
        {
            foreach (SpeakAndSilenceAudioData fragment in videoFileData.audioData)
            {
                if (!fragment.IsSpeaking && !menu.analisysSettings.saveSilencesToggle.isOn)
                    continue;
                string videoID = "";
                SpeakAndSilenceAudioData lastVideoFileData = videoFileData.audioData[videoFileData.audioData.Count - 1];
                videoReferencesToGroups.Add(CreateVideoData(capcutDeserialized.materials.videos[0], (int)((lastVideoFileData.DurationInSamples + lastVideoFileData.StartInSamples) / lastVideoFileData.AudioSampleRate / videoFileData.audioChannelsNumber * 1000000), videoFileData.fileTitle + "_Combinado","",out videoID));

                int fragmentStartInCapcutSeconds = (int)(fragment.StartInSamples / lastVideoFileData.AudioSampleRate / videoFileData.audioChannelsNumber * 1000000);
                int fragmentDurationInCapcutSeconds = (int)(fragment.DurationInSamples / lastVideoFileData.AudioSampleRate / videoFileData.audioChannelsNumber * 1000000);
                Segment segmentCopyVar = CreateSegment(capcutDeserialized.tracks[0].segments[0], fragmentStartInCapcutSeconds, fragmentDurationInCapcutSeconds, lastVideoEndingMilisecond + lastFragmentEndedMilisecond, fragmentDurationInCapcutSeconds, videoID, draftID[videoFileData.fileTitle]);
                videoTimesGroups.Add(segmentCopyVar);
                lastFragmentEndedMilisecond = segmentCopyVar.target_timerange.duration + segmentCopyVar.target_timerange.start;
            }
            lastVideoEndingMilisecond = lastFragmentEndedMilisecond;
        }

        capcutDeserialized.materials.videos = videoReferencesToGroups.ToArray();
        capcutDeserialized.tracks[0].segments = videoTimesGroups.ToArray();
        return capcutDeserialized;
    }

    private static Drafts CreateDraftsContent(Drafts previewDraft, VideoFileData videoFileData,Dictionary<string,string> draftID,string capcutfilepath)
    {
        string previewInString = JsonConvert.SerializeObject(previewDraft);
        Drafts videoDraft = JsonConvert.DeserializeObject<Drafts>(previewInString);
        videoDraft.id = Guid.NewGuid().ToString();
        videoDraft.combination_id = Guid.NewGuid().ToString();
        videoDraft.type = "combination";
        videoDraft.draft.id = Guid.NewGuid().ToString();//subFolder

        string tempDataRoute = Path.Combine(Path.GetDirectoryName(capcutfilepath), "subdraft", videoDraft.draft.id); 
        if (!Directory.Exists(tempDataRoute))
        {
            Directory.CreateDirectory(Path.Combine(Path.GetDirectoryName(capcutfilepath), "subdraft", videoDraft.draft.id));
        }

        videoDraft.draft_config_path = "##_draftpath_placeholder_0E685133-18CE-45ED-8CB8-2904A212EC80_##\\subdraft\\"+ videoDraft.draft.id + "\\sub_draft_config.json";
        videoDraft.draft_cover_path = "##_draftpath_placeholder_0E685133-18CE-45ED-8CB8-2904A212EC80_##\\subdraft\\"+ videoDraft.draft.id + "\\draft_cover.jpg";
        videoDraft.draft_file_path = "##_draftpath_placeholder_0E685133-18CE-45ED-8CB8-2904A212EC80_##\\subdraft\\"+ videoDraft.draft.id + "\\draft_content.json";

        string plastvideoFileDataInString = JsonConvert.SerializeObject(videoFileData.audioData[videoFileData.audioData.Count - 1]);
        SpeakAndSilenceAudioData lastVideoFileData = JsonConvert.DeserializeObject<SpeakAndSilenceAudioData>(plastvideoFileDataInString);
        videoDraft.draft.duration = (int)((lastVideoFileData.DurationInSamples + lastVideoFileData.StartInSamples) / lastVideoFileData.AudioSampleRate / videoFileData.audioChannelsNumber * 1000000);
        videoDraft.name = videoFileData.fileTitle + "_Combinado";
        videoDraft.draft.name = videoFileData.fileTitle + "_Combinado";
        string videoID = "";
        videoDraft.draft.materials.videos[0] = CreateVideoData(videoDraft.draft.materials.videos[0], videoDraft.draft.duration,videoFileData.fileTitle,videoFileData.videoFilePath,out videoID);
        videoDraft.draft.tracks[0].id = Guid.NewGuid().ToString();
        videoDraft.draft.tracks[0].type = "video";
        videoDraft.draft.tracks[0].segments[0] = CreateSegment(videoDraft.draft.tracks[0].segments[0],0, videoDraft.draft.duration, 0, videoDraft.draft.duration, videoID, "");
        if (!draftID.ContainsKey(videoFileData.fileTitle))
        {
            draftID.Add(videoFileData.fileTitle, videoDraft.id);
        }
        File.WriteAllText(Path.Combine(tempDataRoute,"draft_content.json"), JsonConvert.SerializeObject(videoDraft));
        return videoDraft;

    }
    private static Video CreateVideoData(Video previewVideoData,int duration,string materialName,string path,out string videoID)
    {
        string previewVideoInString = JsonConvert.SerializeObject(previewVideoData);
        Video videoData = JsonConvert.DeserializeObject<Video>(previewVideoInString);
        videoData.duration = duration;
        videoData.id = Guid.NewGuid().ToString();
        videoData.material_name = materialName;
        videoData.path = path;
        videoData.type = "video";
        videoID = videoData.id;
        return videoData;
    }

    private static Segment CreateSegment(Segment previewSegmentData,int sampleStartInCapcutMiliseconds, int sampleDurationInCapcutMiliseconds, int timelineStartInCapcutMiliseconds, int timelineDurationInCapcutMiliseconds, string videoID,string extraMaterialRefID)
    {
        string previewSegmentInString = JsonConvert.SerializeObject(previewSegmentData);
        Segment segmentData = JsonConvert.DeserializeObject<Segment>(previewSegmentInString);
        segmentData.id = Guid.NewGuid().ToString();
        segmentData.material_id = videoID;
        segmentData.extra_material_refs[0] = extraMaterialRefID;
        segmentData.source_timerange = new Source_Timerange
        {
            start = sampleStartInCapcutMiliseconds,
            duration = sampleDurationInCapcutMiliseconds,
        };
        segmentData.target_timerange = new Target_Timerange
        {
            start = timelineStartInCapcutMiliseconds,
            duration = timelineDurationInCapcutMiliseconds,
        };
        return segmentData;
    }
    private void StandardLoadAndExportToCapcut(string[] path)
    {
        if (path.Length == 0) return;
        string capcutProjectContent = File.ReadAllText(path[0]);
        capcutProject = JsonConvert.DeserializeObject<CapcutFormatClass>(capcutProjectContent);

        List<Video> videos = new List<Video>();
        List<Segment> segments = new List<Segment>();
        StandardEditedFileOrder(videos, segments);

        capcutProject.materials.videos = videos.ToArray();
        capcutProject.tracks[0].segments = segments.ToArray();

        File.WriteAllText(path[0], JsonConvert.SerializeObject(capcutProject));
    }


    private void StandardEditedFileOrder(List<Video> videos, List<Segment> segments)
    {
        int lastVideoEndingMilisecond = 25000;
        int lastFragmentEndedMilisecond = 0;
        foreach (VideoFileData videoFileData in menu.finalVideoFilesDataWithMargins)
        {
            foreach (SpeakAndSilenceAudioData fragment in videoFileData.audioData)
            {
                if (!fragment.IsSpeaking && !menu.analisysSettings.saveSilencesToggle.isOn)
                    continue;

                string videoInStringFormat = JsonConvert.SerializeObject(capcutProject.materials.videos[0]);
                Video exampleVideo = JsonConvert.DeserializeObject<Video>(videoInStringFormat);
                exampleVideo.id = Guid.NewGuid().ToString();
                exampleVideo.material_id = exampleVideo.id;
                exampleVideo.material_name = Path.GetFileName(videoFileData.videoFilePath);
                exampleVideo.path = videoFileData.videoFilePath;
                exampleVideo.material_url = videoFileData.videoFilePath;
                videos.Add(exampleVideo);

                string segmentCopy = JsonConvert.SerializeObject(capcutProject.tracks[0].segments[0]);
                Segment segmentCopyVar = JsonConvert.DeserializeObject<Segment>(segmentCopy);
                segmentCopyVar.id = Guid.NewGuid().ToString();
                segmentCopyVar.material_id = exampleVideo.id;
                segmentCopyVar.source_timerange = new Source_Timerange
                {
                    duration = (int)(fragment.DurationInSamples / fragment.AudioSampleRate / videoFileData.audioChannelsNumber * 1000000),
                    start = (int)(fragment.StartInSamples / fragment.AudioSampleRate / videoFileData.audioChannelsNumber * 1000000)
                };
                segmentCopyVar.target_timerange = new Target_Timerange
                {
                    duration = (int)(fragment.DurationInSamples / fragment.AudioSampleRate / videoFileData.audioChannelsNumber * 1000000),
                    start = lastVideoEndingMilisecond + lastFragmentEndedMilisecond
                };
                segments.Add(segmentCopyVar);
                lastFragmentEndedMilisecond = segmentCopyVar.target_timerange.duration + segmentCopyVar.target_timerange.start;
            }
            lastVideoEndingMilisecond = lastFragmentEndedMilisecond;
        }
    }
}
