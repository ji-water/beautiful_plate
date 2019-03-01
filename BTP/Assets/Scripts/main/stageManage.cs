using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//stage 관리한다
public class stageManage : MonoBehaviour
{
    private static GameObject stage1,stage2,stage3,stage4,stage5;
    public static int[] clear; //clear한 스테이지 저장 
    static int open; //open 스테이지숫자
    
    void Start()
    {
        open = 5;
        clear = new int[5];

        for (int i = 0; i < 5; i++)
            clear[i] = 0;

        stage1 = GameObject.Find("stage1");
        stage2 = GameObject.Find("stage2");
        stage3 = GameObject.Find("stage3");
        stage4 = GameObject.Find("stage4");
        stage5 = GameObject.Find("stage5");

        Stage_setunactive();
    }

    public static void Stage_setunactive()
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);
        stage5.SetActive(false);
    }
    public static void stage_clear()
    {
        for(int i=0; i<5; i++)
        {
            if (PlayerPrefs.HasKey("clear" + (i + 1)))
            {
                clear[i] = PlayerPrefs.GetInt("clear" + (i + 1));
                if (clear[i] == 1)
                {
                    switch (i + 1)
                    {
                        case 1:
                            stage1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("_main/title2_stage1_clear");
                            break;
                        case 2:
                            stage2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("_main/title2_stage2_clear");
                            break;
                        case 3:
                            stage3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("_main/title2_stage3_clear");
                            break;
                        case 4:
                            stage4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("_main/title2_stage4_clear");
                            break;
                        case 5:
                            stage5.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("_main/title2_stage5_clear");
                            break;
                    }
                }
            }
        }

    }

    public static void stage_check()
    { 
        stage1.SetActive(true);
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

        stage_clear();
    }
}
