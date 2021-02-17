using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixFuckingBye : MonoBehaviour
{

    public GameObject windowNoAdd;
    public GameObject ButtonNoAdd;
    public GameObject MagazinB, startB;
    public Button rewVideio, settingB;

    void Start()
    {
        ButtonNoAdd.SetActive(false);
        windowNoAdd.SetActive(false);
        MagazinB.SetActive(true);
        startB.SetActive(true);
        rewVideio.enabled = true;
        settingB.enabled = true;
    }

}
