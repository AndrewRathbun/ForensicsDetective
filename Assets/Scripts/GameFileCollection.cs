using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameFileCollection
{
    public string[] fileCollection;

    public GameFileCollection(string[] fileArray){
        fileCollection = fileArray;
    }
}
