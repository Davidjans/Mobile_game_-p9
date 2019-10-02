using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int m_Damage;
    [SerializeField] private float m_MaxHealth;
    [SerializeField] private Vector2Int m_GoldValue;
    
    private float m_CurrentHealth;
    private MatchManager m_MatchManager;
    // Start is called before the first frame update
    void Start()
    {
        m_CurrentHealth = m_MaxHealth;
        m_MatchManager = GameObject.Find("MatchManager").GetComponent<MatchManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_CurrentHealth <= 0)
        {
            m_MatchManager.m_Money += Random.Range(m_GoldValue.x, m_GoldValue.y);
            Destroy(gameObject);
        }
    }

    public void GetHit(float damage)
    {
        m_CurrentHealth -= damage;
    }
}
