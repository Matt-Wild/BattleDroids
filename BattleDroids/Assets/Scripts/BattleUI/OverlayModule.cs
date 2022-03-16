using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayModule : MonoBehaviour
{

    Module m_module;

    public Module GetModule()
    {
        return m_module;
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    public void SetModule(Module _module)
    {
        m_module = _module;
        gameObject.GetComponent<RawImage>().texture = m_module.GetIcon();
    }

    public void SetPosition(Vector3 _position)
    {
        gameObject.transform.position = _position;
    }
}
