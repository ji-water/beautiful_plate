using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage2_timeButManage : MonoBehaviour
{
    //일시정지버튼, 재시작, 재도전, 다음스테이지 버튼에 붙음

    public static GameObject translucent;
    public GameObject restart;
    public GameObject retry;
    public GameObject main;
    GameObject FinishParent;

    // Start is called before the first frame update
    void Start()
    {
      translucent = GameObject.Find("translucent");
       // restart = GameObject.Find("restart");

      translucent.SetActive(true);
      restart.SetActive(false);
        retry.SetActive(false);
        main.SetActive(false);

        FinishParent = GameObject.Find("FinishParent");


    }

    private void OnMouseDown()
    {
        if (gameObject.name == "pause")
        {
            
            Time.timeScale = 0;
            translucent.SetActive(true); //화면클릭막음
            restart.SetActive(true);
            retry.SetActive(true);
            main.SetActive(true);
            Debug.Log("일시정지");
        }
        else if (gameObject.name == "restart")
        {
            Time.timeScale = 1;
            translucent.SetActive(false);
            restart.SetActive(false);
            retry.SetActive(false);
            main.SetActive(false);
        }

    }
}
