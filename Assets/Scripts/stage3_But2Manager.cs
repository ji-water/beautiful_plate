using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//재료탭2-과일
public class stage3_But2Manager : MonoBehaviour
{
    static GameObject apple;
    static GameObject avocado;
    static GameObject lemon;
    static GameObject orange;
    static GameObject strawberry;

    static GameObject but2tab1;
    static GameObject but2tab2;

    static int tab;

    void Start()
    {
        apple = GameObject.Find("apple_But");
        avocado = GameObject.Find("avocado_But");
        lemon = GameObject.Find("lemon_But");
        orange = GameObject.Find("orange_But");
        strawberry = GameObject.Find("strawberry_But");

        but2tab1 = GameObject.Find("But2_tab1");
        but2tab2 = GameObject.Find("But2_tab2");

        SetOFFIngredient();
    }

    //현재 탭의 재료 모두 비활성화
    public static void SetOFFIngredient()
    {
        but2tab1.SetActive(false);
        but2tab2.SetActive(false);
    }

    //tab관리
    public static void SetTAB()
    {
        if (tab == 1)
        {
            but2tab1.SetActive(false);
            but2tab2.SetActive(true);
            tab = 2;
        }
        else if (tab == 2)
        {
            but2tab1.SetActive(true);
            but2tab2.SetActive(false);
            tab = 1;
        }
    }

    //재료 소진
    public static void UseAll(int ingredient)
    {
        switch (ingredient)
        {
            case 0: //apple
                SetOFF(apple);
                break;
            case 1: //avocado
                SetOFF(avocado);
                break;
            case 2: //lemon
                SetOFF(lemon);
                break;
            case 3: //orange
                SetOFF(orange);
                break;
            case 4: //strawberry
                SetOFF(strawberry);
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
            case 0: //apple
                SetON(apple);
                break;
            case 1: //avocado
                SetON(avocado);
                break;
            case 2: //lemon
                SetON(lemon);
                break;
            case 3: //orange
                SetON(orange);
                break;
            case 4: //strawberry
                SetON(strawberry);
                break;
        }
    }

    //버튼탭2 클릭시 현재 탭 재료 활성화
    private void OnMouseDown()
    {
        stage3_ButtonManager.ButtonUnActivate(2);
        tab = 1;
        but2tab1.SetActive(true);
    }
}
