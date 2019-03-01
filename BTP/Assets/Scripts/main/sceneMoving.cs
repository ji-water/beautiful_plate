using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneMoving : MonoBehaviour
{
    public static void ClearStage(int stage)
    {
        PlayerPrefs.SetInt("clear"+(stage), 1);
    }

    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(gameObject);
    }

    
    public void PlayStage(string name)
    {
        Debug.Log("playstage" + name);
        SceneManager.LoadScene(name);
    }
}
