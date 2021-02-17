using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class pers_maneger : MonoBehaviour
{
    string tag_boreder = "";
    controll controlSc;
    public Transform LeftT, RightT;
    Transform BordeNow;
    Transform truckLeft, truckRight;
    public GameObject sledSp;
    Material persColor;
    bool allColor = false;

    bool audio = false;
    public AudioSource left, right;

    public GameObject Stick,Trail;

    Transform sled;

    bool goSled = false;
    public bool invulnerability = false;
    MaterialColorAll MaterialColorall;


    private void Awake()
    {
        MaterialColorall = gameObject.transform.Find("PersCinem").GetComponent<MaterialColorAll>();
        MaterialColorall.enabled = false;
    }

    public void Start()
    {

        //PlayerPrefs.SetInt("materialID", 0);
        //PlayerPrefs.SetInt("StikID", 0);
        //PlayerPrefs.SetInt("TrailID", 0);
        //PlayerPrefs.SetInt("",);
        gameObject.transform.Find("PersCinem").GetComponent<Renderer>().material = Resources.Load<Material>("prefab/Skin/material/"+PlayerPrefs.GetInt("materialID"));
        if (PlayerPrefs.GetInt("materialID") >= 16)
        {
            MaterialColorall.enabled = true;
        }
        else {
            MaterialColorall.enabled = false;

        }

        if (PlayerPrefs.GetInt("StikID") >= 0)
        {
            Stick.SetActive(true);
            Stick.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/skinSp/" + PlayerPrefs.GetInt("StikID"));
            if (PlayerPrefs.GetInt("StikID") >= 26)
            {
                Stick.GetComponent<Animation>().enabled = true;
                Stick.GetComponent<Animation>().Play("PersScinRot");
            }
        }

        if (PlayerPrefs.GetInt("TrailID") >= 0) {
            Trail.SetActive(true);
            Trail.GetComponent<TrailRenderer>().enabled = false;
            Trail.GetComponent<TrailRenderer>().colorGradient = Resources.Load<GameObject>("TrailRender/"+PlayerPrefs.GetInt("TrailID")).GetComponent<TrailRenderer>().colorGradient;
            Trail.GetComponent<TrailRenderer>().enabled = true;
        }

        if (PlayerPrefs.GetInt("SoundID") >= 0) {
            GameObject.Find("Main Camera/rightS").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("sound/JUmp/" + PlayerPrefs.GetInt("SoundID"));
            GameObject.Find("Main Camera/leftS").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("sound/JUmp/" + PlayerPrefs.GetInt("SoundID"));
        }

        persColor = gameObject.transform.Find("PersCinem").GetComponent<Renderer>().material;
        truckLeft = GameObject.Find("truckLeft").transform;
        truckRight = GameObject.Find("truckRight").transform;
        controlSc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<controll>();
    }



    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "borderLEFT")
        {
            gameObject.GetComponent<Animation>().Play("PersLeft");
            sled = truckLeft;
            BordeNow = collision.gameObject.transform;
            gameObject.transform.SetParent(collision.gameObject.transform);
        }
        else if (collision.gameObject.tag == "borderRIGHT")
        {

            gameObject.GetComponent<Animation>().Play("persRight");
            sled = truckRight;
            BordeNow = collision.gameObject.transform;
            gameObject.transform.SetParent(collision.gameObject.transform);

        }
        else
        {
            // gameObject.GetComponent<Animation>().Play("Jump");

        }

        

        if (tag_boreder != collision.gameObject.tag)
        {
            if (tag_boreder == "borderRIGHT")
            {
                left.Play();
                SledNow();
            }
            if (tag_boreder == "borderLEFT")
            {
                right.Play();
                SledNow();

            }

            if (collision.gameObject.tag != "Respawn")
            {
                controlSc.DoubleJump = true;
            }


            gameObject.GetComponent<Rigidbody>().isKinematic = true;

            tag_boreder = collision.gameObject.tag;
        }
    }


    void SledNow() {
        if (gameObject.GetComponent<Rigidbody>().isKinematic && tag_boreder != "" && tag_boreder != "Respawn")
        {
            GameObject temp = Instantiate(sledSp, sled);
            float sledScale = Random.Range(0.4f, 1.1f);
            temp.transform.localScale = new Vector3(sledScale, sledScale, 0);
            temp.transform.localEulerAngles = new Vector3(0, -90, Random.Range(0, 360));
            temp.GetComponent<SpriteRenderer>().color = new Color(persColor.color.r, persColor.color.g, persColor.color.b, Random.Range(0.4f, 1));
            temp.transform.SetParent(BordeNow);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "ship" && !invulnerability)
        {
            Godeat();
        }
    }
    public void Godeat() {
        goSled = false;
        GameObject.Find("scipts").GetComponent<Deat>().deat(transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().isKinematic && tag_boreder != "" && tag_boreder != "Respawn")
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.02f);
            goSled = true;

        }
        else {
            goSled = false;
            gameObject.transform.SetParent(null);
        }
    }


    private void FixedUpdate()
    {

        if (goSled) {
            GameObject temp = Instantiate(sledSp,sled);
            float sledScale = Random.Range(0.4f, 1.1f);
            temp.transform.localScale = new Vector3(sledScale, sledScale,0);
            temp.transform.localEulerAngles = new Vector3(0,-90,Random.Range(0,360));
            temp.GetComponent<SpriteRenderer>().color = new Color(persColor.color.r,persColor.color.g,persColor.color.b,Random.Range(0.4f,1));
            temp.transform.SetParent(BordeNow);
            
        }
    }
}
