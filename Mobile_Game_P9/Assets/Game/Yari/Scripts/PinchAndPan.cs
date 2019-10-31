using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchAndPan : MonoBehaviour
{
    [SerializeField] private float perspectiveZoomSpeed = 0.5f, orthoZoomSpeed = 0.5f, groundZ = 0;
    [SerializeField] private GameObject camHolder;

    private Camera cam;
    private Vector3 camHolderPos;

    private Vector3 touchStart;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        //Zooming
        if (Input.touchCount == 2)
        {
            //Store Touches In Vars
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            //Get The Previous Touch Pos
            Vector2 touchZeroPreviousPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePreviousPos = touchOne.position - touchOne.deltaPosition;

            //Get The Vector Difference Between The Two
            float prevTouchDelta = (touchZeroPreviousPos - touchOnePreviousPos).magnitude;
            float touchDelta = (touchZero.position - touchOne.position).magnitude;

            //Gets The Difference Between The Touches
            float deltaDifference = prevTouchDelta - touchDelta;

            if (Camera.main.orthographic)
            {
                Camera.main.orthographicSize += deltaDifference * orthoZoomSpeed;
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
            }
            else
            {
                Camera.main.fieldOfView += deltaDifference * perspectiveZoomSpeed;
                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 20f, 80f);
            }
        }

        //Panning
        if(Input.touchCount < 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchStart = GetWorldPosition(groundZ);
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 direction = touchStart - GetWorldPosition(groundZ);                

                camHolder.transform.position += new Vector3(direction.x, 0, direction.y);
            }

            
        }
    }

    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);

        Plane ground = new Plane(camHolder.transform.forward, new Vector3(0, z, 0));

        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }
}