using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_tissueManage : MonoBehaviour
{

    public static GameObject chocoLineDrawer;
    public static GameObject Collider;
    private GameObject clone;

    private void Start()
    {
        chocoLineDrawer = GameObject.Find("chocoLineDrawer(Clone)");
        
       // scriptIngredient = gamemanager.GetComponent<stage1_ingredient>();
    }
    //plated재료마다 이 스크립트,폴리건콜라이더 붙어있어야함. 지금은 아스파라거스에만 붙어있음
    private void OnMouseDown()
    {
        if (stage1_clicktissue.tissueClicked) {

         
                Debug.Log(gameObject.name);
                Destroy(gameObject); ///현재 click된 오브젝트 삭제
             //   restockCount(gameObject.name); //지운 재료 갯수 +1
            stage1_countManage.findRestockIngredient(gameObject.name);
       

            //stage1_clicktissue.tissueClicked = false;
            // stage1_clicktissue.platedColliderInactive();

            //for (int i = 0; i < stage1_plating.platedParent.transform.childCount; i++)
            //{
            //    clone = stage1_plating.platedParent.transform.GetChild(i).gameObject;
            //    clone.GetComponent<PolygonCollider2D>().enabled = false;
            //}
        }
       // for (int j = 0; j < coltouched.Length; j++) Debug.Log(coltouched[i]);
    }

    //물티슈로 지운 재료 Count+1
    //public void restockCount(string name)
    //{
    //    if ((name == "platedAsparagus(Clone)")||(name =="platedAsparagus_grill(Clone)"))
    //    {
    //        if (stage1_countManage.ingredientCount[11] == 0) stage1_VegeButManage.RestockAsparagus();
    //        stage1_countManage.ingredientCount[11]++;
    //        //Debug.Log(stage1_countManage.asparagusCount);
    //    }
       
    //    else if (name == "platedBasil(Clone)") {
    //        if (stage1_countManage.ingredientCount[12] == 0) stage1_VegeButManage.RestockBasil();
    //        stage1_countManage.ingredientCount[12]++;
    //    }
    //    else if ((name == "platedBroccoli(Clone)")||(name=="platedBroccoli_grill(Clone)"))
    //    {
    //        if (stage1_countManage.ingredientCount[13] == 0) stage1_VegeButManage.RestockBroccoli();
    //        stage1_countManage.ingredientCount[13]++;
    //    }
    //    else if ((name == "platedCarrot_chop(Clone)")|| (name == "platedCarrot_chop_grill(Clone)")|| (name == "platedCarrot_slice(Clone)"))
    //    {
    //        if (stage1_countManage.ingredientCount[14] == 0) stage1_VegeButManage.RestockCarrot();
    //        stage1_countManage.ingredientCount[14]++;
    //    }
    //    else if (name == "platedCherrytomato(Clone)")
    //    {
    //        if (stage1_countManage.ingredientCount[15] == 0) stage1_VegeButManage.RestockCherrytomato();
    //        stage1_countManage.ingredientCount[15]++;
    //    }
    //    else if (name == "platedCucumber(Clone)")
    //    {
    //        if (stage1_countManage.ingredientCount[16] == 0) stage1_VegeButManage.RestockCucumber();
    //        stage1_countManage.ingredientCount[16]++;
    //    }
    //    else if (name == "platedPaprika(Clone)")
    //    {
    //        if (stage1_countManage.ingredientCount[17] == 0) stage1_VegeButManage.RestockPaprika();
    //        stage1_countManage.ingredientCount[17]++;
    //    }
    //    else if (name == "platedRadishsprout(Clone)")
    //    {
    //        if (stage1_countManage.ingredientCount[18] == 0) stage1_VegeButManage.RestockRadishsprout();
    //        stage1_countManage.ingredientCount[18]++;
    //    }
    //}


}
