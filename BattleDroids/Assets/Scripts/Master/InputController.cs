using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    Material m_droidDefault, m_droidGlow, m_enemyGlow;

    Droid m_targetDroid;
    Module m_targetModule;

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

        if (m_targetDroid)
        {
            if (!m_targetDroid.GetTargeted())
            {
                m_targetDroid.Detarget();
                m_targetDroid = null;
            }
        }

        if (m_targetModule)
        {
            if (!m_targetModule.GetTargeted())
            {
                m_targetModule.SetTargeted(false);
                m_targetModule = null;
            }
        }
    }

    void UpdateTargetDroid(GameObject _newTarget)
    {
        if (m_targetDroid)
        {
            if (m_targetDroid == _newTarget.GetComponent<Droid>())
            {
                m_targetDroid.transform.Find("Body").GetComponent<MeshRenderer>().material = m_droidDefault;
                m_targetDroid.GetModuleSelector().Disable();
                m_targetDroid.Detarget();

                m_targetDroid = null;
                return;
            }

            m_targetDroid.transform.Find("Body").GetComponent<MeshRenderer>().material = m_droidDefault;
            m_targetDroid.GetModuleSelector().Disable();
            m_targetDroid.Detarget();
        }

        m_targetDroid = _newTarget.GetComponent<Droid>();
        m_targetDroid.GetModuleSelector().Enable();
        m_targetDroid.SetTargeted(true);

        if (m_targetDroid.GetEnemy())
        {
            m_targetDroid.transform.Find("Body").GetComponent<MeshRenderer>().material = m_enemyGlow;
        }
        else
        {
            m_targetDroid.transform.Find("Body").GetComponent<MeshRenderer>().material = m_droidGlow;
        }

        ClearTargetModule();
    }

    public void ClearTargetModule()
    {
        if (m_targetModule)
        {
            m_targetModule.SetTargeted(false);
            m_targetModule = null;
        }
    }

    public Droid GetTargetDroid()
    {
        return m_targetDroid;
    }

    public Module GetTargetModule()
    {
        return m_targetModule;
    }

    public void SetTargetDroid(Droid _droid)
    {
        m_targetDroid = _droid;
    }

    public void SetTargetModule(Module _module)
    {
        ClearTargetModule();

        m_targetModule = _module;
        m_targetModule.SetTargeted(true);
    }
}
