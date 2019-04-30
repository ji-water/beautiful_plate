using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2_interruptManager : MonoBehaviour

{
    float interval;
    public GameObject[] QuestionSample;
    public GameObject[] AnswerSample;

    GameObject background;

    GameObject but1;
    GameObject but2;

    GameObject interruptManage;


    public static int inter_num;
    public static int inter_i = 0;
    public static bool inter_on;
    int checkAnswer;
    int[][] theAnswer;

    static int wrongAnswer;

    public GameObject sound;

    void Start()
    {
        wrongAnswer = 0;

        inter_i = 0;
        theAnswer = new int[6][];
        theAnswer[0] = new int[] { 1, 2, 2, 2, 1 };
        theAnswer[1] = new int[] { 2, 1, 2, 1, 2 };
        theAnswer[2] = new int[] { 1, 1, 2, 1, 2 };
        theAnswer[3] = new int[] { 2, 2, 1, 2, 1 };
        theAnswer[4] = new int[] { 1, 1, 1, 1, 2 };
        theAnswer[5] = new int[] { 2, 1, 1, 2, 2 };

        interruptManage = GameObject.Find("interruptManage");

        but1 = interruptManage.transform.Find("but_1").gameObject;
        but2 = interruptManage.transform.Find("but_2").gameObject;

        background = interruptManage.transform.Find("background").gameObject;

        inter_on = false;        //방해물이 켜지면 true
        


    }

    float makeInterval()
    {
        float randNum = Random.Range(17, 26);
        return randNum;
    }

    public void makeInterrupt()
    {
        if (Stage2_submitClick.submitOn == true||stage2_checkHint.hint_on==true) Invoke("makeInterrupt", 10.0f);

        else
        {
            for (int k = 0; k < 6; k++)
            {
                if (QuestionSample[k].activeSelf == true) inter_on = true;
            }
            if (inter_on == false)
            {

                inter_i = 0;
                stage1_plating.makeInvisible();

                inter_num = Random.Range(0, 6);
                Debug.Log(inter_num);

                inter_on = true;
                background.SetActive(true);
                QuestionSample[inter_num].SetActive(true);
                AnswerSample[inter_num].SetActive(true);
                but1.SetActive(true);
                but2.SetActive(true);
            }
        }


    }

    void OnMouseDown()
    {
        if (gameObject.name == "but_1")
        {
            //sound
            sound.GetComponent<AudioSource>().Play();

            // Debug.Log("찍찍");
            //Debug.Log("theAnswer[" + inter_num + "][" + inter_i + "] = " + theAnswer[inter_num][inter_i]);
            checkAnswer = 1;

            if (checkAnswer != theAnswer[inter_num][inter_i])
            {
                //slider.value -= 5.0f;

                wrongAnswer = 1;

                stage2_timerManage.time -= 5.0f;
                finishInterrupt();
            }
            else
            {
                inter_i++;
                if (inter_i == 5) finishInterrupt();
            }

        }
        else if (gameObject.name == "but_2")
        {
            //sound
            sound.GetComponent<AudioSource>().Play();

            //Debug.Log("찍-찍");
            // Debug.Log("theAnswer[" + inter_num + "][" + inter_i + "] = " + theAnswer[inter_num][inter_i]);
            checkAnswer = 2;

            if (checkAnswer != theAnswer[inter_num][inter_i])
            {
                //slider.value -= 5.0f;
                wrongAnswer = 1;

                stage2_timerManage.time -= 5.0f;
                finishInterrupt();
            }
            else
            {
                inter_i++;
                if (inter_i == 5) finishInterrupt();
            }

        }



    }

    void finishInterrupt()
    {

        //sound
        if (wrongAnswer == 1)
        {
            Debug.Log("wrong");
            interruptManage.GetComponent<AudioSource>().Play();
        }



        Transform[] childList = interruptManage.GetComponentsInChildren<Transform>(true);
        if (childList != null)
        {
            for (int j = 1; j < childList.Length; j++)  //0번은 부모 class
            {
                //if (childList[j] != transform)
                if(childList[j].name != "sound")
                    childList[j].gameObject.SetActive(false);
            }
        }
        makeVisible();

        wrongAnswer = 0;

        inter_on = false;
        Time.timeScale = 1;
        interval = makeInterval();
        Invoke("makeInterrupt", interval);
        //다음 방해물 예약

    }

    void makeVisible()
    {
        //platedParent 자식들 찾아서 활성화
        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            stage1_plating.platedParent.transform.GetChild(i).gameObject.SetActive(true);

        }
    }
}

