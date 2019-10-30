using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchDetection : MonoBehaviour
{
    private GameObject LastTouched;
    [SerializeField] private Material m_SelectedFloor;
    [SerializeField] private Material m_Floor;
    [SerializeField] private Material m_SelectedCastle;
    [SerializeField] private Material m_Castle;
    [SerializeField] TextMeshProUGUI m_Debug1;
    [SerializeField] TextMeshProUGUI m_Debug2;
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                Physics.Raycast(ray, out hit);
                m_Debug1.text = hit.collider.tag;
                if (hit.collider.tag == "EmptyFloor")
                {
                    if (LastTouched != hit.collider.gameObject)
                    {
                        m_Debug1.text = hit.collider.gameObject.name;
                        if(LastTouched != null)
                        {
                            LastTouched.GetComponent<MeshRenderer>().material = m_Floor;
                        }
                        LastTouched = hit.collider.gameObject;
                        m_Debug2.text = LastTouched.name;
                        LastTouched.GetComponent<MeshRenderer>().material = m_SelectedFloor;
                    }
                    else if(LastTouched == hit.collider.gameObject){
                        LastTouched.GetComponent<MeshRenderer>().material = m_Floor;
                        hit.collider.gameObject.GetComponent<EmptyFloor>().Touched();
                        LastTouched = null;
                    }
                }
                if (hit.collider.tag == "EmptyPlatform")
                {
                    Debug.Log(LastTouched);
                    if (LastTouched != hit.collider.gameObject)
                    {
                        Debug.Log("shouldwork");
                        LastTouched.GetComponent<MeshRenderer>().material = m_Castle;
                        LastTouched = hit.collider.gameObject.GetComponent<GameObject>();
                        LastTouched.GetComponent<MeshRenderer>().material = m_SelectedCastle;
                    }
                    else if (LastTouched == hit.collider.gameObject)
                    {
                        LastTouched.GetComponent<MeshRenderer>().material = m_Castle;
                        hit.collider.gameObject.GetComponent<EmptyPlatform>().Touched();
                        LastTouched = null;
                    }
                }
            }
            
        }
        
    }
}
