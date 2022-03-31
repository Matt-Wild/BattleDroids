using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : Destructible
{
    protected Droid m_host;
    protected Texture m_icon;
    protected bool m_targeted = false;

    [SerializeField]
    protected string m_name = "Module";

    void OnEnable()
    {
        m_icon = Resources.Load<Texture2D>("Textures/Modules/default");
    }

    public override float Damage(float _amount)
    {
        base.Damage(_amount);
        m_host.SpawnPopup(_amount);

        return _amount;
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

    public bool GetTargeted()
    {
        return m_targeted;
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

    public void SetTargeted(bool _targeted)
    {
        m_targeted = _targeted;
    }
}
