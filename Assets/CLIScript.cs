using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class CLIScript : MonoBehaviour{
	public GameObject inputFieldText;
	public GameObject consoleDisplay;
	List<string> textArray = new List<string>();

	public void showText(){
		string temp = inputFieldText.GetComponent<TMP_Text>().text + "\n";
		textArray.Add(temp);

		consoleDisplay.GetComponent<TMP_Text>().text += ">"+temp;
	}
	public void loadDesktop(){
    	SceneManager.LoadScene("MainDesktop");
    }
}
