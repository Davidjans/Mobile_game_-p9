using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPlatform : MonoBehaviour
{
    private MatchManager m_MatchManager;
    [SerializeField] private GameObject m_FullPlatform;
    [SerializeField] private GameObject m_ArcherTower;
    [SerializeField] private GameObject m_MageTower;
    [SerializeField] private GameObject m_BombTower;
    private void Start()
    {
        m_MatchManager = GameObject.Find("MatchManager").GetComponent<MatchManager>();
    }

    public void Touched()
    {

        if (m_MatchManager.m_CurrentTower != 0 && m_MatchManager.m_Towers[m_MatchManager.m_CurrentTower].m_TowerCost <= m_MatchManager.m_Money)
        {
            m_FullPlatform.SetActive(true);
            if(m_MatchManager.m_CurrentTower == 1)
            {
                m_ArcherTower.SetActive(true);
            }
            else if (m_MatchManager.m_CurrentTower == 2)
            {
                m_MageTower.SetActive(true);
            }
            else if (m_MatchManager.m_CurrentTower == 3)
            {
                m_BombTower.SetActive(true);
            }
            m_MatchManager.m_Money -= m_MatchManager.m_Towers[m_MatchManager.m_CurrentTower].m_TowerCost;
            gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Touched();
        }
    }
}
