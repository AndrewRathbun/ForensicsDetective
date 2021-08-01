using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class FileSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject fileSelectTemplate;
    public string[] fileArray;
    public GameObject fileUI;
    private GameObject selectedButton;
    public void Start()
    {
        for(int i = 1; i <= 30; i++){
            GameObject filePanel = Instantiate(fileSelectTemplate) as GameObject;
            filePanel.SetActive(true);
            filePanel.GetComponent<FileSelectElement>().setTMP("File #"+i, "5"+i+" GB");
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
