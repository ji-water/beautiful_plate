using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoPause : MonoBehaviour
{
    GameObject donttouch;
    GameObject tuto_graphic;
    GameObject Main;
    GameObject retry;

    static bool PauseON;

    // Start is called before the first frame update
    void Start()
    {
        PauseON = false;

        donttouch = GameObject.Find("donttouch_back");
        tuto_graphic = GameObject.Find("tuto_graphic_parent");
        Main = GameObject.Find("Main");
        retry = GameObject.Find("tutorial");

        donttouch.SetActive(false);
        Main.SetActive(false);
        retry.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!PauseON)
        {
            donttouch.SetActive(true);
            Main.SetActive(true);
            retry.SetActive(true);
            tuto_graphic.SetActive(false);
            PauseON = true;
        }
        else
        {
            donttouch.SetActive(false);
            Main.SetActive(false);
            retry.SetActive(false);
            tuto_graphic.SetActive(true);
            PauseON = false;
        }
    }
}
