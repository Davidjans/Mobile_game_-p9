using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EditorUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_Selected;
    [SerializeField] private TextMeshProUGUI m_MoneyText;
    [SerializeField] private TextMeshProUGUI m_PlatformText;
    [SerializeField] private TextMeshProUGUI m_CostText;
    [SerializeField] private MatchManager m_MatchManager;
    // Update is called once per frame
    void Update()
    {
        m_MoneyText.text = m_MatchManager.m_Money.ToString();
        m_PlatformText.text = m_MatchManager.m_Platforms.ToString();
        if (m_MatchManager.m_CurrentTower == 0)
        {
            m_CostText.text = m_MatchManager.m_Towers[m_MatchManager.m_CurrentTower].m_TowerCost.ToString() + " Platform";
            if(m_MatchManager.m_Towers[m_MatchManager.m_CurrentTower].m_TowerCost <= m_MatchManager.m_Platforms)
            {
                m_CostText.color = Color.green;
            }
            else
            {
                m_CostText.color = Color.red;
            }
        }
        else
        {
            m_CostText.text = m_MatchManager.m_Towers[m_MatchManager.m_CurrentTower].m_TowerCost.ToString() + " Dough";
            if (m_MatchManager.m_Towers[m_MatchManager.m_CurrentTower].m_TowerCost <= m_MatchManager.m_Money)
            {
                m_CostText.color = Color.green;
            }
            else
            {
                m_CostText.color = Color.red;
            }
        }

        
        ResetSeleceted();
        if (m_MatchManager.m_CurrentTower == 0)
        {
            m_Selected[0].SetActive(true);
        }
        else if (m_MatchManager.m_CurrentTower == 1)
        {
            m_Selected[1].SetActive(true);
        }
        else if (m_MatchManager.m_CurrentTower == 2)
        {
            m_Selected[2].SetActive(true);
        }
        else if (m_MatchManager.m_CurrentTower == 3)
        {
            m_Selected[3].SetActive(true);
        }
        else if (m_MatchManager.m_CurrentTower == 4)
        {
            m_Selected[4].SetActive(true);
        }
        else if (m_MatchManager.m_CurrentTower == 5)
        {
            m_Selected[5].SetActive(true);
        }
    }

    private void ResetSeleceted()
    {
        for (int i = 0; i < m_Selected.Count; i++)
        {
            m_Selected[i].SetActive(false);
        }
    }
}