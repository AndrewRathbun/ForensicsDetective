using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class clockScript : MonoBehaviour
{
    //Variable Declarations
    public TMP_Text clock;

    //Update function
    void Update()
    {
        DateTime time = DateTime.Now;
        int year = time.Year;
        int month = time.Month;
        int day = time.Day;
        int hour = time.Hour;
        int minute = time.Minute;
        int second = time.Second;
        string ampm;

        if((hour >= 12) || (hour != 24)){
            ampm = "PM";
        }
        else{
            ampm = "AM";
        }

        clock.text = (DateTime.Now.ToString("MMMM") + " " + day + " " + year + " " + hour%12 + ":" + minute + ":" + second + " " + ampm);
    }
}
