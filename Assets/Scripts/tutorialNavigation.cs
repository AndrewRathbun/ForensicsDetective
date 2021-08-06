using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tutorialNavigation : MonoBehaviour
{
    private GameObject navPanel;
    FileSelect fileSelect;
    public GameObject fileUI;
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
        navPanel = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.transform.parent.gameObject;
        navPanel.SetActive(false);
    }
}
