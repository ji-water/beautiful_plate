using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//재료탭1-채소
public class stage3_But1Manager : MonoBehaviour
{
    static GameObject asparagus;
    static GameObject basil;
    static GameObject broccoli;
    static GameObject carrot;
    static GameObject cherrytomato;
    static GameObject cucumber;
    static GameObject paprika;
    static GameObject radishsprout;

    static GameObject but1tab1;
    static GameObject but1tab2;

    static int tab; //현재 보여지는 tab num 저장

    void Start()
    {
        but1tab1 = GameObject.Find("But1_tab1");
        but1tab2 = GameObject.Find("But1_tab2");

        asparagus = GameObject.Find("asparagus_But");
        basil = GameObject.Find("basil_But");
        broccoli = GameObject.Find("broccoli_But");
        carrot = GameObject.Find("carrot_But");
        cherrytomato = GameObject.Find("cherrytomato_But");
        cucumber = GameObject.Find("cucumber_But");
        paprika = GameObject.Find("paprika_But");
        radishsprout = GameObject.Find("radishsprout_But");

        tab = 1;
        SetOFFIngredient();
    }

    //모든탭끄기
    public static void SetOFFIngredient()
    {
        but1tab1.SetActive(false);
        but1tab2.SetActive(false);
    }

    //tab
    public static void SetTAB()
    {
        if (tab == 1)
        {
            but1tab1.SetActive(false);
            but1tab2.SetActive(true);
            tab = 2;
        }
        else if (tab == 2)
        {
            but1tab1.SetActive(true);
            but1tab2.SetActive(false);
            tab = 1;
        }
    }

    //재료 소진
    public static void UseAll(int ingredient)
    {
        switch (ingredient)
        {
            case 0: //아스파라거스
                SetOFF(asparagus);
                break;
            case 1: //바질
                SetOFF(basil);
                break;
            case 2: //브로콜리
                SetOFF(broccoli);
                break;
            case 3: //당근
                SetOFF(carrot);
                break;
            case 4: //방울토마토
                SetOFF(cherrytomato);
                break;
            case 5: //오이
                SetOFF(cucumber);
                break;
            case 6: //파프리카
                SetOFF(paprika);
                break;
            case 7: //무순
                SetOFF(radishsprout);
                break;
        }
    }

    static void SetOFF(GameObject ingredient)
    {
        ingredient.GetComponent<SpriteRenderer>().color = Color.gray;
        ingredient.GetComponent<BoxCollider2D>().enabled = false;
    }

    static void SetON(GameObject ingredient)
    {
        ingredient.GetComponent<SpriteRenderer>().color = Color.white;
        ingredient.GetComponent<BoxCollider2D>().enabled = true;
    }

    //재료 충전
    public static void Restock(int ingredient)
    {
        switch (ingredient)
        {
            case 0: //아스파라거스
                SetON(asparagus);
                break;
            case 1: //바질
                SetON(basil);
                break;
            case 2: //브로콜리
                SetON(broccoli);
                break;
            case 3: //당근
                SetON(carrot);
                break;
            case 4: //방울토마토
                SetON(cherrytomato);
                break;
            case 5: //오이
                SetON(cucumber);
                break;
            case 6: //파프리카
                SetON(paprika);
                break;
            case 7: //무순
                SetON(radishsprout);
                break;
        }
    }

    //재료탭 눌렀을때 현재 탭 재료 보여준다
    private void OnMouseDown()
    {
        stage3_ButtonManager.ButtonUnActivate(1);
        tab = 1;
        but1tab1.SetActive(true);
        //다음버튼 누르면 다음거 보여주도록 해야함..
    }
}
