using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour
{
    [SerializeField] private MatchManager m_MatchManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            m_MatchManager.m_Health -= other.GetComponent<EnemyHealth>().m_Damage;
            Destroy(other.gameObject);
        }
    }
}
