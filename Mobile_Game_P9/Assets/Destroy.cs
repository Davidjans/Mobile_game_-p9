using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyThis", 2.5f);
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
