using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//title1-title2 전환 코드
//게임선택창 - 스테이지선택창 전환

public class titleManage : MonoBehaviour
{
    static GameObject title0;
    static GameObject title1;
    static GameObject title2;

    
    void Start()
    { 

        title0 = GameObject.Find("title0");
        title1 = GameObject.Find("title1");
        title2 = GameObject.Find("title2");

        title1.SetActive(false);
        title2.SetActive(false);
    }

    public static void changeTitle(int num)
    {
        switch (num)
        {
            case 0: //main
                title0.SetActive(false);
                title1.SetActive(true);
                break;
            case 1: //title1
                title1.SetActive(true);
                title2.SetActive(false);
                break;
            case 2: //title2
                title2.SetActive(true);
                stageManage.stage_check();
                title1.SetActive(false);
                break;
        }
    }
}
