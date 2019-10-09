using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> m_SpawnLocations;
    [SerializeField] private MatchManager m_MatchManager;
    [SerializeField] private List<WaveType> m_WaveTypes;
    [SerializeField] private float m_TimeBetweenWaves = 15;
    private WaveType m_CurrentWaveType;
    private float m_BetweenWaveTimer;
    private bool m_WaveOngoing = false;
    private int enemiesSpawned;
    private float m_TimeBetweenEnemies;
    // Start is called before the first frame update
    void Start()
    {
        m_BetweenWaveTimer = m_TimeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        StartWave();
        SpawnEnemy();
        if (m_WaveOngoing)
        {
            NextWave();
        }
    }

    private void NextWave()
    {
        if (m_MatchManager.m_Enemies.Count <= 0 && enemiesSpawned >= m_CurrentWaveType.m_EnemyPrefabs.Count)
        {
            m_BetweenWaveTimer = m_TimeBetweenWaves;
            m_MatchManager.m_Platforms += m_CurrentWaveType.m_PlatformsGained;
            m_MatchManager.m_CurrentWave++;
            m_WaveOngoing = false;
        }
    }
    private void StartWave()
    {
        if(m_WaveOngoing == false)
        {
            m_BetweenWaveTimer -= Time.deltaTime;
            if(m_BetweenWaveTimer <= 0)
            {
                if(m_MatchManager.m_CurrentWave >= m_WaveTypes.Count)
                {
                    m_CurrentWaveType = m_WaveTypes[m_WaveTypes.Count - 1];
                }
                else
                {
                    m_CurrentWaveType = m_WaveTypes[m_MatchManager.m_CurrentWave];
                }
                
                m_TimeBetweenEnemies = m_CurrentWaveType.m_TimeBetweenSpawns;
                enemiesSpawned = 0;
                m_WaveOngoing = true;
            }
        }
    }

    private void SpawnEnemy()
    {
        if (m_WaveOngoing)
        {
            m_TimeBetweenEnemies -= Time.deltaTime;  
            if(m_TimeBetweenEnemies <= 0 && m_CurrentWaveType.m_EnemyPrefabs.Count > 0 && enemiesSpawned < m_CurrentWaveType.m_EnemyPrefabs.Count)
            {
                int spawnposition = Random.Range(0, m_SpawnLocations.Count);
                
                GameObject enemy = Instantiate<GameObject>(m_CurrentWaveType.m_EnemyPrefabs[enemiesSpawned], m_SpawnLocations[spawnposition].position, m_SpawnLocations[spawnposition].rotation);
                m_MatchManager.m_Enemies.Add(enemy);
                m_MatchManager.m_EnemyNavMesh.Add(enemy.GetComponent<NavMeshAgent>());

                m_TimeBetweenEnemies = m_CurrentWaveType.m_TimeBetweenSpawns;
                enemiesSpawned++;
            }
        }
    }
}
