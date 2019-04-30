using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManage : MonoBehaviour
{
    static GameObject startStory;

    // Start is called before the first frame update
    void Start()
    {
        startStory = GameObject.Find("startStory");
        startStory.SetActive(false);
 
        //스테이지가 한번도 실행안됐을때만 스토리 출력
        if (!PlayerPrefs.HasKey(Application.loadedLevelName))
        {
            startStory.SetActive(true);
        }

        PlayerPrefs.SetInt(Application.loadedLevelName, 1);
    }
   
}
