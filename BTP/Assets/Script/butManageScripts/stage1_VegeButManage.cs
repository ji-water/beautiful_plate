using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//drawerVege에 붙어 채소 탭 관리 -> drawerVege클릭시 베지tap1 visible
//채소탭 visbile함수, 재료 소진시 탭 sprite바꾸고 되돌리는 함수

public class stage1_VegeButManage : MonoBehaviour
{
    public static GameObject tapVegetable1;
    public static GameObject asparagus_But;
    public static GameObject basil_But;
    public static GameObject broccoli_But;
    public static GameObject carrot_But;

    public static GameObject tapVegetable2;
    public static GameObject cherrytomato_But;
    public static GameObject cucumber_But;
    public static GameObject paprika_But;
    public static GameObject radishsprout_But;

  
    // Start is called before the first frame update
    void Start()
    {
        tapVegetable1 = GameObject.Find("tapVegetable1");
           asparagus_But = GameObject.Find("asparagus_But");
        basil_But = GameObject.Find("basil_But");
        broccoli_But = GameObject.Find("broccoli_But");
        carrot_But = GameObject.Find("carrot_But");

        tapVegetable2 = GameObject.Find("tapVegetable2");
        cherrytomato_But = GameObject.Find("cherrytomato_But");
        cucumber_But = GameObject.Find("cucumber_But");
        paprika_But = GameObject.Find("paprika_But");
        radishsprout_But = GameObject.Find("radishsprout_But");


        tapVege1Invisible();
        tapVege2Invisible();

    }

    private void OnMouseDown()
    {
        stage1_moveButManage.inventoryVisible(); //인벤토리 창으로
        tapVege1Visible();
        stage1_moveButManage.moveButVisible(); //인벤토리 버튼들 활성화
        stage1_moveButManage.currentTab = "tapVegetable1"; //채소창 1쪽
    }

    
    public static void tapVege1Visible() {
        for (int i = 0; i < tapVegetable1.transform.childCount; i++)
        {
            tapVegetable1.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public static void tapVege1Invisible()
    {
        for (int i = 0; i < tapVegetable1.transform.childCount; i++)
        {
            tapVegetable1.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public static void tapVege2Visible() {
        for (int i = 0; i < tapVegetable2.transform.childCount; i++)
        {
            tapVegetable2.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public static void tapVege2Invisible()
    {
        for (int i = 0; i < tapVegetable2.transform.childCount; i++)
        {
            tapVegetable2.transform.GetChild(i).gameObject.SetActive(false);
            
        }
    }
   



    public static void AllusedAsparagus() {
        //아스파라거스 모두 소진시 선택할 수 없음
        asparagus_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        asparagus_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockAsparagus() {
        asparagus_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("vegetableBut/asparagus_But", typeof(Sprite)) as Sprite;
        asparagus_But.GetComponent<BoxCollider2D>().enabled = true;
    }


    public static void AllusedBasil() {
        basil_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        basil_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockBasil()
    {
        basil_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("vegetableBut/basil_But", typeof(Sprite)) as Sprite;
        basil_But.GetComponent<BoxCollider2D>().enabled = true;
    }


    public static void AllusedBroccoli()
    {
        broccoli_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
       broccoli_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockBroccoli()
    {
        Debug.Log("브로콜리 리스톡");
        broccoli_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("vegetableBut/broccoli_But", typeof(Sprite)) as Sprite;
        broccoli_But.GetComponent<BoxCollider2D>().enabled = true;
    }


    public static void AllusedCarrot()
    {
       carrot_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
       carrot_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockCarrot()
    {
       carrot_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("vegetableBut/carrot_But", typeof(Sprite)) as Sprite;
        carrot_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedCherrytomato()
    {
        cherrytomato_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        cherrytomato_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockCherrytomato()
    {
        cherrytomato_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("vegetableBut/cherrytomato_But", typeof(Sprite)) as Sprite;
        cherrytomato_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedCucumber()
    {
        cucumber_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        cucumber_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockCucumber()
    {
        cucumber_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("vegetableBut/cucumber_But", typeof(Sprite)) as Sprite;
        cucumber_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedPaprika()
    {
        paprika_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        paprika_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockPaprika()
    {
        paprika_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("vegetableBut/paprika_But", typeof(Sprite)) as Sprite;
        paprika_But.GetComponent<BoxCollider2D>().enabled = true;
    }

    public static void AllusedRadishsprout()
    {
        radishsprout_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("platedNOPE", typeof(Sprite)) as Sprite;
        radishsprout_But.GetComponent<BoxCollider2D>().enabled = false;
        stage1_plating.touchedName = null;
    }
    public static void RestockRadishsprout()
    {
        radishsprout_But.GetComponent<SpriteRenderer>().sprite = Resources.Load("vegetableBut/radishsprout_But", typeof(Sprite)) as Sprite;
        radishsprout_But.GetComponent<BoxCollider2D>().enabled = true;
    }

   



}
