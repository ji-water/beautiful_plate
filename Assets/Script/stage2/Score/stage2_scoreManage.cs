﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage2_scoreManage : MonoBehaviour
{

    public Text scoreText;

    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        SetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetScoreText() {

        scoreText.text = score.ToString();

    }
}
