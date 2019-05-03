using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



//접시에 재료를 올리고 올라간 재료를 관리하는 코드
public class stage3_Plating : MonoBehaviour
{

    static int count; //재료 제한 수

    static Vector3 touchedPos;
    public static float zPos;

    //소스
    [SerializeField] private GameObject choco;
    [SerializeField] private GameObject caramel;
    [SerializeField] private GameObject ketchup;
    [SerializeField] private GameObject mayo;

    //오브젝트 그대로 올라가는 경우
    [SerializeField] private GameObject apple;
    [SerializeField] private GameObject asparagus;
    [SerializeField] private GameObject avocado;
    [SerializeField] private GameObject basil;
    [SerializeField] private GameObject broccoli;
    [SerializeField] private GameObject carrot;
    [SerializeField] private GameObject cheddar;
    [SerializeField] private GameObject cheese;
    [SerializeField] private GameObject cherrytomato;
    [SerializeField] private GameObject cucumber;
    [SerializeField] private GameObject lemon;
    [SerializeField] private GameObject mozza;
    [SerializeField] private GameObject orange;
    [SerializeField] private GameObject paprika;
    [SerializeField] private GameObject radishsprout;
    [SerializeField] private GameObject strawberry;

    private static GameObject clone;
    private static GameObject c_parent;


    static int[][] plateCount;
    delegate void FuncPt(int tag);

    void Start()
    {
        count = 5;
        zPos = 14; //재료 쌓을때마다 z-- 

        c_parent = GameObject.Find("clone");

        plateCount = new int[5][];
        for(int i=0; i<5; i++)
        {
            plateCount[i] = new int[8];
            for(int j=0; j<8; j++)
            {
                plateCount[i][j] = 0;
            }
        }
    }

    //plating 함수
    private static void plate(FuncPt ButManager,GameObject s_ingredient ,GameObject ingredient, int but, int tag)
    {
        clone = Instantiate(ingredient, touchedPos, Quaternion.Euler(0, 0, 0)) as GameObject;
        clone.transform.parent = c_parent.transform;

        zPos -= (float)0.1;
        plateCount[but][tag]++;
        if (plateCount[but][tag] == count)
        {
            s_ingredient.SetActive(false);
            ButManager(tag);
        }
    }


    private void OnMouseDown()
    {
        touchedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        touchedPos.z = zPos;

        /* ====  BUT0 - 베이스 ==== */

        /* ====  BUT1 - 채소 ====  */
        //아스파라거스
        if (stage3_Ingredient.s_asparagus.activeSelf)
            plate(stage3_But1Manager.UseAll, stage3_Ingredient.s_asparagus, asparagus, 1, 0);
        //바질
        if (stage3_Ingredient.s_basil.activeSelf)
            plate(stage3_But1Manager.UseAll, stage3_Ingredient.s_basil, basil, 1, 1);
        //브로콜리
        if (stage3_Ingredient.s_broccoli.activeSelf)
            plate(stage3_But1Manager.UseAll, stage3_Ingredient.s_broccoli, broccoli, 1, 2);
        //당근
        if (stage3_Ingredient.s_carrot.activeSelf)
            plate(stage3_But1Manager.UseAll, stage3_Ingredient.s_carrot, carrot, 1, 3);
        //방울토마토
        if (stage3_Ingredient.s_cherrytomato.activeSelf)
            plate(stage3_But1Manager.UseAll, stage3_Ingredient.s_cherrytomato, cherrytomato, 1, 4);
        //오이
        if (stage3_Ingredient.s_cucumber.activeSelf)
            plate(stage3_But1Manager.UseAll, stage3_Ingredient.s_cucumber, cucumber, 1, 5);
        //파프리카
        if (stage3_Ingredient.s_paprika.activeSelf)
            plate(stage3_But1Manager.UseAll, stage3_Ingredient.s_paprika, paprika, 1, 6);
        //무순
        if (stage3_Ingredient.s_radishsprout.activeSelf)
            plate(stage3_But1Manager.UseAll, stage3_Ingredient.s_radishsprout, radishsprout, 1, 7);



        /* ====  BUT2 - 과일 ====  */
        //사과 그대로
        if (stage3_Ingredient.s_apple.activeSelf)
            plate(stage3_But2Manager.UseAll, stage3_Ingredient.s_apple, apple, 2, 0);
        //아보카도 그대로
        if (stage3_Ingredient.s_avocado.activeSelf)
            plate(stage3_But2Manager.UseAll, stage3_Ingredient.s_avocado, avocado, 2, 1);
        //레몬 그대로
        if (stage3_Ingredient.s_lemon.activeSelf)
            plate(stage3_But2Manager.UseAll, stage3_Ingredient.s_lemon, lemon, 2, 2);
        //오렌지 그대로
        if (stage3_Ingredient.s_orange.activeSelf)
            plate(stage3_But2Manager.UseAll, stage3_Ingredient.s_orange, orange, 2, 3);
        //딸기 그대로
        if (stage3_Ingredient.s_strawberry.activeSelf)
            plate(stage3_But2Manager.UseAll, stage3_Ingredient.s_strawberry, strawberry, 2, 4);



        /* ====  BUT3 - 유제품 ==== */
        //체다치즈
        if (stage3_Ingredient.s_cheddar.activeSelf)
            plate(stage3_But3Manager.UseAll, stage3_Ingredient.s_cheddar, cheddar, 3, 0);
        //치즈
        if (stage3_Ingredient.s_cheese.activeSelf)
            plate(stage3_But3Manager.UseAll, stage3_Ingredient.s_cheese, cheese, 3, 1);
        //모짜렐라
        if (stage3_Ingredient.s_mozza.activeSelf)
            plate(stage3_But3Manager.UseAll, stage3_Ingredient.s_mozza, mozza, 3, 2);

        /* ====  BUT4- 데코 ==== */

        //초코시럽
        if (stage3_Ingredient.s_choco.activeSelf)
            plate(stage3_But4Manager.UseAll, stage3_Ingredient.s_choco, choco, 4, 1);
        //카라멜시럽
        if (stage3_Ingredient.s_caramel.activeSelf)
            plate(stage3_But4Manager.UseAll, stage3_Ingredient.s_caramel, caramel, 4, 0);
        //케첩
        if (stage3_Ingredient.s_ketchup.activeSelf)
            plate(stage3_But4Manager.UseAll, stage3_Ingredient.s_ketchup, ketchup, 4, 2);
        //마요네즈
        if (stage3_Ingredient.s_mayo.activeSelf)
            plate(stage3_But4Manager.UseAll, stage3_Ingredient.s_mayo, mayo, 4, 3);


    }



}
