using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//hint에 붙음
public class stage2_checkHint : MonoBehaviour
{


    public Transform platingSample1, platingSample2, platingSample3, platingSample4, platingSample5, platingSample6;

    public static Transform hintSample;
    Vector2 hintPosition = new Vector2(0,-0.45f);

    public GameObject allTransparent;

    public static bool hint_on;

    //hint count
    public static GameObject hintCount;

    void Start()
    {
        hintPosition = new Vector2(0, -0.45f);
        hint_on = false;

        hintCount = GameObject.Find("hint3");
;    }


    void OnMouseDown()
    {
        if (gameObject.name == "hint")
        {
            hint_on = true;

            if (Stage2_submitClick.hintCount < 3)
            {

                //hint count
                switch (Stage2_submitClick.hintCount)
                {
                    case 0:
                        hintCount.GetComponent<SpriteRenderer>().sprite = Resources.Load("Hint/hint2", typeof(Sprite)) as Sprite;
                        break;
                    case 1:
                        hintCount.GetComponent<SpriteRenderer>().sprite = Resources.Load("Hint/hint1", typeof(Sprite)) as Sprite;
                        break;
                    case 2:
                        hintCount.SetActive(false);
                        break;
                }

                stage1_plating.makeInvisible();
                allTransparent.SetActive(true); //화면 클릭 막음

                //Debug.Log(stage2_timerManage.currentSample);

                if (stage2_timerManage.currentSample == "plating_1")
                {
                    hintSample = (Transform)Instantiate(platingSample1, hintPosition, platingSample1.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage2_timerManage.currentSample == "plating_2")
                {
                    hintSample = (Transform)Instantiate(platingSample2, hintPosition, platingSample2.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage2_timerManage.currentSample == "plating_3")
                {
                    hintSample = (Transform)Instantiate(platingSample3, hintPosition, platingSample3.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage2_timerManage.currentSample == "plating_4")
                {
                    hintSample = (Transform)Instantiate(platingSample4, hintPosition, platingSample4.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage2_timerManage.currentSample == "plating_5")
                {
                    hintSample = (Transform)Instantiate(platingSample5, hintPosition, platingSample5.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage2_timerManage.currentSample == "plating_6")
                {
                    hintSample = (Transform)Instantiate(platingSample6, hintPosition, platingSample6.rotation); //요리 샘플 clone생성(transform)
                }


            }
        }
        else if (gameObject.name == "allTransparent")
        {
            makeVisible();
            Destroy(hintSample.gameObject);
            Stage2_submitClick.hintCount++;
            hint_on = false;
        }
    }
    void makeVisible()
    {
        //platedParent 자식들 찾아서 활성화
        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            stage1_plating.platedParent.transform.GetChild(i).gameObject.SetActive(true);
           
        }
        allTransparent.SetActive(false);
    }
   
}
