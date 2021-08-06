using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class fileAnalyze:MonoBehaviour{
    //Serialized variables
    [SerializeField]
    private GameObject fileAnalyzeTemplate = null;

    //Variable declarations
    public GameObject hexBtn, stringsBtn, metaBtn;
    public TMP_Text hexBtnTMP, stringsBtnTMP, metaBtnTMP;
    public string[] analyzeArray;
    string[] loadedFiles;
    public TMP_Text textField;
    GameFile temp;
    public int chosenBtn = 0;
    public int firstBtn = 0;

    //Start function
    void Start()
    {
        loadedFiles = GenerateFile.loadFiles();
        for(int i = 0; i < loadedFiles.Length; i++){
            GameFile temp = JsonUtility.FromJson<GameFile>(loadedFiles[i]);
            GameObject analyzePanel = Instantiate(fileAnalyzeTemplate) as GameObject;
            analyzePanel.SetActive(true);
            analyzePanel.GetComponent<fileAnalyzeElement>().setText(temp.getGameFileName(), temp.getGameFilePath(), temp.getGameFileDate(), temp.getGameFileExtension(), temp.getGameFileSize(), temp.getGameFileID().ToString());
            analyzePanel.transform.SetParent(fileAnalyzeTemplate.transform.parent, false);
        }
    }

    //Functions to populate the InspectorView
    public void elaborate(GameObject currentTemplate){
        int ins = int.Parse(currentTemplate.GetComponent<fileAnalyzeElement>().fileID.text);
        temp = JsonUtility.FromJson<GameFile>(loadedFiles[ins]);

        void resetHighlight(){
            GameObject parentGameObject = GameObject.Find("DirectoryContent");
            List<GameObject> childGameObjects = new List<GameObject>();
            int numOfFiles = 20;
            for(int i = 0; i <= numOfFiles; i++){
                parentGameObject.transform.GetChild(i).gameObject.GetComponent<fileAnalyzeElement>().fileName.color = new Color32(230, 230, 230, 255);
                parentGameObject.transform.GetChild(i).gameObject.GetComponent<fileAnalyzeElement>().filePath.color = new Color32(230, 230, 230, 255);
                parentGameObject.transform.GetChild(i).gameObject.GetComponent<fileAnalyzeElement>().fileDate.color = new Color32(230, 230, 230, 255);
                parentGameObject.transform.GetChild(i).gameObject.GetComponent<fileAnalyzeElement>().fileType.color = new Color32(230, 230, 230, 255);
                parentGameObject.transform.GetChild(i).gameObject.GetComponent<fileAnalyzeElement>().fileSize.color = new Color32(230, 230, 230, 255);
            }
        }

        resetHighlight();

        currentTemplate.GetComponent<fileAnalyzeElement>().fileName.color = new Color32(222, 162, 73, 255);
        currentTemplate.GetComponent<fileAnalyzeElement>().filePath.color = new Color32(222, 162, 73, 255);
        currentTemplate.GetComponent<fileAnalyzeElement>().fileDate.color = new Color32(222, 162, 73, 255);
        currentTemplate.GetComponent<fileAnalyzeElement>().fileType.color = new Color32(222, 162, 73, 255);
        currentTemplate.GetComponent<fileAnalyzeElement>().fileSize.color = new Color32(222, 162, 73, 255);
        
        if(firstBtn == 0){
            chosenElaborate(1);
            hexBtn.GetComponent<Button>().interactable = true;
            stringsBtn.GetComponent<Button>().interactable = true;
            metaBtn.GetComponent<Button>().interactable = true;
            firstBtn = 1;
        }
        else{
            chosenElaborate(chosenBtn);
        }
    }
    public void chosenElaborate(int val){
        switch(val){
            case 1:
                chosenBtn = 1;
                chosenButton(1);
                textField.text = temp.getGameFileHex();
                break;
            case 2:
                chosenBtn = 2;
                chosenButton(2);
                textField.text = temp.getGameFileStrings();
                break;
            case 3:
                chosenBtn = 3;
                chosenButton(3);
                textField.text = temp.getGameFileMetaData();
                break;
            default:
                break;
        }
    }
    public void chosenButton(int val){

        void resetButtons(){
            hexBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
            hexBtnTMP.color = new Color32(230, 230, 230, 255);
            stringsBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
            stringsBtnTMP.color = new Color32(230, 230, 230, 255);
            metaBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
            metaBtnTMP.color = new Color32(230, 230, 230, 255);
        }

        resetButtons();

        switch(val){
            case 1:
                hexBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
                hexBtnTMP.color = new Color32(30, 30, 30, 255);
                break;
            case 2:
                stringsBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
                stringsBtnTMP.color = new Color32(30, 30, 30, 255);
                break;
            case 3:
                metaBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
                metaBtnTMP.color = new Color32(30, 30, 30, 255);
                break;
            default:
                break;
        }
    }

    //Button hovers
    public void hoverOnHex(){
        if(firstBtn != 0){
            hexBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
            hexBtnTMP.color = new Color32(30, 30, 30, 255);
        }
    }
    public void hoverOffHex(){
        if(firstBtn != 0 && chosenBtn != 1){
            hexBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
            hexBtnTMP.color = new Color32(230, 230, 230, 255);
        }
    }
    public void hoverOnStrings(){
        if(firstBtn != 0){
            stringsBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
            stringsBtnTMP.color = new Color32(30, 30, 30, 255);
        }
    }
    public void hoverOffStrings(){
        if(firstBtn != 0 && chosenBtn != 2){
            stringsBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
            stringsBtnTMP.color = new Color32(230, 230, 230, 255);
        }
    }
    public void hoverOnMeta(){
        if(firstBtn != 0){
            metaBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
            metaBtnTMP.color = new Color32(30, 30, 30, 255);
        }
    }
    public void hoverOffMeta(){
        if(firstBtn != 0 && chosenBtn != 3){
            metaBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
            metaBtnTMP.color = new Color32(230, 230, 230, 255);
        }
    }
}
