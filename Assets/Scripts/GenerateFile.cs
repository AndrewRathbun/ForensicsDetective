using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFile : MonoBehaviour
{

    List<GameFile> files = new List<GameFile>();

    List<string> nameArray = new List<string>{"notAVirus", "Valorant", "Gooqle"};
    List<string> extensionArray = new List<string>{".exe", ".mp4", ".bin"};
    List<string> sizeArray = new List<string>{"100 KB", "200 MB", "3 GB"};
    List<string> pathArray = new List<string>{"C:/", "D:/", "E:/"};
    List<string> dateArray = new List<string>{"7/10/2021", "4/15/2021", "31/12/1999"};
    List<string> contentArray = new List<string>{"HelloWorld", "execute(launchorder666)", "Bacon Cheeseburger"};

    public GameFile createFile(){
        GameFile temp = new GameFile(
            nameArray[Random.Range(0, nameArray.Count - 1)],
            extensionArray[Random.Range(0, extensionArray.Count - 1)],
            sizeArray[Random.Range(0, sizeArray.Count - 1)],
            pathArray[Random.Range(0, pathArray.Count - 1)],
            dateArray[Random.Range(0, dateArray.Count - 1)],
            contentArray[Random.Range(0, contentArray.Count - 1)]
        );

        return temp;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            files.Add(createFile());
        }

        for (int i = 0; i < files.Count; i++)
        {
            Debug.Log(files[i].getGameFileName());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
