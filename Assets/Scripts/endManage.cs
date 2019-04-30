using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endManage : MonoBehaviour
{
    GameObject end;
    GameObject Main;

    static int touch;
    void Start()
    {
        touch = 0;
        end = GameObject.Find("end");
        Main = GameObject.Find("Main");
    }

    private void OnMouseDown()
    {
        switch (touch)
        {
            case 0:
                end.SetActive(false);
                touch++;
                break;
            case 1:
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
