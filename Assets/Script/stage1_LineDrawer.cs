using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// © 2018 TheFlyingKeyboard and released under MIT License 
// theflyingkeyboard.net 

public class stage1_LineDrawer : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 mousePosition;

    [SerializeField] private bool simplifyLine = false;
    [SerializeField] private float simplifyTolerance = 0.02f;

    private Vector3 mousePos;
    private Vector3 startPos;    // Start position of line
    private Vector3 endPos;
    private GameObject platedParent;
    float maxX = 0;
    float minX = 0;
    float minY = 0;
    float maxY = 0;

   
    // public GameObject Collider;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
        platedParent = GameObject.Find("platedParent");
        //Collider = GameObject.Find("Collider");

    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) //Or use GetKey with key defined with mouse button
        {
            //stage1_plating.layerOrder--;
             Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            objPosition.z = stage1_plating.layerOrder;
          

            line.positionCount++;
            line.SetPosition(line.positionCount - 1, objPosition);
           
            //if (objPosition.x > maxX) maxX = objPosition.x;
            //if (objPosition.x < minX) minX = objPosition.x;
            //if (objPosition.y < minY) minY = objPosition.y;
            //if(objPosition.y > maxY) maxY = objPosition.y;

        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            objPosition.z = stage1_plating.layerOrder;
            endPos = objPosition;
            addColliderToLine();
            if (simplifyLine)
            {             
                line.Simplify(simplifyTolerance);
               
            }

            enabled = false; //Making this script stop
        }
    }
  
    private void addColliderToLine()
    {
        startPos = stage1_plating.startpos;//원콜라이더하나만들때

        // BoxCollider col = new GameObject("Collider").AddComponent<BoxCollider>();
       // BoxCollider col = line.gameObject.AddComponent<BoxCollider>();
        PolygonCollider2D col = line.gameObject.AddComponent<PolygonCollider2D>();
     
        col.gameObject.AddComponent<stage1_tissueManage>();
        col.transform.parent = line.transform; // Collider is added as child object of line

        float lineLength = Vector3.Distance(startPos, endPos); // length of line
       // col.size = new Vector3(lineLength, 0.1f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
       // col.size = new Vector3(endPos.x-startPos.x, endPos.y - startPos.y, stage1_plating.layerOrder);
        //col.size = new Vector3(lineLength, 0.1f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
      //  col.size = new Vector3(maxX-minX, maxY-minY, 0);
        

        // Vector3 midPoint = (startPos + endPos) / 2;
        //  col.transform.position = midPoint; // setting position of collider object
        Vector3 midPoint =new Vector3 ((maxX + minX) / 2, (maxY + minY) / 2,(float) stage1_plating.layerOrder);
        //col.transform.position = midPoint;
        // Following lines calculate the angle between startPos and endPos
        float angle = (Mathf.Abs(startPos.y -endPos.y) / Mathf.Abs(startPos.x - endPos.x));
        if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
        {
            angle *= -1;
        }
        // angle = Mathf.Rad2Deg * Mathf.Atan(angle);
        //  col.transform.Rotate(0, 0, angle);
        // col.GetComponent<CircleCollider2D>().enabled = false;
        Debug.Log(col.transform.position.z);
        col.GetComponent<PolygonCollider2D>().enabled = false;
       // col.GetComponent<BoxCollider>().enabled = false;
    }
}