using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reminderTutorial:MonoBehaviour{

    //Variable declarations
    public GameObject reminderCanvas;

    public void showReminder(){
        reminderCanvas.SetActive(true);
    }

    public void hideReminder(){
        reminderCanvas.SetActive(false);
    }

}
