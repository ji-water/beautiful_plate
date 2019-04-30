using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//hint에 붙음
public class stage5_checkHint : MonoBehaviour
{


    public Transform platingSample1, platingSample2, platingSample3, platingSample4,platingSample5, platingSample6;
    public Transform platingSample7, platingSample8, platingSample9, platingSample10, platingSample11, platingSample12;
    public Transform platingSample13, platingSample14, platingSample15, platingSample16, platingSample17, platingSample18;
    public Transform platingSample19, platingSample20, platingSample21, platingSample22, platingSample23, platingSample24;


    public static Transform hintSample;
    Vector2 hintPosition = new Vector2(0,-0.45f);

    public static GameObject allTransparent;

    public static bool hintOn = false;

    //hint count
    public static GameObject hintCount;

    void Start()
    {
        hintOn = false;

        allTransparent = GameObject.Find("allTransparent");
        allTransparent.SetActive(false);

        //hint count
        hintCount = GameObject.Find("hint3");

     }

    // Update is called once per frame
    void OnMouseDown()
    {
        if (stage5_submitClick.hintCount <3) {
            if (!hintOn)
            {
                //hint count
                switch (stage5_submitClick.hintCount)
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

                if (stage5_timerManage.currentSample == "platingSample1")
                {
                    hintSample = (Transform)Instantiate(platingSample1, hintPosition, platingSample1.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample2")
                {
                    hintSample = (Transform)Instantiate(platingSample2, hintPosition, platingSample2.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample3")
                {
                    hintSample = (Transform)Instantiate(platingSample3, hintPosition, platingSample3.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample4")
                {
                    hintSample = (Transform)Instantiate(platingSample4, hintPosition, platingSample4.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample5")
                {
                    hintSample = (Transform)Instantiate(platingSample5, hintPosition, platingSample5.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample6")
                {
                    hintSample = (Transform)Instantiate(platingSample6, hintPosition, platingSample6.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample7")
                {
                    hintSample = (Transform)Instantiate(platingSample7, hintPosition, platingSample7.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample8")
                {
                    hintSample = (Transform)Instantiate(platingSample8, hintPosition, platingSample8.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample9")
                {
                    hintSample = (Transform)Instantiate(platingSample9, hintPosition, platingSample9.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample10")
                {
                    hintSample = (Transform)Instantiate(platingSample10, hintPosition, platingSample10.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample11")
                {
                    hintSample = (Transform)Instantiate(platingSample11, hintPosition, platingSample11.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample12")
                {
                    hintSample = (Transform)Instantiate(platingSample12, hintPosition, platingSample12.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample13")
                {
                    hintSample = (Transform)Instantiate(platingSample13, hintPosition, platingSample13.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample14")
                {
                    hintSample = (Transform)Instantiate(platingSample14, hintPosition, platingSample14.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample15")
                {
                    hintSample = (Transform)Instantiate(platingSample15, hintPosition, platingSample15.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample16")
                {
                    hintSample = (Transform)Instantiate(platingSample16, hintPosition, platingSample16.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample17")
                {
                    hintSample = (Transform)Instantiate(platingSample17, hintPosition, platingSample17.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample18")
                {
                    hintSample = (Transform)Instantiate(platingSample18, hintPosition, platingSample18.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample19")
                {
                    hintSample = (Transform)Instantiate(platingSample19, hintPosition, platingSample19.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample20")
                {
                    hintSample = (Transform)Instantiate(platingSample20, hintPosition, platingSample20.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample21")
                {
                    hintSample = (Transform)Instantiate(platingSample21, hintPosition, platingSample21.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample22")
                {
                    hintSample = (Transform)Instantiate(platingSample22, hintPosition, platingSample22.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample23")
                {
                    hintSample = (Transform)Instantiate(platingSample23, hintPosition, platingSample23.rotation); //요리 샘플 clone생성(transform)
                }
                else if (stage5_timerManage.currentSample == "platingSample24")
                {
                    hintSample = (Transform)Instantiate(platingSample24, hintPosition, platingSample24.rotation); //요리 샘플 clone생성(transform)
                }

               
                stage5_submitClick.hintCount++; 

                hintOn = true; //힌트 보고있는 상태
            }
        }
        //else if(hintOn){
        //    makeVisible();
        //    Destroy(hintSample.gameObject);
        //    hintOn = false;
        //}
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
