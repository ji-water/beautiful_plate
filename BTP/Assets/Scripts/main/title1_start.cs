using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//title1_start button 클릭 관리 코드
public class title1_start : MonoBehaviour
{
    private void OnMouseDown()
    {
        titleManage.changeTitle(2);
    }
}
