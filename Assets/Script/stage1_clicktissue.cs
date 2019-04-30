using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tissue에 붙음
//티슈 클릭시 활성화되었던 touched재료 비활성화
//touchedName 저장되었던거 null
public class stage1_clicktissue : MonoBehaviour
{
    public static bool tissueClicked = false;
    private stage1_ingredient scriptIngredient;
    public GameObject gamemanager;
    public static GameObject clone;
    public static GameObject colliderclone;
    // Start is called before the first frame update
    void Start()
    {
        tissueClicked = false;
        scriptIngredient = gamemanager.GetComponent<stage1_ingredient>();
    }
    //tissue에 붙어있음

    // Update is called once per frame
    private void OnMouseDown()
    {
        scriptIngredient.touchedTissue.SetActive(true);
        //티슈 누르면 접시 위 재료들 콜라이더 활성화
        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
          
               
            clone = stage1_plating.platedParent.transform.GetChild(i).gameObject;
            //if (clone.gameObject.name == "caramelLineDrawer(Clone)")
            //{
            //    for (int j = 0; j < clone.transform.childCount; j++)
            //    {
            //        colliderclone = clone.transform.GetChild(j).gameObject;
            //        colliderclone.GetComponent<BoxCollider>().enabled = true;
            //       // colliderclone.GetComponent<CircleCollider2D>().enabled = true;
            //    }
            //}
             clone.GetComponent<PolygonCollider2D>().enabled = true;
        }

        //현재 touched된 재료(왼쪽 밑에 뜨는) 비활성화
        scriptIngredient.touchedInactive();
        scriptIngredient.touchedWithToolsInactive();
        stage1_plating.touchedName = null;


        tissueClicked = true;
       
        Debug.Log("티슈선택");
    }
    
    //접시 위 재료들 콜라이더 비활성화
    public static void platedColliderInactive() {
        for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
        {
            clone = stage1_plating.platedParent.transform.GetChild(i).gameObject;
            clone.GetComponent<PolygonCollider2D>().enabled = false;
        }

    }
   
}
