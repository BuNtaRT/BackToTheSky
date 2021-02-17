using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinManger : MonoBehaviour
{
    public GameObject CoinLabel;
    int finalP = 0;

    private void Start()
    {
        //PlayerPrefs.SetInt("coin", 10000);
        //PlayerPrefs.Save();

        finalP = PlayerPrefs.GetInt("coin");

        Set();
    }

    public void BuyItem(int price) {
        finalP = finalP - price;
        Set();

    }

    public void EndGame(int score) {
        if (PlayerPrefs.GetInt("MedidativeMod") == 0)
        {
            finalP = finalP + (int)(score / 0.35f);
        }
        else
        {
            finalP = finalP + (int)(score / 0.10f);
        }
        PlayerPrefs.Save();
        Set();
    }

    public void Get1500() {
        finalP = finalP + 1500;
        Set();
    }

    public void Reklama() {
        finalP = finalP + 150;
        Set();
    }

    void Set(){
        CoinLabel.GetComponent<Text>().text = finalP.ToString();
        PlayerPrefs.SetInt("coin",finalP);
        PlayerPrefs.Save();
    }

}
