using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFile : MonoBehaviour
{

    //Variable declarations
    private string fname, fextension, fsize, fpath, fdate, fcontent;

    //File object constructors
    public GameFile(string fileName, string fileExtension, string fileSize, string filePath, string fileDate, string fileContent){
        fname = fileName;
        fextension = fileExtension;
        fsize = fileSize;
        fpath = filePath;
        fdate = fileDate;
        fcontent = fileContent;
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
