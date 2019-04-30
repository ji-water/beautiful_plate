using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_timeButManage : MonoBehaviour
{
    //일시정지버튼, 재시작 버튼에 붙음

    public static GameObject translucent;
    public GameObject restart;
    public GameObject retry;
    public GameObject main;

    // Start is called before the first frame update
    void Start()
    {
      translucent = GameObject.Find("translucent");

      translucent.SetActive(true);
      restart.SetActive(false);
        retry.SetActive(false);
        main.SetActive(false);

        
    }

    private void OnMouseDown()
    {
        if (gameObject.name == "pause")
        {
            Debug.Log("일시정지");
            Time.timeScale = 0;
           translucent.SetActive(true); //화면클릭막음
            restart.SetActive(true);
            retry.SetActive(true);
            main.SetActive(true);
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
