using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title1_start : MonoBehaviour
{
    GameObject title1;
    GameObject title2;
    // Start is called before the first frame update
    void Start()
    {
        title1 = GameObject.Find("title1");
        title2 = GameObject.Find("title2");
        title2.SetActive(false);
    }

    private void OnMouseDown()
    {
        title2.SetActive(true);
        main_stagemanage.stage_check();
        title1.SetActive(false);
    }
}
