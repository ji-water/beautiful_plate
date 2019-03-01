using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage5_inactiveHint : MonoBehaviour
{
    private Transform temp;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnMouseDown()
    {
        if (stage5_checkHint.hintOn)
        {
            for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
            {
                stage1_plating.platedParent.transform.GetChild(i).gameObject.SetActive(true);
            }

            stage5_checkHint.allTransparent.SetActive(false);

            
            Destroy(stage5_checkHint.hintSample.gameObject);
            stage5_checkHint.hintOn = false;
        }
    }
}
