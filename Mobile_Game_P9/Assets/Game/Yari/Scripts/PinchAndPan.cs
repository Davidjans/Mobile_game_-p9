using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchAndPan : MonoBehaviour
{
    private Vector3 touchStart;

    void Start()
    {
        
    }

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
            touchStart.z = Camera.main.nearClipPlane;
            touchStart = Camera.main.ScreenToWorldPoint(touchStart);
        }

        if (Input.GetMouseButton(0))
        {
            touchStart = Input.mousePosition;
            touchStart.z = Camera.main.nearClipPlane;
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
    }
}
