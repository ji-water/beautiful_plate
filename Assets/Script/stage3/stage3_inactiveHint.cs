using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3_inactiveHint : MonoBehaviour
{
    private Transform temp;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnMouseDown()
    {
        if (stage3_checkHint.hintOn)
        {
            for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
            {
                stage1_plating.platedParent.transform.GetChild(i).gameObject.SetActive(true);
            }

            stage3_checkHint.allTransparent.SetActive(false);


            Destroy(stage3_checkHint.hintSample.gameObject);
            stage3_checkHint.hintOn = false;
        }
    }
}
