using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//drawerDeco에 붙어 데코 탭 관리

public class tutorial_DecoButManage : MonoBehaviour
{

    public static GameObject tapDeco1;
    public static GameObject caramelsyrup_But;
    public static GameObject chocosyrup_But;
    public static GameObject ketchup_But;
    public static GameObject mayonnaise_But;

    public static GameObject tapDeco2;
    public static GameObject gochujang_But;
    public static GameObject ice_But;
    // Start is called before the first frame update
    void Start()
    {
        tapDeco1 = GameObject.Find("tapDeco1");
        caramelsyrup_But = GameObject.Find("caramelsyrup_But");
        chocosyrup_But = GameObject.Find("chocosyrup_But");
        ketchup_But = GameObject.Find("ketchup_But");
        mayonnaise_But = GameObject.Find("mayonnaise_But");

        tapDeco2 = GameObject.Find("tapDeco2");
        gochujang_But = GameObject.Find("gochujang_But");
        ice_But = GameObject.Find("ice_But");

        tapDeco1Invisible();
        tapDeco2Invisible();
    }

    private void OnMouseDown()
    {
        stage1_moveButManage.inventoryVisible(); //인벤토리 창으로
        tapDeco1Visible();
        stage1_moveButManage.moveButVisible(); //인벤토리 버튼들 활성화
        stage1_moveButManage.currentTab = "tapDeco1"; //채소창 1쪽
    }

    public static void tapDeco1Visible()
    {
        for (int i = 0; i < tapDeco1.transform.childCount; i++)
        {
            tapDeco1.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public static void tapDeco1Invisible()
    {
        for (int i = 0; i < tapDeco1.transform.childCount; i++)
        {
            tapDeco1.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public static void tapDeco2Visible()
    {
        for (int i = 0; i < tapDeco2.transform.childCount; i++)
        {
            tapDeco2.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public static void tapDeco2Invisible()
    {
        for (int i = 0; i < tapDeco2.transform.childCount; i++)
        {
            tapDeco2.transform.GetChild(i).gameObject.SetActive(false);

        }
    }

    public static void AllusedCaramelsyrup()
    {
        caramelsyrup_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        caramelsyrup_But.GetComponent<BoxCollider2D>().enabled = false;
        tuto_plating.touchedName = null;
    }
    public static void RestockCaramelsyrup()
    {
        caramelsyrup_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("decoBut/caramelsyrup_But", typeof(Sprite)) as Sprite;
        caramelsyrup_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedChocosyrup()
    {
        chocosyrup_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        chocosyrup_But.GetComponent<BoxCollider2D>().enabled = false;
        tuto_plating.touchedName = null;
    }
    public static void RestockChocosyrup()
    {
        chocosyrup_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("decoBut/chocosyrup_But", typeof(Sprite)) as Sprite;
        chocosyrup_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedKetchup()
    {
        ketchup_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        ketchup_But.GetComponent<BoxCollider2D>().enabled = false;
        tuto_plating.touchedName = null;
    }
    public static void RestockKetchup()
    {
        ketchup_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("decoBut/ketchup_But", typeof(Sprite)) as Sprite;
        ketchup_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedMayonnaise()
    {
        mayonnaise_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        mayonnaise_But.GetComponent<BoxCollider2D>().enabled = false;
        tuto_plating.touchedName = null;
    }
    public static void RestockMayonnaise()
    {
        mayonnaise_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("decoBut/mayonnaise_But", typeof(Sprite)) as Sprite;
        mayonnaise_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedGochujang()
    {
        gochujang_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        gochujang_But.GetComponent<BoxCollider2D>().enabled = false;
        tuto_plating.touchedName = null;
    }
    public static void RestockGochujang()
    {
        gochujang_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("decoBut/gochujang_But", typeof(Sprite)) as Sprite;
        gochujang_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedIce()
    {
        ice_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        ice_But.GetComponent<BoxCollider2D>().enabled = false;
        tuto_plating.touchedName = null;
    }
    public static void RestockIce()
    {
        ice_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("decoBut/ice_But", typeof(Sprite)) as Sprite;
        ice_But.GetComponent<BoxCollider2D>().enabled = true;
    }
}
