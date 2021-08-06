using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public bool hashLoaded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadCLI(){
        SceneManager.LoadScene("CLI");
    }

    public void loadAutopsy(){
        SceneManager.LoadScene("fileAnalyser");
    }
    
    public void loadHashCalc(){
        SceneManager.LoadScene("hashingCalculator");
    }
}
