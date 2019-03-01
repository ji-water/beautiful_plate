using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_clicktrash : MonoBehaviour
{
    //trashcan에 붙음
    public static bool trashcanClicked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        //trashcanClicked =true;
        stage1_plating.deleteAll();
    }
}
