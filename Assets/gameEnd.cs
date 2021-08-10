using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameEnd : MonoBehaviour
{
    public TMP_Dropdown fileSelectDropdown, attackerDropdown, dateDropdown;
    public TMP_Text text;
    public TMP_InputField hashText;
    string[] loadedFiles;
    List<string> uniqueNames = new List<string>();
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
        string selectedFile = fileSelectDropdown.options[fileSelectDropdown.value].text;
        string enteredHash = hashText.text;
        string selectedAttacker = attackerDropdown.options[attackerDropdown.value].text;
        string selectedDate = dateDropdown.options[dateDropdown.value].text;
        if(selectedFile.Equals("BuildTechInc_Onboarding2021.docx") && enteredHash.Equals("0D6CDF31E66A0AA2A11EB9053E00590A")){
            if(selectedAttacker.Equals("Alix.Ereland") && selectedDate.Equals("07/24/2021")){
                Debug.Log("success + BONUS!");
            }
            else{
                Debug.Log("success");
            }
        }
        else{
            Debug.Log("wrong");
        }
    }
}
