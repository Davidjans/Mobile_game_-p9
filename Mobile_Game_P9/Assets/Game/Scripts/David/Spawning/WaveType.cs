using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wavetype", menuName = "WaveType")]
public class WaveType : ScriptableObject
{
    [Tooltip("The types of enemies that should be spawned in the order they will be spawned.")]
    public List<GameObject> m_EnemyPrefabs;
    [Tooltip("The ammount of seconds between enemy spawns.")]
    public float m_TimeBetweenSpawns;
    [Tooltip("The ammount of platforms gained after completing the wave.")]
    public int m_PlatformsGained;
    private void Awake()
    {
        
    }
}
