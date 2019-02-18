using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_titlemanage : MonoBehaviour
{
    GameObject title1;

    private void Start()
    {
        title1 = GameObject.Find("title1");
        title1.SetActive(false);
    }
    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        title1.SetActive(true);
    }
}
