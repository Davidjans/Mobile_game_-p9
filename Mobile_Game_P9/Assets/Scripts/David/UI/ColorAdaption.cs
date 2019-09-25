using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorAdaption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_Target;
    private TextMeshProUGUI m_Itself;
    // Start is called before the first frame update
    void Start()
    {
        m_Itself = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Itself.color = m_Target.color;
    }
}
