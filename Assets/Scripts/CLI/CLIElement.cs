using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CLIElement : MonoBehaviour
{
    [SerializeField]
    public TMP_InputField consoleOutput;

    public void setTMP(string cOut){
        consoleOutput.text = cOut;
    }
}
