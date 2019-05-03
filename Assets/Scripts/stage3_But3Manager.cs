using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selectbut3에 붙어있으며 but3 tab 관리
public class stage3_But3Manager : MonoBehaviour
{
    static GameObject cheddar;
    static GameObject cheese;
    static GameObject mozza;

    static GameObject but3tab1;
    static int tab;

    // Start is called before the first frame update
    void Start()
    {
        cheddar = GameObject.Find("cheddarcheese_But");
        cheese = GameObject.Find("cheese_But");
        mozza = GameObject.Find("mozzacheese_But");

        but3tab1 = GameObject.Find("But3_tab1");

        SetOFFIngredient();
    }

    //현재 탭의 재료 모두 비활성화
    public static void SetOFFIngredient()
    {
        but3tab1.SetActive(false);
    }

    //tab관리
    public static void SetTAB()
    {
    }

    //재료 소진
    public static void UseAll(int ingredient)
    {
        switch (ingredient)
        {
            case 0: //cheddar
                SetOFF(cheddar);
                break;
            case 1: //cheese
                SetOFF(cheese);
                break;
            case 2: //mozza
                SetOFF(mozza);
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
            case 0: 
                SetON(cheddar);
                break;
            case 1: 
                SetON(cheese);
                break;
            case 2: 
                SetON(mozza);
                break;
        }
    }

    //버튼탭2 클릭시 현재 탭 재료 활성화
    private void OnMouseDown()
    {
        stage3_ButtonManager.ButtonUnActivate(3);
        tab = 1;
        but3tab1.SetActive(true);
    }
}
