using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class clockScript:MonoBehaviour{
    //Variable Declarations
    public TMP_Text clock;

    //Update function
    void Update(){
        DateTime time = DateTime.Now;
        int year = time.Year;
        int month = time.Month;
        int day = time.Day;
        string hour = format(time.Hour);
        string minute = format(time.Minute);
        string second = format(time.Second);
        string ampm;

        if((int.Parse(hour) >= 12) && (int.Parse(hour) != 24)){
            ampm = "PM";
        }
        else{
            ampm = "AM";
        }

        clock.text = (DateTime.Now.ToString("MMMM") + " " + day + " " + year + " " + (int.Parse(hour)%12) + ":" + minute + ":" + second + " " + ampm);
    }

    //Leading zero formatting function
    string format(int str){
        return str.ToString().PadLeft(2, '0');
    }
}
