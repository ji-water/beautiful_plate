using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 재료에 붙어있으며, touch시 touched_재료 active */
public class stage3_Ingredient_touch : MonoBehaviour
{

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        stage3_Ingredient.IngredientActi(gameObject.name);
    }

}
