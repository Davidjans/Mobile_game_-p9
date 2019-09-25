using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform m_EnemyGoal;
    [HideInInspector] public NavMeshAgent m_EnemyNavMesh;
    private void Start()
    {
        m_EnemyNavMesh = GetComponent<NavMeshAgent>();
        m_EnemyNavMesh.destination = m_EnemyGoal.position;
    }
}
