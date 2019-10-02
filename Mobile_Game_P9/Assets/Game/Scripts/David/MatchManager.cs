using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MatchManager : MonoBehaviour
{
    public int m_Money = 65;
    public int m_Platforms = 5;
    public List<Tower> m_Towers;
    public int m_CurrentTower = 0;
    public int m_CurrentWave;

    public List<GameObject> m_Enemies;
    public List<NavMeshAgent> m_EnemyNavMesh;
    public List<float> m_DistanceToEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RemoveAllDeadEnemies();
        CheckWhoIsFarthest();
    }

    private void CheckWhoIsFarthest()
    {
        for (int i = 0; i < m_EnemyNavMesh.Count; i++)
        {
            m_DistanceToEnd.Add(m_EnemyNavMesh[i].remainingDistance);
        }
    }

    private void RemoveAllDeadEnemies()
    {
        for (int i = 0; i < m_Enemies.Count; i++)
        {
            if(m_Enemies[i] == null)
            {
                m_Enemies.RemoveAt(i);
                m_EnemyNavMesh.RemoveAt(i);
                m_DistanceToEnd.RemoveAt(i);
                i--;    
            }
        }
    }
}
