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
        if(firstRun.firstHashingCalculator == false){
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
    public void finishTutorial(){
        firstRun.firstHashingCalculator = false; //Disable hashingCalculator tutorial from running again
        navPanel = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.transform.parent.gameObject;
        navPanel.SetActive(false);
    }
}
