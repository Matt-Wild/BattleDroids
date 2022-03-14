using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleSelector : MonoBehaviour
{
    GameObject m_canvas;
    Droid m_host;

    void Awake()
    {
        m_canvas = gameObject;
        Disable();
    }

    public void Enable()
    {
        m_canvas.SetActive(true);
    }

    public void Disable()
    {
        m_canvas.SetActive(false);
    }

    public Droid GetHost()
    {
        return m_host;
    }

    public void SetHost(Droid _droid)
    {
        m_host = _droid;
        GameObject _droidGameObject = m_host.GetGameObject();
        Vector3 _position = _droidGameObject.transform.position;
        _position.y += _droidGameObject.GetComponent<Collider>().bounds.size.y;
        m_canvas.transform.position = _position;
    }
}
