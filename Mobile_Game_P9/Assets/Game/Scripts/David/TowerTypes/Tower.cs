using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Tower")]
public class Tower : ScriptableObject
{
    [Tooltip("The cost of the tower.")]
    public int m_TowerCost;
}
