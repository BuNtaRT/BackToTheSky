using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Del_recover_platform : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

}
