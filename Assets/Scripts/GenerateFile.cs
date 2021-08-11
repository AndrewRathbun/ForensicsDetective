using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFile : MonoBehaviour
{

    const int fileCount = 20;
    
    static string path;
    GameFileCollection fileCollection;
    void Start()
    { 
        path = Application.streamingAssetsPath + "/save.txt";
        loadFiles();
    }
    public static string[] loadFiles(){
        string[] outFiles = new string[]{""};
        if(File.Exists(path)){
            string saveString = File.ReadAllText(path);
            GameFileCollection fileOut = JsonUtility.FromJson<GameFileCollection>(saveString);
            outFiles = fileOut.fileCollection;
        }
        return outFiles;
    }
}
