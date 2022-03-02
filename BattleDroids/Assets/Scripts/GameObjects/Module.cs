﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : Destructible
{
    [SerializeField]
    protected string m_name = "Module";

    protected Droid m_host;

    public string GetName()
    {
        return m_name;
    }

    public Droid GetHost()
    {
        return m_host;
    }

    public void SetName(string _name)
    {
        m_name = _name;
    }

    public void SetHost(Droid _droid)
    {
        m_host = _droid;
    }
}
