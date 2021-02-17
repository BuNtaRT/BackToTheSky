using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Color_Index = Random.Range(0,14);
        Color32[] ColorUnPack = new Color32[2];
        ColorUnPack = ColorList[Color_Index];
        downC = ColorUnPack[0]; 
        centerC = ColorUnPack[1]; 
        upC = ColorUnPack[2];
                                                     // следующие цвета 
        ColorUnPack = ColorList[Color_Index+1];
        downNext = ColorUnPack[0];
        centerNext = ColorUnPack[1];
        upNext = ColorUnPack[2];
                                                    // ставим цвета 
        down.GetComponent<Renderer>().material.color = downC;
        up.GetComponent<Renderer>().material.color = upC;
        center.GetComponent<Renderer>().material.color = centerC;

    }

    bool start = false;

    public void start_game() {
        StartCoroutine(Switch_color());
    }

    Color32 upC, downC, centerC;
    Color32 upNext, downNext, centerNext;
    int Switch_color_mode = 0; // когда достигает 16 заднику задаются цвета из разных массивов для каждого элемента

    bool del_collor_once = true;
    void dell_color() {
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


    IEnumerator Switch_color() {
        //yield return new WaitForSeconds(6f);

        while (true)
        {
            if (timeSteapSwitch_color >= 6) {
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


    IEnumerator LerpBG() {

        var timeStep = 0.0f;
        while (timeStep < 1.0f)
        {
            timeStep += Time.deltaTime / timeSteapSwitch_color;
            down.GetComponent<Renderer>().material.color = Color.Lerp(downC,downNext, timeStep);
            center.GetComponent<Renderer>().material.color = Color.Lerp(centerC,centerNext, timeStep);
            up.GetComponent<Renderer>().material.color = Color.Lerp(upC,upNext, timeStep);
            yield return null;
        }

    }

    // Update is called once per frame
    void Update()
    {


    }
}
