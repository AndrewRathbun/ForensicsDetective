using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FileSelectElement : MonoBehaviour
{
    [SerializeField]
    public TMP_Text fileInfo;
    [SerializeField]
    public TMP_Text fileSize;

    public void setTMP(string fileInfoString, string fileSizeString){
        fileInfo.text = fileInfoString;
        fileSize.text = fileSizeString;
    }
}
