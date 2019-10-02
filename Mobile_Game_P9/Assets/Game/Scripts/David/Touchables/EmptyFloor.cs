using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyFloor : MonoBehaviour
{
    private MatchManager m_MatchManager;
    [SerializeField] private GameObject m_EmptyPlatform;
    [SerializeField] private GameObject m_ValidCheckPlatform;
    private bool m_Clickedon = false;
    private float m_Timer = 0.02f;
    private void Start()
    {
        m_MatchManager = GameObject.Find("MatchManager").GetComponent<MatchManager>();
    }

    private void Update()
    {
        if (m_Clickedon)
        {
            m_Timer -= Time.deltaTime;
            if(m_Timer <= 0)
            {
                bool isValid = m_MatchManager.TestReachable();
                if (isValid)
                {
                    m_ValidCheckPlatform.SetActive(false);
                    m_EmptyPlatform.SetActive(true);
                    m_MatchManager.m_Platforms--;
                    m_Clickedon = false;
                }
                else
                {
                    Debug.Log("HI");
                    m_Clickedon = false;
                    m_Timer = 1;
                    m_ValidCheckPlatform.SetActive(false);
                }
            }
        }
    }

    public void Touched()
    {
        
        if(m_MatchManager.m_CurrentTower == 0 && m_MatchManager.m_Platforms >= 1)
        {
            m_ValidCheckPlatform.SetActive(true);
            m_Clickedon = true;
            
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
