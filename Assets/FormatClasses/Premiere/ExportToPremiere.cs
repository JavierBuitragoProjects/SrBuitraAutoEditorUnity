using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class ExportToPremiere : MonoBehaviour
{
    [SerializeField]
    AutoEditorMenu menu;
    PremiereXML premiereProject = new PremiereXML();
    public void ExportPremiereXMLFile()
    {
        foreach (VideoFileData videoFile in menu.videoFilesDataWithMargins)
        {
            
        }

        File.WriteAllText("NOMBRE DE LA RUTA.xml", JsonConvert.SerializeObject(premiereProject));
    }

   
}
