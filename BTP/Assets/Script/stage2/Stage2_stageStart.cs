using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_stageStart : MonoBehaviour
{
    public GameObject StartStage;
    public GameObject startBut;
    public static bool Stage_Start;

    void Start()
    {
        Time.timeScale = 0;
        Stage_Start = false;
    }

    private void OnMouseDown()
    {
        Stage_Start = true;
        Time.timeScale = 1.0f;
        startBut.SetActive(false);
        StartStage.SetActive(false);
    }
}
