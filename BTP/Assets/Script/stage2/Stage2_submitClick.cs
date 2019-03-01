using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2_submitClick : MonoBehaviour
{
    //제출 버튼 + 점수관리
    public Text scoreText;
    public static int score;

    public Text temp;
    public Text temp2;

    private stage2_timerManage scriptTimer;
    public GameObject Slider;
    public GameObject clone;

    public static int submitCount = 0;
    public int Nplating = 1;
    public static int scoreSum = 0;
    // public string[] savedPlating;

    public static bool submitOn = true;

    public static int hintCount = 0;

    private Stage2_stageFinish finish_script;
    GameObject finishParent;


    // Start is called before the first frame update
    void Start()
    {
        submitOn = true;
        submitCount = 0;
        scoreSum = 0;
        score = 0;
        SetScoreText(0);
        hintCount = 0;

        finishParent = GameObject.Find("FinishParent");
        finish_script = finishParent.GetComponent<Stage2_stageFinish>();

        scriptTimer = Slider.GetComponent<stage2_timerManage>();

        temp.text = (submitCount + 1).ToString();
        // temp = GameObject.Find("platingText").GetComponent<Text>();
        //temp2 = GameObject.Find("tempText").GetComponent<Text>();


    }

    public void SetScoreText(int sumscore)
    {
        score += sumscore;
        scoreText.text = score.ToString();


    }

    private void OnMouseDown()
    {

        //sound
        gameObject.GetComponent<AudioSource>().Play();

        hintCount = 0; //힌트 횟수 초기화

        if (stage2_timerManage.currentSample == "plating_1")
            checkPlating1();
        else if (stage2_timerManage.currentSample == "plating_2")
            checkPlating2();
        else if (stage2_timerManage.currentSample == "plating_3")
            checkPlating3();
        else if (stage2_timerManage.currentSample == "plating_4")
            checkPlating4();
        else if (stage2_timerManage.currentSample == "plating_5")
            checkPlating5();
        else if (stage2_timerManage.currentSample == "plating_6")
            checkPlating6();



        submitCount++;
        //Nplating++;
        stage1_plating.deleteAll();

        if (submitCount < 5)
        {

            temp.text = (submitCount + 1).ToString(); //N번째 접시 text
            temp.gameObject.SetActive(true);
            temp2.gameObject.SetActive(true);

            stage2_timeButManage.translucent.SetActive(true);
            //scriptTimer.slider.enabled = false;
            stage2_timerManage.startslider = false;

            clone = scriptTimer.ObjectRandomGenerator();

            submitOn = true;

            Invoke("submitStartTimer", 7.0f);
            Destroy(clone, 7.0f);
        }

        else
        {
            ////Stage2_stageFinish에서 끝난 후 함수 가져오기
            submitOn = true;    //방해물 안나오게 하기 위해서
            finish_script.StageFinish();
        }


    }

    public void submitStartTimer()
    {
        temp.gameObject.SetActive(false);
        temp2.gameObject.SetActive(false);

        stage2_timerManage.startslider = true;
        stage2_timeButManage.translucent.SetActive(false);
        submitOn = false;

    }

    /*===================================================================== < platingSample1 > =======================================================================*/

    public void checkPlating1()
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
                    else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
                    else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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

        Stage2_stageFinish.score[submitCount] = platingScore;

        tempSteak = null;
        tempCheddar = null;
        tempBroccoli_grill = null;
        tempRadishsprout = null;
        tempCherrytomato = null;
        tempBlueberry = null;


    }

    /*===================================================================== < platingSample2 > =======================================================================*/

    public void checkPlating2()
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
                    else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
                    else platingScore -= (int)(minDist / 0.2) * 100;
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
                        else platingScore -= (int)(minDist / 0.2) * 100;
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

        Stage2_stageFinish.score[submitCount] = platingScore;

        tempSteak = null;
        tempBroccoli = null;
        tempCheese = null;
        tempLemon_chop = null;
        tempPaprika_chop = null;
        tempAsparagus_grill = null;


    }

    /*===================================================================== < platingSample3 > =======================================================================*/
    public void checkPlating3()
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
                    else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
                    else platingScore -= (int)(minDist / 0.2) * 100;
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
                        else platingScore -= (int)(minDist / 0.2) * 100;
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

        Stage2_stageFinish.score[submitCount] = platingScore;

        tempPasta = null;
        tempBasil = null;
        tempBroccoli = null;
        tempCherry = null;
        tempCherrytomato_chop = null;
        tempPaprika_chop = null;
    }




    /*===================================================================== < platingSample4 > =======================================================================*/
    public void checkPlating4()
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
                    else platingScore -= (int)(minDist / 0.2) * 100;
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
                        else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
                    else platingScore -= (int)(minDist / 0.2) * 100;
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
                        else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
                    else platingScore -= (int)(minDist / 0.2) * 100;
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
                        else platingScore -= (int)(minDist / 0.2) * 100;
                        Debug.Log("파프리카4위치체크후" + platingScore);
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

        Stage2_stageFinish.score[submitCount] = platingScore;

        tempPasta = null;
        tempCherrytomato = null;
        tempBasil = null;
        tempCarrot_slice = null;

    }
    /*-----------------------------------------------------------------------< plating Sample5 >-----------------------------------------------------------------*/
    public void checkPlating5()
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
            if (minDist > 6.0) platingScore -= 1100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
                    else platingScore -= (int)(minDist / 0.2) * 100;
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

        Stage2_stageFinish.score[submitCount] = platingScore;

        tempBread = null;
        tempChoco = null;
        tempCream = null;
        tempStrawberry_chop = null;
        tempOrange_juice = null;
        tempBlueberry = null;


    }

    /*-----------------------------------------------------------------------< plating Sample6 >-----------------------------------------------------------------*/

    public void checkPlating6()
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
                    else platingScore -= (int)(minDist / 0.2) * 100;
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
            else platingScore -= (int)(minDist / 0.2) * 100;
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
                else platingScore -= (int)(minDist / 0.2) * 100;
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
                    else platingScore -= (int)(minDist / 0.2) * 100;
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
                        else platingScore -= (int)(minDist / 0.2) * 100;
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

        Stage2_stageFinish.score[submitCount] = platingScore;

        tempBread = null;
        tempKetchup = null;
        tempCucumber_slice = null;
        tempApple_chop = null;
        tempCarrot_chop = null;
        tempMozza = null;


    }



}


