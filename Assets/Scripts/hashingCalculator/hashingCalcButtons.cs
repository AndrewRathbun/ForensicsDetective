using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class hashingCalcButtons:MonoBehaviour{
    //Variable declarations
    public GameObject calcBtn, fileBtn;
    public TMP_Text calcBtnTMP, fileBtnTMP;

    //Button hovers
    public void hoverOnCalc(){
        calcBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
        calcBtnTMP.color = new Color32(230, 230, 230, 255);
    }
    public void hoverOffCalc(){
        calcBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
        calcBtnTMP.color = new Color32(30, 30, 30, 255);
    }
    public void hoverOnFile(){
        fileBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
        fileBtnTMP.color = new Color32(230, 230, 230, 255);
    }
    public void hoverOffFile(){
        fileBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
        fileBtnTMP.color = new Color32(30, 30, 30, 255);
    }
}
