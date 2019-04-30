using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//슬라이더에 붙음

public class stage3_timerManage : MonoBehaviour
{
   
    public Slider slider;
    public static float time = 180f;
    public bool startslider = false;
     public GameObject clone;
    public GameObject[] randomSample;
    public static string currentSample = null;

    public Text temp;
    public Text temp2;

    public static GameObject tutoStart;
    public static bool tutoStartClicked = false;

    private stage3_submitClick scriptSubmit;
    public GameObject submit;

    public GameObject catManage;

   
    // Start is called before the first frame update
    void  Start()
    {
        tutoStart = GameObject.Find("tutoStart");
        time = 180f;

        //scriptTimebut = translucent.GetComponent<stage1_timeButManage>();
        slider.enabled = false;
        slider.maxValue = 180f;
        slider.minValue = 0f;

        scriptSubmit = submit.GetComponent<stage3_submitClick>();

        currentSample = null;

    }


    private void OnMouseDown()
    {
        if (gameObject.name == "tutoStartBut")
        {
            catManage.SetActive(true);

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

            stage3_submitClick.submitOn = true;
            Time.timeScale = 1;
            Invoke("startTimer", 10.0f);
            Destroy(clone, 10.0f);
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
                if (stage3_catManage.catOn)
                {
                    GameObject obstacle = GameObject.Find("cat(Clone)");
                    Destroy(obstacle);
                }

                //타임오버 실패

                startslider = false;
                stage3_submitClick.sliderStopped = true;
                Instantiate(scriptSubmit.fail, new Vector3(0.0f, 0.0f, -1f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
                scriptSubmit.finalScoreText.gameObject.SetActive(true);
                scriptSubmit.finalScoreText.text = "최종점수 : " + stage3_submitClick.score.ToString() + "원";

                //엔딩버튼
                scriptSubmit.retryBut.SetActive(true);
                scriptSubmit.mainBut.SetActive(true);

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
            if (stage3_catPaw.minusCount == 1)
            {
                time -= 5;
                slider.value = time;
                stage3_catPaw.minusCount = 2;
                Debug.Log("시간-5");
            }
        }
       
    }
    public void startTimer()
    {

        slider.enabled = true;
        startslider = true;
        stage1_timeButManage.translucent.SetActive(false);
        stage3_submitClick.submitOn = false;
        temp.gameObject.SetActive(false);
        temp2.gameObject.SetActive(false);
    }

    public GameObject ObjectRandomGenerator()
    {
        //플레이팅 예시 오브젝트 랜덤 생성
  
        GameObject[] sample = new GameObject[6];
        sample[0] = randomSample[0];
        sample[1] = randomSample[1];
        sample[2] = randomSample[2];
        sample[3] = randomSample[3];
        sample[4] = randomSample[4];
        sample[5] = randomSample[5];
        GameObject temp = sample[Random.Range(0, 6)];

        currentSample = temp.name;
       
        return Instantiate(temp, new Vector3(0, -0.45f, 0f), Quaternion.identity);

    }
    public void stopTimer() {

        slider.enabled =false;
    }
}
