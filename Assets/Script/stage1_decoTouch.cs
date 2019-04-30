using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_decoTouch : MonoBehaviour
{
    public static bool syrupTouched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        syrupTouched = true;
        Debug.Log("syrup클릭됨");
    }
}
