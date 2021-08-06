using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class backBtnScript:MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
    //Variable declarations
    public GameObject backBtn;
    public TMP_Text backBtnTMP;

    //Hover functions
    public void OnPointerEnter(PointerEventData eventData)
    {
        backBtn.GetComponent<Image>().color = new Color32(30, 37, 46, 255);
        backBtnTMP.color = new Color32(230, 230, 230, 255);
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        backBtn.GetComponent<Image>().color = new Color32(230, 230, 230, 255);
        backBtnTMP.color = new Color32(30, 30, 30, 255);
    }
}
