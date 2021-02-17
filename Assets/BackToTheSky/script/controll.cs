using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

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

    public void StartGame() {
        GameObject.Find("scipts").GetComponent<grad_background>().start_game();

        StartCoroutine(StartDetectTouch());
        int Record = PlayerPrefs.GetInt("Record");
        if (Record >=2) {
            GameObject temp = Instantiate(PrevRecText);
            temp.transform.position = new Vector3(-5, Record,0);
            temp.GetComponent<TextMesh>().text = "_______________________"+ Record.ToString() +"_______________________";
        }
    }

        IEnumerator StartDetectTouch() {
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
            if (direction.x > 0) {
                direction = new Vector2(direction.x + 150, direction.y);

            }
            if (direction.x > 0 && direction.x > directoinX)
            {
                direction = new Vector2(directoinX, direction.y);
            }
            else if (direction.x < 0 && direction.x < -directoinX) {

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

    int iOffDeat=0;
    void off_terrain() {
        if (iOffDeat >= 0 && iOffDeat <=4)
        {

            GameObject.Find("Terrain").GetComponent<BoxCollider>().isTrigger = true;
            StartDeatCube.SetActive(true);
        }
        iOffDeat++;
    }

    private void FixedUpdate()
    {
        if (PlayerMax >= NextLvl) {
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
