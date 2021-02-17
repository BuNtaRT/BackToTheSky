using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorAll : MonoBehaviour
{

    Color32[] ColorPers = {
        new Color32(230,74,25,255),
        new Color32(245,124,0,255),
        new Color32(255,160,0,255),
        new Color32(251,192,45,255),
        new Color32(175,180,43,255),
        new Color32(104,159,56,255),
        new Color32(56,142,60,255),
        new Color32(0,121,107,255),
        new Color32(0,151,167,255),
        new Color32(2,136,209,255),
        new Color32(25,118,210,255),
        new Color32(48,63,159,255),
        new Color32(81,45,168,255),
        new Color32(123,31,162,255),
        new Color32(194,24,91,255),
        new Color32(211,47,47,255),
        new Color32(230,74,25,255),
    };

    int index = 1;

    IEnumerator LerpPers()
    {

        var timeStep = 0.0f;    
        while (timeStep < 1.0f)
        {
            timeStep += Time.deltaTime / 5;
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(ColorPers[index-1], ColorPers[index], timeStep);
            yield return null;
        }

    }


    void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        index = 1;
        StartCoroutine(LerpPersControll());
    }

    IEnumerator LerpPersControll() {
        while (true)
        {
            StartCoroutine(LerpPers());
            yield return new WaitForSeconds(5f);
            if (ColorPers.Length-1 <= index)
            {
                index = 1;
            }
            else {
                index++;
            }
        }
    }
}
