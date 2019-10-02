using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTilt : MonoBehaviour
{

    void Update()
    {
        Vector3 tilt = Input.acceleration;

        tilt = Quaternion.Euler(90, 0, 0) * tilt;        

        Quaternion startRotation = gameObject.transform.localRotation;

        Quaternion cameraTilt = Quaternion.Euler(startRotation.x += (tilt.y * 2f), startRotation.y += (tilt.x * 2f), startRotation.z);

        gameObject.transform.localRotation = Quaternion.Slerp(gameObject.transform.localRotation, cameraTilt, 0.3f);
    }
}
