using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text Rewer, Add, Setting, Play, Market;



    void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 1)
        {
            gameObject.SetActive(false);
        }
        else {

            StartCoroutine(Tutor());
            SetLang();
        }
    }

    void SetLang() {
        if (PlayerPrefs.GetInt("lg") == 0)
        {
            Rewer.text = "Reward Videos ->";
            Add.text = "Disable ads ->";
            Setting.text = "Select another mode->";
            Play.text = "Touch here to start the game";
            Market.text = "Touch here to open a store";
        }
        else {
            Rewer.text = "Видео за вознаграждение ->";
            Add.text = "Отключи рекламу ->";
            Setting.text = "Выбери другой режим ->";
            Play.text = "Нажми тут что бы начать игру";
            Market.text = "Нажми тут что бы открыть магазин";
        }
        PlayerPrefs.SetInt("Tutorial", 1);
        PlayerPrefs.Save();
    }

    IEnumerator Tutor() {
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<Button>().enabled = true;
    }
}
