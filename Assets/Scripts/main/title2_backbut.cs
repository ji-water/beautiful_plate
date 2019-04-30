using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//title2_backbut
//입력받으면 게임 선택창으로 돌아간다
public class title2_backbut : MonoBehaviour
{
    private void OnMouseDown()
    {
        titleManage.changeTitle(1);
    }
}
