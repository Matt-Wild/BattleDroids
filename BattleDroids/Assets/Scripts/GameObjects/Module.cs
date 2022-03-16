using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : Destructible
{
    protected Droid m_host;
    protected Texture m_icon;

    [SerializeField]
    protected string m_name = "Module";

    void OnEnable()
    {
        m_icon = Resources.Load<Texture2D>("Textures/Modules/default");
    }

    public string GetName()
    {
        return m_name;
    }

    public Droid GetHost()
    {
        return m_host;
    }
    
    public Texture GetIcon()
    {
        return m_icon;
    }

    public void SetName(string _name)
    {
        m_name = _name;
    }

    public void SetHost(Droid _droid)
    {
        m_host = _droid;
    }

    public void SetIcon(Texture _texture)
    {
        m_icon = _texture;
    }
}
