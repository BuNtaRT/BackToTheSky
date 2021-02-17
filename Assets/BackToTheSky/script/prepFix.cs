using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prepFix : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ship") {
            Destroy(other.gameObject);
        }
    }
}
