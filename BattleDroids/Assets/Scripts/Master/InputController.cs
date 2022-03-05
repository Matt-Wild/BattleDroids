using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    Material m_droidDefault, m_droidGlow;

    Droid m_targetDroid;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Droid")
                {
                    UpdateTargetDroid(hit.transform.gameObject);
                }    
            }
        }
    }

    void UpdateTargetDroid(GameObject _newTarget)
    {
        if (m_targetDroid)
        {
            if (m_targetDroid == _newTarget.GetComponent<Droid>())
            {
                m_targetDroid.GetComponent<MeshRenderer>().material = m_droidDefault;

                m_targetDroid = null;
                return;
            }

            m_targetDroid.GetComponent<MeshRenderer>().material = m_droidDefault;
        }

        m_targetDroid = _newTarget.GetComponent<Droid>();

        m_targetDroid.GetComponent<MeshRenderer>().material = m_droidGlow;
    }
}
