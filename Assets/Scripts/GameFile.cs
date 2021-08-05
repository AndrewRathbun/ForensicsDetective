using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameFile
{

    //Variable declarations
    public string fname, fextension, fsize, fpath, fdate, fcontent, fhex, fstrings, fmetadata, fPermissions;
    public bool fMalicious;
    public int fID;

    //File object constructors
    public GameFile(string fileName, string fileExtension, string fileSize, string filePath, string fileDate, string fileContent, string fileHex, string fileStrings, string fileMetaData, bool fileIsMalicious, string filePermissions, int fileID){
        fname = fileName;
        fextension = fileExtension;
        fsize = fileSize;
        fpath = filePath;
        fdate = fileDate;
        fcontent = fileContent;
        fhex = fileHex;
        fstrings = fileStrings;
        fmetadata = fileMetaData;
        fMalicious = fileIsMalicious;
        fPermissions = filePermissions;
        fID = fileID;
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
    public bool getGameMalicious(){
        return fMalicious;
    }public string getGamePermissions(){
        return fPermissions;
    }

    public int getGameFileID(){
        return fID;
    }

}
