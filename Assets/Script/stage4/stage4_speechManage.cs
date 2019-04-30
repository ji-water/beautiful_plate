using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage4_speechManage : MonoBehaviour
{

    private stage4_timerManage scriptTimer;
    public GameObject tutoStartBut;

    public GameObject speech;
    private GameObject Clone;
    public static bool speechOn;

    public static GameObject hintBut;
    // Start is called before the first frame update
    void Start()
    {
        speechOn = false;
        scriptTimer = tutoStartBut.GetComponent<stage4_timerManage>();

        hintBut = GameObject.Find("hint");

        Time.timeScale = 1;
        InvokeRepeating("speechGenerator", 25f, 35f);

    }



    void speechGenerator()
    {

        if ((!speechOn) && (!stage4_submitClick.submitOn) && (!stage4_checkHint.hintOn) && (stage4_timerManage.tutoStartClicked) && (!stage4_submitClick.sliderStopped))
        { //요리 샘플 보여줄땐 생성x
            //힌트 볼때 생성x
            //튜토리얼 끝나고 생성
            //슬라이더 안움직일때 생성x
           // hintBut.GetComponent<BoxCollider2D>().enabled = false;
            Clone = Instantiate(speech, new Vector3(0,-0.4f, 0f), Quaternion.identity);
         
            speechOn = true;
        }

    }
}
