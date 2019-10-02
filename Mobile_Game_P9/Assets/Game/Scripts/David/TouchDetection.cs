using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetection : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                Physics.Raycast(ray, out hit);
                if (hit.collider.tag == "EmptyFloor")
                {
                    hit.collider.gameObject.GetComponent<EmptyFloor>().Touched();
                }
                if (hit.collider.tag == "EmptyPlatform")
                {
                    hit.collider.gameObject.GetComponent<EmptyPlatform>().Touched();
                }
            }
            
        }
        
    }
}
