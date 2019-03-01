
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage5_submitClick : MonoBehaviour
{
    //제출 버튼 + 점수관리
    public Text scoreText;
    public static int score;

    public Text temp;
    public Text temp2;
    public Text finalScoreText;

    private stage5_timerManage scriptTimer;
   // public GameObject Slider;
    public GameObject tutoStartBut;
    public GameObject clone;

    public static int submitCount;
    public int Nplating ;
    public static int scoreSum;


    public static bool submitOn;
 
    public static int hintCount;

    public GameObject clear;
    public GameObject fail;

    public static bool sliderStopped;

    public GameObject endingBut;
    public GameObject mainBut;
    public GameObject retryBut;

    public string[] platingResult; //제출한 요리 순서 + 가격
    public GameObject textclone;
    public Canvas Canvas_result;

    private float standard1 = 1f;
    private float standard2 = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        submitCount = 0;
        Nplating = 1;
        scoreSum = 0;
        submitOn = false;
        hintCount = 0;
        sliderStopped = false;

        score = 0;
        SetScoreText(0);

        // scriptTimer = Slider.GetComponent<stage1_timerManage>();
        scriptTimer = tutoStartBut.GetComponent<stage5_timerManage>();
     
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

        if (stage5_timerManage.currentSample == "platingSample1")
            checkPlating1();
        else if (stage5_timerManage.currentSample == "platingSample2")
            checkPlating2();
        else if (stage5_timerManage.currentSample == "platingSample3")
            checkPlating3();
        else if (stage5_timerManage.currentSample == "platingSample4")
            checkPlating4();
        else if (stage5_timerManage.currentSample == "platingSample5")
            checkPlating5();
        else if (stage5_timerManage.currentSample == "platingSample6")
            checkPlating6();
        else if (stage5_timerManage.currentSample == "platingSample7")
            checkPlating7();
        else if (stage5_timerManage.currentSample == "platingSample8")
            checkPlating8();
        else if (stage5_timerManage.currentSample == "platingSample9")
            checkPlating9();
        else if (stage5_timerManage.currentSample == "platingSample10")
            checkPlating10();
        else if (stage5_timerManage.currentSample == "platingSample11")
            checkPlating11();
        else if (stage5_timerManage.currentSample == "platingSample12")
            checkPlating12();
        else if (stage5_timerManage.currentSample == "platingSample13")
            checkPlating13();
        else if (stage5_timerManage.currentSample == "platingSample14")
            checkPlating14();
        else if (stage5_timerManage.currentSample == "platingSample15")
            checkPlating15();
        else if (stage5_timerManage.currentSample == "platingSample16")
            checkPlating16();
        else if (stage5_timerManage.currentSample == "platingSample17")
            checkPlating17();
        else if (stage5_timerManage.currentSample == "platingSample18")
            checkPlating18();
        else if (stage5_timerManage.currentSample == "platingSample19")
            checkPlating19();
        else if (stage5_timerManage.currentSample == "platingSample20")
            checkPlating20();
        else if (stage5_timerManage.currentSample == "platingSample21")
            checkPlating21();
        else if (stage5_timerManage.currentSample == "platingSample22")
            checkPlating22();
        else if (stage5_timerManage.currentSample == "platingSample23")
            checkPlating23();
        else if (stage5_timerManage.currentSample == "platingSample24")
            checkPlating24();

        submitCount++;
        Nplating++;

        if (score >= 20000 && submitCount <= 5)
        {
            //클리어
            scriptTimer.startslider = false;
            sliderStopped = true;
            Instantiate(clear, new Vector3(0.0f, 0.0f,-1f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
            finalScoreText.gameObject.SetActive(true);
            finalScoreText.text = "최종점수 : " + score.ToString() + "원";
            if (stage5_mistakeManage.mistakeOn)
            {
                GameObject obstacle = GameObject.Find("mistake(Clone)");
                Destroy(obstacle);
            }
            //엔딩버튼
            for (int i = 0; i < endingBut.transform.childCount; i++)
            {
                endingBut.transform.GetChild(i).gameObject.SetActive(true);
            }

            float j = 170f;
            for (int i = 0; i < platingResult.Length; i++)
            {
                Debug.Log(platingResult[i]);
                GameObject Clone = Instantiate(textclone, new Vector3(-250f, j, 0), transform.rotation) as GameObject;
                Clone.GetComponent<Text>().text = platingResult[i];

                Clone.transform.SetParent(Canvas_result.transform, false);
                j -= 70f;
            }


        }
        else if ((score < 20000) && (submitCount ==5))
        {
            if (stage5_mistakeManage.mistakeOn)
            {
                GameObject obstacle = GameObject.Find("mistake(Clone)");
                Destroy(obstacle);
            }
            //실패
            scriptTimer.startslider = false;
            sliderStopped = true;
            Instantiate(fail, new Vector3(0.0f, 0.0f, -1f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
            finalScoreText.gameObject.SetActive(true);
            finalScoreText.text = "최종점수 : "+score.ToString()+"원";

            //엔딩버튼
            mainBut.SetActive(true);
            retryBut.SetActive(true);

            //점수 기록 출력
            float j = 170f;
            for (int i = 0; i < platingResult.Length; i++)
            {             
                Debug.Log(platingResult[i]);
                GameObject Clone =Instantiate(textclone, new Vector3(-250f,j,0), transform.rotation) as GameObject;
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

    /*====================================================+================== < Stage 1 > ==========================================================++++=============*/
    /*===================================================================== < platingSample1 > =======================================================================*/

    public void checkPlating1()
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

        //기준 1100원
        int cherrytomatoCount = 0;
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
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCarrot_slice(Clone)")
            {

                tempCarrot[carrotCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
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
            else
            {
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
        if (noodleCount == 0) platingScore -= 1100;
        if (brothCount == 0) platingScore -= 1100;
        if (basilCount == 0) platingScore -= 1100;
        if (carrotCount == 0)
            platingScore -= 1100;
        else if (carrotCount > 0 && carrotCount < 3)
            platingScore -= (300) * (3 - carrotCount);
        if (cucumberCount == 0)
            platingScore -= 1100;
        else if (cucumberCount > 0 && cucumberCount < 3)
            platingScore -= (300) * (3 - cucumberCount);
        if (cherrytomatoCount == 0) platingScore -= 1100;
        else if (cherrytomatoCount == 1) platingScore -= 500;

        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;


        Vector2 carrot1Answer = new Vector2(-0.15f, -0.3f); //첫번째 당근 정답
        Vector2 carrot2Answer = new Vector2(0.02f, -0.55f);
        Vector2 carrot3Answer = new Vector2(0.21f, -0.78f);
        Vector2[] carrotAnswer = { carrot1Answer, carrot2Answer, carrot3Answer };
        Vector2 basilAnswer = new Vector2(0.08f, -0.54f);
        Vector2 cherrytomato1Answer = new Vector2(3.33f, -1.12f);
        Vector2 cherrytomato2Answer = new Vector2(3.14f, -1.92f);
        Vector2[] cherrytomatoAnswer = { cherrytomato1Answer, cherrytomato2Answer };
        Vector2 cucumber1Answer = new Vector2(0.005f, 1.21f);
        Vector2 cucumber2Answer = new Vector2(-1.56f, -1.43f);
        Vector2 cucumber3Answer = new Vector2(1.46f, -1.54f);
        Vector2[] cucumberAnswer = { cucumber1Answer, cucumber2Answer, cucumber3Answer };


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
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("바질위치체크후" + platingScore);
            minDist = 100f;
            if (basilCount > 1)
            {
                platingScore -= (basilCount - 1) * (1100);
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
                    if (minDist > 0.5) platingScore -= 1100;
                    else platingScore -= (int)(minDist / 0.1) * 100;
                    Debug.Log("당근3위치체크후" + platingScore);
                    minDist = 100f;
                    if (carrotCount > 3)
                    {
                        platingScore -= (carrotCount - 3) * (300);
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
            Debug.Log("방토" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 0.5) platingScore -= 1100;
            else platingScore -= (int)(minDist / 0.1) * 100;
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
                Debug.Log("방토" + minDist);
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
        Debug.Log("0점 미만->" + platingScore);

        SetScoreText(platingScore);
        //Debug.Log("누들x:" + tempNoodle.transform.position.x + "누들y:" + tempNoodle.transform.position.y);
        //Debug.Log("육수x:" + tempBroth.transform.position.x + "육수y:" + tempBroth.transform.position.y);
        //Debug.Log("당근1x:" + tempCarrot[0].transform.position.x + "당근1y:" + tempCarrot[0].transform.position.y);
        //Debug.Log("당근2x:" + tempCarrot[1].transform.position.x + "당근2y:" + tempCarrot[1].transform.position.y);
        //Debug.Log("당근3x:" + tempCarrot[2].transform.position.x + "당근3y:" + tempCarrot[2].transform.position.y);
        //Debug.Log("딸기1x:" + tempStrawberry[0].transform.position.x + "딸기1y:" + tempStrawberry[0].transform.position.y);

        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

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
        Vector2[] carrotAnswer = { carrot1Answer, carrot2Answer, carrot3Answer, carrot4Answer };
        Vector2 basilAnswer = new Vector2(0.03f, -0.52f);
        Vector2 cucumber1Answer = new Vector2(-1.27f, 0.62f);
        Vector2 cucumber2Answer = new Vector2(-1.14f, -1.76f);
        Vector2 cucumber3Answer = new Vector2(1.22f, -1.72f);
        Vector2 cucumber4Answer = new Vector2(1.3f, 0.58f);
        Vector2[] cucumberAnswer = { cucumber1Answer, cucumber2Answer, cucumber3Answer, cucumber4Answer };


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
                for (int j = 0; j < 4; j++)
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
                        else platingScore -= (int)(minDist / 0.1) * 100;
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
        int tempSubmitCount = submitCount + 1;
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
        int tempSubmitCount = submitCount + 1;
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
        Vector2 broccoli1Answer = new Vector2(-1.19f, 1.76f);
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
        int tempSubmitCount = submitCount + 1;
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
        else if (carrotCount == 1)
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
        int tempSubmitCount = submitCount + 1;
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
        Vector2 cucumber1Answer = new Vector2(0.14f, -0.65f);
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
                if (Vector2.Distance(new Vector2(tempLemon[i].transform.position.x, tempLemon[i].transform.position.y), lemonAnswer) < minDist)
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
            int tempIndex4 = 0;
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
                       Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 0.5) platingScore -= 1100;
                        else platingScore -= (int)(minDist / 0.1) * 100;
                        Debug.Log("얼음4위치체크후" + platingScore);
                        minDist = 100f;
                        if (iceCount > 4)
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
        if (platingScore < 0)
        {
            platingScore = 0;
            Debug.Log("0점 미만->" + platingScore);
        }

        SetScoreText(platingScore);
        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";


        tempNoodle = null;
        tempBroth = null;
        tempLemon = null;
        tempCucumber = null;
        tempCarrot = null;
        tempIce = null;


    }


    /*========================================================================== < stage2 > ============================================================================*/
    /*===================================================================== < platingSample7 > =======================================================================*/
   
    public void checkPlating7()
    {

        int platingScore = 7000;
        GameObject tempSteak = null;
        GameObject[] tempCheddar = new GameObject[5];
        GameObject[] tempRadishsprout = new GameObject[5];
        GameObject[] tempBlueberry = new GameObject[5];
        GameObject[] tempBroccoli_grill = new GameObject[5];
        GameObject[] tempCherrytomato = new GameObject[5];

        //기준 1100원
        int cherrytomatoCount = 0;
        int broccoli_grill_Count = 0;
        int blueberryCount = 0;
        int steakCount = 0;
        int cheddarCount = 0;
        int radishsproutCount = 0;

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedSteak(Clone)")
            {
                tempSteak = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                steakCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCheddarcheese(Clone)")
            {
                tempCheddar[cheddarCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cheddarCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedRadishsprout(Clone)")
            {
                tempRadishsprout[radishsproutCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                radishsproutCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBroccoli_grill(Clone)")
            {
                tempBroccoli_grill[broccoli_grill_Count] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                broccoli_grill_Count++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBlueberry(Clone)")
            {

                tempBlueberry[blueberryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherrytomato(Clone)")
            {
                tempCherrytomato[cherrytomatoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherrytomatoCount++;

            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크
        if (tempSteak != null)
        {
            for (int i = 0; i < radishsproutCount; i++)
            {
                if (tempRadishsprout[i].transform.position.z > tempSteak.transform.position.z) platingScore -= 100;

                for (int j = 0; j < cheddarCount; j++)
                    if (tempRadishsprout[i].transform.position.z > tempCheddar[j].transform.position.z) platingScore -= 100;
            }

            for (int i = 0; i < cheddarCount; i++)
            {
                if (tempCheddar[i].transform.position.z > tempSteak.transform.position.z) platingScore -= 100;
            }
        }

        // 있어야할 재료가 모자르면 -(1100÷해당 재료 전체갯수)*모자른 갯수
        if (steakCount == 0) platingScore -= 1100;
        if (cheddarCount == 0) platingScore -= 1100;

        if (radishsproutCount == 0)
            platingScore -= 1100;
        else if (radishsproutCount == 1) platingScore -= 500;

        if (blueberryCount == 0)
            platingScore -= 1100;
        else if (blueberryCount > 0 && blueberryCount < 3)
            platingScore -= (300) * (3 - blueberryCount);

        if (broccoli_grill_Count == 0)
            platingScore -= 1100;
        else if (broccoli_grill_Count > 0 && broccoli_grill_Count < 3)
            platingScore -= (300) * (3 - broccoli_grill_Count);

        if (cherrytomatoCount == 0) platingScore -= 1100;
        else if (cherrytomatoCount == 1) platingScore -= 500;

        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;

        Vector2 cheddarAnswer = new Vector2(0.27f, -0.33f);
        Vector2 radishsprout1Answer = new Vector2(-0.30f, 0); //첫번째 무순 정답
        Vector2 radishsprout2Answer = new Vector2(0.7f, -0.4f);
        Vector2[] radishsproutAnswer = { radishsprout1Answer, radishsprout2Answer };

        Vector2 broccoli_grill_1Answer = new Vector2(0.08f, 2.45f);
        Vector2 broccoli_grill_2Answer = new Vector2(1.21f, 2.44f);
        Vector2 broccoli_grill_3Answer = new Vector2(2.22f, 1.94f);
        Vector2[] broccoli_grill_Answer = { broccoli_grill_1Answer, broccoli_grill_2Answer, broccoli_grill_3Answer };

        Vector2 blueberry1Answer = new Vector2(-3.0f, 0.6f);
        Vector2 blueberry2Answer = new Vector2(-2.44f, 1.5f);
        Vector2 blueberry3Answer = new Vector2(-1.56f, 2.1f);
        Vector2[] blueberryAnswer = { blueberry1Answer, blueberry2Answer, blueberry3Answer };

        Vector2 cherrytomato1Answer = new Vector2(0.52f, -3.11f);
        Vector2 cherrytomato2Answer = new Vector2(2.13f, -2.25f);
        Vector2[] cherrytomatoAnswer = { cherrytomato1Answer, cherrytomato2Answer };


        if (cheddarCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < cheddarCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempCheddar[i].transform.position.x, tempCheddar[i].transform.position.y), cheddarAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempCheddar[i].transform.position.x, tempCheddar[i].transform.position.y), cheddarAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("체다" + minDist);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("체다위치체크후" + platingScore);
            minDist = 100f;
            if (cheddarCount > 1)
            {
                platingScore -= (cheddarCount - 1) * (1100);
            }

        }


        if (radishsproutCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < radishsproutCount; i++)
            {
                for (int j = 0; j < radishsproutAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("무순" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("무순1위치체크후" + platingScore);
            minDist = 100f;
            if (radishsproutCount > 1)
            {
                for (int i = 0; i < radishsproutCount; i++)
                {
                    for (int j = 0; (j < radishsproutAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("무순" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("무순2위치체크후" + platingScore);
                minDist = 100f;
                if (radishsproutCount > 2)
                {
                    platingScore -= (radishsproutCount - 2) * (500);
                }
            }
        }

        if (broccoli_grill_Count > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            for (int i = 0; i < broccoli_grill_Count; i++)
            {
                for (int j = 0; j < broccoli_grill_Answer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempBroccoli_grill[i].transform.position.x, tempBroccoli_grill[i].transform.position.y), broccoli_grill_Answer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempBroccoli_grill[i].transform.position.x, tempBroccoli_grill[i].transform.position.y), broccoli_grill_Answer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("브로콜리1위치체크후" + platingScore);
            minDist = 100f;
            if (broccoli_grill_Count > 1)
            {
                for (int i = 0; (i < broccoli_grill_Count); i++)
                {
                    for (int j = 0; (j < broccoli_grill_Answer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempBroccoli_grill[i].transform.position.x, tempBroccoli_grill[i].transform.position.y), broccoli_grill_Answer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempBroccoli_grill[i].transform.position.x, tempBroccoli_grill[i].transform.position.y), broccoli_grill_Answer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("브로콜리2위치체크후" + platingScore);
                minDist = 100f;
                if (broccoli_grill_Count > 2)
                {
                    for (int i = 0; i < broccoli_grill_Count; i++)
                    {
                        for (int j = 0; j < broccoli_grill_Answer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempBroccoli_grill[i].transform.position.x, tempBroccoli_grill[i].transform.position.y), broccoli_grill_Answer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempBroccoli_grill[i].transform.position.x, tempBroccoli_grill[i].transform.position.y), broccoli_grill_Answer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 1.0) platingScore -= 1100;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("브로콜리3위치체크후" + platingScore);
                    minDist = 100f;
                    if (broccoli_grill_Count > 3)
                    {
                        platingScore -= (broccoli_grill_Count - 3) * (300);
                    }

                }

            }

        }

        if (blueberryCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            for (int i = 0; i < blueberryCount; i++)
            {
                for (int j = 0; j < 3; j++)
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist /standard2) * 100;
            Debug.Log("블루베리1위치체크후" + platingScore);
            minDist = 100f;
            if (blueberryCount > 1)
            {
                for (int i = 0; i < blueberryCount; i++)
                {
                    for (int j = 0; (j < blueberryAnswer.Length); j++)
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
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("블루베리2위치체크후" + platingScore);
                minDist = 100f;
                if (blueberryCount > 2)
                {
                    for (int i = 0; i < blueberryCount; i++)
                    {
                        for (int j = 0; j < blueberryAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempBlueberry[i].transform.position.x, tempBlueberry[i].transform.position.y), blueberryAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempBlueberry[i].transform.position.x, tempBlueberry[i].transform.position.y), blueberryAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 1.0) platingScore -= 1100;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("블루베리3위치체크후" + platingScore);
                    minDist = 100f;
                    if (blueberryCount > 3)
                    {
                        platingScore -= (blueberryCount - 3) * (300);
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
            Debug.Log("방토" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
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
                Debug.Log("방토" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
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
        if (platingScore < 0)
        {
            platingScore = 0;
            Debug.Log("0점 미만->" + platingScore);
        }

        SetScoreText(platingScore);
        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempSteak = null;
        tempCheddar = null;
        tempBroccoli_grill = null;
        tempRadishsprout = null;
        tempCherrytomato = null;
        tempBlueberry = null;


    }

    /*===================================================================== < platingSample8 > =======================================================================*/

    public void checkPlating8()
    {

        int platingScore = 7000;
        GameObject tempSteak = null;
        GameObject[] tempBroccoli = new GameObject[5];
        GameObject[] tempCheese = new GameObject[5];
        GameObject[] tempLemon_chop = new GameObject[5];
        GameObject[] tempPaprika_chop = new GameObject[5];
        GameObject[] tempAsparagus_grill = new GameObject[5];

        //기준1100원
        int steakCount = 0;
        int cheeseCount = 0;
        int asparagus_grill_Count = 0;
        int lemon_chop_Count = 0;
        int broccoliCount = 0;
        int paprika_chop_Count = 0;



        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedSteak(Clone)")
            {
                tempSteak = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                steakCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCheese(Clone)")
            {
                tempCheese[cheeseCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cheeseCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedAsparagus_grill(Clone)")
            {
                tempAsparagus_grill[asparagus_grill_Count] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                asparagus_grill_Count++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBroccoli(Clone)")
            {
                tempBroccoli[broccoliCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                broccoliCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedLemon_chop(Clone)")
            {
                tempLemon_chop[lemon_chop_Count] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                lemon_chop_Count++;
            }

            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedPaprika_chop(Clone)")
            {
                tempPaprika_chop[paprika_chop_Count] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                paprika_chop_Count++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크
        if (tempSteak != null)
        {
            for (int i = 0; i < cheeseCount; i++)
            {
                if (tempCheese[i].transform.position.z > tempSteak.transform.position.z) platingScore -= 100;
            }
            for (int i = 0; i < paprika_chop_Count; i++)
            {
                if (tempPaprika_chop[i].transform.position.z > tempSteak.transform.position.z) platingScore -= 100;
            }
        }
        // 있어야할 재료가 모자르면 -(1000÷해당 재료 전체갯수)*모자른 갯수
        if (steakCount == 0) platingScore -= 1100;
        if (cheeseCount == 0) platingScore -= 1100;
        if (lemon_chop_Count == 0) platingScore -= 1100;

        if (broccoliCount == 0)
            platingScore -= 1100;
        else if (broccoliCount > 0 && broccoliCount < 4)
            platingScore -= (200) * (4 - broccoliCount);

        if (asparagus_grill_Count == 0)
            platingScore -= 1100;
        else if (asparagus_grill_Count > 0 && asparagus_grill_Count < 3)
            platingScore -= (300) * (3 - asparagus_grill_Count);

        if (paprika_chop_Count == 0)
            platingScore -= 1100;
        else if (paprika_chop_Count == 1)
            platingScore -= 500;


        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;

        Vector2 broccoli1Answer = new Vector2(-2.73f, 1.65f); //첫번째 브로콜리 정답
        Vector2 broccoli2Answer = new Vector2(-1.93f, 2.43f);
        Vector2 broccoli3Answer = new Vector2(-1.84f, 1.38f);
        Vector2 broccoli4Answer = new Vector2(-2.69f, 0.65f);
        Vector2[] broccoliAnswer = { broccoli1Answer, broccoli2Answer, broccoli3Answer, broccoli4Answer };

        Vector2 Aspa_grill1Answer = new Vector2(0.3f, -2.67f);
        Vector2 Aspa_grill2Answer = new Vector2(1.55f, -2.37f);
        Vector2 Aspa_grill3Answer = new Vector2(2.8f, -2.07f);
        Vector2[] Aspa_grillAnswer = { Aspa_grill1Answer, Aspa_grill2Answer, Aspa_grill3Answer };

        Vector2 cheeseAnswer = new Vector2(-1.05f, -1.15f);
        Vector2 lemon_chopAnswer = new Vector2(-0.3f, 2.28f);

        Vector2 paprika_chop1Answer = new Vector2(0.23f, 0.88f);
        Vector2 paprika_chop2Answer = new Vector2(1.56f, 0.12f);
        Vector2[] paprika_chopAnswer = { paprika_chop1Answer, paprika_chop2Answer };

        if (cheeseCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < cheeseCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("치즈" + minDist);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("치즈 위치체크후" + platingScore);
            minDist = 100f;
            if (cheeseCount > 1)
            {
                platingScore -= (cheeseCount - 1) * (1100);
            }


        }

        if (lemon_chop_Count > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < lemon_chop_Count; i++)
            {
                if (Vector2.Distance(new Vector2(tempLemon_chop[i].transform.position.x, tempLemon_chop[i].transform.position.y), lemon_chopAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempLemon_chop[i].transform.position.x, tempLemon_chop[i].transform.position.y), lemon_chopAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("레몬" + minDist);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist /standard2) * 100;
            Debug.Log("레몬위치체크후" + platingScore);
            minDist = 100f;
            if (lemon_chop_Count > 1)
            {
                platingScore -= (lemon_chop_Count - 1) * (1100);
            }

        }

        if (paprika_chop_Count > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < paprika_chop_Count; i++)
            {
                for (int j = 0; j < paprika_chopAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempPaprika_chop[i].transform.position.x, tempPaprika_chop[i].transform.position.y), paprika_chopAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempPaprika_chop[i].transform.position.x, tempPaprika_chop[i].transform.position.y), paprika_chopAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }

            Debug.Log("파프리카" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("파프리카1위치체크후" + platingScore);
            minDist = 100f;
            if (paprika_chop_Count > 1)
            {
                for (int i = 0; i < paprika_chop_Count; i++)
                {
                    for (int j = 0; (j < paprika_chopAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempPaprika_chop[i].transform.position.x, tempPaprika_chop[i].transform.position.y), paprika_chopAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempPaprika_chop[i].transform.position.x, tempPaprika_chop[i].transform.position.y), paprika_chopAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }

                Debug.Log("파프리카" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist /standard2) * 100;
                Debug.Log("파프리카2위치체크후" + platingScore);
                minDist = 100f;
                if (paprika_chop_Count > 2)
                {
                    platingScore -= (paprika_chop_Count - 2) * (500);
                }
            }
        }

        if (asparagus_grill_Count > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            for (int i = 0; i < asparagus_grill_Count; i++)
            {
                for (int j = 0; j < Aspa_grillAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempAsparagus_grill[i].transform.position.x, tempAsparagus_grill[i].transform.position.y), Aspa_grillAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempAsparagus_grill[i].transform.position.x, tempAsparagus_grill[i].transform.position.y), Aspa_grillAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }

            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("아스파1위치체크후" + platingScore);
            minDist = 100f;
            if (asparagus_grill_Count > 1)
            {
                for (int i = 0; (i < asparagus_grill_Count); i++)
                {
                    for (int j = 0; (j < Aspa_grillAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempAsparagus_grill[i].transform.position.x, tempAsparagus_grill[i].transform.position.y), Aspa_grillAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempAsparagus_grill[i].transform.position.x, tempAsparagus_grill[i].transform.position.y), Aspa_grillAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("아스파2위치체크후" + platingScore);
                minDist = 100f;
                if (asparagus_grill_Count > 2)
                {
                    for (int i = 0; i < asparagus_grill_Count; i++)
                    {
                        for (int j = 0; j < Aspa_grillAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempAsparagus_grill[i].transform.position.x, tempAsparagus_grill[i].transform.position.y), Aspa_grillAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempAsparagus_grill[i].transform.position.x, tempAsparagus_grill[i].transform.position.y), Aspa_grillAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 1.0) platingScore -= 1100;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("아스파3위치체크후" + platingScore);
                    minDist = 100f;
                    if (asparagus_grill_Count > 3)
                    {
                        platingScore -= (asparagus_grill_Count - 3) * (300);
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
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < broccoliCount; i++)
            {
                for (int j = 0; j < 4; j++)
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
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

                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
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

                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 1.0) platingScore -= 1100;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("브로콜리3위치체크후" + platingScore);
                    minDist = 100f;
                    if (broccoliCount > 3)
                    {
                        for (int i = 0; i < broccoliCount; i++)
                        {
                            for (int j = 0; j < broccoliAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempBroccoli[i].transform.position.x, tempBroccoli[i].transform.position.y), broccoliAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempBroccoli[i].transform.position.x, tempBroccoli[i].transform.position.y), broccoliAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }

                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 1.0) platingScore -= 1100;
                        else platingScore -= (int)(minDist /standard2) * 100;
                        Debug.Log("브로콜리4위치체크후" + platingScore);
                        minDist = 100f;
                        if (broccoliCount > 4)
                        {
                            platingScore -= (broccoliCount - 4) * (200);
                        }

                    }

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
        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempSteak = null;
        tempBroccoli = null;
        tempCheese = null;
        tempLemon_chop = null;
        tempPaprika_chop = null;
        tempAsparagus_grill = null;


    }

    /*===================================================================== < platingSample9 > =======================================================================*/
    public void checkPlating9()
    {

        int platingScore = 7000;
        GameObject tempPasta = null;
        GameObject[] tempBasil = new GameObject[5];
        GameObject[] tempCherry = new GameObject[5];
        GameObject[] tempPaprika_chop = new GameObject[5];
        GameObject[] tempBroccoli = new GameObject[5];
        GameObject[] tempCherrytomato_chop = new GameObject[5];

        //기준 1100원
        int cherrytomato_chopCount = 0;
        int broccoliCount = 0;
        int paprika_chopCount = 0;
        int pastaCount = 0;
        int basilCount = 0;
        int cherryCount = 0;

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedPasta(Clone)")
            {
                tempPasta = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                pastaCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBasil(Clone)")
            {
                tempBasil[basilCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                basilCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherry(Clone)")
            {
                tempCherry[cherryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBroccoli(Clone)")
            {
                tempBroccoli[broccoliCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                broccoliCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedPaprika_chop(Clone)")
            {

                tempPaprika_chop[paprika_chopCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                paprika_chopCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherrytomato_chop(Clone)")
            {
                tempCherrytomato_chop[cherrytomato_chopCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherrytomato_chopCount++;

            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크
        if (tempPasta != null)
        {
            for (int i = 0; i < cherrytomato_chopCount; i++)
            {
                if (tempCherrytomato_chop[i].transform.position.z > tempPasta.transform.position.z) platingScore -= 100;

                for (int j = 0; j < basilCount; j++)
                    if (tempCherrytomato_chop[i].transform.position.z < tempBasil[j].transform.position.z) platingScore -= 100;
            }

            for (int i = 0; i < basilCount; i++)
            {
                if (tempBasil[i].transform.position.z > tempPasta.transform.position.z) platingScore -= 100;
            }

            for (int i = 0; i < paprika_chopCount; i++)
            {
                if (tempPaprika_chop[i].transform.position.z > tempPasta.transform.position.z) platingScore -= 100;
            }

            for (int i = 0; i < broccoliCount; i++)
            {
                if (tempBroccoli[i].transform.position.z > tempPasta.transform.position.z) platingScore -= 100;
            }
        }

        // 있어야할 재료가 모자르면 -(1100÷해당 재료 전체갯수)*모자른 갯수
        if (pastaCount == 0) platingScore -= 1100;
        if (basilCount == 0) platingScore -= 1100;

        if (broccoliCount == 0)
            platingScore -= 1100;
        else if (broccoliCount == 1) platingScore -= 500;

        if (cherrytomato_chopCount == 0)
            platingScore -= 1100;
        else if (cherrytomato_chopCount > 0 && cherrytomato_chopCount < 3)
            platingScore -= (300) * (3 - cherrytomato_chopCount);

        if (paprika_chopCount == 0)
            platingScore -= 1100;
        else if (paprika_chopCount > 0 && paprika_chopCount < 4)
            platingScore -= (200) * (4 - paprika_chopCount);

        if (cherryCount == 0) platingScore -= 1100;
        else if (cherryCount == 1) cherryCount -= 500;

        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;

        Vector2 basilAnswer = new Vector2(0.17f, -0.42f);

        Vector2 cherry1Answer = new Vector2(1.8f, 2.64f);
        Vector2 cherry2Answer = new Vector2(2.81f, 1.94f);
        Vector2[] cherryAnswer = { cherry1Answer, cherry2Answer };

        Vector2 paprika_chop1Answer = new Vector2(-2.4f, -0.55f);
        Vector2 paprika_chop2Answer = new Vector2(-0.2f, 2f);
        Vector2 paprika_chop3Answer = new Vector2(2.36f, -0.02f);
        Vector2 paprika_chop4Answer = new Vector2(0.1f, -2.8f);
        Vector2[] paprika_chopAnswer = { paprika_chop1Answer, paprika_chop2Answer, paprika_chop3Answer, paprika_chop4Answer };

        Vector2 cherrytomato_chop1Answer = new Vector2(-0.26f, -0.02f);
        Vector2 cherrytomato_chop2Answer = new Vector2(0.71f, -0.26f);
        Vector2 cherrytomato_chop3Answer = new Vector2(-0.01f, -0.86f);
        Vector2[] cherrytomato_chopAnswer = { cherrytomato_chop1Answer, cherrytomato_chop2Answer, cherrytomato_chop3Answer };


        Vector2 broccoli1Answer = new Vector2(-2.11f, 1.54f);
        Vector2 broccoli2Answer = new Vector2(2.23f, -2.42f);
        Vector2[] broccoliAnswer = { broccoli1Answer, broccoli2Answer };


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
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("바질위치체크후" + platingScore);
            minDist = 100f;
            if (basilCount > 1)
            {
                platingScore -= (basilCount - 1) * (1100);
            }

        }


        if (broccoliCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

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
            Debug.Log("브로콜리" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("브로콜리1위치체크후" + platingScore);
            minDist = 100f;
            if (broccoliCount > 1)
            {
                for (int i = 0; i < broccoliCount; i++)
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
                Debug.Log("브로콜리" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("브로콜리2위치체크후" + platingScore);
                minDist = 100f;
                if (broccoliCount > 2)
                {
                    platingScore -= (broccoliCount - 2) * (500);
                }
            }
        }

        if (cherryCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < cherryCount; i++)
            {
                for (int j = 0; j < cherryAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }

            Debug.Log("체리" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("체리1위치체크후" + platingScore);
            minDist = 100f;
            if (cherryCount > 1)
            {
                for (int i = 0; i < cherryCount; i++)
                {
                    for (int j = 0; (j < cherryAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }

                Debug.Log("체리" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist /standard2) * 100;
                Debug.Log("체리2위치체크후" + platingScore);
                minDist = 100f;
                if (cherryCount > 2)
                {
                    platingScore -= (cherryCount - 2) * (500);
                }
            }
        }


        if (cherrytomato_chopCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            for (int i = 0; i < cherrytomato_chopCount; i++)
            {
                for (int j = 0; j < cherrytomato_chopAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCherrytomato_chop[i].transform.position.x, tempCherrytomato_chop[i].transform.position.y), cherrytomato_chopAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCherrytomato_chop[i].transform.position.x, tempCherrytomato_chop[i].transform.position.y), cherrytomato_chopAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }

            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("방토1위치체크후" + platingScore);
            minDist = 100f;
            if (cherrytomato_chopCount > 1)
            {
                for (int i = 0; (i < cherrytomato_chopCount); i++)
                {
                    for (int j = 0; (j < cherrytomato_chopAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCherrytomato_chop[i].transform.position.x, tempCherrytomato_chop[i].transform.position.y), cherrytomato_chopAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCherrytomato_chop[i].transform.position.x, tempCherrytomato_chop[i].transform.position.y), cherrytomato_chopAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }

                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("방토2위치체크후" + platingScore);
                minDist = 100f;
                if (cherrytomato_chopCount > 2)
                {
                    for (int i = 0; i < cherrytomato_chopCount; i++)
                    {
                        for (int j = 0; j < cherrytomato_chopAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCherrytomato_chop[i].transform.position.x, tempCherrytomato_chop[i].transform.position.y), cherrytomato_chopAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCherrytomato_chop[i].transform.position.x, tempCherrytomato_chop[i].transform.position.y), cherrytomato_chopAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }

                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 1.0) platingScore -= 1100;
                    else platingScore -= (int)(minDist /standard2) * 100;
                    Debug.Log("방토3위치체크후" + platingScore);
                    minDist = 100f;
                    if (cherrytomato_chopCount > 3)
                    {
                        platingScore -= (cherrytomato_chopCount - 3) * (300);
                    }

                }

            }

        }

        if (paprika_chopCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < paprika_chopCount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Vector2.Distance(new Vector2(tempPaprika_chop[i].transform.position.x, tempPaprika_chop[i].transform.position.y), paprika_chopAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempPaprika_chop[i].transform.position.x, tempPaprika_chop[i].transform.position.y), paprika_chopAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("파프리카1위치체크후" + platingScore);
            minDist = 100f;
            if (paprika_chopCount > 1)
            {
                for (int i = 0; (i < paprika_chopCount); i++)
                {
                    for (int j = 0; (j < paprika_chopAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempPaprika_chop[i].transform.position.x, tempPaprika_chop[i].transform.position.y), paprika_chopAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempPaprika_chop[i].transform.position.x, tempPaprika_chop[i].transform.position.y), paprika_chopAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }

                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("파프리카2위치체크후" + platingScore);
                minDist = 100f;
                if (broccoliCount > 2)
                {
                    for (int i = 0; i < paprika_chopCount; i++)
                    {
                        for (int j = 0; j < paprika_chopAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempPaprika_chop[i].transform.position.x, tempPaprika_chop[i].transform.position.y), paprika_chopAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempPaprika_chop[i].transform.position.x, tempPaprika_chop[i].transform.position.y), paprika_chopAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }

                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 1.0) platingScore -= 1100;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("파프리카3위치체크후" + platingScore);
                    minDist = 100f;
                    if (broccoliCount > 3)
                    {
                        for (int i = 0; i < paprika_chopCount; i++)
                        {
                            for (int j = 0; j < paprika_chopAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempPaprika_chop[i].transform.position.x, tempPaprika_chop[i].transform.position.y), paprika_chopAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempPaprika_chop[i].transform.position.x, tempPaprika_chop[i].transform.position.y), paprika_chopAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }

                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 1.0) platingScore -= 1100;
                        else platingScore -= (int)(minDist / standard2) * 100;
                        Debug.Log("파프리카4위치체크후" + platingScore);
                        minDist = 100f;
                        if (paprika_chopCount > 4)
                        {
                            platingScore -= (paprika_chopCount - 4) * (200);
                        }

                    }

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
        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempPasta = null;
        tempBasil = null;
        tempBroccoli = null;
        tempCherry = null;
        tempCherrytomato_chop = null;
        tempPaprika_chop = null;
    }




    /*===================================================================== < platingSample10 > =======================================================================*/
    public void checkPlating10()
    {

        int platingScore = 7000;

        GameObject tempPasta = null;

        GameObject[] tempCherrytomato = new GameObject[5];
        GameObject[] tempCarrot_slice = new GameObject[5];
        GameObject[] tempBasil = new GameObject[5];

        //기준:1700원
        int cherrytomatoCount = 0;
        int carrot_sliceCount = 0;
        int basilCount = 0;
        int pastaCount = 0;

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedPasta(Clone)")
            {
                tempPasta = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                pastaCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherrytomato(Clone)")
            {
                tempCherrytomato[cherrytomatoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherrytomatoCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCarrot_slice(Clone)")
            {

                tempCarrot_slice[carrot_sliceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                carrot_sliceCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBasil(Clone)")
            {

                tempBasil[basilCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                basilCount++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        if (tempPasta != null)
        {
            for (int i = 0; i < cherrytomatoCount; i++)
            {
                if (tempCherrytomato[i].transform.position.z > tempPasta.transform.position.z) platingScore -= 100;
            }

            for (int i = 0; i < carrot_sliceCount; i++)
            {
                if (tempCarrot_slice[i].transform.position.z > tempPasta.transform.position.z) platingScore -= 100;
            }

            for (int i = 0; i < basilCount; i++)
            {
                if (tempBasil[i].transform.position.z > tempPasta.transform.position.z) platingScore -= 100;
            }
        }

        if (pastaCount == 0) platingScore -= 1700;
        if (cherrytomatoCount == 0) platingScore -= 1700;
        else if (cherrytomatoCount > 0 && cherrytomatoCount < 4)
            platingScore -= (400) * (4 - cherrytomatoCount);


        if (carrot_sliceCount == 0) platingScore -= 1700;
        else if (carrot_sliceCount > 0 && carrot_sliceCount < 4)
            platingScore -= (400) * (4 - carrot_sliceCount);

        if (basilCount == 0) platingScore -= 1700;
        else if (basilCount > 0 && basilCount < 4)
            platingScore -= (400) * (4 - basilCount);



        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;


        Vector2 basil1Answer = new Vector2(-1.01f, -0.48f);
        Vector2 basil2Answer = new Vector2(0.41f, -1.4f);
        Vector2 basil3Answer = new Vector2(-0.21f, 0.62f);
        Vector2 basil4Answer = new Vector2(1.26f, -0.38f);
        Vector2[] basilAnswer = { basil1Answer, basil2Answer, basil3Answer, basil4Answer };

        Vector2 cherrytomato1Answer = new Vector2(-1.24f, 1.43f);
        Vector2 cherrytomato2Answer = new Vector2(1.4f, -2.21f);
        Vector2 cherrytomato3Answer = new Vector2(2.25f, -1.42f);
        Vector2 cherrytomato4Answer = new Vector2(-2.18f, 0.78f);
        Vector2[] cherrytomatoAnswer = { cherrytomato1Answer, cherrytomato2Answer, cherrytomato3Answer, cherrytomato4Answer };

        Vector2 carrot_slice1Answer = new Vector2(-1.64f, -1.84f);
        Vector2 carrot_slice2Answer = new Vector2(-1.15f, -2.23f);
        Vector2 carrot_slice3Answer = new Vector2(1.84f, 0.81f);
        Vector2 carrot_slice4Answer = new Vector2(1.42f, 1.17f);
        Vector2[] carrot_sliceAnswer = { carrot_slice1Answer, carrot_slice2Answer, carrot_slice3Answer, carrot_slice4Answer };


        if (cherrytomatoCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < cherrytomatoCount; i++)
            {
                for (int j = 0; j < 4; j++)
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.6) platingScore -= 1700;
            else platingScore -= (int)(minDist / standard2) * 100;
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

                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.6) platingScore -= 1700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("방토2위치체크후" + platingScore);
                minDist = 100f;
                if (cherrytomatoCount > 2)
                {
                    for (int i = 0; i < cherrytomatoCount; i++)
                    {
                        for (int j = 0; j < cherrytomatoAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }

                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 1.6) platingScore -= 1700;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("방토3위치체크후" + platingScore);
                    minDist = 100f;
                    if (cherrytomatoCount > 3)
                    {
                        for (int i = 0; i < cherrytomatoCount; i++)
                        {
                            for (int j = 0; j < cherrytomatoAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }

                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 1.6) platingScore -= 1700;
                        else platingScore -= (int)(minDist / standard2) * 100;
                        Debug.Log("방토4위치체크후" + platingScore);
                        minDist = 100f;
                        if (cherrytomatoCount > 4)
                        {
                            platingScore -= (cherrytomatoCount - 4) * (400);
                        }

                    }

                }

            }
        }

        if (carrot_sliceCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < carrot_sliceCount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCarrot_slice[i].transform.position.x, tempCarrot_slice[i].transform.position.y), carrot_sliceAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCarrot_slice[i].transform.position.x, tempCarrot_slice[i].transform.position.y), carrot_sliceAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.6) platingScore -= 1700;
            else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("당근1위치체크후" + platingScore);
            minDist = 100f;
            if (carrot_sliceCount > 1)
            {
                for (int i = 0; (i < carrot_sliceCount); i++)
                {
                    for (int j = 0; (j < carrot_sliceAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCarrot_slice[i].transform.position.x, tempCarrot_slice[i].transform.position.y), carrot_sliceAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCarrot_slice[i].transform.position.x, tempCarrot_slice[i].transform.position.y), carrot_sliceAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }

                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.6) platingScore -= 1700;
                else platingScore -= (int)(minDist / 0.1) * 100;
                Debug.Log("당근2위치체크후" + platingScore);
                minDist = 100f;
                if (carrot_sliceCount > 2)
                {
                    for (int i = 0; i < carrot_sliceCount; i++)
                    {
                        for (int j = 0; j < carrot_sliceAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCarrot_slice[i].transform.position.x, tempCarrot_slice[i].transform.position.y), carrot_sliceAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCarrot_slice[i].transform.position.x, tempCarrot_slice[i].transform.position.y), carrot_sliceAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }

                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 1.6) platingScore -= 1700;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("당근3위치체크후" + platingScore);
                    minDist = 100f;
                    if (carrot_sliceCount > 3)
                    {
                        for (int i = 0; i < carrot_sliceCount; i++)
                        {
                            for (int j = 0; j < carrot_sliceAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempCarrot_slice[i].transform.position.x, tempCarrot_slice[i].transform.position.y), carrot_sliceAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempCarrot_slice[i].transform.position.x, tempCarrot_slice[i].transform.position.y), carrot_sliceAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }

                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 1.6) platingScore -= 1700;
                        else platingScore -= (int)(minDist / standard2) * 100;
                        Debug.Log("당근4위치체크후" + platingScore);
                        minDist = 100f;
                        if (carrot_sliceCount > 4)
                        {
                            platingScore -= (carrot_sliceCount - 4) * (400);
                        }

                    }

                }

            }
        }

        if (basilCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < basilCount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.6) platingScore -= 1700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("바질1위치체크후" + platingScore);
            minDist = 100f;
            if (basilCount > 1)
            {
                for (int i = 0; (i < basilCount); i++)
                {
                    for (int j = 0; (j < basilAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }

                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.6) platingScore -= 1700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("바질2위치체크후" + platingScore);
                minDist = 100f;
                if (basilCount > 2)
                {
                    for (int i = 0; i < basilCount; i++)
                    {
                        for (int j = 0; j < basilAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }

                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 1.6) platingScore -= 1700;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("바질3위치체크후" + platingScore);
                    minDist = 100f;
                    if (basilCount > 3)
                    {
                        for (int i = 0; i < basilCount; i++)
                        {
                            for (int j = 0; j < basilAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }

                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 1.6) platingScore -= 1700;
                        else platingScore -= (int)(minDist / standard2) * 100;
                        Debug.Log("바질4위치체크후" + platingScore);
                        minDist = 100f;
                        if (basilCount > 4)
                        {
                            platingScore -= (basilCount - 4) * (400);
                        }

                    }

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
        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempPasta = null;
        tempCherrytomato = null;
        tempBasil = null;
        tempCarrot_slice = null;

    }
    /*-----------------------------------------------------------------------< plating Sample11 >-----------------------------------------------------------------*/
    public void checkPlating11()
    {

        int platingScore = 7000;
        GameObject tempBread = null;
        GameObject[] tempStrawberry_chop = new GameObject[5];
        GameObject[] tempCream = new GameObject[5];
        GameObject[] tempBlueberry = new GameObject[5];
        GameObject[] tempOrange_juice = new GameObject[5];
        GameObject[] tempChoco = new GameObject[5];

        //기준 1100원
        int strawberry_chop_Count = 0;
        int creamCount = 0;
        int blueberryCount = 0;
        int breadCount = 0;
        int orange_juice_Count = 0;
        int chocoCount = 0;

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBread(Clone)")
            {
                tempBread = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                breadCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedStrawberry_chop(Clone)")
            {
                tempStrawberry_chop[strawberry_chop_Count] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                strawberry_chop_Count++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "orangeLineDrawer(Clone)")
            {
                tempOrange_juice[orange_juice_Count] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                orange_juice_Count++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "chocoLineDrawer(Clone)")
            {
                tempChoco[chocoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                chocoCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBlueberry(Clone)")
            {

                tempBlueberry[blueberryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "creamLineDrawer(Clone)")
            {
                tempCream[creamCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                creamCount++;

            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
                Debug.Log(stage1_plating.platedParent.transform.GetChild(i).gameObject.name);
            }

        }


        //순서체크
        if (tempBread != null)
        {
            if (tempOrange_juice != null)
            {
                for (int i = 0; i < orange_juice_Count; i++)
                {
                    if (tempOrange_juice[i].transform.position.z > tempBread.transform.position.z) platingScore -= 100;
                }

                for (int i = 0; i < strawberry_chop_Count; i++)
                {
                    for (int j = 0; j < orange_juice_Count; j++)
                        if (tempStrawberry_chop[i].transform.position.z > tempOrange_juice[j].transform.position.z) platingScore -= 100;

                }

                for (int i = 0; i < blueberryCount; i++)
                {
                    for (int j = 0; j < orange_juice_Count; j++)
                        if (tempBlueberry[i].transform.position.z > tempOrange_juice[j].transform.position.z) platingScore -= 100;
                }
            }
        }

        Debug.Log("순서체크후" + platingScore);


        // 있어야할 재료가 모자르면 -(1100÷해당 재료 전체갯수)*모자른 갯수
        if (breadCount == 0) platingScore -= 1100;

        if (blueberryCount == 0) platingScore -= 1100;
        else if (blueberryCount == 1) platingScore -= 500;

        if (strawberry_chop_Count == 0)
            platingScore -= 1100;
        else if (strawberry_chop_Count > 0 && strawberry_chop_Count < 3)
            platingScore -= (300) * (3 - strawberry_chop_Count);

        if (orange_juice_Count == 0)
            platingScore -= 1100;

        if (creamCount == 0) platingScore -= 1100;
        else if (creamCount == 1) platingScore -= 500;

        if (chocoCount == 0) platingScore -= 1100;
        else if (chocoCount == 1) platingScore -= 500;

        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;

        Vector2 orangeJuiceAnswer = new Vector2(-1.57f, 0.98f);

        Vector2 choco1Answer = new Vector2(2.90f, 0.94f);
        Vector2 choco2Answer = new Vector2(-3.33f, 1.55f);
        Vector2[] chocoAnswer = { choco1Answer, choco2Answer };

        Vector2 strawberry_chop_1Answer = new Vector2(0.1f, 1.37f);
        Vector2 strawberry_chop_2Answer = new Vector2(0, -1.75f);
        Vector2 strawberry_chop_3Answer = new Vector2(1f, -0.3f);
        Vector2[] strawberry_chop_Answer = { strawberry_chop_1Answer, strawberry_chop_2Answer, strawberry_chop_3Answer };

        Vector2 blueberry1Answer = new Vector2(-0.95f, 0.39f);
        Vector2 blueberry2Answer = new Vector2(-0.95f, -1.07f);
        Vector2[] blueberryAnswer = { blueberry1Answer, blueberry2Answer };

        Vector2 cream1Answer = new Vector2(-3.26f, -0.37f);
        Vector2 cream2Answer = new Vector2(3.15f, -0.07f);
        Vector2[] creamAnswer = { cream1Answer, cream2Answer };


        if (orange_juice_Count > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < orange_juice_Count; i++)
            {
                if (Vector2.Distance(new Vector2(tempOrange_juice[i].transform.position.x, tempOrange_juice[i].transform.position.y), orangeJuiceAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempOrange_juice[i].transform.position.x, tempOrange_juice[i].transform.position.y), orangeJuiceAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("오렌지즙" + minDist);
            if (minDist > 10.0) platingScore -= 1100;
            // else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("오렌지즙 위치체크후" + platingScore);
            minDist = 100f;
            if (orange_juice_Count > 1)
            {
                platingScore -= (orange_juice_Count - 1) * (1100);
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
            Debug.Log("블루베리" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("블루베리1위치체크후" + platingScore);
            minDist = 100f;
            if (blueberryCount > 1)
            {
                for (int i = 0; i < blueberryCount; i++)
                {
                    for (int j = 0; (j < blueberryAnswer.Length); j++)
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
                Debug.Log("블루베리" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist /standard2) * 100;
                Debug.Log("블루베리2위치체크후" + platingScore);
                minDist = 100f;
                if (blueberryCount > 2)
                {
                    platingScore -= (blueberryCount - 2) * (500);
                }
            }
        }

        if (strawberry_chop_Count > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            for (int i = 0; i < strawberry_chop_Count; i++)
            {
                for (int j = 0; j < strawberry_chop_Answer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempStrawberry_chop[i].transform.position.x, tempStrawberry_chop[i].transform.position.y), strawberry_chop_Answer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempStrawberry_chop[i].transform.position.x, tempStrawberry_chop[i].transform.position.y), strawberry_chop_Answer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("딸기1위치체크후" + platingScore);
            minDist = 100f;
            if (strawberry_chop_Count > 1)
            {
                for (int i = 0; (i < strawberry_chop_Count); i++)
                {
                    for (int j = 0; (j < strawberry_chop_Answer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempStrawberry_chop[i].transform.position.x, tempStrawberry_chop[i].transform.position.y), strawberry_chop_Answer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempStrawberry_chop[i].transform.position.x, tempStrawberry_chop[i].transform.position.y), strawberry_chop_Answer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("딸기2위치체크후" + platingScore);
                minDist = 100f;
                if (strawberry_chop_Count > 2)
                {
                    for (int i = 0; i < strawberry_chop_Count; i++)
                    {
                        for (int j = 0; j < strawberry_chop_Answer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempStrawberry_chop[i].transform.position.x, tempStrawberry_chop[i].transform.position.y), strawberry_chop_Answer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempStrawberry_chop[i].transform.position.x, tempStrawberry_chop[i].transform.position.y), strawberry_chop_Answer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 1.0) platingScore -= 1100;
                    else platingScore -= (int)(minDist /standard2) * 100;
                    Debug.Log("딸기3위치체크후" + platingScore);
                    minDist = 100f;
                    if (strawberry_chop_Count > 3)
                    {
                        platingScore -= (strawberry_chop_Count - 3) * (300);
                    }

                }

            }

        }


        if (creamCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < creamCount; i++)
            {
                for (int j = 0; j < creamAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("크림" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 3) platingScore -= 1100;
            // else platingScore -= (int)(minDist / 3) * 100;
            Debug.Log("크림1위치체크후" + platingScore);
            minDist = 100f;
            if (creamCount > 1)
            {
                for (int i = 0; (i < creamCount); i++)
                {
                    for (int j = 0; (j < creamAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("크림" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 3) platingScore -= 1100;
                // else platingScore -= (int)(minDist /3) * 100;
                Debug.Log("크림2위치체크후" + platingScore);
                minDist = 100f;
                if (creamCount > 2)
                {
                    platingScore -= (creamCount - 2) * (500);
                }
            }
        }


        if (chocoCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < chocoCount; i++)
            {
                for (int j = 0; j < chocoAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempChoco[i].transform.position.x, tempChoco[i].transform.position.y), chocoAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempChoco[i].transform.position.x, tempChoco[i].transform.position.y), chocoAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("초코" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 2.5) platingScore -= 1100;
            //else platingScore -= (int)(minDist /3) * 100;
            Debug.Log("초코1위치체크후" + platingScore);
            minDist = 100f;
            if (chocoCount > 1)
            {
                for (int i = 0; (i < chocoCount); i++)
                {
                    for (int j = 0; (j < chocoAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempChoco[i].transform.position.x, tempChoco[i].transform.position.y), chocoAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempChoco[i].transform.position.x, tempChoco[i].transform.position.y), chocoAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("초코" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 2.5) platingScore -= 1100;
                // else platingScore -= (int)(minDist /3) * 100;
                Debug.Log("초코2위치체크후" + platingScore);
                minDist = 100f;
                if (chocoCount > 2)
                {
                    platingScore -= (chocoCount - 2) * (500);
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
        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempBread = null;
        tempChoco = null;
        tempCream = null;
        tempStrawberry_chop = null;
        tempOrange_juice = null;
        tempBlueberry = null;


    }

    /*-----------------------------------------------------------------------< plating Sample12 >-----------------------------------------------------------------*/

    public void checkPlating12()
    {

        int platingScore = 7000;
        GameObject tempBread = null;
        GameObject[] tempKetchup = new GameObject[5];
        GameObject[] tempMozza = new GameObject[5];
        GameObject[] tempApple_chop = new GameObject[5];
        GameObject[] tempCucumber_slice = new GameObject[5];
        GameObject[] tempCarrot_chop = new GameObject[5];

        //기준1100원
        int breadCount = 0;
        int mozzaCount = 0;
        int apple_chop_Count = 0;
        int carrot_chop_Count = 0;
        int cucumber_slice_Count = 0;
        int ketchup_Count = 0;



        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBread(Clone)")
            {
                tempBread = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                breadCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "ketchupLineDrawer(Clone)")
            {
                tempKetchup[ketchup_Count] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                ketchup_Count++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedApple_chop(Clone)")
            {
                tempApple_chop[apple_chop_Count] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                apple_chop_Count++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedMozzacheese(Clone)")
            {
                tempMozza[mozzaCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                mozzaCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCarrot_chop(Clone)")
            {
                tempCarrot_chop[carrot_chop_Count] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                carrot_chop_Count++;
            }

            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCucumber_slice(Clone)")
            {
                tempCucumber_slice[cucumber_slice_Count] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cucumber_slice_Count++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크
        if (tempBread != null)
        {
            for (int i = 0; i < mozzaCount; i++)
            {
                if (tempMozza[i].transform.position.z > tempBread.transform.position.z) platingScore -= 100;
            }
            for (int i = 0; i < carrot_chop_Count; i++)
            {

                for (int j = 0; j < mozzaCount; j++)
                    if (tempCarrot_chop[i].transform.position.z > tempMozza[j].transform.position.z) platingScore -= 100;
            }

            for (int i = 0; i < cucumber_slice_Count; i++)
            {
                for (int j = 0; j < mozzaCount; j++)
                    if (tempCucumber_slice[i].transform.position.z > tempMozza[j].transform.position.z) platingScore -= 100;
            }

        }

        Debug.Log("순서체크후" + platingScore);

        // 있어야할 재료가 모자르면 -(1000÷해당 재료 전체갯수)*모자른 갯수
        if (breadCount == 0) platingScore -= 1100;
        if (mozzaCount == 0) platingScore -= 1100;

        if (apple_chop_Count == 0) platingScore -= 1100;
        else if (apple_chop_Count == 1)
            platingScore -= 500;

        if (carrot_chop_Count == 0)
            platingScore -= 1100;
        else if (carrot_chop_Count > 0 && carrot_chop_Count < 4)
            platingScore -= (200) * (4 - carrot_chop_Count);

        if (cucumber_slice_Count == 0)
            platingScore -= 1100;
        else if (cucumber_slice_Count > 0 && cucumber_slice_Count < 3)
            platingScore -= (300) * (3 - cucumber_slice_Count);

        if (ketchup_Count == 0)
            platingScore -= 1100;


        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;

        Vector2 carrot_chop1Answer = new Vector2(-1.21f, 0.76f);
        Vector2 carrot_chop2Answer = new Vector2(-1f, -1.7f);
        Vector2 carrot_chop3Answer = new Vector2(1, 0.9f);
        Vector2 carrot_chop4Answer = new Vector2(0.9f, -1.67f);
        Vector2[] carrot_chop_Answer = { carrot_chop1Answer, carrot_chop2Answer, carrot_chop3Answer, carrot_chop4Answer };

        Vector2 cucumber_slice1Answer = new Vector2(-1.34f, -0.4f);
        Vector2 cucumber_slice2Answer = new Vector2(-0.24f, -0.4f);
        Vector2 cucumber_slice3Answer = new Vector2(0.89f, -0.4f);
        Vector2[] cucumber_sliceAnswer = { cucumber_slice1Answer, cucumber_slice2Answer, cucumber_slice3Answer };

        Vector2 mozzaAnswer = new Vector2(0, -0.45f);
        Vector2 ketchupAnswer = new Vector2(-2.55f, 1.09f);

        Vector2 apple_chop1Answer = new Vector2(3.19f, 0.4f);
        Vector2 apple_chop2Answer = new Vector2(3.19f, -1f);
        Vector2[] apple_chopAnswer = { apple_chop1Answer, apple_chop2Answer };

        if (mozzaCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < mozzaCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempMozza[i].transform.position.x, tempMozza[i].transform.position.y), mozzaAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempMozza[i].transform.position.x, tempMozza[i].transform.position.y), mozzaAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("치즈" + minDist);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("치즈 위치체크후" + platingScore);
            minDist = 100f;
            if (mozzaCount > 1)
            {
                platingScore -= (mozzaCount - 1) * (1100);
            }


        }

        if (ketchup_Count > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < ketchup_Count; i++)
            {
                if (Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("케찹" + minDist);
            if (minDist > 6) platingScore -= 1100;
            //else platingScore -= (int)(minDist / 3) * 100;
            Debug.Log("케찹위치체크후" + platingScore);
            minDist = 100f;
            if (ketchup_Count > 1)
            {
                platingScore -= (ketchup_Count - 1) * (1100);
            }

        }

        if (apple_chop_Count > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < apple_chop_Count; i++)
            {
                for (int j = 0; j < apple_chopAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempApple_chop[i].transform.position.x, tempApple_chop[i].transform.position.y), apple_chopAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempApple_chop[i].transform.position.x, tempApple_chop[i].transform.position.y), apple_chopAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("사과" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("사과1위치체크후" + platingScore);
            minDist = 100f;
            if (apple_chop_Count > 1)
            {
                for (int i = 0; (i < apple_chop_Count); i++)
                {
                    for (int j = 0; (j < apple_chopAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempApple_chop[i].transform.position.x, tempApple_chop[i].transform.position.y), apple_chopAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempApple_chop[i].transform.position.x, tempApple_chop[i].transform.position.y), apple_chopAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("사과" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("사과2위치체크후" + platingScore);
                minDist = 100f;
                if (apple_chop_Count > 2)
                {
                    platingScore -= (apple_chop_Count - 2) * (500);
                }
            }
        }

        if (cucumber_slice_Count > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            for (int i = 0; i < cucumber_slice_Count; i++)
            {
                for (int j = 0; j < cucumber_sliceAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCucumber_slice[i].transform.position.x, tempCucumber_slice[i].transform.position.y), cucumber_sliceAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCucumber_slice[i].transform.position.x, tempCucumber_slice[i].transform.position.y), cucumber_sliceAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }

            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("오이1위치체크후" + platingScore);
            minDist = 100f;
            if (cucumber_slice_Count > 1)
            {
                for (int i = 0; (i < cucumber_slice_Count); i++)
                {
                    for (int j = 0; (j < cucumber_sliceAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCucumber_slice[i].transform.position.x, tempCucumber_slice[i].transform.position.y), cucumber_sliceAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCucumber_slice[i].transform.position.x, tempCucumber_slice[i].transform.position.y), cucumber_sliceAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("오이2위치체크후" + platingScore);
                minDist = 100f;
                if (cucumber_slice_Count > 2)
                {
                    for (int i = 0; i < cucumber_slice_Count; i++)
                    {
                        for (int j = 0; j < cucumber_sliceAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCucumber_slice[i].transform.position.x, tempCucumber_slice[i].transform.position.y), cucumber_sliceAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCucumber_slice[i].transform.position.x, tempCucumber_slice[i].transform.position.y), cucumber_sliceAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 1.0) platingScore -= 1100;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("오이3위치체크후" + platingScore);
                    minDist = 100f;
                    if (cucumber_slice_Count > 3)
                    {
                        platingScore -= (cucumber_slice_Count - 3) * (300);
                    }

                }

            }

        }

        if (carrot_chop_Count > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < carrot_chop_Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCarrot_chop[i].transform.position.x, tempCarrot_chop[i].transform.position.y), carrot_chop_Answer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCarrot_chop[i].transform.position.x, tempCarrot_chop[i].transform.position.y), carrot_chop_Answer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 1.0) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("당근1위치체크후" + platingScore);
            minDist = 100f;
            if (carrot_chop_Count > 1)
            {
                for (int i = 0; (i < carrot_chop_Count); i++)
                {
                    for (int j = 0; (j < carrot_chop_Answer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCarrot_chop[i].transform.position.x, tempCarrot_chop[i].transform.position.y), carrot_chop_Answer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCarrot_chop[i].transform.position.x, tempCarrot_chop[i].transform.position.y), carrot_chop_Answer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }

                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 1.0) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("당근2위치체크후" + platingScore);
                minDist = 100f;
                if (carrot_chop_Count > 2)
                {
                    for (int i = 0; i < carrot_chop_Count; i++)
                    {
                        for (int j = 0; j < carrot_chop_Answer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCarrot_chop[i].transform.position.x, tempCarrot_chop[i].transform.position.y), carrot_chop_Answer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCarrot_chop[i].transform.position.x, tempCarrot_chop[i].transform.position.y), carrot_chop_Answer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }

                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 1.0) platingScore -= 1100;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("당근3위치체크후" + platingScore);
                    minDist = 100f;
                    if (carrot_chop_Count > 3)
                    {
                        for (int i = 0; i < carrot_chop_Count; i++)
                        {
                            for (int j = 0; j < carrot_chop_Answer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempCarrot_chop[i].transform.position.x, tempCarrot_chop[i].transform.position.y), carrot_chop_Answer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempCarrot_chop[i].transform.position.x, tempCarrot_chop[i].transform.position.y), carrot_chop_Answer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }

                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 1.0) platingScore -= 1100;
                        else platingScore -= (int)(minDist / standard2) * 100;
                        Debug.Log("당근4위치체크후" + platingScore);
                        minDist = 100f;
                        if (carrot_chop_Count > 4)
                        {
                            platingScore -= (carrot_chop_Count - 4) * (200);
                        }

                    }

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
        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempBread = null;
        tempKetchup = null;
        tempCucumber_slice = null;
        tempApple_chop = null;
        tempCarrot_chop = null;
        tempMozza = null;


    }

    /*========================================================================== < stage3 > ============================================================================*/
    /*===================================================================== < platingSample13 > =======================================================================*/

    public void checkPlating13()
    {

        int platingScore = 7000;
        //float tempCarrotX = 0;
        GameObject tempNoodle = null;

        // GameObject tempBasil = null;
        GameObject[] tempIce = new GameObject[5];
        GameObject[] tempRadishsprout = new GameObject[5];
        GameObject[] tempCucumber = new GameObject[5];
        GameObject[] tempChocosyrup = new GameObject[5];
        GameObject[] tempCaramelsyrup = new GameObject[5];
        //기준 1100원
        int cucumberCount = 0;
        int radishsproutCount = 0;
        int noodleCount = 0;
        int chocosyrupCount = 0;
        int caramelsyrupCount = 0;
        int iceCount = 0;

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedNoodle_gochujang(Clone)")
            {
                tempNoodle = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                noodleCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedRadishsprout(Clone)")
            {
                tempRadishsprout[radishsproutCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                radishsproutCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedIce(Clone)")
            {

                tempIce[iceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                iceCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCucumber_chop(Clone)")
            {

                tempCucumber[cucumberCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cucumberCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "chocoLineDrawer(Clone)")
            {
                tempChocosyrup[chocosyrupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                chocosyrupCount++;

            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "caramelLineDrawer(Clone)")
            {
                tempCaramelsyrup[caramelsyrupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                caramelsyrupCount++;

            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }
        Debug.Log("올바르지않은재료체크후" + platingScore);
        //순서체크
        //얼음, 오이, 무순이 면보다 위
        for (int i = 0; i < radishsproutCount; i++)
        {
            if (tempNoodle != null)
            {
                if (tempRadishsprout[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
            }
        }
        for (int i = 0; i < cucumberCount; i++)
        {
            if (tempNoodle != null)
            {
                if (tempCucumber[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
            }
        }
        for (int i = 0; i < iceCount; i++)
        {
            if (tempNoodle != null)
            {
                if (tempIce[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
            }
        }
        Debug.Log("순서체크후" + platingScore);
        // 있어야할 재료가 모자르면 -(1100÷해당 재료 전체갯수)*모자른 갯수
        if (noodleCount == 0) platingScore -= 1100;
        if (radishsproutCount == 0) platingScore -= 1100;

        if (iceCount == 0)
            platingScore -= 1100;
        else if (iceCount > 0 && iceCount < 3)
            platingScore -= (300) * (3 - iceCount);

        if (cucumberCount == 0)
            platingScore -= 1100;
        else if (cucumberCount > 0 && cucumberCount < 3)
            platingScore -= (300) * (3 - cucumberCount);

        if (chocosyrupCount == 0)
            platingScore -= 1100;
        else if (chocosyrupCount > 0 && chocosyrupCount < 3)
            platingScore -= (300) * (3 - chocosyrupCount);

        if (caramelsyrupCount == 0)
            platingScore -= 1100;
        else if (caramelsyrupCount > 0 && caramelsyrupCount < 3)
            platingScore -= (300) * (3 - caramelsyrupCount);

        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;


        Vector2 ice1Answer = new Vector2(0f, 1.1f); //첫번째 당근 정답
        Vector2 ice2Answer = new Vector2(-1.59f, -1.01f);
        Vector2 ice3Answer = new Vector2(1.37f, -1.27f);
        Vector2[] iceAnswer = { ice1Answer, ice2Answer, ice3Answer };
        Vector2 radishsproutAnswer = new Vector2(0, -0.45f);
        Vector2 cucumber1Answer = new Vector2(-1.14f, 0.31f);
        Vector2 cucumber2Answer = new Vector2(0, -1.9f);
        Vector2 cucumber3Answer = new Vector2(1.16f, 0.29f);
        Vector2[] cucumberAnswer = { cucumber1Answer, cucumber2Answer, cucumber3Answer };
        Vector2 caramelsyrup1Answer = new Vector2(4.97f, 2.25f);
        Vector2 caramelsyrup2Answer = new Vector2(6.21f, 1.07f);
        Vector2 caramelsyrup3Answer = new Vector2(7.05f, -0.42f);
        Vector2[] caramelsyrupAnswer = { caramelsyrup1Answer, caramelsyrup2Answer, caramelsyrup3Answer };
        Vector2 chocosyrup1Answer = new Vector2(0.05f, -1.87f);
        Vector2 chocosyrup2Answer = new Vector2(1.01f, -3.26f);
        Vector2 chocosyrup3Answer = new Vector2(2.43f, -4.19f);
        Vector2[] chocosyrupAnswer = { chocosyrup1Answer, cucumber2Answer, cucumber3Answer };


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
            if (minDist > standard1) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
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
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
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
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > standard1) platingScore -= 1100;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("오이3위치체크후" + platingScore);
                    minDist = 100f;
                    if (cucumberCount > 3)
                    {
                        platingScore -= (cucumberCount - 3) * (300);
                    }

                }

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
                for (int j = 0; j < 3; j++)
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
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
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
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
                   Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > standard1) platingScore -= 1100;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("얼음3위치체크후" + platingScore);
                    minDist = 100f;
                    if (iceCount > 3)
                    {
                        platingScore -= (iceCount - 3) * (300);
                    }

                }

            }

        }

        if (chocosyrupCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            for (int i = 0; i < chocosyrupCount; i++)
            {
                for (int j = 0; j < chocosyrupAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
           Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 10) platingScore -= 1100;
            else platingScore -= (int)(minDist / 3) * 100;
            Debug.Log("초코시럼1위치체크후" + platingScore);
            minDist = 100f;
            if (chocosyrupCount > 1)
            {
                for (int i = 0; (i < chocosyrupCount); i++)
                {
                    for (int j = 0; (j < chocosyrupAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 10) platingScore -= 1100;
                else platingScore -= (int)(minDist / 3) * 100;
                Debug.Log("초코시럽2위치체크후" + platingScore);
                minDist = 100f;
                if (chocosyrupCount > 2)
                {
                    for (int i = 0; i < chocosyrupCount; i++)
                    {
                        for (int j = 0; j < chocosyrupAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                   Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 10) platingScore -= 1100;
                    else platingScore -= (int)(minDist / 3) * 100;
                    Debug.Log("초코시럽3위치체크후" + platingScore);
                    minDist = 100f;
                    if (chocosyrupCount > 3)
                    {
                        platingScore -= (chocosyrupCount - 3) * (300);
                    }

                }

            }

        }

        if (caramelsyrupCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            for (int i = 0; i < caramelsyrupCount; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
          Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 10) platingScore -= 1100;
            else platingScore -= (int)(minDist / 3) * 100;
            Debug.Log("카라멜시럽1위치체크후" + platingScore);
            minDist = 100f;
            if (caramelsyrupCount > 1)
            {
                for (int i = 0; (i < caramelsyrupCount); i++)
                {
                    for (int j = 0; (j < caramelsyrupAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 10) platingScore -= 1100;
                else platingScore -= (int)(minDist / 3) * 100;
                Debug.Log("카라멜시럽2위치체크후" + platingScore);
                minDist = 100f;
                if (caramelsyrupCount > 2)
                {
                    for (int i = 0; i < caramelsyrupCount; i++)
                    {
                        for (int j = 0; j < caramelsyrupAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 10) platingScore -= 1100;
                    else platingScore -= (int)(minDist / 3) * 100;
                    Debug.Log("카라멜시럽3위치체크후" + platingScore);
                    minDist = 100f;
                    if (caramelsyrupCount > 3)
                    {
                        platingScore -= (caramelsyrupCount - 3) * (300);
                    }

                }

            }

        }

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점
        Debug.Log(platingScore);
        if (platingScore < 0) platingScore = 0;
        Debug.Log("0점 미만->" + platingScore);

        SetScoreText(platingScore);


        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempNoodle = null;
        tempRadishsprout = null;
        tempIce = null;
        tempCucumber = null;
        tempChocosyrup = null;
        tempCaramelsyrup = null;


    }

    /*===================================================================== < platingSample14 > =======================================================================*/

    public void checkPlating14()
    {

        int platingScore = 7000;
        //float tempCarrotX = 0;
        GameObject tempNoodle = null;
        GameObject[] tempBasil = new GameObject[5];
        GameObject[] tempCarrot = new GameObject[5];
        GameObject[] tempCucumber = new GameObject[5];
        GameObject[] tempBlueberrysyrup = new GameObject[5];
        GameObject[] tempOrangesyrup = new GameObject[5];
        //기준1100원
        int cucumberCount = 0;
        int carrotCount = 0;
        int noodleCount = 0;
        int basilCount = 0;
        int blueberrysyrupCount = 0;
        int orangesyrupCount = 0;

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedNoodle_gochujang(Clone)")
            {
                tempNoodle = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                noodleCount++;
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
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "blueberryLineDrawer(Clone)")
            {
                tempBlueberrysyrup[blueberrysyrupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberrysyrupCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "orangeLineDrawer(Clone)")
            {
                tempOrangesyrup[orangesyrupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                orangesyrupCount++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크


        if (tempNoodle != null)
        {
            for (int i = 0; i < basilCount; i++)
            {
                if (tempBasil[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
            }
        }

        for (int i = 0; i < carrotCount; i++)
        {
            if (tempNoodle != null)
            {
                if (tempCarrot[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
            }
            for (int j = 0; j < cucumberCount; j++)
            {
                //당근이 오이보다 위에 있으면 감산
                if (tempCarrot[i].transform.position.z < tempCucumber[j].transform.position.z) platingScore -= 100;
            }
        }
        for (int i = 0; i < cucumberCount; i++)
        {
            if (tempNoodle != null)
            {
                if (tempCucumber[i].transform.position.z > tempNoodle.transform.position.z) platingScore -= 100;
            }
        }

        // 있어야할 재료가 모자르면 -(1000÷해당 재료 전체갯수)*모자른 갯수
        if (noodleCount == 0) platingScore -= 1100;
        if (basilCount == 0) platingScore -= 1100;

        if (carrotCount == 0)
            platingScore -= 1100;
        else if (carrotCount > 0 && carrotCount < 3)
            platingScore -= (300) * (3 - carrotCount);

        if (cucumberCount == 0)
            platingScore -= 1100;
        else if (cucumberCount > 0 && cucumberCount < 3)
            platingScore -= (300) * (3 - cucumberCount);

        if (blueberrysyrupCount == 0)
            platingScore -= 1100;
        else if (blueberrysyrupCount > 0 && blueberrysyrupCount < 4)
            platingScore -= (200) * (4 - blueberrysyrupCount);

        if (orangesyrupCount == 0)
            platingScore -= 1100;
        else if (orangesyrupCount > 0 && orangesyrupCount < 4)
            platingScore -= (200) * (4 - orangesyrupCount);


        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;


        Vector2 carrot1Answer = new Vector2(-1.36f, -0.9f); //첫번째 당근 정답
        Vector2 carrot2Answer = new Vector2(0.79f, 0.74f);
        Vector2 carrot3Answer = new Vector2(0.9f, -1.55f);
        Vector2[] carrotAnswer = { carrot1Answer, carrot2Answer, carrot3Answer };
        Vector2 basilAnswer = new Vector2(0.05f, -0.5f);
        Vector2 cucumber1Answer = new Vector2(-1.3f, -0.82f);
        Vector2 cucumber2Answer = new Vector2(0.96f, -1.52f);
        Vector2 cucumber3Answer = new Vector2(0.8f, 0.74f);
        Vector2[] cucumberAnswer = { cucumber1Answer, cucumber2Answer, cucumber3Answer };
        Vector2 blueberrysyrup1Answer = new Vector2(1.08f, -2.71f);
        Vector2 blueberrysyrup2Answer = new Vector2(-3.25f, 0.57f);
        Vector2 blueberrysyrup3Answer = new Vector2(-1.34f, -3.33f);
        Vector2 blueberrysyrup4Answer = new Vector2(3.38f, -1.11f);
        Vector2[] blueberrysyrupAnswer = { blueberrysyrup1Answer, blueberrysyrup2Answer, blueberrysyrup3Answer, blueberrysyrup4Answer };
        Vector2 orangesyrup1Answer = new Vector2(-1.27f, 2.52f);
        Vector2 orangesyrup2Answer = new Vector2(-3.06f, 1.77f);
        Vector2 orangesyrup3Answer = new Vector2(1.58f, -3.45f);
        Vector2 orangesyrup4Answer = new Vector2(2.91f, 1.23f);
        Vector2[] orangesyrupAnswer = { orangesyrup1Answer, orangesyrup2Answer, orangesyrup3Answer, orangesyrup4Answer };

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
            if (minDist > standard1) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("바질위치체크후" + platingScore);
            minDist = 100f;
            if (basilCount > 1)
            {
                platingScore -= (basilCount - 1) * (1100);
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
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
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
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
                  Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > standard1) platingScore -= 1100;
                    else platingScore -= (int)(minDist / standard2) * 100;
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
          Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
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
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
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
                   Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > standard1) platingScore -= 1100;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("당근3위치체크후" + platingScore);
                    minDist = 100f;
                    if (carrotCount > 3)
                    {
                        platingScore -= (carrotCount - 3) * (300);
                    }

                }

            }

        }

        if (blueberrysyrupCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < blueberrysyrupCount; i++)
            {
                for (int j = 0; j < blueberrysyrupAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempBlueberrysyrup[i].transform.position.x, tempBlueberrysyrup[i].transform.position.y), blueberrysyrupAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempBlueberrysyrup[i].transform.position.x, tempBlueberrysyrup[i].transform.position.y), blueberrysyrupAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 10) platingScore -= 1100;
            else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("블루베리시럽1위치체크후" + platingScore);
            minDist = 100f;
            if (blueberrysyrupCount > 1)
            {
                for (int i = 0; (i < blueberrysyrupCount); i++)
                {
                    for (int j = 0; (j < blueberrysyrupAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempBlueberrysyrup[i].transform.position.x, tempBlueberrysyrup[i].transform.position.y), blueberrysyrupAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempBlueberrysyrup[i].transform.position.x, tempBlueberrysyrup[i].transform.position.y), blueberrysyrupAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 10) platingScore -= 1100;
                else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("블루베리시럽2위치체크후" + platingScore);
                minDist = 100f;
                if (blueberrysyrupCount > 2)
                {
                    for (int i = 0; i < blueberrysyrupCount; i++)
                    {
                        for (int j = 0; j < blueberrysyrupAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempBlueberrysyrup[i].transform.position.x, tempBlueberrysyrup[i].transform.position.y), blueberrysyrupAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempBlueberrysyrup[i].transform.position.x, tempBlueberrysyrup[i].transform.position.y), blueberrysyrupAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                  Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 10) platingScore -= 1100;
                    else platingScore -= (int)(minDist / 5) * 100;
                    Debug.Log("블루베리3위치체크후" + platingScore);
                    minDist = 100f;
                    if (blueberrysyrupCount > 3)
                    {
                        for (int i = 0; i < blueberrysyrupCount; i++)
                        {
                            for (int j = 0; j < blueberrysyrupAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempBlueberrysyrup[i].transform.position.x, tempBlueberrysyrup[i].transform.position.y), blueberrysyrupAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempBlueberrysyrup[i].transform.position.x, tempBlueberrysyrup[i].transform.position.y), blueberrysyrupAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                      Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 10) platingScore -= 1100;
                        else platingScore -= (int)(minDist / 5) * 100;
                        Debug.Log("블루베리4위치체크후" + platingScore);
                        minDist = 100f;
                        if (blueberrysyrupCount > 4)
                        {
                            platingScore -= (blueberrysyrupCount - 4) * (200);
                        }

                    }

                }
            }
        }

        if (orangesyrupCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < orangesyrupCount; i++)
            {
                for (int j = 0; j < orangesyrupAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempOrangesyrup[i].transform.position.x, tempOrangesyrup[i].transform.position.y), orangesyrupAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempOrangesyrup[i].transform.position.x, tempOrangesyrup[i].transform.position.y), orangesyrupAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
          Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 10) platingScore -= 1100;
            else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("오렌지착즙1위치체크후" + platingScore);
            minDist = 100f;
            if (orangesyrupCount > 1)
            {
                for (int i = 0; (i < orangesyrupCount); i++)
                {
                    for (int j = 0; (j < orangesyrupAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempOrangesyrup[i].transform.position.x, tempOrangesyrup[i].transform.position.y), orangesyrupAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempOrangesyrup[i].transform.position.x, tempOrangesyrup[i].transform.position.y), orangesyrupAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 10) platingScore -= 1100;
                else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("오렌지착즙2위치체크후" + platingScore);
                minDist = 100f;
                if (orangesyrupCount > 2)
                {
                    for (int i = 0; i < orangesyrupCount; i++)
                    {
                        for (int j = 0; j < orangesyrupAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempOrangesyrup[i].transform.position.x, tempOrangesyrup[i].transform.position.y), orangesyrupAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempOrangesyrup[i].transform.position.x, tempOrangesyrup[i].transform.position.y), orangesyrupAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                   Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 10) platingScore -= 1100;
                    else platingScore -= (int)(minDist / 5) * 100;
                    Debug.Log("오렌지착즙3위치체크후" + platingScore);
                    minDist = 100f;
                    if (orangesyrupCount > 3)
                    {
                        for (int i = 0; i < orangesyrupCount; i++)
                        {
                            for (int j = 0; j < orangesyrupAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempOrangesyrup[i].transform.position.x, tempOrangesyrup[i].transform.position.y), orangesyrupAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempOrangesyrup[i].transform.position.x, tempOrangesyrup[i].transform.position.y), orangesyrupAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                       Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 10) platingScore -= 1100;
                        else platingScore -= (int)(minDist / 5) * 100;
                        Debug.Log("오렌지착즙4위치체크후" + platingScore);
                        minDist = 100f;
                        if (orangesyrupCount > 4)
                        {
                            platingScore -= (orangesyrupCount - 4) * (200);
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
        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempNoodle = null;
        tempBasil = null;
        tempCarrot = null;
        tempCucumber = null;
        tempOrangesyrup = null;
        tempBlueberrysyrup = null;
    }

    /*===================================================================== < platingSample15 > =======================================================================*/
    public void checkPlating15()
    {

        int platingScore = 7000;

        GameObject tempFish = null;
        GameObject[] tempCherrytomato = new GameObject[5];
        GameObject[] tempAsparagus = new GameObject[5];
        GameObject[] tempOrange = new GameObject[5];
        GameObject[] tempLemon = new GameObject[5];
        GameObject[] tempBasil = new GameObject[5];
        GameObject[] tempRadishsprout = new GameObject[5];
        GameObject[] tempBlueberryjuice = new GameObject[5];
        GameObject[] tempChocosyrup = new GameObject[5];
        //재료9개 -> 기준:700원
        int fishCount = 0;
        int cherrytomatoCount = 0;
        int lemonCount = 0;
        int asparagusCount = 0;
        int blueberryjuiceCount = 0;
        int orangeCount = 0;
        int basilCount = 0;
        int radishsproutCount = 0;
        int chocosyrupCount = 0;


        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedFish(Clone)")
            {
                tempFish = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                fishCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherrytomato(Clone)")
            {
                tempCherrytomato[cherrytomatoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherrytomatoCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "blueberryLineDrawer(Clone)")
            {
                tempBlueberryjuice[blueberryjuiceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberryjuiceCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "chocoLineDrawer(Clone)")
            {
                tempChocosyrup[chocosyrupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                chocosyrupCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedAsparagus_grill(Clone)")
            {
                tempAsparagus[asparagusCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                asparagusCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedLemon_chop(Clone)")
            {
                tempLemon[lemonCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                lemonCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBasil(Clone)")
            {
                tempBasil[basilCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                basilCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedRadishsprout(Clone)")
            {
                tempRadishsprout[radishsproutCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                radishsproutCount++;
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

        //순서체크
        for (int i = 0; i < orangeCount; i++)
        {
            if (tempFish != null)
            {
                if (tempOrange[i].transform.position.z > tempFish.transform.position.z) platingScore -= 100;
            }
        }

        // 있어야할 재료가 모자르면 -(700÷재료갯수)*모자른 갯수
        if (fishCount == 0) platingScore -= 700;
        if (basilCount == 0) platingScore -= 700;
        if (asparagusCount == 0) platingScore -= 700;
        if (radishsproutCount == 0) platingScore -= 700;
        if (lemonCount == 0) platingScore -= 700;

        if (blueberryjuiceCount == 0)
            platingScore -= 700;
        else if (blueberryjuiceCount > 0 && blueberryjuiceCount < 2)
            platingScore -= (300) * (2 - blueberryjuiceCount);

        if (chocosyrupCount == 0)
            platingScore -= 700;
        else if (chocosyrupCount > 0 && chocosyrupCount < 4)
            platingScore -= (100) * (4 - chocosyrupCount);

        if (orangeCount == 0)
            platingScore -= 700;
        else if (orangeCount > 0 && orangeCount < 2)
            platingScore -= (300) * (2 - orangeCount);

        if (cherrytomatoCount == 0)
            platingScore -= 700;
        else if (cherrytomatoCount > 0 && cherrytomatoCount < 2)
            platingScore -= (300) * (2 - cherrytomatoCount);



        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;


        Vector2 asparagusAnswer = new Vector2(1.4f, -2.6f);
        Vector2 lemonAnswer = new Vector2(3.33f, -0.71f);
        Vector2 basilAnswer = new Vector2(0.59f, 2.48f);
        Vector2 radishsproutAnswer = new Vector2(-2.93f, 0.66f);

        Vector2 blueberryjuice1Answer = new Vector2(-1.11f, -3.13f);
        Vector2 blueberryjuice2Answer = new Vector2(-0.41f, -2.74f);
        Vector2[] blueberryjuiceAnswer = { blueberryjuice1Answer, blueberryjuice2Answer };

        Vector2 orange1Answer = new Vector2(-0.75f, 0.41f);
        Vector2 orange2Answer = new Vector2(0.09f, -0.85f);
        Vector2[] orangeAnswer = { orange1Answer, orange2Answer };

        Vector2 cherrytomato1Answer = new Vector2(-1.55f, 1.95f);
        Vector2 cherrytomato2Answer = new Vector2(-0.65f, 2.31f);
        Vector2[] cherrytomatoAnswer = { cherrytomato1Answer, cherrytomato2Answer };

        Vector2 chocosyrup1Answer = new Vector2(-3f, -0.84f);
        Vector2 chocosyrup2Answer = new Vector2(-1.98f, -1.92f);
        Vector2 chocosyrup3Answer = new Vector2(-3.57f, -1.24f);
        Vector2 chocosyrup4Answer = new Vector2(-2.66f, -2.63f);
        Vector2[] chocosyrupAnswer = { chocosyrup1Answer, chocosyrup2Answer, chocosyrup3Answer, chocosyrup4Answer };


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
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("아스파라거스위치체크후" + platingScore);
            minDist = 100f;
            if (asparagusCount > 1)
            {
                platingScore -= (asparagusCount - 1) * (700 / 1);
            }

        }

        if (radishsproutCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < basilCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("무순" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("무순위치체크후" + platingScore);
            minDist = 100f;
            if (radishsproutCount > 1)
            {
                platingScore -= (radishsproutCount - 1) * (700);
            }

        }
        if (lemonCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < lemonCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempLemon[i].transform.position.x, tempLemon[i].transform.position.y), lemonAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempLemon[i].transform.position.x, tempLemon[i].transform.position.y), lemonAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("lemon" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("lemon위치체크후" + platingScore);
            minDist = 100f;
            if (lemonCount > 1)
            {
                platingScore -= (lemonCount - 1) * (700);
            }

        }
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
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("바질위치체크후" + platingScore);
            minDist = 100f;
            if (basilCount > 1)
            {
                platingScore -= (basilCount - 1) * (700);
            }

        }

        if (orangeCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

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
           Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("orange1위치체크후" + platingScore);
            minDist = 100f;
            if (orangeCount > 1)
            {
                for (int i = 0; (i < orangeCount); i++)
                {
                    for (int j = 0; j < orangeAnswer.Length; j++)
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
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("orange2위치체크후" + platingScore);
                minDist = 100f;
                if (orangeCount > 2)
                {
                    platingScore -= (orangeCount - 2) * (300);
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("Cherrytomato1위치체크후" + platingScore);
            minDist = 100f;
            if (cherrytomatoCount > 1)
            {
                for (int i = 0; (i < cherrytomatoCount); i++)
                {
                    for (int j = 0; j < cherrytomatoAnswer.Length; j++)
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
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("Cherrytomato2위치체크후" + platingScore);
                minDist = 100f;
                if (cherrytomatoCount > 2)
                {
                    platingScore -= (cherrytomatoCount - 2) * (300);
                }

            }

        }

        if (blueberryjuiceCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < blueberryjuiceCount; i++)
            {
                for (int j = 0; j < blueberryjuiceAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
           Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 10) platingScore -= 700;
            else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("블루베리착즙1위치체크후" + platingScore);
            minDist = 100f;
            if (blueberryjuiceCount > 1)
            {
                for (int i = 0; (i < blueberryjuiceCount); i++)
                {
                    for (int j = 0; (j < blueberryjuiceAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 10) platingScore -= 700;
                else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("블루베리착즙2위치체크후" + platingScore);
                minDist = 100f;
                if (blueberryjuiceCount > 2)
                {
                    platingScore -= (blueberryjuiceCount - 2) * (300);
                }
            }
        }

        if (chocosyrupCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < chocosyrupCount; i++)
            {
                for (int j = 0; j < chocosyrupAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 10) platingScore -= 700;
            else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("초코시럼1위치체크후" + platingScore);
            minDist = 100f;
            if (chocosyrupCount > 1)
            {
                for (int i = 0; (i < chocosyrupCount); i++)
                {
                    for (int j = 0; (j < chocosyrupAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 10) platingScore -= 700;
                else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("초코시럽2위치체크후" + platingScore);
                minDist = 100f;
                if (chocosyrupCount > 2)
                {
                    for (int i = 0; i < chocosyrupCount; i++)
                    {
                        for (int j = 0; j < chocosyrupAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                   Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 10) platingScore -= 700;
                    else platingScore -= (int)(minDist / 5) * 100;
                    Debug.Log("초코시럽3위치체크후" + platingScore);
                    minDist = 100f;
                    if (chocosyrupCount > 3)
                    {
                        for (int i = 0; i < chocosyrupCount; i++)
                        {
                            for (int j = 0; j < chocosyrupAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 10) platingScore -= 700;
                        else platingScore -= (int)(minDist / 5) * 100;
                        Debug.Log("초코시럽4위치체크후" + platingScore);
                        minDist = 100f;
                        if (chocosyrupCount > 4)
                        {
                            platingScore -= (chocosyrupCount - 4) * (100);
                        }

                    }

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
        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempFish = null;
        tempCherrytomato = null;
        tempBlueberryjuice = null;
        tempAsparagus = null;
        tempRadishsprout = null;
        tempChocosyrup = null;
        tempBasil = null;
        tempLemon = null;
        tempOrange = null;

    }

    /*===================================================================== < platingSample16 > =======================================================================*/
    public void checkPlating16()
    {

        int platingScore = 7000;

        GameObject tempFish = null;
        GameObject[] tempAvocado = new GameObject[5];
        GameObject[] tempCarrot = new GameObject[5];
        GameObject[] tempIcecream = new GameObject[5];
        GameObject[] tempStrawberry = new GameObject[5];
        GameObject[] tempBlueberryjuice = new GameObject[5];
        GameObject[] tempOrangejuice = new GameObject[5];
        GameObject[] tempCaramelsyrup = new GameObject[5];

        //재료 8개->기준 800원
        int fishCount = 0;
        int avocadoCount = 0;
        int carrotCount = 0;
        int strawberryCount = 0;
        int icecreamCount = 0;
        int caramelsyrupCount = 0;
        int blueberryjuiceCount = 0;
        int orangejuiceCount = 0;

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedFish(Clone)")
            {
                tempFish = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                fishCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedAvocado_chop(Clone)")
            {
                tempAvocado[avocadoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                avocadoCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCarrot_chop_grill(Clone)")
            {
                tempCarrot[carrotCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                carrotCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedStrawberry(Clone)")
            {
                tempStrawberry[strawberryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                strawberryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedIcecream(Clone)")
            {
                tempIcecream[icecreamCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                icecreamCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "blueberryLineDrawer(Clone)")
            {
                tempBlueberryjuice[blueberryjuiceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberryjuiceCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "caramelLineDrawer(Clone)")
            {
                tempCaramelsyrup[caramelsyrupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                caramelsyrupCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "orangeLineDrawer(Clone)")
            {
                tempOrangejuice[orangejuiceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                orangejuiceCount++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크X
        for (int i = 0; i < strawberryCount; i++)
        {
            for (int j = 0; j < icecreamCount; j++)
            {
                //딸기가 아이스크림보다 밑에 있으면 감산
                if (tempStrawberry[i].transform.position.z > tempIcecream[j].transform.position.z) platingScore -= 100;
            }
        }
        // 있어야할 재료가 모자르면 -(800÷해당 재료 전체갯수)*모자른 갯수
        if (fishCount == 0) platingScore -= 800;
        if (avocadoCount == 0) platingScore -= 800;

        if (carrotCount == 0)
            platingScore -= 800;
        else if (carrotCount == 1)
            platingScore -= 300;

        if (icecreamCount == 0) platingScore -= 800;
        if (strawberryCount == 0) platingScore -= 800;

        if (caramelsyrupCount == 0)
            platingScore -= 800;
        else if (caramelsyrupCount > 0 && caramelsyrupCount < 4)
            platingScore -= (200) * (4 - caramelsyrupCount);

        if (blueberryjuiceCount == 0)
            platingScore -= 800;
        else if (blueberryjuiceCount > 0 && blueberryjuiceCount < 3)
            platingScore -= (200) * (3 - blueberryjuiceCount);

        if (orangejuiceCount == 0)
            platingScore -= 800;
        else if (orangejuiceCount == 1)
            platingScore -= 300;


        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;

        Vector2 strawberryAnswer = new Vector2(-0.05f, -2.91f);
        Vector2 avocadoAnswer = new Vector2(2.49f, -1.66f);
        Vector2 icecreamAnswer = new Vector2(-0.08f, -3.27f);

        Vector2 carrot1Answer = new Vector2(3.59f, 0.91f);
        Vector2 carrot2Answer = new Vector2(2.72f, 2.06f);
        Vector2[] carrotAnswer = { carrot1Answer, carrot2Answer };

        Vector2 orangejuice1Answer = new Vector2(-2.94f, 1.09f);
        Vector2 orangejuice2Answer = new Vector2(-2.15f, 1.24f);
        Vector2[] orangejuiceAnswer = { orangejuice1Answer, orangejuice2Answer };

        Vector2 blueberryjuice1Answer = new Vector2(-0.13f, 2.13f);
        Vector2 blueberryjuice2Answer = new Vector2(-0.13f, 2.13f);
        Vector2 blueberryjuice3Answer = new Vector2(-0.13f, 2.13f);
        Vector2[] blueberryjuiceAnswer = { blueberryjuice1Answer, blueberryjuice2Answer, blueberryjuice3Answer };

        Vector2 caramelsyrup1Answer = new Vector2(-2.99f, -0.77f);
        Vector2 caramelsyrup2Answer = new Vector2(-3.64f, -1.48f);
        Vector2 caramelsyrup3Answer = new Vector2(-2.13f, -1.86f);
        Vector2 caramelsyrup4Answer = new Vector2(-2.81f, -2.48f);
        Vector2[] caramelsyrupAnswer = { caramelsyrup1Answer, caramelsyrup2Answer, caramelsyrup3Answer, caramelsyrup4Answer };

        if (avocadoCount > 0)
        {
            int tempIndex1 = 0;
            for (int i = 0; i < avocadoCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempAvocado[i].transform.position.x, tempAvocado[i].transform.position.y), avocadoAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempAvocado[i].transform.position.x, tempAvocado[i].transform.position.y), avocadoAnswer);
                    tempIndex1 = i;
                }
            }
            Debug.Log("아보카도" + minDist);
            if (minDist > standard1) platingScore -= 800;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("아보카도위치체크후" + platingScore);
            minDist = 100f;
            if (avocadoCount > 1)
            {
                platingScore -= (avocadoCount - 1) * (800);
            }
        }

        if (strawberryCount > 0)
        {
            int tempIndex1 = 0;
            for (int i = 0; i < strawberryCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer);
                    tempIndex1 = i;
                }
            }
            Debug.Log("strawberry" + minDist);
            if (minDist > standard1) platingScore -= 800;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("strawberry위치체크후" + platingScore);
            minDist = 100f;
            if (strawberryCount > 1)
            {
                platingScore -= (strawberryCount - 1) * (800);
            }
        }

        if (icecreamCount > 0)
        {
            int tempIndex1 = 0;
            for (int i = 0; i < icecreamCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempIcecream[i].transform.position.x, tempIcecream[i].transform.position.y), icecreamAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempIcecream[i].transform.position.x, tempIcecream[i].transform.position.y), icecreamAnswer);
                    tempIndex1 = i;
                }
            }
            Debug.Log("icecream" + minDist);
            if (minDist > standard1) platingScore -= 800;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("icecream위치체크후" + platingScore);
            minDist = 100f;
            if (icecreamCount > 1)
            {
                platingScore -= (icecreamCount - 1) * (800);
            }
        }

        if (orangejuiceCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < orangejuiceCount; i++)
            {
                for (int j = 0; j < orangejuiceAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
           Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 10) platingScore -= 800;
            else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("오렌지1위치체크후" + platingScore);
            minDist = 100f;
            if (orangejuiceCount > 1)
            {
                for (int i = 0; (i < orangejuiceCount); i++)
                {
                    for (int j = 0; (j < orangejuiceAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 10) platingScore -= 800;
                else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("오렌지2위치체크후" + platingScore);
                minDist = 100f;
                if (orangejuiceCount > 2)
                {
                    platingScore -= (orangejuiceCount - 2) * (400);
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
           Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 800;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("Carrot1위치체크후" + platingScore);
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
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 800;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("Carrot2위치체크후" + platingScore);
                minDist = 100f;
                if (carrotCount > 2)
                {
                    platingScore -= (carrotCount - 2) * (400);
                }
            }
        }

        if (blueberryjuiceCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;

            for (int i = 0; i < blueberryjuiceCount; i++)
            {
                for (int j = 0; j < blueberryjuiceAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 10) platingScore -= 800;
            else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("블루베리시럽1위치체크후" + platingScore);
            minDist = 100f;
            if (blueberryjuiceCount > 1)
            {
                for (int i = 0; (i < blueberryjuiceCount); i++)
                {
                    for (int j = 0; (j < blueberryjuiceAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 10) platingScore -= 800;
                else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("블루베리시럽2위치체크후" + platingScore);
                minDist = 100f;
                if (blueberryjuiceCount > 2)
                {
                    for (int i = 0; i < blueberryjuiceCount; i++)
                    {
                        for (int j = 0; j < blueberryjuiceAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                   Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 10) platingScore -= 800;
                    else platingScore -= (int)(minDist / 5) * 100;
                    Debug.Log("블루베리3위치체크후" + platingScore);
                    minDist = 100f;
                    if (blueberryjuiceCount > 3)
                    {
                        platingScore -= (blueberryjuiceCount - 3) * (200);
                    }
                }
            }
        }
        if (caramelsyrupCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < caramelsyrupCount; i++)
            {
                for (int j = 0; j < caramelsyrupAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
           Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 10) platingScore -= 800;
            else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("카라멜시럽1위치체크후" + platingScore);
            minDist = 100f;
            if (caramelsyrupCount > 1)
            {
                for (int i = 0; (i < caramelsyrupCount); i++)
                {
                    for (int j = 0; (j < caramelsyrupAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 10) platingScore -= 800;
                else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("카라멜시럽2위치체크후" + platingScore);
                minDist = 100f;
                if (caramelsyrupCount > 2)
                {
                    for (int i = 0; i < caramelsyrupCount; i++)
                    {
                        for (int j = 0; j < caramelsyrupAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                   Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 10) platingScore -= 800;
                    else platingScore -= (int)(minDist / 5) * 100;
                    Debug.Log("카라멜시럽3위치체크후" + platingScore);
                    minDist = 100f;
                    if (caramelsyrupCount > 3)
                    {
                        for (int i = 0; i < caramelsyrupCount; i++)
                        {
                            for (int j = 0; j < caramelsyrupAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 10) platingScore -= 800;
                        else platingScore -= (int)(minDist / 5) * 100;
                        Debug.Log("카라멜시럽4위치체크후" + platingScore);
                        minDist = 100f;
                        if (caramelsyrupCount > 4)
                        {
                            platingScore -= (caramelsyrupCount - 4) * (200);
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
        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempFish = null;
        tempAvocado = null;
        tempStrawberry = null;
        tempIcecream = null;
        tempCarrot = null;
        tempOrangejuice = null;
        tempBlueberryjuice = null;
        tempCaramelsyrup = null;

    }

    /*===================================================================== < platingSample17 > =======================================================================*/

    public void checkPlating17()
    {

        int platingScore = 7000;
        //float tempCarrotX = 0;
        GameObject tempSalad = null;
        GameObject[] tempBasil = new GameObject[5];
        GameObject[] tempCherrytomato = new GameObject[5];
        GameObject[] tempCarrot = new GameObject[5];
        GameObject[] tempCucumber = new GameObject[5];
        GameObject[] tempRadishsprout = new GameObject[5];
        GameObject[] tempOrangejuice = new GameObject[5];
        GameObject[] tempKetchup = new GameObject[5];
        GameObject[] tempMayo = new GameObject[5];

        //기준9개->700원
        int saladCount = 0;
        int cucumberCount = 0;
        int carrotCount = 0;
        int cherrytomatoCount = 0;
        int basilCount = 0;
        int radishsproutCount = 0;
        int mayoCount = 0;
        int ketchupCount = 0;
        int orangejuiceCount = 0;

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedSalad(Clone)")
            {
                tempSalad = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                saladCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedRadishsprout(Clone)")
            {
                tempRadishsprout[radishsproutCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                radishsproutCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherrytomato_chop(Clone)")
            {
                tempCherrytomato[cherrytomatoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherrytomatoCount++;
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
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBasil(Clone)")
            {
                tempBasil[basilCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                basilCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "ketchupLineDrawer(Clone)")
            {
                tempKetchup[ketchupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                ketchupCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "mayonnaiseLineDrawer(Clone)")
            {
                tempMayo[mayoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                mayoCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "orangeLineDrawer(Clone)")
            {
                tempOrangejuice[orangejuiceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                orangejuiceCount++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크
        for (int i = 0; i < radishsproutCount; i++)
        {
            if (tempSalad != null)
            {
                if (tempRadishsprout[i].transform.position.z > tempSalad.transform.position.z) platingScore -= 100;
            }
            for (int j = 0; j < basilCount; j++)
            {
                if (tempRadishsprout[i].transform.position.z < tempBasil[j].transform.position.z) platingScore -= 100;
            }
        }
        for (int i = 0; i < carrotCount; i++)
        {
            if (tempSalad != null)
            {
                if (tempCarrot[i].transform.position.z > tempSalad.transform.position.z) platingScore -= 100;
            }
        }
        for (int i = 0; i < cucumberCount; i++)
        {
            if (tempSalad != null)
            {
                if (tempCucumber[i].transform.position.z > tempSalad.transform.position.z) platingScore -= 100;
            }
        }
        for (int i = 0; i < cherrytomatoCount; i++)
        {
            if (tempSalad != null)
            {
                if (tempCherrytomato[i].transform.position.z > tempSalad.transform.position.z) platingScore -= 100;
            }
        }
        // 있어야할 재료가 모자르면 -(1000÷해당 재료 전체갯수)*모자른 갯수
        if (saladCount == 0) platingScore -= 700;
        if (basilCount == 0) platingScore -= 700;

        if (radishsproutCount == 0)
            platingScore -= 700;
        else if (radishsproutCount == 1)
            platingScore -= 300;

        if (cucumberCount == 0)
            platingScore -= 700;
        else if (cucumberCount > 0 && carrotCount < 3)
            platingScore -= (200) * (3 - cucumberCount);

        if (cherrytomatoCount == 0)
            platingScore -= 700;
        else if (cherrytomatoCount > 0 && cherrytomatoCount < 3)
            platingScore -= (200) * (3 - cherrytomatoCount);

        if (carrotCount == 0)
            platingScore -= 700;
        else if (carrotCount > 0 && carrotCount < 3)
            platingScore -= (200) * (3 - carrotCount);

        if (mayoCount == 0)
            platingScore -= 700;
        else if (mayoCount > 0 && mayoCount < 5)
            platingScore -= (100) * (5 - mayoCount);

        if (ketchupCount == 0)
            platingScore -= 700;
        else if (ketchupCount > 0 && ketchupCount < 5)
            platingScore -= (100) * (5 - mayoCount);

        if (orangejuiceCount == 0)
            platingScore -= 700;
        else if (orangejuiceCount > 0 && orangejuiceCount < 5)
            platingScore -= (100) * (5 - orangejuiceCount);

        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;



        Vector2 basilAnswer = new Vector2(0f, -0.45f);
        Vector2 radishsprout1Answer = new Vector2(0.33f, -0.56f);
        Vector2 radishsprout2Answer = new Vector2(-0.14f, -0.17f);
        Vector2[] radishsproutAnswer = { radishsprout1Answer, radishsprout2Answer };
        Vector2 cucumber1Answer = new Vector2(-0.61f, 1.35f);
        Vector2 cucumber2Answer = new Vector2(-1.42f, -1.92f);
        Vector2 cucumber3Answer = new Vector2(1.97f, -0.6f);
        Vector2[] cucumberAnswer = { cucumber1Answer, cucumber2Answer, cucumber3Answer };
        Vector2 carrot1Answer = new Vector2(-1.77f, 0.45f); //첫번째 당근 정답
        Vector2 carrot2Answer = new Vector2(1.65f, 0.72f);
        Vector2 carrot3Answer = new Vector2(0.22f, -2.23f);
        Vector2[] carrotAnswer = { carrot1Answer, carrot2Answer, carrot3Answer };
        Vector2 cherrytomato1Answer = new Vector2(0.71f, 1.46f); //첫번째 당근 정답
        Vector2 cherrytomato2Answer = new Vector2(-1.97f, -0.79f);
        Vector2 cherrytomato3Answer = new Vector2(1.46f, -1.81f);
        Vector2[] cherrytomatoAnswer = { cherrytomato1Answer, cherrytomato2Answer, cherrytomato3Answer };

        Vector2[] ketchupAnswer = { new Vector2(-1.81f, 2.44f), new Vector2(-3.68f, -1.03f), new Vector2(-0.33f, -3.8f), new Vector2(3.02f, -2.28f), new Vector2(2.45f, 1.9f) };
        Vector2[] mayoAnswer = { new Vector2(-0.29f, 2.86f), new Vector2(-3.37f, 0.52f), new Vector2(-2.04f, -3.26f), new Vector2(1.9f, -3.26f), new Vector2(3.27f, 0.57f) };
        Vector2[] orangejuiceAnswer = { new Vector2(1.2f, 2.63f), new Vector2(-2.78f, 1.5f), new Vector2(-2.97f, -2.28f), new Vector2(0.81f, -3.72f), new Vector2(3.54f, -0.6f) };

        if (radishsproutCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < radishsproutCount; i++)
            {
                for (int j = 0; (j < radishsproutAnswer.Length); j++)
                {
                    if (Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer[j]) < minDist)
                    {
                        minDist = Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("무순" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("무순위치체크후" + platingScore);
            minDist = 100f;
            if (radishsproutCount > 1)
            {
                for (int i = 0; (i < radishsproutCount); i++)
                {
                    for (int j = 0; (j < radishsproutAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
              Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("무순2위치체크후" + platingScore);
                minDist = 100f;
                if (radishsproutCount > 2)
                {
                    platingScore -= (radishsproutCount - 2) * (400);
                }

            }

        }

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
            Debug.Log("basil" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("basil위치체크후" + platingScore);
            minDist = 100f;
            if (basilCount > 1)
            {
                platingScore -= (basilCount - 1) * (700);
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
           Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
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
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
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
                   Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > standard1) platingScore -= 700;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("오이3위치체크후" + platingScore);
                    minDist = 100f;
                    if (cucumberCount > 3)
                    {
                        platingScore -= (cucumberCount - 3) * (200);
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
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;

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
           Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("cherrytomato1위치체크후" + platingScore);
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
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("cherrytomato2위치체크후" + platingScore);
                minDist = 100f;
                if (cherrytomatoCount > 2)
                {
                    for (int i = 0; i < cherrytomatoCount; i++)
                    {
                        for (int j = 0; j < cherrytomatoAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > standard1) platingScore -= 700;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("당근3위치체크후" + platingScore);
                    minDist = 100f;
                    if (cherrytomatoCount > 3)
                    {
                        platingScore -= (cherrytomatoCount - 3) * (200);
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
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
              Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
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
                   Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > standard1) platingScore -= 700;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("당근3위치체크후" + platingScore);
                    minDist = 100f;
                    if (carrotCount > 3)
                    {
                        platingScore -= (carrotCount - 3) * (200);
                    }

                }

            }

        }

        if (orangejuiceCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            int tempIndex5 = 0;
            int tempAnswerIndex5 = 0;
            for (int i = 0; i < orangejuiceCount; i++)
            {
                for (int j = 0; j < orangejuiceAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
           Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 10) platingScore -= 700;
            else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("오렌지착즙1위치체크후" + platingScore);
            minDist = 100f;
            if (orangejuiceCount > 1)
            {
                for (int i = 0; (i < orangejuiceCount); i++)
                {
                    for (int j = 0; (j < orangejuiceAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
              Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 10) platingScore -= 700;
                else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("오렌지착즙2위치체크후" + platingScore);
                minDist = 100f;
                if (orangejuiceCount > 2)
                {
                    for (int i = 0; i < orangejuiceCount; i++)
                    {
                        for (int j = 0; j < orangejuiceAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                   Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 10) platingScore -= 700;
                    else platingScore -= (int)(minDist / 5) * 100;
                    Debug.Log("오렌지착즙3위치체크후" + platingScore);
                    minDist = 100f;
                    if (orangejuiceCount > 3)
                    {
                        for (int i = 0; i < orangejuiceCount; i++)
                        {
                            for (int j = 0; j < orangejuiceAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                      Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 10) platingScore -= 700;
                        else platingScore -= (int)(minDist / 5) * 100;
                        Debug.Log("오렌지착즙4위치체크후" + platingScore);
                        minDist = 100f;

                        if (orangejuiceCount > 4)
                        {
                            for (int i = 0; i < orangejuiceCount; i++)
                            {
                                for (int j = 0; j < orangejuiceAnswer.Length; j++)
                                {

                                    if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3) && (i != tempIndex4) && (j != tempAnswerIndex4))
                                    {
                                        if (Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]) < minDist)
                                        {
                                            minDist = Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]);

                                            tempIndex5 = i;
                                            tempAnswerIndex5 = j;
                                        }
                                    }
                                }

                            }
                          Debug.Log(minDist);
                            Debug.Log(tempIndex5 + "  " + tempAnswerIndex5);
                            if (minDist > 10) platingScore -= 700;
                            else platingScore -= (int)(minDist / 5) * 100;
                            Debug.Log("오렌지착즙5위치체크후" + platingScore);
                            minDist = 100f;

                            if (orangejuiceCount > 5)
                            {
                                platingScore -= (orangejuiceCount - 5) * (100);
                            }

                        }

                    }

                }
            }
        }

        if (mayoCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            int tempIndex5 = 0;
            int tempAnswerIndex5 = 0;
            for (int i = 0; i < mayoCount; i++)
            {
                for (int j = 0; j < mayoAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempMayo[i].transform.position.x, tempMayo[i].transform.position.y), mayoAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempMayo[i].transform.position.x, tempMayo[i].transform.position.y), mayoAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
           Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 10) platingScore -= 700;
            else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("mayo1위치체크후" + platingScore);
            minDist = 100f;
            if (mayoCount > 1)
            {
                for (int i = 0; (i < mayoCount); i++)
                {
                    for (int j = 0; (j < mayoAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempMayo[i].transform.position.x, tempMayo[i].transform.position.y), mayoAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempMayo[i].transform.position.x, tempMayo[i].transform.position.y), mayoAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 10) platingScore -= 700;
                else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("mayo2위치체크후" + platingScore);
                minDist = 100f;
                if (mayoCount > 2)
                {
                    for (int i = 0; i < mayoCount; i++)
                    {
                        for (int j = 0; j < mayoAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempMayo[i].transform.position.x, tempMayo[i].transform.position.y), mayoAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempMayo[i].transform.position.x, tempMayo[i].transform.position.y), mayoAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 10) platingScore -= 700;
                    else platingScore -= (int)(minDist / 5) * 100;
                    Debug.Log("Mayo3위치체크후" + platingScore);
                    minDist = 100f;
                    if (mayoCount > 3)
                    {
                        for (int i = 0; i < mayoCount; i++)
                        {
                            for (int j = 0; j < mayoAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempMayo[i].transform.position.x, tempMayo[i].transform.position.y), mayoAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempMayo[i].transform.position.x, tempMayo[i].transform.position.y), mayoAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                      Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 10) platingScore -= 700;
                        else platingScore -= (int)(minDist / 5) * 100;
                        Debug.Log("Mayo4위치체크후" + platingScore);
                        minDist = 100f;

                        if (mayoCount > 4)
                        {
                            for (int i = 0; i < mayoCount; i++)
                            {
                                for (int j = 0; j < mayoAnswer.Length; j++)
                                {

                                    if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3) && (i != tempIndex4) && (j != tempAnswerIndex4))
                                    {
                                        if (Vector2.Distance(new Vector2(tempMayo[i].transform.position.x, tempMayo[i].transform.position.y), mayoAnswer[j]) < minDist)
                                        {
                                            minDist = Vector2.Distance(new Vector2(tempMayo[i].transform.position.x, tempMayo[i].transform.position.y), mayoAnswer[j]);

                                            tempIndex5 = i;
                                            tempAnswerIndex5 = j;
                                        }
                                    }
                                }

                            }
                           Debug.Log(minDist);
                            Debug.Log(tempIndex5 + "  " + tempAnswerIndex5);
                            if (minDist > 10) platingScore -= 700;
                            else platingScore -= (int)(minDist / 5) * 100;
                            Debug.Log("mayo5위치체크후" + platingScore);
                            minDist = 100f;

                            if (mayoCount > 5)
                            {
                                platingScore -= (mayoCount - 5) * (100);
                            }

                        }

                    }

                }
            }
        }

        if (ketchupCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            int tempIndex5 = 0;
            int tempAnswerIndex5 = 0;
            for (int i = 0; i < ketchupCount; i++)
            {
                for (int j = 0; j < ketchupAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 10) platingScore -= 700;
            else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("Ketchup1위치체크후" + platingScore);
            minDist = 100f;
            if (ketchupCount > 1)
            {
                for (int i = 0; (i < ketchupCount); i++)
                {
                    for (int j = 0; (j < ketchupAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 10) platingScore -= 700;
                else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("Ketchup2위치체크후" + platingScore);
                minDist = 100f;
                if (ketchupCount > 2)
                {
                    for (int i = 0; i < ketchupCount; i++)
                    {
                        for (int j = 0; j < ketchupAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 10) platingScore -= 700;
                    else platingScore -= (int)(minDist / 5) * 100;
                    Debug.Log("Ketchup3위치체크후" + platingScore);
                    minDist = 100f;
                    if (ketchupCount > 3)
                    {
                        for (int i = 0; i < ketchupCount; i++)
                        {
                            for (int j = 0; j < ketchupAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                       Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 10) platingScore -= 700;
                        else platingScore -= (int)(minDist / 5) * 100;
                        Debug.Log("Ketchup4위치체크후" + platingScore);
                        minDist = 100f;

                        if (ketchupCount > 4)
                        {
                            for (int i = 0; i < ketchupCount; i++)
                            {
                                for (int j = 0; j < ketchupAnswer.Length; j++)
                                {

                                    if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3) && (i != tempIndex4) && (j != tempAnswerIndex4))
                                    {
                                        if (Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer[j]) < minDist)
                                        {
                                            minDist = Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer[j]);

                                            tempIndex5 = i;
                                            tempAnswerIndex5 = j;
                                        }
                                    }
                                }

                            }
                          Debug.Log(minDist);
                            Debug.Log(tempIndex5 + "  " + tempAnswerIndex5);
                            if (minDist > 10) platingScore -= 700;
                            else platingScore -= (int)(minDist / 5) * 100;
                            Debug.Log("Ketchup위치체크후" + platingScore);
                            minDist = 100f;

                            if (ketchupCount > 5)
                            {
                                platingScore -= (ketchupCount - 5) * (100);
                            }

                        }

                    }

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
        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";

        tempSalad = null;
        tempBasil = null;
        tempRadishsprout = null;
        tempCucumber = null;
        tempCarrot = null;
        tempCherrytomato = null;
        tempKetchup = null;
        tempOrangejuice = null;
        tempMayo = null;
    }

    /*===================================================================== < platingSample18 > =======================================================================*/

    public void checkPlating18()
    {
        int platingScore = 7000;
        //float tempCarrotX = 0;
        GameObject tempSalad = null;
        GameObject[] tempPaprika = new GameObject[5];
        GameObject[] tempCarrot = new GameObject[5];
        GameObject[] tempCherrytomato = new GameObject[5];
        GameObject[] tempOrange = new GameObject[5];
        GameObject[] tempAvocado = new GameObject[5];
        GameObject[] tempBlueberry = new GameObject[5];
        GameObject[] tempApple = new GameObject[5];
        GameObject[] tempCherry = new GameObject[5];


        //9개->기준700원
        int saladCount = 0;
        int paprikaCount = 0;
        int avocadoCount = 0;
        int carrotCount = 0;
        int orangeCount = 0;
        int cherryCount = 0;
        int appleCount = 0;
        int blueberryCount = 0;
        int cherrytomatoCount = 0;

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedSalad(Clone)")
            {
                tempSalad = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                saladCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedAvocado_chop(Clone)")
            {
                tempAvocado[avocadoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                avocadoCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherry(Clone)")
            {
                tempCherry[cherryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedApple_chop(Clone)")
            {
                tempApple[appleCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                appleCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedOrange_chop(Clone)")
            {
                tempOrange[orangeCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                orangeCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCarrot_chop(Clone)")
            {
                tempCarrot[carrotCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                carrotCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedPaprika_chop(Clone)")
            {
                tempPaprika[paprikaCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                paprikaCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherrytomato(Clone)")
            {
                tempCherrytomato[cherrytomatoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherrytomatoCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBlueberry(Clone)")
            {
                tempBlueberry[blueberryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberryCount++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크
        for (int i = 0; i < cherryCount; i++)
        {
            if (tempSalad != null)
            {
                if (tempCherry[i].transform.position.z > tempSalad.transform.position.z) platingScore -= 100;
            }
        }
        for (int i = 0; i < carrotCount; i++)
        {
            if (tempSalad != null)
            {
                if (tempCarrot[i].transform.position.z > tempSalad.transform.position.z) platingScore -= 100;
            }
        }
        for (int i = 0; i < appleCount; i++)
        {
            if (tempSalad != null)
            {
                if (tempApple[i].transform.position.z > tempSalad.transform.position.z) platingScore -= 100;
            }
        }
        for (int i = 0; i < paprikaCount; i++)
        {
            if (tempSalad != null)
            {
                if (tempPaprika[i].transform.position.z > tempSalad.transform.position.z) platingScore -= 100;
            }
        }
        // 있어야할 재료가 모자르면 -(700÷해당 재료 전체갯수)*모자른 갯수
        if (saladCount == 0) platingScore -= 700;
        if (appleCount == 0) platingScore -= 700;
        if (orangeCount == 0) platingScore -= 700;
        if (avocadoCount == 0) platingScore -= 700;
        if (cherryCount == 0) platingScore -= 700;

        if (carrotCount == 0)
            platingScore -= 700;
        else if (carrotCount == 1)
            platingScore -= 300;

        if (paprikaCount == 0)
            platingScore -= 700;
        else if (paprikaCount == 1)
            platingScore -= 300;

        if (cherrytomatoCount == 0)
            platingScore -= 700;
        else if (cherrytomatoCount > 0 && cherrytomatoCount < 4)
            platingScore -= (100) * (4 - cherrytomatoCount);

        if (blueberryCount == 0)
            platingScore -= 700;
        else if (blueberryCount > 0 && blueberryCount < 4)
            platingScore -= (100) * (4 - blueberryCount);


        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;

        Vector2 orangeAnswer = new Vector2(0.17f, -3.79f);
        Vector2 cherryAnswer = new Vector2(-0.02f, -0.02f);
        Vector2 appleAnswer = new Vector2(-1.34f, 0.68f);
        Vector2 avocadoAnswer = new Vector2(2.75f, -1.88f);

        Vector2 carrot1Answer = new Vector2(-1.69f, -0.84f);
        Vector2 carrot2Answer = new Vector2(1.58f, -0.64f);
        Vector2[] carrotAnswer = { carrot1Answer, carrot2Answer };

        Vector2 paprika1Answer = new Vector2(0.95f, 1.15f);
        Vector2 paprika2Answer = new Vector2(-0.18f, -2.12f);
        Vector2[] paprikaAnswer = { paprika1Answer, paprika2Answer };

        Vector2 cherrytomato1Answer = new Vector2(-2.67f, 1.74f);
        Vector2 cherrytomato2Answer = new Vector2(-3.37f, -1.84f);
        Vector2 cherrytomato3Answer = new Vector2(0.64f, 2.83f);
        Vector2 cherrytomato4Answer = new Vector2(3.25f, 0.88f);
        Vector2[] cherrytomatoAnswer = { cherrytomato1Answer, cherrytomato2Answer, cherrytomato3Answer, cherrytomato4Answer };

        Vector2[] blueberryAnswer = { new Vector2(2.12f, 2.17f), new Vector2(-1.35f, 2.6f), new Vector2(-3.53f, 0.1f), new Vector2(-2.02f, -3.08f) };


        if (orangeCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < orangeCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempOrange[i].transform.position.x, tempOrange[i].transform.position.y), orangeAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempOrange[i].transform.position.x, tempOrange[i].transform.position.y), orangeAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("orange" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("orange위치체크후" + platingScore);
            minDist = 100f;
            if (orangeCount > 1)
            {
                platingScore -= (orangeCount - 1) * (700);
            }

        }

        if (appleCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < appleCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempApple[i].transform.position.x, tempApple[i].transform.position.y), appleAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempApple[i].transform.position.x, tempApple[i].transform.position.y), appleAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("apple" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("apple위치체크후" + platingScore);
            minDist = 100f;
            if (appleCount > 1)
            {
                platingScore -= (appleCount - 1) * (700);
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
            Debug.Log("Cherry" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("Cherry위치체크후" + platingScore);
            minDist = 100f;
            if (cherryCount > 1)
            {
                platingScore -= (cherryCount - 1) * (700);
            }
        }

        if (avocadoCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < avocadoCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempAvocado[i].transform.position.x, tempAvocado[i].transform.position.y), avocadoAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempAvocado[i].transform.position.x, tempAvocado[i].transform.position.y), avocadoAnswer);
                    tempIndex1 = i;
                }
            }
            Debug.Log("avocado" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("avocado위치체크후" + platingScore);
            minDist = 100f;
            if (avocadoCount > 1)
            {
                platingScore -= (avocadoCount - 1) * (700);
            }
        }


        if (cherrytomatoCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
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
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("방토2위치체크후" + platingScore);
                minDist = 100f;
                if (cherrytomatoCount > 2)
                {
                    for (int i = 0; i < cherrytomatoCount; i++)
                    {
                        for (int j = 0; j < cherrytomatoAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                   
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > standard1) platingScore -= 700;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("방토3위치체크후" + platingScore);
                    minDist = 100f;
                    if (cherrytomatoCount > 3)
                    {
                        for (int i = 0; i < cherrytomatoCount; i++)
                        {
                            for (int j = 0; j < cherrytomatoAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                       
                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > standard1) platingScore -= 700;
                        else platingScore -= (int)(minDist / standard2) * 100;
                        Debug.Log("방토4위치체크후" + platingScore);
                        minDist = 100f;
                        if (cherrytomatoCount > 4)
                        {
                            platingScore -= (cherrytomatoCount - 4) * (100);
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
           
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
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
              
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("당근2위치체크후" + platingScore);
                minDist = 100f;

                if (carrotCount > 2)
                {
                    platingScore -= (carrotCount - 2) * (300);
                }

            }



        }

        if (paprikaCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < paprikaCount; i++)
            {
                for (int j = 0; j < paprikaAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempPaprika[i].transform.position.x, tempPaprika[i].transform.position.y), paprikaAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempPaprika[i].transform.position.x, tempPaprika[i].transform.position.y), paprikaAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
           Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("paprika1위치체크후" + platingScore);
            minDist = 100f;
            if (paprikaCount > 1)
            {
                for (int i = 0; (i < paprikaCount); i++)
                {
                    for (int j = 0; (j < paprikaAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempPaprika[i].transform.position.x, tempPaprika[i].transform.position.y), paprikaAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempPaprika[i].transform.position.x, tempPaprika[i].transform.position.y), paprikaAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("paprika2위치체크후" + platingScore);
                minDist = 100f;

                if (paprikaCount > 2)
                {
                    platingScore -= (paprikaCount - 2) * (300);
                }
            }
        }

        if (blueberryCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("blueberry1위치체크후" + platingScore);
            minDist = 100f;
            if (blueberryCount > 1)
            {
                for (int i = 0; (i < blueberryCount); i++)
                {
                    for (int j = 0; (j < blueberryAnswer.Length); j++)
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
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("blueberry2위치체크후" + platingScore);
                minDist = 100f;
                if (blueberryCount > 2)
                {
                    for (int i = 0; i < blueberryCount; i++)
                    {
                        for (int j = 0; j < blueberryAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempBlueberry[i].transform.position.x, tempBlueberry[i].transform.position.y), blueberryAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempBlueberry[i].transform.position.x, tempBlueberry[i].transform.position.y), blueberryAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > standard1) platingScore -= 700;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("blueberry3위치체크후" + platingScore);
                    minDist = 100f;
                    if (blueberryCount > 3)
                    {
                        for (int i = 0; i < blueberryCount; i++)
                        {
                            for (int j = 0; j < blueberryAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempBlueberry[i].transform.position.x, tempBlueberry[i].transform.position.y), blueberryAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempBlueberry[i].transform.position.x, tempBlueberry[i].transform.position.y), blueberryAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > standard1) platingScore -= 700;
                        else platingScore -= (int)(minDist / standard2) * 100;
                        Debug.Log("blueberry4위치체크후" + platingScore);
                        minDist = 100f;
                        if (blueberryCount > 4)
                        {
                            platingScore -= (blueberryCount - 4) * (100);
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
        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore + "원";


        tempSalad = null;
        tempAvocado = null;
        tempOrange = null;
        tempPaprika = null;
        tempCarrot = null;
        tempBlueberry = null;
        tempCherrytomato = null;
        tempApple = null;
        tempCherry = null;


    }
    /*====================================================+================== < Stage 4 > ==========================================================++++=============*/
    /*===================================================================== < platingSample19 > =======================================================================*/

    public void checkPlating19() {

        int platingScore = 7000;
  
        GameObject tempCake = null;
        GameObject[] tempStrawberry = new GameObject[5];
        GameObject[] tempOrange = new GameObject[5];
        GameObject[] tempBlueberry = new GameObject[5];
        GameObject[] tempIcecream = new GameObject[5];
        GameObject[] tempBlueberryJuice = new GameObject[5];
        GameObject[] tempOrangeJuice = new GameObject[5];
        GameObject[] tempCream = new GameObject[5];

        //기준 800원
        int cakeCount = 0;
        int strawberryCount = 0;
        int orangeCount = 0;
        int blueberryCount = 0;
        int icecreamCount= 0;
        int orangeJuiceCount = 0;
        int blueberryJuiceCount = 0;
        int creamCount = 0;
  
       

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCake(Clone)")
            {              
                tempCake = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cakeCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedStrawberry_chop(Clone)")
            {
                tempStrawberry[strawberryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                strawberryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedOrange_chop(Clone)")
            {
                tempOrange[orangeCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                orangeCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBlueberry(Clone)")
            {
          
                tempBlueberry[blueberryCount]= stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedIcecream(Clone)")
            {

                tempIcecream[icecreamCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                icecreamCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "blueberryLineDrawer(Clone)")
            {
                tempBlueberryJuice[blueberryJuiceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberryJuiceCount++;

            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "orangeLineDrawer(Clone)")
            {
                tempOrangeJuice[orangeJuiceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                orangeJuiceCount++;

            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "creamLineDrawer(Clone)")
            {
                tempCream[creamCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                creamCount++;

            }
            else {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크
     
        if ((tempOrange[0] != null) && (tempCake != null) && (tempBlueberryJuice[0] != null))
        {
            for (int i = 0; i < orangeCount; i++)
            {
                if (tempOrange[i].transform.position.z > tempCake.transform.position.z) platingScore -= 100;

                for (int j = 0; j < blueberryJuiceCount; j++)
                {
                    if (tempOrange[i].transform.position.z > tempBlueberryJuice[j].transform.position.z) platingScore -= 100;
                }
                for (int j = 0; j < creamCount; j++)
                {
                    if (tempOrange[i].transform.position.z > tempCream[j].transform.position.z) platingScore -= 100;
                }
            }
        }
        if ((tempCream[0] != null) && (tempCake != null) && (tempBlueberryJuice[0] != null))
        {
            for (int i = 0; i < creamCount; i++)
            {
                if (tempCream[i].transform.position.z > tempCake.transform.position.z) platingScore -= 100;
              
                for (int j = 0; j < blueberryJuiceCount; j++)
                { 
                    if (tempCream[i].transform.position.z >tempBlueberryJuice[j].transform.position.z) platingScore -= 100;
                }
            }
        }
        if ((tempCake != null) && (tempBlueberryJuice[0] != null))
        { 
            for (int j = 0; j < blueberryJuiceCount; j++)
            { //케익이더 밑에 있으면
                if (tempCake.transform.position.z > tempBlueberryJuice[j].transform.position.z) platingScore -= 100;
            }
        }
        // 있어야할 재료가 모자르면 -(800÷해당 재료 전체갯수)*모자른 갯수
        if (cakeCount==0) platingScore -= 800;
        if (orangeCount == 0) platingScore -= 800;
        if (icecreamCount == 0) platingScore -= 800;
        if (blueberryJuiceCount == 0) platingScore -= 800;
        if (creamCount == 0) platingScore -= 800;

        if (strawberryCount == 0)
            platingScore -= 800;
        else if (strawberryCount == 1)
            platingScore -= 400;

        if (blueberryCount == 0)
            platingScore -= 800;
        else if (blueberryCount == 1)
            platingScore -= 400;

        if (orangeJuiceCount == 0)
            platingScore -= 800;
        else if (orangeJuiceCount > 0 && orangeJuiceCount < 4)
            platingScore -= (100) * (4 - orangeJuiceCount);

   
        

        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;

        Vector2 orangeAnswer = new Vector2(0.46f, 0.75f);
        Vector2 icecreamAnswer = new Vector2(3.12f, -0.85f);
        Vector2 creamAnswer = new Vector2(0.48f,0.81f);
        Vector2 blueberryJuiceAnswer = new Vector2(0.02f,-0.51f);

        Vector2 strawberry1Answer = new Vector2(2.74f,-2.11f); //첫번째 당근 정답
        Vector2 strawberry2Answer = new Vector2(1.8f, -2.97f);
        Vector2[] strawberryAnswer = { strawberry1Answer, strawberry2Answer };

     
        Vector2 blueberry1Answer = new Vector2(0.78f, -2.43f);
        Vector2 blueberry2Answer = new Vector2(0.48f, -2.43f);
        Vector2[] blueberryAnswer = { blueberry1Answer, blueberry2Answer };

        //오렌지 주스 라인 ->가장 긴건 체크x
        Vector2 orangeJuice1Answer = new Vector2(-3.04f,-1.53f);
        Vector2 orangeJuice2Answer = new Vector2(-2.54f, -2.47f);
        Vector2 orangeJuice3Answer = new Vector2(-2f, -3.07f);
        Vector2[] orangeJuiceAnswer = { orangeJuice1Answer, orangeJuice2Answer, orangeJuice3Answer};


        if (orangeCount > 0) {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < orangeCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempOrange[i].transform.position.x, tempOrange[i].transform.position.y), orangeAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempOrange[i].transform.position.x, tempOrange[i].transform.position.y), orangeAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("오렌지"+minDist);
            if (minDist > standard1) platingScore -= 800;
            else platingScore -= (int)(minDist /standard2) * 100;
            Debug.Log("오렌지위치체크후" + platingScore);
            minDist = 100f;
            if (orangeCount > 1)
            {
                platingScore -= (orangeCount - 1) *(800);
            }

        }

        if (icecreamCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < icecreamCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempIcecream[i].transform.position.x, tempIcecream[i].transform.position.y), icecreamAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempIcecream[i].transform.position.x, tempIcecream[i].transform.position.y), icecreamAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("icecream" + minDist);
            if (minDist > standard1) platingScore -= 800;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("icecream위치체크후" + platingScore);
            minDist = 100f;
            if (icecreamCount > 1)
            {
                platingScore -= (icecreamCount - 1) * (800);
            }

        }

        if (blueberryJuiceCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < blueberryJuiceCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempBlueberryJuice[i].transform.position.x, tempBlueberryJuice[i].transform.position.y), blueberryJuiceAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempBlueberryJuice[i].transform.position.x, tempBlueberryJuice[i].transform.position.y), blueberryJuiceAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("blueberryJuice" + minDist);
            if (minDist > 5.0f) platingScore -= 800;
           // else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("blueberryJuice위치체크후" + platingScore);
            minDist = 100f;
            if (blueberryJuiceCount > 1)
            {
                platingScore -= (blueberryJuiceCount - 1) * (800);
            }

        }

        if (creamCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < creamCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("cream" + minDist);
            if (minDist > 2f) platingScore -= 800; //2이상 차이나면 점수 X
           // else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("cream위치체크후" + platingScore);
            minDist = 100f;
            if (creamCount > 1)
            {
                platingScore -= (creamCount - 1) * (800);
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
            Debug.Log("blueberry" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 800;
            else platingScore -= (int)(minDist / standard2) *100;
            Debug.Log("blueberry1위치체크후" + platingScore);
            minDist = 100f;

            if (blueberryCount > 1)
            {
                for (int i = 0; (i < blueberryCount); i++)
                {
                    for (int j = 0; (j < blueberryAnswer.Length); j++)
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
                Debug.Log("blueberry" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 800;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("blueberry2위치체크후" + platingScore);
                minDist = 100f;
                if (blueberryCount > 2)
                {
                    platingScore -= (blueberryCount - 2) * (400);
                }
            }
        }

        if (strawberryCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < strawberryCount; i++)
            {
                for (int j = 0; j < strawberryAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("strawberry" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 800;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("strawberry1위치체크후" + platingScore);
            minDist = 100f;

            if (strawberryCount > 1)
            {
                for (int i = 0; (i < strawberryCount); i++)
                {
                    for (int j = 0; (j < strawberryAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("strawberry" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 800;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("strawberry2위치체크후" + platingScore);
                minDist = 100f;
                if (strawberryCount > 2)
                {
                    platingScore -= (strawberryCount - 2) * (400);
                }
            }
        }

        if (orangeJuiceCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
          
            for (int i = 0; i < orangeJuiceCount; i++)
            {
                for (int j = 0; j < orangeJuiceAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempOrangeJuice[i].transform.position.x, tempOrangeJuice[i].transform.position.y), orangeJuiceAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempOrangeJuice[i].transform.position.x, tempOrangeJuice[i].transform.position.y), orangeJuiceAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist >=2f) platingScore -= 800; //2차이나면 점수X, 1차이나면 조금 깎임
            else platingScore -= (int)(minDist / 1) *400;
            Debug.Log("OrangeJuice1위치체크후" + platingScore);
            minDist = 100f;
            if (orangeJuiceCount > 1)
            {
                for (int i = 0; (i < orangeJuiceCount); i++)
                {
                    for (int j = 0; (j < orangeJuiceAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempOrangeJuice[i].transform.position.x, tempOrangeJuice[i].transform.position.y), orangeJuiceAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempOrangeJuice[i].transform.position.x, tempOrangeJuice[i].transform.position.y), orangeJuiceAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist >=2f) platingScore -= 800;
                else platingScore -= (int)(minDist /1) * 400;
                Debug.Log("OrangeJuice2위치체크후" + platingScore);
                minDist = 100f;
                if (orangeJuiceCount > 2)
                {
                    for (int i = 0; i < orangeJuiceCount; i++)
                    {
                        for (int j = 0; j < orangeJuiceAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempOrangeJuice[i].transform.position.x, tempOrangeJuice[i].transform.position.y), orangeJuiceAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempOrangeJuice[i].transform.position.x, tempOrangeJuice[i].transform.position.y), orangeJuiceAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist >= 2f) platingScore -= 800;
                    else platingScore -= (int)(minDist /1) *400;
                    Debug.Log("OrangeJuice3위치체크후" + platingScore);
                    minDist = 100f;               
                    if (orangeJuiceCount >4)
                     {
                       platingScore -= (orangeJuiceCount -4) * (200);
                     }                  
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
       //Debug.Log("누들x:" + tempNoodle.transform.position.x + "누들y:" + tempNoodle.transform.position.y);
        //Debug.Log("육수x:" + tempBroth.transform.position.x + "육수y:" + tempBroth.transform.position.y);
      //Debug.Log("당근1x:" + tempCarrot[0].transform.position.x + "당근1y:" + tempCarrot[0].transform.position.y);
        //Debug.Log("당근2x:" + tempCarrot[1].transform.position.x + "당근2y:" + tempCarrot[1].transform.position.y);
        //Debug.Log("당근3x:" + tempCarrot[2].transform.position.x + "당근3y:" + tempCarrot[2].transform.position.y);
        //Debug.Log("딸기1x:" + tempStrawberry[0].transform.position.x + "딸기1y:" + tempStrawberry[0].transform.position.y);

        int tempSubmitCount = submitCount + 1;
        platingResult[submitCount] = tempSubmitCount + "번 요리 : " + platingScore+"원";

        tempCake = null;
        tempStrawberry = null;
        tempOrange = null;
        tempOrangeJuice = null;
       tempBlueberry = null;
        tempBlueberryJuice = null;
        tempIcecream = null;
        tempCream = null;

    }

    /*===================================================================== < platingSample20 > =======================================================================*/

    public void checkPlating20()
    {

        int platingScore = 7000;
     
        GameObject tempCake= null;
        GameObject[] tempCheese = new GameObject[5];
        GameObject[] tempStrawberry = new GameObject[5];
        GameObject[] tempCherry = new GameObject[5];
        GameObject[] tempCream = new GameObject[5];
        GameObject[] tempChocosyrup = new GameObject[5];
        GameObject[] tempCaramelsyrup = new GameObject[5];
        GameObject[] tempBlueberryjuice = new GameObject[5];
        GameObject[] tempStrawberryjuice= new GameObject[5];

       //기준700원
        int cakeCount = 0;
        int cheeseCount = 0;
        int strawberryCount = 0;
        int cherryCount = 0;
        int creamCount = 0;
        int chocosyrupCount = 0;
        int caramelsyrupCount = 0;
        int blueberryjuiceCount = 0;
        int strawberryjuiceCount = 0;

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCake(Clone)")
            {
                tempCake = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cakeCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCheese(Clone)")
            {
                tempCheese[cheeseCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cheeseCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedStrawberry(Clone)")
            {
                tempStrawberry[strawberryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                strawberryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherry(Clone)")
            {
                tempCherry[cherryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "creamLineDrawer(Clone)")
            {
                tempCream[creamCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                creamCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "chocoLineDrawer(Clone)")
            {
                tempChocosyrup[chocosyrupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                chocosyrupCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "caramelLineDrawer(Clone)")
            {
                tempCaramelsyrup[caramelsyrupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                caramelsyrupCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "blueberryLineDrawer(Clone)")
            {
                tempBlueberryjuice[blueberryjuiceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberryjuiceCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "strawberryLineDrawer(Clone)")
            {
                tempStrawberryjuice[strawberryjuiceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                strawberryjuiceCount++;
            }
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크

        if ((tempStrawberry[0] != null) && (tempCake != null) && (tempCheese[0] != null)&& (tempBlueberryjuice[0] != null))
        {
            for (int i = 0; i < strawberryCount; i++)
            {
                if (tempStrawberry[i].transform.position.z > tempCake.transform.position.z) platingScore -= 100;

                for (int j = 0; j < blueberryjuiceCount; j++)
                {
                    if (tempStrawberry[i].transform.position.z > tempBlueberryjuice[j].transform.position.z) platingScore -= 100;
                }
                for (int j = 0; j < cheeseCount; j++)
                {
                    if (tempStrawberry[i].transform.position.z > tempCheese[j].transform.position.z) platingScore -= 100;
                }
            }
        }
        if ((tempBlueberryjuice[0] != null) && (tempCake != null) && (tempCheese[0] != null))
        {
            for (int i = 0; i < blueberryjuiceCount; i++)
            {
                if (tempBlueberryjuice[i].transform.position.z > tempCake.transform.position.z) platingScore -= 100;

                for (int j = 0; j < cheeseCount; j++)
                {
                    if (tempBlueberryjuice[i].transform.position.z > tempCheese[j].transform.position.z) platingScore -= 100;
                }
            }
        }
        if ((tempCake != null) && (tempCheese[0] != null))
        {
            for (int j = 0; j <cheeseCount; j++)
            { //케익이더 밑에 있으면
                if (tempCake.transform.position.z > tempCheese[j].transform.position.z) platingScore -= 100;
            }
        }

        if ((tempCherry[0]!= null) && (tempCream[0] != null))
        {
            for (int i = 0; i < cherryCount; i++)
            {
                for (int j = 0; j < creamCount; j++)
                {
                    if (tempCherry[i].transform.position.z > tempCream[j].transform.position.z) platingScore -= 100;
                }
            }
        }

        // 있어야할 재료가 모자르면 -(700÷해당 재료 전체갯수)*모자른 갯수
        if (cakeCount == 0) platingScore -= 700;
        if (cheeseCount == 0) platingScore -= 700;
        if (strawberryCount == 0) platingScore -= 700;
        if (blueberryjuiceCount == 0) platingScore -= 700;

        if (creamCount == 0)
            platingScore -= 700;
        else if (creamCount==1)
            platingScore -= 300;

        if (chocosyrupCount == 0)
            platingScore -= 700;
        else if (chocosyrupCount > 0 && chocosyrupCount < 3)
            platingScore -= (200) * (3 - chocosyrupCount);

        if (cherryCount == 0)
            platingScore -= 700;
        else if (cherryCount == 1)
            platingScore -= 300;

        if (caramelsyrupCount == 0)
            platingScore -= 700;
        else if (caramelsyrupCount == 1)
            platingScore -= 300;

        if (strawberryjuiceCount == 0)
            platingScore -= 700;
        else if (strawberryjuiceCount == 1)
            platingScore -= 300;


        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;

        //초코시럽, 케이크 위치 체크X

        Vector2 cheeseAnswer = new Vector2(0.12f,-0.64f);
        Vector2 strawberryAnswer = new Vector2(0.38f, 1.03f);
        Vector2 blueberryjuiceAnswer = new Vector2(0.27f, 0.88f);

        Vector2 cream1Answer = new Vector2(0.27f, 0.88f); //케이크 위 크림
        Vector2 cream2Answer = new Vector2(-1.38f, 2.14f); //상단 크림
        Vector2[] creamAnswer = { cream1Answer, cream2Answer };
        
        Vector2 caramelsyrup1Answer = new Vector2(-1.21f,-3.51f);
        Vector2 caramelsyrup2Answer = new Vector2(3.36f, -0.5f);  
        Vector2[] caramelsyrupAnswer = { caramelsyrup1Answer, caramelsyrup2Answer };

        Vector2 strawberryjuice1Answer = new Vector2(-1.27f, 2.56f);
        Vector2 strawberryjuice2Answer = new Vector2(-0.54f, -2.38f);
        Vector2[] strawberryjuiceAnswer = { strawberryjuice1Answer, strawberryjuice2Answer };

        Vector2 cherry1Answer = new Vector2(-2.39f, 2.03f);
        Vector2 cherry2Answer = new Vector2(-0.98f, 2.79f);
        Vector2[] cherryAnswer = { cherry1Answer, cherry2Answer };


        if (cheeseCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < cheeseCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("Cheese" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("Cheese위치체크후" + platingScore);
            minDist = 100f;
            if (cheeseCount > 1)
            {
                platingScore -= (cheeseCount - 1) * (700);
            }

        }

        if (strawberryCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < strawberryCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("strawberry" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("strawberry위치체크후" + platingScore);
            minDist = 100f;
            if (strawberryCount > 1)
            {
                platingScore -= (strawberryCount - 1) * (700);
            }

        }

        if (blueberryjuiceCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < blueberryjuiceCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("blueberryjuice" + minDist);
            if (minDist >5f) platingScore -= 700; //5이상 차이나면 점수X
          //  else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("blueberryjuice위치체크후" + platingScore);
            minDist = 100f;
            if (blueberryjuiceCount > 1)
            {
                platingScore -= (blueberryjuiceCount - 1) * (700);
            }

        }

        if (cherryCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < cherryCount; i++)
            {
                for (int j = 0; j < cherryAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("cherry" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("cherry1위치체크후" + platingScore);
            minDist = 100f;

            if (cherryCount > 1)
            {
                for (int i = 0; (i < cherryCount); i++)
                {
                    for (int j = 0; (j < cherryAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("cherry" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("cherry2위치체크후" + platingScore);
                minDist = 100f;
                if (cherryCount > 2)
                {
                    platingScore -= (cherryCount - 2) * (300);
                }
            }
        }

        if (strawberryjuiceCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < strawberryjuiceCount; i++)
            {
                for (int j = 0; j < strawberryjuiceAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempStrawberryjuice[i].transform.position.x, tempStrawberryjuice[i].transform.position.y), strawberryjuiceAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempStrawberryjuice[i].transform.position.x, tempStrawberryjuice[i].transform.position.y), strawberryjuiceAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("strawberryjuice" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 3f) platingScore -= 700;
           // else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("strawberryjuice1위치체크후" + platingScore);
            minDist = 100f;

            if (strawberryjuiceCount > 1)
            {
                for (int i = 0; (i < strawberryjuiceCount); i++)
                {
                    for (int j = 0; (j < strawberryjuiceAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempStrawberryjuice[i].transform.position.x, tempStrawberryjuice[i].transform.position.y), strawberryjuiceAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempStrawberryjuice[i].transform.position.x, tempStrawberryjuice[i].transform.position.y), strawberryjuiceAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("strawberryjuice" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 3f) platingScore -= 700;
              // else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("strawberryjuice2위치체크후" + platingScore);
                minDist = 100f;
                if (strawberryjuiceCount > 2)
                {
                    platingScore -= (strawberryjuiceCount - 2) * (300);
                }
            }
        }

        if (caramelsyrupCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < caramelsyrupCount; i++)
            {
                for (int j = 0; j < caramelsyrupAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("caramelsyrup" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 2f) platingScore -= 700;
            // else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("caramelsyrup1위치체크후" + platingScore);
            minDist = 100f;

            if (caramelsyrupCount > 1)
            {
                for (int i = 0; (i < caramelsyrupCount); i++)
                {
                    for (int j = 0; (j < caramelsyrupAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("caramelsyrup" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 2f) platingScore -= 700;
                // else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("caramelsyrup2위치체크후" + platingScore);
                minDist = 100f;
                if (caramelsyrupCount > 2)
                {
                    platingScore -= (caramelsyrupCount - 2) * (300);
                }
            }
        }

        if (creamCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < creamCount; i++)
            {
                for (int j = 0; j < creamAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("Cream" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (tempAnswerIndex1 == 0)
            {
                if (minDist > 2) platingScore -= 700;
                Debug.Log("Cream1위치체크후" + platingScore);
            }
            else if (tempAnswerIndex1 == 1)
            {
                if (minDist > 3) platingScore -= 700;
                Debug.Log("Cream1위치체크후" + platingScore);
            }
            minDist = 100f;

            if (creamCount > 1)
            {
                for (int i = 0; (i < creamCount); i++)
                {
                    for (int j = 0; (j < creamAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("Cream" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (tempAnswerIndex2 == 0)
                {
                    if (minDist > 2) platingScore -= 700;
                    Debug.Log("Cream2위치체크후" + platingScore);
                }
                else if (tempAnswerIndex2 == 1)
                {
                    if (minDist > 3) platingScore -= 700;
                    Debug.Log("Cream2위치체크후" + platingScore);
                }
                minDist = 100f;
                if (creamCount > 2)
                {
                    platingScore -= (creamCount - 2) * (300);
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

        tempCake = null;
        tempCheese = null;
        tempStrawberry = null;
        tempCherry = null;
        tempCream = null;
        tempStrawberryjuice = null;
        tempChocosyrup = null;
        tempCaramelsyrup = null;
        tempBlueberryjuice = null;

    }

    /*===================================================================== < platingSample21 > =======================================================================*/
    public void checkPlating21()
    {

        int platingScore = 7000;

        GameObject tempIvy = null;
        GameObject[] tempCheese = new GameObject[5];
        GameObject[] tempBasil = new GameObject[5];
        GameObject[] tempBlueberry = new GameObject[5];
        GameObject[] tempCherry = new GameObject[5];
        GameObject[] tempCream = new GameObject[5];
        GameObject[] tempBlueberryjuice = new GameObject[5];
        GameObject[] tempStrawberryjuice = new GameObject[5];
        GameObject[] tempOrangejuice = new GameObject[5];
        GameObject[] tempKetchup = new GameObject[5];

        //기준:700원
        int IvyCount = 0;
        int cheeseCount = 0;
        int basilCount = 0;
        int blueberryCount = 0;      
        int cherryCount = 0;
        int creamCount = 0;
        int blueberryjuiceCount = 0;
        int orangejuiceCount = 0;
        int strawberryjuiceCount = 0;
        int ketchupCount = 0;

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedIvy(Clone)")
            {
                tempIvy = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                IvyCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCheddarcheese_s(Clone)")
            {
                tempCheese[cheeseCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cheeseCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBasil(Clone)")
            {
                tempBasil[basilCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                basilCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBlueberry(Clone)")
            {

                tempBlueberry[blueberryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherry(Clone)")
            {
                tempCherry[cherryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "creamLineDrawer(Clone)")
            {
                tempCream[creamCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                creamCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "blueberryLineDrawer(Clone)")
            {
                tempBlueberryjuice[blueberryjuiceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberryjuiceCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "orangeLineDrawer(Clone)")
            {
                tempOrangejuice[orangejuiceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                orangejuiceCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "strawberryLineDrawer(Clone)")
            {
                tempStrawberryjuice[strawberryjuiceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                strawberryjuiceCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "ketchupLineDrawer(Clone)")
            {
                tempKetchup[ketchupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                ketchupCount++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크

        if ((tempBlueberry[0] != null) && (tempCheese[0] != null) && (tempIvy != null) && (tempCream[0] != null))
        {
            for (int i = 0; i < blueberryCount; i++)
            {
                if (tempBlueberry[i].transform.position.z > tempIvy.transform.position.z) platingScore -= 100;

                for (int j = 0; j < creamCount; j++)
                {
                    if (tempBlueberry[i].transform.position.z > tempCream[j].transform.position.z) platingScore -= 100;
                }
                for (int j = 0; j < cheeseCount; j++)
                {
                    if (tempBlueberry[i].transform.position.z > tempCheese[j].transform.position.z) platingScore -= 100;
                }
            }
        }
        if ((tempCherry[0] != null) && (tempCheese[0] != null) && (tempIvy != null) && (tempCream[0] != null))
        {
            for (int i = 0; i < cherryCount; i++)
            {
                if (tempCherry[i].transform.position.z > tempIvy.transform.position.z) platingScore -= 100;

                for (int j = 0; j < creamCount; j++)
                {
                    if (tempCherry[i].transform.position.z > tempCream[j].transform.position.z) platingScore -= 100;
                }
                for (int j = 0; j < cheeseCount; j++)
                {
                    if (tempCherry[i].transform.position.z > tempCheese[j].transform.position.z) platingScore -= 100;
                }
            }
        }
        if ((tempCream[0] != null)&&(tempCheese[0] != null) && (tempIvy != null))
        {
            for (int i = 0; i < creamCount; i++)
            {
                if (tempCream[i].transform.position.z > tempIvy.transform.position.z) platingScore -= 100;

                for (int j = 0; j < cheeseCount; j++)
                {
                    if (tempCream[i].transform.position.z > tempCheese[j].transform.position.z) platingScore -= 100;
                }
               
            }
        }
        if ((tempCheese[0] != null) && (tempIvy != null))
        {
            for (int i = 0; i < cheeseCount; i++)
            {
                if (tempCheese[i].transform.position.z > tempIvy.transform.position.z) platingScore -= 100;
            }
        }

        // 있어야할 재료가 모자르면 -(700÷해당 재료 전체갯수)*모자른 갯수
        if (IvyCount == 0) platingScore -= 700;
        if (basilCount == 0) platingScore -= 700;
        if (ketchupCount == 0) platingScore -= 700;
        if (orangejuiceCount == 0) platingScore -= 700;

        if (blueberryCount == 0)
            platingScore -= 700;
        else if (blueberryCount>0 && blueberryCount<3)
            platingScore -= 200*(3-blueberryCount);

        if (cherryCount == 0)
            platingScore -= 700;
        else if (cherryCount == 1)
            platingScore -= 300;

        if (strawberryjuiceCount == 0)
            platingScore -= 700;
        else if (strawberryjuiceCount == 1)
            platingScore -= (300);

        if (blueberryjuiceCount == 0)
            platingScore -= 700;
        else if (blueberryjuiceCount > 0 && blueberryjuiceCount < 3)
            platingScore -= (200) * (3 - blueberryjuiceCount);

        if (creamCount == 0)
            platingScore -= 700;
        else if (creamCount > 0 && creamCount <5)
            platingScore -= (100) * (5 - creamCount);

        if (cheeseCount == 0)
            platingScore -= 700;
        else if (cheeseCount > 0 && cheeseCount < 5)
            platingScore -= (100) * (5 - cheeseCount);


        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;


        Vector2 basilAnswer = new Vector2(-0.01f, -0.19f);
        Vector2 ketchupAnswer = new Vector2(0.02f, 2.82f);
        Vector2 orangejuiceAnswer = new Vector2(-0.03f, 3f);

        Vector2 cherry1Answer = new Vector2(-1.78f, 0.28f);
        Vector2 cherry2Answer = new Vector2(1.69f, 0.28f);
        Vector2[]cherryAnswer = { cherry1Answer, cherry2Answer };

        Vector2 blueberry1Answer = new Vector2(-0.04f, 1.64f);
        Vector2 blueberry2Answer = new Vector2(-1.29f, -1.89f);
        Vector2 blueberry3Answer = new Vector2(1.27f, -1.81f);
        Vector2[] blueberryAnswer = { blueberry1Answer, blueberry2Answer, blueberry3Answer };

        Vector2 blueberryjuice1Answer = new Vector2(-1.62f, -3.46f);
        Vector2 blueberryjuice2Answer = new Vector2(0.05f, -3.49f);
        Vector2 blueberryjuice3Answer = new Vector2(1.78f, -3.41f);
        Vector2[] blueberryjuiceAnswer = { blueberryjuice1Answer, blueberryjuice2Answer, blueberryjuice3Answer };

        Vector2 strawberryjuice1Answer = new Vector2(-2.31f, 2.01f);
        Vector2 strawberryjuice2Answer = new Vector2(2.08f, 2.14f);
        Vector2[] strawberryjuiceAnswer = { strawberryjuice1Answer, strawberryjuice2Answer };

        Vector2 cheese1Answer = new Vector2(-0.06f, 1.53f);
        Vector2 cheese2Answer = new Vector2(-1.76f, -0.14f);
        Vector2 cheese3Answer = new Vector2(-1.26f, -2f);
        Vector2 cheese4Answer = new Vector2(1.28f, -2f);
        Vector2 cheese5Answer = new Vector2(1.72f, -0.09f);
        Vector2[] cheeseAnswer = { cheese1Answer, cheese2Answer, cheese3Answer, cheese4Answer, cheese5Answer };

        Vector2 cream1Answer = new Vector2(-0.06f, 1.53f);
        Vector2 cream2Answer = new Vector2(-1.76f, -0.14f);
        Vector2 cream3Answer = new Vector2(-1.26f, -2f);
        Vector2 cream4Answer = new Vector2(1.28f, -2f);
        Vector2 cream5Answer = new Vector2(1.72f, -0.09f);
        Vector2[] creamAnswer = { cream1Answer, cream2Answer, cream3Answer, cream4Answer, cream5Answer };


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
            Debug.Log("basil" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("basil위치체크후" + platingScore);
            minDist = 100f;
            if (basilCount > 1)
            {
                platingScore -= (basilCount - 1) * (700);
            }
        }

        if (ketchupCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < ketchupCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer);
                    tempIndex1 = i;
                }
            }
            Debug.Log("ketchup" + minDist);
            if (minDist > 1f) platingScore -= 700;
           // else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("ketchup위치체크후" + platingScore);
            minDist = 100f;
            if (ketchupCount > 1)
            {
                platingScore -= (ketchupCount - 1) * (700);
            }
        }

        if (orangejuiceCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < orangejuiceCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer);
                    tempIndex1 = i;
                }
            }
            Debug.Log("orangejuice" + minDist);
            if (minDist > 3f) platingScore -= 700;
            // else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("orangejuice위치체크후" + platingScore);
            minDist = 100f;
            if (orangejuiceCount > 1)
            {
                platingScore -= (orangejuiceCount - 1) * (700);
            }
        }

        if (cherryCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < cherryCount; i++)
            {
                for (int j = 0; j < cherryAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("cherry" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("cherry1위치체크후" + platingScore);
            minDist = 100f;

            if (cherryCount > 1)
            {
                for (int i = 0; (i < cherryCount); i++)
                {
                    for (int j = 0; (j < cherryAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCherry[i].transform.position.x, tempCherry[i].transform.position.y), cherryAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("cherry" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("cherry2위치체크후" + platingScore);
                minDist = 100f;
                if (cherryCount > 2)
                {
                    platingScore -= (cherryCount - 2) * (300);
                }
            }
        }

        if (blueberryCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;

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
            if (minDist >standard1) platingScore -= 700;
            else platingScore -= (int)(minDist /standard2) * 100;
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
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("블루베리2위치체크후" + platingScore);
                minDist = 100f;
                if (blueberryCount > 2)
                {
                    for (int i = 0; i < blueberryCount; i++)
                    {
                        for (int j = 0; j < blueberryAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempBlueberry[i].transform.position.x, tempBlueberry[i].transform.position.y), blueberryAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempBlueberry[i].transform.position.x, tempBlueberry[i].transform.position.y), blueberryAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > standard1) platingScore -= 700;
                    else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("blueberry3위치체크후" + platingScore);
                    minDist = 100f;

                    if (blueberryCount > 3)
                    {
                        platingScore -= (blueberryCount - 3) * (200);
                    }

                }

            }

        }

        if (blueberryjuiceCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;

            for (int i = 0; i < blueberryjuiceCount; i++)
            {
                for (int j = 0; j < blueberryjuiceAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist >2f) platingScore -= 700;
            //else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("blueberryjuice1위치체크후" + platingScore);
            minDist = 100f;
            if (blueberryjuiceCount > 1)
            {
                for (int i = 0; (i < blueberryjuiceCount); i++)
                {
                    for (int j = 0; j < blueberryjuiceAnswer.Length; j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 2f) platingScore -= 700;
               // else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("블루베리2위치체크후" + platingScore);
                minDist = 100f;
                if (blueberryjuiceCount > 2)
                {
                    for (int i = 0; i < blueberryjuiceCount; i++)
                    {
                        for (int j = 0; j < blueberryjuiceAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempBlueberryjuice[i].transform.position.x, tempBlueberryjuice[i].transform.position.y), blueberryjuiceAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 2f) platingScore -= 700;
                   // else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("blueberryjuice3위치체크후" + platingScore);
                    minDist = 100f;

                    if (blueberryjuiceCount > 3)
                    {
                        platingScore -= (blueberryjuiceCount - 3) * (200);
                    }

                }

            }

        }

        if (strawberryjuiceCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < strawberryjuiceCount; i++)
            {
                for (int j = 0; j < strawberryjuiceAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempStrawberryjuice[i].transform.position.x, tempStrawberryjuice[i].transform.position.y), strawberryjuiceAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempStrawberryjuice[i].transform.position.x, tempStrawberryjuice[i].transform.position.y), strawberryjuiceAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("strawberryjuice" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 2.5f) platingScore -= 700;
            // else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("strawberryjuice1위치체크후" + platingScore);
            minDist = 100f;

            if (strawberryjuiceCount > 1)
            {
                for (int i = 0; (i < strawberryjuiceCount); i++)
                {
                    for (int j = 0; (j < strawberryjuiceAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempStrawberryjuice[i].transform.position.x, tempStrawberryjuice[i].transform.position.y), strawberryjuiceAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempStrawberryjuice[i].transform.position.x, tempStrawberryjuice[i].transform.position.y), strawberryjuiceAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("strawberryjuice" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 2.5f) platingScore -= 700;
                // else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("strawberryjuice2위치체크후" + platingScore);
                minDist = 100f;
                if (strawberryjuiceCount > 2)
                {
                    platingScore -= (strawberryjuiceCount - 2) * (300);
                }
            }
        }

        if (cheeseCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            int tempIndex5 = 0;
            int tempAnswerIndex5 = 0;
            for (int i = 0; i < cheeseCount; i++)
            {
                for (int j = 0; j < cheeseAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 2f) platingScore -= 700;
            //else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("cheese1위치체크후" + platingScore);
            minDist = 100f;
            if (cheeseCount > 1)
            {
                for (int i = 0; (i < cheeseCount); i++)
                {
                    for (int j = 0; (j < cheeseAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 2f) platingScore -= 700;
               // else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("cheese2위치체크후" + platingScore);
                minDist = 100f;
                if (cheeseCount > 2)
                {
                    for (int i = 0; i < cheeseCount; i++)
                    {
                        for (int j = 0; j < cheeseAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 2f) platingScore -= 700;
                  //  else platingScore -= (int)(minDist / 5) * 100;
                    Debug.Log("cheese3위치체크후" + platingScore);
                    minDist = 100f;
                    if (cheeseCount > 3)
                    {
                        for (int i = 0; i < cheeseCount; i++)
                        {
                            for (int j = 0; j < cheeseAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 2f) platingScore -= 700;
                        //else platingScore -= (int)(minDist / 5) * 100;
                        Debug.Log("cheese4위치체크후" + platingScore);
                        minDist = 100f;

                        if (cheeseCount > 4)
                        {
                            for (int i = 0; i < cheeseCount; i++)
                            {
                                for (int j = 0; j < cheeseAnswer.Length; j++)
                                {

                                    if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3) && (i != tempIndex4) && (j != tempAnswerIndex4))
                                    {
                                        if (Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]) < minDist)
                                        {
                                            minDist = Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]);

                                            tempIndex5 = i;
                                            tempAnswerIndex5 = j;
                                        }
                                    }
                                }

                            }
                            Debug.Log(minDist);
                            Debug.Log(tempIndex5 + "  " + tempAnswerIndex5);
                            if (minDist > 2f) platingScore -= 700;
                            //else platingScore -= (int)(minDist / 5) * 100;
                            Debug.Log("cheese5위치체크후" + platingScore);
                            minDist = 100f;

                            if (cheeseCount > 5)
                            {
                                platingScore -= (cheeseCount - 5) * (100);
                            }

                        }

                    }

                }
            }
        }

        if (creamCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            int tempIndex5 = 0;
            int tempAnswerIndex5 = 0;
            for (int i = 0; i < creamCount; i++)
            {
                for (int j = 0; j < creamAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 2f) platingScore -= 700;
           // else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("cream1위치체크후" + platingScore);
            minDist = 100f;
            if (creamCount > 1)
            {
                for (int i = 0; (i < creamCount); i++)
                {
                    for (int j = 0; (j < creamAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist >2f) platingScore -= 700;
               // else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("cream2위치체크후" + platingScore);
                minDist = 100f;
                if (creamCount > 2)
                {
                    for (int i = 0; i < creamCount; i++)
                    {
                        for (int j = 0; j < creamAnswer.Length; j++)
                        {
                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 2f) platingScore -= 700;
                   // else platingScore -= (int)(minDist / 5) * 100;
                    Debug.Log("cream3위치체크후" + platingScore);
                    minDist = 100f;
                    if (creamCount > 3)
                    {
                        for (int i = 0; i < creamCount; i++)
                        {
                            for (int j = 0; j < creamAnswer.Length; j++)
                            {
                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 2f) platingScore -= 700;
                       // else platingScore -= (int)(minDist / 5) * 100;
                        Debug.Log("cream4위치체크후" + platingScore);
                        minDist = 100f;
                        if (creamCount > 4)
                        {
                            for (int i = 0; i < creamCount; i++)
                            {
                                for (int j = 0; j < creamAnswer.Length; j++)
                                {
                                    if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3) && (i != tempIndex4) && (j != tempAnswerIndex4))
                                    {
                                        if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                                        {
                                            minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);

                                            tempIndex5 = i;
                                            tempAnswerIndex5 = j;
                                        }
                                    }
                                }

                            }
                            Debug.Log(minDist);
                            Debug.Log(tempIndex5 + "  " + tempAnswerIndex5);
                            if (minDist > 2f) platingScore -= 700;
                           // else platingScore -= (int)(minDist / 5) * 100;
                            Debug.Log("cream5위치체크후" + platingScore);
                            minDist = 100f;

                            if (creamCount > 5)
                            {
                                platingScore -= (creamCount - 5) * (100);
                            }
                        }
                    }
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

        tempIvy = null;
        tempCheese = null;
        tempCream = null;
        tempBlueberry = null;
        tempCherry = null;
        tempBasil = null;
        tempStrawberryjuice = null;
        tempOrangejuice = null;
        tempKetchup = null;
        tempBlueberryjuice = null;
    }

    /*===================================================================== < platingSample22 > =======================================================================*/
    public void checkPlating22()
    {

        int platingScore = 7000;

        GameObject tempOmelet = null;
        GameObject[] tempCheese = new GameObject[5];
        GameObject[] tempBasil = new GameObject[5];
        GameObject[] tempBroccoli = new GameObject[5];
        GameObject[] tempCherrytomato = new GameObject[5];
        GameObject[] tempStrawberry = new GameObject[5];
        GameObject[] tempApple = new GameObject[5];
        GameObject[] tempRadishsprout = new GameObject[5];
        GameObject[] tempPaprika = new GameObject[5];
        GameObject[] tempCaramelsyrup = new GameObject[5];

        //기준 700원
        int omeletCount = 0;
        int cheeseCount = 0;
        int basilCount = 0;
        int broccoliCount = 0;
        int cherrytomatoCount = 0;
        int strawberryCount = 0;
        int appleCount = 0;
        int radishsproutCount = 0;
        int paprikaCount = 0;
        int caramelsyrupCount = 0;

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedOmelet(Clone)")
            {
                tempOmelet = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                omeletCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCheese(Clone)")
            {
                tempCheese[cheeseCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cheeseCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBasil(Clone)")
            {
                tempBasil[basilCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                basilCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBroccoli(Clone)")
            {
                tempBroccoli[broccoliCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                broccoliCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherrytomato(Clone)")
            {
                tempCherrytomato[cherrytomatoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherrytomatoCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedStrawberry(Clone)")
            {
                tempStrawberry[strawberryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                strawberryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedApple_chop(Clone)")
            {
                tempApple[appleCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                appleCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedRadishsprout(Clone)")
            {
                tempRadishsprout[radishsproutCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                radishsproutCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedPaprika_chop(Clone)")
            {
                tempPaprika[paprikaCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                paprikaCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "caramelLineDrawer(Clone)")
            {
                tempCaramelsyrup[caramelsyrupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                caramelsyrupCount++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크
        if ((tempBasil[0] != null) && (tempCheese[0] != null) && (tempOmelet != null))
        {
            for (int i = 0; i < basilCount; i++)
            {
                if (tempBasil[i].transform.position.z > tempOmelet.transform.position.z) platingScore -= 100;

                for (int j = 0; j < cheeseCount; j++)
                {
                    if (tempBasil[i].transform.position.z > tempCheese[j].transform.position.z) platingScore -= 100;
                }
            }
        }

        if ((tempBroccoli[0] != null) && (tempCheese[0] != null) && (tempOmelet != null))
        {
            for (int i = 0; i < broccoliCount; i++)
            {
                if (tempBroccoli[i].transform.position.z > tempOmelet.transform.position.z) platingScore -= 100;

                for (int j = 0; j < cheeseCount; j++)
                {
                    if (tempBroccoli[i].transform.position.z > tempCheese[j].transform.position.z) platingScore -= 100;
                }
            }
        }

        if ((tempCheese[0] != null) && (tempOmelet != null))
        {
            for (int i = 0; i < cheeseCount; i++)
            {
                if (tempCheese[i].transform.position.z > tempOmelet.transform.position.z) platingScore -= 100;

            }
        }

        // 있어야할 재료가 모자르면 -(700÷해당 재료 전체갯수)*모자른 갯수
        if (omeletCount == 0) platingScore -= 700;
        if (cheeseCount == 0) platingScore -= 700;
        if (cherrytomatoCount == 0) platingScore -= 700;
        if (broccoliCount == 0) platingScore -= 700;

        if (caramelsyrupCount == 0) platingScore -= 700;
        else if (caramelsyrupCount > 0 && caramelsyrupCount < 3)
            platingScore -= 200 * (3 - caramelsyrupCount);

        if (basilCount == 0)
            platingScore -= 700;
        else if (basilCount ==1)
            platingScore -=300;

        if (appleCount == 0)
            platingScore -= 700;
        else if (appleCount == 1)
            platingScore -= 300;

        if (radishsproutCount == 0)
            platingScore -= 700;
        else if (radishsproutCount == 1)
            platingScore -= 300;

        if (paprikaCount == 0)
            platingScore -= 700;
        else if (paprikaCount == 1)
            platingScore -= 300;

        if (strawberryCount == 0)
            platingScore -= 700;
        else if (strawberryCount == 1)
            platingScore -= 300;


        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;

        Vector2 broccoliAnswer = new Vector2(0.06f,0.02f);
        Vector2 cherrytomatoAnswer = new Vector2(2.83f,-1.08f);
        Vector2 cheeseAnswer = new Vector2(0.12f, -0.21f);

        Vector2 basil1Answer = new Vector2(-0.67f, -0.61f);
        Vector2 basil2Answer = new Vector2(0.95f, 0.46f);
        Vector2[] basilAnswer = { basil1Answer, basil2Answer };

        Vector2 strawberry1Answer = new Vector2(-1.6f, 2.42f);
        Vector2 strawberry2Answer = new Vector2(-3.31f,-0.92f);
        Vector2[] strawberryAnswer = { strawberry1Answer, strawberry2Answer };

        Vector2 apple1Answer = new Vector2(-3.1f, 0.33f);
        Vector2 apple2Answer = new Vector2(-2.55f, 1.19f);
        Vector2[] appleAnswer = { apple1Answer, apple2Answer };

        Vector2 radishsprout1Answer = new Vector2(0.72f, 2.37f);
        Vector2 radishsprout2Answer = new Vector2(2.89f, 0.36f);
        Vector2[] radishsproutAnswer = { radishsprout1Answer, radishsprout2Answer };

        Vector2 paprika1Answer = new Vector2(-0.09f, -3.25f);
        Vector2 paprika2Answer = new Vector2(1.95f, -2.49f);
        Vector2[] paprikaAnswer = { paprika1Answer, paprika2Answer };

        Vector2 caramelsyrup1Answer = new Vector2(-1.76f,-1.42f);
        Vector2 caramelsyrup2Answer = new Vector2(-1.76f, -1.42f);
        Vector2 caramelsyrup3Answer = new Vector2(2.58f, 2.13f);
        Vector2[] caramelsyrupAnswer = { caramelsyrup1Answer, caramelsyrup2Answer, caramelsyrup3Answer };

        if (broccoliCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < broccoliCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempBroccoli[i].transform.position.x, tempBroccoli[i].transform.position.y), broccoliAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempBroccoli[i].transform.position.x, tempBroccoli[i].transform.position.y), broccoliAnswer);
                    tempIndex1 = i;
                }
            }
            Debug.Log("broccoli" + minDist);
            if (minDist >standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("broccoli위치체크후" + platingScore);
            minDist = 100f;
            if (broccoliCount > 1)
            {
                platingScore -= (broccoliCount - 1) * (700);
            }
        }

        if (cherrytomatoCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < cherrytomatoCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempCherrytomato[i].transform.position.x, tempCherrytomato[i].transform.position.y), cherrytomatoAnswer);
                    tempIndex1 = i;
                }
            }
            Debug.Log("cherrytomato" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("cherrytomato위치체크후" + platingScore);
            minDist = 100f;
            if (cherrytomatoCount > 1)
            {
                platingScore -= (cherrytomatoCount - 1) * (700);
            }
        }

        if (cheeseCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < cheeseCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer);
                    tempIndex1 = i;
                }
            }
            Debug.Log("cheese" + minDist);
            if (minDist >standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("cheese위치체크후" + platingScore);
            minDist = 100f;
            if (cheeseCount > 1)
            {
                platingScore -= (cheeseCount - 1) * (700);
            }
        }

        if (basilCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < basilCount; i++)
            {
                for (int j = 0; j < basilAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("basil" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("basil1위치체크후" + platingScore);
            minDist = 100f;

            if (basilCount > 1)
            {
                for (int i = 0; (i < basilCount); i++)
                {
                    for (int j = 0; (j < basilAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempBasil[i].transform.position.x, tempBasil[i].transform.position.y), basilAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("basil" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("basil2위치체크후" + platingScore);
                minDist = 100f;
                if (basilCount > 2)
                {
                    platingScore -= (basilCount - 2) * (300);
                }
            }
        }

        if (strawberryCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < strawberryCount; i++)
            {
                for (int j = 0; j < strawberryAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("strawberry" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("strawberry1위치체크후" + platingScore);
            minDist = 100f;

            if (strawberryCount > 1)
            {
                for (int i = 0; (i < strawberryCount); i++)
                {
                    for (int j = 0; (j < strawberryAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("strawberry" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("strawberry2위치체크후" + platingScore);
                minDist = 100f;
                if (strawberryCount > 2)
                {
                    platingScore -= (strawberryCount - 2) * (300);
                }
            }
        }


        if (appleCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < appleCount; i++)
            {
                for (int j = 0; j < appleAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempApple[i].transform.position.x, tempApple[i].transform.position.y), appleAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempApple[i].transform.position.x, tempApple[i].transform.position.y), appleAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("apple" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("apple1위치체크후" + platingScore);
            minDist = 100f;

            if (appleCount > 1)
            {
                for (int i = 0; (i < appleCount); i++)
                {
                    for (int j = 0; (j < appleAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempApple[i].transform.position.x, tempApple[i].transform.position.y), appleAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempApple[i].transform.position.x, tempApple[i].transform.position.y), appleAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("apple" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("apple2위치체크후" + platingScore);
                minDist = 100f;
                if (appleCount > 2)
                {
                    platingScore -= (appleCount - 2) * (300);
                }
            }
        }

        if (radishsproutCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < radishsproutCount; i++)
            {
                for (int j = 0; j < radishsproutAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("radishsprout" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("radishsprout1위치체크후" + platingScore);
            minDist = 100f;

            if (radishsproutCount > 1)
            {
                for (int i = 0; (i < radishsproutCount); i++)
                {
                    for (int j = 0; (j < radishsproutAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempRadishsprout[i].transform.position.x, tempRadishsprout[i].transform.position.y), radishsproutAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("radishsprout" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("radishsprout2위치체크후" + platingScore);
                minDist = 100f;
                if (radishsproutCount > 2)
                {
                    platingScore -= (radishsproutCount - 2) * (300);
                }
            }
        }


        if (paprikaCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < paprikaCount; i++)
            {
                for (int j = 0; j < paprikaAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempPaprika[i].transform.position.x, tempPaprika[i].transform.position.y), paprikaAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempPaprika[i].transform.position.x, tempPaprika[i].transform.position.y), paprikaAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("paprika" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("paprika1위치체크후" + platingScore);
            minDist = 100f;

            if (paprikaCount > 1)
            {
                for (int i = 0; (i < paprikaCount); i++)
                {
                    for (int j = 0; (j < paprikaAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempPaprika[i].transform.position.x, tempPaprika[i].transform.position.y), paprikaAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempPaprika[i].transform.position.x, tempPaprika[i].transform.position.y), paprikaAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("paprika" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("paprika2위치체크후" + platingScore);
                minDist = 100f;
                if (paprikaCount > 2)
                {
                    platingScore -= (paprikaCount - 2) * (300);
                }
            }
        }

        if (caramelsyrupCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;

            for (int i = 0; i < caramelsyrupCount; i++)
            {
                for (int j = 0; j < caramelsyrupAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
           Debug.Log("caramelsyrup" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 2f) platingScore -= 700;
            //else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("caramelsyrup1위치체크후" + platingScore);
            minDist = 100f;
            if (caramelsyrupCount > 1)
            {
                for (int i = 0; (i < caramelsyrupCount); i++)
                {
                    for (int j = 0; j < caramelsyrupAnswer.Length; j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("caramelsyrup" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 2f) platingScore -= 700;
               // else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("caramelsyrup2위치체크후" + platingScore);
                minDist = 100f;
                if (caramelsyrupCount > 2)
                {
                    for (int i = 0; i < caramelsyrupCount; i++)
                    {
                        for (int j = 0; j < caramelsyrupAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log("caramelsyrup" + minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 2f) platingScore -= 700;
                   // else platingScore -= (int)(minDist / standard2) * 100;
                    Debug.Log("caramelsyrup3위치체크후" + platingScore);
                    minDist = 100f;

                    if (caramelsyrupCount > 3)
                    {
                        platingScore -= (caramelsyrupCount - 3) * (200);
                    }

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

        tempOmelet = null;
        tempCheese = null;
        tempBroccoli = null;
        tempBasil = null;
        tempPaprika = null;
        tempCherrytomato = null;
        tempRadishsprout = null;
        tempStrawberry = null;
        tempApple = null;
        tempCaramelsyrup = null;

    }

    /*===================================================================== < platingSample23 > =======================================================================*/

    public void checkPlating23()
    {

        int platingScore = 7000;
        //float tempCarrotX = 0;
        GameObject tempOmelet = null;
        GameObject[] tempAvocado = new GameObject[5];
        GameObject[] tempBroccoli = new GameObject[5];
        GameObject[] tempCherrytomato = new GameObject[5];
        GameObject[] tempBlueberry = new GameObject[5];
        GameObject[] tempLemon = new GameObject[5];
        GameObject[] tempRadishsprout = new GameObject[5];
        GameObject[] tempCucumber = new GameObject[5];
        GameObject[] tempCaramelsyrup = new GameObject[5];
        GameObject[] tempKetchup = new GameObject[5];

        //기준 700원
        int omeletCount = 0;
        int avocadoCount = 0;
        int broccoliCount = 0;
        int cherrytomatoCount = 0;
        int blueberryCount = 0;
        int lemonCount = 0;
        int radishsproutCount = 0;
        int cucumberCount = 0;
        int caramelsyrupCount = 0;
        int ketchupCount = 0;

        if (stage1_plating.platedParent.transform.childCount==0) platingScore = 0; //아무것도 없을시 0점

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedOmelet(Clone)")
            {
                tempOmelet = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                omeletCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedAvocado_chop(Clone)")
            {
                tempAvocado[avocadoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                avocadoCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBroccoli_grill(Clone)")
            {
                tempBroccoli[broccoliCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                broccoliCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherrytomato(Clone)")
            {
                tempCherrytomato[cherrytomatoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherrytomatoCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBlueberry(Clone)")
            {
                tempBlueberry[blueberryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedLemon_chop(Clone)")
            {
                tempLemon[lemonCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                lemonCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedRadishsprout(Clone)")
            {
                tempRadishsprout[radishsproutCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                radishsproutCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCucumber_chop(Clone)")
            {
                tempCucumber[cucumberCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cucumberCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "caramelLineDrawer(Clone)")
            {
                tempCaramelsyrup[caramelsyrupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                caramelsyrupCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "ketchupLineDrawer(Clone)")
            {
                tempKetchup[ketchupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                ketchupCount++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크
        if ((tempRadishsprout[0] != null) && (tempOmelet != null) && (tempKetchup[0] != null))
        {
            for (int i = 0; i < radishsproutCount; i++)
            {
                if (tempRadishsprout[i].transform.position.z > tempOmelet.transform.position.z) platingScore -= 100;

                for (int j = 0; j < ketchupCount; j++)
                {
                    if (tempRadishsprout[i].transform.position.z > tempKetchup[j].transform.position.z) platingScore -= 100;

                }

            }
        }

        if ((tempOmelet != null) && (tempKetchup[0] != null))
        {
            for (int i = 0; i < ketchupCount; i++)
            {
                if (tempKetchup[i].transform.position.z > tempOmelet.transform.position.z) platingScore -= 100;
            }
        }

        // 있어야할 재료가 모자르면 -(700÷해당 재료 전체갯수)*모자른 갯수
        if (omeletCount == 0) platingScore -= 700;
        if (avocadoCount == 0) platingScore -= 700;
        if (ketchupCount == 0) platingScore -= 700;

        if (caramelsyrupCount == 0) platingScore -= 700;
        else if (caramelsyrupCount == 1)
            platingScore -= 300;

        if (broccoliCount == 0)
            platingScore -= 700;
        else if (broccoliCount == 1)
            platingScore -= 300;

        if (lemonCount == 0)
            platingScore -= 700;
        else if (lemonCount == 1)
            platingScore -= 300;

        if (radishsproutCount == 0)
            platingScore -= 700;
        else if (radishsproutCount >0 && radishsproutCount < 3)
            platingScore -= 200*(3- radishsproutCount);

        if (cucumberCount == 0)
            platingScore -= 700;
        else if (cucumberCount == 1)
            platingScore -= 300;

        if (blueberryCount == 0)
            platingScore -= 700;
        else if (blueberryCount == 1)
            platingScore -= 300;

        if (cherrytomatoCount == 0)
            platingScore -= 700;
        else if (cherrytomatoCount == 1)
            platingScore -= 300;


        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;

        Vector2 ketchupAnswer = new Vector2(-0.14f,-0.11f);
        Vector2 avocadoAnswer = new Vector2(2.66f, -1.37f);

        Vector2 cucumber1Answer = new Vector2(-0.06f,-3.43f); 
        Vector2 cucumber2Answer = new Vector2(1.15f,-3.03f);
        Vector2[] cucumberAnswer = { cucumber1Answer, cucumber2Answer };

        Vector2 broccoli1Answer = new Vector2(-3.27f, -0.75f);
        Vector2 broccoli2Answer = new Vector2(-3.07f, 0.2f);
        Vector2[] broccoliAnswer = { broccoli1Answer, broccoli2Answer };

        Vector2 blueberry1Answer = new Vector2(-1.15f, -3.61f);
        Vector2 blueberry2Answer = new Vector2(-0.27f, 2.67f);
        Vector2[] blueberryAnswer = { blueberry1Answer, blueberry2Answer };

        Vector2 cherrytomato1Answer = new Vector2(0.56f, 2.61f);
        Vector2 cherrytomato2Answer = new Vector2(-1.89f, -3.34f);
        Vector2[] cherrytomatoAnswer = { cherrytomato1Answer, cherrytomato2Answer };

        Vector2 lemon1Answer = new Vector2(-1.63f, 1.90f);
        Vector2 lemon2Answer = new Vector2(-2.2f, 1.19f);
        Vector2[] lemonAnswer = { lemon1Answer, lemon2Answer };

        Vector2 caramelsyrup1Answer = new Vector2(-2.78f, -2.67f);
        Vector2 caramelsyrup2Answer = new Vector2(2.54f, 2.15f);
        Vector2[] caramelsyrupAnswer = { caramelsyrup1Answer, caramelsyrup2Answer };

        Vector2 radishsprout1Answer = new Vector2(-0.54f, -0.04f);
        Vector2 radishsprout2Answer = new Vector2(-0.16f, -0.12f);
        Vector2 radishsprout3Answer = new Vector2(0.14f, -0.32f);
        Vector2[] radishsproutAnswer = { radishsprout1Answer, radishsprout2Answer, radishsprout3Answer };


        if (ketchupCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < ketchupCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempKetchup[i].transform.position.x, tempKetchup[i].transform.position.y), ketchupAnswer);
                    tempIndex1 = i;
                }

            }
            Debug.Log("ketchup" + minDist);
            if (minDist > 4.5) platingScore -= 700;
            ///else platingScore -= (int)(minDist / 0.1) * 100;
            Debug.Log("ketchup위치체크후" + platingScore);
            minDist = 100f;
            if (ketchupCount > 1)
            {
                platingScore -= (ketchupCount - 1) * (700);
            }

        }

        if (avocadoCount > 0)
        {
            int tempIndex1 = 0;
            //int tempAnswerIndex1 = 0;
            for (int i = 0; i < avocadoCount; i++)
            {
                if (Vector2.Distance(new Vector2(tempAvocado[i].transform.position.x, tempAvocado[i].transform.position.y), avocadoAnswer) < minDist)
                {
                    //가장가까운애로 채점
                    minDist = Vector2.Distance(new Vector2(tempAvocado[i].transform.position.x, tempAvocado[i].transform.position.y), avocadoAnswer);
                    tempIndex1 = i;
                }
            }
            Debug.Log("Avocado" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("Avocado위치체크후" + platingScore);
            minDist = 100f;
            if (avocadoCount > 1)
            {
                platingScore -= (avocadoCount - 1) * (700);
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("cucumber1위치체크후" + platingScore);
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
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("cucumber2위치체크후" + platingScore);
                minDist = 100f;
               
                if (cucumberCount > 2)
                {
                  platingScore -= (cucumberCount - 2) * (300);
                }

            }
        }

        if (broccoliCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("broccoli1위치체크후" + platingScore);
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
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("broccoli2위치체크후" + platingScore);
                minDist = 100f;
                if (broccoliCount > 2)
                {
                    platingScore -= (broccoliCount - 2) * (300);
                }

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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("blueberry1위치체크후" + platingScore);
            minDist = 100f;
            if (blueberryCount > 1)
            {
                for (int i = 0; (i < blueberryCount); i++)
                {
                    for (int j = 0; (j < blueberryAnswer.Length); j++)
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
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("blueberry2위치체크후" + platingScore);
                minDist = 100f;
                if (blueberryCount > 2)
                {
                    platingScore -= (blueberryCount - 2) * (300);
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("cherrytomato1위치체크후" + platingScore);
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
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("cherrytomato2위치체크후" + platingScore);
                minDist = 100f;
                if (cherrytomatoCount > 2)
                {
                    platingScore -= (cherrytomatoCount - 2) * (300);
                }

            }
        }

        if (lemonCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < lemonCount; i++)
            {
                for (int j = 0; j < lemonAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempLemon[i].transform.position.x, tempLemon[i].transform.position.y), lemonAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempLemon[i].transform.position.x, tempLemon[i].transform.position.y), lemonAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("lemon1위치체크후" + platingScore);
            minDist = 100f;
            if (lemonCount > 1)
            {
                for (int i = 0; (i < lemonCount); i++)
                {
                    for (int j = 0; (j < lemonAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempLemon[i].transform.position.x, tempLemon[i].transform.position.y), lemonAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempLemon[i].transform.position.x, tempLemon[i].transform.position.y), lemonAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("lemon2위치체크후" + platingScore);
                minDist = 100f;
                if (lemonCount > 2)
                {
                    platingScore -= (lemonCount - 2) * (300);
                }

            }
        }

        if (caramelsyrupCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < caramelsyrupCount; i++)
            {
                for (int j = 0; j < caramelsyrupAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log("caramelsyrup" + minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 2.5f) platingScore -= 700;
            //else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("caramelsyrup1위치체크후" + platingScore);
            minDist = 100f;
            if (caramelsyrupCount > 1)
            {
                for (int i = 0; (i < caramelsyrupCount); i++)
                {
                    for (int j = 0; j < caramelsyrupAnswer.Length; j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log("caramelsyrup" + minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 2.5f) platingScore -= 700;
                // else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("caramelsyrup2위치체크후" + platingScore);
                minDist = 100f;
                if (caramelsyrupCount > 2)
                {
                 platingScore -= (caramelsyrupCount -2) * (300);
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

        tempOmelet = null;
        tempKetchup= null;
        tempRadishsprout = null;
        tempCucumber = null;
        tempAvocado = null;
        tempBlueberry = null;
        tempCherrytomato = null;
        tempBroccoli = null;
        tempLemon = null;
        tempCaramelsyrup = null;


    }

    /*===================================================================== < platingSample24 > =======================================================================*/

    public void checkPlating24()
    {
        int platingScore = 7000;
        //float tempCarrotX = 0;
        GameObject tempIvy = null;
        GameObject[] tempCheese = new GameObject[5];
        GameObject[] tempCream = new GameObject[5];
        GameObject[] tempCherry = new GameObject[5];
        GameObject[] tempCherrytomato = new GameObject[5];
        GameObject[] tempStrawberry = new GameObject[5];
        GameObject[] tempBlueberry = new GameObject[5];
        GameObject[] tempOrangejuice = new GameObject[5];
        GameObject[] tempCaramelsyrup = new GameObject[5];
        GameObject[] tempChocosyrup = new GameObject[5];

        //기준700
        int IvyCount = 0;
        int cheeseCount = 0;
        int creamCount = 0;
        int cherryCount = 0;
        int cherrytomatoCount = 0;
        int strawberryCount = 0;
        int blueberryCount = 0;
        int orangejuiceCount = 0;
        int caramelsyrupCount = 0;
        int chocosyrupCount = 0;

        if (stage1_plating.platedParent.transform.childCount == 0) platingScore = 0; //아무것도 없을시 0점

        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedIvy(Clone)")
            {
                tempIvy = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                IvyCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCheese_s(Clone)")
            {
                tempCheese[cheeseCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cheeseCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedStrawberry(Clone)")
            {

                tempStrawberry[strawberryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                strawberryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBlueberry(Clone)")
            {

                tempBlueberry[blueberryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                blueberryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherry(Clone)")
            {
                tempCherry[cherryCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherryCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedCherrytomato(Clone)")
            {
                tempCherrytomato[cherrytomatoCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                cherrytomatoCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "creamLineDrawer(Clone)")
            {
                tempCream[creamCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                creamCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "orangeLineDrawer(Clone)")
            {
                tempOrangejuice[orangejuiceCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                orangejuiceCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "caramelLineDrawer(Clone)")
            {
                tempCaramelsyrup[caramelsyrupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                caramelsyrupCount++;
            }
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "chocoLineDrawer(Clone)")
            {
                tempChocosyrup[chocosyrupCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                chocosyrupCount++;
            }
            else
            {
                //올바르지않은 재료
                platingScore -= 500;
            }

        }

        //순서체크

        if ((tempBlueberry[0] != null) && (tempCheese[0] != null) && (tempIvy != null) && (tempCream[0] != null))
        {
            for (int i = 0; i < blueberryCount; i++)
            {
                if (tempBlueberry[i].transform.position.z > tempIvy.transform.position.z) platingScore -= 100;

                for (int j = 0; j < creamCount; j++)
                {
                    if (tempBlueberry[i].transform.position.z > tempCream[j].transform.position.z) platingScore -= 100;
                }
                for (int j = 0; j < cheeseCount; j++)
                {
                    if (tempBlueberry[i].transform.position.z > tempCheese[j].transform.position.z) platingScore -= 100;
                }
            }
        }
        if ((tempCherry[0] != null) && (tempCheese[0] != null) && (tempIvy != null) && (tempCream[0] != null))
        {
            for (int i = 0; i < cherryCount; i++)
            {
                if (tempCherry[i].transform.position.z > tempIvy.transform.position.z) platingScore -= 100;

                for (int j = 0; j < creamCount; j++)
                {
                    if (tempCherry[i].transform.position.z > tempCream[j].transform.position.z) platingScore -= 100;
                }
                for (int j = 0; j < cheeseCount; j++)
                {
                    if (tempCherry[i].transform.position.z > tempCheese[j].transform.position.z) platingScore -= 100;
                }
            }
        }
        if ((tempStrawberry[0] != null) && (tempCheese[0] != null) && (tempIvy != null) && (tempCream[0] != null))
        {
            for (int i = 0; i < strawberryCount; i++)
            {
                if (tempStrawberry[i].transform.position.z > tempIvy.transform.position.z) platingScore -= 100;

                for (int j = 0; j < creamCount; j++)
                {
                    if (tempStrawberry[i].transform.position.z > tempCream[j].transform.position.z) platingScore -= 100;
                }
                for (int j = 0; j < cheeseCount; j++)
                {
                    if (tempStrawberry[i].transform.position.z > tempCheese[j].transform.position.z) platingScore -= 100;
                }
            }
        }
        if ((tempCream[0] != null) && (tempCheese[0] != null) && (tempIvy != null))
        {
            for (int i = 0; i < creamCount; i++)
            {
                if (tempCream[i].transform.position.z > tempIvy.transform.position.z) platingScore -= 100;

                for (int j = 0; j < cheeseCount; j++)
                {
                    if (tempCream[i].transform.position.z > tempCheese[j].transform.position.z) platingScore -= 100;
                }

            }
        }
        if ((tempCheese[0] != null) && (tempIvy != null))
        {
            for (int i = 0; i < cheeseCount; i++)
            {
                if (tempCheese[i].transform.position.z > tempIvy.transform.position.z) platingScore -= 100;
            }
        }
        // 있어야할 재료가 모자르면 -(700÷해당 재료 전체갯수)*모자른 갯수
        if (IvyCount == 0) platingScore -= 700;
        if (cherryCount == 0) platingScore -= 700;

        if (blueberryCount == 0)
            platingScore -= 700;
        else if (blueberryCount ==1)
            platingScore -= 700;

        if (cherrytomatoCount == 0)
            platingScore -= 700;
        else if (cherrytomatoCount == 1)
            platingScore -= 300;

        if (strawberryCount == 0)
            platingScore -= 700;
        else if (strawberryCount == 1)
            platingScore -= 300;

        if (orangejuiceCount == 0)
            platingScore -= 700;
        else if (orangejuiceCount >0 && orangejuiceCount<4)
            platingScore -= 100*(4-orangejuiceCount);

        if (caramelsyrupCount == 0)
            platingScore -= 700;
        else if (caramelsyrupCount > 0 && caramelsyrupCount < 4)
            platingScore -= 100 * (4 - caramelsyrupCount);

        if (chocosyrupCount == 0)
            platingScore -= 700;
        else if (chocosyrupCount > 0 && chocosyrupCount < 3)
            platingScore -= (200) * (3 - chocosyrupCount);

        if (creamCount == 0)
            platingScore -= 700;
        else if (creamCount > 0 && creamCount < 5)
            platingScore -= (100) * (5 - creamCount);

        if (cheeseCount == 0)
            platingScore -= 700;
        else if (cheeseCount > 0 && cheeseCount < 5)
            platingScore -= (100) * (5 - cheeseCount);


        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;

        Vector2 cherryAnswer = new Vector2(-0.06f, 2.01f);

        Vector2 blueberry1Answer = new Vector2(-1.3f, -1.95f);
        Vector2 blueberry2Answer = new Vector2(1.3f, -1.99f);
        Vector2[] blueberryAnswer = { blueberry1Answer, blueberry2Answer};

        Vector2 cherrytomato1Answer = new Vector2(-0.28f,-0.15f);
        Vector2 cherrytomato2Answer = new Vector2(0.2f, -0.15f);
        Vector2[] cherrytomatoAnswer = { cherrytomato1Answer, cherrytomato2Answer };

        Vector2 strawberry1Answer = new Vector2(-1.8f, 0.01f);
        Vector2 strawberry2Answer = new Vector2(1.74f, -0.05f);
        Vector2[] strawberryAnswer = { strawberry1Answer, strawberry2Answer };

        Vector2 chocosyrup1Answer = new Vector2(-1.06f, 2.43f);
        Vector2 chocosyrup2Answer = new Vector2(0.88f,2.43f);
        Vector2 chocosyrup3Answer = new Vector2(0.92f, 0.99f);
        Vector2[] chocosyrupAnswer = { chocosyrup1Answer, chocosyrup2Answer, chocosyrup3Answer };

        Vector2 caramelsyrup1Answer = new Vector2(-2.86f, 0.11f);
        Vector2 caramelsyrup2Answer = new Vector2(-1.8f, 0.87f);
        Vector2 caramelsyrup3Answer = new Vector2(1.44f, -3.01f);
        Vector2 caramelsyrup4Answer = new Vector2(2.48f, -2.05f);
        Vector2[] caramelsyrupAnswer = { caramelsyrup1Answer, caramelsyrup2Answer, caramelsyrup3Answer, caramelsyrup4Answer };

        Vector2 orangejuice1Answer = new Vector2(-2.78f, -2.29f);
        Vector2 orangejuice2Answer = new Vector2(-2.6f, -2.85f);
        Vector2 orangejuice3Answer = new Vector2(3.06f, 0.67f);
        Vector2 orangejuice4Answer = new Vector2(3.2f, 0.11f);
        Vector2[] orangejuiceAnswer = { orangejuice1Answer, orangejuice2Answer, orangejuice3Answer, orangejuice4Answer };

        Vector2 cheese1Answer = new Vector2(-0.06f, 1.53f);
        Vector2 cheese2Answer = new Vector2(-1.81f, -0.16f);
        Vector2 cheese3Answer = new Vector2(-1.28f, -2.02f);
        Vector2 cheese4Answer = new Vector2(1.28f, -2.02f);
        Vector2 cheese5Answer = new Vector2(1.73f, -0.13f);
        Vector2[] cheeseAnswer = { cheese1Answer, cheese2Answer, cheese3Answer, cheese4Answer, cheese5Answer };

        Vector2 cream1Answer = new Vector2(-0.06f, 1.53f);
        Vector2 cream2Answer = new Vector2(-1.81f, -0.16f);
        Vector2 cream3Answer = new Vector2(-1.28f, -2.02f);
        Vector2 cream4Answer = new Vector2(1.28f, -2.02f);
        Vector2 cream5Answer = new Vector2(1.73f, -0.13f);
        Vector2[] creamAnswer = { cream1Answer, cream2Answer, cream3Answer, cream4Answer, cream5Answer };

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
            Debug.Log("Cherry" + minDist);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("Cherry위치체크후" + platingScore);
            minDist = 100f;
            if (cherryCount > 1)
            {
                platingScore -= (cherryCount - 1) * (700);
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) * 100;
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
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("블루베리2위치체크후" + platingScore);
                minDist = 100f;
                if (blueberryCount > 2)
                 {
                  platingScore -= (blueberryCount - 2) * (300);
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
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 700;
            else platingScore -= (int)(minDist / standard2) *100;
            Debug.Log("방울토마토1위치체크후" + platingScore);
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
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > standard1) platingScore -= 700;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("방울토마토2위치체크후" + platingScore);
                minDist = 100f;
                if (cherrytomatoCount > 2)
                {
                    platingScore -= (cherrytomatoCount - 2) * (300);
                }

            }



        }

        if (strawberryCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;

            for (int i = 0; i < strawberryCount; i++)
            {
                for (int j = 0; j < strawberryAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
           Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > standard1) platingScore -= 1100;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("딸기1위치체크후" + platingScore);
            minDist = 100f;
            if (strawberryCount > 1)
            {
                for (int i = 0; (i < strawberryCount); i++)
                {
                    for (int j = 0; (j < strawberryAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempStrawberry[i].transform.position.x, tempStrawberry[i].transform.position.y), strawberryAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
               Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist >standard1) platingScore -= 1100;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("딸기2위치체크후" + platingScore);
                minDist = 100f;
                if (strawberryCount > 2)
                {
                    platingScore -= (strawberryCount - 2) * (300);
                }
            }
        }

        if (orangejuiceCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < orangejuiceCount; i++)
            {
                for (int j = 0; j < orangejuiceAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist >= 2f) platingScore -= 700; //2차이나면 점수X, 1차이나면 조금 깎임
            else platingScore -= (int)(minDist / 1) * 300;
            Debug.Log("OrangeJuice1위치체크후" + platingScore);
            minDist = 100f;
            if (orangejuiceCount > 1)
            {
                for (int i = 0; (i < orangejuiceCount); i++)
                {
                    for (int j = 0; (j < orangejuiceAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist >= 2f) platingScore -= 700;
                else platingScore -= (int)(minDist / 1) *300;
                Debug.Log("OrangeJuice2위치체크후" + platingScore);
                minDist = 100f;
                if (orangejuiceCount > 2)
                {
                    for (int i = 0; i < orangejuiceCount; i++)
                    {
                        for (int j = 0; j < orangejuiceAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist >= 2f) platingScore -= 700;
                    else platingScore -= (int)(minDist / 1) * 300;
                    Debug.Log("OrangeJuice3위치체크후" + platingScore);
                    minDist = 100f;
                    if (orangejuiceCount > 3)
                    {
                        for (int i = 0; i < orangejuiceCount; i++)
                        {
                            for (int j = 0; j < orangejuiceAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempOrangejuice[i].transform.position.x, tempOrangejuice[i].transform.position.y), orangejuiceAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 2) platingScore -= 700;
                        else platingScore -= (int)(minDist / 1) * 300;
                        Debug.Log("OrangeJuice4위치체크후" + platingScore);
                        minDist = 100f;
                        if (orangejuiceCount > 4)
                        {
                            platingScore -= (orangejuiceCount - 4) * (300);
                        }
                    }
                }

            }

        }

        if (caramelsyrupCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            for (int i = 0; i < caramelsyrupCount; i++)
            {
                for (int j = 0; j < caramelsyrupAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist >= 2f) platingScore -= 700; //2차이나면 점수X, 1차이나면 조금 깎임
            else platingScore -= (int)(minDist / 1) * 300;
            Debug.Log("caramelsyrup1위치체크후" + platingScore);
            minDist = 100f;
            if (caramelsyrupCount > 1)
            {
                for (int i = 0; (i < caramelsyrupCount); i++)
                {
                    for (int j = 0; (j < caramelsyrupAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist >= 2f) platingScore -= 700;
                else platingScore -= (int)(minDist / 1) * 300;
                Debug.Log("caramelsyrup2위치체크후" + platingScore);
                minDist = 100f;
                if (caramelsyrupCount > 2)
                {
                    for (int i = 0; i < caramelsyrupCount; i++)
                    {
                        for (int j = 0; j < caramelsyrupAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist >= 2f) platingScore -= 700;
                    else platingScore -= (int)(minDist / 1) * 300;
                    Debug.Log("caramelsyrup3위치체크후" + platingScore);
                    minDist = 100f;
                    if (caramelsyrupCount > 3)
                    {
                        for (int i = 0; i < caramelsyrupCount; i++)
                        {
                            for (int j = 0; j < caramelsyrupAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempCaramelsyrup[i].transform.position.x, tempCaramelsyrup[i].transform.position.y), caramelsyrupAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 2) platingScore -= 700;
                        else platingScore -= (int)(minDist / 1) * 300;
                        Debug.Log("caramelsyrup4위치체크후" + platingScore);
                        minDist = 100f;
                        if (caramelsyrupCount > 4)
                        {
                            platingScore -= (caramelsyrupCount - 4) * (300);
                        }
                    }
                }

            }

        }

        if (cheeseCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            int tempIndex5 = 0;
            int tempAnswerIndex5 = 0;
            for (int i = 0; i < cheeseCount; i++)
            {
                for (int j = 0; j < cheeseAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 2f) platingScore -= 700;
            //else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("cheese1위치체크후" + platingScore);
            minDist = 100f;
            if (cheeseCount > 1)
            {
                for (int i = 0; (i < cheeseCount); i++)
                {
                    for (int j = 0; (j < cheeseAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 2f) platingScore -= 700;
                // else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("cheese2위치체크후" + platingScore);
                minDist = 100f;
                if (cheeseCount > 2)
                {
                    for (int i = 0; i < cheeseCount; i++)
                    {
                        for (int j = 0; j < cheeseAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 2f) platingScore -= 700;
                    //  else platingScore -= (int)(minDist / 5) * 100;
                    Debug.Log("cheese3위치체크후" + platingScore);
                    minDist = 100f;
                    if (cheeseCount > 3)
                    {
                        for (int i = 0; i < cheeseCount; i++)
                        {
                            for (int j = 0; j < cheeseAnswer.Length; j++)
                            {

                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 2f) platingScore -= 700;
                        //else platingScore -= (int)(minDist / 5) * 100;
                        Debug.Log("cheese4위치체크후" + platingScore);
                        minDist = 100f;

                        if (cheeseCount > 4)
                        {
                            for (int i = 0; i < cheeseCount; i++)
                            {
                                for (int j = 0; j < cheeseAnswer.Length; j++)
                                {

                                    if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3) && (i != tempIndex4) && (j != tempAnswerIndex4))
                                    {
                                        if (Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]) < minDist)
                                        {
                                            minDist = Vector2.Distance(new Vector2(tempCheese[i].transform.position.x, tempCheese[i].transform.position.y), cheeseAnswer[j]);

                                            tempIndex5 = i;
                                            tempAnswerIndex5 = j;
                                        }
                                    }
                                }

                            }
                            Debug.Log(minDist);
                            Debug.Log(tempIndex5 + "  " + tempAnswerIndex5);
                            if (minDist > 2f) platingScore -= 700;
                            //else platingScore -= (int)(minDist / 5) * 100;
                            Debug.Log("cheese5위치체크후" + platingScore);
                            minDist = 100f;

                            if (cheeseCount > 5)
                            {
                                platingScore -= (cheeseCount - 5) * (100);
                            }

                        }

                    }

                }
            }
        }

        if (creamCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;
            int tempIndex4 = 0;
            int tempAnswerIndex4 = 0;
            int tempIndex5 = 0;
            int tempAnswerIndex5 = 0;
            for (int i = 0; i < creamCount; i++)
            {
                for (int j = 0; j < creamAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if (minDist > 2f) platingScore -= 700;
            // else platingScore -= (int)(minDist / 5) * 100;
            Debug.Log("cream1위치체크후" + platingScore);
            minDist = 100f;
            if (creamCount > 1)
            {
                for (int i = 0; (i < creamCount); i++)
                {
                    for (int j = 0; (j < creamAnswer.Length); j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 2f) platingScore -= 700;
                // else platingScore -= (int)(minDist / 5) * 100;
                Debug.Log("cream2위치체크후" + platingScore);
                minDist = 100f;
                if (creamCount > 2)
                {
                    for (int i = 0; i < creamCount; i++)
                    {
                        for (int j = 0; j < creamAnswer.Length; j++)
                        {
                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 2f) platingScore -= 700;
                    // else platingScore -= (int)(minDist / 5) * 100;
                    Debug.Log("cream3위치체크후" + platingScore);
                    minDist = 100f;
                    if (creamCount > 3)
                    {
                        for (int i = 0; i < creamCount; i++)
                        {
                            for (int j = 0; j < creamAnswer.Length; j++)
                            {
                                if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3))
                                {
                                    if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                                    {
                                        minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);

                                        tempIndex4 = i;
                                        tempAnswerIndex4 = j;
                                    }
                                }
                            }

                        }
                        Debug.Log(minDist);
                        Debug.Log(tempIndex4 + "  " + tempAnswerIndex4);
                        if (minDist > 2f) platingScore -= 700;
                        // else platingScore -= (int)(minDist / 5) * 100;
                        Debug.Log("cream4위치체크후" + platingScore);
                        minDist = 100f;
                        if (creamCount > 4)
                        {
                            for (int i = 0; i < creamCount; i++)
                            {
                                for (int j = 0; j < creamAnswer.Length; j++)
                                {
                                    if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2) && (i != tempIndex3) && (j != tempAnswerIndex3) && (i != tempIndex4) && (j != tempAnswerIndex4))
                                    {
                                        if (Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]) < minDist)
                                        {
                                            minDist = Vector2.Distance(new Vector2(tempCream[i].transform.position.x, tempCream[i].transform.position.y), creamAnswer[j]);

                                            tempIndex5 = i;
                                            tempAnswerIndex5 = j;
                                        }
                                    }
                                }

                            }
                            Debug.Log(minDist);
                            Debug.Log(tempIndex5 + "  " + tempAnswerIndex5);
                            if (minDist > 2f) platingScore -= 700;
                            // else platingScore -= (int)(minDist / 5) * 100;
                            Debug.Log("cream5위치체크후" + platingScore);
                            minDist = 100f;

                            if (creamCount > 5)
                            {
                                platingScore -= (creamCount - 5) * (100);
                            }
                        }
                    }
                }
            }
        }

        if (chocosyrupCount > 0)
        {
            int tempIndex1 = 0;
            int tempAnswerIndex1 = 0;
            int tempIndex2 = 0;
            int tempAnswerIndex2 = 0;
            int tempIndex3 = 0;
            int tempAnswerIndex3 = 0;

            for (int i = 0; i < chocosyrupCount; i++)
            {
                for (int j = 0; j < chocosyrupAnswer.Length; j++)
                {
                    if (Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]) < minDist)
                    {
                        //가장가까운애로 채점
                        minDist = Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]);
                        tempIndex1 = i;
                        tempAnswerIndex1 = j;
                    }
                }

            }
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
            Debug.Log(minDist);
            Debug.Log(tempIndex1 + "  " + tempAnswerIndex1);
            if ((tempAnswerIndex1 == 0)||(tempAnswerIndex1==1))
            {
                if (minDist > 2f) platingScore -= 700;
                //else platingScore -= (int)(minDist / standard2) * 100;
            }
            else if (tempAnswerIndex1 == 2) {
                if (minDist > 1f) platingScore -= 700;
                //else platingScore -= (int)(minDist / standard2) * 100;
            }
            Debug.Log("chocosyrup1위치체크후" + platingScore);
 
            minDist = 100f;
            if (chocosyrupCount > 1)
            {
                for (int i = 0; (i < chocosyrupCount); i++)
                {
                    for (int j = 0; j < chocosyrupAnswer.Length; j++)
                    {
                        if (i != tempIndex1 && j != tempAnswerIndex1)
                        {
                            if (Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]) < minDist)
                            {
                                minDist = Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]);
                                tempIndex2 = i;
                                tempAnswerIndex2 = j;
                            }
                        }
                    }
                }
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if ((tempAnswerIndex2 == 0) || (tempAnswerIndex2 == 1))
                {
                    if (minDist > 2f) platingScore -= 700;
                    //else platingScore -= (int)(minDist / standard2) * 100;
                }
                else if (tempAnswerIndex2 == 2)
                {
                    if (minDist > 1f) platingScore -= 700;
                    //else platingScore -= (int)(minDist / standard2) * 100;
                }
                Debug.Log("chocosyrup2위치체크후" + platingScore);
                minDist = 100f;
                if (chocosyrupCount > 2)
                {
                    for (int i = 0; i < chocosyrupCount; i++)
                    {
                        for (int j = 0; j < chocosyrupAnswer.Length; j++)
                        {

                            if (i != tempIndex1 && j != tempAnswerIndex1 && (i != tempIndex2) && (j != tempAnswerIndex2))
                            {
                                if (Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]) < minDist)
                                {
                                    minDist = Vector2.Distance(new Vector2(tempChocosyrup[i].transform.position.x, tempChocosyrup[i].transform.position.y), chocosyrupAnswer[j]);

                                    tempIndex3 = i;
                                    tempAnswerIndex3 = j;
                                }
                            }
                        }

                    }
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if ((tempAnswerIndex3 == 0) || (tempAnswerIndex3 == 1))
                    {
                        if (minDist > 2f) platingScore -= 700;
                        //else platingScore -= (int)(minDist / standard2) * 100;
                    }
                    else if (tempAnswerIndex3 == 2)
                    {
                        if (minDist > 1f) platingScore -= 700;
                        //else platingScore -= (int)(minDist / standard2) * 100;
                    }
                    Debug.Log("chocosyrup3위치체크후" + platingScore);
                    minDist = 100f;

                    if (chocosyrupCount > 3)
                    {
                        platingScore -= (chocosyrupCount - 3) * (200);
                    }

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


        tempIvy = null;
        tempCheese = null;
        tempCream= null;
        tempCherrytomato = null;
        tempCherry = null;
        tempStrawberry = null;
        tempBlueberry = null;
        tempOrangejuice = null;
        tempCaramelsyrup = null;
        tempChocosyrup = null;
       


    }
   
}
