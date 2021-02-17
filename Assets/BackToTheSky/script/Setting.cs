using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Text Music, audio, checkbox, descr;
    public Slider MusicS, AudioS;
    public AudioSource LeftS, RightS, MainS, DemonstrS;
    public Toggle MedModChek;

    void Start()
    {
        if (PlayerPrefs.GetInt("MedidativeMod") == 0)
        {
            MedModChek.isOn = false;
        }
        else
        {
            MedModChek.isOn = true;
        }
        LeftS.volume = PlayerPrefs.GetFloat("AudioEff");
        RightS.volume = PlayerPrefs.GetFloat("AudioEff");
        DemonstrS.volume = PlayerPrefs.GetFloat("AudioEff");
        MainS.volume = PlayerPrefs.GetFloat("Music");

        MusicS.value = PlayerPrefs.GetFloat("Music");
        AudioS.value = PlayerPrefs.GetFloat("AudioEff");

        if (PlayerPrefs.GetInt("lg") == 0) {
            Music.text = "Music";
            audio.text = "Sounds";
            checkbox.text = "Meditative mode";
            descr.text = "*In meditation mode, only peaks of the wall are present as obstacles";
        }
        else {
            Music.text = "Музыка";
            audio.text = "Звуки";
            checkbox.text = "Медитативный режим";
            descr.text = "*В медитативном режиме присутствуют только настенные шипы в качестве препятствий";
        }

    }

    public void MedMod(bool ck) {
        if (ck)
        {
            PlayerPrefs.SetInt("MedidativeMod", 1);
        }
        else {
            PlayerPrefs.SetInt("MedidativeMod", 0);
        }
        PlayerPrefs.Save();

    }



    public void MusicSlider(float value)
    {
        PlayerPrefs.SetFloat("Music", value);
        MainS.volume = value;
        PlayerPrefs.Save();
    }

    public void AudioSlider(float value)
    {
        PlayerPrefs.SetFloat("AudioEff", value);
        LeftS.volume = value;
        RightS.volume = value;
        DemonstrS.volume = value;
        PlayerPrefs.Save();

    }

}
