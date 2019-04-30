using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage5_mistakeManage : MonoBehaviour
{

    private stage5_timerManage scriptTimer;
    public GameObject tutoStartBut;

    public GameObject mistake;
    private GameObject Clone;
    public static bool mistakeOn;

    public static GameObject hintBut;
    // Start is called before the first frame update
    void Start()
    {
       

        mistakeOn = false;
        scriptTimer = tutoStartBut.GetComponent<stage5_timerManage>();

        hintBut = GameObject.Find("hint");
        Time.timeScale = 1;
        InvokeRepeating("speechGenerator", 35f, 45f);

    }



    void speechGenerator()
    {

        if ((!mistakeOn) && (!stage5_submitClick.submitOn) && (!stage5_checkHint.hintOn) && (stage5_timerManage.tutoStartClicked) && (!stage5_submitClick.sliderStopped))
        { //요리 샘플 보여줄땐 생성x
          //힌트 볼때 생성x
          //튜토리얼 끝나고 생성
          //슬라이더 안움직일때 생성x
          // hintBut.GetComponent<BoxCollider2D>().enabled = false;
            Clone = Instantiate(mistake, new Vector3(0, -0.4f, 0f), Quaternion.identity);

            mistakeOn = true;
        }

    }
}
