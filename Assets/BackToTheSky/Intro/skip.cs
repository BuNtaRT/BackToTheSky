using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class skip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("lg") == 0)
        {
            gameObject.transform.Find("Text").GetComponent<Text>().text = "Skip";
        }
        else {
            gameObject.transform.Find("Text").GetComponent<Text>().text = "Пропустить";

        }
    }

    public void skipScene() {
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
