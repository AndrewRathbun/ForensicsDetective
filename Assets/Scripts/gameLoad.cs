using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameLoad : MonoBehaviour{
    public Animator transition;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            loadDesc("MainDesktop");
        }
    }
    private void loadDesktop(){
        loadDesc("MainDesktop");
    }
    public void loadDesc(string sceneName){
        LoadDesktop(sceneName);
    }
    IEnumerator LoadDesktop(string sceneName){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }    
}
