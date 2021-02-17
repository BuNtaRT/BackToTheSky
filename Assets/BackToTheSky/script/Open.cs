using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public GameObject camera;
    public GameObject LogoIU;
    public GameObject MainUI;
    public bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteKey("OpenApp");
        if (PlayerPrefs.GetInt("OpenApp") == 1)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, 15f, -11f);
            MainUI.SetActive(true);
            LogoIU.SetActive(false);
        }

    }

    private void StartManegerLogo()
    {
        start = false;

        PlayerPrefs.SetInt("OpenApp", 1);
        PlayerPrefs.Save();
        StartCoroutine(DisableLogo());
    }

    private void Update()
    {
        if (start) {
            StartManegerLogo();
        }
    }
    IEnumerator DisableLogo() {
        yield return new WaitForSecondsRealtime(1.5f);
        MainUI.SetActive(true);
        LogoIU.SetActive(false);
    }
}
