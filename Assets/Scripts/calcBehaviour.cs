using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class calcBehaviour : MonoBehaviour
{
    Toggle md5Toggle, sha1Toggle, sha256Toggle, sha512Toggle, allToggle;
    TMP_Text md5Lbl, sha1Lbl, sha256Lbl, sha512Lbl, allLbl;
    public GameObject md5OutputField, sha1OutputField, sha256OutputField, sha512OutputField;
    static TMP_Text filePrint;
    public GameObject fileUI;
    string[] fileArray;

    // Start is called before the first frame update
    void Start()
    {
        md5Toggle = GameObject.Find("md5Toggle").GetComponent<Toggle>();
        sha1Toggle = GameObject.Find("sha1Toggle").GetComponent<Toggle>();
        sha256Toggle = GameObject.Find("sha256Toggle").GetComponent<Toggle>();
        sha512Toggle = GameObject.Find("sha512Toggle").GetComponent<Toggle>();
        allToggle = GameObject.Find("allToggle").GetComponent<Toggle>();
        md5Lbl = GameObject.Find("md5Label").GetComponent<TMP_Text>();
        sha1Lbl = GameObject.Find("sha1Label").GetComponent<TMP_Text>();
        sha256Lbl = GameObject.Find("sha256Label").GetComponent<TMP_Text>();
        sha512Lbl = GameObject.Find("sha512Label").GetComponent<TMP_Text>();
        filePrint = GameObject.Find("fileNamePrint").GetComponent<TMP_Text>();
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
        allToggle.onValueChanged.AddListener(delegate{
            allChanged(allToggle);
        });
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
        md5Toggle.isOn = true;
        sha1Toggle.isOn = true;
        sha256Toggle.isOn = true;
        sha512Toggle.isOn = true;
    }
    void allOff(){
        md5Toggle.isOn = false;
        sha1Toggle.isOn = false;
        sha256Toggle.isOn = false;
        sha512Toggle.isOn = false;
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
    public static void printFile(){
        string[] fileInfo = PlayerPrefsX.GetStringArray("chosenHashFile");
        filePrint.text = fileInfo[0];
        filePrint.color = new Color32(0,0,0,255);
        filePrint.fontStyle = FontStyles.Normal;
    }
    #region hasingFunctions
    public void startHash(){
        fileArray = PlayerPrefsX.GetStringArray("chosenHashFile");
        if(md5Toggle.isOn){
            md5OutputField.GetComponent<TMP_InputField>().text = md5Hash(fileArray[0]);
        }
        else{
            md5OutputField.GetComponent<TMP_InputField>().text = "";
        }
        if(sha1Toggle.isOn){
            sha1OutputField.GetComponent<TMP_InputField>().text = sha1Hash(fileArray[0]);
        }
        else{
            sha1OutputField.GetComponent<TMP_InputField>().text = "";
        }
        if(sha256Toggle.isOn){
            sha256OutputField.GetComponent<TMP_InputField>().text = sha256Hash(fileArray[0]);
        }
        else{
            sha256OutputField.GetComponent<TMP_InputField>().text = "";
        }
        if(sha512Toggle.isOn){
            sha512OutputField.GetComponent<TMP_InputField>().text = sha512Hash(fileArray[0]);
        }
        else{
            sha512OutputField.GetComponent<TMP_InputField>().text = "";
        }
    }
    string md5Hash(string inputFile){
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()){
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(inputFile));
            var sb = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash){
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
    string sha1Hash(string inputFile){
        using (SHA1Managed sha1 = new SHA1Managed()){
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(inputFile));
            var sb = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash){
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
    string sha256Hash(string inputFile){
        using (SHA256Managed sha256 = new SHA256Managed()){
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputFile));
            var sb = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash){
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
    string sha512Hash(string inputFile){
        using (SHA512Managed sha512 = new SHA512Managed()){
            var hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(inputFile));
            var sb = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash){
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
    #endregion
}
