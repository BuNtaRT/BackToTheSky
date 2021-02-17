using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManeger : MonoBehaviour
{
    AudioSource music;
    AudioClip NextAudio;
    float pitch= 1f;
    int ChoiseLvl = 1;

    int lvl1Sound = 5;
    int lvl2sound = 6;
    int lvl3sound = 4;

    AudioClip m1;

    void Start()
    {
        music = gameObject.GetComponent<AudioSource>(); //GameObject.Find("Main Camera/MainMusic").GetComponent<AudioSource>();
        music.clip = Resources.Load<AudioClip>("music/1/" + Random.Range(0, lvl1Sound));
        music.Play();
        StartCoroutine(PLayMusic());
    }


    public void NextLvlSound(int lvl) {
        Debug.Log("next lvl " + lvl);
        StopAllCoroutines();
        ChoiseLvl = lvl;
        if (lvl == 1)
        {
            do
            {
                NextAudio = Resources.Load<AudioClip>("music/" + lvl + "/" + Random.Range(0, lvl1Sound));
            } while (music.clip.name == NextAudio.name);
            pitch = 1f;
            StartCoroutine(Switch());
        }
        else if (lvl == 2) {
            do {
                NextAudio = Resources.Load<AudioClip>("music/" + lvl + "/" + Random.Range(0, lvl2sound));
            } while (music.clip.name == NextAudio.name);
            pitch = 1.25f;
            StartCoroutine(Switch());
        }
        else if (lvl == 3)
        {
            do
            {
                NextAudio = Resources.Load<AudioClip>("music/" + lvl + "/" + Random.Range(0, lvl3sound));
            } while (music.clip.name == NextAudio.name);

        pitch = 1.3f;
            StartCoroutine(Switch());
        }


    }

    private IEnumerator Switch() {
        Debug.Log("switch");
        while (music.volume>=0.06) {
            music.volume -= 0.05f;
            yield return new WaitForSeconds(0.15f);
        }
        music.pitch = pitch;
        music.clip = NextAudio;
        music.Play();

        while (music.volume <= 0.4)
        {
            music.volume += 0.05f;
            yield return new WaitForSeconds(0.15f);
        }
        StartCoroutine(PLayMusic());
    }

    IEnumerator PLayMusic() {


        float timeM = music.clip.length;
        Debug.Log("Time m = " + timeM);

        yield return new WaitForSecondsRealtime(timeM - 4);

        Debug.Log("play music call ");


        NextLvlSound(ChoiseLvl);
    }

    void Update()
    {
        
    }
}
