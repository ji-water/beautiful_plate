using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3_NextBut : MonoBehaviour
{
    static int butstate;

    public static void setButstate(int state)
    {
        butstate = state;
    }

    private void OnMouseDown()
    {
        if (butstate == 1)//채소
        {
            stage3_But1Manager.SetTAB();
        }
        else if (butstate == 2)//과일
            stage3_But2Manager.SetTAB();
        else if (butstate == 3)//유제품
            stage3_But3Manager.SetTAB();
        else if (butstate == 4) //데코
            stage3_But4Manager.SetTAB();
    }
}
