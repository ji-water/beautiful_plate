using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//plate에 붙어 active된 touchedIngredients 찾아 platedingredient 만듬
public class stage1_plating : MonoBehaviour
{
    public GameObject platedBread;
    public GameObject platedBroth;
    public GameObject platedCake;
    public GameObject platedDumpling;
    public GameObject platedFish;
    public GameObject platedIvy;
    public GameObject platedNoodle;
    public GameObject platedOmelet;
    public GameObject platedPasta;
    public GameObject platedSalad;
    public GameObject platedSteak;

    public GameObject platedAsparagus;
    public GameObject platedBasil;
    public GameObject platedBroccoli;
    public GameObject platedCarrot;
    public GameObject platedCherrytomato;
    public GameObject platedCucumber;
    public GameObject platedPaprika;
    public GameObject platedRadishsprout;

    public GameObject platedBlueberry;
    public GameObject platedCherry;
    public GameObject platedStrawberry;

    public GameObject platedCheddarcheese;
    public GameObject platedCheddarcheese_s;
    public GameObject platedCheese;
    public GameObject platedCheese_s;
    public GameObject platedMozzacheese;
    public GameObject platedMozzacheese_s;
    public GameObject platedIcecream;

    public GameObject platedIce;

    public GameObject platedAsparagus_grill;
    public GameObject platedBroccoli_grill;
    public GameObject platedCarrot_chop;
    public GameObject platedCarrot_chop_grill;
    public GameObject platedCarrot_slice;
    public GameObject platedCherrytomato_chop;
    public GameObject platedCucumber_chop;
    public GameObject platedCucumber_slice;
    public GameObject platedPaprika_chop;
    public GameObject platedApple_chop;
    public GameObject platedAvocado_chop;
    public GameObject platedLemon_chop;
    public GameObject platedOrange_chop;
    public GameObject platedStrawberry_chop;
    public GameObject platedNoodle_gochujang;

    public GameObject platedNoodle_Clone;
    public static string currentPlatedBase = null;
    private GameObject Clone;
    public GameObject cant;

    public static string touchedName; //
    private stage1_ingredient scriptIngredient;
    public GameObject gamemanager;

    public static float layerOrder = 30f; //올라가는 재료 순서

    public static GameObject platedParent; //플레이팅되는 오브젝트들의 부모 설정

    public static string deletedIngredient; //trashcan클릭시 삭제되는 재료 이름 임시 저장

    /*-------------------------------------------------<<<LineCreate>>>-----------------------------------------------------*/
    [SerializeField] private GameObject caramelLine, chocoLine, ketchupLine, mayonnaiseLine, creamLine, blueberryLine, strawberryLine, orangeLine;
    //[SerializeField] private GameObject chocoLine;
    private GameObject temp;
    private Vector3 mousePosition;
    public static GameObject LineClone;
    public static Vector3 startpos;

    public void DecoCreate(string touchedName)
    {
        string name = touchedName;

        if (name == "touchedCaramelsyrup") temp = caramelLine;
        else if (name == "touchedChocosyrup") temp = chocoLine;
        else if (name == "touchedKetchup") temp = ketchupLine;
        else if (name == "touchedMayonnaise") temp = mayonnaiseLine;
        else if (name == "touchedCream") temp = creamLine;
        else if (name == "touchedBlueberry_juice") temp = blueberryLine;
        else if (name == "touchedOrange_juice") temp = orangeLine;
        else if (name == "touchedStrawberry_juice") temp = strawberryLine;
        // stage1_plating.layerOrder--;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        objPosition.z = layerOrder;
        startpos = objPosition;

        Clone = Instantiate(temp, objPosition, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        Clone.transform.SetParent(platedParent.transform);
    }
    /*----------------------------------------------------------------------------------------------------------------------*/

    // Start is called before the first frame update
    void Start()
    {
        touchedName = null;
        currentPlatedBase = null;
        layerOrder = 30f;

        scriptIngredient = gamemanager.GetComponent<stage1_ingredient>();

        platedParent = GameObject.Find("platedParent");
      
    }


    //접시위 모든 재료 삭제
    public static void deleteAll() {
        for (int i = 0; i < platedParent.transform.childCount; i++)
        {
            Destroy(platedParent.transform.GetChild(i).gameObject);
            deletedIngredient = platedParent.transform.GetChild(i).gameObject.name;
            Debug.Log(deletedIngredient);
            stage1_countManage.findRestockIngredient(deletedIngredient);

        }

        stage1_plating.layerOrder = 30f; //재료 순서 초기화

        currentPlatedBase = null;
        stage1_BaseButManage.baseColliderActive();
    }



    //접시 위 모든 재료 비활성화
    public static void makeInvisible()
    {
        for (int i = 0; i < platedParent.transform.childCount; i++)
        {
            platedParent.transform.GetChild(i).gameObject.SetActive(false);

        }
    }
    
    //상호작용없이 못올라가는 재료 올릴시 x표시
    private void destroyCant()
    {
        Clone = GameObject.Find("cant(Clone)");
        Destroy(Clone);
    }
    //private void cantPlate()
    //{
    //    Clone = Instantiate(cant, new Vector3(0, 0, 0), Quaternion.identity);
    //    Invoke("destroyCant",0.5f);
    //}
   

    // Update is called once per frame
    private void OnMouseDown() {

        layerOrder-=0.1f;
        Vector3 platePosition = new Vector3(0,-0.45f,layerOrder);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        objPosition.z = layerOrder;
        
        for (int i = 0; i < scriptIngredient.touchedIngredients.Length; i++) {
            if (scriptIngredient.touchedIngredients[i].activeSelf) {
                touchedName = scriptIngredient.touchedIngredients[i].name; //활성화된 touched재료 변수 이름 저장
            }

        }
        //터치된 재료에 맞는 플레이팅 재료 오브젝트 생성후 부모 할당
        /*--------------------------------------------------베이스-----------------------------------------------*/
        if (touchedName == "touchedBread")
        {
            Clone = Instantiate(platedBread, platePosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[0]--;
            Debug.Log("빵" + stage1_countManage.ingredientCount[0]);

            if (stage1_countManage.ingredientCount[0] == 0)
            {
                stage1_BaseButManage.AllusedBread();
                scriptIngredient.touchedIngredients[0].SetActive(false);
            }
          
            stage1_BaseButManage.baseColliderInactive();
        }
        else if (touchedName == "touchedBroth")
        {
            if (currentPlatedBase == "noodle")
            {
                Clone = Instantiate(platedBroth, platePosition, Quaternion.identity);
                Clone.transform.SetParent(platedParent.transform);
                stage1_countManage.ingredientCount[1]--;
                Debug.Log("육수" + stage1_countManage.ingredientCount[1]);

                if (stage1_countManage.ingredientCount[1] == 0)
                {
                    stage1_BaseButManage.AllusedBroth();
                    scriptIngredient.touchedIngredients[1].SetActive(false);
                }

            }
            else {
                Clone = Instantiate(cant, objPosition, Quaternion.identity);
                Time.timeScale = 1;
                Invoke("destroyCant", 0.5f);
            }

        }
        else if (touchedName == "touchedCake")
        {
            Clone = Instantiate(platedCake, platePosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[2]--;
            Debug.Log("케이크" + stage1_countManage.ingredientCount[2]);

            if (stage1_countManage.ingredientCount[2] == 0)
            {
                stage1_BaseButManage.AllusedCake();
                scriptIngredient.touchedIngredients[2].SetActive(false);
            }
            stage1_BaseButManage.baseColliderInactive();
        }
        else if (touchedName == "touchedDumpling")
        {
            Clone = Instantiate(platedDumpling, platePosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[3]--;
            Debug.Log("덤플링" + stage1_countManage.ingredientCount[3]);

            if (stage1_countManage.ingredientCount[3] == 0)
            {
                stage1_BaseButManage.AllusedDumpling();
                scriptIngredient.touchedIngredients[3].SetActive(false);
            }
            stage1_BaseButManage.baseColliderInactive();
        }
        else if (touchedName == "touchedFish")
        {
            Clone = Instantiate(platedFish, platePosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[4]--;
            Debug.Log("생선" + stage1_countManage.ingredientCount[4]);

            if (stage1_countManage.ingredientCount[4] == 0)
            {
                stage1_BaseButManage.AllusedFish();
                scriptIngredient.touchedIngredients[4].SetActive(false);
            }
            stage1_BaseButManage.baseColliderInactive();
        }
        else if (touchedName == "touchedIvy")
        {
            Clone = Instantiate(platedIvy, platePosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[5]--;
            Debug.Log("아이비" + stage1_countManage.ingredientCount[5]);

            if (stage1_countManage.ingredientCount[5] == 0)
            {
                stage1_BaseButManage.AllusedIvy();
                scriptIngredient.touchedIngredients[5].SetActive(false);
            }
            currentPlatedBase = "Ivy";
            stage1_BaseButManage.baseColliderInactive();
        }
        else if (touchedName == "touchedNoodle")
        {
            Clone = Instantiate(platedNoodle, platePosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[6]--;
            Debug.Log("국수" + stage1_countManage.ingredientCount[6]);

            if (stage1_countManage.ingredientCount[6] == 0)
            {
                stage1_BaseButManage.AllusedNoodle();
                scriptIngredient.touchedIngredients[6].SetActive(false);
            }

            currentPlatedBase = "noodle";
            stage1_BaseButManage.baseColliderInactive();
            stage1_BaseButManage.broth_But.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (touchedName == "touchedOmelet")
        {
            Clone = Instantiate(platedOmelet, platePosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[7]--;
            Debug.Log("오믈렛" + stage1_countManage.ingredientCount[7]);

            if (stage1_countManage.ingredientCount[7] == 0)
            {
                stage1_BaseButManage.AllusedOmelet();
                scriptIngredient.touchedIngredients[7].SetActive(false);
            }
            stage1_BaseButManage.baseColliderInactive();
        }
        else if (touchedName == "touchedPasta")
        {
            Clone = Instantiate(platedPasta, platePosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[8]--;
            Debug.Log("파스타" + stage1_countManage.ingredientCount[8]);

            if (stage1_countManage.ingredientCount[8] == 0)
            {
                stage1_BaseButManage.AllusedPasta();
                scriptIngredient.touchedIngredients[8].SetActive(false);
            }
            stage1_BaseButManage.baseColliderInactive();
        }
        else if (touchedName == "touchedSalad")
        {
            Clone = Instantiate(platedSalad, platePosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[9]--;
            Debug.Log("샐러드" + stage1_countManage.ingredientCount[9]);

            if (stage1_countManage.ingredientCount[9] == 0)
            {
                stage1_BaseButManage.AllusedSalad();
                scriptIngredient.touchedIngredients[9].SetActive(false);
            }
            stage1_BaseButManage.baseColliderInactive();
        }
        else if (touchedName == "touchedSteak")
        {
            Clone = Instantiate(platedSteak, platePosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[10]--;
            Debug.Log("스테이크" + stage1_countManage.ingredientCount[10]);

            if (stage1_countManage.ingredientCount[10] == 0)
            {
                stage1_BaseButManage.AllusedSteak();
                scriptIngredient.touchedIngredients[10].SetActive(false);
            }
            stage1_BaseButManage.baseColliderInactive();
        }
        /*--------------------------------------------------채소-----------------------------------------------*/
        else if (touchedName == "touchedAsparagus")
        {
            
            Clone = Instantiate(platedAsparagus, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[11]--;
            Debug.Log("아스파라거스개수" + stage1_countManage.ingredientCount[11]);

            if (stage1_countManage.ingredientCount[11] == 0)
            {
                stage1_VegeButManage.AllusedAsparagus();
                scriptIngredient.touchedIngredients[11].SetActive(false);
            }

        }
        else if (touchedName == "touchedBasil")
        {
            

            Clone = Instantiate(platedBasil, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[12]--;
            Debug.Log("바질개수" + stage1_countManage.ingredientCount[12]);

            if (stage1_countManage.ingredientCount[12] == 0)
            {
                stage1_VegeButManage.AllusedBasil();
                scriptIngredient.touchedIngredients[12].SetActive(false);
            }

        }
        else if (touchedName == "touchedBroccoli")
        {
           
            Clone = Instantiate(platedBroccoli, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[13]--;
            Debug.Log("브로콜리개수" + stage1_countManage.ingredientCount[13]);
            if (stage1_countManage.ingredientCount[13] == 0)
            {
                stage1_VegeButManage.AllusedBroccoli();
                scriptIngredient.touchedIngredients[13].SetActive(false);
            }
        }
        else if (touchedName == "touchedCarrot") //당근 -> 상호작용없이 안올라감
        {
            Clone = Instantiate(cant, objPosition, Quaternion.identity);
            Time.timeScale = 1;
            Invoke("destroyCant", 0.5f);
        }
        else if (touchedName == "touchedCherrytomato")
        {
          
            Clone = Instantiate(platedCherrytomato, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[15]--;
            Debug.Log("방울토마토개수" + stage1_countManage.ingredientCount[15]);
            if (stage1_countManage.ingredientCount[15] == 0)
            {
                stage1_VegeButManage.AllusedCherrytomato();
                scriptIngredient.touchedIngredients[15].SetActive(false);
            }
        }
        else if (touchedName == "touchedCucumber") //오이 -> 상호작용없이 안올라감
        {
            Clone = Instantiate(cant, objPosition, Quaternion.identity);
            Time.timeScale = 1;
            Invoke("destroyCant", 0.5f);
        }
        else if (touchedName == "touchedPaprika")//파프리카 -> 상호작용없이 안올라감
        {
            Clone = Instantiate(cant, objPosition, Quaternion.identity);
            Time.timeScale = 1;
            Invoke("destroyCant", 0.5f);
        }
        else if (touchedName == "touchedRadishsprout")
        {
           
            Clone = Instantiate(platedRadishsprout, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[18]--;
            Debug.Log("무순개수" + stage1_countManage.ingredientCount[18]);
            if (stage1_countManage.ingredientCount[18] == 0)
            {
                stage1_VegeButManage.AllusedRadishsprout();
                scriptIngredient.touchedIngredients[18].SetActive(false);
            }
        }
        else if (touchedName == "touchedAsparagus_grill")
        {
            Clone = Instantiate(platedAsparagus_grill, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[11]--;
            Debug.Log("구운 아스파라거스 사용->아스파라거스 개수" + stage1_countManage.ingredientCount[11]);

            if (stage1_countManage.ingredientCount[11] == 0)
            {
                stage1_VegeButManage.AllusedAsparagus();
              //  scriptIngredient.touchedIngredients[11].SetActive(false);
                scriptIngredient.touchedWithTools[0].SetActive(false);
            }

        }
        else if (touchedName == "touchedBroccoli_grill")
        {

            Clone = Instantiate(platedBroccoli_grill, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[13]--;
            Debug.Log("구운브로콜리사용->브로콜리개수" + stage1_countManage.ingredientCount[13]);
            if (stage1_countManage.ingredientCount[13] == 0)
            {
                stage1_VegeButManage.AllusedBroccoli();
                scriptIngredient.touchedWithTools[1].SetActive(false);
            }
        }
        else if (touchedName == "touchedCarrot_chop") 
        {

            Clone = Instantiate(platedCarrot_chop, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[14]--;
            Debug.Log("칼+당근->당근개수" + stage1_countManage.ingredientCount[14]);
            if (stage1_countManage.ingredientCount[14] == 0)
            {
                stage1_VegeButManage.AllusedCarrot();
                scriptIngredient.touchedWithTools[2].SetActive(false);
            }
        }
        else if (touchedName == "touchedCarrot_chop_grill") 
        {

            Clone = Instantiate(platedCarrot_chop_grill, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[14]--;
            Debug.Log("칼+그릴+당근->당근개수" + stage1_countManage.ingredientCount[14]);
            if (stage1_countManage.ingredientCount[14] == 0)
            {
                stage1_VegeButManage.AllusedCarrot();
                scriptIngredient.touchedWithTools[3].SetActive(false);
            }
        }
        else if (touchedName == "touchedCarrot_slice") 
        {

            Clone = Instantiate(platedCarrot_slice, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[14]--;
            Debug.Log("채칼+당근->당근개수" + stage1_countManage.ingredientCount[14]);
           // Debug.Log("위치:"+objPosition);
            if (stage1_countManage.ingredientCount[14] == 0)
            {
                stage1_VegeButManage.AllusedCarrot();
                scriptIngredient.touchedWithTools[4].SetActive(false);
            }
        }
        else if (touchedName == "touchedCherrytomato_chop")
        {

            Clone = Instantiate(platedCherrytomato_chop, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[15]--;
            Debug.Log("칼+방울토마토->방울토마토개수" + stage1_countManage.ingredientCount[15]);
            if (stage1_countManage.ingredientCount[15] == 0)
            {
                stage1_VegeButManage.AllusedCherrytomato();
                scriptIngredient.touchedWithTools[5].SetActive(false);
            }
        }
        else if (touchedName == "touchedCucumber_chop")
        {

            Clone = Instantiate(platedCucumber_chop, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[16]--;
            Debug.Log("칼+오이->오이개수" + stage1_countManage.ingredientCount[16]);
            if (stage1_countManage.ingredientCount[16] == 0)
            {
                stage1_VegeButManage.AllusedCucumber();
                scriptIngredient.touchedWithTools[6].SetActive(false);
            }
        }
        else if (touchedName == "touchedCucumber_slice") 
        {

            Clone = Instantiate(platedCucumber_slice, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[16]--;
            Debug.Log("채칼+오이->오이개수" + stage1_countManage.ingredientCount[16]);
            if (stage1_countManage.ingredientCount[16] == 0)
            {
                stage1_VegeButManage.AllusedCucumber();
                scriptIngredient.touchedWithTools[7].SetActive(false);
            }
        }
        else if (touchedName == "touchedPaprika_chop")
        {

            Clone = Instantiate(platedPaprika_chop, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[17]--;
            Debug.Log("칼+파프리카->파프리카개수" + stage1_countManage.ingredientCount[17]);
            if (stage1_countManage.ingredientCount[17] == 0)
            {
                stage1_VegeButManage.AllusedPaprika();
                scriptIngredient.touchedWithTools[8].SetActive(false);
            }
        }

        /*--------------------------------------------------과일-----------------------------------------------*/
        else if (touchedName == "touchedApple")//사과-> 상호작용없이 안올라감
        {
            Clone = Instantiate(cant, objPosition, Quaternion.identity);
            Time.timeScale = 1;
            Invoke("destroyCant", 0.5f);
        }
        else if (touchedName == "touchedAvocado")//아보카도-> 상호작용없이 안올라감
        {
            Clone = Instantiate(cant, objPosition, Quaternion.identity);
            Time.timeScale = 1;
            Invoke("destroyCant", 0.5f);
        }
        else if (touchedName == "touchedBlueberry")
        {
            Clone = Instantiate(platedBlueberry, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[21]--;
            Debug.Log("블루베리" + stage1_countManage.ingredientCount[21]);

            if (stage1_countManage.ingredientCount[21] == 0)
            {
                stage1_FruitButManage.AllusedBlueberry();
                scriptIngredient.touchedIngredients[21].SetActive(false);
            }
        }
        else if (touchedName == "touchedCherry")
        {
            Clone = Instantiate(platedCherry, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[22]--;
            Debug.Log("체리" + stage1_countManage.ingredientCount[22]);

            if (stage1_countManage.ingredientCount[22] == 0)
            {
                stage1_FruitButManage.AllusedCherry();
                scriptIngredient.touchedIngredients[22].SetActive(false);
            }
        }
        else if (touchedName == "touchedLemon")//레몬-> 상호작용없이 안올라감
        {
            Clone = Instantiate(cant, objPosition, Quaternion.identity);
            Time.timeScale = 1;
            Invoke("destroyCant", 0.5f);
        }
        else if (touchedName == "touchedOrange") //오렌지-> 상호작용없이 안올라감
        {
            Clone = Instantiate(cant, objPosition, Quaternion.identity);
            Time.timeScale = 1;
            Invoke("destroyCant", 0.5f);
        }
        else if (touchedName == "touchedStrawberry")
        {
            Clone = Instantiate(platedStrawberry, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[25]--;
            Debug.Log("딸기" + stage1_countManage.ingredientCount[25]);

            if (stage1_countManage.ingredientCount[25] == 0)
            {
                stage1_FruitButManage.AllusedStrawberry();
                scriptIngredient.touchedIngredients[25].SetActive(false);
            }
        }
        else if (touchedName == "touchedApple_chop")
        {
            Clone = Instantiate(platedApple_chop, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[19]--;
            Debug.Log("사과+칼->사과 개수" + stage1_countManage.ingredientCount[19]);

            if (stage1_countManage.ingredientCount[19] == 0)
            {
                stage1_FruitButManage.AllusedApple();
                scriptIngredient.touchedWithTools[9].SetActive(false);
            }
        }
        else if (touchedName == "touchedAvocado_chop")
        {
            Clone = Instantiate(platedAvocado_chop, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[20]--;
            Debug.Log("아보카도+칼->아보카도 개수" + stage1_countManage.ingredientCount[20]);

            if (stage1_countManage.ingredientCount[20] == 0)
            {
                stage1_FruitButManage.AllusedAvocado();
                scriptIngredient.touchedWithTools[10].SetActive(false);
            }
        }
        else if (touchedName == "touchedLemon_chop")
        {
            Clone = Instantiate(platedLemon_chop, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[23]--;
            Debug.Log("레몬+칼->레몬 개수" + stage1_countManage.ingredientCount[23]);

            if (stage1_countManage.ingredientCount[23] == 0)
            {
                stage1_FruitButManage.AllusedLemon();
                scriptIngredient.touchedWithTools[11].SetActive(false);
            }
        }
        else if (touchedName == "touchedOrange_chop")
        {
            Clone = Instantiate(platedOrange_chop, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[24]--;
            Debug.Log("오렌지+칼->오렌지 개수" + stage1_countManage.ingredientCount[24]);

            if (stage1_countManage.ingredientCount[24] == 0)
            {
                stage1_FruitButManage.AllusedOrange();
                scriptIngredient.touchedWithTools[12].SetActive(false);
            }
        }
        else if (touchedName == "touchedStrawberry_chop")
        {
            Clone = Instantiate(platedStrawberry_chop, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[25]--;
            Debug.Log("딸기+칼->딸기 개수" + stage1_countManage.ingredientCount[25]);

            if (stage1_countManage.ingredientCount[25] == 0)
            {
                stage1_FruitButManage.AllusedStrawberry();
                scriptIngredient.touchedWithTools[13].SetActive(false);
            }
        }
        else if (touchedName == "touchedBlueberry_juice")
        {
            //착즙
            DecoCreate(touchedName);
            stage1_countManage.ingredientCount[21]--;
            Debug.Log("블루베리+착즙기->블루베리 개수" + stage1_countManage.ingredientCount[21]);

            if (stage1_countManage.ingredientCount[21] == 0)
            {
                stage1_FruitButManage.AllusedBlueberry();
                scriptIngredient.touchedIngredients[21].SetActive(false);
            }
        }
        else if (touchedName == "touchedOrange_juice")
        {
            //착즘
            DecoCreate(touchedName);
            stage1_countManage.ingredientCount[24]--;
            Debug.Log("오렌지+착즙기->오렌지 개수" + stage1_countManage.ingredientCount[24]);

            if (stage1_countManage.ingredientCount[24] == 0)
            {
                stage1_FruitButManage.AllusedOrange();
                scriptIngredient.touchedWithTools[12].SetActive(false);
            }
        }
        else if (touchedName == "touchedStrawberry_juice")
        {
            //착즘
            DecoCreate(touchedName);
            stage1_countManage.ingredientCount[25]--;
            Debug.Log("딸기+착즙기->딸기 개수" + stage1_countManage.ingredientCount[25]);

            if (stage1_countManage.ingredientCount[25] == 0)
            {
                stage1_FruitButManage.AllusedStrawberry();
                scriptIngredient.touchedWithTools[13].SetActive(false);
            }
        }
        /*--------------------------------------------------유제품-----------------------------------------------*/

        else if (touchedName == "touchedCheddarcheese")
        {
            if (currentPlatedBase == "Ivy")
            {
                Clone = Instantiate(platedCheddarcheese_s, objPosition, Quaternion.identity);
                Clone.transform.SetParent(platedParent.transform);
            }
            else
            {
                Clone = Instantiate(platedCheddarcheese, objPosition, Quaternion.identity);
                Clone.transform.SetParent(platedParent.transform);
            }
            stage1_countManage.ingredientCount[26]--;
            Debug.Log("체다치즈" + stage1_countManage.ingredientCount[26]);

            if (stage1_countManage.ingredientCount[26] == 0)
            {
                stage1_DairyButManage.AllusedCheddarcheese();
                scriptIngredient.touchedIngredients[26].SetActive(false);
            }
        }
        else if (touchedName == "touchedCheese")
        {
            if (currentPlatedBase == "Ivy")
            {
                Clone = Instantiate(platedCheese_s, objPosition, Quaternion.identity);
                Clone.transform.SetParent(platedParent.transform);
            }
            else
            {
                Clone = Instantiate(platedCheese, objPosition, Quaternion.identity);
                Clone.transform.SetParent(platedParent.transform);
            }
            stage1_countManage.ingredientCount[27]--;
            Debug.Log("치즈" + stage1_countManage.ingredientCount[27]);

            if (stage1_countManage.ingredientCount[27] == 0)
            {
                stage1_DairyButManage.AllusedCheese();
                scriptIngredient.touchedIngredients[27].SetActive(false);
            }
        }
        else if (touchedName == "touchedMozzacheese")
        {
            if (currentPlatedBase == "Ivy")
            {
                Clone = Instantiate(platedMozzacheese_s, objPosition, Quaternion.identity);
                Clone.transform.SetParent(platedParent.transform);
            }
            else
            {
                Clone = Instantiate(platedMozzacheese, objPosition, Quaternion.identity);
                Clone.transform.SetParent(platedParent.transform);
            }
            stage1_countManage.ingredientCount[28]--;
            Debug.Log("모짜렐라치즈" + stage1_countManage.ingredientCount[28]);

            if (stage1_countManage.ingredientCount[28] == 0)
            {
                stage1_DairyButManage.AllusedMozzacheese();
                scriptIngredient.touchedIngredients[28].SetActive(false);
            }
        }
        else if (touchedName == "touchedCream")
        {
            DecoCreate(touchedName);
            stage1_countManage.ingredientCount[29]--;
            Debug.Log("생크림남은횟수" + stage1_countManage.ingredientCount[29]);
            if (stage1_countManage.ingredientCount[29] == 0)
            {
                stage1_DairyButManage.AllusedCream();
                scriptIngredient.touchedIngredients[29].SetActive(false);
            }
        }
        else if (touchedName == "touchedIcecream")
        {
            Clone = Instantiate(platedIcecream, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[30]--;
            Debug.Log("아이스크림" + stage1_countManage.ingredientCount[30]);

            if (stage1_countManage.ingredientCount[30] == 0)
            {
                stage1_DairyButManage.AllusedIcecream();
                scriptIngredient.touchedIngredients[30].SetActive(false);
            }
        }
        
        /*--------------------------------------------------데코-----------------------------------------------*/
        else if (touchedName == "touchedCaramelsyrup")
        {
            DecoCreate(touchedName);
            stage1_countManage.ingredientCount[31]--;
            Debug.Log("카라멜시럽남은횟수" + stage1_countManage.ingredientCount[31]);
            if (stage1_countManage.ingredientCount[31] == 0)
            {
                stage1_DecoButManage.AllusedCaramelsyrup();
                scriptIngredient.touchedIngredients[31].SetActive(false);
            }
        }
        else if (touchedName == "touchedChocosyrup")
        {
            DecoCreate(touchedName);
            stage1_countManage.ingredientCount[32]--;
            Debug.Log("초코시럽남은횟수" + stage1_countManage.ingredientCount[32]);
            if (stage1_countManage.ingredientCount[32] == 0)
            {
                stage1_DecoButManage.AllusedChocosyrup();
                scriptIngredient.touchedIngredients[32].SetActive(false);
            }
        }
        else if (touchedName == "touchedKetchup")
        {
            DecoCreate(touchedName);
            stage1_countManage.ingredientCount[33]--;
            Debug.Log("케찹남은횟수" + stage1_countManage.ingredientCount[33]);
            if (stage1_countManage.ingredientCount[33] == 0)
            {
                stage1_DecoButManage.AllusedKetchup();
                scriptIngredient.touchedIngredients[33].SetActive(false);
            }
        }
        else if (touchedName == "touchedMayonnaise")
        {
            DecoCreate(touchedName);
            stage1_countManage.ingredientCount[34]--;
            Debug.Log("마요네즈남은횟수" + stage1_countManage.ingredientCount[34]);
            if (stage1_countManage.ingredientCount[34] == 0)
            {
                stage1_DecoButManage.AllusedMayonnaise();
                scriptIngredient.touchedIngredients[34].SetActive(false);
            }
        }
        else if (touchedName == "touchedGochujang")
        {
            if (currentPlatedBase == "noodle")
            {
                platedNoodle_Clone = GameObject.Find("platedNoodle(Clone)");
                //국수가 올려진 상태이면 -> 빨간국수로 바꾸기
                // platedNoodle_Clone.GetComponent<SpriteRenderer>().sprite = Resources.Load("Plated_W_Tools/platedNoodle_gochujang", typeof(Sprite)) as Sprite;
                Destroy(platedNoodle_Clone);
                Clone = Instantiate(platedNoodle_gochujang, platePosition, Quaternion.identity);
                Clone.transform.SetParent(platedParent.transform);
                stage1_countManage.ingredientCount[35]--;
                if (stage1_countManage.ingredientCount[35] == 0)
                {
                    stage1_DecoButManage.AllusedGochujang();
                    scriptIngredient.touchedIngredients[35].SetActive(false);
                }
            }
            else
            {
                Clone = Instantiate(cant, objPosition, Quaternion.identity);
                Time.timeScale = 1;
                Invoke("destroyCant", 0.5f);
            }
        }
        else if (touchedName == "touchedIce")
        {
            Clone = Instantiate(platedIce, objPosition, Quaternion.identity);
            Clone.transform.SetParent(platedParent.transform);
            stage1_countManage.ingredientCount[36]--;
            Debug.Log("마요네즈남은횟수" + stage1_countManage.ingredientCount[36]);
            if (stage1_countManage.ingredientCount[36] == 0)
            {
                stage1_DecoButManage.AllusedIce();
                scriptIngredient.touchedIngredients[36].SetActive(false);
            }
        }


    }
}
