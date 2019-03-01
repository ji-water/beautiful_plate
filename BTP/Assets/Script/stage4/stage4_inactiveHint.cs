using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage4_inactiveHint : MonoBehaviour
{
    private Transform temp;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnMouseDown()
    {
        if (stage4_checkHint.hintOn)
        {
            for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
            {
                stage1_plating.platedParent.transform.GetChild(i).gameObject.SetActive(true);
            }

            stage4_checkHint.allTransparent.SetActive(false);

            
            Destroy(stage4_checkHint.hintSample.gameObject);
            stage4_checkHint.hintOn = false;
        }
    }
}
