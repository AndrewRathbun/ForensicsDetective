using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameEnd : MonoBehaviour
{
    public TMP_Dropdown fileSelectDropdown, attackerDropdown, dateDropdown;
    public TMP_Text text, titleText, descriptionText, correctFileText, correctHashText, correctAttackerText, correctDateText, mainPortionText, mainScoreText, optionalPortionText, optionalScoreText, totalScoreText;
	public Image correctFileImg, correctHashImg, correctAttackerImg, correctDateImg;
	public Sprite checkImg, wrongImg;
    public TMP_InputField hashText;
    string[] loadedFiles;
    List<string> uniqueNames = new List<string>();
    public GameObject solveUI, scoreUI, titleBarUI;
    void Start(){
        loadedFiles = GenerateFile.loadFiles();
        fileSelectDropdown.options.Clear();
        attackerDropdown.options.Clear();
        dateDropdown.options.Clear();
        for(int i = 0; i < loadedFiles.Length; i++){
            GameFile fileToPrint = JsonUtility.FromJson<GameFile>(loadedFiles[i]);
            setFile(fileToPrint.getGameFileName()+fileToPrint.getGameFileExtension());
            if(!uniqueNames.Contains(fileToPrint.getGameFileOwner())){
                uniqueNames.Add(fileToPrint.getGameFileOwner());
            }
        }
        parseOwners(uniqueNames);
        setDate();
        fileSelectDropdown.RefreshShownValue();
        attackerDropdown.RefreshShownValue();
        dateDropdown.RefreshShownValue();
    }
    void parseOwners(List<string> inOwner){
        foreach (string x in inOwner){
            setAttacker(x);
        }
    }
    void setFile(string inString){
        fileSelectDropdown.options.Add (new TMP_Dropdown.OptionData() {text=inString});
    }
    void setAttacker(string inString){
        attackerDropdown.options.Add (new TMP_Dropdown.OptionData() {text=inString});
    }
    void setDate(){
        for(int i = 21; i <= 28; i++){
            dateDropdown.options.Add (new TMP_Dropdown.OptionData() {text="07/"+i+"/2021"});
            
        }
    }
    public void solveCase(){
        bool selectedFile = (fileSelectDropdown.options[fileSelectDropdown.value].text).Equals("BuildTechInc_Onboarding2021.docx");
        bool enteredHash = hashText.text.Equals("EA58C95455020BD3233BE14F1011F7C8");;
        bool selectedAttacker = attackerDropdown.options[attackerDropdown.value].text.Equals("Alix.Ereland");
        bool selectedDate = dateDropdown.options[dateDropdown.value].text.Equals("07/24/2021");
        solveUI.SetActive(false);
        titleBarUI.SetActive(false);
        scoreUI.SetActive(true);
        showEndScreen(selectedFile, enteredHash, selectedAttacker, selectedDate);
    }
    void showEndScreen(bool correctFile, bool correctHash, bool correctAttacker, bool correctDate){
		int numMain = 0;
		int numOpt = 0;
        if(correctFile && correctHash){
			titleText.text = "Congratulations!";
			setCorrect(correctFileImg, correctFileText);
			setCorrect(correctHashImg, correctHashText);
			numMain = 2;
        }
        else{
			titleText.text = "Try again!";
			descriptionText.text = "Looks like you weren't able to complete one of the main objectives of this case!\nYou can run through it again as many times as you'd like. Make use of the provided tutorials and manuals if you're stuck at any point!";
            if(correctFile){
				setCorrect(correctFileImg, correctFileText);
				numMain += 1;
			}
			else{
				setIncorrect(correctFileImg, correctFileText);
			}
            if(correctHash){
				setCorrect(correctHashImg, correctHashText);
				numMain += 1;
			}
			else{
				setIncorrect(correctHashImg, correctHashText);
			}
        }
        if(correctAttacker){
			setCorrect(correctAttackerImg, correctAttackerText);
			numOpt += 1;
		}
		else{
			setIncorrect(correctAttackerImg, correctAttackerText);
		}
        if(correctDate){
			setCorrect(correctDateImg, correctDateText);
			numOpt += 1;
		}
		else{
			setIncorrect(correctDateImg, correctDateText);
		}
		setTheScore(numMain, numOpt);
    }
	void setCorrect(Image inImage, TMP_Text inText){
		inImage.sprite = checkImg;
		inImage.color = new Color32(28,164,0,255);
		inText.fontStyle = FontStyles.Normal;
		inText.color = new Color32(255, 255, 255, 255);
	}
	void setIncorrect(Image inImage, TMP_Text inText){
		inImage.sprite = wrongImg;
		inImage.color = new Color32(164,3,0,255);
		inText.fontStyle = FontStyles.Strikethrough;
		inText.color = new Color32(142, 142, 142, 255);
	}
	void setTheScore(int inMain, int inOpt){
		mainPortionText.text = inMain + "/2";
		optionalPortionText.text = inOpt + "/2";
		mainScoreText.text = "+" + inMain * 100;
		optionalScoreText.text = "+" + inOpt * 50;
		totalScoreText.text = "" + ((inMain * 100) + (inOpt * 50));
	}
	public void exitGame(){
    	Application.Quit();
    }
    public void returnToMenu(){
        SceneManager.LoadScene("gameMenu");
    }
}
