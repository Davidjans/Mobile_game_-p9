using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(Input.acceleration, ForceMode.Acceleration);
    }

    public void Restart()
    {
        SceneManager.LoadScene("AccelerometerTestScene");
    }
}
