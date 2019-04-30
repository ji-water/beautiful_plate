using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2_stageFinish : MonoBehaviour
{
    public Text scoreText;

    public Text resultText;
    public Text resultScore;
    public Text finalText;
    public Text finalScore;

    public GameObject Fail;
    public GameObject Success;

    private stage2_timerManage scriptTimer;
    public GameObject Slider;

    GameObject FinishParent;
    GameObject nextStageBut;
    GameObject retryBut;
    GameObject mainBut;

    public static int[] score ;

    void Start()
    {
        score = new int[5];
        for (int i = 0; i < 5; i++)
            score[i] = 0;

        FinishParent = GameObject.Find("FinishParent");
        scriptTimer = Slider.GetComponent<stage2_timerManage>();
        nextStageBut = FinishParent.transform.Find("stage3").gameObject;
        retryBut = FinishParent.transform.Find("stage2").gameObject;
        mainBut = FinishParent.transform.Find("Main").gameObject;

        nextStageBut.SetActive(false);
        retryBut.SetActive(false);
        mainBut.SetActive(false);

    }

    public void StageFinish()
    {
        Time.timeScale = 0;
        scriptTimer.slider.enabled = false;

     
        if (int.Parse(scoreText.text) >= 20000)
        {
            sceneMoving.ClearStage(2);
            Success.SetActive(true);
            nextStageBut.SetActive(true);
        
         }

        else
        {
            Fail.SetActive(true);
        }

        retryBut.SetActive(true);
        mainBut.SetActive(true);

        for (int i = 0; i < 5; i++)
        {
            resultScore.text += score[i].ToString() + "\n";
        }

        resultText.gameObject.SetActive(true);
        resultScore.gameObject.SetActive(true);

        finalScore.text = scoreText.text + "원";

        finalText.gameObject.SetActive(true);
        finalScore.gameObject.SetActive(true);
    }

    
}
