using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3_catPaw : MonoBehaviour
{
    int catTouch = 0;
    public float catTime = 5f;
    public static int minusCount = 0;
    public static bool catDestroyed = false;

    GameObject catManager;

    private void Start()
    {
        catManager = GameObject.Find("catManager");

        catTouch = 0;
        catTime = 5f;
        minusCount = 0;
        catDestroyed = false;
    }
    void FixedUpdate()
    {

        Vector3 temp = new Vector3(stage3_catManage.randomX, -3f, 0);
        Vector3 temp2 = new Vector3(stage3_catManage.randomX, -8f, 0); //시작지점

        //샘플볼때 움직이지x
        if (!stage3_submitClick.submitOn)
        {
            transform.position = Vector3.MoveTowards(transform.position, temp, 15 * Time.deltaTime);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            catTime -= Time.deltaTime;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, temp, 0);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (catTime <= 0 && catTouch<15)
        {
            //5초 지남+접시 범위안이면 멈춘다
            //현재 접시 중심 0,0,0
            transform.position = Vector3.MoveTowards(transform.position, temp2, 35 * Time.deltaTime);
            catDestroyed = true;
            if (minusCount == 0)
            {
                minusCount++;
            }
            Destroy(gameObject,0.5f);

            stage3_catManage.catOn = false;
            stage3_catManage.hintBut.GetComponent<BoxCollider2D>().enabled = true;

        }


    }

    private void OnMouseDown() {
        catTouch++;
        if (catTouch == 15 && catTime>0) {
            catTouch = 0;
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("_stage3/catSuccess", typeof(Sprite)) as Sprite;

            //sound
            catManager.GetComponent<AudioSource>().Play();

            Destroy(gameObject,0.5f);
            //Debug.Log("15번때리기성공");
            stage3_catManage.catOn = false;
            stage3_catManage.hintBut.GetComponent<BoxCollider2D>().enabled = true;
        }
        

    }
}
