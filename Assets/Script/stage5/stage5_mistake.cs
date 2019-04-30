using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage5_mistake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        stage5_checkHint.allTransparent.SetActive(true);

        stage1_plating.deleteAll();
        stage5_timerManage.time -= 10f;

        Time.timeScale = 1;
        Invoke("mistakeOff", 1f);
        Destroy(gameObject,1f);
        
    }

    void mistakeOff() {

        stage5_mistakeManage.mistakeOn = false;
        stage5_checkHint.allTransparent.SetActive(false);
    }
}
