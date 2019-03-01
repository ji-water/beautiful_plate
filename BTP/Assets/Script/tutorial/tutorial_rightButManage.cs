using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_rightButManage : MonoBehaviour
{
    //public static bool rightButClicked;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown() {

        //---------------------------------------------------------베이스탭
        if (stage1_moveButManage.currentTab == "tapBase1")
        {
            tutorial_BaseButManage.tapBase1Invisible();
            tutorial_BaseButManage.tapBase2Visible();
            stage1_moveButManage.currentTab = "tapBase2";
        }
        else if (stage1_moveButManage.currentTab == "tapBase2")
        {
            tutorial_BaseButManage.tapBase2Invisible();
            tutorial_BaseButManage.tapBase3Visible();
            stage1_moveButManage.currentTab = "tapBase3";
        }
        else if (stage1_moveButManage.currentTab == "tapBase3")
        {
            tutorial_BaseButManage.tapBase3Invisible();
            tutorial_BaseButManage.tapBase1Visible();
            stage1_moveButManage.currentTab = "tapBase1";
        }
        //---------------------------------------------------------채소탭
        else if (stage1_moveButManage.currentTab == "tapVegetable1")
        {
            tutorial_VegeButManage.tapVege1Invisible();
            tutorial_VegeButManage.tapVege2Visible();
            stage1_moveButManage.currentTab = "tapVegetable2";
        }
        else if (stage1_moveButManage.currentTab == "tapVegetable2") {
            tutorial_VegeButManage.tapVege2Invisible();
            tutorial_VegeButManage.tapVege1Visible();
            stage1_moveButManage.currentTab = "tapVegetable1";
        }
        //---------------------------------------------------------과일탭
        else if (stage1_moveButManage.currentTab == "tapFruit1")
        {
            tutorial_FruitButManage.tapFruit1Invisible();
            tutorial_FruitButManage.tapFruit2Visible();
            stage1_moveButManage.currentTab = "tapFruit2";
        }
        else if (stage1_moveButManage.currentTab == "tapFruit2")
        {
            tutorial_FruitButManage.tapFruit2Invisible();
            tutorial_FruitButManage.tapFruit1Visible();
            stage1_moveButManage.currentTab = "tapFruit1";
        }
        //---------------------------------------------------------유제품탭
        else if (stage1_moveButManage.currentTab == "tapDairy1")
        {
            tutorial_DairyButManage.tapDairy1Invisible();
            tutorial_DairyButManage.tapDairy2Visible();
            stage1_moveButManage.currentTab = "tapDairy2";
        }
        else if (stage1_moveButManage.currentTab == "tapDairy2")
        {
            tutorial_DairyButManage.tapDairy2Invisible();
            tutorial_DairyButManage.tapDairy1Visible();
            stage1_moveButManage.currentTab = "tapDairy1";
        }
        //---------------------------------------------------------데코탭
        else if (stage1_moveButManage.currentTab == "tapDeco1")
        {
            tutorial_DecoButManage.tapDeco1Invisible();
            tutorial_DecoButManage.tapDeco2Visible();
            stage1_moveButManage.currentTab = "tapDeco2";
        }
        else if (stage1_moveButManage.currentTab == "tapDeco2")
        {
            tutorial_DecoButManage.tapDeco2Invisible();
            tutorial_DecoButManage.tapDeco1Visible();
            stage1_moveButManage.currentTab = "tapDeco1";
        }

    }
}
