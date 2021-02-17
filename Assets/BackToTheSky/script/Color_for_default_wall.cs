using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_for_default_wall : MonoBehaviour
{
    Color32[] color_wall = { new Color32(216,67,21,255), new Color32(239,108,0,255),
                            new Color32(255,143,0,255), new Color32(249,168,37,255), new Color32(158,157,36,255), new Color32(85,139,47,255),
                            new Color32(46,125,50,255), new Color32(0,105,92,255) , new Color32(0,131,143,255), new Color32(2,119,189,255), new Color32(21,101,192,255),
                            new Color32(40,53,147,255), new Color32(69,39,160,255), new Color32(106,27,154,255), new Color32(173,20,87,255), new Color32(78,52,46,255) };
    // Start is called before the first frame update
    void Start()
    {
        int collor = Random.Range(0, 15);
        gameObject.transform.Find("site_left").GetComponent<Renderer>().material.color = color_wall[collor];
        gameObject.transform.Find("site_right").GetComponent<Renderer>().material.color = color_wall[collor];
    }

}
