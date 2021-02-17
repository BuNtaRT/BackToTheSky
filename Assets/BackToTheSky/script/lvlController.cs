using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlController : MonoBehaviour
{
    public ParticleSystem list, cloud, star, hz;
    int I = 110; 
    controll control;
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Main Camera").GetComponent<controll>();
        control.NextLvl = I;
        //GameObject.Find("Main Camera/MainMusic").GetComponent<MusicManeger>().NextLvlSound(2);
        cloud.Stop();
        star.Stop();
        list.Play();
    }

   
    public void NewLvl() {
        Debug.Log("NextLvl");
        if (I <= 110) {
            GameObject.Find("Main Camera/MainMusic").GetComponent<MusicManeger>().NextLvlSound(2);
            list.Stop();
            cloud.Play();
            I += 200;
            control.NextLvl = I;
            
        }
        else if (I <= 310) {
            cloud.Stop();
            star.Play();
            GameObject.Find("Main Camera/MainMusic").GetComponent<MusicManeger>().NextLvlSound(3);
            I += 150;
            control.NextLvl = I;

        }
        else if (I <= 460) {
            control.NextLvl = I + 100000000;

            star.Stop();
            hz.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
