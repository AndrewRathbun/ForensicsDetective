using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class FileSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject fileSelectTemplate = null;
    public string[] fileArray;
    string[] loadedFiles;
    public GameObject fileUI;
    private GameObject selectedButton;
    public void Start()
    {
        loadedFiles = GenerateFile.loadFiles();
        for(int i = 0; i < loadedFiles.Length; i++){
            GameFile fileToPrint = JsonUtility.FromJson<GameFile>(loadedFiles[i]);
            GameObject filePanel = Instantiate(fileSelectTemplate) as GameObject;
            filePanel.SetActive(true);
            filePanel.GetComponent<FileSelectElement>().setTMP(fileToPrint.getGameFileName(), fileToPrint.getGameFileSize());
            filePanel.transform.SetParent(fileSelectTemplate.transform.parent, false);
        }
    }
    public void chooseFile(){
        selectedButton = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        string fileName = selectedButton.GetComponent<FileSelectElement>().fileInfo.text;
        string fileSize = selectedButton.GetComponent<FileSelectElement>().fileSize.text;
        fileArray = new string[]{fileName, fileSize};
        PlayerPrefsX.SetStringArray("chosenHashFile", fileArray);
        fileUI.SetActive(false);
        calcBehaviour.printFile();
    }
}
