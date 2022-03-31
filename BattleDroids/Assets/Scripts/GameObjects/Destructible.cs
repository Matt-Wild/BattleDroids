using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : ScriptableObject
{
    [SerializeField]
    protected float m_durability = 100.0f, m_integrity = 100.0f;

    public virtual float Damage(float _amount)
    {
        m_integrity -= _amount;

        if (m_integrity < 0)
        {
            m_integrity = 0;
        }

        return m_integrity;
    }

    public float Repair(float _amount)
    {
        m_integrity += _amount;

        if (m_integrity > m_durability)
        {
            m_integrity = m_durability;
        }

        return m_integrity;
    }

    public float RepairFull()
    {
        m_integrity = m_durability;

        return m_integrity;
    }

    public float GetIntegrityPercent()
    {
        return m_integrity / m_durability;
    }

    public float GetDurability()
    {
        return m_durability;
    }

    public float GetIntegrity()
    {
        return m_integrity;
    }

    public void SetDurability(float _durability)
    {
        m_durability = _durability;
    }

    public void SetIntegrity(float _integrity)
    {
        m_integrity = _integrity;
    }
}
