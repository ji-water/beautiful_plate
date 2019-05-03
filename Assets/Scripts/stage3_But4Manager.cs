using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3_But4Manager : MonoBehaviour
{
    static GameObject choco;
    static GameObject caramel;
    static GameObject ketchup;
    static GameObject mayo;

    static GameObject but4tab1;
    static GameObject but4tab2;
    static int tab;

    // Start is called before the first frame update
    void Start()
    {
        choco = GameObject.Find("chocosyrup_But");
        caramel = GameObject.Find("caramelsyrup_But");
        ketchup = GameObject.Find("ketchup_But");
        mayo = GameObject.Find("mayonnaise_But");

        but4tab1 = GameObject.Find("But4_tab1");
        but4tab2 = GameObject.Find("But4_tab2");

        SetOFFIngredient();
    }

    //현재 탭의 재료 모두 비활성화
    public static void SetOFFIngredient()
    {
        but4tab1.SetActive(false);
        but4tab2.SetActive(false);
    }

    //tab관리
    public static void SetTAB()
    {
        if (tab == 1)
        {
            but4tab1.SetActive(false);
            but4tab2.SetActive(true);
            tab = 2;
        }
        else if (tab == 2)
        {
            but4tab1.SetActive(true);
            but4tab2.SetActive(false);
            tab = 1;
        }

    }

    //재료 소진
    public static void UseAll(int ingredient)
    {
        switch (ingredient)
        {
            case 0: //caramel
                SetOFF(caramel);
                break;
            case 1: //choco
                SetOFF(choco);
                break;
            case 2: //ketchup
                SetOFF(ketchup);
                break;
            case 3: //mayo
                SetOFF(mayo);
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
                SetON(caramel);
                break;
            case 1:
                SetON(choco);
                break;
            case 2:
                SetON(ketchup);
                break;
            case 3:
                SetON(mayo);
                break;
        }
    }

    //현재 탭 재료 활성화
    private void OnMouseDown()
    {
        stage3_ButtonManager.ButtonUnActivate(4);
        tab = 1;
        but4tab1.SetActive(true);
    }


}
