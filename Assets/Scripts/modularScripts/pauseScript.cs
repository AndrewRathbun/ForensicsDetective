using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScript:MonoBehaviour{
    //Variable declarations
    public static bool gamePaused = false;
    public GameObject pauseMenuUi;

    //Update function
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
        	if(gamePaused){
        		resumeGame();
        	}
        	else{
        		pauseGame();
        	}
        }
    }

    //Action functions
    public void resumeGame(){
    	pauseMenuUi.SetActive(false);
    	Time.timeScale = 1f;
    	gamePaused = false;
    }
    public void pauseGame(){
    	pauseMenuUi.SetActive(true);
    	Time.timeScale = 0f;
    	gamePaused = true;
    }
    public void exitGame(){
    	Application.Quit();
    }
    public void returnToMenu(){
        SceneManager.LoadScene("gameMenu");
    }
}
