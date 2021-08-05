using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class fileAnalyse : MonoBehaviour
{
    //Variable declarations
    [SerializeField]
    private GameObject fileAnalyseTemplate;

    public GameObject hexBtn, stringsBtn, metaBtn;
    public string[] analyseArray;
    string[] loadedFiles;
    GameObject template;
    public TMP_Text textField;
    GameFile temp;

    //Start function
    void Start()
    {

        loadedFiles = GenerateFile.loadFiles();

        for(int i = 0; i < loadedFiles.Length; i++){
            GameFile temp = JsonUtility.FromJson<GameFile>(loadedFiles[i]);
            GameObject analysePanel = Instantiate(fileAnalyseTemplate) as GameObject;
            analysePanel.SetActive(true);
            analysePanel.GetComponent<fileAnalyseElement>().setText(temp.getGameFileName(), temp.getGameFilePath(), temp.getGameFileDate(), temp.getGameFileExtension(), temp.getGameFileSize(), temp.getGameFileID().ToString());
            analysePanel.transform.SetParent(fileAnalyseTemplate.transform.parent, false);
        }
    }

    //Functions to populate the InspectorView
    public void elaborate(GameObject currentTemplate){
        int ins = int.Parse(currentTemplate.GetComponent<fileAnalyseElement>().fileID.text);
        temp = JsonUtility.FromJson<GameFile>(loadedFiles[ins]);
        textField.text = temp.getGameFileHex();
    }

    public void chosenElaborate(int val){
        switch(val){
            case 1:
                textField.text = temp.getGameFileHex();
                break;
            case 2:
                textField.text = temp.getGameFileStrings();
                break;
            case 3:
                textField.text = temp.getGameFileMetaData();
                break;
            default:
                break;
        }
    }
}
