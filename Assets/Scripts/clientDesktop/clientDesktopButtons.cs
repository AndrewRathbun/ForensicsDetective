using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class clientDesktopButtons:MonoBehaviour{
    //Variable declarations
    public GameObject fileBtn, hashBtn, cliBtn, solveBtn;
    public TMP_Text fileBtnTMP, hashBtnTMP, cliBtnTMP, solveBtnTMP;

    //Button hovers
    public void hoverOnFile(){
        fileBtn.GetComponent<Image>().color = new Color32(222, 162, 73, 255);
        fileBtnTMP.color = new Color32(222, 162, 73, 255);
    }
    public void hoverOffFile(){
        fileBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
        fileBtnTMP.color = new Color32(230, 230, 230, 255);
    }
    public void hoverOnHash(){
        hashBtn.GetComponent<Image>().color = new Color32(222, 162, 73, 255);
        hashBtnTMP.color = new Color32(222, 162, 73, 255);
    }
    public void hoverOffHash(){
        hashBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
        hashBtnTMP.color = new Color32(230, 230, 230, 255);
    }
    public void hoverOnCli(){
        cliBtn.GetComponent<Image>().color = new Color32(222, 162, 73, 255);
        cliBtnTMP.color = new Color32(222, 162, 73, 255);
    }
    public void hoverOffCli(){
        cliBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
        cliBtnTMP.color = new Color32(230, 230, 230, 255);
    }
    public void hoverOnSolve(){
        solveBtn.GetComponent<Image>().color = new Color32(222, 162, 73, 255);
        solveBtnTMP.color = new Color32(222, 162, 73, 255);
    }
    public void hoverOffSolve(){
        solveBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
        solveBtnTMP.color = new Color32(230, 230, 230, 255);
    }
}
