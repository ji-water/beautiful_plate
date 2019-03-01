using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_currentTouched : MonoBehaviour
{
    //탭의 재료에 붙어있음
    //탭 재료 터치시 touchedIngredients 전부 비활성화,
    //touched재료 active

    private stage1_ingredient scriptIngredient;
   public GameObject gamemanager;
    void Start()
    {
        scriptIngredient = gamemanager.GetComponent<stage1_ingredient>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        scriptIngredient.touchedInactive(); //touchedIngredients배열 초기화,전부 비활성화
        scriptIngredient.touchedWithToolsInactive(); //도구사용한 재료 배열 전부 비활성화


        if(gameObject.name == "bread_But")
        {
            scriptIngredient.touchedIngredients[0].SetActive(true);
        }
        else if (gameObject.name == "broth_But")
        {
            scriptIngredient.touchedIngredients[1].SetActive(true);

        }
        else if (gameObject.name == "cake_But")
        {
            scriptIngredient.touchedIngredients[2].SetActive(true);

        }
        else if (gameObject.name == "dumpling_But")
        {
            scriptIngredient.touchedIngredients[3].SetActive(true);

        }
        else if (gameObject.name == "fish_But")
        {
            scriptIngredient.touchedIngredients[4].SetActive(true);

        }
        else if (gameObject.name == "Ivy_But")
        {
            scriptIngredient.touchedIngredients[5].SetActive(true);

        }
        else if (gameObject.name == "noodle_But")
        {
            scriptIngredient.touchedIngredients[6].SetActive(true);

        }
        else if (gameObject.name == "omelet_But")
        {
            scriptIngredient.touchedIngredients[7].SetActive(true);

        }
        else if (gameObject.name == "pasta_But")
        {
            scriptIngredient.touchedIngredients[8].SetActive(true);

        }
        else if (gameObject.name == "salad_But")
        {
            scriptIngredient.touchedIngredients[9].SetActive(true);

        }
        else if (gameObject.name == "steak_But")
        {
            scriptIngredient.touchedIngredients[10].SetActive(true);

        }
        else if (gameObject.name == "asparagus_But")
        {       
            scriptIngredient.touchedIngredients[11].SetActive(true);
           
        }
        else if (gameObject.name == "basil_But")
        {
            scriptIngredient.touchedIngredients[12].SetActive(true);
           
        }
        else if (gameObject.name == "broccoli_But")
        {
            scriptIngredient.touchedIngredients[13].SetActive(true);  
        }
        else if (gameObject.name == "carrot_But")
        {
            scriptIngredient.touchedIngredients[14].SetActive(true);
      
        }
        else if (gameObject.name == "cherrytomato_But")
        {
            scriptIngredient.touchedIngredients[15].SetActive(true);
   
        }
        else if (gameObject.name == "cucumber_But")
        {
            scriptIngredient.touchedIngredients[16].SetActive(true);
       
        }
        else if (gameObject.name == "paprika_But")
        {
            scriptIngredient.touchedIngredients[17].SetActive(true);
       
        }
        else if (gameObject.name == "radishsprout_But")
        {
            scriptIngredient.touchedIngredients[18].SetActive(true);
      
        }
        else if (gameObject.name == "apple_But")
        {
            scriptIngredient.touchedIngredients[19].SetActive(true);

        }
        else if (gameObject.name == "avocado_But")
        {
            scriptIngredient.touchedIngredients[20].SetActive(true);

        }
        else if (gameObject.name == "blueberry_But")
        {
            scriptIngredient.touchedIngredients[21].SetActive(true);

        }
        else if (gameObject.name == "cherry_But")
        {
            scriptIngredient.touchedIngredients[22].SetActive(true);

        }
        else if (gameObject.name == "lemon_But")
        {
            scriptIngredient.touchedIngredients[23].SetActive(true);

        }
        else if (gameObject.name == "orange_But")
        {
            scriptIngredient.touchedIngredients[24].SetActive(true);

        }
        else if (gameObject.name == "strawberry_But")
        {
            scriptIngredient.touchedIngredients[25].SetActive(true);

        }
        else if (gameObject.name == "cheddarcheese_But")
        {
            scriptIngredient.touchedIngredients[26].SetActive(true);

        }
        else if (gameObject.name == "cheese_But")
        {
            scriptIngredient.touchedIngredients[27].SetActive(true);

        }
        else if (gameObject.name == "mozzacheese_But")
        {
            scriptIngredient.touchedIngredients[28].SetActive(true);

        }
        else if (gameObject.name == "cream_But")
        {
            scriptIngredient.touchedIngredients[29].SetActive(true);

        }
        else if (gameObject.name == "icecream_But")
        {
            scriptIngredient.touchedIngredients[30].SetActive(true);

        }
        else if (gameObject.name == "caramelsyrup_But")
        {
            scriptIngredient.touchedIngredients[31].SetActive(true);
       
        }
        else if (gameObject.name == "chocosyrup_But")
        {
            scriptIngredient.touchedIngredients[32].SetActive(true);
   
        }
        else if (gameObject.name == "ketchup_But")
        {
            scriptIngredient.touchedIngredients[33].SetActive(true);

        }
        else if (gameObject.name == "mayonnaise_But")
        {
            scriptIngredient.touchedIngredients[34].SetActive(true);

        }
        else if (gameObject.name == "gochujang_But")
        {
            scriptIngredient.touchedIngredients[35].SetActive(true);

        }
        else if (gameObject.name == "ice_But")
        {
            scriptIngredient.touchedIngredients[36].SetActive(true);

        }

    }
}