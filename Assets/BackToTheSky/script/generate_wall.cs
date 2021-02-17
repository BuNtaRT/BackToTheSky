using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_wall : MonoBehaviour
{
    public GameObject wall;
    List<GameObject> WallObj = new List<GameObject>();
    float Ywall;
    public GameObject ship;
    public GameObject Vidvigalka;
    public GameObject ShipPanel;


    Color32[] color_wall = { new Color32(216,67,21,255), new Color32(239,108,0,255),
                            new Color32(255,143,0,255), new Color32(249,168,37,255), new Color32(158,157,36,255), new Color32(85,139,47,255),
                            new Color32(46,125,50,255), new Color32(0,105,92,255) , new Color32(0,131,143,255), new Color32(2,119,189,255), new Color32(21,101,192,255),
                            new Color32(40,53,147,255), new Color32(69,39,160,255), new Color32(106,27,154,255), new Color32(173,20,87,255), new Color32(78,52,46,255) };

    // Start is called before the first frame update
    void Start()
    {

        //generate(-10f);
        //generate(0f);
        //generate(10f);

        WallObj.Insert(0, GameObject.Find("borderFix"));
        WallObj.Insert(0, GameObject.Find("borderStart"));
        WallObj.Insert(0, GameObject.Find("border_next"));
        WallObj.Insert(0, GameObject.Find("Next_next"));


        //CreatWallShip();

        Ywall = 20;

    }

    public void GoGenerateWall() {
        Destroy(WallObj[3]);
        WallObj.RemoveAt(3);

        Ywall += 10;
        generate(Ywall);
    }

    private void generate(float Yp) {





        GameObject temp = Instantiate(wall, new Vector3(0, Yp, 0), new Quaternion());
        WallObj.Insert(0, temp);



        int collor = Random.Range(0, 15);
        WallObj[0].transform.Find("site_left").GetComponent<Renderer>().material.color = color_wall[collor];
        WallObj[0].transform.Find("site_right").GetComponent<Renderer>().material.color = color_wall[collor];
        if ((Yp > 20 && Yp <= 180) && Random.Range(0, 10) >= 4)               /// 5
        {
            creat_hard(1);
        } else if ((Yp >= 181 && Yp <= 310) && Random.Range(0, 10) >= 3)
        {
            creat_hard(2);
        }
        else if ((Yp >= 311 && Yp <= 460) && Random.Range(0, 10) >= 2)
        {
            creat_hard(3);
        }
        else if (Yp >= 461 && Random.Range(0, 9) >= 1)
        {
            creat_hard(4);
        }


    }


    void creat_hard(int LvlHard) {

        if (PlayerPrefs.GetInt("MedidativeMod") == 0)
        {
        if (LvlHard == 1)
        {
            int Rand = Random.Range(0, 3);
            if (Rand == 0)
            {
                GoSpawnShip();
            }
            else if (Rand == 1)
            {
                GoMoveWall(1);
            }
            else
            {
                wall_invis(0f);
            }
        }
        else if (LvlHard == 2)
        {
            int Rand = Random.Range(0, 3);

            if (Rand == 0)
            {
                GoCreateShipPanel();
                GoMoveWall(1);
            }
            else if (Rand == 1)
            {
                GoMoveWall(3);
                GoSpawnShip();
            }
            else
            {
                wall_invis(0.1f);
                
            }

            }
        else if (LvlHard == 3) {
            int Rand = Random.Range(0, 5);

            if (Rand == 0) {
                GoSpawnShip();
                GoMoveWall(3);
            }
            else if (Rand == 1) {
                GoCreateShipPanel();
                GoCreateVidvigalka();
            }
            else if (Rand == 2)
            {
                wall_invis(0.15f);
                GoCreateShipPanel();
            }
            else if (Rand == 3)
            {
                GoMoveWall(3);
            }
            else
            {
                GoCreateShipPanel();
                GoMoveWall(1);
                GoCreateVidvigalka();
            }
        }
        else 
        {
            int Rand = Random.Range(0, 5);

            if (Rand == 0)
            {
                wall_invis(0.15f);
                GoCreateVidvigalka();
                GoMoveWall(2);
            }
            else if (Rand == 1)
            {
                GoCreateShipPanel();
                GoCreateVidvigalka();
                GoCreateVidvigalka();
            }
            else if (Rand == 2)
            {
                GoMoveWall(3);
                GoCreateVidvigalka();
                GoCreateVidvigalka();
            }
            else if (Rand == 3)
            {
                GoCreateShipPanel();
                GoCreateVidvigalka();
                GoSpawnShip();

            }
            else
            {
                GoCreateVidvigalka();
                GoCreateVidvigalka();
                wall_invis(0f);
            }
        }
        }
        else
        {
            GoSpawnShip();
        }

       


        //GoMoveWall(1);
        //GoCreateShipPanel();
        //GoCreateVidvigalka();
        //GoSpawnShip();
        //wall_invis(0f);


    }
    void wall_invis(float hard)
    {

        string wallName = "";
        if (Random.Range(0, 2) >= 1)
        {
            wallName = "site_right";
        }
        else
        {
            wallName = "site_left";

        }

        Transform wall = WallObj[0].transform.Find(wallName).transform;
        StartCoroutine(wall.GetComponent<InvisWall>().InvisStart(hard));

    }

    public void GoCreateShipPanel() {

        int RandomWall = Random.Range(0, 4);
        if (RandomWall <= 1)
        {

            ShipPanelSpawn("site_left");
        }
        else if (RandomWall >= 2)
        {
            ShipPanelSpawn("site_right");
        }
    }

    void ShipPanelSpawn(string name) {
        float posX = 1f;
        float rot = 180;

        if (name.Contains("right"))
        {
            posX = -1f;
            rot = 0;
        }
        Transform wall = WallObj[0].transform.Find(name).transform;
        GameObject temp = Instantiate(ShipPanel);
        float RandomY = Random.Range(-4.5f, 4.5f);
        temp.transform.position = new Vector3(0f, wall.transform.position.y + RandomY);
        temp.transform.eulerAngles = new Vector2(temp.transform.eulerAngles.x, rot);
        temp.transform.localScale = new Vector3(2f, 0.25f, 0.8f);
        temp.transform.SetParent(wall);
        temp.transform.localPosition = new Vector2(posX, temp.transform.localPosition.y);

    }

    void GoMoveWall(int hard) {
        WallObj[0].GetComponent<wall_moved>().hard = hard;
    }

    void GoCreateVidvigalka() {

        if (Ywall >= 150)
        {
            vidvigalkaSpawn("site_right");
            vidvigalkaSpawn("site_left");

        }
        else {
            int RandomWall = Random.Range(0, 5);
            if (RandomWall <= 2)
            {

                vidvigalkaSpawn("site_left");
            }
            else if (RandomWall >= 3)
            {
                vidvigalkaSpawn("site_right");

            }
        }
    }                       // выбираем на кукую стену или стены спавнить выдвижные плиты 

    void vidvigalkaSpawn(string nameWall) {
        float posX = -0.35f;
        bool leftVidvSc = true;

        if (nameWall.Contains("right"))
        {
            posX = 0.35f;
            leftVidvSc = false;
        }
        Transform wall = WallObj[0].transform.Find(nameWall).transform;
        GameObject temp = Instantiate(Vidvigalka);
        float RandomY = Random.Range(-5f, 5f);
        temp.transform.position = new Vector3(0f, wall.transform.position.y + RandomY);
        temp.transform.localScale = new Vector3(1.2f, 1.2f, 0.5f);
        temp.transform.SetParent(wall);
        temp.transform.localPosition = new Vector2(posX, temp.transform.localPosition.y);
        temp.gameObject.GetComponent<vidvigalkaController>().left = leftVidvSc;
        StartCoroutine(temp.gameObject.GetComponent<vidvigalkaController>().StartAn());

    }                               // спавним выдвижную плиту

    void GoSpawnShip() {

        int RandomWall = Random.Range(0, 4);
        if (RandomWall <= 1)
        {

            setVall(false, "site_left");
        }
        else if (RandomWall >= 3)
        {
            setVall(false, "site_right");

        }
        else {
            setVall(true, "site_right");
            setVall(true, "site_left");

        }

    }                       // штука которая выбирает на какую сторону или стороны повесить шипы 

    void setVall(bool one, string Left_right) {

        float posX = 0.67f;
        float rotY = 90;

        if (Left_right.Contains("right")) {
            posX = -0.67f;
            rotY = 270f;
        }

        Transform wall = WallObj[0].transform.Find(Left_right).transform;

        GameObject temp = Instantiate(ship);

        float RandomY = Random.Range(-5f, 5f);

        temp.transform.position = new Vector3(0f, wall.transform.position.y + RandomY);
        temp.transform.localScale = new Vector3(35, 35, 17);
        temp.transform.SetParent(wall);
        temp.transform.localPosition = new Vector2(posX, temp.transform.localPosition.y);
        temp.transform.localEulerAngles = new Vector3(0,rotY,0);

        if (!one)
        {
            GameObject temp1 = Instantiate(ship);

            if (RandomY >= 0f)
            {           // верх
                temp1.transform.position = new Vector3(0f, wall.transform.position.y + RandomY - 3.5f);
            }
            else
            {
                temp1.transform.position = new Vector3(0f, wall.transform.position.y + RandomY + 3.5f);
            }
            temp1.transform.localScale = new Vector3(35, 35, 17);
            temp1.transform.localEulerAngles = new Vector3(0, rotY, 0);
            temp1.transform.SetParent(wall);
            temp1.transform.localPosition = new Vector2(posX, temp1.transform.localPosition.y);
        }


    }



}
