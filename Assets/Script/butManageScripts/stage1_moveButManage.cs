using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//moveButManager에 붙어
//재료 탭 이동 전체 관리
//서랍, 재료 인벤토리 배경 관리
public class stage1_moveButManage : MonoBehaviour
{

    public static GameObject rightBut;
    public static GameObject leftBut;
    public static GameObject backBut;//뒤로가기버튼

    public static GameObject inventory; //재료 칸 배경

    public static GameObject drawerButParent;//서랍 탭들

    public static string currentTab; //현재 보고있는 탭??


    public static GameObject drawerDeco;
    // Start is called before the first frame update
    void Start()
    {
        rightBut = GameObject.Find("rightBut");
        leftBut = GameObject.Find("leftBut");
        backBut = GameObject.Find("backBut");
        inventory = GameObject.Find("inventory");

        drawerButParent = GameObject.Find("drawerButParent");
        drawerDeco = GameObject.Find("drawerDeco");

        //inventory.SetActive(false);
        inventoryInvisible();
        moveButInvisible();
    }

    // Update is called once per frame
    public static void moveButInvisible() {

        rightBut.SetActive(false);
        leftBut.SetActive(false);
        backBut.SetActive(false);
    }

    public static void moveButVisible() {
        Debug.Log("moveButActive");
        rightBut.SetActive(true);
        leftBut.SetActive(true);
        backBut.SetActive(true);
    }

    public static void inventoryVisible() {
        //서랍->재료칸으로 넘어갈시 
      
        for (int i = 0; i < drawerButParent.transform.childCount; i++)
        {
            drawerButParent.transform.GetChild(i).gameObject.SetActive(false);
        }
        inventory.SetActive(true);
        
        drawerDeco.GetComponent<BoxCollider2D>().enabled = false; //콜라이더켭치니까 데코칸 콜라이더 비활성화
    }

    public static void inventoryInvisible() {
        //재료칸->서랍
        for (int i = 0; i < drawerButParent.transform.childCount; i++)
        {
            drawerButParent.transform.GetChild(i).gameObject.SetActive(true);
        }
        inventory.SetActive(false);
        drawerDeco.GetComponent<BoxCollider2D>().enabled =true;
      
    }
}
