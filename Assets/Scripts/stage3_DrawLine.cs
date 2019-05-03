using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3_DrawLine : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 mousePosition;
    [SerializeField] private bool simplifyLine = false;
    [SerializeField] private float simplifyTolerance = 0.02f;

    GameObject plate;


    private void Start()
    {
        line = GetComponent<LineRenderer>();
        plate = GameObject.Find("Plate");
    }


    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = stage3_Plating.zPos + (float)0.1;
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (simplifyLine)
            {
                line.Simplify(simplifyTolerance);
            }

            enabled = false;
        }
    }
}
