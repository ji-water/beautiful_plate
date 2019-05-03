using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage3_TimerManager : MonoBehaviour
{
    public Slider TimerSlider;
    int time;

    // Start is called before the first frame update
    void Start()
    {
        time = 180; //3분?
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (true)
        {
            if (time <= 0)
                break;
            yield return new WaitForSeconds(1);
            time--;
            TimerSlider.value -= 1;
        }
    }
    
}
