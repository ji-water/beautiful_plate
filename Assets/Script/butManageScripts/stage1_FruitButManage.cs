using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_FruitButManage : MonoBehaviour
{
    public static GameObject tapFruit1;
    public static GameObject apple_But;
    public static GameObject avocado_But;
    public static GameObject blueberry_But;
    public static GameObject cherry_But;


    public static GameObject tapFruit2;
    public static GameObject lemon_But;
    public static GameObject orange_But;
    public static GameObject strawberry_But;
    // Start is called before the first frame update
    void Start()
    {
        tapFruit1 = GameObject.Find("tapFruit1");
        apple_But = GameObject.Find("apple_But");
        avocado_But = GameObject.Find("avocado_But");
        blueberry_But = GameObject.Find("blueberry_But");
        cherry_But = GameObject.Find("cherry_But");

        tapFruit2 = GameObject.Find("tapFruit2");
        lemon_But = GameObject.Find("lemon_But");
        orange_But = GameObject.Find("orange_But");
        strawberry_But = GameObject.Find("strawberry_But");
        tapFruit1Invisible();
        tapFruit2Invisible();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        stage1_moveButManage.inventoryVisible(); //인벤토리 창으로
        tapFruit1Visible();
        stage1_moveButManage.moveButVisible(); //인벤토리 버튼들 활성화
        stage1_moveButManage.currentTab = "tapFruit1"; //채소창 1쪽
    }

    public static void tapFruit1Visible()
    {
        for (int i = 0; i < tapFruit1.transform.childCount; i++)
        {
            tapFruit1.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public static void tapFruit1Invisible()
    {
        for (int i = 0; i < tapFruit1.transform.childCount; i++)
        {
            tapFruit1.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public static void tapFruit2Visible()
    {
        for (int i = 0; i < tapFruit2.transform.childCount; i++)
        {
            tapFruit2.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public static void tapFruit2Invisible()
    {
        for (int i = 0; i < tapFruit2.transform.childCount; i++)
        {
            tapFruit2.transform.GetChild(i).gameObject.SetActive(false);

        }
    }

    public static void AllusedApple()
    {     //사과 모두 소진시 선택할 수 없음
        apple_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        apple_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockApple()
    {
        apple_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("fruitBut/apple_But", typeof(Sprite)) as Sprite;
        apple_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedAvocado()
    {    
        avocado_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        avocado_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockAvocado()
    {
        avocado_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("fruitBut/avocado_But", typeof(Sprite)) as Sprite;
        avocado_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedBlueberry()
    {
       blueberry_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        blueberry_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockBlueberry()
    {
        blueberry_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("fruitBut/blueberry_But", typeof(Sprite)) as Sprite;
        blueberry_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedCherry()
    {
        cherry_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        cherry_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockCherry()
    {
        cherry_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("fruitBut/cherry_But", typeof(Sprite)) as Sprite;
        cherry_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedLemon()
    {
        lemon_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        lemon_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockLemon()
    {
        lemon_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("fruitBut/lemon_But", typeof(Sprite)) as Sprite;
        lemon_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedOrange()
    {
        orange_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        orange_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockOrange()
    {
        orange_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("fruitBut/orange_But", typeof(Sprite)) as Sprite;
        orange_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedStrawberry()
    {
        strawberry_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        strawberry_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockStrawberry()
    {
        strawberry_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("fruitBut/strawberry_But", typeof(Sprite)) as Sprite;
        strawberry_But.GetComponent<BoxCollider2D>().enabled = true;
    }
}