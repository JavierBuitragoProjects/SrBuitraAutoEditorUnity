using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AnotherFileBrowser.Windows;
using UnityEngine;
using UnityEditor.Search;
using FuzzySharp;

using static Unity.VisualScripting.Member;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.HableCurve;
using Unity.VisualScripting;

public class OrderByDialog : MonoBehaviour
{
    public AutoEditorMenu menu;
    public void SearchDialogFile()
    {
        var bp = new BrowserProperties();
        bp.filter = "Dialog (*.txt) | *.txt;";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            OrderAudioAnalysisByDialog(path);
        });
    }

    public void OrderAudioAnalysisByDialog(string[] path)
    {
        if (path == null || path.Length == 0) return;

        string[] dialogLines = File.ReadAllLines(path[0]).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
        List<VideoFileData> finalVideoFiles = new List<VideoFileData>(); 
        List<VideoFileData> notAddedVideoFiles = new List<VideoFileData>();

        for (int dialogIndex = 0; dialogIndex < dialogLines.Length; dialogIndex++)
        {
            VideoFileData dialogSegment = new VideoFileData();
            dialogSegment.audioData = new List<SpeakAndSilenceAudioData>();
            if (dialogIndex < dialogLines.Length)
            {
                foreach (VideoFileData videoData in menu.videoFilesDataWithMargins)
                {
                    foreach (SpeakAndSilenceAudioData segment in videoData.audioData)
                    {
                        if (CheckIfString2IsSimilarToLine1InContext(dialogLines[dialogIndex], segment.subtitle, 80))
                        {
                            dialogSegment.videoFilePath = videoData.videoFilePath;
                            dialogSegment.fileTitle = videoData.fileTitle;
                            dialogSegment.completeSoundWaveSprite = videoData.completeSoundWaveSprite;
                            dialogSegment.audioClip = videoData.audioClip;
                            dialogSegment.audioChannelsNumber = videoData.audioChannelsNumber;
                            dialogSegment.audioData.Add(segment);
                        }
                        else
                        {
                            VideoFileData notAddedDialogSegment = new VideoFileData();
                            notAddedDialogSegment.audioData = new List<SpeakAndSilenceAudioData>();
                            notAddedDialogSegment.videoFilePath = videoData.videoFilePath;
                            notAddedDialogSegment.fileTitle = videoData.fileTitle;
                            notAddedDialogSegment.completeSoundWaveSprite = videoData.completeSoundWaveSprite;
                            notAddedDialogSegment.audioClip = videoData.audioClip;
                            notAddedDialogSegment.audioChannelsNumber = videoData.audioChannelsNumber;
                            notAddedDialogSegment.audioData.Add(segment);
                            if (!notAddedVideoFiles.Contains(notAddedDialogSegment))
                            {
                                notAddedVideoFiles.Add(notAddedDialogSegment);
                            }
                        }
                    }
                }
            }
            finalVideoFiles.Add(dialogSegment);
        }

        if (menu.analisysSettings.addAllDataAfterDialogToggle.isOn)
        {
            foreach (VideoFileData videoData in menu.videoFilesDataWithMargins)
            {
                VideoFileData notAddedDialogSegment = new VideoFileData();
                notAddedDialogSegment.audioData = new List<SpeakAndSilenceAudioData>();
                notAddedDialogSegment.videoFilePath = videoData.videoFilePath;
                notAddedDialogSegment.fileTitle = videoData.fileTitle;
                notAddedDialogSegment.completeSoundWaveSprite = videoData.completeSoundWaveSprite;
                notAddedDialogSegment.audioClip = videoData.audioClip;
                notAddedDialogSegment.audioChannelsNumber = videoData.audioChannelsNumber;

                foreach (VideoFileData notAddedVF in notAddedVideoFiles)
                {
                    if(videoData.fileTitle == notAddedVF.fileTitle)
                    {
                        foreach (var notAdded in notAddedVF.audioData)
                        {
                            if (!notAddedDialogSegment.audioData.Contains(notAdded))
                            {
                                notAddedDialogSegment.audioData.Add(notAdded);
                            }
                        }
                    }
                }
                if (!finalVideoFiles.Contains(notAddedDialogSegment))
                {
                    finalVideoFiles.Add(notAddedDialogSegment);
                }
            }
        }

        menu.finalVideoFilesDataWithMargins = finalVideoFiles;
       
        Debug.Log("Analysis complete. Segments ordered by subtitles.");
    }

    private bool CheckIfString2IsSimilarToLine1InContext(string line1, string line2, int threshold)
    {
        if (line2 != null)
        {
            var similarityRatio = Fuzz.Ratio(line1, line2);
            var partialSimilarityRatio = Fuzz.PartialRatio(line1, line2);
            var tokenSortRatio = Fuzz.TokenSortRatio(line1, line2);
            Console.WriteLine($"Similaridad general: {similarityRatio}%");
            Console.WriteLine($"Similaridad parcial: {partialSimilarityRatio}%");
            Console.WriteLine($"Similaridad ordenada: {tokenSortRatio}%");
            if (partialSimilarityRatio > threshold)
                return true;
        }
        return false;
    }
}
