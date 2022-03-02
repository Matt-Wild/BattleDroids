using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeModule : Module
{
    [SerializeField]
    protected float m_capacity = 100.0f, m_charge = 0.0f;

    public void Update()
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

    public float GetChargePercent()
    {
        return (float)m_charge / (float)m_capacity;
    }

    public float GetCapacity()
    {
        return m_capacity;
    }

    public float GetCharge()
    {
        return m_charge;
    }

    public void SetCapacity(float _capacity)
    {
        m_capacity = _capacity;
    }

    public void SetCharge(float _charge)
    {
        m_charge = _charge;
    }
}
