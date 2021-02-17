using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Deat : MonoBehaviour
{
    float PlayerMax;
    public controll script;
    public GameObject Deat_screen;
    public GameObject score;
    GameObject Player;
    public GameObject leftTrack, rightTrak;
    public Text continueText;

    int sh = 0;

    bool once = false;
    public GameObject respButton;

    public Text RecordNow,Record;

    // Start is called before the first frame update
    void Start()
    {
        Player =  GameObject.Find("Pers");
        if (Advertisement.isSupported && !Advertisement.isInitialized) {
            Advertisement.Initialize("3719057", false);
        }
    }

    public void deat(float PlayerM) {
        if (!once)
        {

            if (sh >= 2) {

                respButton.SetActive(false);
            }

            once = true;

            if (PlayerPrefs.GetInt("Record") < (int)PlayerM) {
                PlayerPrefs.SetInt("Record", (int)PlayerM);
                PlayerPrefs.Save();
                RecordNow.color = new Color(244, 81, 30);
            }
            if (PlayerPrefs.GetInt("lg") == 0)
            {
                Record.text = "Highscore : " + PlayerPrefs.GetInt("Record").ToString();
                RecordNow.text = "Result : " + (int)PlayerM;
                continueText.text = "+1 Сontinue";
            }
            else
            {
                Record.text = "Лучший счет : " + PlayerPrefs.GetInt("Record").ToString();
                RecordNow.text = "Результат : " + (int)PlayerM;
                continueText.text = "+1 Продолжить";

            }

            Player.GetComponent<Rigidbody>().isKinematic = true;
            Player.GetComponent<Rigidbody>().isKinematic = false;
            Player.GetComponent<pers_maneger>().enabled = false;
            Player.GetComponent<BoxCollider>().isTrigger = true;
            script.enabled = false;
            leftTrack.SetActive(false);
            rightTrak.SetActive(false);


            Deat_screen.SetActive(true);
            PlayerMax = PlayerM;
            score.SetActive(false);
        }
    }

    public void Respawn() {

        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo");


            Player.GetComponent<pers_maneger>().invulnerability = true;
            once = false;
            GameObject.Find("Main Camera").GetComponent<controll>().deat = false;
            score.SetActive(true);
            leftTrack.SetActive(true);
            rightTrak.SetActive(true);
            GameObject temp = Resources.Load<GameObject>("prefab/RecoverPlatform");
            Instantiate(temp, new Vector3(0, PlayerMax, 0), new Quaternion());
            GameObject pers = GameObject.Find("Pers");
            pers.GetComponent<Rigidbody>().isKinematic = true;
            pers.transform.position = new Vector2(0, PlayerMax + 1.5f);
            pers.GetComponent<pers_maneger>().enabled = true;
            pers.GetComponent<BoxCollider>().isTrigger = false;
            Deat_screen.SetActive(false);
            script.enabled = true;
            pers.GetComponent<Rigidbody>().isKinematic = false;
            script.DoubleJump = true;
            sh++;
        }
    }
    public void end() {

        if (PlayerPrefs.GetInt("NoAdd") != 3)
        {
            if (PlayerPrefs.GetInt("DieAD") >= 3)
            {

                if (Advertisement.IsReady())
                {
                    Advertisement.Show("video");
                    PlayerPrefs.SetInt("DieAD", 0);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                PlayerPrefs.SetInt("DieAD", PlayerPrefs.GetInt("DieAD") + 1);
                PlayerPrefs.Save();
            }
        }

        GameObject.Find("scipts").GetComponent<coinManger>().EndGame((int)PlayerMax);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
