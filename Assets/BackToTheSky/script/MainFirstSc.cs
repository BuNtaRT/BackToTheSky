using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainFirstSc : MonoBehaviour
{
    public GameObject defBg;
    void Start()
    {
        if (PlayerPrefs.GetInt("FirstLoad") == 1) {
            SceneManager.LoadScene(1);
            defBg.SetActive(true);
            PlayerPrefs.SetInt("OpenApp",0);
        }
    }

    public void SetLang(int l) {

        PlayerPrefs.SetInt("lg", l);
        PlayerPrefs.SetInt("materialID",0);
        PlayerPrefs.SetInt("StikID", -1);
        PlayerPrefs.SetInt("TrailID", 0);
        PlayerPrefs.SetInt("SoundID", 0);
        PlayerPrefs.SetInt("OpenApp", 0);
        PlayerPrefs.SetInt("coin", 0);
        //PlayerPrefs.SetInt("coin", 20000);
        PlayerPrefs.SetInt("FirstLoad", 1);
        PlayerPrefs.SetFloat("Music",0.6f);
        PlayerPrefs.SetFloat("AudioEff", 0.5f);
        PlayerPrefs.SetInt("MedidativeMod", 0);

        PlayerPrefs.Save();
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
