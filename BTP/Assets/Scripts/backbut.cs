using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backbut : MonoBehaviour
{
    GameObject title1, title2;

    private void Start()
    {
        title1 = GameObject.Find("title1");
        title2 = GameObject.Find("title2");
    }
    private void OnMouseDown()
    {
        title1.SetActive(true);
        title2.SetActive(false);
    }
}
