using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_flying : MonoBehaviour
{

    public Vector3 temp;
    public float flyingTime = 5f;
    public static bool flyStopped = false;
    public static int minusCount = 0;
    public static bool flyDestroyed = false;

    Quaternion qt;

    public GameObject swatterClone;
    public GameObject deadFly;

    void Start()
    {
        flyingTime = 5f;

        //SetRandomPos();
        Time.timeScale = 1;
        InvokeRepeating("setTime",0,1f);
         minusCount = 0;
        flyDestroyed = false;
        flyStopped = false;
    }

    void FixedUpdate()
    {
        Vector3 vectorToTarget = temp - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        qt = Quaternion.AngleAxis(angle, Vector3.forward);

        if (!stage1_submitClick.submitOn)
            flyingTime -= Time.deltaTime;

        if (stage1_submitClick.submitOn)
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, 0);
            transform.position = Vector3.MoveTowards(transform.position, temp, 0);
        }

        
        if (flyingTime < 0&&(Vector3.Distance(gameObject.transform.position, new Vector3(0, -0.45f, 0)) < 3.8f))
        {
           //5초 지남+접시 범위안이면 멈춘다
          //현재 접시 중심 0,0,0
            Debug.Log(Vector3.Distance(gameObject.transform.position, new Vector3(0, -0.45f, 0)));
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("sittingFly", typeof(Sprite)) as Sprite;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, 0);
            transform.position = Vector3.MoveTowards(transform.position, temp, 0);
          
            flyStopped = true;
            if (minusCount == 0) {
                minusCount++;
            }
            Destroy(gameObject,0.5f);//앉았다가 2초뒤에 사라짐.
            swatterDestroy();//파리채 삭제
            stage1_flyManage.flyOn = false;
            stage1_flyManage.hintBut.GetComponent<BoxCollider2D>().enabled = true;

        }
        else if(!stage1_submitClick.submitOn)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * 800f);
            transform.position = Vector3.MoveTowards(transform.position, temp, 5 * Time.deltaTime);

        }

        
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<AudioSource>().Play();

        GameObject clone;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        objPosition.z = -50f;
        
        Destroy(gameObject);
        Instantiate(deadFly, objPosition, Quaternion.identity);
        clone = GameObject.Find("deadFly(Clone)");
        clone.transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, 0);

        
        Destroy(clone, 1);

        if (!stage1_swatterClick.swatterClicked) { //파리채 안누른 상태에서 파리 잡으면 시간 깎임
            if (minusCount == 0)
            {
                minusCount++;
            }
        }
        swatterDestroy(); //파리채 삭제

        if (!flyStopped) flyDestroyed = true;

        stage1_flyManage.hintBut.GetComponent<BoxCollider2D>().enabled = true;
        stage1_flyManage.flyOn = false;

    }

    void setTime() {
        float dist;
        Vector3 randomP;
        while (true)
        {
            randomP = new Vector3(Random.Range(-6.0f, 6f), Random.Range(-6.0f, 6.0f), 0);
            dist = Vector3.Distance(gameObject.transform.position, randomP);
            if (dist < 6.0f)
               randomP = new Vector3(Random.Range(-5.0f, 5f), Random.Range(-5.0f, 5.0f), 0);
            else break;
        }
        temp = randomP;
    }

    public void swatterDestroy() {
        swatterClone = GameObject.Find("swatter(Clone)");
        Destroy(swatterClone);
        stage1_swatterClick.swatterClicked = false;

    }
}
