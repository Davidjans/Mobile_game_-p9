using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject ObjectToSpawn;
    private void OnDestroy()
    {
        Instantiate(ObjectToSpawn, transform.position, transform.rotation);
    }
}
