using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyFloor : MonoBehaviour
{
    private MatchManager m_MatchManager;
    [SerializeField] private GameObject m_EmptyPlatform;
    private void Start()
    {
        m_MatchManager = GameObject.Find("MatchManager").GetComponent<MatchManager>();
    }

    public void Touched()
    {
        
        if(m_MatchManager.m_CurrentTower == 0 && m_MatchManager.m_Platforms >= 1)
        {
            m_EmptyPlatform.SetActive(true);
            m_MatchManager.m_Platforms--;
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
