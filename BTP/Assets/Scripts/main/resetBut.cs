using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetBut : MonoBehaviour
{
    int count;

    private void Start()
    {
        count = 0;
    }

    private void OnMouseDown()
    {
        count++;
        if (count > 3)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Main");
        }

    }
}
