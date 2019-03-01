
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage1_submitClick : MonoBehaviour
{
    //제출 버튼 + 점수관리
    public Text scoreText;
    public static int score;

    public Text temp;
    public Text temp2;
    public Text finalScoreText;

    private stage1_timerManage scriptTimer;
   // public GameObject Slider;
    public GameObject tutoStartBut;
    public GameObject clone;

    public static int submitCount = 0;
    public int Nplating = 1;
    public static int scoreSum = 0;


    public static bool submitOn = false;
 
    public static int hintCount = 0;

    public GameObject clear;
    public GameObject fail;

    public static bool sliderStopped = false;

    public GameObject endingBut;
    public GameObject retryBut;
    public GameObject mainBut;

    public string[] platingResult; //제출한 요리 순서 + 가격
    public GameObject textclone;
    public Canvas Canvas_result;

    
    void Start()
    {
        submitOn = false;
        sliderStopped = false;

        score = 0;
        submitCount = 0;
        scoreSum = 0;
        hintCount = 0;
        SetScoreText(0);

        // scriptTimer = Slider.GetComponent<stage1_timerManage>();
        scriptTimer = tutoStartBut.GetComponent<stage1_timerManage>();
     
    }

    public void SetScoreText(int sumscore)
    {
        score += sumscore;
        scoreText.text = score.ToString()+"원";
    }
  
    private void OnMouseDown()
    {

        //sound
        gameObject.GetComponent<AudioSource>().Play();

        hintCount = 0; //힌트 횟수 초기화

        if (stage1_timerManage.currentSample == "platingSample1")
            checkPlating1();
        else if (stage1_timerManage.currentSample == "platingSample2")
            checkPlating2();
        else if (stage1_timerManage.currentSample == "platingSample3")
            checkPlating3();
        else if (stage1_timerManage.currentSample == "platingSample4")
            checkPlating4();
        else if (stage1_timerManage.currentSample == "platingSample5")
            checkPlating5();
        else if (stage1_timerManage.currentSample == "platingSample6")
            checkPlating6();


        submitCount++;
        Nplating++;

        if (score >= 20000 && submitCount <= 5)
        {
            if (stage1_flyManage.flyOn)
            {
                GameObject obstacle = GameObject.Find("fly(Clone)");
                Destroy(obstacle);
            }

            //클리어
            sceneMoving.ClearStage(1);
            scriptTimer.startslider = false;
            sliderStopped = true;
            Instantiate(clear, new Vector3(0.0f, 0.0f,-1f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
            finalScoreText.gameObject.SetActive(true);
            finalScoreText.text = "최종점수 : " + score.ToString() + "원";


            //엔딩버튼
            for (int i = 0; i < endingBut.transform.childCount; i++)
            {
                endingBut.transform.GetChild(i).gameObject.SetActive(true);
            }

            float j = 150f;
            for (int i = 0; i < platingResult.Length; i++)
            {
                Debug.Log(platingResult[i]);
                GameObject Clone = Instantiate(textclone, new Vector3(-200f, j, 0), transform.rotation) as GameObject;
                Clone.GetComponent<Text>().text = platingResult[i];

                Clone.transform.SetParent(Canvas_result.transform, false);
                j -= 70f;
            }


        }
        else if ((score < 20000) && (submitCount ==5))
        {
            //실패

            if (stage1_flyManage.flyOn)
            {
                GameObject obstacle = GameObject.Find("fly(Clone)");
                Destroy(obstacle);
            }

            scriptTimer.startslider = false;
            sliderStopped = true;
            Instantiate(fail, new Vector3(0.0f, 0.0f, -1f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
            finalScoreText.gameObject.SetActive(true);
            finalScoreText.text = "최종점수 : "+score.ToString()+"원";

            retryBut.SetActive(true);
            mainBut.SetActive(true);


            //점수 기록 출력
            float j = 150f;
            for (int i = 0; i < platingResult.Length; i++)
            {             
                Debug.Log(platingResult[i]);
                GameObject Clone =Instantiate(textclone, new Vector3(-200f,j,0), transform.rotation) as GameObject;
                Clone.GetComponent<Text>().text = platingResult[i];
                
                Clone.transform.SetParent(Canvas_result.transform,false);
                j -= 70f;
            }

        }
        else if ((score < 20000) && (submitCount < 5))
        {
            //다음 접시
            temp.text = Nplating.ToString(); //N번째 접시 text
            temp.gameObject.SetActive(true);
            temp2.gameObject.SetActive(true);

            stage1_timeButManage.translucent.SetActive(true);
            //scriptTimer.slider.enabled = false;
            scriptTimer.startslider = false;
            sliderStopped = true;
            stage1_plating.deleteAll();

            clone = scriptTimer.ObjectRandomGenerator();
            submitOn = true;

            Time.timeScale = 1;
            Invoke("submitStartTimer", 7.0f);
            Destroy(clone, 7.0f);
           
           
        }
    }

    public void submitStartTimer()
    {
      
        temp.gameObject.SetActive(false);
        temp2.gameObject.SetActive(false);

        scriptTimer.startslider = true;
        stage1_timeButManage.translucent.SetActive(false);
        submitOn = false;
        sliderStopped =false;
    }

    /*===================================================================== < platingSample1 > =======================================================================*/

    public void checkPlating1() {

        int platingScore = 7000;
        //float tempCarrotX = 0;
        GameObject tempNoodle = null;
        GameObject tempBroth = null;
       // GameObject tempBasil = null;
        GameObject[] tempBasil = new GameObject[5];
        GameObject[] tempCherrytomato = new GameObject[5];
        GameObject[] tempCarrot = new GameObject[5];
        GameObject[] tempCucumber = new GameObject[5];

        //기준 1100원
        int cherrytomatoCount = 0;
        int cucumberCount = 0;
        int carrotCount= 0;
        int noodleCount = 0;
        int brothCount = 0;
        int basilCount = 0;

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedNoodle(Clone)")
            {              
                tempNoodle = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                noodleCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBroth(Clone)")
            {
                tempBroth = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                brothCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBasil(Clone)")
            {
                tempBasil[basilCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                basilCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCarrot_slice(Clone)")
            {
          
                tempCarrot[carrotCount]= stage1_plating.platedParent.transform.GetChild(i).gameObject;
                carrotCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCucumber_chop(Clone)")
            {

                tempCucumber[cucumberCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cucumberCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherrytomato(Clone)")
            {
                tempCherrytomato[cherrytomatoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherrytomatoCount++;

            }
            else {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크
        //딸기 체크x
        if ((tempBasil[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < basilCount; i++)
            {
                if (tempBasil[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
                if (tempBasil[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;
            }
        }
        if ((tempCarrot[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < carrotCount; i++)
            {
                if (tempCarrot[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
                if (tempCarrot[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;

                for (int j = 0; j < basilCount; j++)
                {
                    //당근이 바질보다 위에 있으면 감산
                    if (tempCarrot[i].transform.position.z < tempBasil[j].transform.position.z) platingScore -= 100;
                }
            }
        }
        if ((tempCucumber[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < cucumberCount; i++)
            {
                if (tempCucumber[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;
                if (tempCucumber[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
            }
        }
        // 있어야할 재료가 모자르면 -(1100÷해당 재료 전체갯수)*모자른 갯수
        if (noodleCount==0) platingScore -= 1100;
        if (brothCount == 0) platingScore -= 1100;
        if (basilCount == 0) platingScore -= 1100;
        if (carrotCount == 0)
            platingScore -= 1100;
        else if (carrotCount > 0 && carrotCount < 3)
            platingScore -= (300)*(3 - carrotCount);
        if (cucumberCount == 0)
            platingScore -= 1100;
        else if (cucumberCount > 0 && cucumberCount < 3)
            platingScore -= (300) * (3 - cucumberCount);
        if (cherrytomatoCount == 0) platingScore -= 1100;
        else if (cherrytomatoCount == 1) platingScore -= 500;

        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;


        Vector2 carrot1Answer = new Vector2(-0.15f,-0.3f); //첫번째 당근 정답
        Vector2 carrot2Answer = new Vector2(0.02f, -0.55f);
        Vector2 carrot3Answer = new Vector2(0.21f, -0.78f);
        Vector2[] carrotAnswer = { carrot1Answer, carrot2Answer, carrot3Answer };
        Vector2 basilAnswer = new Vector2(0.08f,-0.54f);
        Vector2 cherrytomato1Answer = new Vector2(3.33f, -1.12f);
        Vector2 cherrytomato2Answer = new Vector2(3.14f, -1.92f);
        Vector2[] cherrytomatoAnswer = { cherrytomato1Answer, cherrytomato2Answer };
        Vector2 cucumber1Answer = new Vector2(0.005f,1.21f);
        Vector2 cucumber2Answer = new Vector2(-1.56f, -1.43f);
        Vector2 cucumber3Answer = new Vector2(1.46f, -1.54f);
        Vector2[] cucumberAnswer = { cucumber1Answer, cucumber2Answer, cucumber3Answer };


        if (basilCount > 0) {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < basilCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("바질"+minDist);
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("바질위치체크후" + platingScore);
            minDist = 100f;
            if (basilCount > 1)
            {
                platingScore -= (basilCount - 1) *(1100);
            }

        }

        if (cucumberCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            for (int i = 0; i < cucumberCount; i++)
            {
                for (int j = 0; j < cucumberAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("오이1위치체크후" + platingScore);
            minDist = 100f;
            if (cucumberCount > 1)
            {
                for (int i = 0; (i < cucumberCount); i++)
                {
                    for (int j = 0; (j < cucumberAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 0.5) platingScore -= 1100;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("오이2위치체크후" + platingScore);
                minDist = 100f;
                if (cucumberCount > 2)
                {
                    for (int i = 0; i < cucumberCount; i++)
                    {
                        for (int j = 0; j < cucumberAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 0.5) platingScore -= 1100;
                    else platingScore -= (int)(minDist / 0.1) * 100;
                    Debug.Log("오이3위치체크후" + platingScore);
                    minDist = 100f;
                    if (cucumberCount > 3)
                    {
                        platingScore -= (cucumberCount - 3) * (300);
                    }

                }

            }

        }

        if (carrotCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            for (int i = 0; i < carrotCount; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1+"  "+tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("당근1위치체크후" + platingScore);
            minDist = 100f;
            if (carrotCount > 1)
            {
                for (int i = 0; (i < carrotCount); i++)
                {
                    for (int j = 0; (j < carrotAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
               // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 0.5) platingScore -= 1100;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("당근2위치체크후" + platingScore);
                minDist = 100f;
                if (carrotCount > 2)
                {
                    for (int i = 0; i < carrotCount; i++)
                    {
                        for (int j = 0;j < carrotAnswer.Length ; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                   // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 0.5) platingScore -= 1100;
                    else platingScore -= (int)(minDist / 0.1) * 100;
                    Debug.Log("당근3위치체크후" + platingScore);
                    minDist = 100f;
                    if (carrotCount > 3) {
                        platingScore-=(carrotCount - 3) * (300);
                    }

                }
                
            }
         
        }

        if (cherrytomatoCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
           
            for (int i = 0; i < cherrytomatoCount; i++)
            {
                for (int j = 0; j < cherrytomatoAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log("방토"+minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) *100;
            Debug.Log("방토1위치체크후" + platingScore);
            minDist = 100f;
            if (cherrytomatoCount > 1)
            {
                for (int i = 0; (i < cherrytomatoCount); i++)
                {
                    for (int j = 0; (j < cherrytomatoAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log("방토"+minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 0.5) platingScore -= 1100;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("방토2위치체크후" + platingScore);
                minDist = 100f;
                if (cherrytomatoCount > 2)
                {
                    platingScore -= (cherrytomatoCount - 2) * (500);
                }
            }
        }

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점
        Debug.Log(platingScore);
        if (platingScore < 0) platingScore = 0;
        Debug.Log("0점 미만->"+platingScore);

        SetScoreText(platingScore);
       //Debug.Log("누들x:" + tempNoodle.transform.position.x + "누들y:" + tempNoodle.transform.position.y);
        //Debug.Log("육수x:" + tempBroth.transform.position.x + "육수y:" + tempBroth.transform.position.y);
      //Debug.Log("당근1x:" + tempCarrot[0].transform.position.x + "당근1y:" + tempCarrot[0].transform.position.y);
        //Debug.Log("당근2x:" + tempCarrot[1].transform.position.x + "당근2y:" + tempCarrot[1].transform.position.y);
        //Debug.Log("당근3x:" + tempCarrot[2].transform.position.x + "당근3y:" + tempCarrot[2].transform.position.y);
        //Debug.Log("딸기1x:" + tempStrawberry[0].transform.position.x + "딸기1y:" + tempStrawberry[0].transform.position.y);

        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore+"원";

        tempNoodle = null;
        tempBroth = null;
        tempBasil = null;
        tempCherrytomato = null;
       tempCarrot = null;

    
    }

    /*===================================================================== < platingSample2 > =======================================================================*/

    public void checkPlating2()
    {

        int platingScore = 7000;
        //float tempCarrotX = 0;
        GameObject tempNoodle = null;
        GameObject tempBroth = null;
        // GameObject tempBasil = null;
        GameObject[] tempBasil = new GameObject[5];
        GameObject[] tempCherrytomato = new GameObject[5];
        GameObject[] tempCarrot = new GameObject[5];
        GameObject[] tempCucumber = new GameObject[5];

       //기준1400원
        int cucumberCount = 0;
        int carrotCount = 0;
        int noodleCount = 0;
        int brothCount = 0;
        int basilCount = 0;

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedNoodle(Clone)")
            {
                tempNoodle = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                noodleCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBroth(Clone)")
            {
                tempBroth = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                brothCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBasil(Clone)")
            {
                tempBasil[basilCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                basilCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCarrot_chop(Clone)")
            {

                tempCarrot[carrotCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                carrotCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCucumber_slice(Clone)")
            {

                tempCucumber[cucumberCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cucumberCount++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크
        if ((tempBasil[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < basilCount; i++)
            {
                if (tempBasil[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
                if (tempBasil[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;
            }
        }

        if ((tempCarrot[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < carrotCount; i++)
            {
                if (tempCarrot[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
                if (tempCarrot[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;

                if (tempCucumber[0] != null)
                {
                    for (int j = 0; j < cucumberCount; j++)
                    {
                        //당근이 오이보다 위에 있으면 감산
                        if (tempCarrot[i].transform.position.z < tempCucumber[j].transform.position.z) platingScore -= 100;
                    }
                }
            }
        }

        if ((tempCucumber[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < cucumberCount; i++)
            {
                if (tempCucumber[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
                if (tempCucumber[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;
            }
        }
        // 있어야할 재료가 모자르면 -(1000÷해당 재료 전체갯수)*모자른 갯수
        if (noodleCount == 0) platingScore -= 1400;
        if (brothCount == 0) platingScore -= 1400;
        if (basilCount == 0) platingScore -= 1400;
        if (carrotCount == 0)
            platingScore -= 1400;
        else if (carrotCount > 0 && carrotCount < 4)
            platingScore -= (300) * (4 - carrotCount);
        if (cucumberCount == 0)
            platingScore -= 1100;
        else if (cucumberCount > 0 && cucumberCount < 4)
            platingScore -= (300) * (4 - cucumberCount);
       

        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;


        Vector2 carrot1Answer = new Vector2(0.1f, 1.19f); //첫번째 당근 정답
        Vector2 carrot2Answer = new Vector2(-1.71f, -0.64f);
        Vector2 carrot3Answer = new Vector2(0.08f, -2.21f);
        Vector2 carrot4Answer = new Vector2(1.7f, -0.55f);
        Vector2[] carrotAnswer = { carrot1Answer, carrot2Answer, carrot3Answer, carrot4Answer};
        Vector2 basilAnswer = new Vector2(0.03f, -0.52f);
        Vector2 cucumber1Answer = new Vector2(-1.27f,0.62f);
        Vector2 cucumber2Answer = new Vector2(-1.14f, -1.76f);
        Vector2 cucumber3Answer = new Vector2(1.22f, -1.72f);
        Vector2 cucumber4Answer = new Vector2(1.3f, 0.58f);
        Vector2[] cucumberAnswer = { cucumber1Answer, cucumber2Answer, cucumber3Answer, cucumber4Answer};


        if (basilCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < basilCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("바질" + minDist);
            if (minDist > 0.5) platingScore -= 1400;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("바질위치체크후" + platingScore);
            minDist = 100f;
            if (basilCount > 1)
            {
                platingScore -= (basilCount - 1) * (1400);
            }

        }

        if (cucumberCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < cucumberCount; i++)
            {
                for (int j = 0; j <4; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 1400;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("오이1위치체크후" + platingScore);
            minDist = 100f;
            if (cucumberCount > 1)
            {
                for (int i = 0; (i < cucumberCount); i++)
                {
                    for (int j = 0; (j < cucumberAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 0.5) platingScore -= 1400;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("오이2위치체크후" + platingScore);
                minDist = 100f;
                if (cucumberCount > 2)
                {
                    for (int i = 0; i < cucumberCount; i++)
                    {
                        for (int j = 0; j < cucumberAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 0.5) platingScore -= 1400;
                    else platingScore -= (int)(minDist / 0.1) * 100;
                    Debug.Log("오이3위치체크후" + platingScore);
                    minDist = 100f;
                    if (cucumberCount > 3)
                    {
                        for (int i = 0; i < cucumberCount; i++)
                        {
                            for (int j = 0; j < cucumberAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                        // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 0.5) platingScore -= 1400;
                        else platingScore -= (int)(minDist / 0.1) * 100;
                        Debug.Log("오이4위치체크후" + platingScore);
                        minDist = 100f;
                        if (cucumberCount > 4)
                        {
                            platingScore -= (cucumberCount - 4) * (300);
                        }

                    }

                }

            }
        }
        if (carrotCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < carrotCount; i++)
            {
                for (int j = 0; j < carrotAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 1400;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("당근1위치체크후" + platingScore);
            minDist = 100f;
            if (carrotCount > 1)
            {
                for (int i = 0; (i < carrotCount); i++)
                {
                    for (int j = 0; (j < carrotAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 0.5) platingScore -= 1400;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("당근2위치체크후" + platingScore);
                minDist = 100f;
                if (carrotCount > 2)
                {
                    for (int i = 0; i < carrotCount; i++)
                    {
                        for (int j = 0; j < carrotAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 0.5) platingScore -= 1400;
                    else platingScore -= (int)(minDist / 0.1) * 100;
                    Debug.Log("당근3위치체크후" + platingScore);
                    minDist = 100f;
                    if (carrotCount > 3)
                    {
                        for (int i = 0; i < carrotCount; i++)
                        {
                            for (int j = 0; j < carrotAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 0.5) platingScore -= 1400;
                        else platingScore -= (int)(minDist / 0.1) *100;
                        Debug.Log("당근4위치체크후" + platingScore);
                        minDist = 100f;
                        if (carrotCount > 4)
                        {
                            platingScore -= (carrotCount - 4) * (300);
                        }
                    }
                }

            }

        }

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점
        Debug.Log(platingScore);
        if (platingScore < 0) platingScore = 0;
        Debug.Log("0점 미만->" + platingScore);
        SetScoreText(platingScore);
       int tempSubmitCount = submitCount+1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempNoodle = null;
        tempBroth = null;
        tempBasil = null;
        tempCarrot = null;

    }

    /*===================================================================== < platingSample3 > =======================================================================*/
    public void checkPlating3()
    {

        int platingScore = 7000;

        GameObject tempDumpling = null;

        GameObject[] tempCherry = new GameObject[5];
        GameObject[] tempAsparagus = new GameObject[5];
        GameObject[] tempBlueberry = new GameObject[5];

        //기준:1700원
        int cherryCount = 0;
        int asparagusCount = 0;
        int blueberryCount = 0;
        int dumplingCount = 0;

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedDumpling(Clone)")
            {
                tempDumpling = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                dumplingCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherry(Clone)")
            {
                tempCherry[cherryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBlueberry(Clone)")
            {

                tempBlueberry[blueberryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedAsparagus_grill(Clone)")
            {

                tempAsparagus[asparagusCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                asparagusCount++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크X

        // 있어야할 재료가 모자르면 -(1000÷해당 재료 전체갯수)*모자른 갯수
        if (dumplingCount == 0) platingScore -= 1700;
        if (cherryCount == 0) platingScore -= 1700;
        if (asparagusCount == 0) platingScore -= 1700;
        if (blueberryCount == 0)
            platingScore -= 1700;
        else if (blueberryCount == 1)
            platingScore -= 800;



        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;


        Vector2 asparagusAnswer = new Vector2(-0.1f, -2.39f);
        Vector2 cherryAnswer = new Vector2(-0.02f, -1.87f);
        Vector2 blueberry1Answer = new Vector2(-1.55f, -1.98f);
        Vector2 blueberry2Answer = new Vector2(1.51f, -1.98f);
        Vector2[] blueberryAnswer = { blueberry1Answer, blueberry2Answer };


        if (asparagusCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < asparagusCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempAsparagus[i].transform.position.x, tempAsparagus[i].transform.position.y), asparagusAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempAsparagus[i].transform.position.x, tempAsparagus[i].transform.position.y), asparagusAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("아스파라거스" + minDist);
            if (minDist > 0.5) platingScore -= 1700;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("아스파라거스위치체크후" + platingScore);
            minDist = 100f;
            if (asparagusCount > 1)
            {
                platingScore -= (asparagusCount - 1) * (1000 / 1);
            }

        }

        if (cherryCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < cherryCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("체리" + minDist);
            if (minDist > 0.5) platingScore -= 1700;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("체리위치체크후" + platingScore);
            minDist = 100f;
            if (cherryCount > 1)
            {
                platingScore -= (cherryCount - 1) * (1700);
            }

        }

        if (blueberryCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < blueberryCount; i++)
            {
                for (int j = 0; j < blueberryAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempBlueberry[i].transform.position.x, tempBlueberry[i].transform.position.y), blueberryAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempBlueberry[i].transform.position.x, tempBlueberry[i].transform.position.y), blueberryAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 1700;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("블루베리1위치체크후" + platingScore);
            minDist = 100f;
            if (blueberryCount > 1)
            {
                for (int i = 0; (i < blueberryCount); i++)
                {
                    for (int j = 0; j < blueberryAnswer.Length; j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempBlueberry[i].transform.position.x, tempBlueberry[i].transform.position.y), blueberryAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempBlueberry[i].transform.position.x, tempBlueberry[i].transform.position.y), blueberryAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 0.5) platingScore -= 1700;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("블루베리2위치체크후" + platingScore);
                minDist = 100f;
                if (blueberryCount > 2)
                {
                    platingScore -= (blueberryCount - 2) * (800);
                }

            }

        }

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점
        Debug.Log(platingScore);
        if (platingScore < 0)
        {
            platingScore = 0;
            Debug.Log("0점 미만->" + platingScore);
        }
        SetScoreText(platingScore);
        int tempSubmitCount = submitCount+1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempDumpling = null;
        tempCherry = null;
        tempBlueberry = null;
        tempAsparagus = null;

    }

    /*===================================================================== < platingSample4 > =======================================================================*/
    public void checkPlating4()
    {

        int platingScore = 7000;

        GameObject tempDumpling = null;
        GameObject[] tempBroccoli = new GameObject[5];
        GameObject[] tempOrange = new GameObject[5];

        //기준 2300원
        int broccoliCount = 0;
        int orangeCount = 0;
        int dumplingCount = 0;

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedDumpling(Clone)")
            {
                tempDumpling = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                dumplingCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBroccoli(Clone)")
            {
                tempBroccoli[broccoliCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                broccoliCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedOrange_chop(Clone)")
            {

                tempOrange[orangeCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                orangeCount++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크X

        // 있어야할 재료가 모자르면 -(1000÷해당 재료 전체갯수)*모자른 갯수
        if (dumplingCount == 0) platingScore -= 2300;
        if (broccoliCount == 0)
            platingScore -= 2300;
        else if (broccoliCount > 0 && broccoliCount < 3)
            platingScore -= (700) * (3 - broccoliCount);
        if (orangeCount == 0)
            platingScore -= 2300;
        else if (orangeCount > 0 && orangeCount < 3)
            platingScore -= (700) * (3 - orangeCount);


        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;


        Vector2 orange1Answer = new Vector2(-2.41f, -1.98f);
        Vector2 orange2Answer = new Vector2(-0.05f, -3f);
        Vector2 orange3Answer = new Vector2(2.21f, -2.03f);
        Vector2[] orangeAnswer = { orange1Answer, orange2Answer, orange3Answer };
        Vector2 broccoli1Answer = new Vector2(-1.19f,1.76f);
        Vector2 broccoli2Answer = new Vector2(0.12f, 1.72f);
        Vector2 broccoli3Answer = new Vector2(1.35f, 1.7f);
        Vector2[] broccoliAnswer = { broccoli1Answer, broccoli2Answer, broccoli3Answer };


        if (orangeCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;

            for (int i = 0; i < orangeCount; i++)
            {
                for (int j = 0; j < orangeAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempOrange[i].transform.position.x, tempOrange[i].transform.position.y), orangeAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempOrange[i].transform.position.x, tempOrange[i].transform.position.y), orangeAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 2300;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("오렌지1위치체크후" + platingScore);
            minDist = 100f;
            if (orangeCount > 1)
            {
                for (int i = 0; (i < orangeCount); i++)
                {
                    for (int j = 0; (j < orangeAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempOrange[i].transform.position.x, tempOrange[i].transform.position.y), orangeAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempOrange[i].transform.position.x, tempOrange[i].transform.position.y), orangeAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 0.5) platingScore -= 2300;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("오렌지2위치체크후" + platingScore);
                minDist = 100f;
                if (orangeCount > 2)
                {
                    for (int i = 0; i < orangeCount; i++)
                    {
                        for (int j = 0; j < orangeAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempOrange[i].transform.position.x, tempOrange[i].transform.position.y), orangeAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempOrange[i].transform.position.x, tempOrange[i].transform.position.y), orangeAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 0.5) platingScore -= 2300;
                    else platingScore -= (int)(minDist / 0.1) * 100;
                    Debug.Log("오렌지3위치체크후" + platingScore);
                    minDist = 100f;
                   
                        if (orangeCount > 3)
                        {
                            platingScore -= (orangeCount - 3) * (700);
                        }

                    }

                }

            
        }

        if (broccoliCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            for (int i = 0; i < broccoliCount; i++)
            {
                for (int j = 0; j < broccoliAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempBroccoli[i].transform.position.x, tempBroccoli[i].transform.position.y), broccoliAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempBroccoli[i].transform.position.x, tempBroccoli[i].transform.position.y), broccoliAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 2300;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("브로콜리1위치체크후" + platingScore);
            minDist = 100f;
            if (broccoliCount > 1)
            {
                for (int i = 0; (i < broccoliCount); i++)
                {
                    for (int j = 0; (j < broccoliAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempBroccoli[i].transform.position.x, tempBroccoli[i].transform.position.y), broccoliAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempBroccoli[i].transform.position.x, tempBroccoli[i].transform.position.y), broccoliAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 0.5) platingScore -= 2300;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("브로콜리2위치체크후" + platingScore);
                minDist = 100f;
                if (broccoliCount > 2)
                {
                    for (int i = 0; i < broccoliCount; i++)
                    {
                        for (int j = 0; j < broccoliAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempBroccoli[i].transform.position.x, tempBroccoli[i].transform.position.y), broccoliAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempBroccoli[i].transform.position.x, tempBroccoli[i].transform.position.y), broccoliAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 0.5) platingScore -= 2300;
                    else platingScore -= (int)(minDist / 0.1) * 100;
                    Debug.Log("브로콜리3위치체크후" + platingScore);
                    minDist = 100f;
                    if (broccoliCount > 3)
                    {
                        platingScore -= (broccoliCount - 3) * (700);
                    }

                }

            }

        }
        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점
        Debug.Log(platingScore);
        if (platingScore < 0) platingScore = 0;
        Debug.Log("0점 미만->" + platingScore);
        SetScoreText(platingScore);
        int tempSubmitCount = submitCount+1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempDumpling = null;
        tempOrange = null;
        tempBroccoli = null;

    }

    /*===================================================================== < platingSample5 > =======================================================================*/

    public void checkPlating5()
    {

        int platingScore = 7000;
        //float tempCarrotX = 0;
        GameObject tempNoodle = null;
        GameObject tempBroth = null;
        GameObject[] tempIce = new GameObject[5];
        GameObject[] tempCarrot = new GameObject[5];
        GameObject[] tempCucumber = new GameObject[5];
        GameObject[] tempRadishsprout = new GameObject[5];

        //기준 1100
        int iceCount = 0;
        int cucumberCount = 0;
        int carrotCount = 0;
        int noodleCount = 0;
        int brothCount = 0;
        int radishsproutCount = 0;

        if (stage1_plating.platedParent.transform.childCount==0) platingScore = 0; //아무것도 없을시 0점

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedNoodle(Clone)")
            {
                tempNoodle = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                noodleCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBroth(Clone)")
            {
                tempBroth = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                brothCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedRadishsprout(Clone)")
            {
                tempRadishsprout[radishsproutCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                radishsproutCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCarrot_chop(Clone)")
            {

                tempCarrot[carrotCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                carrotCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCucumber_chop(Clone)")
            {

                tempCucumber[cucumberCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cucumberCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedIce(Clone)")
            {
                tempIce[iceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                iceCount++;

            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크
        if ((tempRadishsprout[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < radishsproutCount; i++)
            {
                if (tempRadishsprout[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
                if (tempRadishsprout[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;
            }
        }

        if ((tempCarrot[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < carrotCount; i++)
            {
                if (tempCarrot[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
                if (tempCarrot[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;
            }
        }

        if ((tempCucumber[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < cucumberCount; i++)
            {
                if (tempCucumber[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
                if (tempCucumber[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;
            }
        }

        if ((tempIce[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < iceCount; i++)
            {
                if (tempIce[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
                if (tempIce[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;
            }
        }
        // 있어야할 재료가 모자르면 -(1000÷해당 재료 전체갯수)*모자른 갯수
        if (noodleCount == 0) platingScore -= 1100;
        if (brothCount == 0) platingScore -= 1100;
        if (radishsproutCount == 0) platingScore -= 1100;
        if (cucumberCount == 0) platingScore -= 1100;

        if (carrotCount == 0)
            platingScore -= 1100;
        else if (carrotCount ==1)
            platingScore -= 500;

        if (iceCount == 0)
            platingScore -= 1100;
        else if (iceCount > 0 && iceCount < 3)
            platingScore -= (300) * (3 - iceCount);
       

        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;


        Vector2 carrot1Answer = new Vector2(1.57f, 0.31f); //첫번째 당근 정답
        Vector2 carrot2Answer = new Vector2(-0.06f, -2.24f);
        Vector2[] carrotAnswer = { carrot1Answer, carrot2Answer };
        Vector2 cucumberAnswer = new Vector2(-1.49f, 0.19f);
        Vector2 radishsproutAnswer = new Vector2(0.05f, -0.5f);
        Vector2 ice1Answer = new Vector2(0f, 1.18f);
        Vector2 ice2Answer = new Vector2(-1.5f, -1.4f);
        Vector2 ice3Answer = new Vector2(1.42f, -1.38f);
        Vector2[] iceAnswer = { ice1Answer, ice2Answer, ice3Answer };


        if (radishsproutCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < radishsproutCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("무순" + minDist);
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("무순위치체크후" + platingScore);
            minDist = 100f;
            if (radishsproutCount > 1)
            {
                platingScore -= (radishsproutCount - 1) * (1100);
            }

        }

        if (cucumberCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < cucumberCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("오이" + minDist);
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("오이위치체크후" + platingScore);
            minDist = 100f;
            if (cucumberCount > 1)
            {
                platingScore -= (cucumberCount - 1) * (1100);
            }

        }

        if (iceCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            for (int i = 0; i < iceCount; i++)
            {
                for (int j = 0; j < iceAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("얼음1위치체크후" + platingScore);
            minDist = 100f;
            if (iceCount > 1)
            {
                for (int i = 0; (i < iceCount); i++)
                {
                    for (int j = 0; (j < iceAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 0.5) platingScore -= 1100;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("얼음2위치체크후" + platingScore);
                minDist = 100f;
                if (iceCount > 2)
                {
                    for (int i = 0; i < iceCount; i++)
                    {
                        for (int j = 0; j < iceAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 0.5) platingScore -= 1100;
                    else platingScore -= (int)(minDist / 0.1) * 100;
                    Debug.Log("얼음3위치체크후" + platingScore);
                    minDist = 100f;
                    if (iceCount > 3)
                    {
                        platingScore -= (iceCount - 3) * (300);
                    }

                }

            }

        }

        if (carrotCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < carrotCount; i++)
            {
                for (int j = 0; j < carrotAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("당근1위치체크후" + platingScore);
            minDist = 100f;
            if (carrotCount > 1)
            {
                for (int i = 0; (i < carrotCount); i++)
                {
                    for (int j = 0; (j < carrotAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 0.5) platingScore -= 1100;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("당근2위치체크후" + platingScore);
                minDist = 100f;
               
                if (carrotCount > 2)
                {
                  platingScore -= (carrotCount - 2) * (500);
                }

            }

            

        }


        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점
        Debug.Log(platingScore);
        if (platingScore < 0) platingScore = 0;
        Debug.Log("0점 미만->" + platingScore);

        SetScoreText(platingScore);
        int tempSubmitCount = submitCount+1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempNoodle = null;
        tempBroth = null;
        tempRadishsprout = null;
        tempCucumber = null;
        tempCarrot = null;
        tempIce = null;


    }

    /*===================================================================== < platingSample6 > =======================================================================*/

    public void checkPlating6()
    {
        int platingScore = 7000;
        //float tempCarrotX = 0;
        GameObject tempNoodle = null;
        GameObject tempBroth = null;
        GameObject[] tempIce = new GameObject[5];
        GameObject[] tempCarrot = new GameObject[5];
        GameObject[] tempCucumber = new GameObject[5];
        GameObject[] tempLemon = new GameObject[5];

        //기준1100
        int noodleCount = 0;
        int brothCount = 0;
        int iceCount = 0;
        int cucumberCount = 0;
        int carrotCount = 0;
        int lemonCount = 0;

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedNoodle(Clone)")
            {
                tempNoodle = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                noodleCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBroth(Clone)")
            {
                tempBroth = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                brothCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedLemon_chop(Clone)")
            {
                tempLemon[lemonCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                lemonCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCarrot_slice(Clone)")
            {

                tempCarrot[carrotCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                carrotCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCucumber_slice(Clone)")
            {

                tempCucumber[cucumberCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cucumberCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedIce(Clone)")
            {
                tempIce[iceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                iceCount++;

            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크
        if ((tempLemon[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < lemonCount; i++)
            {
                if (tempLemon[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
                if (tempLemon[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;
            }
        }

        if ((tempCarrot[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < carrotCount; i++)
            {
                if (tempCarrot[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
                if (tempCarrot[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;
            }
        }

        if ((tempCucumber[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < cucumberCount; i++)
            {
                if (tempCucumber[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
                if (tempCucumber[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;
            }
        }

        if ((tempIce[0] != null) && (tempNoodle != null) && (tempBroth != null))
        {
            for (int i = 0; i < iceCount; i++)
            {
                if (tempIce[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
                if (tempIce[i].transform.position.z > tempBroth.transform.position.z) platingScore -= 100;
            }
        }
        // 있어야할 재료가 모자르면 -(1000÷해당 재료 전체갯수)*모자른 갯수
        if (noodleCount == 0) platingScore -= 1100;
        if (brothCount == 0) platingScore -= 1100;
        if (lemonCount == 0) platingScore -= 1100;
     
        if (carrotCount == 0)
            platingScore -= 1100;
        else if (carrotCount == 1)
            platingScore -= 500;

        if (cucumberCount == 0)
            platingScore -= 1100;
        else if (cucumberCount == 1)
            platingScore -= 500;

        if (iceCount == 0)
            platingScore -= 1100;
        else if (iceCount > 0 && iceCount < 4)
            platingScore -= (200) * (4 - iceCount);


        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;


        Vector2 carrot1Answer = new Vector2(-0.19f, -0.19f); 
        Vector2 carrot2Answer = new Vector2(-0.07f, -0.45f);
        Vector2[] carrotAnswer = { carrot1Answer, carrot2Answer };
        Vector2 cucumber1Answer = new Vector2(0.14f,-0.65f);
        Vector2 cucumber2Answer = new Vector2(0.25f, -0.95f);
        Vector2[] cucumberAnswer = { cucumber1Answer, cucumber2Answer };
        Vector2 ice1Answer = new Vector2(-1.63f, 0.14f);
        Vector2 ice2Answer = new Vector2(-1.16f, -1.92f);
        Vector2 ice3Answer = new Vector2(1.27f, -1.83f);
        Vector2 ice4Answer = new Vector2(1.7f, 0.04f);
        Vector2[] iceAnswer = { ice1Answer, ice2Answer, ice3Answer, ice4Answer };
        Vector2 lemonAnswer = new Vector2(0.11f, 1.22f);


        if (lemonCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < lemonCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempLemon[i].transform.position.x, tempLemon[i].transform.position.y),lemonAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempLemon[i].transform.position.x, tempLemon[i].transform.position.y), lemonAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("레몬" + minDist);
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("레몬위치체크후" + platingScore);
            minDist = 100f;
            if (lemonCount > 1)
            {
                platingScore -= (lemonCount - 1) * (1100);
            }

        }

       

        if (iceCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 =0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < iceCount; i++)
            {
                for (int j = 0; j < iceAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("얼음1위치체크후" + platingScore);
            minDist = 100f;
            if (iceCount > 1)
            {
                for (int i = 0; (i < iceCount); i++)
                {
                    for (int j = 0; (j < iceAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 0.5) platingScore -= 1100;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("얼음2위치체크후" + platingScore);
                minDist = 100f;
                if (iceCount > 2)
                {
                    for (int i = 0; i < iceCount; i++)
                    {
                        for (int j = 0; j < iceAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 0.5) platingScore -= 1100;
                    else platingScore -= (int)(minDist / 0.1) * 100;
                    Debug.Log("얼음3위치체크후" + platingScore);
                    minDist = 100f;
                    if (iceCount > 3)
                    {
                        for (int i = 0; i < iceCount; i++)
                        {
                            for (int j = 0; j < iceAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempIce[i].transform.position.x, tempIce[i].transform.position.y), iceAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                        // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 0.5) platingScore -= 1100;
                        else platingScore -= (int)(minDist / 0.1) * 100;
                        Debug.Log("얼음4위치체크후" + platingScore);
                        minDist = 100f;
                        if (iceCount >4)
                        {
                            platingScore -= (iceCount - 4) * (200);
                        }

                    }

                }
            }
        }

        if (carrotCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < carrotCount; i++)
            {
                for (int j = 0; j < carrotAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) *100;
            Debug.Log("당근1위치체크후" + platingScore);
            minDist = 100f;
            if (carrotCount > 1)
            {
                for (int i = 0; (i < carrotCount); i++)
                {
                    for (int j = 0; (j < carrotAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCarrot[i].transform.position.x, tempCarrot[i].transform.position.y), carrotAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 0.5) platingScore -= 1100;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("당근2위치체크후" + platingScore);
                minDist = 100f;

                if (carrotCount > 2)
                {
                    platingScore -= (carrotCount - 2) * (500);
                }

            }



        }

        if (cucumberCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < cucumberCount; i++)
            {
                for (int j = 0; j < cucumberAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("오이1위치체크후" + platingScore);
            minDist = 100f;
            if (cucumberCount > 1)
            {
                for (int i = 0; (i < cucumberCount); i++)
                {
                    for (int j = 0; (j < cucumberAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCucumber[i].transform.position.x, tempCucumber[i].transform.position.y), cucumberAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 0.5) platingScore -= 1100;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("오이2위치체크후" + platingScore);
                minDist = 100f;

                if (cucumberCount > 2)
                {
                    platingScore -= (cucumberCount - 2) * (500);
                }

            }



        }

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점
        Debug.Log(platingScore);
        if (platingScore < 0) platingScore = 0;
        Debug.Log("0점 미만->" + platingScore);

        SetScoreText(platingScore);
        int tempSubmitCount = submitCount+1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";


        tempNoodle = null;
        tempBroth = null;
        tempLemon = null;
        tempCucumber = null;
        tempCarrot = null;
        tempIce = null;


    }
   
}
