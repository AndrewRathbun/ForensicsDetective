using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class CLIScript : MonoBehaviour{
	public string consoleDisplay;
	public GameObject inputField;
	public GameObject textDisplay;

	public void showText(){
		consoleDisplay = inputField.GetComponent<TMP_Text>().text;
		textDisplay.GetComponent<TMP_Text>().text = ">"+consoleDisplay;
	}
	public void loadDesktop(){
    	SceneManager.LoadScene("MainDesktop");
    }
}
