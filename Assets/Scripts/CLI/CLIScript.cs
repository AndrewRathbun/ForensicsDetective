using System;
using System.Text;
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
	GameFile foundFile;
	string[] loadedFiles;
	int padWidth = 15;

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
        cliDisplayPanel.GetComponent<TMP_InputField>().text = temp;
        cliDisplayPanel.transform.SetParent(cliDisplayTemplate.transform.parent, false);
		inputField.text = "";
		EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
	}
	public void parseInput(){
		string temp = inputFieldText.GetComponent<TMP_Text>().text;
		showText(">"+temp);
		temp = temp.ToLower();
		temp = temp.Substring(0, temp.Length - 1);
		if(temp.StartsWith("ls -") || temp.Equals("ls")){
			printFiles(temp);
		}
		else if(temp.StartsWith("man ") || temp.Equals("man")){
			printMan(temp);
		}
		else if(temp.StartsWith("cat ") || temp.Equals("cat")){
			printCat(temp);
		}
		else if(temp.StartsWith("trid ") || temp.Equals("trid")){
			printTrid(temp);
		}
		else if(temp.StartsWith("decode ") || temp.Equals("decode")){
			printEncoded(temp);
		}
		else if(temp.Equals("?")){
			printCommands();
		}
		else if(temp.Equals("")){
			return;
		}
		else{
			showText(" Invalid Command\n Enter ? to show a list of commands");
		}
		
	}
	public void printFiles(string tempIn){
		if(tempIn.Length > 2){
			string[] args = tempIn.Split('-');
			if(args[1].Equals("l")){
				printAll(1);
			}
			else if(args[1].Equals("lh") || args[1].Equals("hl")){
				printAll(2);
			}
			else{
				showText(" Invalid Command");
			}
		}
		else{
			printFileNames();
		}
		
	}
	public void printAll(int args){
		string tempOutput = "Permissions".PadRight(padWidth);
		string formattedSize = "";
		tempOutput = string.Concat(tempOutput, "Owner".PadRight(padWidth));
		tempOutput = string.Concat(tempOutput, "Date".PadRight(padWidth));
		tempOutput = string.Concat(tempOutput, "Size".PadRight(padWidth));
		tempOutput = string.Concat(tempOutput, "Name");
		showText(" "+tempOutput);
		for(int i = 0; i < loadedFiles.Length; i++){
            GameFile fileToPrint = JsonUtility.FromJson<GameFile>(loadedFiles[i]);
			formattedSize = fileToPrint.getGameFileSize();
			if(args > 1){
				formattedSize = formatSize(formattedSize);
			}
			showText(" "+fileToPrint.getGamePermissions().PadRight(padWidth)+fileToPrint.getGameFileOwner().PadRight(padWidth)+fileToPrint.getGameFileDate().PadRight(padWidth)+formattedSize.PadRight(padWidth)+fileToPrint.getGameFileName()+fileToPrint.getGameFileExtension());
        }
	}
	public string formatSize(string inSize){
		double sizeNum = Int64.Parse(inSize);
		if(sizeNum >= 1000000000){
			sizeNum = Math.Round((sizeNum/1000000000),2);
			return sizeNum.ToString() + "GB";
		}
		else if(sizeNum >= 1000000){
			sizeNum = Math.Round((sizeNum/1000000),2);
			return sizeNum.ToString() + "MB";
		}
		else if(sizeNum >= 1000){
			sizeNum = Math.Round((sizeNum/1000),2);
			return sizeNum.ToString() + "KB";
		}
		else{
			return inSize + "B";
		}
	}
	public void printFileNames(){
		for(int i = 0; i < loadedFiles.Length; i++){
            GameFile fileToPrint = JsonUtility.FromJson<GameFile>(loadedFiles[i]);
			showText(" "+fileToPrint.getGameFileName()+fileToPrint.getGameFileExtension());
        }
	}
	public void printCat(string inArgs){
		string[] args = inArgs.Split(' ');
		if(args.Length > 2){
			showText("Invalid Command");
		}
		else if(args.Length == 2){
			string fileName = args[1];
			string[] fileContents = fileName.Split('.');
			if(fileContents.Length == 2){
				if((foundFile = findFile(fileContents))!= null){
					showText(foundFile.getGameFileContent());
				}
				else{
					showText("File does not exist");
				}
			}
			else{
				showText("cat: " + fileName + ": No such file or directory");
			}
		}
		else{
			showText("Which file would you like to examine?\nUsage: cat [file name]");
		}
	}
	public void printTrid(string inArgs){
		string[] args = inArgs.Split(' ');
		if(args.Length == 2){
			string fileName = args[1];
			string[] fileContents = fileName.Split('.');
			if(fileContents.Length == 2){
				if((foundFile = findFile(fileContents))!= null){
					showText("Collecting data from file: " + fileName + "\nAnalyzing...\n\nSuspected file extension: " + foundFile.getGameTrueFileExtension());
				}
				else{
					showText("File does not exist");
				}
			}
			else{
				showText("trid: " + fileName + ": No such file or directory");
			}
		}
		else{
			showText("Which file would you like to examine?\nUsage: trid [file name]");
		}
	}
	public void printEncoded(string inArgs){
		string[] args = inArgs.Split(' ');
		if(args.Length == 2){
			string fileName = args[1];
			string[] fileContents = fileName.Split('.');
			if(fileContents.Length == 2){
				if((foundFile = findFile(fileContents))!= null){
					if(foundFile.getGameEncoded()){
						string encodedString = foundFile.getGameFileContent();
						byte[] data = Convert.FromBase64String(encodedString);
						string decodedString = Encoding.UTF8.GetString(data);
						showText(decodedString);
					}
					else{
						showText("File not encoded");
					}
				}
				else{
					showText("File does not exist");
				}
			}
			else{
				showText("decode: " + fileName + ": No such file or directory");
			}
		}
		else{
			showText("Which file would you like to decode?\nUsage: decode [file name]");
		}
	}
	public void printCommands(){
		showText("Available commands\n\tls\n\tcat\n\ttrid\n\tdecode");
	}
	public void printMan(string inArgs){
		string[] args = inArgs.Split(' ');
		if(args.Length > 2){
			showText("Invalid Command");
		}
		else if(args.Length == 1){
			showText("What manual page do you want?\nUsage: man [command]");
		}
		else{
			switch(args[1]){
				case "ls":
					showText("NAME\n\tls - list directory contents\nSYNOPSIS\n\tls [OPTION]...\nDESCRIPTION\n\tList information about the FILEs. Entries are sorted alphabetically"
					+"\n\t-l\n\t\tuse a long listing format\n\t-h\n\t\tmust be used with -l (like -lh)\n\t\thuman readable, print file sizes like 1K 234M 2G etc.");
					break;
				case "cat":
					showText("NAME\n\tcat - concatenate files and print on the standard output\nSYNOPSIS\n\tcat [FILENAME]...\nDESCRIPTION\n\tConcatenate FILE(s) to standard output."
					+"\nEXAMPLE\n\tcat test.txt\n\t\tOutput the contents of test.txt");
					break;
				case "trid":
					showText("NAME\n\ttrid - File Identifier\nSYNOPSIS\n\ttrid [FILENAME]...\nDESCRIPTION\n\tIdentify the true filetype of a file, regardless of its extension."
					+"\nEXAMPLE\n\ttrid test.txt\n\t\tAnalyze test.txt and identify its true file extension.");
					break;
				case "decode":
					showText("NAME\n\tdecode - Decode the content of a file.\nSYNOPSIS\n\tdecode [FILENAME]...\nDESCRIPTION\n\tDecode the contents of an encoded file."
					+"\nEXAMPLE\n\tdecode test.txt\n\t\tDecode the contents of test.txt and print the results.");
					break;
				default:
					break;
			}
		}
	}
	public GameFile findFile(string[] inFile){
		for(int i = 0; i < loadedFiles.Length; i++){
            GameFile fileToPrint = JsonUtility.FromJson<GameFile>(loadedFiles[i]);
			if(fileToPrint.getGameFileName().ToLower().Equals(inFile[0]) && fileToPrint.getGameFileExtension().ToLower().TrimStart('.').Equals(inFile[1])){
				return fileToPrint;
			}
		}
		return null;
	}
	public void loadDesktop(){
		SceneManager.LoadScene("MainDesktop");
		// SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainDesktop"));
    }
}
