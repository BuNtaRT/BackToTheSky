using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
/*
namespace Assets.BackToTheSky.script
{
    class Class1
    {
    }

    public class InvisWall : MonoBehaviour
    {

        Color32 wallColor;
        float hard;
        public IEnumerator InvisStart(float Hard)
        {
            hard = Hard;
            wallColor = gameObject.GetComponent<Renderer>().material.color;
            BoxCollider BoxCol = gameObject.GetComponent<BoxCollider>();
            MeshRenderer MeshRen = gameObject.GetComponent<MeshRenderer>();
            string Mtag = gameObject.tag;

            while (true)
            {
                BoxCollider deatZone2 = gameObject.transform.Find("deatZone2").GetComponent<BoxCollider>();
                StartCoroutine(LerpColorWall());
                yield return new WaitForSeconds(1.8f - hard * 2);
                StartCoroutine(LerpColorWall());
                yield return new WaitForSeconds(1.8f - hard * 2);
                StartCoroutine(LerpColorWall());
                yield return new WaitForSeconds(0.8f - hard);

                if (gameObject.transform.childCount > 0)
                {
                    foreach (Transform tr in gameObject.transform)
                    {
                        if (tr.tag == "sled")
                        {
                            Destroy(tr.gameObject);
                        }
                        else if (tr.tag == "Player")
                        {
                            tr.gameObject.GetComponent<pers_maneger>().Godeat();
                        }
                    }
                }
                MeshRen.enabled = false;
                BoxCol.enabled = false;
                deatZone2.enabled = false;
                yield return new WaitForSeconds(3f + hard * 2);
                MeshRen.enabled = true;
                BoxCol.enabled = true;
                deatZone2.enabled = true;

                yield return new WaitForSeconds(2f - hard);



            }
        }



        IEnumerator LerpColorWall()
        {

            var timeStep = 0.0f;
            while (timeStep < 1.0f)
            {
                timeStep += Time.deltaTime / 0.8f - hard;
                gameObject.GetComponent<Renderer>().material.color = Color.Lerp(wallColor, new Color32(wallColor.r, wallColor.g, wallColor.b, 20), timeStep);
                yield return null;
            }
            timeStep = 0.0f;
            while (timeStep < 1.0f)
            {
                timeStep += Time.deltaTime / 0.8f - hard;
                gameObject.GetComponent<Renderer>().material.color = Color.Lerp(new Color32(wallColor.r, wallColor.g, wallColor.b, 20), wallColor, timeStep);
                yield return null;
            }

        }
    }



    public class vidvigalkaController : MonoBehaviour
    {

        Coroutine Move, back;
        public bool left = true;
        float sdw = 0f;
        float myX = 0;
        private void Start()
        {
            myX = transform.localPosition.x;
        }
        private void OnDestroy()
        {
            StopCoroutine(back);
            StopCoroutine(Move);
        }

        public IEnumerator StartAn()
        {
            while (true)
            {
                if (left)
                {
                    sdw = 6f;
                }
                else
                {
                    sdw = -6f;
                }

                Move = StartCoroutine(Lm());
                yield return new WaitForSeconds(1.8f);
                back = StartCoroutine(Ln());
                yield return new WaitForSeconds(1.8f);

            }
        }

        IEnumerator Lm()
        {
            var timeStep = 0.0f;
            while (timeStep < 1.0f)
            {
                timeStep += Time.deltaTime / 2.5f;
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(sdw, transform.localPosition.y), timeStep);
                yield return null;
            }
        }
        IEnumerator Ln()
        {
            var timeStep = 0.0f;
            while (timeStep < 1.0f)
            {
                timeStep += Time.deltaTime / 2.5f;
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(myX, transform.localPosition.y), timeStep);
                yield return null;
            }
        }
    }
    public class wall_moved : MonoBehaviour
    {
        public int hard = 0;
        public Transform deatZoneLeft, deatZoneRight;

        void Start()
        {
            Debug.Log("start wall mov hard = " + hard);
            if (hard == 0)
            {

            }
            else if (hard == 1)
            {
                Debug.Log("hard 1 ");
                Transform wall;
                float Xmove = 0.001f;
                if (System.Random.Range(0, 2) == 0)
                {
                    wall = gameObject.transform.Find("site_left").transform;
                    Xmove = -1.5f;
                    deatZoneLeft.gameObject.SetActive(true);
                }
                else
                {
                    wall = gameObject.transform.Find("site_right").transform;
                    Xmove = 1.5f;
                    deatZoneRight.gameObject.SetActive(true);

                }
                StartCoroutine(Move(wall, Xmove, 0));
            }
            else if (hard == 2)
            {

                Transform wall = gameObject.transform.Find("site_left").transform;
                float Xmove = 0;
                Xmove = -1.5f;
                deatZoneLeft.gameObject.SetActive(true);

                StartCoroutine(Move(wall, Xmove, 0));


                wall = wall = gameObject.transform.Find("site_right").transform;
                Xmove = 1.5f;
                deatZoneRight.gameObject.SetActive(true);

                StartCoroutine(Move(wall, Xmove, 0));

            }
            else if (hard == 3)
            {
                Transform wall = gameObject.transform.Find("site_left").transform;
                float Xmove = 0;
                Xmove = -1.5f;
                deatZoneLeft.gameObject.SetActive(true);
                deatZoneRight.gameObject.SetActive(true);

                StartCoroutine(Move(wall, Xmove, 2));


                wall = wall = gameObject.transform.Find("site_right").transform;
                Xmove = 1.5f;
                StartCoroutine(Move(wall, Xmove, 2));

            }

        }


        IEnumerator Move(Transform wall, float move, float wait)
        {

            yield return new WaitForSeconds(Random.Range(0, wait));
            float prewTransf = wall.transform.localPosition.x;
            while (true)
            {

                var timeStep = 0.0f;

                while (timeStep < 1.0f)
                {
                    timeStep += Time.deltaTime * 1f;
                    wall.transform.localPosition = Vector3.Lerp(wall.localPosition, new Vector3(move, wall.localPosition.y, 0), timeStep);
                    yield return null;
                }


                timeStep = 0.0f;
                while (timeStep < 1.0f)
                {
                    timeStep += Time.deltaTime * 1f;
                    wall.transform.localPosition = Vector3.Lerp(wall.localPosition, new Vector3(prewTransf, wall.localPosition.y, 0), timeStep);
                    yield return null;
                }

            }
        }
    }

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

        public void BuyItem(int price)
        {
            finalP = finalP - price;
            Set();

        }

        public void EndGame(int score)
        {
            if (PlayerPrefs.GetInt("MedidativeMod") == 0)
            {
                finalP = finalP + (int)(score / 1.85f);
            }
            else
            {
                finalP = finalP + (int)(score / 1.15f);
            }
            PlayerPrefs.Save();
            Set();
        }

        public void Get1500()
        {
            finalP = finalP + 1500;
            Set();
        }

        public void Reklama()
        {
            finalP = finalP + 150;
            Set();
        }

        void Set()
        {
            CoinLabel.GetComponent<Text>().text = finalP.ToString();
            PlayerPrefs.SetInt("coin", finalP);
            PlayerPrefs.Save();
        }

    }

    public class Color_for_default_wall : MonoBehaviour
    {
        Color32[] color_wall = { new Color32(216,67,21,255), new Color32(239,108,0,255),
                            new Color32(255,143,0,255), new Color32(249,168,37,255), new Color32(158,157,36,255), new Color32(85,139,47,255),
                            new Color32(46,125,50,255), new Color32(0,105,92,255) , new Color32(0,131,143,255), new Color32(2,119,189,255), new Color32(21,101,192,255),
                            new Color32(40,53,147,255), new Color32(69,39,160,255), new Color32(106,27,154,255), new Color32(173,20,87,255), new Color32(78,52,46,255) };
        // Start is called before the first frame update
        void Start()
        {
            int collor = Random.Range(0, 15);
            gameObject.transform.Find("site_left").GetComponent<Renderer>().material.color = color_wall[collor];
            gameObject.transform.Find("site_right").GetComponent<Renderer>().material.color = color_wall[collor];
        }

    }

    public class controll : MonoBehaviour
    {

        Vector2 startPos, endPos, direction;
        public GameObject Player;
        public ParticleSystem P1, P2;
        public GameObject StartDeatCube;
        public int NextLvl = 0;
        public Text Score;
        int scoreText = 0;
        public GameObject PrevRecText;                // текст с предыдущим рекордом игрока 

        public bool deat = false;                     // когда умираем ничего не делаем 

        float throwForceInXandX = 1.65f;              // сила ускорения 
        float throwForceInXandY = 1.35f;              // тоже сила ускорения только по вертикали 

        public bool DoubleJump = false;               // лок что бы в воздухе не прыгать много раз 
        float directoinX = 150;                       // максимальное помножения свайпа влево 
        float directoinY = 350;                       // максимальное помножения свайпа вверх 
        float PlayerMax = 1;                          // если игрок опускается на 8 юнитов то смерть - это хранит его максимально достигнутую высоту

        generate_wall GenWall;

        // Start is called before the first frame update
        void Start()
        {
            LastY = Player.transform.position.y;

            GenWall = GameObject.Find("scipts").GetComponent<generate_wall>();

            float Sw = Screen.width;
            float Sh = Screen.height;



            //if (Sh < 1000)                                                                      // уменьшение области для тача 
            //{
            //    directoinY = directoinY - (directoinY * (Sh / 1920));

            //    directoinX = directoinX - (directoinX * (Sw / 1080));
            //    throwForceInXandX = throwForceInXandX + (1.25f * (250 / (250 - directoinX)));   

            //    throwForceInXandY = throwForceInXandY + (1.05f * (350 / (350 - directoinY)));

            //}

        }

        public void StartGame()
        {
            GameObject.Find("scipts").GetComponent<grad_background>().start_game();

            StartCoroutine(StartDetectTouch());
            int Record = PlayerPrefs.GetInt("Record");
            if (Record >= 2)
            {
                GameObject temp = Instantiate(PrevRecText);
                temp.transform.position = new Vector3(-5, Record, 0);
                temp.GetComponent<TextMesh>().text = "_______________________" + Record.ToString() + "_______________________";
            }
        }

        IEnumerator StartDetectTouch()
        {
            yield return new WaitForSecondsRealtime(1.5f);
            DoubleJump = true;
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPos = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                endPos = Input.GetTouch(0).position;

                direction = startPos - endPos;


                Player.GetComponent<Rigidbody>().isKinematic = false;

                ///////////////////////////////////////////////////// ограничения на X
                if (direction.x > 0)
                {
                    direction = new Vector2(direction.x + 150, direction.y);

                }
                if (direction.x > 0 && direction.x > directoinX)
                {
                    direction = new Vector2(directoinX, direction.y);
                }
                else if (direction.x < 0 && direction.x < -directoinX)
                {

                    direction = new Vector2(-directoinX, direction.y);
                }

                ///////////////////////////////////////////////////// ограничения на Y
                if (direction.y > 0 && direction.y > directoinY)
                {
                    direction = new Vector2(direction.x, directoinY);
                }
                else if (direction.y < 0 && direction.y < -directoinY)
                {

                    direction = new Vector2(direction.x, -directoinY);
                }




                if (DoubleJump)
                {
                    off_terrain();
                    Player.GetComponent<Rigidbody>().AddForce(-direction.x * throwForceInXandX, -direction.y * throwForceInXandY, 0);
                    Player.GetComponent<Animation>().Play("Jump");
                    Player.GetComponent<pers_maneger>().invulnerability = false;
                    DoubleJump = false;

                }



            }

        }

        int iOffDeat = 0;
        void off_terrain()
        {
            if (iOffDeat >= 0 && iOffDeat <= 4)
            {

                GameObject.Find("Terrain").GetComponent<BoxCollider>().isTrigger = true;
                StartDeatCube.SetActive(true);
            }
            iOffDeat++;
        }

        private void FixedUpdate()
        {
            if (PlayerMax >= NextLvl)
            {
                GameObject.Find("scipts").GetComponent<lvlController>().NewLvl();
            }
            scoreText = (int)PlayerMax;
            Score.text = scoreText.ToString();
        }

        float LastY = 0; // позиция для каммеры если увеличиватся на 10 то пора спаснить стену и удалять преведущию

        private void LateUpdate()
        {
            if (!deat)
            {
                if (PlayerMax < Player.transform.position.y)
                {
                    PlayerMax = Player.transform.position.y;
                }
                if (LastY + 10 <= Player.transform.position.y)
                {
                    GenWall.GoGenerateWall();
                    LastY = Player.transform.position.y;
                }
                if (PlayerMax - 6.5 > Player.transform.position.y || Player.transform.position.y < -0.5)
                {                      // игрок слишком низко - это смэрть 
                    deat = true;
                    GameObject.Find("scipts").GetComponent<Deat>().deat(PlayerMax);
                }
                else
                {
                    gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Player.transform.position.y, transform.position.z), Time.deltaTime * 1.5f);
                }
            }
        }

    }

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

        public Text RecordNow, Record;

        // Start is called before the first frame update
        void Start()
        {
            Player = GameObject.Find("Pers");
            if (Advertisement.isSupported && !Advertisement.isInitialized)
            {
                Advertisement.Initialize("3719057", false);
            }
        }

        public void deat(float PlayerM)
        {
            if (!once)
            {

                if (sh >= 2)
                {

                    respButton.SetActive(false);
                }

                once = true;

                if (PlayerPrefs.GetInt("Record") < (int)PlayerM)
                {
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

        public void Respawn()
        {

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
        public void end()
        {

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

    public class Del_recover_platform : MonoBehaviour
    {
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Destroy(this.gameObject);
            }
        }

    }

    public class FixFuckingBye : MonoBehaviour
    {

        public GameObject windowNoAdd;
        public GameObject ButtonNoAdd;
        public GameObject MagazinB, startB;
        public Button rewVideio, settingB;

        void Start()
        {
            ButtonNoAdd.SetActive(false);
            windowNoAdd.SetActive(false);
            MagazinB.SetActive(true);
            startB.SetActive(true);
            rewVideio.enabled = true;
            settingB.enabled = true;
        }

    }

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

        public void GoGenerateWall()
        {
            Destroy(WallObj[3]);
            WallObj.RemoveAt(3);

            Ywall += 10;
            generate(Ywall);
        }

        private void generate(float Yp)
        {





            GameObject temp = Instantiate(wall, new Vector3(0, Yp, 0), new Quaternion());
            WallObj.Insert(0, temp);



            int collor = Random.Range(0, 15);
            WallObj[0].transform.Find("site_left").GetComponent<Renderer>().material.color = color_wall[collor];
            WallObj[0].transform.Find("site_right").GetComponent<Renderer>().material.color = color_wall[collor];
            if ((Yp > 20 && Yp <= 180) && Random.Range(0, 9) >= 5)               /// 5
            {
                creat_hard(1);
            }
            else if ((Yp >= 181 && Yp <= 310) && Random.Range(0, 8) >= 4)
            {
                creat_hard(2);
            }
            else if ((Yp >= 311 && Yp <= 460) && Random.Range(0, 8) >= 3)
            {
                creat_hard(3);
            }
            else if (Yp >= 461 && Random.Range(0, 9) >= 1)
            {
                creat_hard(4);
            }


        }


        void creat_hard(int LvlHard)
        {

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
                else if (LvlHard == 3)
                {
                    int Rand = Random.Range(0, 5);

                    if (Rand == 0)
                    {
                        GoSpawnShip();
                        GoMoveWall(3);
                    }
                    else if (Rand == 1)
                    {
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

        public void GoCreateShipPanel()
        {

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

        void ShipPanelSpawn(string name)
        {
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

        void GoMoveWall(int hard)
        {
            WallObj[0].GetComponent<wall_moved>().hard = hard;
        }

        void GoCreateVidvigalka()
        {

            if (Ywall >= 150)
            {
                vidvigalkaSpawn("site_right");
                vidvigalkaSpawn("site_left");

            }
            else
            {
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

        void vidvigalkaSpawn(string nameWall)
        {
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

        void GoSpawnShip()
        {

            int RandomWall = Random.Range(0, 4);
            if (RandomWall <= 1)
            {

                setVall(false, "site_left");
            }
            else if (RandomWall >= 3)
            {
                setVall(false, "site_right");

            }
            else
            {
                setVall(true, "site_right");
                setVall(true, "site_left");

            }

        }                       // штука которая выбирает на какую сторону или стороны повесить шипы 

        void setVall(bool one, string Left_right)
        {

            float posX = 0.67f;
            float rotY = 90;

            if (Left_right.Contains("right"))
            {
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
            temp.transform.localEulerAngles = new Vector3(0, rotY, 0);

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

    public class grad_background : MonoBehaviour
    {
        public GameObject up, down, center;
        float timeSteapSwitch_color = 13f;      // время на смену цвета


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////цвета 
        Color32[] C1 = { new Color32(244, 81, 30, 255), new Color32(255, 138, 101, 255), new Color32(255, 167, 38, 255) };
        Color32[] C2 = { new Color32(251, 140, 0, 255), new Color32(255, 183, 77, 255), new Color32(255, 202, 40, 255) };
        Color32[] C3 = { new Color32(255, 179, 0, 255), new Color32(255, 213, 79, 255), new Color32(255, 238, 88, 255) };
        Color32[] C4 = { new Color32(253, 216, 53, 255), new Color32(255, 241, 118, 255), new Color32(212, 225, 87, 255) };
        Color32[] C5 = { new Color32(192, 202, 51, 255), new Color32(220, 231, 117, 255), new Color32(156, 204, 101, 255) };
        Color32[] C6 = { new Color32(124, 179, 66, 255), new Color32(174, 213, 129, 255), new Color32(102, 187, 106, 255) };
        Color32[] C7 = { new Color32(67, 160, 71, 255), new Color32(129, 199, 132, 255), new Color32(38, 166, 154, 255) };
        Color32[] C8 = { new Color32(0, 137, 123, 255), new Color32(77, 182, 172, 255), new Color32(38, 198, 218, 255) };
        Color32[] C9 = { new Color32(0, 172, 193, 255), new Color32(77, 208, 225, 255), new Color32(41, 182, 246, 255) };
        Color32[] C10 = { new Color32(3, 155, 229, 255), new Color32(79, 195, 247, 255), new Color32(66, 165, 245, 255) };
        Color32[] C11 = { new Color32(30, 136, 229, 255), new Color32(100, 181, 246, 255), new Color32(92, 107, 192, 255) };
        Color32[] C12 = { new Color32(57, 73, 171, 255), new Color32(121, 134, 203, 255), new Color32(126, 87, 194, 255) };
        Color32[] C13 = { new Color32(94, 53, 177, 255), new Color32(149, 117, 205, 255), new Color32(171, 71, 188, 255) };
        Color32[] C14 = { new Color32(142, 36, 170, 255), new Color32(186, 104, 200, 255), new Color32(236, 64, 122, 255) };
        Color32[] C15 = { new Color32(216, 27, 96, 255), new Color32(240, 98, 146, 255), new Color32(239, 83, 80, 255) };
        Color32[] C16 = { new Color32(229, 57, 53, 255), new Color32(229, 115, 115, 255), new Color32(255, 112, 67, 255) };
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////цвета закончились  

        /// индекс цвета для доступа к ColorList
        int Color_Index = 0;

        /// Лист массивов цветов 
        List<Color32[]> ColorList = new List<Color32[]>();

        void Start()
        {
            ColorList.Add(C1);
            ColorList.Add(C2);
            ColorList.Add(C3);
            ColorList.Add(C4);
            ColorList.Add(C5);
            ColorList.Add(C6);
            ColorList.Add(C7);
            ColorList.Add(C8);
            ColorList.Add(C9);
            ColorList.Add(C10);
            ColorList.Add(C11);
            ColorList.Add(C12);
            ColorList.Add(C13);
            ColorList.Add(C14);
            ColorList.Add(C15);
            ColorList.Add(C16);

            //////////////////////////////////////  ставим начальный цвет
            Color_Index = Random.Range(0, 14);
            Color32[] ColorUnPack = new Color32[2];
            ColorUnPack = ColorList[Color_Index];
            downC = ColorUnPack[0];
            centerC = ColorUnPack[1];
            upC = ColorUnPack[2];
            // следующие цвета 
            ColorUnPack = ColorList[Color_Index + 1];
            downNext = ColorUnPack[0];
            centerNext = ColorUnPack[1];
            upNext = ColorUnPack[2];
            // ставим цвета 
            down.GetComponent<Renderer>().material.color = downC;
            up.GetComponent<Renderer>().material.color = upC;
            center.GetComponent<Renderer>().material.color = centerC;

        }

        bool start = false;

        public void start_game()
        {
            StartCoroutine(Switch_color());
        }

        Color32 upC, downC, centerC;
        Color32 upNext, downNext, centerNext;
        int Switch_color_mode = 0; // когда достигает 16 заднику задаются цвета из разных массивов для каждого элемента

        bool del_collor_once = true;
        void dell_color()
        {
            //if (del_collor_once) {
            //    ColorList.RemoveAt(4);
            //    ColorList.RemoveAt(4);
            //    ColorList.RemoveAt(4);
            //    ColorList.RemoveAt(4);
            //    ColorList.RemoveAt(4);
            //    ColorList.RemoveAt(4);
            //    ColorList.RemoveAt(4);
            //    Debug.Log(ColorList.Count);
            //    del_collor_once = false;
            //}
        }


        IEnumerator Switch_color()
        {
            //yield return new WaitForSeconds(6f);

            while (true)
            {
                if (timeSteapSwitch_color >= 6)
                {
                    timeSteapSwitch_color -= 0.05f;
                }
                Switch_color_mode++;
                StartCoroutine(LerpBG());
                yield return new WaitForSeconds(timeSteapSwitch_color);
                if (Switch_color_mode <= 15)
                {
                    Color_Index++;
                    Color32[] ColorUnPack1 = new Color32[2];
                    ColorUnPack1 = ColorList[Color_Index];
                    downC = ColorUnPack1[0];
                    centerC = ColorUnPack1[1];
                    upC = ColorUnPack1[2];
                    // следующие цвета 
                    if (Color_Index == 15)
                    {
                        Color_Index = -1;
                    }
                    ColorUnPack1 = ColorList[Color_Index + 1];
                    downNext = ColorUnPack1[0];
                    centerNext = ColorUnPack1[1];
                    upNext = ColorUnPack1[2];

                }
                else
                {
                    dell_color();

                    Color32[] ColorUnPack = new Color32[2];
                    downC = downNext;
                    centerC = centerNext;
                    upC = upNext;
                    // следующие цвета 

                    ColorUnPack = ColorList[Random.Range(0, 8)];
                    downNext = ColorUnPack[0];
                    ColorUnPack = ColorList[Random.Range(0, 8)];
                    centerNext = ColorUnPack[1];
                    ColorUnPack = ColorList[Random.Range(0, 8)];
                    upNext = ColorUnPack[2];
                }
            }
        }


        IEnumerator LerpBG()
        {

            var timeStep = 0.0f;
            while (timeStep < 1.0f)
            {
                timeStep += Time.deltaTime / timeSteapSwitch_color;
                down.GetComponent<Renderer>().material.color = Color.Lerp(downC, downNext, timeStep);
                center.GetComponent<Renderer>().material.color = Color.Lerp(centerC, centerNext, timeStep);
                up.GetComponent<Renderer>().material.color = Color.Lerp(upC, upNext, timeStep);
                yield return null;
            }

        }

        // Update is called once per frame
        void Update()
        {


        }
    }

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


        public void NewLvl()
        {
            Debug.Log("NextLvl");
            if (I <= 110)
            {
                GameObject.Find("Main Camera/MainMusic").GetComponent<MusicManeger>().NextLvlSound(2);
                list.Stop();
                cloud.Play();
                I += 200;
                control.NextLvl = I;

            }
            else if (I <= 310)
            {
                cloud.Stop();
                star.Play();
                GameObject.Find("Main Camera/MainMusic").GetComponent<MusicManeger>().NextLvlSound(3);
                I += 150;
                control.NextLvl = I;

            }
            else if (I <= 460)
            {
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

    public class magazinSC : MonoBehaviour
    {
        public GameObject LightMat, LightStik, LightTrail, LightSound;              // тут хранится освещение 
        float Golvl = 0;                                                            // это положение камеры
        private Vector2 startPos;                                                   // это для 
        private Vector2 endPos;                                                     // touch
        private Vector2 direction;                                                  // управления 
        int lvlN = 1;                                                               // это уровень магазина
        public Text PriceText;                                                      // текст для вывода цены 

        public GameObject PersStik, PersTrail;


        public GameObject BuyWindow;                                                // окно покупки 
        public GameObject ErrorBuy;                                                 // информативное окно о недостатке монет

        public GameObject[] Mat = new GameObject[1];                                // массив с материалами 
        public Sprite[] Stik = new Sprite[1];                                      // и стикерами 
        public TrailRenderer[] Trail = new TrailRenderer[1];                        // и эфектами 
        public AudioClip[] Sound = new AudioClip[1];                              // и звуками 
        GameObject ScrollMat, ScrollStic, ScrollTrail, ScrollSound;                    // скролы, ни слова больше
        public AudioSource DemonstrationSound;

        bool[] MatSave = new bool[17];                                              // это 
        bool[] StickSave = new bool[33];                                            // bool 
        bool[] TrailSave = new bool[60];                                            // обозначающие 
        bool[] SoundSave = new bool[13];                                            // куплен или нет предмет

        public GameObject Mgazin;
        public GameObject RechoiseWindow;

        public Sprite Pay, Payed;
        public SpriteRenderer MatInd, SprInd, TraInd, SouInd;                       // индикатор покупки предмета ы

        string pathResNow = "";                                                     // путь до ресурсов выбравнного предмета

        float PosMat = 0;                                                             // положение скрола для материалов 

        bool BuyBool = false;                                                       // нужно для блокировки жестов при покупки 

        public GameObject SettingB, RewB, AdsB;

        int IndexMat = 0;                                                           // всякие индексы в массиве (материалы)
        int IndexStik = 0;                                                          // стикеры 
        int IndexTrail = 0;                                                         // эффекты
        int IndexSound = 0;                                                         // звуки, а что же еще 

        public GameObject StartB, MarketB;                                    // кнопки (догадайся за что они отвечают??)
        int price = 300;                                                            // наверно цена текущего предмета, или нет ??

        bool language = false;                                                      // false = english , правда = русский  

        // Start is called before the first frame update
        private void OnEnable()
        {
            gameObject.GetComponent<controll>().enabled = false;
            lvlN = 1;
            Mgazin.SetActive(true);

            SettingB.SetActive(false);
            RewB.SetActive(false);
            AdsB.SetActive(false);



        }

        void Start()
        {
            if (!File.Exists(Application.persistentDataPath + "/Mat.izg"))                                         //если фала нет то созздаем 
            {
                Debug.Log("not find");
                using (StreamWriter file = File.CreateText(Application.persistentDataPath + "/Mat.izg"))
                {
                    for (int i = 0; i <= Mat.Length - 1; i++)
                    {
                        if (i == 0)
                        {
                            file.WriteLine(true);
                        }
                        else
                        {
                            file.WriteLine(false);
                        }
                    }
                }
                using (StreamWriter file = File.CreateText(Application.persistentDataPath + "/Sti.izg"))
                {
                    for (int i = 0; i <= Stik.Length - 1; i++)
                    {
                        file.WriteLine(false);
                    }
                }
                using (StreamWriter file = File.CreateText(Application.persistentDataPath + "/Tra.izg"))
                {
                    for (int i = 0; i <= Trail.Length - 1; i++)
                    {
                        file.WriteLine(false);
                    }
                }
                using (StreamWriter file = File.CreateText(Application.persistentDataPath + "/Sou.izg"))
                {
                    for (int i = 0; i <= Sound.Length - 1; i++)
                    {
                        if (i == 0)
                        {
                            file.WriteLine(true);
                        }
                        else
                        {
                            file.WriteLine(false);
                        }
                    }
                }
            }

            if (PlayerPrefs.GetInt("lg") == 0)                          // ставим язык 
            {
                language = false;
            }
            else
            {
                language = true;
            }
            ScrollMat = GameObject.Find("magazin/Material/Scroll");
            ScrollStic = GameObject.Find("magazin/Stiker/Scroll/DemonstrationCubeStick");
            ScrollTrail = GameObject.Find("magazin/Trail/Scroll/DemonstrationCubeStick");
            ScrollSound = GameObject.Find("magazin/Sound/Scroll");
        }

        public void SetLvl()
        {                                                  // ставим уровень магазина для камеры и включаем свейт там где надо 

            switch (lvlN)
            {
                case 0:
                    gameObject.GetComponent<controll>().enabled = true;
                    LightMat.SetActive(false);
                    StartB.SetActive(true);
                    MarketB.SetActive(true);
                    PriceText.enabled = false;
                    this.enabled = false;
                    Mgazin.SetActive(true);
                    SettingB.SetActive(true);
                    RewB.SetActive(true);
                    if (PlayerPrefs.GetInt("NoAdd") == 3)
                    {
                        AdsB.SetActive(false);
                    }
                    else
                    {
                        AdsB.SetActive(true);
                    }
                    break;
                case 1:
                    Load();
                    Golvl = -7f;
                    LightMat.SetActive(true);
                    LightStik.SetActive(false);
                    prChkMat();
                    break;
                case 2:
                    Golvl = -11;
                    LightMat.SetActive(false);
                    ScrollStic.GetComponent<Renderer>().material = GameObject.Find("Pers/PersCinem").GetComponent<Renderer>().material;
                    ScrollStic.transform.Find("Skin/Sprite").GetComponent<SpriteRenderer>().sprite = Stik[IndexStik];
                    if (ScrollStic.GetComponent<Renderer>().material.name.Contains("18"))
                    {
                        ScrollStic.GetComponent<MaterialColorAll>().enabled = true;
                    }
                    else
                    {
                        ScrollStic.GetComponent<MaterialColorAll>().enabled = false;
                    }
                    LightStik.SetActive(true);
                    LightTrail.SetActive(false);
                    prChkStik();
                    break;
                case 3:
                    Golvl = -14.6f;
                    LightStik.SetActive(false);
                    LightTrail.SetActive(true);
                    LightSound.SetActive(false);
                    ScrollTrail.GetComponent<Renderer>().material = GameObject.Find("Pers/PersCinem").GetComponent<Renderer>().material;
                    if (ScrollStic.GetComponent<Renderer>().material.name.Contains("18"))
                    {
                        ScrollStic.GetComponent<MaterialColorAll>().enabled = true;
                    }
                    else
                    {
                        ScrollStic.GetComponent<MaterialColorAll>().enabled = false;
                    }
                    prChkTrail();
                    DemonstrationSound.gameObject.SetActive(false);
                    if (PlayerPrefs.GetInt("StikID") >= 0)
                    {
                        ScrollTrail.transform.Find("Skin").GetComponent<Animation>().clip = GameObject.Find("Pers/PersCinem/Skin").GetComponent<Animation>().clip;
                        ScrollTrail.transform.Find("Skin").GetComponent<Animation>().enabled = GameObject.Find("Pers/PersCinem/Skin").GetComponent<Animation>().enabled;
                        ScrollTrail.transform.Find("Skin/Sprite").GetComponent<SpriteRenderer>().sprite = GameObject.Find("Pers/PersCinem/Skin/Sprite").GetComponent<SpriteRenderer>().sprite;
                    }
                    break;
                case 4:
                    Golvl = -18.1f;
                    LightTrail.SetActive(false);
                    LightSound.SetActive(true);
                    prChkSound();
                    DemonstrationSound.gameObject.SetActive(true);
                    //ScrollTrail.GetComponent<TrailRenderer>().colorGradient = Trail[IndesTrail].colorGradient;
                    //ScrollTrail.GetComponent<TrailRenderer>().widthCurve = Trail[IndesTrail].widthCurve;
                    //ScrollTrail.GetComponent<TrailRenderer>().time = Trail[IndesTrail].time;
                    break;
                default:
                    gameObject.GetComponent<controll>().enabled = true;
                    LightMat.SetActive(false);
                    StartB.SetActive(true);
                    MarketB.SetActive(true);
                    PriceText.enabled = false;
                    this.enabled = false;
                    DemonstrationSound.gameObject.SetActive(false);
                    Mgazin.SetActive(true);
                    SettingB.SetActive(true);
                    RewB.SetActive(true);
                    if (PlayerPrefs.GetInt("NoAdd") == 3)
                    {
                        AdsB.SetActive(false);
                    }
                    else
                    {
                        AdsB.SetActive(true);
                    }
                    break;

            }
            setPrice();
        }                                  // ставим уровень магазина

        void setPrice()
        {

            string Path = "";
            Debug.Log("mat = " + IndexMat);
            switch (lvlN)
            {
                case 1:
                    Path = "prefab/Skin/material/" + (IndexMat).ToString();
                    if (IndexMat <= 1)
                    {
                        price = 300;
                    }
                    else if (IndexMat <= 15)
                    {
                        price = 500;
                    }
                    else if (IndexMat == 16)
                    {
                        price = 1500;
                    }
                    break;
                case 2:
                    Path = "Sprite/skinSp/" + IndexStik.ToString();
                    if (IndexStik <= 12)
                    {
                        price = 300;
                    }
                    else if (IndexStik <= 25)
                    {
                        price = 600;
                    }
                    else if (IndexStik <= 33)
                    {
                        price = 800;
                    }
                    break;
                case 3:
                    Path = "TrailRender/" + IndexTrail.ToString();
                    if (IndexTrail == 0)
                    {
                        price = 200;
                    }
                    else if (IndexTrail <= 9)
                    {
                        price = 500;
                    }
                    else if (IndexTrail <= 57)
                    {
                        price = 650;
                    }
                    else if (IndexTrail <= 59)
                    {
                        price = 800;
                    }
                    break;

                case 4:
                    Path = "sound/JUmp/" + IndexSound.ToString();
                    if (IndexSound <= 8)
                    {
                        price = 300;
                    }
                    else
                    {
                        price = 500;
                    }
                    break;
            }

            pathResNow = Path;
            if (language == false)
            {
                PriceText.text = "Price " + price.ToString();
            }
            else
            {
                PriceText.text = "Цена " + price.ToString();
            }
        }                                       //ставим цену за предмет


        private void MaterialManeger(bool right)
        {

            if (right)
            {
                if (IndexMat > 0)
                {
                    if (IndexMat < Mat.Length - 3)
                    {
                        Mat[IndexMat + 3].SetActive(false);
                    }
                    if (IndexMat - 2 >= 0)
                    {
                        Mat[IndexMat - 2].SetActive(true);
                    }
                    IndexMat--;
                    PosMat += 2.5f;
                    setPrice();
                }
            }
            else
            {
                if (IndexMat >= 3)
                {
                    Mat[IndexMat - 3].SetActive(false);
                }
                if (IndexMat < Mat.Length - 1)
                {
                    if (IndexMat < Mat.Length - 3)
                    {
                        Mat[IndexMat + 3].SetActive(true);
                    }
                    IndexMat++;
                    PosMat -= 2.5f;
                    setPrice();
                }
            }
            prChkMat();
        }              // управляем материалами 

        private void StickManeger(bool right)
        {
            if (right)
            {
                if (IndexStik > 0)
                {
                    IndexStik--;
                    StartCoroutine(SetStick());
                    setPrice();

                }
            }
            else
            {
                if (IndexStik < Stik.Length - 1)
                {
                    IndexStik++;
                    StartCoroutine(SetStick());
                    setPrice();

                }
            }
        }                  // управляем стикерами

        IEnumerator SetStick()
        {                                            //установка стикера
            ScrollStic.GetComponent<Animation>().Stop();
            ScrollStic.GetComponent<Animation>().Play("SwitchStick");       // анимация смены стикера

            yield return new WaitForSecondsRealtime(0.5f);                  //ждем

            ScrollStic.transform.Find("Skin/Sprite").GetComponent<SpriteRenderer>().sprite = Stik[IndexStik];   // ставим наш стик
            prChkStik();

            Animation AnimateSprite = ScrollStic.transform.Find("Skin").GetComponent<Animation>();              // анимация вертелки
            if (IndexStik >= 26)                                                                                // анимированный стикер сеййчас или нет
            {
                AnimateSprite.enabled = true;
            }
            else
            {
                AnimateSprite.enabled = false;
                ScrollStic.transform.Find("Skin/Sprite").transform.eulerAngles = new Vector3(0, 0, 0);
            }

            yield return new WaitForSecondsRealtime(0.5f);


            ScrollStic.GetComponent<Animation>().Play("StikDem");

        }                                // для эффекта переключения стикеров

        private void TrailManeger(bool right)
        {
            if (right)
            {
                if (IndexTrail > 0)
                {
                    IndexTrail--;
                }
            }
            else
            {
                if (IndexTrail < Trail.Length - 1)
                {
                    IndexTrail++;

                }
            }
            TrailRenderer TrailTemp = ScrollTrail.transform.Find("Trail").GetComponent<TrailRenderer>();
            TrailTemp.enabled = false;
            TrailTemp.colorGradient = Trail[IndexTrail].colorGradient;
            TrailTemp.enabled = true;
            setPrice();
            prChkTrail();

        }                  // управляем эффектами 

        private void SoundManeger(bool right)
        {
            if (right)
            {
                if (IndexSound > 0)
                {
                    IndexSound--;
                    DemonstrationSound.enabled = true;
                    DemonstrationSound.clip = Sound[IndexSound];
                    ScrollSound.GetComponent<Animation>().Play("soundSwitchmarket");

                }
            }
            else
            {
                if (IndexSound < Sound.Length - 1)
                {
                    IndexSound++;
                    DemonstrationSound.enabled = true;
                    DemonstrationSound.clip = Sound[IndexSound];
                    ScrollSound.GetComponent<Animation>().Play("soundSwitchmarket");
                }
            }
            setPrice();
            prChkSound();
        }




        ////////////////////////////////////////тут происходит проверка на то куплен предмет или нет путем сверения индекса в мас предметов и загруженных предметов
        private void prChkMat()
        {
            PriceText.enabled = true;
            if (MatSave[IndexMat] == false)
            {
                MatInd.sprite = Pay;
            }
            else
            {
                MatInd.sprite = Payed;
                PriceText.enabled = false;
            }
        }
        private void prChkStik()
        {
            PriceText.enabled = true;
            if (StickSave[IndexStik] == false)
            {
                SprInd.sprite = Pay;
            }
            else
            {
                SprInd.sprite = Payed;
                PriceText.enabled = false;
            }
        }
        private void prChkTrail()
        {
            PriceText.enabled = true;
            if (TrailSave[IndexTrail] == false)
            {
                TraInd.sprite = Pay;
            }
            else
            {
                TraInd.sprite = Payed;
                PriceText.enabled = false;
            }
        }
        private void prChkSound()
        {
            PriceText.enabled = true;
            if (SoundSave[IndexSound] == false)
            {
                SouInd.sprite = Pay;
            }
            else
            {
                SouInd.sprite = Payed;
                PriceText.enabled = false;
            }
        }

        private void Buy()
        {

            if (!rechoiseCheck())
            {
                if (PriceText.enabled == true)
                {
                    if (Convert.ToInt32(GameObject.Find("PlayerMoney").GetComponent<Text>().text) >= price)
                    {

                        BuyWindow.SetActive(true);
                        BuyBool = true;
                        PriceText.enabled = false;

                        string setTextInf = "";

                        if (language == false)
                        {
                            BuyWindow.transform.Find("bg/DontI/Text").GetComponent<Text>().text = "Not";
                            BuyWindow.transform.Find("bg/YesI/Text").GetComponent<Text>().text = "Yes";

                            switch (lvlN)
                            {
                                case 1:
                                    setTextInf = "Buy this color for ";
                                    break;
                                case 2:
                                    setTextInf = "Buy this sticker for ";
                                    break;
                                case 3:
                                    setTextInf = "Buy this track for ";
                                    break;
                                case 4:
                                    setTextInf = "Buy this sound for ";
                                    break;
                            }
                        }
                        else
                        {
                            BuyWindow.transform.Find("bg/DontI/Text").GetComponent<Text>().text = "Нет";
                            BuyWindow.transform.Find("bg/YesI/Text").GetComponent<Text>().text = "Да";
                            switch (lvlN)
                            {
                                case 1:
                                    setTextInf = "Купить этот цвет за ";
                                    break;
                                case 2:
                                    setTextInf = "Купить эту наклейку за ";
                                    break;
                                case 3:
                                    setTextInf = "Купить этот след за ";
                                    break;
                                case 4:
                                    setTextInf = "Купить этот звук за ";
                                    break;
                            }
                        }
                        BuyWindow.transform.Find("bg/Text").GetComponent<Text>().text = setTextInf + price.ToString() + " ?";


                    }
                    else
                    {

                        ErrorBuy.SetActive(true);
                        if (!language)
                        {
                            ErrorBuy.transform.Find("bg/Text").GetComponent<Text>().text = "Not enough coins to buy";
                        }
                        else
                        {
                            ErrorBuy.transform.Find("bg/Text").GetComponent<Text>().text = "Для покупки недостаточно монет";
                        }
                    }
                }
            }
            else
            {
                BuyBool = true;
                RechoiseWindow.SetActive(true);
                if (PlayerPrefs.GetInt("lg") == 0)
                {
                    RechoiseWindow.transform.Find("bg/Text").GetComponent<Text>().text = "Choose again ?";
                    RechoiseWindow.transform.Find("bg/DontI/Text").GetComponent<Text>().text = "Not";
                    RechoiseWindow.transform.Find("bg/YesI/Text").GetComponent<Text>().text = "Yes";
                }
                else
                {
                    RechoiseWindow.transform.Find("bg/Text").GetComponent<Text>().text = "Выбрать снова ?";
                    RechoiseWindow.transform.Find("bg/DontI/Text").GetComponent<Text>().text = "Нет";
                    RechoiseWindow.transform.Find("bg/YesI/Text").GetComponent<Text>().text = "Да";
                }
            }


        }                                    // пользователь хочет что то купить ?? ну тогда выведим сообщение если предмет еще не куплен

        public void RechoiseConfim(bool conf)
        {
            RechoiseWindow.SetActive(false);
            if (conf)
            {
                if (lvlN == 1)
                {
                    PlayerPrefs.SetInt("materialID", IndexMat);
                    PlayerPrefs.Save();
                    //GameObject.Find("Pers/PersCinem").GetComponent<Renderer>().material = Resources.Load<Material>(pathResNow);
                    //if (pathResNow.Contains("18"))
                    //{
                    //    GameObject.Find("Pers/PersCinem").GetComponent<MaterialColorAll>().enabled = true;
                    //}
                    //else
                    //{
                    //    GameObject.Find("Pers/PersCinem").GetComponent<MaterialColorAll>().enabled = false;
                    //}
                    GameObject.Find("Pers").GetComponent<pers_maneger>().Start();

                }
                else if (lvlN == 2)
                {
                    StickSave[IndexStik] = true;
                    PlayerPrefs.SetInt("StikID", IndexStik);
                    PlayerPrefs.Save();

                    //PersStik.SetActive(true);
                    //PersStik.GetComponent<Animation>().enabled = false;
                    //PersStik.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(pathResNow);

                    //if (IndexStik >= 26)
                    //{
                    //    PersStik.GetComponent<Animation>().enabled = true;
                    //    PersStik.GetComponent<Animation>().Play("PersScinRot");
                    //}
                    GameObject.Find("Pers").GetComponent<pers_maneger>().Start();

                }
                if (lvlN == 3)
                {
                    PlayerPrefs.SetInt("TrailID", IndexTrail);
                    PlayerPrefs.Save();
                    TrailSave[IndexTrail] = true;

                    //PersTrail.SetActive(true);
                    //PersTrail.GetComponent<TrailRenderer>().enabled = false;
                    //PersTrail.GetComponent<TrailRenderer>().colorGradient = Trail[IndexTrail].colorGradient;
                    //PersTrail.GetComponent<TrailRenderer>().enabled = true;
                    GameObject.Find("Pers").GetComponent<pers_maneger>().Start();

                }
                if (lvlN == 4)
                {
                    PlayerPrefs.SetInt("SoundID", IndexSound);
                    PlayerPrefs.Save();
                    GameObject.Find("Pers").GetComponent<pers_maneger>().Start();

                    //GameObject.Find("Main Camera/rightS").GetComponent<AudioSource>().clip = Sound[IndexSound];
                    //GameObject.Find("Main Camera/leftS").GetComponent<AudioSource>().clip = Sound[IndexSound];
                }
            }
            BuyBool = false;
        }

        bool rechoiseCheck()
        {
            if (lvlN == 1 && MatInd.sprite.name.Contains("buyed"))
            {
                return true;
            }
            else if (lvlN == 2 && SprInd.sprite.name.Contains("buyed"))
            {
                return true;
            }
            if (lvlN == 3 && TraInd.sprite.name.Contains("buyed"))
            {
                return true;
            }
            if (lvlN == 4 && SouInd.sprite.name.Contains("buyed"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BuyConfim(bool buy)
        {
            Debug.Log("Buy confim " + pathResNow);

            if (buy)
            {                      //покупка
                string[] indexTemp = pathResNow.Split('/');
                Debug.Log(pathResNow);
                //string path = pathResNow.Substring(0, pathResNow.LastIndexOf('/'));
                int index = Convert.ToInt32(indexTemp[indexTemp.Length - 1]);
                GameObject.Find("scipts").GetComponent<coinManger>().BuyItem(price);

                if (pathResNow.Contains("material"))
                {
                    PlayerPrefs.SetInt("materialID", index);
                    PlayerPrefs.Save();
                    MatSave[index] = true;
                    prChkMat();
                    //GameObject.Find("Pers/PersCinem").GetComponent<Renderer>().material = Resources.Load<Material>(pathResNow);
                    //if (pathResNow.Contains("18"))
                    //{
                    //    GameObject.Find("Pers/PersCinem").GetComponent<MaterialColorAll>().enabled = true;
                    //}
                    //else
                    //{
                    //    GameObject.Find("Pers/PersCinem").GetComponent<MaterialColorAll>().enabled = false;
                    //}
                    GameObject.Find("Pers").GetComponent<pers_maneger>().Start();

                }
                else if (pathResNow.Contains("Sprite"))
                {

                    StickSave[index] = true;
                    PlayerPrefs.SetInt("StikID", index);
                    PlayerPrefs.Save();

                    //PersStik.SetActive(true);
                    //PersStik.GetComponent<Animation>().enabled = false;
                    //PersStik.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(pathResNow);

                    //if (index >= 26)
                    //{
                    //    PersStik.GetComponent<Animation>().enabled = true;
                    //    PersStik.GetComponent<Animation>().Play("PersScinRot");
                    //}
                    GameObject.Find("Pers").GetComponent<pers_maneger>().Start();

                    prChkStik();
                }
                else if (pathResNow.Contains("TrailRender"))
                {
                    PlayerPrefs.SetInt("TrailID", index);
                    PlayerPrefs.Save();
                    TrailSave[index] = true;

                    //PersTrail.SetActive(true);
                    //PersTrail.GetComponent<TrailRenderer>().enabled = false;
                    //PersTrail.GetComponent<TrailRenderer>().enabled = true;
                    GameObject.Find("Pers").GetComponent<pers_maneger>().Start();

                    prChkTrail();
                }
                else if (pathResNow.Contains("sound"))
                {
                    PlayerPrefs.SetInt("SoundID", IndexSound);
                    PlayerPrefs.Save();
                    //GameObject.Find("Main Camera/rightS").GetComponent<AudioSource>().clip = Sound[index];
                    //GameObject.Find("Main Camera/leftS").GetComponent<AudioSource>().clip = Sound[index];
                    GameObject.Find("Pers").GetComponent<pers_maneger>().Start();

                    prChkSound();
                }

                Save();
            }
            else
            {
                PriceText.enabled = true;
            }
            BuyBool = false;


        }                               // подтверждение покупки 



        void Load()
        {


            using (StreamReader file = File.OpenText(Application.persistentDataPath + "/Mat.izg"))
            {
                for (int i = 0; i <= Mat.Length - 1; i++)
                {
                    MatSave[i] = Convert.ToBoolean(file.ReadLine());
                }
            }
            using (StreamReader file = File.OpenText(Application.persistentDataPath + "/Sti.izg"))
            {
                for (int i = 0; i <= Stik.Length - 1; i++)
                {
                    StickSave[i] = Convert.ToBoolean(file.ReadLine());
                }
            }

            using (StreamReader file = File.OpenText(Application.persistentDataPath + "/Tra.izg"))
            {
                for (int i = 0; i <= Trail.Length - 1; i++)
                {
                    TrailSave[i] = Convert.ToBoolean(file.ReadLine());
                }
            }
            using (StreamReader file = File.OpenText(Application.persistentDataPath + "/Sou.izg"))
            {
                for (int i = 0; i <= Sound.Length - 1; i++)
                {
                    SoundSave[i] = Convert.ToBoolean(file.ReadLine());
                }
            }
        }

        void Save()
        {

            using (StreamWriter file = new StreamWriter(Application.persistentDataPath + "/Mat.izg"))
            {
                for (int i = 0; i <= Mat.Length - 1; i++)
                {
                    file.WriteLine(MatSave[i]);
                }
            }
            using (StreamWriter file = new StreamWriter(Application.persistentDataPath + "/Sti.izg"))
            {
                for (int i = 0; i <= Stik.Length - 1; i++)
                {
                    file.WriteLine(StickSave[i]);
                }
            }
            using (StreamWriter file = new StreamWriter(Application.persistentDataPath + "/Tra.izg"))
            {
                for (int i = 0; i <= Trail.Length - 1; i++)
                {
                    file.WriteLine(TrailSave[i]);
                }
            }

            using (StreamWriter file = new StreamWriter(Application.persistentDataPath + "/Sou.izg"))
            {
                for (int i = 0; i <= Sound.Length - 1; i++)
                {
                    file.WriteLine(SoundSave[i]);
                }
            }


        }





        // Update is called once per frame
        void Update()
        {
            if (!BuyBool)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    startPos = Input.GetTouch(0).position;
                }
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                {

                    endPos = Input.GetTouch(0).position;


                    direction = startPos - endPos;


                    if ((startPos - endPos).magnitude <= 15)
                    {
                        Buy();
                    }
                    else
                    {
                        if ((direction.x > 0 && direction.x > direction.y) || ((direction.x <= 0 && direction.x < direction.y) && !(direction.y >= 0 && direction.y > direction.x)))
                        {
                            if (direction.x >= 0 && direction.x > direction.y)
                            {        //свайп влево 
                                if (lvlN == 1)
                                {
                                    MaterialManeger(false);
                                }
                                else if (lvlN == 2)
                                {
                                    StickManeger(false);
                                }
                                else if (lvlN == 3)
                                {
                                    TrailManeger(false);
                                }
                                else if (lvlN == 4)
                                {
                                    SoundManeger(false);
                                }

                            }
                            else if (direction.x <= 0 && direction.x < direction.y)
                            {           //свайп вправо
                                if (lvlN == 1)
                                {
                                    MaterialManeger(true);
                                }
                                else if (lvlN == 2)
                                {
                                    StickManeger(true);
                                }
                                else if (lvlN == 3)
                                {
                                    TrailManeger(true);
                                }
                                else if (lvlN == 4)
                                {
                                    SoundManeger(true);
                                }
                            }
                        }
                        else if (direction.y >= 0 && direction.y > direction.x)
                        {      //свайп ввверх
                            lvlN--;
                            SetLvl();
                        }
                        else if (direction.y <= 0 && direction.y < direction.x)
                        {      //свайп вниз

                            if (lvlN <= 3)
                            {
                                lvlN++;
                                SetLvl();
                            }
                        }
                    }
                }
            }

            ScrollMat.transform.position = Vector3.Lerp(ScrollMat.transform.position, new Vector3(PosMat, ScrollMat.transform.position.y, ScrollMat.transform.position.z), Time.deltaTime * 2f);
            gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Golvl, transform.position.z), Time.deltaTime * 1.5f);
        }
    }

    public class MainFirstSc : MonoBehaviour
    {
        public GameObject defBg;
        void Start()
        {
            if (PlayerPrefs.GetInt("FirstLoad") == 1)
            {
                SceneManager.LoadScene(1);
                defBg.SetActive(true);
                PlayerPrefs.SetInt("OpenApp", 0);
            }
        }

        public void SetLang(int l)
        {

            PlayerPrefs.SetInt("lg", l);
            PlayerPrefs.SetInt("materialID", 0);
            PlayerPrefs.SetInt("StikID", -1);
            PlayerPrefs.SetInt("TrailID", 0);
            PlayerPrefs.SetInt("SoundID", 0);
            PlayerPrefs.SetInt("OpenApp", 0);
            PlayerPrefs.SetInt("coin", 0);
            //PlayerPrefs.SetInt("coin", 20000);
            PlayerPrefs.SetInt("FirstLoad", 1);
            PlayerPrefs.SetFloat("Music", 0.6f);
            PlayerPrefs.SetFloat("AudioEff", 0.5f);
            PlayerPrefs.SetInt("MedidativeMod", 0);

            PlayerPrefs.Save();
            SceneManager.LoadScene(2);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public class MaterialColorAll : MonoBehaviour
    {

        Color32[] ColorPers = {
        new Color32(230,74,25,255),
        new Color32(245,124,0,255),
        new Color32(255,160,0,255),
        new Color32(251,192,45,255),
        new Color32(175,180,43,255),
        new Color32(104,159,56,255),
        new Color32(56,142,60,255),
        new Color32(0,121,107,255),
        new Color32(0,151,167,255),
        new Color32(2,136,209,255),
        new Color32(25,118,210,255),
        new Color32(48,63,159,255),
        new Color32(81,45,168,255),
        new Color32(123,31,162,255),
        new Color32(194,24,91,255),
        new Color32(211,47,47,255),
        new Color32(230,74,25,255),
    };

        int index = 1;

        IEnumerator LerpPers()
        {

            var timeStep = 0.0f;
            while (timeStep < 1.0f)
            {
                timeStep += Time.deltaTime / 5;
                gameObject.GetComponent<Renderer>().material.color = Color.Lerp(ColorPers[index - 1], ColorPers[index], timeStep);
                yield return null;
            }

        }


        void OnDisable()
        {
            StopAllCoroutines();
        }

        private void OnEnable()
        {
            index = 1;
            StartCoroutine(LerpPersControll());
        }

        IEnumerator LerpPersControll()
        {
            while (true)
            {
                StartCoroutine(LerpPers());
                yield return new WaitForSeconds(5f);
                if (ColorPers.Length - 1 <= index)
                {
                    index = 1;
                }
                else
                {
                    index++;
                }
            }
        }
    }

    public class MusicManeger : MonoBehaviour
    {
        AudioSource music;
        AudioClip NextAudio;
        float pitch = 1f;
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


        public void NextLvlSound(int lvl)
        {
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
            else if (lvl == 2)
            {
                do
                {
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

        private IEnumerator Switch()
        {
            Debug.Log("switch");
            while (music.volume >= 0.06)
            {
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

        IEnumerator PLayMusic()
        {


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



        public void OnPurchaseFail(Product product, PurchaseFailureReason purchase)
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

    public class Open : MonoBehaviour
    {
        public GameObject camera;
        public GameObject LogoIU;
        public GameObject MainUI;
        public bool start = false;
        // Start is called before the first frame update
        void Start()
        {
            //PlayerPrefs.DeleteKey("OpenApp");
            if (PlayerPrefs.GetInt("OpenApp") == 1)
            {
                camera.transform.position = new Vector3(camera.transform.position.x, 15f, -11f);
                MainUI.SetActive(true);
                LogoIU.SetActive(false);
            }

        }

        private void StartManegerLogo()
        {
            start = false;

            PlayerPrefs.SetInt("OpenApp", 1);
            PlayerPrefs.Save();
            StartCoroutine(DisableLogo());
        }

        private void Update()
        {
            if (start)
            {
                StartManegerLogo();
            }
        }
        IEnumerator DisableLogo()
        {
            yield return new WaitForSecondsRealtime(1.5f);
            MainUI.SetActive(true);
            LogoIU.SetActive(false);
        }
    }

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

        public GameObject Stick, Trail;

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
            gameObject.transform.Find("PersCinem").GetComponent<Renderer>().material = Resources.Load<Material>("prefab/Skin/material/" + PlayerPrefs.GetInt("materialID"));
            if (PlayerPrefs.GetInt("materialID") >= 16)
            {
                MaterialColorall.enabled = true;
            }
            else
            {
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

            if (PlayerPrefs.GetInt("TrailID") >= 0)
            {
                Trail.SetActive(true);
                Trail.GetComponent<TrailRenderer>().enabled = false;
                Trail.GetComponent<TrailRenderer>().colorGradient = Resources.Load<GameObject>("TrailRender/" + PlayerPrefs.GetInt("TrailID")).GetComponent<TrailRenderer>().colorGradient;
                Trail.GetComponent<TrailRenderer>().enabled = true;
            }

            if (PlayerPrefs.GetInt("SoundID") >= 0)
            {
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


        void SledNow()
        {
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
        public void Godeat()
        {
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
            else
            {
                goSled = false;
                gameObject.transform.SetParent(null);
            }
        }


        private void FixedUpdate()
        {

            if (goSled)
            {
                GameObject temp = Instantiate(sledSp, sled);
                float sledScale = Random.Range(0.4f, 1.1f);
                temp.transform.localScale = new Vector3(sledScale, sledScale, 0);
                temp.transform.localEulerAngles = new Vector3(0, -90, Random.Range(0, 360));
                temp.GetComponent<SpriteRenderer>().color = new Color(persColor.color.r, persColor.color.g, persColor.color.b, Random.Range(0.4f, 1));
                temp.transform.SetParent(BordeNow);

            }
        }
    }

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

            if (PlayerPrefs.GetInt("lg") == 0)
            {
                Music.text = "Music";
                audio.text = "Sounds";
                checkbox.text = "Meditative mode";
                descr.text = "*In meditation mode, only peaks of the wall are present as obstacles";
            }
            else
            {
                Music.text = "Музыка";
                audio.text = "Звуки";
                checkbox.text = "Медитативный режим";
                descr.text = "*В медитативном режиме присутствуют только настенные шипы в качестве препятствий";
            }

        }

        public void MedMod(bool ck)
        {
            if (ck)
            {
                PlayerPrefs.SetInt("MedidativeMod", 1);
            }
            else
            {
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

        public void Show()
        {
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

    public class Tutorial : MonoBehaviour
    {
        public Text Rewer, Add, Setting, Play, Market;



        void Start()
        {
            if (PlayerPrefs.GetInt("Tutorial") == 1)
            {
                gameObject.SetActive(false);
            }
            else
            {

                StartCoroutine(Tutor());
                SetLang();
            }
        }

        void SetLang()
        {
            if (PlayerPrefs.GetInt("lg") == 0)
            {
                Rewer.text = "Reward Videos ->";
                Add.text = "Disable ads ->";
                Setting.text = "Select another mode->";
                Play.text = "Touch here to start the game";
                Market.text = "Touch here to open a store";
            }
            else
            {
                Rewer.text = "Видео за вознаграждение ->";
                Add.text = "Отключи рекламу ->";
                Setting.text = "Выбери другой режим ->";
                Play.text = "Нажми тут что бы начать игру";
                Market.text = "Нажми тут что бы открыть магазин";
            }
            PlayerPrefs.SetInt("Tutorial", 1);
            PlayerPrefs.Save();
        }

        IEnumerator Tutor()
        {
            yield return new WaitForSeconds(3f);
            gameObject.GetComponent<Button>().enabled = true;
        }
    }
}
*/