using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_stagemanage : MonoBehaviour
{
    private static GameObject stage1,stage2,stage3,stage4,stage5;
    public static int clear; //clear한 스테이지 숫자
    static int open; //open 스테이지숫자
    
    void Start()
    {
        open = 3;
        clear = 0;
        stage1 = GameObject.Find("stage1");
        stage2 = GameObject.Find("stage2");
        stage3 = GameObject.Find("stage3");
        stage4 = GameObject.Find("stage4");
        stage5 = GameObject.Find("stage5");

        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);
        stage5.SetActive(false);
    }

    public static void stage_clear(int num)
    {
        clear = num;
        switch (clear)
        {
            case 1:
                stage1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("title2_stage1_clear");
                break;
            case 2:
                stage2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("title2_stage2_clear");
                break;
            case 3:
                stage3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("title2_stage3_clear");
                break;
            case 4:
                stage4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("title2_stage4_clear");
                break;
            case 5:
                stage5.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("title2_stage5_clear");
                break;
        }
        if (clear == open)
            open = clear + 1;
    }

    public static void stage_check()
    {
        if (open <= 1)
            return;
        stage2.SetActive(true);
        if (open <= 2)
            return;
        stage3.SetActive(true);
        if (open <= 3)
            return;
        stage4.SetActive(true);
        if (open <= 4)
            return;
        stage5.SetActive(true);
    }
}
