using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.UI;

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
    public Sprite [] Stik = new Sprite[1];                                      // и стикерами 
    public TrailRenderer[] Trail = new TrailRenderer[1];                        // и эфектами 
    public AudioClip[] Sound = new AudioClip[1];                              // и звуками 
    GameObject ScrollMat,ScrollStic,ScrollTrail,ScrollSound;                    // скролы, ни слова больше
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

    float PosMat=0;                                                             // положение скрола для материалов 

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
            using (StreamWriter file = File.CreateText(Application.persistentDataPath + "/Mat.izg")){
                for (int i =0; i <= Mat.Length-1; i++) {
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
            using (StreamWriter file = File.CreateText(Application.persistentDataPath + "/Sti.izg")){
                for (int i = 0; i <= Stik.Length - 1; i++)
                {
                    file.WriteLine(false);
                }
            }
            using (StreamWriter file = File.CreateText(Application.persistentDataPath + "/Tra.izg")){
                for (int i = 0; i <= Trail.Length - 1; i++)
                {
                    file.WriteLine(false);
                }
            }
            using (StreamWriter file = File.CreateText(Application.persistentDataPath + "/Sou.izg")){
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
        else {
            language = true;
        }
        ScrollMat = GameObject.Find("magazin/Material/Scroll");
        ScrollStic = GameObject.Find("magazin/Stiker/Scroll/DemonstrationCubeStick");
        ScrollTrail = GameObject.Find("magazin/Trail/Scroll/DemonstrationCubeStick");
        ScrollSound = GameObject.Find("magazin/Sound/Scroll");
    }

    public void SetLvl() {                                                  // ставим уровень магазина для камеры и включаем свейт там где надо 
        
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
                else {
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

    void setPrice() {

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
                else if(IndexMat==16) {
                    price = 1500;
                }
                break;
            case 2:
                Path = "Sprite/skinSp/" + IndexStik.ToString();
                if (IndexStik <= 12) {
                    price = 300;
                }
                else if (IndexStik <= 25) {
                    price = 600;
                }
                else if (IndexStik <= 33) {
                    price = 800;
                }
                break;
            case 3:
                Path = "TrailRender/" + IndexTrail.ToString();
                if (IndexTrail == 0) {
                    price = 200;
                }
                else if (IndexTrail <= 9) {
                    price = 500;
                }
                else if (IndexTrail <= 57) {
                    price = 650;
                }
                else if (IndexTrail <= 59) {
                    price = 800;
                }
                break;

            case 4:
                Path = "sound/JUmp/" + IndexSound.ToString();
                if (IndexSound <= 8)
                {
                    price = 300;
                }
                else {
                    price = 500;
                }
                break;
        }

        pathResNow = Path;
        if (language == false)
        {
            PriceText.text = "Price " + price.ToString();
        }
        else {
            PriceText.text = "Цена " + price.ToString();
        }
    }                                       //ставим цену за предмет


    private void MaterialManeger(bool right) {

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
            if (IndexMat < Mat.Length-1 )
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
            if (IndexStik < Stik.Length -1)
            {
                IndexStik++;
                StartCoroutine(SetStick());
                setPrice();

            }
        }
    }                  // управляем стикерами

    IEnumerator SetStick() {                                            //установка стикера
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
        else {
            AnimateSprite.enabled = false;
            ScrollStic.transform.Find("Skin/Sprite").transform.eulerAngles = new Vector3(0,0,0);
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

    private void SoundManeger(bool right) {
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
    private void prChkMat() {
        PriceText.enabled = true;
        if (MatSave[IndexMat] == false)
        {
            MatInd.sprite = Pay;
        }
        else {
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

    private void Buy() {

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
                    BuyBool = true;
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
        else{
            BuyBool = true;
            RechoiseWindow.SetActive(true);
            if (PlayerPrefs.GetInt("lg") == 0)
            {
                RechoiseWindow.transform.Find("bg/Text").GetComponent<Text>().text = "Choose again ?";
                RechoiseWindow.transform.Find("bg/DontI/Text").GetComponent<Text>().text = "Not";
                RechoiseWindow.transform.Find("bg/YesI/Text").GetComponent<Text>().text = "Yes";
            }
            else {
                RechoiseWindow.transform.Find("bg/Text").GetComponent<Text>().text = "Выбрать снова ?";
                RechoiseWindow.transform.Find("bg/DontI/Text").GetComponent<Text>().text = "Нет";
                RechoiseWindow.transform.Find("bg/YesI/Text").GetComponent<Text>().text = "Да";
            }
        }


    }                                    // пользователь хочет что то купить ?? ну тогда выведим сообщение если предмет еще не куплен

    public void RechoiseConfim(bool conf) {
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
            if (lvlN == 3 )
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

    bool rechoiseCheck() {
        if (lvlN == 1 && MatInd.sprite.name.Contains("buyed")) {
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
        else {
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
                SoundSave[index] = true;
                //GameObject.Find("Main Camera/rightS").GetComponent<AudioSource>().clip = Sound[index];
                //GameObject.Find("Main Camera/leftS").GetComponent<AudioSource>().clip = Sound[index];
                GameObject.Find("Pers").GetComponent<pers_maneger>().Start();

                prChkSound();
            }

            Save();
        }
        else {
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

    void Save() {

        using (StreamWriter file =  new StreamWriter(Application.persistentDataPath + "/Mat.izg"))
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

    public void errorWindowClose() {
        BuyBool = false;
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

        ScrollMat.transform.position = Vector3.Lerp(ScrollMat.transform.position, new Vector3(PosMat,ScrollMat.transform.position.y, ScrollMat.transform.position.z), Time.deltaTime *2f);
        gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Golvl, transform.position.z), Time.deltaTime * 1.5f);
    }
}
