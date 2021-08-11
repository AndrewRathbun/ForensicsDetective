using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class caseDescription : MonoBehaviour
{
    public GameObject scenarioUI, detailsUI, scenarioBtn, detailsBtn;
    public void showScenario(){
        scenarioUI.SetActive(true);
        detailsUI.SetActive(false);
        scenarioBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
        detailsBtn.GetComponent<Image>().color = new Color32(11, 15, 20, 255);
        scenarioUI.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
    }
    public void showDetails(){
        detailsUI.SetActive(true);
        scenarioUI.SetActive(false);
        detailsBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
        scenarioBtn.GetComponent<Image>().color = new Color32(11, 15, 20, 255);
        detailsUI.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
    }
    public void goToGame(){
        SceneManager.LoadScene("clientDesktop");
    }
}
