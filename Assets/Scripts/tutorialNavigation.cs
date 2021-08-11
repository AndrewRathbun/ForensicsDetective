using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class tutorialNavigation : MonoBehaviour
{
    private GameObject navPanel;
    FileSelect fileSelect;
    public GameObject fileUI, introCanvas;

    void Start(){
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name.Equals("hashingCalculator") && !firstRun.firstHashingCalculator){
            introCanvas.SetActive(false);
        }
        else if(scene.name.Equals("commandLine") && !firstRun.firstCLI){
            introCanvas.SetActive(false);
        }
        else if(scene.name.Equals("fileAnalyzer") && !firstRun.firstAnalyzer){
            introCanvas.SetActive(false);
        }
        else if(scene.name.Equals("clientDesktop") && !firstRun.firstDesktop){
            introCanvas.SetActive(false);
        }
    }

    public void restartTutorial(){
        introCanvas.SetActive(true);
        introCanvas.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void navigateBtn(GameObject panelToShow){
        navPanel = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.transform.parent.gameObject;
        panelToShow.SetActive(true);
        navPanel.SetActive(false);
    }
    public void navigateFileBtn(GameObject panelToShow){
        if(fileUI.activeSelf){
            fileUI.SetActive(false);
        }
        else{
            fileUI.SetActive(true);
        }
        navPanel = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.transform.parent.gameObject;
        panelToShow.SetActive(true);
        navPanel.SetActive(false);
    }
    public void finishTutorial(string currentTutorial){
        if(currentTutorial.Equals("hashCalc")){
            firstRun.firstHashingCalculator = false; //Disable hashingCalculator tutorial from running again
        }
        else if(currentTutorial.Equals("cli")){
            firstRun.firstCLI = false; //Disable CLI tutorial from running again
        }
        else if(currentTutorial.Equals("analyzer")){
            firstRun.firstAnalyzer = false; //Disable Analyzer tutorial from running again
        }
        else if(currentTutorial.Equals("desktop")){
            firstRun.firstDesktop = false; //Disable dekstop tutorial from running again
        }
        navPanel = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.transform.parent.gameObject;
        navPanel.SetActive(false);
    }
}
