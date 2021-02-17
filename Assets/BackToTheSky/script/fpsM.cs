using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpsM : MonoBehaviour
{
    public int i = 0;
    public float fraimrate = 0;
    public Text text;


    private void Start()
    {
        Application.targetFrameRate = 300;
    }
    // Update is called once per frame
    void Update()
    {
        float fps = 1.0f / Time.deltaTime;
        fraimrate = fraimrate + fps;
        i++;
        text.text = "FPS(" + (int)fps + ") SredFps(" + (int)fraimrate / i + ")";
    }

    void OnGUI()
    {
        float fps = 1.0f / Time.deltaTime;
        
        //ILayout.Label("FPS = " + fps);
        
        //GUILayout.Label("SredneeFPS = " + fraimrate / i);

    }
}
