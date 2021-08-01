using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class difficultySelector : MonoBehaviour
{

    public GameObject mainUI;
    public GameObject difficultyUI;

    public GameObject beginnerDescription;
    public GameObject intermediateDescription;

    public GameObject beginnerButton;
    public GameObject intermediateButton;

    public GameObject startButton;

    public int difficulty = 1; //Default beginner

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showDifficultySelect(){
        mainUI.SetActive(false);
    	difficultyUI.SetActive(true);
    }

    public void changeDifficultySelected(int mode){
        switch(mode){
            case 1:
                beginnerButton.GetComponent<Image>().color = new Color32(255,255,255,70);
                intermediateButton.GetComponent<Image>().color = new Color32(255,255,255,40);
                beginnerDescription.SetActive(true);
                intermediateDescription.SetActive(false);
                break;
            case 2:
                beginnerButton.GetComponent<Image>().color = new Color32(255,255,255,40);
                intermediateButton.GetComponent<Image>().color = new Color32(255,255,255,70);
                beginnerDescription.SetActive(false);
                intermediateDescription.SetActive(true);
                break;
            default:
                break;

        }
    }

    public void backToHome(){
        mainUI.SetActive(true);
    	difficultyUI.SetActive(false);
    }

    public void startGame(){
        SceneManager.LoadScene("MainDesktop");
    }
}
