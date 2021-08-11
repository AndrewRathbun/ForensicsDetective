using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameFile
{

    //Variable declarations
    public string fname, fOwner, fextension, fTrueExtension, fsize, fpath, fdate, fcontent, fhex, fstrings, fmetadata, fPermissions;
    public bool fMalicious, fEncoded;
    public int fID;

    //File object constructors
    public GameFile(string fileName, string fileOwner, string fileExtension, string trueFileExtension, string fileSize, string filePath, string fileDate, string fileContent, string fileHex, string fileStrings, string fileMetaData, bool fileIsMalicious, string filePermissions, bool fileIsEncoded, int fileID){
        fname = fileName;
        fOwner = fileOwner;
        fextension = fileExtension;
        fTrueExtension = trueFileExtension;
        fsize = fileSize;
        fpath = filePath;
        fdate = fileDate;
        fcontent = fileContent;
        fhex = fileHex;
        fstrings = fileStrings;
        fmetadata = fileMetaData;
        fMalicious = fileIsMalicious;
        fPermissions = filePermissions;
        fEncoded = fileIsEncoded;
        fID = fileID;
    }

    //Getters
    public string getGameFileName(){
        return fname;
    }
    public string getGameFileOwner(){
        return fOwner;
    }

    public string getGameFileExtension(){
        return fextension;
    }
    public string getGameTrueFileExtension(){
        return fTrueExtension;
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
    }
    public string getGamePermissions(){
        return fPermissions;
    }

    public bool getGameEncoded(){
        return fEncoded;
    }

    public int getGameFileID(){
        return fID;
    }
    override public string ToString(){
        return fname+fOwner+fextension+fTrueExtension+fsize+fpath+fdate+fcontent+fhex+fstrings+fmetadata+fMalicious+fPermissions+fEncoded+fID;
    }

}
