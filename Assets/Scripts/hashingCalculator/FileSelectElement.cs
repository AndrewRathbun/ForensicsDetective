using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FileSelectElement : MonoBehaviour
{
    [SerializeField]
    public TMP_Text fileInfo, fileSize, fileId;

    public void setTMP(string fileInfoString, string fileSizeString, string fileIdString){
        fileInfo.text = fileInfoString;
        fileSize.text = fileSizeString;
        fileId.text = fileIdString;
    }
}