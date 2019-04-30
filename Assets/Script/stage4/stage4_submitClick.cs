
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage4_submitClick : MonoBehaviour
{
    //제출 버튼 + 점수관리
    public Text scoreText;
    public static int score;

    public Text temp;
    public Text temp2;
    public Text finalScoreText;

    private stage4_timerManage scriptTimer;
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
        scriptTimer = tutoStartBut.GetComponent<stage4_timerManage>();
     
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

        //hint count
        stage4_checkHint.hintCount.SetActive(true);
        stage4_checkHint.hintCount.GetComponent<SpriteRenderer>().sprite = Resources.Load("Hint/hint3", typeof(Sprite)) as Sprite;

        if (stage4_timerManage.currentSample == "platingSample1")
            checkPlating1();
        else if (stage4_timerManage.currentSample == "platingSample2")
            checkPlating2();
        else if (stage4_timerManage.currentSample == "platingSample3")
            checkPlating3();
        else if (stage4_timerManage.currentSample == "platingSample4")
            checkPlating4();
        else if (stage4_timerManage.currentSample == "platingSample5")
            checkPlating5();
        else if (stage4_timerManage.currentSample == "platingSample6")
            checkPlating6();


        submitCount++;
        Nplating++;

        if (score >= 20000 && submitCount <= 5)
        {
            //클리어
            sceneMoving.ClearStage(4);

            scriptTimer.startslider = false;
            sliderStopped = true;
            Instantiate(clear, new Vector3(0.0f, 0.0f,-1f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
            finalScoreText.gameObject.SetActive(true);
            finalScoreText.text = "최종점수 : " + score.ToString() + "원";
            if (stage4_speechManage.speechOn)
            {
                GameObject obstacle = GameObject.Find("speech(Clone)");
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
            if (stage4_speechManage.speechOn)
            {
                GameObject obstacle = GameObject.Find("speech(Clone)");
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
        sliderStopped =false;
    }

    /*===================================================================== < platingSample1 > =======================================================================*/

    public void checkPlating1() {

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

    /*===================================================================== < platingSample2 > =======================================================================*/

    public void checkPlating2()
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
            else{
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

    /*===================================================================== < platingSample3 > =======================================================================*/
    public void checkPlating3()
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
        GameObject[] tempBroccoli = new GameObject[5];

        //기준:600원
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
        int broccoliCount = 0;

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
            else if (stage1_plating.platedParent.transform.GetChild(i).gameObject.name == "platedBroccoli_grill(Clone)")
            {
                tempBroccoli[broccoliCount] = stage1_plating.platedParent.transform.GetChild(i).gameObject;
                broccoliCount++;
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
        if ((tempBroccoli[0] != null) && (tempCheese[0] != null) && (tempIvy != null) && (tempCream[0] != null))
        {
            for (int i = 0; i < broccoliCount; i++)
            {
                if (tempBroccoli[i].transform.position.z > tempIvy.transform.position.z) platingScore -= 100;

                for (int j = 0; j < creamCount; j++)
                {
                    if (tempBroccoli[i].transform.position.z > tempCream[j].transform.position.z) platingScore -= 100;
                }
                for (int j = 0; j < cheeseCount; j++)
                {
                    if (tempBroccoli[i].transform.position.z > tempCheese[j].transform.position.z) platingScore -= 100;
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

        // 있어야할 재료가 모자르면 -(600÷해당 재료 전체갯수)*모자른 갯수
        if (IvyCount == 0) platingScore -= 600;
        if (basilCount == 0) platingScore -= 600;
        if (ketchupCount == 0) platingScore -= 600;
        if (orangejuiceCount == 0) platingScore -= 600;
        if (broccoliCount == 0) platingScore -= 600;

        if (blueberryCount == 0)
            platingScore -= 600;
        else if (blueberryCount == 1)
            platingScore -= 300;

        if (cherryCount == 0)
            platingScore -= 600;
        else if (cherryCount == 1)
            platingScore -= 300;

        if (strawberryjuiceCount == 0)
            platingScore -= 600;
        else if (strawberryjuiceCount == 1)
            platingScore -= (300);

        if (blueberryjuiceCount == 0)
            platingScore -= 600;
        else if (blueberryjuiceCount > 0 && blueberryjuiceCount < 3)
            platingScore -= (200) * (3 - blueberryjuiceCount);

        if (creamCount == 0)
            platingScore -= 600;
        else if (creamCount > 0 && creamCount < 5)
            platingScore -= (100) * (5 - creamCount);

        if (cheeseCount == 0)
            platingScore -= 600;
        else if (cheeseCount > 0 && cheeseCount < 5)
            platingScore -= (100) * (5 - cheeseCount);


        Debug.Log("모자란갯수,필요없는재료,순서체크후" + platingScore);

        float minDist = 100f;


        Vector2 basilAnswer = new Vector2(-0.01f, -0.19f);
        Vector2 ketchupAnswer = new Vector2(0.02f, 2.82f);
        Vector2 orangejuiceAnswer = new Vector2(-0.03f, 3f);
        Vector2 broccoliAnswer = new Vector2(-0.02f, 1.62f);

        Vector2 cherry1Answer = new Vector2(-1.78f, 0.28f);
        Vector2 cherry2Answer = new Vector2(1.69f, 0.28f);
        Vector2[] cherryAnswer = { cherry1Answer, cherry2Answer };

        Vector2 blueberry1Answer = new Vector2(-1.29f, -1.89f);
        Vector2 blueberry2Answer = new Vector2(1.27f, -1.81f);
        Vector2[] blueberryAnswer = { blueberry1Answer, blueberry2Answer };

        Vector2 blueberryjuice1Answer = new Vector2(-1.62f, -3.46f);
        Vector2 blueberryjuice2Answer = new Vector2(0.05f, -3.49f);
        Vector2 blueberryjuice3Answer = new Vector2(1.78f, -3.41f);
        Vector2[] blueberryjuiceAnswer = { blueberryjuice1Answer, blueberryjuice2Answer, blueberryjuice3Answer };

        Vector2 strawberryjuice1Answer = new Vector2(-2.31f, 2.01f);
        Vector2 strawberryjuice2Answer = new Vector2(2.08f, 2.14f);
        Vector2[] strawberryjuiceAnswer = { strawberryjuice1Answer, strawberryjuice2Answer };

        Vector2 cheese1Answer = new Vector2(-0.06f, 1.53f); //맨위
        Vector2 cheese2Answer = new Vector2(-1.26f, -2f); //중간1
        Vector2 cheese3Answer = new Vector2(1.28f, -2f); //중간2
        Vector2 cheese4Answer = new Vector2(-1.76f, -0.14f); //아래1
        Vector2 cheese5Answer = new Vector2(1.72f, -0.09f); //아래2
        Vector2[] cheeseAnswer = { cheese1Answer, cheese2Answer, cheese3Answer, cheese4Answer, cheese5Answer };

        Vector2 cream1Answer = new Vector2(-0.06f, 1.53f);
        Vector2 cream2Answer = new Vector2(-1.26f, -2f); //중간1
        Vector2 cream3Answer = new Vector2(1.28f, -2f); //중간2
        Vector2 cream4Answer = new Vector2(-1.76f, -0.14f); //아래1
        Vector2 cream5Answer = new Vector2(1.72f, -0.09f); //아래2
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
            if (minDist > standard1) platingScore -= 600;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("basil위치체크후" + platingScore);
            minDist = 100f;
            if (basilCount > 1)
            {
                platingScore -= (basilCount - 1) * (600);
            }
        }

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
            if (minDist > standard1) platingScore -= 600;
            else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("broccoli위치체크후" + platingScore);
            minDist = 100f;
            if (broccoliCount > 1)
            {
                platingScore -= (broccoliCount - 1) * (600);
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
            if (minDist > 1f) platingScore -= 600;
            // else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("ketchup위치체크후" + platingScore);
            minDist = 100f;
            if (ketchupCount > 1)
            {
                platingScore -= (ketchupCount - 1) * (600);
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
            if (minDist > 3f) platingScore -= 600;
            // else platingScore -= (int)(minDist / standard2) * 100;
            Debug.Log("orangejuice위치체크후" + platingScore);
            minDist = 100f;
            if (orangejuiceCount > 1)
            {
                platingScore -= (orangejuiceCount - 1) * (600);
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
            if (minDist > standard1) platingScore -= 600;
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
                if (minDist > standard1) platingScore -= 600;
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
            if (minDist > standard1) platingScore -= 600;
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
                if (minDist > standard1) platingScore -= 600;
                else platingScore -= (int)(minDist / standard2) * 100;
                Debug.Log("블루베리2위치체크후" + platingScore);
                minDist = 100f;
                if (blueberryCount > 2)
                {
                    platingScore -= (blueberryCount - 2) * (300);
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
            if (minDist > 2f) platingScore -= 600;
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
                Debug.Log(minDist);
                Debug.Log(tempIndex2 + "  " + tempAnswerIndex2);
                if (minDist > 2f) platingScore -= 600;
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
                    Debug.Log(minDist);
                    Debug.Log(tempIndex3 + "  " + tempAnswerIndex3);
                    if (minDist > 2f) platingScore -= 600;
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
            if (minDist > 2.5f) platingScore -= 600;
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
                if (minDist > 2.5f) platingScore -= 600;
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
            if (minDist > 2f) platingScore -= 600;
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
                if (minDist > 2f) platingScore -= 600;
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
                    if (minDist > 2f) platingScore -= 600;
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
                        if (minDist > 2f) platingScore -= 600;
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
                            if (minDist > 2f) platingScore -= 600;
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
            if (minDist > 2f) platingScore -= 600;
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
                if (minDist > 2f) platingScore -= 600;
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
                    if (minDist > 2f) platingScore -= 600;
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
                        if (minDist > 2f) platingScore -= 600;
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
                            if (minDist > 2f) platingScore -= 600;
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
        int tempSubmitCount = submitCount + 1;
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
        tempBroccoli = null;
    }

    /*===================================================================== < platingSample4 > =======================================================================*/
    public void checkPlating4()
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

    /*===================================================================== < platingSample5 > =======================================================================*/

    public void checkPlating5()
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

    /*===================================================================== < platingSample6 > =======================================================================*/

    public void checkPlating6()
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
            platingScore -= 300;

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
