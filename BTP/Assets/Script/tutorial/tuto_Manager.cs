using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tuto_Manager : MonoBehaviour
{
    public static int tuto_i;
    public GameObject[] tutoGraphic;

    public static GameObject tempObj;
    public static string currentTabName;

    void Start()
    {
        tuto_i = 0;
        tempObj = null;
        tutoGraphic[0].SetActive(true);
    }

    private void OnMouseDown()
    {
        if (tuto_i < 6) {

            tutoGraphic[tuto_i].SetActive(false);
            tutoGraphic[tuto_i + 1].SetActive(true);
            tuto_i++;

            if (tuto_i == 6)  //베이스탭 터치해
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }      

        else if(tuto_i < 11)
        {
            tutoGraphic[tuto_i].SetActive(false);
            tutoGraphic[tuto_i + 1].SetActive(true);
            tuto_i++;

            if (tuto_i == 11)   //국수만들어
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        else if (tuto_i < 20)
        {
            if (tuto_i == 12)
            {
                tuto_plating.deleteAll();
                currentTabName = stage1_moveButManage.currentTab;

                Debug.Log("보고있던 탭" + currentTabName);

                tempObj = GameObject.Find(currentTabName); //현재 보이는 탭의 부모 오브젝트

                //탭 비활성화
                for (int i = 0; i < tempObj.transform.childCount; i++)
                {
                    tempObj.transform.GetChild(i).gameObject.SetActive(false);
                }
                stage1_moveButManage.moveButInvisible();
                stage1_moveButManage.inventoryInvisible();
            }
            tutoGraphic[tuto_i].SetActive(false);
            tutoGraphic[tuto_i + 1].SetActive(true);
            tuto_i++;

            if (tuto_i == 20)  //브로콜리 구워
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }       

        else if (tuto_i < 24)
        {
            if(tuto_i == 21)
            {
                currentTabName = stage1_moveButManage.currentTab;

                Debug.Log("보고있던 탭" + currentTabName);

                tempObj = GameObject.Find(currentTabName); //현재 보이는 탭의 부모 오브젝트

                //탭 비활성화
                for (int i = 0; i < tempObj.transform.childCount; i++)
                {
                    tempObj.transform.GetChild(i).gameObject.SetActive(false);
                }
                stage1_moveButManage.moveButInvisible();
                stage1_moveButManage.inventoryInvisible();
            }
            
            tutoGraphic[tuto_i].SetActive(false);
            tutoGraphic[tuto_i + 1].SetActive(true);
            tuto_i++;

            if (tuto_i == 24)  //오이 잘라
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        else if (tuto_i < 28)
        {
            if (tuto_i == 25)
            {
                currentTabName = stage1_moveButManage.currentTab;

                Debug.Log("보고있던 탭" + currentTabName);

                tempObj = GameObject.Find(currentTabName); //현재 보이는 탭의 부모 오브젝트

                //탭 비활성화
                for (int i = 0; i < tempObj.transform.childCount; i++)
                {
                    tempObj.transform.GetChild(i).gameObject.SetActive(false);
                }
                stage1_moveButManage.moveButInvisible();
                stage1_moveButManage.inventoryInvisible();
            }
            tutoGraphic[tuto_i].SetActive(false);
            tutoGraphic[tuto_i + 1].SetActive(true);
            tuto_i++;

            if (tuto_i == 28)  //오이 채썰어
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        else if (tuto_i < 32)
        {
            if (tuto_i == 29)
            {
                currentTabName = stage1_moveButManage.currentTab;

                Debug.Log("보고있던 탭" + currentTabName);

                tempObj = GameObject.Find(currentTabName); //현재 보이는 탭의 부모 오브젝트

                //탭 비활성화
                for (int i = 0; i < tempObj.transform.childCount; i++)
                {
                    tempObj.transform.GetChild(i).gameObject.SetActive(false);
                }
                stage1_moveButManage.moveButInvisible();
                stage1_moveButManage.inventoryInvisible();
            }
            tutoGraphic[tuto_i].SetActive(false);
            tutoGraphic[tuto_i + 1].SetActive(true);
            tuto_i++;

            if (tuto_i == 32)  //블루베리 주스
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        else if (tuto_i < 37)
        {
            if (tuto_i == 33)
            {
                currentTabName = stage1_moveButManage.currentTab;

                Debug.Log("보고있던 탭" + currentTabName);

                tempObj = GameObject.Find(currentTabName); //현재 보이는 탭의 부모 오브젝트

                //탭 비활성화
                for (int i = 0; i < tempObj.transform.childCount; i++)
                {
                    tempObj.transform.GetChild(i).gameObject.SetActive(false);
                }
                stage1_moveButManage.moveButInvisible();
                stage1_moveButManage.inventoryInvisible();
            }
            tutoGraphic[tuto_i].SetActive(false);
            tutoGraphic[tuto_i + 1].SetActive(true);
            tuto_i++;

            if (tuto_i == 37)  //블루베리 주스 그려라
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        else if (tuto_i < 49)
        {

            tuto_plating.deleteAll();
            tutoGraphic[tuto_i].SetActive(false);
            if (tuto_i == 38)
            {
                tuto_plating.deleteAll();
                currentTabName = stage1_moveButManage.currentTab;

                Debug.Log("보고있던 탭" + currentTabName);

                tempObj = GameObject.Find(currentTabName); //현재 보이는 탭의 부모 오브젝트

                //탭 비활성화
                for (int i = 0; i < tempObj.transform.childCount; i++)
                {
                    tempObj.transform.GetChild(i).gameObject.SetActive(false);
                }
                stage1_moveButManage.moveButInvisible();
                stage1_moveButManage.inventoryInvisible();
            }
            tutoGraphic[tuto_i + 1].SetActive(true);
            tuto_i++;

            if (tuto_i == 49)
                SceneManager.LoadScene("Main");
        }

        

    }
}
