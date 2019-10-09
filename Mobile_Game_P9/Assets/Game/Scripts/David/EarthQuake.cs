using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuake : MonoBehaviour
{
    [SerializeField] private float m_EQDamage;
    [SerializeField] private MatchManager m_MatchManager;

    private void ShakeItBaby()
    {
        for (int i = 0; i < m_MatchManager.m_Enemies.Count; i++)
        {
            m_MatchManager.m_Enemies[i].GetComponent<EnemyHealth>().TakeDamage(m_EQDamage);
        }
    }
}
