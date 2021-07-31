using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class homeMenu : MonoBehaviour
{

    public GameObject newGameButton, continueButton, settingsButton, exitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitGame(){
        Application.Quit();
        Debug.Log("game quit");
    }
}
