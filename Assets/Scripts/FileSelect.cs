using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FileSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject fileSelectTemplate;
    public List<GameObject> fileList = new List<GameObject>();
    public GameObject fileUI;

    public void Start()
    {
        for(int i = 1; i <= 30; i++){
            GameObject filePanel = Instantiate(fileSelectTemplate) as GameObject;
            filePanel.SetActive(true);
            filePanel.GetComponent<FileSelectElement>().setTMP("File #"+i, "5"+i+" GB");
            filePanel.transform.SetParent(fileSelectTemplate.transform.parent, false);
            addToFileList(filePanel);
        }
    }
    public void addToFileList(GameObject fileElement){
        Debug.Log("got to here"+fileElement);
        
        fileList.Add(fileElement);
        Debug.Log(fileList.Count);
    }
    public void chooseFile(){
        Debug.Log(fileList.Count);
        fileUI.SetActive(false);
    }
}
