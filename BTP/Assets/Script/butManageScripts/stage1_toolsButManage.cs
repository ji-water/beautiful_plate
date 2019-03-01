using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_toolsButManage : MonoBehaviour
{
    //도구들에 붙어있음
    //도구와으 상호작용 관리

    private stage1_ingredient scriptIngredient;
    public GameObject gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        scriptIngredient = gamemanager.GetComponent<stage1_ingredient>();
    }


    private void OnMouseDown()
    {  /*------------------------------후라이팬 상호작용(grill)--------------------------*/
        if (gameObject.name == "pan_But") {
            //touched재료가 아스파라거스일때 후라이팬 버튼 클릭시
            //현재 재료칸에 구워진 아스파라거스 활성화 시키고
            //현재 재료칸에 있던 touched아스파라거스 비활성화
           
            //touchedName 변수를 bakedAsparagus로 바꿈

            //도구 이용한 재료를 담는 배열이 잇는게 좋겟다 ->touchedwithtool[] 만들어서 다른 재료 터치될때마다 비활성화해야할듯.
            //

            //그 후 plating.cs에서 tochedName이 bakesAsparagus일때 해당 오브젝트 생성하도록하고
            //->touchedName이 baked아스파라거스일동안 계속 생성할 수 있되, ,생성할때마다 아스파라거스 갯수를 깎는다.
            //복원할때도 아스파라거스 개수

            if (scriptIngredient.touchedIngredients[11].activeSelf)
            {//아스파라거스+그릴
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[0].SetActive(true);
                scriptIngredient.touchedIngredients[11].SetActive(false);
                stage1_plating.touchedName = "touchedAsparagus_grill";
            }
            else if (scriptIngredient.touchedIngredients[13].activeSelf)
            {//브로콜리+그릴
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[1].SetActive(true);
                scriptIngredient.touchedIngredients[13].SetActive(false);
                stage1_plating.touchedName = "touchedBroccoli_grill";
            }
            else if (scriptIngredient.touchedWithTools[2].activeSelf)
            {//당근+칼 이 활성화되어있을때 grill 누를시
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[3].SetActive(true);//당근+칼+그릴
                scriptIngredient.touchedWithTools[2].SetActive(false);//당근+칼
                stage1_plating.touchedName = "touchedCarrot_chop_grill";
            }
        }
        /*----------------------------------------칼 상호작용(chop)--------------------------------------*/
        if (gameObject.name == "knife_But") {

            if (scriptIngredient.touchedIngredients[14].activeSelf)
            {//당근+칼
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[2].SetActive(true);
                scriptIngredient.touchedIngredients[14].SetActive(false);
                stage1_plating.touchedName = "touchedCarrot_chop";
            }
            else if (scriptIngredient.touchedIngredients[15].activeSelf)
            {//방울토마토+칼
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[5].SetActive(true);
                scriptIngredient.touchedIngredients[15].SetActive(false);
                stage1_plating.touchedName = "touchedCherrytomato_chop";
            }
            else if (scriptIngredient.touchedIngredients[16].activeSelf)
            {//오이+칼
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[6].SetActive(true);
                scriptIngredient.touchedIngredients[16].SetActive(false);
                stage1_plating.touchedName = "touchedCucumber_chop";
            }
            else if (scriptIngredient.touchedIngredients[17].activeSelf)
            {//파프리카+칼
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[8].SetActive(true);
                scriptIngredient.touchedIngredients[17].SetActive(false);
                stage1_plating.touchedName = "touchedPaprika_chop";
            }
            else if (scriptIngredient.touchedIngredients[19].activeSelf)
            {//사과+칼
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[9].SetActive(true);
                scriptIngredient.touchedIngredients[19].SetActive(false);
                stage1_plating.touchedName = "touchedApple_chop";
            }
            else if (scriptIngredient.touchedIngredients[20].activeSelf)
            {//아보카도+칼
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[10].SetActive(true);
                scriptIngredient.touchedIngredients[20].SetActive(false);
                stage1_plating.touchedName = "touchedAvocado_chop";
            }
            else if (scriptIngredient.touchedIngredients[23].activeSelf)
            {//레몬+칼
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[11].SetActive(true);
                scriptIngredient.touchedIngredients[23].SetActive(false);
                stage1_plating.touchedName = "touchedLemon_chop";
            }
            else if (scriptIngredient.touchedIngredients[24].activeSelf)
            {//오렌지+칼
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[12].SetActive(true);
                scriptIngredient.touchedIngredients[24].SetActive(false);
                stage1_plating.touchedName = "touchedOrange_chop";
            }
            else if (scriptIngredient.touchedIngredients[25].activeSelf)
            {//딸기+칼
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[13].SetActive(true);
                scriptIngredient.touchedIngredients[25].SetActive(false);
                stage1_plating.touchedName = "touchedStrawberry_chop";
            }
        
        }
        /*------------------------------착즙기 상호작용(juice)--------------------------*/
        if (gameObject.name == "juicer_But") {

            if (scriptIngredient.touchedIngredients[21].activeSelf)
            {//블루베리+착즙기
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[14].SetActive(true);
                scriptIngredient.touchedIngredients[21].SetActive(false);
                stage1_plating.touchedName = "touchedBlueberry_juice";
            }
            else if (scriptIngredient.touchedIngredients[24].activeSelf)
            {//오렌지+착즙기
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[15].SetActive(true);
                scriptIngredient.touchedIngredients[24].SetActive(false);
                stage1_plating.touchedName = "touchedOrange_juice";
            }
            else if (scriptIngredient.touchedIngredients[25].activeSelf)
            {//딸기+착즙기
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[16].SetActive(true);
                scriptIngredient.touchedIngredients[25].SetActive(false);
                stage1_plating.touchedName = "touchedStrawberry_juice";
            }
        }
        /*------------------------------채칼 상호작용(slice)--------------------------*/
        if (gameObject.name == "grater_But") {
            if (scriptIngredient.touchedIngredients[14].activeSelf)
            {//당근+채칼
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[4].SetActive(true);
                scriptIngredient.touchedIngredients[14].SetActive(false);
                stage1_plating.touchedName = "touchedCarrot_slice";
            }
            else if (scriptIngredient.touchedIngredients[16].activeSelf)
            {//오이+채칼
                //sound
                gameObject.GetComponent<AudioSource>().Play();

                scriptIngredient.touchedWithTools[7].SetActive(true);
                scriptIngredient.touchedIngredients[16].SetActive(false);
                stage1_plating.touchedName = "touchedCucumber_slice";
            }
        }
    }
}
