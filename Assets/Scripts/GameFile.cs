using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameFile : MonoBehaviour
{

    //Variable declarations
    private string fname, fextension, fsize, fpath, fdate, fcontent;
    private string fhex, fstrings, fmetadata;

    //File object constructors
    public GameFile(string fileName, string fileExtension, string fileSize, string filePath, string fileDate, string fileContent, string fileHex, string fileStrings, string fileMetaData){
        fname = fileName;
        fextension = fileExtension;
        fsize = fileSize;
        fpath = filePath;
        fdate = fileDate;
        fcontent = fileContent;
        fhex = fileHex;
        fstrings = fileStrings;
        fmetadata = fileMetaData;
    }

    //Getters
    public string getGameFileName(){
        return fname;
    }

    public string getGameFileExtension(){
        return fextension;
    }

    public string getGameFileSize(){
        return fsize;
    }

    public string getGameFilePath(){
        return fpath;
    }

    public string getGameFileDate(){
        return fdate;
    }

    public string getGameFileContent(){
        return fcontent;
    }

    public string getGameFileHex(){
        return fhex;
    }

    public string getGameFileStrings(){
        return fstrings;
    }

    public string getGameFileMetaData(){
        return fmetadata;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
