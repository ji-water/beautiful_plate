using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_BaseButManage : MonoBehaviour
{

    public static GameObject tapBase1;
    public static GameObject bread_But;
    public static GameObject broth_But;
    public static GameObject cake_But;
    public static GameObject dumpling_But;

    public static GameObject tapBase2;
    public static GameObject fish_But;
    public static GameObject Ivy_But;
    public static GameObject noodle_But;
    public static GameObject omelet_But;

    public static GameObject tapBase3;
    public static GameObject pasta_But;
    public static GameObject salad_But;
    public static GameObject steak_But;

    // Start is called before the first frame update
    void Start()
    {
        tapBase1 = GameObject.Find("tapBase1");
        bread_But = GameObject.Find("bread_But");
        broth_But = GameObject.Find("broth_But");
        cake_But = GameObject.Find("cake_But");
        dumpling_But = GameObject.Find("dumpling_But");

        tapBase2 = GameObject.Find("tapBase2");
        fish_But = GameObject.Find("fish_But");
        Ivy_But = GameObject.Find("Ivy_But");
        noodle_But = GameObject.Find("noodle_But");
        omelet_But = GameObject.Find("omelet_But");

        tapBase3 = GameObject.Find("tapBase3");
        pasta_But = GameObject.Find("pasta_But");
        salad_But = GameObject.Find("salad_But");
        steak_But = GameObject.Find("steak_But");

        tapBase1Invisible();
        tapBase2Invisible();
        tapBase3Invisible();
    }

    private void OnMouseDown()
    {
        stage1_moveButManage.inventoryVisible(); //인벤토리 창으로
        tapBase1Visible();
        stage1_moveButManage.moveButVisible(); //인벤토리 버튼들 활성화
        stage1_moveButManage.currentTab = "tapBase1"; //베이스창 1쪽
    }

    //베이스 전체 콜라이더 비활성화
    public static void baseColliderInactive()
    {
        for (int i = 0; i < tapBase1.transform.childCount; i++)
            tapBase1.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        for (int i = 0; i < tapBase2.transform.childCount; i++)
            tapBase2.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        for (int i = 0; i < tapBase3.transform.childCount; i++)
            tapBase3.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    //베이스 전체 콜라이더 활성화
    public static void baseColliderActive()
    {
        for (int i = 0; i < tapBase1.transform.childCount; i++)
            tapBase1.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        for (int i = 0; i < tapBase2.transform.childCount; i++)
            tapBase2.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = true;
        for (int i = 0; i < tapBase3.transform.childCount; i++)
            tapBase3.transform.GetChild(i).gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void tapBase1Visible()
    {
        for (int i = 0; i < tapBase1.transform.childCount; i++)
        {
            tapBase1.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public static void tapBase1Invisible()
    {
        for (int i = 0; i < tapBase1.transform.childCount; i++)
        {
            tapBase1.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public static void tapBase2Visible()
    {
        for (int i = 0; i < tapBase2.transform.childCount; i++)
        {
            tapBase2.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public static void tapBase2Invisible()
    {
        for (int i = 0; i < tapBase2.transform.childCount; i++)
        {
            tapBase2.transform.GetChild(i).gameObject.SetActive(false);

        }
    }

    public static void tapBase3Visible()
    {
        for (int i = 0; i < tapBase3.transform.childCount; i++)
        {
            tapBase3.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public static void tapBase3Invisible()
    {
        for (int i = 0; i < tapBase3.transform.childCount; i++)
        {
            tapBase3.transform.GetChild(i).gameObject.SetActive(false);

        }
    }


    public static void AllusedBread()
    {
        //빵 모두 소진시 선택할 수 없음
        bread_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        bread_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockBread()
    {
        bread_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("baseBut/bread_But", typeof(Sprite)) as Sprite;
        bread_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedBroth()
    {
        broth_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        broth_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockBroth()
    {
        broth_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("baseBut/broth_But", typeof(Sprite)) as Sprite;
        broth_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedCake()
    {
        cake_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        cake_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockCake()
    {
       cake_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("baseBut/cake_But", typeof(Sprite)) as Sprite;
       cake_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedDumpling()
    {
        dumpling_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        dumpling_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockDumpling()
    {
        dumpling_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("baseBut/dumpling_But", typeof(Sprite)) as Sprite;
        dumpling_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedFish()
    {
        fish_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        fish_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockFish()
    {
       fish_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("baseBut/fish_But", typeof(Sprite)) as Sprite;
       fish_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedIvy()
    {
        Ivy_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        Ivy_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockIvy()
    {
       Ivy_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("baseBut/Ivy_But", typeof(Sprite)) as Sprite;
       Ivy_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedNoodle()
    {
        noodle_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        noodle_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockNoodle()
    {
        noodle_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("baseBut/noodle_But", typeof(Sprite)) as Sprite;
        noodle_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedOmelet()
    {
        omelet_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        omelet_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockOmelet()
    {
        omelet_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("baseBut/omelet_But", typeof(Sprite)) as Sprite;
        omelet_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedPasta()
    {
        pasta_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        pasta_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockPasta()
    {
        pasta_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("baseBut/pasta_But", typeof(Sprite)) as Sprite;
        pasta_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedSalad()
    {
        salad_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        salad_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockSalad()
    {
        salad_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("baseBut/salad_But", typeof(Sprite)) as Sprite;
        salad_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedSteak()
    {
        steak_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        steak_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockSteak()
    {
        steak_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("baseBut/steak_But", typeof(Sprite)) as Sprite;
        steak_But.GetComponent<BoxCollider2D>().enabled = true;
    }
}
