using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class NoAdd : MonoBehaviour
{
    public GameObject windowNoAdd;
    public GameObject ButtonNoAdd;

    public void CompliteBuy(Product product)
    {
        if (product.definition.id == "noadd_1500coins")
        {
            PlayerPrefs.SetInt("NoAdd", 3);
            PlayerPrefs.Save();
            gameObject.GetComponent<coinManger>().Get1500();
        }
    }
    


    public void OnPurchaseFail(Product product, PurchaseFailureReason purchase )
    {
        Debug.Log("Not Buy");
    }

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("NoAdd") == 3)
        {
            ButtonNoAdd.SetActive(false);
        }
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }
}
