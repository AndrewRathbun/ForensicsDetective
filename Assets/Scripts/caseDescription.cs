using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class caseDescription : MonoBehaviour
{
    public GameObject continueButton;
    public void goToGame(){
        SceneManager.LoadScene("clientDesktop");
    }
}
