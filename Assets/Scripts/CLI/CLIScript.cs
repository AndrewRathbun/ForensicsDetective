using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;


public class CLIScript : MonoBehaviour{
	[SerializeField]
    private GameObject cliDisplayTemplate = null;
	public GameObject inputFieldText, consoleDisplay;
	public TMP_InputField inputField;
	string[] loadedFiles;

	public void Start(){
        loadedFiles = GenerateFile.loadFiles();
		EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
    }
	void Update(){
		string temp = inputFieldText.GetComponent<TMP_Text>().text;
		if(Input.GetKeyUp(KeyCode.Return)){
			parseInput();
		}
	}

	public void showText(string temp){
		GameObject cliDisplayPanel = Instantiate(cliDisplayTemplate) as GameObject;
        cliDisplayPanel.SetActive(true);
        cliDisplayPanel.GetComponent<TMP_Text>().text = temp;
        cliDisplayPanel.transform.SetParent(cliDisplayTemplate.transform.parent, false);
		inputField.text = "";
		EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
	}
	public void parseInput(){
		string temp = inputFieldText.GetComponent<TMP_Text>().text;
		showText(">"+temp);
		temp = temp.Substring(0, temp.Length - 1);
		if(temp.StartsWith("ls ") || temp.Equals("ls")){
			printFiles();
		}
		else if(temp.Equals("")){
			return;
		}
		else{
			showText(" Invalid Command");
		}
		
	}
	public void printFiles(){
		string tempOutput = "filedate";
		tempOutput = string.Concat(tempOutput, " \tfilesize");
		tempOutput = string.Concat(tempOutput, "\tfilename");
		showText(" "+tempOutput);
		for(int i = 0; i < loadedFiles.Length; i++){
            GameFile fileToPrint = JsonUtility.FromJson<GameFile>(loadedFiles[i]);
			showText(" "+fileToPrint.getGameFileDate()+"\t"+fileToPrint.getGameFileSize()+"\t"+fileToPrint.getGameFileName());
        }
	}
	public void loadDesktop(){
		SceneManager.LoadScene("MainDesktop");
		// SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainDesktop"));
    }
}
