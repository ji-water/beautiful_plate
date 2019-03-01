using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//각 스테이지 버튼마다 붙음
public class Stage_load : MonoBehaviour
{
    GameObject sceneManager;

    void Start()
    {
        sceneManager = GameObject.Find("sceneManager");
    }
    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        sceneManager.GetComponent<sceneMoving>().PlayStage(gameObject.name);
    }
}
