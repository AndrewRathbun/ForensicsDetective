using System;
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
    string[] loadedFiles;
    public GameObject fileUI;
    private GameObject selectedButton;
    public void Start()
    {
        loadedFiles = GenerateFile.loadFiles();
        string formattedSize = "";
        for(int i = 0; i < loadedFiles.Length; i++){
            GameFile fileToPrint = JsonUtility.FromJson<GameFile>(loadedFiles[i]);
            GameObject filePanel = Instantiate(fileSelectTemplate) as GameObject;
            filePanel.SetActive(true);
            formattedSize = formatSize(fileToPrint.getGameFileSize());
            filePanel.GetComponent<FileSelectElement>().setTMP(fileToPrint.getGameFileName()+fileToPrint.getGameFileExtension(), formattedSize, fileToPrint.getGameFileID().ToString());
            filePanel.transform.SetParent(fileSelectTemplate.transform.parent, false);
        }
    }

    public string formatSize(string inSize){
		double sizeNum = Int64.Parse(inSize);
		if(sizeNum >= 1000000000){
			sizeNum = Math.Round((sizeNum/1000000000),2);
			return sizeNum.ToString() + " GB";
		}
		else if(sizeNum >= 1000000){
			sizeNum = Math.Round((sizeNum/1000000),2);
			return sizeNum.ToString() + " MB";
		}
		else if(sizeNum >= 1000){
			sizeNum = Math.Round((sizeNum/1000),2);
			return sizeNum.ToString() + " KB";
		}
		else{
			return inSize + "B";
		}
	}
    
    public void chooseFile(){
        selectedButton = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        string fileId = selectedButton.GetComponent<FileSelectElement>().fileId.text;
        PlayerPrefs.SetString("chosenFileId", fileId);
        fileUI.SetActive(false);
        calcBehaviour.callPrint();
    }
}
