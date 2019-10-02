using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float m_Money;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(float moneyGained)
    {
        m_Money += moneyGained;
    }

    public void RemoveMoney(float moneyLost)
    {
        m_Money -= moneyLost;
    }
}
