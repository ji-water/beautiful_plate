using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_inactiveHint : MonoBehaviour
{
    private Transform temp;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnMouseDown()
    {
        if (stage1_checkHint.hintOn)
        {
            for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
            {
                stage1_plating.platedParent.transform.GetChild(i).gameObject.SetActive(true);
            }

            stage1_checkHint.allTransparent.SetActive(false);


            Destroy(stage1_checkHint.hintSample.gameObject);
            stage1_checkHint.hintOn = false;
        }
    }
}
