using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float m_MaxHealth;
    private float m_CurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHealth = m_MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetHit(float damage)
    {
        m_CurrentHealth -= damage;
    }
}
