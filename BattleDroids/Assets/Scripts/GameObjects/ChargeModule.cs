using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeModule : Module
{
    [SerializeField]
    protected float m_capacity = 100.0f, m_charge = 0.0f;

    void Update()
    {
        float _powerGeneration = m_host.GetPowerOuput();

        AddCharge(_powerGeneration * Time.deltaTime);
    }

    public float AddCharge(float _amount)
    {
        m_charge += _amount;

        if (m_charge > m_capacity)
        {
            m_charge = m_capacity;
        }

        return m_charge;
    }
}
