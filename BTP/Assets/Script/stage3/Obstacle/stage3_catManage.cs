using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3_catManage : MonoBehaviour
{
    private stage3_timerManage scriptTimer;
    public GameObject tutoStartBut;

    public GameObject cat;
    private GameObject Clone;
    public static bool catOn = false;
    public static float randomX;
    public static GameObject hintBut;
    // Start is called before the first frame update
    void Start()
    {
        scriptTimer = tutoStartBut.GetComponent<stage3_timerManage>();

        hintBut = GameObject.Find("hint");
        Time.timeScale = 1;
        InvokeRepeating("catGenerator", 18f, 25f); //10초뒤20초마다

    }



    void catGenerator()
    {

        if ((!catOn) && (!stage3_submitClick.submitOn) && (!stage3_checkHint.hintOn) && (stage3_timerManage.tutoStartClicked) && (!stage3_submitClick.sliderStopped))
        { //요리 샘플 보여줄땐 생성x
            //힌트 볼때 생성x
            //튜토리얼 끝나고 생성
            //슬라이더 안움직일때 생성x
            hintBut.GetComponent<BoxCollider2D>().enabled = false;
            randomX = Random.Range(-2.7f, 2.23f);
            Clone = Instantiate(cat, new Vector3(randomX, -7.97f, 0), Quaternion.identity);
            catOn = true;
        }
    }
}
