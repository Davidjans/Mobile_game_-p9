using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public CameraShake cameraShake;
    private Rigidbody rb;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float shakeSensitivty = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Vector3 tilt = Input.acceleration;

        //tilt = Quaternion.Euler(90, 0, 0) * tilt;

        //rb.AddForce(tilt, ForceMode.Acceleration);

        //if (tilt.x > shakeSensitivty || tilt.x < shakeSensitivty * -1f)
        //{
        //    text.text = "SHAKE X";
        //    StartCoroutine(cameraShake.Shake(.15f, .4f));
        //}

        //if (tilt.z > shakeSensitivty || tilt.z < shakeSensitivty * -1f)
        //{
        //    text.text = "SHAKE Z";
        //    StartCoroutine(cameraShake.Shake(.15f, .4f));
        //}

        //Debug Code
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("AccelerometerTestScene");
    }
}
