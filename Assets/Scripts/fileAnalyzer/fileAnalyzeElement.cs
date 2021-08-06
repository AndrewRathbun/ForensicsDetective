using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fileAnalyzeElement:MonoBehaviour{
    //Serialized variables
    [SerializeField]
    public TMP_Text fileName, filePath, fileDate, fileType, fileSize, fileID;

    public void setText(string fName, string fPath, string fDate, string fType, string fSize, string fID){
        fileName.text = fName;
        filePath.text = fPath;
        fileDate.text = fDate;
        fileType.text = fType;
        fileSize.text = fSize;
        fileID.text = fID;
    }
}