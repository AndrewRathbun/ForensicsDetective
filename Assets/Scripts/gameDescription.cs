using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameDescription : MonoBehaviour{
    public GameObject gameDescUI;
    public GameObject caseDescUI;
    public GameObject continueButton;
    public void goToCaseDesc(){
        gameDescUI.SetActive(false);
    	caseDescUI.SetActive(true);
    }
}
