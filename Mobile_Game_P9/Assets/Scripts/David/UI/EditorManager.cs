using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EditorManager : MonoBehaviour
{
    [SerializeField] private MatchManager m_MatchManager;

    public void SelectedTower(int selectedTower)
    {
        m_MatchManager.m_CurrentTower = selectedTower;
    }
}
