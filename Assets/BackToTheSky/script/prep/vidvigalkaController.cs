using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class vidvigalkaController : MonoBehaviour
{

    Coroutine Move, back;
    public bool left = true;
    float sdw = 0f;
    float myX = 0;
    private void Start()
    {
        myX = transform.localPosition.x;
    }
    private void OnDestroy()
    {
        StopCoroutine(back);
        StopCoroutine(Move);
    }

    public IEnumerator StartAn() {
        while (true)
        {
            if (left)
            {
                sdw = 6f;
            }
            else {
                sdw = -6f;
            }

            Move = StartCoroutine(Lm());
            yield return new WaitForSeconds(1.8f);
            back =  StartCoroutine(Ln());
            yield return new WaitForSeconds(1.8f);

        }
    }

    IEnumerator Lm() {
        var timeStep = 0.0f;
        while (timeStep < 1.0f)
        {
            timeStep += Time.deltaTime / 2.5f;
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(sdw,transform.localPosition.y),timeStep);
            yield return null;
        }
    }
    IEnumerator Ln()
    {
        var timeStep = 0.0f;
        while (timeStep < 1.0f)
        {
            timeStep += Time.deltaTime / 2.5f;
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(myX, transform.localPosition.y), timeStep);
            yield return null;
        }
    }
}
