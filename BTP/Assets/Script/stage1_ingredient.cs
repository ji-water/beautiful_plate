using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_ingredient : MonoBehaviour
{
    //gamemanager에 붙어 
    //touched 재료 및 도구 상호작용된 재료 관리

        //배열 순서 -> 재료 버튼 나열 순서

    public GameObject[] touchedIngredients;
    public GameObject[] touchedWithTools;
    public GameObject touchedTissue;
    // Start is called before the first frame update
    void Start()
    {

        touchedInactive();
        touchedWithToolsInactive();
        touchedTissue.SetActive(false);
    }
    public void touchedInactive()
    {
        for (int i = 0; i < touchedIngredients.Length; i++)
        {
            touchedIngredients[i].SetActive(false);
        }
    }

    public void touchedWithToolsInactive()
    {
        for (int i = 0; i < touchedWithTools.Length; i++)
        {
            touchedWithTools[i].SetActive(false);
        }

    }

}
