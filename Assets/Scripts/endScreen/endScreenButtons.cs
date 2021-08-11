using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class endScreenButtons:MonoBehaviour{
    //Variable declarations
    public GameObject solveBtn, mainBtn, quitBtn;
    public TMP_Text solveBtnTMP, mainBtnTMP, quitBtnTMP;

    //Button hovers
    public void hoverOnSolve(){
        solveBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
        solveBtnTMP.color = new Color32(230, 230, 230, 255);
    }
    public void hoverOffSolve(){
        solveBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
        solveBtnTMP.color = new Color32(30, 30, 30, 255);
    }
    public void hoverOnMain(){
        mainBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
        mainBtnTMP.color = new Color32(230, 230, 230, 255);
    }
    public void hoverOffMain(){
        mainBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
        mainBtnTMP.color = new Color32(30, 30, 30, 255);
    }
    public void hoverOnQuit(){
        quitBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
        quitBtnTMP.color = new Color32(230, 230, 230, 255);
    }
    public void hoverOffQuit(){
        quitBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
        quitBtnTMP.color = new Color32(30, 30, 30, 255);
    }
}

