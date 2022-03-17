using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerModule : Module
{
    [SerializeField]
    protected float m_basePowerOutput = 1.0f;

    void OnEnable()
    {
        m_icon = Resources.Load<Texture2D>("Textures/Modules/powerModule");
    }

    public float GetPowerOutput()
    {
        return m_basePowerOutput * GetIntegrityPercent();
    }

    public void SetBasePowerOutput(float _output)
    {
        m_basePowerOutput = _output;
    }
}
