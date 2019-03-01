using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//슬라이더에 붙음

public class stage2_timerManage : MonoBehaviour
{

    public Slider slider;
    public static float time = 180f;
    public static bool startslider ;
    public GameObject clone;
    public GameObject[] randomSample;
    public static string currentSample = null;

    private Stage2_stageFinish finish_script;
    GameObject finishParent;

    public static GameObject tutoStart;
    public static bool tutoStartClicked = false;

    public Text temp;
    public Text temp2;

    private Stage2_interruptManager interrupt_script;
    GameObject interruptManage;

    // Start is called before the first frame update
    void  Start()
    {

        interruptManage = GameObject.Find("interruptManage");
        interrupt_script = interruptManage.GetComponent<Stage2_interruptManager>();

        time = 180f;
        currentSample = null;

        tutoStart = GameObject.Find("tutoStart");
        finishParent = GameObject.Find("FinishParent");
        finish_script = finishParent.GetComponent<Stage2_stageFinish>();

        slider.maxValue = 180f;
        slider.minValue = 0f;


        tutoStartClicked = false;
        Stage2_submitClick.submitOn = true;
    }


    private void OnMouseDown()
    {
        if (gameObject.name == "tutoStartBut")
        {
            tutoStartClicked = true;
            tutoStart.SetActive(false);
            gameObject.SetActive(false);

            clone = ObjectRandomGenerator();
            temp.text = "1";

            Time.timeScale = 1;
            Invoke("interrupt_start", 23.0f);
            Invoke("startTimer", 7);
            Destroy(clone, 7);

        }
    }

    void interrupt_start()
    {
        interrupt_script.makeInterrupt();
    }

    // Update is called once per frame
    void Update()
    {
        if (startslider)
        {
            time -= Time.deltaTime;
            slider.value = time;
        }

        if (time <= 0)
        {
            //Stage2_stageFinish에서 끝난 후 함수 가져오기
            finish_script.StageFinish();
        }
    }



    public void startTimer()
    {
        
        slider.enabled = true;
        startslider = true;
        stage2_timeButManage.translucent.SetActive(false);
        Stage2_submitClick.submitOn = false;
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
        Debug.Log(temp.name);
        currentSample = temp.name;
       
        return Instantiate(temp, new Vector3(0, -0.45f, 0), Quaternion.identity);

    }
}
