using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_swatterClick : MonoBehaviour
{

    public static bool swatterClicked = false;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    private void OnMouseDown()
    {
        swatterClicked = true;
        Destroy(gameObject);
    }
}
