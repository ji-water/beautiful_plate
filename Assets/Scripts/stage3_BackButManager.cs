using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//재료와 함께 보여지는 뒤로가기 버튼관리
public class stage3_BackButManager : MonoBehaviour
{
    static int butstate;

    // Start is called before the first frame update
    void Start()
    {
    }

    static public void setButstate(int state)
    {
        butstate = state;
    }

    //터치가 들어오면 켜져있는 재료를 끄고 버튼탭을 보여준다
    private void OnMouseDown()
    {
        if (butstate == 1)
            stage3_But1Manager.SetOFFIngredient();
        else if (butstate == 2)
            stage3_But2Manager.SetOFFIngredient();
        else if (butstate == 3)
            stage3_But3Manager.SetOFFIngredient();
        else if (butstate == 4)
            stage3_But4Manager.SetOFFIngredient();
        
            
        stage3_ButtonManager.ButtonActivate();
    }
}
