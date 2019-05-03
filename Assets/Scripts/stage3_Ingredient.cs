using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 게임매니져에 붙어있으며 시작시 selected 관리하는 코드 */
public class stage3_Ingredient : MonoBehaviour
{
    public static GameObject s_apple;
    public static GameObject s_asparagus;
    public static GameObject s_avocado;
    public static GameObject s_basil;
    public static GameObject s_broccoli;
    public static GameObject s_carrot;
    public static GameObject s_cheddar;
    public static GameObject s_cheese;
    public static GameObject s_cherrytomato;
    public static GameObject s_cucumber;
    public static GameObject s_lemon;
    public static GameObject s_mozza;
    public static GameObject s_orange;
    public static GameObject s_paprika;
    public static GameObject s_radishsprout;
    public static GameObject s_strawberry;
    public static GameObject s_choco;
    public static GameObject s_caramel;
    public static GameObject s_darkchoco;
    public static GameObject s_ketchup;
    public static GameObject s_mayo;
    public static GameObject s_whitechoco;
    

    // Start is called before the first frame update
    void Start()
    {
        s_apple = GameObject.Find("selected_apple");
        s_asparagus = GameObject.Find("selected_asparagus");
        s_avocado = GameObject.Find("selected_avocado");
        s_basil = GameObject.Find("selected_basil");
        s_broccoli = GameObject.Find("selected_broccoli");
        s_carrot = GameObject.Find("selected_carrot");
        s_cheddar = GameObject.Find("selected_cheddar");
        s_cheese = GameObject.Find("selected_cheese");
        s_cherrytomato = GameObject.Find("selected_cherrytomato");
        s_cucumber = GameObject.Find("selected_cucumber");
        s_lemon = GameObject.Find("selected_lemon");
        s_mozza = GameObject.Find("selected_mozza");
        s_orange = GameObject.Find("selected_orange");
        s_paprika = GameObject.Find("selected_paprika");
        s_radishsprout = GameObject.Find("selected_radishsprout");
        s_strawberry = GameObject.Find("selected_strawberry");
        s_choco = GameObject.Find("selected_choco");
        s_caramel = GameObject.Find("selected_caramel");
        s_darkchoco = GameObject.Find("selected_darkchoco");
        s_ketchup = GameObject.Find("selected_ketchup");
        s_mayo = GameObject.Find("selected_mayo");
        s_whitechoco = GameObject.Find("selected_whitechoco");

        IngredientUnActi();
    }

    //selected된 재료 모두 끔
    public static void IngredientUnActi()
    {
        s_apple.SetActive(false);
        s_asparagus.SetActive(false);
        s_avocado.SetActive(false);
        s_basil.SetActive(false);
        s_broccoli.SetActive(false);
        s_carrot.SetActive(false);
        s_cheddar.SetActive(false);
        s_cheese.SetActive(false);
        s_cherrytomato.SetActive(false);
        s_cucumber.SetActive(false);
        s_lemon.SetActive(false);
        s_mozza.SetActive(false);
        s_orange.SetActive(false);
        s_paprika.SetActive(false);
        s_radishsprout.SetActive(false);
        s_strawberry.SetActive(false);
        s_choco.SetActive(false);
        s_caramel.SetActive(false);
        s_darkchoco.SetActive(false);
        s_ketchup.SetActive(false);
        s_mayo.SetActive(false);
        s_whitechoco.SetActive(false);
    }

    //재료버튼이 눌러지면 name을 읽어서 activate 시켜줌
    public static void IngredientActi(string name)
    {
        IngredientUnActi();

        if (name.Contains("apple"))
            s_apple.SetActive(true);
        else if (name.Contains("asparagus"))
            s_asparagus.SetActive(true);
        else if (name.Contains("avocado"))
            s_avocado.SetActive(true);
        else if (name.Contains("basil"))
            s_basil.SetActive(true);
        else if (name.Contains("broccoli"))
            s_broccoli.SetActive(true);
        else if (name.Contains("carrot"))
            s_carrot.SetActive(true);
        else if (name.Contains("cheddar"))
            s_cheddar.SetActive(true);
        else if (name.Contains("mozza"))
            s_mozza.SetActive(true);
        else if (name.Contains("cheese"))
            s_cheese.SetActive(true);
        else if (name.Contains("cherrytomato"))
            s_cherrytomato.SetActive(true);
        else if (name.Contains("cucumber"))
            s_cucumber.SetActive(true);
        else if (name.Contains("lemon"))
            s_lemon.SetActive(true);
        else if (name.Contains("orange"))
            s_orange.SetActive(true);
        else if (name.Contains("paprika"))
            s_paprika.SetActive(true);
        else if (name.Contains("radishsprout"))
            s_radishsprout.SetActive(true);
        else if (name.Contains("strawberry"))
            s_strawberry.SetActive(true);
        else if (name.Contains("darkchoco"))
            s_darkchoco.SetActive(true);
        else if (name.Contains("whitechoco"))
            s_whitechoco.SetActive(true);
        else if (name.Contains("choco"))
            s_choco.SetActive(true);
        else if (name.Contains("caramel"))
            s_caramel.SetActive(true);
        else if (name.Contains("ketchup"))
            s_ketchup.SetActive(true);
        else if (name.Contains("mayo"))
            s_mayo.SetActive(true);


    }
}
