using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_leftButManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown() {
        //---------------------------------------------------------베이스탭
        if (stage1_moveButManage.currentTab == "tapBase1")
        {
            stage1_BaseButManage.tapBase1Invisible();
            stage1_BaseButManage.tapBase3Visible();
            stage1_moveButManage.currentTab = "tapBase3";
        }
        else if (stage1_moveButManage.currentTab == "tapBase2")
        {
            stage1_BaseButManage.tapBase2Invisible();
            stage1_BaseButManage.tapBase1Visible();
            stage1_moveButManage.currentTab = "tapBase1";
        }
        else if (stage1_moveButManage.currentTab == "tapBase3")
        {
            stage1_BaseButManage.tapBase3Invisible();
            stage1_BaseButManage.tapBase2Visible();
            stage1_moveButManage.currentTab = "tapBase2";
        }
        //---------------------------------------------------------채소탭
        else if (stage1_moveButManage.currentTab == "tapVegetable2") {
            stage1_VegeButManage.tapVege2Invisible();
            stage1_VegeButManage.tapVege1Visible();
            stage1_moveButManage.currentTab = "tapVegetable1";
        }
       else if (stage1_moveButManage.currentTab == "tapVegetable1")
        {
            stage1_VegeButManage.tapVege1Invisible();
            stage1_VegeButManage.tapVege2Visible();
            stage1_moveButManage.currentTab = "tapVegetable2";
        }
        //---------------------------------------------------------과일탭
        else if (stage1_moveButManage.currentTab == "tapFruit1")
        {
            stage1_FruitButManage.tapFruit1Invisible();
            stage1_FruitButManage.tapFruit2Visible();
            stage1_moveButManage.currentTab = "tapFruit2";
        }
        else if (stage1_moveButManage.currentTab == "tapFruit2")
        {
            stage1_FruitButManage.tapFruit2Invisible();
            stage1_FruitButManage.tapFruit1Visible();
            stage1_moveButManage.currentTab = "tapFruit1";
        }
        //---------------------------------------------------------유제품탭
        else if (stage1_moveButManage.currentTab == "tapDairy1")
        {
            stage1_DairyButManage.tapDairy1Invisible();
            stage1_DairyButManage.tapDairy2Visible();
            stage1_moveButManage.currentTab = "tapDairy2";
        }
        else if (stage1_moveButManage.currentTab == "tapDairy2")
        {
            stage1_DairyButManage.tapDairy2Invisible();
            stage1_DairyButManage.tapDairy1Visible();
            stage1_moveButManage.currentTab = "tapDairy1";
        }
        //---------------------------------------------------------데코탭
        else if (stage1_moveButManage.currentTab == "tapDeco1")
        {
            stage1_DecoButManage.tapDeco1Invisible();
            stage1_DecoButManage.tapDeco2Visible();
            stage1_moveButManage.currentTab = "tapDeco2";
        }
        else if (stage1_moveButManage.currentTab == "tapDeco2")
        {
            stage1_DecoButManage.tapDeco2Invisible();
            stage1_DecoButManage.tapDeco1Visible();
            stage1_moveButManage.currentTab = "tapDeco1";
        }

    }
}
