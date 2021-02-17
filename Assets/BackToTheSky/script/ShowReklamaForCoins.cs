using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ShowReklamaForCoins : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Advertisement.isSupported && !Advertisement.isInitialized)
        {
            Advertisement.Initialize("3719057", false);
        }
    }

    public void Show() {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo");
            gameObject.GetComponent<coinManger>().Reklama();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
