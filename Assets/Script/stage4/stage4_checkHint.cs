﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//hint에 붙음
public class stage4_checkHint : MonoBehaviour
{

    public Transform platingSample1, platingSample2, platingSample3, platingSample4,platingSample5, platingSample6;

    public static Transform hintSample;
    Vector2 hintPosition = new Vector2(0,-0.45f);

    public static GameObject allTransparent;

    public static bool hintOn = false;

    //hint count
    public static GameObject hintCount;

    void Start()
    {
        hintOn = false;

        allTransparent = GameObject.Find("allTransparent");
        allTransparent.SetActive(false);

        //hint count
        hintCount = GameObject.Find("hint3");

    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if (stage4_submitClick.hintCount <3) {
            if (!hintOn)
            {

                //hint count
                switch (stage4_submitClick.hintCount)
                {
                    case 0:
                        hintCount.GetComponent<SpriteRenderer>().sprite = Resources.Load("Hint/hint2", typeof(Sprite)) as Sprite;
                        break;
                    case 1:
                        hintCount.GetComponent<SpriteRenderer>().sprite = Resources.Load("Hint/hint1", typeof(Sprite)) as Sprite;
                        break;
                    case 2:
                        hintCount.SetActive(false);
                        break;
                }

                stage1_plating.makeInvisible();
                allTransparent.SetActive(true); //화면 클릭 막음

                if (stage4_timerManage.currentSample == "platingSample1")
                {
                    hintSample = (Transform)Instantiate(platingSample1, hintPosition, platingSample1.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage4_timerManage.currentSample == "platingSample2")
                {
                    hintSample = (Transform)Instantiate(platingSample2, hintPosition, platingSample2.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage4_timerManage.currentSample == "platingSample3")
                {
                    hintSample = (Transform)Instantiate(platingSample3, hintPosition, platingSample3.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage4_timerManage.currentSample == "platingSample4")
                {
                    hintSample = (Transform)Instantiate(platingSample4, hintPosition, platingSample4.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage4_timerManage.currentSample == "platingSample5")
                {
                    hintSample = (Transform)Instantiate(platingSample5, hintPosition, platingSample4.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage4_timerManage.currentSample == "platingSample6")
                {
                    hintSample = (Transform)Instantiate(platingSample6, hintPosition, platingSample4.rotation); //요리 샘플 clone생성(transform)
                }

                // Invoke("makeVisible", hintTime); //3초뒤에 makeVisible함수 호출
                // Destroy(hintSample.gameObject, hintTime);//3초뒤에 샘플 삭제

                // hintCount++;
                stage4_submitClick.hintCount++; //힌트=>plating당 한번만 가능

                hintOn = true; //힌트 보고있는 상태
            }
        }
        //else if(hintOn){
        //    makeVisible();
        //    Destroy(hintSample.gameObject);
        //    hintOn = false;
        //}
    }
    void makeVisible()
    {
        //platedParent 자식들 찾아서 활성화
        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            stage1_plating.platedParent.transform.GetChild(i).gameObject.SetActive(true);
           
        }
        allTransparent.SetActive(false);
    }
   
}
