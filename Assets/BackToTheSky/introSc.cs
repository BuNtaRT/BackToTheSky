using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introSc : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(continueScene());
    }

    IEnumerator continueScene(){
        yield return new WaitForSecondsRealtime(50.5f);
        SceneManager.LoadScene(1);
    }
}
