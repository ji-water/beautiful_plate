using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 초기 시작화면에서 터치들어오면 title1 전환
public class mainStart: MonoBehaviour
{

    private void OnMouseDown()
    {
        titleManage.changeTitle(0);
    }
}
