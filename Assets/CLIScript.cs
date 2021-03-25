using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CLIScript : MonoBehaviour{
	public string consoleDisplay;
	public GameObject inputField;
	public GameObject textDisplay;

	public void showText(){
		consoleDisplay = inputField.GetComponent<Text>().text;
		textDisplay.GetComponent<Text>().text = ">"+consoleDisplay;
	}
}
