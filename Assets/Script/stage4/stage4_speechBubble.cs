using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage4_speechBubble : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject rottenCheese;
    private GameObject Clone;
    public static GameObject platedParent;
    public bool cheeseDone = false;

   
    void Start()
    {
        platedParent = GameObject.Find("platedParent");
        stage4_checkHint.allTransparent.SetActive(true); //stage1_checkHint.allTransparent : private->static
    }

    private void FixedUpdate()
    {
       
        if (gameObject.transform.localScale.x <1.8f)
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x + 0.015f, transform.localScale.y + 0.015f, transform.localScale.z);
 
        }
        else if (gameObject.transform.localScale.x > 1.8f) {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("_stage4/speech_", typeof(Sprite)) as Sprite;
            gameObject.transform.localScale = new Vector3(transform.localScale.x + 0.03f, transform.localScale.y + 0.03f, transform.localScale.z);
        }

        if (gameObject.transform.localScale.x > 2.6f)
        {

            gameObject.transform.localScale = new Vector3(1.8f, 1.8f, transform.localScale.z);
            Time.timeScale = 1;
            Invoke("inactiveTransparent", 0.8f);
            Destroy(gameObject,0.8f);

            if (!cheeseDone)
            {
                for (int i = 0; i < 5; i++)
                {
                    stage1_plating.layerOrder -= 0.1f;
                     Clone = Instantiate(rottenCheese, new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-3f, 2f), stage1_plating.layerOrder), Quaternion.identity);
                    Clone.transform.SetParent(platedParent.transform);
                    if (stage1_clicktissue.tissueClicked) {
                        Clone.GetComponent<PolygonCollider2D>().enabled = true;
                    }
                }
                
                cheeseDone = true;
                stage4_speechManage.speechOn = false;
            }
        }
        
    }

    void inactiveTransparent() {

        stage4_checkHint.allTransparent.SetActive(false);
        //stage4_speechManage.hintBut.GetComponent<BoxCollider2D>().enabled = true;
    }



}
