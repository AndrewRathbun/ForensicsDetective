using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class calcBehaviour : MonoBehaviour
{
    Toggle md4Toggle, md5Toggle, sha1Toggle, sha256Toggle, sha512Toggle, panamaToggle, tigerToggle, crc32Toggle, allToggle;
    TMP_Text md4Lbl, md5Lbl, sha1Lbl, sha256Lbl, sha512Lbl, panamaLbl, tigerLbl, crc32Lbl, allLbl;
    public GameObject fileUI;

    // Start is called before the first frame update
    void Start()
    {
        md4Toggle = GameObject.Find("md4Toggle").GetComponent<Toggle>();
        md5Toggle = GameObject.Find("md5Toggle").GetComponent<Toggle>();
        sha1Toggle = GameObject.Find("sha1Toggle").GetComponent<Toggle>();
        sha256Toggle = GameObject.Find("sha256Toggle").GetComponent<Toggle>();
        sha512Toggle = GameObject.Find("sha512Toggle").GetComponent<Toggle>();
        panamaToggle = GameObject.Find("panamaToggle").GetComponent<Toggle>();
        tigerToggle = GameObject.Find("tigerToggle").GetComponent<Toggle>();
        crc32Toggle = GameObject.Find("crc32Toggle").GetComponent<Toggle>();
        allToggle = GameObject.Find("allToggle").GetComponent<Toggle>();
        md4Lbl = GameObject.Find("md4Label").GetComponent<TMP_Text>();
        md5Lbl = GameObject.Find("md5Label").GetComponent<TMP_Text>();
        sha1Lbl = GameObject.Find("sha1Label").GetComponent<TMP_Text>();
        sha256Lbl = GameObject.Find("sha256Label").GetComponent<TMP_Text>();
        sha512Lbl = GameObject.Find("sha512Label").GetComponent<TMP_Text>();
        panamaLbl = GameObject.Find("panamaLabel").GetComponent<TMP_Text>();
        tigerLbl = GameObject.Find("tigerLabel").GetComponent<TMP_Text>();
        crc32Lbl = GameObject.Find("crc32Label").GetComponent<TMP_Text>();
        md4Toggle.onValueChanged.AddListener(delegate{
            checkText(md4Toggle, md4Lbl);
        });
        md5Toggle.onValueChanged.AddListener(delegate{
            checkText(md5Toggle, md5Lbl);
        });
        sha1Toggle.onValueChanged.AddListener(delegate{
            checkText(sha1Toggle, sha1Lbl);
        });
        sha256Toggle.onValueChanged.AddListener(delegate{
            checkText(sha256Toggle, sha256Lbl);
        });
        sha512Toggle.onValueChanged.AddListener(delegate{
            checkText(sha512Toggle, sha512Lbl);
        });
        panamaToggle.onValueChanged.AddListener(delegate{
            checkText(panamaToggle, panamaLbl);
        });
        tigerToggle.onValueChanged.AddListener(delegate{
            checkText(tigerToggle, tigerLbl);
        });
        crc32Toggle.onValueChanged.AddListener(delegate{
            checkText(crc32Toggle, crc32Lbl);
        });
        allToggle.onValueChanged.AddListener(delegate{
            allChanged(allToggle);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void allChanged(Toggle allT){
        if(allT.GetComponent<Toggle>().isOn){
            allOn();
        }
        else{
            allOff();
        }
    }
    void allOn(){
        md4Toggle.isOn = true;
        md5Toggle.isOn = true;
        sha1Toggle.isOn = true;
        sha256Toggle.isOn = true;
        sha512Toggle.isOn = true;
        panamaToggle.isOn = true;
        tigerToggle.isOn = true;
        crc32Toggle.isOn = true;
    }
    void allOff(){
        md4Toggle.isOn = false;
        md5Toggle.isOn = false;
        sha1Toggle.isOn = false;
        sha256Toggle.isOn = false;
        sha512Toggle.isOn = false;
        panamaToggle.isOn = false;
        tigerToggle.isOn = false;
        crc32Toggle.isOn = false;
    }
    void checkText(Toggle changedT, TMP_Text changedL){
        if(changedT.isOn){
            changedL.color = new Color32(255,255,255,255);
        }
        else{
            changedL.color = new Color32(255,255,255,100);
        }
    }
    public void showFileSelect(){
    	fileUI.SetActive(true);
    }
}
