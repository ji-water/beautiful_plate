using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_backButManage : MonoBehaviour
{
    //backBut에 붙어 뒤로가기 버튼 관리
    
    public static GameObject tempObj = null;
    public static string currentTabName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnMouseDown()
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
}