using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class homeMenu:MonoBehaviour{
    //Variable declarations
    public GameObject newGameButton, continueButton, settingsButton, exitButton;

    public void exitGame(){
        Application.Quit();
    }
}
