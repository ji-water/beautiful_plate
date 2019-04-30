using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ingredientCount에 붙어서 전체 재료 갯수 관리
public class stage1_countManage : MonoBehaviour
{

    public static int[] ingredientCount = new int[37];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 11; i++)
            ingredientCount[i] = 1;
        for (int i = 11; i <ingredientCount.Length; i++)
            ingredientCount[i] = 5;
        ingredientCount[35] = 1;
    }

    // Update is called once per frame
    //deleteAll()에 포함
    //쓰레기통 클릭시 플레이팅된 재료 지우면서 재료 갯수 복원
    //갯수가 0이었을때 쓰레기통 -> 해당 재료 다시 활성화
    public static void findRestockIngredient(string name) {

        if (name == "platedBread(Clone)")
        {
            if (ingredientCount[0] == 0) stage1_BaseButManage.RestockBread();
            ingredientCount[0]++;
        }
        else if (name == "platedBroth(Clone)")
        {
            if (ingredientCount[1] == 0) stage1_BaseButManage.RestockBroth();
            ingredientCount[1]++;
        }
        else if (name == "platedCake(Clone)")
        {
            if (ingredientCount[2] == 0) stage1_BaseButManage.RestockCake();
            ingredientCount[2]++;
        }
        else if (name == "platedDumpling(Clone)")
        {
            if (ingredientCount[3] == 0) stage1_BaseButManage.RestockDumpling();
            ingredientCount[3]++;
        }
        else if (name == "platedFish(Clone)")
        {
            if (ingredientCount[4] == 0) stage1_BaseButManage.RestockFish();
            ingredientCount[4]++;
        }
        else if (name == "platedIvy(Clone)")
        {
            if (ingredientCount[5] == 0) stage1_BaseButManage.RestockIvy();
            ingredientCount[5]++;
        }
        else if (name == "platedNoodle(Clone)")
        {
            if (ingredientCount[6] == 0) stage1_BaseButManage.RestockNoodle();
            ingredientCount[6]++;
        }
        else if (name == "platedOmelet(Clone)")
        {
            if (ingredientCount[7] == 0) stage1_BaseButManage.RestockOmelet();
            ingredientCount[7]++;
        }
        else if (name == "platedPasta(Clone)")
        {
            if (ingredientCount[8] == 0) stage1_BaseButManage.RestockPasta();
            ingredientCount[8]++;
        }
        else if (name == "platedSalad(Clone)")
        {
            if (ingredientCount[9] == 0) stage1_BaseButManage.RestockSalad();
            ingredientCount[9]++;
        }
        else if (name == "platedSteak(Clone)")
        {
            if (ingredientCount[10] == 0) stage1_BaseButManage.RestockSteak();
            ingredientCount[10]++;
        }
        /*------------------------------------------채소------------------------------------------*/

        else if ((name == "platedAsparagus(Clone)") || (name == "platedAsparagus_grill(Clone)"))
        {
            //if (asparagusCount == 0) stage1_VegeButManage.RestockAsparagus();
            //asparagusCount++;
            if (ingredientCount[11] == 0) stage1_VegeButManage.RestockAsparagus();
            ingredientCount[11]++;
        }
        else if (name == "platedBasil(Clone)")
        {
            if (ingredientCount[12] == 0) stage1_VegeButManage.RestockBasil();
            ingredientCount[12]++;
        }
        else if ((name == "platedBroccoli(Clone)") || (name == "platedBroccoli_grill(Clone)"))
        {
            if (ingredientCount[13] == 0) stage1_VegeButManage.RestockBroccoli();
            ingredientCount[13]++;
        }
        else if ((name == "platedCarrot_chop(Clone)") || (name == "platedCarrot_chop_grill(Clone)") || (name == "platedCarrot_slice(Clone)"))
        {
            if (ingredientCount[14] == 0) stage1_VegeButManage.RestockCarrot();
            ingredientCount[14]++;
        }
        else if ((name == "platedCherrytomato(Clone)") || (name == "platedCherrytomato_chop(Clone)"))
        {
            if (ingredientCount[15] == 0) stage1_VegeButManage.RestockCherrytomato();
            ingredientCount[15]++;
        }
        else if ((name == "platedCucumber_slice(Clone)") || (name == "platedCucumber_chop(Clone)"))
        {

            if (ingredientCount[16] == 0) stage1_VegeButManage.RestockCucumber();
            ingredientCount[16]++;

        }
        else if (name == "platedPaprika_chop(Clone)")
        {
            if (ingredientCount[17] == 0) stage1_VegeButManage.RestockPaprika();
            ingredientCount[17]++;
        }
        else if (name == "platedRadishsprout(Clone)")
        {
            if (ingredientCount[18] == 0) stage1_VegeButManage.RestockRadishsprout();
            ingredientCount[18]++;
        }
        /*-------------------------------------------------과일----------------------------------------------------------*/
        else if (name == "platedApple_chop(Clone)")
        {
            if (ingredientCount[19] == 0) stage1_FruitButManage.RestockApple();
            ingredientCount[19]++;
        }
        else if (name == "platedAvocado_chop(Clone)")
        {
            if (ingredientCount[20] == 0) stage1_FruitButManage.RestockAvocado();
            ingredientCount[20]++;
        }
        else if ((name == "platedBlueberry(Clone)") || (name == "blueberryLineDrawer(Clone)"))
        {
            if (ingredientCount[21] == 0) stage1_FruitButManage.RestockBlueberry();
            ingredientCount[21]++;
        }
        else if (name == "platedCherry(Clone)")
        {
            if (ingredientCount[22] == 0) stage1_FruitButManage.RestockCherry();
            ingredientCount[22]++;
        }
        else if (name == "platedLemon_chop(Clone)")
        {
            if (ingredientCount[23] == 0) stage1_FruitButManage.RestockLemon();
            ingredientCount[23]++;
        }
        else if ((name == "platedOrange_chop(Clone)") || (name == "orangeLineDrawer(Clone)"))
        {
            if (ingredientCount[24] == 0) stage1_FruitButManage.RestockOrange();
            ingredientCount[24]++;
        }
        else if ((name == "platedStrawberry(Clone)") || (name == "platedStrawberry_chop(Clone)") || (name == "strawberryLineDrawer(Clone)"))
        {
            if (ingredientCount[25] == 0) stage1_FruitButManage.RestockStrawberry();
            ingredientCount[25]++;
        }
        /*-------------------------------------------------유제품----------------------------------------------------------*/
        else if ((name == "platedCheddarcheese(Clone)") || (name == "platedCheddarcheese_s(Clone)"))
        {
            if (ingredientCount[26] == 0) stage1_DairyButManage.RestockCheddarcheese();
            ingredientCount[26]++;
        }
        else if ((name == "platedCheese(Clone)") || (name == "platedCheese_s(Clone)"))
        {
            if (ingredientCount[27] == 0) stage1_DairyButManage.RestockCheese();
            ingredientCount[27]++;
        }
        else if ((name == "platedMozzacheese(Clone)")||(name == "platedMozzacheese_s(Clone)"))
        {
            if (ingredientCount[28] == 0) stage1_DairyButManage.RestockMozzacheese();
            ingredientCount[28]++;
        }
        else if (name == "creamLineDrawer(Clone)")
        {
            if (ingredientCount[29] == 0) stage1_DairyButManage.RestockCream();
            ingredientCount[29]++;
        }
        else if (name == "platedIcecream(Clone)")
        {
            if (ingredientCount[30] == 0) stage1_DairyButManage.RestockIcecream();
            ingredientCount[30]++;
        }
        /*-------------------------------------------------데코----------------------------------------------------------*/
        else if (name == "caramelLineDrawer(Clone)")
        {
            if (ingredientCount[31] == 0) stage1_DecoButManage.RestockCaramelsyrup();
            ingredientCount[31]++;
        }
        else if (name == "chocoLineDrawer(Clone)")
        {
            if (ingredientCount[32] == 0) stage1_DecoButManage.RestockChocosyrup();
            ingredientCount[32]++;
        }
        else if (name == "ketchupLineDrawer(Clone)")
        {
            if (ingredientCount[33] == 0) stage1_DecoButManage.RestockKetchup();
            ingredientCount[33]++;
        }
        else if (name == "mayonnaiseLineDrawer(Clone)")
        {
            if (ingredientCount[34] == 0) stage1_DecoButManage.RestockMayonnaise();
            ingredientCount[34]++;
        }
        else if (name == "platedNoodle_gochujang(Clone)")
        {
            if (ingredientCount[35] == 0) stage1_DecoButManage.RestockGochujang();
            ingredientCount[35]++;
            if (ingredientCount[6] == 0) stage1_BaseButManage.RestockNoodle();
            ingredientCount[6]++;
        }
        else if (name == "platedIce(Clone)")
        {
            if (ingredientCount[36] == 0) stage1_DecoButManage.RestockIce();
            ingredientCount[36]++;
        }

    }


}
