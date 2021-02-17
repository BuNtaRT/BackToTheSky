using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_moved : MonoBehaviour
{
    public int hard = 0;
    public Transform deatZoneLeft, deatZoneRight;

    void Start()
    {
        Debug.Log("start wall mov hard = " + hard);
        if (hard == 0)
        {

        }
        else if (hard == 1)
        {
            Debug.Log("hard 1 ");
            Transform wall;
            float Xmove = 0.001f;
            if (Random.Range(0, 2) == 0)
            {
                wall = gameObject.transform.Find("site_left").transform;
                Xmove = -1.5f;
                deatZoneLeft.gameObject.SetActive(true);
            }
            else
            {
                wall = gameObject.transform.Find("site_right").transform;
                Xmove = 1.5f;
                deatZoneRight.gameObject.SetActive(true);

            }
            StartCoroutine(Move(wall, Xmove, 0));
        }
        else if (hard == 2)
        {

            Transform wall = gameObject.transform.Find("site_left").transform;
            float Xmove = 0;
            Xmove = -1.5f;
            deatZoneLeft.gameObject.SetActive(true);

            StartCoroutine(Move(wall, Xmove, 0));


            wall = wall = gameObject.transform.Find("site_right").transform;
            Xmove = 1.5f;
            deatZoneRight.gameObject.SetActive(true);

            StartCoroutine(Move(wall, Xmove, 0));

        }
        else if (hard == 3) {
            Transform wall = gameObject.transform.Find("site_left").transform;
            float Xmove = 0;
            Xmove = -1.5f;
            deatZoneLeft.gameObject.SetActive(true);
            deatZoneRight.gameObject.SetActive(true);

            StartCoroutine(Move(wall, Xmove, 2));


            wall = wall = gameObject.transform.Find("site_right").transform;
            Xmove = 1.5f;
            StartCoroutine(Move(wall, Xmove, 2));

        }

    }


    IEnumerator Move(Transform wall,float move,float wait) {

        yield return new WaitForSeconds(Random.Range(0, wait));
        float prewTransf = wall.transform.localPosition.x;
        while (true) {

            var timeStep = 0.0f;

            while (timeStep < 1.0f)
            {
                timeStep += Time.deltaTime * 1f;
                wall.transform.localPosition = Vector3.Lerp(wall.localPosition, new Vector3(move,wall.localPosition.y,0), timeStep);
                yield return null;
            }


            timeStep = 0.0f;
            while (timeStep < 1.0f)
            {
                timeStep += Time.deltaTime * 1f;
                wall.transform.localPosition = Vector3.Lerp(wall.localPosition, new Vector3(prewTransf, wall.localPosition.y, 0), timeStep);
                yield return null;
            }

        }
    }
}
