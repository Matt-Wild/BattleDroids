using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerModule : Module
{
    [SerializeField]
    protected float m_powerOutput = 1.0f;

    public float GetPowerOutput()
    {
        return m_powerOutput;
    }

    public void SetPowerOutput(float _output)
    {
        m_powerOutput = _output;
    }
}
