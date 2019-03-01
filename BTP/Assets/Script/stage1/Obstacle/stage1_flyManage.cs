using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_flyManage : MonoBehaviour
{
    private stage1_timerManage scriptTimer;
    public GameObject tutoStartBut;

    public GameObject fly;
    public GameObject swatter;
    private GameObject Clone;
    public static bool flyOn = false;

    public static GameObject hintBut;
    // Start is called before the first frame update
    void Start()
    {
        flyOn = false;

        scriptTimer = tutoStartBut.GetComponent<stage1_timerManage>();

        hintBut = GameObject.Find("hint");
        Time.timeScale = 1;
        InvokeRepeating("flyGenerator",15f,25f); //10초뒤20초마다
        
    }



    void flyGenerator() {

        if ((!flyOn)&&(!stage1_submitClick.submitOn)&&(!stage1_checkHint.hintOn)&&(stage1_timerManage.tutoStartClicked)&&(!stage1_submitClick.sliderStopped))
        { //요리 샘플 보여줄땐 생성x
            //힌트 볼때 생성x
            //튜토리얼 끝나고 생성
            //슬라이더 안움직일때 생성x
            hintBut.GetComponent<BoxCollider2D>().enabled = false;
            Clone = Instantiate(fly, new Vector3(-4.0f, -4.0f, 0), Quaternion.identity);
            Instantiate(swatter, new Vector3(4.97f, 1.61f, 0), Quaternion.identity);
            flyOn = true;
        }
    }
}
