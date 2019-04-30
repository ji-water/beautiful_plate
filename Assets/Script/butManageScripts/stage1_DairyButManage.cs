using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_DairyButManage : MonoBehaviour
{
    public static GameObject tapDairy1;
    public static GameObject cheddarcheese_But;
    public static GameObject cheese_But;
    public static GameObject mozzacheese_But;
    public static GameObject cream_But;

    public static GameObject tapDairy2;
    public static GameObject icecream_But;

    // Start is called before the first frame update
    void Start()
    {
        tapDairy1 = GameObject.Find("tapDairy1");
        cheddarcheese_But = GameObject.Find("cheddarcheese_But");
        cheese_But = GameObject.Find("cheese_But");
        mozzacheese_But = GameObject.Find("mozzacheese_But");
        cream_But = GameObject.Find("cream_But");

        tapDairy2 = GameObject.Find("tapDairy2");
        icecream_But = GameObject.Find("icecream_But");

        tapDairy1Invisible();
        tapDairy2Invisible();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        stage1_moveButManage.inventoryVisible(); //인벤토리 창으로
        tapDairy1Visible();
        stage1_moveButManage.moveButVisible(); //인벤토리 버튼들 활성화
        stage1_moveButManage.currentTab = "tapDairy1"; //채소창 1쪽
    }

    public static void tapDairy1Visible()
    {
        for (int i = 0; i < tapDairy1.transform.childCount; i++)
        {
            tapDairy1.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public static void tapDairy1Invisible()
    {
        for (int i = 0; i < tapDairy1.transform.childCount; i++)
        {
            tapDairy1.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public static void tapDairy2Visible()
    {
        for (int i = 0; i < tapDairy2.transform.childCount; i++)
        {
            tapDairy2.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public static void tapDairy2Invisible()
    {
        for (int i = 0; i < tapDairy2.transform.childCount; i++)
        {
            tapDairy2.transform.GetChild(i).gameObject.SetActive(false);

        }
    }



    public static void AllusedCheddarcheese()
    {
        cheddarcheese_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        cheddarcheese_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockCheddarcheese()
    {
        cheddarcheese_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("dairyBut/cheddarcheese_But", typeof(Sprite)) as Sprite;
        cheddarcheese_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedCheese()
    {
        cheese_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        cheese_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockCheese()
    {
        cheese_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("dairyBut/cheese_But", typeof(Sprite)) as Sprite;
        cheese_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedMozzacheese()
    {
        mozzacheese_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        mozzacheese_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockMozzacheese()
    {
        mozzacheese_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("dairyBut/mozzacheese_But", typeof(Sprite)) as Sprite;
        mozzacheese_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedCream()
    {
        cream_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        cream_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockCream()
    {
        cream_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("dairyBut/cream_But", typeof(Sprite)) as Sprite;
        cream_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedIcecream()
    {
        icecream_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        icecream_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockIcecream()
    {
        icecream_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("dairyBut/icecream_But", typeof(Sprite)) as Sprite;
        icecream_But.GetComponent<BoxCollider2D>().enabled = true;
    }
}
