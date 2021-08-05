using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFile : MonoBehaviour
{

    const int fileCount = 20;

    GameFile[] files = new GameFile[fileCount];
    
    static string path;

    List<string> nameArray = new List<string>{"notAVirus", "Valorant", "Gooqle"};
    List<string> extensionArray = new List<string>{".exe", ".mp4", ".bin"};
    List<string> sizeArray = new List<string>{"100 KB", "200 MB", "3 GB"};
    List<string> pathArray = new List<string>{"C:/", "D:/", "E:/"};
    List<string> dateArray = new List<string>{"7/10/2021", "4/15/2021", "31/12/1999"};
    List<string> contentArray = new List<string>{"HelloWorld", "execute(launchorder666)", "Bacon Cheeseburger"};
    List<string> hexArray = new List<string>{"0x1111", "0x2222", "0x3333"};
    List<string> stringsArray = new List<string>{"a b c", "hello world", "injector"};
    List<string> metaDataArray = new List<string>{"meta A", "meta B", "meta C"};
    bool malicious;
    List<string> permissionsArray = new List<string>{"r--", "rw-", "r-x", "-w-", "--x", "-wx", "rwx", "---"};

    string[] spacename = new string[fileCount];
    string[] spaceLoaded;
    string serializedSpace;
    GameFileCollection fileCollection;

    public GameFile createFile(int value){
        GameFile temp = new GameFile(
            nameArray[Random.Range(0, nameArray.Count - 1)],
            extensionArray[Random.Range(0, extensionArray.Count - 1)],
            sizeArray[Random.Range(0, sizeArray.Count - 1)],
            pathArray[Random.Range(0, pathArray.Count - 1)],
            dateArray[Random.Range(0, dateArray.Count - 1)],
            contentArray[Random.Range(0, contentArray.Count - 1)],
            hexArray[Random.Range(0, hexArray.Count - 1)],
            stringsArray[Random.Range(0, stringsArray.Count - 1)],
            metaDataArray[Random.Range(0, metaDataArray.Count - 1)],
            malicious = (Random.Range(0,2) == 1),
            permissionsArray[Random.Range(0, permissionsArray.Count - 1)],
            value //id
        );
        spacename[value] = JsonUtility.ToJson(temp);
        return temp;
    }
    void Start()
    { 
        path = Application.dataPath + "/save.txt";
        for (int i = 0; i < fileCount; i++)
        {
            createFile(i);
        }
        fileCollection = new GameFileCollection(spacename);
        serializedSpace = JsonUtility.ToJson(fileCollection);
        saveFiles(spacename);
    }
    void saveFiles(string[] fileArray){
        File.WriteAllText(path, serializedSpace);
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
