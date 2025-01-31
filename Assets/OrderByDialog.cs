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
        List<SpeakAndSilenceAudioData> orderedSegments = new List<SpeakAndSilenceAudioData>();

        VideoFileData[] videoFiles = new VideoFileData[dialogLines.Length];

        for (int dialogIndex = 0; dialogIndex < videoFiles.Length; dialogIndex++)
        {
            VideoFileData dialogSegments = new VideoFileData();
            dialogSegments.audioData = new List<SpeakAndSilenceAudioData>();
            if (dialogIndex < dialogLines.Length)
            {
                foreach (VideoFileData videoData in menu.videoFilesDataWithMargins)
                {
                    foreach (SpeakAndSilenceAudioData segment in videoData.audioData)
                    {
                        if (CheckIfString2IsSimilarToLine1InContext(dialogLines[dialogIndex], segment.subtitle, 80))
                        {
                            dialogSegments.videoFilePath = videoData.videoFilePath;
                            dialogSegments.fileTitle = videoData.fileTitle;
                            dialogSegments.completeSoundWaveSprite = videoData.completeSoundWaveSprite;
                            dialogSegments.audioClip = videoData.audioClip;
                            dialogSegments.audioChannelsNumber = videoData.audioChannelsNumber;
                            dialogSegments.audioData.Add(segment);
                        }
                    }

                }
            }            
            videoFiles[dialogIndex] = dialogSegments;
        }

        menu.finalVideoFilesDataWithMargins = videoFiles.ToList();
        if (menu.analisysSettings.addAllDataAfterDialogToggle.isOn)
        {
            menu.finalVideoFilesDataWithMargins.AddRange(menu.videoFilesDataWithMargins);
        }
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
