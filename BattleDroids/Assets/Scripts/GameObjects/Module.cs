using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : Destructible
{
    [SerializeField]
    protected string m_name ="Module";

    protected Drone m_host;

    public string GetName()
    {
        return m_name;
    }

    public void SetName(string _name)
    {
        m_name = _name;
    }

    public void SetHost(Drone _drone)
    {
        m_host = _drone;
    }
}
