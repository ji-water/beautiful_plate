
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage3_submitClick : MonoBehaviour
{
    //제출 버튼 + 점수관리
    public Text scoreText;
    public static int score;

    public Text temp;
    public Text temp2;
    public Text finalScoreText;

    private stage3_timerManage scriptTimer;
    // public GameObject Slider;
    public GameObject tutoStartBut;
    public GameObject clone;

    public static int submitCount;
    public int Nplating = 1;
    public static int scoreSum;


    public static bool submitOn ;

    public static int hintCount;

    public GameObject clear;
    public GameObject fail;

    public static bool sliderStopped ;

    public GameObject endingBut;
    public GameObject retryBut;
    public GameObject mainBut;

    //난이도
    private float standard1 = 1f; //기준 점수 깎이는 기준
    private float standard2 = 0.2f; //100원깎이는기준

    public string[] platingResult; //제출한 요리 순서 + 가격
    public GameObject textclone;
    public Canvas Canvas_result;

    // Start is called before the first frame update
    void Start()
    {

        standard1 = 1f;
        standard2 = 0.2f;

        submitOn = false;
        sliderStopped = false;
        submitCount = 0;
        scoreSum = 0;
        Nplating = 1;
        hintCount = 0;

        score = 0;
        SetScoreText(0);

        // scriptTimer = Slider.GetComponent<stage1_timerManage>();
        scriptTimer = tutoStartBut.GetComponent<stage3_timerManage>();

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

        if (stage3_timerManage.currentSample == "platingSample1")
            checkPlating1();
        else if (stage3_timerManage.currentSample == "platingSample2")
            checkPlating2();
        else if (stage3_timerManage.currentSample == "platingSample3")
            checkPlating3();
        else if (stage3_timerManage.currentSample == "platingSample4")
            checkPlating4();
        else if (stage3_timerManage.currentSample == "platingSample5")
            checkPlating5();
        else if (stage3_timerManage.currentSample == "platingSample6")
            checkPlating6();
        //else if (stage3_timerManage.currentSample == "platingSample7")
            //checkPlating7();
        //else if (stage3_timerManage.currentSample == "platingSample8")
            //checkPlating8();


        submitCount++;
        Nplating++;

        if (score >= 20000 && submitCount <= 5)
        {
            if (stage3_catManage.catOn)
            {
                GameObject obstacle = GameObject.Find("cat(Clone)");
                Destroy(obstacle);
            }

            //클리어
            sceneMoving.ClearStage(3);
            scriptTimer.startslider = false;
            sliderStopped = true;
            Instantiate(clear, new Vector3(0.0f, 0.0f, -1f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
            finalScoreText.gameObject.SetActive(true);
            finalScoreText.text = "최종점수 : " + score.ToString() + "원";

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
        else if ((score < 20000) && (submitCount == 5))
        {
            if (stage3_catManage.catOn)
            {
                GameObject obstacle = GameObject.Find("cat(Clone)");
                Destroy(obstacle);
            }
            //실패
            scriptTimer.startslider = false;
            sliderStopped = true;
            Instantiate(fail, new Vector3(0.0f, 0.0f, -1f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
            finalScoreText.gameObject.SetActive(true);
            finalScoreText.text = "최종점수 : " + score.ToString() + "원";

            retryBut.SetActive(true);
            mainBut.SetActive(true);

            

            //점수 기록 출력
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
            Invoke("submitStartTimer", 10.0f);
            Destroy(clone, 10.0f);


        }
    }

    public void submitStartTimer()
    {

        temp.gameObject.SetActive(false);
        temp2.gameObject.SetActive(false);

        scriptTimer.startslider = true;
        stage1_timeButManage.translucent.SetActive(false);
        submitOn = false;
        sliderStopped = false;
    }

    /*===================================================================== < platingSample1 > =======================================================================*/

    public void checkPlating1()
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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

    /*===================================================================== < platingSample2 > =======================================================================*/

    public void checkPlating2()
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
                        // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
                        // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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

    /*===================================================================== < platingSample3 > =======================================================================*/
    public void checkPlating3()
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
                        // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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

    /*===================================================================== < platingSample4 > =======================================================================*/
    public void checkPlating4()
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
                        // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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

    /*===================================================================== < platingSample5 > =======================================================================*/

    public void checkPlating5()
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
                        // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
                            // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
                        // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
                            // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
                        // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
                            // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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

    /*===================================================================== < platingSample6 > =======================================================================*/

    public void checkPlating6()
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
                        // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
            //minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex1].transform.position.x, tempCarrot[tempIndex1].transform.position.x), carrotAnswer[tempAnswerIndex1]);
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
                // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex2].transform.position.x, tempCarrot[tempIndex2].transform.position.x), carrotAnswer[tempAnswerIndex2]);
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
                    // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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
                        // minDist = Vector2.Distance(new Vector2(tempCarrot[tempIndex3].transform.position.x, tempCarrot[tempIndex3].transform.position.x), carrotAnswer[tempAnswerIndex3]);
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

}