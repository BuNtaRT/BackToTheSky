using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisWall : MonoBehaviour
{

    Color32 wallColor;
    float hard;
    public IEnumerator InvisStart(float Hard)
    {
        hard = Hard;
        wallColor = gameObject.GetComponent<Renderer>().material.color;
        BoxCollider BoxCol = gameObject.GetComponent<BoxCollider>();
        MeshRenderer MeshRen = gameObject.GetComponent<MeshRenderer>();
        string Mtag = gameObject.tag;

        while (true)
        {
            BoxCollider deatZone2 = gameObject.transform.Find("deatZone2").GetComponent<BoxCollider>();
            StartCoroutine(LerpColorWall());
            yield return new WaitForSeconds(1.8f - hard * 2);
            StartCoroutine(LerpColorWall());
            yield return new WaitForSeconds(1.8f - hard * 2);
            StartCoroutine(LerpColorWall());
            yield return new WaitForSeconds(0.8f - hard);
            
            if (gameObject.transform.childCount > 0)
            {
                foreach (Transform tr in gameObject.transform)
                {
                    if (tr.tag == "sled")
                    {
                        Destroy(tr.gameObject);
                    }
                    else if (tr.tag == "Player") {
                        tr.gameObject.GetComponent<pers_maneger>().Godeat();
                    }
                }
            }
            MeshRen.enabled = false;
            BoxCol.enabled = false;
            deatZone2.enabled = false;
            yield return new WaitForSeconds(3f + hard * 2);
            MeshRen.enabled = true;
            BoxCol.enabled = true;
            deatZone2.enabled = true;

            yield return new WaitForSeconds(2f - hard);



        }
    }



    IEnumerator LerpColorWall()
    {

        var timeStep = 0.0f;
        while (timeStep < 1.0f)
        {
            timeStep += Time.deltaTime / 0.8f - hard;
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(wallColor, new Color32(wallColor.r, wallColor.g, wallColor.b, 20), timeStep);
            yield return null;
        }
        timeStep = 0.0f;
        while (timeStep < 1.0f)
        {
            timeStep += Time.deltaTime / 0.8f - hard;
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(new Color32(wallColor.r, wallColor.g, wallColor.b, 20), wallColor, timeStep);
            yield return null;
        }

    }
}
