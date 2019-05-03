using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//버튼탭을 관리하는 매니져
public class stage3_ButtonManager : MonoBehaviour
{
    static GameObject SELECTBUT;
    static GameObject TABBUT;

    void Start()
    {
        SELECTBUT = GameObject.Find("SELECT_BUT");
        TABBUT = GameObject.Find("TAB_BUT");

        ButtonActivate();
    }

    //모든 버튼탭을 끈다 (재료를 보여줄때)
    static public void ButtonUnActivate(int but)
    {
        SELECTBUT.SetActive(false);
        TABBUT.SetActive(true);
        stage3_BackButManager.setButstate(but);
        stage3_NextBut.setButstate(but);
    }

    //모든 버튼탭을 켠다 (재료를 끌때)
    static public void ButtonActivate()
    {
        SELECTBUT.SetActive(true);
        TABBUT.SetActive(false);
        stage3_BackButManager.setButstate(0);
        stage3_NextBut.setButstate(0);
    }
    
}
