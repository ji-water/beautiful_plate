using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//슬라이더에 붙음

public class stage5_timerManage : MonoBehaviour
{
   
    public Slider slider;
    public static float time;
    public bool startslider = false;
     public GameObject clone;
    public GameObject[] randomSample;
    public static string currentSample;

    public Text temp;
    public Text temp2;

    public static GameObject tutoStart;
    public static bool tutoStartClicked;

    private stage5_submitClick scriptSubmit;
    public GameObject submit;

    //방해물
    public GameObject mistakeManage;
   
    // Start is called before the first frame update
    void  Start()
    {
        time = 180f;
        currentSample = null;
        tutoStartClicked = false;

        tutoStart = GameObject.Find("tutoStart");
        //scriptTimebut = translucent.GetComponent<stage1_timeButManage>();
        slider.enabled = false;
        slider.maxValue = 180f;
        slider.minValue = 0f;

        scriptSubmit = submit.GetComponent<stage5_submitClick>();
        //   temp = GameObject.Find("platingText").GetComponent<Text>();
        //   temp2 = GameObject.Find("tempText").GetComponent<Text>();



        //clone = ObjectRandomGenerator();
        //stage1_submitClick.submitCount++;
        //temp = GameObject.Find("platingText").GetComponent<Text>();
        //temp2 = GameObject.Find("tempText").GetComponent<Text>();

        //temp.text = "1";

        //Invoke("startTimer", 3.0f);
        //Destroy(clone, 3.0f);

    }


    private void OnMouseDown()
    {
        if (gameObject.name == "tutoStartBut")
        {
            mistakeManage.SetActive(true);

            tutoStartClicked = true;
            Destroy(tutoStart);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            slider.gameObject.SetActive(true);
            temp.gameObject.SetActive(true);
            temp2.gameObject.SetActive(true);
           
            clone = ObjectRandomGenerator();
            //stage1_submitClick.submitCount++;
           

            temp.text = "1";

            stage5_submitClick.submitOn = true;
            Invoke("startTimer", 7.0f);
            Destroy(clone, 7.0f);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (startslider)
        {
            time -= Time.deltaTime;
            slider.value = time;
          
            if (time <= 0) {

                //타임오버 실패
                if (stage5_mistakeManage.mistakeOn)
                {
                    GameObject obstacle = GameObject.Find("mistake(Clone)");
                    Destroy(obstacle);
                }

                startslider = false;
                stage5_submitClick.sliderStopped = true;
                Instantiate(scriptSubmit.fail, new Vector3(0.0f, 0.0f, -1f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
                scriptSubmit.finalScoreText.gameObject.SetActive(true);
                scriptSubmit.finalScoreText.text = "최종점수 : " + stage5_submitClick.score.ToString() + "원";

                //엔딩버튼
                scriptSubmit.mainBut.SetActive(true);
                scriptSubmit.retryBut.SetActive(true);

                //점수 기록 출력
                float j = 170f;
                for (int i = 0; i < scriptSubmit.platingResult.Length; i++)
                {
                    Debug.Log(scriptSubmit.platingResult[i]);
                    GameObject Clone = Instantiate(scriptSubmit.textclone, new Vector3(-250f, j, 0), transform.rotation) as GameObject;
                    Clone.GetComponent<Text>().text = scriptSubmit.platingResult[i];

                    Clone.transform.SetParent(scriptSubmit.Canvas_result.transform, false);
                    j -= 70f;
                }
            }
           
        }
       
    }
    public void startTimer()
    {
        slider.enabled = true;
        startslider = true;
        stage1_timeButManage.translucent.SetActive(false);
        stage5_submitClick.submitOn = false;
        temp.gameObject.SetActive(false);
        temp2.gameObject.SetActive(false);
    }

    public GameObject ObjectRandomGenerator()
    {
        //플레이팅 예시 오브젝트 랜덤 생성


        GameObject[] sample = new GameObject[24];
        sample[0] = randomSample[0];
        sample[1] = randomSample[1];
        sample[2] = randomSample[2];
        sample[3] = randomSample[3];
        sample[4] = randomSample[4];
        sample[5] = randomSample[5];
        sample[6] = randomSample[6];
        sample[7] = randomSample[7];
        sample[8] = randomSample[8];
        sample[9] = randomSample[9];
        sample[10] = randomSample[10];
        sample[11] = randomSample[11];
        sample[12] = randomSample[12];
        sample[13] = randomSample[13];
        sample[14] = randomSample[14];
        sample[15] = randomSample[15];
        sample[16] = randomSample[16];
        sample[17] = randomSample[17];
        sample[18] = randomSample[18];
        sample[19] = randomSample[19];
        sample[20] = randomSample[20];
        sample[21] = randomSample[21];
        sample[22] = randomSample[22];
        sample[23] = randomSample[23];

        int RN = Random.Range(0, 24);
        GameObject temp = sample[RN];
        Debug.Log(RN);
        //while (currentSample == temp.name) {
        //    temp = sample[Random.Range(0, 6)];
        //    Debug.Log(temp.name);
        //}
        RN += 1;
        currentSample ="platingSample"+RN;
        Debug.Log(currentSample);

        return Instantiate(temp, new Vector3(0, -0.45f, 0f), Quaternion.identity);

    }
    public void stopTimer() {

        slider.enabled =false;
    }
}
